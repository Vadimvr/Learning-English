using LElWPF.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LElWPF.Core.Models.db;
using System.Windows.Input;
using System.Windows;
using LElWPF.Core.Infrastructure.Commands;

namespace LElWPF.Core.ViewModels.DatabaseWindow
{
    class DatabaseWindowViewModel : ViewModel
    {
       // public ObservableCollection<TableInDB> AllDB { get; private set; }

        #region AllDB

        private FullBase _AllDB;
        public FullBase AllDB { get => _AllDB; set => Set(ref _AllDB, value); }

        #endregion


        СreationTableInDB сreationTableInDB;
        #region SelectedTable


        private TableInDB _SelectedTable;

       
        public TableInDB SelectedTable
        {
            get => _SelectedTable;
            set => Set(ref _SelectedTable, value);
        }

        #endregion

        #region NameNewTable

        private string _NameNewTable;
        public string NameNewTable { get => _NameNewTable; set => Set(ref _NameNewTable, value); }

        #endregion
        #region AddNewTableCommand

        public ICommand AddNewTableCommand { get; }

        private bool CanAddNewTableCommandExecute(object p) => true;
        private void OnAddNewTableCommandExecuted(object p)
        {
            AllDB.AddTable(NameNewTable);
        }

        #endregion
        #region SaveTablesCommand

        public ICommand SaveTablesCommand { get; }

        private bool CanSaveTablesCommandExecute(object p) => true;
        private void OnSaveTablesCommandExecuted(object p)
        {
            //comamnd run
            SelectedTable.SeveTable();
        }
       
        
        #endregion









        public DatabaseWindowViewModel()
        {
            SaveTablesCommand = new LambdaCommand(OnSaveTablesCommandExecuted, CanSaveTablesCommandExecute);
            AddNewTableCommand = new LambdaCommand(OnAddNewTableCommandExecuted, CanAddNewTableCommandExecute);
            сreationTableInDB = new СreationTableInDB(@"D:\test\", "test2.db");
            AllDB = new FullBase(@"D:\test\", "test2.db");
        }
    }
}
