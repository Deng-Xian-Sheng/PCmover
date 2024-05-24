using System;
using System.Collections;

namespace zz93
{
	// Token: 0x020003A0 RID: 928
	internal class ya : IComparer
	{
		// Token: 0x0600278D RID: 10125 RVA: 0x0016B270 File Offset: 0x0016A270
		int IComparer.a(object A_0, object A_1)
		{
			string text = (string)A_0;
			string text2 = (string)A_1;
			int num = (text.Length < text2.Length) ? text.Length : text2.Length;
			int i = 0;
			while (i < num)
			{
				int result;
				if (text[i] > text2[i])
				{
					result = 1;
				}
				else
				{
					if (text[i] >= text2[i])
					{
						i++;
						continue;
					}
					result = -1;
				}
				return result;
			}
			if (text2.Length == text.Length)
			{
				return 0;
			}
			return (text.Length > text2.Length) ? 1 : -1;
		}
	}
}
