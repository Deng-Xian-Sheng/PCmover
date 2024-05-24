using System;
using System.Collections.Generic;
using System.IO;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200046A RID: 1130
	internal class adh : sa
	{
		// Token: 0x06002F00 RID: 12032 RVA: 0x001AC140 File Offset: 0x001AB140
		internal adh(int A_0, Stream A_1, byte[] A_2, int A_3) : base(A_1, A_2, A_3)
		{
			this.b = new char[A_0];
			this.c = new bool[A_0];
			int num = -1;
			int num2 = -1;
			int num3 = base.e(2);
			int num4 = -1;
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			for (int i = 0; i < num3; i++)
			{
				if (base.e(4 + i * 8) == 3)
				{
					list2.Add(i);
				}
				else if (base.e(4 + i * 8) == 1)
				{
					list.Add(i);
				}
			}
			foreach (int i in list)
			{
				int i;
				int num5 = base.e(6 + i * 8);
				if (num5 == 0)
				{
					num4 = base.d(8 + i * 8);
					int num6 = base.e(num4);
					if (num6 == 0)
					{
						this.b(num4);
					}
					else if (num6 == 6)
					{
						this.c(num4);
					}
				}
			}
			foreach (int i in list2)
			{
				int i;
				int num5 = base.e(6 + i * 8);
				if (num5 == 1)
				{
					this.d = num5;
					num = base.d(8 + i * 8);
					break;
				}
				if (num5 == 0)
				{
					num2 = base.d(8 + i * 8);
				}
			}
			int num7 = num2;
			if (num > 0)
			{
				num7 = num;
			}
			if (num7 < 0 && num4 < 0)
			{
				throw new GeneratorException("TrueType font does not contain a valid Unicode Table");
			}
			if (num7 > 0)
			{
				this.a(num7);
			}
		}

		// Token: 0x06002F01 RID: 12033 RVA: 0x001AC394 File Offset: 0x001AB394
		private void c(int A_0)
		{
			if (base.e(A_0 + 4) == 0)
			{
				int num = base.e(A_0 + 6);
				int num2 = base.e(A_0 + 8);
				int num3 = A_0 + 10;
				for (int i = 0; i < num2; i++)
				{
					int num4 = base.e(num3);
					num3 += 2;
					this.a((char)(num + i), (char)num4);
				}
			}
		}

		// Token: 0x06002F02 RID: 12034 RVA: 0x001AC404 File Offset: 0x001AB404
		private void b(int A_0)
		{
			for (int i = 0; i < 256; i++)
			{
				int num = base.g(A_0 + 6 + i);
				this.a((char)i, (char)num);
			}
		}

		// Token: 0x06002F03 RID: 12035 RVA: 0x001AC440 File Offset: 0x001AB440
		private void a(int A_0)
		{
			int num = base.e(A_0 + 6);
			int num2 = A_0 + 14;
			int num3 = A_0 + 16 + num;
			int num4 = A_0 + 16 + num * 2;
			int num5 = A_0 + 16 + num * 3;
			for (int i = 0; i < num; i += 2)
			{
				int num6 = base.e(num3 + i);
				int num7 = base.e(num2 + i);
				int num8 = 65536 - base.e(num4 + i);
				int num9 = base.e(num5 + i);
				if (num9 == 0)
				{
					for (int j = num6; j <= num7; j++)
					{
						this.b((char)j, (char)(j - num8));
					}
				}
				else
				{
					if (num6 > 65534)
					{
						break;
					}
					for (int j = num6; j <= num7; j++)
					{
						int a_ = num9 + (j - num6) * 2 + num5 + i;
						int num10 = base.e(a_);
						this.b((char)j, (char)num10);
					}
				}
			}
		}

		// Token: 0x06002F04 RID: 12036 RVA: 0x001AC568 File Offset: 0x001AB568
		private void b(char A_0, char A_1)
		{
			this.a[(int)A_0] = A_1;
			if (A_1 > '\0' && A_1 < '￿')
			{
				if (!this.c[(int)A_1])
				{
					this.c[(int)A_1] = true;
					this.b[(int)A_1] = A_0;
				}
			}
		}

		// Token: 0x06002F05 RID: 12037 RVA: 0x001AC5B8 File Offset: 0x001AB5B8
		private void a(char A_0, char A_1)
		{
			this.a[(int)A_0] = A_1;
			if (A_1 > '\0' && A_1 < '￿')
			{
				this.b[(int)A_1] = A_0;
			}
		}

		// Token: 0x06002F06 RID: 12038 RVA: 0x001AC5F4 File Offset: 0x001AB5F4
		internal int a()
		{
			return this.d;
		}

		// Token: 0x06002F07 RID: 12039 RVA: 0x001AC60C File Offset: 0x001AB60C
		internal char[] b()
		{
			return this.a;
		}

		// Token: 0x06002F08 RID: 12040 RVA: 0x001AC624 File Offset: 0x001AB624
		internal char[] c()
		{
			return this.b;
		}

		// Token: 0x06002F09 RID: 12041 RVA: 0x001AC63C File Offset: 0x001AB63C
		internal void a(ad8 A_0)
		{
			A_0.b();
			A_0.a(10, base.p().Length);
			A_0.a(base.p());
		}

		// Token: 0x0400165C RID: 5724
		private new char[] a = new char[65536];

		// Token: 0x0400165D RID: 5725
		private char[] b;

		// Token: 0x0400165E RID: 5726
		private bool[] c;

		// Token: 0x0400165F RID: 5727
		private new int d = 0;
	}
}
