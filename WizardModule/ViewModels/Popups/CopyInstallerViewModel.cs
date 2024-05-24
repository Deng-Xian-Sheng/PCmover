using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls.Primitives;
using Laplink.Tools.Popups;
using Prism.Commands;
using WizardModule.Properties;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000A1 RID: 161
	public class CopyInstallerViewModel : PopupViewModelBase
	{
		// Token: 0x06000E6B RID: 3691 RVA: 0x00026CF0 File Offset: 0x00024EF0
		public CopyInstallerViewModel(CopyInstallerData data)
		{
			this._data = data;
			base.PopupData.Animation = PopupAnimation.None;
			base.PopupData.IsBlackout = true;
			base.PopupData.UseOverlay = true;
			this.Rescan = new DelegateCommand(new Action(this.OnRescan), new Func<bool>(this.CanOnRescan));
			this.CopyInstaller = new DelegateCommand(new Action(this.OnCopyInstaller), new Func<bool>(this.CanOnCopyInstaller));
			this.ClosePopup = new DelegateCommand(new Action(this.OnClosePopup), new Func<bool>(this.CanOnClosePopup));
			this.PopulateDrives();
		}

		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x06000E6C RID: 3692 RVA: 0x00026D9D File Offset: 0x00024F9D
		// (set) Token: 0x06000E6D RID: 3693 RVA: 0x00026DA5 File Offset: 0x00024FA5
		public bool IsBusy
		{
			get
			{
				return this._IsBusy;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsBusy, value, "IsBusy");
				this.CopyInstaller.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x06000E6E RID: 3694 RVA: 0x00026DC5 File Offset: 0x00024FC5
		// (set) Token: 0x06000E6F RID: 3695 RVA: 0x00026DCD File Offset: 0x00024FCD
		public string SelectedDrive
		{
			get
			{
				return this._SelectedDrive;
			}
			set
			{
				this.SetProperty<string>(ref this._SelectedDrive, value, "SelectedDrive");
				this.CopyInstaller.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700066C RID: 1644
		// (get) Token: 0x06000E70 RID: 3696 RVA: 0x00026DED File Offset: 0x00024FED
		// (set) Token: 0x06000E71 RID: 3697 RVA: 0x00026DF5 File Offset: 0x00024FF5
		public ObservableCollection<string> Drives
		{
			get
			{
				return this._Drives;
			}
			set
			{
				this.SetProperty<ObservableCollection<string>>(ref this._Drives, value, "Drives");
			}
		}

		// Token: 0x1700066D RID: 1645
		// (get) Token: 0x06000E72 RID: 3698 RVA: 0x00026E0A File Offset: 0x0002500A
		// (set) Token: 0x06000E73 RID: 3699 RVA: 0x00026E12 File Offset: 0x00025012
		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				this.SetProperty<string>(ref this._Status, value, "Status");
			}
		}

		// Token: 0x1700066E RID: 1646
		// (get) Token: 0x06000E74 RID: 3700 RVA: 0x00026E27 File Offset: 0x00025027
		// (set) Token: 0x06000E75 RID: 3701 RVA: 0x00026E2F File Offset: 0x0002502F
		public DelegateCommand CopyInstaller { get; private set; }

		// Token: 0x06000E76 RID: 3702 RVA: 0x00026E38 File Offset: 0x00025038
		private bool CanOnCopyInstaller()
		{
			return !string.IsNullOrWhiteSpace(this.SelectedDrive);
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x00026E48 File Offset: 0x00025048
		private void OnCopyInstaller()
		{
			CopyInstallerViewModel.<OnCopyInstaller>d__23 <OnCopyInstaller>d__;
			<OnCopyInstaller>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnCopyInstaller>d__.<>4__this = this;
			<OnCopyInstaller>d__.<>1__state = -1;
			<OnCopyInstaller>d__.<>t__builder.Start<CopyInstallerViewModel.<OnCopyInstaller>d__23>(ref <OnCopyInstaller>d__);
		}

		// Token: 0x1700066F RID: 1647
		// (get) Token: 0x06000E78 RID: 3704 RVA: 0x00026E7F File Offset: 0x0002507F
		// (set) Token: 0x06000E79 RID: 3705 RVA: 0x00026E87 File Offset: 0x00025087
		public DelegateCommand Rescan { get; private set; }

		// Token: 0x06000E7A RID: 3706 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnRescan()
		{
			return true;
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x00026E90 File Offset: 0x00025090
		private void OnRescan()
		{
			this.Status = string.Empty;
			this.PopulateDrives();
		}

		// Token: 0x17000670 RID: 1648
		// (get) Token: 0x06000E7C RID: 3708 RVA: 0x00026EA3 File Offset: 0x000250A3
		// (set) Token: 0x06000E7D RID: 3709 RVA: 0x00026EAB File Offset: 0x000250AB
		public DelegateCommand ClosePopup { get; private set; }

		// Token: 0x06000E7E RID: 3710 RVA: 0x00026EB4 File Offset: 0x000250B4
		private bool CanOnClosePopup()
		{
			return !this.IsBusy;
		}

		// Token: 0x06000E7F RID: 3711 RVA: 0x00026EBF File Offset: 0x000250BF
		private void OnClosePopup()
		{
			this.IsBusy = false;
			base.PopupData.IsOpen = false;
			this._data.ResetEvent.Set();
		}

		// Token: 0x06000E80 RID: 3712 RVA: 0x00026EE8 File Offset: 0x000250E8
		private void PopulateDrives()
		{
			this.Drives = Tools.GetLogicalUsbDisks();
			if (this.Drives.Count == 0)
			{
				this.Status = Resources.CIP_NoDrivesFound;
				return;
			}
			this.SelectedDrive = this.Drives[0];
			this.Status = string.Empty;
		}

		// Token: 0x040004DA RID: 1242
		private CopyInstallerData _data;

		// Token: 0x040004DB RID: 1243
		private bool _IsBusy;

		// Token: 0x040004DC RID: 1244
		private string _SelectedDrive;

		// Token: 0x040004DD RID: 1245
		private ObservableCollection<string> _Drives;

		// Token: 0x040004DE RID: 1246
		private string _Status;
	}
}
