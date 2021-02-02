using LElWPF.Core.Infrastructure.Commands;
using LElWPF.Core.Models;
using LElWPF.Core.Models.db;
using LElWPF.Core.ViewModels.Base;
using LElWPF.Core.ViewModels.Windows;
using System;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace LElWPF.Core.ViewModels
{
    partial class MainWindowViewModel : ViewModel
    {
        #region Commands


        #region OpenDictionaryCommand

        public ICommand OpenDictionaryCommand { get; }

        private bool CanOpenDictionaryCommandExecute(object p) => true;
        private void OnOpenDictionaryCommandExecuted(object p)
        {

            try
            {
                if (dialogService.OpenFileDialog() == true)
                {
                    //DataValues = new ListValues(dialogService.Path, dialogService.File);
                    //RandomValues = DataValues.GetRandomValues();
                    //Status = dialogService.FilePath;
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
            mediaPlayer.Position = TimeSpan.FromSeconds(0);
            mediaPlayer.Play();
        }

        #endregion

        #region ClickButtonCheckCommand

        public ICommand ClickButtonCheckCommand { get; }

        private bool CanClickButtonCheckCommandExecute(object p) => true;
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
                // if (TexBoxAnswer.ToLower().Trim() == RandomValues.Eng.ToLower().Trim())
                //{
                ButtonHelpVisibility = Visibility.Visible;
                BorderHintVisibility = Visibility.Collapsed;
                RandomValues = DB.GetRandomValues();
                TexBoxAnswer = "";
                mediaPlayer.Open(new Uri(RandomValues.Song));
                mediaPlayer.Play();
                //}
            }
        }
        #endregion

        #endregion
    }
}
