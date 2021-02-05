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
            StaticPath = System.AppDomain.CurrentDomain.BaseDirectory;
            StaticName = "data.db";
            FileFound = File.Exists(StaticPath + StaticName);
            Status = StaticPath;
            try
            {
                if (FileFound)
                {
                    DB = new RandomValueFromTable(StaticPath , StaticName);
                    RandomValues = DB.GetRandomValues();
                }
                else
                {
                    Status = System.AppDomain.CurrentDomain.BaseDirectory; 
                }
            }
            catch (System.Exception ex)
            {
                Status = ex.Message;
            }
            OpenSongLinkInBrowserCommand = new LambdaCommand(OnOpenSongLinkInBrowserCommandExecuted, CanOpenSongLinkInBrowserCommandExecute);
            OpenImageLinkInBrowserCommand = new LambdaCommand(OnOpenImageLinkInBrowserCommandExecuted, CanOpenImageLinkInBrowserCommandExecute);
            OpenDatabaseWindowCommand = new LambdaCommand(OnOpenDatabaseWindowCommandExecuted, CanOpenDatabaseWindowCommandExecute);
            OpenDictionaryCommand = new LambdaCommand(OnOpenDictionaryCommandExecuted, CanOpenDictionaryCommandExecute);
            DisplayHintCommand = new LambdaCommand(OnDisplayHintCommandExecuted, CanDisplayHintCommandExecute);
            RepeatSoundFileCommand = new LambdaCommand(OnRepeatSoundFileCommandExecuted, CanRepeatSoundFileCommandExecute);
            ClickButtonCheckCommand = new LambdaCommand(OnClickButtonCheckCommandExecuted, CanClickButtonCheckCommandExecute);
            NewNameCommand = new LambdaCommand(OnNewNameCommandExecuted, CanNewNameCommandExecute);
        }
    }
}
