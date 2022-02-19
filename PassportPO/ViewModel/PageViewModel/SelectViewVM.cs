using System.Windows.Input;
using PassportPO.Infrastructure.Command.Base;

namespace PassportPO.ViewModel.PageViewModel;
internal class SelectViewVm
{
    private RelayCommand? _passCommand;
    public ICommand PassCommand
    {
        get
        {
            if (_passCommand==null)
            {
                _passCommand = new RelayCommand(
                    param =>
                    {
                        MainViewModel.MainWindowVm.Root.SelectedViewModel = new PassportVm();
                    },
                    param => true
                );
            }
            return _passCommand;
        }
    }
    private RelayCommand? _vizaCommand;
    public ICommand VizaCommand
    {
        get
        {
            if (_vizaCommand == null)
            {
                _vizaCommand = new RelayCommand(
                    param =>
                    {
                        MainViewModel.MainWindowVm.Root.SelectedViewModel = new ViseVM();
                    },
                    param => true
                );
            }
            return _vizaCommand;
        }
    }
}