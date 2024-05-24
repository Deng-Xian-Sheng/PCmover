using System;
using System.Collections.Generic;

namespace CefSharp
{
	// Token: 0x02000097 RID: 151
	public struct ResolveCallbackResult
	{
		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000466 RID: 1126 RVA: 0x00006D7C File Offset: 0x00004F7C
		// (set) Token: 0x06000467 RID: 1127 RVA: 0x00006D84 File Offset: 0x00004F84
		public CefErrorCode Result { get; private set; }

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000468 RID: 1128 RVA: 0x00006D8D File Offset: 0x00004F8D
		// (set) Token: 0x06000469 RID: 1129 RVA: 0x00006D95 File Offset: 0x00004F95
		public IList<string> ResolvedIpAddresses { get; private set; }

		// Token: 0x0600046A RID: 1130 RVA: 0x00006D9E File Offset: 0x00004F9E
		public ResolveCallbackResult(CefErrorCode result, IList<string> resolvedIpAddresses)
		{
			this = default(ResolveCallbackResult);
			this.Result = result;
			this.ResolvedIpAddresses = resolvedIpAddresses;
		}
	}
}
