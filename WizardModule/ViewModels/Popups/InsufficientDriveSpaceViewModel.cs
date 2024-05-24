using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Popups;
using PCmover.Infrastructure;
using Prism.Commands;
using WizardModule.Properties;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000A6 RID: 166
	public class InsufficientDriveSpaceViewModel : PopupViewModelBase
	{
		// Token: 0x06000E9C RID: 3740 RVA: 0x0002715C File Offset: 0x0002535C
		public InsufficientDriveSpaceViewModel(IPCmoverEngine pcmoverEngine, InsufficientDriveSpaceData data)
		{
			this.engine = pcmoverEngine;
			this._data = data;
			this.Drives = new ObservableCollection<InsufficientDriveSpaceViewModel.ErrorString>();
			base.PopupData.Animation = PopupAnimation.Scroll;
			base.PopupData.BlackoutWhenOpen = true;
			base.PopupData.UseOverlay = true;
			this.OnClose = new DelegateCommand<string>(new Action<string>(this.OnCloseCommand), new Func<string, bool>(this.CanOnCloseCommand));
			this.OnDrivespaceInfo = new DelegateCommand<string>(new Action<string>(this.OnDrivespaceInfoCommand), new Func<string, bool>(this.CanOnDrivespaceInfoCommand));
			IPCmoverEngine ipcmoverEngine = this.engine;
			bool hasMultipleDrives;
			if (ipcmoverEngine == null)
			{
				hasMultipleDrives = false;
			}
			else
			{
				IEnumerable<DriveSpaceData> thisMachineDriveSpace = ipcmoverEngine.ThisMachineDriveSpace;
				int? num = (thisMachineDriveSpace != null) ? new int?(thisMachineDriveSpace.Count<DriveSpaceData>()) : null;
				int num2 = 1;
				hasMultipleDrives = (num.GetValueOrDefault() > num2 & num != null);
			}
			this.HasMultipleDrives = hasMultipleDrives;
			this.DriveSpaceError = string.Format(Resources.TEP_DrivespacePopup1, Tools.GetDisplaySize(this._data.Stats.Disk.TotalSize));
			this.Drives.Add(new InsufficientDriveSpaceViewModel.ErrorString
			{
				ErrorText = this.DriveSpaceError,
				TextColor = Brushes.Black
			});
			using (IEnumerator<DriveSpaceData> enumerator = ((pcmoverEngine != null) ? pcmoverEngine.ThisMachineDriveSpace : null).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DriveSpaceData drive = enumerator.Current;
					try
					{
						DriveSpaceRequired driveSpaceRequired = data.Stats.DriveSpaceRequired.FirstOrDefault((DriveSpaceRequired x) => x.Drive == drive.Drive);
						string errorText = string.Format(Resources.TEP_DrivespacePopup2, new object[]
						{
							drive.Drive,
							Tools.GetDisplaySize(drive.FreeBytes),
							Tools.GetDisplaySize(drive.TotalBytes),
							Tools.GetDisplaySize(driveSpaceRequired.Required),
							Tools.GetDisplaySize(driveSpaceRequired.Required + Math.Pow(1024.0, 3.0) * 10.0)
						});
						Brush textColor = (driveSpaceRequired.Required + Math.Pow(1024.0, 3.0) * 10.0 > drive.FreeBytes) ? Brushes.Red : Brushes.Black;
						this.Drives.Add(new InsufficientDriveSpaceViewModel.ErrorString
						{
							ErrorText = errorText,
							TextColor = textColor
						});
					}
					catch
					{
					}
				}
			}
			this.DriveSpaceError = this.DriveSpaceError + Environment.NewLine + Resources.TEP_DrivespacePopup3;
		}

		// Token: 0x1700067B RID: 1659
		// (get) Token: 0x06000E9D RID: 3741 RVA: 0x0002743C File Offset: 0x0002563C
		// (set) Token: 0x06000E9E RID: 3742 RVA: 0x00027444 File Offset: 0x00025644
		public bool HasMultipleDrives
		{
			get
			{
				return this._HasMultipleDrives;
			}
			set
			{
				this.SetProperty<bool>(ref this._HasMultipleDrives, value, "HasMultipleDrives");
			}
		}

		// Token: 0x1700067C RID: 1660
		// (get) Token: 0x06000E9F RID: 3743 RVA: 0x00027459 File Offset: 0x00025659
		// (set) Token: 0x06000EA0 RID: 3744 RVA: 0x00027461 File Offset: 0x00025661
		public string DriveSpaceError
		{
			get
			{
				return this._DriveSpaceError;
			}
			private set
			{
				this.SetProperty<string>(ref this._DriveSpaceError, value, "DriveSpaceError");
			}
		}

		// Token: 0x1700067D RID: 1661
		// (get) Token: 0x06000EA1 RID: 3745 RVA: 0x00027476 File Offset: 0x00025676
		// (set) Token: 0x06000EA2 RID: 3746 RVA: 0x0002747E File Offset: 0x0002567E
		public ObservableCollection<InsufficientDriveSpaceViewModel.ErrorString> Drives
		{
			get
			{
				return this._Drives;
			}
			private set
			{
				this.SetProperty<ObservableCollection<InsufficientDriveSpaceViewModel.ErrorString>>(ref this._Drives, value, "Drives");
			}
		}

		// Token: 0x1700067E RID: 1662
		// (get) Token: 0x06000EA3 RID: 3747 RVA: 0x00027493 File Offset: 0x00025693
		public DelegateCommand<string> OnClose { get; }

		// Token: 0x06000EA4 RID: 3748 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCloseCommand(string customize)
		{
			return true;
		}

		// Token: 0x06000EA5 RID: 3749 RVA: 0x0002749B File Offset: 0x0002569B
		private void OnCloseCommand(string customize)
		{
			base.PopupData.IsOpen = false;
			this._data.Customize = Convert.ToBoolean(customize);
			this._data.ResetEvent.Set();
		}

		// Token: 0x1700067F RID: 1663
		// (get) Token: 0x06000EA6 RID: 3750 RVA: 0x000274CB File Offset: 0x000256CB
		public DelegateCommand<string> OnDrivespaceInfo { get; }

		// Token: 0x06000EA7 RID: 3751 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnDrivespaceInfoCommand(string arg)
		{
			return true;
		}

		// Token: 0x06000EA8 RID: 3752 RVA: 0x000274D4 File Offset: 0x000256D4
		private void OnDrivespaceInfoCommand(string url)
		{
			try
			{
				Process.Start(new ProcessStartInfo(url));
			}
			catch
			{
			}
		}

		// Token: 0x040004EE RID: 1262
		private readonly IPCmoverEngine engine;

		// Token: 0x040004EF RID: 1263
		private readonly InsufficientDriveSpaceData _data;

		// Token: 0x040004F0 RID: 1264
		private bool _HasMultipleDrives;

		// Token: 0x040004F1 RID: 1265
		private string _DriveSpaceError;

		// Token: 0x040004F2 RID: 1266
		private ObservableCollection<InsufficientDriveSpaceViewModel.ErrorString> _Drives;

		// Token: 0x020001B8 RID: 440
		public class ErrorString
		{
			// Token: 0x1700071E RID: 1822
			// (get) Token: 0x06001339 RID: 4921 RVA: 0x0003F0F2 File Offset: 0x0003D2F2
			// (set) Token: 0x0600133A RID: 4922 RVA: 0x0003F0FA File Offset: 0x0003D2FA
			public string ErrorText { get; set; }

			// Token: 0x1700071F RID: 1823
			// (get) Token: 0x0600133B RID: 4923 RVA: 0x0003F103 File Offset: 0x0003D303
			// (set) Token: 0x0600133C RID: 4924 RVA: 0x0003F10B File Offset: 0x0003D30B
			public Brush TextColor { get; set; }
		}
	}
}
