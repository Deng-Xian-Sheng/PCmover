using System;

namespace Laplink.Pcmover.ScriptApi
{
	// Token: 0x02000005 RID: 5
	public interface IScriptChannel
	{
		// Token: 0x06000013 RID: 19
		string InvokeScript(string script);

		// Token: 0x06000014 RID: 20
		bool Poll(string script, Predicate<string> checkResult, out string result);

		// Token: 0x06000015 RID: 21
		bool Poll(string script, Predicate<string> checkResult, TimeSpan timeout, out string result);
	}
}
