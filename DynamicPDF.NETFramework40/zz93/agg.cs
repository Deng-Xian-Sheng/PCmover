using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004D7 RID: 1239
	internal class agg : ad7
	{
		// Token: 0x0600329D RID: 12957 RVA: 0x001C4044 File Offset: 0x001C3044
		internal agg(FontSubsetter A_0) : base(A_0.GlyphsUsed)
		{
			this.a = A_0;
		}

		// Token: 0x0600329E RID: 12958 RVA: 0x001C405C File Offset: 0x001C305C
		internal override void k3(char[] A_0)
		{
			base.a(ad7.a);
			char c = '\u0001';
			while ((int)c < this.a.GlyphsUsed.Length)
			{
				if (this.a.GlyphsUsed[(int)c] && A_0[(int)c] > '\0')
				{
					base.a(c, A_0[(int)c]);
				}
				c += '\u0001';
			}
			for (int i = 0; i < this.a.b.Count; i++)
			{
				this.a(this.a.b[i], this.a.c[i]);
			}
			base.e();
			base.a(ad7.b);
		}

		// Token: 0x0600329F RID: 12959 RVA: 0x001C4120 File Offset: 0x001C3120
		private new void a(char[] A_0, char A_1)
		{
			base.a(base.c() + 1);
			base.d(8 + A_0.Length * 6);
			this.a(A_0);
			byte[] array = base.b();
			int num;
			base.b((num = base.d()) + 1);
			array[num] = 32;
			base.a(A_1);
			byte[] array2 = base.b();
			base.b((num = base.d()) + 1);
			array2[num] = 10;
		}

		// Token: 0x060032A0 RID: 12960 RVA: 0x001C4194 File Offset: 0x001C3194
		private new void a(ushort A_0, char[] A_1)
		{
			base.a(base.c() + 1);
			base.d(8 + A_1.Length * 6);
			base.a((char)A_0);
			byte[] array = base.b();
			int num;
			base.b((num = base.d()) + 1);
			array[num] = 32;
			this.a(A_1);
			byte[] array2 = base.b();
			base.b((num = base.d()) + 1);
			array2[num] = 10;
		}

		// Token: 0x060032A1 RID: 12961 RVA: 0x001C4208 File Offset: 0x001C3208
		private new void a(char[] A_0)
		{
			byte[] array = base.b();
			int num;
			base.b((num = base.d()) + 1);
			array[num] = 60;
			for (int i = 0; i < A_0.Length; i++)
			{
				base.c((int)(A_0[i] >> 12));
				base.c((int)(A_0[i] >> 8));
				base.c((int)(A_0[i] >> 4));
				base.c((int)A_0[i]);
			}
			byte[] array2 = base.b();
			base.b((num = base.d()) + 1);
			array2[num] = 62;
		}

		// Token: 0x0400183F RID: 6207
		private new FontSubsetter a;
	}
}
