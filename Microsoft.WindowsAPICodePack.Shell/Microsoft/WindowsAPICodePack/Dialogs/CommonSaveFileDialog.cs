using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000090 RID: 144
	public sealed class CommonSaveFileDialog : CommonFileDialog
	{
		// Token: 0x060004D5 RID: 1237 RVA: 0x000123FC File Offset: 0x000105FC
		public CommonSaveFileDialog()
		{
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x0001240E File Offset: 0x0001060E
		public CommonSaveFileDialog(string name) : base(name)
		{
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x00012424 File Offset: 0x00010624
		// (set) Token: 0x060004D8 RID: 1240 RVA: 0x0001243C File Offset: 0x0001063C
		public bool OverwritePrompt
		{
			get
			{
				return this.overwritePrompt;
			}
			set
			{
				base.ThrowIfDialogShowing(LocalizedMessages.OverwritePromptCannotBeChanged);
				this.overwritePrompt = value;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x00012454 File Offset: 0x00010654
		// (set) Token: 0x060004DA RID: 1242 RVA: 0x0001246C File Offset: 0x0001066C
		public bool CreatePrompt
		{
			get
			{
				return this.createPrompt;
			}
			set
			{
				base.ThrowIfDialogShowing(LocalizedMessages.CreatePromptCannotBeChanged);
				this.createPrompt = value;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060004DB RID: 1243 RVA: 0x00012484 File Offset: 0x00010684
		// (set) Token: 0x060004DC RID: 1244 RVA: 0x0001249C File Offset: 0x0001069C
		public bool IsExpandedMode
		{
			get
			{
				return this.isExpandedMode;
			}
			set
			{
				base.ThrowIfDialogShowing(LocalizedMessages.IsExpandedModeCannotBeChanged);
				this.isExpandedMode = value;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060004DD RID: 1245 RVA: 0x000124B4 File Offset: 0x000106B4
		// (set) Token: 0x060004DE RID: 1246 RVA: 0x000124CC File Offset: 0x000106CC
		public bool AlwaysAppendDefaultExtension
		{
			get
			{
				return this.alwaysAppendDefaultExtension;
			}
			set
			{
				base.ThrowIfDialogShowing(LocalizedMessages.AlwaysAppendDefaultExtensionCannotBeChanged);
				this.alwaysAppendDefaultExtension = value;
			}
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x000124E4 File Offset: 0x000106E4
		public void SetSaveAsItem(ShellObject item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			this.InitializeNativeFileDialog();
			IFileSaveDialog fileSaveDialog = this.GetNativeFileDialog() as IFileSaveDialog;
			if (fileSaveDialog != null)
			{
				fileSaveDialog.SetSaveAsItem(item.NativeShellItem);
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00012538 File Offset: 0x00010738
		public void SetCollectedPropertyKeys(bool appendDefault, params PropertyKey[] propertyList)
		{
			bool flag;
			if (propertyList != null && propertyList.Length > 0)
			{
				PropertyKey propertyKey = propertyList[0];
				flag = (1 == 0);
			}
			else
			{
				flag = true;
			}
			if (!flag)
			{
				StringBuilder stringBuilder = new StringBuilder("prop:");
				foreach (PropertyKey key in propertyList)
				{
					string canonicalName = ShellPropertyDescriptionsCache.Cache.GetPropertyDescription(key).CanonicalName;
					if (!string.IsNullOrEmpty(canonicalName))
					{
						stringBuilder.AppendFormat("{0};", canonicalName);
					}
				}
				Guid guid = new Guid("1F9FC1D0-C39B-4B26-817F-011967D3440E");
				IPropertyDescriptionList propertyDescriptionList = null;
				try
				{
					int num = PropertySystemNativeMethods.PSGetPropertyDescriptionListFromString(stringBuilder.ToString(), ref guid, out propertyDescriptionList);
					if (CoreErrorHelper.Succeeded(num))
					{
						this.InitializeNativeFileDialog();
						IFileSaveDialog fileSaveDialog = this.GetNativeFileDialog() as IFileSaveDialog;
						if (fileSaveDialog != null)
						{
							num = fileSaveDialog.SetCollectedProperties(propertyDescriptionList, appendDefault);
							if (!CoreErrorHelper.Succeeded(num))
							{
								throw new ShellException(num);
							}
						}
					}
				}
				finally
				{
					if (propertyDescriptionList != null)
					{
						Marshal.ReleaseComObject(propertyDescriptionList);
					}
				}
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060004E1 RID: 1249 RVA: 0x0001267C File Offset: 0x0001087C
		public ShellPropertyCollection CollectedProperties
		{
			get
			{
				this.InitializeNativeFileDialog();
				IFileSaveDialog fileSaveDialog = this.GetNativeFileDialog() as IFileSaveDialog;
				if (fileSaveDialog != null)
				{
					IPropertyStore propertyStore;
					HResult properties = fileSaveDialog.GetProperties(out propertyStore);
					if (propertyStore != null && CoreErrorHelper.Succeeded(properties))
					{
						return new ShellPropertyCollection(propertyStore);
					}
				}
				return null;
			}
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x000126D8 File Offset: 0x000108D8
		internal override void InitializeNativeFileDialog()
		{
			if (this.saveDialogCoClass == null)
			{
				this.saveDialogCoClass = (NativeFileSaveDialog)new FileSaveDialogRCW();
			}
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00012708 File Offset: 0x00010908
		internal override IFileDialog GetNativeFileDialog()
		{
			Debug.Assert(this.saveDialogCoClass != null, "Must call Initialize() before fetching dialog interface");
			return this.saveDialogCoClass;
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00012738 File Offset: 0x00010938
		internal override void PopulateWithFileNames(Collection<string> names)
		{
			IShellItem shellItem;
			this.saveDialogCoClass.GetResult(out shellItem);
			if (shellItem == null)
			{
				throw new InvalidOperationException(LocalizedMessages.SaveFileNullItem);
			}
			names.Clear();
			names.Add(CommonFileDialog.GetFileNameFromShellItem(shellItem));
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00012780 File Offset: 0x00010980
		internal override void PopulateWithIShellItems(Collection<IShellItem> items)
		{
			IShellItem shellItem;
			this.saveDialogCoClass.GetResult(out shellItem);
			if (shellItem == null)
			{
				throw new InvalidOperationException(LocalizedMessages.SaveFileNullItem);
			}
			items.Clear();
			items.Add(shellItem);
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x000127C4 File Offset: 0x000109C4
		internal override void CleanUpNativeFileDialog()
		{
			if (this.saveDialogCoClass != null)
			{
				Marshal.ReleaseComObject(this.saveDialogCoClass);
			}
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x000127F0 File Offset: 0x000109F0
		internal override ShellNativeMethods.FileOpenOptions GetDerivedOptionFlags(ShellNativeMethods.FileOpenOptions flags)
		{
			if (this.overwritePrompt)
			{
				flags |= ShellNativeMethods.FileOpenOptions.OverwritePrompt;
			}
			if (this.createPrompt)
			{
				flags |= ShellNativeMethods.FileOpenOptions.CreatePrompt;
			}
			if (!this.isExpandedMode)
			{
				flags |= ShellNativeMethods.FileOpenOptions.DefaultNoMiniMode;
			}
			if (this.alwaysAppendDefaultExtension)
			{
				flags |= ShellNativeMethods.FileOpenOptions.StrictFileTypes;
			}
			return flags;
		}

		// Token: 0x04000304 RID: 772
		private NativeFileSaveDialog saveDialogCoClass;

		// Token: 0x04000305 RID: 773
		private bool overwritePrompt = true;

		// Token: 0x04000306 RID: 774
		private bool createPrompt;

		// Token: 0x04000307 RID: 775
		private bool isExpandedMode;

		// Token: 0x04000308 RID: 776
		private bool alwaysAppendDefaultExtension;
	}
}
