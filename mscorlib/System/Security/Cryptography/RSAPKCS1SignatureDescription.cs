using System;

namespace System.Security.Cryptography
{
	// Token: 0x0200029A RID: 666
	internal abstract class RSAPKCS1SignatureDescription : SignatureDescription
	{
		// Token: 0x06002380 RID: 9088 RVA: 0x000806E0 File Offset: 0x0007E8E0
		protected RSAPKCS1SignatureDescription(string hashAlgorithm, string digestAlgorithm)
		{
			base.KeyAlgorithm = "System.Security.Cryptography.RSA";
			base.DigestAlgorithm = digestAlgorithm;
			base.FormatterAlgorithm = "System.Security.Cryptography.RSAPKCS1SignatureFormatter";
			base.DeformatterAlgorithm = "System.Security.Cryptography.RSAPKCS1SignatureDeformatter";
			this._hashAlgorithm = hashAlgorithm;
		}

		// Token: 0x06002381 RID: 9089 RVA: 0x00080718 File Offset: 0x0007E918
		public sealed override AsymmetricSignatureDeformatter CreateDeformatter(AsymmetricAlgorithm key)
		{
			AsymmetricSignatureDeformatter asymmetricSignatureDeformatter = base.CreateDeformatter(key);
			asymmetricSignatureDeformatter.SetHashAlgorithm(this._hashAlgorithm);
			return asymmetricSignatureDeformatter;
		}

		// Token: 0x06002382 RID: 9090 RVA: 0x0008073C File Offset: 0x0007E93C
		public sealed override AsymmetricSignatureFormatter CreateFormatter(AsymmetricAlgorithm key)
		{
			AsymmetricSignatureFormatter asymmetricSignatureFormatter = base.CreateFormatter(key);
			asymmetricSignatureFormatter.SetHashAlgorithm(this._hashAlgorithm);
			return asymmetricSignatureFormatter;
		}

		// Token: 0x04000CE7 RID: 3303
		private string _hashAlgorithm;
	}
}
