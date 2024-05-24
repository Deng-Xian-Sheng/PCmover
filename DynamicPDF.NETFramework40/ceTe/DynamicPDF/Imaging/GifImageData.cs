using System;
using System.IO;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Imaging
{
	// Token: 0x02000877 RID: 2167
	public class GifImageData : ImageData
	{
		// Token: 0x06005830 RID: 22576 RVA: 0x00333794 File Offset: 0x00332794
		public GifImageData(string filePath)
		{
			FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			byte[] array = new byte[16];
			fileStream.Read(array, 0, 16);
			if (GifImageData.IsValid(array))
			{
				fileStream.Seek(0L, SeekOrigin.Begin);
				this.a(fileStream);
				fileStream.Close();
				return;
			}
			fileStream.Close();
			throw new ImageParsingException("Invalid GIF File.");
		}

		// Token: 0x06005831 RID: 22577 RVA: 0x0033380B File Offset: 0x0033280B
		public GifImageData(Stream stream)
		{
			this.a(stream);
		}

		// Token: 0x06005832 RID: 22578 RVA: 0x00333828 File Offset: 0x00332828
		public static bool IsValid(string fileExtension)
		{
			return fileExtension == "gif";
		}

		// Token: 0x06005833 RID: 22579 RVA: 0x00333848 File Offset: 0x00332848
		public static bool IsValid(byte[] header)
		{
			return header[0] == 71 && header[1] == 73 && header[2] == 70 && header[3] == 56 && (header[4] == 55 || header[4] == 57) && header[5] == 97;
		}

		// Token: 0x06005834 RID: 22580 RVA: 0x00333890 File Offset: 0x00332890
		private new void a(Stream A_0)
		{
			int a_ = 0;
			int num = 0;
			bool a_2 = false;
			A_0.Seek(10L, SeekOrigin.Begin);
			int num2 = A_0.ReadByte();
			if ((num2 & 128) == 128)
			{
				a_ = (int)A_0.Position + 2;
				num = this.a(num2 & 7);
			}
			A_0.Seek((long)(num * 3 + 2), SeekOrigin.Current);
			int num3 = A_0.ReadByte();
			while (num3 != 44 && num3 != 33 && A_0.Position < A_0.Length)
			{
				num3 = A_0.ReadByte();
			}
			while (num3 == 33)
			{
				int num4 = A_0.ReadByte();
				int num5 = A_0.ReadByte();
				if (num4 == 249 && num5 == 4)
				{
					num2 = A_0.ReadByte();
					A_0.Seek(2L, SeekOrigin.Current);
					if ((num2 & 1) == 1)
					{
						this.e = A_0.ReadByte();
						A_0.Seek(1L, SeekOrigin.Current);
					}
					else
					{
						A_0.Seek(2L, SeekOrigin.Current);
					}
				}
				else
				{
					while (num5 != 0)
					{
						A_0.Seek((long)num5, SeekOrigin.Current);
						num5 = A_0.ReadByte();
					}
				}
				num3 = A_0.ReadByte();
				while (num3 != 44 && num3 != 33 && A_0.Position < A_0.Length)
				{
					num3 = A_0.ReadByte();
				}
			}
			while (num3 != 44 && A_0.Position < A_0.Length)
			{
				num3 = A_0.ReadByte();
			}
			A_0.Seek(4L, SeekOrigin.Current);
			this.a = (A_0.ReadByte() | A_0.ReadByte() << 8);
			this.b = (A_0.ReadByte() | A_0.ReadByte() << 8);
			num2 = A_0.ReadByte();
			if ((num2 & 64) == 64)
			{
				a_2 = true;
			}
			if ((num2 & 128) == 128)
			{
				a_ = (int)A_0.Position;
				num = this.a(num2 & 7);
				A_0.Seek((long)(num * 3), SeekOrigin.Current);
			}
			byte[] array = new byte[A_0.Length - A_0.Position - 1L];
			A_0.Read(array, 0, array.Length);
			this.a(array, a_2);
			this.a(A_0, a_, num);
		}

		// Token: 0x06005835 RID: 22581 RVA: 0x00333AF8 File Offset: 0x00332AF8
		private new byte[] a(byte[] A_0)
		{
			byte[] array = new byte[A_0.Length];
			int num = 0;
			for (int i = 0; i < this.b; i += 8)
			{
				Array.Copy(A_0, num++ * this.a, array, i * this.a, this.a);
			}
			for (int i = 4; i < this.b; i += 8)
			{
				Array.Copy(A_0, num++ * this.a, array, i * this.a, this.a);
			}
			for (int i = 2; i < this.b; i += 4)
			{
				Array.Copy(A_0, num++ * this.a, array, i * this.a, this.a);
			}
			for (int i = 1; i < this.b; i += 2)
			{
				Array.Copy(A_0, num++ * this.a, array, i * this.a, this.a);
			}
			return array;
		}

		// Token: 0x06005836 RID: 22582 RVA: 0x00333C04 File Offset: 0x00332C04
		private new void a(byte[] A_0, bool A_1)
		{
			y8 y = new y8(A_0);
			byte[] array = new byte[this.a * this.b];
			y.g6(array, 0);
			if (A_1)
			{
				array = this.a(array);
			}
			y0 y2 = new y0();
			y2.b(array, 0, array.Length);
			y2.b();
			byte[] array2 = new byte[(int)((float)array.Length * 1.002f + 12f)];
			int num = y2.a(array2);
			this.c = new byte[num];
			Array.Copy(array2, 0, this.c, 0, num);
		}

		// Token: 0x06005837 RID: 22583 RVA: 0x00333CA0 File Offset: 0x00332CA0
		private new int a(int A_0)
		{
			int num = 2;
			for (int i = 0; i < A_0; i++)
			{
				num *= 2;
			}
			return num;
		}

		// Token: 0x06005838 RID: 22584 RVA: 0x00333CCB File Offset: 0x00332CCB
		private new void a(Stream A_0, int A_1, int A_2)
		{
			this.d = new byte[A_2 * 3];
			A_0.Seek((long)A_1, SeekOrigin.Begin);
			A_0.Read(this.d, 0, this.d.Length);
		}

		// Token: 0x170008C5 RID: 2245
		// (get) Token: 0x06005839 RID: 22585 RVA: 0x00333CFC File Offset: 0x00332CFC
		public override int RequiredPdfObjects
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x170008C6 RID: 2246
		// (get) Token: 0x0600583A RID: 22586 RVA: 0x00333D10 File Offset: 0x00332D10
		public override int Width
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170008C7 RID: 2247
		// (get) Token: 0x0600583B RID: 22587 RVA: 0x00333D28 File Offset: 0x00332D28
		public override int Height
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x170008C8 RID: 2248
		// (get) Token: 0x0600583C RID: 22588 RVA: 0x00333D40 File Offset: 0x00332D40
		public override float ScaleX
		{
			get
			{
				return 0.24f;
			}
		}

		// Token: 0x170008C9 RID: 2249
		// (get) Token: 0x0600583D RID: 22589 RVA: 0x00333D58 File Offset: 0x00332D58
		public override float ScaleY
		{
			get
			{
				return 0.24f;
			}
		}

		// Token: 0x0600583E RID: 22590 RVA: 0x00333D70 File Offset: 0x00332D70
		internal override byte[] gs()
		{
			return this.c;
		}

		// Token: 0x0600583F RID: 22591 RVA: 0x00333D88 File Offset: 0x00332D88
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
			writer.WriteNumber(8);
			if (this.e >= 0)
			{
				writer.WriteName(ImageData.h);
				writer.WriteArrayOpen();
				writer.WriteNumber(this.e);
				writer.WriteNumber(this.e);
				writer.WriteArrayClose();
			}
			writer.WriteName(ImageData.e);
			writer.WriteArrayOpen();
			writer.WriteName(ImageData.i);
			writer.WriteName(ImageData.g);
			writer.WriteNumber(this.d.Length / 3 - 1);
			writer.WriteReference(writer.GetObjectNumber(1));
			writer.WriteArrayClose();
			writer.WriteName(Resource.c);
			writer.WriteArrayOpen();
			writer.WriteName(Resource.d);
			writer.WriteArrayClose();
			writer.WriteName(Resource.e);
			writer.ai(this.c.Length);
			writer.WriteDictionaryClose();
			writer.WriteStream(this.c, this.c.Length);
			writer.WriteEndObject();
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.e);
			writer.ai(this.d.Length);
			writer.WriteDictionaryClose();
			writer.WriteStream(this.d, this.d.Length);
			writer.WriteEndObject();
		}

		// Token: 0x04002ED2 RID: 11986
		private new int a;

		// Token: 0x04002ED3 RID: 11987
		private new int b;

		// Token: 0x04002ED4 RID: 11988
		private new byte[] c;

		// Token: 0x04002ED5 RID: 11989
		private new byte[] d;

		// Token: 0x04002ED6 RID: 11990
		private new int e = -1;
	}
}
