using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004EE RID: 1262
	internal class ag3 : abw
	{
		// Token: 0x060033A0 RID: 13216 RVA: 0x001CA5B8 File Offset: 0x001C95B8
		internal ag3(agt A_0, int A_1, short A_2, bool A_3) : base(A_3)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.f = 0;
		}

		// Token: 0x060033A1 RID: 13217 RVA: 0x001CA608 File Offset: 0x001C9608
		internal ag3(agt A_0, int A_1, short A_2, int A_3) : base(false)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.f = A_3;
		}

		// Token: 0x060033A2 RID: 13218 RVA: 0x001CA658 File Offset: 0x001C9658
		internal override ag9 hy()
		{
			return ag9.b;
		}

		// Token: 0x060033A3 RID: 13219 RVA: 0x001CA66C File Offset: 0x001C966C
		internal override int kd()
		{
			if (!this.d)
			{
				this.a();
			}
			int result;
			if (base.b())
			{
				result = (int)this.e;
			}
			else
			{
				result = this.f;
			}
			return result;
		}

		// Token: 0x060033A4 RID: 13220 RVA: 0x001CA6B0 File Offset: 0x001C96B0
		internal override float ke()
		{
			if (!this.d)
			{
				this.a();
			}
			float result;
			if (base.b())
			{
				result = this.e;
			}
			else
			{
				result = (float)this.f;
			}
			return result;
		}

		// Token: 0x060033A5 RID: 13221 RVA: 0x001CA6F4 File Offset: 0x001C96F4
		private void a()
		{
			if (base.b())
			{
				switch (this.a.a()[this.b])
				{
				case 43:
					this.e = this.a.d(this.b + 1);
					goto IL_89;
				case 45:
					this.e = -this.a.d(this.b + 1);
					goto IL_89;
				}
				this.e = this.a.d(this.b);
				IL_89:;
			}
			else
			{
				switch (this.a.a()[this.b])
				{
				case 43:
					this.f = this.a.e(this.b + 1);
					goto IL_107;
				case 45:
					this.f = -this.a.e(this.b + 1);
					goto IL_107;
				}
				this.f = this.a.e(this.b);
				IL_107:;
			}
			this.d = true;
		}

		// Token: 0x060033A6 RID: 13222 RVA: 0x001CA810 File Offset: 0x001C9810
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				A_0.WriteNumber(this.a.a(), this.b, (int)this.c);
			}
		}

		// Token: 0x0400189B RID: 6299
		private agt a;

		// Token: 0x0400189C RID: 6300
		private int b;

		// Token: 0x0400189D RID: 6301
		private short c;

		// Token: 0x0400189E RID: 6302
		private bool d = false;

		// Token: 0x0400189F RID: 6303
		private float e = 0f;

		// Token: 0x040018A0 RID: 6304
		private int f = 0;
	}
}
