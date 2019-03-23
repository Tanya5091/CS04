﻿using System;
using System.Windows;
using CS4.Models;
using CS4.DataStorage;

namespace CS4.Managers
{
	internal static class StationManager
	{
		public static event Action StopThreads;

		private static IDataStorage _dataStorage;

		internal static Person CurrentPerson { get; set; }

		internal static IDataStorage DataStorage
		{
			get { return _dataStorage; }
		}

		internal static void Initialize(IDataStorage dataStorage)
		{
			_dataStorage = dataStorage;
		}

		internal static void CloseApp()
		{
			MessageBox.Show("ShutDown");
			StopThreads?.Invoke();
			Environment.Exit(1);
		}
	}
}
