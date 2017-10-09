using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SWExtension.Jira.Mvvm
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void Set<T>(ref T obj, T value, [CallerMemberName] string propertyName = null)
        {
            obj = value;
            RaisePropertyChanged(propertyName);
        }

        protected bool IsInDesignMode()
        {
            return DesignerProperties.GetIsInDesignMode(new DependencyObject());
        }
    }
}
