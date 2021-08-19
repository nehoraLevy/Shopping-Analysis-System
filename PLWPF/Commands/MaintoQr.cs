using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PLWPF.Commands
{
    public class MaintoQr:ICommand
    {
        
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public event Action GotoEvent;

        public MaintoQr()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //CurrentVM.Students.Add(parameter as Student);
            if (GotoEvent != null)
                GotoEvent();
        }
        }
    }

