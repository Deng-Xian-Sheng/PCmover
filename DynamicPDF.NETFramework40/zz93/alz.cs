using System;
using System.Collections;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005A4 RID: 1444
	internal class alz
	{
		// Token: 0x0600394D RID: 14669 RVA: 0x001EAF29 File Offset: 0x001E9F29
		internal alz(x5 A_0, Report A_1, bool A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x0600394E RID: 14670 RVA: 0x001EAF49 File Offset: 0x001E9F49
		internal alz(x5 A_0, alp A_1, bool A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x0600394F RID: 14671 RVA: 0x001EAF6C File Offset: 0x001E9F6C
		internal bool a(amh A_0, ref amh A_1)
		{
			amk amk = A_0.e();
			x5 x = this.a;
			amk amk2 = null;
			while (amk != null)
			{
				if (this.b.e() != null)
				{
					if (this.b.e().f())
					{
						this.a(ref amk, x, false, false);
					}
				}
				x5 x2 = x5.a();
				int num = 0;
				amk amk3 = amk;
				amk amk4 = amk2;
				while (num < this.b.a() && amk != null)
				{
					if (x5.d(x2, amk.d()))
					{
						x2 = amk.d();
					}
					num++;
					amk2 = amk;
					amk = amk.e();
					if (this.b.e() != null)
					{
						if (this.b.e().f() && amk != null)
						{
							this.a(ref amk, x, false, false);
						}
					}
				}
				if (x5.d(x, x2))
				{
					if (x5.d(x2, this.a))
					{
						amk = amk3;
					}
					if (amk4 != null)
					{
						amk4.a(null);
					}
					A_1 = new amh(amk, this.b);
					return false;
				}
				x = x5.e(x, x5.f(x2, this.b.c()));
			}
			return true;
		}

		// Token: 0x06003950 RID: 14672 RVA: 0x001EB0F4 File Offset: 0x001EA0F4
		internal bool a(amh A_0, ref amh A_1, bool A_2)
		{
			amk amk = A_0.e();
			amk amk2 = null;
			x5 x = this.a;
			x5 x2 = x5.c();
			int num = 0;
			int num2 = 0;
			ami[] array = new ami[this.b.a()];
			al0 al = new al0(this.a);
			bool flag = A_0.e().j() != null && A_0.e().j().a() > 0;
			while (amk != null)
			{
				if (this.b.e() != null)
				{
					if (this.b.e().f())
					{
						this.a(ref amk, x, false, false);
					}
				}
				if (x5.d(x, amk.d()))
				{
					if (flag)
					{
						x2 = amk.j().a(x, num2 == 0);
						if (x5.h(x2, x5.a()))
						{
							if (x5.c(amk.d(), this.a) && !amk.ns())
							{
								amk.j().d();
							}
						}
						else
						{
							x = x2;
							amk amk3 = new ana(x);
							amk amk4 = new ana(x5.e(amk.d(), x));
							if (amk.j() != null)
							{
								amk3.b(amk.j());
								amk4.b(amk.j());
							}
							al.a(amk, amk3, amk4, false, x, A_2);
							amk amk5 = amk3;
							int a_;
							amk4.no(a_ = amk.nn());
							amk5.no(a_);
							if (amk2 != null && amk3.h() != null)
							{
								amk2.a(amk3);
								amk2 = amk3;
								num2++;
							}
							else if (amk2 == null && amk3.h() != null)
							{
								amk2 = amk3;
								A_0.b(amk3);
								num2++;
							}
							if (amk4.h() != null)
							{
								if (amk2 != null)
								{
									amk2.a(amk4);
								}
								amk4.a(amk.e());
								amk = amk4;
							}
							else
							{
								amk = amk.e();
								if (amk2 != null)
								{
									amk2.a(amk);
								}
							}
						}
					}
					if (num2 > 0)
					{
						array[num] = new ami(num2);
						num++;
						num2 = 0;
						x = this.a;
						if (num >= array.Length)
						{
							if (amk2 != null)
							{
								amk2.a(null);
							}
							A_0.a(array);
							A_1 = new amh(amk, this.b);
							if (flag)
							{
								if (x5.c(amk.d(), this.a) && !amk.ns())
								{
									amk.j().d();
								}
							}
							return false;
						}
						continue;
					}
					else if (this.b.e() != null)
					{
						if (this.b.e().f())
						{
							this.a(ref amk, x, false, false);
						}
					}
				}
				num2++;
				x = x5.e(x, x5.f(amk.d(), this.b.c()));
				amk2 = amk;
				amk = amk.e();
			}
			if (num < array.Length && array[num] == null && num2 > 0)
			{
				array[num] = new ami(num2);
			}
			A_0.a(array);
			return true;
		}

		// Token: 0x06003951 RID: 14673 RVA: 0x001EB4C0 File Offset: 0x001EA4C0
		internal bool b(amh A_0, ref amh A_1, bool A_2)
		{
			amk amk = A_0.e();
			amk amk2 = null;
			x5 x = this.a;
			int num = 0;
			int num2 = 0;
			ami[] array = new ami[this.b.a()];
			bool flag = false;
			al0 al = new al0(this.a);
			while (amk != null)
			{
				if (this.b.e() != null)
				{
					if (this.b.e().f())
					{
						this.a(ref amk, x, false, false);
					}
				}
				if (x5.d(x, amk.d()))
				{
					alx alx = new alx();
					ArrayList arrayList = new ArrayList();
					amk amk3 = new ana(x);
					amk amk4 = new ana(x5.e(amk.d(), x));
					amk amk5 = amk3;
					int a_;
					amk4.no(a_ = amk.nn());
					amk5.no(a_);
					al0.a(alx, x, amk);
					al.a(alx, x, flag, amk3, arrayList, A_2);
					if (alx.a != null)
					{
						al0.a(alx, x, arrayList, amk, amk3, amk4, flag, A_2);
						if (amk2 != null)
						{
							amk2.a(amk3);
						}
						else
						{
							A_0.b(amk3);
						}
						amk2 = amk3;
						num2++;
						if (amk4.h() != null)
						{
							amk4.a(amk.e());
							amk3.a(amk4);
							amk = amk4;
						}
						else
						{
							amk = amk.e();
							amk3.a(amk);
						}
						if (amk == null)
						{
							continue;
						}
					}
					if (num2 > 0)
					{
						array[num] = new ami(num2);
						num++;
						num2 = 0;
						x = this.a;
						if (num >= array.Length)
						{
							if (amk2 != null)
							{
								amk2.a(null);
							}
							A_0.a(array);
							A_1 = new amh(amk, this.b);
							return false;
						}
					}
					if (this.b.e() != null)
					{
						if (this.b.e().f())
						{
							this.a(ref amk, x, false, false);
						}
					}
				}
				if (x5.b(amk.d(), this.a))
				{
					num2++;
					x = x5.e(x, x5.f(amk.d(), this.b.c()));
					amk2 = amk;
					amk = amk.e();
					flag = false;
				}
				else
				{
					x = this.a;
					flag = true;
				}
			}
			if (num < array.Length && array[num] == null && num2 > 0)
			{
				array[num] = new ami(num2);
			}
			A_0.a(array);
			return true;
		}

		// Token: 0x06003952 RID: 14674 RVA: 0x001EB7AC File Offset: 0x001EA7AC
		internal bool a(amh A_0, ref amh A_1, bool A_2, bool A_3)
		{
			amk amk = A_0.e();
			amk amk2 = null;
			x5 x = this.a;
			int num = 0;
			int num2 = 0;
			ami[] array = new ami[this.b.a()];
			bool flag = false;
			al0 al = new al0(this.a);
			while (amk != null)
			{
				if (this.b.e() != null)
				{
					if (this.b.e().f())
					{
						this.a(ref amk, x, A_3, false);
					}
				}
				if (x5.d(x, amk.d()))
				{
					alx alx = new alx();
					ArrayList arrayList = new ArrayList();
					amk amk3 = new ana(x);
					amk amk4 = new ana(x5.e(amk.d(), x));
					al0.a(alx, x, amk);
					al.a(alx, x, flag, amk3, arrayList, A_2);
					if (alx.a != null)
					{
						al0.a(alx, x, arrayList, amk, amk3, amk4, flag, A_2);
						amk amk5 = amk3;
						int a_;
						amk4.no(a_ = amk.nn());
						amk5.no(a_);
						if (amk2 != null)
						{
							amk2.a(amk3);
						}
						else
						{
							A_0.b(amk3);
						}
						amk2 = amk3;
						num2++;
						if (amk4.h() != null)
						{
							amk4.a(amk.e());
							amk3.a(amk4);
							amk = amk4;
						}
						else
						{
							amk = amk.e();
							amk3.a(amk);
						}
						if (amk == null)
						{
							continue;
						}
					}
					if (num2 > 0)
					{
						array[num] = new ami(num2);
						num++;
						num2 = 0;
						x = this.a;
						if (num >= array.Length)
						{
							if (amk2 != null)
							{
								amk2.a(null);
							}
							A_0.a(array);
							A_1 = new amh(amk, this.b);
							return false;
						}
					}
					if (this.b.e() != null)
					{
						if (this.b.e().f())
						{
							this.a(ref amk, x, A_3, false);
						}
					}
				}
				if (x5.b(amk.d(), this.a))
				{
					num2++;
					x = x5.e(x, x5.f(amk.d(), this.b.c()));
					amk2 = amk;
					amk = amk.e();
					flag = false;
				}
				else
				{
					x = this.a;
					flag = true;
				}
			}
			if (num < array.Length && array[num] == null && num2 > 0)
			{
				array[num] = new ami(num2);
			}
			A_0.a(array);
			return true;
		}

		// Token: 0x06003953 RID: 14675 RVA: 0x001EBA9C File Offset: 0x001EAA9C
		internal bool a(amh A_0, ref amh A_1, ref x5 A_2)
		{
			amk amk = A_0.e();
			amk amk2 = null;
			x5 x = this.a;
			int num = 0;
			int num2 = 0;
			ami[] array = new ami[this.b.a()];
			while (amk != null)
			{
				if (this.b.e() != null)
				{
					if (this.b.e().f())
					{
						this.a(ref amk, x, false, false);
					}
				}
				if (x5.d(x, amk.d()))
				{
					if (num2 > 0)
					{
						array[num] = new ami(num2);
						num++;
						num2 = 0;
						x = this.a;
						if (num >= array.Length)
						{
							if (amk2 != null)
							{
								amk2.a(null);
							}
							A_0.a(array);
							A_1 = new amh(amk, this.b);
							return false;
						}
					}
				}
				num2++;
				x = x5.e(x, x5.f(amk.d(), this.b.c()));
				A_2 = x5.f(A_2, x5.f(amk.d(), this.b.c()));
				amk2 = amk;
				amk = amk.e();
			}
			if (num < array.Length && array[num] == null && num2 > 0)
			{
				array[num] = new ami(num2);
			}
			A_0.a(array);
			return true;
		}

		// Token: 0x06003954 RID: 14676 RVA: 0x001EBC30 File Offset: 0x001EAC30
		internal void a(amh A_0, x5 A_1)
		{
			x5 x = this.a;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			ami[] array = new ami[this.b.a()];
			amk amk = A_0.e();
			amk amk2 = null;
			amk amk3 = A_0.e();
			while (num < this.b.a() && amk != null)
			{
				x5 x2 = x5.a(A_1, this.b.a() - num);
				x = x2;
				x5 a_ = x5.b();
				while (x5.c(a_, x5.c()))
				{
					if (x5.g(a_, x5.b()))
					{
						x2 = x5.f(x2, x5.a(a_, this.b.a() - num));
						if (x5.c(x2, this.a))
						{
							break;
						}
						x = x2;
					}
					num2 = num;
					num3 = 0;
					amk3 = amk;
					a_ = x5.c();
					A_1 = x5.c();
					amk2 = null;
					while (amk3 != null)
					{
						if (x5.d(x, amk3.d()))
						{
							if (num3 > 0)
							{
								array[num2] = new ami(num3);
								if (num2 == num)
								{
									amk2 = amk3;
								}
								num2++;
								num3 = 0;
								if (x5.c(x, x5.c()))
								{
									a_ = x5.f(a_, x);
								}
								x = x2;
								if (num2 >= array.Length)
								{
									break;
								}
							}
						}
						num3++;
						x = x5.e(x, x5.f(amk3.d(), this.b.c()));
						if (amk2 != null)
						{
							A_1 = x5.f(A_1, x5.f(amk3.d(), this.b.c()));
						}
						amk3 = amk3.e();
					}
					if (amk3 == null)
					{
						break;
					}
					if (x5.b(a_, x5.c()) && num + 1 == this.b.a() && amk3 != null)
					{
						a_ = x5.f(amk3.d(), this.b.c());
					}
				}
				amk = amk2;
				num++;
			}
			if (num2 < array.Length && num3 > 0)
			{
				array[num2] = new ami(num3);
			}
			A_0.a(array);
		}

		// Token: 0x06003955 RID: 14677 RVA: 0x001EBEB4 File Offset: 0x001EAEB4
		internal void a(ref amh A_0, bool A_1)
		{
			x5 a_ = x5.c();
			x5 x = x5.c();
			x5 x2 = this.a;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			ami[] array = new ami[this.b.a()];
			amh[] array2 = new amh[this.b.a()];
			amk amk = A_0.e();
			amk amk2 = null;
			amk amk3 = null;
			amk amk4 = A_0.e();
			x5 a_2 = x5.b();
			bool flag = false;
			double num4 = 1.0;
			amh amh = A_0;
			al0 al = new al0(this.a);
			while (num < this.b.a() && amk != null)
			{
				x5 a_3 = x5.b();
				while (x5.c(a_3, x5.c()))
				{
					A_0 = amh.a(amk, amh, this.b);
					if (x5.g(a_3, x5.b()))
					{
						x = x5.f(x, x5.a(a_3, this.b.a() - num));
						if (x5.c(x, this.a))
						{
							break;
						}
						x2 = x;
					}
					else if (!flag)
					{
						a_ = this.a(A_0, true);
						x = x5.a(x5.a(a_) / (double)(this.b.a() - num) * num4);
						x2 = x;
					}
					flag = false;
					amk = A_0.e();
					num2 = num;
					num3 = 0;
					amk4 = amk;
					a_3 = x5.c();
					a_ = x5.c();
					amk2 = null;
					amk amk5 = null;
					while (amk4 != null)
					{
						if (this.b.e() != null)
						{
							if (this.b.e().f())
							{
								if (!this.a(ref amk4, x2, true, true))
								{
									amk = amh.e();
									num = 0;
									num3 = 0;
									amk2 = null;
									amk3 = null;
									a_3 = x5.b();
									num4 += 0.02500000037252903;
									a_ = this.a(amh, true);
									x = x5.a(x5.a(a_) / (double)(this.b.a() - num) * num4);
									x2 = x;
									flag = true;
									if (x5.c(x, this.a))
									{
										x = this.a;
									}
									a_2 = x;
									break;
								}
							}
						}
						if (x5.d(x2, amk4.d()))
						{
							alx alx = new alx();
							ArrayList arrayList = new ArrayList();
							amk amk6 = new ana(x2);
							amk amk7 = new ana(x5.e(amk4.d(), x2));
							amk amk8 = amk6;
							int a_4;
							amk7.no(a_4 = amk4.nn());
							amk8.no(a_4);
							al0.a(alx, x2, amk4);
							al.a(alx, x2, true, amk6, arrayList, A_1);
							if (alx.a != null)
							{
								al0.a(alx, x2, arrayList, amk4, amk6, amk7, true, A_1);
								if (amk5 != null)
								{
									amk5.a(amk6);
								}
								else
								{
									A_0.b(amk6);
								}
								amk5 = amk6;
								x2 = x5.e(x2, amk6.d());
								num3++;
								if (amk7.h() != null)
								{
									amk7.a(amk4.e());
									amk6.a(amk7);
									amk4 = amk7;
								}
								else
								{
									amk4 = amk4.e();
									amk6.a(amk4);
								}
								if (amk4 == null)
								{
									continue;
								}
							}
							if (num3 > 0)
							{
								array[num2] = new ami(num3);
								if (num2 == num)
								{
									amk3 = amk5;
									amk2 = amk4;
								}
								num2++;
								num3 = 0;
								if (x5.c(x2, x5.c()))
								{
									a_3 = x5.f(a_3, x2);
								}
								x2 = this.a;
								if (num2 >= array.Length)
								{
									break;
								}
							}
						}
						num3++;
						x2 = x5.e(x2, x5.f(amk4.d(), this.b.c()));
						amk5 = amk4;
						amk4 = amk4.e();
					}
					if (amk4 == null)
					{
						break;
					}
				}
				if (x5.c(x, this.a))
				{
					A_0 = null;
					return;
				}
				if (this.b.e() != null)
				{
					if ((x5.d(a_2, x) && (!this.b.e().f() || num4 < 1.2599999904632568)) || (num == this.b.a() - 1 && amk4 != null))
					{
						amk = amh.e();
						num = 0;
						num3 = 0;
						amk2 = null;
						amk3 = null;
						num4 += 0.02500000037252903;
						a_ = this.a(amh, true);
						x = x5.a(x5.a(a_) / (double)(this.b.a() - num) * num4);
						x2 = x;
						flag = true;
						if (x5.c(x, this.a))
						{
							x = this.a;
						}
						a_2 = x;
						continue;
					}
				}
				a_2 = x;
				amk = amk2;
				if (amk3 != null)
				{
					amk3.a(null);
				}
				array2[num] = amh.a(A_0.e(), this.b);
				num++;
			}
			if (num2 < array.Length && num3 > 0)
			{
				array[num2] = new ami(num3);
			}
			A_0.a(array);
			A_0.b(null);
			A_0.a(array2);
		}

		// Token: 0x06003956 RID: 14678 RVA: 0x001EC49C File Offset: 0x001EB49C
		internal static void a(ref amg[] A_0, ref int A_1, amk A_2, alp A_3)
		{
			A_1++;
			if (A_0.Length <= A_1)
			{
				amg[] array = new amg[A_0.Length * 2];
				Array.Copy(A_0, array, A_0.Length);
				A_0 = array;
			}
			A_0[A_1] = new amg(A_2, A_3);
		}

		// Token: 0x06003957 RID: 14679 RVA: 0x001EC4E8 File Offset: 0x001EB4E8
		internal bool a(amg A_0, ref amg A_1, bool A_2)
		{
			amk amk = A_0.e();
			amk amk2 = null;
			x5 x = this.a;
			bool flag = false;
			int num = 0;
			if (x5.d(this.a, x5.c()))
			{
				x = (this.a = new x5(0.01f));
			}
			al0 al = new al0(x);
			while (amk != null)
			{
				if (this.b.e() != null)
				{
					if (this.b.e().f())
					{
						this.a(ref amk, x, false, false);
					}
				}
				if (x5.d(x, amk.d()))
				{
					amk amk3 = new ana(x);
					amk amk4 = new ana(x5.e(amk.d(), x));
					if (amk.i() != null)
					{
						amk3.a(amk.i());
						amk4.a(amk.i());
					}
					al.a(amk, amk3, amk4, flag, x, A_2);
					amk amk5 = amk3;
					int a_;
					amk4.no(a_ = amk.nn());
					amk5.no(a_);
					if (amk2 == null)
					{
						if (amk3.h() != null)
						{
							A_0.b(amk3);
							amk2 = amk3;
							num = 0;
						}
						else
						{
							A_0.b(null);
							amk2 = amk3;
						}
					}
					else if (amk3.h() != null)
					{
						amk2.a(amk3);
						num = 0;
					}
					else
					{
						amk2.a(null);
					}
					if (amk4.h() != null)
					{
						flag = x5.c(amk4.d(), this.a);
						amk4.a(amk.e());
						amk = amk4;
					}
					else
					{
						amk = amk.e();
						num = 0;
					}
					x = this.a;
					if (amk == null)
					{
						continue;
					}
					A_1 = alz.a(this.c, amk, A_0, this.b);
					if (flag && A_1 == null && num < 2)
					{
						if (amk3.h() != null && al.a() != amk3)
						{
							al.a(null);
						}
						amk2 = null;
						num++;
						continue;
					}
					num = 0;
					if (A_1 != null)
					{
						return false;
					}
				}
				al.a(null);
				amk2 = amk;
				x = x5.e(x, x5.f(amk.d(), this.b.c()));
				amk = amk.e();
			}
			return true;
		}

		// Token: 0x06003958 RID: 14680 RVA: 0x001EC7A0 File Offset: 0x001EB7A0
		private bool a(ref amk A_0, x5 A_1, bool A_2, bool A_3)
		{
			am6 am = A_0.h();
			((aml)A_0).b();
			bool flag = false;
			bool flag2 = false;
			x5 a_ = A_3 ? A_1 : this.a;
			while (am != null)
			{
				if (am.a().cb() == 239 && ((am1)am.a()).b(A_3))
				{
					if (!this.b.d() || this.b.f() == akq.a)
					{
						flag = ((am1)am.a()).f(x5.e(am.a().b8(), am.a().b7()), a_, A_2);
					}
					else
					{
						flag = ((am1)am.a()).f(x5.e(A_1, am.a().b7()), a_, A_2);
					}
					flag2 = true;
					((aml)A_0).a().a((am1)am.a());
				}
				am = am.b();
			}
			if (flag)
			{
				((aml)A_0).c();
			}
			return !flag2 || flag;
		}

		// Token: 0x06003959 RID: 14681 RVA: 0x001EC8FC File Offset: 0x001EB8FC
		internal bool b(amg A_0, ref amg A_1, bool A_2)
		{
			amk amk = A_0.e();
			amk amk2 = null;
			x5 x = this.a;
			bool flag = false;
			al0 al = new al0(x);
			if (A_0.e() != null)
			{
				if (A_0.e().j() != null && A_0.e().j().a() > 0)
				{
					flag = true;
				}
			}
			while (amk != null)
			{
				if (this.b.e() != null)
				{
					if (this.b.e().f())
					{
						this.a(ref amk, x, false, false);
					}
				}
				if (x5.d(x, amk.d()))
				{
					if (flag)
					{
						x = amk.j().a(x, amk2 == null);
						if (x5.h(x, x5.a()))
						{
							if (amk2 == null)
							{
								A_0.b(null);
							}
							else
							{
								amk2.a(null);
							}
							A_1 = alz.a(this.c, amk, A_0, this.b);
							if (x5.c(amk.d(), this.a) && A_1 != null)
							{
								amk.j().d();
							}
						}
						else
						{
							amk amk3 = new ana(x);
							amk amk4 = new ana(x5.e(amk.d(), x));
							if (amk.j() != null)
							{
								amk3.b(amk.j());
								amk4.b(amk.j());
							}
							al.a(amk, amk3, amk4, false, x, A_2);
							amk amk5 = amk3;
							int a_;
							amk4.no(a_ = amk.nn());
							amk5.no(a_);
							if (amk2 == null)
							{
								if (amk3.h() != null)
								{
									A_0.b(amk3);
								}
								else
								{
									A_0.b(null);
								}
							}
							else if (amk3.h() != null)
							{
								amk2.a(amk3);
							}
							else
							{
								amk2.a(null);
							}
							if (amk4.h() != null)
							{
								amk4.a(amk.e());
								amk = amk4;
							}
							else
							{
								amk = amk.e();
							}
							if (amk == null)
							{
								break;
							}
							A_1 = alz.a(this.c, amk, A_0, this.b);
						}
					}
					else
					{
						if (amk2 == null)
						{
							A_0.b(null);
						}
						else
						{
							amk2.a(null);
						}
						A_1 = alz.a(this.c, amk, A_0, this.b);
					}
					if (A_1 == null)
					{
						amk2 = amk;
						amk = amk.e();
						if (amk != null && x5.c(amk.d(), this.a))
						{
							amk2.a(null);
							A_1 = alz.a(this.c, amk, A_0, this.b);
							if (A_1 != null)
							{
								return false;
							}
						}
						x = this.a;
						continue;
					}
					return false;
				}
				amk2 = amk;
				x = x5.e(x, x5.f(amk.d(), this.b.c()));
				amk = amk.e();
			}
			return true;
		}

		// Token: 0x0600395A RID: 14682 RVA: 0x001ECC7C File Offset: 0x001EBC7C
		private static amg a(bool A_0, amk A_1, amg A_2, alp A_3)
		{
			amg result;
			if (A_2.e() == null && !A_0)
			{
				A_2.b(A_1);
				result = null;
			}
			else
			{
				result = new amg(A_1, A_3);
			}
			return result;
		}

		// Token: 0x0600395B RID: 14683 RVA: 0x001ECCB4 File Offset: 0x001EBCB4
		private x5 a(amh A_0, bool A_1)
		{
			x5 x = x5.c();
			for (amk amk = A_0.e(); amk != null; amk = amk.e())
			{
				if (this.b.e() != null)
				{
					if (A_1 && this.b.e().f())
					{
						this.a(ref amk, this.a, false, false);
					}
				}
				x = x5.f(x, x5.f(amk.d(), this.b.c()));
			}
			return x;
		}

		// Token: 0x04001B4F RID: 6991
		private x5 a;

		// Token: 0x04001B50 RID: 6992
		private alp b;

		// Token: 0x04001B51 RID: 6993
		private bool c;
	}
}
