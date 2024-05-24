using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200063E RID: 1598
	public struct Attached
	{
		// Token: 0x06003C02 RID: 15362 RVA: 0x001FDB5E File Offset: 0x001FCB5E
		public Attached(Edge value)
		{
			this.f = false;
			this.g = false;
			this.h = false;
			this.i = false;
			this.a(value);
		}

		// Token: 0x06003C03 RID: 15363 RVA: 0x001FDB85 File Offset: 0x001FCB85
		public Attached(Edge value1, Edge value2)
		{
			this.f = false;
			this.g = false;
			this.h = false;
			this.i = false;
			this.a(value1);
			this.a(value2);
		}

		// Token: 0x06003C04 RID: 15364 RVA: 0x001FDBB4 File Offset: 0x001FCBB4
		public Attached(Edge value1, Edge value2, Edge value3)
		{
			this.f = false;
			this.g = false;
			this.h = false;
			this.i = false;
			this.a(value1);
			this.a(value2);
			this.a(value3);
		}

		// Token: 0x06003C05 RID: 15365 RVA: 0x001FDBEB File Offset: 0x001FCBEB
		public Attached(Edge value1, Edge value2, Edge value3, Edge value4)
		{
			this.f = false;
			this.g = false;
			this.h = false;
			this.i = false;
			this.a(value1);
			this.a(value2);
			this.a(value3);
			this.a(value4);
		}

		// Token: 0x06003C06 RID: 15366 RVA: 0x001FDC2C File Offset: 0x001FCC2C
		private void a(Edge A_0)
		{
			switch (A_0)
			{
			case Edge.Top:
				this.f = true;
				break;
			case Edge.Bottom:
				this.g = true;
				break;
			case Edge.Left:
				this.h = true;
				break;
			case Edge.Right:
				this.i = true;
				break;
			}
		}

		// Token: 0x06003C07 RID: 15367 RVA: 0x001FDC78 File Offset: 0x001FCC78
		public void SetEdge(Edge value)
		{
			this.a(value);
		}

		// Token: 0x06003C08 RID: 15368 RVA: 0x001FDC84 File Offset: 0x001FCC84
		internal bool a()
		{
			return this.f;
		}

		// Token: 0x06003C09 RID: 15369 RVA: 0x001FDC9C File Offset: 0x001FCC9C
		internal bool b()
		{
			return this.g;
		}

		// Token: 0x06003C0A RID: 15370 RVA: 0x001FDCB4 File Offset: 0x001FCCB4
		internal bool c()
		{
			return this.i;
		}

		// Token: 0x06003C0B RID: 15371 RVA: 0x001FDCCC File Offset: 0x001FCCCC
		internal bool d()
		{
			return this.h;
		}

		// Token: 0x06003C0C RID: 15372 RVA: 0x001FDCE4 File Offset: 0x001FCCE4
		internal void a(PageWriter A_0)
		{
			if (this.f || this.g || this.h || this.i)
			{
				A_0.WriteName(Attached.a);
				A_0.ae();
				if (this.f)
				{
					A_0.Write(Attached.b);
				}
				if (this.g)
				{
					A_0.Write(Attached.c);
				}
				if (this.h)
				{
					A_0.Write(Attached.d);
				}
				if (this.i)
				{
					A_0.Write(Attached.e);
				}
				A_0.ad();
			}
		}

		// Token: 0x040020B4 RID: 8372
		private static byte[] a = new byte[]
		{
			65,
			116,
			116,
			97,
			99,
			104,
			101,
			100
		};

		// Token: 0x040020B5 RID: 8373
		private static byte[] b = new byte[]
		{
			40,
			84,
			111,
			112,
			41
		};

		// Token: 0x040020B6 RID: 8374
		private static byte[] c = new byte[]
		{
			40,
			66,
			111,
			116,
			116,
			111,
			109,
			41
		};

		// Token: 0x040020B7 RID: 8375
		private static byte[] d = new byte[]
		{
			40,
			76,
			101,
			102,
			116,
			41
		};

		// Token: 0x040020B8 RID: 8376
		private static byte[] e = new byte[]
		{
			40,
			82,
			105,
			103,
			104,
			116,
			41
		};

		// Token: 0x040020B9 RID: 8377
		private bool f;

		// Token: 0x040020BA RID: 8378
		private bool g;

		// Token: 0x040020BB RID: 8379
		private bool h;

		// Token: 0x040020BC RID: 8380
		private bool i;
	}
}
