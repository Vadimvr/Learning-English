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



        public MainWindowViewModel()
        {
        }
    }
}
