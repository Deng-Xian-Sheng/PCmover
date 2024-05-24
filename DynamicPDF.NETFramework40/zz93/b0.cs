using System;
using System.IO;
using System.Security.Cryptography;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200005E RID: 94
	internal class b0 : Encrypter
	{
		// Token: 0x06000319 RID: 793 RVA: 0x00040E94 File Offset: 0x0003FE94
		public b0(byte[] A_0, byte[] A_1, byte[] A_2, int A_3, byte[] A_4, byte[] A_5, byte[] A_6) : base(A_0, A_1, A_2, A_3)
		{
			this.a = A_4;
			this.b = A_5;
			this.c = A_6;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00040EF0 File Offset: 0x0003FEF0
		internal override b5 v()
		{
			return b5.b;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00040F04 File Offset: 0x0003FF04
		public override void Encrypt(Stream stream, byte[] data, int start, int length)
		{
			using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
			{
				aesCryptoServiceProvider.Mode = CipherMode.CBC;
				aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
				aesCryptoServiceProvider.KeySize = 256;
				aesCryptoServiceProvider.Key = this.c;
				aesCryptoServiceProvider.GenerateIV();
				ICryptoTransform transform = aesCryptoServiceProvider.CreateEncryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
				byte[] array = new byte[length + (16 - length % 16)];
				int num = 512;
				byte[] array2 = new byte[num + 16];
				int num2 = 0;
				using (MemoryStream memoryStream = new MemoryStream(array2))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
					{
						do
						{
							memoryStream.Position = 0L;
							if (length - num2 > num)
							{
								cryptoStream.Write(data, start + num2, num);
								Array.Copy(array2, 0, array, num2, num);
								num2 += num;
							}
							else
							{
								cryptoStream.Write(data, start + num2, length - num2);
								cryptoStream.FlushFinalBlock();
								Array.Copy(array2, 0, array, num2, length - num2 + (16 - (length - num2) % 16));
								num2 += num;
							}
						}
						while (num2 < length);
						memoryStream.Close();
						cryptoStream.Close();
						stream.Write(aesCryptoServiceProvider.IV, 0, 16);
						stream.Write(array, 0, array.Length);
					}
				}
				aesCryptoServiceProvider.Clear();
			}
		}

		// Token: 0x0600031C RID: 796 RVA: 0x000410EC File Offset: 0x000400EC
		public override byte[] Encrypt(byte[] text)
		{
			byte[] result;
			using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
			{
				aesCryptoServiceProvider.Mode = CipherMode.CBC;
				aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
				aesCryptoServiceProvider.KeySize = 256;
				aesCryptoServiceProvider.Key = this.c;
				aesCryptoServiceProvider.GenerateIV();
				ICryptoTransform transform = aesCryptoServiceProvider.CreateEncryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
				byte[] array = new byte[text.Length + (16 - text.Length % 16) + 16];
				using (MemoryStream memoryStream = new MemoryStream(text))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
					{
						cryptoStream.Read(array, 16, array.Length - 16);
						memoryStream.Close();
						cryptoStream.Close();
						Array.Copy(aesCryptoServiceProvider.IV, 0, array, 0, 16);
					}
				}
				aesCryptoServiceProvider.Clear();
				result = array;
			}
			return result;
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00041218 File Offset: 0x00040218
		public override void Reset(int objectNumber)
		{
			if (this.e != objectNumber)
			{
				Array.Copy(this.c, this.f, this.f.Length);
				this.e = objectNumber;
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00041258 File Offset: 0x00040258
		public override void Draw(DocumentWriter writer)
		{
			base.Draw(writer);
			writer.WriteName(b0.d);
			writer.WriteTextWithoutEncryption(this.a);
			writer.WriteName(b0.e);
			writer.WriteTextWithoutEncryption(this.b);
			writer.WriteName(b0.f);
			writer.WriteTextWithoutEncryption(this.c);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x000412BC File Offset: 0x000402BC
		internal override void w(Stream A_0, byte[][] A_1, int A_2, int A_3, int A_4, int A_5, int[] A_6)
		{
			using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
			{
				aesCryptoServiceProvider.Mode = CipherMode.CBC;
				aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
				aesCryptoServiceProvider.KeySize = 256;
				aesCryptoServiceProvider.Key = this.c;
				aesCryptoServiceProvider.GenerateIV();
				ICryptoTransform transform = aesCryptoServiceProvider.CreateEncryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
				int num = A_6[A_2] - A_4;
				for (int i = A_2 + 1; i < A_3; i++)
				{
					num += A_6[i];
				}
				num += A_5;
				byte[] array = new byte[num + (16 - num % 16)];
				using (MemoryStream memoryStream = new MemoryStream(array))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
					{
						cryptoStream.Write(A_1[A_2], A_4, A_6[A_2] - A_4);
						for (int i = A_2 + 1; i < A_3; i++)
						{
							cryptoStream.Write(A_1[i], 0, A_6[i]);
						}
						cryptoStream.Write(A_1[A_3], 0, A_5);
						cryptoStream.FlushFinalBlock();
						memoryStream.Close();
						cryptoStream.Close();
						A_0.Write(aesCryptoServiceProvider.IV, 0, 16);
						A_0.Write(array, 0, array.Length);
					}
				}
				aesCryptoServiceProvider.Clear();
			}
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00041480 File Offset: 0x00040480
		internal override void x(Stream A_0, byte[][] A_1, int A_2, int A_3, int A_4, int A_5)
		{
			using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
			{
				aesCryptoServiceProvider.Mode = CipherMode.CBC;
				aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
				aesCryptoServiceProvider.KeySize = 256;
				aesCryptoServiceProvider.Key = this.c;
				aesCryptoServiceProvider.GenerateIV();
				ICryptoTransform transform = aesCryptoServiceProvider.CreateEncryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
				int num = A_1[A_2].Length - A_4;
				for (int i = A_2 + 1; i < A_3; i++)
				{
					num += A_1[i].Length;
				}
				num += A_5;
				byte[] array = new byte[num + (16 - num % 16)];
				using (MemoryStream memoryStream = new MemoryStream(array))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
					{
						cryptoStream.Write(A_1[A_2], A_4, A_1[A_2].Length - A_4);
						for (int i = A_2 + 1; i < A_3; i++)
						{
							cryptoStream.Write(A_1[i], 0, A_1[i].Length);
						}
						cryptoStream.Write(A_1[A_3], 0, A_5);
						cryptoStream.FlushFinalBlock();
						memoryStream.Close();
						cryptoStream.Close();
						A_0.Write(aesCryptoServiceProvider.IV, 0, 16);
						A_0.Write(array, 0, array.Length);
					}
				}
				aesCryptoServiceProvider.Clear();
			}
		}

		// Token: 0x0400021D RID: 541
		private new byte[] a = new byte[32];

		// Token: 0x0400021E RID: 542
		private new byte[] b = new byte[32];

		// Token: 0x0400021F RID: 543
		private new byte[] c = new byte[16];

		// Token: 0x04000220 RID: 544
		private new static byte[] d = new byte[]
		{
			85,
			69
		};

		// Token: 0x04000221 RID: 545
		private new static byte[] e = new byte[]
		{
			79,
			69
		};

		// Token: 0x04000222 RID: 546
		private new static byte[] f = new byte[]
		{
			80,
			101,
			114,
			109,
			115
		};
	}
}
