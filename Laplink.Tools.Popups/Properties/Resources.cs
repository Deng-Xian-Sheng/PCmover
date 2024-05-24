using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Laplink.Tools.Popups.Properties
{
	// Token: 0x0200000F RID: 15
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	public class Resources
	{
		// Token: 0x0600007A RID: 122 RVA: 0x00002FE6 File Offset: 0x000011E6
		internal Resources()
		{
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00002FEE File Offset: 0x000011EE
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Laplink.Tools.Popups.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600007C RID: 124 RVA: 0x0000301A File Offset: 0x0000121A
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00003021 File Offset: 0x00001221
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
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

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00003029 File Offset: 0x00001229
		public static string lblCancel
		{
			get
			{
				return Resources.ResourceManager.GetString("lblCancel", Resources.resourceCulture);
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600007F RID: 127 RVA: 0x0000303F File Offset: 0x0000123F
		public static string lblContinue
		{
			get
			{
				return Resources.ResourceManager.GetString("lblContinue", Resources.resourceCulture);
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00003055 File Offset: 0x00001255
		public static string lblNo
		{
			get
			{
				return Resources.ResourceManager.GetString("lblNo", Resources.resourceCulture);
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000081 RID: 129 RVA: 0x0000306B File Offset: 0x0000126B
		public static string lblYes
		{
			get
			{
				return Resources.ResourceManager.GetString("lblYes", Resources.resourceCulture);
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00003081 File Offset: 0x00001281
		public static string OK
		{
			get
			{
				return Resources.ResourceManager.GetString("OK", Resources.resourceCulture);
			}
		}

		// Token: 0x04000035 RID: 53
		private static ResourceManager resourceMan;

		// Token: 0x04000036 RID: 54
		private static CultureInfo resourceCulture;
	}
}
