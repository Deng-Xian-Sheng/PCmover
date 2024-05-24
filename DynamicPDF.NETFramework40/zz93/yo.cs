using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003AE RID: 942
	internal class yo : yg
	{
		// Token: 0x0600280A RID: 10250 RVA: 0x00171A20 File Offset: 0x00170A20
		public yo(TiffImageData A_0, yj A_1)
		{
			this.a = A_0;
			uint num = 0U;
			uint num2 = 0U;
			uint[] array = null;
			uint num3 = 0U;
			byte[] array2 = null;
			if (A_1.b(279U))
			{
				array = A_1.k();
			}
			if (A_1.b(512U))
			{
				A_1.e();
			}
			if (A_1.b(513U))
			{
				num = A_1.i();
			}
			if (A_1.b(514U))
			{
				num2 = A_1.i();
			}
			if (A_1.b(34665U))
			{
				num3 = A_1.i();
			}
			if (A_1.b(34675U))
			{
				array2 = A_1.m();
			}
			if (num > 0U)
			{
				for (int i = 0; i < array.Length; i++)
				{
					num2 += array[i];
				}
				this.b = new byte[num2];
				A_1.a(num, this.b, 0, this.b.Length);
				if (array2 != null)
				{
					this.c = new bn(array2);
				}
				if (num3 != 0U)
				{
					this.d = A_1.d(num3);
				}
				return;
			}
			throw new ImageParsingException("JPEG in TIFF without Interchange Format data is not supported.");
		}

		// Token: 0x0600280B RID: 10251 RVA: 0x00171B94 File Offset: 0x00170B94
		internal override byte[] gx()
		{
			return this.b;
		}

		// Token: 0x0600280C RID: 10252 RVA: 0x00171BAC File Offset: 0x00170BAC
		internal override void gy(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(yg.g);
			A_0.WriteName(yg.k);
			A_0.WriteName(yg.h);
			A_0.WriteName(yg.l);
			if (this.a.Interpolate)
			{
				A_0.WriteName(yg.a);
				A_0.WriteBoolean(true);
			}
			A_0.WriteName(yg.b);
			A_0.WriteNumber(this.a.Width);
			A_0.WriteName(yg.c);
			A_0.WriteNumber(this.a.Height);
			A_0.WriteName(yg.d);
			A_0.WriteNumber(this.a.f()[0]);
			switch (this.a.j())
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
				if (this.c != null && this.c.b() == 3)
				{
					A_0.WriteArrayOpen();
					A_0.WriteName(yg.x);
					A_0.WriteReference(this.c.a());
					A_0.WriteArrayClose();
				}
				else if (this.d == 1)
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
				goto IL_344;
			case 3:
				goto IL_339;
			case 4:
				throw new ImageParsingException("TIFF Transparency mask can not be drawn.");
			case 5:
				A_0.WriteName(yg.e);
				if (this.c != null && this.c.b() == 4)
				{
					A_0.WriteArrayOpen();
					A_0.WriteName(yg.x);
					A_0.WriteReference(this.c.a());
					A_0.WriteArrayClose();
				}
				else
				{
					A_0.WriteName(yg.s);
				}
				goto IL_344;
			case 6:
				A_0.WriteName(yg.e);
				if (this.c != null && this.c.b() == 3)
				{
					A_0.WriteArrayOpen();
					A_0.WriteName(yg.x);
					A_0.WriteReference(this.c.a());
					A_0.WriteArrayClose();
				}
				else
				{
					A_0.WriteName(yg.r);
				}
				goto IL_344;
			default:
				goto IL_339;
			}
			A_0.WriteName(yg.e);
			if (this.c != null && this.c.b() == 1)
			{
				A_0.WriteArrayOpen();
				A_0.WriteName(yg.x);
				A_0.WriteReference(this.c.a());
				A_0.WriteArrayClose();
			}
			else
			{
				A_0.WriteName(yg.f);
			}
			goto IL_344;
			IL_339:
			throw new ImageParsingException("Invalid TIFF PhotometricInterpretation.");
			IL_344:
			A_0.WriteName(yg.i);
			A_0.WriteArrayOpen();
			A_0.WriteName(yo.e);
			A_0.WriteArrayClose();
			A_0.WriteName(yg.j);
			A_0.ai(this.b.Length);
			A_0.WriteDictionaryClose();
			A_0.WriteStream(this.b, this.b.Length);
			A_0.WriteEndObject();
		}

		// Token: 0x04001180 RID: 4480
		private new TiffImageData a;

		// Token: 0x04001181 RID: 4481
		private new byte[] b = null;

		// Token: 0x04001182 RID: 4482
		private new bn c = null;

		// Token: 0x04001183 RID: 4483
		private new int d = 0;

		// Token: 0x04001184 RID: 4484
		private new static byte[] e = new byte[]
		{
			68,
			67,
			84,
			68,
			101,
			99,
			111,
			100,
			101
		};
	}
}
