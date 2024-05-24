using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.Practices.Unity.Properties
{
	// Token: 0x02000005 RID: 5
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600001B RID: 27 RVA: 0x00002730 File Offset: 0x00000930
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Resources()
		{
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00002738 File Offset: 0x00000938
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Microsoft.Practices.Unity.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00002777 File Offset: 0x00000977
		// (set) Token: 0x0600001E RID: 30 RVA: 0x0000277E File Offset: 0x0000097E
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00002786 File Offset: 0x00000986
		internal static string DuplicateTypeMappingException
		{
			get
			{
				return Resources.ResourceManager.GetString("DuplicateTypeMappingException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000020 RID: 32 RVA: 0x0000279C File Offset: 0x0000099C
		internal static string ExceptionNullAssembly
		{
			get
			{
				return Resources.ResourceManager.GetString("ExceptionNullAssembly", Resources.resourceCulture);
			}
		}

		// Token: 0x0400000B RID: 11
		private static ResourceManager resourceMan;

		// Token: 0x0400000C RID: 12
		private static CultureInfo resourceCulture;
	}
}
