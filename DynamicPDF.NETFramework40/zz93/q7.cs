using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200028E RID: 654
	internal abstract class q7 : q6
	{
		// Token: 0x06001D48 RID: 7496 RVA: 0x0012B633 File Offset: 0x0012A633
		internal q7()
		{
		}

		// Token: 0x06001D49 RID: 7497
		internal abstract bool eq(LayoutWriter A_0);

		// Token: 0x06001D4A RID: 7498
		internal abstract bool er(LayoutWriter A_0, vi A_1);

		// Token: 0x06001D4B RID: 7499
		internal abstract bool ee(LayoutWriter A_0);

		// Token: 0x06001D4C RID: 7500
		internal abstract bool ef(LayoutWriter A_0, vi A_1);

		// Token: 0x06001D4D RID: 7501
		internal abstract DateTime eg(LayoutWriter A_0);

		// Token: 0x06001D4E RID: 7502
		internal abstract DateTime eh(LayoutWriter A_0, vi A_1);

		// Token: 0x06001D4F RID: 7503
		internal abstract decimal ei(LayoutWriter A_0);

		// Token: 0x06001D50 RID: 7504
		internal abstract decimal ej(LayoutWriter A_0, vi A_1);

		// Token: 0x06001D51 RID: 7505
		internal abstract double ek(LayoutWriter A_0);

		// Token: 0x06001D52 RID: 7506
		internal abstract double el(LayoutWriter A_0, vi A_1);

		// Token: 0x06001D53 RID: 7507
		internal abstract int em(LayoutWriter A_0);

		// Token: 0x06001D54 RID: 7508
		internal abstract int en(LayoutWriter A_0, vi A_1);

		// Token: 0x06001D55 RID: 7509
		internal abstract object es(LayoutWriter A_0);

		// Token: 0x06001D56 RID: 7510
		internal abstract object et(LayoutWriter A_0, vi A_1);

		// Token: 0x06001D57 RID: 7511
		internal abstract string eo(LayoutWriter A_0);

		// Token: 0x06001D58 RID: 7512
		internal abstract string ep(LayoutWriter A_0, vi A_1);

		// Token: 0x06001D59 RID: 7513
		internal abstract void eu(LayoutWriter A_0, vi A_1, PageElement A_2);

		// Token: 0x06001D5A RID: 7514 RVA: 0x0012B640 File Offset: 0x0012A640
		internal override void ec(LayoutWriter A_0, wt A_1, char[] A_2)
		{
			string text = this.eo(A_0);
			A_1.a((text != null) ? text : string.Empty);
		}

		// Token: 0x06001D5B RID: 7515 RVA: 0x0012B66C File Offset: 0x0012A66C
		internal override void ed(LayoutWriter A_0, vi A_1, wt A_2, char[] A_3)
		{
			string text = this.ep(A_0, A_1);
			A_2.a((text != null) ? text : string.Empty);
		}

		// Token: 0x06001D5C RID: 7516 RVA: 0x0012B698 File Offset: 0x0012A698
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
					throw new ReportWriterException("The value \"" + A_0.ToString() + "\"Value cannot be converted to a number.");
				}
				result = Convert.ToDecimal(A_0);
			}
			return result;
		}

		// Token: 0x06001D5D RID: 7517 RVA: 0x0012B6F8 File Offset: 0x0012A6F8
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
					throw new ReportWriterException("The value \"" + A_0.ToString() + "\"Value cannot be converted to a number.");
				}
				result = Convert.ToDouble(A_0);
			}
			return result;
		}

		// Token: 0x06001D5E RID: 7518 RVA: 0x0012B758 File Offset: 0x0012A758
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
					throw new ReportWriterException("The value \"" + A_0.ToString() + "\"Value cannot be converted to an integer.");
				}
				result = Convert.ToInt32(A_0);
			}
			return result;
		}

		// Token: 0x06001D5F RID: 7519 RVA: 0x0012B7B8 File Offset: 0x0012A7B8
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
					throw new ReportWriterException("The value \"" + A_0.ToString() + "\"Value cannot be converted to a date or time.");
				}
				result = Convert.ToDateTime(A_0);
			}
			return result;
		}

		// Token: 0x06001D60 RID: 7520 RVA: 0x0012B818 File Offset: 0x0012A818
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
					throw new ReportWriterException("The value \"null\" cannot be converted to a boolean.");
				}
				throw new ReportWriterException("The value \"" + A_0.ToString() + "\"Value cannot be converted to a boolean.");
			}
			return result;
		}
	}
}
