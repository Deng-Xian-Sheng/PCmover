using System;
using System.IO;
using System.Security.Cryptography;
using zz93;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x0200005D RID: 93
	public class Encrypter
	{
		// Token: 0x0600030F RID: 783 RVA: 0x00040A74 File Offset: 0x0003FA74
		public Encrypter(byte[] owner, byte[] user, byte[] encryptionKey, int privileges)
		{
			this.a = owner;
			this.b = user;
			this.c = encryptionKey;
			this.d = privileges;
			int num = encryptionKey.Length + 5;
			if (num > 16)
			{
				num = 16;
			}
			this.f = new byte[num];
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00040B18 File Offset: 0x0003FB18
		internal virtual b5 v()
		{
			return b5.a;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00040B2C File Offset: 0x0003FB2C
		public virtual void Draw(DocumentWriter writer)
		{
			writer.WriteName(79);
			writer.WriteTextWithoutEncryption(this.a);
			writer.WriteName(85);
			writer.WriteTextWithoutEncryption(this.b);
			writer.WriteName(80);
			writer.WriteNumber(this.d);
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00040B7C File Offset: 0x0003FB7C
		public byte Encrypt(byte data)
		{
			this.i = (this.i + 1 & 255);
			this.g = this.k[this.i];
			this.j = (this.j + this.g & 255);
			this.k[this.i] = (this.h = this.k[this.j]);
			this.k[this.j] = this.g;
			return (byte)((int)data ^ this.k[this.g + this.h & 255]);
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00040C24 File Offset: 0x0003FC24
		public virtual void Encrypt(Stream stream, byte[] data, int start, int length)
		{
			int num = 0;
			for (int i = 0; i < length; i++)
			{
				if (num == this.l.Length)
				{
					stream.Write(this.l, 0, num);
					num = 0;
				}
				this.i = (this.i + 1 & 255);
				this.g = this.k[this.i];
				this.j = (this.j + this.g & 255);
				this.k[this.i] = (this.h = this.k[this.j]);
				this.k[this.j] = this.g;
				this.l[num++] = (byte)((int)data[start++] ^ this.k[this.g + this.h & 255]);
			}
			stream.Write(this.l, 0, num);
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00040D28 File Offset: 0x0003FD28
		public virtual byte[] Encrypt(byte[] data)
		{
			return null;
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00040D3C File Offset: 0x0003FD3C
		public virtual void Reset(int objectNumber)
		{
			if (this.e != objectNumber)
			{
				MD5 md = new MD5CryptoServiceProvider();
				byte[] array = new byte[this.c.Length + 5];
				this.c.CopyTo(array, 0);
				Array.Copy(BitConverter.GetBytes(objectNumber), 0, array, this.c.Length, 3);
				byte[] sourceArray = md.ComputeHash(array);
				Array.Copy(sourceArray, this.f, this.f.Length);
				this.e = objectNumber;
			}
			this.a();
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00040DBF File Offset: 0x0003FDBF
		internal virtual void w(Stream A_0, byte[][] A_1, int A_2, int A_3, int A_4, int A_5, int[] A_6)
		{
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00040DC4 File Offset: 0x0003FDC4
		internal virtual void x(Stream A_0, byte[][] A_1, int A_2, int A_3, int A_4, int A_5)
		{
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00040DCC File Offset: 0x0003FDCC
		private void a()
		{
			this.g = 0;
			this.h = 0;
			this.i = 0;
			this.j = 0;
			this.k = new int[256];
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 256; i++)
			{
				this.k[i] = i;
			}
			for (int i = 0; i < 256; i++)
			{
				int num3 = this.k[i];
				num = (num + num3 + (int)this.f[num2] & 255);
				this.k[i] = this.k[num];
				this.k[num] = num3;
				if (++num2 >= this.f.Length)
				{
					num2 = 0;
				}
			}
		}

		// Token: 0x04000211 RID: 529
		internal byte[] a = null;

		// Token: 0x04000212 RID: 530
		internal byte[] b = null;

		// Token: 0x04000213 RID: 531
		internal byte[] c = null;

		// Token: 0x04000214 RID: 532
		internal int d = 0;

		// Token: 0x04000215 RID: 533
		internal int e = 0;

		// Token: 0x04000216 RID: 534
		internal byte[] f;

		// Token: 0x04000217 RID: 535
		internal int g = 0;

		// Token: 0x04000218 RID: 536
		internal int h = 0;

		// Token: 0x04000219 RID: 537
		internal int i = 0;

		// Token: 0x0400021A RID: 538
		internal int j = 0;

		// Token: 0x0400021B RID: 539
		internal int[] k;

		// Token: 0x0400021C RID: 540
		internal byte[] l = new byte[512];
	}
}
