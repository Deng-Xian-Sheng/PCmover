using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200009B RID: 155
	internal class di : c1
	{
		// Token: 0x06000785 RID: 1925 RVA: 0x0006C6E0 File Offset: 0x0006B6E0
		internal void a(abk A_0)
		{
			abj abj = null;
			if (A_0.c().hy() == ag9.j)
			{
				abj = (abj)A_0.c().h6();
			}
			abk abk = abj.l();
			string text = null;
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
								this.d = ((abu)abk.c()).j9();
								if (this.d.Equals(base.a()) || this.d.Equals(base.b()))
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
									this.d = ((abu)abd).j9();
									if (this.d.Equals(base.a()) || this.d.Equals(base.b()))
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
						text = ((abu)abk.c()).j9();
						this.a(abj);
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
					this.f = new dh(((afj)abj4).j4());
				}
				if (flag)
				{
					break;
				}
				abk = abk.d();
			}
			if (!this.a && !this.b)
			{
				string text2 = text;
				if (text2 != null)
				{
					if (!(text2 == "Symbol"))
					{
						if (text2 == "ZapfDingbats")
						{
							this.d = "ZapfDingBatsEncoding";
						}
					}
					else
					{
						this.d = "SymbolEncoding";
					}
				}
			}
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0006C9CC File Offset: 0x0006B9CC
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
				if (this.g)
				{
					if (num == 0)
					{
						return this.e.a(array);
					}
					return this.e.a(encoding.GetString(A_0.b()));
				}
			}
			else if (this.b)
			{
				A_0.a(array);
				return this.f.a(A_0, this);
			}
			int num2 = num;
			string result;
			if (num2 != 0)
			{
				if (this.d != null && this.d.Equals(base.b()))
				{
					result = base.b(encoding.GetString(A_0.b()));
				}
				else
				{
					result = base.c(encoding.GetString(A_0.b()));
				}
			}
			else if (this.d != null && this.d.Equals(base.b()))
			{
				result = base.c(array);
			}
			else
			{
				result = encoding.GetString(array);
			}
			return result;
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x0006CB38 File Offset: 0x0006BB38
		internal override char? by(byte A_0)
		{
			char? result;
			if (this.g)
			{
				result = new char?(this.e.a(A_0));
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

		// Token: 0x06000788 RID: 1928 RVA: 0x0006CB8C File Offset: 0x0006BB8C
		private void a(abj A_0)
		{
			abk abk = A_0.l();
			Hashtable hashtable = null;
			while (abk != null)
			{
				int num = abk.a().j8();
				if (num != 738839499)
				{
					if (num == 909148531)
					{
						if (hashtable == null)
						{
							hashtable = new Hashtable();
						}
						abe abe = (abe)abk.c().h6();
						this.g = true;
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
					this.d = ((abu)abk.c()).j9();
					if (this.d.Equals(base.a()) || this.d.Equals(base.b()))
					{
						this.a = true;
					}
				}
				abk = abk.d();
			}
			if (hashtable != null)
			{
				this.e = new c0(hashtable, this.d);
			}
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x0006CD51 File Offset: 0x0006BD51
		private void a(abd A_0)
		{
			this.c = new c2(A_0);
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0006CD60 File Offset: 0x0006BD60
		internal override bool bz()
		{
			return this.a;
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0006CD78 File Offset: 0x0006BD78
		internal override bool b0()
		{
			return this.b;
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0006CD90 File Offset: 0x0006BD90
		internal override Font b1()
		{
			Font result;
			if (this.c != null)
			{
				result = this.c;
			}
			else
			{
				result = base.b1();
			}
			return result;
		}

		// Token: 0x040003F4 RID: 1012
		private new bool a = false;

		// Token: 0x040003F5 RID: 1013
		private new bool b = false;

		// Token: 0x040003F6 RID: 1014
		private new Font c = null;

		// Token: 0x040003F7 RID: 1015
		private string d = null;

		// Token: 0x040003F8 RID: 1016
		private c0 e = null;

		// Token: 0x040003F9 RID: 1017
		private dh f = null;

		// Token: 0x040003FA RID: 1018
		private bool g = false;
	}
}
