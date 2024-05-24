using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002F8 RID: 760
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class UIPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x060026D0 RID: 9936 RVA: 0x0008CC80 File Offset: 0x0008AE80
		public UIPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x060026D1 RID: 9937 RVA: 0x0008CC89 File Offset: 0x0008AE89
		// (set) Token: 0x060026D2 RID: 9938 RVA: 0x0008CC91 File Offset: 0x0008AE91
		public UIPermissionWindow Window
		{
			get
			{
				return this.m_windowFlag;
			}
			set
			{
				this.m_windowFlag = value;
			}
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x060026D3 RID: 9939 RVA: 0x0008CC9A File Offset: 0x0008AE9A
		// (set) Token: 0x060026D4 RID: 9940 RVA: 0x0008CCA2 File Offset: 0x0008AEA2
		public UIPermissionClipboard Clipboard
		{
			get
			{
				return this.m_clipboardFlag;
			}
			set
			{
				this.m_clipboardFlag = value;
			}
		}

		// Token: 0x060026D5 RID: 9941 RVA: 0x0008CCAB File Offset: 0x0008AEAB
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new UIPermission(PermissionState.Unrestricted);
			}
			return new UIPermission(this.m_windowFlag, this.m_clipboardFlag);
		}

		// Token: 0x04000EFC RID: 3836
		private UIPermissionWindow m_windowFlag;

		// Token: 0x04000EFD RID: 3837
		private UIPermissionClipboard m_clipboardFlag;
	}
}
