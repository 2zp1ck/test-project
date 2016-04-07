using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //подключаем системное пространство имен, к которому обращаемся в массиве musicFiles
using Microsoft.Win32; //подключаем системное пространство имен для обращения к классу RegistryKey

namespace WinFormsPlayer
{
    static class Storage //создание статического класса, через который формы будут взаимодействовать друг с другом (обмениваться данными)
    {
        //создаем строковый массив (List) со списком файлов
        static public List<string> listMusic = new List<string>(); //указание "public" позволяет получать доступ из других классов

        static public int gameDuration = 60; //задаем продолжительность игры
        static public int musicDuration = 10; //задаем продолжительность звучания композиции
        static public bool randomStart = false; //проигрывание трека с начала или со случайного места
        static public string lastFolder = ""; //сохраняем последнюю выбранную папку
        static public bool allDirectories = false; //обработка вложенных папок
        static public string answer = ""; //переменная для передачи названия песни, которая проигрывается в данный момент

        static public void ReadMusic() //статический публичный метод
        {
            try
            {
                //создаем строковый массив со списком песен
                string[] musicFiles = Directory.GetFiles(lastFolder, "*.mp3", allDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                //если allDirectories = true, то AllDirectories - обработка внутренних директорий, иначе TopDirectoryOnly - только верхняя директория

                listMusic.Clear(); //очистка списка
                listMusic.AddRange(musicFiles); //обращаемся к публичному элементу listMusic, используя данные из массива musicFiles
            }
            catch
            { 
                //если массив не создан, то ничего не делать
            }
        }

        static string regKeyName = "Software\\2zp1ck_C#\\MusicPlayer"; //создаем ключ в реестре для записи параметров в реестр

        static public void WriteParam() //создаем функцию WriteParam для записи параметров в реестр
        {
            RegistryKey regKey = null; //создаем класс для работы с ключами реестра
            try
            { 
                regKey = Registry.CurrentUser.CreateSubKey(regKeyName); //создание вложенного ключа по указанному пути
                if (regKey == null) return; //если ключ не найден или недоступен, то возврат
                //если ключ не равен null, то записываем параметры ("название ключа внутри реестра", сохраняемые данные из значения)
                regKey.SetValue("LastFolder", lastFolder);
                regKey.SetValue("RandomStart", randomStart);
                regKey.SetValue("GameDuration", gameDuration);
                regKey.SetValue("MusicDuration", musicDuration);
                regKey.SetValue("AllDirectories", allDirectories);
            }
            //если в блоке try происходит ошибка (сбой при попытке записи параметров), управление передается в блок finally
            finally
            {
                if (regKey != null) regKey.Close(); //regKey не равен null, но так как данные не передались, то закрываем ключ
            }
        }

        static public void ReadParam() //создаем функцию ReadParam для чтения параметров из реестра
        {
            RegistryKey regKey = null; //создаем regKey для доступа к реестру
            try
            {
                regKey = Registry.CurrentUser.OpenSubKey(regKeyName); //пытаемся читать данные по указанному в regKeyName пути
                if (regKey != null) //если получили доступ к разделу (regKey не null), то считываем данные                
                {
                    lastFolder = (string)regKey.GetValue("LastFolder"); //GetValue по умолчанию возвращает тип object (общий тип для C#), приводим к нужному типу
                    randomStart = Convert.ToBoolean(regKey.GetValue("RandomStart", false));
                    gameDuration = (int)regKey.GetValue("GameDuration");
                    musicDuration = (int)regKey.GetValue("MusicDuration");
                    allDirectories = Convert.ToBoolean(regKey.GetValue("AllDirectories", false));
                }
            }
            //если в блоке try происходит ошибка (сбой при попытке чтения параметров), управление передается в блок finally
            finally
            {
                if (regKey != null) regKey.Close(); //regKey не равен null, но так как данные не прочитались, то закрываем ключ
            }
        }

    }
}
