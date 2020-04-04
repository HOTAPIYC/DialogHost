using System;
using System.Windows.Input;

namespace DialogHost
{
    public class DialogViewModel : ViewModelBase, IDialogRequestClose
    {
        public bool? DialogResult { get; set; }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        private ICommand _cmdTrue;
        private ICommand _cmdFalse;

        public ICommand CmdTrue
        {
            get => _cmdTrue;
        }

        public ICommand CmdFalse
        {
            get => _cmdFalse;
        }

        public DialogViewModel()
        {
            _cmdTrue = new DelegateCommand(x => 
            { 
                CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
            });
            _cmdFalse = new DelegateCommand(x => 
            { 
                CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)); 
            });
        }
    }
}
