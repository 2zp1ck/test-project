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
    public partial class fMessage : Form
    {
        int answerTime;
        
        public fMessage()
        {
            InitializeComponent();
        }

        private void fMessage_Load(object sender, EventArgs e) //при загрузке формы
        {
            answerTime = 10;
            timer1.Start(); //запуск таймера
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            answerTime--;
            lblAnswerTime.Text = answerTime.ToString(); //выводим в метку lblAnswerTime значение answerTime
            if (answerTime == 0) //если время на ответ равно нулю, то
            {
                timer1.Stop(); //остановка таймера
                SoundPlayer sp = new SoundPlayer("Resources\\xen_turret1.wav"); //путь к аудио-файлу
                sp.PlaySync(); //проигрываем аудио-файл
            }
        }

        private void fMessage_FormClosed(object sender, FormClosedEventArgs e) //при закрытии формы
        {
            timer1.Stop(); //остановка таймера
        }

        private void lblShowAnswer_Click(object sender, EventArgs e) //при клике на "Show Answer"
        {
            var mp3File = TagLib.File.Create(Storage.answer); //используем подключаемую библиотеку taglib-sharp для передачи тегов mp3-файла (http://xnotes.ru/notes/c-chtenie-id3-tegov-mp3-fayla)

            lblShowAnswer.Text = String.Join("/", mp3File.Tag.Performers) + " - " + mp3File.Tag.Title; //отображаем в lblShowAnswer имя исполнителя и название песни
        }        
    }
}
