using System;

namespace CefSharp.Internals
{
	// Token: 0x020000EC RID: 236
	public class TryCallMethodResult
	{
		// Token: 0x17000217 RID: 535
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x0000B8CC File Offset: 0x00009ACC
		// (set) Token: 0x06000700 RID: 1792 RVA: 0x0000B8D4 File Offset: 0x00009AD4
		public string Exception { get; private set; }

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000701 RID: 1793 RVA: 0x0000B8DD File Offset: 0x00009ADD
		// (set) Token: 0x06000702 RID: 1794 RVA: 0x0000B8E5 File Offset: 0x00009AE5
		public object ReturnValue { get; private set; }

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000703 RID: 1795 RVA: 0x0000B8EE File Offset: 0x00009AEE
		// (set) Token: 0x06000704 RID: 1796 RVA: 0x0000B8F6 File Offset: 0x00009AF6
		public bool Success { get; private set; }

		// Token: 0x06000705 RID: 1797 RVA: 0x0000B8FF File Offset: 0x00009AFF
		public TryCallMethodResult(bool success, object returnValue, string exception)
		{
			this.Success = success;
			this.ReturnValue = returnValue;
			this.Exception = exception;
		}
	}
}
