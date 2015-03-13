using GalaSoft.MvvmLight;
using PasswordGenerator.HelperClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PasswordGenerator.ViewModels
{
    public class PasswordGeneratorViewModel:ViewModelBase
    {
        private ObservableCollection<PasswordViewModel> allPasswords;

        private PasswordViewModel newPassword;

        private MasterPasswordViewModel newMasterPassword;

        private ICommand addNewPasswordCommand;
        private ICommand addNewMasterPasswordCommand;
        private ICommand showNewMasterPasswordWindowCommand;

        public PasswordGeneratorViewModel()
        {
            this.newPassword = new PasswordViewModel();
            this.newMasterPassword = new MasterPasswordViewModel();
        }

        public IEnumerable<PasswordViewModel> Passwords
        {
            get
            {
                if (this.allPasswords == null)
                {
                    this.Passwords = DataPersister.GetAllPasswords();
                }
                return allPasswords;
            }
            set
            {
                if(this.allPasswords==null)
                {
                    this.allPasswords = new ObservableCollection<PasswordViewModel>();
                }
                this.allPasswords.Clear();
                foreach (var item in value)
                {
                    this.allPasswords.Add(item);
                }
            }
        }

        public PasswordViewModel NewPassword
        {
            get
            {
                return this.newPassword;
            }
            set
            {
                this.newPassword = value;
                this.RaisePropertyChanged(() => this.NewPassword);
            }
        }

        public MasterPasswordViewModel NewMasterPassword
        {
            get
            {
                return this.newMasterPassword;
            }
            set
            {
                this.newMasterPassword = value;
                this.RaisePropertyChanged(() => this.NewMasterPassword);
            }
        }

        #region Commands
        public ICommand AddNewPassword
        {
            get
            {
                if(this.addNewPasswordCommand==null)
                {
                    this.addNewPasswordCommand = new RelayCommand(this.HandleAddNewPasswordCommand);
                }
                return this.addNewPasswordCommand;
            }
        }

        public ICommand AddNewMasterPassword
        {
            get
            {
                if(this.addNewMasterPasswordCommand==null)
                {
                    this.addNewMasterPasswordCommand = new RelayCommand(this.HandleAddNewMasterPasswordCommand);
                }
                return this.addNewMasterPasswordCommand;
            }
        }

        public ICommand ShowNewMasterPasswordWindow
        {
            get
            {
                if (this.showNewMasterPasswordWindowCommand == null)
                {
                    this.showNewMasterPasswordWindowCommand = new RelayCommand(this.HandleShowNewMasterPasswordWindowCommand);
                }
                return this.showNewMasterPasswordWindowCommand;
            }
        }
        #endregion

        private void HandleShowNewMasterPasswordWindowCommand(object obj)
        {
            DataPersister.OpenAddMasterPasswordWindow();
        }

        private void HandleAddNewMasterPasswordCommand(object obj)
        {
            DataPersister.AddNewMasterPassword(this.NewMasterPassword);
        }
        
        private void HandleAddNewPasswordCommand(object obj)
        {
            DataPersister.AddNewPassword(this.NewPassword);
        }
       
    }
}
