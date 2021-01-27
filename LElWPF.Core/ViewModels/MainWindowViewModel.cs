using LElWPF.Core.Infrastructure.Commands;
using LElWPF.Core.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace LElWPF.Core.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
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

        #region ButtonVisibility

        private Visibility _ButtonVisibility = Visibility.Visible;
        public Visibility ButtonVisibility { get => _ButtonVisibility; set => Set(ref _ButtonVisibility, value); }

        #endregion



        #region Commands
        #region DisplayHint

        public ICommand DisplayHint { get; }

        private bool CanDisplayHintExecute(object p) => true;
        private void OnDisplayHintExecuted(object p)
        {
            ButtonVisibility = Visibility.Collapsed;
            PromptVisibility = Visibility.Visible;
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






        #endregion

        public MainWindowViewModel()
        {
            DisplayHint = new LambdaCommand(OnDisplayHintExecuted, CanDisplayHintExecute);
            RepeatSoundFileCommand = new LambdaCommand(OnRepeatSoundFileCommandExecuted, CanRepeatSoundFileCommandExecute);
        }
    }
}
