using System;

namespace QRCoder.Extensions
{
	// Token: 0x0200001C RID: 28
	public static class CustomExtensions
	{
		// Token: 0x060000A4 RID: 164 RVA: 0x00006C6C File Offset: 0x00004E6C
		public static string GetStringValue(this Enum value)
		{
			StringValueAttribute[] array = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
			if (array.Length == 0)
			{
				return null;
			}
			return array[0].StringValue;
		}
	}
}
