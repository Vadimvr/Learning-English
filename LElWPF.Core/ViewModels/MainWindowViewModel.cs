using LElWPF.Core.Infrastructure.Commands;
using LElWPF.Core.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace LElWPF.Core.ViewModels
{
    class MainWindowViewModel: ViewModel
    {
        #region Title
        private string _Title = "My title";

        /// <summary> Title window</summary>
        public string Title
        {
            get => _Title;
    
            set => Set(ref _Title, value);

        }
        #endregion


        #region Commands


        #region Close Application Command
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion



        #endregion

        public MainWindowViewModel()
        {
            #region Commands

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);


            #endregion
        }
    }
}
