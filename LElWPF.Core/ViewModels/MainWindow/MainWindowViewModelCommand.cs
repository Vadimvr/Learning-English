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

        #region ShowHintCommand

        public ICommand ShowHintCommand { get; }

        private bool CanShowHintCommandExecute(object p) => true;
        private void OnShowHintCommandExecuted(object p)
        {
            ShowHint = !ShowHint;
        }
        
        #endregion

        #region AccidentallyCommand

        public ICommand AccidentallyCommand { get; }

        private bool CanAccidentallyCommandExecute(object p) => true;
        private void OnAccidentallyCommandExecuted(object p)
        {
            Accidentally = !Accidentally;
        }
        
        #endregion

        #region DoNotCheckAnswersCommand

        public ICommand DoNotCheckAnswersCommand { get; }

        private bool CanDoNotCheckAnswersCommandExecute(object p) => true;
        private void OnDoNotCheckAnswersCommandExecuted(object p)
        {
            DoNotCheckAnswers = !DoNotCheckAnswers;
        }
        
        #endregion

        #region OpenImageLinkInBrowserCommand

        public ICommand OpenImageLinkInBrowserCommand { get; }

        private bool CanOpenImageLinkInBrowserCommandExecute(object p) => true;
        private void OnOpenImageLinkInBrowserCommandExecuted(object p)
        {
            if (RandomValues != null)
            {
                var destinationurl = $"https://www.google.com/search?q={RandomValues.Eng.ToLower().Replace('!', '_')}+clipart&tbm=isch";
                var sInfo = new System.Diagnostics.ProcessStartInfo(destinationurl)
                {
                    UseShellExecute = true,
                };
                System.Diagnostics.Process.Start(sInfo);
                Clipboard.SetText($"{RandomValues.Eng.ToLower().Replace('!', '_').Replace('?', '_')}.jpg");
            }
        }


        #endregion

        #region OpenSongLinkInBrowserCommand

        public ICommand OpenSongLinkInBrowserCommand { get; }

        private bool CanOpenSongLinkInBrowserCommandExecute(object p) => true;
        private void OnOpenSongLinkInBrowserCommandExecuted(object p)
        {
            if (RandomValues != null)
            {
                var destinationurl = $"https://forvo.com/search/{RandomValues.Eng}/en/";
                var sInfo = new System.Diagnostics.ProcessStartInfo(destinationurl)
                {
                    UseShellExecute = true,
                };
                System.Diagnostics.Process.Start(sInfo);
            }
        }

        #endregion

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
                if (dialogService.OpenFileDialog())
                {
                    try
                    {
                        StaticPath = dialogService.Path;
                        StaticName = dialogService.File;
                        DB = new RandomValueFromTable(StaticPath, StaticName);
                        NamesTable = DB.NamesTable;
                        DB.NameTable = SelectedTable;

                        FileFound = true;
                        Status = StaticName;
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
                Status = DB.Index.ToString();
            }

            else
            {
                // disabled сhecking the correct answer
                if (DoNotCheckAnswers ||TexBoxAnswer.ToLower().Trim() == RandomValues.Eng.ToLower().Trim())
                {
                    Status = "Right";
                    ButtonHelpVisibility = ShowHint ?  Visibility.Collapsed : Visibility.Visible;

                    BorderHintVisibility = ShowHint ? Visibility.Visible: Visibility.Collapsed;

                    RandomValues = Accidentally ? DB.GetRandomValues():DB.GetNextValues();
                    TexBoxAnswer = "";
                    mediaPlayer.Stop();
                    mediaPlayer.Open(new Uri(RandomValues.Song));
                    mediaPlayer.Play();
                    Status = DB.Index.ToString();
                }

                else
                {
                    Status = "mistake";
                }
            }
        }
        #endregion

        #endregion
    }
}
