using System;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006AA RID: 1706
	internal enum StoreTransactionOperationType
	{
		// Token: 0x04002253 RID: 8787
		Invalid,
		// Token: 0x04002254 RID: 8788
		SetCanonicalizationContext = 14,
		// Token: 0x04002255 RID: 8789
		StageComponent = 20,
		// Token: 0x04002256 RID: 8790
		PinDeployment,
		// Token: 0x04002257 RID: 8791
		UnpinDeployment,
		// Token: 0x04002258 RID: 8792
		StageComponentFile,
		// Token: 0x04002259 RID: 8793
		InstallDeployment,
		// Token: 0x0400225A RID: 8794
		UninstallDeployment,
		// Token: 0x0400225B RID: 8795
		SetDeploymentMetadata,
		// Token: 0x0400225C RID: 8796
		Scavenge
	}
}
