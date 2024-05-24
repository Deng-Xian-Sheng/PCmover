using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x0200042B RID: 1067
	[DefaultMember("Item")]
	internal class abt : abs
	{
		// Token: 0x06002C4D RID: 11341 RVA: 0x00196508 File Offset: 0x00195508
		internal abt(PdfDocument A_0) : base(A_0)
		{
		}

		// Token: 0x06002C4E RID: 11342 RVA: 0x00196594 File Offset: 0x00195594
		internal void a(agv A_0)
		{
			abi a_ = new abi(base.j());
			this.a(A_0, a_);
			this.l.Sort();
			this.b.a(this.l);
			if (this.d != null && this.d.hy() != ag9.i)
			{
				abe abe = (abe)this.g.h6();
				abj a_2 = (abj)this.d.h6();
				base.j().a(b6.a(a_2, base.j().d(), (ab7)abe.a(0), this.n));
			}
		}

		// Token: 0x06002C4F RID: 11343 RVA: 0x00196648 File Offset: 0x00195648
		internal bool a()
		{
			return this.n;
		}

		// Token: 0x06002C50 RID: 11344 RVA: 0x00196660 File Offset: 0x00195660
		internal void a(bool A_0)
		{
			this.n = A_0;
		}

		// Token: 0x06002C51 RID: 11345 RVA: 0x0019666C File Offset: 0x0019566C
		internal List<long> b()
		{
			return this.l;
		}

		// Token: 0x06002C52 RID: 11346 RVA: 0x00196684 File Offset: 0x00195684
		internal int c()
		{
			return this.a.Length;
		}

		// Token: 0x06002C53 RID: 11347 RVA: 0x001966A0 File Offset: 0x001956A0
		internal ab6 d()
		{
			return this.e;
		}

		// Token: 0x06002C54 RID: 11348 RVA: 0x001966B8 File Offset: 0x001956B8
		internal abd e()
		{
			return this.f;
		}

		// Token: 0x06002C55 RID: 11349 RVA: 0x001966D0 File Offset: 0x001956D0
		internal override aba h4()
		{
			aba result;
			if (this.m != null)
			{
				aba aba = this.m;
				this.m = null;
				result = aba;
			}
			else
			{
				result = base.j().f().k8();
			}
			return result;
		}

		// Token: 0x06002C56 RID: 11350 RVA: 0x00196712 File Offset: 0x00195712
		internal override void h5(aba A_0)
		{
			this.m = A_0;
		}

		// Token: 0x06002C57 RID: 11351 RVA: 0x0019671C File Offset: 0x0019571C
		internal void a(abd A_0)
		{
			if (this.d == null)
			{
				this.d = A_0;
			}
		}

		// Token: 0x06002C58 RID: 11352 RVA: 0x00196744 File Offset: 0x00195744
		internal void a(ab6 A_0)
		{
			if (this.e == null)
			{
				this.e = A_0;
			}
		}

		// Token: 0x06002C59 RID: 11353 RVA: 0x0019676C File Offset: 0x0019576C
		internal void b(abd A_0)
		{
			if (this.f == null)
			{
				this.f = A_0;
			}
		}

		// Token: 0x06002C5A RID: 11354 RVA: 0x00196794 File Offset: 0x00195794
		internal void c(abd A_0)
		{
			if (this.g == null)
			{
				this.g = A_0;
			}
		}

		// Token: 0x06002C5B RID: 11355 RVA: 0x001967BC File Offset: 0x001957BC
		private void a(agv A_0, abi A_1)
		{
			if (A_0.lf())
			{
				this.c(A_0, A_1);
			}
			else
			{
				this.b(A_0, A_1);
			}
		}

		// Token: 0x06002C5C RID: 11356 RVA: 0x001967EC File Offset: 0x001957EC
		internal void b(agv A_0, abi A_1)
		{
			this.i++;
			ahh ahh = new ahh(this);
			long num = ahh.a(A_0, A_1);
			if (ahh.b() > this.h)
			{
				this.h = ahh.b();
			}
			if (this.j > ahh.c())
			{
				this.j = ahh.c();
			}
			if (ahh.a() > 0L)
			{
				A_0.lj(ahh.a());
				if (!A_0.lf())
				{
					throw new PdfParsingException("Invalid PDF File. Xref position invalid");
				}
				this.a(A_0, A_1);
			}
			if (num > 0L)
			{
				if (this.k.Count % 5 == 0)
				{
					short num2 = 0;
					for (int i = 0; i < this.k.Count; i++)
					{
						if ((long)((int)this.k[i]) == num)
						{
							num2 += 1;
						}
					}
					if (num2 > 2)
					{
						throw new PdfParsingException("Invalid PDF File. Xref positions are repeated");
					}
				}
				this.l.Add(num);
				A_0.lj(num);
				this.a(A_0, A_1);
			}
		}

		// Token: 0x06002C5D RID: 11357 RVA: 0x00196950 File Offset: 0x00195950
		internal void c(agv A_0, abi A_1)
		{
			ahg ahg = new ahg(this);
			int num = ahg.a(A_0, A_1);
			if (ahg.a() > 0)
			{
				this.l.Add((long)num);
				A_0.lj((long)num);
				this.a(A_0, A_1);
			}
			if (num > 0)
			{
				this.l.Add((long)num);
				A_0.lj((long)num);
				this.a(A_0, A_1);
			}
		}

		// Token: 0x06002C5E RID: 11358 RVA: 0x001969D0 File Offset: 0x001959D0
		internal void a(ab9 A_0, long A_1)
		{
			checked
			{
				if (this.a[(int)((IntPtr)A_1)] == null)
				{
					this.a[(int)((IntPtr)A_1)] = A_0;
					this.b.a(A_0);
				}
			}
		}

		// Token: 0x06002C5F RID: 11359 RVA: 0x00196A0C File Offset: 0x00195A0C
		internal void a(abh A_0, long A_1)
		{
			checked
			{
				if (this.a[(int)((IntPtr)A_1)] == null)
				{
					this.a[(int)((IntPtr)A_1)] = A_0;
				}
			}
		}

		// Token: 0x06002C60 RID: 11360 RVA: 0x00196A3C File Offset: 0x00195A3C
		internal void a(long A_0)
		{
			if (this.a == null)
			{
				this.a = new abg[A_0 + 1L];
				this.b.a(this.a.Length);
			}
			else if (A_0 >= this.a.LongLength)
			{
				abg[] array = new abg[A_0 + 1L];
				this.a.CopyTo(array, 0);
				this.a = array;
				this.b.a(array.Length);
			}
		}

		// Token: 0x06002C61 RID: 11361 RVA: 0x00196AC8 File Offset: 0x00195AC8
		private void a(Stream A_0)
		{
			while (this.c > 0 && this.c <= 32)
			{
				this.c = A_0.ReadByte();
			}
		}

		// Token: 0x06002C62 RID: 11362 RVA: 0x00196B04 File Offset: 0x00195B04
		public abg b(long A_0)
		{
			abg result;
			if (A_0 >= (long)this.a.Length)
			{
				result = null;
			}
			else
			{
				result = this.a[(int)(checked((IntPtr)A_0))];
			}
			return result;
		}

		// Token: 0x06002C63 RID: 11363 RVA: 0x00196B34 File Offset: 0x00195B34
		public abg b(ab6 A_0)
		{
			return this.a[A_0.c()];
		}

		// Token: 0x06002C64 RID: 11364 RVA: 0x00196B53 File Offset: 0x00195B53
		internal void a(int A_0, abg A_1)
		{
			this.a[A_0] = A_1;
		}

		// Token: 0x06002C65 RID: 11365 RVA: 0x00196B60 File Offset: 0x00195B60
		internal int f()
		{
			return this.h;
		}

		// Token: 0x06002C66 RID: 11366 RVA: 0x00196B78 File Offset: 0x00195B78
		internal void a(int A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06002C67 RID: 11367 RVA: 0x00196B84 File Offset: 0x00195B84
		internal int g()
		{
			return this.i;
		}

		// Token: 0x06002C68 RID: 11368 RVA: 0x00196B9C File Offset: 0x00195B9C
		internal int h()
		{
			return this.j;
		}

		// Token: 0x040014D9 RID: 5337
		private abg[] a = null;

		// Token: 0x040014DA RID: 5338
		private aca b = new aca();

		// Token: 0x040014DB RID: 5339
		private int c = 0;

		// Token: 0x040014DC RID: 5340
		private abd d = null;

		// Token: 0x040014DD RID: 5341
		private ab6 e = null;

		// Token: 0x040014DE RID: 5342
		private abd f = null;

		// Token: 0x040014DF RID: 5343
		private abd g = null;

		// Token: 0x040014E0 RID: 5344
		private int h = 0;

		// Token: 0x040014E1 RID: 5345
		private int i = 0;

		// Token: 0x040014E2 RID: 5346
		private int j = int.MaxValue;

		// Token: 0x040014E3 RID: 5347
		private ArrayList k = new ArrayList();

		// Token: 0x040014E4 RID: 5348
		private List<long> l = new List<long>();

		// Token: 0x040014E5 RID: 5349
		private aba m = null;

		// Token: 0x040014E6 RID: 5350
		private bool n = false;
	}
}
