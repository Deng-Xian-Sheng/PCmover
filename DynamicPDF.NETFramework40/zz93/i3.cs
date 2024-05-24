using System;

namespace zz93
{
	// Token: 0x02000167 RID: 359
	internal abstract class i3
	{
		// Token: 0x06000D1B RID: 3355 RVA: 0x000966E8 File Offset: 0x000956E8
		private static float f(kz A_0)
		{
			float result = 12f;
			for (kz kz = A_0.dr(); kz != null; kz = kz.dr())
			{
				if (kz.dy())
				{
					result = x5.b(((n5)kz.db()).a().i());
					break;
				}
			}
			return result;
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x0009674C File Offset: 0x0009574C
		private static x5 a(float A_0)
		{
			x5 result;
			if (A_0 < 8f)
			{
				result = x5.a(7.5);
			}
			else if (A_0 < 10f)
			{
				result = x5.a(10f);
			}
			else if (A_0 < 12f)
			{
				result = x5.a(12f);
			}
			else if (A_0 < 14f)
			{
				result = x5.a(13.5);
			}
			else if (A_0 < 18f)
			{
				result = x5.a(18f);
			}
			else if (A_0 < 24f)
			{
				result = x5.a(24f);
			}
			else if (A_0 < 36f)
			{
				result = x5.a(36f);
			}
			else if (A_0 < 54f)
			{
				result = x5.a(54f);
			}
			else
			{
				result = x5.a(82f);
			}
			return result;
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x0009685C File Offset: 0x0009585C
		private static fb<f5>[] a(fb<f5>[] A_0)
		{
			fb<f5>[] array = new fb<f5>[]
			{
				new fb<f5>(20835613, null),
				new fb<f5>(144877216, null),
				new fb<f5>(791474706, null),
				new fb<f5>(2163680, null),
				new fb<f5>(1652275116, null),
				new fb<f5>(675106854, null)
			};
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < A_0.Length; j++)
				{
					if (array[i].a() == A_0[j].a())
					{
						array[i].a(A_0[j].a());
						array[i].a(A_0[j].b());
					}
				}
			}
			return array;
		}

