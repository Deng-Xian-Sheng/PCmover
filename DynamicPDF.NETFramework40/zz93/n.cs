using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000010 RID: 16
	internal class n
	{
		// Token: 0x060000A8 RID: 168 RVA: 0x0001D1DC File Offset: 0x0001C1DC
		internal n(string A_0, float A_1, float A_2)
		{
			this.f = A_1;
			this.e = A_2;
			this.g = A_0;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0001D204 File Offset: 0x0001C204
		internal float b()
		{
			return (float)this.a() * this.e;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0001D224 File Offset: 0x0001C224
		internal BitArray c()
		{
			this.a = new BitArray(this.a(), true);
			this.c = true;
			this.b(ref this.f);
			this.b(ref this.f);
			this.a(ref this.f);
			foreach (char a_ in this.g)
			{
				this.a(a_, ref this.f);
			}
			this.b(ref this.f);
			this.a(ref this.f);
			this.b(ref this.f);
			return this.a;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0001D2DC File Offset: 0x0001C2DC
		private int a()
		{
			return this.g.Length * 14 + 19;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0001D300 File Offset: 0x0001C300
		private void a(char A_0, ref float A_1)
		{
			switch (A_0 % 'Ā')
			{
			case '0':
				this.a(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				break;
			case '1':
				this.b(ref A_1);
				this.a(ref A_1);
				this.a(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				break;
			case '2':
				this.a(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				break;
			case '3':
				this.b(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				this.a(ref A_1);
				this.a(ref A_1);
				break;
			case '4':
				this.a(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				break;
			case '5':
				this.b(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				this.a(ref A_1);
				break;
			case '6':
				this.a(ref A_1);
				this.b(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				this.a(ref A_1);
				break;
			case '7':
				this.a(ref A_1);
				this.a(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				this.b(ref A_1);
				break;
			case '8':
				this.b(ref A_1);
				this.a(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				break;
			case '9':
				this.a(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				break;
			default:
				throw new ap("Invalid Code 2 of 5 character.");
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0001D510 File Offset: 0x0001C510
		private void b(ref float A_0)
		{
			if (this.c)
			{
				for (int i = 0; i < 3; i++)
				{
					this.a[this.b] = false;
					this.b++;
				}
				A_0 += this.e * 4f;
				this.d = A_0 + 1f;
				this.c = false;
			}
			else if (A_0 != this.d)
			{
				this.a[this.b] = true;
				this.b++;
				for (int i = 0; i < 3; i++)
				{
					this.a[this.b] = false;
					this.b++;
				}
				A_0 += this.e * 4f;
				this.d = A_0 + 1f;
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0001D610 File Offset: 0x0001C610
		private void a(ref float A_0)
		{
			if (this.c)
			{
				this.a[this.b] = false;
				this.b++;
				A_0 += this.e * 2f;
				this.d = A_0 + 1f;
				this.c = false;
			}
			else if (A_0 != this.d)
			{
				this.a[this.b] = true;
				this.b++;
				this.a[this.b] = false;
				this.b++;
				A_0 += this.e * 2f;
				this.d = A_0 + 1f;
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0001D6EC File Offset: 0x0001C6EC
		internal float d()
		{
			return this.f;
		}

		// Token: 0x0400006B RID: 107
		private BitArray a;

		// Token: 0x0400006C RID: 108
		private int b;

		// Token: 0x0400006D RID: 109
		private bool c = true;

		// Token: 0x0400006E RID: 110
		private float d;

		// Token: 0x0400006F RID: 111
		private float e;

		// Token: 0x04000070 RID: 112
		private float f;

		// Token: 0x04000071 RID: 113
		private string g;
	}
}
