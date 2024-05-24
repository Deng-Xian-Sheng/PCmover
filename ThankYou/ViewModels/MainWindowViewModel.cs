using System;
using System.Reflection;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using ThankYou.UIData;

namespace ThankYou.ViewModels
{
	// Token: 0x02000010 RID: 16
	public class MainWindowViewModel : BindableBase
	{
		// Token: 0x06000037 RID: 55 RVA: 0x000028B8 File Offset: 0x00000AB8
		public MainWindowViewModel(IUnityContainer container, IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			this.container = container;
			eventAggregator.GetEvent<PrismEvents.SetHeaderTitle>().Subscribe(new Action<string>(this.OnUpdateHeader));
			eventAggregator.GetEvent<PrismEvents.UIDownloadComplete>().Subscribe(new Action<MainData>(this.UIDownloadCompleted));
			eventAggregator.GetEvent<PrismEvents.DontShowCheckChanged>().Subscribe(new Action<bool>(this.OnDontShowCheckChanged));
			eventAggregator.GetEvent<PrismEvents.HideFooterChanged>().Subscribe(new Action<bool>(this.OnHideFooterChanged));
			this.OnSpecialOffers = new DelegateCommand(new Action(this.SpecialOfferClicked), new Func<bool>(this.CanSpecialOfferClick));
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000038 RID: 56 RVA: 0x0000295C File Offset: 0x00000B5C
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00002964 File Offset: 0x00000B64
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				this.SetProperty<string>(ref this._Title, value, "Title");
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002979 File Offset: 0x00000B79
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00002981 File Offset: 0x00000B81
		public string HeaderTitle
		{
			get
			{
				return this._HeaderTitle;
			}
			set
			{
				this.SetProperty<string>(ref this._HeaderTitle, value, "HeaderTitle");
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002996 File Offset: 0x00000B96
		// (set) Token: 0x0600003D RID: 61 RVA: 0x0000299E File Offset: 0x00000B9E
		public string Footer1
		{
			get
			{
				return this._Footer1;
			}
			set
			{
				this.SetProperty<string>(ref this._Footer1, value, "Footer1");
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600003E RID: 62 RVA: 0x000029B3 File Offset: 0x00000BB3
		// (set) Token: 0x0600003F RID: 63 RVA: 0x000029BB File Offset: 0x00000BBB
		public string Footer2
		{
			get
			{
				return this._Footer2;
			}
			set
			{
				this.SetProperty<string>(ref this._Footer2, value, "Footer2");
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000040 RID: 64 RVA: 0x000029D0 File Offset: 0x00000BD0
		// (set) Token: 0x06000041 RID: 65 RVA: 0x000029D8 File Offset: 0x00000BD8
		public string FooterUrlText
		{
			get
			{
				return this._FooterUrlText;
			}
			set
			{
				this.SetProperty<string>(ref this._FooterUrlText, value, "FooterUrlText");
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000042 RID: 66 RVA: 0x000029ED File Offset: 0x00000BED
		// (set) Token: 0x06000043 RID: 67 RVA: 0x000029F5 File Offset: 0x00000BF5
		public Visibility FooterVisibility
		{
			get
			{
				return this._FooterVisibility;
			}
			set
			{
				this.SetProperty<Visibility>(ref this._FooterVisibility, value, "FooterVisibility");
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002A0A File Offset: 0x00000C0A
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00002A12 File Offset: 0x00000C12
		public string DontShow
		{
			get
			{
				return this._DontShow;
			}
			set
			{
				this.SetProperty<string>(ref this._DontShow, value, "DontShow");
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00002A27 File Offset: 0x00000C27
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00002A30 File Offset: 0x00000C30
		public bool DontShowSelected
		{
			get
			{
				return this._DontShowSelected;
			}
			set
			{
				this.SetProperty<bool>(ref this._DontShowSelected, value, "DontShowSelected");
				if (this._DontShowSelected)
				{
					Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).DeleteValue("LaplinkOffers", false);
					return;
				}
				Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Run", "LaplinkOffers", Assembly.GetExecutingAssembly().Location, RegistryValueKind.String);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002A8E File Offset: 0x00000C8E
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00002A96 File Offset: 0x00000C96
		public DelegateCommand OnSpecialOffers { get; private set; }

		// Token: 0x0600004A RID: 74 RVA: 0x00002A9F File Offset: 0x00000C9F
		private bool CanSpecialOfferClick()
		{
			return true;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002AA2 File Offset: 0x00000CA2
		private void SpecialOfferClicked()
		{
			Tools.LaunchURL(this._FooterUrl);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002AAF File Offset: 0x00000CAF
		private void OnUpdateHeader(string title)
		{
			this.HeaderTitle = title;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002AB8 File Offset: 0x00000CB8
		private void UIDownloadCompleted(MainData UI)
		{
			this.Title = UI.Title;
			this.DontShow = UI.DontShow;
			this.Footer1 = UI.Footer1;
			this.Footer2 = UI.Footer2;
			this._FooterUrl = UI.FooterUrl;
			this.FooterUrlText = UI.FooterUrlText;
			Application.Current.MainWindow.Show();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002B1C File Offset: 0x00000D1C
		private void OnDontShowCheckChanged(bool IsChecked)
		{
			this.DontShowSelected = IsChecked;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002B25 File Offset: 0x00000D25
		private void OnHideFooterChanged(bool HideFooter)
		{
			this.FooterVisibility = (HideFooter ? Visibility.Collapsed : Visibility.Visible);
		}

		// Token: 0x0400000D RID: 13
		private readonly IEventAggregator eventAggregator;

		// Token: 0x0400000E RID: 14
		private readonly IUnityContainer container;

		// Token: 0x0400000F RID: 15
		private string _FooterUrl;

		// Token: 0x04000010 RID: 16
		private string _Title;

		// Token: 0x04000011 RID: 17
		private string _HeaderTitle;

		// Token: 0x04000012 RID: 18
		private string _Footer1;

		// Token: 0x04000013 RID: 19
		private string _Footer2;

		// Token: 0x04000014 RID: 20
		private string _FooterUrlText;

		// Token: 0x04000015 RID: 21
		private Visibility _FooterVisibility;

		// Token: 0x04000016 RID: 22
		private string _DontShow;

		// Token: 0x04000017 RID: 23
		private bool _DontShowSelected;
	}
}
