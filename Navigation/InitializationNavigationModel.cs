using System;
using CS4.Navigation;
using CS4.Views;


namespace CS4.Navigation
{
	internal class InitializationNavigationModel : BaseNavigationModel
	{
		public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
		{

		}

		protected override void InitializeView(ViewType viewType)
		{
			switch (viewType)
			{
				case ViewType.PeopleList:
					ViewsDictionary.Add(viewType, new PeopleListView());
					break;
				case ViewType.AddPerson:
					ViewsDictionary.Add(viewType, new AddPersonView());
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
			}
		}
	}
}
