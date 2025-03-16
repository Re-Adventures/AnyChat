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

    public async void Execute(object? parameter)
    {
        viewModel.ErrorMessage = "Loggin in please wait";

        // Checking if the user's credentials are correct
        var userInDb = viewModel.context.Users
            .FirstOrDefault(user => user.Name == viewModel.Username
                && user.Password == viewModel.Password);

        if (userInDb == null)
        {
            viewModel.ErrorMessage = "Invalid username or password!";
            return;
        }

        userInDb.IsOnline = true;
        userInDb.LastLogin = DateTime.Now;

        await viewModel.context.SaveChangesAsync();

        viewModel.ErrorMessage = "Login Successful";

        // TODO: Show the Chat window
    }
}
