using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Laplink.Pcmover.Contracts;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Mvvm;

namespace WizardModule.ViewModels.Dialogs
{
	// Token: 0x020000B2 RID: 178
	public class AddImageAssistMappingViewModel : BindableBase
	{
		// Token: 0x06000F0A RID: 3850 RVA: 0x00027F40 File Offset: 0x00026140
		public AddImageAssistMappingViewModel(Events.OverlayPopupResolveArgs overlayArgs)
		{
			this.OnClose = new DelegateCommand(new Action(this.OnCloseCommand), new Func<bool>(this.CanOnCloseCommand));
			this.OnCancel = new DelegateCommand(new Action(this.OnCancelCommand), new Func<bool>(this.CanOnCancelCommand));
			this.OnBrowseMultiple = new DelegateCommand(new Action(this.OnBrowseMultipleCommand), new Func<bool>(this.CanOnBrowseMultipleCommand));
			ImageFolderMapping imageFolderMapping = (ImageFolderMapping)overlayArgs.Parameter;
			this.PhysicalPath = ((imageFolderMapping != null) ? imageFolderMapping.PStr : null);
			this.VirtualPath = ((imageFolderMapping != null) ? imageFolderMapping.VStr : null);
			this.ResultCallback = overlayArgs.PopupResultCallback;
			this.OnClosePopup = overlayArgs.ClosePopupCallback;
		}

		// Token: 0x170006A1 RID: 1697
		// (get) Token: 0x06000F0B RID: 3851 RVA: 0x00028004 File Offset: 0x00026204
		// (set) Token: 0x06000F0C RID: 3852 RVA: 0x0002800C File Offset: 0x0002620C
		public string VirtualPath
		{
			get
			{
				return this._VirtualPath;
			}
			set
			{
				this.SetProperty<string>(ref this._VirtualPath, value, "VirtualPath");
				this.OnClose.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170006A2 RID: 1698
		// (get) Token: 0x06000F0D RID: 3853 RVA: 0x0002802C File Offset: 0x0002622C
		// (set) Token: 0x06000F0E RID: 3854 RVA: 0x00028034 File Offset: 0x00026234
		public string PhysicalPath
		{
			get
			{
				return this._PhysicalPath;
			}
			set
			{
				this.SetProperty<string>(ref this._PhysicalPath, value, "PhysicalPath");
				this.OnClose.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170006A3 RID: 1699
		// (get) Token: 0x06000F0F RID: 3855 RVA: 0x00028054 File Offset: 0x00026254
		// (set) Token: 0x06000F10 RID: 3856 RVA: 0x0002805C File Offset: 0x0002625C
		private Action<object> ResultCallback { get; set; }

		// Token: 0x170006A4 RID: 1700
		// (get) Token: 0x06000F11 RID: 3857 RVA: 0x00028065 File Offset: 0x00026265
		// (set) Token: 0x06000F12 RID: 3858 RVA: 0x0002806D File Offset: 0x0002626D
		private Action OnClosePopup { get; set; }

		// Token: 0x170006A5 RID: 1701
		// (get) Token: 0x06000F13 RID: 3859 RVA: 0x00028076 File Offset: 0x00026276
		// (set) Token: 0x06000F14 RID: 3860 RVA: 0x0002807E File Offset: 0x0002627E
		public DelegateCommand OnClose { get; private set; }

		// Token: 0x06000F15 RID: 3861 RVA: 0x00028087 File Offset: 0x00026287
		private bool CanOnCloseCommand()
		{
			return !string.IsNullOrWhiteSpace(this._VirtualPath) && !string.IsNullOrWhiteSpace(this._PhysicalPath);
		}

		// Token: 0x06000F16 RID: 3862 RVA: 0x000280A8 File Offset: 0x000262A8
		private void OnCloseCommand()
		{
			if (this._VirtualPath.Length == 1 && Regex.IsMatch(this._VirtualPath, "^[a-zA-Z]+$"))
			{
				this._VirtualPath += ":";
			}
			if (this._VirtualPath.EndsWith(":"))
			{
				this._VirtualPath += "\\";
			}
			if (this._PhysicalPath.Length == 1 && Regex.IsMatch(this._PhysicalPath, "^[a-zA-Z]+$"))
			{
				this._PhysicalPath += ":";
			}
			if (this._PhysicalPath.EndsWith(":"))
			{
				this._PhysicalPath += "\\";
			}
			Action<object> resultCallback = this.ResultCallback;
			if (resultCallback != null)
			{
				resultCallback(new ImageFolderMapping
				{
					VStr = this._VirtualPath,
					PStr = this._PhysicalPath
				});
			}
			Action onClosePopup = this.OnClosePopup;
			if (onClosePopup == null)
			{
				return;
			}
			onClosePopup();
		}

		// Token: 0x170006A6 RID: 1702
		// (get) Token: 0x06000F17 RID: 3863 RVA: 0x000281AF File Offset: 0x000263AF
		// (set) Token: 0x06000F18 RID: 3864 RVA: 0x000281B7 File Offset: 0x000263B7
		public DelegateCommand OnCancel { get; private set; }

		// Token: 0x06000F19 RID: 3865 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelCommand()
		{
			return true;
		}

		// Token: 0x06000F1A RID: 3866 RVA: 0x000281C0 File Offset: 0x000263C0
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

		// Token: 0x170006A7 RID: 1703
		// (get) Token: 0x06000F1B RID: 3867 RVA: 0x000281E4 File Offset: 0x000263E4
		// (set) Token: 0x06000F1C RID: 3868 RVA: 0x000281EC File Offset: 0x000263EC
		public DelegateCommand OnBrowseMultiple { get; private set; }

		// Token: 0x06000F1D RID: 3869 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBrowseMultipleCommand()
		{
			return true;
		}

		// Token: 0x06000F1E RID: 3870 RVA: 0x000281F8 File Offset: 0x000263F8
		private void OnBrowseMultipleCommand()
		{
			string text = this.ShowFolderDialog();
			if (text.Length > 0)
			{
				this.PhysicalPath = text;
			}
		}

		// Token: 0x06000F1F RID: 3871 RVA: 0x0002821C File Offset: 0x0002641C
		private string ShowFolderDialog()
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.ShowNewFolderButton = false;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				return folderBrowserDialog.SelectedPath;
			}
			return string.Empty;
		}

		// Token: 0x04000522 RID: 1314
		private string _VirtualPath;

		// Token: 0x04000523 RID: 1315
		private string _PhysicalPath;
	}
}
