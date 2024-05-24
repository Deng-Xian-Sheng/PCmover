using System;

namespace zz93
{
	// Token: 0x020000E1 RID: 225
	internal abstract class fd
	{
		// Token: 0x060009ED RID: 2541 RVA: 0x000804F4 File Offset: 0x0007F4F4
		internal static fd a(int A_0, gi A_1)
		{
			fd result = null;
			if (A_0 <= 445130693)
			{
				if (A_0 <= 189525969)
				{
					if (A_0 <= 8714757)
					{
						if (A_0 <= 6947816)
						{
							if (A_0 == 136794)
							{
								return new i0(A_1);
							}
							if (A_0 == 6947816)
							{
								return new hq(A_1);
							}
						}
						else
						{
							if (A_0 == 6968946)
							{
								return new hd(A_1);
							}
							if (A_0 == 7021096)
							{
								return new hm(A_1);
							}
							if (A_0 == 8714757)
							{
								return new fm(A_1);
							}
						}
					}
					else if (A_0 <= 67814465)
					{
						if (A_0 == 31536467)
						{
							return new hz(A_1);
						}
						if (A_0 == 40160150)
						{
							return new i8(A_1);
						}
						if (A_0 == 67814465)
						{
							return new gy(A_1);
						}
					}
					else
					{
						if (A_0 == 136941815)
						{
							return new hf(A_1);
						}
						if (A_0 == 148235845)
						{
							return new fg(A_1);
						}
						if (A_0 == 189525969)
						{
							return new hn(A_1);
						}
					}
				}
				else if (A_0 <= 275611842)
				{
					if (A_0 <= 254664735)
					{
						if (A_0 == 200780672)
						{
							return new fi(A_1);
						}
						if (A_0 == 202920309)
						{
							return new i5(A_1);
						}
						if (A_0 == 254664735)
						{
							return new hr(A_1);
						}
					}
					else
					{
						if (A_0 == 265770411)
						{
							return new hx(A_1);
						}
						if (A_0 == 272801619)
						{
							return new hy(A_1);
						}
						if (A_0 == 275611842)
						{
							return new fk(A_1);
						}
					}
				}
				else if (A_0 <= 427944185)
				{
					if (A_0 == 397142149)
					{
						return new h0(A_1);
					}
					if (A_0 == 426354259)
					{
						return new fj(A_1);
					}
					if (A_0 == 427944185)
					{
						return new gw(A_1);
					}
				}
				else
				{
					if (A_0 == 436574770)
					{
						return new hc(A_1);
					}
					if (A_0 == 440052479)
					{
						return new h1(A_1);
					}
					if (A_0 == 445130693)
					{
						return new hs(A_1);
					}
				}
			}
			else if (A_0 <= 795562982)
			{
				if (A_0 <= 587060291)
				{
					if (A_0 <= 448574430)
					{
						if (A_0 == 445330501)
						{
							return new hu(A_1);
						}
						if (A_0 == 448574430)
						{
							return new ib(A_1);
						}
					}
					else
					{
						if (A_0 == 503613957)
						{
							return new fl(A_1);
						}
						if (A_0 == 510035525)
						{
							return new iv(A_1);
						}
						if (A_0 == 587060291)
						{
							return new jb(A_1);
						}
					}
				}
				else if (A_0 <= 663362251)
				{
					if (A_0 == 633671921)
					{
						return new iw(A_1);
					}
					if (A_0 == 663292235)
					{
						return new hv(A_1);
					}
					if (A_0 == 663362251)
					{
						return new ht(A_1);
					}
				}
				else
				{
					if (A_0 == 679876343)
					{
						return new gz(A_1);
					}
					if (A_0 == 791474715)
					{
						return new hh(A_1);
					}
					if (A_0 == 795562982)
					{
						return new ja(A_1);
					}
				}
			}
			else if (A_0 <= 1652275116)
			{
				if (A_0 <= 1005822593)
				{
					if (A_0 == 847005961)
					{
						return new hw(A_1);
					}
					if (A_0 == 898954496)
					{
						return new jc(A_1);
					}
					if (A_0 == 1005822593)
					{
						return new ir(A_1);
					}
				}
				else
				{
					if (A_0 == 1352615981)
					{
						return new fh(A_1);
					}
					if (A_0 == 1617181893)
					{
						return new fe(A_1);
					}
					if (A_0 == 1652275116)
					{
						return new ho(A_1);
					}
				}
			}
			else if (A_0 <= 1982853278)
			{
				if (A_0 == 1688661191)
				{
					return new he(A_1);
				}
				if (A_0 == 1844443081)
				{
					return new i7(A_1);
				}
				if (A_0 == 1982853278)
				{
					return new iy(A_1);
				}
			}
			else
			{
				if (A_0 == 1982903832)
				{
					return new it(A_1);
				}
				if (A_0 == 2066421648)
				{
					return new ha(A_1);
				}
				if (A_0 == 2098498396)
				{
					return new iz(A_1);
				}
			}
			return result;
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x000809CC File Offset: 0x0007F9CC
		internal static int a(int A_0, fb<fn>[] A_1)
		{
			for (int i = 0; i < A_1.Length; i++)
			{
				if (A_1[i].a() == A_0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060009EF RID: 2543
		internal abstract int cv();

		// Token: 0x060009F0 RID: 2544
		internal abstract void cw(gi A_0);

		// Token: 0x060009F1 RID: 2545 RVA: 0x00080A10 File Offset: 0x0007FA10
		internal virtual bool ct()
		{
			return false;
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x00080A23 File Offset: 0x0007FA23
		internal virtual void cu(bool A_0)
		{
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x00080A28 File Offset: 0x0007FA28
		internal virtual bool ky()
		{
			return false;
		}

		// Token: 0x060009F4 RID: 2548
		internal abstract fn cx();
	}
}
