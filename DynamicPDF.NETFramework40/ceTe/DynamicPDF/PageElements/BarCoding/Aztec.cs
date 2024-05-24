using System;
using System.Collections;
using System.Collections.Generic;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000754 RID: 1876
	public class Aztec : Dim2Barcode
	{
		// Token: 0x06004C71 RID: 19569 RVA: 0x0026BC24 File Offset: 0x0026AC24
		public Aztec(string value, float x, float y, AztecSymbolSize size, float xDimension) : base(x, y)
		{
			this.c = value;
			this.i = af.a(this.c, false);
			this.g.a(this.i);
			base.XDimension = xDimension;
			this.g.c((int)size);
			this.b = size;
			this.g.b(1);
		}

		// Token: 0x06004C72 RID: 19570 RVA: 0x0026BCB8 File Offset: 0x0026ACB8
		public Aztec(string value, float x, float y, AztecSymbolSize size) : this(value, x, y, size, 3f)
		{
		}

		// Token: 0x06004C73 RID: 19571 RVA: 0x0026BCD0 File Offset: 0x0026ACD0
		public Aztec(byte[] value, float x, float y, AztecSymbolSize size, float xDimension) : base(x, y)
		{
			this.i = value;
			this.g.a(value);
			base.XDimension = xDimension;
			this.g.c((int)size);
			this.b = size;
			this.g.b(1);
		}

		// Token: 0x06004C74 RID: 19572 RVA: 0x0026BD4D File Offset: 0x0026AD4D
		public Aztec(byte[] value, float x, float y, AztecSymbolSize size) : this(value, x, y, size, 3f)
		{
		}

		// Token: 0x06004C75 RID: 19573 RVA: 0x0026BD64 File Offset: 0x0026AD64
		internal Aztec(List<byte[]> A_0, float A_1, float A_2, AztecSymbolSize A_3, float A_4, bool A_5, string A_6, int A_7, int A_8, bool A_9, bool A_10, int A_11) : base(A_1, A_2)
		{
			this.g.a(A_0[A_7 - 1]);
			this.g.c((int)A_3);
			base.XDimension = A_4;
			this.g.c(A_5);
			this.g.a(A_6);
			this.g.b(A_7);
			this.g.a(A_8);
			this.g.a(A_9);
			this.g.a(A_0);
			this.g.d(A_10);
			this.g.d(A_11);
			this.i = A_0[A_7 - 1];
			this.b = A_3;
			base.XDimension = A_4;
			this.d = A_5;
			this.e = A_6;
			this.h = A_10;
			this.a = A_11;
		}

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x06004C76 RID: 19574 RVA: 0x0026BE80 File Offset: 0x0026AE80
		// (set) Token: 0x06004C77 RID: 19575 RVA: 0x0026BE98 File Offset: 0x0026AE98
		public int ErrorCorrection
		{
			get
			{
				return this.a;
			}
			set
			{
				if (value < 5 || value > 95)
				{
					throw new BarCodeException("Error correction level may be between 5 to 95.");
				}
				this.a = value;
			}
		}

		// Token: 0x170005E0 RID: 1504
		// (get) Token: 0x06004C78 RID: 19576 RVA: 0x0026BECC File Offset: 0x0026AECC
		// (set) Token: 0x06004C79 RID: 19577 RVA: 0x0026BEE4 File Offset: 0x0026AEE4
		public bool AllowStructuredAppend
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x06004C7A RID: 19578 RVA: 0x0026BEF0 File Offset: 0x0026AEF0
		// (set) Token: 0x06004C7B RID: 19579 RVA: 0x0026BF08 File Offset: 0x0026AF08
		public string MessageID
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x06004C7C RID: 19580 RVA: 0x0026BF14 File Offset: 0x0026AF14
		public AztecSymbolSize Size
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x06004C7D RID: 19581 RVA: 0x0026BF2C File Offset: 0x0026AF2C
		public string Value
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x170005E4 RID: 1508
		// (get) Token: 0x06004C7E RID: 19582 RVA: 0x0026BF44 File Offset: 0x0026AF44
		// (set) Token: 0x06004C7F RID: 19583 RVA: 0x0026BF5C File Offset: 0x0026AF5C
		public bool IsReaderInitializationSymbol
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x06004C80 RID: 19584 RVA: 0x0026BF68 File Offset: 0x0026AF68
		// (set) Token: 0x06004C81 RID: 19585 RVA: 0x0026BF80 File Offset: 0x0026AF80
		public bool ProcessTilde
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
				if (value)
				{
					if (!string.IsNullOrEmpty(this.c))
					{
						this.i = af.a(this.c, this.h);
						this.g.a(this.i);
					}
				}
			}
		}

		// Token: 0x06004C82 RID: 19586 RVA: 0x0026BFDC File Offset: 0x0026AFDC
		public override void Draw(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				base.e(writer);
			}
			BitArray a_ = this.a();
			int num = this.g.d();
			int num2 = this.g.e();
			byte[] a_2 = BarCode.a(a_, base.PixelsPerXDimension, base.PixelsPerXDimension, num, num2);
			if (base.Angle != 0f)
			{
				writer.SetDimensionsSimpleRotate(base.X, base.Y, base.Angle);
			}
			writer.SetFillColor(base.Color);
			writer.a(base.X, base.Y + this.GetSymbolHeight(), this.GetSymbolWidth(), this.GetSymbolHeight(), num * base.PixelsPerXDimension, num2 * base.PixelsPerXDimension, a_2);
			if (base.Angle != 0f)
			{
				writer.ResetDimensions();
			}
		}

		// Token: 0x06004C83 RID: 19587 RVA: 0x0026C0CC File Offset: 0x0026B0CC
		public Aztec GetOverflowAztec()
		{
			return this.GetOverflowAztec(base.X, base.Y);
		}

		// Token: 0x06004C84 RID: 19588 RVA: 0x0026C0F0 File Offset: 0x0026B0F0
		public Aztec GetOverflowAztec(float x, float y)
		{
			Aztec result;
			if (this.g == null)
			{
				result = null;
			}
			else
			{
				if (!this.g.h())
				{
					this.g.b(this.f);
					this.g.d(this.a);
					this.g.c(this.d);
					this.g.a(this.e);
					this.g.d(this.h);
					this.g.p();
				}
				if (this.g.g() < this.g.f())
				{
					result = new Aztec(this.g.m(), x, y, this.b, base.XDimension, this.d, this.e, this.g.g() + 1, this.g.f(), this.g.h(), this.g.l(), this.g.k())
					{
						Tag = this.Tag,
						TagOrder = this.TagOrder
					};
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x06004C85 RID: 19589 RVA: 0x0026C238 File Offset: 0x0026B238
		public override float GetSymbolWidth()
		{
			this.a();
			return (float)this.g.d() * base.XDimension;
		}

		// Token: 0x06004C86 RID: 19590 RVA: 0x0026C264 File Offset: 0x0026B264
		public override float GetSymbolHeight()
		{
			this.a();
			return (float)this.g.e() * base.XDimension;
		}

		// Token: 0x06004C87 RID: 19591 RVA: 0x0026C290 File Offset: 0x0026B290
		private void a(byte[] A_0, int A_1, int A_2, PageWriter A_3)
		{
			if (base.Angle != 0f)
			{
				A_3.SetDimensionsSimpleRotate(base.X, base.Y, base.Angle);
			}
			A_3.SetFillColor(base.Color);
			A_3.a(base.X, base.Y + (float)A_1 * base.XDimension, (float)A_2 * base.XDimension, (float)A_1 * base.XDimension, A_2, A_1, A_0);
			if (base.Angle != 0f)
			{
				A_3.ResetDimensions();
			}
		}

		// Token: 0x06004C88 RID: 19592 RVA: 0x0026C328 File Offset: 0x0026B328
		private BitArray a()
		{
			if (!this.g.h() && this.d)
			{
				this.g.b(this.f);
				this.g.d(this.a);
				this.g.c(this.d);
				this.g.a(this.e);
				this.g.d(this.h);
				this.g.p();
			}
			BitArray result;
			try
			{
				this.g.b(this.f);
				this.g.d(this.h);
				this.g.d(this.a);
				if (this.d && this.g.f() > 1)
				{
					result = this.g.o();
				}
				else
				{
					result = this.g.n();
				}
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (ao ao)
			{
				throw new dt(ao.Message);
			}
			catch (an an)
			{
				throw new ds(an.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			return result;
		}

		// Token: 0x0400293E RID: 10558
		private new int a = 23;

		// Token: 0x0400293F RID: 10559
		private AztecSymbolSize b = AztecSymbolSize.Auto;

		// Token: 0x04002940 RID: 10560
		private string c;

		// Token: 0x04002941 RID: 10561
		private new bool d;

		// Token: 0x04002942 RID: 10562
		private new string e = "A";

		// Token: 0x04002943 RID: 10563
		private bool f;

		// Token: 0x04002944 RID: 10564
		private d g = new d();

		// Token: 0x04002945 RID: 10565
		private bool h;

		// Token: 0x04002946 RID: 10566
		private byte[] i;
	}
}
