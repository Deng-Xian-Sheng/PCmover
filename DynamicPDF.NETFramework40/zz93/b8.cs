using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000067 RID: 103
	internal class b8 : b6
	{
		// Token: 0x0600045A RID: 1114 RVA: 0x00048C10 File Offset: 0x00047C10
		internal b8(abj A_0, string A_1, bool A_2)
		{
			abw abw = null;
			ab7 ab = null;
			ab7 ab2 = null;
			ab7 ab3 = null;
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 18)
				{
					if (num != 15)
					{
						if (num == 18)
						{
							abw = (abw)abk.c();
						}
					}
					else
					{
						ab = (ab7)abk.c();
					}
				}
				else if (num != 21)
				{
					if (num != 965)
					{
						if (num == 351860972)
						{
							this.b = ((abf)abk.c()).a();
						}
					}
					else
					{
						ab3 = (ab7)abk.c();
					}
				}
				else
				{
					ab2 = (ab7)abk.c();
				}
			}
			int num2 = abw.kd();
			if (num2 != 5 && num2 != 6)
			{
				throw new PdfParsingException("Document can not be decrypted. Invalid revision.");
			}
			SHA256 sha = new SHA256CryptoServiceProvider();
			if (num2 == 5)
			{
				byte[] a_ = this.a(sha, this.a(A_1), ab2.kh(), ab.kh(), false);
				if (A_2)
				{
					cd a_2 = cd.d;
					if (!this.a(a_, ab.kh()))
					{
						byte[] a_3 = this.a(sha, this.a(A_1), ab2.kh(), ab.kh(), true);
						if (!this.a(a_3, ab2.kh()))
						{
							a_2 = cd.c;
						}
						else
						{
							a_2 = cd.b;
						}
					}
					byte[] a_4 = this.a(sha, this.a(A_1), ab2.kh(), ab.kh(), true);
					if (!this.a(a_4, ab2.kh()))
					{
						a_2 = cd.a;
					}
					base.a(a_2);
				}
				else
				{
					if (!this.a(a_, ab.kh()))
					{
						throw new PdfSecurityException("Document can not be decrypted. Invalid owner password.");
					}
					byte[] array = new byte[32];
					byte[] array2 = this.a(A_1);
					byte[] array3 = new byte[array2.Length + 56];
					Array.Copy(array2, 0, array3, 0, array2.Length);
					Array.Copy(ab.kh(), 40, array3, array2.Length, 8);
					Array.Copy(ab2.kh(), 0, array3, array2.Length + 8, 48);
					byte[] array4 = sha.ComputeHash(array3);
					Array.Copy(array4, 0, array, 0, 32);
					this.a = this.b(ab3.kh(), array);
				}
			}
			else if (num2 == 6)
			{
				byte[] array5 = this.a(A_1);
				byte[] array = this.b(array5, ab2.kh(), ab.kh());
				byte[] a_5 = this.a(array5, ab2.kh(), ab.kh());
				SHA384 a_6 = new SHA384CryptoServiceProvider();
				SHA512 a_7 = new SHA512CryptoServiceProvider();
				byte[] array4 = this.a(sha, a_6, a_7, array5, array, ab2.kh(), true);
				if (A_2)
				{
					cd a_2 = cd.d;
					byte[] a_8 = this.a(sha, a_6, a_7, array5, a_5, ab2.kh(), false);
					if (!this.a(array4, ab.kh()))
					{
						if (!this.a(a_8, ab2.kh()))
						{
							a_2 = cd.c;
						}
						else
						{
							a_2 = cd.b;
						}
					}
					else if (!this.a(a_8, ab2.kh()))
					{
						a_2 = cd.a;
					}
					base.a(a_2);
				}
				else
				{
					if (!this.a(array4, ab.kh()))
					{
						throw new PdfSecurityException("Document can not be decrypted. Invalid owner password.");
					}
					byte[] array3 = new byte[array5.Length + 56];
					Array.Copy(array5, 0, array3, 0, array5.Length);
					Array.Copy(ab.kh(), 40, array3, array5.Length, 8);
					Array.Copy(ab2.kh(), 0, array3, array5.Length + 8, 48);
					array4 = this.a(sha, a_6, a_7, array5, array3, ab2.kh(), true);
					this.a = this.b(ab3.kh(), array4);
				}
			}
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00049054 File Offset: 0x00048054
		private byte[] b(byte[] A_0, byte[] A_1, byte[] A_2)
		{
			byte[] array = new byte[A_0.Length + 8 + 48];
			Array.Copy(A_0, 0, array, 0, A_0.Length);
			Array.Copy(A_2, 32, array, A_0.Length, 8);
			Array.Copy(A_1, 0, array, A_0.Length + 8, 48);
			return array;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x000490A0 File Offset: 0x000480A0
		private byte[] a(byte[] A_0, byte[] A_1, byte[] A_2)
		{
			byte[] array = new byte[A_0.Length + 8];
			Array.Copy(A_0, 0, array, 0, A_0.Length);
			Array.Copy(A_1, 32, array, A_0.Length, 8);
			return array;
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x000490DC File Offset: 0x000480DC
		private byte[] a(SHA256 A_0, SHA384 A_1, SHA512 A_2, byte[] A_3, byte[] A_4, byte[] A_5, bool A_6)
		{
			byte[] sourceArray = A_0.ComputeHash(A_4);
			byte[] array = null;
			int i;
			for (i = 0; i < 64; i++)
			{
				this.a(A_0, A_1, A_2, ref sourceArray, ref array, A_3, A_5, A_6);
			}
			while ((int)array[array.Length - 1] > i - 32)
			{
				this.a(A_0, A_1, A_2, ref sourceArray, ref array, A_3, A_5, A_6);
				i++;
			}
			byte[] array2 = new byte[32];
			Array.Copy(sourceArray, array2, 32);
			return array2;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00049168 File Offset: 0x00048168
		private void a(SHA256 A_0, SHA384 A_1, SHA512 A_2, ref byte[] A_3, ref byte[] A_4, byte[] A_5, byte[] A_6, bool A_7)
		{
			byte[] array;
			if (A_7)
			{
				array = new byte[A_5.Length + A_3.Length + 48];
				Array.Copy(A_5, array, A_5.Length);
				Array.Copy(A_3, 0, array, A_5.Length, A_3.Length);
				Array.Copy(A_6, 0, array, A_5.Length + A_3.Length, 48);
			}
			else
			{
				array = new byte[A_5.Length + A_3.Length];
				Array.Copy(A_5, array, A_5.Length);
				Array.Copy(A_3, 0, array, A_5.Length, A_3.Length);
			}
			byte[] array2 = new byte[array.Length * 64];
			for (int i = 0; i < 64; i++)
			{
				Array.Copy(array, 0, array2, array.Length * i, array.Length);
			}
			A_4 = this.c(array2, A_3);
			byte[] array3 = new byte[16];
			Array.Copy(A_4, 0, array3, 0, 16);
			h a_ = new h(array3);
			h h = h.d(a_, h.a(3));
			switch (h.b())
			{
			case 0:
				A_3 = A_0.ComputeHash(A_4);
				break;
			case 1:
				A_3 = A_1.ComputeHash(A_4);
				break;
			case 2:
				A_3 = A_2.ComputeHash(A_4);
				break;
			}
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x000492B8 File Offset: 0x000482B8
		private byte[] c(byte[] A_0, byte[] A_1)
		{
			byte[] result;
			using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
			{
				aesCryptoServiceProvider.Mode = CipherMode.CBC;
				aesCryptoServiceProvider.Padding = PaddingMode.None;
				aesCryptoServiceProvider.KeySize = 128;
				byte[] array = new byte[16];
				byte[] array2 = new byte[16];
				Array.Copy(A_1, array, 16);
				Array.Copy(A_1, 16, array2, 0, 16);
				aesCryptoServiceProvider.Key = array;
				aesCryptoServiceProvider.IV = array2;
				ICryptoTransform transform = aesCryptoServiceProvider.CreateEncryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
				byte[] array3 = new byte[A_0.Length];
				using (MemoryStream memoryStream = new MemoryStream(A_0))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
					{
						cryptoStream.Read(array3, 0, array3.Length);
						memoryStream.Close();
						cryptoStream.Close();
					}
				}
				aesCryptoServiceProvider.Clear();
				result = array3;
			}
			return result;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x000493EC File Offset: 0x000483EC
		private byte[] b(byte[] A_0, byte[] A_1)
		{
			if (A_0 == null || A_0.Length <= 0)
			{
				throw new ArgumentNullException("Cipher text");
			}
			if (A_1 == null || A_1.Length <= 0)
			{
				throw new ArgumentNullException("Key");
			}
			byte[] result;
			using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
			{
				aesCryptoServiceProvider.IV = new byte[16];
				aesCryptoServiceProvider.Padding = PaddingMode.None;
				aesCryptoServiceProvider.Mode = CipherMode.CBC;
				aesCryptoServiceProvider.KeySize = 256;
				ICryptoTransform transform = aesCryptoServiceProvider.CreateDecryptor(A_1, aesCryptoServiceProvider.IV);
				byte[] array = new byte[A_0.Length];
				using (MemoryStream memoryStream = new MemoryStream(A_0))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
					{
						cryptoStream.Read(array, 0, array.Length);
						memoryStream.Close();
						cryptoStream.Close();
						result = array;
					}
				}
			}
			return result;
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00049518 File Offset: 0x00048518
		private byte[] a(string A_0)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(A_0);
			int num = (bytes.Length > 127) ? 127 : bytes.Length;
			byte[] array = new byte[num];
			Array.Copy(bytes, array, num);
			return array;
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00049558 File Offset: 0x00048558
		private bool a(byte[] A_0, byte[] A_1)
		{
			for (int i = 0; i < 32; i++)
			{
				if (A_0[i] != A_1[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00049590 File Offset: 0x00048590
		private byte[] a(SHA256 A_0, byte[] A_1, byte[] A_2, byte[] A_3, bool A_4)
		{
			byte[] result;
			if (A_4)
			{
				byte[] array = new byte[32];
				byte[] array2 = new byte[A_1.Length + 8];
				Array.Copy(A_1, 0, array2, 0, A_1.Length);
				Array.Copy(A_2, 32, array2, A_1.Length, 8);
				byte[] sourceArray = A_0.ComputeHash(array2);
				Array.Copy(sourceArray, 0, array, 0, 32);
				result = array;
			}
			else
			{
				byte[] array = new byte[32];
				byte[] array2 = new byte[A_1.Length + 56];
				Array.Copy(A_1, 0, array2, 0, A_1.Length);
				Array.Copy(A_3, 32, array2, A_1.Length, 8);
				Array.Copy(A_2, 0, array2, A_1.Length + 8, 48);
				byte[] sourceArray = A_0.ComputeHash(array2);
				Array.Copy(sourceArray, 0, array, 0, 32);
				result = array;
			}
			return result;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0004964C File Offset: 0x0004864C
		internal override bool @as()
		{
			return this.b;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00049664 File Offset: 0x00048664
		internal override bool at()
		{
			return this.c;
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0004967C File Offset: 0x0004867C
		internal override void au(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00049688 File Offset: 0x00048688
		internal override SecurityInfo aq()
		{
			return SecurityInfo.Aes256;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0004969C File Offset: 0x0004869C
		internal override byte[] ar(long A_0, int A_1)
		{
			return this.a;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x000496B4 File Offset: 0x000486B4
		internal override int av(ref byte[] A_0, int A_1, int A_2, byte[] A_3)
		{
			int num = 0;
			if (A_0 != null && A_0.Length > 0 && A_3 != null && A_3.Length > 0 && A_2 > 0)
			{
				using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
				{
					aesCryptoServiceProvider.Key = A_3;
					byte[] array = new byte[16];
					Array.Copy(A_0, A_1, array, 0, 16);
					aesCryptoServiceProvider.IV = array;
					ICryptoTransform transform = aesCryptoServiceProvider.CreateDecryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
					aesCryptoServiceProvider.Mode = CipherMode.CBC;
					aesCryptoServiceProvider.KeySize = 256;
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
						aesCryptoServiceProvider.Clear();
					}
					else
					{
						Array.Copy(new byte[A_2], 0, A_0, A_1, A_2);
					}
				}
			}
			return num;
		}

		// Token: 0x0400028C RID: 652
		private new byte[] a;

		// Token: 0x0400028D RID: 653
		private new bool b = true;

		// Token: 0x0400028E RID: 654
		private bool c = false;
	}
}
