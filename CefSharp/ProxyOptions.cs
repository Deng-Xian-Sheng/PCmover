using System;

namespace CefSharp
{
	// Token: 0x0200008D RID: 141
	public class ProxyOptions
	{
		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x00003DA1 File Offset: 0x00001FA1
		// (set) Token: 0x060003EF RID: 1007 RVA: 0x00003DA9 File Offset: 0x00001FA9
		public string IP { get; private set; }

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060003F0 RID: 1008 RVA: 0x00003DB2 File Offset: 0x00001FB2
		// (set) Token: 0x060003F1 RID: 1009 RVA: 0x00003DBA File Offset: 0x00001FBA
		public string Port { get; private set; }

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060003F2 RID: 1010 RVA: 0x00003DC3 File Offset: 0x00001FC3
		// (set) Token: 0x060003F3 RID: 1011 RVA: 0x00003DCB File Offset: 0x00001FCB
		public string Username { get; set; }

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060003F4 RID: 1012 RVA: 0x00003DD4 File Offset: 0x00001FD4
		// (set) Token: 0x060003F5 RID: 1013 RVA: 0x00003DDC File Offset: 0x00001FDC
		public string Password { get; set; }

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060003F6 RID: 1014 RVA: 0x00003DE5 File Offset: 0x00001FE5
		// (set) Token: 0x060003F7 RID: 1015 RVA: 0x00003DED File Offset: 0x00001FED
		public string BypassList { get; private set; }

		// Token: 0x060003F8 RID: 1016 RVA: 0x00003DF6 File Offset: 0x00001FF6
		public bool HasUsernameAndPassword()
		{
			return !string.IsNullOrEmpty(this.Username) && !string.IsNullOrEmpty(this.Password);
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00003E15 File Offset: 0x00002015
		public ProxyOptions(string ip, string port, string username = "", string password = "", string bypassList = "")
		{
			this.IP = ip;
			this.Port = port;
			this.Username = username;
			this.Password = password;
			this.BypassList = bypassList;
		}
	}
}
