using System;
using System.Windows.Controls.Primitives;
using Laplink.Tools.Popups;
using Prism.Commands;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000A3 RID: 163
	public class GoogleUsernameViewModel : PopupViewModelBase
	{
		// Token: 0x06000E86 RID: 3718 RVA: 0x00026F58 File Offset: 0x00025158
		public GoogleUsernameViewModel(GoogleUsernameData data)
		{
			this._data = data;
			base.PopupData.Animation = PopupAnimation.Scroll;
			base.PopupData.IsBlackout = true;
			base.PopupData.UseOverlay = true;
			this.OnClose = new DelegateCommand<string>(new Action<string>(this.OnCloseCommand), new Func<string, bool>(this.CanOnCloseCommand));
		}

		// Token: 0x17000673 RID: 1651
		// (get) Token: 0x06000E87 RID: 3719 RVA: 0x00026FB9 File Offset: 0x000251B9
		public DelegateCommand<string> OnClose { get; }

		// Token: 0x06000E88 RID: 3720 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCloseCommand(string name)
		{
			return true;
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x00026FC1 File Offset: 0x000251C1
		private void OnCloseCommand(string name)
		{
			base.PopupData.IsOpen = false;
			this._data.Username = name;
			this._data.ResetEvent.Set();
		}

		// Token: 0x040004E4 RID: 1252
		private readonly GoogleUsernameData _data;
	}
}
