using System;
using System.Collections.ObjectModel;
using Laplink.Pcmover.Contracts;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace WizardModule.ViewModels.Dialogs
{
	// Token: 0x020000B8 RID: 184
	public class OtherComputersFoundViewModel : BindableBase, INavigationAware
	{
		// Token: 0x06000F82 RID: 3970 RVA: 0x00028B79 File Offset: 0x00026D79
		public OtherComputersFoundViewModel()
		{
			this.OnClose = new DelegateCommand(new Action(this.OnCloseCommand), new Func<bool>(this.CanOnCloseCommand));
		}

		// Token: 0x170006C5 RID: 1733
		// (get) Token: 0x06000F83 RID: 3971 RVA: 0x00028BA4 File Offset: 0x00026DA4
		// (set) Token: 0x06000F84 RID: 3972 RVA: 0x00028BAC File Offset: 0x00026DAC
		public ObservableCollection<ConnectableMachine> OtherMachines
		{
			get
			{
				return this._OtherMachines;
			}
			private set
			{
				this.SetProperty<ObservableCollection<ConnectableMachine>>(ref this._OtherMachines, value, "OtherMachines");
			}
		}

		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x06000F85 RID: 3973 RVA: 0x00028BC1 File Offset: 0x00026DC1
		public string MainText
		{
			get
			{
				return Tools.GetResourceString("FPP_Others");
			}
		}

		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x06000F86 RID: 3974 RVA: 0x00028BCD File Offset: 0x00026DCD
		// (set) Token: 0x06000F87 RID: 3975 RVA: 0x00028BD5 File Offset: 0x00026DD5
		public DelegateCommand OnClose { get; private set; }

		// Token: 0x06000F88 RID: 3976 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCloseCommand()
		{
			return true;
		}

		// Token: 0x06000F89 RID: 3977 RVA: 0x00028BDE File Offset: 0x00026DDE
		private void OnCloseCommand()
		{
			Action onClosePopup = this.OnClosePopup;
			if (onClosePopup != null)
			{
				onClosePopup();
			}
			Action<object> resultCallback = this.ResultCallback;
			if (resultCallback == null)
			{
				return;
			}
			resultCallback(null);
		}

		// Token: 0x06000F8A RID: 3978 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000F8B RID: 3979 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000F8C RID: 3980 RVA: 0x00028C04 File Offset: 0x00026E04
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			Events.OverlayPopupArgs overlayPopupArgs = (Events.OverlayPopupArgs)navigationContext.Parameters["Param"];
			this.OtherMachines = (ObservableCollection<ConnectableMachine>)overlayPopupArgs.Parameter;
			this.ResultCallback = overlayPopupArgs.PopupResultCallback;
			this.OnClosePopup = overlayPopupArgs.ClosePopupCallback;
		}

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x06000F8D RID: 3981 RVA: 0x00028C50 File Offset: 0x00026E50
		// (set) Token: 0x06000F8E RID: 3982 RVA: 0x00028C58 File Offset: 0x00026E58
		private Action<object> ResultCallback { get; set; }

		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x06000F8F RID: 3983 RVA: 0x00028C61 File Offset: 0x00026E61
		// (set) Token: 0x06000F90 RID: 3984 RVA: 0x00028C69 File Offset: 0x00026E69
		private Action OnClosePopup { get; set; }

		// Token: 0x04000547 RID: 1351
		private ObservableCollection<ConnectableMachine> _OtherMachines;
	}
}
