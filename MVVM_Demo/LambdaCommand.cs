using System;
using System.Windows.Input;

namespace MVVM_Demo;

public class LambdaCommand : ICommand
{
    private readonly Func<bool> _canExecute;
    private readonly Action _execute;

    public LambdaCommand(Func<bool> canExecute, Action execute)
    {
        _canExecute = canExecute;
        _execute = execute;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute();
    }

    public void Execute(object? parameter)
    {
        _execute();
    }

    public event EventHandler? CanExecuteChanged;
}