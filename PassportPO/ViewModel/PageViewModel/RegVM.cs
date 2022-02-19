using PassportPO.ViewModel.Base;
using PassportPO.Infrastructure.Command.Base;
using PassportPO.Model;
using System.Linq;
using System.Windows.Input;

namespace PassportPO.ViewModel.PageViewModel{

internal class RegVm: ViewModelBase
{
            #region Привязываемые Свойства


        #region Поля Логин, Пароль, Имя

        private string? _Login;
        public string? Login { get => _Login; set => Set(ref _Login, value); }

        private string? _Password;
        public string? Password { get => _Password; set => Set(ref _Password, value); }

        private string? _Name;
        public string? Name { get => _Name; set => Set(ref _Name, value); }

        #endregion

        #endregion

        #region Конструктор Комманд

        private RelayCommand? _backCommand;

        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                {
                    _regCommand = new RelayCommand(
                        _ =>
                        {
                            MainViewModel.MainWindowVm.Root.SelectedViewModel = new AuthVm();
                        },
                        _ => true
                        );
                }
                return _backCommand;
            }
        }

        #region Регистрация

        private RelayCommand? _regCommand;

        public ICommand RegCommand
        {
            get
            {
                if (_regCommand == null)
                {
                    _regCommand = new RelayCommand(
                        param =>
                        {
                            Employee regUser = new Employee(Name, Login, Password);
                            Employee fields = null;
                            using (PassportPoBdContext db = new PassportPoBdContext())
                            {
                                fields = db.Employees.Where(p => p.Login == Login && p.Password == Password).ToList().FirstOrDefault();
                                db.Dispose();
                            }

                            if (fields != null)
                            {
                                System.Windows.MessageBox.Show("Пользователь с таким логином или паролем уже существует");
                            }
                            else
                            {
                                using PassportPoBdContext db = new PassportPoBdContext();
                                db.Employees.Add(regUser);
                                db.SaveChanges();
                                db.Dispose();
                                MainViewModel.MainWindowVm.Root.SelectedViewModel = new AuthVm();
                            }

                        },
                        parem => true);
                }
                return _regCommand;
            }
        }

        
        #endregion

        #endregion
    }}
