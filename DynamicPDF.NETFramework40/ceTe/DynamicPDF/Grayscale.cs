using System;
using System.Text;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200069C RID: 1692
	public class Grayscale : DeviceColor
	{
		// Token: 0x06004040 RID: 16448 RVA: 0x0022121E File Offset: 0x0022021E
		public Grayscale(byte grayLevel)
		{
			this.a = (float)grayLevel / 255f;
		}

		// Token: 0x06004041 RID: 16449 RVA: 0x00221238 File Offset: 0x00220238
		public Grayscale(float grayLevel)
		{
			if (grayLevel < 0f || grayLevel > 1f)
			{
				throw new GeneratorException("Grayscale value must be from 0.0 to 1.0.");
			}
			this.a = grayLevel;
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06004042 RID: 16450 RVA: 0x0022127C File Offset: 0x0022027C
		public override int Components
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06004043 RID: 16451 RVA: 0x00221290 File Offset: 0x00220290
		public override ColorSpace ColorSpace
		{
			get
			{
				return ColorSpace.DeviceGray;
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06004044 RID: 16452 RVA: 0x002212A8 File Offset: 0x002202A8
		public float GrayLevel
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06004045 RID: 16453 RVA: 0x002212C0 File Offset: 0x002202C0
		public override bool Equals(object obj)
		{
			return obj is Grayscale && this.GrayLevel == ((Grayscale)obj).GrayLevel;
		}

		// Token: 0x06004046 RID: 16454 RVA: 0x002212F4 File Offset: 0x002202F4
		public override int GetHashCode()
		{
			return this.a.GetHashCode();
		}

		// Token: 0x06004047 RID: 16455 RVA: 0x00221311 File Offset: 0x00220311
		public override void ToStringBuilder(StringBuilder stringBuilder)
		{
			base.a(stringBuilder, this.a);
			stringBuilder.Append(" g");
		}

		// Token: 0x06004048 RID: 16456 RVA: 0x0022132E File Offset: 0x0022032E
		public override void DrawStroke(OperatorWriter writer)
		{
			writer.Write_G(this);
		}

		// Token: 0x06004049 RID: 16457 RVA: 0x00221339 File Offset: 0x00220339
		public override void DrawFill(OperatorWriter writer)
		{
			writer.Write_g_(this);
		}

		// Token: 0x0600404A RID: 16458 RVA: 0x00221344 File Offset: 0x00220344
		internal override void gr(DocumentWriter A_0)
		{
			A_0.WriteArrayOpen();
			A_0.WriteNumberColor(this.a);
			A_0.WriteArrayClose();
		}

		// Token: 0x0600404B RID: 16459 RVA: 0x00221364 File Offset: 0x00220364
		internal override RgbColor m()
		{
			return new RgbColor(this.GrayLevel, this.GrayLevel, this.GrayLevel);
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x0600404C RID: 16460 RVA: 0x00221390 File Offset: 0x00220390
		public static Grayscale Black
		{
			get
			{
				Grayscale.g();
				return Grayscale.b;
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x0600404D RID: 16461 RVA: 0x002213B0 File Offset: 0x002203B0
		public static Grayscale LightGrey
		{
			get
			{
				Grayscale.f();
				return Grayscale.c;
			}
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x0600404E RID: 16462 RVA: 0x002213D0 File Offset: 0x002203D0
		public static Grayscale Silver
		{
			get
			{
				Grayscale.e();
				return Grayscale.d;
			}
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x0600404F RID: 16463 RVA: 0x002213F0 File Offset: 0x002203F0
		public static Grayscale DarkGray
		{
			get
			{
				Grayscale.d();
				return Grayscale.e;
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06004050 RID: 16464 RVA: 0x00221410 File Offset: 0x00220410
		public static Grayscale Gray
		{
			get
			{
				Grayscale.c();
				return Grayscale.f;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06004051 RID: 16465 RVA: 0x00221430 File Offset: 0x00220430
		public static Grayscale DimGray
		{
			get
			{
				Grayscale.b();
				return Grayscale.g;
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06004052 RID: 16466 RVA: 0x00221450 File Offset: 0x00220450
		public static Grayscale White
		{
			get
			{
				Grayscale.a();
				return Grayscale.h;
			}
		}

		// Token: 0x06004053 RID: 16467 RVA: 0x00221470 File Offset: 0x00220470
		private static void g()
		{
			if (Grayscale.b == null)
			{
				Grayscale.b = new Grayscale(0);
			}
		}

		// Token: 0x06004054 RID: 16468 RVA: 0x00221498 File Offset: 0x00220498
		private static void f()
		{
			if (Grayscale.c == null)
			{
				Grayscale.c = new Grayscale(211);
			}
		}

		// Token: 0x06004055 RID: 16469 RVA: 0x002214C4 File Offset: 0x002204C4
		private static void e()
		{
			if (Grayscale.d == null)
			{
				Grayscale.d = new Grayscale(192);
			}
		}

		// Token: 0x06004056 RID: 16470 RVA: 0x002214F0 File Offset: 0x002204F0
		private static void d()
		{
			if (Grayscale.e == null)
			{
				Grayscale.e = new Grayscale(167);
			}
		}

		// Token: 0x06004057 RID: 16471 RVA: 0x0022151C File Offset: 0x0022051C
		private static void c()
		{
			if (Grayscale.f == null)
			{
				Grayscale.f = new Grayscale(190);
			}
		}

		// Token: 0x06004058 RID: 16472 RVA: 0x00221548 File Offset: 0x00220548
		private static void b()
		{
			if (Grayscale.g == null)
			{
				Grayscale.g = new Grayscale(105);
			}
		}

		// Token: 0x06004059 RID: 16473 RVA: 0x00221574 File Offset: 0x00220574
		private new static void a()
		{
			if (Grayscale.h == null)
			{
				Grayscale.h = new Grayscale(byte.MaxValue);
			}
		}

		// Token: 0x040023A9 RID: 9129
		private new float a;

		// Token: 0x040023AA RID: 9130
		private new static Grayscale b = null;

		// Token: 0x040023AB RID: 9131
		private new static Grayscale c = null;

		// Token: 0x040023AC RID: 9132
		private new static Grayscale d = null;

		// Token: 0x040023AD RID: 9133
		private static Grayscale e = null;

		// Token: 0x040023AE RID: 9134
		private static Grayscale f = null;

		// Token: 0x040023AF RID: 9135
		private static Grayscale g = null;

		// Token: 0x040023B0 RID: 9136
		private static Grayscale h = null;
	}
}
