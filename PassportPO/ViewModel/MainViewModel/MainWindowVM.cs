using PassportPO.ViewModel.PageViewModel;

namespace PassportPO.ViewModel.MainViewModel;

internal class MainWindowVm: Base.ViewModelBase
{
    #region Заголовок Окна // String

    private string? _title = "PassportPO";
    public string? Title { get => _title; set => Set(ref _title, value); }

    #endregion

    #region Свойство навигации // Object

    private object _selectedViewModel;
    public object SelectedViewModel
    {
        get => _selectedViewModel;
        set => Set(ref _selectedViewModel, value);
    }
    #endregion

    #region Статичное поле для вызова навигации // Root

    public static MainWindowVm Root;

    #endregion

    #region Метод класса

    public MainWindowVm()
    {

        #region Стартовая Навигации

        SelectedViewModel = new AuthVM();
        Root = this;

        #endregion
    }

    #endregion
}