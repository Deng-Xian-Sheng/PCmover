using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Imaging
{
	// Token: 0x0200087D RID: 2173
	public class TiffImageData : ImageData
	{
		// Token: 0x0600587D RID: 22653 RVA: 0x00336558 File Offset: 0x00335558
		internal TiffImageData(uint A_0, ye A_1, bool A_2) : this(new yj(A_1, A_0))
		{
			this.o = A_2;
		}

		// Token: 0x0600587E RID: 22654 RVA: 0x00336574 File Offset: 0x00335574
		internal TiffImageData(yj A_0)
		{
			float num = 0f;
			float num2 = 0f;
			int num3 = 1;
			this.d = A_0;
			if (A_0.b(256U))
			{
				this.f = A_0.f();
			}
			if (A_0.b(257U))
			{
				this.g = A_0.f();
			}
			if (A_0.b(258U))
			{
				this.i = A_0.l();
			}
			if (A_0.b(259U))
			{
				this.j = A_0.e();
			}
			if (A_0.b(262U))
			{
				this.k = A_0.e();
			}
			if (A_0.b(277U))
			{
				this.h = A_0.f();
			}
			if (this.i == null)
			{
				this.i = new uint[this.h];
				int num4 = 0;
				while ((long)num4 < (long)((ulong)this.h))
				{
					this.i[num4] = 1U;
					num4++;
				}
			}
			if (A_0.b(282U))
			{
				num = A_0.j();
			}
			if (A_0.b(283U))
			{
				num2 = A_0.j();
			}
			if (A_0.b(296U))
			{
				num3 = (int)A_0.e();
			}
			A_0.c(262U);
			switch (num3)
			{
			case 1:
				if (num != num2)
				{
					this.m = 72f / num;
					this.n = 72f / num2;
				}
				break;
			case 2:
				if (num <= 0f)
				{
					this.m = 0.24f;
				}
				else
				{
					this.m = 72f / num;
				}
				if (num2 <= 0f)
				{
					this.n = 0.24f;
				}
				else
				{
					this.n = 72f / num2;
				}
				break;
			case 3:
				if (num <= 0f)
				{
					this.m = 0.24f;
				}
				else
				{
					this.m = 28.346457f / num;
				}
				if (num2 <= 0f)
				{
					this.n = 0.24f;
				}
				else
				{
					this.n = 28.346457f / num2;
				}
				break;
			}
		}

		// Token: 0x0600587F RID: 22655 RVA: 0x00336824 File Offset: 0x00335824
		internal new uint e()
		{
			return this.h;
		}

		// Token: 0x170008DB RID: 2267
		// (get) Token: 0x06005880 RID: 22656 RVA: 0x0033683C File Offset: 0x0033583C
		public override int RequiredPdfObjects
		{
			get
			{
				return this.l;
			}
		}

		// Token: 0x170008DC RID: 2268
		// (get) Token: 0x06005881 RID: 22657 RVA: 0x00336854 File Offset: 0x00335854
		public override int Width
		{
			get
			{
				return (int)this.f;
			}
		}

		// Token: 0x170008DD RID: 2269
		// (get) Token: 0x06005882 RID: 22658 RVA: 0x0033686C File Offset: 0x0033586C
		public override int Height
		{
			get
			{
				return (int)this.g;
			}
		}

		// Token: 0x170008DE RID: 2270
		// (get) Token: 0x06005883 RID: 22659 RVA: 0x00336884 File Offset: 0x00335884
		public override float ScaleX
		{
			get
			{
				return this.m;
			}
		}

		// Token: 0x170008DF RID: 2271
		// (get) Token: 0x06005884 RID: 22660 RVA: 0x0033689C File Offset: 0x0033589C
		public override float ScaleY
		{
			get
			{
				return this.n;
			}
		}

		// Token: 0x06005885 RID: 22661 RVA: 0x003368B4 File Offset: 0x003358B4
		internal override byte[] gs()
		{
			return this.c.gx();
		}

		// Token: 0x06005886 RID: 22662 RVA: 0x003368D4 File Offset: 0x003358D4
		internal new uint[] f()
		{
			return this.i;
		}

		// Token: 0x06005887 RID: 22663 RVA: 0x003368EC File Offset: 0x003358EC
		internal new bool i()
		{
			return this.o;
		}

		// Token: 0x06005888 RID: 22664 RVA: 0x00336904 File Offset: 0x00335904
		internal new ushort j()
		{
			return this.k;
		}

		// Token: 0x06005889 RID: 22665 RVA: 0x0033691C File Offset: 0x0033591C
		internal new TiffImageData k()
		{
			if (!this.b)
			{
				yj yj = this.d.d();
				if (yj != null)
				{
					this.a = new TiffImageData(yj);
				}
				this.b = true;
			}
			return this.a;
		}

		// Token: 0x0600588A RID: 22666 RVA: 0x00336967 File Offset: 0x00335967
		internal new void a(int A_0)
		{
			this.l = A_0;
		}

		// Token: 0x0600588B RID: 22667 RVA: 0x00336974 File Offset: 0x00335974
		private new void c()
		{
			if (!this.e)
			{
				this.a();
				this.e = true;
			}
		}

		// Token: 0x0600588C RID: 22668 RVA: 0x0033699C File Offset: 0x0033599C
		private new void a()
		{
			ushort num = this.j;
			switch (num)
			{
			case 1:
				this.c = new ys(this, this.d);
				break;
			case 2:
				this.c = new yi(this, this.d);
				break;
			case 3:
				this.c = new yk(this, this.d);
				break;
			case 4:
				this.c = new yl(this, this.d);
				break;
			case 5:
				this.c = new yq(this, this.d);
				break;
			case 6:
				this.c = new yo(this, this.d);
				break;
			case 7:
				throw new ImageParsingException("TIFF Compression value 7 (Extended JPEG) is not supported.");
			case 8:
				throw new ImageParsingException("TIFF Compression value 8 (Flate/Deflate) is not supported.");
			default:
				if (num != 32773)
				{
					throw new ImageParsingException("TIFF Compression value " + this.j + " (Unrecognized) is not supported.");
				}
				this.c = new yr(this, this.d);
				break;
			}
		}

		// Token: 0x0600588D RID: 22669 RVA: 0x00336AB4 File Offset: 0x00335AB4
		public override void Draw(OperatorWriter writer, float pdfX, float pdfY, float width, float height)
		{
			this.c();
			base.Draw(writer, pdfX, pdfY, width, height);
		}

		// Token: 0x0600588E RID: 22670 RVA: 0x00336ACC File Offset: 0x00335ACC
		public override void Draw(DocumentWriter writer)
		{
			this.c();
			this.c.gy(writer);
		}

		// Token: 0x04002F00 RID: 12032
		private new TiffImageData a = null;

		// Token: 0x04002F01 RID: 12033
		private new bool b = false;

		// Token: 0x04002F02 RID: 12034
		private new yg c;

		// Token: 0x04002F03 RID: 12035
		private new yj d;

		// Token: 0x04002F04 RID: 12036
		private new bool e = false;

		// Token: 0x04002F05 RID: 12037
		private new uint f;

		// Token: 0x04002F06 RID: 12038
		private new uint g;

		// Token: 0x04002F07 RID: 12039
		private new uint h;

		// Token: 0x04002F08 RID: 12040
		private new uint[] i;

		// Token: 0x04002F09 RID: 12041
		private new ushort j;

		// Token: 0x04002F0A RID: 12042
		private new ushort k;

		// Token: 0x04002F0B RID: 12043
		private new int l = 1;

		// Token: 0x04002F0C RID: 12044
		private new float m = 1f;

		// Token: 0x04002F0D RID: 12045
		private float n = 1f;

		// Token: 0x04002F0E RID: 12046
		private bool o;
	}
}
