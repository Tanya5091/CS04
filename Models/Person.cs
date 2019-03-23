using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using CS4.Exceptions;
using CS4.Annotations;

namespace CS4.Models
{
	[Serializable]
	internal class Person: INotifyPropertyChanged
	{
	#region Fields
		private string _firstName;
		private string _lastName;
		private DateTime _birthDate;
		private string _email;
		private string _isAdult;
		private string _sunSign;
		private string _chineseSign;
		private bool _isBirthday;
		private readonly string[] _sunSigns =
		{
			"Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio",
			"Sagittarius"
		};

		private readonly string[] _chineseHoroscopes =
			{"Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Sheep"};

	#endregion
		public Person(string firstName, string lastName, DateTime birthDate, string email)
		{
			FirstName = firstName;
			LastName = lastName;
			BirthDate = birthDate;
			CheckValidity(birthDate);
			Email = email;
			//if (!(new EmailAddressAttribute().IsValid(email)))
			//	throw new InvalidEmailException(Email);
			AgeDetection(birthDate);
			Chinese(birthDate);
			SunSignCalc(birthDate);

		}
		public Person(string firstName, string lastName, DateTime birthDate)
		{
			FirstName = firstName;
			LastName = lastName;
			BirthDate = birthDate;
			Email = "no@no.no";
		}

		public Person(string firstName, string lastName, string email)
		{
			FirstName = firstName;
			LastName = lastName;
			BirthDate = new DateTime(2000, 01, 01);
			Email = email;
		}

		public void SunSignCalc(DateTime date)
		{
			int zodN = 0;
			var day = date.Day;
			switch (date.Month)
			{
				case 1:

					zodN = day < 21 ? 0 : 1;
					break;
				case 2:
					zodN = day < 20 ? 1 : 2;
					break;
				case 3:

					zodN = day < 22 ? 2 : 3;
					break;
				case 4:
					zodN = day < 21 ? 3 : 4;
					break;
				case 5:

					zodN = day < 22 ? 4 : 5;
					break;
				case 6:
					zodN = day < 22 ? 5 : 6;
					break;
				case 7:

					zodN = day < 24 ? 6 : 7;
					break;
				case 8:
					zodN = day < 24 ? 7 : 8;
					break;
				case 9:

					zodN = day < 24 ? 8 : 9;
					break;
				case 10:
					zodN = day < 24 ? 9 : 10;
					break;
				case 11:

					zodN = day < 23 ? 10 : 11;
					break;
				case 12:
					zodN = day < 23 ? 11 : 0;
					break;
			}
			SunSign = _sunSigns[zodN];
		}
		public void Chinese(DateTime date)
		{
			ChineseSign = _chineseHoroscopes[date.Year % 12];
		}


		private void AgeDetection(DateTime date)
		{
			var years = DateTime.Today.Year - date.Year;
			if (DateTime.Today.Month < date.Month ||
				(DateTime.Today.Month == date.Month && DateTime.Today.Day < date.Day))
			{
				years--;
			}

			IsAdult = (years > 17) ? "Adult" : "Underage";
			if (date.Day == DateTime.Today.Day && DateTime.Today.Month == date.Month)
				IsBirthday = true;
			else
				IsBirthday = false;
		}

		private void CheckValidity(DateTime date)
		{
			if (FullAge(date) > 134)
			{
				throw new TooFarBirthdayException(date);
			}
			if (DateTime.Today.Year < date.Year || DateTime.Today.DayOfYear < date.DayOfYear && DateTime.Today.Year == date.Year)
				throw new FutureBirthdayException(date);
		}
		private int FullAge(DateTime birth)
		{
			int years = DateTime.Today.Year - birth.Year;
			if (DateTime.Today.Month < birth.Month || (DateTime.Today.Month == birth.Month && DateTime.Today.Day < birth.Day))
			{
				years--;
			}
			return years;
		}

		public string FirstName
		{
			get { return _firstName; }
			 set { _firstName = value; OnPropertyChanged(); }
}

		public string LastName
		{
			get { return _lastName; }
			 set { _lastName = value; OnPropertyChanged(); }
}

		public DateTime BirthDate
		{
			get { return _birthDate; }
			 set { _birthDate = value; OnPropertyChanged(); }
}

		public string Email
		{
			get { return _email; }
			 set { _email = value; OnPropertyChanged(); }
}

		public string IsAdult
		{
			get { return _isAdult; }
			 set { _isAdult = value; OnPropertyChanged(); }
}

		public string SunSign
		{
			get { return _sunSign; }
			 set { _sunSign = value; OnPropertyChanged(); }
		}

		public string ChineseSign
		{
			get { return _chineseSign; }
			private set { _chineseSign = value; OnPropertyChanged(); }
		}

		public bool IsBirthday
		{
			get { return _isBirthday; }
			private set { _isBirthday = value; OnPropertyChanged(); }
}
		[field:NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
