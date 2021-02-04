﻿using LElWPF.Core.ViewModels.Base;
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
        #region OpenSeconWindowCommand

        public ICommand OpenDatabaseWindowCommand { get; }

        private bool CanOpenDatabaseWindowCommandExecute(object p) => FileFaind;
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
                    //DataValues = new ListValues(dialogService.Path, dialogService.File);
                    //RandomValues = DataValues.GetRandomValues();
                    //Status = dialogService.FilePath;
                    try
                    {
                        StaticPath = dialogService.Path;
                        StaticName = dialogService.File;
                        DB = new ConectionDB(dialogService.Path, dialogService.File);
                        RandomValues = DB.GetRandomValues();
                        FileFaind = true;
                    }
                    catch (System.Exception ex)
                    {
                        Status = "Not found " + _path + _nameDB;
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

        private bool CanClickButtonCheckCommandExecute(object p) => FileFaind;
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

                //disabled сhecking the correct answer
                // if (TexBoxAnswer.ToLower().Trim() == RandomValues.Eng.ToLower().Trim())
                //{
                ButtonHelpVisibility = Visibility.Visible;
                BorderHintVisibility = Visibility.Collapsed;
                RandomValues = DB.GetRandomValues();
                TexBoxAnswer = "";
                mediaPlayer.Stop();
                mediaPlayer.Open(new Uri(RandomValues.Song));
                mediaPlayer.Play();
                //}
            }
        }
        #endregion

        #endregion
    }
}
