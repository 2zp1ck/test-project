using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO; //подключаем системное пространство имен, к которому будет обращаться приложение, чтобы не прописывать каждый раз System.IO

namespace WinFormsPlayer
{
    public partial class fSettings : Form
    {
        public fSettings()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //указываем, откуда брать параметры для игры, которые запишутся в Storage и в реестр
            Storage.allDirectories = cbSubfolder.Checked;
            Storage.gameDuration = Convert.ToInt32(cbGameDuration.Text);
            Storage.musicDuration = Convert.ToInt32(cbMusicDuration.Text);
            Storage.randomStart = chbRandomStart.Checked;
            Storage.WriteParam(); //обращаемя к методу WriteParam класса Storage при нажатии на "ОК"
            this.Hide(); //обработчик для кнопки "OK" - спрятать окно
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Set(); //при нажатии Cancel вызываем метод Set
            this.Hide(); //обработчик для кнопки "Cancel" - спрятать окно
        }

        void Set()
        {
            //берем значения по умолчанию из Storage
            cbSubfolder.Checked = Storage.allDirectories;
            cbGameDuration.Text = Storage.gameDuration.ToString();
            cbMusicDuration.Text = Storage.musicDuration.ToString();
            chbRandomStart.Checked = Storage.randomStart;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fBrD = new FolderBrowserDialog(); //вызов стандартной формы для выбора папки
            if (fBrD.ShowDialog() == DialogResult.OK) //если результат диалогового окна "OK"
            {
                /*//создаем массив из строк со списком песен, используем метод GetFiles для получения файлов из выбранной папки                
                //папка сохраняется в SelectedPath, берем файлы с определенным расширением
                //обработчик чекбокса: если нажат, то AllDirectories - обработка внутренних директорий, иначе TopDirectoryOnly - только верхняя директория*/

                //string[] musicList = System.IO.Directory.GetFiles(fBrD.SelectedPath, "*.mp3", cbSubfolder.Checked?System.IO.SearchOption.AllDirectories:System.IO.SearchOption.TopDirectoryOnly);

                string[] musicList = Directory.GetFiles(fBrD.SelectedPath, "*.mp3", cbSubfolder.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                Storage.lastFolder = fBrD.SelectedPath; //сохраняем в Storage выбранную папку с файлами
                listBox1.Items.Clear(); //очистить listBox
                listBox1.Items.AddRange(musicList); //помещение полученного списка на listBox

                Storage.listMusic.Clear();
                Storage.listMusic.AddRange(musicList); //обращаемся к публичному элементу listMusic созданного класса Storage для получения файлов
            }
        }

        private void fSettings_Load(object sender, EventArgs e)
        {
            Set(); //при загрузке формы вызываем метод Set, тем самым устанавливая значения по умолчанию из Storage
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Storage.listMusic.ToArray()); //при загрузке формы загружаем массив (список песен) из Storage

        }
    }
}
