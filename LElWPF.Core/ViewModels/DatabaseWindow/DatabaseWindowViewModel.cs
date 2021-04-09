using LElWPF.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LElWPF.Core.Models.db;
using System.Windows.Input;
using System.Windows;
using LElWPF.Core.Infrastructure.Commands;
using LElWPF.Core.Models;

namespace LElWPF.Core.ViewModels.DatabaseWindow
{
    class DatabaseWindowViewModel : ViewModel
    {
        #region AllDB

        private FullBase _AllDB;
        public FullBase AllDB { get => _AllDB; set => Set(ref _AllDB, value); }

        #endregion
        #region SelectedItem

        private int _SelectedItem = 0;
        public int SelectedItem { get => _SelectedItem; set => Set(ref _SelectedItem, value); }

        #endregion



        #region SelectedTable

        private TableInDB _SelectedTable;
        public TableInDB SelectedTable { get => _SelectedTable; set => Set(ref _SelectedTable, value); }

        #endregion

        #region SelectedValue

        private Values _SelectedValue;
        public Values SelectedValue { get => _SelectedValue; set => Set(ref _SelectedValue, value); }

        #endregion

        #region AddValueTemp

        private Values _AddValueTemp = new Values();
        public Values AddValueTemp { get => _AddValueTemp; set => Set(ref _AddValueTemp, value); }

        #endregion

        #region SaveAllTablesCommand

        public ICommand SaveAllTablesCommand { get; }

        private bool CanSaveAllTablesCommandExecute(object p) => true;
        private void OnSaveAllTablesCommandExecuted(object p)
        {
            int tem  = SelectedItem;
            AllDB.SaveAllTeble();
            AllDB = new FullBase(StaticPath, StaticName);
            SelectedItem = tem;
        }
      
        #endregion




        #region AddValuesCommand

        public ICommand AddValuesCommand { get; }

        private bool CanAddValuesCommandExecute(object p) => true;
        private void OnAddValuesCommandExecuted(object p)
        {
            SelectedTable.Values.Add(new Values(AddValueTemp.Eng, AddValueTemp.EngTranscription, AddValueTemp.Rus));
        }

        #endregion

        #region CreadeValuesCommand

        public ICommand CreadeValuesCommand { get; }

        private bool CanCreadeValuesCommandExecute(object p) => true;
        private void OnCreadeValuesCommandExecuted(object p)
        {
            if (SelectedValue == null)
                SelectedValue = new Values();
        }

        #endregion

        #region DeleteValueCommand

        public ICommand DeleteValueCommand { get; }

        private bool CanDeleteValueCommandExecute(object p) => true;
        private void OnDeleteValueCommandExecuted(object p)
        {
            SelectedTable.Values.Remove(SelectedValue);
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

            SelectedTable.SeveTable();
            AllDB = new FullBase(StaticPath, StaticName);
        }

        #endregion

        #region DeleteTableCommand

        public ICommand DeleteTableCommand { get; }

        private bool CanDeleteTableCommandExecute(object p) => true;
        private void OnDeleteTableCommandExecuted(object p)
        {
            SelectedTable.DeleteTable();
            AllDB = new FullBase(StaticPath,StaticName);
        }
        #endregion

        public DatabaseWindowViewModel()
        {

            CreadeValuesCommand = new LambdaCommand(OnCreadeValuesCommandExecuted, CanCreadeValuesCommandExecute);
            SaveAllTablesCommand = new LambdaCommand(OnSaveAllTablesCommandExecuted, CanSaveAllTablesCommandExecute);
            AddValuesCommand = new LambdaCommand(OnAddValuesCommandExecuted, CanAddValuesCommandExecute);
            DeleteValueCommand = new LambdaCommand(OnDeleteValueCommandExecuted, CanDeleteValueCommandExecute);
            DeleteTableCommand = new LambdaCommand(OnDeleteTableCommandExecuted, CanDeleteTableCommandExecute);
            SaveTablesCommand = new LambdaCommand(OnSaveTablesCommandExecuted, CanSaveTablesCommandExecute);
            AddNewTableCommand = new LambdaCommand(OnAddNewTableCommandExecuted, CanAddNewTableCommandExecute);
            AllDB = new FullBase(StaticPath, StaticName);
        }
    }
}
