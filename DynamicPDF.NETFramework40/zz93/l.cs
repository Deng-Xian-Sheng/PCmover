using System;
using System.Collections;
using System.Text;

namespace zz93
{
	// Token: 0x0200000E RID: 14
	internal class l
	{
		// Token: 0x06000091 RID: 145 RVA: 0x0001C16F File Offset: 0x0001B16F
		internal l(string A_0, float A_1, float A_2)
		{
			this.g = A_0;
			this.e = A_1;
			this.f = A_2;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0001C198 File Offset: 0x0001B198
		internal float b()
		{
			return this.e;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0001C1B0 File Offset: 0x0001B1B0
		internal BitArray c()
		{
			char[] array = this.g.ToCharArray();
			this.a = new BitArray(this.a(), true);
			foreach (byte a_ in array)
			{
				this.a(a_, ref this.e);
			}
			return this.a;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0001C218 File Offset: 0x0001B218
		internal float d()
		{
			return (float)this.a() * this.f;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0001C238 File Offset: 0x0001B238
		internal int a(byte A_0)
		{
			if (A_0 <= 84)
			{
				switch (A_0)
				{
				case 36:
					return 11;
				case 37:
				case 38:
				case 39:
				case 40:
				case 41:
				case 44:
				case 59:
				case 60:
				case 61:
				case 62:
				case 63:
				case 64:
				case 70:
				case 71:
				case 72:
				case 73:
				case 74:
				case 75:
				case 76:
				case 77:
					goto IL_176;
				case 42:
					goto IL_156;
				case 43:
					return 17;
				case 45:
					return 11;
				case 46:
					return 13;
				case 47:
					return 13;
				case 48:
					return 11;
				case 49:
					return 11;
				case 50:
					return 11;
				case 51:
					return 11;
				case 52:
					return 11;
				case 53:
					return 11;
				case 54:
					return 11;
				case 55:
					return 11;
				case 56:
					return 11;
				case 57:
					return 11;
				case 58:
					return 13;
				case 65:
					break;
				case 66:
					goto IL_151;
				case 67:
					goto IL_156;
				case 68:
					goto IL_15B;
				case 69:
					goto IL_15B;
				case 78:
					goto IL_151;
				default:
					if (A_0 != 84)
					{
						goto IL_176;
					}
					break;
				}
			}
			else
			{
				switch (A_0)
				{
				case 97:
					break;
				case 98:
					goto IL_151;
				case 99:
					goto IL_156;
				case 100:
					goto IL_15B;
				case 101:
					goto IL_15B;
				default:
					if (A_0 == 110)
					{
						goto IL_151;
					}
					if (A_0 != 116)
					{
						goto IL_176;
					}
					break;
				}
			}
			return 13;
			IL_151:
			return 13;
			IL_156:
			return 13;
			IL_15B:
			return 13;
			IL_176:
			throw new ap("Invalid Codabar character.");
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0001C3C8 File Offset: 0x0001B3C8
		private int a()
		{
			byte[] bytes = Encoding.ASCII.GetBytes(this.g);
			int num = bytes.Length - 1;
			foreach (byte a_ in bytes)
			{
				num += this.a(a_);
			}
			return num;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0001C424 File Offset: 0x0001B424
		private void a(byte A_0, ref float A_1)
		{
			if (A_0 <= 84)
			{
				switch (A_0)
				{
				case 36:
					this.c(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					this.b(ref A_1);
					this.c(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					goto IL_5F3;
				case 37:
				case 38:
				case 39:
				case 40:
				case 41:
				case 44:
				case 59:
				case 60:
				case 61:
				case 62:
				case 63:
				case 64:
				case 70:
				case 71:
				case 72:
				case 73:
				case 74:
				case 75:
				case 76:
				case 77:
					goto IL_5E8;
				case 42:
					goto IL_549;
				case 43:
					this.c(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					goto IL_5F3;
				case 45:
					this.c(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					this.b(ref A_1);
					this.d(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					goto IL_5F3;
				case 46:
					this.d(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					goto IL_5F3;
				case 47:
					this.d(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					goto IL_5F3;
				case 48:
					this.c(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					this.b(ref A_1);
					this.d(ref A_1);
					goto IL_5F3;
				case 49:
					this.c(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					this.b(ref A_1);
					this.c(ref A_1);
					goto IL_5F3;
				case 50:
					this.c(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					this.b(ref A_1);
					this.c(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					goto IL_5F3;
				case 51:
					this.d(ref A_1);
					this.b(ref A_1);
					this.c(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					goto IL_5F3;
				case 52:
					this.c(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					this.b(ref A_1);
					this.c(ref A_1);
					goto IL_5F3;
				case 53:
					this.d(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					this.b(ref A_1);
					this.c(ref A_1);
					goto IL_5F3;
				case 54:
					this.c(ref A_1);
					this.b(ref A_1);
					this.c(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					goto IL_5F3;
				case 55:
					this.c(ref A_1);
					this.b(ref A_1);
					this.c(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					goto IL_5F3;
				case 56:
					this.c(ref A_1);
					this.b(ref A_1);
					this.d(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					goto IL_5F3;
				case 57:
					this.d(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					this.b(ref A_1);
					this.c(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					goto IL_5F3;
				case 58:
					this.d(ref A_1);
					this.a(ref A_1);
					this.c(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					this.a(ref A_1);
					this.d(ref A_1);
					goto IL_5F3;
				case 65:
					break;
				case 66:
					goto IL_50C;
				case 67:
					goto IL_549;
				case 68:
					goto IL_583;
				case 69:
					goto IL_583;
				case 78:
					goto IL_50C;
				default:
					if (A_0 != 84)
					{
						goto IL_5E8;
					}
					break;
				}
			}
			else
			{
				switch (A_0)
				{
				case 97:
					break;
				case 98:
					goto IL_50C;
				case 99:
					goto IL_549;
				case 100:
					goto IL_583;
				case 101:
					goto IL_583;
				default:
					if (A_0 == 110)
					{
						goto IL_50C;
					}
					if (A_0 != 116)
					{
						goto IL_5E8;
					}
					break;
				}
			}
			this.c(ref A_1);
			this.a(ref A_1);
			this.d(ref A_1);
			this.b(ref A_1);
			this.c(ref A_1);
			this.b(ref A_1);
			this.c(ref A_1);
			goto IL_5F3;
			IL_50C:
			this.c(ref A_1);
			this.b(ref A_1);
			this.c(ref A_1);
			this.b(ref A_1);
			this.c(ref A_1);
			this.a(ref A_1);
			this.d(ref A_1);
			goto IL_5F3;
			IL_549:
			this.c(ref A_1);
			this.a(ref A_1);
			this.c(ref A_1);
			this.b(ref A_1);
			this.c(ref A_1);
			this.b(ref A_1);
			this.d(ref A_1);
			goto IL_5F3;
			IL_583:
			this.c(ref A_1);
			this.a(ref A_1);
			this.c(ref A_1);
			this.b(ref A_1);
			this.d(ref A_1);
			this.b(ref A_1);
			this.c(ref A_1);
			goto IL_5F3;
			IL_5E8:
			throw new ap("Invalid Codabar character.");
			IL_5F3:
			A_1 += this.f;
			this.d = 1f;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0001CA3C File Offset: 0x0001BA3C
		private void d(ref float A_0)
		{
			if (this.c)
			{
				for (int i = 0; i < 3; i++)
				{
					this.a[this.b] = false;
					this.b++;
				}
				A_0 += this.f * 3f;
				this.c = false;
			}
			else
			{
				int num = 0;
				while ((float)num < this.d)
				{
					this.a[this.b] = true;
					this.b++;
					num++;
				}
				for (int i = 0; i < 3; i++)
				{
					this.a[this.b] = false;
					this.b++;
				}
				A_0 += this.f * 3f;
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0001CB28 File Offset: 0x0001BB28
		private void c(ref float A_0)
		{
			if (this.c)
			{
				this.a[this.b] = false;
				this.b++;
				A_0 += this.f;
				this.c = false;
			}
			else
			{
				int num = 0;
				while ((float)num < this.d)
				{
					this.a[this.b] = true;
					this.b++;
					num++;
				}
				this.a[this.b] = false;
				this.b++;
				A_0 += this.f;
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0001CBE1 File Offset: 0x0001BBE1
		private void b(ref float A_0)
		{
			A_0 += this.f * 3f;
			this.d = 3f;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0001CC00 File Offset: 0x0001BC00
		private void a(ref float A_0)
		{
			A_0 += this.f;
			this.d = 1f;
		}

		// Token: 0x04000060 RID: 96
		private BitArray a;

		// Token: 0x04000061 RID: 97
		private int b;

		// Token: 0x04000062 RID: 98
		private bool c = true;

		// Token: 0x04000063 RID: 99
		private float d;

		// Token: 0x04000064 RID: 100
		private float e;

		// Token: 0x04000065 RID: 101
		private float f;

		// Token: 0x04000066 RID: 102
		private string g;
	}
}
