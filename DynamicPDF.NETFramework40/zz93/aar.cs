using System;
using System.Security.Cryptography;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000403 RID: 1027
	internal class aar : b6
	{
		// Token: 0x06002B07 RID: 11015 RVA: 0x0018E450 File Offset: 0x0018D450
		internal aar(abj A_0, string A_1, ab7 A_2, bool A_3)
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
			if (abw2.kd() != 3 && abw2.kd() != 4)
			{
				throw new PdfParsingException("Document can not be decrypted. Invalid revision.");
			}
			if (abw2.kd() == 3)
			{
				this.d = true;
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

		// Token: 0x06002B08 RID: 11016 RVA: 0x0018E710 File Offset: 0x0018D710
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

		// Token: 0x06002B09 RID: 11017 RVA: 0x0018E748 File Offset: 0x0018D748
		internal override byte[] ar(long A_0, int A_1)
		{
			int value = (int)A_0;
			MD5 md = new MD5CryptoServiceProvider();
			int num = this.c + 5;
			byte[] array = new byte[num];
			this.b.CopyTo(array, 0);
			Array.Copy(BitConverter.GetBytes(value), 0, array, this.c, 3);
			Array.Copy(BitConverter.GetBytes(A_1), 0, array, this.c + 3, 2);
			byte[] sourceArray = md.ComputeHash(array);
			if (num > 16)
			{
				num = 16;
			}
			byte[] array2 = new byte[num];
			Array.Copy(sourceArray, 0, array2, 0, num);
			return array2;
		}

		// Token: 0x06002B0A RID: 11018 RVA: 0x0018E7E0 File Offset: 0x0018D7E0
		internal override SecurityInfo aq()
		{
			return SecurityInfo.RC4128;
		}

		// Token: 0x06002B0B RID: 11019 RVA: 0x0018E7F4 File Offset: 0x0018D7F4
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
				aar.a.a(array3, a_);
			}
			return array3;
		}

		// Token: 0x06002B0C RID: 11020 RVA: 0x0018E88C File Offset: 0x0018D88C
		private byte[] a(MD5 A_0, byte[] A_1, byte[] A_2)
		{
			byte[] array = new byte[32];
			byte[] array2 = new byte[48];
			b6.a().CopyTo(array2, 0);
			A_1.CopyTo(array2, 32);
			byte[] array3 = A_0.ComputeHash(array2);
			aar.a.a(array3, A_2);
			for (int i = 1; i < 20; i++)
			{
				byte[] a_ = this.a(A_2, (byte)i);
				aar.a.a(array3, a_);
			}
			Array.Copy(array3, 0, array, 0, 16);
			Array.Copy(b6.a(), 0, array, 16, 16);
			return array;
		}

		// Token: 0x06002B0D RID: 11021 RVA: 0x0018E92C File Offset: 0x0018D92C
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

		// Token: 0x06002B0E RID: 11022 RVA: 0x0018EA1C File Offset: 0x0018DA1C
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

		// Token: 0x06002B0F RID: 11023 RVA: 0x0018EA6C File Offset: 0x0018DA6C
		internal override bool @as()
		{
			return this.d;
		}

		// Token: 0x040013C7 RID: 5063
		private new static aau a = new aau();

		// Token: 0x040013C8 RID: 5064
		private new byte[] b;

		// Token: 0x040013C9 RID: 5065
		private int c;

		// Token: 0x040013CA RID: 5066
		private new bool d = true;
	}
}
