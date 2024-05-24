using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000020 RID: 32
	internal class ad : ac
	{
		// Token: 0x06000139 RID: 313 RVA: 0x00026670 File Offset: 0x00025670
		internal ad(string A_0)
		{
			if (A_0.Length < 12 || A_0.Length > 13)
			{
				throw new ap("EAN 13 value must be 12 or 13 characters long.");
			}
			if (A_0.Length == 12)
			{
				this.a = new char[A_0.Length + 1];
				A_0.ToCharArray().CopyTo(this.a, 0);
				this.b(this.a);
			}
			else
			{
				this.a = A_0.ToCharArray();
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00026708 File Offset: 0x00025708
		internal static int c()
		{
			return 103;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0002671C File Offset: 0x0002571C
		internal static float b()
		{
			return 133f;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00026734 File Offset: 0x00025734
		internal static float a()
		{
			return 160f;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0002674C File Offset: 0x0002574C
		internal char[] d()
		{
			return this.a;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00026764 File Offset: 0x00025764
		internal BitArray e()
		{
			base.a(1);
			base.b(1);
			base.a(1);
			base.a(this.a[1]);
			av[] array = this.a(this.a);
			for (int i = 2; i < 7; i++)
			{
				if (array[i - 2] == av.a)
				{
					base.b(this.a[i]);
				}
				else
				{
					base.a(this.a[i]);
				}
			}
			base.b(1);
			base.a(1);
			base.b(1);
			base.a(1);
			base.b(1);
			for (int i = 7; i < 13; i++)
			{
				base.c(this.a[i]);
			}
			base.a(1);
			base.b(1);
			base.a(1);
			return base.f();
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00026858 File Offset: 0x00025858
		internal void b(char[] A_0)
		{
			int num = 0;
			int i;
			for (i = 0; i < A_0.Length - 1; i++)
			{
				if (i % 2 == 0)
				{
					num += (int)(A_0[i] - '0');
				}
				else
				{
					num += (int)((A_0[i] - '0') * '\u0003');
				}
			}
			A_0[i] = (char)(58 - num % 10);
			if (A_0[i] == ':')
			{
				A_0[i] = '0';
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x000268C0 File Offset: 0x000258C0
		internal BitArray a(BitArray A_0)
		{
			BitArray bitArray = new BitArray(95, true);
			for (int i = 0; i < 95; i++)
			{
				if (i == 0 || i == 2 || i == 46 || i == 48 || i == 92 || i == 94)
				{
					bitArray[i] = A_0[i];
				}
				else
				{
					bitArray[i] = true;
				}
			}
			return bitArray;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00026934 File Offset: 0x00025934
		internal BitArray b(BitArray A_0)
		{
			BitArray bitArray = new BitArray(95, true);
			for (int i = 0; i < 95; i++)
			{
				if (i == 0 || i == 2 || i == 46 || i == 48 || i == 92 || i == 94)
				{
					bitArray[i] = true;
				}
				else
				{
					bitArray[i] = A_0[i];
				}
			}
			return bitArray;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000269A8 File Offset: 0x000259A8
		private av[] a(char[] A_0)
		{
			av[] result;
			switch (A_0[0] % '\u0010')
			{
			case '\0':
				result = new av[]
				{
					av.b,
					av.b,
					av.b,
					av.b,
					av.b
				};
				break;
			case '\u0001':
			{
				av[] array = new av[5];
				array[0] = av.b;
				array[2] = av.b;
				result = array;
				break;
			}
			case '\u0002':
			{
				av[] array = new av[5];
				array[0] = av.b;
				array[3] = av.b;
				result = array;
				break;
			}
			case '\u0003':
				result = new av[]
				{
					av.b,
					av.a,
					av.a,
					av.a,
					av.b
				};
				break;
			case '\u0004':
			{
				av[] array = new av[5];
				array[1] = av.b;
				array[2] = av.b;
				result = array;
				break;
			}
			case '\u0005':
			{
				av[] array = new av[5];
				array[2] = av.b;
				array[3] = av.b;
				result = array;
				break;
			}
			case '\u0006':
				result = new av[]
				{
					av.a,
					av.a,
					av.a,
					av.b,
					av.b
				};
				break;
			case '\a':
			{
				av[] array = new av[5];
				array[1] = av.b;
				array[3] = av.b;
				result = array;
				break;
			}
			case '\b':
				result = new av[]
				{
					av.a,
					av.b,
					av.a,
					av.a,
					av.b
				};
				break;
			case '\t':
				result = new av[]
				{
					av.a,
					av.a,
					av.b,
					av.a,
					av.b
				};
				break;
			default:
				result = new av[]
				{
					av.b,
					av.b,
					av.b,
					av.b,
					av.b
				};
				break;
			}
			return result;
		}

		// Token: 0x040000B8 RID: 184
		private new char[] a;
	}
}
