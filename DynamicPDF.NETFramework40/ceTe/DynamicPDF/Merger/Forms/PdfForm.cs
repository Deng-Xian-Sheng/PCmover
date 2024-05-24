using System;
using System.Collections;
using ceTe.DynamicPDF.Forms;
using zz93;

namespace ceTe.DynamicPDF.Merger.Forms
{
	// Token: 0x02000701 RID: 1793
	public class PdfForm
	{
		// Token: 0x06004626 RID: 17958 RVA: 0x0023DCAC File Offset: 0x0023CCAC
		internal PdfForm(abj A_0)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 274)
				{
					if (num <= 207)
					{
						if (num != 17)
						{
							if (num == 207)
							{
								this.e = (abe)abk.c().h6();
							}
						}
						else
						{
							this.c = (abw)abk.c();
						}
					}
					else if (num != 257)
					{
						if (num == 274)
						{
							if (abk.c().hy() == ag9.g)
							{
								this.a = new abn(abk.c());
							}
							else if (abk.c().hy() == ag9.j)
							{
								ab6 ab = (ab6)abk.c();
								this.a = ab.b().m().b(ab).d();
							}
						}
					}
					else
					{
						this.b = (ab7)abk.c().h6();
					}
				}
				else if (num <= 111565591)
				{
					if (num != 98689)
					{
						if (num == 111565591)
						{
							this.d = new PdfFormFieldList(this, null, (abe)abk.c().h6());
						}
					}
					else
					{
						this.h = abk.c();
					}
				}
				else if (num != 329541727)
				{
					if (num == 535705600)
					{
						this.f = ((abf)abk.c()).a();
					}
				}
				else
				{
					this.g = (SignatureFlags)((abw)abk.c()).kd();
				}
			}
		}

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x06004627 RID: 17959 RVA: 0x0023DED4 File Offset: 0x0023CED4
		public PdfFormFieldList Fields
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x06004628 RID: 17960 RVA: 0x0023DEEC File Offset: 0x0023CEEC
		internal abe b()
		{
			return this.e;
		}

		// Token: 0x06004629 RID: 17961 RVA: 0x0023DF04 File Offset: 0x0023CF04
		internal bool c()
		{
			return this.k;
		}

		// Token: 0x0600462A RID: 17962 RVA: 0x0023DF1C File Offset: 0x0023CF1C
		internal void a(bool A_0)
		{
			this.k = A_0;
		}

		// Token: 0x0600462B RID: 17963 RVA: 0x0023DF28 File Offset: 0x0023CF28
		internal Resource d()
		{
			return this.a;
		}

		// Token: 0x0600462C RID: 17964 RVA: 0x0023DF40 File Offset: 0x0023CF40
		internal ab7 e()
		{
			return this.b;
		}

		// Token: 0x0600462D RID: 17965 RVA: 0x0023DF58 File Offset: 0x0023CF58
		internal abw f()
		{
			return this.c;
		}

		// Token: 0x0600462E RID: 17966 RVA: 0x0023DF70 File Offset: 0x0023CF70
		private FormField a(int A_0, FormFieldList A_1)
		{
			int i = 0;
			while (i < A_1.Count)
			{
				FormField formField = A_1[i];
				if (formField.hb() == null || formField.hb().l() != A_0)
				{
					if (formField.hb() == null && formField.HasChildFields)
					{
						FormFieldList childFields = A_1[i].ChildFields;
						formField = this.a(A_0, childFields);
						if (formField != null)
						{
							return formField;
						}
					}
					i++;
					continue;
				}
				return A_1[i];
			}
			return null;
		}

		// Token: 0x0600462F RID: 17967 RVA: 0x0023E018 File Offset: 0x0023D018
		internal void a(Document A_0, acg A_1, bool A_2)
		{
			if (this.f)
			{
				A_0.d().NeedsAppearances = true;
			}
			A_0.d().SignatureFlags |= this.g;
			if (A_1 != null && this.e != null)
			{
				for (int i = 0; i < this.e.a(); i++)
				{
					FormField formField = A_1.a(((ab6)this.e.a(i)).c());
					if (formField == null)
					{
						formField = this.a(((ab6)this.e.a(i)).c(), A_0.Form.Fields);
					}
					if (formField != null)
					{
						A_0.Form.CalculationOrder.Add(formField);
					}
				}
			}
			if (A_2)
			{
				A_0.Form.a(this.h);
			}
		}

		// Token: 0x06004630 RID: 17968 RVA: 0x0023E118 File Offset: 0x0023D118
		private void a()
		{
			if (!this.j)
			{
				if (this.a != null && this.a is abn)
				{
					abd abd = ((abn)this.a).a();
					if (abd.hy() == ag9.g)
					{
						for (abk abk = ((abj)abd).l(); abk != null; abk = abk.d())
						{
							if (abk.a().j8() == 1768372)
							{
								abd abd2 = abk.c();
								abd abd3;
								if (abd2.hy() == ag9.j)
								{
									abd3 = abd2.h6();
								}
								else
								{
									abd3 = abd2;
								}
								if (abd3 != null && abd3.hy() == ag9.g)
								{
									for (abk abk2 = ((abj)abd3).l(); abk2 != null; abk2 = abk2.d())
									{
										if (abk2.c().hy() == ag9.j)
										{
											c2 c = new c2(abk2.c());
											string key = string.Empty;
											if (abk2.a().j9().IndexOf('+') <= 0)
											{
												key = abk2.a().j9();
											}
											else if (c.i() != null)
											{
												key = c.i().Name;
											}
											if (!this.i.ContainsKey(key))
											{
												this.i.Add(key, c);
											}
										}
									}
									break;
								}
							}
						}
					}
				}
				this.j = true;
			}
		}

		// Token: 0x06004631 RID: 17969 RVA: 0x0023E2F8 File Offset: 0x0023D2F8
		internal Font a(string A_0)
		{
			if (!this.j)
			{
				this.a();
			}
			Font result;
			if (this.i != null && this.i.ContainsKey(A_0))
			{
				result = (Font)this.i[A_0];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06004632 RID: 17970 RVA: 0x0023E350 File Offset: 0x0023D350
		internal void a(string A_0, Font A_1)
		{
			if (!this.i.ContainsKey(A_0))
			{
				this.i.Add(A_0, A_1);
			}
		}

		// Token: 0x040026D2 RID: 9938
		private Resource a = null;

		// Token: 0x040026D3 RID: 9939
		private ab7 b = null;

		// Token: 0x040026D4 RID: 9940
		private abw c = null;

		// Token: 0x040026D5 RID: 9941
		private PdfFormFieldList d = null;

		// Token: 0x040026D6 RID: 9942
		private abe e = null;

		// Token: 0x040026D7 RID: 9943
		private bool f = false;

		// Token: 0x040026D8 RID: 9944
		private SignatureFlags g = SignatureFlags.None;

		// Token: 0x040026D9 RID: 9945
		private abd h = null;

		// Token: 0x040026DA RID: 9946
		private Hashtable i = new Hashtable();

		// Token: 0x040026DB RID: 9947
		private bool j = false;

		// Token: 0x040026DC RID: 9948
		private bool k = false;
	}
}
