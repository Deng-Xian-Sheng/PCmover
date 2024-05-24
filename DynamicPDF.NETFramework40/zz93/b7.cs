using System;
using System.IO;
using System.Security.Cryptography;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000066 RID: 102
	internal class b7 : b6
	{
		// Token: 0x0600044D RID: 1101 RVA: 0x000483D8 File Offset: 0x000473D8
		internal b7(abj A_0, string A_1, ab7 A_2, bool A_3)
		{
			abw abw = null;
			abw abw2 = null;
			ab7 ab = null;
			ab7 ab2 = null;
			abw abw3 = null;
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				switch (num)
				{
				case 15:
					ab = (ab7)abk.c();
					break;
				case 16:
					abw3 = (abw)abk.c();
					break;
				case 17:
				case 19:
				case 20:
					break;
				case 18:
					abw2 = (abw)abk.c();
					break;
				case 21:
					ab2 = (ab7)abk.c();
					break;
				default:
					if (num != 211216860)
					{
						if (num == 351860972)
						{
							this.d = ((abf)abk.c()).a();
						}
					}
					else
					{
						abw = (abw)abk.c();
					}
					break;
				}
			}
			if (abw2.kd() != 4)
			{
				throw new PdfParsingException("Document can not be decrypted. Invalid revision.");
			}
			this.c = abw.kd() / 8;
			MD5 a_ = new MD5CryptoServiceProvider();
			byte[] a_2 = this.b(a_, base.b(A_1), ab.kh());
			this.b = this.a(a_, a_2, A_2.kh(), ab.kh(), abw3.kd());
			if (A_3)
			{
				cd a_3 = cd.d;
				if (!this.a(ab2.kh(), this.a(a_, A_2.kh(), this.b)))
				{
					this.b = this.a(a_, base.b(A_1), A_2.kh(), ab.kh(), abw3.kd());
					byte[] a_4 = this.a(a_, A_2.kh(), this.b);
					if (!this.a(ab2.kh(), a_4))
					{
						a_3 = cd.c;
					}
					else
					{
						a_3 = cd.b;
					}
				}
				else
				{
					this.b = this.a(a_, base.b(A_1), A_2.kh(), ab.kh(), abw3.kd());
					byte[] a_5 = this.a(a_, A_2.kh(), this.b);
					if (!this.a(ab2.kh(), a_5))
					{
						a_3 = cd.a;
					}
				}
				base.a(a_3);
			}
			else if (!this.a(ab2.kh(), this.a(a_, A_2.kh(), this.b)))
			{
				throw new PdfSecurityException("Document can not be decrypted. Invalid owner password.");
			}
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0004867C File Offset: 0x0004767C
		private bool a(byte[] A_0, byte[] A_1)
		{
			for (int i = 0; i < 16; i++)
			{
				if (A_0[i] != A_1[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x000486B4 File Offset: 0x000476B4
		internal override SecurityInfo aq()
		{
			return SecurityInfo.Aes128;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x000486C8 File Offset: 0x000476C8
		internal override byte[] ar(long A_0, int A_1)
		{
			int value = (int)A_0;
			byte[] result;
			if (this.at())
			{
				result = this.b;
			}
			else
			{
				MD5 md = new MD5CryptoServiceProvider();
				int num = this.c + 9;
				byte[] array = new byte[num];
				this.b.CopyTo(array, 0);
				Array.Copy(BitConverter.GetBytes(value), 0, array, this.c, 3);
				Array.Copy(BitConverter.GetBytes(A_1), 0, array, this.c + 3, 2);
				Array.Copy(new byte[]
				{
					115,
					65,
					108,
					84
				}, 0, array, this.c + 5, 4);
				byte[] sourceArray = md.ComputeHash(array);
				if (num > 16)
				{
					num = 16;
				}
				byte[] array2 = new byte[num];
				Array.Copy(sourceArray, 0, array2, 0, num);
				result = array2;
			}
			return result;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x000487A4 File Offset: 0x000477A4
		private byte[] b(MD5 A_0, byte[] A_1, byte[] A_2)
		{
			byte[] array = A_0.ComputeHash(A_1);
			for (int i = 0; i < 50; i++)
			{
				array = A_0.ComputeHash(array);
			}
			byte[] array2 = new byte[this.c];
			Array.Copy(array, array2, this.c);
			byte[] array3 = new byte[32];
			A_2.CopyTo(array3, 0);
			for (int i = 19; i >= 0; i--)
			{
				byte[] a_ = this.a(array2, (byte)i);
				b7.a.a(array3, a_);
			}
			return array3;
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0004883C File Offset: 0x0004783C
		private byte[] a(MD5 A_0, byte[] A_1, byte[] A_2)
		{
			byte[] array = new byte[32];
			byte[] array2 = new byte[48];
			b6.a().CopyTo(array2, 0);
			A_1.CopyTo(array2, 32);
			byte[] array3 = A_0.ComputeHash(array2);
			b7.a.a(array3, A_2);
			for (int i = 1; i < 20; i++)
			{
				byte[] a_ = this.a(A_2, (byte)i);
				b7.a.a(array3, a_);
			}
			Array.Copy(array3, 0, array, 0, 16);
			Array.Copy(b6.a(), 0, array, 16, 16);
			return array;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x000488DC File Offset: 0x000478DC
		private byte[] a(MD5 A_0, byte[] A_1, byte[] A_2, byte[] A_3, int A_4)
		{
			int num = this.c + 5;
			if (num > 16)
			{
				num = 16;
			}
			byte[] array = new byte[num];
			byte[] array2;
			if (!this.d)
			{
				array2 = new byte[88];
			}
			else
			{
				array2 = new byte[84];
			}
			Array.Copy(A_1, 0, array2, 0, 32);
			Array.Copy(A_3, 0, array2, 32, 32);
			Array.Copy(BitConverter.GetBytes(A_4), 0, array2, 64, 4);
			Array.Copy(A_2, 0, array2, 68, 16);
			if (!this.d)
			{
				Array.Copy(new byte[]
				{
					byte.MaxValue,
					byte.MaxValue,
					byte.MaxValue,
					byte.MaxValue
				}, 0, array2, 84, 4);
			}
			byte[] array3 = A_0.ComputeHash(array2);
			for (int i = 0; i < 50; i++)
			{
				array3 = A_0.ComputeHash(array3);
			}
			Array.Copy(array3, 0, array, 0, num);
			return array;
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x000489CC File Offset: 0x000479CC
		private byte[] a(byte[] A_0, byte A_1)
		{
			byte[] array = new byte[A_0.Length];
			A_0.CopyTo(array, 0);
			for (int i = 0; i < A_0.Length; i++)
			{
				byte[] array2 = array;
				int num = i;
				array2[num] ^= A_1;
			}
			return array;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00048A1C File Offset: 0x00047A1C
		internal override bool @as()
		{
			return this.d;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00048A34 File Offset: 0x00047A34
		internal override bool at()
		{
			return this.e;
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00048A4C File Offset: 0x00047A4C
		internal override void au(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00048A58 File Offset: 0x00047A58
		internal override int av(ref byte[] A_0, int A_1, int A_2, byte[] A_3)
		{
			int num = 0;
			if (A_0 != null && A_0.Length > 0 && A_3 != null && A_3.Length > 0 && A_2 > 0)
			{
				using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
				{
					rijndaelManaged.Key = A_3;
					byte[] array = new byte[16];
					Array.Copy(A_0, A_1, array, 0, 16);
					rijndaelManaged.IV = array;
					ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
					rijndaelManaged.Mode = CipherMode.CBC;
					rijndaelManaged.KeySize = 128;
					if (A_2 > 16)
					{
						byte[] array2 = new byte[A_2];
						using (MemoryStream memoryStream = new MemoryStream(A_0, A_1 + 16, A_2 - 16))
						{
							using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
							{
								num = cryptoStream.Read(array2, 0, array2.Length);
								memoryStream.Close();
								cryptoStream.Close();
								Array.Copy(array2, 0, A_0, A_1, num);
							}
						}
						rijndaelManaged.Clear();
					}
					else
					{
						Array.Copy(new byte[A_2], 0, A_0, A_1, A_2);
					}
				}
			}
			return num;
		}

		// Token: 0x04000287 RID: 647
		private new static aau a = new aau();

		// Token: 0x04000288 RID: 648
		private new byte[] b;

		// Token: 0x04000289 RID: 649
		private int c;

		// Token: 0x0400028A RID: 650
		private new bool d = true;

		// Token: 0x0400028B RID: 651
		private bool e = false;
	}
}
