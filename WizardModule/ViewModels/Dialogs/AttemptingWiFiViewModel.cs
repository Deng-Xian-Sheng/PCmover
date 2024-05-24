using System;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace WizardModule.ViewModels.Dialogs
{
	// Token: 0x020000B3 RID: 179
	public class AttemptingWiFiViewModel : BindableBase, INavigationAware
	{
		// Token: 0x06000F20 RID: 3872 RVA: 0x0002824C File Offset: 0x0002644C
		public AttemptingWiFiViewModel()
		{
			this.OnSender = new DelegateCommand(new Action(this.OnSenderCommand), new Func<bool>(this.CanOnSenderCommand));
			this.OnReceiver = new DelegateCommand(new Action(this.OnReceiverCommand), new Func<bool>(this.CanOnReceiverCommand));
			this.OnCancel = new DelegateCommand(new Action(this.OnCancelCommand), new Func<bool>(this.CanOnCancelCommand));
		}

		// Token: 0x170006A8 RID: 1704
		// (get) Token: 0x06000F21 RID: 3873 RVA: 0x000282C8 File Offset: 0x000264C8
		// (set) Token: 0x06000F22 RID: 3874 RVA: 0x000282D0 File Offset: 0x000264D0
		private Action<object> ResultCallback { get; set; }

		// Token: 0x170006A9 RID: 1705
		// (get) Token: 0x06000F23 RID: 3875 RVA: 0x000282D9 File Offset: 0x000264D9
		// (set) Token: 0x06000F24 RID: 3876 RVA: 0x000282E1 File Offset: 0x000264E1
		private Action OnClosePopup { get; set; }

		// Token: 0x06000F25 RID: 3877 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000F26 RID: 3878 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000F27 RID: 3879 RVA: 0x000282EC File Offset: 0x000264EC
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			Events.OverlayPopupArgs overlayPopupArgs = (Events.OverlayPopupArgs)navigationContext.Parameters["Param"];
			this.ResultCallback = overlayPopupArgs.PopupResultCallback;
			this.OnClosePopup = overlayPopupArgs.ClosePopupCallback;
		}

		// Token: 0x170006AA RID: 1706
		// (get) Token: 0x06000F28 RID: 3880 RVA: 0x00028327 File Offset: 0x00026527
		// (set) Token: 0x06000F29 RID: 3881 RVA: 0x0002832F File Offset: 0x0002652F
		public DelegateCommand OnSender { get; private set; }

		// Token: 0x06000F2A RID: 3882 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnSenderCommand()
		{
			return true;
		}

		// Token: 0x06000F2B RID: 3883 RVA: 0x00028338 File Offset: 0x00026538
		private void OnSenderCommand()
		{
			object obj = 0;
			Action<object> resultCallback = this.ResultCallback;
			if (resultCallback != null)
			{
				resultCallback(obj);
			}
			Action onClosePopup = this.OnClosePopup;
			if (onClosePopup == null)
			{
				return;
			}
			onClosePopup();
		}

		// Token: 0x170006AB RID: 1707
		// (get) Token: 0x06000F2C RID: 3884 RVA: 0x0002836E File Offset: 0x0002656E
		// (set) Token: 0x06000F2D RID: 3885 RVA: 0x00028376 File Offset: 0x00026576
		public DelegateCommand OnReceiver { get; private set; }

		// Token: 0x06000F2E RID: 3886 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnReceiverCommand()
		{
			return true;
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x00028380 File Offset: 0x00026580
		private void OnReceiverCommand()
		{
			object obj = 1;
			Action<object> resultCallback = this.ResultCallback;
			if (resultCallback != null)
			{
				resultCallback(obj);
			}
			Action onClosePopup = this.OnClosePopup;
			if (onClosePopup == null)
			{
				return;
			}
			onClosePopup();
		}

		// Token: 0x170006AC RID: 1708
		// (get) Token: 0x06000F30 RID: 3888 RVA: 0x000283B6 File Offset: 0x000265B6
		// (set) Token: 0x06000F31 RID: 3889 RVA: 0x000283BE File Offset: 0x000265BE
		public DelegateCommand OnCancel { get; private set; }

		// Token: 0x06000F32 RID: 3890 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelCommand()
		{
			return true;
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x000283C7 File Offset: 0x000265C7
		private void OnCancelCommand()
		{
			Action<object> resultCallback = this.ResultCallback;
			if (resultCallback != null)
			{
				resultCallback(null);
			}
			Action onClosePopup = this.OnClosePopup;
			if (onClosePopup == null)
			{
				return;
			}
			onClosePopup();
		}
	}
}
