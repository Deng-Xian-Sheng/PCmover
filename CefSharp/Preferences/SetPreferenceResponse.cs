using System;

namespace CefSharp.Preferences
{
	// Token: 0x020000B3 RID: 179
	public class SetPreferenceResponse
	{
		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x00008A70 File Offset: 0x00006C70
		// (set) Token: 0x0600057A RID: 1402 RVA: 0x00008A78 File Offset: 0x00006C78
		public bool Success { get; private set; }

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x00008A81 File Offset: 0x00006C81
		// (set) Token: 0x0600057C RID: 1404 RVA: 0x00008A89 File Offset: 0x00006C89
		public string ErrorMessage { get; private set; }

		// Token: 0x0600057D RID: 1405 RVA: 0x00008A92 File Offset: 0x00006C92
		public SetPreferenceResponse(bool success, string errorMessage)
		{
			this.Success = success;
			this.ErrorMessage = errorMessage;
		}
	}
}
