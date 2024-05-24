using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;
using Laplink.Pcmover.Contracts;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace WizardModule.ViewModels.Dialogs
{
	// Token: 0x020000B5 RID: 181
	public class MultipleComputersFoundViewModel : BindableBase, INavigationAware
	{
		// Token: 0x06000F49 RID: 3913 RVA: 0x0002865C File Offset: 0x0002685C
		public MultipleComputersFoundViewModel()
		{
			this.OnClose = new DelegateCommand(new Action(this.OnCloseCommand), new Func<bool>(this.CanOnCloseCommand));
			this.OnCancel = new DelegateCommand(new Action(this.OnCancelCommand), new Func<bool>(this.CanOnCancelCommand));
		}

		// Token: 0x170006B5 RID: 1717
		// (get) Token: 0x06000F4A RID: 3914 RVA: 0x000286B5 File Offset: 0x000268B5
		// (set) Token: 0x06000F4B RID: 3915 RVA: 0x000286BD File Offset: 0x000268BD
		public ObservableCollection<ConnectableMachine> Machines
		{
			get
			{
				return this._Machines;
			}
			private set
			{
				this.SetProperty<ObservableCollection<ConnectableMachine>>(ref this._Machines, value, "Machines");
			}
		}

		// Token: 0x170006B6 RID: 1718
		// (get) Token: 0x06000F4C RID: 3916 RVA: 0x000286D2 File Offset: 0x000268D2
		// (set) Token: 0x06000F4D RID: 3917 RVA: 0x000286DA File Offset: 0x000268DA
		public ConnectableMachine CurrentSelectedMachine
		{
			get
			{
				return this._CurrentSelectedMachine;
			}
			set
			{
				this.SetProperty<ConnectableMachine>(ref this._CurrentSelectedMachine, value, "CurrentSelectedMachine");
			}
		}

		// Token: 0x170006B7 RID: 1719
		// (get) Token: 0x06000F4E RID: 3918 RVA: 0x000286EF File Offset: 0x000268EF
		// (set) Token: 0x06000F4F RID: 3919 RVA: 0x000286F7 File Offset: 0x000268F7
		public DelegateCommand OnClose { get; private set; }

		// Token: 0x06000F50 RID: 3920 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCloseCommand()
		{
			return true;
		}

		// Token: 0x06000F51 RID: 3921 RVA: 0x00028700 File Offset: 0x00026900
		private void OnCloseCommand()
		{
			this.findUSBTimer.Stop();
			this.findUSBTimer.Tick -= this.FindUSBTimer_Tick;
			Action<object> resultCallback = this.ResultCallback;
			if (resultCallback != null)
			{
				resultCallback(this.CurrentSelectedMachine);
			}
			Action onClosePopup = this.OnClosePopup;
			if (onClosePopup == null)
			{
				return;
			}
			onClosePopup();
		}

		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x06000F52 RID: 3922 RVA: 0x00028756 File Offset: 0x00026956
		// (set) Token: 0x06000F53 RID: 3923 RVA: 0x0002875E File Offset: 0x0002695E
		public DelegateCommand OnCancel { get; private set; }

		// Token: 0x06000F54 RID: 3924 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelCommand()
		{
			return true;
		}

		// Token: 0x06000F55 RID: 3925 RVA: 0x00028768 File Offset: 0x00026968
		private void OnCancelCommand()
		{
			this.findUSBTimer.Stop();
			this.findUSBTimer.Tick -= this.FindUSBTimer_Tick;
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

		// Token: 0x06000F56 RID: 3926 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000F57 RID: 3927 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000F58 RID: 3928 RVA: 0x000287BC File Offset: 0x000269BC
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.CurrentSelectedMachine = null;
			Events.OverlayPopupArgs overlayPopupArgs = (Events.OverlayPopupArgs)navigationContext.Parameters["Param"];
			this.Machines = (ObservableCollection<ConnectableMachine>)overlayPopupArgs.Parameter;
			this.ResultCallback = overlayPopupArgs.PopupResultCallback;
			this.OnClosePopup = overlayPopupArgs.ClosePopupCallback;
			this.findUSBTimer = new DispatcherTimer
			{
				Interval = TimeSpan.FromSeconds(1.0)
			};
			this.findUSBTimer.Tick += this.FindUSBTimer_Tick;
			this.findUSBTimer.Start();
		}

		// Token: 0x06000F59 RID: 3929 RVA: 0x00028850 File Offset: 0x00026A50
		private void FindUSBTimer_Tick(object sender, EventArgs e)
		{
			if (this.CurrentSelectedMachine == null)
			{
				ObservableCollection<ConnectableMachine> machines = this.Machines;
				ConnectableMachine connectableMachine;
				if (machines == null)
				{
					connectableMachine = null;
				}
				else
				{
					connectableMachine = machines.FirstOrDefault((ConnectableMachine x) => x.Method == TransferMethodType.Usb);
				}
				ConnectableMachine connectableMachine2 = connectableMachine;
				if (connectableMachine2 != null)
				{
					this.CurrentSelectedMachine = connectableMachine2;
					return;
				}
			}
			else
			{
				this.findUSBTimer.Stop();
			}
		}

		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x06000F5A RID: 3930 RVA: 0x000288AD File Offset: 0x00026AAD
		// (set) Token: 0x06000F5B RID: 3931 RVA: 0x000288B5 File Offset: 0x00026AB5
		private Action<object> ResultCallback { get; set; }

		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x06000F5C RID: 3932 RVA: 0x000288BE File Offset: 0x00026ABE
		// (set) Token: 0x06000F5D RID: 3933 RVA: 0x000288C6 File Offset: 0x00026AC6
		private Action OnClosePopup { get; set; }

		// Token: 0x04000536 RID: 1334
		private DispatcherTimer findUSBTimer;

		// Token: 0x04000537 RID: 1335
		private ObservableCollection<ConnectableMachine> _Machines;

		// Token: 0x04000538 RID: 1336
		private ConnectableMachine _CurrentSelectedMachine;
	}
}
