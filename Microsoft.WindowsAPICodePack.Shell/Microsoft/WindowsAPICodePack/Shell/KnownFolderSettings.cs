using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000066 RID: 102
	internal class KnownFolderSettings
	{
		// Token: 0x06000379 RID: 889 RVA: 0x0000DB2A File Offset: 0x0000BD2A
		internal KnownFolderSettings(IKnownFolderNative knownFolderNative)
		{
			this.GetFolderProperties(knownFolderNative);
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000DB40 File Offset: 0x0000BD40
		private void GetFolderProperties(IKnownFolderNative knownFolderNative)
		{
			Debug.Assert(knownFolderNative != null);
			KnownFoldersSafeNativeMethods.NativeFolderDefinition nativeFolderDefinition;
			knownFolderNative.GetFolderDefinition(out nativeFolderDefinition);
			try
			{
				this.knownFolderProperties.category = nativeFolderDefinition.category;
				this.knownFolderProperties.canonicalName = Marshal.PtrToStringUni(nativeFolderDefinition.name);
				this.knownFolderProperties.description = Marshal.PtrToStringUni(nativeFolderDefinition.description);
				this.knownFolderProperties.parentId = nativeFolderDefinition.parentId;
				this.knownFolderProperties.relativePath = Marshal.PtrToStringUni(nativeFolderDefinition.relativePath);
				this.knownFolderProperties.parsingName = Marshal.PtrToStringUni(nativeFolderDefinition.parsingName);
				this.knownFolderProperties.tooltipResourceId = Marshal.PtrToStringUni(nativeFolderDefinition.tooltip);
				this.knownFolderProperties.localizedNameResourceId = Marshal.PtrToStringUni(nativeFolderDefinition.localizedName);
				this.knownFolderProperties.iconResourceId = Marshal.PtrToStringUni(nativeFolderDefinition.icon);
				this.knownFolderProperties.security = Marshal.PtrToStringUni(nativeFolderDefinition.security);
				this.knownFolderProperties.fileAttributes = (FileAttributes)nativeFolderDefinition.attributes;
				this.knownFolderProperties.definitionOptions = nativeFolderDefinition.definitionOptions;
				this.knownFolderProperties.folderTypeId = nativeFolderDefinition.folderTypeId;
				this.knownFolderProperties.folderType = FolderTypes.GetFolderType(this.knownFolderProperties.folderTypeId);
				bool pathExists;
				this.knownFolderProperties.path = this.GetPath(out pathExists, knownFolderNative);
				this.knownFolderProperties.pathExists = pathExists;
				this.knownFolderProperties.redirection = knownFolderNative.GetRedirectionCapabilities();
				this.knownFolderProperties.tooltip = CoreHelpers.GetStringResource(this.knownFolderProperties.tooltipResourceId);
				this.knownFolderProperties.localizedName = CoreHelpers.GetStringResource(this.knownFolderProperties.localizedNameResourceId);
				this.knownFolderProperties.folderId = knownFolderNative.GetId();
			}
			finally
			{
				Marshal.FreeCoTaskMem(nativeFolderDefinition.name);
				Marshal.FreeCoTaskMem(nativeFolderDefinition.description);
				Marshal.FreeCoTaskMem(nativeFolderDefinition.relativePath);
				Marshal.FreeCoTaskMem(nativeFolderDefinition.parsingName);
				Marshal.FreeCoTaskMem(nativeFolderDefinition.tooltip);
				Marshal.FreeCoTaskMem(nativeFolderDefinition.localizedName);
				Marshal.FreeCoTaskMem(nativeFolderDefinition.icon);
				Marshal.FreeCoTaskMem(nativeFolderDefinition.security);
			}
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0000DD98 File Offset: 0x0000BF98
		private string GetPath(out bool fileExists, IKnownFolderNative knownFolderNative)
		{
			Debug.Assert(knownFolderNative != null);
			string text = string.Empty;
			fileExists = true;
			string result;
			if (this.knownFolderProperties.category == FolderCategory.Virtual)
			{
				fileExists = false;
				result = text;
			}
			else
			{
				try
				{
					text = knownFolderNative.GetPath(0);
				}
				catch (FileNotFoundException)
				{
					fileExists = false;
				}
				catch (DirectoryNotFoundException)
				{
					fileExists = false;
				}
				result = text;
			}
			return result;
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600037C RID: 892 RVA: 0x0000DE18 File Offset: 0x0000C018
		public string Path
		{
			get
			{
				return this.knownFolderProperties.path;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600037D RID: 893 RVA: 0x0000DE38 File Offset: 0x0000C038
		public FolderCategory Category
		{
			get
			{
				return this.knownFolderProperties.category;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600037E RID: 894 RVA: 0x0000DE58 File Offset: 0x0000C058
		public string CanonicalName
		{
			get
			{
				return this.knownFolderProperties.canonicalName;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600037F RID: 895 RVA: 0x0000DE78 File Offset: 0x0000C078
		public string Description
		{
			get
			{
				return this.knownFolderProperties.description;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000380 RID: 896 RVA: 0x0000DE98 File Offset: 0x0000C098
		public Guid ParentId
		{
			get
			{
				return this.knownFolderProperties.parentId;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000381 RID: 897 RVA: 0x0000DEB8 File Offset: 0x0000C0B8
		public string RelativePath
		{
			get
			{
				return this.knownFolderProperties.relativePath;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000382 RID: 898 RVA: 0x0000DED8 File Offset: 0x0000C0D8
		public string Tooltip
		{
			get
			{
				return this.knownFolderProperties.tooltip;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000383 RID: 899 RVA: 0x0000DEF8 File Offset: 0x0000C0F8
		public string TooltipResourceId
		{
			get
			{
				return this.knownFolderProperties.tooltipResourceId;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000384 RID: 900 RVA: 0x0000DF18 File Offset: 0x0000C118
		public string LocalizedName
		{
			get
			{
				return this.knownFolderProperties.localizedName;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000385 RID: 901 RVA: 0x0000DF38 File Offset: 0x0000C138
		public string LocalizedNameResourceId
		{
			get
			{
				return this.knownFolderProperties.localizedNameResourceId;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000386 RID: 902 RVA: 0x0000DF58 File Offset: 0x0000C158
		public string Security
		{
			get
			{
				return this.knownFolderProperties.security;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000387 RID: 903 RVA: 0x0000DF78 File Offset: 0x0000C178
		public FileAttributes FileAttributes
		{
			get
			{
				return this.knownFolderProperties.fileAttributes;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000388 RID: 904 RVA: 0x0000DF98 File Offset: 0x0000C198
		public DefinitionOptions DefinitionOptions
		{
			get
			{
				return this.knownFolderProperties.definitionOptions;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000389 RID: 905 RVA: 0x0000DFB8 File Offset: 0x0000C1B8
		public Guid FolderTypeId
		{
			get
			{
				return this.knownFolderProperties.folderTypeId;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600038A RID: 906 RVA: 0x0000DFD8 File Offset: 0x0000C1D8
		public string FolderType
		{
			get
			{
				return this.knownFolderProperties.folderType;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600038B RID: 907 RVA: 0x0000DFF8 File Offset: 0x0000C1F8
		public Guid FolderId
		{
			get
			{
				return this.knownFolderProperties.folderId;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600038C RID: 908 RVA: 0x0000E018 File Offset: 0x0000C218
		public bool PathExists
		{
			get
			{
				return this.knownFolderProperties.pathExists;
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600038D RID: 909 RVA: 0x0000E038 File Offset: 0x0000C238
		public RedirectionCapability Redirection
		{
			get
			{
				return this.knownFolderProperties.redirection;
			}
		}

		// Token: 0x0400023A RID: 570
		private FolderProperties knownFolderProperties;
	}
}
