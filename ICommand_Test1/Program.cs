using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

//https://www.sysnet.pe.kr/2/0/10917

namespace ICommand_Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmd = new RelayCommand();

            ConsolePrompt prompt = new ConsolePrompt();
            prompt.Command = cmd;
            prompt.Run();
        }
    }

    public class RelayCommand : ICommand
    {
        // Execute를 실행할 수 있는가에 대한 조건이 변화했을때
        public event EventHandler CanExecuteChanged;

        //Execute를 실행할 수 있는가에 대한 조건을 설정할 수 있다.
        public bool CanExecute(object parameter)
        {
            return DateTime.Now.Hour != 9;//9시에서 10시 사이에는 명령어처리를 할 수 없다. 할당값을 변화시켜가면서 테스트 가능
        }

        public void Execute(object parameter)
        {
            Console.WriteLine(DateTime.Now + ": RelayCommand.Execute - " + parameter);
        }
    }

    public class ConsolePrompt
    {
        public ICommand Command
        {
            get; set;
        }

        public void Run()
        {
            while (true)
            {
                string txt = Console.ReadLine();
                if (string.IsNullOrEmpty(txt) == true)
                    break;
                //Command.Execute(txt);

                if(Command.CanExecute(null) == true)
                {
                    Command.Execute(txt);
                }
            }
        }
    }
}
