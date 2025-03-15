using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AnyChat.ViewModel
{
	public class MainViewModel : INotifyPropertyChanged
	{

		private ObservableCollection<string> items;

		public ObservableCollection<string> Items
		{
			get
			{
				return items;
			}
			set
			{
				items = value;
				OnChange(nameof(Items));
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		public MainViewModel()
		{
			items = [];

			if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
			{
				items.Add("Contact1");
				items.Add("Contact2");
				items.Add("Contact3");
				items.Add("Contact4");
			}
		}

		private void OnChange(string propertyName)
		{
			PropertyChanged?.Invoke(propertyName,
				new PropertyChangedEventArgs(propertyName));
		}
	}
}
