using System;
using System.Collections.Generic;
using System.Text;

namespace LElWPF.Core.ViewModels.Windows
{
    public interface IDialogService
    {
       
        string FilePath { get; set; }  
        bool OpenFileDialog(); 
        bool SaveFileDialog();  
    }
}
