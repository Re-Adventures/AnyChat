﻿using AnyChat.Commands;
using AnyChat.Data;
using System.ComponentModel;

namespace AnyChat.ViewModel;

class LoginViewModel : INotifyPropertyChanged
{
	private string username;
	public string Username
	{
		get { return username; }
		set
		{
			username = value;
			OnChange(nameof(Username));
		}
	}

	private string password;
	public string Password
	{
		get { return password; }
		set
		{
			password = value;
			OnChange(nameof(Password));
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	public LoginButtonCommand LoginButtonCommand { get; set; }
	public readonly ApplicationDbContext context;

	public LoginViewModel()
	{
		username = "";
		password = "";

		LoginButtonCommand = new LoginButtonCommand(this);
		context = new ApplicationDbContext();
	}

	public void OnChange(string propertyName)
	{
		PropertyChanged?
			.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
