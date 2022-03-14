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

namespace ICommand_Test2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        ICommand _clickCommand = new RelayCommand();
        public ICommand ClickCommand
        {
            get { return _clickCommand; }
        }

        public MainWindow()
        {
            InitializeComponent();
            ClickCommand.CanExecuteChanged += CanExecuteChanged_testfunc;
        }

        private void _txtBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            (_clickCommand as RelayCommand).FireChanged(_txtBox.Text.Length != 0);
        }

        private void CanExecuteChanged_testfunc(object sender, EventArgs arg)
        {
            MessageBox.Show($"CanExecuteChanged_testfunc 실행! {_txtBox.Text.Length != 0}");
        }
    }

    public class RelayCommand : ICommand
    {
        bool _canExceute = false;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return false;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("RelayCommand.Execute called!");
        }

        public void FireChanged(bool cond)
        {
            _canExceute = cond;
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
