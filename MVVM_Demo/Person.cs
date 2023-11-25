using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Demo;

public class Person : INotifyPropertyChanged
{
    private int _id;
    public int Id
    {
        get => _id; 
        set => SetField(ref _id, value);
    }

    private string _lastName;
    public string LastName
    {
        get => _lastName;
        set => SetField(ref _lastName, value);
    }

    private string _firstName;
    public string FirstName
    {
        get => _firstName;
        set => SetField(ref _firstName, value);
        /*
        set
        {
            if (_firstName == value) return;
            _firstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
        */
    }
    
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}