using System;

namespace System.Security.Cryptography
{
	// Token: 0x0200029F RID: 671
	internal class DSASignatureDescription : SignatureDescription
	{
		// Token: 0x06002387 RID: 9095 RVA: 0x000807A6 File Offset: 0x0007E9A6
		public DSASignatureDescription()
		{
			base.KeyAlgorithm = "System.Security.Cryptography.DSACryptoServiceProvider";
			base.DigestAlgorithm = "System.Security.Cryptography.SHA1CryptoServiceProvider";
			base.FormatterAlgorithm = "System.Security.Cryptography.DSASignatureFormatter";
			base.DeformatterAlgorithm = "System.Security.Cryptography.DSASignatureDeformatter";
		}
	}
}
