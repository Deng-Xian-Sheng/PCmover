using System;
using System.Net.Mail;
using Laplink.Pcmover.Contracts;

namespace PCmover.Infrastructure
{
	// Token: 0x0200002B RID: 43
	public class LicenseInfo : AuthorizationRequestData
	{
		// Token: 0x06000286 RID: 646 RVA: 0x00006D74 File Offset: 0x00004F74
		public LicenseInfo()
		{
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00006D7C File Offset: 0x00004F7C
		public LicenseInfo(AuthorizationRequestData other) : base(other)
		{
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000288 RID: 648 RVA: 0x00006D85 File Offset: 0x00004F85
		public bool IsValidEmail
		{
			get
			{
				return LicenseInfo.IsValidEmailAddress(base.Email);
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000289 RID: 649 RVA: 0x00006D92 File Offset: 0x00004F92
		public bool IsValidUser
		{
			get
			{
				return !string.IsNullOrWhiteSpace(base.User);
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600028A RID: 650 RVA: 0x00006DA2 File Offset: 0x00004FA2
		public bool IsValidSerialNumber
		{
			get
			{
				return !string.IsNullOrWhiteSpace(base.SerialNumber);
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600028B RID: 651 RVA: 0x00006DB2 File Offset: 0x00004FB2
		public bool IsValid
		{
			get
			{
				return this.IsValidUser && this.IsValidEmail && this.IsValidSerialNumber;
			}
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00006DCC File Offset: 0x00004FCC
		private static bool IsValidEmailAddress(string address)
		{
			if (string.IsNullOrEmpty(address))
			{
				return false;
			}
			try
			{
				new MailAddress(address);
				return true;
			}
			catch
			{
			}
			return false;
		}
	}
}
