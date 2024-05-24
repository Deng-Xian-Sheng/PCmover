using System;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x02000131 RID: 305
	internal class hl
	{
		// Token: 0x06000B92 RID: 2962 RVA: 0x0008CCF6 File Offset: 0x0008BCF6
		internal hl(ij A_0, gi A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x0008CD30 File Offset: 0x0008BD30
		private List<ig> a(int A_0)
		{
			List<ig> list;
			if (this.g != null)
			{
				list = this.g.c3(A_0);
				if (list != null)
				{
					if (list.Count == 1)
					{
						this.c(list[0]);
						if (list[0].b() == null)
						{
							list = null;
						}
					}
					else
					{
						for (int i = 0; i < list.Count; i++)
						{
							this.c(list[i]);
							if (list[i].b() == null)
							{
								list.Remove(list[i]);
							}
						}
					}
				}
			}
			else
			{
				list = null;
			}
			return list;
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x0008CE00 File Offset: 0x0008BE00
		private void a(List<string> A_0)
		{
			int count = A_0.Count;
			int num = A_0.Count - 1;
			for (int i = 0; i < count; i++)
			{
				int num2 = i + 1;
				do
				{
					if (num2 > num)
					{
						num2 = 0;
					}
					else
					{
						A_0.Add(A_0[i] + A_0[num2]);
						num2++;
					}
				}
				while (num2 != i);
			}
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x0008CE75 File Offset: 0x0008BE75
		private void b(ig A_0)
		{
			this.e = 0;
			this.f = 0;
			this.b.a(A_0.a());
			this.a();
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x0008CEA0 File Offset: 0x0008BEA0
		private void a(ig A_0)
		{
			if (this.f > 0)
			{
				fc[] array = new fc[this.e + this.f + 1];
				Array.Copy(this.c, 0, array, 0, this.e);
				Array.Copy(this.d, 0, array, this.e, this.f);
				array[array.Length - 1] = new fc(1210592242, new af7(this.e));
				A_0.a(array);
			}
			else
			{
				fc[] array = new fc[this.e];
				Array.Copy(this.c, 0, array, 0, this.e);
				A_0.a(array);
			}
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x0008CF58 File Offset: 0x0008BF58
		private void a()
		{
			while (this.b.ae())
			{
				int num = this.b.v();
				if (this.b.c(num) && this.b.@as())
				{
					if (this.b.ab())
					{
						fc fc = fc.a(this.d, this.f, num);
						if (fc == null)
						{
							int num2 = num;
							if (num2 != 510035525)
							{
								fc = new fc(num, fd.a(num, this.b));
								this.a(fc);
							}
							else
							{
								iv iv = (iv)fd.a(num, this.b);
								if (iv.b())
								{
									fc = new fc(num, iv);
									this.a(fc);
								}
							}
						}
						else
						{
							fc.b().cw(this.b);
						}
						if (fc != null)
						{
							this.a(true, fc);
						}
					}
					else
					{
						fc fc = fc.a(this.c, this.e, num);
						if (fc == null)
						{
							int num2 = num;
							if (num2 != 510035525)
							{
								fc = new fc(num, fd.a(num, this.b));
								this.b(fc);
							}
							else
							{
								iv iv = (iv)fd.a(num, this.b);
								if (iv.b())
								{
									fc = new fc(num, iv);
									this.b(fc);
								}
							}
						}
						else
						{
							fc.b().cw(this.b);
						}
						if (fc != null)
						{
							this.a(false, fc);
						}
					}
				}
				else
				{
					this.b.ap();
				}
			}
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x0008D130 File Offset: 0x0008C130
		private void a(bool A_0, fc A_1)
		{
			int num = A_1.a();
			if (num != 6968946)
			{
				if (num == 1652275116)
				{
					fc fc;
					if (A_0)
					{
						fc = fc.a(this.d, this.d.Length, 6968946);
					}
					else
					{
						fc = fc.a(this.c, this.c.Length, 6968946);
					}
					if (fc != null)
					{
						int num2 = ((hd)fc.b()).c();
						((hd)fc.b()).a(num2, ((ho)A_1.b()).a());
					}
				}
			}
			else
			{
				int num2 = ((hd)A_1.b()).c();
				if (num2 > -1)
				{
					fc fc2;
					if (A_0)
					{
						fc2 = fc.a(this.d, this.d.Length, 1652275116);
					}
					else
					{
						fc2 = fc.a(this.c, this.c.Length, 1652275116);
					}
					if (fc2 == null)
					{
						ho ho = new ho();
						ho.a((afz)((hd)A_1.b()).a()[num2].b());
						fc2 = new fc(1652275116, ho);
						if (A_0)
						{
							this.a(fc2);
						}
						else
						{
							this.b(fc2);
						}
					}
					else
					{
						((ho)fc2.b()).a((afz)((hd)A_1.b()).a()[num2].b());
					}
				}
			}
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x0008D2E4 File Offset: 0x0008C2E4
		private void b(fc A_0)
		{
			if (this.e == this.c.Length)
			{
				this.c = this.a(this.c);
			}
			this.c[this.e] = A_0;
			this.e++;
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x0008D338 File Offset: 0x0008C338
		private void a(fc A_0)
		{
			if (this.f == this.d.Length)
			{
				this.d = this.a(this.d);
			}
			this.d[this.f] = A_0;
			this.f++;
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x0008D38C File Offset: 0x0008C38C
		private fc[] a(fc[] A_0)
		{
			fc[] array = new fc[A_0.Length * 2];
			Array.Copy(A_0, 0, array, 0, A_0.Length);
			A_0 = array;
			return A_0;
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x0008D3BC File Offset: 0x0008C3BC
		private int a(fc[] A_0, int A_1)
		{
			int i;
			for (i = 0; i < A_0.Length; i++)
			{
				if (A_0[i].a() == A_1)
				{
					return i;
				}
			}
			return i;
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x0008D3FC File Offset: 0x0008C3FC
		private int a(string A_0)
		{
			hg hg = new hg();
			hl.a(A_0, hg);
			int result = hg.b();
			hg.a();
			return result;
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x0008D42C File Offset: 0x0008C42C
		private int a(string A_0, string A_1)
		{
			hg hg = new hg();
			hl.a(A_0, hg);
			hl.a(A_1, hg);
			int result = hg.b();
			hg.a();
			return result;
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x0008D464 File Offset: 0x0008C464
		private static void a(string A_0, hg A_1)
		{
			if (A_0.Length == 1)
			{
				A_1.b(A_0[0]);
			}
			else
			{
				for (int i = 0; i < A_0.Length; i++)
				{
					A_1.b(A_0[i]);
				}
			}
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x0008D4BC File Offset: 0x0008C4BC
		private int a(char A_0, char[] A_1)
		{
			hg hg = new hg();
			hg.b(A_0);
			foreach (char a_ in A_1)
			{
				hg.b(a_);
			}
			int result = hg.b();
			hg.a();
			return result;
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x0008D518 File Offset: 0x0008C518
		private int a(char[] A_0, char A_1, char[] A_2)
		{
			hg hg = new hg();
			foreach (char a_ in A_0)
			{
				hg.b(a_);
			}
			hg.b(A_1);
			foreach (char a_ in A_2)
			{
				hg.b(a_);
			}
			int result = hg.b();
			hg.a();
			return result;
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x0008D5A4 File Offset: 0x0008C5A4
		internal List<ig> b(int A_0)
		{
			this.g = this.a.j();
			return this.a(A_0);
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x0008D5D0 File Offset: 0x0008C5D0
		internal ih a(d0 A_0)
		{
			List<ig> list = new List<ig>();
			List<int> list2 = new List<int>();
			List<int> list3 = this.b(A_0);
			this.g = this.a.j();
			foreach (int num in list3)
			{
				List<ig> list4 = this.a(num);
				if (list4 != null)
				{
					if (list4.Count == 1)
					{
						list.Add(list4[0]);
						list2.Add(num);
					}
					else
					{
						foreach (ig item in list4)
						{
							list.Add(item);
							list2.Add(num);
						}
					}
				}
			}
			return new ih(list2, list);
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x0008D6F4 File Offset: 0x0008C6F4
		internal void c(ig A_0)
		{
			if (A_0 != null && A_0.b() == null && A_0.a() != null)
			{
				this.b(A_0);
				this.a(A_0);
				A_0.e();
			}
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x0008D738 File Offset: 0x0008C738
		internal List<int> b(d0 A_0)
		{
			if (A_0.n() == null)
			{
				List<string> list = new List<string>();
				List<int> list2 = new List<int>();
				List<string> list3 = A_0.o();
				if (A_0.k() != null)
				{
					if (this.a.o())
					{
						list.Add("#" + A_0.k());
					}
					if (list3 == null)
					{
						list3 = new List<string>();
					}
					list3.Add("id=" + A_0.k());
				}
				if (A_0.l() != null && A_0.l().Length > 0)
				{
					if (list3 == null)
					{
						list3 = new List<string>();
					}
					foreach (string str in A_0.l())
					{
						if (this.a.n())
						{
							list.Add("." + str);
						}
						list3.Add("class=" + str);
					}
				}
				if (list3 != null && this.a.m())
				{
					foreach (string text in list3)
					{
						list.Add("[" + text + "]");
						int num = text.IndexOf('=');
						if (num != -1)
						{
							string text2 = text.Substring(0, num + 1);
							text2 = text2 + "\"" + text.Substring(num + 1) + "\"";
							list.Add("[" + text2 + "]");
							list.Add("[" + text.Substring(0, num) + "]");
						}
					}
				}
				if (this.a.p())
				{
					bool flag = this.a.a(this.a.i().b());
					if (flag)
					{
						list.Add(":first-child");
					}
				}
				this.a(list);
				foreach (string text3 in list)
				{
					list2.Add(this.a(A_0.co(), text3));
					list2.Add(this.a(text3));
				}
				list2.Add(A_0.cn());
				A_0.a(list2);
			}
			return A_0.n();
		}

		// Token: 0x04000629 RID: 1577
		private ij a;

		// Token: 0x0400062A RID: 1578
		private gi b;

		// Token: 0x0400062B RID: 1579
		private fc[] c = new fc[1];

		// Token: 0x0400062C RID: 1580
		private fc[] d = new fc[1];

		// Token: 0x0400062D RID: 1581
		private int e;

		// Token: 0x0400062E RID: 1582
		private int f;

		// Token: 0x0400062F RID: 1583
		private hi g = null;
	}
}
