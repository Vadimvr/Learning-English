using LElWPF.Core.ViewModels.Windows;
using Microsoft.Win32;

namespace LElWPF.Core.ViewModels.Base
{
    public class DefaultDialogService : IDialogService
    {
        public string File{ get; set; }
        public string Path { get; set; }
        public string FilePath { get; set; }
        
        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                int temp = GetIndexFileName(openFileDialog.FileName);
                Path = openFileDialog.FileName.Substring(0,temp);
                File = openFileDialog.FileName[temp..];
                return true;
            }
            return false;
        }

        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }
        int GetIndexFileName(string filepath)
        {
            int temp = 0;
            for (int i = 0; i < filepath.Length; i++)
            {
                if (filepath[i] == '\\')
                    temp = i;
            }
            return temp+1;
        }
    }
}
