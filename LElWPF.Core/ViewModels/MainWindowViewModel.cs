using LElWPF.Core.Infrastructure.Commands;
using LElWPF.Core.Models;
using LElWPF.Core.ViewModels.Base;
using LElWPF.Core.ViewModels.Windows;
using System;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace LElWPF.Core.ViewModels
{
    class MainWindowViewModel : ViewModel
    {


        #region Filed


        #region DtatValues


        public ListValues DataValues { get; set; }
        public Values RandomValues { get; set; }

        public bool FirstRun { get; set; } = true;

        #endregion

        private MediaPlayer mediaPlayer = new MediaPlayer();
        IDialogService dialogService = new DefaultDialogService();

        #region Title
        private string _Title = "Learning English language";

        /// <summary> Title window</summary>
        public string Title
        {
            get => _Title;

            set => Set(ref _Title, value);

        }
        #endregion

        #region Status

        private string _Status = "Status";
        public string Status { get => _Status; set => Set(ref _Status, value); }

        #endregion

        #region ImegePath

        private string _ImegePath = @"/Data/image/Rectangle4.png";
        public string ImegePath { get => _ImegePath; set => Set(ref _ImegePath, value); }

        #endregion

        #region Question

        private string _Question = "Бежать";
        public string Question { get => _Question; set => Set(ref _Question, value); }

        #endregion

        #region Hint

        private string _Hint = "Run";
        public string Hint { get => _Hint; set => Set(ref _Hint, value); }

        #endregion

        #region PromptVisibility

        private Visibility _PromptVisibility = Visibility.Collapsed;
        public Visibility PromptVisibility { get => _PromptVisibility; set => Set(ref _PromptVisibility, value); }

        #endregion
        #region TexBoxAnswer

        private string _TexBoxAnswer = "";
        public string TexBoxAnswer { get => _TexBoxAnswer; set => Set(ref _TexBoxAnswer, value); }

        #endregion
        #endregion

        #endregion



        #region BorderHintVisibility

        private Visibility _BorderHintVisibility = Visibility.Collapsed;
        public Visibility BorderHintVisibility { get => _BorderHintVisibility; set => Set(ref _BorderHintVisibility, value); }

        #endregion


        #region ButtonHelpVisibility

        private Visibility _ButtonHelpVisibility = Visibility.Collapsed;
        public Visibility ButtonHelpVisibility { get => _ButtonHelpVisibility; set => Set(ref _ButtonHelpVisibility, value); }

        #endregion
        #endregion

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
                    DataValues = new ListValues(dialogService.Path,dialogService.File);
                    RandomValues = DataValues.GetRandomValues();
                    Status = dialogService.FilePath;
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
                ImegePath = RandomValues.Img;
                Question = RandomValues.Rus;
                Hint = RandomValues.Eng + " " + RandomValues.EngTranscription;

                mediaPlayer.Open(new Uri(RandomValues.Song));
                mediaPlayer.Play();

            }

            else
            {
                // if (TexBoxAnswer.ToLower().Trim() == RandomValues.Eng.ToLower().Trim())
                //{
                ButtonHelpVisibility = Visibility.Visible;
                BorderHintVisibility = Visibility.Collapsed;
                RandomValues = DataValues.GetRandomValues();
                ImegePath = RandomValues.Img;
                Question = RandomValues.Rus;
                Hint = RandomValues.Eng + " " + RandomValues.EngTranscription;
                TexBoxAnswer = "";
                mediaPlayer.Open(new Uri(RandomValues.Song));
                mediaPlayer.Play();
                //}
            }
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            DataValues = new ListValues(@"D:\TestDB\","data.db");
            RandomValues = DataValues.GetRandomValues();

            OpenDictionaryCommand = new LambdaCommand(OnOpenDictionaryCommandExecuted, CanOpenDictionaryCommandExecute);
            DisplayHintCommand = new LambdaCommand(OnDisplayHintCommandExecuted, CanDisplayHintCommandExecute);
            RepeatSoundFileCommand = new LambdaCommand(OnRepeatSoundFileCommandExecuted, CanRepeatSoundFileCommandExecute);
            ClickButtonCheckCommand = new LambdaCommand(OnClickButtonCheckCommandExecuted, CanClickButtonCheckCommandExecute);
        }
    }
}
