using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using PassportPO.Infrastructure.Command.Base;
using PassportPO.ViewModel.Base;
using PassportPO.Model;


namespace PassportPO.ViewModel.PageViewModel;

internal class PassportVm: ViewModelBase
{
        #region Поля

        private string? _name;
        public string? Namestring
        {
            get => _name; 
            set => Set(ref _name, value);
        }

        private string? _surName;
        public string? SurNamestring
        {
            get => _surName; 
            set=> Set(ref _surName, value); 
        }

        private string? _secondName;
        public string? SecondNamestring
        {
            get => _secondName;
            set=> Set(ref _secondName, value);
        }

        private string? _kod;
        public string? Kodstring
        {
            get => _kod;
            set => Set(ref _kod, value);
        }

        private string? _kem;
        public string? Kemstring
        {
            get => _kem;
            set => Set(ref _kem, value);
        }

        private string? _sitizenShip;
        public string? SitizenShipstring
        {
            get => _sitizenShip;
            set => Set(ref _sitizenShip, value);
        }

        private IList? _id;
        public IList? Idsstring { get => _id; set => Set(ref _id, value); }

        private int? _idStr;
        public int? IdStrstring { get => _idStr; set => Set(ref _idStr, value); }

        #endregion

        #region Collection // ObservableCollection

        private ObservableCollection<PassportList> _passportLists;
        public ObservableCollection<PassportList> PassportLists { get => _passportLists; set => Set(ref _passportLists, value); }

        #endregion

        #region Visibility  AddButton// bool
        private bool _visible = false; // Установить False // Не забыть
        public bool Visible { get => _visible; set => Set(ref _visible, value); }

        private bool _checkBox = false;
        public bool CheckBox { get => _checkBox; set => Set(ref _checkBox, value); }
        #endregion

        #region Method // Void

        private void BDset()
        {
            PassportLists = null;


            using( PassportPoBdContext db = new PassportPoBdContext())
            {
                PassportLists = new ObservableCollection<PassportList>(db.PassportLists.ToList());
                Idsstring = PassportLists.Select(t => t.Id).ToList();
                db.Dispose();
            }

        }

        #endregion

        #region Command // RelayCommand , ICommand

        #region BackButton

        private RelayCommand _backCommand;

        public ICommand BackButton
        {
            get
            {
                if (_backCommand==null)
                {
                    _backCommand = new RelayCommand(_ =>
                        {
                            MainViewModel.MainWindowVm.Root.SelectedViewModel = new SelectViewVm();
                        },
                        _ => true);
                }

                return _backCommand;
            }
        }

        #endregion

        #region RefrashButton

        RelayCommand _refrashButton;
        public ICommand RefrashButton
        {
            get
            {
                if (_refrashButton == null)
                {
                    _refrashButton = new RelayCommand(
                        param =>
                        {
                            BDset();
                            OnPropertyChanged(nameof(PassportLists));
                        }
                    , param => true);
                }

                return _refrashButton;
            }
        }

        #endregion

        #region Кнопка открытия окна добавления/Изменения  // AddButton

        RelayCommand _addButton;
        public ICommand AddButton
        {
            get
            {
                if (_addButton == null)
                {
                    _addButton = new RelayCommand(
                        param =>
                        {
                            if (Visible == false) { Visible = true; }
                        }
                    , param =>
                    {
                        if (Visible == true)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    });
                }

                return _addButton;
            }
        }

        #endregion

        #region Кнопка добавления записи в базу данных // AddInBDButton

        RelayCommand _addInBdButton;

        public ICommand AddInBdButton
        {
            get
            {
                if (_addInBdButton == null)
                {
                    _addInBdButton = new RelayCommand(
                        param =>
                        {

                            PassportList addobject = new PassportList
                                (Namestring,SurNamestring,SecondNamestring,Int32.Parse(Kodstring), Kemstring,SitizenShipstring);

                            using PassportPoBdContext db = new PassportPoBdContext();

                            db.PassportLists.Add(addobject); db.SaveChanges();


                            BDset();
                            OnPropertyChanged(nameof(PassportLists));

                            Namestring = null; SurNamestring = null;
                            SecondNamestring = null; Kodstring = null;
                            Kemstring = null; SitizenShipstring = null;

                        },
                        param => true
                    );
                }

                return _addInBdButton;
            }
        }

        #endregion

        #region Изменение записи в БД // ChangeButton

        RelayCommand _changeButton;

        public ICommand ChangeButton
        {
            get
            {
                if (_changeButton == null)
                {
                    _changeButton = new RelayCommand(
                        param =>
                        {
                            if (IdStrstring != null)
                            {
                                using PassportPoBdContext db = new PassportPoBdContext();

                                PassportList objectTable = db.PassportLists.Find(IdStrstring);
                                objectTable.Name = Namestring;
                                objectTable.Surname = SurNamestring;
                                objectTable.SecondName = SecondNamestring;
                                objectTable.Kod = Int32.Parse(Kodstring);
                                objectTable.Kem = Kemstring;
                                objectTable.Citizenship = SitizenShipstring;
                                db.Update(objectTable); db.SaveChanges();
                                BDset();
                                OnPropertyChanged(nameof(PassportLists));
                                IdStrstring = null;
                                Namestring = null;
                                SurNamestring = null;
                                SecondNamestring = null;
                                Kodstring = null;
                                Kemstring = null;
                                SitizenShipstring = null;
                            }

                        }
                    , param => true);
                }

                return _changeButton;
            }
        }

        #endregion

        #region Удаление записи из БД // DeleteButton

        RelayCommand _deleteButton;

        public ICommand DeleteButton
        {
            get
            {
                if (_deleteButton == null)
                {
                    _deleteButton = new RelayCommand(
                        param =>
                        {
                            using PassportPoBdContext db = new PassportPoBdContext();
                            PassportList objdel = db.PassportLists.Find(IdStrstring);
                            db.PassportLists.Remove(objdel);
                            db.SaveChanges();

                            BDset();
                            OnPropertyChanged(nameof(PassportLists));
                            IdStrstring = null; Idsstring = null;
                            Idsstring = PassportLists.Select(j => j.Id).ToList();

                        },
                        param => true);
                }

                return _deleteButton;
            }
        }

        #endregion

        #region SearchButton

        RelayCommand _search;

        public ICommand Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new RelayCommand(
                        param =>
                        {
                            using PassportPoBdContext db = new PassportPoBdContext();
                            PassportList objectTable = db.PassportLists.Find(IdStrstring);
                            Namestring = objectTable.Name;
                            SurNamestring = objectTable.Surname;
                            SecondNamestring = objectTable.SecondName;
                            Kodstring = Convert.ToString(objectTable.Kod);
                            Kemstring = objectTable.Kem;
                            SitizenShipstring = objectTable.Citizenship;
                            db.Dispose();
                            OnPropertyChanged();
                        },
                        param => true);
                }

                return _search;
            }
        }
        #endregion

        #endregion


        public PassportVm()
        {
            BDset();
        }
}