using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000054 RID: 84
	public class PcmoverProperties
	{
		// Token: 0x0600024F RID: 591 RVA: 0x00002050 File Offset: 0x00000250
		protected PcmoverProperties()
		{
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000344C File Offset: 0x0000164C
		public static bool? GetNullableBool(string trueFalseValue)
		{
			if (trueFalseValue == PcmoverProperties.TrueValue)
			{
				return new bool?(true);
			}
			if (trueFalseValue == PcmoverProperties.FalseValue)
			{
				return new bool?(false);
			}
			return null;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000348C File Offset: 0x0000168C
		public static bool GetBool(string trueFalseValue, bool defaultValue)
		{
			bool? nullableBool = PcmoverProperties.GetNullableBool(trueFalseValue);
			if (nullableBool == null)
			{
				return defaultValue;
			}
			return nullableBool.Value;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000034B2 File Offset: 0x000016B2
		public static string TrueFalseValue(bool b)
		{
			if (!b)
			{
				return PcmoverProperties.FalseValue;
			}
			return PcmoverProperties.TrueValue;
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000253 RID: 595 RVA: 0x000034C4 File Offset: 0x000016C4
		public static string NowValue
		{
			get
			{
				return DateTime.Now.ToString("o");
			}
		}

		// Token: 0x040001F4 RID: 500
		public static readonly string FalseValue = "0";

		// Token: 0x040001F5 RID: 501
		public static readonly string TrueValue = "1";
	}
}
