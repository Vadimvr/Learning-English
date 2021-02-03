using LElWPF.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LElWPF.Core.Models.db;

namespace LElWPF.Core.ViewModels.DatabaseWindow
{
    class DatabaseWindowViewModel : ViewModel
    {
        public ObservableCollection<TableInDB> AllDB { get; }

        #region SelectedTable

        
        private TableInDB _SelectedTable;

       
        public TableInDB SelectedTable
        {
            get => _SelectedTable;
            set => Set(ref _SelectedTable, value);
        }

        #endregion
        public DatabaseWindowViewModel()
        {

            СreationTableInDB сreationTableInDB = new СreationTableInDB(@"D:\test\", "test2.db");
            AllDB = сreationTableInDB.GetFullBase();
        }
    }
}
