using System;

namespace zz93
{
	// Token: 0x02000129 RID: 297
	internal class hd : fd
	{
		// Token: 0x06000B53 RID: 2899 RVA: 0x0008A978 File Offset: 0x00089978
		internal hd()
		{
			this.g = new fb<f5>[6];
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x0008A9D4 File Offset: 0x000899D4
		internal hd(gi A_0)
		{
			this.g = new fb<f5>[6];
			this.cw(A_0);
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x0008AA38 File Offset: 0x00089A38
		internal override void cw(gi A_0)
		{
			if (A_0.aw())
			{
				if (A_0.x())
				{
					int num = A_0.y();
					if (num != 0)
					{
						this.a(A_0, num);
					}
				}
				else
				{
					this.g = new fb<f5>[6];
					this.a = false;
					this.b = false;
					this.c = false;
					this.d = false;
					this.e = false;
					this.f = false;
					this.h = 0;
					string text;
					if (A_0.al())
					{
						text = A_0.ak().Trim();
					}
					else
					{
						text = A_0.ah();
					}
					this.a(text, A_0);
					if (A_0.a4() && A_0.ax())
					{
						this.e = true;
					}
					while (A_0.a0())
					{
						if (A_0.al() || this.d)
						{
							if (!this.e)
							{
								text = A_0.ak().Trim();
							}
							else
							{
								text = A_0.ah();
								this.e = false;
							}
						}
						else
						{
							text = A_0.ah();
						}
						if (text != null)
						{
							this.a(text, A_0);
						}
						if (A_0.a4() && A_0.ax())
						{
							this.e = true;
						}
					}
					this.i = true;
				}
			}
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x0008ABA8 File Offset: 0x00089BA8
		private void a(string A_0, gi A_1)
		{
			int num = A_1.a(A_0, 0, A_0.Length);
			int num2 = num;
			if (num2 != 505607249)
			{
				if (!this.a && this.c(A_0))
				{
					this.a = true;
				}
				else if (!this.b && this.d(A_0))
				{
					this.b = true;
				}
				else if (!this.c && this.b(A_0))
				{
					this.c = true;
				}
				else if (this.a(A_0))
				{
					this.d = true;
				}
				else if (!this.d && (char.IsNumber(A_0[0]) || A_0.StartsWith(".")))
				{
					h2 a_ = new h2(A_1.a(A_0));
					af0 af = new af0(m4.a(a_));
					af.a(a_.a().b());
					if (a_.a().b() == i2.b)
					{
						af.a(true);
						af.b(x5.a(a_.a().a()));
					}
					this.a(2163680, af);
					this.d = true;
				}
				else if (this.d && (char.IsNumber(A_0[0]) || A_0.StartsWith(".")))
				{
					h2 a_2 = new h2(A_1.a(A_0));
					x5 a_3 = x5.c();
					if (a_2.a().a() >= 0f)
					{
						if (a_2.a().b() == i2.a)
						{
							a_3 = x5.a(a_2.a().a());
						}
						else
						{
							a_3 = m4.a(a_2);
						}
						afz afz = new afz(a_3);
						if (a_2.a().b() == i2.a)
						{
							afz.c(true);
						}
						else if (a_2.a().b() == i2.b)
						{
							afz.b(true);
						}
						else
						{
							afz.a(a_2.a().b());
						}
						this.a(1652275116, afz);
					}
				}
				else if (!this.f && !this.a && !this.b && !this.c && !this.d)
				{
					this.a(675106854, new afy(A_0));
					this.f = true;
				}
				else
				{
					this.a(675106854, new afy(A_0));
					this.f = true;
				}
			}
			else
			{
				this.c(A_0);
				this.d(A_0);
				this.b(A_0);
				this.a(A_0);
				afz afz2 = new afz(x5.a(0f));
				afz2.d(true);
				this.a(1652275116, afz2);
				this.e(A_0);
			}
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x0008AF24 File Offset: 0x00089F24
		private void a(gi A_0, int A_1)
		{
			if (A_1 <= 20835613)
			{
				if (A_1 == 2163680)
				{
					string text = A_0.ah();
					if (text != null && text != "" && (char.IsNumber(text[0]) || text[0] == '-' || text[0] == '+'))
					{
						i4 a_ = A_0.a(text);
						af0 af = new af0(m4.a(new h2(a_)));
						af.a(a_.b());
						if (text[0] == '-' && a_.a() == 0f)
						{
							if (a_.b() == i2.b)
							{
								af.a(true);
								af.b(x5.a(a_.a()));
							}
							this.a(2163680, af);
						}
						else if (a_.a() >= 0f)
						{
							if (a_.b() == i2.b)
							{
								af.a(true);
								af.b(x5.a(a_.a()));
							}
							this.a(2163680, af);
						}
					}
					else
					{
						this.a(text);
					}
					if (A_0.a4() && A_0.ax())
					{
						text = A_0.ah();
						i4 a_2 = A_0.a(text);
						if (a_2.a() >= 0f)
						{
							afz afz = new afz(m4.a(new h2(a_2)));
							if (a_2.b() == i2.b)
							{
								afz.b(true);
							}
							else if (a_2.b() == i2.a)
							{
								afz.c(true);
							}
							else
							{
								afz.a(a_2.b());
							}
							this.a(1652275116, afz);
						}
					}
					return;
				}
				if (A_1 == 20835613)
				{
					string text = A_0.ah();
					this.d(text);
					return;
				}
			}
			else
			{
				if (A_1 == 144877216)
				{
					string text = A_0.ah();
					this.c(text);
					return;
				}
				if (A_1 == 675106854)
				{
					string text = A_0.ak();
					if (text != null)
					{
						this.e(text);
					}
					return;
				}
				if (A_1 == 791474706)
				{
					string text = A_0.ah();
					this.b(text);
					return;
				}
			}
			A_0.ap();
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x0008B1D0 File Offset: 0x0008A1D0
		private void a(int A_0, f5 A_1)
		{
			int num = this.a(A_0);
			if (num < 0)
			{
				this.g[this.h++] = new fb<f5>(A_0, A_1);
			}
			else
			{
				this.g[num].a(A_0);
				this.g[num].a(A_1);
			}
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x0008B248 File Offset: 0x0008A248
		private int a(int A_0)
		{
			for (int i = 0; i < this.g.Length; i++)
			{
				if (this.g[i].a() == A_0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x0008B298 File Offset: 0x0008A298
		private void e(string A_0)
		{
			string text = A_0.ToLower();
			afy afy;
			if (text != null)
			{
				if (text == "inherit")
				{
					afy = new afy(null);
					afy.d(true);
					goto IL_34;
				}
			}
			afy = new afy(A_0);
			IL_34:
			this.a(675106854, afy);
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x0008B2E8 File Offset: 0x0008A2E8
		private bool d(string A_0)
		{
			string text = A_0.ToLower();
			if (text != null)
			{
				if (text == "normal")
				{
					af2 af = new af2(f6.a);
					this.a(20835613, af);
					return true;
				}
				if (text == "small-caps")
				{
					af2 af = new af2(f6.b);
					this.a(20835613, af);
					return true;
				}
				if (text == "inherit")
				{
					af2 af = new af2(f6.a);
					af.d(true);
					this.a(20835613, af);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x0008B380 File Offset: 0x0008A380
		private bool c(string A_0)
		{
			string text = A_0.ToLower();
			if (text != null)
			{
				if (text == "italic")
				{
					af1 af = new af1(f4.b);
					this.a(144877216, af);
					return true;
				}
				if (text == "normal")
				{
					af1 af = new af1(f4.a);
					this.a(144877216, af);
					return true;
				}
				if (text == "oblique")
				{
					af1 af = new af1(f4.c);
					this.a(144877216, af);
					return true;
				}
				if (text == "inherit")
				{
					af1 af = new af1(f4.a);
					af.d(true);
					this.a(144877216, af);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x0008B440 File Offset: 0x0008A440
		private bool b(string A_0)
		{
			string text = A_0.ToLower();
			switch (text)
			{
			case "bold":
			{
				af3 af = new af3(f7.k);
				this.a(791474706, af);
				return true;
			}
			case "bolder":
			{
				af3 af = new af3(f7.c);
				this.a(791474706, af);
				return true;
			}
			case "lighter":
			{
				af3 af = new af3(f7.d);
				this.a(791474706, af);
				return true;
			}
			case "normal":
			case "400":
			{
				af3 af = new af3(f7.h);
				this.a(791474706, af);
				return true;
			}
			case "100":
			{
				af3 af = new af3(f7.e);
				this.a(791474706, af);
				return true;
			}
			case "200":
			{
				af3 af = new af3(f7.f);
				this.a(791474706, af);
				return true;
			}
			case "300":
			{
				af3 af = new af3(f7.g);
				this.a(791474706, af);
				return true;
			}
			case "500":
			{
				af3 af = new af3(f7.i);
				this.a(791474706, af);
				return true;
			}
			case "600":
			{
				af3 af = new af3(f7.j);
				this.a(791474706, af);
				return true;
			}
			case "700":
			{
				af3 af = new af3(f7.k);
				this.a(791474706, af);
				return true;
			}
			case "800":
			{
				af3 af = new af3(f7.l);
				this.a(791474706, af);
				return true;
			}
			case "900":
			{
				af3 af = new af3(f7.m);
				this.a(791474706, af);
				return true;
			}
			case "inherit":
			{
				af3 af = new af3(f7.h);
				af.d(true);
				this.a(791474706, af);
				return true;
			}
			}
			return false;
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x0008B700 File Offset: 0x0008A700
		private bool a(string A_0)
		{
			string text = A_0.ToLower();
			switch (text)
			{
			case "larger":
			{
				af0 af = new af0(x5.b());
				af.a(i2.d);
				this.a(2163680, af);
				return true;
			}
			case "smaller":
			{
				af0 af = new af0(x5.a());
				af.a(i2.d);
				this.a(2163680, af);
				return true;
			}
			case "xx-large":
			{
				af0 af = new af0(m4.a(new h2(new i4(i2.d, hd.p))));
				af.a(i2.d);
				this.a(2163680, af);
				return true;
			}
			case "x-large":
			{
				af0 af = new af0(m4.a(new h2(new i4(i2.d, hd.o))));
				af.a(i2.d);
				this.a(2163680, af);
				return true;
			}
			case "large":
			{
				af0 af = new af0(m4.a(new h2(new i4(i2.d, hd.n))));
				af.a(i2.d);
				this.a(2163680, af);
				return true;
			}
			case "medium":
			{
				af0 af = new af0(m4.a(new h2(new i4(i2.d, hd.r))));
				af.a(i2.d);
				this.a(2163680, af);
				return true;
			}
			case "small":
			{
				af0 af = new af0(m4.a(new h2(new i4(i2.d, hd.j))));
				af.a(i2.d);
				this.a(2163680, af);
				return true;
			}
			case "x-small":
			{
				af0 af = new af0(m4.a(new h2(new i4(i2.d, hd.k))));
				af.a(i2.d);
				this.a(2163680, af);
				return true;
			}
			case "xx-small":
			{
				af0 af = new af0(m4.a(new h2(new i4(i2.d, hd.l))));
				af.a(i2.d);
				this.a(2163680, af);
				return true;
			}
			case "inherit":
			{
				af0 af = new af0(m4.a(new h2(new i4(i2.d, hd.s))));
				af.a(i2.d);
				af.d(true);
				this.a(2163680, af);
				return true;
			}
			}
			return false;
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x0008BA00 File Offset: 0x0008AA00
		internal fb<f5>[] a()
		{
			return this.g;
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x0008BA18 File Offset: 0x0008AA18
		internal void a(fb<f5>[] A_0)
		{
			this.g = A_0;
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x0008BA24 File Offset: 0x0008AA24
		internal override int cv()
		{
			return 6968946;
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x0008BA3B File Offset: 0x0008AA3B
		internal override fn cx()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x0008BA48 File Offset: 0x0008AA48
		internal bool b()
		{
			bool result = false;
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0 && this.a()[i].b().g())
				{
					result = true;
					i = this.a().Length;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x0008BAB8 File Offset: 0x0008AAB8
		internal bool b(int A_0)
		{
			bool result = false;
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() == A_0 && this.a()[i].b().g())
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x0008BB20 File Offset: 0x0008AB20
		internal hd a(hd A_0)
		{
			fb<f5>[] array = A_0.a();
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0)
				{
					for (int j = 0; j < array.Length; j++)
					{
						if (this.a()[i].a() == array[j].a())
						{
							if (this.a()[i].b().g() && !array[j].b().g())
							{
								this.a()[i].a(array[j].b());
								this.a()[i].b().d(false);
							}
							break;
						}
					}
				}
			}
			return this;
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x0008BC2C File Offset: 0x0008AC2C
		internal hd b(hd A_0)
		{
			hd hd = new hd();
			int num = 0;
			fb<f5>[] array = A_0.a();
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0)
				{
					hd.a()[num].a(this.a()[i].a());
					hd.a()[num].a(this.a()[i].b());
					num++;
				}
			}
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = false;
				if (array[i].a() != 0)
				{
					for (int j = 0; j < this.a().Length; j++)
					{
						if (this.a()[j].a() == array[i].a())
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						this.a(array[i], ref hd, ref num);
					}
				}
			}
			return hd;
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x0008BD78 File Offset: 0x0008AD78
		internal override bool ct()
		{
			return this.i;
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x0008BD90 File Offset: 0x0008AD90
		internal override void cu(bool A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x0008BD9C File Offset: 0x0008AD9C
		private void a(fb<f5> A_0, ref hd A_1, ref int A_2)
		{
			if (!this.a(A_0.a(), A_1.a()))
			{
				A_1.a()[A_2].a(A_0.a());
				A_1.a()[A_2].a(A_0.b());
				A_1.a()[A_2].b().d(A_0.b().g());
				A_2++;
			}
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x0008BE28 File Offset: 0x0008AE28
		private bool a(int A_0, fb<f5>[] A_1, ref int A_2)
		{
			while (A_2 < A_1.Length)
			{
				bool result;
				if (A_1[A_2].a() != 0 && A_1[A_2].a() == A_0)
				{
					result = true;
				}
				else
				{
					if (A_1[A_2].a() != 0)
					{
						A_2++;
						continue;
					}
					result = false;
				}
				return result;
			}
			if (A_2 == A_1.Length)
			{
				A_2--;
				return true;
			}
			return false;
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x0008BEB4 File Offset: 0x0008AEB4
		internal bool a(int A_0, fb<f5>[] A_1)
		{
			for (int i = 0; i < A_1.Length; i++)
			{
				if (A_1[i].a() == A_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x0008BEF8 File Offset: 0x0008AEF8
		internal hd a(hd A_0, hd A_1)
		{
			hd hd = new hd();
			fb<f5>[] array = A_0.a();
			fb<f5>[] array2 = A_1.a();
			int num = 0;
			for (int i = 0; i < array2.Length; i++)
			{
				if (!this.a(array2[i].a(), array, ref num))
				{
					if (array2[i].a() != 0)
					{
						array[num].a(array2[i].a());
						array[num].a(array2[i].b());
					}
				}
				num = 0;
			}
			hd.a(array);
			return hd;
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x0008BFB4 File Offset: 0x0008AFB4
		internal int c()
		{
			for (int i = 0; i < this.g.Length; i++)
			{
				if (this.g[i].a() == 1652275116)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x0008C004 File Offset: 0x0008B004
		internal void a(int A_0, afz A_1)
		{
			if (A_0 == -1)
			{
				for (int i = 0; i < this.g.Length; i++)
				{
					if (this.g[i].a() == 0)
					{
						this.g[i].a(1652275116);
						this.g[i].a(A_1);
						break;
					}
				}
			}
			else if (this.g[A_0].a() == 1652275116)
			{
				this.g[A_0].a(A_1);
			}
		}

		// Token: 0x04000609 RID: 1545
		private new bool a = false;

		// Token: 0x0400060A RID: 1546
		private bool b = false;

		// Token: 0x0400060B RID: 1547
		private bool c = false;

		// Token: 0x0400060C RID: 1548
		private bool d = false;

		// Token: 0x0400060D RID: 1549
		private bool e = false;

		// Token: 0x0400060E RID: 1550
		private bool f = false;

		// Token: 0x0400060F RID: 1551
		private fb<f5>[] g;

		// Token: 0x04000610 RID: 1552
		private int h = 0;

		// Token: 0x04000611 RID: 1553
		private bool i = false;

		// Token: 0x04000612 RID: 1554
		internal static float j = 9.8f;

		// Token: 0x04000613 RID: 1555
		internal static float k = 7.5f;

		// Token: 0x04000614 RID: 1556
		internal static float l = 6.8f;

		// Token: 0x04000615 RID: 1557
		internal static float m = 9.6f;

		// Token: 0x04000616 RID: 1558
		internal static float n = 13.5f;

		// Token: 0x04000617 RID: 1559
		internal static float o = 18f;

		// Token: 0x04000618 RID: 1560
		internal static float p = 24f;

		// Token: 0x04000619 RID: 1561
		internal static float q = 13.5f;

		// Token: 0x0400061A RID: 1562
		internal static float r = 12f;

		// Token: 0x0400061B RID: 1563
		internal static float s = 12f;
	}
}
