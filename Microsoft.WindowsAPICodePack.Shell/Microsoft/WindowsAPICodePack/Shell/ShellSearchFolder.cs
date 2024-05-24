using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000010 RID: 16
	public class ShellSearchFolder : ShellSearchCollection
	{
		// Token: 0x06000080 RID: 128 RVA: 0x00003B70 File Offset: 0x00001D70
		public ShellSearchFolder(SearchCondition searchCondition, params ShellContainer[] searchScopePath)
		{
			CoreHelpers.ThrowIfNotVista();
			this.NativeSearchFolderItemFactory = (ISearchFolderItemFactory)new SearchFolderItemFactoryCoClass();
			this.SearchCondition = searchCondition;
			if (searchScopePath != null && searchScopePath.Length > 0 && searchScopePath[0] != null)
			{
				this.SearchScopePaths = from cont in searchScopePath
				select cont.ParsingName;
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003BF0 File Offset: 0x00001DF0
		public ShellSearchFolder(SearchCondition searchCondition, params string[] searchScopePath)
		{
			CoreHelpers.ThrowIfNotVista();
			this.NativeSearchFolderItemFactory = (ISearchFolderItemFactory)new SearchFolderItemFactoryCoClass();
			if (searchScopePath != null && searchScopePath.Length > 0 && searchScopePath[0] != null)
			{
				this.SearchScopePaths = searchScopePath;
			}
			this.SearchCondition = searchCondition;
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00003C48 File Offset: 0x00001E48
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00003C5F File Offset: 0x00001E5F
		internal ISearchFolderItemFactory NativeSearchFolderItemFactory { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00003C68 File Offset: 0x00001E68
		// (set) Token: 0x06000085 RID: 133 RVA: 0x00003C80 File Offset: 0x00001E80
		public SearchCondition SearchCondition
		{
			get
			{
				return this.searchCondition;
			}
			private set
			{
				this.searchCondition = value;
				this.NativeSearchFolderItemFactory.SetCondition(this.searchCondition.NativeSearchCondition);
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00003E80 File Offset: 0x00002080
		// (set) Token: 0x06000087 RID: 135 RVA: 0x00003EA4 File Offset: 0x000020A4
		public IEnumerable<string> SearchScopePaths
		{
			get
			{
				foreach (string scopePath in this.searchScopePaths)
				{
					yield return scopePath;
				}
				yield break;
			}
			private set
			{
				this.searchScopePaths = value.ToArray<string>();
				List<IShellItem> list = new List<IShellItem>(this.searchScopePaths.Length);
				Guid guid = new Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE");
				Guid guid2 = new Guid("B63EA76D-1F85-456F-A19C-48159EFA858B");
				foreach (string path in this.searchScopePaths)
				{
					IShellItem item;
					int result = ShellNativeMethods.SHCreateItemFromParsingName(path, IntPtr.Zero, ref guid, out item);
					if (CoreErrorHelper.Succeeded(result))
					{
						list.Add(item);
					}
				}
				IShellItemArray scope = new ShellItemArray(list.ToArray());
				HResult hresult = this.NativeSearchFolderItemFactory.SetScope(scope);
				if (!CoreErrorHelper.Succeeded((int)hresult))
				{
					throw new ShellException((int)hresult);
				}
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00003F74 File Offset: 0x00002174
		internal override IShellItem NativeShellItem
		{
			get
			{
				Guid guid = new Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE");
				IShellItem result;
				if (this.NativeSearchFolderItemFactory == null)
				{
					result = null;
				}
				else
				{
					IShellItem shellItem2;
					int shellItem = this.NativeSearchFolderItemFactory.GetShellItem(ref guid, out shellItem2);
					if (!CoreErrorHelper.Succeeded(shellItem))
					{
						throw new ShellException(shellItem);
					}
					result = shellItem2;
				}
				return result;
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003FD4 File Offset: 0x000021D4
		public void SetStacks(params string[] canonicalNames)
		{
			if (canonicalNames == null)
			{
				throw new ArgumentNullException("canonicalNames");
			}
			List<PropertyKey> list = new List<PropertyKey>();
			foreach (string pszCanonicalName in canonicalNames)
			{
				PropertyKey item;
				int num = PropertySystemNativeMethods.PSGetPropertyKeyFromName(pszCanonicalName, out item);
				if (!CoreErrorHelper.Succeeded(num))
				{
					throw new ArgumentException(LocalizedMessages.ShellInvalidCanonicalName, "canonicalNames", Marshal.GetExceptionForHR(num));
				}
				list.Add(item);
			}
			if (list.Count > 0)
			{
				this.SetStacks(list.ToArray());
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000407C File Offset: 0x0000227C
		public void SetStacks(params PropertyKey[] propertyKeys)
		{
			if (propertyKeys != null && propertyKeys.Length > 0)
			{
				this.NativeSearchFolderItemFactory.SetStacks((uint)propertyKeys.Length, propertyKeys);
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000040B0 File Offset: 0x000022B0
		public void SetDisplayName(string displayName)
		{
			HResult result = this.NativeSearchFolderItemFactory.SetDisplayName(displayName);
			if (!CoreErrorHelper.Succeeded(result))
			{
				throw new ShellException(result);
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000040E0 File Offset: 0x000022E0
		public void SetIconSize(int value)
		{
			HResult result = this.NativeSearchFolderItemFactory.SetIconSize(value);
			if (!CoreErrorHelper.Succeeded(result))
			{
				throw new ShellException(result);
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00004110 File Offset: 0x00002310
		public void SetFolderTypeID(Guid value)
		{
			HResult result = this.NativeSearchFolderItemFactory.SetFolderTypeID(value);
			if (!CoreErrorHelper.Succeeded(result))
			{
				throw new ShellException(result);
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00004140 File Offset: 0x00002340
		public void SetFolderLogicalViewMode(FolderLogicalViewMode mode)
		{
			HResult result = this.NativeSearchFolderItemFactory.SetFolderLogicalViewMode(mode);
			if (!CoreErrorHelper.Succeeded(result))
			{
				throw new ShellException(result);
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00004170 File Offset: 0x00002370
		public void SetVisibleColumns(PropertyKey[] value)
		{
			HResult hresult = this.NativeSearchFolderItemFactory.SetVisibleColumns((uint)((value == null) ? 0 : value.Length), value);
			if (!CoreErrorHelper.Succeeded(hresult))
			{
				throw new ShellException(LocalizedMessages.ShellSearchFolderUnableToSetVisibleColumns, Marshal.GetExceptionForHR((int)hresult));
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000041B4 File Offset: 0x000023B4
		public void SortColumns(SortColumn[] value)
		{
			HResult hresult = this.NativeSearchFolderItemFactory.SetSortColumns((uint)((value == null) ? 0 : value.Length), value);
			if (!CoreErrorHelper.Succeeded(hresult))
			{
				throw new ShellException(LocalizedMessages.ShellSearchFolderUnableToSetSortColumns, Marshal.GetExceptionForHR((int)hresult));
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000041F8 File Offset: 0x000023F8
		public void SetGroupColumn(PropertyKey propertyKey)
		{
			HResult result = this.NativeSearchFolderItemFactory.SetGroupColumn(ref propertyKey);
			if (!CoreErrorHelper.Succeeded(result))
			{
				throw new ShellException(result);
			}
		}

		// Token: 0x04000020 RID: 32
		private SearchCondition searchCondition;

		// Token: 0x04000021 RID: 33
		private string[] searchScopePaths;
	}
}
