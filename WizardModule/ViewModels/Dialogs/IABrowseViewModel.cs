using System;
using System.Collections.ObjectModel;
using Laplink.Pcmover.Contracts;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Mvvm;

namespace WizardModule.ViewModels.Dialogs
{
	// Token: 0x020000B4 RID: 180
	public class IABrowseViewModel : BindableBase
	{
		// Token: 0x06000F34 RID: 3892 RVA: 0x000283EC File Offset: 0x000265EC
		public IABrowseViewModel(Events.OverlayPopupResolveArgs overlayArgs)
		{
			this.OnClose = new DelegateCommand(new Action(this.OnCloseCommand), new Func<bool>(this.CanOnCloseCommand));
			this.OnCancel = new DelegateCommand(new Action(this.OnCancelCommand), new Func<bool>(this.CanOnCancelCommand));
			MachineDriveInfo machineDriveInfo = (MachineDriveInfo)overlayArgs.Parameter;
			this.Drives = new ObservableCollection<string>();
			foreach (char c in machineDriveInfo.UsbDrives)
			{
				this.Drives.Add(c.ToString());
			}
			foreach (char c2 in machineDriveInfo.VirtualDrives)
			{
				this.Drives.Add(c2.ToString());
			}
			if (this.Drives.Count > 0)
			{
				this.SelectedIndex = 0;
			}
			this.ResultCallback = overlayArgs.PopupResultCallback;
			this.OnClosePopup = overlayArgs.ClosePopupCallback;
		}

		// Token: 0x170006AD RID: 1709
		// (get) Token: 0x06000F35 RID: 3893 RVA: 0x000284EE File Offset: 0x000266EE
		// (set) Token: 0x06000F36 RID: 3894 RVA: 0x000284F6 File Offset: 0x000266F6
		private Action<object> ResultCallback { get; set; }

		// Token: 0x170006AE RID: 1710
		// (get) Token: 0x06000F37 RID: 3895 RVA: 0x000284FF File Offset: 0x000266FF
		// (set) Token: 0x06000F38 RID: 3896 RVA: 0x00028507 File Offset: 0x00026707
		private Action OnClosePopup { get; set; }

		// Token: 0x170006AF RID: 1711
		// (get) Token: 0x06000F39 RID: 3897 RVA: 0x00028510 File Offset: 0x00026710
		// (set) Token: 0x06000F3A RID: 3898 RVA: 0x00028518 File Offset: 0x00026718
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

		// Token: 0x170006B0 RID: 1712
		// (get) Token: 0x06000F3B RID: 3899 RVA: 0x0002852D File Offset: 0x0002672D
		// (set) Token: 0x06000F3C RID: 3900 RVA: 0x00028535 File Offset: 0x00026735
		public string SelectedPath
		{
			get
			{
				return this._SelectedPath;
			}
			set
			{
				this.SetProperty<string>(ref this._SelectedPath, value, "SelectedPath");
			}
		}

		// Token: 0x170006B1 RID: 1713
		// (get) Token: 0x06000F3D RID: 3901 RVA: 0x0002854A File Offset: 0x0002674A
		// (set) Token: 0x06000F3E RID: 3902 RVA: 0x00028554 File Offset: 0x00026754
		public string SelectedDrive
		{
			get
			{
				return this._SelectedDrive;
			}
			set
			{
				this.SetProperty<string>(ref this._SelectedDrive, value, "SelectedDrive");
				if (this.SelectedDrive == null)
				{
					return;
				}
				if (this.SelectedPath == null)
				{
					this.SelectedPath = this.SelectedDrive + ":\\";
					return;
				}
				if (!this.SelectedPath.StartsWith(this.SelectedDrive))
				{
					string str = this.SelectedPath.Substring(1);
					this.SelectedPath = this.SelectedDrive + str;
				}
			}
		}

		// Token: 0x170006B2 RID: 1714
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x000285CE File Offset: 0x000267CE
		// (set) Token: 0x06000F40 RID: 3904 RVA: 0x000285D6 File Offset: 0x000267D6
		public int SelectedIndex
		{
			get
			{
				return this._SelectedIndex;
			}
			set
			{
				this.SetProperty<int>(ref this._SelectedIndex, value, "SelectedIndex");
			}
		}

		// Token: 0x170006B3 RID: 1715
		// (get) Token: 0x06000F41 RID: 3905 RVA: 0x000285EB File Offset: 0x000267EB
		// (set) Token: 0x06000F42 RID: 3906 RVA: 0x000285F3 File Offset: 0x000267F3
		public DelegateCommand OnClose { get; private set; }

		// Token: 0x06000F43 RID: 3907 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCloseCommand()
		{
			return true;
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x000285FC File Offset: 0x000267FC
		private void OnCloseCommand()
		{
			Action<object> resultCallback = this.ResultCallback;
			if (resultCallback != null)
			{
				resultCallback(this.SelectedPath);
			}
			Action onClosePopup = this.OnClosePopup;
			if (onClosePopup == null)
			{
				return;
			}
			onClosePopup();
		}

		// Token: 0x170006B4 RID: 1716
		// (get) Token: 0x06000F45 RID: 3909 RVA: 0x00028625 File Offset: 0x00026825
		// (set) Token: 0x06000F46 RID: 3910 RVA: 0x0002862D File Offset: 0x0002682D
		public DelegateCommand OnCancel { get; private set; }

		// Token: 0x06000F47 RID: 3911 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelCommand()
		{
			return true;
		}

		// Token: 0x06000F48 RID: 3912 RVA: 0x00028636 File Offset: 0x00026836
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

		// Token: 0x04000530 RID: 1328
		private ObservableCollection<string> _Drives;

		// Token: 0x04000531 RID: 1329
		private string _SelectedPath;

		// Token: 0x04000532 RID: 1330
		private string _SelectedDrive;

		// Token: 0x04000533 RID: 1331
		private int _SelectedIndex;
	}
}
