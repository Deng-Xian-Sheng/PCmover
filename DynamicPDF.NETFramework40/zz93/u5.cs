using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000326 RID: 806
	internal class u5 : to
	{
		// Token: 0x0600230D RID: 8973 RVA: 0x0014E634 File Offset: 0x0014D634
		internal u5(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid WeekDay Name function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x0600230E RID: 8974 RVA: 0x0014E69C File Offset: 0x0014D69C
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x0600230F RID: 8975 RVA: 0x0014E6BC File Offset: 0x0014D6BC
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x06002310 RID: 8976 RVA: 0x0014E6DC File Offset: 0x0014D6DC
		internal override string eo(LayoutWriter A_0)
		{
			string result;
			switch (this.a.eg(A_0).DayOfWeek)
			{
			case DayOfWeek.Sunday:
				result = "Sunday";
				break;
			case DayOfWeek.Monday:
				result = "Monday";
				break;
			case DayOfWeek.Tuesday:
				result = "Tuesday";
				break;
			case DayOfWeek.Wednesday:
				result = "Wednesday";
				break;
			case DayOfWeek.Thursday:
				result = "Thursday";
				break;
			case DayOfWeek.Friday:
				result = "Friday";
				break;
			case DayOfWeek.Saturday:
				result = "Saturday";
				break;
			default:
				throw new DplxParseException("Invalid WeekDayName function detected.");
			}
			return result;
		}

		// Token: 0x06002311 RID: 8977 RVA: 0x0014E768 File Offset: 0x0014D768
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			string result;
			switch (this.a.eh(A_0, A_1).DayOfWeek)
			{
			case DayOfWeek.Sunday:
				result = "Sunday";
				break;
			case DayOfWeek.Monday:
				result = "Monday";
				break;
			case DayOfWeek.Tuesday:
				result = "Tuesday";
				break;
			case DayOfWeek.Wednesday:
				result = "Wednesday";
				break;
			case DayOfWeek.Thursday:
				result = "Thursday";
				break;
			case DayOfWeek.Friday:
				result = "Friday";
				break;
			case DayOfWeek.Saturday:
				result = "Saturday";
				break;
			default:
				throw new DplxParseException("Invalid WeekDayName function detected.");
			}
			return result;
		}

		// Token: 0x06002312 RID: 8978 RVA: 0x0014E7F4 File Offset: 0x0014D7F4
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x06002313 RID: 8979 RVA: 0x0014E808 File Offset: 0x0014D808
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 11 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'e' || A_0[A_1 + 2] == 'E') && (A_0[A_1 + 3] == 'k' || A_0[A_1 + 3] == 'K') && (A_0[A_1 + 4] == 'd' || A_0[A_1 + 4] == 'D') && (A_0[A_1 + 5] == 'a' || A_0[A_1 + 5] == 'A') && (A_0[A_1 + 6] == 'y' || A_0[A_1 + 6] == 'Y') && (A_0[A_1 + 7] == 'n' || A_0[A_1 + 7] == 'N') && (A_0[A_1 + 8] == 'a' || A_0[A_1 + 8] == 'A') && (A_0[A_1 + 9] == 'm' || A_0[A_1 + 9] == 'M') && (A_0[A_1 + 10] == 'e' || A_0[A_1 + 10] == 'E') && (A_0[A_1] == 'W' || A_0[A_1] == 'w');
		}

		// Token: 0x04000F11 RID: 3857
		private new q7 a;
	}
}
