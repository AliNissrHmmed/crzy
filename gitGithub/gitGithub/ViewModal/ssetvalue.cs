using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace gitGithub.ViewModal
{
    class ssetvalue : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string ProprtyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ProprtyName));
        }
        public void SetValue<T>(ref T backingField, T value, [CallerMemberName] string ProprtyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;
            backingField = value;
            OnPropertyChanged(ProprtyName);
        }

    }
}
