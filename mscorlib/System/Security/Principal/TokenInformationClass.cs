using System;

namespace System.Security.Principal
{
	// Token: 0x0200032F RID: 815
	[Serializable]
	internal enum TokenInformationClass
	{
		// Token: 0x04001051 RID: 4177
		TokenUser = 1,
		// Token: 0x04001052 RID: 4178
		TokenGroups,
		// Token: 0x04001053 RID: 4179
		TokenPrivileges,
		// Token: 0x04001054 RID: 4180
		TokenOwner,
		// Token: 0x04001055 RID: 4181
		TokenPrimaryGroup,
		// Token: 0x04001056 RID: 4182
		TokenDefaultDacl,
		// Token: 0x04001057 RID: 4183
		TokenSource,
		// Token: 0x04001058 RID: 4184
		TokenType,
		// Token: 0x04001059 RID: 4185
		TokenImpersonationLevel,
		// Token: 0x0400105A RID: 4186
		TokenStatistics,
		// Token: 0x0400105B RID: 4187
		TokenRestrictedSids,
		// Token: 0x0400105C RID: 4188
		TokenSessionId,
		// Token: 0x0400105D RID: 4189
		TokenGroupsAndPrivileges,
		// Token: 0x0400105E RID: 4190
		TokenSessionReference,
		// Token: 0x0400105F RID: 4191
		TokenSandBoxInert,
		// Token: 0x04001060 RID: 4192
		TokenAuditPolicy,
		// Token: 0x04001061 RID: 4193
		TokenOrigin,
		// Token: 0x04001062 RID: 4194
		TokenElevationType,
		// Token: 0x04001063 RID: 4195
		TokenLinkedToken,
		// Token: 0x04001064 RID: 4196
		TokenElevation,
		// Token: 0x04001065 RID: 4197
		TokenHasRestrictions,
		// Token: 0x04001066 RID: 4198
		TokenAccessInformation,
		// Token: 0x04001067 RID: 4199
		TokenVirtualizationAllowed,
		// Token: 0x04001068 RID: 4200
		TokenVirtualizationEnabled,
		// Token: 0x04001069 RID: 4201
		TokenIntegrityLevel,
		// Token: 0x0400106A RID: 4202
		TokenUIAccess,
		// Token: 0x0400106B RID: 4203
		TokenMandatoryPolicy,
		// Token: 0x0400106C RID: 4204
		TokenLogonSid,
		// Token: 0x0400106D RID: 4205
		TokenIsAppContainer,
		// Token: 0x0400106E RID: 4206
		TokenCapabilities,
		// Token: 0x0400106F RID: 4207
		TokenAppContainerSid,
		// Token: 0x04001070 RID: 4208
		TokenAppContainerNumber,
		// Token: 0x04001071 RID: 4209
		TokenUserClaimAttributes,
		// Token: 0x04001072 RID: 4210
		TokenDeviceClaimAttributes,
		// Token: 0x04001073 RID: 4211
		TokenRestrictedUserClaimAttributes,
		// Token: 0x04001074 RID: 4212
		TokenRestrictedDeviceClaimAttributes,
		// Token: 0x04001075 RID: 4213
		TokenDeviceGroups,
		// Token: 0x04001076 RID: 4214
		TokenRestrictedDeviceGroups,
		// Token: 0x04001077 RID: 4215
		MaxTokenInfoClass
	}
}
