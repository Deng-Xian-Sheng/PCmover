﻿using System;
using System.Deployment.Internal.Isolation.Manifest;
using System.Reflection;
using System.Runtime.Hosting;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Policy;

namespace System.Security
{
	// Token: 0x020001D9 RID: 473
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	[Serializable]
	public class HostSecurityManager
	{
		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06001C9C RID: 7324 RVA: 0x0006209C File Offset: 0x0006029C
		public virtual HostSecurityManagerOptions Flags
		{
			get
			{
				return HostSecurityManagerOptions.AllFlags;
			}
		}

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06001C9D RID: 7325 RVA: 0x000620A0 File Offset: 0x000602A0
		[Obsolete("AppDomain policy levels are obsolete and will be removed in a future release of the .NET Framework. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		public virtual PolicyLevel DomainPolicy
		{
			get
			{
				if (!AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled)
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_RequiresCasPolicyExplicit"));
				}
				return null;
			}
		}

		// Token: 0x06001C9E RID: 7326 RVA: 0x000620BF File Offset: 0x000602BF
		public virtual Evidence ProvideAppDomainEvidence(Evidence inputEvidence)
		{
			return inputEvidence;
		}

		// Token: 0x06001C9F RID: 7327 RVA: 0x000620C2 File Offset: 0x000602C2
		public virtual Evidence ProvideAssemblyEvidence(Assembly loadedAssembly, Evidence inputEvidence)
		{
			return inputEvidence;
		}

		// Token: 0x06001CA0 RID: 7328 RVA: 0x000620C8 File Offset: 0x000602C8
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Assert, Unrestricted = true)]
		public virtual ApplicationTrust DetermineApplicationTrust(Evidence applicationEvidence, Evidence activatorEvidence, TrustManagerContext context)
		{
			if (applicationEvidence == null)
			{
				throw new ArgumentNullException("applicationEvidence");
			}
			ActivationArguments hostEvidence = applicationEvidence.GetHostEvidence<ActivationArguments>();
			if (hostEvidence == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Policy_MissingActivationContextInAppEvidence"));
			}
			ActivationContext activationContext = hostEvidence.ActivationContext;
			if (activationContext == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Policy_MissingActivationContextInAppEvidence"));
			}
			ApplicationTrust applicationTrust = applicationEvidence.GetHostEvidence<ApplicationTrust>();
			if (applicationTrust != null && !CmsUtils.CompareIdentities(applicationTrust.ApplicationIdentity, hostEvidence.ApplicationIdentity, ApplicationVersionMatch.MatchExactVersion))
			{
				applicationTrust = null;
			}
			if (applicationTrust == null)
			{
				if (AppDomain.CurrentDomain.ApplicationTrust != null && CmsUtils.CompareIdentities(AppDomain.CurrentDomain.ApplicationTrust.ApplicationIdentity, hostEvidence.ApplicationIdentity, ApplicationVersionMatch.MatchExactVersion))
				{
					applicationTrust = AppDomain.CurrentDomain.ApplicationTrust;
				}
				else
				{
					applicationTrust = ApplicationSecurityManager.DetermineApplicationTrustInternal(activationContext, context);
				}
			}
			ApplicationSecurityInfo applicationSecurityInfo = new ApplicationSecurityInfo(activationContext);
			if (applicationTrust != null && applicationTrust.IsApplicationTrustedToRun && !applicationSecurityInfo.DefaultRequestSet.IsSubsetOf(applicationTrust.DefaultGrantSet.PermissionSet))
			{
				throw new InvalidOperationException(Environment.GetResourceString("Policy_AppTrustMustGrantAppRequest"));
			}
			return applicationTrust;
		}

		// Token: 0x06001CA1 RID: 7329 RVA: 0x000621B4 File Offset: 0x000603B4
		public virtual PermissionSet ResolvePolicy(Evidence evidence)
		{
			if (evidence == null)
			{
				throw new ArgumentNullException("evidence");
			}
			if (evidence.GetHostEvidence<GacInstalled>() != null)
			{
				return new PermissionSet(PermissionState.Unrestricted);
			}
			if (AppDomain.CurrentDomain.IsHomogenous)
			{
				return AppDomain.CurrentDomain.GetHomogenousGrantSet(evidence);
			}
			if (!AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled)
			{
				return new PermissionSet(PermissionState.Unrestricted);
			}
			return SecurityManager.PolicyManager.CodeGroupResolve(evidence, false);
		}

		// Token: 0x06001CA2 RID: 7330 RVA: 0x00062215 File Offset: 0x00060415
		public virtual Type[] GetHostSuppliedAppDomainEvidenceTypes()
		{
			return null;
		}

		// Token: 0x06001CA3 RID: 7331 RVA: 0x00062218 File Offset: 0x00060418
		public virtual Type[] GetHostSuppliedAssemblyEvidenceTypes(Assembly assembly)
		{
			return null;
		}

		// Token: 0x06001CA4 RID: 7332 RVA: 0x0006221B File Offset: 0x0006041B
		public virtual EvidenceBase GenerateAppDomainEvidence(Type evidenceType)
		{
			return null;
		}

		// Token: 0x06001CA5 RID: 7333 RVA: 0x0006221E File Offset: 0x0006041E
		public virtual EvidenceBase GenerateAssemblyEvidence(Type evidenceType, Assembly assembly)
		{
			return null;
		}
	}
}
