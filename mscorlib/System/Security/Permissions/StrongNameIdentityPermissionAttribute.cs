using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002FA RID: 762
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class StrongNameIdentityPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x060026DA RID: 9946 RVA: 0x0008CD0A File Offset: 0x0008AF0A
		public StrongNameIdentityPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x060026DB RID: 9947 RVA: 0x0008CD13 File Offset: 0x0008AF13
		// (set) Token: 0x060026DC RID: 9948 RVA: 0x0008CD1B File Offset: 0x0008AF1B
		public string Name
		{
			get
			{
				return this.m_name;
			}
			set
			{
				this.m_name = value;
			}
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x060026DD RID: 9949 RVA: 0x0008CD24 File Offset: 0x0008AF24
		// (set) Token: 0x060026DE RID: 9950 RVA: 0x0008CD2C File Offset: 0x0008AF2C
		public string Version
		{
			get
			{
				return this.m_version;
			}
			set
			{
				this.m_version = value;
			}
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x060026DF RID: 9951 RVA: 0x0008CD35 File Offset: 0x0008AF35
		// (set) Token: 0x060026E0 RID: 9952 RVA: 0x0008CD3D File Offset: 0x0008AF3D
		public string PublicKey
		{
			get
			{
				return this.m_blob;
			}
			set
			{
				this.m_blob = value;
			}
		}

		// Token: 0x060026E1 RID: 9953 RVA: 0x0008CD48 File Offset: 0x0008AF48
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new StrongNameIdentityPermission(PermissionState.Unrestricted);
			}
			if (this.m_blob == null && this.m_name == null && this.m_version == null)
			{
				return new StrongNameIdentityPermission(PermissionState.None);
			}
			if (this.m_blob == null)
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentNull_Key"));
			}
			StrongNamePublicKeyBlob blob = new StrongNamePublicKeyBlob(this.m_blob);
			if (this.m_version == null || this.m_version.Equals(string.Empty))
			{
				return new StrongNameIdentityPermission(blob, this.m_name, null);
			}
			return new StrongNameIdentityPermission(blob, this.m_name, new Version(this.m_version));
		}

		// Token: 0x04000EFF RID: 3839
		private string m_name;

		// Token: 0x04000F00 RID: 3840
		private string m_version;

		// Token: 0x04000F01 RID: 3841
		private string m_blob;
	}
}
