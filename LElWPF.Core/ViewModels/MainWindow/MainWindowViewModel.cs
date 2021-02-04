using LElWPF.Core.Infrastructure.Commands;
using LElWPF.Core.Models.db;
using LElWPF.Core.ViewModels.Base;
using LElWPF.Core.Views.Windows;
using System.IO;

namespace LElWPF.Core.ViewModels
{
    partial class MainWindowViewModel : ViewModel
    {
   
        public MainWindowViewModel()
        {
            FileFaind = File.Exists(StaticPath+ StaticName);


            Status = StaticPath;


            try
            {
                if (FileFaind)
                {
                    DB = new ConectionDB(StaticPath , StaticName);
                    RandomValues = DB.GetRandomValues();
                }
                else
                {
                    Status =  "Not found " + StaticPath + StaticName; 
                }
            }
            catch (System.Exception ex)
            {
                Status = ex.Message;
            }
            OpenDatabaseWindowCommand = new LambdaCommand(OnOpenDatabaseWindowCommandExecuted, CanOpenDatabaseWindowCommandExecute);
            OpenDictionaryCommand = new LambdaCommand(OnOpenDictionaryCommandExecuted, CanOpenDictionaryCommandExecute);
            DisplayHintCommand = new LambdaCommand(OnDisplayHintCommandExecuted, CanDisplayHintCommandExecute);
            RepeatSoundFileCommand = new LambdaCommand(OnRepeatSoundFileCommandExecuted, CanRepeatSoundFileCommandExecute);
            ClickButtonCheckCommand = new LambdaCommand(OnClickButtonCheckCommandExecuted, CanClickButtonCheckCommandExecute);
        }
    }
}
