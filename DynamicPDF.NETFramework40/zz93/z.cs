using System;

namespace zz93
{
	// Token: 0x0200001C RID: 28
	internal class z : r
	{
		// Token: 0x06000123 RID: 291 RVA: 0x00025281 File Offset: 0x00024281
		internal z(int A_0, bool A_1, bool A_2, int A_3, bool A_4) : base(A_0, A_3, A_2, A_1, A_4)
		{
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00025294 File Offset: 0x00024294
		internal i a(byte[] A_0, bool A_1, i A_2)
		{
			i i = new i();
			i i2 = new i();
			int j = 0;
			while (j < A_0.Length)
			{
				if (!A_1)
				{
					goto IL_C9;
				}
				if ((A_0[j] != 126 || j >= A_0.Length - 1 || A_0[j + 1] != 49) && (A_0[j] != 126 || A_0[j + 1] != 50 || j + 7 > A_0.Length))
				{
					goto IL_C9;
				}
				bool flag = A_0[j] == 126 && j < A_0.Length - 1 && A_0[j + 1] == 49;
				base.a(i2, i, A_0, j + 2, j + 8, flag, A_2, 6);
				i2 = new i();
				i = new i();
				j++;
				if (!flag)
				{
					j += 6;
				}
				IL_420:
				j++;
				continue;
				IL_C9:
				if (z.b.IndexOf((char)A_0[j]) >= 0)
				{
					i i3 = i;
					string text = z.b;
					char c = (char)A_0[j];
					i3.a((byte)(text.IndexOf(c.ToString()) + 3));
				}
				else if (A_0[j] >= 0 && A_0[j] <= 31)
				{
					i.a(0);
					i.a(A_0[j]);
				}
				else if (z.a.IndexOf((char)A_0[j]) >= 0)
				{
					i.a(1);
					i i4 = i;
					string text2 = z.a;
					char c = (char)A_0[j];
					i4.a((byte)text2.IndexOf(c.ToString()));
				}
				else if (z.c.IndexOf((char)A_0[j]) >= 0)
				{
					i.a(2);
					i i5 = i;
					string text3 = z.c;
					char c = (char)A_0[j];
					i5.a((byte)text3.IndexOf(c.ToString()));
				}
				else if (A_0[j] > 127 && A_0[j] <= 255)
				{
					byte b = A_0[j] - 128;
					if (z.b.IndexOf((char)b) >= 0)
					{
						i.a(1);
						i.a(30);
						i i6 = i;
						string text4 = z.b;
						char c = (char)b;
						i6.a((byte)(text4.IndexOf(c.ToString()) + 3));
					}
					else
					{
						i.a(1);
						i.a(30);
						if (b >= 0 && b <= 31)
						{
							i.a(0);
							i.a(b);
						}
						else if (z.a.IndexOf((char)b) >= 0)
						{
							i.a(1);
							i i7 = i;
							string text5 = z.a;
							char c = (char)b;
							i7.a((byte)text5.IndexOf(c.ToString()));
						}
						else if (z.c.IndexOf((char)b) >= 0)
						{
							i.a(2);
							i i8 = i;
							string text6 = z.c;
							char c = (char)b;
							i8.a((byte)text6.IndexOf(c.ToString()));
						}
					}
				}
				if (base.d())
				{
					if (i.a() >= 3)
					{
						if (!base.d() || base.a(A_2.a() + base.d(i.a()), base.c() - 2))
						{
							i.a(ref i2);
						}
						else if (i2.a() > 0)
						{
							if (base.b() != 6)
							{
								base.b(base.b(), A_2);
							}
							if (base.b() != 6)
							{
								base.c(6, A_2);
							}
							base.b(i2, A_2);
							j--;
							i2 = new i();
							i = new i();
							base.b(base.b(), A_2);
							A_2 = base.a(A_2);
						}
						else if (i2.a() == 0 && i.a() > 0)
						{
							A_2 = base.a(A_2);
							base.c(6, A_2);
							base.b(i, A_2);
							i2 = new i();
							i = new i();
						}
					}
				}
				goto IL_420;
			}
			if (i.a() > 0)
			{
				if (!base.d() || base.a(A_2.a() + base.d(i.a()), base.c() - 2))
				{
					if (base.b() != 6)
					{
						base.b(base.b(), A_2);
					}
					if (base.b() != 6)
					{
						base.c(6, A_2);
					}
					base.b(i, A_2);
				}
				else
				{
					A_2 = base.a(A_2);
					base.c(6, A_2);
					base.b(i, A_2);
				}
			}
			if (base.e())
			{
				A_2 = base.b(A_2);
			}
			return A_2;
		}

		// Token: 0x040000AF RID: 175
		private new static string a = "!\"#$%&'()*+,-./:;<=>?@[\\]^_";

		// Token: 0x040000B0 RID: 176
		private new static string b = " 0123456789abcdefghijklmnopqrstuvwxyz";

		// Token: 0x040000B1 RID: 177
		private new static string c = "`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~";
	}
}
