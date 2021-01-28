using LElWPF.Core.Infrastructure.Commands;
using LElWPF.Core.Models;
using LElWPF.Core.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace LElWPF.Core.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region DtatValues

        
        public ListValues DataValues { get ; set ; }
        public Values RandomValues { get; set; }

        public bool FirstRun { get; set; } = true;

        #endregion


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

        #region Visibility

        #region FirstStartApp

        private Visibility _FirstStartApp = Visibility.Collapsed;
        public Visibility FirstStartApp { get => _FirstStartApp; set => Set(ref _FirstStartApp, value); }

        #endregion



        #region BorderHintVisibility

        private Visibility _BorderHintVisibility = Visibility.Collapsed;
        public Visibility BorderHintVisibility { get => _BorderHintVisibility; set => Set(ref _BorderHintVisibility, value); }

        #endregion
        #endregion

        #region ButtonVisibility

        private Visibility _ButtonVisibility = Visibility.Visible;
        public Visibility ButtonVisibility { get => _ButtonVisibility; set => Set(ref _ButtonVisibility, value); }

        #endregion

        #region TexBoxAnswer

        private string _TexBoxAnswer;
        public string TexBoxAnswer { get => _TexBoxAnswer; set => Set(ref _TexBoxAnswer, value); }

        #endregion



        #region Commands
        #region DisplayHintCommand

        public ICommand DisplayHintCommand { get; }

        private bool CanDisplayHintCommandExecute(object p) => true;
        private void OnDisplayHintCommandExecuted(object p)
        {

            ButtonVisibility = Visibility.Collapsed;
            BorderHintVisibility = Visibility.Visible;
        }

        #endregion

        #region RepeatSoundFileCommand

        public ICommand RepeatSoundFileCommand { get; }

        private bool CanRepeatSoundFileCommandExecute(object p) => true;
        private void OnRepeatSoundFileCommandExecuted(object p)
        {
            //comamnd run
            Application.Current.Shutdown();
        }

        #endregion

        #region ClickButtonCheckCommand

        public ICommand ClickButtonCheckCommand { get; }

        private bool CanClickButtonCheckCommandExecute(object p) => true;
        private void OnClickButtonCheckCommandExecuted(object p)
        {
            if(FirstRun == true)
                FirstStartApp = Visibility.Visible;
            //comamnd run
           // Application.Current.Shutdown();
        }
        //below line move in MainWindowViewModel
        
        #endregion



        #endregion

        public MainWindowViewModel()
        {
            DataValues = new ListValues(@"D:\TestDB\", "data.db");
            RandomValues = DataValues.GetRandomValues();
            
            
            DisplayHintCommand = new LambdaCommand(OnDisplayHintCommandExecuted, CanDisplayHintCommandExecute);
            RepeatSoundFileCommand = new LambdaCommand(OnRepeatSoundFileCommandExecuted, CanRepeatSoundFileCommandExecute);
            ClickButtonCheckCommand = new LambdaCommand(OnClickButtonCheckCommandExecuted, CanClickButtonCheckCommandExecute);
        }
    }
}
