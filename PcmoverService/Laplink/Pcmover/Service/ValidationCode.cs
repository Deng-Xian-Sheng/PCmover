using System;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000033 RID: 51
	public class ValidationCode
	{
		// Token: 0x0600025B RID: 603 RVA: 0x00011323 File Offset: 0x0000F523
		static ValidationCode()
		{
			if ("3456789ABCDEFGHJKLMNPQRSTWXY".Length != 28)
			{
				throw new SystemException();
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0001133C File Offset: 0x0000F53C
		public static uint CalcChecksum(string str)
		{
			string text = str.ToUpper();
			uint num = 0U;
			for (int i = 0; i < text.Length; i++)
			{
				uint num2 = (uint)text[i];
				num += num2;
				num += num2 / (uint)((i & 3) + 1);
			}
			return num;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0001137C File Offset: 0x0000F57C
		public static string CreateVcCode(uint code)
		{
			char[] array = new char[7];
			uint num = 0U;
			while (num < 7U)
			{
				uint index = code % 28U;
				array[(int)num] = "3456789ABCDEFGHJKLMNPQRSTWXY"[(int)index];
				num += 1U;
				code /= 28U;
			}
			if (code != 0U)
			{
				throw new SystemException();
			}
			return new string(array);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x000113C4 File Offset: 0x0000F5C4
		public static bool GetCheckDigit(string numericString, out uint digit)
		{
			uint num;
			if (!ValidationCode.AddDigits(numericString, out num))
			{
				digit = 10U;
				return false;
			}
			digit = ValidationCode.GetCheckDigit(num);
			return true;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000113EC File Offset: 0x0000F5EC
		private static bool AddDigits(string numericString, out uint total)
		{
			total = 0U;
			foreach (char c in numericString)
			{
				if (!char.IsDigit(c))
				{
					return false;
				}
				uint num = (uint)(c - '0');
				total += num;
			}
			return true;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0001142D File Offset: 0x0000F62D
		private static uint GetCheckDigit(uint num)
		{
			return 9U - num % 10U;
		}

		// Token: 0x040000C5 RID: 197
		protected const int VC_CODELENGTH = 7;

		// Token: 0x040000C6 RID: 198
		private const int VC_BASE = 28;

		// Token: 0x040000C7 RID: 199
		private const string baseTable = "3456789ABCDEFGHJKLMNPQRSTWXY";
	}
}
