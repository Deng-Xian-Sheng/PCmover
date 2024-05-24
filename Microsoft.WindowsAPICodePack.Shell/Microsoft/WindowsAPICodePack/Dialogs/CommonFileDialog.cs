using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Markup;
using Microsoft.WindowsAPICodePack.Controls;
using Microsoft.WindowsAPICodePack.Dialogs.Controls;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000076 RID: 118
	[ContentProperty("Controls")]
	public abstract class CommonFileDialog : IDialogControlHost, IDisposable
	{
		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x0000F0AC File Offset: 0x0000D2AC
		protected IEnumerable<string> FileNameCollection
		{
			get
			{
				foreach (string name in this.filenames)
				{
					yield return name;
				}
				yield break;
			}
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0000F0D0 File Offset: 0x0000D2D0
		protected CommonFileDialog()
		{
			if (!CoreHelpers.RunningOnVista)
			{
				throw new PlatformNotSupportedException(LocalizedMessages.CommonFileDialogRequiresVista);
			}
			this.filenames = new Collection<string>();
			this.filters = new CommonFileDialogFilterCollection();
			this.items = new Collection<IShellItem>();
			this.controls = new CommonFileDialogControlCollection<CommonFileDialogControl>(this);
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0000F14F File Offset: 0x0000D34F
		protected CommonFileDialog(string title) : this()
		{
			this.title = title;
		}

		// Token: 0x060003C8 RID: 968
		internal abstract void InitializeNativeFileDialog();

		// Token: 0x060003C9 RID: 969
		internal abstract IFileDialog GetNativeFileDialog();

		// Token: 0x060003CA RID: 970
		internal abstract void PopulateWithFileNames(Collection<string> names);

		// Token: 0x060003CB RID: 971
		internal abstract void PopulateWithIShellItems(Collection<IShellItem> shellItems);

		// Token: 0x060003CC RID: 972
		internal abstract void CleanUpNativeFileDialog();

		// Token: 0x060003CD RID: 973
		internal abstract ShellNativeMethods.FileOpenOptions GetDerivedOptionFlags(ShellNativeMethods.FileOpenOptions flags);

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060003CE RID: 974 RVA: 0x0000F164 File Offset: 0x0000D364
		// (remove) Token: 0x060003CF RID: 975 RVA: 0x0000F1A0 File Offset: 0x0000D3A0
		public event CancelEventHandler FileOk;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060003D0 RID: 976 RVA: 0x0000F1DC File Offset: 0x0000D3DC
		// (remove) Token: 0x060003D1 RID: 977 RVA: 0x0000F218 File Offset: 0x0000D418
		public event EventHandler<CommonFileDialogFolderChangeEventArgs> FolderChanging;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060003D2 RID: 978 RVA: 0x0000F254 File Offset: 0x0000D454
		// (remove) Token: 0x060003D3 RID: 979 RVA: 0x0000F290 File Offset: 0x0000D490
		public event EventHandler FolderChanged;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060003D4 RID: 980 RVA: 0x0000F2CC File Offset: 0x0000D4CC
		// (remove) Token: 0x060003D5 RID: 981 RVA: 0x0000F308 File Offset: 0x0000D508
		public event EventHandler SelectionChanged;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060003D6 RID: 982 RVA: 0x0000F344 File Offset: 0x0000D544
		// (remove) Token: 0x060003D7 RID: 983 RVA: 0x0000F380 File Offset: 0x0000D580
		public event EventHandler FileTypeChanged;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060003D8 RID: 984 RVA: 0x0000F3BC File Offset: 0x0000D5BC
		// (remove) Token: 0x060003D9 RID: 985 RVA: 0x0000F3F8 File Offset: 0x0000D5F8
		public event EventHandler DialogOpening;

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060003DA RID: 986 RVA: 0x0000F434 File Offset: 0x0000D634
		public CommonFileDialogControlCollection<CommonFileDialogControl> Controls
		{
			get
			{
				return this.controls;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060003DB RID: 987 RVA: 0x0000F44C File Offset: 0x0000D64C
		public CommonFileDialogFilterCollection Filters
		{
			get
			{
				return this.filters;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060003DC RID: 988 RVA: 0x0000F464 File Offset: 0x0000D664
		// (set) Token: 0x060003DD RID: 989 RVA: 0x0000F47C File Offset: 0x0000D67C
		public string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				this.title = value;
				if (this.NativeDialogShowing)
				{
					this.nativeDialog.SetTitle(value);
				}
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060003DE RID: 990 RVA: 0x0000F4B0 File Offset: 0x0000D6B0
		// (set) Token: 0x060003DF RID: 991 RVA: 0x0000F4C8 File Offset: 0x0000D6C8
		public bool EnsureFileExists
		{
			get
			{
				return this.ensureFileExists;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.EnsureFileExistsCannotBeChanged);
				this.ensureFileExists = value;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x0000F4E0 File Offset: 0x0000D6E0
		// (set) Token: 0x060003E1 RID: 993 RVA: 0x0000F4F8 File Offset: 0x0000D6F8
		public bool EnsurePathExists
		{
			get
			{
				return this.ensurePathExists;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.EnsurePathExistsCannotBeChanged);
				this.ensurePathExists = value;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x0000F510 File Offset: 0x0000D710
		// (set) Token: 0x060003E3 RID: 995 RVA: 0x0000F528 File Offset: 0x0000D728
		public bool EnsureValidNames
		{
			get
			{
				return this.ensureValidNames;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.EnsureValidNamesCannotBeChanged);
				this.ensureValidNames = value;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x0000F540 File Offset: 0x0000D740
		// (set) Token: 0x060003E5 RID: 997 RVA: 0x0000F558 File Offset: 0x0000D758
		public bool EnsureReadOnly
		{
			get
			{
				return this.ensureReadOnly;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.EnsureReadonlyCannotBeChanged);
				this.ensureReadOnly = value;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x0000F570 File Offset: 0x0000D770
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x0000F588 File Offset: 0x0000D788
		public bool RestoreDirectory
		{
			get
			{
				return this.restoreDirectory;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.RestoreDirectoryCannotBeChanged);
				this.restoreDirectory = value;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x0000F5A0 File Offset: 0x0000D7A0
		// (set) Token: 0x060003E9 RID: 1001 RVA: 0x0000F5B8 File Offset: 0x0000D7B8
		public bool ShowPlacesList
		{
			get
			{
				return this.showPlacesList;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.ShowPlacesListCannotBeChanged);
				this.showPlacesList = value;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x0000F5D0 File Offset: 0x0000D7D0
		// (set) Token: 0x060003EB RID: 1003 RVA: 0x0000F5E8 File Offset: 0x0000D7E8
		public bool AddToMostRecentlyUsedList
		{
			get
			{
				return this.addToMruList;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.AddToMostRecentlyUsedListCannotBeChanged);
				this.addToMruList = value;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x0000F600 File Offset: 0x0000D800
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x0000F618 File Offset: 0x0000D818
		public bool ShowHiddenItems
		{
			get
			{
				return this.showHiddenItems;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.ShowHiddenItemsCannotBeChanged);
				this.showHiddenItems = value;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x0000F630 File Offset: 0x0000D830
		// (set) Token: 0x060003EF RID: 1007 RVA: 0x0000F648 File Offset: 0x0000D848
		public bool AllowPropertyEditing
		{
			get
			{
				return this.allowPropertyEditing;
			}
			set
			{
				this.allowPropertyEditing = value;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060003F0 RID: 1008 RVA: 0x0000F654 File Offset: 0x0000D854
		// (set) Token: 0x060003F1 RID: 1009 RVA: 0x0000F66C File Offset: 0x0000D86C
		public bool NavigateToShortcut
		{
			get
			{
				return this.navigateToShortcut;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.NavigateToShortcutCannotBeChanged);
				this.navigateToShortcut = value;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060003F2 RID: 1010 RVA: 0x0000F684 File Offset: 0x0000D884
		// (set) Token: 0x060003F3 RID: 1011 RVA: 0x0000F69B File Offset: 0x0000D89B
		public string DefaultExtension { get; set; }

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060003F4 RID: 1012 RVA: 0x0000F6A4 File Offset: 0x0000D8A4
		public int SelectedFileTypeIndex
		{
			get
			{
				int result;
				if (this.nativeDialog != null)
				{
					uint num;
					this.nativeDialog.GetFileTypeIndex(out num);
					result = (int)num;
				}
				else
				{
					result = -1;
				}
				return result;
			}
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0000F6D8 File Offset: 0x0000D8D8
		private void SyncFileTypeComboToDefaultExtension(IFileDialog dialog)
		{
			if (this is CommonSaveFileDialog && this.DefaultExtension != null && this.filters.Count > 0)
			{
				uint num = 0U;
				while ((ulong)num < (ulong)((long)this.filters.Count))
				{
					CommonFileDialogFilter commonFileDialogFilter = this.filters[(int)num];
					if (commonFileDialogFilter.Extensions.Contains(this.DefaultExtension))
					{
						dialog.SetFileTypeIndex(num + 1U);
						break;
					}
					num += 1U;
				}
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060003F6 RID: 1014 RVA: 0x0000F764 File Offset: 0x0000D964
		public string FileName
		{
			get
			{
				this.CheckFileNamesAvailable();
				if (this.filenames.Count > 1)
				{
					throw new InvalidOperationException(LocalizedMessages.CommonFileDialogMultipleFiles);
				}
				string text = this.filenames[0];
				if (!string.IsNullOrEmpty(this.DefaultExtension))
				{
					text = Path.ChangeExtension(text, this.DefaultExtension);
				}
				return text;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x0000F7CC File Offset: 0x0000D9CC
		public ShellObject FileAsShellObject
		{
			get
			{
				this.CheckFileItemsAvailable();
				if (this.items.Count > 1)
				{
					throw new InvalidOperationException(LocalizedMessages.CommonFileDialogMultipleItems);
				}
				ShellObject result;
				if (this.items.Count == 0)
				{
					result = null;
				}
				else
				{
					result = ShellObjectFactory.Create(this.items[0]);
				}
				return result;
			}
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0000F834 File Offset: 0x0000DA34
		public void AddPlace(ShellContainer place, FileDialogAddPlaceLocation location)
		{
			if (place == null)
			{
				throw new ArgumentNullException("place");
			}
			if (this.nativeDialog == null)
			{
				this.InitializeNativeFileDialog();
				this.nativeDialog = this.GetNativeFileDialog();
			}
			if (this.nativeDialog != null)
			{
				this.nativeDialog.AddPlace(place.NativeShellItem, (ShellNativeMethods.FileDialogAddPlacement)location);
			}
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0000F8A4 File Offset: 0x0000DAA4
		public void AddPlace(string path, FileDialogAddPlaceLocation location)
		{
			if (string.IsNullOrEmpty(path))
			{
				throw new ArgumentNullException("path");
			}
			if (this.nativeDialog == null)
			{
				this.InitializeNativeFileDialog();
				this.nativeDialog = this.GetNativeFileDialog();
			}
			Guid guid = new Guid("7E9FB0D3-919F-4307-AB2E-9B1860310C93");
			IShellItem2 psi;
			int num = ShellNativeMethods.SHCreateItemFromParsingName(path, IntPtr.Zero, ref guid, out psi);
			if (!CoreErrorHelper.Succeeded(num))
			{
				throw new CommonControlException(LocalizedMessages.CommonFileDialogCannotCreateShellItem, Marshal.GetExceptionForHR(num));
			}
			if (this.nativeDialog != null)
			{
				this.nativeDialog.AddPlace(psi, (ShellNativeMethods.FileDialogAddPlacement)location);
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060003FA RID: 1018 RVA: 0x0000F94C File Offset: 0x0000DB4C
		// (set) Token: 0x060003FB RID: 1019 RVA: 0x0000F964 File Offset: 0x0000DB64
		public string InitialDirectory
		{
			get
			{
				return this.initialDirectory;
			}
			set
			{
				this.initialDirectory = value;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060003FC RID: 1020 RVA: 0x0000F970 File Offset: 0x0000DB70
		// (set) Token: 0x060003FD RID: 1021 RVA: 0x0000F988 File Offset: 0x0000DB88
		public ShellContainer InitialDirectoryShellContainer
		{
			get
			{
				return this.initialDirectoryShellContainer;
			}
			set
			{
				this.initialDirectoryShellContainer = value;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060003FE RID: 1022 RVA: 0x0000F994 File Offset: 0x0000DB94
		// (set) Token: 0x060003FF RID: 1023 RVA: 0x0000F9AC File Offset: 0x0000DBAC
		public string DefaultDirectory
		{
			get
			{
				return this.defaultDirectory;
			}
			set
			{
				this.defaultDirectory = value;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000400 RID: 1024 RVA: 0x0000F9B8 File Offset: 0x0000DBB8
		// (set) Token: 0x06000401 RID: 1025 RVA: 0x0000F9D0 File Offset: 0x0000DBD0
		public ShellContainer DefaultDirectoryShellContainer
		{
			get
			{
				return this.defaultDirectoryShellContainer;
			}
			set
			{
				this.defaultDirectoryShellContainer = value;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x0000F9DC File Offset: 0x0000DBDC
		// (set) Token: 0x06000403 RID: 1027 RVA: 0x0000F9F4 File Offset: 0x0000DBF4
		public Guid CookieIdentifier
		{
			get
			{
				return this.cookieIdentifier;
			}
			set
			{
				this.cookieIdentifier = value;
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0000FA00 File Offset: 0x0000DC00
		public CommonFileDialogResult ShowDialog(IntPtr ownerWindowHandle)
		{
			if (ownerWindowHandle == IntPtr.Zero)
			{
				throw new ArgumentException(LocalizedMessages.CommonFileDialogInvalidHandle, "ownerWindowHandle");
			}
			this.parentWindow = ownerWindowHandle;
			return this.ShowDialog();
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0000FA44 File Offset: 0x0000DC44
		public CommonFileDialogResult ShowDialog(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			this.parentWindow = new WindowInteropHelper(window).Handle;
			return this.ShowDialog();
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0000FA84 File Offset: 0x0000DC84
		public CommonFileDialogResult ShowDialog()
		{
			this.InitializeNativeFileDialog();
			this.nativeDialog = this.GetNativeFileDialog();
			this.ApplyNativeSettings(this.nativeDialog);
			this.InitializeEventSink(this.nativeDialog);
			if (this.resetSelections)
			{
				this.resetSelections = false;
			}
			this.showState = DialogShowState.Showing;
			int result = this.nativeDialog.Show(this.parentWindow);
			this.showState = DialogShowState.Closed;
			CommonFileDialogResult result2;
			if (CoreErrorHelper.Matches(result, 1223))
			{
				this.canceled = new bool?(true);
				result2 = CommonFileDialogResult.Cancel;
				this.filenames.Clear();
			}
			else
			{
				this.canceled = new bool?(false);
				result2 = CommonFileDialogResult.Ok;
				this.PopulateWithFileNames(this.filenames);
				this.PopulateWithIShellItems(this.items);
			}
			return result2;
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000FB54 File Offset: 0x0000DD54
		public void ResetUserSelections()
		{
			this.resetSelections = true;
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x0000FB60 File Offset: 0x0000DD60
		// (set) Token: 0x06000409 RID: 1033 RVA: 0x0000FB77 File Offset: 0x0000DD77
		public string DefaultFileName { get; set; }

		// Token: 0x0600040A RID: 1034 RVA: 0x0000FB80 File Offset: 0x0000DD80
		private void InitializeEventSink(IFileDialog nativeDlg)
		{
			if (this.FileOk != null || this.FolderChanging != null || this.FolderChanged != null || this.SelectionChanged != null || this.FileTypeChanged != null || this.DialogOpening != null || (this.controls != null && this.controls.Count > 0))
			{
				this.nativeEventSink = new CommonFileDialog.NativeDialogEventSink(this);
				uint cookie;
				nativeDlg.Advise(this.nativeEventSink, out cookie);
				this.nativeEventSink.Cookie = cookie;
			}
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0000FC10 File Offset: 0x0000DE10
		private void ApplyNativeSettings(IFileDialog dialog)
		{
			Debug.Assert(dialog != null, "No dialog instance to configure");
			if (this.parentWindow == IntPtr.Zero)
			{
				if (System.Windows.Application.Current != null && System.Windows.Application.Current.MainWindow != null)
				{
					this.parentWindow = new WindowInteropHelper(System.Windows.Application.Current.MainWindow).Handle;
				}
				else if (System.Windows.Forms.Application.OpenForms.Count > 0)
				{
					this.parentWindow = System.Windows.Forms.Application.OpenForms[0].Handle;
				}
			}
			Guid guid = new Guid("7E9FB0D3-919F-4307-AB2E-9B1860310C93");
			dialog.SetOptions(this.CalculateNativeDialogOptionFlags());
			if (this.title != null)
			{
				dialog.SetTitle(this.title);
			}
			if (this.initialDirectoryShellContainer != null)
			{
				dialog.SetFolder(this.initialDirectoryShellContainer.NativeShellItem);
			}
			if (this.defaultDirectoryShellContainer != null)
			{
				dialog.SetDefaultFolder(this.defaultDirectoryShellContainer.NativeShellItem);
			}
			if (!string.IsNullOrEmpty(this.initialDirectory))
			{
				IShellItem2 shellItem;
				ShellNativeMethods.SHCreateItemFromParsingName(this.initialDirectory, IntPtr.Zero, ref guid, out shellItem);
				if (shellItem != null)
				{
					dialog.SetFolder(shellItem);
				}
			}
			if (!string.IsNullOrEmpty(this.defaultDirectory))
			{
				IShellItem2 shellItem2;
				ShellNativeMethods.SHCreateItemFromParsingName(this.defaultDirectory, IntPtr.Zero, ref guid, out shellItem2);
				if (shellItem2 != null)
				{
					dialog.SetDefaultFolder(shellItem2);
				}
			}
			if (this.filters.Count > 0 && !this.filterSet)
			{
				dialog.SetFileTypes((uint)this.filters.Count, this.filters.GetAllFilterSpecs());
				this.filterSet = true;
				this.SyncFileTypeComboToDefaultExtension(dialog);
			}
			if (this.cookieIdentifier != Guid.Empty)
			{
				dialog.SetClientGuid(ref this.cookieIdentifier);
			}
			if (!string.IsNullOrEmpty(this.DefaultExtension))
			{
				dialog.SetDefaultExtension(this.DefaultExtension);
			}
			dialog.SetFileName(this.DefaultFileName);
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0000FE40 File Offset: 0x0000E040
		private ShellNativeMethods.FileOpenOptions CalculateNativeDialogOptionFlags()
		{
			ShellNativeMethods.FileOpenOptions fileOpenOptions = ShellNativeMethods.FileOpenOptions.NoTestFileCreate;
			fileOpenOptions = this.GetDerivedOptionFlags(fileOpenOptions);
			if (this.ensureFileExists)
			{
				fileOpenOptions |= ShellNativeMethods.FileOpenOptions.FileMustExist;
			}
			if (this.ensurePathExists)
			{
				fileOpenOptions |= ShellNativeMethods.FileOpenOptions.PathMustExist;
			}
			if (!this.ensureValidNames)
			{
				fileOpenOptions |= ShellNativeMethods.FileOpenOptions.NoValidate;
			}
			if (!this.EnsureReadOnly)
			{
				fileOpenOptions |= ShellNativeMethods.FileOpenOptions.NoReadOnlyReturn;
			}
			if (this.restoreDirectory)
			{
				fileOpenOptions |= ShellNativeMethods.FileOpenOptions.NoChangeDirectory;
			}
			if (!this.showPlacesList)
			{
				fileOpenOptions |= ShellNativeMethods.FileOpenOptions.HidePinnedPlaces;
			}
			if (!this.addToMruList)
			{
				fileOpenOptions |= ShellNativeMethods.FileOpenOptions.DontAddToRecent;
			}
			if (this.showHiddenItems)
			{
				fileOpenOptions |= ShellNativeMethods.FileOpenOptions.ForceShowHidden;
			}
			if (!this.navigateToShortcut)
			{
				fileOpenOptions |= ShellNativeMethods.FileOpenOptions.NoDereferenceLinks;
			}
			return fileOpenOptions;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0000FF1D File Offset: 0x0000E11D
		private static void GenerateNotImplementedException()
		{
			throw new NotImplementedException(LocalizedMessages.NotImplementedException);
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0000FF2C File Offset: 0x0000E12C
		public virtual bool IsCollectionChangeAllowed()
		{
			return true;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0000FF40 File Offset: 0x0000E140
		public virtual void ApplyCollectionChanged()
		{
			this.GetCustomizedFileDialog();
			foreach (CommonFileDialogControl commonFileDialogControl in this.controls)
			{
				if (!commonFileDialogControl.IsAdded)
				{
					commonFileDialogControl.HostingDialog = this;
					commonFileDialogControl.Attach(this.customize);
					commonFileDialogControl.IsAdded = true;
				}
			}
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0000FFC4 File Offset: 0x0000E1C4
		public virtual bool IsControlPropertyChangeAllowed(string propertyName, DialogControl control)
		{
			CommonFileDialog.GenerateNotImplementedException();
			return false;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x0000FFE0 File Offset: 0x0000E1E0
		public virtual void ApplyControlPropertyChange(string propertyName, DialogControl control)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			CommonFileDialogControl commonFileDialogControl = null;
			if (propertyName == "Text")
			{
				CommonFileDialogTextBox commonFileDialogTextBox = control as CommonFileDialogTextBox;
				if (commonFileDialogTextBox != null)
				{
					this.customize.SetEditBoxText(control.Id, commonFileDialogTextBox.Text);
				}
				else
				{
					this.customize.SetControlLabel(control.Id, commonFileDialogTextBox.Text);
				}
			}
			else if (propertyName == "Visible" && (commonFileDialogControl = (control as CommonFileDialogControl)) != null)
			{
				ShellNativeMethods.ControlState controlState;
				this.customize.GetControlState(control.Id, out controlState);
				if (commonFileDialogControl.Visible)
				{
					controlState |= ShellNativeMethods.ControlState.Visible;
				}
				else if (!commonFileDialogControl.Visible)
				{
					controlState &= (ShellNativeMethods.ControlState)(-3);
				}
				this.customize.SetControlState(control.Id, controlState);
			}
			else if (propertyName == "Enabled" && commonFileDialogControl != null)
			{
				ShellNativeMethods.ControlState controlState;
				this.customize.GetControlState(control.Id, out controlState);
				if (commonFileDialogControl.Enabled)
				{
					controlState |= ShellNativeMethods.ControlState.Enable;
				}
				else if (!commonFileDialogControl.Enabled)
				{
					controlState &= (ShellNativeMethods.ControlState)(-2);
				}
				this.customize.SetControlState(control.Id, controlState);
			}
			else if (propertyName == "SelectedIndex")
			{
				CommonFileDialogRadioButtonList commonFileDialogRadioButtonList;
				CommonFileDialogComboBox commonFileDialogComboBox;
				if ((commonFileDialogRadioButtonList = (control as CommonFileDialogRadioButtonList)) != null)
				{
					this.customize.SetSelectedControlItem(commonFileDialogRadioButtonList.Id, commonFileDialogRadioButtonList.SelectedIndex);
				}
				else if ((commonFileDialogComboBox = (control as CommonFileDialogComboBox)) != null)
				{
					this.customize.SetSelectedControlItem(commonFileDialogComboBox.Id, commonFileDialogComboBox.SelectedIndex);
				}
			}
			else if (propertyName == "IsChecked")
			{
				CommonFileDialogCheckBox commonFileDialogCheckBox = control as CommonFileDialogCheckBox;
				if (commonFileDialogCheckBox != null)
				{
					this.customize.SetCheckButtonState(commonFileDialogCheckBox.Id, commonFileDialogCheckBox.IsChecked);
				}
			}
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00010210 File Offset: 0x0000E410
		protected void CheckFileNamesAvailable()
		{
			if (this.showState != DialogShowState.Closed)
			{
				throw new InvalidOperationException(LocalizedMessages.CommonFileDialogNotClosed);
			}
			if (this.canceled.GetValueOrDefault())
			{
				throw new InvalidOperationException(LocalizedMessages.CommonFileDialogCanceled);
			}
			Debug.Assert(this.filenames.Count != 0, "FileNames empty - shouldn't happen unless dialog canceled or not yet shown.");
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00010274 File Offset: 0x0000E474
		protected void CheckFileItemsAvailable()
		{
			if (this.showState != DialogShowState.Closed)
			{
				throw new InvalidOperationException(LocalizedMessages.CommonFileDialogNotClosed);
			}
			if (this.canceled.GetValueOrDefault())
			{
				throw new InvalidOperationException(LocalizedMessages.CommonFileDialogCanceled);
			}
			Debug.Assert(this.items.Count != 0, "Items list empty - shouldn't happen unless dialog canceled or not yet shown.");
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x000102D8 File Offset: 0x0000E4D8
		private bool NativeDialogShowing
		{
			get
			{
				return this.nativeDialog != null && (this.showState == DialogShowState.Showing || this.showState == DialogShowState.Closing);
			}
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0001030C File Offset: 0x0000E50C
		internal static string GetFileNameFromShellItem(IShellItem item)
		{
			string result = null;
			IntPtr zero = IntPtr.Zero;
			if (item.GetDisplayName(ShellNativeMethods.ShellItemDesignNameOptions.DesktopAbsoluteParsing, out zero) == HResult.Ok && zero != IntPtr.Zero)
			{
				result = Marshal.PtrToStringAuto(zero);
				Marshal.FreeCoTaskMem(zero);
			}
			return result;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00010360 File Offset: 0x0000E560
		internal static IShellItem GetShellItemAt(IShellItemArray array, int i)
		{
			IShellItem result;
			array.GetItemAt((uint)i, out result);
			return result;
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00010380 File Offset: 0x0000E580
		protected void ThrowIfDialogShowing(string message)
		{
			if (this.NativeDialogShowing)
			{
				throw new InvalidOperationException(message);
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x000103A4 File Offset: 0x0000E5A4
		private void GetCustomizedFileDialog()
		{
			if (this.customize == null)
			{
				if (this.nativeDialog == null)
				{
					this.InitializeNativeFileDialog();
					this.nativeDialog = this.GetNativeFileDialog();
				}
				this.customize = (IFileDialogCustomize)this.nativeDialog;
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000103FC File Offset: 0x0000E5FC
		protected virtual void OnFileOk(CancelEventArgs e)
		{
			CancelEventHandler fileOk = this.FileOk;
			if (fileOk != null)
			{
				fileOk(this, e);
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00010424 File Offset: 0x0000E624
		protected virtual void OnFolderChanging(CommonFileDialogFolderChangeEventArgs e)
		{
			EventHandler<CommonFileDialogFolderChangeEventArgs> folderChanging = this.FolderChanging;
			if (folderChanging != null)
			{
				folderChanging(this, e);
			}
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0001044C File Offset: 0x0000E64C
		protected virtual void OnFolderChanged(EventArgs e)
		{
			EventHandler folderChanged = this.FolderChanged;
			if (folderChanged != null)
			{
				folderChanged(this, e);
			}
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00010474 File Offset: 0x0000E674
		protected virtual void OnSelectionChanged(EventArgs e)
		{
			EventHandler selectionChanged = this.SelectionChanged;
			if (selectionChanged != null)
			{
				selectionChanged(this, e);
			}
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0001049C File Offset: 0x0000E69C
		protected virtual void OnFileTypeChanged(EventArgs e)
		{
			EventHandler fileTypeChanged = this.FileTypeChanged;
			if (fileTypeChanged != null)
			{
				fileTypeChanged(this, e);
			}
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x000104C4 File Offset: 0x0000E6C4
		protected virtual void OnOpening(EventArgs e)
		{
			EventHandler dialogOpening = this.DialogOpening;
			if (dialogOpening != null)
			{
				dialogOpening(this, e);
			}
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x000104EC File Offset: 0x0000E6EC
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.CleanUpNativeFileDialog();
			}
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0001050B File Offset: 0x0000E70B
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x00010520 File Offset: 0x0000E720
		public static bool IsPlatformSupported
		{
			get
			{
				return CoreHelpers.RunningOnVista;
			}
		}

		// Token: 0x040002AA RID: 682
		private Collection<string> filenames;

		// Token: 0x040002AB RID: 683
		internal readonly Collection<IShellItem> items;

		// Token: 0x040002AC RID: 684
		internal DialogShowState showState = DialogShowState.PreShow;

		// Token: 0x040002AD RID: 685
		private IFileDialog nativeDialog;

		// Token: 0x040002AE RID: 686
		private IFileDialogCustomize customize;

		// Token: 0x040002AF RID: 687
		private CommonFileDialog.NativeDialogEventSink nativeEventSink;

		// Token: 0x040002B0 RID: 688
		private bool? canceled;

		// Token: 0x040002B1 RID: 689
		private bool resetSelections;

		// Token: 0x040002B2 RID: 690
		private IntPtr parentWindow = IntPtr.Zero;

		// Token: 0x040002B3 RID: 691
		private bool filterSet;

		// Token: 0x040002BA RID: 698
		private CommonFileDialogControlCollection<CommonFileDialogControl> controls;

		// Token: 0x040002BB RID: 699
		private CommonFileDialogFilterCollection filters;

		// Token: 0x040002BC RID: 700
		private string title;

		// Token: 0x040002BD RID: 701
		private bool ensureFileExists;

		// Token: 0x040002BE RID: 702
		private bool ensurePathExists;

		// Token: 0x040002BF RID: 703
		private bool ensureValidNames;

		// Token: 0x040002C0 RID: 704
		private bool ensureReadOnly;

		// Token: 0x040002C1 RID: 705
		private bool restoreDirectory;

		// Token: 0x040002C2 RID: 706
		private bool showPlacesList = true;

		// Token: 0x040002C3 RID: 707
		private bool addToMruList = true;

		// Token: 0x040002C4 RID: 708
		private bool showHiddenItems;

		// Token: 0x040002C5 RID: 709
		private bool allowPropertyEditing;

		// Token: 0x040002C6 RID: 710
		private bool navigateToShortcut = true;

		// Token: 0x040002C7 RID: 711
		private string initialDirectory;

		// Token: 0x040002C8 RID: 712
		private ShellContainer initialDirectoryShellContainer;

		// Token: 0x040002C9 RID: 713
		private string defaultDirectory;

		// Token: 0x040002CA RID: 714
		private ShellContainer defaultDirectoryShellContainer;

		// Token: 0x040002CB RID: 715
		private Guid cookieIdentifier;

		// Token: 0x02000079 RID: 121
		private class NativeDialogEventSink : IFileDialogEvents, IFileDialogControlEvents
		{
			// Token: 0x0600042D RID: 1069 RVA: 0x00010537 File Offset: 0x0000E737
			public NativeDialogEventSink(CommonFileDialog commonDialog)
			{
				this.parent = commonDialog;
			}

			// Token: 0x17000157 RID: 343
			// (get) Token: 0x0600042E RID: 1070 RVA: 0x00010550 File Offset: 0x0000E750
			// (set) Token: 0x0600042F RID: 1071 RVA: 0x00010567 File Offset: 0x0000E767
			public uint Cookie { get; set; }

			// Token: 0x06000430 RID: 1072 RVA: 0x00010570 File Offset: 0x0000E770
			public HResult OnFileOk(IFileDialog pfd)
			{
				CancelEventArgs cancelEventArgs = new CancelEventArgs();
				this.parent.OnFileOk(cancelEventArgs);
				if (!cancelEventArgs.Cancel)
				{
					if (this.parent.Controls != null)
					{
						foreach (CommonFileDialogControl commonFileDialogControl in this.parent.Controls)
						{
							CommonFileDialogTextBox commonFileDialogTextBox;
							CommonFileDialogGroupBox commonFileDialogGroupBox;
							if ((commonFileDialogTextBox = (commonFileDialogControl as CommonFileDialogTextBox)) != null)
							{
								commonFileDialogTextBox.SyncValue();
								commonFileDialogTextBox.Closed = true;
							}
							else if ((commonFileDialogGroupBox = (commonFileDialogControl as CommonFileDialogGroupBox)) != null)
							{
								foreach (DialogControl dialogControl in commonFileDialogGroupBox.Items)
								{
									CommonFileDialogControl commonFileDialogControl2 = (CommonFileDialogControl)dialogControl;
									CommonFileDialogTextBox commonFileDialogTextBox2 = commonFileDialogControl2 as CommonFileDialogTextBox;
									if (commonFileDialogTextBox2 != null)
									{
										commonFileDialogTextBox2.SyncValue();
										commonFileDialogTextBox2.Closed = true;
									}
								}
							}
						}
					}
				}
				return cancelEventArgs.Cancel ? HResult.False : HResult.Ok;
			}

			// Token: 0x06000431 RID: 1073 RVA: 0x000106D8 File Offset: 0x0000E8D8
			public HResult OnFolderChanging(IFileDialog pfd, IShellItem psiFolder)
			{
				CommonFileDialogFolderChangeEventArgs commonFileDialogFolderChangeEventArgs = new CommonFileDialogFolderChangeEventArgs(CommonFileDialog.GetFileNameFromShellItem(psiFolder));
				if (!this.firstFolderChanged)
				{
					this.parent.OnFolderChanging(commonFileDialogFolderChangeEventArgs);
				}
				return commonFileDialogFolderChangeEventArgs.Cancel ? HResult.False : HResult.Ok;
			}

			// Token: 0x06000432 RID: 1074 RVA: 0x0001071C File Offset: 0x0000E91C
			public void OnFolderChange(IFileDialog pfd)
			{
				if (this.firstFolderChanged)
				{
					this.firstFolderChanged = false;
					this.parent.OnOpening(EventArgs.Empty);
				}
				else
				{
					this.parent.OnFolderChanged(EventArgs.Empty);
				}
			}

			// Token: 0x06000433 RID: 1075 RVA: 0x00010766 File Offset: 0x0000E966
			public void OnSelectionChange(IFileDialog pfd)
			{
				this.parent.OnSelectionChanged(EventArgs.Empty);
			}

			// Token: 0x06000434 RID: 1076 RVA: 0x0001077A File Offset: 0x0000E97A
			public void OnShareViolation(IFileDialog pfd, IShellItem psi, out ShellNativeMethods.FileDialogEventShareViolationResponse pResponse)
			{
				pResponse = ShellNativeMethods.FileDialogEventShareViolationResponse.Accept;
			}

			// Token: 0x06000435 RID: 1077 RVA: 0x00010780 File Offset: 0x0000E980
			public void OnTypeChange(IFileDialog pfd)
			{
				this.parent.OnFileTypeChanged(EventArgs.Empty);
			}

			// Token: 0x06000436 RID: 1078 RVA: 0x00010794 File Offset: 0x0000E994
			public void OnOverwrite(IFileDialog pfd, IShellItem psi, out ShellNativeMethods.FileDialogEventOverwriteResponse pResponse)
			{
				pResponse = ShellNativeMethods.FileDialogEventOverwriteResponse.Default;
			}

			// Token: 0x06000437 RID: 1079 RVA: 0x0001079C File Offset: 0x0000E99C
			public void OnItemSelected(IFileDialogCustomize pfdc, int dwIDCtl, int dwIDItem)
			{
				DialogControl controlbyId = this.parent.controls.GetControlbyId(dwIDCtl);
				ICommonFileDialogIndexedControls commonFileDialogIndexedControls;
				CommonFileDialogMenu commonFileDialogMenu;
				if ((commonFileDialogIndexedControls = (controlbyId as ICommonFileDialogIndexedControls)) != null)
				{
					commonFileDialogIndexedControls.SelectedIndex = dwIDItem;
					commonFileDialogIndexedControls.RaiseSelectedIndexChangedEvent();
				}
				else if ((commonFileDialogMenu = (controlbyId as CommonFileDialogMenu)) != null)
				{
					foreach (CommonFileDialogMenuItem commonFileDialogMenuItem in commonFileDialogMenu.Items)
					{
						if (commonFileDialogMenuItem.Id == dwIDItem)
						{
							commonFileDialogMenuItem.RaiseClickEvent();
							break;
						}
					}
				}
			}

			// Token: 0x06000438 RID: 1080 RVA: 0x00010860 File Offset: 0x0000EA60
			public void OnButtonClicked(IFileDialogCustomize pfdc, int dwIDCtl)
			{
				DialogControl controlbyId = this.parent.controls.GetControlbyId(dwIDCtl);
				CommonFileDialogButton commonFileDialogButton = controlbyId as CommonFileDialogButton;
				if (commonFileDialogButton != null)
				{
					commonFileDialogButton.RaiseClickEvent();
				}
			}

			// Token: 0x06000439 RID: 1081 RVA: 0x00010898 File Offset: 0x0000EA98
			public void OnCheckButtonToggled(IFileDialogCustomize pfdc, int dwIDCtl, bool bChecked)
			{
				DialogControl controlbyId = this.parent.controls.GetControlbyId(dwIDCtl);
				CommonFileDialogCheckBox commonFileDialogCheckBox = controlbyId as CommonFileDialogCheckBox;
				if (commonFileDialogCheckBox != null)
				{
					commonFileDialogCheckBox.IsChecked = bChecked;
					commonFileDialogCheckBox.RaiseCheckedChangedEvent();
				}
			}

			// Token: 0x0600043A RID: 1082 RVA: 0x000108D8 File Offset: 0x0000EAD8
			public void OnControlActivating(IFileDialogCustomize pfdc, int dwIDCtl)
			{
			}

			// Token: 0x040002CE RID: 718
			private CommonFileDialog parent;

			// Token: 0x040002CF RID: 719
			private bool firstFolderChanged = true;
		}
	}
}
