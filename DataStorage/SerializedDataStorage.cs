using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using CS4.Managers;
using CS4.Models;
using CS4.Tools;

namespace CS4.DataStorage
{
	internal class SerializedDataStorage : IDataStorage
	{
		private static readonly string[] Names = {
			"Emily", "Hannah", "Madison", "Ashley", "Sarah", "Alexis", "Samantha", "Jessica",
			"Elizabeth", "Taylor", "Lauren", "Alyssa", "Kayla", "Abigail", "Brianna", "Olivia", "Emma", "Megan", "Grace", "Victoria",
			"Rachel", "Anna", "Sydney", "Destiny", "Morgan", "Jennifer", "Jasmine", "Haley", "Julia", "Kaitlyn", "Nicole", "Amanda",
			"Katherine", "Natalie", "Hailey", "Alexandra", "Savannah", "Chloe", "Rebecca", "Stephanie", "Maria", "Sophia", "Mackenzie",
			"Allison", "Isabella", "Amber", "Mary", "Danielle", "Gabrielle", "Jordan", "Brooke", "Michelle", "Sierra", "Katelyn", "Andrea",
			"Madeline", "Sara", "Kimberly", "Courtney", "Erin", "Brittany", "Vanessa", "Jenna", "Jacqueline", "Caroline", "Faith", "Makayla",
			"Bailey", "Paige", "Shelby", "Melissa", "Kaylee", "Christina", "Trinity", "Mariah", "Caitlin", "Autumn", "Marissa", "Breanna",
			"Angela", "Catherine", "Zoe", "Briana", "Jada", "Laura", "Claire", "Alexa", "Kelsey", "Kathryn", "Leslie", "Alexandria", "Sabrina",
			"Mia", "Isabel", "Molly", "Leah", "Katie", "Gabriella", "Cheyenne", "Cassandra","Michael","Matthew","Joshua","Christopher",
			"Nicholas","Andrew","Joseph","Daniel","Tyler","William","Brandon","Ryan","John","Zachary","David","Anthony","James","Justin",
			"Alexander","Jonathan","Christian","Austin","Dylan","Ethan","Benjamin","Noah","Samuel","Robert","Nathan","Cameron","Kevin",
			"Thomas","Jose","Hunter","Jordan","Kyle","Caleb","Jason","Logan","Aaron","Eric","Brian","Gabriel","Adam","Jack","Isaiah",
			"Juan","Luis","Connor","Charles","Elijah","Isaac","Steven","Evan","Jared","Sean","Timothy","Luke","Cody","Nathaniel","Alex",
			"Seth","Mason","Richard","Carlos","Angel","Patrick","Devin","Bryan"};

		private static readonly string[] LastNames =
		{
			"Anderson", "Ashwoon", "Aikin", "Bateman", "Bongard", "Bowers", "Boyd", "Cannon", "Cast", "Deitz", "Dewalt",
			"Ebner", "Frick",
			"Hancock", "Haworth", "Hesch", "Hoffman", "Kassing", "Knutson", "Lawless", "Lawicki", "Mccord", "McCormack",
			"Miller", "Myers",
			"Nugent", "Ortiz", "Orwig", "Ory", "Paiser", "Pak", "Pettigrew", "Quinn", "Quizoz", "Ramachandran",
			"Resnick", "Sagar",
			"Schickowski", "Schiebel", "Sellon", "Severson", "Shaffer", "Solberg", "Soloman", "Sonderling", "Soukup",
			"Soulis", "Stahl",
			"Sweeney", "Tandy", "Trebil", "Trusela", "Trussel", "Turco", "Uddin", "Uflan", "Ulrich", "Upson", "Vader",
			"Vail", "Valente",
			"Van Zandt", "Vanderpoel", "Ventotla", "Vogal", "Wagle", "Wagner", "Wakefield", "Weinstein", "Weiss", "Woo",
			"Yang", "Yates",
			"Yocum", "Zeaser", "Zeller", "Ziegler", "Bauer", "Baxster", "Casal", "Cataldi", "Caswell", "Celedon",
			"Chambers", "Chapman",
			"Christensen", "Darnell", "Davidson", "Davis", "DeLorenzo", "Dinkins", "Doran", "Dugelman", "Dugan",
			"Duffman", "Eastman",
			"Ferro", "Ferry", "Fletcher", "Fietzer", "Hylan", "Hydinger", "Illingsworth", "Ingram", "Irwin", "Jagtap",
			"Jenson", "Johnson",
			"Johnsen", "Jones", "Jurgenson", "Kalleg", "Kaskel", "Keller", "Leisinger", "LePage", "Lewis", "Linde",
			"Lulloff", "Maki",
			"Martin", "McGinnis", "Mills", "Moody", "Moore", "Napier", "Nelson", "Norquist", "Nuttle", "Olson",
			"Ostrander", "Reamer"
		};

		private List<Person> _people;

		internal SerializedDataStorage()
		{
			try
			{
				_people = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
			}
			catch (FileNotFoundException)
			{
				_people = new List<Person>();
				AddPeople();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void AddPeople()
		{
			Random random = new Random();
			for (int i = 0; i < 50; i++)
			{
				string name = Names[random.Next(0, Names.Length)];
				string last = LastNames[random.Next(0, LastNames.Length)];
				_people.Add(new Person(name, last, new DateTime(random.Next(1900, 2018), random.Next(1, 13), random.Next(1, 29)), last + "@gmail.com"));
			}
			SaveChanges();
		}


		public void AddPerson(Person person)
		{
			_people.Add(person);
			SaveChanges();
		}

		public void EditPerson(Person person, int position)
		{
			_people[position] = person;
		}

		public void DeletePerson(Person person)
		{
			if (_people.Contains(person))
			{
				_people.Remove(person);
				SaveChanges();
			}
		}


		public List<Person> UsersList
		{
			get { return _people.ToList(); }
			set { _people = value; }
		}

		public void SaveChanges()
		{
			SerializationManager.Serialize(_people, FileFolderHelper.StorageFilePath);
		}

	}
}

