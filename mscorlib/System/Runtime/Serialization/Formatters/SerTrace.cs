using System;
using System.Diagnostics;

namespace System.Runtime.Serialization.Formatters
{
	// Token: 0x02000763 RID: 1891
	internal static class SerTrace
	{
		// Token: 0x0600530D RID: 21261 RVA: 0x00123BC2 File Offset: 0x00121DC2
		[Conditional("_LOGGING")]
		internal static void InfoLog(params object[] messages)
		{
		}

		// Token: 0x0600530E RID: 21262 RVA: 0x00123BC4 File Offset: 0x00121DC4
		[Conditional("SER_LOGGING")]
		internal static void Log(params object[] messages)
		{
			if (!(messages[0] is string))
			{
				messages[0] = messages[0].GetType().Name + " ";
				return;
			}
			int num = 0;
			object obj = messages[0];
			messages[num] = ((obj != null) ? obj.ToString() : null) + " ";
		}
	}
}
