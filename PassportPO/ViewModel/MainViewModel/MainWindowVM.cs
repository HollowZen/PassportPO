namespace PassportPO.ViewModel.MainViewModel;

internal class MainWindowVM: Base.ViewModelBase
{
    #region Заголовок Окна // String

    private string? _Title = "PassportPO";
    public string? Title { get => _Title; set => Set(ref _Title, value); }

    #endregion

    #region Свойство навигации // Object

    private object _SelectedViewModel;
    public object SelectedViewModel
    {
        get => _SelectedViewModel;
        set => Set(ref _SelectedViewModel, value);
    }
    #endregion

    #region Статичное поле для вызова навигации // Root

    public static MainWindowVM Root;

    #endregion

    #region Метод класса

    public MainWindowVM()
    {

        #region Стартовая Навигации

        /*SelectedViewModel = new AuthViewModel();*/
        Root = this;

        #endregion
    }

    #endregion
}