using PassportPO.ViewModel.Base;
using PassportPO.Infrastructure.Command.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PassportPO.Model;

namespace PassportPO.ViewModel.PageViewModel{

internal class ViseVm: ViewModelBase
{
    #region Поля

        private string _name;
        public string Namestring
        {
            get => _name;
            set => Set(ref _name, value);
        }

        private string _surName;
        public string SurNamestring
        {
            get => _surName;
            set => Set(ref _surName, value);
        }

        private string _secondName;
        public string SecondNamestring
        {
            get => _secondName;
            set => Set(ref _secondName, value);
        }

        private bool? _status;
        public bool? Statusstring
        {
            get => _status;
            set => Set(ref _status, value);
        }

        private string _sitizenShip;
        public string SitizenShipstring
        {
            get => _sitizenShip;
            set => Set(ref _sitizenShip, value);
        }

        private IList? _id = null;
        public IList? Idsstring { get => _id; set => Set(ref _id, value); }

        private int? _idStr;
        public int? IdStrstring { get => _idStr; set => Set(ref _idStr, value); }

        #endregion

        #region Collection // ObservableCollection

        private ObservableCollection<VizeList>? _vizeLists;
        public ObservableCollection<VizeList>? VizeLists { get => _vizeLists; set => Set(ref _vizeLists, value); }

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
            VizeLists = null;
            using PassportPoBdContext db = new PassportPoBdContext();
            VizeLists = new ObservableCollection<VizeList>(db.VizeLists.ToList());
            Idsstring = VizeLists.Select(t => t.Id).ToList();
            db.Dispose();
        }

        #endregion

        #region Command // RelayCommand , ICommand

        #region BackButton

        private RelayCommand _backCommand;

        public ICommand BackButton
        {
            get
            {
                if (_backCommand == null)
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
                            OnPropertyChanged(nameof(VizeLists));
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

                            VizeList addobject = new VizeList(Namestring, SurNamestring, SecondNamestring, SitizenShipstring,Statusstring);

                            using PassportPoBdContext db = new PassportPoBdContext();

                            db.VizeLists.Add(addobject); 
                            db.SaveChanges();
                            BDset();
                            OnPropertyChanged(nameof(VizeLists));

                            Namestring = null; SurNamestring = null;
                            SecondNamestring = null; Statusstring = null;
                            SitizenShipstring = null;

                        },
                        param =>
                        {
                            if (Namestring != null && SurNamestring != null
                                                   && SecondNamestring != null
                                                   && SitizenShipstring != null) return true;
                            return false;
                        }
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

                                VizeList objectTable = db.VizeLists.Find(IdStrstring);
                                objectTable.Name = Namestring;
                                objectTable.SurName = SurNamestring;
                                objectTable.SecondName = SecondNamestring;
                                objectTable.Status = Statusstring;
                                objectTable.CitizenShip = SitizenShipstring;
                                db.Update(objectTable); db.SaveChanges();
                                BDset();
                                OnPropertyChanged(nameof(VizeLists));
                                IdStrstring = null;
                                Namestring = null;
                                SurNamestring = null;
                                SecondNamestring = null;
                                Statusstring = null;
                                SitizenShipstring = null;
                            }

                        }
                    , param =>
                    {
                        if (IdStrstring != null) return true;
                        return false;
                    });
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
                            VizeList objdel = db.VizeLists.Find(IdStrstring);
                            db.VizeLists.Remove(objdel);
                            db.SaveChanges();

                            BDset();
                            OnPropertyChanged(nameof(VizeLists));
                            IdStrstring = null; Idsstring = null;
                            Idsstring = VizeLists.Select(j => j.Id).ToList();

                        },
                        param =>
                        {
                            if (IdStrstring != null) return true;
                            return false;
                        });
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
                            VizeList objectTable = db.VizeLists.Find(IdStrstring);
                            Namestring = objectTable.Name;
                            SurNamestring = objectTable.SurName;
                            SecondNamestring = objectTable.SecondName;
                            Statusstring = objectTable.Status;
                            SitizenShipstring = objectTable.CitizenShip;
                            db.Dispose();
                            OnPropertyChanged();
                        },
                        param =>
                        {
                            if (IdStrstring != null)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        });
                }

                return _search;
            }
        }
        #endregion

        #endregion


        public ViseVm()
        {
            BDset();

        }
}}