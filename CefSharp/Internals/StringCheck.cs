using System;
using System.Text.RegularExpressions;

namespace CefSharp.Internals
{
	// Token: 0x020000EA RID: 234
	public static class StringCheck
	{
		// Token: 0x060006F4 RID: 1780 RVA: 0x0000B640 File Offset: 0x00009840
		public static bool IsLettersAndNumbers(string stringToCheck)
		{
			return !string.IsNullOrWhiteSpace(stringToCheck) && Regex.IsMatch(stringToCheck, "^\\w+$");
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x0000B657 File Offset: 0x00009857
		public static bool IsFirstCharacterLowercase(string str)
		{
			return !string.IsNullOrEmpty(str) && char.IsLetter(str[0]) && char.IsLower(str[0]);
		}
	}
}
