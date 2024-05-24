using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003B2 RID: 946
	internal class ys : yg
	{
		// Token: 0x0600281B RID: 10267 RVA: 0x00174008 File Offset: 0x00173008
		internal ys(TiffImageData A_0, yj A_1)
		{
			this.f = A_0;
			if (A_0.f()[0] == 32U)
			{
				throw new ImageParsingException("32 bit TIFF image is not supported.");
			}
			uint num = A_0.f()[0];
			for (int i = 1; i < A_0.f().Length; i++)
			{
				if (A_0.f()[i] != num)
				{
					throw new ImageParsingException("Tiff image with different bits per sample is not supported.");
				}
			}
			bool flag = false;
			uint[] array = null;
			uint[] array2 = null;
			uint num2 = 0U;
			byte[] array3 = null;
			if (A_0.j() == 3)
			{
				A_0.a(2);
			}
			if (A_1.b(266U))
			{
				flag = (A_1.e() == 2);
			}
			if (A_1.b(273U))
			{
				array = A_1.k();
			}
			if (A_1.b(279U))
			{
				array2 = A_1.k();
			}
			if (A_1.b(320U))
			{
				this.d = A_1.n();
			}
			if (A_1.b(34665U))
			{
				num2 = A_1.i();
			}
			if (A_1.b(34675U))
			{
				array3 = A_1.m();
			}
			A_1.c(320U);
			switch (A_0.j())
			{
			case 0:
				this.e = 1;
				goto IL_20D;
			case 1:
				this.e = 1;
				goto IL_20D;
			case 2:
				this.e = 3;
				goto IL_20D;
			case 3:
				A_0.a(2);
				this.e = 1;
				goto IL_20D;
			case 4:
				throw new ImageParsingException("TIFF Transparency mask can not be drawn.");
			case 5:
				this.e = 4;
				goto IL_20D;
			case 6:
				throw new ImageParsingException("YCbCr TIFF format is not supported.");
			case 8:
				this.e = 3;
				goto IL_20D;
			}
			throw new ImageParsingException("Invalid TIFF PhotometricInterpretation.");
			IL_20D:
			uint num3 = 0U;
			if (array2 != null)
			{
				foreach (uint num4 in array2)
				{
					num3 += num4;
				}
			}
			else if (array.Length == 1)
			{
				num3 = (uint)(A_1.p() - (int)array[0]);
				array2 = new uint[]
				{
					num3
				};
			}
			byte[] array5 = new byte[num3];
			int num5 = 0;
			for (int i = 0; i < array.Length; i++)
			{
				A_1.a(array[i], array5, num5, (int)array2[i]);
				num5 += (int)array2[i];
			}
			if (flag)
			{
				base.a(this.c);
			}
			if ((long)this.e < (long)((ulong)A_0.e()))
			{
				if (A_0.j() != 2 && A_0.j() != 5)
				{
					throw new ImageParsingException("TIFF Transparency mask can not be read.");
				}
				int num6 = (int)(A_0.e() - (uint)this.e);
				if (num6 != 1)
				{
					throw new ImageParsingException("TIFF Transparency mask can not be drawn (extra bytes > 1).");
				}
				if (!A_1.b(338U) || A_1.e() == 0)
				{
					throw new ImageParsingException("TIFF Transparency mask can not be drawn (unspecified data present).");
				}
				if (A_1.e() == 1)
				{
					this.b = true;
				}
				A_0.a(2);
				int k = 0;
				int num7 = 0;
				int num8 = 0;
				if (A_0.j() == 2)
				{
					this.a = new byte[A_0.Width * A_0.Height];
					this.c = new byte[this.a.Length * 3];
					while (k < array5.Length)
					{
						this.c[num7++] = array5[k++];
						this.c[num7++] = array5[k++];
						this.c[num7++] = array5[k++];
						this.a[num8++] = array5[k++];
					}
				}
				else if (num == 16U)
				{
					this.a = new byte[A_0.Width * A_0.Height * 2];
					this.c = new byte[this.a.Length * 4];
					while (k < array5.Length && num8 < this.a.Length)
					{
						this.c[num7++] = array5[k++];
						this.c[num7++] = array5[k++];
						this.c[num7++] = array5[k++];
						this.c[num7++] = array5[k++];
						this.c[num7++] = array5[k++];
						this.c[num7++] = array5[k++];
						this.c[num7++] = array5[k++];
						this.c[num7++] = array5[k++];
						this.a[num8++] = array5[k++];
						this.a[num8++] = array5[k++];
					}
				}
				else
				{
					this.a = new byte[A_0.Width * A_0.Height];
					this.c = new byte[this.a.Length * 4];
					while (k < array5.Length && num8 < this.a.Length)
					{
						this.c[num7++] = array5[k++];
						this.c[num7++] = array5[k++];
						this.c[num7++] = array5[k++];
						this.c[num7++] = array5[k++];
						this.a[num8++] = array5[k++];
					}
				}
			}
			else if (A_0.i() && num == 16U)
			{
				this.c = new byte[array5.Length];
				for (int i = 0; i < array5.Length; i += 2)
				{
					this.c[i] = array5[i + 1];
					this.c[i + 1] = array5[i];
				}
			}
			else
			{
				this.c = array5;
			}
			if (array3 != null)
			{
				this.j = new bn(array3);
			}
			if (num2 != 0U)
			{
				this.k = A_1.d(num2);
			}
		}

		// Token: 0x0600281C RID: 10268 RVA: 0x00174730 File Offset: 0x00173730
		internal override byte[] gx()
		{
			return this.c;
		}

		// Token: 0x0600281D RID: 10269 RVA: 0x00174748 File Offset: 0x00173748
		internal override void gy(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(yg.g);
			A_0.WriteName(yg.k);
			A_0.WriteName(yg.h);
			A_0.WriteName(yg.l);
			if (this.f.Interpolate)
			{
				A_0.WriteName(yg.a);
				A_0.WriteBoolean(true);
			}
			A_0.WriteName(yg.b);
			A_0.WriteNumber(this.f.Width);
			A_0.WriteName(yg.c);
			A_0.WriteNumber(this.f.Height);
			A_0.WriteName(yg.d);
			A_0.WriteNumber(this.f.f()[0]);
			switch (this.f.j())
			{
			case 0:
				A_0.WriteName(yg.t);
				A_0.WriteArrayOpen();
				A_0.WriteNumber1();
				A_0.WriteNumber0();
				A_0.WriteArrayClose();
				break;
			case 1:
				break;
			case 2:
				A_0.WriteName(yg.e);
				if (this.j != null && this.j.b() == 3)
				{
					A_0.WriteArrayOpen();
					A_0.WriteName(yg.x);
					A_0.WriteReference(this.j.a());
					A_0.WriteArrayClose();
				}
				else if (this.k == 1)
				{
					byte[] iccProfile = (byte[])Document.a.GetObject("sRGBColorSpaceProfile");
					IccProfile resource = new IccProfile(iccProfile);
					A_0.WriteArrayOpen();
					A_0.WriteName(yg.x);
					A_0.WriteReference(resource);
					A_0.WriteArrayClose();
				}
				else
				{
					A_0.WriteName(yg.r);
				}
				goto IL_3AF;
			case 3:
				A_0.WriteName(yg.e);
				A_0.WriteArrayOpen();
				A_0.WriteName(yg.w);
				if (this.j != null && this.j.b() == 3)
				{
					A_0.WriteArrayOpen();
					A_0.WriteName(yg.x);
					A_0.WriteReference(this.j.a());
					A_0.WriteArrayClose();
				}
				else
				{
					A_0.WriteName(yg.r);
				}
				A_0.WriteNumber(this.d.Length / 3 - 1);
				A_0.WriteReference(A_0.GetObjectNumber(1));
				A_0.WriteArrayClose();
				goto IL_3AF;
			case 4:
				throw new ImageParsingException("TIFF Transparency mask can not be drawn.");
			case 5:
				A_0.WriteName(yg.e);
				if (this.j != null && this.j.b() == 4)
				{
					A_0.WriteArrayOpen();
					A_0.WriteName(yg.x);
					A_0.WriteReference(this.j.a());
					A_0.WriteArrayClose();
				}
				else
				{
					A_0.WriteName(yg.s);
				}
				goto IL_3AF;
			case 6:
				throw new ImageParsingException("YCbCr TIFF format is not supported.");
			case 7:
				goto IL_3A4;
			case 8:
				A_0.WriteName(yg.e);
				A_0.WriteName(yg.u);
				goto IL_3AF;
			default:
				goto IL_3A4;
			}
			A_0.WriteName(yg.e);
			if (this.j != null && this.j.b() == 1)
			{
				A_0.WriteArrayOpen();
				A_0.WriteName(yg.x);
				A_0.WriteReference(this.j.a());
				A_0.WriteArrayClose();
			}
			else
			{
				A_0.WriteName(yg.f);
			}
			goto IL_3AF;
			IL_3A4:
			throw new ImageParsingException("Invalid TIFF PhotometricInterpretation.");
			IL_3AF:
			A_0.WriteName(yg.j);
			A_0.ai(this.c.Length);
			if (this.a != null)
			{
				A_0.WriteName(ImageData.l);
				A_0.WriteReference(A_0.GetObjectNumber(1));
			}
			A_0.WriteDictionaryClose();
			A_0.WriteStream(this.c, this.c.Length);
			A_0.WriteEndObject();
			if (this.a != null)
			{
				A_0.WriteBeginObject();
				A_0.WriteDictionaryOpen();
				A_0.WriteName(yg.g);
				A_0.WriteName(yg.k);
				A_0.WriteName(Resource.b);
				A_0.WriteName(yg.l);
				A_0.WriteName(yg.b);
				A_0.WriteNumber(this.f.Width);
				A_0.WriteName(yg.c);
				A_0.WriteNumber(this.f.Height);
				A_0.WriteName(yg.d);
				A_0.WriteNumber(8);
				if (this.b)
				{
					switch (this.f.j())
					{
					case 0:
						A_0.WriteName(ys.g);
						break;
					case 1:
						A_0.WriteName(ys.g);
						break;
					case 2:
						A_0.WriteName(ys.h);
						break;
					case 3:
						A_0.WriteName(ys.h);
						break;
					case 5:
						A_0.WriteName(ys.i);
						break;
					case 8:
						A_0.WriteName(ys.h);
						break;
					}
				}
				A_0.WriteName(yg.e);
				A_0.WriteName(yg.f);
				A_0.WriteName(yg.j);
				A_0.ai(this.a.Length);
				A_0.WriteDictionaryClose();
				A_0.WriteStream(this.a, this.a.Length);
				A_0.WriteEndObject();
			}
			if (this.d != null)
			{
				A_0.WriteBeginObject();
				A_0.WriteDictionaryOpen();
				A_0.WriteName(yg.j);
				A_0.ai(this.d.Length);
				A_0.WriteDictionaryClose();
				A_0.WriteStream(this.d, this.d.Length);
				A_0.WriteEndObject();
			}
		}

		// Token: 0x0400119A RID: 4506
		private new byte[] a = null;

		// Token: 0x0400119B RID: 4507
		private new bool b = false;

		// Token: 0x0400119C RID: 4508
		private new byte[] c = null;

		// Token: 0x0400119D RID: 4509
		private new byte[] d = null;

		// Token: 0x0400119E RID: 4510
		private new int e;

		// Token: 0x0400119F RID: 4511
		private new TiffImageData f;

		// Token: 0x040011A0 RID: 4512
		private new static byte[] g = new byte[]
		{
			77,
			97,
			116,
			116,
			101,
			91,
			48,
			93
		};

		// Token: 0x040011A1 RID: 4513
		private new static byte[] h = new byte[]
		{
			77,
			97,
			116,
			116,
			101,
			91,
			48,
			32,
			48,
			32,
			48,
			93
		};

		// Token: 0x040011A2 RID: 4514
		private new static byte[] i = new byte[]
		{
			77,
			97,
			116,
			116,
			101,
			91,
			48,
			32,
			48,
			32,
			48,
			32,
			48,
			93
		};

		// Token: 0x040011A3 RID: 4515
		private new bn j = null;

		// Token: 0x040011A4 RID: 4516
		private new int k = 0;
	}
}
