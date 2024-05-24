using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008AB RID: 2219
	public static class RuntimeFeature
	{
		// Token: 0x06005D91 RID: 23953 RVA: 0x0014931C File Offset: 0x0014751C
		public static bool IsSupported(string feature)
		{
			return feature == "PortablePdb" && !AppContextSwitches.IgnorePortablePDBsInStackTraces;
		}

		// Token: 0x04002A09 RID: 10761
		public const string PortablePdb = "PortablePdb";
	}
}
