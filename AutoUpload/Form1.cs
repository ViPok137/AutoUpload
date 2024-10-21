using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUpload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Apload == true)
            {
                button3.Text = "ДА";
                AddToStartup(); // Добавить в автозагрузку при старте
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "ДА")
            {
                button3.Text = "НЕТ";
                Properties.Settings.Default.Apload = false;
                RemoveFromStartup(); // Удалить из автозагрузки
            }
            else
            {
                button3.Text = "ДА";
                Properties.Settings.Default.Apload = true;
                AddToStartup(); // Добавить в автозагрузку
            }
            Properties.Settings.Default.Save(); // Сохранение изменений
        }

        private void AddToStartup()
        {
            // Получаем путь к исполняемому файлу приложения
            string appName = Application.ProductName;
            string appPath = Application.ExecutablePath;

            // Добавляем запись в реестр
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue(appName, appPath);
            }
        }

        private void RemoveFromStartup()
        {
            string appName = Application.ProductName;

            // Удаляем запись из реестра
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.DeleteValue(appName, false);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(0 + 10000, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*",
                Title = "Выберите исполняемый файл"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                // Здесь вы можете добавить код для работы с выбранным файлом
                MessageBox.Show($"Вы выбрали файл: {selectedFilePath}");
            }
        }
    }
}