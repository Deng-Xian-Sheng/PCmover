using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.WindowsAPICodePack.ShellExtensions.Resources
{
	// Token: 0x02000017 RID: 23
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[CompilerGenerated]
	[DebuggerNonUserCode]
	internal class LocalizedMessages
	{
		// Token: 0x06000088 RID: 136 RVA: 0x0000335C File Offset: 0x0000155C
		internal LocalizedMessages()
		{
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00003368 File Offset: 0x00001568
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(LocalizedMessages.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Microsoft.WindowsAPICodePack.ShellExtensions.Resources.LocalizedMessages", typeof(LocalizedMessages).Assembly);
					LocalizedMessages.resourceMan = resourceManager;
				}
				return LocalizedMessages.resourceMan;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600008A RID: 138 RVA: 0x000033B4 File Offset: 0x000015B4
		// (set) Token: 0x0600008B RID: 139 RVA: 0x000033CB File Offset: 0x000015CB
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return LocalizedMessages.resourceCulture;
			}
			set
			{
				LocalizedMessages.resourceCulture = value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600008C RID: 140 RVA: 0x000033D4 File Offset: 0x000015D4
		internal static string PreviewHandlerControlNotInitialized
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PreviewHandlerControlNotInitialized", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000033FC File Offset: 0x000015FC
		internal static string PreviewHandlerInterfaceNotImplemented
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PreviewHandlerInterfaceNotImplemented", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00003424 File Offset: 0x00001624
		internal static string PreviewHandlerInvalidAttributes
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PreviewHandlerInvalidAttributes", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600008F RID: 143 RVA: 0x0000344C File Offset: 0x0000164C
		internal static string PreviewHandlerUnsupportedInterfaceCalled
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PreviewHandlerUnsupportedInterfaceCalled", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00003474 File Offset: 0x00001674
		internal static string StorageStreamBufferOverflow
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("StorageStreamBufferOverflow", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000091 RID: 145 RVA: 0x0000349C File Offset: 0x0000169C
		internal static string StorageStreamCountLessThanZero
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("StorageStreamCountLessThanZero", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000092 RID: 146 RVA: 0x000034C4 File Offset: 0x000016C4
		internal static string StorageStreamIsReadonly
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("StorageStreamIsReadonly", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000093 RID: 147 RVA: 0x000034EC File Offset: 0x000016EC
		internal static string StorageStreamOffsetLessThanZero
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("StorageStreamOffsetLessThanZero", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00003514 File Offset: 0x00001714
		internal static string ThumbnailProviderDisabledProcessIsolation
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ThumbnailProviderDisabledProcessIsolation", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000095 RID: 149 RVA: 0x0000353C File Offset: 0x0000173C
		internal static string ThumbnailProviderInterfaceNotImplemented
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ThumbnailProviderInterfaceNotImplemented", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00003564 File Offset: 0x00001764
		internal static string WpfPreviewHandlerNoHandle
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("WpfPreviewHandlerNoHandle", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x04000038 RID: 56
		private static ResourceManager resourceMan;

		// Token: 0x04000039 RID: 57
		private static CultureInfo resourceCulture;
	}
}
