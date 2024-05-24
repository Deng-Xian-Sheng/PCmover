using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000562 RID: 1378
	internal class aka : ail
	{
		// Token: 0x0600370B RID: 14091 RVA: 0x001DD3D0 File Offset: 0x001DC3D0
		internal aka(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid WeekDay Name function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x0600370C RID: 14092 RVA: 0x001DD438 File Offset: 0x001DC438
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x0600370D RID: 14093 RVA: 0x001DD458 File Offset: 0x001DC458
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x0600370E RID: 14094 RVA: 0x001DD478 File Offset: 0x001DC478
		internal override string mb(LayoutWriter A_0)
		{
			string result;
			switch (this.a.l6(A_0).DayOfWeek)
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
				throw new DlexParseException("Invalid WeekDayName function detected.");
			}
			return result;
		}

		// Token: 0x0600370F RID: 14095 RVA: 0x001DD504 File Offset: 0x001DC504
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			string result;
			switch (this.a.ly(A_0, A_1).DayOfWeek)
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
				throw new DlexParseException("Invalid WeekDayName function detected.");
			}
			return result;
		}

		// Token: 0x06003710 RID: 14096 RVA: 0x001DD590 File Offset: 0x001DC590
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x06003711 RID: 14097 RVA: 0x001DD5A4 File Offset: 0x001DC5A4
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 11 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'e' || A_0[A_1 + 2] == 'E') && (A_0[A_1 + 3] == 'k' || A_0[A_1 + 3] == 'K') && (A_0[A_1 + 4] == 'd' || A_0[A_1 + 4] == 'D') && (A_0[A_1 + 5] == 'a' || A_0[A_1 + 5] == 'A') && (A_0[A_1 + 6] == 'y' || A_0[A_1 + 6] == 'Y') && (A_0[A_1 + 7] == 'n' || A_0[A_1 + 7] == 'N') && (A_0[A_1 + 8] == 'a' || A_0[A_1 + 8] == 'A') && (A_0[A_1 + 9] == 'm' || A_0[A_1 + 9] == 'M') && (A_0[A_1 + 10] == 'e' || A_0[A_1 + 10] == 'E') && (A_0[A_1] == 'W' || A_0[A_1] == 'w');
		}

		// Token: 0x04001A0E RID: 6670
		private new ahq a;
	}
}
