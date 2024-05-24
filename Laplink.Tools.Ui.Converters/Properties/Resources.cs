using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Laplink.Tools.Ui.Converters.Properties
{
	// Token: 0x02000012 RID: 18
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000042 RID: 66 RVA: 0x0000264A File Offset: 0x0000084A
		internal Resources()
		{
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002652 File Offset: 0x00000852
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Laplink.Tools.Ui.Converters.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000044 RID: 68 RVA: 0x0000267E File Offset: 0x0000087E
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00002685 File Offset: 0x00000885
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

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000046 RID: 70 RVA: 0x0000268D File Offset: 0x0000088D
		internal static string NO
		{
			get
			{
				return Resources.ResourceManager.GetString("NO", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000026A3 File Offset: 0x000008A3
		internal static string YES
		{
			get
			{
				return Resources.ResourceManager.GetString("YES", Resources.resourceCulture);
			}
		}

		// Token: 0x04000009 RID: 9
		private static ResourceManager resourceMan;

		// Token: 0x0400000A RID: 10
		private static CultureInfo resourceCulture;
	}
}
