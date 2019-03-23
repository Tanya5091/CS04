using System.Windows;
using CS4.Managers;
using CS4.Tools;
using CS4.ViewModels;


namespace CS4.ViewModels
{
	internal class MainWindowViewModel : BaseViewModel, ILoaderOwner
	{
		#region Fields
		private Visibility _loaderVisibility = Visibility.Hidden;
		private bool _isControlEnabled = true;
		#endregion

		#region Properties
		public Visibility LoaderVisibility
		{
			get { return _loaderVisibility; }
			set
			{
				_loaderVisibility = value;
				OnPropertyChanged();
			}
		}
		public bool IsControlEnabled
		{
			get { return _isControlEnabled; }
			set
			{
				_isControlEnabled = value;
				OnPropertyChanged();
			}
		}
		#endregion

		internal MainWindowViewModel()
		{
			LoaderManager.Instance.Initialize(this);
		}
	}
}
