using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000438 RID: 1080
	internal class ab6 : abd
	{
		// Token: 0x06002CB7 RID: 11447 RVA: 0x00198197 File Offset: 0x00197197
		public ab6(PdfDocument A_0, int A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06002CB8 RID: 11448 RVA: 0x001981C0 File Offset: 0x001971C0
		internal override ag9 hy()
		{
			return ag9.j;
		}

		// Token: 0x06002CB9 RID: 11449 RVA: 0x001981D8 File Offset: 0x001971D8
		internal override abd h6()
		{
			if (this.c == null)
			{
				this.c = this.a.m().b((long)this.b);
				if (this.c == null)
				{
					return null;
				}
			}
			return this.c.i();
		}

		// Token: 0x06002CBA RID: 11450 RVA: 0x00198238 File Offset: 0x00197238
		internal abg a()
		{
			return this.a.m().b((long)this.b);
		}

		// Token: 0x06002CBB RID: 11451 RVA: 0x00198264 File Offset: 0x00197264
		internal PdfDocument b()
		{
			return this.a;
		}

		// Token: 0x06002CBC RID: 11452 RVA: 0x0019827C File Offset: 0x0019727C
		internal int c()
		{
			return this.b;
		}

		// Token: 0x06002CBD RID: 11453 RVA: 0x00198294 File Offset: 0x00197294
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				abg abg = this.a.m().b((long)this.b);
				if (abg == null)
				{
					A_0.WriteNull();
				}
				else
				{
					abg.a(A_0);
				}
			}
		}

		// Token: 0x06002CBE RID: 11454 RVA: 0x001982E8 File Offset: 0x001972E8
		internal void a(DocumentWriter A_0)
		{
			abg abg = this.a.m().b((long)this.b);
			if (abg == null)
			{
				A_0.WriteNull();
			}
			else
			{
				abg.b(A_0);
			}
		}

		// Token: 0x04001506 RID: 5382
		private PdfDocument a;

		// Token: 0x04001507 RID: 5383
		private int b = 0;

		// Token: 0x04001508 RID: 5384
		private abg c = null;
	}
}
