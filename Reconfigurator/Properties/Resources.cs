using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Reconfigurator.Properties
{
	// Token: 0x02000004 RID: 4
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	public class Resources
	{
		// Token: 0x0600000A RID: 10 RVA: 0x00002137 File Offset: 0x00000337
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000213F File Offset: 0x0000033F
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Reconfigurator.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000C RID: 12 RVA: 0x0000216B File Offset: 0x0000036B
		// (set) Token: 0x0600000D RID: 13 RVA: 0x00002172 File Offset: 0x00000372
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

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000E RID: 14 RVA: 0x0000217A File Offset: 0x0000037A
		public static string Cancel
		{
			get
			{
				return Resources.ResourceManager.GetString("Cancel", Resources.resourceCulture);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002190 File Offset: 0x00000390
		public static string Continue
		{
			get
			{
				return Resources.ResourceManager.GetString("Continue", Resources.resourceCulture);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000021A6 File Offset: 0x000003A6
		public static string Replace
		{
			get
			{
				return Resources.ResourceManager.GetString("Replace", Resources.resourceCulture);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000021BC File Offset: 0x000003BC
		public static string ReplaceOrSkipFiles
		{
			get
			{
				return Resources.ResourceManager.GetString("ReplaceOrSkipFiles", Resources.resourceCulture);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000012 RID: 18 RVA: 0x000021D2 File Offset: 0x000003D2
		public static string Skip
		{
			get
			{
				return Resources.ResourceManager.GetString("Skip", Resources.resourceCulture);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000021E8 File Offset: 0x000003E8
		public static string Title
		{
			get
			{
				return Resources.ResourceManager.GetString("Title", Resources.resourceCulture);
			}
		}

		// Token: 0x04000003 RID: 3
		private static ResourceManager resourceMan;

		// Token: 0x04000004 RID: 4
		private static CultureInfo resourceCulture;
	}
}
