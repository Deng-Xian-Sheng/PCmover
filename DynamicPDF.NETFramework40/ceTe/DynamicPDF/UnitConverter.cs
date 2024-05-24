using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000665 RID: 1637
	public class UnitConverter
	{
		// Token: 0x06003DD8 RID: 15832 RVA: 0x00216D4C File Offset: 0x00215D4C
		private UnitConverter()
		{
		}

		// Token: 0x06003DD9 RID: 15833 RVA: 0x00216D58 File Offset: 0x00215D58
		public static float PointsToInches(float size)
		{
			return size / 72f;
		}

		// Token: 0x06003DDA RID: 15834 RVA: 0x00216D74 File Offset: 0x00215D74
		public static float PointsToMillimeters(float size)
		{
			return size / 2.8346457f;
		}

		// Token: 0x06003DDB RID: 15835 RVA: 0x00216D90 File Offset: 0x00215D90
		public static float InchesToPoints(float size)
		{
			return size * 72f;
		}

		// Token: 0x06003DDC RID: 15836 RVA: 0x00216DAC File Offset: 0x00215DAC
		public static float MillimetersToPoints(float size)
		{
			return size * 2.8346457f;
		}
	}
}
