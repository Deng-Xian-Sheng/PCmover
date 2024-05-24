using System;
using System.IO;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Imaging
{
	// Token: 0x0200087B RID: 2171
	public class PngImageData : ImageData
	{
		// Token: 0x0600585E RID: 22622 RVA: 0x003350C0 File Offset: 0x003340C0
		public PngImageData(string filePath)
		{
			FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			this.o = new byte[fileStream.Length];
			fileStream.Read(this.o, 0, this.o.Length);
			fileStream.Close();
			this.b(this.o);
		}

		// Token: 0x0600585F RID: 22623 RVA: 0x0033515C File Offset: 0x0033415C
		public PngImageData(Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			this.b(array);
		}

		// Token: 0x06005860 RID: 22624 RVA: 0x003351D4 File Offset: 0x003341D4
		public static bool IsValid(string fileExtension)
		{
			return fileExtension == "png";
		}

		// Token: 0x06005861 RID: 22625 RVA: 0x003351F4 File Offset: 0x003341F4
		public static bool IsValid(byte[] header)
		{
			return header[0] == 137 && header[1] == 80 && header[2] == 78 && header[3] == 71 && header[4] == 13 && header[5] == 10 && header[6] == 26 && header[7] == 10;
		}

		// Token: 0x06005862 RID: 22626 RVA: 0x00335248 File Offset: 0x00334248
		private new void b(byte[] A_0)
		{
			yd yd = new yd(A_0);
			int num = yd.b();
			if (num != 1229472850)
			{
				throw new ImageParsingException("PNG file can not be read or is corrupt.");
			}
			this.e(yd);
			byte[] array = null;
			while ((num = yd.a()) != 1229209940)
			{
				int num2 = num;
				if (num2 <= 1766015824)
				{
					if (num2 != 1347179589)
					{
						if (num2 == 1766015824)
						{
							this.a(yd);
						}
					}
					else
					{
						this.d(yd);
					}
				}
				else if (num2 != 1883789683)
				{
					if (num2 == 1951551059)
					{
						array = this.b(yd);
					}
				}
				else
				{
					this.c(yd);
				}
			}
			while (num != 1229209940)
			{
				num = yd.a();
			}
			zp zp = new zp(A_0.Length - yd.g() - 16);
			while (num == 1229209940)
			{
				zp.a(A_0, yd.g(), yd.h());
				num = yd.a();
			}
			if (zp == null)
			{
				throw new ImageParsingException("PNG file can not be read or is corrupt.");
			}
			if (this.e == 6 || this.e == 4)
			{
				zf zf = new zf(zp.b(), this.a, this.b, this.e == 4, this.c / 8);
				this.f = zf.a();
				this.h = zf.b();
				this.c();
				this.a();
				this.d = 2;
			}
			else if (this.c == 16)
			{
				zf zf = new zf();
				this.f = zf.e(zp.b(), this.a, this.b);
				this.c();
				if (array != null)
				{
					this.a(array);
				}
			}
			else
			{
				this.f = new byte[zp.a()];
				Array.Copy(zp.b(), 0, this.f, 0, this.f.Length);
				if (array != null)
				{
					this.a(array);
				}
			}
		}

		// Token: 0x06005863 RID: 22627 RVA: 0x00335490 File Offset: 0x00334490
		private new void a(byte[] A_0)
		{
			switch (this.e)
			{
			case 1:
				this.i = new int[2];
				this.i[0] = ((int)A_0[0] << 8 | (int)A_0[1]);
				this.i[1] = this.i[0];
				break;
			case 2:
				this.i = new int[6];
				this.i[0] = ((int)A_0[0] << 8 | (int)A_0[1]);
				this.i[1] = this.i[0];
				this.i[2] = ((int)A_0[2] << 8 | (int)A_0[3]);
				this.i[3] = this.i[2];
				this.i[4] = ((int)A_0[4] << 8 | (int)A_0[5]);
				this.i[5] = this.i[4];
				break;
			case 3:
			{
				bool flag = false;
				int num = 0;
				byte b = byte.MaxValue;
				for (int i = 0; i < A_0.Length; i++)
				{
					if (A_0[i] != 0 & A_0[i] != 255)
					{
						flag = true;
						break;
					}
					if (b != A_0[i])
					{
						num++;
						b = A_0[i];
					}
				}
				if (flag)
				{
					y9 y = new y9(this.a, this.b, this.c);
					y.f(this.f);
					y.a(A_0);
					this.h = y.a();
					this.a();
					this.d = 3;
				}
				else
				{
					if (num % 2 == 1)
					{
						num++;
					}
					this.i = new int[num];
					b = byte.MaxValue;
					int num2 = 0;
					for (int j = 0; j < A_0.Length; j++)
					{
						if (b != A_0[j])
						{
							b = A_0[j];
							this.i[num2++] = j;
						}
					}
					if (num2 < this.i.Length)
					{
						this.i[num2] = A_0.Length - 1;
					}
				}
				break;
			}
			}
		}

		// Token: 0x06005864 RID: 22628 RVA: 0x003356AC File Offset: 0x003346AC
		private new void e(yd A_0)
		{
			this.a = A_0.c();
			this.b = A_0.c();
			this.c = (int)A_0.d();
			this.e = (int)A_0.d();
			int num = (int)A_0.d();
			int num2 = (int)A_0.d();
			int num3 = (int)A_0.d();
			if (num != 0)
			{
				throw new ImageParsingException("PNG file uses an unrecognized compression method.");
			}
			if (num2 != 0)
			{
				throw new ImageParsingException("PNG file uses an unrecognized filter method.");
			}
			if (num3 != 0)
			{
				throw new ImageParsingException("PNG file is interlaced. Interlaced PNGs are not supported.");
			}
		}

		// Token: 0x06005865 RID: 22629 RVA: 0x00335738 File Offset: 0x00334738
		private new void d(yd A_0)
		{
			this.g = A_0.e();
			this.d = 2;
		}

		// Token: 0x06005866 RID: 22630 RVA: 0x00335750 File Offset: 0x00334750
		private new void c(yd A_0)
		{
			int num = A_0.c();
			int num2 = A_0.c();
			byte b = A_0.d();
			if (b == 1)
			{
				this.j = 2834.6458f / (float)num;
				this.k = 2834.6458f / (float)num2;
			}
			else
			{
				float num3 = (float)(num + num2) / 0.48f;
				this.j = (float)num / num3;
				this.k = (float)num2 / num3;
			}
		}

		// Token: 0x06005867 RID: 22631 RVA: 0x003357C8 File Offset: 0x003347C8
		private new byte[] b(yd A_0)
		{
			return A_0.e();
		}

		// Token: 0x06005868 RID: 22632 RVA: 0x003357E0 File Offset: 0x003347E0
		private new void a(yd A_0)
		{
			byte[] array = A_0.f();
			za za = new za();
			za.a(array);
			array = new byte[array.Length * 3];
			int num = za.b(array);
			byte[] array2 = new byte[num];
			Array.Copy(array, array2, num);
			this.p = new bm(array2);
		}

		// Token: 0x170008D4 RID: 2260
		// (get) Token: 0x06005869 RID: 22633 RVA: 0x00335834 File Offset: 0x00334834
		public override int RequiredPdfObjects
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x170008D5 RID: 2261
		// (get) Token: 0x0600586A RID: 22634 RVA: 0x0033584C File Offset: 0x0033484C
		public override int Width
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170008D6 RID: 2262
		// (get) Token: 0x0600586B RID: 22635 RVA: 0x00335864 File Offset: 0x00334864
		public override int Height
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x170008D7 RID: 2263
		// (get) Token: 0x0600586C RID: 22636 RVA: 0x0033587C File Offset: 0x0033487C
		public override float ScaleX
		{
			get
			{
				return this.j;
			}
		}

		// Token: 0x170008D8 RID: 2264
		// (get) Token: 0x0600586D RID: 22637 RVA: 0x00335894 File Offset: 0x00334894
		public override float ScaleY
		{
			get
			{
				return this.k;
			}
		}

		// Token: 0x0600586E RID: 22638 RVA: 0x003358AC File Offset: 0x003348AC
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.g);
			writer.WriteName(Resource.b);
			writer.WriteName(Resource.h);
			if (base.Interpolate)
			{
				writer.WriteName(ImageData.a);
				writer.WriteBoolean(true);
			}
			writer.WriteName(ImageData.b);
			writer.WriteNumber(this.a);
			writer.WriteName(ImageData.c);
			writer.WriteNumber(this.b);
			writer.WriteName(ImageData.d);
			writer.WriteNumber(this.c);
			switch (this.e)
			{
			case 0:
				writer.WriteName(ImageData.e);
				if (this.p != null && this.p.b() == 1)
				{
					writer.WriteArrayOpen();
					writer.WriteName(ImageData.m);
					writer.WriteReference(this.p.a());
					writer.WriteArrayClose();
				}
				else
				{
					writer.WriteName(ImageData.f);
				}
				if (this.c == 8)
				{
					writer.WriteName(ImageData.j);
					writer.WriteArrayOpen();
					writer.WriteDictionaryOpen();
					writer.WriteName(PngImageData.l);
					writer.WriteNumber(15);
					writer.WriteName(PngImageData.m);
					writer.WriteNumber(this.a);
					writer.WriteDictionaryClose();
					writer.WriteArrayClose();
				}
				else
				{
					writer.WriteName(ImageData.j);
					writer.WriteArrayOpen();
					writer.WriteDictionaryOpen();
					writer.WriteName(PngImageData.l);
					writer.WriteNumber(15);
					writer.WriteName(PngImageData.m);
					writer.WriteNumber(this.a);
					writer.WriteName(ImageData.d);
					writer.WriteNumber(this.c);
					writer.WriteDictionaryClose();
					writer.WriteArrayClose();
				}
				break;
			case 2:
				writer.WriteName(ImageData.e);
				if (this.p != null && this.p.b() == 3)
				{
					writer.WriteArrayOpen();
					writer.WriteName(ImageData.m);
					writer.WriteReference(this.p.a());
					writer.WriteArrayClose();
				}
				else
				{
					writer.WriteName(ImageData.g);
				}
				if (this.c != 16)
				{
					writer.WriteName(ImageData.j);
					writer.WriteArrayOpen();
					writer.WriteDictionaryOpen();
					writer.WriteName(PngImageData.l);
					writer.WriteNumber(15);
					writer.WriteName(PngImageData.m);
					writer.WriteNumber(this.a);
					writer.WriteName(PngImageData.n);
					writer.WriteNumber(3);
					writer.WriteDictionaryClose();
					writer.WriteArrayClose();
				}
				break;
			case 3:
				writer.WriteName(ImageData.e);
				writer.WriteArrayOpen();
				writer.WriteName(ImageData.i);
				if (this.p != null && this.p.b() == 3)
				{
					writer.WriteArrayOpen();
					writer.WriteName(ImageData.m);
					writer.WriteReference(this.p.a());
					writer.WriteArrayClose();
				}
				else
				{
					writer.WriteName(ImageData.g);
				}
				writer.WriteNumber(this.g.Length / 3 - 1);
				writer.WriteReference(writer.GetObjectNumber(1));
				writer.WriteArrayClose();
				if (this.c == 8)
				{
					writer.WriteName(ImageData.j);
					writer.WriteArrayOpen();
					writer.WriteDictionaryOpen();
					writer.WriteName(PngImageData.l);
					writer.WriteNumber(15);
					writer.WriteName(PngImageData.m);
					writer.WriteNumber(this.a);
					writer.WriteDictionaryClose();
					writer.WriteArrayClose();
					if (this.h != null)
					{
						writer.WriteName(ImageData.l);
						writer.WriteReference(writer.GetObjectNumber(2));
					}
				}
				else
				{
					writer.WriteName(ImageData.j);
					writer.WriteArrayOpen();
					writer.WriteDictionaryOpen();
					writer.WriteName(PngImageData.l);
					writer.WriteNumber(15);
					writer.WriteName(PngImageData.m);
					writer.WriteNumber(this.a);
					writer.WriteName(ImageData.d);
					writer.WriteNumber(this.c);
					writer.WriteDictionaryClose();
					writer.WriteArrayClose();
					if (this.h != null)
					{
						writer.WriteName(ImageData.l);
						writer.WriteReference(writer.GetObjectNumber(2));
					}
				}
				break;
			case 4:
				writer.WriteName(ImageData.e);
				if (this.p != null && this.p.b() == 1)
				{
					writer.WriteArrayOpen();
					writer.WriteName(ImageData.m);
					writer.WriteReference(this.p.a());
					writer.WriteArrayClose();
				}
				else
				{
					writer.WriteName(ImageData.f);
				}
				writer.WriteName(ImageData.l);
				writer.WriteReference(writer.GetObjectNumber(1));
				break;
			case 6:
				writer.WriteName(ImageData.e);
				if (this.p != null && this.p.b() == 3)
				{
					writer.WriteArrayOpen();
					writer.WriteName(ImageData.m);
					writer.WriteReference(this.p.a());
					writer.WriteArrayClose();
				}
				else
				{
					writer.WriteName(ImageData.g);
				}
				writer.WriteName(ImageData.l);
				writer.WriteReference(writer.GetObjectNumber(1));
				break;
			}
			if (this.i != null)
			{
				writer.WriteName(ImageData.h);
				writer.WriteArrayOpen();
				for (int i = 0; i < this.i.Length; i++)
				{
					writer.WriteNumber(this.i[i]);
				}
				writer.WriteArrayClose();
			}
			writer.WriteName(Resource.c);
			writer.WriteArrayOpen();
			writer.WriteName(Resource.d);
			writer.WriteArrayClose();
			writer.WriteName(Resource.e);
			writer.ai(this.f.Length);
			writer.WriteDictionaryClose();
			writer.WriteStream(this.f, this.f.Length);
			writer.WriteEndObject();
			if (this.g != null)
			{
				writer.WriteBeginObject();
				writer.WriteDictionaryOpen();
				writer.WriteName(Resource.e);
				writer.ai(this.g.Length);
				writer.WriteDictionaryClose();
				writer.WriteStream(this.g, this.g.Length);
				writer.WriteEndObject();
			}
			if (this.h != null)
			{
				writer.WriteBeginObject();
				writer.WriteDictionaryOpen();
				writer.WriteName(Resource.a);
				writer.WriteName(Resource.g);
				writer.WriteName(Resource.b);
				writer.WriteName(Resource.h);
				if (base.Interpolate)
				{
					writer.WriteName(ImageData.a);
					writer.WriteBoolean(true);
				}
				writer.WriteName(ImageData.b);
				writer.WriteNumber(this.a);
				writer.WriteName(ImageData.c);
				writer.WriteNumber(this.b);
				writer.WriteName(ImageData.d);
				writer.WriteNumber(8);
				writer.WriteName(ImageData.e);
				writer.WriteName(ImageData.f);
				writer.WriteName(Resource.c);
				writer.WriteArrayOpen();
				writer.WriteName(Resource.d);
				writer.WriteArrayClose();
				writer.WriteName(Resource.e);
				writer.ai(this.h.Length);
				writer.WriteDictionaryClose();
				writer.WriteStream(this.h, this.h.Length);
				writer.WriteEndObject();
			}
		}

		// Token: 0x0600586F RID: 22639 RVA: 0x00336100 File Offset: 0x00335100
		internal override byte[] gs()
		{
			return this.o;
		}

		// Token: 0x06005870 RID: 22640 RVA: 0x00336118 File Offset: 0x00335118
		private new void c()
		{
			y0 y = new y0();
			y.b(this.f, 0, this.f.Length);
			y.b();
			byte[] array = new byte[(int)((float)this.f.Length * 1.002f + 12f)];
			int num = y.a(array);
			this.f = new byte[num];
			Array.Copy(array, 0, this.f, 0, num);
		}

		// Token: 0x06005871 RID: 22641 RVA: 0x0033618C File Offset: 0x0033518C
		private new void a()
		{
			y0 y = new y0();
			y.b(this.h, 0, this.h.Length);
			y.b();
			byte[] array = new byte[(int)((float)this.h.Length * 1.002f + 12f)];
			int num = y.a(array);
			this.h = new byte[num];
			Array.Copy(array, 0, this.h, 0, num);
		}

		// Token: 0x04002EEC RID: 12012
		private new int a;

		// Token: 0x04002EED RID: 12013
		private new int b;

		// Token: 0x04002EEE RID: 12014
		private new int c;

		// Token: 0x04002EEF RID: 12015
		private new int d = 1;

		// Token: 0x04002EF0 RID: 12016
		private new int e = 0;

		// Token: 0x04002EF1 RID: 12017
		private new byte[] f;

		// Token: 0x04002EF2 RID: 12018
		private new byte[] g = null;

		// Token: 0x04002EF3 RID: 12019
		private new byte[] h = null;

		// Token: 0x04002EF4 RID: 12020
		private new int[] i = null;

		// Token: 0x04002EF5 RID: 12021
		private new float j = 0.24f;

		// Token: 0x04002EF6 RID: 12022
		private new float k = 0.24f;

		// Token: 0x04002EF7 RID: 12023
		private new static byte[] l = new byte[]
		{
			80,
			114,
			101,
			100,
			105,
			99,
			116,
			111,
			114
		};

		// Token: 0x04002EF8 RID: 12024
		private new static byte[] m = new byte[]
		{
			67,
			111,
			108,
			117,
			109,
			110,
			115
		};

		// Token: 0x04002EF9 RID: 12025
		private static byte[] n = new byte[]
		{
			67,
			111,
			108,
			111,
			114,
			115
		};

		// Token: 0x04002EFA RID: 12026
		private byte[] o;

		// Token: 0x04002EFB RID: 12027
		private bm p = null;
	}
}
