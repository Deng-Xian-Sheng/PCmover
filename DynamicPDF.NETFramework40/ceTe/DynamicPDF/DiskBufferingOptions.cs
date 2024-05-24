using System;
using System.IO;
using System.Reflection;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006C4 RID: 1732
	public class DiskBufferingOptions
	{
		// Token: 0x060042DC RID: 17116 RVA: 0x0022CF30 File Offset: 0x0022BF30
		public DiskBufferingOptions()
		{
			if (Assembly.GetExecutingAssembly().Location == null || Assembly.GetExecutingAssembly().Location == string.Empty)
			{
				this.b = "Cache";
			}
			else
			{
				this.b = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Cache");
			}
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x060042DD RID: 17117 RVA: 0x0022CFA8 File Offset: 0x0022BFA8
		// (set) Token: 0x060042DE RID: 17118 RVA: 0x0022CFC0 File Offset: 0x0022BFC0
		public string Location
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x060042DF RID: 17119 RVA: 0x0022CFCC File Offset: 0x0022BFCC
		// (set) Token: 0x060042E0 RID: 17120 RVA: 0x0022CFE4 File Offset: 0x0022BFE4
		public bool Enabled
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		} = false;

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x060042E1 RID: 17121 RVA: 0x0022CFF0 File Offset: 0x0022BFF0
		public static DiskBufferingOptions Current
		{
			get
			{
				return DiskBufferingOptions.a;
			}
		}

		// Token: 0x060042E2 RID: 17122 RVA: 0x0022D008 File Offset: 0x0022C008
		internal agk a()
		{
			if (!Directory.Exists(this.b))
			{
				Directory.CreateDirectory(this.b);
			}
			return new agk(this.b);
		}

		// Token: 0x04002544 RID: 9540
		private static DiskBufferingOptions a = new DiskBufferingOptions();

		// Token: 0x04002545 RID: 9541
		private string b;

		// Token: 0x04002546 RID: 9542
		private bool c = true;
	}
}
