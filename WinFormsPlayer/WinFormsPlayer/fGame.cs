using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media; //подключаем системное пространство имен для обращения к классу SoundPlayer

namespace WinFormsPlayer
{
    public partial class fGame : Form
    {
        Random rnd = new Random(); //создаем переменную со случайным числом

        int musicDuration = Storage.musicDuration; //берем значение musicDuration из класса Storage

        bool[] players = new bool[2];
        
        public fGame()
        {
            InitializeComponent();
        }

        void MakeMusic() //функция для загадывания музыки
        {
            if (Storage.listMusic.Count == 0) GameOver(); //если в списке песен к-во песен равно нулю, то вызов функции GameOver
            //иначе продолжаем
            else
            {
                musicDuration = Storage.musicDuration; //присваиваем значение параметра musicDuration (продолжительность песни) из класса Storage

                int n = rnd.Next(0, Storage.listMusic.Count); //случайное число (0, количество песен в списке)
                WMP.URL = Storage.listMusic[n]; //обращаемся к n-му элементу списка listMusic класса Storage, используя WMP

                Storage.answer = WMP.URL;
                //Storage.answer = System.IO.Path.GetFileNameWithoutExtension(WMP.URL); //записываем в переменную answer класса Storage название файла, который проигрывается, без пути к нему и расширения

                //WMP.Ctlcontrols.play(); //автоматически запускать проигрыватель
                Storage.listMusic.RemoveAt(n); //удаление из списка ранее использованной песни
                lblTrackCounter.Text = Storage.listMusic.Count.ToString(); //показать к-во оставшихся песен в списке
                
                players[0] = false; //игрок 1 еше не нажимал кнопку
                players[1] = false; //игрок 2 еще не нажимал кнопку
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start(); //запуск таймера при клике на кнопку "Next Track"
            //WMP.URL = Storage.listMusic[0]; //обращаемся к нулевому элементу списка listMusic класса Storage, используя WMP
            MakeMusic(); //при нажатии "Next Track" вызываем функцию MakeMusic
        }

        private void fGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            //при закрытии формы
            timer1.Stop(); //остановка таймера
            WMP.Ctlcontrols.stop(); //остановка воспроизведения музыки в WMP
        }

        private void fGame_Load(object sender, EventArgs e)
        {
            lblTrackCounter.Text = Storage.listMusic.Count.ToString(); //отображение к-ва песен при загрузке формы
            progressBar1.Value = 0; //устанавливаем начальное значение прогресс-бара
            progressBar1.Minimum = 0; //устанавливаем минимальное значение прогресс-бара
            progressBar1.Maximum = Storage.gameDuration; //максимально значение прогресс-бара = продолжительности игры
            lblMusicDuration.Text = Storage.musicDuration.ToString(); //показываем в lblMusicDuration оставшееся до конца песни время
        }

        private void timer1_Tick(object sender, EventArgs e) //обработчик события для таймера
        {
            progressBar1.Value++; //увеличиваем значение прогресс-бара каждые 1000 мс
            musicDuration--;
            lblMusicDuration.Text = musicDuration.ToString(); //показываем в lblMusicDuration оставшееся до конца песни время
            if (progressBar1.Value == progressBar1.Maximum) //если значение прогресс-бара достигло максимума, то
            {
                GameOver(); //вызов функции
                return; //выход из функции
            }
            if (musicDuration == 0) MakeMusic(); //если время для угадывания песни = 0, то вызываем функцию MakeMusic (запуск следующего трека)
        }

        void GameOver() //функция для окончания игры
        {
            timer1.Stop(); //остановка таймера
            WMP.Ctlcontrols.stop(); //остановка воспроизведения музыки в WMP
        }

        private void btnPause_Click(object sender, EventArgs e) //при нажатии на кнопку "Pause"
        {
            GamePause(); //вызов функции
        }

        private void btnContinue_Click(object sender, EventArgs e) //при нажатии на кнопку "Continue"
        {
            GameContinue(); //вызов функции
        }

        void GamePause() //функция для паузы
        {
            timer1.Stop(); //остановка таймера
            WMP.Ctlcontrols.pause(); //воспроизведение музыки в WMP ставится на паузу
        }

