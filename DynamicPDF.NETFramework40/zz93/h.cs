using System;

namespace zz93
{
	// Token: 0x0200000A RID: 10
	internal class h
	{
		// Token: 0x06000058 RID: 88 RVA: 0x00019484 File Offset: 0x00018484
		internal h(byte[] A_0)
		{
			this.c = A_0.Length >> 2;
			int num = A_0.Length & 3;
			if (num != 0)
			{
				this.c++;
			}
			if (this.c > 70)
			{
				throw new ArithmeticException("Byte overflow in constructor.");
			}
			this.b = new uint[70];
			int i = A_0.Length - 1;
			int num2 = 0;
			while (i >= 3)
			{
				this.b[num2] = (uint)(((int)A_0[i - 3] << 24) + ((int)A_0[i - 2] << 16) + ((int)A_0[i - 1] << 8) + (int)A_0[i]);
				i -= 4;
				num2++;
			}
			if (num == 1)
			{
				this.b[this.c - 1] = (uint)A_0[0];
			}
			else if (num == 2)
			{
				this.b[this.c - 1] = (uint)(((int)A_0[0] << 8) + (int)A_0[1]);
			}
			else if (num == 3)
			{
				this.b[this.c - 1] = (uint)(((int)A_0[0] << 16) + ((int)A_0[1] << 8) + (int)A_0[2]);
			}
			while (this.c > 1 && this.b[this.c - 1] == 0U)
			{
				this.c--;
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000195D0 File Offset: 0x000185D0
		internal h(uint[] A_0)
		{
			this.c = A_0.Length;
			if (this.c > 70)
			{
				throw new ArithmeticException("Byte overflow in constructor.");
			}
			this.b = new uint[70];
			int i = this.c - 1;
			int num = 0;
			while (i >= 0)
			{
				this.b[num] = A_0[i];
				i--;
				num++;
			}
			while (this.c > 1 && this.b[this.c - 1] == 0U)
			{
				this.c--;
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00019676 File Offset: 0x00018676
		internal h(uint A_0)
		{
			this.c = 1;
			this.b = new uint[70];
			this.b[0] = A_0;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000196A0 File Offset: 0x000186A0
		internal h(string A_0, int A_1)
		{
			h a_ = new h(1U);
			h h = new h();
			A_0 = A_0.ToUpper().Trim();
			int num = 0;
			if (A_0[0] == '-')
			{
				num = 1;
			}
			for (int i = A_0.Length - 1; i >= num; i--)
			{
				int num2 = (int)A_0[i];
				if (num2 >= 48 && num2 <= 57)
				{
					num2 -= 48;
				}
				else if (num2 >= 65 && num2 <= 90)
				{
					num2 = num2 - 65 + 10;
				}
				else
				{
					num2 = 9999999;
				}
				if (num2 >= A_1)
				{
					throw new ArithmeticException("Invalid string in constructor.");
				}
				if (A_0[0] == '-')
				{
					num2 = -num2;
				}
				h = zz93.h.n(h, zz93.h.l(a_, zz93.h.a(num2)));
				if (i - 1 >= num)
				{
					a_ = zz93.h.l(a_, zz93.h.a(A_1));
				}
			}
			if (A_0[0] == '-')
			{
				if ((h.b[69] & 2147483648U) == 0U)
				{
					throw new ArithmeticException("Negative underflow in constructor.");
				}
			}
			else if ((h.b[69] & 2147483648U) != 0U)
			{
				throw new ArithmeticException("Positive overflow in constructor.");
			}
			this.b = new uint[70];
			for (int i = 0; i < h.c; i++)
			{
				this.b[i] = h.b[i];
			}
			this.c = h.c;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0001985E File Offset: 0x0001885E
		private h()
		{
			this.b = new uint[70];
			this.c = 1;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00019880 File Offset: 0x00018880
		private h(long A_0)
		{
			this.b = new uint[70];
			long num = A_0;
			this.c = 0;
			while (A_0 != 0L && this.c < 70)
			{
				this.b[this.c] = (uint)(A_0 & (long)((ulong)-1));
				A_0 >>= 32;
				this.c++;
			}
			if (num > 0L)
			{
				if (A_0 != 0L || (this.b[69] & 2147483648U) != 0U)
				{
					throw new ArithmeticException("Positive overflow in constructor.");
				}
			}
			else if (num < 0L)
			{
				if (A_0 != -1L || (this.b[this.c - 1] & 2147483648U) == 0U)
				{
					throw new ArithmeticException("Negative underflow in constructor.");
				}
			}
			if (this.c == 0)
			{
				this.c = 1;
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00019980 File Offset: 0x00018980
		private h(ulong A_0)
		{
			this.b = new uint[70];
			this.c = 0;
			while (A_0 != 0UL && this.c < 70)
			{
				this.b[this.c] = (uint)(A_0 & (ulong)-1);
				A_0 >>= 32;
				this.c++;
			}
			if (A_0 != 0UL || (this.b[69] & 2147483648U) != 0U)
			{
				throw new ArithmeticException("Positive overflow in constructor.");
			}
			if (this.c == 0)
			{
				this.c = 1;
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00019A2C File Offset: 0x00018A2C
		private h(h A_0)
		{
			this.b = new uint[70];
			this.c = A_0.c;
			for (int i = 0; i < this.c; i++)
			{
				this.b[i] = A_0.b[i];
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00019A80 File Offset: 0x00018A80
		public static h a(long A_0)
		{
			return new h(A_0);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00019A98 File Offset: 0x00018A98
		public static h a(ulong A_0)
		{
			return new h(A_0);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00019AB0 File Offset: 0x00018AB0
		public static h a(int A_0)
		{
			return new h((long)A_0);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00019ACC File Offset: 0x00018ACC
		public static h a(uint A_0)
		{
			return new h((ulong)A_0);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00019AE8 File Offset: 0x00018AE8
		public static h n(h A_0, h A_1)
		{
			h h = new h();
			h.c = ((A_0.c > A_1.c) ? A_0.c : A_1.c);
			long num = 0L;
			for (int i = 0; i < h.c; i++)
			{
				long num2 = (long)((ulong)A_0.b[i] + (ulong)A_1.b[i] + (ulong)num);
				num = num2 >> 32;
				h.b[i] = (uint)(num2 & (long)((ulong)-1));
			}
			if (num != 0L && h.c < 70)
			{
				h.b[h.c] = (uint)num;
				h.c++;
			}
			while (h.c > 1 && h.b[h.c - 1] == 0U)
			{
				h.c--;
			}
			int num3 = 69;
			if ((A_0.b[num3] & 2147483648U) == (A_1.b[num3] & 2147483648U) && (h.b[num3] & 2147483648U) != (A_0.b[num3] & 2147483648U))
			{
				throw new ArithmeticException();
			}
			return h;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00019C30 File Offset: 0x00018C30
		public static h d(h A_0)
		{
			h h = new h(A_0);
			long num = 1L;
			int num2 = 0;
			while (num != 0L && num2 < 70)
			{
				long num3 = (long)((ulong)h.b[num2]);
				num3 += 1L;
				h.b[num2] = (uint)(num3 & (long)((ulong)-1));
				num = num3 >> 32;
				num2++;
			}
			if (num2 > h.c)
			{
				h.c = num2;
			}
			else
			{
				while (h.c > 1 && h.b[h.c - 1] == 0U)
				{
					h.c--;
				}
			}
			int num4 = 69;
			if ((A_0.b[num4] & 2147483648U) == 0U && (h.b[num4] & 2147483648U) != (A_0.b[num4] & 2147483648U))
			{
				throw new ArithmeticException("Overflow in ++.");
			}
			return h;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00019D2C File Offset: 0x00018D2C
		public static h m(h A_0, h A_1)
		{
			h h = new h();
			h.c = ((A_0.c > A_1.c) ? A_0.c : A_1.c);
			long num = 0L;
			for (int i = 0; i < h.c; i++)
			{
				long num2 = (long)((ulong)A_0.b[i] - (ulong)A_1.b[i] - (ulong)num);
				h.b[i] = (uint)(num2 & (long)((ulong)-1));
				if (num2 < 0L)
				{
					num = 1L;
				}
				else
				{
					num = 0L;
				}
			}
			if (num != 0L)
			{
				for (int i = h.c; i < 70; i++)
				{
					h.b[i] = uint.MaxValue;
				}
				h.c = 70;
			}
			while (h.c > 1 && h.b[h.c - 1] == 0U)
			{
				h.c--;
			}
			int num3 = 69;
			if ((A_0.b[num3] & 2147483648U) != (A_1.b[num3] & 2147483648U) && (h.b[num3] & 2147483648U) != (A_0.b[num3] & 2147483648U))
			{
				throw new ArithmeticException();
			}
			return h;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00019E80 File Offset: 0x00018E80
		public static h c(h A_0)
		{
			h h = new h(A_0);
			bool flag = true;
			int num = 0;
			while (flag && num < 70)
			{
				long num2 = (long)((ulong)h.b[num]);
				num2 -= 1L;
				h.b[num] = (uint)(num2 & (long)((ulong)-1));
				if (num2 >= 0L)
				{
					flag = false;
				}
				num++;
			}
			if (num > h.c)
			{
				h.c = num;
			}
			while (h.c > 1 && h.b[h.c - 1] == 0U)
			{
				h.c--;
			}
			int num3 = 69;
			if ((A_0.b[num3] & 2147483648U) != 0U && (h.b[num3] & 2147483648U) != (A_0.b[num3] & 2147483648U))
			{
				throw new ArithmeticException("Underflow in --.");
			}
			return h;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00019F7C File Offset: 0x00018F7C
		public static h l(h A_0, h A_1)
		{
			int num = 69;
			bool flag = false;
			bool flag2 = false;
			try
			{
				if ((A_0.b[num] & 2147483648U) != 0U)
				{
					flag = true;
					A_0 = zz93.h.a(A_0);
				}
				if ((A_1.b[num] & 2147483648U) != 0U)
				{
					flag2 = true;
					A_1 = zz93.h.a(A_1);
				}
			}
			catch (Exception)
			{
			}
			h h = new h();
			try
			{
				for (int i = 0; i < A_0.c; i++)
				{
					if (A_0.b[i] != 0U)
					{
						ulong num2 = 0UL;
						int j = 0;
						int num3 = i;
						while (j < A_1.c)
						{
							ulong num4 = (ulong)A_0.b[i] * (ulong)A_1.b[j] + (ulong)h.b[num3] + num2;
							h.b[num3] = (uint)(num4 & (ulong)-1);
							num2 = num4 >> 32;
							j++;
							num3++;
						}
						if (num2 != 0UL)
						{
							h.b[i + A_1.c] = (uint)num2;
						}
					}
				}
			}
			catch (Exception)
			{
				throw new ArithmeticException("Multiplication overflow.");
			}
			h.c = A_0.c + A_1.c;
			if (h.c > 70)
			{
				h.c = 70;
			}
			while (h.c > 1 && h.b[h.c - 1] == 0U)
			{
				h.c--;
			}
			if ((h.b[num] & 2147483648U) != 0U)
			{
				if (flag != flag2 && h.b[num] == 2147483648U)
				{
					if (h.c == 1)
					{
						return h;
					}
					bool flag3 = true;
					int i = 0;
					while (i < h.c - 1 && flag3)
					{
						if (h.b[i] != 0U)
						{
							flag3 = false;
						}
						i++;
					}
					if (flag3)
					{
						return h;
					}
				}
				throw new ArithmeticException("Multiplication overflow.");
			}
			h result;
			if (flag != flag2)
			{
				result = zz93.h.a(h);
			}
			else
			{
				result = h;
			}
			return result;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0001A204 File Offset: 0x00019204
		public static h b(h A_0, int A_1)
		{
			h h = new h(A_0);
			h.c = zz93.h.a(h.b, A_1);
			return h;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0001A230 File Offset: 0x00019230
		public static h a(h A_0, int A_1)
		{
			h h = new h(A_0);
			h.c = zz93.h.b(h.b, A_1);
			if ((A_0.b[69] & 2147483648U) != 0U)
			{
				for (int i = 69; i >= h.c; i--)
				{
					h.b[i] = uint.MaxValue;
				}
				uint num = 2147483648U;
				for (int i = 0; i < 32; i++)
				{
					if ((h.b[h.c - 1] & num) != 0U)
					{
						break;
					}
					h.b[h.c - 1] |= num;
					num >>= 1;
				}
				h.c = 70;
			}
			return h;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0001A300 File Offset: 0x00019300
		public static h b(h A_0)
		{
			h h = new h(A_0);
			for (int i = 0; i < 70; i++)
			{
				h.b[i] = ~A_0.b[i];
			}
			h.c = 70;
			while (h.c > 1 && h.b[h.c - 1] == 0U)
			{
				h.c--;
			}
			return h;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0001A378 File Offset: 0x00019378
		public static h a(h A_0)
		{
			h result;
			if (A_0.c == 1 && A_0.b[0] == 0U)
			{
				result = new h();
			}
			else
			{
				h h = new h(A_0);
				for (int i = 0; i < 70; i++)
				{
					h.b[i] = ~A_0.b[i];
				}
				long num = 1L;
				int num2 = 0;
				while (num != 0L && num2 < 70)
				{
					long num3 = (long)((ulong)h.b[num2]);
					num3 += 1L;
					h.b[num2] = (uint)(num3 & (long)((ulong)-1));
					num = num3 >> 32;
					num2++;
				}
				if ((A_0.b[69] & 2147483648U) == (h.b[69] & 2147483648U))
				{
					throw new ArithmeticException("Overflow in negation.\n");
				}
				h.c = 70;
				while (h.c > 1 && h.b[h.c - 1] == 0U)
				{
					h.c--;
				}
				result = h;
			}
			return result;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0001A4A0 File Offset: 0x000194A0
		public static bool k(h A_0, h A_1)
		{
			return A_0.Equals(A_1);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0001A4BC File Offset: 0x000194BC
		public static bool j(h A_0, h A_1)
		{
			return !A_0.Equals(A_1);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0001A4D8 File Offset: 0x000194D8
		public override bool Equals(object o)
		{
			h h = (h)o;
			bool result;
			if (this.c != h.c)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < this.c; i++)
				{
					if (this.b[i] != h.b[i])
					{
						return false;
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0001A53C File Offset: 0x0001953C
		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0001A55C File Offset: 0x0001955C
		public static bool i(h A_0, h A_1)
		{
			int num = 69;
			bool result;
			if ((A_0.b[num] & 2147483648U) != 0U && (A_1.b[num] & 2147483648U) == 0U)
			{
				result = false;
			}
			else if ((A_0.b[num] & 2147483648U) == 0U && (A_1.b[num] & 2147483648U) != 0U)
			{
				result = true;
			}
			else
			{
				int num2 = (A_0.c > A_1.c) ? A_0.c : A_1.c;
				num = num2 - 1;
				while (num >= 0 && A_0.b[num] == A_1.b[num])
				{
					num--;
				}
				result = (num >= 0 && A_0.b[num] > A_1.b[num]);
			}
			return result;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0001A644 File Offset: 0x00019644
		public static bool h(h A_0, h A_1)
		{
			int num = 69;
			bool result;
			if ((A_0.b[num] & 2147483648U) != 0U && (A_1.b[num] & 2147483648U) == 0U)
			{
				result = true;
			}
			else if ((A_0.b[num] & 2147483648U) == 0U && (A_1.b[num] & 2147483648U) != 0U)
			{
				result = false;
			}
			else
			{
				int num2 = (A_0.c > A_1.c) ? A_0.c : A_1.c;
				num = num2 - 1;
				while (num >= 0 && A_0.b[num] == A_1.b[num])
				{
					num--;
				}
				result = (num >= 0 && A_0.b[num] < A_1.b[num]);
			}
			return result;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0001A72C File Offset: 0x0001972C
		public static bool g(h A_0, h A_1)
		{
			return zz93.h.k(A_0, A_1) || zz93.h.i(A_0, A_1);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0001A754 File Offset: 0x00019754
		public static bool f(h A_0, h A_1)
		{
			return zz93.h.k(A_0, A_1) || zz93.h.h(A_0, A_1);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0001A77C File Offset: 0x0001977C
		public static h e(h A_0, h A_1)
		{
			h h = new h();
			h a_ = new h();
			int num = 69;
			bool flag = false;
			bool flag2 = false;
			if ((A_0.b[num] & 2147483648U) != 0U)
			{
				A_0 = zz93.h.a(A_0);
				flag2 = true;
			}
			if ((A_1.b[num] & 2147483648U) != 0U)
			{
				A_1 = zz93.h.a(A_1);
				flag = true;
			}
			h result;
			if (zz93.h.h(A_0, A_1))
			{
				result = h;
			}
			else
			{
				if (A_1.c == 1)
				{
					zz93.h.a(A_0, A_1, h, a_);
				}
				else
				{
					zz93.h.b(A_0, A_1, h, a_);
				}
				if (flag2 != flag)
				{
					result = zz93.h.a(h);
				}
				else
				{
					result = h;
				}
			}
			return result;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0001A840 File Offset: 0x00019840
		public static h d(h A_0, h A_1)
		{
			h a_ = new h();
			h h = new h(A_0);
			int num = 69;
			bool flag = false;
			if ((A_0.b[num] & 2147483648U) != 0U)
			{
				A_0 = zz93.h.a(A_0);
				flag = true;
			}
			if ((A_1.b[num] & 2147483648U) != 0U)
			{
				A_1 = zz93.h.a(A_1);
			}
			h result;
			if (zz93.h.h(A_0, A_1))
			{
				result = h;
			}
			else
			{
				if (A_1.c == 1)
				{
					zz93.h.a(A_0, A_1, a_, h);
				}
				else
				{
					zz93.h.b(A_0, A_1, a_, h);
				}
				if (flag)
				{
					result = zz93.h.a(h);
				}
				else
				{
					result = h;
				}
			}
			return result;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0001A8FC File Offset: 0x000198FC
		public static h c(h A_0, h A_1)
		{
			h h = new h();
			int num = (A_0.c > A_1.c) ? A_0.c : A_1.c;
			for (int i = 0; i < num; i++)
			{
				uint num2 = A_0.b[i] & A_1.b[i];
				h.b[i] = num2;
			}
			h.c = 70;
			while (h.c > 1 && h.b[h.c - 1] == 0U)
			{
				h.c--;
			}
			return h;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0001A9A4 File Offset: 0x000199A4
		public static h b(h A_0, h A_1)
		{
			h h = new h();
			int num = (A_0.c > A_1.c) ? A_0.c : A_1.c;
			for (int i = 0; i < num; i++)
			{
				uint num2 = A_0.b[i] | A_1.b[i];
				h.b[i] = num2;
			}
			h.c = 70;
			while (h.c > 1 && h.b[h.c - 1] == 0U)
			{
				h.c--;
			}
			return h;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0001AA4C File Offset: 0x00019A4C
		public static h a(h A_0, h A_1)
		{
			h h = new h();
			int num = (A_0.c > A_1.c) ? A_0.c : A_1.c;
			for (int i = 0; i < num; i++)
			{
				uint num2 = A_0.b[i] ^ A_1.b[i];
				h.b[i] = num2;
			}
			h.c = 70;
			while (h.c > 1 && h.b[h.c - 1] == 0U)
			{
				h.c--;
			}
			return h;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0001AAF4 File Offset: 0x00019AF4
		public override string ToString()
		{
			return this.b(10);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0001AB10 File Offset: 0x00019B10
		internal string b(int A_0)
		{
			if (A_0 < 2 || A_0 > 36)
			{
				throw new ArgumentException("Radix must be >= 2 and <= 36");
			}
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string text2 = "";
			h h = this;
			bool flag = false;
			if ((h.b[69] & 2147483648U) != 0U)
			{
				flag = true;
				try
				{
					h = zz93.h.a(h);
				}
				catch (Exception)
				{
				}
			}
			h h2 = new h();
			h h3 = new h();
			h a_ = new h((long)A_0);
			if (h.c == 1 && h.b[0] == 0U)
			{
				text2 = "0";
			}
			else
			{
				while (h.c > 1 || (h.c == 1 && h.b[0] != 0U))
				{
					zz93.h.a(h, a_, h2, h3);
					if (h3.b[0] < 10U)
					{
						text2 = h3.b[0] + text2;
					}
					else
					{
						text2 = text[(int)(h3.b[0] - 10U)] + text2;
					}
					h = h2;
				}
				if (flag)
				{
					text2 = "-" + text2;
				}
			}
			return text2;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0001AC80 File Offset: 0x00019C80
		internal h o(h A_0, h A_1)
		{
			if ((A_0.b[69] & 2147483648U) != 0U)
			{
				throw new ArithmeticException("Positive exponents only.");
			}
			h h = zz93.h.a(1);
			bool flag = false;
			h h2;
			if ((this.b[69] & 2147483648U) != 0U)
			{
				h2 = zz93.h.d(zz93.h.a(this), A_1);
				flag = true;
			}
			else
			{
				h2 = zz93.h.d(this, A_1);
			}
			if ((A_1.b[69] & 2147483648U) != 0U)
			{
				A_1 = zz93.h.a(A_1);
			}
			h h3 = new h();
			int num = A_1.c << 1;
			h3.b[num] = 1U;
			h3.c = num + 1;
			h3 = zz93.h.e(h3, A_1);
			int num2 = A_0.a();
			int num3 = 0;
			for (int i = 0; i < A_0.c; i++)
			{
				uint num4 = 1U;
				int j = 0;
				while (j < 32)
				{
					if ((A_0.b[i] & num4) != 0U)
					{
						h = this.a(zz93.h.l(h, h2), A_1, h3);
					}
					num4 <<= 1;
					h2 = this.a(zz93.h.l(h2, h2), A_1, h3);
					if (h2.c == 1 && h2.b[0] == 1U)
					{
						if (flag && (A_0.b[0] & 1U) != 0U)
						{
							return zz93.h.a(h);
						}
						return h;
					}
					else
					{
						num3++;
						if (num3 == num2)
						{
							break;
						}
						j++;
					}
				}
			}
			if (flag && (A_0.b[0] & 1U) != 0U)
			{
				return zz93.h.a(h);
			}
			return h;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0001AE54 File Offset: 0x00019E54
		internal int b()
		{
			return (int)this.b[0];
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0001AE70 File Offset: 0x00019E70
		private static void b(h A_0, h A_1, h A_2, h A_3)
		{
			uint[] array = new uint[70];
			int num = A_0.c + 1;
			uint[] array2 = new uint[num];
			uint num2 = 2147483648U;
			uint num3 = A_1.b[A_1.c - 1];
			int num4 = 0;
			int num5 = 0;
			while (num2 != 0U && (num3 & num2) == 0U)
			{
				num4++;
				num2 >>= 1;
			}
			for (int i = 0; i < A_0.c; i++)
			{
				array2[i] = A_0.b[i];
			}
			zz93.h.a(array2, num4);
			A_1 = zz93.h.b(A_1, num4);
			int j = num - A_1.c;
			int num6 = num - 1;
			ulong num7 = (ulong)A_1.b[A_1.c - 1];
			ulong num8 = (ulong)A_1.b[A_1.c - 2];
			int num9 = A_1.c + 1;
			uint[] array3 = new uint[num9];
			while (j > 0)
			{
				ulong num10 = ((ulong)array2[num6] << 32) + (ulong)array2[num6 - 1];
				ulong num11 = num10 / num7;
				ulong num12 = num10 % num7;
				bool flag = false;
				while (!flag)
				{
					flag = true;
					if (num11 == 4294967296UL || num11 * num8 > (num12 << 32) + (ulong)array2[num6 - 2])
					{
						num11 -= 1UL;
						num12 += num7;
						if (num12 < 4294967296UL)
						{
							flag = false;
						}
					}
				}
				for (int k = 0; k < num9; k++)
				{
					array3[k] = array2[num6 - k];
				}
				h h = new h(array3);
				h h2 = zz93.h.l(A_1, zz93.h.a((long)num11));
				while (zz93.h.i(h2, h))
				{
					num11 -= 1UL;
					h2 = zz93.h.m(h2, A_1);
				}
				h h3 = zz93.h.m(h, h2);
				for (int k = 0; k < num9; k++)
				{
					array2[num6 - k] = h3.b[A_1.c - k];
				}
				array[num5++] = (uint)num11;
				num6--;
				j--;
			}
			A_2.c = num5;
			int l = 0;
			int m = A_2.c - 1;
			while (m >= 0)
			{
				A_2.b[l] = array[m];
				m--;
				l++;
			}
			while (l < 70)
			{
				A_2.b[l] = 0U;
				l++;
			}
			while (A_2.c > 1 && A_2.b[A_2.c - 1] == 0U)
			{
				A_2.c--;
			}
			if (A_2.c == 0)
			{
				A_2.c = 1;
			}
			A_3.c = zz93.h.b(array2, num4);
			for (l = 0; l < A_3.c; l++)
			{
				A_3.b[l] = array2[l];
			}
			while (l < 70)
			{
				A_3.b[l] = 0U;
				l++;
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0001B1A8 File Offset: 0x0001A1A8
		private static void a(h A_0, h A_1, h A_2, h A_3)
		{
			uint[] array = new uint[70];
			int num = 0;
			int i;
			for (i = 0; i < 70; i++)
			{
				A_3.b[i] = A_0.b[i];
			}
			A_3.c = A_0.c;
			while (A_3.c > 1 && A_3.b[A_3.c - 1] == 0U)
			{
				A_3.c--;
			}
			ulong num2 = (ulong)A_1.b[0];
			int j = A_3.c - 1;
			ulong num3 = (ulong)A_3.b[j];
			if (num3 >= num2)
			{
				ulong num4 = num3 / num2;
				array[num++] = (uint)num4;
				A_3.b[j] = (uint)(num3 % num2);
			}
			j--;
			while (j >= 0)
			{
				num3 = ((ulong)A_3.b[j + 1] << 32) + (ulong)A_3.b[j];
				ulong num4 = num3 / num2;
				array[num++] = (uint)num4;
				A_3.b[j + 1] = 0U;
				A_3.b[j--] = (uint)(num3 % num2);
			}
			A_2.c = num;
			int k = 0;
			i = A_2.c - 1;
			while (i >= 0)
			{
				A_2.b[k] = array[i];
				i--;
				k++;
			}
			while (k < 70)
			{
				A_2.b[k] = 0U;
				k++;
			}
			while (A_2.c > 1 && A_2.b[A_2.c - 1] == 0U)
			{
				A_2.c--;
			}
			if (A_2.c == 0)
			{
				A_2.c = 1;
			}
			while (A_3.c > 1 && A_3.b[A_3.c - 1] == 0U)
			{
				A_3.c--;
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0001B3AC File Offset: 0x0001A3AC
		private static int b(uint[] A_0, int A_1)
		{
			int num = 32;
			int num2 = 0;
			int num3 = A_0.Length;
			while (num3 > 1 && A_0[num3 - 1] == 0U)
			{
				num3--;
			}
			for (int i = A_1; i > 0; i -= num)
			{
				if (i < num)
				{
					num = i;
					num2 = 32 - num;
				}
				ulong num4 = 0UL;
				for (int j = num3 - 1; j >= 0; j--)
				{
					ulong num5 = (ulong)A_0[j] >> num;
					num5 |= num4;
					num4 = (ulong)A_0[j] << num2;
					A_0[j] = (uint)num5;
				}
			}
			while (num3 > 1 && A_0[num3 - 1] == 0U)
			{
				num3--;
			}
			return num3;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0001B474 File Offset: 0x0001A474
		private static int a(uint[] A_0, int A_1)
		{
			int num = 32;
			int num2 = A_0.Length;
			while (num2 > 1 && A_0[num2 - 1] == 0U)
			{
				num2--;
			}
			for (int i = A_1; i > 0; i -= num)
			{
				if (i < num)
				{
					num = i;
				}
				ulong num3 = 0UL;
				for (int j = 0; j < num2; j++)
				{
					ulong num4 = (ulong)A_0[j] << num;
					num4 |= num3;
					A_0[j] = (uint)(num4 & (ulong)-1);
					num3 = num4 >> 32;
				}
				if (num3 != 0UL)
				{
					if (num2 + 1 <= A_0.Length)
					{
						A_0[num2] = (uint)num3;
						num2++;
					}
				}
			}
			return num2;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0001B538 File Offset: 0x0001A538
		private h a(h A_0, h A_1, h A_2)
		{
			int num = A_1.c;
			int num2 = num + 1;
			int num3 = num - 1;
			h h = new h();
			int i = num3;
			int num4 = 0;
			while (i < A_0.c)
			{
				h.b[num4] = A_0.b[i];
				i++;
				num4++;
			}
			h.c = A_0.c - num3;
			if (h.c <= 0)
			{
				h.c = 1;
			}
			h h2 = zz93.h.l(h, A_2);
			h h3 = new h();
			i = num2;
			num4 = 0;
			while (i < h2.c)
			{
				h3.b[num4] = h2.b[i];
				i++;
				num4++;
			}
			h3.c = h2.c - num2;
			if (h3.c <= 0)
			{
				h3.c = 1;
			}
			h h4 = new h();
			int num5 = (A_0.c > num2) ? num2 : A_0.c;
			for (i = 0; i < num5; i++)
			{
				h4.b[i] = A_0.b[i];
			}
			h4.c = num5;
			h h5 = new h();
			for (i = 0; i < h3.c; i++)
			{
				if (h3.b[i] != 0U)
				{
					ulong num6 = 0UL;
					int num7 = i;
					num4 = 0;
					while (num4 < A_1.c && num7 < num2)
					{
						ulong num8 = (ulong)h3.b[i] * (ulong)A_1.b[num4] + (ulong)h5.b[num7] + num6;
						h5.b[num7] = (uint)(num8 & (ulong)-1);
						num6 = num8 >> 32;
						num4++;
						num7++;
					}
					if (num7 < num2)
					{
						h5.b[num7] = (uint)num6;
					}
				}
			}
			h5.c = num2;
			while (h5.c > 1 && h5.b[h5.c - 1] == 0U)
			{
				h5.c--;
			}
			h4 = zz93.h.m(h4, h5);
			if ((h4.b[69] & 2147483648U) != 0U)
			{
				h h6 = new h();
				h6.b[num2] = 1U;
				h6.c = num2 + 1;
				h4 = zz93.h.n(h4, h6);
			}
			while (zz93.h.g(h4, A_1))
			{
				h4 = zz93.h.m(h4, A_1);
			}
			return h4;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0001B7F8 File Offset: 0x0001A7F8
		private int a()
		{
			while (this.c > 1 && this.b[this.c - 1] == 0U)
			{
				this.c--;
			}
			uint num = this.b[this.c - 1];
			uint num2 = 2147483648U;
			int num3 = 32;
			while (num3 > 0 && (num & num2) == 0U)
			{
				num3--;
				num2 >>= 1;
			}
			return num3 + (this.c - 1 << 5);
		}

		// Token: 0x04000056 RID: 86
		private const int a = 70;

		// Token: 0x04000057 RID: 87
		private uint[] b;

		// Token: 0x04000058 RID: 88
		private int c;
	}
}
