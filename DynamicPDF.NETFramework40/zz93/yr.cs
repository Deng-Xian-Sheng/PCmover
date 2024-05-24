using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003B1 RID: 945
	internal class yr : yg
	{
		// Token: 0x06002817 RID: 10263 RVA: 0x00173990 File Offset: 0x00172990
		internal yr(TiffImageData A_0, yj A_1)
		{
			this.c = A_0;
			bool flag = false;
			uint[] array = null;
			uint[] array2 = null;
			uint num = 0U;
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
				this.b = A_1.n();
			}
			if (A_1.b(34665U))
			{
				num = A_1.i();
			}
			if (A_1.b(34675U))
			{
				array3 = A_1.m();
			}
			uint num2 = 0U;
			foreach (uint num3 in array2)
			{
				num2 += num3;
			}
			this.a = new byte[num2];
			int num4 = 0;
			for (int j = 0; j < array.Length; j++)
			{
				A_1.a(array[j], this.a, num4, (int)array2[j]);
				num4 += (int)array2[j];
			}
			if (flag)
			{
				base.a(this.a);
			}
			if (array3 != null)
			{
				this.e = new bn(array3);
			}
			if (num != 0U)
			{
				this.f = A_1.d(num);
			}
		}

		// Token: 0x06002818 RID: 10264 RVA: 0x00173B5C File Offset: 0x00172B5C
		internal override byte[] gx()
		{
			return this.a;
		}

		// Token: 0x06002819 RID: 10265 RVA: 0x00173B74 File Offset: 0x00172B74
		internal override void gy(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(yg.g);
			A_0.WriteName(yg.k);
			A_0.WriteName(yg.h);
			A_0.WriteName(yg.l);
			if (this.c.Interpolate)
			{
				A_0.WriteName(yg.a);
				A_0.WriteBoolean(true);
			}
			A_0.WriteName(yg.b);
			A_0.WriteNumber(this.c.Width);
			A_0.WriteName(yg.c);
			A_0.WriteNumber(this.c.Height);
			A_0.WriteName(yg.d);
			A_0.WriteNumber(this.c.f()[0]);
			switch (this.c.j())
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
				if (this.e != null && this.e.b() == 3)
				{
					A_0.WriteArrayOpen();
					A_0.WriteName(yg.x);
					A_0.WriteReference(this.e.a());
					A_0.WriteArrayClose();
				}
				else if (this.f == 1)
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
				if (this.e != null && this.e.b() == 3)
				{
					A_0.WriteArrayOpen();
					A_0.WriteName(yg.x);
					A_0.WriteReference(this.e.a());
					A_0.WriteArrayClose();
				}
				else
				{
					A_0.WriteName(yg.r);
				}
				A_0.WriteNumber(this.b.Length / 3 - 1);
				A_0.WriteReference(A_0.GetObjectNumber(1));
				A_0.WriteArrayClose();
				goto IL_3AF;
			case 4:
				throw new ImageParsingException("TIFF Transparency mask can not be drawn.");
			case 5:
				A_0.WriteName(yg.e);
				if (this.e != null && this.e.b() == 4)
				{
					A_0.WriteArrayOpen();
					A_0.WriteName(yg.x);
					A_0.WriteReference(this.e.a());
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
			if (this.e != null && this.e.b() == 1)
			{
				A_0.WriteArrayOpen();
				A_0.WriteName(yg.x);
				A_0.WriteReference(this.e.a());
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
			A_0.WriteName(yg.i);
			A_0.WriteArrayOpen();
			A_0.WriteName(yr.d);
			A_0.WriteArrayClose();
			A_0.WriteName(yg.j);
			A_0.ai(this.a.Length);
			A_0.WriteDictionaryClose();
			A_0.WriteStream(this.a, this.a.Length);
			A_0.WriteEndObject();
			if (this.b != null)
			{
				A_0.WriteBeginObject();
				A_0.WriteDictionaryOpen();
				A_0.WriteName(yg.j);
				A_0.ai(this.b.Length);
				A_0.WriteDictionaryClose();
				A_0.WriteStream(this.b, this.b.Length);
				A_0.WriteEndObject();
			}
		}

		// Token: 0x04001194 RID: 4500
		private new byte[] a = null;

		// Token: 0x04001195 RID: 4501
		private new byte[] b = null;

		// Token: 0x04001196 RID: 4502
		private new TiffImageData c;

		// Token: 0x04001197 RID: 4503
		private new static byte[] d = new byte[]
		{
			82,
			117,
			110,
			76,
			101,
			110,
			103,
			116,
			104,
			68,
			101,
			99,
			111,
			100,
			101
		};

		// Token: 0x04001198 RID: 4504
		private new bn e = null;

		// Token: 0x04001199 RID: 4505
		private new int f = 0;
	}
}
