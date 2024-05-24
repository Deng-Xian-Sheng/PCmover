using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x0200009C RID: 156
	internal class dj : c1
	{
		// Token: 0x0600078E RID: 1934 RVA: 0x0006CDF8 File Offset: 0x0006BDF8
		internal void b(abk A_0)
		{
			abj abj = null;
			if (A_0.c().hy() == ag9.j)
			{
				abj = (abj)A_0.c().h6();
			}
			abk abk = abj.l();
			bool flag = false;
			afj afj = null;
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
								this.e = ((abu)abk.c()).j9();
								if (this.e.Equals(base.a()) || this.e.Equals(base.b()))
								{
									this.a = true;
									flag = true;
								}
							}
							else if (abk.c() is afj)
							{
								afj = (afj)abk.c();
							}
							else
							{
								abd abd = abk.c().h6();
								if (abd.hy() == ag9.g)
								{
									abj abj2 = (abj)abk.c().h6();
									if (abj2 != null)
									{
										this.b(abj2);
									}
								}
								else if (abd.hy() == ag9.d)
								{
									this.e = ((abu)abd).j9();
									if (this.e.Equals(base.a()) || this.e.Equals(base.b()))
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
						this.a(abj);
					}
				}
				else if (num != 338928268)
				{
					if (num != 598973023)
					{
						if (num == 750505570)
						{
							this.j = this.a(abk);
						}
					}
					else
					{
						abj abj3 = (abj)abk.c().h6();
						if (abj3 != null)
						{
							this.b(abj3);
						}
					}
				}
				else if (abk.c().hy() == ag9.j)
				{
					abj abj4 = (abj)abk.c().h6();
					this.b = true;
					this.a = false;
					this.h = new dh(((afj)abj4).j4());
				}
				if (flag)
				{
					break;
				}
				abk = abk.d();
			}
			if (afj != null || (this.e != null && this.a(this.e) && this.j.IndexOf('-') != this.j.Length - 1))
			{
				if (!this.b && !(this.e == "Identity-H") && !(this.e == "Identity-V"))
				{
					this.d = true;
					this.i = new dc(this.e, this.j, afj);
				}
			}
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x0006D168 File Offset: 0x0006C168
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
			string result;
			if (this.a && !this.b)
			{
				int num2 = num;
				if (num2 != 0)
				{
					if (this.c)
					{
						result = this.g.a(encoding.GetString(A_0.b()));
					}
					else if (this.e.Equals(base.b()))
					{
						result = base.b(encoding.GetString(A_0.b()));
					}
					else
					{
						result = base.c(encoding.GetString(A_0.b()));
					}
				}
				else if (this.c)
				{
					result = this.g.a(array);
				}
				else if (this.e.Equals(base.b()))
				{
					result = base.c(array);
				}
				else
				{
					result = encoding.GetString(array);
				}
			}
			else if (this.b && !this.d)
			{
				A_0.a(array);
				result = this.h.a(A_0, this);
			}
			else if (this.d)
			{
				A_0.a(array);
				result = this.i.c(A_0);
			}
			else
			{
				result = encoding.GetString(array);
			}
			return result;
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x0006D2FC File Offset: 0x0006C2FC
		internal override char? by(byte A_0)
		{
			char? result;
			if (this.c)
			{
				result = new char?(this.g.a(A_0));
			}
			else if (this.a)
			{
				result = new char?((char)A_0);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x0006D350 File Offset: 0x0006C350
		internal override char? b2(string A_0)
		{
			if (this.b)
			{
				if (this.d)
				{
					char? c = this.i.d(A_0);
					int? num = (c != null) ? new int?((int)c.GetValueOrDefault()) : null;
					if (num != null)
					{
						return this.i.d(A_0);
					}
					if (this.k != null)
					{
						return new char?(((r5)this.k).a(Convert.ToInt32(A_0, 16)));
					}
				}
				else if (this.c)
				{
					int num2 = Convert.ToInt32(A_0, 16);
					return new char?(this.g.a((byte)num2));
				}
			}
			else if (this.d)
			{
				if (this.c)
				{
					int num2 = Convert.ToInt32(A_0, 16);
					return new char?(this.g.a((byte)num2));
				}
			}
			return null;
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x0006D478 File Offset: 0x0006C478
		private void b(abj A_0)
		{
			abk abk = A_0.l();
			Hashtable hashtable = null;
			while (abk != null)
			{
				int num = abk.a().j8();
				if (num == 738839499)
				{
					if (abk.c().hy() == ag9.d)
					{
						this.e = ((abu)abk.c()).j9();
						if (this.e.Equals(base.a()) || this.e.Equals(base.b()))
						{
							this.a = true;
						}
					}
				}
				abk = abk.d();
			}
			if (hashtable != null)
			{
				this.g = new c0(hashtable, this.e);
			}
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0006D540 File Offset: 0x0006C540
		private string a(abk A_0)
		{
			string result = null;
			if (A_0.c().h6().hy() == ag9.g)
			{
				abj a_ = (abj)A_0.c().h6();
				result = this.a(a_);
			}
			else if (A_0.c().h6().hy() == ag9.e)
			{
				abe abe = (abe)A_0.c().h6();
				for (int i = 0; i < abe.a(); i++)
				{
					if (abe.a(i) != null)
					{
						abj a_ = (abj)abe.a(i).h6();
						result = this.a(a_);
					}
				}
			}
			return result;
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x0006D608 File Offset: 0x0006C608
		private string a(abj A_0)
		{
			abk abk = A_0.l();
			bool flag = false;
			string str = null;
			string str2 = null;
			while (abk != null)
			{
				int num = abk.a().j8();
				if (num == 821360159)
				{
					abj abj = (abj)abk.c().h6();
					for (abk abk2 = abj.l(); abk2 != null; abk2 = abk2.d())
					{
						num = abk2.a().j8();
						if (num != 264819413)
						{
							if (num == 311768778)
							{
								if (abk2.c().hy() == ag9.c)
								{
									str2 = ((ab7)abk2.c()).kf();
								}
								else if (abk2.c().hy() == ag9.j)
								{
									str = ((ab7)abk2.c().h6()).kf();
								}
							}
						}
						else if (abk2.c().hy() == ag9.c)
						{
							str = ((ab7)abk2.c()).kf();
						}
						else if (abk2.c().hy() == ag9.j)
						{
							str = ((ab7)abk2.c().h6()).kf();
						}
					}
					flag = true;
				}
				if (flag)
				{
					return str2 + "-" + str;
				}
				abk = abk.d();
			}
			return null;
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0006D7AC File Offset: 0x0006C7AC
		private bool a(string A_0)
		{
			if (char.IsNumber(A_0[0]))
			{
				A_0 = "_" + A_0;
			}
			return Document.a.GetObject(A_0.Replace('-', '_')) != null || (A_0 == "Identity-H" || A_0 == "Identity-V");
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0006D828 File Offset: 0x0006C828
		private void a(abd A_0)
		{
			this.f = new c2(A_0);
			if (this.f != null)
			{
				this.k = this.f.Encoder;
			}
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x0006D864 File Offset: 0x0006C864
		internal override bool bz()
		{
			return this.a;
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x0006D87C File Offset: 0x0006C87C
		internal override bool b0()
		{
			return this.b;
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0006D894 File Offset: 0x0006C894
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

		// Token: 0x040003FB RID: 1019
		private new bool a = false;

		// Token: 0x040003FC RID: 1020
		private new bool b = false;

		// Token: 0x040003FD RID: 1021
		private new bool c = false;

		// Token: 0x040003FE RID: 1022
		private bool d = false;

		// Token: 0x040003FF RID: 1023
		private string e = null;

		// Token: 0x04000400 RID: 1024
		private Font f = null;

		// Token: 0x04000401 RID: 1025
		private c0 g = null;

		// Token: 0x04000402 RID: 1026
		private dh h = null;

		// Token: 0x04000403 RID: 1027
		private dc i = null;

		// Token: 0x04000404 RID: 1028
		private string j = null;

		// Token: 0x04000405 RID: 1029
		private ceTe.DynamicPDF.Text.Encoder k = null;
	}
}
