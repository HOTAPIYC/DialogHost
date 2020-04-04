using System;
using System.Windows.Input;

namespace DialogHost
{
    public class DialogTextViewModel : ViewModelBase, IDialogRequestClose
    {
        public bool? DialogResult { get; set; }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        private ICommand _cmdOk;
        private ICommand _cmdCancel;

        private string _textInput;

        public ICommand CmdOk
        {
            get => _cmdOk;
        }

        public ICommand CmdCancel
        {
            get => _cmdCancel;
        }

        public string TextInput
        {
            get => _textInput;
            set { _textInput = value; NotifyPropertChanged("TextInput"); }
        }

        public DialogTextViewModel()
        {
            _cmdOk = new DelegateCommand(x =>
            {
                CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
            });
            _cmdCancel = new DelegateCommand(x =>
            {
                CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false));
            });
        }
    }
}
