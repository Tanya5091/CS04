using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CS4.DataStorage;
using CS4.Managers;
using CS4.Navigation;
using CS4.ViewModels;

namespace CS4
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, IContentOwner
	{
		public ContentControl ContentControl
		{
			get { return _contentControl; }
		}
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new MainWindowViewModel();
			StationManager.Initialize(new SerializedDataStorage());
			NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
			NavigationManager.Instance.Navigate(ViewType.PeopleList);
		}

		
	}
}
