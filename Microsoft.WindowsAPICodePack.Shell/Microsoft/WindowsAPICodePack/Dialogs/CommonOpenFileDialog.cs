using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x0200008F RID: 143
	public sealed class CommonOpenFileDialog : CommonFileDialog
	{
		// Token: 0x060004C5 RID: 1221 RVA: 0x00012135 File Offset: 0x00010335
		public CommonOpenFileDialog()
		{
			base.EnsureReadOnly = true;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00012148 File Offset: 0x00010348
		public CommonOpenFileDialog(string name) : base(name)
		{
			base.EnsureReadOnly = true;
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x0001215C File Offset: 0x0001035C
		public IEnumerable<string> FileNames
		{
			get
			{
				base.CheckFileNamesAvailable();
				return base.FileNameCollection;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x0001217C File Offset: 0x0001037C
		public ICollection<ShellObject> FilesAsShellObject
		{
			get
			{
				base.CheckFileItemsAvailable();
				ICollection<ShellObject> collection = new Collection<ShellObject>();
				foreach (IShellItem nativeShellItem in this.items)
				{
					collection.Add(ShellObjectFactory.Create(nativeShellItem));
				}
				return collection;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x000121F4 File Offset: 0x000103F4
		// (set) Token: 0x060004CA RID: 1226 RVA: 0x0001220C File Offset: 0x0001040C
		public bool Multiselect
		{
			get
			{
				return this.multiselect;
			}
			set
			{
				this.multiselect = value;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x00012218 File Offset: 0x00010418
		// (set) Token: 0x060004CC RID: 1228 RVA: 0x00012230 File Offset: 0x00010430
		public bool IsFolderPicker
		{
			get
			{
				return this.isFolderPicker;
			}
			set
			{
				this.isFolderPicker = value;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x0001223C File Offset: 0x0001043C
		// (set) Token: 0x060004CE RID: 1230 RVA: 0x00012254 File Offset: 0x00010454
		public bool AllowNonFileSystemItems
		{
			get
			{
				return this.allowNonFileSystem;
			}
			set
			{
				this.allowNonFileSystem = value;
			}
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00012260 File Offset: 0x00010460
		internal override IFileDialog GetNativeFileDialog()
		{
			Debug.Assert(this.openDialogCoClass != null, "Must call Initialize() before fetching dialog interface");
			return this.openDialogCoClass;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00012290 File Offset: 0x00010490
		internal override void InitializeNativeFileDialog()
		{
			if (this.openDialogCoClass == null)
			{
				this.openDialogCoClass = (NativeFileOpenDialog)new FileOpenDialogRCW();
			}
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x000122C0 File Offset: 0x000104C0
		internal override void CleanUpNativeFileDialog()
		{
			if (this.openDialogCoClass != null)
			{
				Marshal.ReleaseComObject(this.openDialogCoClass);
			}
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x000122EC File Offset: 0x000104EC
		internal override void PopulateWithFileNames(Collection<string> names)
		{
			IShellItemArray shellItemArray;
			this.openDialogCoClass.GetResults(out shellItemArray);
			uint num;
			shellItemArray.GetCount(out num);
			names.Clear();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				names.Add(CommonFileDialog.GetFileNameFromShellItem(CommonFileDialog.GetShellItemAt(shellItemArray, num2)));
				num2++;
			}
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00012340 File Offset: 0x00010540
		internal override void PopulateWithIShellItems(Collection<IShellItem> items)
		{
			IShellItemArray shellItemArray;
			this.openDialogCoClass.GetResults(out shellItemArray);
			uint num;
			shellItemArray.GetCount(out num);
			items.Clear();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				items.Add(CommonFileDialog.GetShellItemAt(shellItemArray, num2));
				num2++;
			}
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00012390 File Offset: 0x00010590
		internal override ShellNativeMethods.FileOpenOptions GetDerivedOptionFlags(ShellNativeMethods.FileOpenOptions flags)
		{
			if (this.multiselect)
			{
				flags |= ShellNativeMethods.FileOpenOptions.AllowMultiSelect;
			}
			if (this.isFolderPicker)
			{
				flags |= ShellNativeMethods.FileOpenOptions.PickFolders;
			}
			if (!this.allowNonFileSystem)
			{
				flags |= ShellNativeMethods.FileOpenOptions.ForceFilesystem;
			}
			else if (this.allowNonFileSystem)
			{
				flags |= ShellNativeMethods.FileOpenOptions.AllNonStorageItems;
			}
			return flags;
		}

		// Token: 0x04000300 RID: 768
		private NativeFileOpenDialog openDialogCoClass;

		// Token: 0x04000301 RID: 769
		private bool multiselect;

		// Token: 0x04000302 RID: 770
		private bool isFolderPicker;

		// Token: 0x04000303 RID: 771
		private bool allowNonFileSystem;
	}
}
