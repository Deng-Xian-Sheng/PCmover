using System;
using System.IO;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003DB RID: 987
	internal class zu : zq, zr
	{
		// Token: 0x06002961 RID: 10593 RVA: 0x001837E3 File Offset: 0x001827E3
		internal zu(byte[] A_0, int A_1, int A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06002962 RID: 10594 RVA: 0x00183804 File Offset: 0x00182804
		void zr.a(b3 A_0, int A_1)
		{
			byte[] array = this.a;
			int sourceIndex = this.b;
			Encrypter encrypter = A_0.j();
			if (encrypter.v() == b5.b)
			{
				int num = this.c * 2;
				A_0.a(num + 16 + (16 - num % 16) + 2);
			}
			else
			{
				A_0.a(this.c * 2 + 2);
			}
			this.a = A_0.h();
			this.b = A_0.g();
			encrypter.Reset(A_1);
			if (encrypter.v() == b5.b)
			{
				byte[] array2 = new byte[this.c];
				Array.Copy(array, sourceIndex, array2, 0, this.c);
				byte[] array3 = encrypter.Encrypt(array2);
				for (int i = 0; i < array3.Length; i++)
				{
					A_0.a(array3[i]);
				}
			}
			else
			{
				for (int i = 0; i < this.c; i++)
				{
					A_0.a(encrypter.Encrypt(array[sourceIndex++]));
				}
			}
			this.c = A_0.g() - this.b;
		}

		// Token: 0x06002963 RID: 10595 RVA: 0x00183937 File Offset: 0x00182937
		internal override void g7(Stream A_0)
		{
			A_0.Write(this.a, this.b, this.c);
		}

		// Token: 0x06002964 RID: 10596 RVA: 0x00183954 File Offset: 0x00182954
		internal override int g8()
		{
			return this.c;
		}

		// Token: 0x040012BC RID: 4796
		private byte[] a;

		// Token: 0x040012BD RID: 4797
		private int b;

		// Token: 0x040012BE RID: 4798
		private int c;
	}
}
