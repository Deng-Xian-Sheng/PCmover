using System;
using System.Windows.Controls.Primitives;
using Laplink.Tools.Popups;
using PCmover.Infrastructure;
using Prism.Commands;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000B1 RID: 177
	public class UndoWarningViewModel : PopupViewModelBase
	{
		// Token: 0x06000F03 RID: 3843 RVA: 0x00027E54 File Offset: 0x00026054
		public UndoWarningViewModel(IPCmoverEngine pcmoverEngine, UndoWarningData data)
		{
			this.engine = pcmoverEngine;
			this.data = data;
			base.PopupData.Animation = PopupAnimation.Scroll;
			base.PopupData.BlackoutWhenOpen = true;
			base.PopupData.UseOverlay = true;
			this.OnClosePopup = new DelegateCommand(new Action(this.OnClosePopupCommand));
			this.OnStart = new DelegateCommand(new Action(this.OnStartCommand));
		}

		// Token: 0x1700069F RID: 1695
		// (get) Token: 0x06000F04 RID: 3844 RVA: 0x00027EC7 File Offset: 0x000260C7
		// (set) Token: 0x06000F05 RID: 3845 RVA: 0x00027ECF File Offset: 0x000260CF
		public DelegateCommand OnClosePopup { get; private set; }

		// Token: 0x06000F06 RID: 3846 RVA: 0x00027ED8 File Offset: 0x000260D8
		private void OnClosePopupCommand()
		{
			this.data.Start = false;
			this.data.ResetEvent.Set();
			base.PopupData.IsOpen = false;
		}

		// Token: 0x170006A0 RID: 1696
		// (get) Token: 0x06000F07 RID: 3847 RVA: 0x00027F03 File Offset: 0x00026103
		// (set) Token: 0x06000F08 RID: 3848 RVA: 0x00027F0B File Offset: 0x0002610B
		public DelegateCommand OnStart { get; private set; }

		// Token: 0x06000F09 RID: 3849 RVA: 0x00027F14 File Offset: 0x00026114
		private void OnStartCommand()
		{
			this.data.Start = true;
			this.data.ResetEvent.Set();
			base.PopupData.IsOpen = false;
		}

		// Token: 0x0400051E RID: 1310
		private readonly IPCmoverEngine engine;

		// Token: 0x0400051F RID: 1311
		private readonly UndoWarningData data;
	}
}
