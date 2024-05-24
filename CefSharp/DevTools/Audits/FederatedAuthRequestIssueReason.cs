using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200042A RID: 1066
	public enum FederatedAuthRequestIssueReason
	{
		// Token: 0x040010AB RID: 4267
		[EnumMember(Value = "ApprovalDeclined")]
		ApprovalDeclined,
		// Token: 0x040010AC RID: 4268
		[EnumMember(Value = "TooManyRequests")]
		TooManyRequests,
		// Token: 0x040010AD RID: 4269
		[EnumMember(Value = "ManifestHttpNotFound")]
		ManifestHttpNotFound,
		// Token: 0x040010AE RID: 4270
		[EnumMember(Value = "ManifestNoResponse")]
		ManifestNoResponse,
		// Token: 0x040010AF RID: 4271
		[EnumMember(Value = "ManifestInvalidResponse")]
		ManifestInvalidResponse,
		// Token: 0x040010B0 RID: 4272
		[EnumMember(Value = "ClientMetadataHttpNotFound")]
		ClientMetadataHttpNotFound,
		// Token: 0x040010B1 RID: 4273
		[EnumMember(Value = "ClientMetadataNoResponse")]
		ClientMetadataNoResponse,
		// Token: 0x040010B2 RID: 4274
		[EnumMember(Value = "ClientMetadataInvalidResponse")]
		ClientMetadataInvalidResponse,
		// Token: 0x040010B3 RID: 4275
		[EnumMember(Value = "ErrorFetchingSignin")]
		ErrorFetchingSignin,
		// Token: 0x040010B4 RID: 4276
		[EnumMember(Value = "InvalidSigninResponse")]
		InvalidSigninResponse,
		// Token: 0x040010B5 RID: 4277
		[EnumMember(Value = "AccountsHttpNotFound")]
		AccountsHttpNotFound,
		// Token: 0x040010B6 RID: 4278
		[EnumMember(Value = "AccountsNoResponse")]
		AccountsNoResponse,
		// Token: 0x040010B7 RID: 4279
		[EnumMember(Value = "AccountsInvalidResponse")]
		AccountsInvalidResponse,
		// Token: 0x040010B8 RID: 4280
		[EnumMember(Value = "IdTokenHttpNotFound")]
		IdTokenHttpNotFound,
		// Token: 0x040010B9 RID: 4281
		[EnumMember(Value = "IdTokenNoResponse")]
		IdTokenNoResponse,
		// Token: 0x040010BA RID: 4282
		[EnumMember(Value = "IdTokenInvalidResponse")]
		IdTokenInvalidResponse,
		// Token: 0x040010BB RID: 4283
		[EnumMember(Value = "IdTokenInvalidRequest")]
		IdTokenInvalidRequest,
		// Token: 0x040010BC RID: 4284
		[EnumMember(Value = "ErrorIdToken")]
		ErrorIdToken,
		// Token: 0x040010BD RID: 4285
		[EnumMember(Value = "Canceled")]
		Canceled
	}
}
