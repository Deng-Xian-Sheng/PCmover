using System;

namespace CefSharp.RenderProcess
{
	// Token: 0x020000B1 RID: 177
	public interface IV8Context
	{
		// Token: 0x06000567 RID: 1383
		bool Execute(string code, string scriptUrl, int startLine, out V8Exception exception);
	}
}
