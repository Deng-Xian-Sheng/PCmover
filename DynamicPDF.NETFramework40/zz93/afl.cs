using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004B8 RID: 1208
	internal class afl : abu
	{
		// Token: 0x060031B4 RID: 12724 RVA: 0x001BCC1C File Offset: 0x001BBC1C
		internal afl(agp A_0, int A_1, int A_2, int A_3)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = (short)A_2;
			this.d = (short)A_3;
		}

		// Token: 0x060031B5 RID: 12725 RVA: 0x001BCC50 File Offset: 0x001BBC50
		internal override int j7(aba A_0)
		{
			agx agx = A_0.lq();
			agx.a(this.b, (int)this.c, 1);
			return agx.v();
		}

		// Token: 0x060031B6 RID: 12726 RVA: 0x001BCC84 File Offset: 0x001BBC84
		internal override int j8()
		{
			if (this.e == -1)
			{
				this.ka();
			}
			return this.e;
		}

		// Token: 0x060031B7 RID: 12727 RVA: 0x001BCCB4 File Offset: 0x001BBCB4
		internal override string j9()
		{
			agx agx = this.a.a(this.b, (int)this.c, 1);
			string result = agx.g((int)(this.d - 1));
			this.a.a(agx);
			return result;
		}

		// Token: 0x060031B8 RID: 12728 RVA: 0x001BCCFC File Offset: 0x001BBCFC
		internal override void ka()
		{
			this.e = this.a();
		}

		// Token: 0x060031B9 RID: 12729 RVA: 0x001BCD0C File Offset: 0x001BBD0C
		internal int a()
		{
			agx agx = this.a.a(this.b, (int)this.c, 1);
			int result = agx.h((int)(this.d - 1));
			this.a.a(agx);
			return result;
		}

		// Token: 0x060031BA RID: 12730 RVA: 0x001BCD54 File Offset: 0x001BBD54
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				agx a_ = A_0.a(this.a);
				this.h9(a_, A_0);
			}
		}

		// Token: 0x060031BB RID: 12731 RVA: 0x001BCD88 File Offset: 0x001BBD88
		internal override void h9(agx A_0, DocumentWriter A_1)
		{
			if (base.p())
			{
				A_0.c(this.b, (int)this.c);
				A_0.b(A_1, (int)this.d);
			}
		}

		// Token: 0x060031BC RID: 12732 RVA: 0x001BCDC8 File Offset: 0x001BBDC8
		internal override int kb(int A_0)
		{
			agx agx = this.a.a(this.b, (int)this.c, 1);
			int num = agx.x();
			this.a.a(agx);
			int result;
			if (num > A_0)
			{
				result = num;
			}
			else
			{
				result = A_0;
			}
			return result;
		}

		// Token: 0x060031BD RID: 12733 RVA: 0x001BCE18 File Offset: 0x001BBE18
		internal override int kc()
		{
			return this.b();
		}

		// Token: 0x060031BE RID: 12734 RVA: 0x001BCE30 File Offset: 0x001BBE30
		internal int b()
		{
			agx agx = this.a.a(this.b, (int)this.c, 1);
			int result = agx.w();
			this.a.a(agx);
			return result;
		}

		// Token: 0x04001736 RID: 5942
		private new agp a;

		// Token: 0x04001737 RID: 5943
		private int b;

		// Token: 0x04001738 RID: 5944
		private short c;

		// Token: 0x04001739 RID: 5945
		private short d;

		// Token: 0x0400173A RID: 5946
		private int e = -1;
	}
}
