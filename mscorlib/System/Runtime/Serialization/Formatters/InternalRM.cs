using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Serialization.Formatters
{
	// Token: 0x02000761 RID: 1889
	[SecurityCritical]
	[ComVisible(true)]
	public sealed class InternalRM
	{
		// Token: 0x06005303 RID: 21251 RVA: 0x00123B01 File Offset: 0x00121D01
		[Conditional("_LOGGING")]
		public static void InfoSoap(params object[] messages)
		{
		}

		// Token: 0x06005304 RID: 21252 RVA: 0x00123B03 File Offset: 0x00121D03
		public static bool SoapCheckEnabled()
		{
			return BCLDebug.CheckEnabled("SOAP");
		}
	}
}
