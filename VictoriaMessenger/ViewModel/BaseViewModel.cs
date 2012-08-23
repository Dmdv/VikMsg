using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.Phone.Controls;

namespace VictoriaMessenger.ViewModel
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		private PhoneApplicationPage _applicationPage;

		public event PropertyChangedEventHandler PropertyChanged;

		public bool IsOpenedFromPinned
		{
			get { return GetStateOrUrlParamNullable("pinToStart") == "1"; }
		}

		public bool IsPortraitOrientation
		{
			get
			{
				return Orientation == PageOrientation.Portrait ||
				       Orientation == PageOrientation.PortraitUp ||
				       Orientation == PageOrientation.PortraitDown;
			}
		}

		public bool IsLandscapeOrientation
		{
			get
			{
				return Orientation == PageOrientation.Landscape ||
				       Orientation == PageOrientation.LandscapeLeft ||
				       Orientation == PageOrientation.LandscapeRight;
			}
		}

		protected bool IsInDesignMode
		{
			get { return DesignerProperties.IsInDesignTool; }
		}

		protected Dispatcher Dispatcher
		{
			get { return Deployment.Current.Dispatcher; }
		}

		private PageOrientation Orientation
		{
			get { return ((PhoneApplicationFrame) Application.Current.RootVisual).Orientation; }
		}

		private IDictionary<string, object> PageState
		{
			get { return _applicationPage.State; }
		}

		public string GetStateOrUrlParam(string key)
		{
			var result = GetStateOrUrlParamNullable(key);
			if (result == null) throw new Exception("Key " + key + " not found");
			return result;
		}

		public T GetState<T>(string key)
		{
			if (PageState.ContainsKey(key))
			{
				return (T) PageState[key];
			}
			return default(T);
		}

		public virtual void OnNavigatedTo(PhoneApplicationPage page, NavigationEventArgs e)
		{
			_applicationPage = page;
		}

		public virtual void OnNavigatedFrom(PhoneApplicationPage page, NavigationEventArgs e)
		{
		}

		protected void OnPropertyChanged(string property)
		{
			OnPropertyChanged(new PropertyChangedEventArgs(property));
		}

		private void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, e);
		}

		private string GetStateOrUrlParamNullable(string key)
		{
			if (PageState.ContainsKey(key))
			{
				return (string) PageState[key];
			}
			if (_applicationPage.NavigationContext.QueryString.ContainsKey(key))
			{
				return _applicationPage.NavigationContext.QueryString[key];
			}
			return null;
		}
	}
}