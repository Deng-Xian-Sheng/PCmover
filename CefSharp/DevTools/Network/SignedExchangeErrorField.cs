using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002D0 RID: 720
	public enum SignedExchangeErrorField
	{
		// Token: 0x04000BE1 RID: 3041
		[EnumMember(Value = "signatureSig")]
		SignatureSig,
		// Token: 0x04000BE2 RID: 3042
		[EnumMember(Value = "signatureIntegrity")]
		SignatureIntegrity,
		// Token: 0x04000BE3 RID: 3043
		[EnumMember(Value = "signatureCertUrl")]
		SignatureCertUrl,
		// Token: 0x04000BE4 RID: 3044
		[EnumMember(Value = "signatureCertSha256")]
		SignatureCertSha256,
		// Token: 0x04000BE5 RID: 3045
		[EnumMember(Value = "signatureValidityUrl")]
		SignatureValidityUrl,
		// Token: 0x04000BE6 RID: 3046
		[EnumMember(Value = "signatureTimestamps")]
		SignatureTimestamps
	}
}
