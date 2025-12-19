using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WishList.Maui.ViewModels.Base;

public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    // Notify the 'system' of a property that is updated
    // A propertyname can be supplied, when none is supplied it will use the name of the member calling this method (CallerMemberName),
    // usually this will be the property that called the method
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null!)
    {
        if (EqualityComparer<T>.Default.Equals(backingField, value))
            return false;

        backingField = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}