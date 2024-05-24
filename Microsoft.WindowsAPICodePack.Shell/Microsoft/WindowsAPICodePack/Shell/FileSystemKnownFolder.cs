using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x020000DF RID: 223
	public class FileSystemKnownFolder : ShellFileSystemFolder, IKnownFolder, IEnumerable<ShellObject>, IEnumerable, IDisposable
	{
		// Token: 0x06000888 RID: 2184 RVA: 0x00024C18 File Offset: 0x00022E18
		internal FileSystemKnownFolder(IShellItem2 shellItem) : base(shellItem)
		{
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00024C24 File Offset: 0x00022E24
		internal FileSystemKnownFolder(IKnownFolderNative kf)
		{
			Debug.Assert(kf != null);
			this.knownFolderNative = kf;
			Guid guid = new Guid("7E9FB0D3-919F-4307-AB2E-9B1860310C93");
			this.knownFolderNative.GetShellItem(0, ref guid, out this.nativeShellItem);
		}

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x0600088A RID: 2186 RVA: 0x00024C74 File Offset: 0x00022E74
		private KnownFolderSettings KnownFolderSettings
		{
			get
			{
				if (this.knownFolderNative == null)
				{
					if (this.nativeShellItem != null && base.PIDL == IntPtr.Zero)
					{
						base.PIDL = ShellHelper.PidlFromShellItem(this.nativeShellItem);
					}
					if (base.PIDL != IntPtr.Zero)
					{
						this.knownFolderNative = KnownFolderHelper.FromPIDL(base.PIDL);
					}
					Debug.Assert(this.knownFolderNative != null);
				}
				if (this.knownFolderSettings == null)
				{
					this.knownFolderSettings = new KnownFolderSettings(this.knownFolderNative);
				}
				return this.knownFolderSettings;
			}
		}

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x0600088B RID: 2187 RVA: 0x00024D34 File Offset: 0x00022F34
		public override string Path
		{
			get
			{
				return this.KnownFolderSettings.Path;
			}
		}

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x0600088C RID: 2188 RVA: 0x00024D54 File Offset: 0x00022F54
		public FolderCategory Category
		{
			get
			{
				return this.KnownFolderSettings.Category;
			}
		}

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x0600088D RID: 2189 RVA: 0x00024D74 File Offset: 0x00022F74
		public string CanonicalName
		{
			get
			{
				return this.KnownFolderSettings.CanonicalName;
			}
		}

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x0600088E RID: 2190 RVA: 0x00024D94 File Offset: 0x00022F94
		public string Description
		{
			get
			{
				return this.KnownFolderSettings.Description;
			}
		}

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x0600088F RID: 2191 RVA: 0x00024DB4 File Offset: 0x00022FB4
		public Guid ParentId
		{
			get
			{
				return this.KnownFolderSettings.ParentId;
			}
		}

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06000890 RID: 2192 RVA: 0x00024DD4 File Offset: 0x00022FD4
		public string RelativePath
		{
			get
			{
				return this.KnownFolderSettings.RelativePath;
			}
		}

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06000891 RID: 2193 RVA: 0x00024DF4 File Offset: 0x00022FF4
		public override string ParsingName
		{
			get
			{
				return base.ParsingName;
			}
		}

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06000892 RID: 2194 RVA: 0x00024E0C File Offset: 0x0002300C
		public string Tooltip
		{
			get
			{
				return this.KnownFolderSettings.Tooltip;
			}
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06000893 RID: 2195 RVA: 0x00024E2C File Offset: 0x0002302C
		public string TooltipResourceId
		{
			get
			{
				return this.KnownFolderSettings.TooltipResourceId;
			}
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06000894 RID: 2196 RVA: 0x00024E4C File Offset: 0x0002304C
		public string LocalizedName
		{
			get
			{
				return this.KnownFolderSettings.LocalizedName;
			}
		}

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06000895 RID: 2197 RVA: 0x00024E6C File Offset: 0x0002306C
		public string LocalizedNameResourceId
		{
			get
			{
				return this.KnownFolderSettings.LocalizedNameResourceId;
			}
		}

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06000896 RID: 2198 RVA: 0x00024E8C File Offset: 0x0002308C
		public string Security
		{
			get
			{
				return this.KnownFolderSettings.Security;
			}
		}

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06000897 RID: 2199 RVA: 0x00024EAC File Offset: 0x000230AC
		public FileAttributes FileAttributes
		{
			get
			{
				return this.KnownFolderSettings.FileAttributes;
			}
		}

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06000898 RID: 2200 RVA: 0x00024ECC File Offset: 0x000230CC
		public DefinitionOptions DefinitionOptions
		{
			get
			{
				return this.KnownFolderSettings.DefinitionOptions;
			}
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06000899 RID: 2201 RVA: 0x00024EEC File Offset: 0x000230EC
		public Guid FolderTypeId
		{
			get
			{
				return this.KnownFolderSettings.FolderTypeId;
			}
		}

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x0600089A RID: 2202 RVA: 0x00024F0C File Offset: 0x0002310C
		public string FolderType
		{
			get
			{
				return this.KnownFolderSettings.FolderType;
			}
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x0600089B RID: 2203 RVA: 0x00024F2C File Offset: 0x0002312C
		public Guid FolderId
		{
			get
			{
				return this.KnownFolderSettings.FolderId;
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x0600089C RID: 2204 RVA: 0x00024F4C File Offset: 0x0002314C
		public bool PathExists
		{
			get
			{
				return this.KnownFolderSettings.PathExists;
			}
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x0600089D RID: 2205 RVA: 0x00024F6C File Offset: 0x0002316C
		public RedirectionCapability Redirection
		{
			get
			{
				return this.KnownFolderSettings.Redirection;
			}
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x00024F8C File Offset: 0x0002318C
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.knownFolderSettings = null;
			}
			if (this.knownFolderNative != null)
			{
				Marshal.ReleaseComObject(this.knownFolderNative);
				this.knownFolderNative = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000429 RID: 1065
		private IKnownFolderNative knownFolderNative;

		// Token: 0x0400042A RID: 1066
		private KnownFolderSettings knownFolderSettings;
	}
}
