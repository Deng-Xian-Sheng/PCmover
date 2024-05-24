using System;
using System.Collections;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x0200006B RID: 107
	internal class cc
	{
		// Token: 0x06000475 RID: 1141 RVA: 0x0004A67C File Offset: 0x0004967C
		internal cc(aba A_0, abj A_1)
		{
			this.a = A_0;
			for (abk abk = A_1.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 3053875)
				{
					this.b = (abe)abk.c().h6();
					break;
				}
				if (abk.a().j8() == 243718515)
				{
					this.c = (abe)abk.c().h6();
					break;
				}
			}
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0004A71C File Offset: 0x0004971C
		internal Hashtable a(PdfDocument A_0)
		{
			Hashtable hashtable = new Hashtable();
			if (this.b != null)
			{
				for (int i = 0; i < this.b.a(); i++)
				{
					if (this.b.a(i) is ab6)
					{
						abj abj = (abj)this.b.a(i).h6();
						abk abk = abj.l();
						abe abe = null;
						abe abe2 = null;
						while (abk != null)
						{
							int num = abk.a().j8();
							if (num != 3053875)
							{
								if (num == 243718515)
								{
									abe = (abe)abk.c().h6();
								}
							}
							else
							{
								abe2 = (abe)abk.c().h6();
							}
							abk = abk.d();
						}
						if (abe2 != null)
						{
							for (int j = 0; j < abe2.a(); j++)
							{
								abj a_ = (abj)abe2.a(j).h6();
								this.a(a_, ref hashtable, A_0);
							}
						}
						else
						{
							int num2 = 0;
							if (abe != null)
							{
								for (int k = 1; k < abe.a(); k += 2)
								{
									ab7 ab = (ab7)abe.a(k - 1);
									string text = ab.kf();
									abd abd = abe.a(k).h6();
									if (abd.hy() == ag9.e)
									{
										abe abe3 = (abe)abe.a(k).h6();
										ab6 a_2 = (ab6)abe3.a(0);
										PdfPage pdfPage = A_0.m().b(a_2).h();
										num2 = pdfPage.e() + 1;
									}
									else if (abd.hy() == ag9.g)
									{
										cb cb = new cb((abj)abe.a(k).h6());
										num2 = cb.a(A_0);
									}
									if (text != null)
									{
										hashtable.Add(text, num2);
									}
								}
							}
						}
					}
				}
			}
			else if (this.c != null)
			{
				for (int i = 0; i < this.c.a(); i++)
				{
					int num2 = 0;
					if (this.c.a(i) is ab6)
					{
						abd abd = this.c.a(i).h6();
						if (abd.hy() == ag9.e)
						{
							abe abe3 = (abe)this.c.a(i).h6();
							ab6 a_2 = (ab6)abe3.a(0);
							PdfPage pdfPage = A_0.m().b(a_2).h();
							num2 = pdfPage.e() + 1;
						}
						else if (abd.hy() == ag9.g)
						{
							cb cb = new cb((abj)this.c.a(i).h6());
							num2 = cb.a(A_0);
						}
						ab7 ab = (ab7)this.c.a(i - 1);
						string text = ab.kf();
						if (text != null)
						{
							hashtable.Add(text, num2);
						}
					}
				}
			}
			return hashtable;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0004AACC File Offset: 0x00049ACC
		private void a(abj A_0, ref Hashtable A_1, PdfDocument A_2)
		{
			abe abe = null;
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 243718515)
				{
					abe = (abe)abk.c().h6();
					break;
				}
			}
			int num = 0;
			if (abe != null)
			{
				for (int i = 1; i < abe.a(); i += 2)
				{
					ab7 ab = (ab7)abe.a(i - 1);
					string text = ab.kf();
					abd abd = abe.a(i).h6();
					if (abd.hy() == ag9.e)
					{
						abe abe2 = (abe)abe.a(i).h6();
						ab6 a_ = (ab6)abe2.a(0);
						PdfPage pdfPage = A_2.m().b(a_).h();
						num = pdfPage.e() + 1;
					}
					else if (abd.hy() == ag9.g)
					{
						cb cb = new cb((abj)abe.a(i).h6());
						num = cb.a(A_2);
					}
					if (text != null)
					{
						A_1.Add(text, num);
					}
				}
			}
		}

		// Token: 0x0400029B RID: 667
		private aba a;

		// Token: 0x0400029C RID: 668
		private abe b;

		// Token: 0x0400029D RID: 669
		private abe c;
	}
}
