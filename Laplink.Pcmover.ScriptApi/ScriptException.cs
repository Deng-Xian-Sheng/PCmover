using System;
using System.ServiceModel;

namespace Laplink.Pcmover.ScriptApi
{
	// Token: 0x02000009 RID: 9
	public class ScriptException : CommunicationException
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00003034 File Offset: 0x00001234
		public string Script { get; }

		// Token: 0x0600005E RID: 94 RVA: 0x0000303C File Offset: 0x0000123C
		public ScriptException()
		{
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003044 File Offset: 0x00001244
		public ScriptException(string script, string msg, Exception innerException = null) : base(msg, innerException)
		{
			this.Script = script;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003055 File Offset: 0x00001255
		public static ScriptException Create(ScriptResult res, string script, string msg, Exception innerException = null)
		{
			if (res == ScriptResult.InvalidInterpreter)
			{
				return new InvalidInterpreterException(script, msg, innerException);
			}
			if (res != ScriptResult.UnexpectedException)
			{
				return new ScriptException(script, msg, innerException);
			}
			return new UnexpectedScriptException(script, msg, innerException);
		}
	}
}
