using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Hospital;
using System.Data;
namespace VrachMedcentr
{
    class nano : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        private Action<object> execute;
        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
