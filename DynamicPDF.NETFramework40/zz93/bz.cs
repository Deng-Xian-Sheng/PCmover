using System;
using System.IO;
using System.Security.Cryptography;
using ceTe.DynamicPDF.Cryptography;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200005C RID: 92
	internal class bz : Encrypter
	{
		// Token: 0x06000308 RID: 776 RVA: 0x000402C0 File Offset: 0x0003F2C0
		public bz(byte[] A_0, byte[] A_1, byte[] A_2, int A_3, EncryptDocumentComponents A_4) : base(A_0, A_1, A_2, A_3)
		{
			this.a = A_4;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x000402E0 File Offset: 0x0003F2E0
		internal override b5 v()
		{
			return b5.b;
		}

		// Token: 0x0600030A RID: 778 RVA: 0x000402F4 File Offset: 0x0003F2F4
		public override void Encrypt(Stream stream, byte[] data, int start, int length)
		{
			using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
			{
				rijndaelManaged.Mode = CipherMode.CBC;
				rijndaelManaged.Padding = PaddingMode.PKCS7;
				rijndaelManaged.KeySize = 128;
				rijndaelManaged.Key = this.f;
				rijndaelManaged.GenerateIV();
				ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
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
						stream.Write(rijndaelManaged.IV, 0, 16);
						stream.Write(array, 0, array.Length);
					}
				}
				rijndaelManaged.Clear();
			}
		}

		// Token: 0x0600030B RID: 779 RVA: 0x000404DC File Offset: 0x0003F4DC
		public override byte[] Encrypt(byte[] text)
		{
			byte[] result;
			using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
			{
				rijndaelManaged.Mode = CipherMode.CBC;
				rijndaelManaged.Padding = PaddingMode.PKCS7;
				rijndaelManaged.KeySize = 128;
				rijndaelManaged.Key = this.f;
				rijndaelManaged.GenerateIV();
				ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
				byte[] array = new byte[text.Length + (16 - text.Length % 16) + 16];
				using (MemoryStream memoryStream = new MemoryStream(text))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
					{
						cryptoStream.Read(array, 16, array.Length - 16);
						memoryStream.Close();
						cryptoStream.Close();
						Array.Copy(rijndaelManaged.IV, 0, array, 0, 16);
					}
				}
				rijndaelManaged.Clear();
				result = array;
			}
			return result;
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00040608 File Offset: 0x0003F608
		public override void Reset(int objectNumber)
		{
			if (this.e != objectNumber)
			{
				if (this.a == EncryptDocumentComponents.OnlyFileAttachments)
				{
					Array.Copy(this.c, this.f, this.f.Length);
					this.e = objectNumber;
				}
				else
				{
					MD5 md = new MD5CryptoServiceProvider();
					byte[] array = new byte[this.c.Length + 9];
					this.c.CopyTo(array, 0);
					Array.Copy(BitConverter.GetBytes(objectNumber), 0, array, this.c.Length, 3);
					Array.Copy(new byte[]
					{
						115,
						65,
						108,
						84
					}, 0, array, this.c.Length + 5, 4);
					byte[] sourceArray = md.ComputeHash(array);
					Array.Copy(sourceArray, this.f, this.f.Length);
					this.e = objectNumber;
				}
			}
		}

		// Token: 0x0600030D RID: 781 RVA: 0x000406E8 File Offset: 0x0003F6E8
		internal override void w(Stream A_0, byte[][] A_1, int A_2, int A_3, int A_4, int A_5, int[] A_6)
		{
			using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
			{
				rijndaelManaged.Mode = CipherMode.CBC;
				rijndaelManaged.Padding = PaddingMode.PKCS7;
				rijndaelManaged.KeySize = 128;
				rijndaelManaged.Key = this.f;
				rijndaelManaged.GenerateIV();
				ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
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
						A_0.Write(rijndaelManaged.IV, 0, 16);
						A_0.Write(array, 0, array.Length);
					}
				}
				rijndaelManaged.Clear();
			}
		}

		// Token: 0x0600030E RID: 782 RVA: 0x000408AC File Offset: 0x0003F8AC
		internal override void x(Stream A_0, byte[][] A_1, int A_2, int A_3, int A_4, int A_5)
		{
			using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
			{
				rijndaelManaged.Mode = CipherMode.CBC;
				rijndaelManaged.Padding = PaddingMode.PKCS7;
				rijndaelManaged.KeySize = 128;
				rijndaelManaged.Key = this.f;
				rijndaelManaged.GenerateIV();
				ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
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
						A_0.Write(rijndaelManaged.IV, 0, 16);
						A_0.Write(array, 0, array.Length);
					}
				}
				rijndaelManaged.Clear();
			}
		}

		// Token: 0x04000210 RID: 528
		private new EncryptDocumentComponents a = EncryptDocumentComponents.All;
	}
}
