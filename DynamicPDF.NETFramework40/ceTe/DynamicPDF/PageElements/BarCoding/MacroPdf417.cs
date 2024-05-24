using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000772 RID: 1906
	public class MacroPdf417 : Pdf417
	{
		// Token: 0x06004D66 RID: 19814 RVA: 0x00270DD6 File Offset: 0x0026FDD6
		public MacroPdf417(string value, float x, float y, int columns, float xDimension) : base(value, x, y, columns, xDimension)
		{
		}

		// Token: 0x06004D67 RID: 19815 RVA: 0x00270DE8 File Offset: 0x0026FDE8
		public MacroPdf417(byte[] values, float x, float y, int columns, float xDimension) : base(values, x, y, columns, xDimension)
		{
		}

		// Token: 0x06004D68 RID: 19816 RVA: 0x00270DFA File Offset: 0x0026FDFA
		public MacroPdf417(byte[] values, float x, float y, int columns, int rows, float xDimension) : base(values, x, y, columns, rows, xDimension)
		{
		}

		// Token: 0x06004D69 RID: 19817 RVA: 0x00270E0E File Offset: 0x0026FE0E
		public MacroPdf417(string value, float x, float y, int columns, int rows, float xDimension) : base(value, x, y, columns, rows, xDimension)
		{
		}

		// Token: 0x06004D6A RID: 19818 RVA: 0x00270E24 File Offset: 0x0026FE24
		internal MacroPdf417(byte[] A_0, float A_1, float A_2, int A_3, int A_4, float A_5, int A_6, int A_7, ax A_8, int[] A_9, int[] A_10, ErrorCorrection A_11, Color A_12, bool A_13, float A_14, bool A_15, int A_16) : base(A_0, A_1, A_2, A_3, A_4, A_5)
		{
			try
			{
				this.b.f(A_7);
				this.b.g(A_6);
				this.b.a(A_8);
				this.b.e(A_9);
				this.b.b(A_10);
				this.b.j(0);
				this.b.d(A_16);
				this.b.f(A_15);
				base.ErrorCorrection = A_11;
				base.Color = A_12;
				base.CompactPdf417 = A_13;
				base.Angle = A_14;
				this.b.ab();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (ao ao)
			{
				throw new dt(ao.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
		}

		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x06004D6B RID: 19819 RVA: 0x00270F3C File Offset: 0x0026FF3C
		// (set) Token: 0x06004D6C RID: 19820 RVA: 0x00270F59 File Offset: 0x0026FF59
		public string FileName
		{
			get
			{
				return this.b.e();
			}
			set
			{
				this.b.b(value);
			}
		}

		// Token: 0x17000600 RID: 1536
		// (get) Token: 0x06004D6D RID: 19821 RVA: 0x00270F6C File Offset: 0x0026FF6C
		// (set) Token: 0x06004D6E RID: 19822 RVA: 0x00270F89 File Offset: 0x0026FF89
		public string Sender
		{
			get
			{
				return this.b.g();
			}
			set
			{
				this.b.c(value);
			}
		}

		// Token: 0x17000601 RID: 1537
		// (get) Token: 0x06004D6F RID: 19823 RVA: 0x00270F9C File Offset: 0x0026FF9C
		// (set) Token: 0x06004D70 RID: 19824 RVA: 0x00270FB9 File Offset: 0x0026FFB9
		public string Address
		{
			get
			{
				return this.b.k();
			}
			set
			{
				this.b.d(value);
			}
		}

		// Token: 0x17000602 RID: 1538
		// (set) Token: 0x06004D71 RID: 19825 RVA: 0x00270FC9 File Offset: 0x0026FFC9
		public bool IncludeFileSize
		{
			set
			{
				this.b.d(value);
			}
		}

		// Token: 0x17000603 RID: 1539
		// (set) Token: 0x06004D72 RID: 19826 RVA: 0x00270FD9 File Offset: 0x0026FFD9
		public bool IncludeCheckSum
		{
			set
			{
				this.b.b(value);
			}
		}

		// Token: 0x17000604 RID: 1540
		// (set) Token: 0x06004D73 RID: 19827 RVA: 0x00270FE9 File Offset: 0x0026FFE9
		public bool IncludeTimeStamp
		{
			set
			{
				this.b.c(value);
			}
		}

		// Token: 0x06004D74 RID: 19828 RVA: 0x00270FF9 File Offset: 0x0026FFF9
		public void SetFileID(int fileId)
		{
			this.b.e(fileId);
		}

		// Token: 0x06004D75 RID: 19829 RVA: 0x0027100C File Offset: 0x0027000C
		public void SetFileID(int[] fileIdArray)
		{
			this.b.e(-1);
			foreach (int num in fileIdArray)
			{
				if (num > 899 || num < 0)
				{
					throw new BarCodeException("Only base 900 numbers (0 to 899) are allowed in the array.");
				}
			}
			this.b.a(fileIdArray);
		}

		// Token: 0x06004D76 RID: 19830 RVA: 0x00271074 File Offset: 0x00270074
		public override float GetSymbolWidth()
		{
			float result;
			try
			{
				if (!this.b.z())
				{
					this.b.ad();
				}
				if (base.CompactPdf417)
				{
					result = (float)(35 + 17 * this.b.m()) * base.XDimension;
				}
				else
				{
					result = (float)(17 * this.b.m() + 69) * base.XDimension;
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
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			return result;
		}

		// Token: 0x06004D77 RID: 19831 RVA: 0x00271140 File Offset: 0x00270140
		public override float GetSymbolHeight()
		{
			float result;
			try
			{
				if (!this.b.z())
				{
					this.b.ad();
				}
				result = (float)this.b.l() * base.YDimension;
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (ao ao)
			{
				throw new dt(ao.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			return result;
		}

		// Token: 0x06004D78 RID: 19832 RVA: 0x002711D8 File Offset: 0x002701D8
		public override void Draw(PageWriter writer)
		{
			try
			{
				if (this.b.y() == null)
				{
					this.b.ad();
					base.d(writer);
				}
				else
				{
					base.d(writer);
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
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
		}

		// Token: 0x06004D79 RID: 19833 RVA: 0x00271274 File Offset: 0x00270274
		public MacroPdf417 GetOverflowMacroPdf417()
		{
			MacroPdf417 result;
			try
			{
				if (!this.b.z())
				{
					this.b.ad();
					if (this.b.y().d() < this.b.n().Length)
					{
						result = new MacroPdf417(this.b.n(), base.X, base.Y, this.b.m(), this.b.l(), base.XDimension, this.b.y().d(), this.b.h(), this.b.y(), this.b.s(), this.b.i(), base.ErrorCorrection, base.Color, base.CompactPdf417, base.Angle, this.b.aa(), this.b.d());
					}
					else
					{
						result = null;
					}
				}
				else if (this.b.y().d() < this.b.n().Length)
				{
					result = new MacroPdf417(this.b.n(), base.X, base.Y, this.b.m(), this.b.l(), base.XDimension, this.b.y().d(), this.b.h(), this.b.y(), this.b.s(), this.b.i(), base.ErrorCorrection, base.Color, base.CompactPdf417, base.Angle, this.b.aa(), this.b.d());
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
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			return result;
		}

		// Token: 0x06004D7A RID: 19834 RVA: 0x002714D0 File Offset: 0x002704D0
		public MacroPdf417 GetOverflowMacroPdf417(float x, float y)
		{
			MacroPdf417 result;
			try
			{
				if (!this.b.z())
				{
					this.b.ad();
					if (this.b.y().d() < this.b.n().Length)
					{
						result = new MacroPdf417(this.b.n(), x, y, this.b.m(), this.b.l(), base.XDimension, this.b.y().d(), this.b.h(), this.b.y(), this.b.s(), this.b.i(), base.ErrorCorrection, base.Color, base.CompactPdf417, base.Angle, this.b.aa(), this.b.d())
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
				else if (this.b.y().d() < this.b.n().Length)
				{
					result = new MacroPdf417(this.b.n(), x, y, this.b.m(), this.b.l(), base.XDimension, this.b.y().d(), this.b.h(), this.b.y(), this.b.s(), this.b.i(), base.ErrorCorrection, base.Color, base.CompactPdf417, base.Angle, this.b.aa(), this.b.d())
					{
						TagOrder = this.TagOrder,
						Tag = this.Tag
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
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			return result;
		}
	}
}
