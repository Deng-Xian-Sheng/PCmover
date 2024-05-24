using System;
using System.Collections;
using System.Security.Principal;
using System.ServiceModel;
using System.Threading;

namespace Laplink.Service.Infrastructure
{
	// Token: 0x02000006 RID: 6
	public interface IServiceManager
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600003B RID: 59
		// (set) Token: 0x0600003C RID: 60
		string EnabledSettingName { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600003D RID: 61
		// (set) Token: 0x0600003E RID: 62
		string PreviousLogFileSettingName { get; set; }

		// Token: 0x17000017 RID: 23
		// (set) Token: 0x0600003F RID: 63
		ManualResetEvent ExitEvent { set; }

		// Token: 0x17000018 RID: 24
		// (set) Token: 0x06000040 RID: 64
		WindowsIdentity InvokerIdentity { set; }

		// Token: 0x17000019 RID: 25
		// (set) Token: 0x06000041 RID: 65
		string InvokerScheme { set; }

		// Token: 0x1700001A RID: 26
		// (set) Token: 0x06000042 RID: 66
		IDictionary InvokerEnvironment { set; }

		// Token: 0x06000043 RID: 67
		ServiceHost CreateServiceHost();

		// Token: 0x06000044 RID: 68
		void OnStart();

		// Token: 0x06000045 RID: 69
		void OnStop();
	}
}
