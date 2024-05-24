using System;
using System.IO;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004AF RID: 1199
	internal class afc : zq, zr
	{
		// Token: 0x0600317F RID: 12671 RVA: 0x001BB9DC File Offset: 0x001BA9DC
		internal afc(agx A_0, int A_1)
		{
			this.a = A_0;
			this.b = A_0.ac();
			this.c = A_1;
		}

		// Token: 0x06003180 RID: 12672 RVA: 0x001BBA0F File Offset: 0x001BAA0F
		void zr.a(b3 A_0, int A_1)
		{
			this.e = A_0.j();
			this.d = A_1;
		}

		// Token: 0x06003181 RID: 12673 RVA: 0x001BBA28 File Offset: 0x001BAA28
		internal override void g7(Stream A_0)
		{
			A_0.Write(aff.a, 0, aff.a.Length);
			this.e.Reset(this.d);
			this.a.a(this.b);
			this.a.a(A_0, this.c, this.e);
			A_0.Write(aff.b, 0, aff.b.Length);
		}

		// Token: 0x06003182 RID: 12674 RVA: 0x001BBA9C File Offset: 0x001BAA9C
		internal override int g8()
		{
			int result;
			if (this.e.v() == b5.b)
			{
				int num = this.c + 16 + (16 - this.c % 16);
				result = num + 17;
			}
			else
			{
				result = this.c + 17;
			}
			return result;
		}

		// Token: 0x04001712 RID: 5906
		private agx a;

		// Token: 0x04001713 RID: 5907
		private long b;

		// Token: 0x04001714 RID: 5908
		private int c;

		// Token: 0x04001715 RID: 5909
		private int d = -1;

		// Token: 0x04001716 RID: 5910
		private Encrypter e = null;
	}
}
