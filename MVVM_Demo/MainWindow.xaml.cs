using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Demo
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Person> Persons { get; set; }

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get => _selectedPerson;
            set => SetField(ref _selectedPerson, value);
        }

        public LambdaCommand DeleteCommand { get; set; }
        
        public MainWindow()
        {
            Persons = new ObservableCollection<Person>()
            {
                new()
                {
                    Id = 1,
                    LastName = "Starinin",
                    FirstName = "Andrey"
                },
                new()
                {
                    Id = 2,
                    LastName = "Petrov",
                    FirstName = "Petr"
                },
                new()
                {
                    Id = 3,
                    LastName = "Иванов",
                    FirstName = "Иван"
                }
            };

            DeleteCommand = new LambdaCommand(
                canExecute: () => true,
                execute: () => Persons.Remove(SelectedPerson)
                    );
            
            InitializeComponent();
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
}