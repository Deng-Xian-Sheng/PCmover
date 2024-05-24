using System;

namespace ControlzEx.Standard
{
	// Token: 0x02000019 RID: 25
	internal static class DoubleUtilities
	{
		// Token: 0x06000132 RID: 306 RVA: 0x00007488 File Offset: 0x00005688
		public static bool AreClose(double value1, double value2)
		{
			if (value1 == value2)
			{
				return true;
			}
			double num = value1 - value2;
			return num < 1.53E-06 && num > -1.53E-06;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x000074B9 File Offset: 0x000056B9
		public static bool IsCloseTo(this double value1, double value2)
		{
			return DoubleUtilities.AreClose(value1, value2);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x000074C2 File Offset: 0x000056C2
		public static bool IsStrictlyLessThan(this double value1, double value2)
		{
			return value1 < value2 && !DoubleUtilities.AreClose(value1, value2);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000074D4 File Offset: 0x000056D4
		public static bool IsStrictlyGreaterThan(this double value1, double value2)
		{
			return value1 > value2 && !DoubleUtilities.AreClose(value1, value2);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000074E6 File Offset: 0x000056E6
		public static bool IsLessThanOrCloseTo(this double value1, double value2)
		{
			return value1 < value2 || DoubleUtilities.AreClose(value1, value2);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000074F5 File Offset: 0x000056F5
		public static bool IsGreaterThanOrCloseTo(this double value1, double value2)
		{
			return value1 > value2 || DoubleUtilities.AreClose(value1, value2);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00007504 File Offset: 0x00005704
		public static bool IsFinite(this double value)
		{
			return !double.IsNaN(value) && !double.IsInfinity(value);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00007519 File Offset: 0x00005719
		public static bool IsValidSize(this double value)
		{
			return value.IsFinite() && value.IsGreaterThanOrCloseTo(0.0);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00007534 File Offset: 0x00005734
		public static bool IsFiniteAndNonNegative(this double d)
		{
			return !double.IsNaN(d) && !double.IsInfinity(d) && d >= 0.0;
		}

		// Token: 0x040000C8 RID: 200
		private const double Epsilon = 1.53E-06;
	}
}
