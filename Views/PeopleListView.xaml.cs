using System.Windows.Controls;
using CS4.Navigation;
using CS4.ViewModels;

namespace CS4.Views
{
	/// <summary>
	/// Interaction logic for InfoView.xaml
	/// </summary>
	public partial class PeopleListView : UserControl, INavigatable
	{

		public PeopleListView()
		{
			InitializeComponent();
			DataContext = new PeopleListViewModel();
		}
	}
}
