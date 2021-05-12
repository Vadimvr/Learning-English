using LElWPF.Core.Infrastructure.Commands;
using LElWPF.Core.Models.db;
using LElWPF.Core.Models.pathFromDb;
using LElWPF.Core.ViewModels.Base;
using System;
using System.IO;


namespace LElWPF.Core.ViewModels
{
   
    partial class MainWindowViewModel : ViewModel
    { 
        public event EventHandler SetDbEventHandler;
        public void SetDb(object sendler, EventArgs args)
        {
            SetDb();
        }
        public void SetDb()
        {
            PathFromDb.GetPath();
            StaticName = PathFromDb.Name;
            StaticPath = PathFromDb.Path;
            FileFound = File.Exists(StaticPath + StaticName);
            Status = StaticPath;
            try
            {
                if (FileFound)
                {
                    DB = new RandomValueFromTable(StaticPath, StaticName);
                    if (DB.MaxEndIndex != 0)
                    {
                        RandomValues = DB.GetNextValues();
                        Status = DB.Index.ToString();
                        NamesTable = DB.NamesTable;
                    }
                }
                else
                {
                    Status = System.AppDomain.CurrentDomain.BaseDirectory;
                }
            }
            catch (System.Exception ex)
            {
                Status = "Please open DateBase file";
            }
        }
        public MainWindowViewModel()
        {
            SetDb();
            SetDbEventHandler += SetDb;
            ShowHintCommand = new LambdaCommand(OnShowHintCommandExecuted, CanShowHintCommandExecute);
            AccidentallyCommand = new LambdaCommand(OnAccidentallyCommandExecuted, CanAccidentallyCommandExecute);
            OpenSongLinkInBrowserCommand = new LambdaCommand(OnOpenSongLinkInBrowserCommandExecuted, CanOpenSongLinkInBrowserCommandExecute);
            OpenImageLinkInBrowserCommand = new LambdaCommand(OnOpenImageLinkInBrowserCommandExecuted, CanOpenImageLinkInBrowserCommandExecute);
            OpenDatabaseWindowCommand = new LambdaCommand(OnOpenDatabaseWindowCommandExecuted, CanOpenDatabaseWindowCommandExecute);
            OpenDictionaryCommand = new LambdaCommand(OnOpenDictionaryCommandExecuted, CanOpenDictionaryCommandExecute);
            DisplayHintCommand = new LambdaCommand(OnDisplayHintCommandExecuted, CanDisplayHintCommandExecute);
            RepeatSoundFileCommand = new LambdaCommand(OnRepeatSoundFileCommandExecuted, CanRepeatSoundFileCommandExecute);
            ClickButtonCheckCommand = new LambdaCommand(OnClickButtonCheckCommandExecuted, CanClickButtonCheckCommandExecute);
            NewNameCommand = new LambdaCommand(OnNewNameCommandExecuted, CanNewNameCommandExecute);
            DoNotCheckAnswersCommand = new LambdaCommand(OnDoNotCheckAnswersCommandExecuted, CanDoNotCheckAnswersCommandExecute);
        }
    }
}
