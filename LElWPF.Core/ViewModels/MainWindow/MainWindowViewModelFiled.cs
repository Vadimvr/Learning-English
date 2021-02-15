using LElWPF.Core.Models;
using LElWPF.Core.Models.db;
using LElWPF.Core.ViewModels.Base;
using LElWPF.Core.ViewModels.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace LElWPF.Core.ViewModels
{
    partial class MainWindowViewModel : ViewModel
    {
        #region Accidentally

        private bool _Accidentally;
        public bool Accidentally { get => _Accidentally; set => Set(ref _Accidentally, value); }

        #endregion



        bool FirstRun { get; set; } = true;
        private MediaPlayer mediaPlayer = new MediaPlayer();
        IDialogService dialogService = new DefaultDialogService();
        public bool FileFound { get; set; } = false;


        private RandomValueFromTable _DB;
        public RandomValueFromTable DB { get => _DB; set => Set(ref _DB, value); }


        #region NamesTable

        private ObservableCollection<string> _NamesTable;
        public ObservableCollection<string> NamesTable { get => _NamesTable; set => Set(ref _NamesTable, value); }


        #endregion

        #region DoNotCheckAnswers

        private bool _DoNotCheckAnswers;
        public bool DoNotCheckAnswers { get => _DoNotCheckAnswers; set => Set(ref _DoNotCheckAnswers, value); }

        #endregion



        #region SelectedTable

        private string _SelectedTable;
        public string SelectedTable
        {
            get => _SelectedTable; set
            {
                Set(ref _SelectedTable, value);
                DB.NameTable = SelectedTable;
                StartIndex = DB.StartIndex;
                EndIndex = DB.EndIndex;
                RandomValues = DB.GetRandomValues();
            }
        }

        #endregion

        #region StartIndex

        private int _StartIndex;
        public int StartIndex
        {
            get => _StartIndex; set
            {
                DB.StartIndex = value;
                Set(ref _StartIndex, DB.StartIndex);
                if(value > EndIndex)
                    EndIndex = DB.EndIndex;
                RandomValues = DB.GetRandomValues();
            }
        }

        #endregion

        #region EndIndex

        private int _EndIndex;
        public int EndIndex
        {
            get => _EndIndex; set
            {
                DB.EndIndex = value;
                Set(ref _EndIndex, DB.EndIndex);
                if (value < StartIndex)
                    StartIndex = DB.StartIndex;
                RandomValues = DB.GetRandomValues();
            }
        }

        #endregion









        #region Filed



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
