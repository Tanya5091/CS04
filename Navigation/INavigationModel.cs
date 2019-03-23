namespace CS4.Navigation
{
	internal enum ViewType
	{
		PeopleList,
		AddPerson
	}

	interface INavigationModel
	{
		void Navigate(ViewType viewType);
	}
}
