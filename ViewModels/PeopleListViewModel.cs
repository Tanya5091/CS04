using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using CS4.DataStorage;
using CS4.Managers;
using CS4.Models;
using CS4.Tools;
using CS4.Navigation;

namespace CS4.ViewModels
{
	class PeopleListViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<Person> _people;
		private RelayCommand<object> _addCommand;
		private RelayCommand<object> _restoreCommand;
		private RelayCommand<object> _deleteCommand;
		private RelayCommand<object> _updateCommand;
		private RelayCommand<object> _sortCommand;
		private RelayCommand<object> _filterCommand;
		private string _key;
		private string _propertyChoice;
		private Person _current;


		internal PeopleListViewModel()
		{
			_people = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
		}
		public ObservableCollection<Person> People
		{
			get => _people;
			set
			{
				_people = value;
				OnPropertyChanged();
			}
		}
		public Person Current
		{
			get => _current;
			 set
			{
				_current = value;
				OnPropertyChanged();
			}
		}

		public RelayCommand<object> AddCommand =>
			_addCommand ?? (_addCommand = new RelayCommand<object>(AddImplementation));

		private void AddImplementation(object obj)
		{
			NavigationManager.Instance.Navigate(ViewType.AddPerson);

		}
		public RelayCommand<object> DeleteCommand =>
			_deleteCommand ?? (_deleteCommand = new RelayCommand<object>(DeleteImplementation, CanDeleteCommand));

		private void DeleteImplementation(object obj)
		{
			MessageBox.Show($"Person {Current.FirstName} {Current.LastName} was deleted");
			StationManager.DataStorage.DeletePerson(Current);
			People = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
			Current = null;
		}

		public RelayCommand<object> RestoreCommand =>
			_restoreCommand ?? (_restoreCommand = new RelayCommand<object>(RestoreImplementation));

		private void RestoreImplementation(object obj)
		{
			People=new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
		}
		public RelayCommand<object> SortCommand =>
			_sortCommand ?? (_sortCommand = new RelayCommand<object>(SortImplementation, CanSortCommand));

		public RelayCommand<object> FilterCommand =>
			_filterCommand ?? (_filterCommand = new RelayCommand<object>(FilterImplementation, CanFilterCommand));


		private void FilterImplementation(object obj)
		{
		
			_people = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
			if (PropertyChoice.Contains("First Name"))
				People = new ObservableCollection<Person>(from p in People where p.FirstName.Contains(Key) select p);
			if (PropertyChoice.Contains("Last Name"))
				People = new ObservableCollection<Person>(from p in People where p.LastName.Contains(Key) select p);
			if (PropertyChoice.Contains("Email"))
				People = new ObservableCollection<Person>(from p in People where p.Email.Contains(Key) select p);
			if (PropertyChoice.Contains("Birth Date"))
				People = new ObservableCollection<Person>(from p in People where p.BirthDate.ToString().Contains(Key) select p);
			if (PropertyChoice.Contains("Sun Sign"))
				People = new ObservableCollection<Person>(from p in People where p.SunSign.Contains(Key) select p);
			if (PropertyChoice.Contains("Chinese Sign"))
				People = new ObservableCollection<Person>(from p in People where p.ChineseSign.Contains(Key) select p);
			if (PropertyChoice.Contains("Is Birthday"))
				People = new ObservableCollection<Person>(from p in People where p.IsBirthday.ToString().Contains(Key) select p);
			if (PropertyChoice.Contains("Is Adult"))
				People = new ObservableCollection<Person>(from p in People where p.IsAdult.Contains(Key) select p);

		}


		public string Key
		{
			get { return _key; }
			set { _key = value; OnPropertyChanged(); }
		}

		public string PropertyChoice
		{
			get { return _propertyChoice; }
			set { _propertyChoice = value; OnPropertyChanged(); }
		}

		private void SortImplementation(object obj)

		{
			_people = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);


			if(PropertyChoice.Contains("First Name"))
				People = new ObservableCollection<Person>(_people.OrderBy(p => p.FirstName));
			
			 else if (PropertyChoice.Contains("Last Name"))
			
				People = new ObservableCollection<Person>(_people.OrderBy(p => p.LastName));
			
			else if (PropertyChoice.Contains("Email"))
			{
				People = new ObservableCollection<Person>(_people.OrderBy(p => p.Email));
			}
			else if (PropertyChoice.Contains("Birth Date"))
			{
				People = new ObservableCollection<Person>(_people.OrderBy(p => p.BirthDate));
			}
			else if (PropertyChoice.Contains("Sun Sign"))
			{
				People = new ObservableCollection<Person>(_people.OrderBy(p => p.SunSign));
			}
			else if (PropertyChoice.Contains("Chinese Sign"))
			{
				People = new ObservableCollection<Person>(_people.OrderBy(p => p.ChineseSign));
			}
			else if (PropertyChoice.Contains("Is Adult"))
			{
				People = new ObservableCollection<Person>(_people.OrderBy(p => p.IsAdult));
			}
			else if (PropertyChoice.Contains("Is Birthday"))
			{
				People = new ObservableCollection<Person>(_people.OrderBy(p => p.IsBirthday));
			}
			else
			{
				_people= new ObservableCollection<Person>(_people.OrderBy(p=> p.FirstName));
			}
		
		}
		private bool CanDeleteCommand(object obj)
		{
			return _current != null;

		}
		private bool CanSortCommand(object obj)
		{
			return  _propertyChoice != null;

		}
		private bool CanFilterCommand(object obj)
		{
			return _propertyChoice != null && _key != null;

		}
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
