using AnyChat.Models;
using AnyChat.ViewModel;
using System.Windows.Input;

namespace AnyChat.Commands
{
    internal class RegisterButtonCommand : ICommand
    {
        private readonly RegisterViewModel viewModel;

        public event EventHandler? CanExecuteChanged
        {
            add    { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RegisterButtonCommand(RegisterViewModel vm)
        {
            viewModel = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return string.IsNullOrWhiteSpace(viewModel.Username) == false
                && string.IsNullOrWhiteSpace(viewModel.Password) == false
                && string.IsNullOrWhiteSpace(viewModel.Email)    == false;
        }

        public async void Execute(object? parameter)
        {
            // Checking if this username is already taken
            if (viewModel.context.Users
                .Any(user => user.Name == viewModel.Username))
            {
                viewModel.ErrorMessage = "Username is already taken";
                return;
            }

            // Checking if this email is already taken
            if (viewModel.context.Users
                .Any(user => user.Email == viewModel.Email))
            {
                viewModel.ErrorMessage = "Email is already taken";
                return;
            }

            var newUser = new User()
            {
                Name = viewModel.Username,
                Password = viewModel.Password,
                Email = viewModel.Email,
                IsOnline = false,
            };

            await viewModel.context.Users.AddAsync(newUser);
            await viewModel.context.SaveChangesAsync();

            viewModel.ErrorMessage = "User registered successfully. You can login now";

            // TODO: Show the login page now
        }
    }
}
