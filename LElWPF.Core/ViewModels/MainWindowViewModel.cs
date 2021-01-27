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

        #region Prompt

        private string _Prompt = "run";
        public string Prompt { get => _Prompt; set => Set(ref _Prompt, value); }

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





        #endregion

        public MainWindowViewModel()
        {
             DisplayHint = new LambdaCommand(OnDisplayHintExecuted, CanDisplayHintExecute);
        }
    }
}
