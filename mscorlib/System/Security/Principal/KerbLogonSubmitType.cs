using System;

namespace System.Security.Principal
{
	// Token: 0x0200032C RID: 812
	[Serializable]
	internal enum KerbLogonSubmitType
	{
		// Token: 0x0400103E RID: 4158
		KerbInteractiveLogon = 2,
		// Token: 0x0400103F RID: 4159
		KerbSmartCardLogon = 6,
		// Token: 0x04001040 RID: 4160
		KerbWorkstationUnlockLogon,
		// Token: 0x04001041 RID: 4161
		KerbSmartCardUnlockLogon,
		// Token: 0x04001042 RID: 4162
		KerbProxyLogon,
		// Token: 0x04001043 RID: 4163
		KerbTicketLogon,
		// Token: 0x04001044 RID: 4164
		KerbTicketUnlockLogon,
		// Token: 0x04001045 RID: 4165
		KerbS4ULogon
	}
}
