using System;
using System.Runtime.InteropServices;
using System.Security;

namespace MahApps.Metro.Controls.Dialogs
{
	// Token: 0x020000A9 RID: 169
	public class LoginDialogData
	{
		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x0600093C RID: 2364 RVA: 0x00024E9B File Offset: 0x0002309B
		// (set) Token: 0x0600093D RID: 2365 RVA: 0x00024EA3 File Offset: 0x000230A3
		public string Username { get; internal set; }

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x0600093E RID: 2366 RVA: 0x00024EAC File Offset: 0x000230AC
		public string Password
		{
			[SecurityCritical]
			get
			{
				IntPtr intPtr = Marshal.SecureStringToBSTR(this.SecurePassword);
				string result;
				try
				{
					result = Marshal.PtrToStringBSTR(intPtr);
				}
				finally
				{
					Marshal.ZeroFreeBSTR(intPtr);
				}
				return result;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x00024EE8 File Offset: 0x000230E8
		// (set) Token: 0x06000940 RID: 2368 RVA: 0x00024EF0 File Offset: 0x000230F0
		public SecureString SecurePassword { get; internal set; }

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000941 RID: 2369 RVA: 0x00024EF9 File Offset: 0x000230F9
		// (set) Token: 0x06000942 RID: 2370 RVA: 0x00024F01 File Offset: 0x00023101
		public bool ShouldRemember { get; internal set; }
	}
}
