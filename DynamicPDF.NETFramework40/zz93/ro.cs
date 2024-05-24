using System;
using System.Collections;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002A0 RID: 672
	internal class ro
	{
		// Token: 0x06001DF4 RID: 7668 RVA: 0x0012DCE6 File Offset: 0x0012CCE6
		internal ro(x5 A_0, Report A_1, bool A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06001DF5 RID: 7669 RVA: 0x0012DD06 File Offset: 0x0012CD06
		internal ro(x5 A_0, xc A_1, bool A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06001DF6 RID: 7670 RVA: 0x0012DD28 File Offset: 0x0012CD28
		internal bool a(xe A_0, ref xe A_1)
		{
			xg xg = A_0.e();
			x5 x = this.a;
			xg xg2 = null;
			while (xg != null)
			{
				if (this.b.e() != null)
				{
					if (this.b.e().f())
					{
						this.a(ref xg, x, false, false);
					}
				}
				x5 x2 = x5.a();
				int num = 0;
				xg xg3 = xg;
				xg xg4 = xg2;
				while (num < this.b.a() && xg != null)
				{
					if (x5.d(x2, xg.d()))
					{
						x2 = xg.d();
					}
					num++;
					xg2 = xg;
					xg = xg.e();
					if (this.b.e() != null)
					{
						if (this.b.e().f() && xg != null)
						{
							this.a(ref xg, x, false, false);
						}
					}
				}
				if (x5.d(x, x2))
				{
					if (x5.d(x2, this.a))
					{
						xg = xg3;
					}
					if (xg4 != null)
					{
						xg4.a(null);
					}
					A_1 = new xe(xg, this.b);
					return false;
				}
				x = x5.e(x, x5.f(x2, this.b.c()));
			}
			return true;
		}

		// Token: 0x06001DF7 RID: 7671 RVA: 0x0012DEB0 File Offset: 0x0012CEB0
		internal bool a(xe A_0, ref xe A_1, bool A_2)
		{
			xg xg = A_0.e();
			xg xg2 = null;
			x5 x = this.a;
			x5 x2 = x5.c();
			int num = 0;
			int num2 = 0;
			rr[] array = new rr[this.b.a()];
			rp rp = new rp(this.a);
			bool flag = A_0.e().j() != null && A_0.e().j().a() > 0;
			while (xg != null)
			{
				if (this.b.e() != null)
				{
					if (this.b.e().f())
					{
						this.a(ref xg, x, false, false);
					}
				}
				if (x5.d(x, xg.d()))
				{
					if (flag)
					{
						x2 = xg.j().a(x, num2 == 0);
						if (x5.h(x2, x5.a()))
						{
							if (x5.c(xg.d(), this.a) && !xg.gh())
							{
								xg.j().d();
							}
						}
						else
						{
							x = x2;
							xg xg3 = new xz(x);
							xg xg4 = new xz(x5.e(xg.d(), x));
							if (xg.j() != null)
							{
								xg3.b(xg.j());
								xg4.b(xg.j());
							}
							rp.a(xg, xg3, xg4, false, x, A_2);
							xg xg5 = xg3;
							int a_;
							xg4.gd(a_ = xg.gc());
							xg5.gd(a_);
							if (xg2 != null && xg3.h() != null)
							{
								xg2.a(xg3);
								xg2 = xg3;
								num2++;
							}
							else if (xg2 == null && xg3.h() != null)
							{
								xg2 = xg3;
								A_0.b(xg3);
								num2++;
							}
							if (xg4.h() != null)
							{
								if (xg2 != null)
								{
									xg2.a(xg4);
								}
								xg4.a(xg.e());
								xg = xg4;
							}
							else
							{
								xg = xg.e();
								if (xg2 != null)
								{
									xg2.a(xg);
								}
							}
						}
					}
					if (num2 > 0)
					{
						array[num] = new rr(num2);
						num++;
						num2 = 0;
						x = this.a;
						if (num >= array.Length)
						{
							if (xg2 != null)
							{
								xg2.a(null);
							}
							A_0.a(array);
							A_1 = new xe(xg, this.b);
							if (flag)
							{
								if (x5.c(xg.d(), this.a) && !xg.gh())
								{
									xg.j().d();
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
							this.a(ref xg, x, false, false);
						}
					}
				}
				num2++;
				x = x5.e(x, x5.f(xg.d(), this.b.c()));
				xg2 = xg;
				xg = xg.e();
			}
			if (num < array.Length && array[num] == null && num2 > 0)
			{
				array[num] = new rr(num2);
			}
			A_0.a(array);
			return true;
		}

		// Token: 0x06001DF8 RID: 7672 RVA: 0x0012E27C File Offset: 0x0012D27C
		internal bool b(xe A_0, ref xe A_1, bool A_2)
		{
			xg xg = A_0.e();
			xg xg2 = null;
			x5 x = this.a;
			int num = 0;
			int num2 = 0;
			rr[] array = new rr[this.b.a()];
			bool flag = false;
			rp rp = new rp(this.a);
			while (xg != null)
			{
				if (this.b.e() != null)
				{
					if (this.b.e().f())
					{
						this.a(ref xg, x, false, false);
					}
				}
				if (x5.d(x, xg.d()))
				{
					w3 w = new w3();
					ArrayList arrayList = new ArrayList();
					xg xg3 = new xz(x);
					xg xg4 = new xz(x5.e(xg.d(), x));
					xg xg5 = xg3;
					int a_;
					xg4.gd(a_ = xg.gc());
					xg5.gd(a_);
					rp.a(w, x, xg);
					rp.a(w, x, flag, xg3, arrayList, A_2);
					if (w.a != null)
					{
						rp.a(w, x, arrayList, xg, xg3, xg4, flag, A_2);
						if (xg2 != null)
						{
							xg2.a(xg3);
						}
						else
						{
							A_0.b(xg3);
						}
						xg2 = xg3;
						num2++;
						if (xg4.h() != null)
						{
							xg4.a(xg.e());
							xg3.a(xg4);
							xg = xg4;
						}
						else
						{
							xg = xg.e();
							xg3.a(xg);
						}
						if (xg == null)
						{
							continue;
						}
					}
					if (num2 > 0)
					{
						array[num] = new rr(num2);
						num++;
						num2 = 0;
						x = this.a;
						if (num >= array.Length)
						{
							if (xg2 != null)
							{
								xg2.a(null);
							}
							A_0.a(array);
							A_1 = new xe(xg, this.b);
							return false;
						}
					}
					if (this.b.e() != null)
					{
						if (this.b.e().f())
						{
							this.a(ref xg, x, false, false);
						}
					}
				}
				if (x5.b(xg.d(), this.a))
				{
					num2++;
					x = x5.e(x, x5.f(xg.d(), this.b.c()));
					xg2 = xg;
					xg = xg.e();
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
				array[num] = new rr(num2);
			}
			A_0.a(array);
			return true;
		}

		// Token: 0x06001DF9 RID: 7673 RVA: 0x0012E568 File Offset: 0x0012D568
		internal bool a(xe A_0, ref xe A_1, bool A_2, bool A_3)
		{
			xg xg = A_0.e();
			xg xg2 = null;
			x5 x = this.a;
			int num = 0;
			int num2 = 0;
			rr[] array = new rr[this.b.a()];
			bool flag = false;
			rp rp = new rp(this.a);
			while (xg != null)
			{
				if (this.b.e() != null)
				{
					if (this.b.e().f())
					{
						this.a(ref xg, x, A_3, false);
					}
				}
				if (x5.d(x, xg.d()))
				{
					w3 w = new w3();
					ArrayList arrayList = new ArrayList();
					xg xg3 = new xz(x);
					xg xg4 = new xz(x5.e(xg.d(), x));
					rp.a(w, x, xg);
					rp.a(w, x, flag, xg3, arrayList, A_2);
					if (w.a != null)
					{
						rp.a(w, x, arrayList, xg, xg3, xg4, flag, A_2);
						xg xg5 = xg3;
						int a_;
						xg4.gd(a_ = xg.gc());
						xg5.gd(a_);
						if (xg2 != null)
						{
							xg2.a(xg3);
						}
						else
						{
							A_0.b(xg3);
						}
						xg2 = xg3;
						num2++;
						if (xg4.h() != null)
						{
							xg4.a(xg.e());
							xg3.a(xg4);
							xg = xg4;
						}
						else
						{
							xg = xg.e();
							xg3.a(xg);
						}
						if (xg == null)
						{
							continue;
						}
					}
					if (num2 > 0)
					{
						array[num] = new rr(num2);
						num++;
						num2 = 0;
						x = this.a;
						if (num >= array.Length)
						{
							if (xg2 != null)
							{
								xg2.a(null);
							}
							A_0.a(array);
							A_1 = new xe(xg, this.b);
							return false;
						}
					}
					if (this.b.e() != null)
					{
						if (this.b.e().f())
						{
							this.a(ref xg, x, A_3, false);
						}
					}
				}
				if (x5.b(xg.d(), this.a))
				{
					num2++;
					x = x5.e(x, x5.f(xg.d(), this.b.c()));
					xg2 = xg;
					xg = xg.e();
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
				array[num] = new rr(num2);
			}
			A_0.a(array);
			return true;
		}

		// Token: 0x06001DFA RID: 7674 RVA: 0x0012E858 File Offset: 0x0012D858
		internal bool a(xe A_0, ref xe A_1, ref x5 A_2)
		{
			xg xg = A_0.e();
			xg xg2 = null;
			x5 x = this.a;
			int num = 0;
			int num2 = 0;
			rr[] array = new rr[this.b.a()];
			while (xg != null)
			{
				if (this.b.e() != null)
				{
					if (this.b.e().f())
					{
						this.a(ref xg, x, false, false);
					}
				}
				if (x5.d(x, xg.d()))
				{
					if (num2 > 0)
					{
						array[num] = new rr(num2);
						num++;
						num2 = 0;
						x = this.a;
						if (num >= array.Length)
						{
							if (xg2 != null)
							{
								xg2.a(null);
							}
							A_0.a(array);
							A_1 = new xe(xg, this.b);
							return false;
						}
					}
				}
				num2++;
				x = x5.e(x, x5.f(xg.d(), this.b.c()));
				A_2 = x5.f(A_2, x5.f(xg.d(), this.b.c()));
				xg2 = xg;
				xg = xg.e();
			}
			if (num < array.Length && array[num] == null && num2 > 0)
			{
				array[num] = new rr(num2);
			}
			A_0.a(array);
			return true;
		}

		// Token: 0x06001DFB RID: 7675 RVA: 0x0012E9EC File Offset: 0x0012D9EC
		internal void a(xe A_0, x5 A_1)
		{
			x5 x = this.a;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			rr[] array = new rr[this.b.a()];
			xg xg = A_0.e();
			xg xg2 = null;
			xg xg3 = A_0.e();
			while (num < this.b.a() && xg != null)
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
					xg3 = xg;
					a_ = x5.c();
					A_1 = x5.c();
					xg2 = null;
					while (xg3 != null)
					{
						if (x5.d(x, xg3.d()))
						{
							if (num3 > 0)
							{
								array[num2] = new rr(num3);
								if (num2 == num)
								{
									xg2 = xg3;
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
						x = x5.e(x, x5.f(xg3.d(), this.b.c()));
						if (xg2 != null)
						{
							A_1 = x5.f(A_1, x5.f(xg3.d(), this.b.c()));
						}
						xg3 = xg3.e();
					}
					if (xg3 == null)
					{
						break;
					}
					if (x5.b(a_, x5.c()) && num + 1 == this.b.a() && xg3 != null)
					{
						a_ = x5.f(xg3.d(), this.b.c());
					}
				}
				xg = xg2;
				num++;
			}
			if (num2 < array.Length && num3 > 0)
			{
				array[num2] = new rr(num3);
			}
			A_0.a(array);
		}

		// Token: 0x06001DFC RID: 7676 RVA: 0x0012EC70 File Offset: 0x0012DC70
		internal void a(ref xe A_0, bool A_1)
		{
			x5 a_ = x5.c();
			x5 x = x5.c();
			x5 x2 = this.a;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			rr[] array = new rr[this.b.a()];
			xe[] array2 = new xe[this.b.a()];
			xg xg = A_0.e();
			xg xg2 = null;
			xg xg3 = null;
			xg xg4 = A_0.e();
			x5 a_2 = x5.b();
			bool flag = false;
			double num4 = 1.0;
			xe xe = A_0;
			rp rp = new rp(this.a);
			while (num < this.b.a() && xg != null)
			{
				x5 a_3 = x5.b();
				while (x5.c(a_3, x5.c()))
				{
					A_0 = xe.a(xg, xe, this.b);
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
					xg = A_0.e();
					num2 = num;
					num3 = 0;
					xg4 = xg;
					a_3 = x5.c();
					a_ = x5.c();
					xg2 = null;
					xg xg5 = null;
					while (xg4 != null)
					{
						if (this.b.e() != null)
						{
							if (this.b.e().f())
							{
								if (!this.a(ref xg4, x2, true, true))
								{
									xg = xe.e();
									num = 0;
									num3 = 0;
									xg2 = null;
									xg3 = null;
									a_3 = x5.b();
									num4 += 0.02500000037252903;
									a_ = this.a(xe, true);
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
						if (x5.d(x2, xg4.d()))
						{
							w3 w = new w3();
							ArrayList arrayList = new ArrayList();
							xg xg6 = new xz(x2);
							xg xg7 = new xz(x5.e(xg4.d(), x2));
							xg xg8 = xg6;
							int a_4;
							xg7.gd(a_4 = xg4.gc());
							xg8.gd(a_4);
							rp.a(w, x2, xg4);
							rp.a(w, x2, true, xg6, arrayList, A_1);
							if (w.a != null)
							{
								rp.a(w, x2, arrayList, xg4, xg6, xg7, true, A_1);
								if (xg5 != null)
								{
									xg5.a(xg6);
								}
								else
								{
									A_0.b(xg6);
								}
								xg5 = xg6;
								x2 = x5.e(x2, xg6.d());
								num3++;
								if (xg7.h() != null)
								{
									xg7.a(xg4.e());
									xg6.a(xg7);
									xg4 = xg7;
								}
								else
								{
									xg4 = xg4.e();
									xg6.a(xg4);
								}
								if (xg4 == null)
								{
									continue;
								}
							}
							if (num3 > 0)
							{
								array[num2] = new rr(num3);
								if (num2 == num)
								{
									xg3 = xg5;
									xg2 = xg4;
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
						x2 = x5.e(x2, x5.f(xg4.d(), this.b.c()));
						xg5 = xg4;
						xg4 = xg4.e();
					}
					if (xg4 == null)
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
					if ((x5.d(a_2, x) && (!this.b.e().f() || num4 < 1.2599999904632568)) || (num == this.b.a() - 1 && xg4 != null))
					{
						xg = xe.e();
						num = 0;
						num3 = 0;
						xg2 = null;
						xg3 = null;
						num4 += 0.02500000037252903;
						a_ = this.a(xe, true);
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
				xg = xg2;
				if (xg3 != null)
				{
					xg3.a(null);
				}
				array2[num] = xe.a(A_0.e(), this.b);
				num++;
			}
			if (num2 < array.Length && num3 > 0)
			{
				array[num2] = new rr(num3);
			}
			A_0.a(array);
			A_0.b(null);
			A_0.a(array2);
		}

		// Token: 0x06001DFD RID: 7677 RVA: 0x0012F258 File Offset: 0x0012E258
		internal static void a(ref xd[] A_0, ref int A_1, xg A_2, xc A_3)
		{
			A_1++;
			if (A_0.Length <= A_1)
			{
				xd[] array = new xd[A_0.Length * 2];
				Array.Copy(A_0, array, A_0.Length);
				A_0 = array;
			}
			A_0[A_1] = new xd(A_2, A_3);
		}

		// Token: 0x06001DFE RID: 7678 RVA: 0x0012F2A4 File Offset: 0x0012E2A4
		internal bool a(xd A_0, ref xd A_1, bool A_2)
		{
			xg xg = A_0.e();
			xg xg2 = null;
			x5 x = this.a;
			bool flag = false;
			int num = 0;
			if (x5.d(this.a, x5.c()))
			{
				x = (this.a = new x5(0.01f));
			}
			rp rp = new rp(x);
			while (xg != null)
			{
				if (this.b.e() != null)
				{
					if (this.b.e().f())
					{
						this.a(ref xg, x, false, false);
					}
				}
				if (x5.d(x, xg.d()))
				{
					xg xg3 = new xz(x);
					xg xg4 = new xz(x5.e(xg.d(), x));
					if (xg.i() != null)
					{
						xg3.a(xg.i());
						xg4.a(xg.i());
					}
					rp.a(xg, xg3, xg4, flag, x, A_2);
					xg xg5 = xg3;
					int a_;
					xg4.gd(a_ = xg.gc());
					xg5.gd(a_);
					if (xg2 == null)
					{
						if (xg3.h() != null)
						{
							A_0.b(xg3);
							xg2 = xg3;
							num = 0;
						}
						else
						{
							A_0.b(null);
							xg2 = xg3;
						}
					}
					else if (xg3.h() != null)
					{
						xg2.a(xg3);
						num = 0;
					}
					else
					{
						xg2.a(null);
					}
					if (xg4.h() != null)
					{
						flag = x5.c(xg4.d(), this.a);
						xg4.a(xg.e());
						xg = xg4;
					}
					else
					{
						xg = xg.e();
						num = 0;
					}
					x = this.a;
					if (xg == null)
					{
						continue;
					}
					A_1 = ro.a(this.c, xg, A_0, this.b);
					if (flag && A_1 == null && num < 2)
					{
						if (xg3.h() != null && rp.a() != xg3)
						{
							rp.a(null);
						}
						xg2 = null;
						num++;
						continue;
					}
					num = 0;
					if (A_1 != null)
					{
						return false;
					}
				}
				rp.a(null);
				xg2 = xg;
				x = x5.e(x, x5.f(xg.d(), this.b.c()));
				xg = xg.e();
			}
			return true;
		}

		// Token: 0x06001DFF RID: 7679 RVA: 0x0012F55C File Offset: 0x0012E55C
		private bool a(ref xg A_0, x5 A_1, bool A_2, bool A_3)
		{
			xx xx = A_0.h();
			((xh)A_0).b();
			bool flag = false;
			bool flag2 = false;
			x5 a_ = A_3 ? A_1 : this.a;
			while (xx != null)
			{
				if (xx.a().cb() == 239 && ((xs)xx.a()).b(A_3))
				{
					if (!this.b.d() || this.b.f() == rk.a)
					{
						flag = ((xs)xx.a()).f(x5.e(xx.a().b8(), xx.a().b7()), a_, A_2);
					}
					else
					{
						flag = ((xs)xx.a()).f(x5.e(A_1, xx.a().b7()), a_, A_2);
					}
					flag2 = true;
					((xh)A_0).a().a((xs)xx.a());
				}
				xx = xx.b();
			}
			if (flag)
			{
				((xh)A_0).c();
			}
			return !flag2 || flag;
		}

		// Token: 0x06001E00 RID: 7680 RVA: 0x0012F6B8 File Offset: 0x0012E6B8
		internal bool b(xd A_0, ref xd A_1, bool A_2)
		{
			xg xg = A_0.e();
			xg xg2 = null;
			x5 x = this.a;
			bool flag = false;
			rp rp = new rp(x);
			if (A_0.e() != null)
			{
				if (A_0.e().j() != null && A_0.e().j().a() > 0)
				{
					flag = true;
				}
			}
			while (xg != null)
			{
				if (this.b.e() != null)
				{
					if (this.b.e().f())
					{
						this.a(ref xg, x, false, false);
					}
				}
				if (x5.d(x, xg.d()))
				{
					if (flag)
					{
						x = xg.j().a(x, xg2 == null);
						if (x5.h(x, x5.a()))
						{
							if (xg2 == null)
							{
								A_0.b(null);
							}
							else
							{
								xg2.a(null);
							}
							A_1 = ro.a(this.c, xg, A_0, this.b);
							if (x5.c(xg.d(), this.a) && A_1 != null)
							{
								xg.j().d();
							}
						}
						else
						{
							xg xg3 = new xz(x);
							xg xg4 = new xz(x5.e(xg.d(), x));
							if (xg.j() != null)
							{
								xg3.b(xg.j());
								xg4.b(xg.j());
							}
							rp.a(xg, xg3, xg4, false, x, A_2);
							xg xg5 = xg3;
							int a_;
							xg4.gd(a_ = xg.gc());
							xg5.gd(a_);
							if (xg2 == null)
							{
								if (xg3.h() != null)
								{
									A_0.b(xg3);
								}
								else
								{
									A_0.b(null);
								}
							}
							else if (xg3.h() != null)
							{
								xg2.a(xg3);
							}
							else
							{
								xg2.a(null);
							}
							if (xg4.h() != null)
							{
								xg4.a(xg.e());
								xg = xg4;
							}
							else
							{
								xg = xg.e();
							}
							if (xg == null)
							{
								break;
							}
							A_1 = ro.a(this.c, xg, A_0, this.b);
						}
					}
					else
					{
						if (xg2 == null)
						{
							A_0.b(null);
						}
						else
						{
							xg2.a(null);
						}
						A_1 = ro.a(this.c, xg, A_0, this.b);
					}
					if (A_1 == null)
					{
						xg2 = xg;
						xg = xg.e();
						if (xg != null && x5.c(xg.d(), this.a))
						{
							xg2.a(null);
							A_1 = ro.a(this.c, xg, A_0, this.b);
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
				xg2 = xg;
				x = x5.e(x, x5.f(xg.d(), this.b.c()));
				xg = xg.e();
			}
			return true;
		}

		// Token: 0x06001E01 RID: 7681 RVA: 0x0012FA38 File Offset: 0x0012EA38
		private static xd a(bool A_0, xg A_1, xd A_2, xc A_3)
		{
			xd result;
			if (A_2.e() == null && !A_0)
			{
				A_2.b(A_1);
				result = null;
			}
			else
			{
				result = new xd(A_1, A_3);
			}
			return result;
		}

		// Token: 0x06001E02 RID: 7682 RVA: 0x0012FA70 File Offset: 0x0012EA70
		private x5 a(xe A_0, bool A_1)
		{
			x5 x = x5.c();
			for (xg xg = A_0.e(); xg != null; xg = xg.e())
			{
				if (this.b.e() != null)
				{
					if (A_1 && this.b.e().f())
					{
						this.a(ref xg, this.a, false, false);
					}
				}
				x = x5.f(x, x5.f(xg.d(), this.b.c()));
			}
			return x;
		}

		// Token: 0x04000D46 RID: 3398
		private x5 a;

		// Token: 0x04000D47 RID: 3399
		private xc b;

		// Token: 0x04000D48 RID: 3400
		private bool c;
	}
}
