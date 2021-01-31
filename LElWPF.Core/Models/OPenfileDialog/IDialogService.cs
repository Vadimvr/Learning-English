using System;
using System.Collections.Generic;
using System.Text;

namespace LElWPF.Core.ViewModels.Windows
{
    public interface IDialogService
    {

        string FilePath { get; set; }
        string Path { get; set; }
        string File { get; set; }
        bool OpenFileDialog(); 
        bool SaveFileDialog();  
    }
}
