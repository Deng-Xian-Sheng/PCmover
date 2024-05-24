using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x0200026C RID: 620
	[ComVisible(true)]
	public interface ICspAsymmetricAlgorithm
	{
		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06002203 RID: 8707
		CspKeyContainerInfo CspKeyContainerInfo { get; }

		// Token: 0x06002204 RID: 8708
		byte[] ExportCspBlob(bool includePrivateParameters);

		// Token: 0x06002205 RID: 8709
		void ImportCspBlob(byte[] rawData);
	}
}