        void GameContinue() //функция для продолжения
        {
            timer1.Start(); //запуск таймера
            WMP.Ctlcontrols.play(); //продолжение воспроизведения музыки в WMP
        }

        private void fGame_KeyDown(object sender, KeyEventArgs e) //обработчик для события "нажатие кнопки"
        {
            if (!timer1.Enabled) return; //если таймер не включен, то прерываем выполнение функции и не обрабатываем нажатия кнопок
            //для первого игрока
            if (players[0] == false && e.KeyData == Keys.A) //если игрок 1 еще не нажимал на кнопку и передалось "нажатие A", то
            {
                GamePause(); //игра ставится на паузу
                fMessage fMes = new fMessage(); //создание единичного окна для указания пользователем, верным ли был ответ

                fMes.lblMessage.Text = "Player 1"; //записываем текст в lblMessage в форме fMessage

                SoundPlayer sp1 = new SoundPlayer("Resources\\one.wav"); //путь к аудио-файлу
                sp1.PlaySync(); //проигрываем аудио-файл

                players[0] = true; //игрок 1 нажал на кнопку

                //if (MessageBox.Show("Right?", "Player 1", MessageBoxButtons.YesNo) == DialogResult.Yes) //если ответ правильный (нажата кнопка "Yes"), то
                if (fMes.ShowDialog() == DialogResult.Yes) //если в выпадающей форме нажать "Yes", то
                {
                    lblCounter1.Text = Convert.ToString(Convert.ToInt32(lblCounter1.Text) + 1); //увеличиваем на единицу значение в lblCounter1
                    MakeMusic(); //вызов функции MakeMusic, запуск следующей песни
                }
                GameContinue(); //продолжение игры
            }
            //для второго игрока
            if (players[1] == false && e.KeyData == Keys.L) //если игрок 2 еще не нажимал на кнопку и передалось "нажатие L", то
            {
                GamePause(); //игра ставится на паузу
                fMessage fMes = new fMessage(); //создание единичного окна для указания пользователем, верным ли был ответ

                fMes.lblMessage.Text = "Player 2"; //записываем текст в lblMessage в форме fMessage

                SoundPlayer sp2 = new SoundPlayer("Resources\\two.wav"); //путь к аудио-файлу
                sp2.PlaySync(); //проигрываем аудио-файл

                players[1] = true; //игрок 2 нажал на кнопку

                //if (MessageBox.Show("Right?", "Player 2", MessageBoxButtons.YesNo) == DialogResult.Yes) //если ответ правильный (нажата кнопка "Yes"), то
                if (fMes.ShowDialog() == DialogResult.Yes) //если в выпадающей форме нажать "Yes", то
                {
                    lblCounter2.Text = Convert.ToString(Convert.ToInt32(lblCounter2.Text) + 1); //увеличиваем на единицу значение в lblCounter2
                    MakeMusic(); //вызов функции MakeMusic, запуск следующей песни
                }
                GameContinue(); //продолжение игры
            }
            if (players[0] == true && players[1] == true) MakeMusic();
        }

        private void WMP_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e) //событие WMP - открытие
        {
            if (Storage.randomStart == true) //если значение randomStart в классе Storage равно true (проигрывание со случайного места), то
                if (WMP.openState == WMPLib.WMPOpenState.wmposMediaOpen) //если WMP открылся, то
                    WMP.Ctlcontrols.currentPosition = rnd.Next(0, (int)WMP.currentMedia.duration / 2); //начальная позиция для проигрывания - случайное число (0, середина трека); приводи duration к целому типу
        }

        private void lblCounter1_MouseClick(object sender, MouseEventArgs e) //обработчик для события "клик мышью на lblCounter1"
        {
            //если была нажата левая кнопка, то увеличиваем на единицу значение в lblCounter1
            if (e.Button == MouseButtons.Left) (sender as Label).Text = Convert.ToString(Convert.ToInt32((sender as Label).Text) + 1);
            //если была нажата правая кнопка, то уменьшаем на единицу значение в lblCounter1
            if (e.Button == MouseButtons.Right) (sender as Label).Text = Convert.ToString(Convert.ToInt32((sender as Label).Text) - 1);
        }
    }
}
