using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000299 RID: 665
	[ComVisible(true)]
	public class SignatureDescription
	{
		// Token: 0x06002373 RID: 9075 RVA: 0x000805CC File Offset: 0x0007E7CC
		public SignatureDescription()
		{
		}

		// Token: 0x06002374 RID: 9076 RVA: 0x000805D4 File Offset: 0x0007E7D4
		public SignatureDescription(SecurityElement el)
		{
			if (el == null)
			{
				throw new ArgumentNullException("el");
			}
			this._strKey = el.SearchForTextOfTag("Key");
			this._strDigest = el.SearchForTextOfTag("Digest");
			this._strFormatter = el.SearchForTextOfTag("Formatter");
			this._strDeformatter = el.SearchForTextOfTag("Deformatter");
		}

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x06002375 RID: 9077 RVA: 0x00080639 File Offset: 0x0007E839
		// (set) Token: 0x06002376 RID: 9078 RVA: 0x00080641 File Offset: 0x0007E841
		public string KeyAlgorithm
		{
			get
			{
				return this._strKey;
			}
			set
			{
				this._strKey = value;
			}
		}

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06002377 RID: 9079 RVA: 0x0008064A File Offset: 0x0007E84A
		// (set) Token: 0x06002378 RID: 9080 RVA: 0x00080652 File Offset: 0x0007E852
		public string DigestAlgorithm
		{
			get
			{
				return this._strDigest;
			}
			set
			{
				this._strDigest = value;
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x06002379 RID: 9081 RVA: 0x0008065B File Offset: 0x0007E85B
		// (set) Token: 0x0600237A RID: 9082 RVA: 0x00080663 File Offset: 0x0007E863
		public string FormatterAlgorithm
		{
			get
			{
				return this._strFormatter;
			}
			set
			{
				this._strFormatter = value;
			}
		}

		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x0600237B RID: 9083 RVA: 0x0008066C File Offset: 0x0007E86C
		// (set) Token: 0x0600237C RID: 9084 RVA: 0x00080674 File Offset: 0x0007E874
		public string DeformatterAlgorithm
		{
			get
			{
				return this._strDeformatter;
			}
			set
			{
				this._strDeformatter = value;
			}
		}

		// Token: 0x0600237D RID: 9085 RVA: 0x00080680 File Offset: 0x0007E880
		public virtual AsymmetricSignatureDeformatter CreateDeformatter(AsymmetricAlgorithm key)
		{
			AsymmetricSignatureDeformatter asymmetricSignatureDeformatter = (AsymmetricSignatureDeformatter)CryptoConfig.CreateFromName(this._strDeformatter);
			asymmetricSignatureDeformatter.SetKey(key);
			return asymmetricSignatureDeformatter;
		}

		// Token: 0x0600237E RID: 9086 RVA: 0x000806A8 File Offset: 0x0007E8A8
		public virtual AsymmetricSignatureFormatter CreateFormatter(AsymmetricAlgorithm key)
		{
			AsymmetricSignatureFormatter asymmetricSignatureFormatter = (AsymmetricSignatureFormatter)CryptoConfig.CreateFromName(this._strFormatter);
			asymmetricSignatureFormatter.SetKey(key);
			return asymmetricSignatureFormatter;
		}

		// Token: 0x0600237F RID: 9087 RVA: 0x000806CE File Offset: 0x0007E8CE
		public virtual HashAlgorithm CreateDigest()
		{
			return (HashAlgorithm)CryptoConfig.CreateFromName(this._strDigest);
		}

		// Token: 0x04000CE3 RID: 3299
		private string _strKey;

		// Token: 0x04000CE4 RID: 3300
		private string _strDigest;

		// Token: 0x04000CE5 RID: 3301
		private string _strFormatter;

		// Token: 0x04000CE6 RID: 3302
		private string _strDeformatter;
	}
}
