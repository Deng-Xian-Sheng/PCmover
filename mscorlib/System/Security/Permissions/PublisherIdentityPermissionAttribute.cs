using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Util;

namespace System.Security.Permissions
{
	// Token: 0x020002FD RID: 765
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class PublisherIdentityPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x060026EA RID: 9962 RVA: 0x0008CE70 File Offset: 0x0008B070
		public PublisherIdentityPermissionAttribute(SecurityAction action) : base(action)
		{
			this.m_x509cert = null;
			this.m_certFile = null;
			this.m_signedFile = null;
		}

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x060026EB RID: 9963 RVA: 0x0008CE8E File Offset: 0x0008B08E
		// (set) Token: 0x060026EC RID: 9964 RVA: 0x0008CE96 File Offset: 0x0008B096
		public string X509Certificate
		{
			get
			{
				return this.m_x509cert;
			}
			set
			{
				this.m_x509cert = value;
			}
		}

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x060026ED RID: 9965 RVA: 0x0008CE9F File Offset: 0x0008B09F
		// (set) Token: 0x060026EE RID: 9966 RVA: 0x0008CEA7 File Offset: 0x0008B0A7
		public string CertFile
		{
			get
			{
				return this.m_certFile;
			}
			set
			{
				this.m_certFile = value;
			}
		}

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x060026EF RID: 9967 RVA: 0x0008CEB0 File Offset: 0x0008B0B0
		// (set) Token: 0x060026F0 RID: 9968 RVA: 0x0008CEB8 File Offset: 0x0008B0B8
		public string SignedFile
		{
			get
			{
				return this.m_signedFile;
			}
			set
			{
				this.m_signedFile = value;
			}
		}

		// Token: 0x060026F1 RID: 9969 RVA: 0x0008CEC4 File Offset: 0x0008B0C4
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new PublisherIdentityPermission(PermissionState.Unrestricted);
			}
			if (this.m_x509cert != null)
			{
				return new PublisherIdentityPermission(new X509Certificate(Hex.DecodeHexString(this.m_x509cert)));
			}
			if (this.m_certFile != null)
			{
				return new PublisherIdentityPermission(System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromCertFile(this.m_certFile));
			}
			if (this.m_signedFile != null)
			{
				return new PublisherIdentityPermission(System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromSignedFile(this.m_signedFile));
			}
			return new PublisherIdentityPermission(PermissionState.None);
		}

		// Token: 0x04000F04 RID: 3844
		private string m_x509cert;

		// Token: 0x04000F05 RID: 3845
		private string m_certFile;

		// Token: 0x04000F06 RID: 3846
		private string m_signedFile;
	}
}
