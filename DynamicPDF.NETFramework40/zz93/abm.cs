using System;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000424 RID: 1060
	internal class abm : abi
	{
		// Token: 0x06002C2E RID: 11310 RVA: 0x00196020 File Offset: 0x00195020
		internal abm(PdfDocument A_0, long A_1, int A_2) : base(A_0)
		{
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06002C2F RID: 11311 RVA: 0x00196044 File Offset: 0x00195044
		internal override int h1(byte[] A_0, int A_1, int A_2)
		{
			if (this.a == null)
			{
				this.a();
			}
			int result;
			if (base.b().g() is aar || base.b().g() is ach)
			{
				abm.d.a(A_0, A_1, A_2, this.a);
				result = A_2;
			}
			else
			{
				result = base.b().g().av(ref A_0, A_1, A_2, this.a);
			}
			return result;
		}

		// Token: 0x06002C30 RID: 11312 RVA: 0x001960D7 File Offset: 0x001950D7
		private void a()
		{
			this.a = base.b().g().ar(this.b, this.c);
		}

		// Token: 0x06002C31 RID: 11313 RVA: 0x001960FC File Offset: 0x001950FC
		internal override bool h2()
		{
			return true;
		}

		// Token: 0x040014CE RID: 5326
		private byte[] a = null;

		// Token: 0x040014CF RID: 5327
		private long b;

		// Token: 0x040014D0 RID: 5328
		private int c;

		// Token: 0x040014D1 RID: 5329
		private static aau d = new aau();
	}
}
