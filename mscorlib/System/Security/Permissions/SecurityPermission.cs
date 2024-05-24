using System;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Permissions
{
	// Token: 0x02000306 RID: 774
	[ComVisible(true)]
	[Serializable]
	public sealed class SecurityPermission : CodeAccessPermission, IUnrestrictedPermission, IBuiltInPermission
	{
		// Token: 0x06002731 RID: 10033 RVA: 0x0008E049 File Offset: 0x0008C249
		public SecurityPermission(PermissionState state)
		{
			if (state == PermissionState.Unrestricted)
			{
				this.SetUnrestricted(true);
				return;
			}
			if (state == PermissionState.None)
			{
				this.SetUnrestricted(false);
				this.Reset();
				return;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_InvalidPermissionState"));
		}

		// Token: 0x06002732 RID: 10034 RVA: 0x0008E07D File Offset: 0x0008C27D
		public SecurityPermission(SecurityPermissionFlag flag)
		{
			this.VerifyAccess(flag);
			this.SetUnrestricted(false);
			this.m_flags = flag;
		}

		// Token: 0x06002733 RID: 10035 RVA: 0x0008E09A File Offset: 0x0008C29A
		private void SetUnrestricted(bool unrestricted)
		{
			if (unrestricted)
			{
				this.m_flags = SecurityPermissionFlag.AllFlags;
			}
		}

		// Token: 0x06002734 RID: 10036 RVA: 0x0008E0AA File Offset: 0x0008C2AA
		private void Reset()
		{
			this.m_flags = SecurityPermissionFlag.NoFlags;
		}

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06002736 RID: 10038 RVA: 0x0008E0C3 File Offset: 0x0008C2C3
		// (set) Token: 0x06002735 RID: 10037 RVA: 0x0008E0B3 File Offset: 0x0008C2B3
		public SecurityPermissionFlag Flags
		{
			get
			{
				return this.m_flags;
			}
			set
			{
				this.VerifyAccess(value);
				this.m_flags = value;
			}
		}

		// Token: 0x06002737 RID: 10039 RVA: 0x0008E0CC File Offset: 0x0008C2CC
		public override bool IsSubsetOf(IPermission target)
		{
			if (target == null)
			{
				return this.m_flags == SecurityPermissionFlag.NoFlags;
			}
			SecurityPermission securityPermission = target as SecurityPermission;
			if (securityPermission != null)
			{
				return (this.m_flags & ~securityPermission.m_flags) == SecurityPermissionFlag.NoFlags;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
			{
				base.GetType().FullName
			}));
		}

		// Token: 0x06002738 RID: 10040 RVA: 0x0008E128 File Offset: 0x0008C328
		public override IPermission Union(IPermission target)
		{
			if (target == null)
			{
				return this.Copy();
			}
			if (!base.VerifyType(target))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			SecurityPermission securityPermission = (SecurityPermission)target;
			if (securityPermission.IsUnrestricted() || this.IsUnrestricted())
			{
				return new SecurityPermission(PermissionState.Unrestricted);
			}
			SecurityPermissionFlag flag = this.m_flags | securityPermission.m_flags;
			return new SecurityPermission(flag);
		}

		// Token: 0x06002739 RID: 10041 RVA: 0x0008E1A0 File Offset: 0x0008C3A0
		public override IPermission Intersect(IPermission target)
		{
			if (target == null)
			{
				return null;
			}
			if (!base.VerifyType(target))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			SecurityPermission securityPermission = (SecurityPermission)target;
			SecurityPermissionFlag securityPermissionFlag;
			if (securityPermission.IsUnrestricted())
			{
				if (this.IsUnrestricted())
				{
					return new SecurityPermission(PermissionState.Unrestricted);
				}
				securityPermissionFlag = this.m_flags;
			}
			else if (this.IsUnrestricted())
			{
				securityPermissionFlag = securityPermission.m_flags;
			}
			else
			{
				securityPermissionFlag = (this.m_flags & securityPermission.m_flags);
			}
			if (securityPermissionFlag == SecurityPermissionFlag.NoFlags)
			{
				return null;
			}
			return new SecurityPermission(securityPermissionFlag);
		}

		// Token: 0x0600273A RID: 10042 RVA: 0x0008E232 File Offset: 0x0008C432
		public override IPermission Copy()
		{
			if (this.IsUnrestricted())
			{
				return new SecurityPermission(PermissionState.Unrestricted);
			}
			return new SecurityPermission(this.m_flags);
		}

		// Token: 0x0600273B RID: 10043 RVA: 0x0008E24E File Offset: 0x0008C44E
		public bool IsUnrestricted()
		{
			return this.m_flags == SecurityPermissionFlag.AllFlags;
		}

		// Token: 0x0600273C RID: 10044 RVA: 0x0008E25D File Offset: 0x0008C45D
		private void VerifyAccess(SecurityPermissionFlag type)
		{
			if ((type & ~(SecurityPermissionFlag.Assertion | SecurityPermissionFlag.UnmanagedCode | SecurityPermissionFlag.SkipVerification | SecurityPermissionFlag.Execution | SecurityPermissionFlag.ControlThread | SecurityPermissionFlag.ControlEvidence | SecurityPermissionFlag.ControlPolicy | SecurityPermissionFlag.SerializationFormatter | SecurityPermissionFlag.ControlDomainPolicy | SecurityPermissionFlag.ControlPrincipal | SecurityPermissionFlag.ControlAppDomain | SecurityPermissionFlag.RemotingConfiguration | SecurityPermissionFlag.Infrastructure | SecurityPermissionFlag.BindingRedirects)) != SecurityPermissionFlag.NoFlags)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
				{
					(int)type
				}));
			}
		}

		// Token: 0x0600273D RID: 10045 RVA: 0x0008E288 File Offset: 0x0008C488
		public override SecurityElement ToXml()
		{
			SecurityElement securityElement = CodeAccessPermission.CreatePermissionElement(this, "System.Security.Permissions.SecurityPermission");
			if (!this.IsUnrestricted())
			{
				securityElement.AddAttribute("Flags", XMLUtil.BitFieldEnumToString(typeof(SecurityPermissionFlag), this.m_flags));
			}
			else
			{
				securityElement.AddAttribute("Unrestricted", "true");
			}
			return securityElement;
		}

		// Token: 0x0600273E RID: 10046 RVA: 0x0008E2E4 File Offset: 0x0008C4E4
		public override void FromXml(SecurityElement esd)
		{
			CodeAccessPermission.ValidateElement(esd, this);
			if (XMLUtil.IsUnrestricted(esd))
			{
				this.m_flags = SecurityPermissionFlag.AllFlags;
				return;
			}
			this.Reset();
			this.SetUnrestricted(false);
			string text = esd.Attribute("Flags");
			if (text != null)
			{
				this.m_flags = (SecurityPermissionFlag)Enum.Parse(typeof(SecurityPermissionFlag), text);
			}
		}

		// Token: 0x0600273F RID: 10047 RVA: 0x0008E343 File Offset: 0x0008C543
		int IBuiltInPermission.GetTokenIndex()
		{
			return SecurityPermission.GetTokenIndex();
		}

		// Token: 0x06002740 RID: 10048 RVA: 0x0008E34A File Offset: 0x0008C54A
		internal static int GetTokenIndex()
		{
			return 6;
		}

		// Token: 0x04000F2D RID: 3885
		private SecurityPermissionFlag m_flags;

		// Token: 0x04000F2E RID: 3886
		private const string _strHeaderAssertion = "Assertion";

		// Token: 0x04000F2F RID: 3887
		private const string _strHeaderUnmanagedCode = "UnmanagedCode";

		// Token: 0x04000F30 RID: 3888
		private const string _strHeaderExecution = "Execution";

		// Token: 0x04000F31 RID: 3889
		private const string _strHeaderSkipVerification = "SkipVerification";

		// Token: 0x04000F32 RID: 3890
		private const string _strHeaderControlThread = "ControlThread";

		// Token: 0x04000F33 RID: 3891
		private const string _strHeaderControlEvidence = "ControlEvidence";

		// Token: 0x04000F34 RID: 3892
		private const string _strHeaderControlPolicy = "ControlPolicy";

		// Token: 0x04000F35 RID: 3893
		private const string _strHeaderSerializationFormatter = "SerializationFormatter";

		// Token: 0x04000F36 RID: 3894
		private const string _strHeaderControlDomainPolicy = "ControlDomainPolicy";

		// Token: 0x04000F37 RID: 3895
		private const string _strHeaderControlPrincipal = "ControlPrincipal";

		// Token: 0x04000F38 RID: 3896
		private const string _strHeaderControlAppDomain = "ControlAppDomain";
	}
}
