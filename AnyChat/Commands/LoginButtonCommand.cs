using AnyChat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AnyChat.Commands;

class LoginButtonCommand : ICommand
{
    readonly LoginViewModel viewModel;
    public LoginButtonCommand(LoginViewModel vm)
    {
        viewModel = vm;
    }

    public event EventHandler? CanExecuteChanged
    {
        add    { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object? parameter)
    {
        return string.IsNullOrWhiteSpace(viewModel.Username) == false
            && string.IsNullOrWhiteSpace(viewModel.Password) == false;
    }

    public void Execute(object? parameter)
    {
        //viewModel.context.Users.FirstOrDefault()
        MessageBox.Show("Button Clicked");
    }
}
