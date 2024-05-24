using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020000A1 RID: 161
	internal class @do
	{
		// Token: 0x060007B5 RID: 1973 RVA: 0x0006EBDC File Offset: 0x0006DBDC
		internal @do()
		{
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x0006EC84 File Offset: 0x0006DC84
		internal void a(abj A_0)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 39134326)
				{
					if (num <= 974)
					{
						if (num != 83)
						{
							if (num == 974)
							{
								this.d = (abe)abk.c().h6();
								this.e(this.d);
								abk.a(false);
							}
						}
						else
						{
							this.g = (abe)abk.c().h6();
							this.c(this.g);
							abk.a(false);
						}
					}
					else if (num != 61830)
					{
						if (num != 3808101)
						{
							if (num == 39134326)
							{
								this.c = (abu)abk.c().h6();
								abk.a(false);
							}
						}
						else
						{
							this.a = (ab7)abk.c().h6();
							abk.a(false);
						}
					}
					else
					{
						this.e = (abe)abk.c().h6();
						this.d(this.e);
						abk.a(false);
					}
				}
				else if (num <= 212190248)
				{
					if (num != 63591302)
					{
						if (num != 163268954)
						{
							if (num == 212190248)
							{
								this.h = (abu)abk.c().h6();
								abk.a(false);
							}
						}
						else
						{
							this.f = abk.c().h6();
							abk.a(false);
						}
					}
					else
					{
						this.b = (ab7)abk.c().h6();
						abk.a(false);
					}
				}
				else if (num != 213793473)
				{
					if (num != 264915314)
					{
						if (num == 302719132)
						{
							this.i = (abe)abk.c().h6();
							this.b(this.i);
							abk.a(false);
						}
					}
					else
					{
						abd abd = abk.c().h6();
						if (abd.hy() == ag9.g)
						{
							this.n.Add(abk.c());
						}
						else
						{
							abd a_ = abd;
							this.a(a_);
							abk.a(false);
						}
					}
				}
				else
				{
					this.j = (abe)abk.c().h6();
					this.a(this.j);
					abk.a(false);
				}
			}
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x0006EF3C File Offset: 0x0006DF3C
		private void e(abe A_0)
		{
			for (int i = 0; i < A_0.a(); i++)
			{
				this.k.Add(A_0.a(i));
			}
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0006EF74 File Offset: 0x0006DF74
		private void d(abe A_0)
		{
			for (int i = 0; i < A_0.a(); i++)
			{
				this.l.Add(A_0.a(i));
			}
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x0006EFAC File Offset: 0x0006DFAC
		private void a(abd A_0)
		{
			abe abe = (abe)A_0;
			for (int i = 0; i < abe.a(); i++)
			{
				this.n.Add(abe.a(i));
			}
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x0006EFF0 File Offset: 0x0006DFF0
		private void c(abe A_0)
		{
			for (int i = 0; i < A_0.a(); i++)
			{
				this.m.Add((abj)A_0.a(i).h6());
			}
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0006F034 File Offset: 0x0006E034
		private void b(abe A_0)
		{
			for (int i = 0; i < A_0.a(); i++)
			{
				if (A_0.hy() == ag9.e)
				{
					this.o.Add((abe)A_0.a(i).h6());
				}
				else
				{
					this.o.Add((abj)A_0.a(i).h6());
				}
			}
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0006F0AC File Offset: 0x0006E0AC
		private void a(abe A_0)
		{
			for (int i = 0; i < A_0.a(); i++)
			{
				this.p.Add((abj)A_0.a(i).h6());
			}
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0006F0EE File Offset: 0x0006E0EE
		internal void f(abe A_0)
		{
			this.q = A_0;
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0006F0F8 File Offset: 0x0006E0F8
		internal void a(DocumentWriter A_0)
		{
			if (this.q != null)
			{
				this.q.hz(A_0);
			}
			else
			{
				if (this.a != null)
				{
					A_0.WriteName(@do.r);
					this.a.hz(A_0);
				}
				if (this.b != null)
				{
					A_0.WriteName(@do.s);
					this.b.hz(A_0);
				}
				if (this.c != null)
				{
					A_0.WriteName(@do.t);
					this.c.hz(A_0);
				}
				if (this.k.Count > 0)
				{
					A_0.WriteName(@do.u);
					A_0.WriteArrayOpen();
					for (int i = 0; i < this.k.Count; i++)
					{
						((ab6)this.k[i]).hz(A_0);
					}
					A_0.WriteArrayClose();
				}
				if (this.l.Count > 0)
				{
					A_0.WriteName(@do.v);
					A_0.WriteArrayOpen();
					for (int i = 0; i < this.l.Count; i++)
					{
						((ab6)this.l[i]).hz(A_0);
					}
					A_0.WriteArrayClose();
				}
				if (this.f != null)
				{
					A_0.WriteName(@do.w);
					this.f.hz(A_0);
				}
				if (this.m.Count > 0)
				{
					A_0.WriteName(@do.y);
					A_0.WriteArrayOpen();
					for (int i = 0; i < this.m.Count; i++)
					{
						((abj)this.m[i]).hz(A_0);
					}
					A_0.WriteArrayClose();
				}
				if (this.n.Count > 0)
				{
					A_0.WriteName(@do.z);
					A_0.WriteArrayOpen();
					for (int i = 0; i < this.n.Count; i++)
					{
						((abd)this.n[i]).hz(A_0);
					}
					A_0.WriteArrayClose();
				}
				if (this.h != null)
				{
					A_0.WriteName(@do.x);
					this.h.hz(A_0);
				}
				if (this.o.Count > 0)
				{
					A_0.WriteName(@do.aa);
					A_0.WriteArrayOpen();
					for (int i = 0; i < this.o.Count; i++)
					{
						abd abd = (abd)this.o[i];
						if (abd.hy() == ag9.e)
						{
							((abe)this.o[i]).hz(A_0);
						}
						else
						{
							((abj)this.o[i]).hz(A_0);
						}
					}
					A_0.WriteArrayClose();
				}
				if (this.p.Count > 0)
				{
					A_0.WriteName(@do.ab);
					A_0.WriteArrayOpen();
					for (int i = 0; i < this.p.Count; i++)
					{
						((abj)this.p[i]).hz(A_0);
					}
					A_0.WriteArrayClose();
				}
			}
		}

		// Token: 0x0400041D RID: 1053
		private ab7 a = null;

		// Token: 0x0400041E RID: 1054
		private ab7 b = null;

		// Token: 0x0400041F RID: 1055
		private abu c = null;

		// Token: 0x04000420 RID: 1056
		private abe d = null;

		// Token: 0x04000421 RID: 1057
		private abe e = null;

		// Token: 0x04000422 RID: 1058
		private abd f = null;

		// Token: 0x04000423 RID: 1059
		private abe g = null;

		// Token: 0x04000424 RID: 1060
		private abu h = null;

		// Token: 0x04000425 RID: 1061
		private abe i = null;

		// Token: 0x04000426 RID: 1062
		private abe j = null;

		// Token: 0x04000427 RID: 1063
		private ArrayList k = new ArrayList();

		// Token: 0x04000428 RID: 1064
		private ArrayList l = new ArrayList();

		// Token: 0x04000429 RID: 1065
		private ArrayList m = new ArrayList();

		// Token: 0x0400042A RID: 1066
		private ArrayList n = new ArrayList();

		// Token: 0x0400042B RID: 1067
		private ArrayList o = new ArrayList();

		// Token: 0x0400042C RID: 1068
		private ArrayList p = new ArrayList();

		// Token: 0x0400042D RID: 1069
		private abe q = null;

		// Token: 0x0400042E RID: 1070
		private static byte[] r = new byte[]
		{
			78,
			97,
			109,
			101
		};

		// Token: 0x0400042F RID: 1071
		private static byte[] s = new byte[]
		{
			67,
			114,
			101,
			97,
			116,
			111,
			114
		};

		// Token: 0x04000430 RID: 1072
		private static byte[] t = new byte[]
		{
			66,
			97,
			115,
			101,
			83,
			116,
			97,
			116,
			101
		};

		// Token: 0x04000431 RID: 1073
		private static byte[] u = new byte[]
		{
			79,
			78
		};

		// Token: 0x04000432 RID: 1074
		private static byte[] v = new byte[]
		{
			79,
			70,
			70
		};

		// Token: 0x04000433 RID: 1075
		private static byte[] w = new byte[]
		{
			73,
			110,
			116,
			101,
			110,
			116
		};

		// Token: 0x04000434 RID: 1076
		private static byte[] x = new byte[]
		{
			76,
			105,
			115,
			116,
			77,
			111,
			100,
			101
		};

		// Token: 0x04000435 RID: 1077
		private static byte[] y = new byte[]
		{
			65,
			83
		};

		// Token: 0x04000436 RID: 1078
		private static byte[] z = new byte[]
		{
			79,
			114,
			100,
			101,
			114
		};

		// Token: 0x04000437 RID: 1079
		private static byte[] aa = new byte[]
		{
			82,
			66,
			71,
			114,
			111,
			117,
			112,
			115
		};

		// Token: 0x04000438 RID: 1080
		private static byte[] ab = new byte[]
		{
			76,
			111,
			99,
			107,
			101,
			100
		};
	}
}
