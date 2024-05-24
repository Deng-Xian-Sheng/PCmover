using System;

namespace CefSharp
{
	// Token: 0x02000084 RID: 132
	public class JavascriptException
	{
		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000399 RID: 921 RVA: 0x00003846 File Offset: 0x00001A46
		// (set) Token: 0x0600039A RID: 922 RVA: 0x0000384E File Offset: 0x00001A4E
		public string Message { get; set; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00003857 File Offset: 0x00001A57
		// (set) Token: 0x0600039C RID: 924 RVA: 0x0000385F File Offset: 0x00001A5F
		public JavascriptStackFrame[] StackTrace { get; set; }
	}
}
