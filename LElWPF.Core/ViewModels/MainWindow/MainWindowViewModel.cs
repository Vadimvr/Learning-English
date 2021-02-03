using LElWPF.Core.Infrastructure.Commands;
using LElWPF.Core.Models.db;
using LElWPF.Core.ViewModels.Base;
using LElWPF.Core.Views.Windows;

namespace LElWPF.Core.ViewModels
{
    partial class  MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {

            
            OpenDatabaseWindowCommand = new LambdaCommand(OnOpenDatabaseWindowCommandExecuted, CanOpenDatabaseWindowCommandExecute);
            DB = new ConectionDB(@"D:\test\","test.db");
            RandomValues = DB.GetRandomValues();
            OpenDictionaryCommand = new LambdaCommand(OnOpenDictionaryCommandExecuted, CanOpenDictionaryCommandExecute);
            DisplayHintCommand = new LambdaCommand(OnDisplayHintCommandExecuted, CanDisplayHintCommandExecute);
            RepeatSoundFileCommand = new LambdaCommand(OnRepeatSoundFileCommandExecuted, CanRepeatSoundFileCommandExecute);
            ClickButtonCheckCommand = new LambdaCommand(OnClickButtonCheckCommandExecuted, CanClickButtonCheckCommandExecute);
        }
    }
}
