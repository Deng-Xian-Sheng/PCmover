using System;
using System.Diagnostics;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace WizardModule.ViewModels.Dialogs
{
	// Token: 0x020000B6 RID: 182
	public class NoComputersFoundViewModel : BindableBase, INavigationAware
	{
		// Token: 0x06000F5E RID: 3934 RVA: 0x000288D0 File Offset: 0x00026AD0
		public NoComputersFoundViewModel()
		{
			this.OnClose = new DelegateCommand(new Action(this.OnCloseCommand), new Func<bool>(this.CanOnCloseCommand));
			this.OnDownload = new DelegateCommand(new Action(this.OnDownloadCommand), new Func<bool>(this.CanOnDownloadCommand));
		}

		// Token: 0x170006BB RID: 1723
		// (get) Token: 0x06000F5F RID: 3935 RVA: 0x00028929 File Offset: 0x00026B29
		// (set) Token: 0x06000F60 RID: 3936 RVA: 0x00028931 File Offset: 0x00026B31
		public bool IsFTAHidden
		{
			get
			{
				return this._IsFTAHidden;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsFTAHidden, value, "IsFTAHidden");
			}
		}

		// Token: 0x170006BC RID: 1724
		// (get) Token: 0x06000F61 RID: 3937 RVA: 0x00028946 File Offset: 0x00026B46
		// (set) Token: 0x06000F62 RID: 3938 RVA: 0x0002894E File Offset: 0x00026B4E
		public bool IsDownloadVisible
		{
			get
			{
				return this._IsDownloadVisible;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsDownloadVisible, value, "IsDownloadVisible");
			}
		}

		// Token: 0x170006BD RID: 1725
		// (get) Token: 0x06000F63 RID: 3939 RVA: 0x00028963 File Offset: 0x00026B63
		// (set) Token: 0x06000F64 RID: 3940 RVA: 0x0002896B File Offset: 0x00026B6B
		public DelegateCommand OnClose { get; private set; }

		// Token: 0x06000F65 RID: 3941 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCloseCommand()
		{
			return true;
		}

		// Token: 0x06000F66 RID: 3942 RVA: 0x00028974 File Offset: 0x00026B74
		private void OnCloseCommand()
		{
			Action<object> resultCallback = this.ResultCallback;
			if (resultCallback == null)
			{
				return;
			}
			resultCallback(null);
		}

		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x06000F67 RID: 3943 RVA: 0x00028987 File Offset: 0x00026B87
		// (set) Token: 0x06000F68 RID: 3944 RVA: 0x0002898F File Offset: 0x00026B8F
		public DelegateCommand OnDownload { get; private set; }

		// Token: 0x06000F69 RID: 3945 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnDownloadCommand()
		{
			return true;
		}

		// Token: 0x06000F6A RID: 3946 RVA: 0x00028998 File Offset: 0x00026B98
		private void OnDownloadCommand()
		{
			try
			{
				Process.Start(new ProcessStartInfo(Resources.FPP_Download));
			}
			catch
			{
			}
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000F6C RID: 3948 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000F6D RID: 3949 RVA: 0x000289CC File Offset: 0x00026BCC
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			Events.OverlayPopupArgs overlayPopupArgs = (Events.OverlayPopupArgs)navigationContext.Parameters["Param"];
			this.ResultCallback = overlayPopupArgs.PopupResultCallback;
			this.OnClosePopup = overlayPopupArgs.ClosePopupCallback;
			this.IsFTAHidden = string.IsNullOrWhiteSpace(Resources.FTAURL);
			this.IsDownloadVisible = !Resources.Edition.StartsWith("Enterprise");
		}

		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x06000F6E RID: 3950 RVA: 0x00028A2F File Offset: 0x00026C2F
		// (set) Token: 0x06000F6F RID: 3951 RVA: 0x00028A37 File Offset: 0x00026C37
		private Action<object> ResultCallback { get; set; }

		// Token: 0x170006C0 RID: 1728
		// (get) Token: 0x06000F70 RID: 3952 RVA: 0x00028A40 File Offset: 0x00026C40
		// (set) Token: 0x06000F71 RID: 3953 RVA: 0x00028A48 File Offset: 0x00026C48
		private Action OnClosePopup { get; set; }

		// Token: 0x0400053D RID: 1341
		private bool _IsFTAHidden;

		// Token: 0x0400053E RID: 1342
		private bool _IsDownloadVisible;
	}
}
