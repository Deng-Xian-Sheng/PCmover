using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200009E RID: 158
	internal class dl : c1
	{
		// Token: 0x060007A4 RID: 1956 RVA: 0x0006E2F4 File Offset: 0x0006D2F4
		internal void a(abk A_0)
		{
			abj abj = null;
			if (A_0.c().hy() == ag9.j)
			{
				abj = (abj)A_0.c().h6();
			}
			abk abk = abj.l();
			bool flag = false;
			while (abk != null)
			{
				int num = abk.a().j8();
				if (num <= 95985731)
				{
					if (num != 42320626)
					{
						if (num == 95985731)
						{
							if (abk.c().hy() == ag9.d)
							{
								this.g = ((abu)abk.c()).j9();
								if (this.g.Equals(base.a()) || this.g.Equals(base.b()))
								{
									this.a = true;
									flag = true;
								}
							}
							else
							{
								abd abd = abk.c().h6();
								if (abd.hy() == ag9.g)
								{
									abj abj2 = (abj)abd;
									if (abj2 != null)
									{
										this.a(abj2);
									}
								}
								else if (abd.hy() == ag9.d)
								{
									this.g = ((abu)abd).j9();
									if (this.g.Equals(base.a()) || this.g.Equals(base.b()))
									{
										this.a = true;
										flag = true;
									}
								}
							}
						}
					}
					else if (abk.c().hy() == ag9.d)
					{
						string a_ = ((abu)abk.c()).j9();
						this.a(a_);
					}
				}
				else if (num != 338928268)
				{
					if (num == 598973023)
					{
						abj abj3 = (abj)abk.c().h6();
						if (abj3 != null)
						{
							this.a(abj3);
						}
					}
				}
				else if (abk.c().hy() == ag9.j)
				{
					abj abj4 = (abj)abk.c().h6();
					this.b = true;
					this.a = false;
					this.e = new dh(((afj)abj4).j4());
				}
				if (flag)
				{
					break;
				}
				abk = abk.d();
			}
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0006E588 File Offset: 0x0006D588
		internal override string bx(de A_0)
		{
			Encoding encoding = ae5.a(1252);
			byte[] array = base.a(A_0.b());
			int num = 1;
			if (A_0.i())
			{
				num = 0;
				array = base.b(array);
			}
			if (this.a && !this.b)
			{
				if (this.c)
				{
					if (num == 0)
					{
						return this.d.a(array);
					}
					return this.d.a(encoding.GetString(A_0.b()));
				}
			}
			else if (this.b)
			{
				A_0.a(array);
				return this.e.a(A_0, this);
			}
			string result;
			if (num == 0)
			{
				result = encoding.GetString(array);
			}
			else
			{
				result = base.c(encoding.GetString(A_0.b()));
			}
			return result;
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0006E684 File Offset: 0x0006D684
		internal override char? by(byte A_0)
		{
			char? result;
			if (this.c)
			{
				result = new char?(this.d.a(A_0));
			}
			else if (this.a)
			{
				result = new char?((char)A_0);
			}
			else
			{
				result = new char?((char)A_0);
			}
			return result;
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0006E6D4 File Offset: 0x0006D6D4
		private void a(abj A_0)
		{
			abk abk = A_0.l();
			Hashtable hashtable = null;
			while (abk != null)
			{
				int num = abk.a().j8();
				if (num != 60954087)
				{
					if (num != 738839499)
					{
						if (num == 909148531)
						{
							if (hashtable == null)
							{
								hashtable = new Hashtable();
							}
							abe abe = (abe)abk.c().h6();
							this.c = true;
							int i = 0;
							int num2 = 0;
							while (i < abe.a())
							{
								if (abe.a(i).hy() == ag9.b)
								{
									hashtable.Add(((abw)abe.a(i)).kd(), ((abu)abe.a(i + 1)).j9());
									num2 = ((abw)abe.a(i)).kd();
									i += 2;
								}
								else
								{
									hashtable.Add(num2 + 1, ((abu)abe.a(i)).j9());
									num2++;
									i++;
								}
							}
							this.a = true;
						}
					}
					else if (abk.c().hy() == ag9.d)
					{
						this.g = ((abu)abk.c()).j9();
						if (this.g.Equals(base.a()) || this.g.Equals(base.b()))
						{
							this.a = true;
						}
					}
				}
				abk = abk.d();
			}
			if (hashtable != null)
			{
				this.d = new c0(hashtable, this.g);
			}
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0006E8AC File Offset: 0x0006D8AC
		private void a(string A_0)
		{
			if (A_0.IndexOf('+') > 1)
			{
				A_0 = A_0.Substring(A_0.IndexOf('+') + 1);
			}
			A_0 = A_0.Replace(",", string.Empty);
			A_0 = A_0.Replace("-", string.Empty);
			this.f = r8.b(A_0, false);
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0006E910 File Offset: 0x0006D910
		internal override bool bz()
		{
			return this.a;
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x0006E928 File Offset: 0x0006D928
		internal override bool b0()
		{
			return this.b;
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0006E940 File Offset: 0x0006D940
		internal override Font b1()
		{
			Font result;
			if (this.f != null)
			{
				result = this.f;
			}
			else
			{
				result = base.b1();
			}
			return result;
		}

		// Token: 0x0400040E RID: 1038
		private new bool a = false;

		// Token: 0x0400040F RID: 1039
		private new bool b = false;

		// Token: 0x04000410 RID: 1040
		private new bool c = false;

		// Token: 0x04000411 RID: 1041
		private c0 d = null;

		// Token: 0x04000412 RID: 1042
		private dh e = null;

		// Token: 0x04000413 RID: 1043
		private Font f = null;

		// Token: 0x04000414 RID: 1044
		private string g = null;
	}
}
