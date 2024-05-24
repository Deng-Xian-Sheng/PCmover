using System;

namespace CefSharp.RenderProcess
{
	// Token: 0x020000B2 RID: 178
	public class V8Exception
	{
		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x00008995 File Offset: 0x00006B95
		// (set) Token: 0x06000569 RID: 1385 RVA: 0x0000899D File Offset: 0x00006B9D
		public int EndColumn { get; private set; }

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x000089A6 File Offset: 0x00006BA6
		// (set) Token: 0x0600056B RID: 1387 RVA: 0x000089AE File Offset: 0x00006BAE
		public int EndPosition { get; private set; }

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x0600056C RID: 1388 RVA: 0x000089B7 File Offset: 0x00006BB7
		// (set) Token: 0x0600056D RID: 1389 RVA: 0x000089BF File Offset: 0x00006BBF
		public int LineNumber { get; private set; }

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x000089C8 File Offset: 0x00006BC8
		// (set) Token: 0x0600056F RID: 1391 RVA: 0x000089D0 File Offset: 0x00006BD0
		public string Message { get; private set; }

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x000089D9 File Offset: 0x00006BD9
		// (set) Token: 0x06000571 RID: 1393 RVA: 0x000089E1 File Offset: 0x00006BE1
		public string ScriptResourceName { get; private set; }

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000572 RID: 1394 RVA: 0x000089EA File Offset: 0x00006BEA
		// (set) Token: 0x06000573 RID: 1395 RVA: 0x000089F2 File Offset: 0x00006BF2
		public string SourceLine { get; private set; }

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000574 RID: 1396 RVA: 0x000089FB File Offset: 0x00006BFB
		// (set) Token: 0x06000575 RID: 1397 RVA: 0x00008A03 File Offset: 0x00006C03
		public int StartColumn { get; private set; }

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x00008A0C File Offset: 0x00006C0C
		// (set) Token: 0x06000577 RID: 1399 RVA: 0x00008A14 File Offset: 0x00006C14
		public int StartPosition { get; private set; }

		// Token: 0x06000578 RID: 1400 RVA: 0x00008A20 File Offset: 0x00006C20
		public V8Exception(int endColumn, int endPosition, int lineNumber, string message, string scriptResourceName, string sourceLine, int startColumn, int startPosition)
		{
			this.EndColumn = endColumn;
			this.EndPosition = endPosition;
			this.LineNumber = lineNumber;
			this.Message = message;
			this.ScriptResourceName = scriptResourceName;
			this.SourceLine = sourceLine;
			this.StartColumn = startColumn;
			this.StartPosition = startPosition;
		}
	}
}
