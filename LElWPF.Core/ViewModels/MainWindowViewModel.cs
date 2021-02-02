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
    partial class  MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            DB = new ConectionDB(@"D:\test\","test.db");
            RandomValues = DB.GetRandomValues();
            OpenDictionaryCommand = new LambdaCommand(OnOpenDictionaryCommandExecuted, CanOpenDictionaryCommandExecute);
            DisplayHintCommand = new LambdaCommand(OnDisplayHintCommandExecuted, CanDisplayHintCommandExecute);
            RepeatSoundFileCommand = new LambdaCommand(OnRepeatSoundFileCommandExecuted, CanRepeatSoundFileCommandExecute);
            ClickButtonCheckCommand = new LambdaCommand(OnClickButtonCheckCommandExecuted, CanClickButtonCheckCommandExecute);
        }
    }
}
