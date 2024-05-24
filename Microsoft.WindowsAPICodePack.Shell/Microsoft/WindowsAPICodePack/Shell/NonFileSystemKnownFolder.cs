using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x020000E2 RID: 226
	public class NonFileSystemKnownFolder : ShellNonFileSystemFolder, IKnownFolder, IEnumerable<ShellObject>, IEnumerable, IDisposable
	{
		// Token: 0x060008A2 RID: 2210 RVA: 0x00025004 File Offset: 0x00023204
		internal NonFileSystemKnownFolder(IShellItem2 shellItem) : base(shellItem)
		{
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x00025010 File Offset: 0x00023210
		internal NonFileSystemKnownFolder(IKnownFolderNative kf)
		{
			Debug.Assert(kf != null);
			this.knownFolderNative = kf;
			Guid guid = new Guid("7E9FB0D3-919F-4307-AB2E-9B1860310C93");
			this.knownFolderNative.GetShellItem(0, ref guid, out this.nativeShellItem);
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x060008A4 RID: 2212 RVA: 0x00025060 File Offset: 0x00023260
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

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x060008A5 RID: 2213 RVA: 0x00025120 File Offset: 0x00023320
		public string Path
		{
			get
			{
				return this.KnownFolderSettings.Path;
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x060008A6 RID: 2214 RVA: 0x00025140 File Offset: 0x00023340
		public FolderCategory Category
		{
			get
			{
				return this.KnownFolderSettings.Category;
			}
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x060008A7 RID: 2215 RVA: 0x00025160 File Offset: 0x00023360
		public string CanonicalName
		{
			get
			{
				return this.KnownFolderSettings.CanonicalName;
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x060008A8 RID: 2216 RVA: 0x00025180 File Offset: 0x00023380
		public string Description
		{
			get
			{
				return this.KnownFolderSettings.Description;
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x060008A9 RID: 2217 RVA: 0x000251A0 File Offset: 0x000233A0
		public Guid ParentId
		{
			get
			{
				return this.KnownFolderSettings.ParentId;
			}
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x060008AA RID: 2218 RVA: 0x000251C0 File Offset: 0x000233C0
		public string RelativePath
		{
			get
			{
				return this.KnownFolderSettings.RelativePath;
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x060008AB RID: 2219 RVA: 0x000251E0 File Offset: 0x000233E0
		public override string ParsingName
		{
			get
			{
				return base.ParsingName;
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x060008AC RID: 2220 RVA: 0x000251F8 File Offset: 0x000233F8
		public string Tooltip
		{
			get
			{
				return this.KnownFolderSettings.Tooltip;
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x060008AD RID: 2221 RVA: 0x00025218 File Offset: 0x00023418
		public string TooltipResourceId
		{
			get
			{
				return this.KnownFolderSettings.TooltipResourceId;
			}
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x060008AE RID: 2222 RVA: 0x00025238 File Offset: 0x00023438
		public string LocalizedName
		{
			get
			{
				return this.KnownFolderSettings.LocalizedName;
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x060008AF RID: 2223 RVA: 0x00025258 File Offset: 0x00023458
		public string LocalizedNameResourceId
		{
			get
			{
				return this.KnownFolderSettings.LocalizedNameResourceId;
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x00025278 File Offset: 0x00023478
		public string Security
		{
			get
			{
				return this.KnownFolderSettings.Security;
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x060008B1 RID: 2225 RVA: 0x00025298 File Offset: 0x00023498
		public FileAttributes FileAttributes
		{
			get
			{
				return this.KnownFolderSettings.FileAttributes;
			}
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x000252B8 File Offset: 0x000234B8
		public DefinitionOptions DefinitionOptions
		{
			get
			{
				return this.KnownFolderSettings.DefinitionOptions;
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x060008B3 RID: 2227 RVA: 0x000252D8 File Offset: 0x000234D8
		public Guid FolderTypeId
		{
			get
			{
				return this.KnownFolderSettings.FolderTypeId;
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x060008B4 RID: 2228 RVA: 0x000252F8 File Offset: 0x000234F8
		public string FolderType
		{
			get
			{
				return this.KnownFolderSettings.FolderType;
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x060008B5 RID: 2229 RVA: 0x00025318 File Offset: 0x00023518
		public Guid FolderId
		{
			get
			{
				return this.KnownFolderSettings.FolderId;
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x060008B6 RID: 2230 RVA: 0x00025338 File Offset: 0x00023538
		public bool PathExists
		{
			get
			{
				return this.KnownFolderSettings.PathExists;
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x060008B7 RID: 2231 RVA: 0x00025358 File Offset: 0x00023558
		public RedirectionCapability Redirection
		{
			get
			{
				return this.KnownFolderSettings.Redirection;
			}
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x00025378 File Offset: 0x00023578
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

		// Token: 0x0400042B RID: 1067
		private IKnownFolderNative knownFolderNative;

		// Token: 0x0400042C RID: 1068
		private KnownFolderSettings knownFolderSettings;
	}
}
