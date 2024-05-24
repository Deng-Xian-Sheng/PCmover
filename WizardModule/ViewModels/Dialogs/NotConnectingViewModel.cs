using System;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace WizardModule.ViewModels.Dialogs
{
	// Token: 0x020000B7 RID: 183
	public class NotConnectingViewModel : BindableBase, INavigationAware
	{
		// Token: 0x06000F72 RID: 3954 RVA: 0x00028A54 File Offset: 0x00026C54
		public NotConnectingViewModel()
		{
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnCancel = new DelegateCommand(new Action(this.OnCancelCommand), new Func<bool>(this.CanOnCancelCommand));
		}

		// Token: 0x170006C1 RID: 1729
		// (get) Token: 0x06000F73 RID: 3955 RVA: 0x00028AAD File Offset: 0x00026CAD
		// (set) Token: 0x06000F74 RID: 3956 RVA: 0x00028AB5 File Offset: 0x00026CB5
		private Action<object> ResultCallback { get; set; }

		// Token: 0x170006C2 RID: 1730
		// (get) Token: 0x06000F75 RID: 3957 RVA: 0x00028ABE File Offset: 0x00026CBE
		// (set) Token: 0x06000F76 RID: 3958 RVA: 0x00028AC6 File Offset: 0x00026CC6
		private Action OnClosePopup { get; set; }

		// Token: 0x06000F77 RID: 3959 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000F79 RID: 3961 RVA: 0x00028AD0 File Offset: 0x00026CD0
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			Events.OverlayPopupArgs overlayPopupArgs = (Events.OverlayPopupArgs)navigationContext.Parameters["Param"];
			this.ResultCallback = overlayPopupArgs.PopupResultCallback;
			this.OnClosePopup = overlayPopupArgs.ClosePopupCallback;
		}

		// Token: 0x170006C3 RID: 1731
		// (get) Token: 0x06000F7A RID: 3962 RVA: 0x00028B0B File Offset: 0x00026D0B
		// (set) Token: 0x06000F7B RID: 3963 RVA: 0x00028B13 File Offset: 0x00026D13
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000F7C RID: 3964 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnNextCommand()
		{
			return true;
		}

		// Token: 0x06000F7D RID: 3965 RVA: 0x00028B1C File Offset: 0x00026D1C
		private void OnNextCommand()
		{
			Action<object> resultCallback = this.ResultCallback;
			if (resultCallback != null)
			{
				resultCallback(new object());
			}
			Action onClosePopup = this.OnClosePopup;
			if (onClosePopup == null)
			{
				return;
			}
			onClosePopup();
		}

		// Token: 0x170006C4 RID: 1732
		// (get) Token: 0x06000F7E RID: 3966 RVA: 0x00028B44 File Offset: 0x00026D44
		// (set) Token: 0x06000F7F RID: 3967 RVA: 0x00028B4C File Offset: 0x00026D4C
		public DelegateCommand OnCancel { get; private set; }

		// Token: 0x06000F80 RID: 3968 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelCommand()
		{
			return true;
		}

		// Token: 0x06000F81 RID: 3969 RVA: 0x00028B55 File Offset: 0x00026D55
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
