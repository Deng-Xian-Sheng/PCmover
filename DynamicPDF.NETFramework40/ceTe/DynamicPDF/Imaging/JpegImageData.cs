using System;
using System.IO;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Imaging
{
	// Token: 0x0200087A RID: 2170
	public class JpegImageData : ImageData
	{
		// Token: 0x0600584E RID: 22606 RVA: 0x00334634 File Offset: 0x00333634
		public JpegImageData(string filePath)
		{
			FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			this.a(fileStream);
			fileStream.Close();
		}

		// Token: 0x0600584F RID: 22607 RVA: 0x003346A4 File Offset: 0x003336A4
		public JpegImageData(Stream stream)
		{
			this.a(stream);
		}

		// Token: 0x06005850 RID: 22608 RVA: 0x00334704 File Offset: 0x00333704
		public static bool IsValid(string fileExtension)
		{
			return fileExtension == "jpg" || fileExtension == "jpeg" || fileExtension == "jpe";
		}

		// Token: 0x06005851 RID: 22609 RVA: 0x00334740 File Offset: 0x00333740
		public static bool IsValid(byte[] header)
		{
			return header[0] == byte.MaxValue && header[1] == 216 && header[2] == byte.MaxValue;
		}

		// Token: 0x06005852 RID: 22610 RVA: 0x00334774 File Offset: 0x00333774
		private new void a(Stream A_0)
		{
			this.f = new byte[A_0.Length];
			A_0.Seek(0L, SeekOrigin.Begin);
			A_0.Read(this.f, 0, (int)A_0.Length);
			if (this.f[0] != 255 && this.f[1] != 216 && this.f[2] != 255)
			{
				throw new ImageParsingException("Invalid JPEG File.");
			}
			yc yc = new yc(this.f);
			int num = yc.a();
			while (num != 218)
			{
				int num2 = num;
				switch (num2)
				{
				case 192:
					goto IL_C3;
				case 193:
					goto IL_C3;
				case 194:
					goto IL_C3;
				default:
					switch (num2)
					{
					case 224:
						this.c(yc);
						break;
					case 225:
						this.a(yc);
						break;
					case 226:
						this.b(yc);
						break;
					}
					break;
				}
				IL_113:
				num = yc.a();
				continue;
				IL_C3:
				this.d = (int)yc.c();
				this.b = yc.b();
				this.a = yc.b();
				this.c = (int)yc.c();
				goto IL_113;
			}
			if (this.m != null)
			{
				this.l = new bl(yc, this.m, this.n);
				this.m = null;
			}
		}

		// Token: 0x06005853 RID: 22611 RVA: 0x003348DC File Offset: 0x003338DC
		private new void c(yc A_0)
		{
			A_0.a(7);
			byte b = A_0.c();
			int num = A_0.b();
			int num2 = A_0.b();
			if (num <= 0 || num2 <= 0)
			{
				this.g = 0.75f;
				this.h = 0.75f;
			}
			else
			{
				switch (b)
				{
				case 0:
				{
					float num3 = (float)(num + num2) / 0.48f;
					this.g = (float)num / num3;
					this.h = (float)num2 / num3;
					break;
				}
				case 1:
					this.g = 72f / (float)num;
					this.h = 72f / (float)num2;
					break;
				case 2:
					this.g = 28.346457f / (float)num;
					this.h = 28.346457f / (float)num2;
					break;
				}
			}
		}

		// Token: 0x06005854 RID: 22612 RVA: 0x003349B0 File Offset: 0x003339B0
		private new void b(yc A_0)
		{
			if (A_0.d() == 1229144927 && A_0.d() == 1347571526 && A_0.d() == 1229735168)
			{
				int num = (int)A_0.c();
				int num2 = (int)A_0.c();
				if (num == 1)
				{
					this.n = (uint)A_0.d();
				}
				if (this.m == null)
				{
					this.m = new bk[num2];
				}
				if (num <= this.m.Length)
				{
					this.m[num - 1] = new bk(A_0);
				}
			}
		}

		// Token: 0x06005855 RID: 22613 RVA: 0x00334A58 File Offset: 0x00333A58
		private new void a(yc A_0)
		{
			if (this.m == null && A_0.d() == 1165519206 && A_0.b() == 0)
			{
				bool a_ = true;
				int num = 0;
				int num2 = A_0.d();
				if (num2 == 1229531648 || num2 == 1296891946)
				{
					if (num2 == 1229531648)
					{
						int a_2 = A_0.f();
						A_0.a(-8);
						byte[] array = A_0.a(a_2, a_);
						for (int i = 0; i < array.Length; i += 12)
						{
							if (array[i] == 105 && array[i + 1] == 135)
							{
								num = ((int)array[i + 8] | (int)array[i + 9] << 8 | (int)array[i + 10] << 16 | (int)array[i + 11] << 24);
								break;
							}
						}
						if (num != 0 && num < this.f.Length)
						{
							byte[] array2 = A_0.a(num, a_);
							for (int i = 0; i < array2.Length; i += 12)
							{
								if (array2[i] == 1 && array2[i + 1] == 160)
								{
									this.k = ((int)array2[i + 8] | (int)array2[i + 9] << 8);
									break;
								}
							}
						}
					}
					else
					{
						a_ = false;
						int a_2 = A_0.d();
						A_0.a(-8);
						byte[] array = A_0.a(a_2, a_);
						for (int i = 0; i < array.Length; i += 12)
						{
							if (array[i] == 135 && array[i + 1] == 105)
							{
								num = ((int)array[i + 8] << 24 | (int)array[i + 9] << 16 | (int)array[i + 10] << 8 | (int)array[i + 11]);
								break;
							}
						}
						if (num != 0)
						{
							byte[] array2 = A_0.a(num, a_);
							for (int i = 0; i < array2.Length; i += 12)
							{
								if (array2[i] == 160 && array2[i + 1] == 1)
								{
									this.k = ((int)array2[i + 8] << 8 | (int)array2[i + 9]);
									break;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x170008CF RID: 2255
		// (get) Token: 0x06005856 RID: 22614 RVA: 0x00334CDC File Offset: 0x00333CDC
		public override int RequiredPdfObjects
		{
			get
			{
				return this.e;
			}
		}

		// Token: 0x170008D0 RID: 2256
		// (get) Token: 0x06005857 RID: 22615 RVA: 0x00334CF4 File Offset: 0x00333CF4
		public override int Width
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170008D1 RID: 2257
		// (get) Token: 0x06005858 RID: 22616 RVA: 0x00334D0C File Offset: 0x00333D0C
		public override int Height
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x170008D2 RID: 2258
		// (get) Token: 0x06005859 RID: 22617 RVA: 0x00334D24 File Offset: 0x00333D24
		public override float ScaleX
		{
			get
			{
				return this.g;
			}
		}

		// Token: 0x170008D3 RID: 2259
		// (get) Token: 0x0600585A RID: 22618 RVA: 0x00334D3C File Offset: 0x00333D3C
		public override float ScaleY
		{
			get
			{
				return this.h;
			}
		}

		// Token: 0x0600585B RID: 22619 RVA: 0x00334D54 File Offset: 0x00333D54
		internal override byte[] gs()
		{
			return this.f;
		}

		// Token: 0x0600585C RID: 22620 RVA: 0x00334D6C File Offset: 0x00333D6C
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
			writer.WriteNumber(this.d);
			int num = this.c;
			if (num != 1)
			{
				if (num != 4)
				{
					writer.WriteName(ImageData.e);
					if (this.l != null && this.l.b() == 3)
					{
						writer.WriteArrayOpen();
						writer.WriteName(ImageData.m);
						writer.WriteReference(this.l.a());
						writer.WriteArrayClose();
					}
					else if (this.k == 1)
					{
						byte[] iccProfile = (byte[])Document.a.GetObject("sRGBColorSpaceProfile");
						IccProfile resource = new IccProfile(iccProfile);
						writer.WriteArrayOpen();
						writer.WriteName(ImageData.m);
						writer.WriteReference(resource);
						writer.WriteArrayClose();
					}
					else
					{
						writer.WriteName(ImageData.g);
					}
				}
				else
				{
					writer.WriteName(ImageData.e);
					if (this.l != null && this.l.b() == 4)
					{
						writer.WriteArrayOpen();
						writer.WriteName(ImageData.m);
						writer.WriteReference(this.l.a());
						writer.WriteArrayClose();
					}
					else
					{
						writer.WriteName(ImageData.k);
					}
					writer.WriteName(JpegImageData.j);
					writer.WriteArrayOpen();
					writer.WriteNumber1();
					writer.WriteNumber0();
					writer.WriteNumber1();
					writer.WriteNumber0();
					writer.WriteNumber1();
					writer.WriteNumber0();
					writer.WriteNumber1();
					writer.WriteNumber0();
					writer.WriteArrayClose();
				}
			}
			else
			{
				writer.WriteName(ImageData.e);
				if (this.l != null && this.l.b() == 1)
				{
					writer.WriteArrayOpen();
					writer.WriteName(ImageData.m);
					writer.WriteReference(this.l.a());
					writer.WriteArrayClose();
				}
				else
				{
					writer.WriteName(ImageData.f);
				}
			}
			writer.WriteName(Resource.c);
			writer.WriteArrayOpen();
			writer.WriteName(JpegImageData.i);
			writer.WriteArrayClose();
			writer.WriteName(Resource.e);
			writer.ai(this.f.Length);
			writer.WriteDictionaryClose();
			writer.WriteStream(this.f, this.f.Length);
			writer.WriteEndObject();
		}

		// Token: 0x04002EDE RID: 11998
		private new int a = 0;

		// Token: 0x04002EDF RID: 11999
		private new int b;

		// Token: 0x04002EE0 RID: 12000
		private new int c;

		// Token: 0x04002EE1 RID: 12001
		private new int d;

		// Token: 0x04002EE2 RID: 12002
		private new int e = 1;

		// Token: 0x04002EE3 RID: 12003
		private new byte[] f;

		// Token: 0x04002EE4 RID: 12004
		private new float g = 0.24f;

		// Token: 0x04002EE5 RID: 12005
		private new float h = 0.24f;

		// Token: 0x04002EE6 RID: 12006
		private new static byte[] i = new byte[]
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

		// Token: 0x04002EE7 RID: 12007
		private new static byte[] j = new byte[]
		{
			68,
			101,
			99,
			111,
			100,
			101
		};

		// Token: 0x04002EE8 RID: 12008
		private new int k = 0;

		// Token: 0x04002EE9 RID: 12009
		private new bl l = null;

		// Token: 0x04002EEA RID: 12010
		private new bk[] m = null;

		// Token: 0x04002EEB RID: 12011
		private uint n = 0U;
	}
}
