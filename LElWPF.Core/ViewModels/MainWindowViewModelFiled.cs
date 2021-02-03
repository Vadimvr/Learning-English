using LElWPF.Core.Models;
using LElWPF.Core.Models.db;
using LElWPF.Core.ViewModels.Base;
using LElWPF.Core.ViewModels.Windows;
using System.Windows.Media;

namespace LElWPF.Core.ViewModels
{
    partial class MainWindowViewModel : ViewModel
    {

        #region Filed
        
        private MediaPlayer mediaPlayer = new MediaPlayer();
        IDialogService dialogService = new DefaultDialogService();
        ConectionDB DB;
        bool FirstRun { get; set; } = true;
               
        #region RandomValues

        private Values _RandomValues;
        public Values RandomValues { get => _RandomValues; set => Set(ref _RandomValues, value); }

        #endregion

        #region Title
        private string _Title = "Learning English language";
        public string Title { get => _Title; set => Set(ref _Title, value); }
        #endregion

        #region Status

        private string _Status = "Status";
        public string Status { get => _Status; set => Set(ref _Status, value); }

        #endregion

        #region ButtomTextChexkAnsver

        private string _ButtomTextChexkAnsver = "Click to start";
        public string ButtomTextChexkAnsver { get => _ButtomTextChexkAnsver; set => Set(ref _ButtomTextChexkAnsver, value); }

        #endregion

        #region TexBoxAnswer


        private string _TexBoxAnswer = "";
        public string TexBoxAnswer { get => _TexBoxAnswer; set => Set(ref _TexBoxAnswer, value); }


        #endregion

        #endregion


    }
}
