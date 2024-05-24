using System;
using System.Security.Cryptography;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000443 RID: 1091
	internal class ach : b6
	{
		// Token: 0x06002D0B RID: 11531 RVA: 0x0019A1BC File Offset: 0x001991BC
		internal ach(abj A_0, string A_1, ab7 A_2, bool A_3)
		{
			abw abw = null;
			ab7 ab = null;
			ab7 ab2 = null;
			abw abw2 = null;
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				switch (abk.a().j8())
				{
				case 15:
					ab = (ab7)abk.c();
					break;
				case 16:
					abw2 = (abw)abk.c();
					break;
				case 18:
					abw = (abw)abk.c();
					break;
				case 21:
					ab2 = (ab7)abk.c();
					break;
				}
			}
			if (abw.kd() != 2)
			{
				throw new PdfParsingException("Document can not be decrypted. Invalid revision.");
			}
			MD5 md = new MD5CryptoServiceProvider();
			byte[] a_ = this.a(md, base.b(A_1), ab.kh());
			this.b = this.a(md, a_, A_2.kh(), ab.kh(), abw2.kd());
			if (A_3)
			{
				cd a_2 = cd.d;
				if (!base.d(ab2.kh(), this.a(this.b)))
				{
					md.Initialize();
					this.b = this.a(md, base.b(A_1), A_2.kh(), ab.kh(), abw2.kd());
					if (!base.d(ab2.kh(), this.a(this.b)))
					{
						a_2 = cd.c;
					}
					else
					{
						a_2 = cd.b;
					}
				}
				else
				{
					md.Initialize();
					this.b = this.a(md, base.b(A_1), A_2.kh(), ab.kh(), abw2.kd());
					if (!base.d(ab2.kh(), this.a(this.b)))
					{
						a_2 = cd.a;
					}
				}
				base.a(a_2);
			}
			else if (!base.d(ab2.kh(), this.a(this.b)))
			{
				throw new PdfSecurityException("Document can not be decrypted. Invalid owner password.");
			}
		}

		// Token: 0x06002D0C RID: 11532 RVA: 0x0019A3E8 File Offset: 0x001993E8
		internal override SecurityInfo aq()
		{
			return SecurityInfo.RC440;
		}

		// Token: 0x06002D0D RID: 11533 RVA: 0x0019A3FC File Offset: 0x001993FC
		internal override byte[] ar(long A_0, int A_1)
		{
			int value = (int)A_0;
			MD5 md = new MD5CryptoServiceProvider();
			byte[] array = new byte[10];
			this.b.CopyTo(array, 0);
			Array.Copy(BitConverter.GetBytes(value), 0, array, 5, 3);
			Array.Copy(BitConverter.GetBytes(A_1), 0, array, 8, 2);
			byte[] sourceArray = md.ComputeHash(array);
			Array.Copy(sourceArray, 0, array, 0, 10);
			return array;
		}

		// Token: 0x06002D0E RID: 11534 RVA: 0x0019A464 File Offset: 0x00199464
		private byte[] a(MD5 A_0, byte[] A_1, byte[] A_2)
		{
			byte[] array = new byte[5];
			byte[] sourceArray = A_0.ComputeHash(A_1);
			Array.Copy(sourceArray, array, 5);
			byte[] array2 = new byte[A_2.Length];
			A_2.CopyTo(array2, 0);
			ach.a.a(array2, array);
			return array2;
		}

		// Token: 0x06002D0F RID: 11535 RVA: 0x0019A4B0 File Offset: 0x001994B0
		private byte[] a(byte[] A_0)
		{
			byte[] array = new byte[32];
			b6.a().CopyTo(array, 0);
			ach.a.a(array, A_0);
			return array;
		}

		// Token: 0x06002D10 RID: 11536 RVA: 0x0019A4E8 File Offset: 0x001994E8
		private byte[] a(MD5 A_0, byte[] A_1, byte[] A_2, byte[] A_3, int A_4)
		{
			byte[] array = new byte[5];
			byte[] array2 = new byte[84];
			Array.Copy(A_1, 0, array2, 0, 32);
			Array.Copy(A_3, 0, array2, 32, 32);
			Array.Copy(BitConverter.GetBytes(A_4), 0, array2, 64, 4);
			Array.Copy(A_2, 0, array2, 68, 16);
			Array.Copy(A_0.ComputeHash(array2), 0, array, 0, 5);
			return array;
		}

		// Token: 0x0400154F RID: 5455
		private new static aau a = new aau();

		// Token: 0x04001550 RID: 5456
		private new byte[] b;
	}
}
