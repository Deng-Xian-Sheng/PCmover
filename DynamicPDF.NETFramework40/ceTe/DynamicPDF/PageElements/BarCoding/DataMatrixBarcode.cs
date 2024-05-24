using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000758 RID: 1880
	public class DataMatrixBarcode : Dim2Barcode
	{
		// Token: 0x06004C99 RID: 19609 RVA: 0x0026C974 File Offset: 0x0026B974
		public DataMatrixBarcode(string value, float x, float y) : this(value, x, y, DataMatrixSymbolSize.Auto, DataMatrixEncodingType.Auto, DataMatrixFunctionCharacter.None, 2f)
		{
		}

		// Token: 0x06004C9A RID: 19610 RVA: 0x0026C98A File Offset: 0x0026B98A
		public DataMatrixBarcode(byte[] value, float x, float y) : this(value, x, y, DataMatrixSymbolSize.Auto, DataMatrixEncodingType.Auto, DataMatrixFunctionCharacter.None, 2f)
		{
		}

		// Token: 0x06004C9B RID: 19611 RVA: 0x0026C9A0 File Offset: 0x0026B9A0
		public DataMatrixBarcode(string value, float x, float y, DataMatrixSymbolSize dataMatrixSymbolSize) : this(value, x, y, dataMatrixSymbolSize, DataMatrixEncodingType.Auto, DataMatrixFunctionCharacter.None, 2f)
		{
		}

		// Token: 0x06004C9C RID: 19612 RVA: 0x0026C9B7 File Offset: 0x0026B9B7
		public DataMatrixBarcode(byte[] value, float x, float y, DataMatrixSymbolSize dataMatrixSymbolSize) : this(value, x, y, dataMatrixSymbolSize, DataMatrixEncodingType.Auto, DataMatrixFunctionCharacter.None, 2f)
		{
		}

		// Token: 0x06004C9D RID: 19613 RVA: 0x0026C9CE File Offset: 0x0026B9CE
		public DataMatrixBarcode(string value, float x, float y, DataMatrixSymbolSize dataMatrixSymbolSize, DataMatrixEncodingType dataMatrixEncodingType) : this(value, x, y, dataMatrixSymbolSize, dataMatrixEncodingType, DataMatrixFunctionCharacter.None, 2f)
		{
		}

		// Token: 0x06004C9E RID: 19614 RVA: 0x0026C9E6 File Offset: 0x0026B9E6
		public DataMatrixBarcode(byte[] value, float x, float y, DataMatrixSymbolSize dataMatrixSymbolSize, DataMatrixEncodingType dataMatrixEncodingType) : this(value, x, y, dataMatrixSymbolSize, dataMatrixEncodingType, DataMatrixFunctionCharacter.None, 2f)
		{
		}

		// Token: 0x06004C9F RID: 19615 RVA: 0x0026C9FE File Offset: 0x0026B9FE
		public DataMatrixBarcode(byte[] value, float x, float y, DataMatrixSymbolSize dataMatrixSymbolSize, DataMatrixEncodingType dataMatrixEncodingType, DataMatrixFunctionCharacter dataMatrixFunctionCharacter) : this(value, x, y, dataMatrixSymbolSize, dataMatrixEncodingType, dataMatrixFunctionCharacter, 2f)
		{
		}

		// Token: 0x06004CA0 RID: 19616 RVA: 0x0026CA17 File Offset: 0x0026BA17
		public DataMatrixBarcode(string value, float x, float y, DataMatrixSymbolSize dataMatrixSymbolSize, DataMatrixEncodingType dataMatrixEncodingType, DataMatrixFunctionCharacter dataMatrixFunctionCharacter) : this(value, x, y, dataMatrixSymbolSize, dataMatrixEncodingType, dataMatrixFunctionCharacter, 2f)
		{
		}

		// Token: 0x06004CA1 RID: 19617 RVA: 0x0026CA30 File Offset: 0x0026BA30
		internal DataMatrixBarcode(byte[] A_0, float A_1, float A_2, int A_3, int A_4, ArrayList A_5, int[] A_6, DataMatrixSymbolSize A_7, float A_8) : base(A_1, A_2)
		{
			this.a = new u();
			this.a.x = A_0;
			base.X = A_1;
			base.Y = A_2;
			this.a.h(A_3);
			this.a.f(A_4);
			this.a.y = A_5;
			this.a.aa = A_6;
			this.a.j((int)A_7);
			this.a.b(true);
			base.XDimension = A_8;
		}

		// Token: 0x06004CA2 RID: 19618 RVA: 0x0026CAC9 File Offset: 0x0026BAC9
		internal DataMatrixBarcode(string A_0, float A_1, float A_2, DataMatrixSymbolSize A_3, DataMatrixEncodingType A_4, DataMatrixFunctionCharacter A_5, float A_6) : base(A_1, A_2)
		{
			this.c = A_0;
			this.a(af.a(A_0, false), A_3, A_4, A_5, A_6);
		}

		// Token: 0x06004CA3 RID: 19619 RVA: 0x0026CAF3 File Offset: 0x0026BAF3
		internal DataMatrixBarcode(byte[] A_0, float A_1, float A_2, DataMatrixSymbolSize A_3, DataMatrixEncodingType A_4, DataMatrixFunctionCharacter A_5, float A_6) : base(A_1, A_2)
		{
			this.a(A_0, A_3, A_4, A_5, A_6);
		}

		// Token: 0x06004CA4 RID: 19620 RVA: 0x0026CB10 File Offset: 0x0026BB10
		private void a(byte[] A_0, DataMatrixSymbolSize A_1, DataMatrixEncodingType A_2, DataMatrixFunctionCharacter A_3, float A_4)
		{
			this.a = new u(A_0);
			this.b = A_0;
			this.a.i((int)A_2);
			this.a.j((int)A_1);
			this.a.k((int)A_3);
			base.XDimension = A_4;
		}

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x06004CA6 RID: 19622 RVA: 0x0026CBC0 File Offset: 0x0026BBC0
		// (set) Token: 0x06004CA5 RID: 19621 RVA: 0x0026CB64 File Offset: 0x0026BB64
		public bool ProcessTilde
		{
			get
			{
				return this.a.i();
			}
			set
			{
				this.a.a(value);
				if (value)
				{
					if (!string.IsNullOrEmpty(this.c))
					{
						this.b = af.a(this.c, true);
						this.a.i(this.b);
					}
				}
			}
		}

		// Token: 0x06004CA7 RID: 19623 RVA: 0x0026CBE0 File Offset: 0x0026BBE0
		public override void Draw(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				base.e(writer);
			}
			try
			{
				BitArray a_ = this.a.j(this.b);
				int af = this.a.af;
				int ae = this.a.ae;
				byte[] a_2 = BarCode.a(a_, base.PixelsPerXDimension, base.PixelsPerXDimension, af, ae);
				if (base.Angle != 0f)
				{
					writer.SetDimensionsSimpleRotate(base.X, base.Y, base.Angle);
				}
				writer.SetFillColor(base.Color);
				writer.a(base.X, base.Y + (float)ae * base.XDimension, (float)af * base.XDimension, (float)ae * base.XDimension, af * base.PixelsPerXDimension, ae * base.PixelsPerXDimension, a_2);
				if (base.Angle != 0f)
				{
					writer.ResetDimensions();
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
			if (writer.Document.Tag != null)
			{
				Tag.a(writer);
			}
		}

		// Token: 0x06004CA8 RID: 19624 RVA: 0x0026CD78 File Offset: 0x0026BD78
		public DataMatrixBarcode GetOverFlowDataMatrixBarcode(float x, float y)
		{
			DataMatrixBarcode result;
			try
			{
				if (this.a.j())
				{
					int[] a_ = new int[]
					{
						233,
						this.a.a(this.a.e() + 1, this.a.c()),
						this.a.aa[2],
						this.a.aa[3]
					};
					result = new DataMatrixBarcode((byte[])this.a.y[this.a.e()], x, y, this.a.e() + 1, this.a.c(), this.a.y, a_, (DataMatrixSymbolSize)this.a.g(), base.XDimension)
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

		// Token: 0x06004CA9 RID: 19625 RVA: 0x0026CEE8 File Offset: 0x0026BEE8
		public DataMatrixBarcode GetOverFlowDataMatrixBarcode()
		{
			return this.GetOverFlowDataMatrixBarcode(base.X, base.Y);
		}

		// Token: 0x06004CAA RID: 19626 RVA: 0x0026CF0C File Offset: 0x0026BF0C
		public override float GetSymbolHeight()
		{
			return (float)this.a.k() * base.XDimension;
		}

		// Token: 0x06004CAB RID: 19627 RVA: 0x0026CF34 File Offset: 0x0026BF34
		public override float GetSymbolWidth()
		{
			return (float)this.a.l() * base.XDimension;
		}

		// Token: 0x04002970 RID: 10608
		private new u a;

		// Token: 0x04002971 RID: 10609
		private byte[] b;

		// Token: 0x04002972 RID: 10610
		private string c;
	}
}
