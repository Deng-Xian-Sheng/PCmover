using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004B9 RID: 1209
	internal class afm : abw
	{
		// Token: 0x060031BF RID: 12735 RVA: 0x001BCE70 File Offset: 0x001BBE70
		internal afm(agp A_0, int A_1, int A_2, int A_3, bool A_4) : base(A_4)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = (short)A_2;
			this.d = (short)A_3;
			this.g = 0;
			this.e = false;
		}

		// Token: 0x060031C0 RID: 12736 RVA: 0x001BCEC8 File Offset: 0x001BBEC8
		internal afm(agp A_0, int A_1, int A_2, int A_3, int A_4) : base(false)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = (short)A_2;
			this.d = (short)A_3;
			this.g = A_4;
			this.e = true;
		}

		// Token: 0x060031C1 RID: 12737 RVA: 0x001BCF20 File Offset: 0x001BBF20
		internal override ag9 hy()
		{
			return ag9.b;
		}

		// Token: 0x060031C2 RID: 12738 RVA: 0x001BCF34 File Offset: 0x001BBF34
		internal override int kd()
		{
			if (!this.e)
			{
				this.a();
			}
			int result;
			if (base.b())
			{
				result = (int)this.f;
			}
			else
			{
				result = this.g;
			}
			return result;
		}

		// Token: 0x060031C3 RID: 12739 RVA: 0x001BCF78 File Offset: 0x001BBF78
		internal override float ke()
		{
			if (!this.e)
			{
				this.a();
			}
			float result;
			if (base.b())
			{
				result = this.f;
			}
			else
			{
				result = (float)this.g;
			}
			return result;
		}

		// Token: 0x060031C4 RID: 12740 RVA: 0x001BCFBC File Offset: 0x001BBFBC
		private void a()
		{
			agx agx = this.a.a(this.b, (int)this.c);
			if (base.b())
			{
				switch (agx.u())
				{
				case 43:
					agx.o();
					break;
				case 45:
					agx.o();
					this.f = -agx.y();
					goto IL_72;
				}
				this.f = agx.y();
				IL_72:;
			}
			else
			{
				switch (agx.u())
				{
				case 43:
					agx.o();
					break;
				case 45:
					agx.o();
					this.g = -agx.z();
					goto IL_C1;
				}
				this.g = agx.z();
				IL_C1:;
			}
			this.e = true;
			this.a.a(agx);
		}

		// Token: 0x060031C5 RID: 12741 RVA: 0x001BD0A0 File Offset: 0x001BC0A0
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				agx a_ = A_0.a(this.a);
				this.h9(a_, A_0);
			}
		}

		// Token: 0x060031C6 RID: 12742 RVA: 0x001BD0D4 File Offset: 0x001BC0D4
		internal override void h9(agx A_0, DocumentWriter A_1)
		{
			if (base.p())
			{
				A_0.c(this.b, (int)this.c);
				A_0.a(A_1, (int)this.d);
			}
		}

		// Token: 0x0400173B RID: 5947
		private agp a;

		// Token: 0x0400173C RID: 5948
		private int b;

		// Token: 0x0400173D RID: 5949
		private short c;

		// Token: 0x0400173E RID: 5950
		private short d;

		// Token: 0x0400173F RID: 5951
		private bool e;

		// Token: 0x04001740 RID: 5952
		private float f = 0f;

		// Token: 0x04001741 RID: 5953
		private int g = 0;
	}
}
