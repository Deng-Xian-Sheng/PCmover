using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace zz93
{
	// Token: 0x02000007 RID: 7
	internal class e
	{
		// Token: 0x06000043 RID: 67 RVA: 0x00017A08 File Offset: 0x00016A08
		internal bool a()
		{
			return this.y;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00017A20 File Offset: 0x00016A20
		internal void a(bool A_0)
		{
			this.y = A_0;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00017A2C File Offset: 0x00016A2C
		private int k(byte A_0)
		{
			for (int i = 0; i < zz93.e.s.GetLength(0); i++)
			{
				if (zz93.e.s[i, 0] == (short)A_0)
				{
					return (int)zz93.e.s[i, 1];
				}
			}
			return (int)A_0;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00017A80 File Offset: 0x00016A80
		private int j(byte A_0)
		{
			for (int i = 0; i < zz93.e.t.GetLength(0); i++)
			{
				if (zz93.e.t[i, 0] == (short)A_0)
				{
					return (int)zz93.e.t[i, 1];
				}
			}
			return (int)A_0;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00017AD4 File Offset: 0x00016AD4
		private int i(byte A_0)
		{
			for (int i = 0; i < zz93.e.u.GetLength(0); i++)
			{
				if (zz93.e.u[i, 0] == (short)A_0)
				{
					return (int)zz93.e.u[i, 1];
				}
			}
			return (int)A_0;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00017B28 File Offset: 0x00016B28
		private int h(byte A_0)
		{
			for (int i = 0; i < zz93.e.v.GetLength(0); i++)
			{
				if (zz93.e.v[i, 0] == (short)A_0)
				{
					return (int)zz93.e.v[i, 1];
				}
			}
			return (int)A_0;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00017B7C File Offset: 0x00016B7C
		private int g(byte A_0)
		{
			for (int i = 0; i < zz93.e.x.GetLength(0); i++)
			{
				if (zz93.e.x[i, 0] == (short)A_0)
				{
					return (int)zz93.e.x[i, 1];
				}
			}
			return (int)A_0;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00017BD0 File Offset: 0x00016BD0
		private f f(byte A_0)
		{
			using (IEnumerator enumerator = Enum.GetValues(typeof(f)).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					f f = (f)enumerator.Current;
					if (this.a(A_0))
					{
						return zz93.f.a;
					}
					if (this.b(A_0))
					{
						return zz93.f.b;
					}
					if (this.c(A_0))
					{
						return zz93.f.c;
					}
					if (this.d(A_0))
					{
						return zz93.f.d;
					}
					if (this.e(A_0))
					{
						return zz93.f.e;
					}
					return zz93.f.f;
				}
			}
			return zz93.f.f;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00017CA0 File Offset: 0x00016CA0
		private bool e(byte A_0)
		{
			for (int i = 0; i < zz93.e.x.GetLength(0); i++)
			{
				if (zz93.e.x[i, 0] == (short)A_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00017CE8 File Offset: 0x00016CE8
		private bool d(byte A_0)
		{
			for (int i = 0; i < zz93.e.v.GetLength(0); i++)
			{
				if (zz93.e.v[i, 0] == (short)A_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00017D30 File Offset: 0x00016D30
		private bool c(byte A_0)
		{
			for (int i = 0; i < zz93.e.u.GetLength(0); i++)
			{
				if (zz93.e.u[i, 0] == (short)A_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00017D78 File Offset: 0x00016D78
		private bool b(byte A_0)
		{
			for (int i = 0; i < zz93.e.t.GetLength(0); i++)
			{
				if (zz93.e.t[i, 0] == (short)A_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00017DC0 File Offset: 0x00016DC0
		private bool a(byte A_0)
		{
			for (int i = 0; i < zz93.e.s.GetLength(0); i++)
			{
				if (zz93.e.s[i, 0] == (short)A_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00017E08 File Offset: 0x00016E08
		private void a(byte[] A_0, ref int A_1, List<int> A_2, List<f> A_3)
		{
			if (this.z == zz93.f.d)
			{
				A_2.Add(31);
				A_3.Add(this.z);
				this.z = zz93.f.a;
			}
			else if (this.z == zz93.f.e)
			{
				A_2.Add(14);
				A_3.Add(this.z);
				this.z = zz93.f.a;
			}
			A_2.Add(31);
			A_3.Add(this.z);
			int num = 0;
			A_2.Add(0);
			A_3.Add(zz93.f.a);
			A_2.Add((int)A_0[A_1]);
			A_3.Add(zz93.f.f);
			A_1++;
			num++;
			while (A_1 < A_0.Length)
			{
				if (this.f(A_0[A_1]) != zz93.f.f)
				{
					break;
				}
				A_2.Add((int)A_0[A_1]);
				A_3.Add(zz93.f.f);
				A_1++;
				num++;
			}
			if (num <= 31)
			{
				A_2[A_2.Count - num - 1] = num;
			}
			if (num > 31)
			{
				A_2.Insert(A_2.Count - num, num - 31);
				A_3.Insert(A_2.Count - num, zz93.f.g);
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00017F54 File Offset: 0x00016F54
		internal List<string> a(string A_0, bool A_1, int A_2)
		{
			return this.a(Encoding.Default.GetBytes(A_0), A_1, A_2);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00017F7C File Offset: 0x00016F7C
		internal List<string> a(byte[] A_0, bool A_1, int A_2)
		{
			List<int> list = new List<int>();
			List<f> list2 = new List<f>();
			int num = 0;
			for (;;)
			{
				if (A_2 == 1 && A_1 && num + "~1".Length < A_0.Length && (num == 0 || num == 1 || num == 2))
				{
					if (A_0[num] != 126 || A_0[num + 1] != 49 || (num != 0 && (num != 1 || (!this.b(A_0[num - 1]) && !this.a(A_0[num - 1]))) && (num != 2 || (!this.e(A_0[num - 1]) && !this.e(A_0[num - 2])))))
					{
						goto IL_20F;
					}
					list.Add(0);
					list2.Add(this.z);
					list.Add(0);
					list2.Add(zz93.f.d);
					list.Add(0);
					list2.Add(zz93.f.h);
					num += 2;
				}
				else
				{
					if (!A_1 || num + 2 >= A_0.Length)
					{
						goto IL_20F;
					}
					if (A_0[num] != 126 || A_0[num + 1] != 49)
					{
						goto IL_20F;
					}
					switch (this.z)
					{
					case zz93.f.a:
					case zz93.f.b:
						list.Add(29);
						list2.Add(this.z);
						this.z = zz93.f.c;
						break;
					case zz93.f.d:
						list.Add(31);
						list2.Add(this.z);
						this.z = zz93.f.a;
						list.Add(29);
						list2.Add(this.z);
						this.z = zz93.f.c;
						break;
					case zz93.f.e:
						list.Add(14);
						list2.Add(this.z);
						this.z = zz93.f.a;
						list.Add(29);
						list2.Add(this.z);
						this.z = zz93.f.c;
						break;
					}
					list.Add(17);
					list2.Add(this.z);
					num += 2;
				}
				IL_104C:
				if (num >= A_0.Length)
				{
					goto Block_54;
				}
				continue;
				IL_20F:
				if (A_1 && num + 2 + 6 < A_0.Length)
				{
					if (A_0[num] == 126 && A_0[num + 1] == 50)
					{
						switch (this.z)
						{
						case zz93.f.a:
						case zz93.f.b:
							list.Add(30);
							list2.Add(this.z);
							this.z = zz93.f.e;
							break;
						case zz93.f.c:
							list.Add(29);
							list2.Add(this.z);
							this.z = zz93.f.a;
							list.Add(30);
							list2.Add(this.z);
							this.z = zz93.f.e;
							break;
						case zz93.f.d:
							list.Add(31);
							list2.Add(this.z);
							this.z = zz93.f.a;
							list.Add(30);
							list2.Add(this.z);
							this.z = zz93.f.e;
							break;
						}
						list.Add(0);
						list2.Add(this.z);
						list.Add(0);
						list2.Add(zz93.f.d);
						num += 2;
						string arg = string.Empty;
						for (int i = num; i < num + 6; i++)
						{
							if (A_0[i] <= 47 || A_0[i] >= 58)
							{
								goto IL_375;
							}
							arg += (int)(A_0[i] - 48);
						}
						int num2 = int.Parse(arg);
						int length = num2.ToString().Length;
						list.Add(length);
						list2.Add(zz93.f.h);
						for (int j = 0; j < num2.ToString().Length; j++)
						{
							list.Add(this.g((byte)num2.ToString()[j]));
							list2.Add(zz93.f.e);
						}
						num += 6;
						goto IL_104C;
					}
				}
				if (A_0[num] == 32 && num + 1 < A_0.Length)
				{
					if (this.e(A_0[num + 1]))
					{
						switch (this.z)
						{
						case zz93.f.a:
						case zz93.f.b:
							list.Add(30);
							list2.Add(this.z);
							this.z = zz93.f.e;
							break;
						case zz93.f.c:
							list.Add(29);
							list2.Add(this.z);
							list.Add(30);
							list2.Add(zz93.f.a);
							this.z = zz93.f.e;
							break;
						case zz93.f.d:
							list.Add(31);
							list2.Add(this.z);
							list.Add(30);
							list2.Add(zz93.f.a);
							this.z = zz93.f.e;
							break;
						}
						list.Add(this.g(A_0[num]));
						list2.Add(this.z);
						list.Add(this.g(A_0[num + 1]));
						list2.Add(this.z);
						num += 2;
						goto IL_104C;
					}
				}
				if ((A_0[num] == 13 || A_0[num] == 44 || A_0[num] == 46 || A_0[num] == 58) && num + 1 < A_0.Length)
				{
					bool flag = false;
					for (int k = 0; k < zz93.e.w.GetLength(0); k++)
					{
						if (zz93.e.w[k, 0] == (short)A_0[num] && zz93.e.w[k, 1] == (short)A_0[num + 1])
						{
							if (this.z != zz93.f.d)
							{
								list.Add(0);
								list2.Add(this.z);
							}
							list.Add((int)zz93.e.w[k, 2]);
							list2.Add(zz93.f.d);
							flag = true;
							break;
						}
					}
					if (flag)
					{
						num += 2;
						goto IL_104C;
					}
				}
				if (A_0[num] == 13)
				{
					switch (this.z)
					{
					case zz93.f.a:
					case zz93.f.b:
						if (num + 1 < A_0.Length)
						{
							if (this.c(A_0[num + 1]))
							{
								list.Add(29);
								list2.Add(this.z);
								this.z = zz93.f.c;
								list.Add(this.i(A_0[num]));
								list2.Add(this.z);
								list.Add(this.i(A_0[num + 1]));
								list2.Add(this.z);
								num += 2;
								goto IL_104C;
							}
						}
						break;
					case zz93.f.c:
						list.Add(this.i(A_0[num]));
						list2.Add(this.z);
						num++;
						goto IL_104C;
					case zz93.f.d:
						list.Add(this.h(A_0[num]));
						list2.Add(this.z);
						num++;
						goto IL_104C;
					}
					list.Add(0);
					list2.Add(this.z);
					list.Add(this.h(A_0[num]));
					list2.Add(zz93.f.d);
					num++;
					goto IL_104C;
				}
				if (A_0[num] == 46 || A_0[num] == 44)
				{
					switch (this.z)
					{
					case zz93.f.a:
					case zz93.f.b:
						list.Add(30);
						list2.Add(this.z);
						this.z = zz93.f.e;
						list.Add(this.g(A_0[num]));
						list2.Add(this.z);
						num++;
						goto IL_104C;
					case zz93.f.c:
						list.Add(30);
						list2.Add(this.z);
						this.z = zz93.f.d;
						list.Add(this.h(A_0[num]));
						list2.Add(this.z);
						num++;
						goto IL_104C;
					case zz93.f.d:
						list.Add(this.h(A_0[num]));
						list2.Add(this.z);
						num++;
						goto IL_104C;
					case zz93.f.e:
						list.Add(this.g(A_0[num]));
						list2.Add(this.z);
						num++;
						goto IL_104C;
					}
				}
				f f = this.f(A_0[num]);
				switch (this.z)
				{
				case zz93.f.a:
					switch (f)
					{
					case zz93.f.a:
						list.Add(this.k(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.b:
						list.Add(28);
						list2.Add(this.z);
						this.z = zz93.f.b;
						list.Add(this.j(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.c:
						list.Add(29);
						list2.Add(this.z);
						this.z = zz93.f.c;
						list.Add(this.i(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.d:
						list.Add(0);
						list2.Add(this.z);
						list.Add(this.h(A_0[num]));
						list2.Add(zz93.f.d);
						num++;
						break;
					case zz93.f.e:
						list.Add(30);
						list2.Add(this.z);
						this.z = zz93.f.e;
						list.Add(this.g(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.f:
						this.a(A_0, ref num, list, list2);
						break;
					}
					break;
				case zz93.f.b:
					switch (f)
					{
					case zz93.f.a:
						list.Add(28);
						list2.Add(this.z);
						list.Add(this.k(A_0[num]));
						list2.Add(zz93.f.a);
						num++;
						break;
					case zz93.f.b:
						list.Add(this.j(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.c:
						list.Add(29);
						list2.Add(this.z);
						this.z = zz93.f.c;
						list.Add(this.i(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.d:
						list.Add(0);
						list2.Add(this.z);
						list.Add(this.h(A_0[num]));
						list2.Add(zz93.f.d);
						num++;
						break;
					case zz93.f.e:
						list.Add(30);
						list2.Add(this.z);
						this.z = zz93.f.e;
						list.Add(this.g(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.f:
						this.a(A_0, ref num, list, list2);
						break;
					}
					break;
				case zz93.f.c:
					switch (f)
					{
					case zz93.f.a:
						list.Add(29);
						list2.Add(this.z);
						this.z = zz93.f.a;
						list.Add(this.k(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.b:
						list.Add(28);
						list2.Add(this.z);
						this.z = zz93.f.b;
						list.Add(this.j(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.c:
						list.Add(this.i(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.d:
						list.Add(30);
						list2.Add(this.z);
						this.z = zz93.f.d;
						list.Add(this.h(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.e:
						list.Add(29);
						list2.Add(this.z);
						this.z = zz93.f.a;
						list.Add(30);
						list2.Add(this.z);
						this.z = zz93.f.e;
						list.Add(this.g(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.f:
						this.a(A_0, ref num, list, list2);
						break;
					}
					break;
				case zz93.f.d:
					switch (f)
					{
					case zz93.f.a:
						list.Add(31);
						list2.Add(this.z);
						this.z = zz93.f.a;
						list.Add(this.k(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.b:
						list.Add(31);
						list2.Add(this.z);
						this.z = zz93.f.a;
						list.Add(28);
						list2.Add(this.z);
						this.z = zz93.f.b;
						list.Add(this.j(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.c:
						list.Add(31);
						list2.Add(this.z);
						this.z = zz93.f.a;
						list.Add(29);
						list2.Add(this.z);
						this.z = zz93.f.c;
						list.Add(this.i(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.d:
						list.Add(this.h(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.e:
						list.Add(31);
						list2.Add(this.z);
						this.z = zz93.f.a;
						list.Add(30);
						list2.Add(this.z);
						this.z = zz93.f.e;
						list.Add(this.g(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.f:
						this.a(A_0, ref num, list, list2);
						break;
					}
					break;
				case zz93.f.e:
					switch (f)
					{
					case zz93.f.a:
						list.Add(14);
						list2.Add(this.z);
						this.z = zz93.f.a;
						list.Add(this.k(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.b:
						list.Add(14);
						list2.Add(this.z);
						this.z = zz93.f.a;
						list.Add(28);
						list2.Add(this.z);
						this.z = zz93.f.b;
						list.Add(this.j(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.c:
						list.Add(14);
						list2.Add(this.z);
						this.z = zz93.f.a;
						list.Add(29);
						list2.Add(this.z);
						this.z = zz93.f.c;
						list.Add(this.i(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.d:
						list.Add(0);
						list2.Add(this.z);
						list.Add(this.h(A_0[num]));
						list2.Add(zz93.f.d);
						num++;
						break;
					case zz93.f.e:
						list.Add(this.g(A_0[num]));
						list2.Add(this.z);
						num++;
						break;
					case zz93.f.f:
						this.a(A_0, ref num, list, list2);
						break;
					}
					break;
				}
				goto IL_104C;
			}
			IL_375:
			throw new an("ECI number must be 6 digits long.");
			Block_54:
			List<string> list3 = new List<string>();
			for (int j = 0; j < list.Count; j++)
			{
				switch (list2[j])
				{
				case zz93.f.e:
					list3.Add(Convert.ToString(list[j], 2).PadLeft(4, '0'));
					break;
				case zz93.f.f:
					list3.Add(Convert.ToString(list[j], 2).PadLeft(8, '0'));
					break;
				case zz93.f.g:
					list3.Add(Convert.ToString(list[j], 2).PadLeft(11, '0'));
					break;
				case zz93.f.h:
					list3.Add(Convert.ToString(list[j], 2).PadLeft(3, '0'));
					break;
				default:
					list3.Add(Convert.ToString(list[j], 2).PadLeft(5, '0'));
					break;
				}
			}
			return list3;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000190E4 File Offset: 0x000180E4
		internal List<string> a(byte[] A_0, bool A_1)
		{
			int num = 0;
			List<string> list = new List<string>();
			List<int> list2 = new List<int>();
			List<f> list3 = new List<f>();
			if (A_1 && A_0.Length > "~1".Length && A_0[0] == 126 && A_0[1] == 49)
			{
				list2.Add(0);
				list3.Add(zz93.f.a);
				list2.Add(0);
				list3.Add(zz93.f.d);
				list2.Add(0);
				list3.Add(zz93.f.h);
				num += 2;
			}
			for (int i = 0; i < list2.Count; i++)
			{
				if (list3[i] == zz93.f.h)
				{
					list.Add(Convert.ToString(list2[i], 2).PadLeft(3, '0'));
				}
				else
				{
					list.Add(Convert.ToString(list2[i], 2).PadLeft(5, '0'));
				}
			}
			int num2 = 0;
			for (int j = num; j < A_0.Length; j++)
			{
				if (A_0[j] <= 47 || A_0[j] >= 58)
				{
					throw new ap("Incorrect Rune value. The value may be 0 to 255 only.");
				}
				num2 += (int)(A_0[j] - 48);
				num2 *= 10;
			}
			num2 /= 10;
			string text = Convert.ToString(num2, 2).PadLeft(8, '0');
			list.Add(text.Substring(0, 4));
			list.Add(text.Substring(4));
			return list;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00019278 File Offset: 0x00018278
		internal List<string> a(string A_0, int A_1, int A_2, byte[] A_3, bool A_4)
		{
			this.z = zz93.f.a;
			List<int> list = new List<int>();
			List<f> list2 = new List<f>();
			list.Add(29);
			list2.Add(this.z);
			list.Add(29);
			list2.Add(zz93.f.c);
			List<string> list3 = new List<string>();
			for (int i = 0; i < list.Count; i++)
			{
				if (list2[i] == zz93.f.e)
				{
					list3.Add(Convert.ToString(list[i], 2).PadLeft(4, '0'));
				}
				else
				{
					list3.Add(Convert.ToString(list[i], 2).PadLeft(5, '0'));
				}
			}
			list3.AddRange(this.a(A_0, false, 0));
			list3.AddRange(this.a(((char)(A_1 + 64)).ToString() + ((char)(A_2 + 64)).ToString(), A_4, 0));
			list3.AddRange(this.a(A_3, A_4, A_1));
			return list3;
		}

		// Token: 0x04000033 RID: 51
		private const int a = 0;

		// Token: 0x04000034 RID: 52
		private const int b = 31;

		// Token: 0x04000035 RID: 53
		private const int c = 28;

		// Token: 0x04000036 RID: 54
		private const int d = 28;

		// Token: 0x04000037 RID: 55
		private const int e = 29;

		// Token: 0x04000038 RID: 56
		private const int f = 30;

		// Token: 0x04000039 RID: 57
		private const int g = 29;

		// Token: 0x0400003A RID: 58
		private const int h = 30;

		// Token: 0x0400003B RID: 59
		private const int i = 31;

		// Token: 0x0400003C RID: 60
		private const int j = 14;

		// Token: 0x0400003D RID: 61
		private const string k = "~1";

		// Token: 0x0400003E RID: 62
		private const string l = "~2";

		// Token: 0x0400003F RID: 63
		private const byte m = 126;

		// Token: 0x04000040 RID: 64
		private const byte n = 49;

		// Token: 0x04000041 RID: 65
		private const byte o = 50;

		// Token: 0x04000042 RID: 66
		private static int[,] p = new int[,]
		{
			{
				0,
				5,
				5,
				10,
				5,
				10
			},
			{
				10,
				0,
				5,
				10,
				5,
				10
			},
			{
				5,
				5,
				0,
				5,
				10,
				10
			},
			{
				5,
				10,
				10,
				0,
				10,
				15
			},
			{
				4,
				9,
				9,
				14,
				0,
				14
			},
			{
				0,
				0,
				0,
				0,
				0,
				0
			}
		};

		// Token: 0x04000043 RID: 67
		private static int[,] q = new int[,]
		{
			{
				10000,
				10000,
				10000,
				5,
				10000
			},
			{
				5,
				10000,
				10000,
				5,
				10000
			},
			{
				10000,
				10000,
				10000,
				5,
				10000
			},
			{
				10000,
				10000,
				10000,
				10000,
				10000
			},
			{
				4,
				10000,
				10000,
				4,
				10000
			}
		};

		// Token: 0x04000044 RID: 68
		private static int[] r = new int[]
		{
			5,
			5,
			5,
			5,
			4,
			8
		};

		// Token: 0x04000045 RID: 69
		private static short[,] s = new short[,]
		{
			{
				32,
				1
			},
			{
				65,
				2
			},
			{
				66,
				3
			},
			{
				67,
				4
			},
			{
				68,
				5
			},
			{
				69,
				6
			},
			{
				70,
				7
			},
			{
				71,
				8
			},
			{
				72,
				9
			},
			{
				73,
				10
			},
			{
				74,
				11
			},
			{
				75,
				12
			},
			{
				76,
				13
			},
			{
				77,
				14
			},
			{
				78,
				15
			},
			{
				79,
				16
			},
			{
				80,
				17
			},
			{
				81,
				18
			},
			{
				82,
				19
			},
			{
				83,
				20
			},
			{
				84,
				21
			},
			{
				85,
				22
			},
			{
				86,
				23
			},
			{
				87,
				24
			},
			{
				88,
				25
			},
			{
				89,
				26
			},
			{
				90,
				27
			}
		};

		// Token: 0x04000046 RID: 70
		private static short[,] t = new short[,]
		{
			{
				32,
				1
			},
			{
				97,
				2
			},
			{
				98,
				3
			},
			{
				99,
				4
			},
			{
				100,
				5
			},
			{
				101,
				6
			},
			{
				102,
				7
			},
			{
				103,
				8
			},
			{
				104,
				9
			},
			{
				105,
				10
			},
			{
				106,
				11
			},
			{
				107,
				12
			},
			{
				108,
				13
			},
			{
				109,
				14
			},
			{
				110,
				15
			},
			{
				111,
				16
			},
			{
				112,
				17
			},
			{
				113,
				18
			},
			{
				114,
				19
			},
			{
				115,
				20
			},
			{
				116,
				21
			},
			{
				117,
				22
			},
			{
				118,
				23
			},
			{
				119,
				24
			},
			{
				120,
				25
			},
			{
				121,
				26
			},
			{
				122,
				27
			}
		};

		// Token: 0x04000047 RID: 71
		private static short[,] u = new short[,]
		{
			{
				32,
				1
			},
			{
				1,
				2
			},
			{
				2,
				3
			},
			{
				3,
				4
			},
			{
				4,
				5
			},
			{
				5,
				6
			},
			{
				6,
				7
			},
			{
				7,
				8
			},
			{
				8,
				9
			},
			{
				9,
				10
			},
			{
				10,
				11
			},
			{
				11,
				12
			},
			{
				12,
				13
			},
			{
				13,
				14
			},
			{
				27,
				15
			},
			{
				28,
				16
			},
			{
				29,
				17
			},
			{
				30,
				18
			},
			{
				31,
				19
			},
			{
				64,
				20
			},
			{
				92,
				21
			},
			{
				94,
				22
			},
			{
				95,
				23
			},
			{
				96,
				24
			},
			{
				124,
				25
			},
			{
				126,
				26
			},
			{
				127,
				27
			}
		};

		// Token: 0x04000048 RID: 72
		private static short[,] v = new short[,]
		{
			{
				13,
				1
			},
			{
				33,
				6
			},
			{
				34,
				7
			},
			{
				35,
				8
			},
			{
				36,
				9
			},
			{
				37,
				10
			},
			{
				38,
				11
			},
			{
				39,
				12
			},
			{
				40,
				13
			},
			{
				41,
				14
			},
			{
				42,
				15
			},
			{
				43,
				16
			},
			{
				44,
				17
			},
			{
				45,
				18
			},
			{
				46,
				19
			},
			{
				47,
				20
			},
			{
				58,
				21
			},
			{
				59,
				22
			},
			{
				60,
				23
			},
			{
				61,
				24
			},
			{
				62,
				25
			},
			{
				63,
				26
			},
			{
				91,
				27
			},
			{
				93,
				28
			},
			{
				123,
				29
			},
			{
				125,
				30
			}
		};

		// Token: 0x04000049 RID: 73
		private static short[,] w = new short[,]
		{
			{
				13,
				10,
				2
			},
			{
				46,
				32,
				3
			},
			{
				44,
				32,
				4
			},
			{
				58,
				32,
				5
			}
		};

		// Token: 0x0400004A RID: 74
		private static short[,] x = new short[,]
		{
			{
				32,
				1
			},
			{
				48,
				2
			},
			{
				49,
				3
			},
			{
				50,
				4
			},
			{
				51,
				5
			},
			{
				52,
				6
			},
			{
				53,
				7
			},
			{
				54,
				8
			},
			{
				55,
				9
			},
			{
				56,
				10
			},
			{
				57,
				11
			},
			{
				44,
				12
			},
			{
				46,
				13
			}
		};

		// Token: 0x0400004B RID: 75
		private bool y;

		// Token: 0x0400004C RID: 76
		private f z = zz93.f.a;
	}
}
