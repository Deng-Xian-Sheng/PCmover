using System;

namespace QRCoder
{
	// Token: 0x0200000C RID: 12
	internal static class String40Methods
	{
		// Token: 0x0600002E RID: 46 RVA: 0x00002E28 File Offset: 0x00001028
		public static bool IsNullOrWhiteSpace(string value)
		{
			if (value == null)
			{
				return true;
			}
			for (int i = 0; i < value.Length; i++)
			{
				if (!char.IsWhiteSpace(value[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002E5C File Offset: 0x0000105C
		public static string ReverseString(string str)
		{
			char[] array = str.ToCharArray();
			char[] array2 = new char[array.Length];
			int i = 0;
			int num = str.Length - 1;
			while (i < str.Length)
			{
				array2[i] = array[num];
				i++;
				num--;
			}
			return new string(array2);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002EA4 File Offset: 0x000010A4
		public static bool IsAllDigit(string str)
		{
			for (int i = 0; i < str.Length; i++)
			{
				if (!char.IsDigit(str[i]))
				{
					return false;
				}
			}
			return true;
		}
	}
}
