using System.Windows;
using System.Windows.Input;

namespace DialogHost
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IDialogService _dialogService;
        private ICommand _cmdShowDialog;
        private ICommand _cmdShowTextDialog;

        public IDialogService DialogHost
        {
            get => _dialogService;
        }

        public ICommand CmdShowDialog
        {
            get => _cmdShowDialog;
        }

        public ICommand CmdShowTextDialog
        {
            get => _cmdShowTextDialog;
        }

        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            _cmdShowDialog = new DelegateCommand(async x =>
            {
                var dialogViewModel = new DialogViewModel();

                var result = await _dialogService.ShowDialog(dialogViewModel);

                MessageBox.Show(string.Format("Your choice: {0}",result.ToString()));
            });

            _cmdShowTextDialog = new DelegateCommand(async x => 
            {
                var dialogViewModel = new DialogTextViewModel();

                var result = await _dialogService.ShowDialog(dialogViewModel);

                if (result.Value) { MessageBox.Show(string.Format("You typed: {0}", dialogViewModel.TextInput)); }
            });
        }
    }
}
