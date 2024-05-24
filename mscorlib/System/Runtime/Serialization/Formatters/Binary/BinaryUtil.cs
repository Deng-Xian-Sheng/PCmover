using System;
using System.Diagnostics;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x0200077E RID: 1918
	internal static class BinaryUtil
	{
		// Token: 0x060053B9 RID: 21433 RVA: 0x00126D2D File Offset: 0x00124F2D
		[Conditional("_LOGGING")]
		public static void NVTraceI(string name, string value)
		{
			BCLDebug.CheckEnabled("BINARY");
		}

		// Token: 0x060053BA RID: 21434 RVA: 0x00126D3A File Offset: 0x00124F3A
		[Conditional("_LOGGING")]
		public static void NVTraceI(string name, object value)
		{
			BCLDebug.CheckEnabled("BINARY");
		}
	}
}
