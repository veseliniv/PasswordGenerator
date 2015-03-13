using Devart.Data.SQLite;
using PasswordGenerator.View;
using PasswordGenerator.ViewModels;
using PasswordGeneratorContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordGenerator.HelperClasses
{
    public class DataPersister
    {
        private static readonly PasswordGeneratorDataContext context = 
            new PasswordGeneratorDataContext(@"Data Source=..\..\Database\PasswordGeneratorDB.db");


        internal static IEnumerable<PasswordViewModel> GetAllPasswords()
        {
            var passes =
                from pass in context.Password
                select new PasswordViewModel()
                {
                    Site=pass.Site,
                    Password=pass.Password1
                };

            return passes;
        }

        internal static void AddNewPassword(PasswordViewModel newPassword)
        {
           // newPassword.Password = GeneratePassword();

            var passwordToAdd =
                from pta in context.Password
                where pta.Site == newPassword.Site
                select pta;

            if(passwordToAdd.Count()!=0)
            {
                MessageBox.Show("The site" + newPassword.Site + " already exists.","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    context.Password.InsertOnSubmit(
                                            new Password()
                                            {
                                                Site = newPassword.Site,
                                                Password1 = newPassword.Password
                                            }
                                      );
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }


                MessageBox.Show("Password added successful!!!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        internal static void AddNewMasterPassword(MasterPasswordViewModel newMasterPassword)
        {
            var masterPasswordToAdd =
                from mpta in context.MasterPassword
                select mpta;

            if(masterPasswordToAdd.Count()!=0)
            {
                MessageBox.Show("Master password exists!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    context.MasterPassword.InsertOnSubmit(
                            new MasterPassword()
                            {
                                MasterPassword1 = newMasterPassword.MasterPassword
                            }
                        );
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                MessageBox.Show("Master password added successful!!!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        internal static void OpenAddMasterPasswordWindow()
        {
            try
            {
                AddMasterPasswordWindow addMasterPasswordWindow = new AddMasterPasswordWindow();
                addMasterPasswordWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        internal static void OpenEnterMasterPasswordWindow()
        {
            try
            {
                EnterMasterPasswordWindow enterMasterPasswordWindow = new EnterMasterPasswordWindow();
                enterMasterPasswordWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
