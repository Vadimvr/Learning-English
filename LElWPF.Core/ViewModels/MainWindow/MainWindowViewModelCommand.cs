using LElWPF.Core.ViewModels.Base;
using System;
using System.Windows;
using System.Windows.Input;
using LElWPF.Core.Views.Windows;
using LElWPF.Core.Models.db;

namespace LElWPF.Core.ViewModels
{
    partial class MainWindowViewModel : ViewModel
    {
        #region Commands

        #region NewNameCommand

        public ICommand NewNameCommand { get; }

        private bool CanNewNameCommandExecute(object p) => true;
        private void OnNewNameCommandExecuted(object p)
        {
            //comamnd run
            Application.Current.Shutdown();
        }
        #endregion

        #region OpenSeconWindowCommand

        public ICommand OpenDatabaseWindowCommand { get; }

        private bool CanOpenDatabaseWindowCommandExecute(object p) => FileFound;
        private void OnOpenDatabaseWindowCommandExecuted(object p)
        {
            Views.Windows.DatabaseWindow databaseWindow = new Views.Windows.DatabaseWindow();
            databaseWindow.Show();
        }

        #endregion

        #region OpenDictionaryCommand

        public ICommand OpenDictionaryCommand { get; }

        private bool CanOpenDictionaryCommandExecute(object p) => true;
        private void OnOpenDictionaryCommandExecuted(object p)
        {
            try
            {
                if (dialogService.OpenFileDialog() == true)
                {
                    try
                    {
                        StaticPath = dialogService.Path;
                        StaticName = dialogService.File;
                        DB = new RandomValueFromTable(StaticPath, StaticName);
                        RandomValues = DB.GetRandomValues();
                        FileFound = true;
                    }
                    catch (System.Exception ex)
                    {
                        Status = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                Status = ex.ToString();
            }
        }

        #endregion

        #region DisplayHintCommand

        public ICommand DisplayHintCommand { get; }

        private bool CanDisplayHintCommandExecute(object p) => true;
        private void OnDisplayHintCommandExecuted(object p)
        {
            ButtonHelpVisibility = Visibility.Collapsed;
            BorderHintVisibility = Visibility.Visible;
        }

        #endregion

        #region RepeatSoundFileCommand

        public ICommand RepeatSoundFileCommand { get; }

        private bool CanRepeatSoundFileCommandExecute(object p) => true;
        private void OnRepeatSoundFileCommandExecuted(object p)
        {
            mediaPlayer.Stop();
            mediaPlayer.Position = TimeSpan.FromSeconds(0);
            mediaPlayer.Play();
        }

        #endregion

        #region ClickButtonCheckCommand

        public ICommand ClickButtonCheckCommand { get; }

        private bool CanClickButtonCheckCommandExecute(object p) => FileFound;
        private void OnClickButtonCheckCommandExecuted(object p)
        {

            if (FirstRun == true)
            {
                ButtonHelpVisibility = Visibility.Visible;
                FirstStartApp = Visibility.Visible;
                FirstRun = false;
                ButtomTextChexkAnsver = "Check";
                mediaPlayer.Open(new Uri(RandomValues.Song));
                mediaPlayer.Play();
            }

            else
            {
                // disabled сhecking the correct answer
                if (TexBoxAnswer.ToLower().Trim() == RandomValues.Eng.ToLower().Trim())
                {
                    ButtonHelpVisibility = Visibility.Visible;
                    BorderHintVisibility = Visibility.Collapsed;
                    RandomValues = DB.GetRandomValues();
                    TexBoxAnswer = "";
                    mediaPlayer.Stop();
                    mediaPlayer.Open(new Uri(RandomValues.Song));
                    mediaPlayer.Play();
                }
            }
        }
        #endregion

        #endregion
    }
}
