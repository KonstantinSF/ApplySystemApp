using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplySystemApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Process process = new Process();
        string path = null; 
        public MainWindow()
        {
            InitializeComponent();
        }
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    commandSourse.Focus();
        //}
        private void cencel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        private void open_btn_Click(object sender, RoutedEventArgs e)
        {
            path=LoadPath();
            if (path != null)
            {
                commandSourse.Text = path;
                OkButton.IsEnabled = true;
            }
        }

        private string LoadPath()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "exe Files(*.exe)|*.exe",
                Title = "Выберите исполняемый файл", 
                Multiselect = false,
                CheckPathExists = true
            };
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        private void ok_btn_Click(object sender, RoutedEventArgs e)
        {
            process.StartInfo = new ProcessStartInfo(@commandSourse.Text);
            try
            {
                process.Start(); 
                this.Close();
            }
            catch
            {
                MessageBox.Show(this,"Ошибка, попробуйте еще раз", "Ошибка!");
                commandSourse.Text = null;
                commandSourse.Focus();
            }
        }

        private void commandSourse_textChanged(object sender, TextChangedEventArgs e)
        {
            if (commandSourse.Text !=null) OkButton.IsEnabled = true;
        }
    }
    
}
