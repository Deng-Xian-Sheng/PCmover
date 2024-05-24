using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000505 RID: 1285
	internal abstract class ahq : ahp
	{
		// Token: 0x06003433 RID: 13363 RVA: 0x001CF13B File Offset: 0x001CE13B
		internal ahq()
		{
		}

		// Token: 0x06003434 RID: 13364
		internal abstract bool l4(LayoutWriter A_0);

		// Token: 0x06003435 RID: 13365
		internal abstract bool lw(LayoutWriter A_0, akk A_1);

		// Token: 0x06003436 RID: 13366
		internal abstract bool l5(LayoutWriter A_0);

		// Token: 0x06003437 RID: 13367
		internal abstract bool lx(LayoutWriter A_0, akk A_1);

		// Token: 0x06003438 RID: 13368
		internal abstract DateTime l6(LayoutWriter A_0);

		// Token: 0x06003439 RID: 13369
		internal abstract DateTime ly(LayoutWriter A_0, akk A_1);

		// Token: 0x0600343A RID: 13370
		internal abstract decimal l7(LayoutWriter A_0);

		// Token: 0x0600343B RID: 13371
		internal abstract decimal lz(LayoutWriter A_0, akk A_1);

		// Token: 0x0600343C RID: 13372
		internal abstract double l8(LayoutWriter A_0);

		// Token: 0x0600343D RID: 13373
		internal abstract double l0(LayoutWriter A_0, akk A_1);

		// Token: 0x0600343E RID: 13374
		internal abstract int l9(LayoutWriter A_0);

		// Token: 0x0600343F RID: 13375
		internal abstract int l1(LayoutWriter A_0, akk A_1);

		// Token: 0x06003440 RID: 13376
		internal abstract object ma(LayoutWriter A_0);

		// Token: 0x06003441 RID: 13377
		internal abstract object l2(LayoutWriter A_0, akk A_1);

		// Token: 0x06003442 RID: 13378
		internal abstract string mb(LayoutWriter A_0);

		// Token: 0x06003443 RID: 13379
		internal abstract string l3(LayoutWriter A_0, akk A_1);

		// Token: 0x06003444 RID: 13380
		internal abstract void mc(LayoutWriter A_0, akk A_1, PageElement A_2);

		// Token: 0x06003445 RID: 13381 RVA: 0x001CF148 File Offset: 0x001CE148
		internal override void lu(LayoutWriter A_0, alq A_1, char[] A_2)
		{
			string text = this.mb(A_0);
			A_1.a((text != null) ? text : string.Empty);
		}

		// Token: 0x06003446 RID: 13382 RVA: 0x001CF174 File Offset: 0x001CE174
		internal override void lv(LayoutWriter A_0, akk A_1, alq A_2, char[] A_3)
		{
			string text = this.l3(A_0, A_1);
			A_2.a((text != null) ? text : string.Empty);
		}

		// Token: 0x06003447 RID: 13383 RVA: 0x001CF1A0 File Offset: 0x001CE1A0
		internal static decimal e(object A_0)
		{
			decimal result;
			if (A_0 is decimal)
			{
				result = (decimal)A_0;
			}
			else
			{
				if (!(A_0 is IConvertible))
				{
					throw new LayoutEngineException("The value \"" + A_0.ToString() + "\"Value cannot be converted to a number.");
				}
				result = Convert.ToDecimal(A_0);
			}
			return result;
		}

		// Token: 0x06003448 RID: 13384 RVA: 0x001CF200 File Offset: 0x001CE200
		internal static double d(object A_0)
		{
			double result;
			if (A_0 is double)
			{
				result = (double)A_0;
			}
			else
			{
				if (!(A_0 is IConvertible))
				{
					throw new LayoutEngineException("The value \"" + A_0.ToString() + "\"Value cannot be converted to a number.");
				}
				result = Convert.ToDouble(A_0);
			}
			return result;
		}

		// Token: 0x06003449 RID: 13385 RVA: 0x001CF260 File Offset: 0x001CE260
		internal static int c(object A_0)
		{
			int result;
			if (A_0 is int)
			{
				result = (int)A_0;
			}
			else
			{
				if (!(A_0 is IConvertible))
				{
					throw new LayoutEngineException("The value \"" + A_0.ToString() + "\"Value cannot be converted to an integer.");
				}
				result = Convert.ToInt32(A_0);
			}
			return result;
		}

		// Token: 0x0600344A RID: 13386 RVA: 0x001CF2C0 File Offset: 0x001CE2C0
		internal static DateTime b(object A_0)
		{
			DateTime result;
			if (A_0 is DateTime)
			{
				result = (DateTime)A_0;
			}
			else
			{
				if (!(A_0 is IConvertible))
				{
					throw new LayoutEngineException("The value \"" + A_0.ToString() + "\"Value cannot be converted to a date or time.");
				}
				result = Convert.ToDateTime(A_0);
			}
			return result;
		}

		// Token: 0x0600344B RID: 13387 RVA: 0x001CF320 File Offset: 0x001CE320
		internal static bool a(object A_0)
		{
			bool result;
			if (A_0 is bool)
			{
				result = (bool)A_0;
			}
			else if (A_0 is IConvertible)
			{
				result = Convert.ToBoolean(A_0);
			}
			else
			{
				if (A_0 == null)
				{
					throw new LayoutEngineException("The value \"null\" cannot be converted to a boolean.");
				}
				throw new LayoutEngineException("The value \"" + A_0.ToString() + "\"Value cannot be converted to a boolean.");
			}
			return result;
		}
	}
}
