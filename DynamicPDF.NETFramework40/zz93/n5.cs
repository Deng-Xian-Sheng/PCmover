using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200021F RID: 543
	internal class n5 : lj
	{
		// Token: 0x06001976 RID: 6518 RVA: 0x0010C8B4 File Offset: 0x0010B8B4
		internal n5()
		{
			this.a = new l4();
			this.s = new m0();
			this.b = gu.a;
			this.c = gp.b;
			this.j = f3.a;
			this.k = gs.a;
			this.d = Color.d("black");
			this.e[0] = gx.a;
			this.f = gn.a;
			this.g = i1.a;
			this.h = gf.e;
			this.i = gf.e;
			this.l = new x5?(x5.c());
			this.m = new x5?(x5.c());
			this.n = new x5?(x5.c());
			this.o = new my();
			this.p = new x5?(x5.c());
			this.q = null;
			this.aa = null;
			this.ab = i2.a;
			this.ac = i2.a;
			this.ad = i2.a;
		}

		// Token: 0x06001977 RID: 6519 RVA: 0x0010CA2C File Offset: 0x0010BA2C
		internal override int[] ds()
		{
			return lj.c();
		}

		// Token: 0x06001978 RID: 6520 RVA: 0x0010CA44 File Offset: 0x0010BA44
		internal override void dt(int A_0, fd A_1)
		{
			if (A_0 <= 272801619)
			{
				if (A_0 <= 40160150)
				{
					if (A_0 <= 6968946)
					{
						if (A_0 != 6947816)
						{
							if (A_0 == 6968946)
							{
								this.r = (hd)A_1;
								this.a.a(this.r.a());
								this.a.a(false);
							}
						}
						else
						{
							this.t = (hq)A_1;
							this.s.a(this.t.a());
						}
					}
					else if (A_0 != 24798759)
					{
						if (A_0 != 31536467)
						{
							if (A_0 == 40160150)
							{
								this.b = ((i8)A_1).a().a();
							}
						}
						else
						{
							this.i = ((hz)A_1).a().a();
						}
					}
				}
				else if (A_0 <= 136941815)
				{
					if (A_0 != 67814465)
					{
						if (A_0 == 136941815)
						{
							this.j = ((hf)A_1).a().a();
						}
					}
					else
					{
						this.c = ((gy)A_1).a().a();
					}
				}
				else if (A_0 != 189525969)
				{
					if (A_0 != 202920309)
					{
						if (A_0 == 272801619)
						{
							this.h = ((hy)A_1).a().a();
						}
					}
					else
					{
						this.k = ((i5)A_1).a().c();
						if (this.k == gs.j || this.k == gs.k)
						{
							this.m = new x5?(((i5)A_1).a().b());
						}
					}
				}
				else if (!((hn)A_1).a().a())
				{
					gm gm = ((hn)A_1).a();
					this.l = new x5?(gm.c());
					this.ac = gm.e();
				}
			}
			else if (A_0 <= 633671921)
			{
				if (A_0 <= 562197724)
				{
					if (A_0 != 510035525)
					{
						if (A_0 != 562197724)
						{
						}
					}
					else if (((iv)A_1).a() != null)
					{
						string text = ((iv)A_1).a().a();
						if (text.StartsWith("rgb"))
						{
							text = Regex.Replace(text, "\\s+", "");
							bool flag = text.Contains("%");
							string text2 = text.Substring(text.IndexOf('(') + 1, text.Length - (text.IndexOf('(') + 1) - 1);
							string[] array = text2.Split(new char[]
							{
								','
							});
							if (array.Length == 3)
							{
								float[] array2 = new float[array.Length];
								switch (flag)
								{
								case false:
									for (int i = 0; i < array.Length; i++)
									{
										array2[i] = float.Parse(array[i].Trim()) / 255f;
									}
									break;
								case true:
									for (int i = 0; i < array.Length; i++)
									{
										array2[i] = 255f * (float.Parse(array[i].Trim(new char[]
										{
											' ',
											'%'
										})) / 100f);
										array2[i] /= 255f;
									}
									break;
								}
								string a_ = string.Concat(new string[]
								{
									"rgb(",
									array2[0].ToString(),
									",",
									array2[1].ToString(),
									",",
									array2[2].ToString(),
									")"
								});
								this.d = Color.d(a_);
							}
						}
						else
						{
							this.d = Color.d(text);
						}
						this.u = false;
					}
				}
				else if (A_0 != 562205895)
				{
					if (A_0 != 587060291)
					{
						if (A_0 == 633671921)
						{
							int num = ((iw)A_1).a().Length;
							this.e = new gx[num];
							for (int i = 0; i < num; i++)
							{
								if (((iw)A_1).a()[i] != null)
								{
									this.e[i] = ((iw)A_1).a()[i].a();
									this.w = false;
								}
							}
						}
					}
					else if (!((jb)A_1).a().a())
					{
						gm gm2 = ((jb)A_1).a();
						this.n = new x5?(gm2.c());
						this.ad = gm2.e();
					}
				}
			}
			else if (A_0 <= 1688661191)
			{
				if (A_0 != 1652275116)
				{
					if (A_0 == 1688661191)
					{
						if (!((he)A_1).a().a())
						{
							this.p = new x5?(((he)A_1).a().b());
						}
					}
				}
				else
				{
					this.o.a((ho)A_1);
				}
			}
			else if (A_0 != 1982853278)
			{
				if (A_0 != 1982903832)
				{
					if (A_0 == 2098498396)
					{
						this.g = ((iz)A_1).a().a();
					}
				}
				else
				{
					this.f = ((it)A_1).a().a();
					this.v = false;
				}
			}
			else
			{
				this.q = new x5?(((iy)A_1).a().b());
				this.ab = ((iy)A_1).a().c();
			}
		}

		// Token: 0x06001979 RID: 6521 RVA: 0x0010D0A4 File Offset: 0x0010C0A4
		internal new l4 a()
		{
			return this.a;
		}

		// Token: 0x0600197A RID: 6522 RVA: 0x0010D0BC File Offset: 0x0010C0BC
		internal new void a(l4 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600197B RID: 6523 RVA: 0x0010D0C8 File Offset: 0x0010C0C8
		internal new m0 b()
		{
			return this.s;
		}

		// Token: 0x0600197C RID: 6524 RVA: 0x0010D0E0 File Offset: 0x0010C0E0
		internal new void a(m0 A_0)
		{
			this.s = A_0;
		}

		// Token: 0x0600197D RID: 6525 RVA: 0x0010D0EC File Offset: 0x0010C0EC
		internal new gu c()
		{
			return this.b;
		}

		// Token: 0x0600197E RID: 6526 RVA: 0x0010D104 File Offset: 0x0010C104
		internal new void a(gu A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600197F RID: 6527 RVA: 0x0010D110 File Offset: 0x0010C110
		internal new gp d()
		{
			return this.c;
		}

		// Token: 0x06001980 RID: 6528 RVA: 0x0010D128 File Offset: 0x0010C128
		internal new void a(gp A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001981 RID: 6529 RVA: 0x0010D134 File Offset: 0x0010C134
		internal new f3 e()
		{
			return this.j;
		}

		// Token: 0x06001982 RID: 6530 RVA: 0x0010D14C File Offset: 0x0010C14C
		internal new void a(f3 A_0)
		{
			this.j = A_0;
		}

		// Token: 0x06001983 RID: 6531 RVA: 0x0010D158 File Offset: 0x0010C158
		internal new x5? f()
		{
			return this.l;
		}

		// Token: 0x06001984 RID: 6532 RVA: 0x0010D170 File Offset: 0x0010C170
		internal new void a(x5? A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06001985 RID: 6533 RVA: 0x0010D17C File Offset: 0x0010C17C
		internal new i2 g()
		{
			return this.ac;
		}

		// Token: 0x06001986 RID: 6534 RVA: 0x0010D194 File Offset: 0x0010C194
		internal new void a(i2 A_0)
		{
			this.ac = A_0;
		}

		// Token: 0x06001987 RID: 6535 RVA: 0x0010D1A0 File Offset: 0x0010C1A0
		internal new gs h()
		{
			return this.k;
		}

		// Token: 0x06001988 RID: 6536 RVA: 0x0010D1B8 File Offset: 0x0010C1B8
		internal new void a(gs A_0)
		{
			this.k = A_0;
		}

		// Token: 0x06001989 RID: 6537 RVA: 0x0010D1C4 File Offset: 0x0010C1C4
		internal new x5? i()
		{
			return this.m;
		}

		// Token: 0x0600198A RID: 6538 RVA: 0x0010D1DC File Offset: 0x0010C1DC
		internal new void b(x5? A_0)
		{
			this.m = A_0;
		}

		// Token: 0x0600198B RID: 6539 RVA: 0x0010D1E8 File Offset: 0x0010C1E8
		internal new Color j()
		{
			return this.d;
		}

		// Token: 0x0600198C RID: 6540 RVA: 0x0010D200 File Offset: 0x0010C200
		internal new void a(Color A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600198D RID: 6541 RVA: 0x0010D20C File Offset: 0x0010C20C
		internal new x5? k()
		{
			return this.n;
		}

		// Token: 0x0600198E RID: 6542 RVA: 0x0010D224 File Offset: 0x0010C224
		internal new void c(x5? A_0)
		{
			this.n = A_0;
		}

		// Token: 0x0600198F RID: 6543 RVA: 0x0010D230 File Offset: 0x0010C230
		internal new i2 l()
		{
			return this.ad;
		}

		// Token: 0x06001990 RID: 6544 RVA: 0x0010D248 File Offset: 0x0010C248
		internal new void b(i2 A_0)
		{
			this.ad = A_0;
		}

		// Token: 0x06001991 RID: 6545 RVA: 0x0010D254 File Offset: 0x0010C254
		internal new gx[] m()
		{
			return this.e;
		}

		// Token: 0x06001992 RID: 6546 RVA: 0x0010D26C File Offset: 0x0010C26C
		internal new void a(gx[] A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001993 RID: 6547 RVA: 0x0010D278 File Offset: 0x0010C278
		internal new my n()
		{
			return this.o;
		}

		// Token: 0x06001994 RID: 6548 RVA: 0x0010D290 File Offset: 0x0010C290
		internal new void a(my A_0)
		{
			this.o = A_0;
		}

		// Token: 0x06001995 RID: 6549 RVA: 0x0010D29C File Offset: 0x0010C29C
		internal new x5? o()
		{
			return this.p;
		}

		// Token: 0x06001996 RID: 6550 RVA: 0x0010D2B4 File Offset: 0x0010C2B4
		internal new void d(x5? A_0)
		{
			this.p = A_0;
		}

		// Token: 0x06001997 RID: 6551 RVA: 0x0010D2C0 File Offset: 0x0010C2C0
		internal new x5? p()
		{
			return this.q;
		}

		// Token: 0x06001998 RID: 6552 RVA: 0x0010D2D8 File Offset: 0x0010C2D8
		internal new void e(x5? A_0)
		{
			this.q = A_0;
		}

		// Token: 0x06001999 RID: 6553 RVA: 0x0010D2E4 File Offset: 0x0010C2E4
		internal new i2 q()
		{
			return this.ab;
		}

		// Token: 0x0600199A RID: 6554 RVA: 0x0010D2FC File Offset: 0x0010C2FC
		internal new void c(i2 A_0)
		{
			this.ab = A_0;
		}

		// Token: 0x0600199B RID: 6555 RVA: 0x0010D308 File Offset: 0x0010C308
		internal new gn r()
		{
			return this.f;
		}

		// Token: 0x0600199C RID: 6556 RVA: 0x0010D320 File Offset: 0x0010C320
		internal new void a(gn A_0)
		{
			this.f = A_0;
		}

		// Token: 0x0600199D RID: 6557 RVA: 0x0010D32C File Offset: 0x0010C32C
		internal new i1 s()
		{
			return this.g;
		}

		// Token: 0x0600199E RID: 6558 RVA: 0x0010D344 File Offset: 0x0010C344
		internal new void a(i1 A_0)
		{
			this.g = A_0;
		}

		// Token: 0x0600199F RID: 6559 RVA: 0x0010D350 File Offset: 0x0010C350
		internal new hd t()
		{
			return this.r;
		}

		// Token: 0x060019A0 RID: 6560 RVA: 0x0010D368 File Offset: 0x0010C368
		internal new void a(hd A_0)
		{
			this.r = A_0;
		}

		// Token: 0x060019A1 RID: 6561 RVA: 0x0010D374 File Offset: 0x0010C374
		internal new bool u()
		{
			return this.u;
		}

		// Token: 0x060019A2 RID: 6562 RVA: 0x0010D38C File Offset: 0x0010C38C
		internal new void a(bool A_0)
		{
			this.u = A_0;
		}

		// Token: 0x060019A3 RID: 6563 RVA: 0x0010D398 File Offset: 0x0010C398
		internal new bool v()
		{
			return this.v;
		}

		// Token: 0x060019A4 RID: 6564 RVA: 0x0010D3B0 File Offset: 0x0010C3B0
		internal new void b(bool A_0)
		{
			this.v = A_0;
		}

		// Token: 0x060019A5 RID: 6565 RVA: 0x0010D3BC File Offset: 0x0010C3BC
		internal new bool w()
		{
			return this.w;
		}

		// Token: 0x060019A6 RID: 6566 RVA: 0x0010D3D4 File Offset: 0x0010C3D4
		internal new void c(bool A_0)
		{
			this.w = A_0;
		}

		// Token: 0x060019A7 RID: 6567 RVA: 0x0010D3E0 File Offset: 0x0010C3E0
		internal new bool x()
		{
			return this.z;
		}

		// Token: 0x060019A8 RID: 6568 RVA: 0x0010D3F8 File Offset: 0x0010C3F8
		internal new void d(bool A_0)
		{
			this.z = A_0;
		}

		// Token: 0x060019A9 RID: 6569 RVA: 0x0010D404 File Offset: 0x0010C404
		internal new int y()
		{
			return this.x;
		}

		// Token: 0x060019AA RID: 6570 RVA: 0x0010D41C File Offset: 0x0010C41C
		internal new void a(int A_0)
		{
			this.x = A_0;
		}

		// Token: 0x060019AB RID: 6571 RVA: 0x0010D428 File Offset: 0x0010C428
		internal new int z()
		{
			return this.y;
		}

		// Token: 0x060019AC RID: 6572 RVA: 0x0010D440 File Offset: 0x0010C440
		internal new void b(int A_0)
		{
			this.y = A_0;
		}

		// Token: 0x060019AD RID: 6573 RVA: 0x0010D44C File Offset: 0x0010C44C
		internal new string aa()
		{
			return this.aa;
		}

		// Token: 0x060019AE RID: 6574 RVA: 0x0010D464 File Offset: 0x0010C464
		internal new void a(string A_0)
		{
			this.aa = A_0;
		}

		// Token: 0x060019AF RID: 6575 RVA: 0x0010D470 File Offset: 0x0010C470
		internal new gf ab()
		{
			return this.i;
		}

		// Token: 0x060019B0 RID: 6576 RVA: 0x0010D488 File Offset: 0x0010C488
		internal new void a(gf A_0)
		{
			this.i = A_0;
		}

		// Token: 0x060019B1 RID: 6577 RVA: 0x0010D494 File Offset: 0x0010C494
		internal new gf ac()
		{
			return this.h;
		}

		// Token: 0x060019B2 RID: 6578 RVA: 0x0010D4AC File Offset: 0x0010C4AC
		internal new void b(gf A_0)
		{
			this.h = A_0;
		}

		// Token: 0x060019B3 RID: 6579 RVA: 0x0010D4B8 File Offset: 0x0010C4B8
		internal new List<string> ad()
		{
			return this.ae;
		}

		// Token: 0x060019B4 RID: 6580 RVA: 0x0010D4D0 File Offset: 0x0010C4D0
		internal new void a(List<string> A_0)
		{
			this.ae = A_0;
		}

		// Token: 0x060019B5 RID: 6581 RVA: 0x0010D4DC File Offset: 0x0010C4DC
		internal override lj du()
		{
			n5 n = new n5();
			n.a(this.a().p());
			n.a(this.t());
			n.a(this.b().d());
			n.a(this.c());
			n.a(this.e());
			n.a(this.d());
			n.a(this.h());
			n.b(this.i());
			n.a(this.j());
			n.a(this.u());
			n.a(this.m());
			n.c(this.w());
			n.a(this.r());
			n.b(this.v());
			n.a(this.s());
			n.a(this.f());
			n.c(this.k());
			n.a(this.n().e());
			n.d(this.o());
			n.e(this.p());
			n.a(this.y());
			n.b(this.z());
			n.a(this.aa());
			n.d(this.x());
			n.b(this.ac());
			n.a(this.ab());
			return n;
		}

		// Token: 0x04000B95 RID: 2965
		private new l4 a;

		// Token: 0x04000B96 RID: 2966
		private new gu b;

		// Token: 0x04000B97 RID: 2967
		private new gp c;

		// Token: 0x04000B98 RID: 2968
		private new Color d;

		// Token: 0x04000B99 RID: 2969
		private new gx[] e = new gx[1];

		// Token: 0x04000B9A RID: 2970
		private new gn f;

		// Token: 0x04000B9B RID: 2971
		private new i1 g;

		// Token: 0x04000B9C RID: 2972
		private new gf h;

		// Token: 0x04000B9D RID: 2973
		private new gf i;

		// Token: 0x04000B9E RID: 2974
		private new f3 j;

		// Token: 0x04000B9F RID: 2975
		private new gs k;

		// Token: 0x04000BA0 RID: 2976
		private new x5? l = null;

		// Token: 0x04000BA1 RID: 2977
		private new x5? m = null;

		// Token: 0x04000BA2 RID: 2978
		private new x5? n = null;

		// Token: 0x04000BA3 RID: 2979
		private new my o;

		// Token: 0x04000BA4 RID: 2980
		private new x5? p = null;

		// Token: 0x04000BA5 RID: 2981
		private new x5? q;

		// Token: 0x04000BA6 RID: 2982
		private new hd r;

		// Token: 0x04000BA7 RID: 2983
		private new m0 s;

		// Token: 0x04000BA8 RID: 2984
		private new hq t;

		// Token: 0x04000BA9 RID: 2985
		private new bool u = true;

		// Token: 0x04000BAA RID: 2986
		private new bool v = true;

		// Token: 0x04000BAB RID: 2987
		private new bool w = true;

		// Token: 0x04000BAC RID: 2988
		private new int x = 1;

		// Token: 0x04000BAD RID: 2989
		private new int y = 1;

		// Token: 0x04000BAE RID: 2990
		private new bool z = false;

		// Token: 0x04000BAF RID: 2991
		private new string aa;

		// Token: 0x04000BB0 RID: 2992
		private new i2 ab = i2.a;

		// Token: 0x04000BB1 RID: 2993
		private new i2 ac = i2.a;

		// Token: 0x04000BB2 RID: 2994
		private new i2 ad = i2.a;

		// Token: 0x04000BB3 RID: 2995
		private new List<string> ae = new List<string>();
	}
}
