using System;
using System.Windows.Controls.Primitives;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Popups;
using PCmover.Infrastructure;
using Prism.Commands;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000A4 RID: 164
	public class InteractiveAlertViewModel : PopupViewModelBase
	{
		// Token: 0x06000E8A RID: 3722 RVA: 0x00026FEC File Offset: 0x000251EC
		[Obsolete("Design only")]
		public InteractiveAlertViewModel()
		{
		}

		// Token: 0x06000E8B RID: 3723 RVA: 0x00026FF4 File Offset: 0x000251F4
		public InteractiveAlertViewModel(DefaultPolicy policy, IPCmoverEngine engine)
		{
			this._policy = policy;
			this._engine = engine;
			base.PopupData.Animation = PopupAnimation.Scroll;
			this.OnSave = new DelegateCommand(new Action(this.OnSaveCommand), new Func<bool>(this.CanOnSaveCommand));
			this.OnCancel = new DelegateCommand(new Action(this.OnCancelCommand), new Func<bool>(this.CanOnCancelCommand));
		}

		// Token: 0x17000674 RID: 1652
		// (get) Token: 0x06000E8C RID: 3724 RVA: 0x00027067 File Offset: 0x00025267
		public TaskAlertData AlertData
		{
			get
			{
				return this._engine.InteractiveDoneAlert;
			}
		}

		// Token: 0x17000675 RID: 1653
		// (get) Token: 0x06000E8D RID: 3725 RVA: 0x00027074 File Offset: 0x00025274
		public DelegateCommand OnCancel { get; }

		// Token: 0x06000E8E RID: 3726 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelCommand()
		{
			return true;
		}

		// Token: 0x06000E8F RID: 3727 RVA: 0x0002707C File Offset: 0x0002527C
		private void OnCancelCommand()
		{
			base.PopupData.IsOpen = false;
		}

		// Token: 0x17000676 RID: 1654
		// (get) Token: 0x06000E90 RID: 3728 RVA: 0x0002708A File Offset: 0x0002528A
		public DelegateCommand OnSave { get; }

		// Token: 0x06000E91 RID: 3729 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnSaveCommand()
		{
			return true;
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x00027094 File Offset: 0x00025294
		private void OnSaveCommand()
		{
			this._policy.enginePolicy.Alerts.Email = this.AlertData.Email;
			this._policy.enginePolicy.Alerts.Name = this.AlertData.User;
			this._policy.enginePolicy.Alerts.Message = this.AlertData.Message;
			this._policy.WriteProfile();
			base.PopupData.IsOpen = false;
		}

		// Token: 0x040004E6 RID: 1254
		private readonly DefaultPolicy _policy;

		// Token: 0x040004E7 RID: 1255
		private readonly IPCmoverEngine _engine;
	}
}
