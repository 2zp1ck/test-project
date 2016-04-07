using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsPlayer
{
    public partial class fMain : Form
    {
        fSettings fSet = new fSettings(); //создание единичного окна с настройками

        fGame fForGame = new fGame(); //создание единичного окна, отображаемого при нажатии "Game"

        public fMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); //цепляем на кнопку метод "закрыть форму"
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            //fSettings fSet = new fSettings(); //создаем форму с настройками (при каждом нажатии создается новое окно)
            fSet.ShowDialog(); //вызов модального окна
            //fSet.Show(); //вызов независимого окна
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            fForGame.ShowDialog(); //вызов модального окна fGame
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            Storage.ReadParam(); //считываем параметры из Storage при загрузке формы
            Storage.ReadMusic(); //вызываем метод ReadMusic из Storage при загрузке формы
        }
    }
}
