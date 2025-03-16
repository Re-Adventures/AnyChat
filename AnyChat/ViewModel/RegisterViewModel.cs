using AnyChat.Commands;
using AnyChat.Data;
using System.ComponentModel;

namespace AnyChat.ViewModel
{
    internal class RegisterViewModel : INotifyPropertyChanged
    {
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnChange(nameof(Username));
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnChange(nameof(Password));
            }
        }

        private string email;

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnChange(nameof(Email));
            }
        }

        private string? errorMessage;

        public string? ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                OnChange(nameof(ErrorMessage));
            }
        }


        public ApplicationDbContext context = new ApplicationDbContext();
        public RegisterButtonCommand RegisterCommand { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnChange(string propertyName)
        {
            PropertyChanged?
                .Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RegisterViewModel()
        {
            RegisterCommand = new RegisterButtonCommand(this);
        }

    }
}
