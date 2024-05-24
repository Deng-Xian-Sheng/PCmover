using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000237 RID: 567
	internal class ot : dy
	{
		// Token: 0x06001A55 RID: 6741 RVA: 0x00112408 File Offset: 0x00111408
		internal ot(ov A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new ou(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001A56 RID: 6742 RVA: 0x00112460 File Offset: 0x00111460
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001A57 RID: 6743 RVA: 0x00112478 File Offset: 0x00111478
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001A58 RID: 6744 RVA: 0x00112490 File Offset: 0x00111490
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001A59 RID: 6745 RVA: 0x001124A8 File Offset: 0x001114A8
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001A5A RID: 6746 RVA: 0x001124B4 File Offset: 0x001114B4
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06001A5B RID: 6747 RVA: 0x001124CC File Offset: 0x001114CC
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001A5C RID: 6748 RVA: 0x001124D8 File Offset: 0x001114D8
		private void a(m5 A_0)
		{
			switch (A_0.b())
			{
			case ow.a:
			case ow.b:
				if (A_0.c5().v() == null && A_0.c5().am() == null)
				{
					A_0.c5().i(new x5?(x5.a(180.75)));
					A_0.c5().j(new x5?(x5.a(183.75)));
					A_0.c5().d(i2.d);
					A_0.c5().a(i2.d);
				}
				else
				{
					if (A_0.c5().v() == null)
					{
						A_0.c5().i(new x5?(x5.a(180.75)));
						A_0.c5().a(i2.d);
					}
					if (A_0.c5().am() == null)
					{
						A_0.c5().j(new x5?(x5.a(183.75)));
						A_0.c5().d(i2.d);
					}
				}
				break;
			case ow.c:
				if (A_0.c5().v() == null && A_0.c5().am() == null)
				{
					A_0.c5().i(new x5?(x5.a(100f)));
					A_0.c5().j(new x5?(x5.a(100f)));
					A_0.c5().d(i2.d);
					A_0.c5().a(i2.d);
				}
				else
				{
					if (A_0.c5().v() == null)
					{
						A_0.c5().i(new x5?(x5.a(100f)));
						A_0.c5().a(i2.d);
					}
					if (A_0.c5().am() == null)
					{
						A_0.c5().j(new x5?(x5.a(100f)));
						A_0.c5().d(i2.d);
					}
				}
				break;
			default:
			{
				lk lk = A_0.c5();
				x5? a_;
				A_0.c5().i(a_ = new x5?(x5.a(75f)));
				lk.j(a_);
				lk lk2 = A_0.c5();
				i2 a_2;
				A_0.c5().a(a_2 = i2.d);
				lk2.d(a_2);
				break;
			}
			}
		}

		// Token: 0x06001A5D RID: 6749 RVA: 0x0011277C File Offset: 0x0011177C
		private void a(lk A_0)
		{
			if (A_0.am() == null && this.a.c().a().a() != 0f)
			{
				A_0.j(new x5?(new f9(m4.a(this.a.c())).c()));
				A_0.d(this.a.c().a().b());
			}
			if (A_0.v() == null)
			{
				if (this.a.d().a().a() != 0f)
				{
					A_0.i(new x5?(new f9(m4.a(this.a.d())).c()));
					A_0.a(this.a.d().a().b());
				}
			}
		}

		// Token: 0x06001A5E RID: 6750 RVA: 0x00112894 File Offset: 0x00111894
		private void a()
		{
			if (this.b.b().Count != 0)
			{
				if (this.a(1, string.Empty))
				{
					foreach (object obj in this.b.b())
					{
						DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
						string text = (string)dictionaryEntry.Value;
						if (this.a(2, dictionaryEntry.Key.ToString()))
						{
							if (text.LastIndexOf('.') > 0)
							{
								this.a.a(text);
								this.a.a(this.a.g());
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x06001A5F RID: 6751 RVA: 0x00112994 File Offset: 0x00111994
		private bool a(int A_0, string A_1)
		{
			bool flag = false;
			string[] array = new string[]
			{
				"movie",
				"file",
				"url",
				"src"
			};
			foreach (string key in array)
			{
				if (A_0 == 1)
				{
					flag = this.b.b().ContainsKey(key);
				}
				else
				{
					flag = Convert.ToBoolean(A_1 == key);
				}
				if (flag)
				{
					return flag;
				}
			}
			return flag;
		}

		// Token: 0x06001A60 RID: 6752 RVA: 0x00112A40 File Offset: 0x00111A40
		internal override kz cm(ij A_0, kz A_1)
		{
			m5 m = new m5();
			lk a_ = m.c5();
			this.a(a_);
			A_0.c(this.ch());
			A_0.a(m);
			n5 n = (n5)m.db();
			m.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(m);
			}
			if (this.a.a() == null)
			{
				this.a();
			}
			bool flag = this.b.b;
			m.a(this.a.f());
			if (!flag)
			{
				if (this.a.f() == ow.d)
				{
					kk kk = new kk();
					kk.b(this.a.a());
					if (this.b.h() == 0)
					{
						this.b.a(new kj(kk), 0);
					}
					else
					{
						this.b.a(0, new kj(kk));
					}
					flag = true;
				}
				else
				{
					this.b = null;
				}
			}
			bool flag2 = true;
			bool a_2 = false;
			g2 valueOrDefault = m.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					m = null;
					flag2 = false;
					A_0.a(false);
					break;
				case g2.c:
					a_2 = true;
					break;
				}
			}
			if (flag2)
			{
				A_0.a(true);
				m.j(A_1);
				hd a_3 = i3.b(m);
				ig a_4 = new ig(new fc[]
				{
					new fc(6968946, a_3)
				});
				A_0.a(this.ch().cn(), a_4);
				i3.a(m);
				i3.a(m, A_0);
				m4.a(n, m.c5(), a_2);
				if (m.c5().ay().e() != null)
				{
					m.b(mg.a(A_0, m.c5().ay().e(), A_0.e()));
				}
				if (this.b != null)
				{
					base.e(m, A_0);
				}
				if (this.a.a() == null)
				{
					m.c5().i(null);
					m.c5().j(null);
				}
				if (!flag && this.a.a() != null)
				{
					this.a(m);
				}
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return m;
		}

		// Token: 0x04000BFD RID: 3069
		private new ov a = null;

		// Token: 0x04000BFE RID: 3070
		private ou b = null;

		// Token: 0x04000BFF RID: 3071
		private bool c = false;

		// Token: 0x04000C00 RID: 3072
		private new bool d = true;
	}
}
