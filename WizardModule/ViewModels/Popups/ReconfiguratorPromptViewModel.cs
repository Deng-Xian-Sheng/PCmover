using System;
using System.Windows.Controls.Primitives;
using Laplink.Tools.Popups;
using Prism.Commands;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000AD RID: 173
	public class ReconfiguratorPromptViewModel : PopupViewModelBase
	{
		// Token: 0x06000EEA RID: 3818 RVA: 0x00027BF4 File Offset: 0x00025DF4
		public ReconfiguratorPromptViewModel(ReconfiguratorPromptData data)
		{
			this._data = data;
			base.PopupData.Animation = PopupAnimation.Scroll;
			base.PopupData.IsBlackout = true;
			base.PopupData.UseOverlay = true;
			this.OnYes = new DelegateCommand(new Action(this.OnYesCommand), new Func<bool>(this.CanOnYesCommand));
			this.OnNo = new DelegateCommand(new Action(this.OnNoCommand), new Func<bool>(this.CanOnNoCommand));
		}

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x06000EEB RID: 3819 RVA: 0x00027C78 File Offset: 0x00025E78
		public DelegateCommand OnYes { get; }

		// Token: 0x06000EEC RID: 3820 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnYesCommand()
		{
			return true;
		}

		// Token: 0x06000EED RID: 3821 RVA: 0x00027C80 File Offset: 0x00025E80
		private void OnYesCommand()
		{
			base.PopupData.IsOpen = false;
			this._data.Run = true;
			this._data.ResetEvent.Set();
		}

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x06000EEE RID: 3822 RVA: 0x00027CAB File Offset: 0x00025EAB
		public DelegateCommand OnNo { get; }

		// Token: 0x06000EEF RID: 3823 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnNoCommand()
		{
			return true;
		}

		// Token: 0x06000EF0 RID: 3824 RVA: 0x00027CB3 File Offset: 0x00025EB3
		private void OnNoCommand()
		{
			base.PopupData.IsOpen = false;
			this._data.Run = false;
			this._data.ResetEvent.Set();
		}

		// Token: 0x04000513 RID: 1299
		private readonly ReconfiguratorPromptData _data;
	}
}
