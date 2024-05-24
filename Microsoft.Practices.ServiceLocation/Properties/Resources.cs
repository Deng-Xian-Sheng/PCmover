using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.Practices.ServiceLocation.Properties
{
	// Token: 0x02000007 RID: 7
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600001D RID: 29 RVA: 0x00002405 File Offset: 0x00000605
		internal Resources()
		{
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002410 File Offset: 0x00000610
		[EditorBrowsable(2)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Microsoft.Practices.ServiceLocation.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001F RID: 31 RVA: 0x0000244F File Offset: 0x0000064F
		// (set) Token: 0x06000020 RID: 32 RVA: 0x00002456 File Offset: 0x00000656
		[EditorBrowsable(2)]
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

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000021 RID: 33 RVA: 0x0000245E File Offset: 0x0000065E
		internal static string ActivateAllExceptionMessage
		{
			get
			{
				return Resources.ResourceManager.GetString("ActivateAllExceptionMessage", Resources.resourceCulture);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002474 File Offset: 0x00000674
		internal static string ActivationExceptionMessage
		{
			get
			{
				return Resources.ResourceManager.GetString("ActivationExceptionMessage", Resources.resourceCulture);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000023 RID: 35 RVA: 0x0000248A File Offset: 0x0000068A
		internal static string ServiceLocationProviderNotSetMessage
		{
			get
			{
				return Resources.ResourceManager.GetString("ServiceLocationProviderNotSetMessage", Resources.resourceCulture);
			}
		}

		// Token: 0x04000002 RID: 2
		private static ResourceManager resourceMan;

		// Token: 0x04000003 RID: 3
		private static CultureInfo resourceCulture;
	}
}