		// Token: 0x06000D1E RID: 3358 RVA: 0x00096984 File Offset: 0x00095984
		private static hd b(kz A_0, x5 A_1)
		{
			n5 n = (n5)A_0.db();
			hd hd = new hd();
			fb<f5>[] array = new fb<f5>[6];
			if (n.a().a())
			{
				array[0] = new fb<f5>(2163680, new af0(A_1));
				n.a().a(A_1);
				n.a().a(i2.d);
				hd.cu(false);
			}
			else
			{
				array = i3.a(n.t().a());
				if (n.a().d())
				{
					array[3].a(new af0(A_1));
					n.a().a(A_1);
					n.a().a(i2.d);
				}
				else if (!A_0.dy())
				{
					float num = x5.b(((n5)A_0.dr().db()).a().i());
					int num2 = A_0.dg();
					if (num2 <= 137440)
					{
						if (num2 == 46073)
						{
							A_1 = x5.a(num + x5.b(A_1) * 0.6667f);
							goto IL_161;
						}
						if (num2 != 137440)
						{
							goto IL_161;
						}
					}
					else if (num2 != 235744 && num2 != 681579872)
					{
						goto IL_161;
					}
					A_1 = x5.a(num * 0.75f);
					IL_161:
					array[3].a(new af0(A_1));
					n.a().a(A_1);
					n.a().a(i2.d);
				}
			}
			hd.a(array);
			i3.a(hd);
			return hd;
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x00096B38 File Offset: 0x00095B38
		private static hd a(kz A_0, f4 A_1)
		{
			n5 n = (n5)A_0.db();
			hd hd = new hd();
			fb<f5>[] array = new fb<f5>[6];
			if (n.a().a())
			{
				array[0] = new fb<f5>(144877216, new af1(A_1));
				hd.cu(false);
			}
			else
			{
				array = i3.a(n.t().a());
				if (n.a().e() || !A_0.c2())
				{
					array[1].a(new af1(A_1));
				}
			}
			hd.a(array);
			i3.a(hd);
			n.a().a(A_1);
			return hd;
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x00096C04 File Offset: 0x00095C04
		private static hd a(kz A_0, string A_1)
		{
			n5 n = (n5)A_0.db();
			hd hd = new hd();
			fb<f5>[] array = new fb<f5>[6];
			if (n.a().a())
			{
				array[0] = new fb<f5>(675106854, new afy(A_1));
				hd.cu(false);
			}
			else
			{
				array = i3.a(n.t().a());
				array[5].a(new afy(A_1));
			}
			hd.a(array);
			n.a().a(A_1);
			if (A_0.dg() == 23684646)
			{
				n.a().b(false);
			}
			i3.a(hd);
			return hd;
		}

		// Token: 0x06000D21 RID: 3361 RVA: 0x00096CD4 File Offset: 0x00095CD4
		private static hd e(kz A_0)
		{
			n5 n = (n5)A_0.db();
			hd hd = new hd();
			fb<f5>[] array = new fb<f5>[6];
			if (n.a().a())
			{
				array[0] = new fb<f5>(791474706, new af3(f7.k));
				hd.cu(false);
				n.a().a(f7.k);
			}
			else
			{
				array = i3.a(n.t().a());
				if (n.a().c() || !A_0.c2())
				{
					int num = (int)n.a().h();
					if ((num > 200 && num < 700) || num == 0 || num == 4)
					{
						array[2].a(new af3(f7.k));
						n.a().a(f7.k);
					}
				}
			}
			hd.a(array);
			i3.a(hd);
			return hd;
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x00096DF4 File Offset: 0x00095DF4
		private static hd d(kz A_0)
		{
			n5 n = (n5)A_0.db();
			hd hd = new hd();
			fb<f5>[] array = new fb<f5>[6];
			if (n.a().a())
			{
				array[0] = new fb<f5>(791474706, new af3(f7.k));
				hd.cu(false);
				n.a().a(f7.k);
			}
			else
			{
				array = i3.a(n.t().a());
				if (n.a().c())
				{
					array[2].a(new af3(f7.k));
					n.a().a(f7.k);
				}
			}
			hd.a(array);
			i3.a(hd);
			return hd;
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x00096ED4 File Offset: 0x00095ED4
		private static hd a(kz A_0, x5 A_1)
		{
			hd hd = new hd();
			n5 n = (n5)A_0.db();
			fb<f5>[] array = new fb<f5>[6];
			float num = x5.b(((n5)A_0.dr().db()).a().i());
			if (n.a().d())
			{
				n.a().a(A_1);
				n.a().a(f7.k);
				af0 af = new af0(A_1);
				af.a(i2.d);
				array[0] = new fb<f5>(2163680, af);
				array[1] = new fb<f5>(791474706, new af3(f7.k));
				hd.cu(false);
			}
			else if (n.a().k() == mw.b)
			{
				if (A_0.c2())
				{
					A_1 = x5.a(num * (x5.b(n.a().o()) / 100f));
				}
				n.a().a(A_1);
				n.a().a(mw.a);
				n.a().a(i2.d);
				n.a().a(f7.k);
				af0 af = new af0(A_1);
				af.a(i2.d);
				array[0] = new fb<f5>(2163680, af);
				array[1] = new fb<f5>(791474706, new af3(f7.k));
				hd.cu(false);
			}
			else if (!A_0.dy())
			{
				int num2 = A_0.dg();
				if (num2 <= 879)
				{
					if (num2 != 431)
					{
						if (num2 != 687)
						{
							if (num2 == 879)
							{
								n.a().a(x5.a(num * 2f));
							}
						}
						else
						{
							n.a().a(x5.a(num + num * 0f));
						}
					}
					else
					{
						n.a().a(x5.a(num - num * 0f));
					}
				}
				else if (num2 != 3119)
				{
					if (num2 != 3375)
					{
						if (num2 == 3567)
						{
							n.a().a(x5.a(num - num * 0f));
						}
					}
				}
				else
				{
					n.a().a(x5.a(num + num / 2f));
				}
				n.a().a(i2.d);
				n.a().a(f7.k);
				array[1] = new fb<f5>(791474706, new af3(f7.k));
				hd.cu(false);
			}
			else if (n.a().c())
			{
				n.a().a(f7.k);
				array[0] = new fb<f5>(791474706, new af3(f7.k));
				hd.cu(false);
			}
			hd.a(array);
			return hd;
		}

		// Token: 0x06000D24 RID: 3364 RVA: 0x00097220 File Offset: 0x00096220
		private static hd c(kz A_0)
		{
			hd hd = new hd();
			n5 n = (n5)A_0.db();
			fb<f5>[] array = new fb<f5>[6];
			bool flag = false;
			if (n.a().b())
			{
				n.a().a("Courier New");
				array[0] = new fb<f5>(675106854, new afy("Courier New"));
				flag = true;
			}
			if (n.a().d())
			{
				n.a().a(x5.a(10f));
				af0 af = new af0(n.a().i());
				af.a(i2.d);
				if (flag)
				{
					array[1] = new fb<f5>(2163680, af);
				}
				else
				{
					array[0] = new fb<f5>(2163680, af);
				}
				flag = true;
			}
			hd result;
			if (flag)
			{
				hd.a(array);
				result = hd;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000D25 RID: 3365 RVA: 0x00097338 File Offset: 0x00096338
		private static void a(kz A_0, x5 A_1, string A_2)
		{
			n5 n = (n5)A_0.db();
			if (!A_0.c2())
			{
				if (n.a().d())
				{
					n.a().a(A_1);
				}
				if (n.a().b())
				{
					n.a().a(A_2);
				}
			}
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x0009739C File Offset: 0x0009639C
		private static void a(hd A_0)
		{
			bool a_ = true;
			for (int i = 0; i < A_0.a().Length; i++)
			{
				if (A_0.a()[i].b() == null)
				{
					A_0.a()[i].a(0);
					a_ = false;
				}
			}
			A_0.cu(a_);
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x00097400 File Offset: 0x00096400
		internal static hd b(kz A_0)
		{
			int num = A_0.dg();
			string text;
			if (num > 46073)
			{
				x5 a_;
				if (num <= 2204613)
				{
					if (num <= 154805)
					{
						if (num == 122967)
						{
							goto IL_18B;
						}
						if (num != 137440)
						{
							if (num != 154805)
							{
								goto IL_2A8;
							}
							goto IL_18B;
						}
					}
					else
					{
						if (num == 220754)
						{
							goto IL_198;
						}
						if (num != 235744)
						{
							if (num != 2204613)
							{
								goto IL_2A8;
							}
							goto IL_18B;
						}
					}
				}
				else if (num <= 23684646)
				{
					if (num == 2315845 || num == 8736864)
					{
						goto IL_198;
					}
					if (num != 23684646)
					{
						goto IL_2A8;
					}
					text = "monospace";
					return i3.a(A_0, text);
				}
				else if (num <= 423471123)
				{
					if (num == 142298369)
					{
						goto IL_18B;
					}
					if (num != 423471123)
					{
						goto IL_2A8;
					}
					a_ = x5.a(11f);
					text = "arial";
					i3.a(A_0, a_, text);
					goto IL_2A8;
				}
				else
				{
					if (num == 627435190)
					{
						return i3.d(A_0);
					}
					if (num != 681579872)
					{
						goto IL_2A8;
					}
				}
				a_ = x5.a(hd.m);
				return i3.b(A_0, a_);
			}
			if (num <= 1352)
			{
				if (num <= 431)
				{
					if (num != 15)
					{
						if (num == 57)
						{
							return i3.e(A_0);
						}
						if (num != 431)
						{
							goto IL_2A8;
						}
						x5 a_ = x5.a(9.96);
						return i3.a(A_0, a_);
					}
				}
				else
				{
					if (num == 687)
					{
						x5 a_ = x5.a(14.04);
						return i3.a(A_0, a_);
					}
					if (num == 879)
					{
						x5 a_ = x5.a(24f);
						return i3.a(A_0, a_);
					}
					if (num != 1352)
					{
						goto IL_2A8;
					}
				}
			}
			else if (num <= 3375)
			{
				if (num == 1690)
				{
					goto IL_198;
				}
				x5 a_;
				if (num == 3119)
				{
					a_ = x5.a(18f);
					return i3.a(A_0, a_);
				}
				if (num != 3375)
				{
					goto IL_2A8;
				}
				a_ = x5.a(12f);
				return i3.a(A_0, a_);
			}
			else
			{
				x5 a_;
				if (num == 3567)
				{
					a_ = x5.a(8.04);
					return i3.a(A_0, a_);
				}
				if (num == 34721)
				{
					return i3.c(A_0);
				}
				if (num != 46073)
				{
					goto IL_2A8;
				}
				a_ = x5.a(13.5);
				return i3.b(A_0, a_);
			}
			IL_18B:
			return i3.a(A_0, f4.b);
			IL_198:
			text = "monospace";
			return i3.a(A_0, text);
			IL_2A8:
			return null;
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x000976BC File Offset: 0x000966BC
		internal static void a(kz A_0)
		{
			n5 n = (n5)A_0.db();
			x5 a_ = (A_0.dr() != null) ? ((n5)A_0.dr().db()).a().i() : x5.a(12f);
			if (A_0.dy())
			{
				i2 i = n.a().j();
				if (i != i2.b)
				{
					switch (i)
					{
					case i2.f:
					{
						float num = i3.f(A_0);
						n.a().a(x5.a(num * x5.b(n.a().i())));
						A_0.au(false);
						goto IL_1A7;
					}
					case i2.h:
					{
						float num = i3.f(A_0);
						n.a().a(x5.a(num * (x5.b(n.a().i()) / 2f)));
						A_0.au(false);
						goto IL_1A7;
					}
					}
					if (x5.h(n.a().i(), x5.b()))
					{
						n.a().a(i3.a(x5.b(a_)));
					}
					else if (x5.h(n.a().i(), x5.a()))
					{
						n.a().a(x5.a(x5.b(a_) * 0.74f));
					}
				}
				else
				{
					float num = i3.f(A_0);
					n.a().a(x5.a(num * (x5.b(n.a().o()) / 100f)));
					A_0.au(false);
				}
				IL_1A7:
				n.a().a(i2.d);
			}
			else
			{
				int num2 = A_0.dg();
				if (num2 <= 3375)
				{
					if (num2 <= 687)
					{
						if (num2 != 431 && num2 != 687)
						{
							goto IL_293;
						}
					}
					else if (num2 != 879 && num2 != 3119 && num2 != 3375)
					{
						goto IL_293;
					}
				}
				else if (num2 <= 46073)
				{
					if (num2 != 3567 && num2 != 34721 && num2 != 46073)
					{
						goto IL_293;
					}
				}
				else if (num2 != 137440 && num2 != 235744 && num2 != 681579872)
				{
					goto IL_293;
				}
				if (n.a().k() == mw.b || n.a().j() == i2.f || n.a().j() == i2.h)
				{
					n.a().a(a_);
				}
				goto IL_2A2;
				IL_293:
				n.a().a(a_);
				IL_2A2:;
			}
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x0009796C File Offset: 0x0009696C
		internal static void a(kz A_0, ij A_1)
		{
			A_1.a(true);
			n5 n = (n5)A_0.db();
			if (n.a().d() && x5.h(n.a().i(), x5.c()))
			{
				n.a().a(x5.a(12f));
			}
			x5? x = n.n().a();
			if (x != null)
			{
				if (A_0.dt() && n.n().c() == mw.b)
				{
					x = new x5?(x5.a(x5.b(x.Value) / 100f * x5.b(n.a().i())));
					n.n().a(new x5?(x.Value));
					n.n().a(mw.a);
					ho ho = new ho();
					ho.a(new afz(x.Value));
					ho.a().b(true);
					ig a_ = new ig(new fc[]
					{
						new fc(1652275116, ho)
					});
					A_1.a(A_0.dg(), a_);
				}
				else if (n.n().c() == mw.a && n.n().d() == i2.f)
				{
					x = new x5?(x5.a(x5.b(x.Value) * x5.b(n.a().i())));
					n.n().a(new x5?(x.Value));
				}
				else if (n.n().c() == mw.a && n.n().d() == i2.h)
				{
					x = new x5?(x5.a(x5.b(x.Value) * (x5.b(n.a().i()) / 2f)));
					n.n().a(new x5?(x.Value));
				}
			}
			A_1.a(false);
		}
	}
}
