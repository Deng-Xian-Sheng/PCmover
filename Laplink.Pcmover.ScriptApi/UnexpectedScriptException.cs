using System;

namespace Laplink.Pcmover.ScriptApi
{
	// Token: 0x0200000B RID: 11
	public class UnexpectedScriptException : ScriptException
	{
		// Token: 0x06000063 RID: 99 RVA: 0x0000308E File Offset: 0x0000128E
		public UnexpectedScriptException()
		{
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003096 File Offset: 0x00001296
		public UnexpectedScriptException(string script, string msg, Exception innerException = null) : base(script, msg, innerException)
		{
		}
	}
}
