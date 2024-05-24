using System;

namespace CefSharp
{
	// Token: 0x0200002F RID: 47
	[Flags]
	public enum CertStatus
	{
		// Token: 0x0400018A RID: 394
		None = 0,
		// Token: 0x0400018B RID: 395
		CommonNameInvalid = 1,
		// Token: 0x0400018C RID: 396
		DateInvalid = 2,
		// Token: 0x0400018D RID: 397
		AuthorityInvalid = 4,
		// Token: 0x0400018E RID: 398
		NoRevocation_Mechanism = 16,
		// Token: 0x0400018F RID: 399
		UnableToCheckRevocation = 32,
		// Token: 0x04000190 RID: 400
		Revoked = 64,
		// Token: 0x04000191 RID: 401
		Invalid = 128,
		// Token: 0x04000192 RID: 402
		WeakSignatureAlgorithm = 256,
		// Token: 0x04000193 RID: 403
		NonUniqueName = 1024,
		// Token: 0x04000194 RID: 404
		WeakKey = 2048,
		// Token: 0x04000195 RID: 405
		PinnedKeyMissing = 8192,
		// Token: 0x04000196 RID: 406
		NameConstraintViolation = 16384,
		// Token: 0x04000197 RID: 407
		ValidityTooLong = 32768,
		// Token: 0x04000198 RID: 408
		IsEv = 65536,
		// Token: 0x04000199 RID: 409
		RevCheckingEnabled = 131072,
		// Token: 0x0400019A RID: 410
		Sha1SignaturePresent = 524288,
		// Token: 0x0400019B RID: 411
		CtComplianceFailed = 1048576
	}
}
