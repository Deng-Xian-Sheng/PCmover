using System;
using System.IO;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.Imaging
{
	// Token: 0x02000879 RID: 2169
	public class Jpeg2000ImageData : ImageData
	{
		// Token: 0x06005841 RID: 22593 RVA: 0x00333F90 File Offset: 0x00332F90
		public Jpeg2000ImageData(string filePath)
		{
			FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			byte[] array = new byte[16];
			fileStream.Read(array, 0, 16);
			if (Jpeg2000ImageData.IsValid(array))
			{
				fileStream.Seek(0L, SeekOrigin.Begin);
				this.f = new byte[fileStream.Length];
				if (fileStream.Position != 0L)
				{
					fileStream.Seek(0L, SeekOrigin.Begin);
				}
				fileStream.Read(this.f, 0, (int)fileStream.Length);
				fileStream.Close();
				this.a();
				return;
			}
			fileStream.Close();
			throw new ImageParsingException("Invalid JPEG 2000 File.");
		}

		// Token: 0x06005842 RID: 22594 RVA: 0x00334054 File Offset: 0x00333054
		public Jpeg2000ImageData(Stream stream)
		{
			this.f = new byte[stream.Length];
			if (stream.Position != 0L)
			{
				stream.Seek(0L, SeekOrigin.Begin);
			}
			stream.Read(this.f, 0, (int)stream.Length);
			this.a();
		}

		// Token: 0x06005843 RID: 22595 RVA: 0x003340C8 File Offset: 0x003330C8
		public static bool IsValid(string fileExtension)
		{
			return fileExtension == "jp2";
		}

		// Token: 0x06005844 RID: 22596 RVA: 0x003340E8 File Offset: 0x003330E8
		public static bool IsValid(byte[] header)
		{
			return (header[0] == 0 && header[1] == 0 && header[2] == 0 && header[3] == 12 && header[4] == 106 && header[5] == 80 && (header[6] == 26 || header[6] == 32) && (header[7] == 26 || header[7] == 32) && header[8] == 13 && header[9] == 10 && header[10] == 135 && header[11] == 10) || (header[0] == byte.MaxValue && header[1] == 79 && header[2] == byte.MaxValue && header[3] == 81 && header[6] == 0 && header[7] == 0);
		}

		// Token: 0x06005845 RID: 22597 RVA: 0x00334194 File Offset: 0x00333194
		private new void a()
		{
			if (this.f[0] == 0)
			{
				int num = 12;
				while (num < this.f.Length - 8 && (this.f[num + 4] != 106 || this.f[num + 5] != 112 || this.f[num + 6] != 50 || this.f[num + 7] != 99))
				{
					num += this.a(num);
				}
				num += 8;
				if (this.f[num] == 255 && this.f[num + 1] == 79 && this.f[num + 2] == 255 && this.f[num + 3] == 81)
				{
					this.a = ((int)this.f[num + 8] << 24 | (int)this.f[num + 9] << 16 | (int)this.f[num + 10] << 8 | (int)this.f[num + 11]);
					this.b = ((int)this.f[num + 12] << 24 | (int)this.f[num + 13] << 16 | (int)this.f[num + 14] << 8 | (int)this.f[num + 15]);
				}
			}
			else if (this.f[0] == 255 && this.f[1] == 79 && this.f[2] == 255 && this.f[3] == 81)
			{
				this.a = ((int)this.f[8] << 24 | (int)this.f[9] << 16 | (int)this.f[10] << 8 | (int)this.f[11]);
				this.b = ((int)this.f[12] << 24 | (int)this.f[13] << 16 | (int)this.f[14] << 8 | (int)this.f[15]);
				this.d = ((int)this.f[40] << 8 | (int)this.f[41]);
				this.c = (int)(this.f[42] + 1);
			}
		}

		// Token: 0x06005846 RID: 22598 RVA: 0x003343C8 File Offset: 0x003333C8
		private new int a(int A_0)
		{
			return (int)this.f[A_0++] << 24 | (int)this.f[A_0++] << 16 | (int)this.f[A_0++] << 8 | (int)this.f[A_0];
		}

		// Token: 0x170008CA RID: 2250
		// (get) Token: 0x06005847 RID: 22599 RVA: 0x00334414 File Offset: 0x00333414
		public override int RequiredPdfObjects
		{
			get
			{
				return this.e;
			}
		}

		// Token: 0x170008CB RID: 2251
		// (get) Token: 0x06005848 RID: 22600 RVA: 0x0033442C File Offset: 0x0033342C
		public override int Width
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170008CC RID: 2252
		// (get) Token: 0x06005849 RID: 22601 RVA: 0x00334444 File Offset: 0x00333444
		public override int Height
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x170008CD RID: 2253
		// (get) Token: 0x0600584A RID: 22602 RVA: 0x0033445C File Offset: 0x0033345C
		public override float ScaleX
		{
			get
			{
				return 0.24f;
			}
		}

		// Token: 0x170008CE RID: 2254
		// (get) Token: 0x0600584B RID: 22603 RVA: 0x00334474 File Offset: 0x00333474
		public override float ScaleY
		{
			get
			{
				return 0.24f;
			}
		}

		// Token: 0x0600584C RID: 22604 RVA: 0x0033448C File Offset: 0x0033348C
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
			if (this.c > 0)
			{
				writer.WriteName(ImageData.d);
				writer.WriteNumber(this.c);
				int num = this.d;
				if (num != 1)
				{
					if (num != 4)
					{
						writer.WriteName(ImageData.e);
						writer.WriteName(ImageData.g);
					}
					else
					{
						writer.WriteName(ImageData.e);
						writer.WriteName(ImageData.k);
					}
				}
				else
				{
					writer.WriteName(ImageData.e);
					writer.WriteName(ImageData.f);
				}
			}
			writer.WriteName(Resource.c);
			writer.WriteArrayOpen();
			writer.WriteName(Jpeg2000ImageData.g);
			writer.WriteArrayClose();
			writer.WriteName(Resource.e);
			writer.ai(this.f.Length);
			writer.WriteDictionaryClose();
			writer.WriteStream(this.f, this.f.Length);
			writer.WriteEndObject();
		}

		// Token: 0x04002ED7 RID: 11991
		private new int a;

		// Token: 0x04002ED8 RID: 11992
		private new int b;

		// Token: 0x04002ED9 RID: 11993
		private new int c = -1;

		// Token: 0x04002EDA RID: 11994
		private new int d = -1;

		// Token: 0x04002EDB RID: 11995
		private new int e = 1;

		// Token: 0x04002EDC RID: 11996
		private new byte[] f;

		// Token: 0x04002EDD RID: 11997
		private new static byte[] g = new byte[]
		{
			74,
			80,
			88,
			68,
			101,
			99,
			111,
			100,
			101
		};
	}
}
