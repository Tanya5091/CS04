using System.Collections.Generic;
using CS4.Models;

namespace CS4.DataStorage
{
	internal interface IDataStorage
	{
		void AddPerson(Person person);
		void EditPerson(Person person, int position);
		void DeletePerson(Person person);
		List<Person> UsersList { get; set; }
	}
}
