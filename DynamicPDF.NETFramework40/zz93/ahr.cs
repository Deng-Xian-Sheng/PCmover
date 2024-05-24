using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000506 RID: 1286
	internal abstract class ahr : ahq
	{
		// Token: 0x0600344C RID: 13388 RVA: 0x001CF393 File Offset: 0x001CE393
		internal ahr()
		{
		}

		// Token: 0x0600344D RID: 13389 RVA: 0x001CF3BC File Offset: 0x001CE3BC
		internal void a(al5 A_0)
		{
			if (A_0.b() == ',')
			{
				A_0.a(A_0.d() + 1);
				this.b = A_0.k();
				if (A_0.b() == ',')
				{
					A_0.a(A_0.d() + 1);
					this.a = A_0.k();
					if (A_0.b() == ',')
					{
						A_0.a(A_0.d() + 1);
						this.c = A_0.k();
					}
				}
				else
				{
					this.a = A_0.a();
				}
			}
			else
			{
				this.b = A_0.a();
				this.a = A_0.a();
			}
		}

		// Token: 0x0600344E RID: 13390
		internal abstract ahu md();

		// Token: 0x0600344F RID: 13391 RVA: 0x001CF484 File Offset: 0x001CE484
		internal string a()
		{
			return this.a;
		}

		// Token: 0x06003450 RID: 13392 RVA: 0x001CF49C File Offset: 0x001CE49C
		internal string b()
		{
			return this.b;
		}

		// Token: 0x06003451 RID: 13393 RVA: 0x001CF4B4 File Offset: 0x001CE4B4
		internal string c()
		{
			return this.c;
		}

		// Token: 0x06003452 RID: 13394 RVA: 0x001CF4CC File Offset: 0x001CE4CC
		internal bool d()
		{
			return this.d;
		}

		// Token: 0x06003453 RID: 13395 RVA: 0x001CF4E4 File Offset: 0x001CE4E4
		internal void a(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06003454 RID: 13396 RVA: 0x001CF4F0 File Offset: 0x001CE4F0
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return false;
		}

		// Token: 0x06003455 RID: 13397 RVA: 0x001CF504 File Offset: 0x001CE504
		internal override bool lx(LayoutWriter A_0, akk A_1)
		{
			return ahq.a(this.l2(A_0, A_1));
		}

		// Token: 0x06003456 RID: 13398 RVA: 0x001CF524 File Offset: 0x001CE524
		internal override DateTime ly(LayoutWriter A_0, akk A_1)
		{
			return ahq.b(this.l2(A_0, A_1));
		}

		// Token: 0x06003457 RID: 13399 RVA: 0x001CF544 File Offset: 0x001CE544
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			return ahq.e(this.l2(A_0, A_1));
		}

		// Token: 0x06003458 RID: 13400 RVA: 0x001CF564 File Offset: 0x001CE564
		internal override double l0(LayoutWriter A_0, akk A_1)
		{
			return ahq.d(this.l2(A_0, A_1));
		}

		// Token: 0x06003459 RID: 13401 RVA: 0x001CF584 File Offset: 0x001CE584
		internal override int l1(LayoutWriter A_0, akk A_1)
		{
			return ahq.c(this.l2(A_0, A_1));
		}

		// Token: 0x0600345A RID: 13402 RVA: 0x001CF5A4 File Offset: 0x001CE5A4
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			object result;
			if (string.Compare(this.b, "CurrentPage", true) == 0 || string.Compare(this.b, "PreviousPage", true) == 0)
			{
				result = A_0.m4().a(this).a().c();
			}
			else
			{
				result = A_0.m4().a(this).a().b();
			}
			return result;
		}

		// Token: 0x0600345B RID: 13403 RVA: 0x001CF61C File Offset: 0x001CE61C
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			return this.l2(A_0, A_1).ToString();
		}

		// Token: 0x0600345C RID: 13404 RVA: 0x001CF63B File Offset: 0x001CE63B
		internal override bool l4(LayoutWriter A_0)
		{
			throw new LayoutEngineException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x0600345D RID: 13405 RVA: 0x001CF648 File Offset: 0x001CE648
		internal override bool l5(LayoutWriter A_0)
		{
			throw new LayoutEngineException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x0600345E RID: 13406 RVA: 0x001CF655 File Offset: 0x001CE655
		internal override DateTime l6(LayoutWriter A_0)
		{
			throw new LayoutEngineException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x0600345F RID: 13407 RVA: 0x001CF662 File Offset: 0x001CE662
		internal override decimal l7(LayoutWriter A_0)
		{
			throw new LayoutEngineException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x06003460 RID: 13408 RVA: 0x001CF66F File Offset: 0x001CE66F
		internal override double l8(LayoutWriter A_0)
		{
			throw new LayoutEngineException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x06003461 RID: 13409 RVA: 0x001CF67C File Offset: 0x001CE67C
		internal override int l9(LayoutWriter A_0)
		{
			throw new LayoutEngineException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x06003462 RID: 13410 RVA: 0x001CF689 File Offset: 0x001CE689
		internal override object ma(LayoutWriter A_0)
		{
			throw new LayoutEngineException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x06003463 RID: 13411 RVA: 0x001CF696 File Offset: 0x001CE696
		internal override string mb(LayoutWriter A_0)
		{
			throw new LayoutEngineException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x06003464 RID: 13412 RVA: 0x001CF6A3 File Offset: 0x001CE6A3
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			A_0.m4().a(this).a().a();
		}

		// Token: 0x0400194E RID: 6478
		private new string a = null;

		// Token: 0x0400194F RID: 6479
		private new string b = null;

		// Token: 0x04001950 RID: 6480
		private new string c = null;

		// Token: 0x04001951 RID: 6481
		private new bool d = false;
	}
}
