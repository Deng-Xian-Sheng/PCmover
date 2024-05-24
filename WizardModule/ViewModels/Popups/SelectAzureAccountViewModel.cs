using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;
using Laplink.Tools.Popups;
using Prism.Commands;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000AF RID: 175
	public class SelectAzureAccountViewModel : PopupViewModelBase
	{
		// Token: 0x06000EF8 RID: 3832 RVA: 0x00027D14 File Offset: 0x00025F14
		public SelectAzureAccountViewModel(SelectAzureAccountData data)
		{
			if (data != null)
			{
				List<string> accounts = data.Accounts;
				int? num = (accounts != null) ? new int?(accounts.Count) : null;
				int num2 = 0;
				if (num.GetValueOrDefault() > num2 & num != null)
				{
					this._data = data;
					this.Accounts = new ObservableCollection<string>(this._data.Accounts);
					base.PopupData.Animation = PopupAnimation.Scroll;
					base.PopupData.IsBlackout = true;
					base.PopupData.UseOverlay = true;
					this.OnClose = new DelegateCommand<string>(new Action<string>(this.OnCloseCommand), new Func<string, bool>(this.CanOnCloseCommand));
					return;
				}
			}
			base.PopupData.IsOpen = false;
			data.ResetEvent.Set();
		}

		// Token: 0x1700069B RID: 1691
		// (get) Token: 0x06000EF9 RID: 3833 RVA: 0x00027DE0 File Offset: 0x00025FE0
		// (set) Token: 0x06000EFA RID: 3834 RVA: 0x00027DE8 File Offset: 0x00025FE8
		public ObservableCollection<string> Accounts
		{
			get
			{
				return this._Accounts;
			}
			set
			{
				this.SetProperty<ObservableCollection<string>>(ref this._Accounts, value, "Accounts");
			}
		}

		// Token: 0x1700069C RID: 1692
		// (get) Token: 0x06000EFB RID: 3835 RVA: 0x00027DFD File Offset: 0x00025FFD
		public DelegateCommand<string> OnClose { get; }

		// Token: 0x06000EFC RID: 3836 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCloseCommand(string account)
		{
			return true;
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x00027E05 File Offset: 0x00026005
		private void OnCloseCommand(string account)
		{
			base.PopupData.IsOpen = false;
			this._data.SelectedAccount = account;
			this._data.ResetEvent.Set();
		}

		// Token: 0x04000519 RID: 1305
		private readonly SelectAzureAccountData _data;

		// Token: 0x0400051A RID: 1306
		private ObservableCollection<string> _Accounts;
	}
}
