using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004B6 RID: 1206
	internal abstract class afj : abj
	{
		// Token: 0x06003193 RID: 12691 RVA: 0x001BBD64 File Offset: 0x001BAD64
		internal afj(abi A_0, abk A_1) : base(A_0, A_1)
		{
			abu abu = null;
			abu abu2 = null;
			for (abk abk = A_1; abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 211216860)
				{
					if (num <= 111594775)
					{
						if (num != 5479461)
						{
							if (num == 111594775)
							{
								this.h = abk.c();
							}
						}
						else
						{
							abu = (abu)abk.c();
							abu.j8();
						}
					}
					else if (num != 144087516)
					{
						if (num == 211216860)
						{
							abk.a(false);
							abw abw = (abw)abk.c().h6();
							this.g = abw.kd();
						}
					}
					else if (abk.c().hy() == ag9.j)
					{
						this.f = ((abw)abk.c().h6()).kd();
					}
					else
					{
						this.f = ((abw)abk.c()).kd();
					}
				}
				else if (num <= 322313451)
				{
					if (num != 276615959)
					{
						if (num == 322313451)
						{
							if (abk.c().hy() == ag9.j)
							{
								this.i = (afj)abk.c().h6();
							}
						}
					}
					else if (abk.c().hy() == ag9.j)
					{
						abd abd = abk.c().h6();
						if (abd.hy() == ag9.e)
						{
							this.j = (abe)abk.c().h6();
						}
					}
				}
				else if (num != 332800284)
				{
					if (num == 396774696)
					{
						abd abd2 = abk.c().h6();
						this.e = ((abw)abd2).kd();
					}
				}
				else
				{
					abu2 = (abu)abk.c();
					abu2.ka();
				}
			}
			base.a(abu, abu2);
		}

		// Token: 0x06003194 RID: 12692 RVA: 0x001BBFE8 File Offset: 0x001BAFE8
		internal override ag9 hy()
		{
			return ag9.h;
		}

		// Token: 0x06003195 RID: 12693 RVA: 0x001BC000 File Offset: 0x001BB000
		internal void a()
		{
			if (this.h != null)
			{
				abu abu = null;
				if (this.h.hy() == ag9.e)
				{
					abe abe = (abe)this.h;
					for (int i = 0; i < abe.a(); i++)
					{
						int num = ((abu)abe.a(i)).j8();
						if (num != 35923684)
						{
							if (num != 216500224)
							{
								if (num == 966427151)
								{
									this.b = true;
								}
							}
							else
							{
								this.c = true;
							}
						}
						else
						{
							this.a = true;
						}
					}
				}
				else if (this.h.hy() == ag9.j)
				{
					abd abd = this.h.h6();
					if (abd.hy() == ag9.d)
					{
						abu = (abu)abd;
					}
					else if (abd.hy() == ag9.e)
					{
						abe abe2 = (abe)abd;
						abu = (abu)abe2.a(0);
					}
				}
				else if (this.h.hy() == ag9.d)
				{
					abu = (abu)this.h;
				}
				if (abu != null)
				{
					this.a = (abu.j8() == 35923684 || abu.j8() == 428);
					this.b = (abu.j8() == 966427151 || abu.j8() == 7733);
					this.c = (abu.j8() == 216500224 || abu.j8() == 50839);
				}
				this.h = null;
			}
		}

		// Token: 0x06003196 RID: 12694
		internal abstract byte[] j4();

		// Token: 0x06003197 RID: 12695
		internal abstract byte[] j5();

		// Token: 0x06003198 RID: 12696
		internal abstract byte[] j3();

		// Token: 0x06003199 RID: 12697
		internal abstract void j6(DocumentWriter A_0);

		// Token: 0x0600319A RID: 12698 RVA: 0x001BC1CC File Offset: 0x001BB1CC
		internal bool b()
		{
			this.a();
			return this.a;
		}

		// Token: 0x0600319B RID: 12699 RVA: 0x001BC1EC File Offset: 0x001BB1EC
		internal bool c()
		{
			this.a();
			return this.b;
		}

		// Token: 0x0600319C RID: 12700 RVA: 0x001BC20C File Offset: 0x001BB20C
		internal bool d()
		{
			this.a();
			return this.c;
		}

		// Token: 0x0600319D RID: 12701 RVA: 0x001BC22C File Offset: 0x001BB22C
		internal int e()
		{
			return this.e;
		}

		// Token: 0x0600319E RID: 12702 RVA: 0x001BC244 File Offset: 0x001BB244
		internal int f()
		{
			return this.f;
		}

		// Token: 0x0600319F RID: 12703 RVA: 0x001BC25C File Offset: 0x001BB25C
		internal int g()
		{
			return this.g;
		}

		// Token: 0x060031A0 RID: 12704 RVA: 0x001BC274 File Offset: 0x001BB274
		internal void e(int A_0)
		{
			this.g = A_0;
		}

		// Token: 0x060031A1 RID: 12705 RVA: 0x001BC280 File Offset: 0x001BB280
		internal afj h()
		{
			return this.i;
		}

		// Token: 0x060031A2 RID: 12706 RVA: 0x001BC298 File Offset: 0x001BB298
		internal abe i()
		{
			return this.j;
		}

		// Token: 0x04001729 RID: 5929
		private new bool a = false;

		// Token: 0x0400172A RID: 5930
		private new bool b = false;

		// Token: 0x0400172B RID: 5931
		private bool c = false;

		// Token: 0x0400172C RID: 5932
		internal static byte[] d = new byte[]
		{
			76,
			101,
			110,
			103,
			116,
			104
		};

		// Token: 0x0400172D RID: 5933
		private int e = -1;

		// Token: 0x0400172E RID: 5934
		private new int f = -1;

		// Token: 0x0400172F RID: 5935
		private new int g = -1;

		// Token: 0x04001730 RID: 5936
		private new abd h = null;

		// Token: 0x04001731 RID: 5937
		private afj i = null;

		// Token: 0x04001732 RID: 5938
		private new abe j = null;
	}
}
