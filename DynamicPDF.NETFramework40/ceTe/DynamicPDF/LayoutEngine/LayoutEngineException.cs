using System;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x02000939 RID: 2361
	public class LayoutEngineException : Exception
	{
		// Token: 0x06006001 RID: 24577 RVA: 0x0035FAC0 File Offset: 0x0035EAC0
		public LayoutEngineException(string message) : base(message)
		{
		}

		// Token: 0x06006002 RID: 24578 RVA: 0x0035FACC File Offset: 0x0035EACC
		internal LayoutEngineException(string A_0, Exception A_1) : base(A_0, A_1)
		{
		}
	}
}
