using System;
using System.Collections.Generic;
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
using System.IO;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;

namespace FileOpenAndSave
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            // OpenFileDialog를 VistaOpenFileDialog로 그대로 바꿀 수 있다.
            //OpenFileDialog openFileDialog = new OpenFileDialog()
            VistaOpenFileDialog openFileDialog = new VistaOpenFileDialog()
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = "C:\\Users"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            VistaSaveFileDialog dialog = new VistaSaveFileDialog();
            dialog.Title = "Save your translation as..";
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                using(FileStream fs = new FileStream(dialog.FileName, FileMode.Create))
                {
                    using(StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        sw.Write(txtEditor.Text);
                        sw.Flush();
                    }
                }
            }
        }
    }
}
