using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace LElWPF.Core.ViewModels.Base
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S3881:\"IDisposable\" should be implemented correctly", Justification = "<Pending>")]
    internal abstract class ViewModel : INotifyPropertyChanged, IDisposable
    { 
        private static string staticPath = "";
        private static string staticName = "";

#pragma warning disable S2696 // Instance members should not write to "static" fields
        public string StaticPath { get => staticPath; set => staticPath = value; }
        public string StaticName { get => staticName; set => staticName = value; }
#pragma warning restore S2696 // Instance members should not write to "static" fields


        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T filed, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(filed, value)) return false;
            filed = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
        #endregion

        public void Dispose()
        {
            Dispose(true);
        }
        private bool _Disposed;


        protected virtual void Dispose(bool Disposing)
        {
            if (_Disposed || !Disposing) return;
            _Disposed = true;
        }
    }
}