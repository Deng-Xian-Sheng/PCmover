using System;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000831 RID: 2097
	public class ContentGroup : ReportElement
	{
		// Token: 0x06005482 RID: 21634 RVA: 0x002954C8 File Offset: 0x002944C8
		internal ContentGroup(rm A_0, vs A_1)
		{
			this.c = A_1.e();
			this.d = A_1.f();
			this.b = A_1.d();
			this.a = A_1.a();
			this.e = A_1.b();
			this.f = new ReportElementList(A_0, A_1.c());
			this.a();
			A_0.b().DocumentLayout.a(A_1.f0(), this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.f0());
			}
		}

		// Token: 0x06005483 RID: 21635 RVA: 0x0029556F File Offset: 0x0029456F
		internal override void fi(xf A_0, LayoutWriter A_1)
		{
			throw new ReportWriterException("A content group can only be placed in the detail of a report.");
		}

		// Token: 0x06005484 RID: 21636 RVA: 0x0029557C File Offset: 0x0029457C
		internal override void gi(xh A_0, LayoutWriter A_1)
		{
			if (this.f != null)
			{
				xk xk = new xk(this.c, this.d, this.a, this.e, this.g, this.h, this.f);
				for (int i = 0; i < this.f.Count; i++)
				{
					this.f[i].gi(xk.a(), A_1);
				}
				xk.a(this.g);
				A_0.a(xk);
				A_0.a().a(xk);
			}
		}

		// Token: 0x06005485 RID: 21637 RVA: 0x00295624 File Offset: 0x00294624
		private void a()
		{
			short num = 0;
			for (int i = 0; i < this.f.Count; i++)
			{
				if (this.f[i].gp())
				{
					for (int j = 0; j < this.f.Count; j++)
					{
						if (this.f[j].gj() && x5.d(this.f[i].gm(), this.f[j].gn()) && x5.a(this.f[i].gn(), this.f[j].gn()) && i != j)
						{
							if (this.f[j].gk() == -32768)
							{
								ReportElement reportElement = this.f[j];
								short num2 = num;
								num = num2 + 1;
								reportElement.gl(num2);
							}
							this.h = true;
							this.f[i].gq(this.f[j].gk());
						}
					}
				}
			}
		}

		// Token: 0x06005486 RID: 21638 RVA: 0x0029576C File Offset: 0x0029476C
		internal override bool gj()
		{
			return true;
		}

		// Token: 0x06005487 RID: 21639 RVA: 0x00295780 File Offset: 0x00294780
		internal override short gk()
		{
			return this.g;
		}

		// Token: 0x06005488 RID: 21640 RVA: 0x00295798 File Offset: 0x00294798
		internal override void gl(short A_0)
		{
			this.g = A_0;
		}

		// Token: 0x06005489 RID: 21641 RVA: 0x002957A4 File Offset: 0x002947A4
		internal override x5 gm()
		{
			return this.d;
		}

		// Token: 0x0600548A RID: 21642 RVA: 0x002957BC File Offset: 0x002947BC
		internal override x5 gn()
		{
			return x5.f(this.d, this.a);
		}

		// Token: 0x170007C9 RID: 1993
		// (get) Token: 0x0600548B RID: 21643 RVA: 0x002957E0 File Offset: 0x002947E0
		// (set) Token: 0x0600548C RID: 21644 RVA: 0x002957FE File Offset: 0x002947FE
		public float Height
		{
			get
			{
				return x5.b(this.a);
			}
			set
			{
				this.a = x5.a(value);
			}
		}

		// Token: 0x170007CA RID: 1994
		// (get) Token: 0x0600548D RID: 21645 RVA: 0x00295810 File Offset: 0x00294810
		public ReportElementList Elements
		{
			get
			{
				return this.f;
			}
		}

		// Token: 0x170007CB RID: 1995
		// (get) Token: 0x0600548E RID: 21646 RVA: 0x00295828 File Offset: 0x00294828
		// (set) Token: 0x0600548F RID: 21647 RVA: 0x00295846 File Offset: 0x00294846
		public float Width
		{
			get
			{
				return x5.b(this.b);
			}
			set
			{
				this.b = x5.a(value);
			}
		}

		// Token: 0x170007CC RID: 1996
		// (get) Token: 0x06005490 RID: 21648 RVA: 0x00295858 File Offset: 0x00294858
		// (set) Token: 0x06005491 RID: 21649 RVA: 0x00295876 File Offset: 0x00294876
		public float X
		{
			get
			{
				return x5.b(this.c);
			}
			set
			{
				this.c = x5.a(value);
			}
		}

		// Token: 0x170007CD RID: 1997
		// (get) Token: 0x06005492 RID: 21650 RVA: 0x00295888 File Offset: 0x00294888
		// (set) Token: 0x06005493 RID: 21651 RVA: 0x002958A6 File Offset: 0x002948A6
		public float Y
		{
			get
			{
				return x5.b(this.d);
			}
			set
			{
				this.d = x5.a(value);
			}
		}

		// Token: 0x04002D42 RID: 11586
		private x5 a;

		// Token: 0x04002D43 RID: 11587
		private x5 b;

		// Token: 0x04002D44 RID: 11588
		private x5 c;

		// Token: 0x04002D45 RID: 11589
		private x5 d;

		// Token: 0x04002D46 RID: 11590
		private bool e;

		// Token: 0x04002D47 RID: 11591
		private ReportElementList f;

		// Token: 0x04002D48 RID: 11592
		private short g = short.MinValue;

		// Token: 0x04002D49 RID: 11593
		private bool h;
	}
}
