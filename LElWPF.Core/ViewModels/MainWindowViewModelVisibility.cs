using LElWPF.Core.Infrastructure.Commands;
using LElWPF.Core.Models;
using LElWPF.Core.Models.db;
using LElWPF.Core.ViewModels.Base;
using LElWPF.Core.ViewModels.Windows;
using System;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace LElWPF.Core.ViewModels
{
    partial class MainWindowViewModel : ViewModel
    {
        #region Visibility

        #region FirstStartApp

        private Visibility _FirstStartApp = Visibility.Collapsed;
        public Visibility FirstStartApp { get => _FirstStartApp; set => Set(ref _FirstStartApp, value); }

        #endregion

        #region BorderHintVisibility

        private Visibility _BorderHintVisibility = Visibility.Collapsed;
        public Visibility BorderHintVisibility { get => _BorderHintVisibility; set => Set(ref _BorderHintVisibility, value); }

        #endregion

        #region ButtonHelpVisibility

        private Visibility _ButtonHelpVisibility = Visibility.Collapsed;
        public Visibility ButtonHelpVisibility { get => _ButtonHelpVisibility; set => Set(ref _ButtonHelpVisibility, value); }

        #endregion

        #endregion
    }
}
