using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ClientEngineModule.Mock.Properties
{
	// Token: 0x02000004 RID: 4
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x060000CB RID: 203 RVA: 0x000042A3 File Offset: 0x000024A3
		internal Resources()
		{
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000CC RID: 204 RVA: 0x000042AB File Offset: 0x000024AB
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("ClientEngineModule.Mock.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000CD RID: 205 RVA: 0x000042D7 File Offset: 0x000024D7
		// (set) Token: 0x060000CE RID: 206 RVA: 0x000042DE File Offset: 0x000024DE
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

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000CF RID: 207 RVA: 0x000042E6 File Offset: 0x000024E6
		internal static string MOCK_drive
		{
			get
			{
				return Resources.ResourceManager.GetString("MOCK_drive", Resources.resourceCulture);
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x000042FC File Offset: 0x000024FC
		internal static string SIM_NewMachine
		{
			get
			{
				return Resources.ResourceManager.GetString("SIM_NewMachine", Resources.resourceCulture);
			}
		}

		// Token: 0x04000034 RID: 52
		private static ResourceManager resourceMan;

		// Token: 0x04000035 RID: 53
		private static CultureInfo resourceCulture;
	}
}
