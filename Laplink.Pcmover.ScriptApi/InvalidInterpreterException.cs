using System;

namespace Laplink.Pcmover.ScriptApi
{
	// Token: 0x0200000A RID: 10
	public class InvalidInterpreterException : ScriptException
	{
		// Token: 0x06000061 RID: 97 RVA: 0x0000307B File Offset: 0x0000127B
		public InvalidInterpreterException()
		{
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003083 File Offset: 0x00001283
		public InvalidInterpreterException(string script, string msg, Exception innerException = null) : base(script, msg, innerException)
		{
		}
	}
}
