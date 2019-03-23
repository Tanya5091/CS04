using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CS4.Exceptions;
using CS4.Managers;
using CS4.Models;
using CS4.Navigation;
using CS4.Tools;

namespace CS4.ViewModels
{
	class AddPersonViewModel
	{
		private string _first;
		private string _last;
		private DateTime _date;
		private string _address;
		private Person current;
		private RelayCommand<object> _addPersonCommand;
		private RelayCommand<object> _cancelCommand;

		public string First
		{
			get { return _first; }
			set { _first = value; }
		}

		public string Last
		{
			get { return _last; }
			set { _last = value; }
		}

		public DateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}

		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}

		public Person Current
		{
			get { return current; }
			set { current = value; }
		}
		private bool CanExecuteCommand(object o)
		{
			return !(string.IsNullOrWhiteSpace(_first) || string.IsNullOrWhiteSpace(_last) || string.IsNullOrWhiteSpace(_date.ToString()) || string.IsNullOrWhiteSpace(_address));
		}
		public RelayCommand<object> AddPersonCommand =>
			_addPersonCommand ?? (_addPersonCommand = new RelayCommand<object>(AddPersonImplementation, CanExecuteCommand));
		public RelayCommand<object> CancelCommand =>
			_cancelCommand ?? (_cancelCommand = new RelayCommand<object>(CancelImplementation));

		private void CancelImplementation(object obj)
		{
			MessageBox.Show("Cancel", "Returning to main window");
			NavigationManager.Instance.Navigate(ViewType.PeopleList);
		}

		private async void AddPersonImplementation(object obj)
		{
			LoaderManager.Instance.ShowLoader();
			await Task.Run(() =>
			{
				try
				{
					var person = new Person(First, Last, Date, Address);
					StationManager.DataStorage.AddPerson(person);
					StationManager.CurrentPerson = person;
					MessageBox.Show("Success", $"User {First} {Last} was successfully created");

				}
				catch (InvalidEmailException)
				{
					MessageBox.Show("Cannot create user", "Invalid email");
				}
				catch (FutureBirthdayException)
				{
					MessageBox.Show("Cannot create user", "Invalid birthdate");
				}
				catch (TooFarBirthdayException)
				{
					MessageBox.Show("Cannot create user", "Invalid birthdate");
				}
				catch (Exception ex)

				{

					MessageBox.Show($"Sign Up failed for {First} {Last}. {ex.Message}");

					return false;

				}
				return true;
			});
			LoaderManager.Instance.HideLoader();
			First = null;
			Last = null;
			Address = null;
			NavigationManager.Instance.Navigate(ViewType.PeopleList);

		}
	}


}
