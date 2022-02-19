using System.Linq;
using System.Windows.Input;
using PassportPO.ViewModel.Base;
using PassportPO.Infrastructure.Command.Base;
using PassportPO.Model;
using PassportPO.ViewModel.MainViewModel;

namespace PassportPO.ViewModel.PageViewModel{

internal class AuthVm: ViewModelBase
{
    #region Поля Логин и Пароль

        private string? _login;
        public string? Login { get => _login; set => Set(ref _login, value); }

        private string? _password;
        public string? Password { get => _password; set => Set(ref _password, value); }

        #endregion

        #region Конструктор Комманд

        #region Вход

        RelayCommand? _authCommand;

        public ICommand AuthCommand
        {
            get
            {
                if (_authCommand == null)
                {
                    _authCommand = new RelayCommand(
                        parem =>
                        {
                            Employee? authUser = null;
                            using PassportPoBdContext db = new PassportPoBdContext();
                            authUser = db.Employees.FirstOrDefault(p => p.Login == Login && p.Password == Password);
                            db.Dispose();
                            if (authUser != null)
                            {
                                MainWindowVm.Root.SelectedViewModel = new SelectViewVm();
                            }
                            else { System.Windows.MessageBox.Show("Не верный логин или пароль!!!"); }
                        },
                        parem => true);
                }
                return _authCommand;
            }
        }

        #endregion

         #region Регистрация

        RelayCommand? _regCommand;

        public ICommand RegCommand
        {
            get
            {
                if (_regCommand == null)
                {
                    _regCommand = new RelayCommand(
                        param =>
                        {
                            MainViewModel.MainWindowVm.Root.SelectedViewModel = new RegVm();
                            Dispose();
                        },
                        param => true);
                }
                return _regCommand;
            }
        }

        #endregion

        #endregion
}}