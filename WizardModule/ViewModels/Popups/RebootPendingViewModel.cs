using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Controls.Primitives;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using WizardModule.Properties;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000AB RID: 171
	public class RebootPendingViewModel : PopupViewModelBase
	{
		// Token: 0x06000ED3 RID: 3795 RVA: 0x00026FEC File Offset: 0x000251EC
		[Obsolete("Design only")]
		public RebootPendingViewModel()
		{
		}

		// Token: 0x06000ED4 RID: 3796 RVA: 0x000279E0 File Offset: 0x00025BE0
		public RebootPendingViewModel(IUnityContainer container, IPCmoverEngine pcmoverEngine, IEventAggregator eventAggregator, RebootPendingData data)
		{
			this._container = container;
			this._pcmoverEngine = pcmoverEngine;
			this._eventAggregator = eventAggregator;
			this._data = data;
			base.PopupData.Animation = PopupAnimation.Scroll;
			this._pcmoverEngine.CatchCommEx(delegate
			{
				this.Message = string.Format(Resources.RebootPendingMessage, this._pcmoverEngine.ThisMachine.NetName);
			}, ".ctor");
			this.OnReboot = new DelegateCommand(new Action(this.OnRebootCommand), new Func<bool>(this.CanOnRebootCommand));
			this.OnExit = new DelegateCommand(new Action(this.OnExitCommand), new Func<bool>(this.CanOnExitCommand));
			this.OnCancel = new DelegateCommand(new Action(this.OnCancelCommand), new Func<bool>(this.CanOnCancelCommand));
		}

		// Token: 0x17000690 RID: 1680
		// (get) Token: 0x06000ED5 RID: 3797 RVA: 0x00027AA2 File Offset: 0x00025CA2
		// (set) Token: 0x06000ED6 RID: 3798 RVA: 0x00027AAA File Offset: 0x00025CAA
		public string Message
		{
			get
			{
				return this._Message;
			}
			private set
			{
				this.SetProperty<string>(ref this._Message, value, "Message");
			}
		}

		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x06000ED7 RID: 3799 RVA: 0x00027ABF File Offset: 0x00025CBF
		// (set) Token: 0x06000ED8 RID: 3800 RVA: 0x00027AC7 File Offset: 0x00025CC7
		public DelegateCommand OnReboot { get; private set; }

		// Token: 0x06000ED9 RID: 3801 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnRebootCommand()
		{
			return true;
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x00027AD0 File Offset: 0x00025CD0
		private void OnRebootCommand()
		{
			RebootPendingData data = this._data;
			if (data != null)
			{
				AutoResetEvent resetEvent = data.ResetEvent;
				if (resetEvent != null)
				{
					resetEvent.Set();
				}
			}
			this._pcmoverEngine.CatchCommEx(delegate
			{
				this._pcmoverEngine.Reboot(2U);
				this.OnExitCommand();
			}, "OnRebootCommand");
		}

		// Token: 0x17000692 RID: 1682
		// (get) Token: 0x06000EDB RID: 3803 RVA: 0x00027B0C File Offset: 0x00025D0C
		// (set) Token: 0x06000EDC RID: 3804 RVA: 0x00027B14 File Offset: 0x00025D14
		public DelegateCommand OnExit { get; private set; }

		// Token: 0x06000EDD RID: 3805 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnExitCommand()
		{
			return true;
		}

		// Token: 0x06000EDE RID: 3806 RVA: 0x00027B1D File Offset: 0x00025D1D
		private void OnExitCommand()
		{
			RebootPendingData data = this._data;
			if (data != null)
			{
				AutoResetEvent resetEvent = data.ResetEvent;
				if (resetEvent != null)
				{
					resetEvent.Set();
				}
			}
			this._eventAggregator.GetEvent<Events.ProcessShutdownRequest>().Publish(new Events.ShutdownEventArgs(Events.TransferStateEnum.CanceledEngineTerminated));
		}

		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x06000EDF RID: 3807 RVA: 0x00027B52 File Offset: 0x00025D52
		// (set) Token: 0x06000EE0 RID: 3808 RVA: 0x00027B5A File Offset: 0x00025D5A
		public DelegateCommand OnCancel { get; private set; }

		// Token: 0x06000EE1 RID: 3809 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelCommand()
		{
			return true;
		}

		// Token: 0x06000EE2 RID: 3810 RVA: 0x00027B64 File Offset: 0x00025D64
		private void OnCancelCommand()
		{
			RebootPendingViewModel.<OnCancelCommand>d__27 <OnCancelCommand>d__;
			<OnCancelCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnCancelCommand>d__.<>4__this = this;
			<OnCancelCommand>d__.<>1__state = -1;
			<OnCancelCommand>d__.<>t__builder.Start<RebootPendingViewModel.<OnCancelCommand>d__27>(ref <OnCancelCommand>d__);
		}

		// Token: 0x04000509 RID: 1289
		private IUnityContainer _container;

		// Token: 0x0400050A RID: 1290
		private IPCmoverEngine _pcmoverEngine;

		// Token: 0x0400050B RID: 1291
		private IEventAggregator _eventAggregator;

		// Token: 0x0400050C RID: 1292
		private RebootPendingData _data;

		// Token: 0x0400050D RID: 1293
		private string _Message;
	}
}
