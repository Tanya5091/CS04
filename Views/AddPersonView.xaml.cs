using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CS4.Navigation;
using CS4.ViewModels;

namespace CS4.Views
{
	/// <summary>
	/// Interaction logic for PersonInfoView.xaml
	/// </summary>
	public partial class AddPersonView : UserControl, INavigatable
	{
		public AddPersonView()
		{
			InitializeComponent();
			DataContext = new AddPersonViewModel();
		}
	}
}
