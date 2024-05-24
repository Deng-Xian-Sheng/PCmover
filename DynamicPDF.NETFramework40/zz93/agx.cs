using System;
using System.Collections.Generic;
using System.IO;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x020004E8 RID: 1256
	internal class agx : aba
	{
		// Token: 0x0600332C RID: 13100 RVA: 0x001C6C9C File Offset: 0x001C5C9C
		internal agx(agp A_0, agy A_1) : base(A_0.f())
		{
			this.b = A_0;
			this.a(A_1);
			this.f = 0;
		}

		// Token: 0x0600332D RID: 13101 RVA: 0x001C6D10 File Offset: 0x001C5D10
		internal agx(agp A_0, int A_1, int A_2) : base(A_0.f())
		{
			this.b = A_0;
			this.a(A_0.a(A_1));
			this.f = A_2;
		}

		// Token: 0x0600332E RID: 13102 RVA: 0x001C6D88 File Offset: 0x001C5D88
		internal agx(agp A_0, int A_1, int A_2, int A_3) : base(A_0.f())
		{
			this.b = A_0;
			this.f = A_2 + A_3;
			if (this.f >= 16384)
			{
				A_1++;
				this.f -= 16384;
			}
			this.a(A_0.a(A_1));
		}

		// Token: 0x0600332F RID: 13103 RVA: 0x001C6E2C File Offset: 0x001C5E2C
		internal override agx lq()
		{
			return this;
		}

		// Token: 0x06003330 RID: 13104 RVA: 0x001C6E40 File Offset: 0x001C5E40
		internal override void lb()
		{
			agz agz = new agz(this);
			agz.le();
		}

		// Token: 0x06003331 RID: 13105 RVA: 0x001C6E5C File Offset: 0x001C5E5C
		internal ab8 a(abt A_0, abi A_1)
		{
			while (this.e[this.f] != 60)
			{
				this.o();
			}
			abj a_ = this.b(A_1, 0);
			ab8 ab = new ab8();
			ab.a(a_, A_0);
			return ab;
		}

		// Token: 0x06003332 RID: 13106 RVA: 0x001C6EA8 File Offset: 0x001C5EA8
		private agy l()
		{
			if (this.d == null)
			{
				this.d = this.c.e();
			}
			return this.d;
		}

		// Token: 0x06003333 RID: 13107 RVA: 0x001C6EE3 File Offset: 0x001C5EE3
		private void a(agy A_0)
		{
			this.d = null;
			this.c = A_0;
			this.e = A_0.a();
			this.g = this.e.Length - 1;
		}

		// Token: 0x06003334 RID: 13108 RVA: 0x001C6F10 File Offset: 0x001C5F10
		private void k()
		{
			this.j = this.e;
			this.i = 0;
			this.h = this.f;
		}

		// Token: 0x06003335 RID: 13109 RVA: 0x001C6F34 File Offset: 0x001C5F34
		internal void c(int A_0, int A_1)
		{
			if (this.c.d() != A_0)
			{
				this.a(this.b.a(A_0));
			}
			this.f = A_1;
		}

		// Token: 0x06003336 RID: 13110 RVA: 0x001C6F70 File Offset: 0x001C5F70
		internal void a(int A_0, int A_1, int A_2)
		{
			A_1 += A_2;
			if (A_1 >= 16384)
			{
				A_0++;
				A_1 -= 16384;
			}
			if (this.c.d() != A_0)
			{
				this.a(this.b.a(A_0));
			}
			this.f = A_1;
		}

		// Token: 0x06003337 RID: 13111 RVA: 0x001C6FD0 File Offset: 0x001C5FD0
		internal void a(long A_0)
		{
			if (this.c == null || A_0 < this.c.b() || A_0 >= this.c.c())
			{
				this.a(this.b.c(A_0));
			}
			this.f = (int)this.b.b(A_0);
		}

		// Token: 0x06003338 RID: 13112 RVA: 0x001C7034 File Offset: 0x001C6034
		internal void e(int A_0)
		{
			this.f += A_0;
			while (this.f >= 16384)
			{
				int num = this.f - 16384;
				if (this.d != null)
				{
					this.a(this.d);
				}
				else
				{
					this.a(this.c.e());
				}
				this.f = num;
			}
		}

		// Token: 0x06003339 RID: 13113 RVA: 0x001C70B0 File Offset: 0x001C60B0
		private void d(int A_0)
		{
			this.f += A_0;
			if (this.f > 16384)
			{
				int num = this.c.d() + 1;
				this.f -= 16384;
				while (this.f >= 16384)
				{
					this.f -= 16384;
					num++;
				}
				this.a(this.b.a(num));
			}
		}

		// Token: 0x0600333A RID: 13114 RVA: 0x001C7144 File Offset: 0x001C6144
		internal override abd ld(ab9 A_0)
		{
			abd result;
			if (A_0.c() == -5L)
			{
				result = null;
			}
			else
			{
				this.a(A_0.a());
				abd abd = null;
				if (base.af().g() == null)
				{
					while (this.e[this.f] != 106)
					{
						this.o();
					}
					this.o();
					this.s();
					abd = this.c(new abi(base.af()), (int)A_0.c());
				}
				else if (A_0.c() > 0L)
				{
					while (this.e[this.f] < 48)
					{
						this.o();
					}
					this.g();
					while (this.e[this.f] < 48)
					{
						this.o();
					}
					int num = 0;
					while (agx.e(this.e[this.f]))
					{
						num *= 10;
						num += (int)(this.e[this.f] - 48);
						this.o();
					}
					this.s();
					while (this.e[this.f] != 106)
					{
						this.o();
					}
					this.o();
					abm a_ = new abm(base.af(), (long)A_0.l(), num);
					abd = this.c(a_, (int)A_0.c());
				}
				result = abd;
			}
			return result;
		}

		// Token: 0x0600333B RID: 13115 RVA: 0x001C72DC File Offset: 0x001C62DC
		private ab7 b(abi A_0)
		{
			int num = this.c.d();
			int num2 = this.f;
			bool flag = this.e[this.f] == 60;
			this.o();
			if (flag)
			{
				while (this.e[this.f] != 62)
				{
					this.o();
				}
				this.o();
			}
			else
			{
				int i = 1;
				while (i > 0)
				{
					if (this.e[this.f] == 92)
					{
						this.o();
					}
					else if (this.e[this.f] == 40)
					{
						i++;
					}
					else if (this.e[this.f] == 41)
					{
						i--;
					}
					this.o();
				}
			}
			int a_ = this.b(num, num2);
			return new afn(this.b, A_0, num, num2, a_, flag);
		}

		// Token: 0x0600333C RID: 13116 RVA: 0x001C73EC File Offset: 0x001C63EC
		private afh a(abi A_0)
		{
			this.o();
			this.s();
			List<abd> list = new List<abd>(4);
			while (this.e[this.f] != 93)
			{
				list.Add(this.c(A_0, 0));
				this.s();
			}
			this.o();
			return new afh(this.b, list);
		}

		// Token: 0x0600333D RID: 13117 RVA: 0x001C7458 File Offset: 0x001C6458
		private abf a(bool A_0)
		{
			if (A_0)
			{
				this.e(4);
			}
			else
			{
				this.e(5);
			}
			return new abf(A_0);
		}

		// Token: 0x0600333E RID: 13118 RVA: 0x001C7490 File Offset: 0x001C6490
		private abj a(abi A_0, abk A_1, int A_2)
		{
			int a_ = this.c.d();
			int a_2 = this.f;
			afk afk = new afk(this.b, A_0, A_1);
			this.a(a_, a_2, 5);
			while (this.e[this.f] != 10 && this.e[this.f] != 13)
			{
				this.o();
			}
			byte b = this.e[this.f];
			this.o();
			if (this.e[this.f] == 10 && b == 13)
			{
				this.o();
			}
			int a_3 = this.c.d();
			int a_4 = this.f;
			afk.a(a_3, a_4);
			A_2 -= this.b(a_, a_2);
			if (afk.g() > A_2)
			{
				afk.e(this.a(a_3, a_4, afk.g(), A_2));
			}
			return afk;
		}

		// Token: 0x0600333F RID: 13119 RVA: 0x001C75A0 File Offset: 0x001C65A0
		private int a(int A_0, int A_1, int A_2, int A_3)
		{
			this.d(A_3);
			while (A_0 < this.c.d() || A_1 < this.f)
			{
				if (this.e[this.f] == 109)
				{
					this.p();
					if (this.e[this.f] == 97)
					{
						this.p();
						if (this.e[this.f] == 101)
						{
							this.p();
							if (this.e[this.f] == 114)
							{
								this.p();
								if (this.e[this.f] == 116)
								{
									this.p();
									if (this.e[this.f] == 115)
									{
										this.p();
										if (this.e[this.f] == 100)
										{
											this.p();
											if (this.e[this.f] == 110)
											{
												this.p();
												if (this.e[this.f] == 101)
												{
													this.p();
													if (this.e[this.f] == 10)
													{
														this.p();
														return this.b(A_0, A_1);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				this.p();
			}
			throw new PdfParsingException("Indirect Object contains an invalid stream length (" + A_2 + " bytes).");
		}

		// Token: 0x06003340 RID: 13120 RVA: 0x001C776C File Offset: 0x001C676C
		private abj b(abi A_0, int A_1)
		{
			int a_ = this.c.d();
			int a_2 = this.f;
			this.e(2);
			this.s();
			abk abk = null;
			abk abk2 = null;
			while (this.e[this.f] != 62)
			{
				abu a_3 = this.i();
				abd a_4 = this.c(A_0, 0);
				abk abk3 = new abk(a_3, a_4);
				if (abk2 == null)
				{
					abk2 = (abk = abk3);
				}
				else
				{
					abk2.a(abk3);
					abk2 = abk3;
				}
				this.s();
			}
			this.e(2);
			abj result;
			if (A_1 == 0)
			{
				result = new abj(A_0, abk);
			}
			else
			{
				this.s();
				if (A_1 > 0 && this.e[this.f] == 115)
				{
					int num = this.b(a_, a_2);
					result = this.a(A_0, abk, A_1 - num);
				}
				else
				{
					result = new afi(this.b, A_0, abk);
				}
			}
			return result;
		}

		// Token: 0x06003341 RID: 13121 RVA: 0x001C7880 File Offset: 0x001C6880
		private abj a(abi A_0, int A_1)
		{
			int a_ = this.c.d();
			int a_2 = this.f;
			this.e(2);
			this.s();
			abk abk = null;
			abk abk2 = null;
			while (this.e[this.f] != 62)
			{
				abu abu = this.i();
				abd abd = this.c(A_0, 0);
				if (abu.j9() == "A")
				{
					if (abd.hy() == ag9.d)
					{
						if (((abu)abd).j9() == "A" || ((abu)abd).j9() == "Dest")
						{
							abu = (abu)abd;
							abd = this.c(A_0, 0);
						}
					}
				}
				abk abk3 = new abk(abu, abd);
				if (abk2 == null)
				{
					abk2 = (abk = abk3);
				}
				else
				{
					abk2.a(abk3);
					abk2 = abk3;
				}
				this.s();
			}
			this.e(2);
			abj result;
			if (A_1 == 0)
			{
				result = new abj(A_0, abk);
			}
			else
			{
				this.s();
				if (A_1 > 0 && this.e[this.f] == 115)
				{
					int num = this.b(a_, a_2);
					result = this.a(A_0, abk, A_1 - num);
				}
				else
				{
					result = new afi(this.b, A_0, abk);
				}
			}
			return result;
		}

		// Token: 0x06003342 RID: 13122 RVA: 0x001C7A18 File Offset: 0x001C6A18
		private abv j()
		{
			this.e(4);
			return new abv();
		}

		// Token: 0x06003343 RID: 13123 RVA: 0x001C7A38 File Offset: 0x001C6A38
		private abu i()
		{
			int num = this.c.d();
			int num2 = this.f;
			this.o();
			while (agx.b(this.e[this.f]))
			{
				this.o();
			}
			int a_ = this.b(num, num2);
			return new afl(this.b, num, num2, a_);
		}

		// Token: 0x06003344 RID: 13124 RVA: 0x001C7A9C File Offset: 0x001C6A9C
		private int b(int A_0, int A_1)
		{
			int result;
			if (A_0 == this.c.d())
			{
				result = this.f - A_1;
			}
			else
			{
				result = (this.c.d() - A_0) * 16384 + this.f - A_1;
			}
			return result;
		}

		// Token: 0x06003345 RID: 13125 RVA: 0x001C7AEC File Offset: 0x001C6AEC
		internal abd c(abi A_0, int A_1)
		{
			this.s();
			byte b = this.e[this.f];
			if (b <= 91)
			{
				switch (b)
				{
				case 40:
					if (this.n() == 13)
					{
						this.f += 2;
						return null;
					}
					return this.b(A_0);
				case 41:
				case 42:
				case 44:
					goto IL_158;
				case 43:
					break;
				case 45:
					break;
				case 46:
					break;
				case 47:
					return this.i();
				default:
					if (b != 60)
					{
						if (b != 91)
						{
							goto IL_158;
						}
						return this.a(A_0);
					}
					else
					{
						if (this.n() != 60)
						{
							return this.b(A_0);
						}
						if (A_0.b().h())
						{
							return this.a(A_0, A_1);
						}
						return this.b(A_0, A_1);
					}
					break;
				}
				return this.h();
			}
			if (b == 102)
			{
				return this.a(false);
			}
			if (b == 110)
			{
				return this.j();
			}
			if (b == 116)
			{
				return this.a(true);
			}
			IL_158:
			if (!agx.e(this.e[this.f]))
			{
				throw new PdfParsingException("Invalid PDF Object Type.");
			}
			this.k();
			int num = this.m();
			short num2 = this.i;
			abd result;
			if (agx.c(this.j[this.h]))
			{
				this.r();
				if (this.j[this.h] <= 32)
				{
					this.r();
					this.a();
				}
				if (agx.e(this.j[this.h]))
				{
					this.f();
					if (agx.c(this.j[this.h]))
					{
						this.r();
						this.a();
						if (this.j[this.h] == 82)
						{
							this.r();
							this.e((int)this.i);
							result = new ab6(base.af(), num);
						}
						else
						{
							int num3 = this.c.d();
							int num4 = this.f;
							this.e((int)num2);
							result = new afm(this.b, num3, num4, (int)num2, num);
						}
					}
					else
					{
						int num3 = this.c.d();
						int num4 = this.f;
						this.e((int)num2);
						result = new afm(this.b, num3, num4, (int)num2, num);
					}
				}
				else
				{
					int num3 = this.c.d();
					int num4 = this.f;
					this.e((int)num2);
					result = new afm(this.b, num3, num4, (int)num2, num);
				}
			}
			else if (this.j[this.h] == 46)
			{
				int num3 = this.c.d();
				int num4 = this.f;
				this.e((int)this.i);
				this.o();
				this.g();
				int a_ = this.b(num3, num4);
				result = new afm(this.b, num3, num4, a_, true);
			}
			else
			{
				int num3 = this.c.d();
				int num4 = this.f;
				this.e((int)this.i);
				result = new afm(this.b, num3, num4, (int)num2, num);
			}
			return result;
		}

		// Token: 0x06003346 RID: 13126 RVA: 0x001C7EA8 File Offset: 0x001C6EA8
		private abw h()
		{
			bool a_ = false;
			int num = this.c.d();
			int num2 = this.f;
			if (this.e[this.f] == 43 || this.e[this.f] == 45)
			{
				this.o();
			}
			if (this.e[this.f] == 43 || this.e[this.f] == 45)
			{
				this.o();
				num = this.c.d();
				num2 = this.f;
			}
			this.g();
			if (this.e[this.f] == 46)
			{
				a_ = true;
				this.o();
				this.g();
			}
			int a_2 = this.b(num, num2);
			return new afm(this.b, num, num2, a_2, a_);
		}

		// Token: 0x06003347 RID: 13127 RVA: 0x001C7FA0 File Offset: 0x001C6FA0
		internal int m()
		{
			int num = 0;
			while (agx.e(this.j[this.h]))
			{
				num = num * 10 + (int)this.j[this.h] - 48;
				this.r();
			}
			return num;
		}

		// Token: 0x06003348 RID: 13128 RVA: 0x001C7FEC File Offset: 0x001C6FEC
		private void g()
		{
			while (agx.e(this.e[this.f]))
			{
				this.o();
			}
		}

		// Token: 0x06003349 RID: 13129 RVA: 0x001C801C File Offset: 0x001C701C
		private void f()
		{
			while (agx.e(this.j[this.h]))
			{
				this.r();
			}
		}

		// Token: 0x0600334A RID: 13130 RVA: 0x001C804C File Offset: 0x001C704C
		internal byte n()
		{
			byte result;
			if (this.f == this.g)
			{
				this.d = this.c.e();
				result = this.d.a()[0];
			}
			else
			{
				result = this.e[this.f + 1];
			}
			return result;
		}

		// Token: 0x0600334B RID: 13131 RVA: 0x001C80A4 File Offset: 0x001C70A4
		internal void o()
		{
			if (this.f == this.g)
			{
				this.q();
				this.f = 0;
			}
			else
			{
				this.f++;
			}
		}

		// Token: 0x0600334C RID: 13132 RVA: 0x001C80EC File Offset: 0x001C70EC
		internal void p()
		{
			this.f--;
			if (this.f < 0)
			{
				this.a(this.c.f());
				this.f = 16383;
			}
		}

		// Token: 0x0600334D RID: 13133 RVA: 0x001C8138 File Offset: 0x001C7138
		internal void q()
		{
			if (this.d != null)
			{
				this.a(this.d);
			}
			else
			{
				this.a(this.c.e());
			}
		}

		// Token: 0x0600334E RID: 13134 RVA: 0x001C8178 File Offset: 0x001C7178
		internal void r()
		{
			if (this.h >= this.g)
			{
				if (this.d == null)
				{
					this.d = this.c.e();
				}
				this.j = this.d.a();
				this.h = 0;
			}
			else
			{
				this.h++;
			}
			this.i += 1;
		}

		// Token: 0x0600334F RID: 13135 RVA: 0x001C81F8 File Offset: 0x001C71F8
		internal void s()
		{
			while (this.e[this.f] <= 32)
			{
				this.o();
			}
			if (this.e[this.f] == 37)
			{
				this.o();
				while (this.e[this.f] != 10 && this.e[this.f] != 13)
				{
					this.o();
				}
				this.s();
			}
		}

		// Token: 0x06003350 RID: 13136 RVA: 0x001C8288 File Offset: 0x001C7288
		internal static bool e(byte A_0)
		{
			return A_0 >= 48 && A_0 <= 57;
		}

		// Token: 0x06003351 RID: 13137 RVA: 0x001C82AC File Offset: 0x001C72AC
		internal bool t()
		{
			return this.e[this.f] >= 48 && this.e[this.f] <= 57;
		}

		// Token: 0x06003352 RID: 13138 RVA: 0x001C82E8 File Offset: 0x001C72E8
		internal byte u()
		{
			return this.e[this.f];
		}

		// Token: 0x06003353 RID: 13139 RVA: 0x001C8308 File Offset: 0x001C7308
		internal static bool d(byte A_0)
		{
			if (A_0 <= 47)
			{
				switch (A_0)
				{
				case 37:
					return true;
				case 38:
				case 39:
					break;
				case 40:
					return true;
				case 41:
					return true;
				default:
					if (A_0 == 47)
					{
						return true;
					}
					break;
				}
			}
			else
			{
				switch (A_0)
				{
				case 60:
					return true;
				case 61:
					break;
				case 62:
					return true;
				default:
					switch (A_0)
					{
					case 91:
						return true;
					case 92:
						break;
					case 93:
						return true;
					default:
						switch (A_0)
						{
						case 123:
							return true;
						case 125:
							return true;
						}
						break;
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x06003354 RID: 13140 RVA: 0x001C83B0 File Offset: 0x001C73B0
		internal static bool c(byte A_0)
		{
			return A_0 <= 32;
		}

		// Token: 0x06003355 RID: 13141 RVA: 0x001C83CC File Offset: 0x001C73CC
		internal static bool b(byte A_0)
		{
			return !agx.c(A_0) && !agx.d(A_0);
		}

		// Token: 0x06003356 RID: 13142 RVA: 0x001C83F4 File Offset: 0x001C73F4
		internal afj c(abi A_0)
		{
			while (this.e[this.f] != 60)
			{
				this.o();
			}
			return (afj)this.b(A_0, int.MaxValue);
		}

		// Token: 0x06003357 RID: 13143 RVA: 0x001C843A File Offset: 0x001C743A
		internal override void lr()
		{
			this.b.la();
		}

		// Token: 0x06003358 RID: 13144 RVA: 0x001C844C File Offset: 0x001C744C
		internal int v()
		{
			int num = (int)((this.e[this.f] - 48) * 10);
			this.e(2);
			return num + (int)(this.e[this.f] - 48);
		}

		// Token: 0x06003359 RID: 13145 RVA: 0x001C8490 File Offset: 0x001C7490
		internal byte[] f(int A_0)
		{
			byte[] result;
			if (this.e[this.f] == 40)
			{
				this.o();
				result = this.c(A_0 - 2);
			}
			else
			{
				this.o();
				result = this.b(A_0 / 2 - 1);
			}
			return result;
		}

		// Token: 0x0600335A RID: 13146 RVA: 0x001C84E8 File Offset: 0x001C74E8
		private byte[] c(int A_0)
		{
			byte[] array = new byte[A_0];
			int num = 0;
			int i = 1;
			bool flag = false;
			while (i > 0)
			{
				byte b;
				if (flag)
				{
					b = this.e[this.f];
					if (b <= 98)
					{
						if (b != 13)
						{
							if (b != 98)
							{
								goto IL_E3;
							}
							array[num++] = 8;
							this.o();
						}
						else
						{
							this.o();
						}
					}
					else if (b != 102)
					{
						if (b != 110)
						{
							switch (b)
							{
							case 114:
								array[num++] = 13;
								this.o();
								break;
							case 115:
								goto IL_E3;
							case 116:
								array[num++] = 9;
								this.o();
								break;
							default:
								goto IL_E3;
							}
						}
						else
						{
							array[num++] = 10;
							this.o();
						}
					}
					else
					{
						array[num++] = 12;
						this.o();
					}
					IL_1F8:
					flag = false;
					continue;
					IL_E3:
					if (this.e[this.f] >= 48 && this.e[this.f] <= 57)
					{
						int num2 = (int)(this.e[this.f] - 48);
						this.o();
						if (this.e[this.f] >= 48 && this.e[this.f] <= 57)
						{
							num2 *= 8;
							num2 += (int)(this.e[this.f] - 48);
							this.o();
							if (this.e[this.f] >= 48 && this.e[this.f] <= 57)
							{
								num2 *= 8;
								num2 += (int)(this.e[this.f] - 48);
								this.o();
							}
						}
						array[num++] = (byte)num2;
					}
					else
					{
						array[num++] = this.e[this.f];
						this.o();
					}
					goto IL_1F8;
				}
				b = this.e[this.f];
				switch (b)
				{
				case 40:
					i++;
					goto IL_23E;
				case 41:
					i--;
					goto IL_23E;
				default:
					if (b != 92)
					{
						goto IL_23E;
					}
					flag = true;
					this.o();
					break;
				}
				continue;
				IL_23E:
				if (i > 0)
				{
					array[num++] = this.e[this.f];
				}
				this.o();
			}
			byte[] array2 = new byte[num];
			Array.Copy(array, 0, array2, 0, num);
			return array2;
		}

		// Token: 0x0600335B RID: 13147 RVA: 0x001C8788 File Offset: 0x001C7788
		private byte[] b(int A_0)
		{
			byte[] array = new byte[A_0];
			int num = 0;
			while (this.e[this.f] != 62)
			{
				this.s();
				byte a_ = this.e[this.f];
				this.o();
				this.s();
				if (this.e[this.f] == 62)
				{
					array[num++] = this.a(a_, 0);
					break;
				}
				array[num++] = this.a(a_, this.e[this.f]);
				this.o();
				this.s();
			}
			byte[] array2 = new byte[num];
			Array.Copy(array, 0, array2, 0, num);
			return array2;
		}

		// Token: 0x0600335C RID: 13148 RVA: 0x001C8858 File Offset: 0x001C7858
		private byte a(byte A_0, byte A_1)
		{
			return (byte)(this.a(A_0) << 4 | this.a(A_1));
		}

		// Token: 0x0600335D RID: 13149 RVA: 0x001C887C File Offset: 0x001C787C
		private int a(byte A_0)
		{
			int result;
			if (A_0 <= 57)
			{
				result = (int)(A_0 - 48);
			}
			else if (A_0 <= 70)
			{
				result = (int)(A_0 - 55);
			}
			else
			{
				result = (int)(A_0 - 87);
			}
			return result;
		}

		// Token: 0x0600335E RID: 13150 RVA: 0x001C88B4 File Offset: 0x001C78B4
		internal string g(int A_0)
		{
			string result;
			if (this.f + A_0 > this.e.Length)
			{
				byte[] array = new byte[A_0];
				int num = this.e.Length - this.f;
				Array.Copy(this.e, this.f, array, 0, num);
				this.q();
				int length = A_0 - num;
				Array.Copy(this.e, 0, array, num, length);
				this.f = length;
				result = ab2.a(array, 0, A_0);
			}
			else
			{
				string text = ab2.a(this.e, this.f, A_0);
				this.e(A_0);
				result = text;
			}
			return result;
		}

		// Token: 0x0600335F RID: 13151 RVA: 0x001C895C File Offset: 0x001C795C
		internal int h(int A_0)
		{
			int result;
			if (this.f + A_0 > this.e.Length)
			{
				result = this.i(A_0);
			}
			else
			{
				int num = 0;
				int num2 = 0;
				int num3 = this.f + A_0;
				int num4 = 0;
				while (this.f < num3)
				{
					num2 <<= 6;
					num2 |= (int)(this.e[this.f] % 64);
					if (num4 % 5 == 4)
					{
						num ^= num2;
						num2 = 0;
					}
					this.f++;
					num4++;
				}
				if (num4 % 5 != 0)
				{
					num ^= num2;
				}
				result = num;
			}
			return result;
		}

		// Token: 0x06003360 RID: 13152 RVA: 0x001C8A0C File Offset: 0x001C7A0C
		internal int i(int A_0)
		{
			int num = 0;
			int num2 = 0;
			int i;
			for (i = 0; i < A_0; i++)
			{
				num2 <<= 6;
				num2 |= (int)(this.e[this.f] % 64);
				if (i % 5 == 4)
				{
					num ^= num2;
					num2 = 0;
				}
				this.o();
			}
			if (i % 5 != 0)
			{
				num ^= num2;
			}
			return num;
		}

		// Token: 0x06003361 RID: 13153 RVA: 0x001C8A80 File Offset: 0x001C7A80
		internal int w()
		{
			int num = 0;
			while (this.e[this.f] == 48)
			{
				this.o();
			}
			while (agx.e(this.e[this.f]))
			{
				num = num * 10 + (int)this.e[this.f] - 48;
				this.o();
			}
			int result;
			if (!agx.b(this.e[this.f]))
			{
				result = num;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06003362 RID: 13154 RVA: 0x001C8B08 File Offset: 0x001C7B08
		internal int x()
		{
			byte b = this.e[this.f];
			this.o();
			if (agx.e(this.e[this.f]))
			{
				byte b2 = b;
				if (b2 <= 77)
				{
					switch (b2)
					{
					case 67:
						break;
					case 68:
					case 69:
						goto IL_81;
					case 70:
						break;
					case 71:
						break;
					default:
						if (b2 != 77)
						{
							goto IL_81;
						}
						break;
					}
				}
				else if (b2 != 80)
				{
					if (b2 != 83)
					{
						if (b2 != 88)
						{
							goto IL_81;
						}
					}
				}
				return this.w();
				IL_81:;
			}
			return -1;
		}

		// Token: 0x06003363 RID: 13155 RVA: 0x001C8B9C File Offset: 0x001C7B9C
		internal float y()
		{
			int num = 0;
			int num2 = 0;
			while (this.e[this.f] == 48)
			{
				this.o();
			}
			while (agx.e(this.e[this.f]))
			{
				num = num * 10 + (int)this.e[this.f] - 48;
				num2++;
				this.o();
			}
			float result;
			if (this.e[this.f] == 46)
			{
				this.o();
				int num3 = 1;
				while (ags.d(this.e[this.f]) && num2 < 9)
				{
					num = num * 10 + (int)this.e[this.f] - 48;
					num3 *= 10;
					num2++;
					this.o();
				}
				result = (float)num / (float)num3;
			}
			else
			{
				result = (float)num;
			}
			return result;
		}

		// Token: 0x06003364 RID: 13156 RVA: 0x001C8C8C File Offset: 0x001C7C8C
		internal int z()
		{
			int num = 0;
			while (this.e[this.f] == 48)
			{
				this.o();
			}
			while (ags.d(this.e[this.f]))
			{
				num = num * 10 + (int)this.e[this.f] - 48;
				this.o();
			}
			return num;
		}

		// Token: 0x06003365 RID: 13157 RVA: 0x001C8CF8 File Offset: 0x001C7CF8
		internal void a(DocumentWriter A_0, int A_1)
		{
			if (this.f + A_1 > this.e.Length)
			{
				agy agy = this.l();
				A_0.z(this.e, this.f, A_1, agy.a());
				this.a(agy);
			}
			else
			{
				A_0.WriteNumber(this.e, this.f, A_1);
			}
		}

		// Token: 0x06003366 RID: 13158 RVA: 0x001C8D64 File Offset: 0x001C7D64
		internal void b(DocumentWriter A_0, int A_1)
		{
			if (this.f + A_1 > this.e.Length)
			{
				agy agy = this.l();
				A_0.y(this.e, this.f, A_1, agy.a());
				this.a(agy);
			}
			else
			{
				A_0.WriteName(this.e, this.f, A_1);
			}
		}

		// Token: 0x06003367 RID: 13159 RVA: 0x001C8DD0 File Offset: 0x001C7DD0
		internal void c(DocumentWriter A_0, int A_1)
		{
			if (this.f + A_1 > this.e.Length)
			{
				int i = 0;
				int num = this.e.Length - this.f;
				while (i < A_1)
				{
					A_0.WriteTextRawWithoutEncryption(this.e, this.f, num);
					this.d = this.l();
					this.a(this.d);
					this.f = 0;
					i += num;
					if (A_1 - i > 16384)
					{
						num = 16384;
					}
					else
					{
						num = A_1 - i;
					}
				}
			}
			else
			{
				A_0.WriteTextRawWithoutEncryption(this.e, this.f, A_1);
			}
		}

		// Token: 0x06003368 RID: 13160 RVA: 0x001C8E84 File Offset: 0x001C7E84
		internal void d(DocumentWriter A_0, int A_1)
		{
			if (this.f + A_1 > this.e.Length)
			{
				A_0.ab(this, A_1);
			}
			else
			{
				A_0.WriteStream(this.e, this.f, A_1);
			}
		}

		// Token: 0x06003369 RID: 13161 RVA: 0x001C8ED0 File Offset: 0x001C7ED0
		internal void e(DocumentWriter A_0, int A_1)
		{
			if (this.f + A_1 > this.e.Length)
			{
				A_0.aa(this, A_1);
			}
			else
			{
				A_0.ag(this.e, this.f, A_1);
			}
		}

		// Token: 0x0600336A RID: 13162 RVA: 0x001C8F1C File Offset: 0x001C7F1C
		internal void a(Stream A_0, int A_1, Encrypter A_2)
		{
			byte[] array = this.j(A_1);
			A_2.Encrypt(A_0, array, 0, array.Length);
		}

		// Token: 0x0600336B RID: 13163 RVA: 0x001C8F40 File Offset: 0x001C7F40
		internal void f(DocumentWriter A_0, int A_1)
		{
			int i = this.e.Length - this.f;
			A_0.Write(this.e, this.f, i);
			while (i < A_1)
			{
				this.q();
				if (i + this.e.Length > A_1)
				{
					int num = A_1 - i;
					A_0.Write(this.e, 0, num);
					i += num;
				}
				else
				{
					A_0.Write(this.e, 0, this.e.Length);
					i += this.e.Length;
				}
			}
		}

		// Token: 0x0600336C RID: 13164 RVA: 0x001C8FD8 File Offset: 0x001C7FD8
		internal void a(Stream A_0, int A_1)
		{
			int i = this.e.Length - this.f;
			A_0.Write(this.e, this.f, i);
			while (i < A_1)
			{
				this.q();
				if (i + this.e.Length > A_1)
				{
					int num = A_1 - i;
					A_0.Write(this.e, 0, num);
					i += num;
				}
				else
				{
					A_0.Write(this.e, 0, this.e.Length);
					i += this.e.Length;
				}
			}
		}

		// Token: 0x0600336D RID: 13165 RVA: 0x001C9070 File Offset: 0x001C8070
		private void e()
		{
			if (this.k == null)
			{
				this.k = new byte[16384];
			}
			this.l = 0;
			if (this.m == null)
			{
				this.m = new List<byte[]>(4);
			}
			else
			{
				this.m.Clear();
			}
		}

		// Token: 0x0600336E RID: 13166 RVA: 0x001C90CF File Offset: 0x001C80CF
		private void d()
		{
			this.m.Add(this.k);
			this.k = new byte[16384];
			this.l = 0;
		}

		// Token: 0x0600336F RID: 13167 RVA: 0x001C90FC File Offset: 0x001C80FC
		private byte[] a(int A_0)
		{
			byte[] array = new byte[this.m.Count * 16384 + this.l + A_0];
			int num = 0;
			foreach (byte[] sourceArray in this.m)
			{
				Array.Copy(sourceArray, 0, array, num++ * 16384, 16384);
			}
			Array.Copy(this.k, 0, array, num * 16384, this.l);
			this.m.Clear();
			return array;
		}

		// Token: 0x06003370 RID: 13168 RVA: 0x001C91BC File Offset: 0x001C81BC
		internal byte[] a(bool A_0, bool A_1, bool A_2, int A_3, int A_4)
		{
			byte[] array = null;
			if (A_2)
			{
				array = this.a(A_3, A_4);
				if (!A_0 && !A_1)
				{
					return array;
				}
			}
			if (A_0)
			{
				if (array == null)
				{
					if (((int)this.e[this.f] << 8 | (int)this.e[this.f + 1]) % 31 != 0)
					{
						A_0 = false;
					}
				}
				else if (((int)array[0] << 8 | (int)array[1]) % 31 != 0)
				{
					A_0 = false;
				}
			}
			byte[] result;
			if (A_0)
			{
				this.e();
				za za = new za();
				int num = A_3;
				if (array != null)
				{
					za.a(array, 0, array.Length);
				}
				else if (this.f + num < this.e.Length)
				{
					za.a(this.e, this.f, num);
					num = 0;
				}
				else
				{
					za.a(this.e, this.f, this.e.Length - this.f);
					num -= this.e.Length - this.f;
				}
				this.l = za.b(this.k);
				while (num > 0 || this.l == this.k.Length)
				{
					if (this.l == 16384)
					{
						this.d();
						this.l = 0;
					}
					if (za.f() && num > 0)
					{
						this.q();
						if (num < this.e.Length)
						{
							za.a(this.e, 0, num);
							num = 0;
						}
						else
						{
							za.a(this.e);
							num -= this.e.Length;
						}
					}
					int num2 = za.b(this.k, this.l, 16384 - this.l);
					this.l += num2;
					if (num2 < 1)
					{
						break;
					}
				}
				result = this.a(A_4);
			}
			else if (A_1)
			{
				zd zd;
				if (this.f + A_3 < this.e.Length)
				{
					zd = new zd(this.e, this.f, A_3 * 4);
				}
				else
				{
					zd = new zd(this.e, this.f, A_3 * 4);
				}
				byte[] array2 = new byte[zd.e() + A_4];
				Array.Copy(zd.d(), array2, zd.e());
				result = array2;
			}
			else
			{
				byte[] array2 = new byte[A_3 + A_4];
				if (this.f + A_3 < this.e.Length)
				{
					Array.Copy(this.e, this.f, array2, 0, A_3);
				}
				else
				{
					int num3 = this.e.Length - this.f;
					int i = A_3 - num3;
					Array.Copy(this.e, this.f, array2, 0, num3);
					while (i > this.e.Length)
					{
						this.q();
						Array.Copy(this.e, 0, array2, num3, this.e.Length);
						i -= this.e.Length;
						num3 += this.e.Length;
					}
					this.q();
					Array.Copy(this.e, 0, array2, num3, i);
				}
				result = array2;
			}
			return result;
		}

		// Token: 0x06003371 RID: 13169 RVA: 0x001C9590 File Offset: 0x001C8590
		private byte[] a(int A_0, int A_1)
		{
			byte[] array = new byte[(int)((float)A_0 * 0.8f + 4f)];
			while (this.e[this.f] <= 32)
			{
				this.o();
			}
			int num = 0;
			while (this.e[this.f] != 126)
			{
				if (this.e[this.f] == 122)
				{
					this.b(array, ref num);
				}
				else if (!this.a(array, ref num))
				{
					break;
				}
			}
			byte[] array2 = new byte[num + A_1];
			Array.Copy(array, array2, num);
			return array2;
		}

		// Token: 0x06003372 RID: 13170 RVA: 0x001C9644 File Offset: 0x001C8644
		private void b(byte[] A_0, ref int A_1)
		{
			A_0[A_1++] = 0;
			A_0[A_1++] = 0;
			A_0[A_1++] = 0;
			A_0[A_1++] = 0;
			this.o();
			while (this.e[this.f] <= 32)
			{
				this.o();
			}
		}

		// Token: 0x06003373 RID: 13171 RVA: 0x001C96AC File Offset: 0x001C86AC
		private bool a(byte[] A_0, ref int A_1)
		{
			int num = 1;
			uint num2 = (uint)(this.e[this.f] - 33) * 52200625U;
			this.o();
			while (this.e[this.f] <= 32)
			{
				this.o();
			}
			num2 += (uint)(this.e[this.f] - 33) * 614125U;
			this.o();
			while (this.e[this.f] <= 32)
			{
				this.o();
			}
			bool result;
			if (this.e[this.f] == 126)
			{
				this.a(A_0, ref A_1, num2, num);
				while (this.e[this.f] <= 32)
				{
					this.o();
				}
				result = false;
			}
			else
			{
				num++;
				num2 += (uint)(this.e[this.f] - 33) * 7225U;
				this.o();
				while (this.e[this.f] <= 32)
				{
					this.o();
				}
				if (this.e[this.f] == 126)
				{
					this.a(A_0, ref A_1, num2, num);
					while (this.e[this.f] <= 32)
					{
						this.o();
					}
					result = false;
				}
				else
				{
					num++;
					num2 += (uint)((this.e[this.f] - 33) * 85);
					this.o();
					while (this.e[this.f] <= 32)
					{
						this.o();
					}
					if (this.e[this.f] == 126)
					{
						this.a(A_0, ref A_1, num2, num);
						while (this.e[this.f] <= 32)
						{
							this.o();
						}
						result = false;
					}
					else
					{
						num++;
						num2 += (uint)(this.e[this.f] - 33);
						this.o();
						this.a(A_0, ref A_1, num2, num);
						while (this.e[this.f] <= 32)
						{
							this.o();
						}
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06003374 RID: 13172 RVA: 0x001C98F4 File Offset: 0x001C88F4
		private void a(byte[] A_0, ref int A_1, uint A_2, int A_3)
		{
			if (A_3 == 1)
			{
				A_2 += 614125U;
			}
			if (A_3 == 2)
			{
				A_2 += 7225U;
			}
			if (A_3 == 3)
			{
				A_2 += 85U;
			}
			A_0[A_1++] = (byte)((A_2 & 4278190080U) >> 24);
			if (A_3 != 1)
			{
				A_0[A_1++] = (byte)((A_2 & 16711680U) >> 16);
				if (A_3 != 2)
				{
					A_0[A_1++] = (byte)((A_2 & 65280U) >> 8);
					if (A_3 != 3)
					{
						A_0[A_1++] = (byte)(A_2 & 255U);
					}
				}
			}
		}

		// Token: 0x06003375 RID: 13173 RVA: 0x001C99BC File Offset: 0x001C89BC
		internal byte[] j(int A_0)
		{
			byte[] result;
			if (A_0 + this.f > this.e.Length)
			{
				result = this.k(A_0);
			}
			else
			{
				byte[] array = new byte[A_0];
				Array.Copy(this.e, this.f, array, 0, A_0);
				result = array;
			}
			return result;
		}

		// Token: 0x06003376 RID: 13174 RVA: 0x001C9A10 File Offset: 0x001C8A10
		internal byte[] k(int A_0)
		{
			byte[] array = new byte[A_0];
			int num = this.e.Length - this.f;
			Array.Copy(this.e, this.f, array, 0, num);
			do
			{
				this.q();
				if (num + this.e.Length > A_0)
				{
					int num2 = A_0 - num;
					Array.Copy(this.e, 0, array, num, num2);
					num += num2;
				}
				else
				{
					Array.Copy(this.e, 0, array, num, this.e.Length);
					num += this.e.Length;
				}
			}
			while (num < A_0);
			return array;
		}

		// Token: 0x06003377 RID: 13175 RVA: 0x001C9AB8 File Offset: 0x001C8AB8
		internal int aa()
		{
			return this.b.b();
		}

		// Token: 0x06003378 RID: 13176 RVA: 0x001C9AD8 File Offset: 0x001C8AD8
		private void c()
		{
			int i = 0;
			while (i < 32)
			{
				while (this.e[this.f] != 102)
				{
					if (i > 32)
					{
						throw new PdfParsingException("Invalid PDF File. Cross-reference table not found.");
					}
					this.p();
					i++;
				}
				this.p();
				i++;
				if (this.e[this.f] == 101)
				{
					this.p();
					i++;
					if (this.e[this.f] == 114)
					{
						this.p();
						i++;
						if (this.e[this.f] == 120)
						{
							this.p();
							i++;
							if (this.e[this.f] == 116)
							{
								this.p();
								i++;
								if (this.e[this.f] == 114)
								{
									this.p();
									i++;
									if (this.e[this.f] == 97)
									{
										this.p();
										i++;
										if (this.e[this.f] == 116)
										{
											this.p();
											i++;
											if (this.e[this.f] == 115)
											{
												return;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			throw new PdfParsingException("Invalid PDF File. Cross-reference table not found.");
		}

		// Token: 0x06003379 RID: 13177 RVA: 0x001C9C7C File Offset: 0x001C8C7C
		private void b()
		{
			int num = 0;
			while (this.ac() > 10L)
			{
				while (this.e[this.f] != 70)
				{
					if (this.ac() < 10L)
					{
						throw new PdfParsingException("Invalid PDF File. %%EOF not found.");
					}
					this.p();
					num++;
				}
				this.p();
				num++;
				if (this.e[this.f] == 79)
				{
					this.p();
					num++;
					if (this.e[this.f] == 69)
					{
						this.p();
						num++;
						if (this.e[this.f] == 37)
						{
							this.p();
							num++;
							if (this.e[this.f] == 37)
							{
								return;
							}
						}
					}
				}
			}
			throw new PdfParsingException("Invalid PDF File. %%EOF not found.");
		}

		// Token: 0x0600337A RID: 13178 RVA: 0x001C9D8C File Offset: 0x001C8D8C
		internal void ab()
		{
			if (this.c.d() != this.b.a())
			{
				this.a(this.b.c());
			}
			this.f = this.e.Length - 1;
			this.b();
			this.c();
			base.af().m().b().Add(this.ac());
			this.e(9);
			while (this.e[this.f] <= 32)
			{
				this.o();
			}
			int num = this.z();
			this.b((long)num);
		}

		// Token: 0x0600337B RID: 13179 RVA: 0x001C9E3E File Offset: 0x001C8E3E
		internal void b(long A_0)
		{
			this.a(A_0);
			base.af().m().b().Add(A_0);
			this.s();
		}

		// Token: 0x0600337C RID: 13180 RVA: 0x001C9E68 File Offset: 0x001C8E68
		internal long ac()
		{
			return (long)this.c.d() * 16384L + (long)this.f;
		}

		// Token: 0x0600337D RID: 13181 RVA: 0x001C9E98 File Offset: 0x001C8E98
		internal long ad()
		{
			long num = 0L;
			while (this.e[this.f] == 48)
			{
				this.o();
			}
			while (this.e[this.f] >= 48 && this.e[this.f] <= 57)
			{
				num = num * 10L + (long)((ulong)this.e[this.f]) - 48L;
				this.o();
			}
			this.e(7);
			if (this.e[this.f] != 110)
			{
				num = -1L;
			}
			this.e(2);
			while (this.e[this.f] < 48)
			{
				this.o();
			}
			return num;
		}

		// Token: 0x0600337E RID: 13182 RVA: 0x001C9F68 File Offset: 0x001C8F68
		internal void ae()
		{
			this.e(19);
			while (this.e[this.f] < 48)
			{
				this.o();
			}
		}

		// Token: 0x0600337F RID: 13183 RVA: 0x001C9FA0 File Offset: 0x001C8FA0
		private void a()
		{
			while (this.j[this.h] <= 32)
			{
				this.r();
			}
			if (this.j[this.h] == 37)
			{
				this.r();
				while (this.j[this.h] != 10 && this.j[this.h] != 13)
				{
					this.r();
				}
				this.a();
			}
		}

		// Token: 0x0400186F RID: 6255
		private const int a = 16384;

		// Token: 0x04001870 RID: 6256
		private agp b;

		// Token: 0x04001871 RID: 6257
		private agy c = null;

		// Token: 0x04001872 RID: 6258
		private agy d = null;

		// Token: 0x04001873 RID: 6259
		private byte[] e = null;

		// Token: 0x04001874 RID: 6260
		private int f;

		// Token: 0x04001875 RID: 6261
		private int g;

		// Token: 0x04001876 RID: 6262
		private int h = 0;

		// Token: 0x04001877 RID: 6263
		private short i = 0;

		// Token: 0x04001878 RID: 6264
		private byte[] j = null;

		// Token: 0x04001879 RID: 6265
		private byte[] k = null;

		// Token: 0x0400187A RID: 6266
		private int l = 0;

		// Token: 0x0400187B RID: 6267
		private List<byte[]> m = null;
	}
}
