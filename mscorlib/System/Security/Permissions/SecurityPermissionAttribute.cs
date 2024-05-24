using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002F7 RID: 759
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class SecurityPermissionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x060026B0 RID: 9904 RVA: 0x0008C99D File Offset: 0x0008AB9D
		public SecurityPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x060026B1 RID: 9905 RVA: 0x0008C9A6 File Offset: 0x0008ABA6
		// (set) Token: 0x060026B2 RID: 9906 RVA: 0x0008C9AE File Offset: 0x0008ABAE
		public SecurityPermissionFlag Flags
		{
			get
			{
				return this.m_flag;
			}
			set
			{
				this.m_flag = value;
			}
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x060026B3 RID: 9907 RVA: 0x0008C9B7 File Offset: 0x0008ABB7
		// (set) Token: 0x060026B4 RID: 9908 RVA: 0x0008C9C4 File Offset: 0x0008ABC4
		public bool Assertion
		{
			get
			{
				return (this.m_flag & SecurityPermissionFlag.Assertion) > SecurityPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | SecurityPermissionFlag.Assertion) : (this.m_flag & ~SecurityPermissionFlag.Assertion));
			}
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x060026B5 RID: 9909 RVA: 0x0008C9E2 File Offset: 0x0008ABE2
		// (set) Token: 0x060026B6 RID: 9910 RVA: 0x0008C9EF File Offset: 0x0008ABEF
		public bool UnmanagedCode
		{
			get
			{
				return (this.m_flag & SecurityPermissionFlag.UnmanagedCode) > SecurityPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | SecurityPermissionFlag.UnmanagedCode) : (this.m_flag & ~SecurityPermissionFlag.UnmanagedCode));
			}
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x060026B7 RID: 9911 RVA: 0x0008CA0D File Offset: 0x0008AC0D
		// (set) Token: 0x060026B8 RID: 9912 RVA: 0x0008CA1A File Offset: 0x0008AC1A
		public bool SkipVerification
		{
			get
			{
				return (this.m_flag & SecurityPermissionFlag.SkipVerification) > SecurityPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | SecurityPermissionFlag.SkipVerification) : (this.m_flag & ~SecurityPermissionFlag.SkipVerification));
			}
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x060026B9 RID: 9913 RVA: 0x0008CA38 File Offset: 0x0008AC38
		// (set) Token: 0x060026BA RID: 9914 RVA: 0x0008CA45 File Offset: 0x0008AC45
		public bool Execution
		{
			get
			{
				return (this.m_flag & SecurityPermissionFlag.Execution) > SecurityPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | SecurityPermissionFlag.Execution) : (this.m_flag & ~SecurityPermissionFlag.Execution));
			}
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x060026BB RID: 9915 RVA: 0x0008CA63 File Offset: 0x0008AC63
		// (set) Token: 0x060026BC RID: 9916 RVA: 0x0008CA71 File Offset: 0x0008AC71
		public bool ControlThread
		{
			get
			{
				return (this.m_flag & SecurityPermissionFlag.ControlThread) > SecurityPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | SecurityPermissionFlag.ControlThread) : (this.m_flag & ~SecurityPermissionFlag.ControlThread));
			}
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x060026BD RID: 9917 RVA: 0x0008CA90 File Offset: 0x0008AC90
		// (set) Token: 0x060026BE RID: 9918 RVA: 0x0008CA9E File Offset: 0x0008AC9E
		public bool ControlEvidence
		{
			get
			{
				return (this.m_flag & SecurityPermissionFlag.ControlEvidence) > SecurityPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | SecurityPermissionFlag.ControlEvidence) : (this.m_flag & ~SecurityPermissionFlag.ControlEvidence));
			}
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x060026BF RID: 9919 RVA: 0x0008CABD File Offset: 0x0008ACBD
		// (set) Token: 0x060026C0 RID: 9920 RVA: 0x0008CACB File Offset: 0x0008ACCB
		public bool ControlPolicy
		{
			get
			{
				return (this.m_flag & SecurityPermissionFlag.ControlPolicy) > SecurityPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | SecurityPermissionFlag.ControlPolicy) : (this.m_flag & ~SecurityPermissionFlag.ControlPolicy));
			}
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x060026C1 RID: 9921 RVA: 0x0008CAEA File Offset: 0x0008ACEA
		// (set) Token: 0x060026C2 RID: 9922 RVA: 0x0008CAFB File Offset: 0x0008ACFB
		public bool SerializationFormatter
		{
			get
			{
				return (this.m_flag & SecurityPermissionFlag.SerializationFormatter) > SecurityPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | SecurityPermissionFlag.SerializationFormatter) : (this.m_flag & ~SecurityPermissionFlag.SerializationFormatter));
			}
		}

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x060026C3 RID: 9923 RVA: 0x0008CB20 File Offset: 0x0008AD20
		// (set) Token: 0x060026C4 RID: 9924 RVA: 0x0008CB31 File Offset: 0x0008AD31
		public bool ControlDomainPolicy
		{
			get
			{
				return (this.m_flag & SecurityPermissionFlag.ControlDomainPolicy) > SecurityPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | SecurityPermissionFlag.ControlDomainPolicy) : (this.m_flag & ~SecurityPermissionFlag.ControlDomainPolicy));
			}
		}

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x060026C5 RID: 9925 RVA: 0x0008CB56 File Offset: 0x0008AD56
		// (set) Token: 0x060026C6 RID: 9926 RVA: 0x0008CB67 File Offset: 0x0008AD67
		public bool ControlPrincipal
		{
			get
			{
				return (this.m_flag & SecurityPermissionFlag.ControlPrincipal) > SecurityPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | SecurityPermissionFlag.ControlPrincipal) : (this.m_flag & ~SecurityPermissionFlag.ControlPrincipal));
			}
		}

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x060026C7 RID: 9927 RVA: 0x0008CB8C File Offset: 0x0008AD8C
		// (set) Token: 0x060026C8 RID: 9928 RVA: 0x0008CB9D File Offset: 0x0008AD9D
		public bool ControlAppDomain
		{
			get
			{
				return (this.m_flag & SecurityPermissionFlag.ControlAppDomain) > SecurityPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | SecurityPermissionFlag.ControlAppDomain) : (this.m_flag & ~SecurityPermissionFlag.ControlAppDomain));
			}
		}

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x060026C9 RID: 9929 RVA: 0x0008CBC2 File Offset: 0x0008ADC2
		// (set) Token: 0x060026CA RID: 9930 RVA: 0x0008CBD3 File Offset: 0x0008ADD3
		public bool RemotingConfiguration
		{
			get
			{
				return (this.m_flag & SecurityPermissionFlag.RemotingConfiguration) > SecurityPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | SecurityPermissionFlag.RemotingConfiguration) : (this.m_flag & ~SecurityPermissionFlag.RemotingConfiguration));
			}
		}

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x060026CB RID: 9931 RVA: 0x0008CBF8 File Offset: 0x0008ADF8
		// (set) Token: 0x060026CC RID: 9932 RVA: 0x0008CC09 File Offset: 0x0008AE09
		[ComVisible(true)]
		public bool Infrastructure
		{
			get
			{
				return (this.m_flag & SecurityPermissionFlag.Infrastructure) > SecurityPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | SecurityPermissionFlag.Infrastructure) : (this.m_flag & ~SecurityPermissionFlag.Infrastructure));
			}
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x060026CD RID: 9933 RVA: 0x0008CC2E File Offset: 0x0008AE2E
		// (set) Token: 0x060026CE RID: 9934 RVA: 0x0008CC3F File Offset: 0x0008AE3F
		public bool BindingRedirects
		{
			get
			{
				return (this.m_flag & SecurityPermissionFlag.BindingRedirects) > SecurityPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | SecurityPermissionFlag.BindingRedirects) : (this.m_flag & ~SecurityPermissionFlag.BindingRedirects));
			}
		}

		// Token: 0x060026CF RID: 9935 RVA: 0x0008CC64 File Offset: 0x0008AE64
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new SecurityPermission(PermissionState.Unrestricted);
			}
			return new SecurityPermission(this.m_flag);
		}

		// Token: 0x04000EFB RID: 3835
		private SecurityPermissionFlag m_flag;
	}
}
