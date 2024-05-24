using System;
using System.Collections.Generic;
using System.Reflection;

namespace System.Security.Policy
{
	// Token: 0x0200033F RID: 831
	internal sealed class AppDomainEvidenceFactory : IRuntimeEvidenceFactory
	{
		// Token: 0x06002963 RID: 10595 RVA: 0x00098EB4 File Offset: 0x000970B4
		internal AppDomainEvidenceFactory(AppDomain target)
		{
			this.m_targetDomain = target;
		}

		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x06002964 RID: 10596 RVA: 0x00098EC3 File Offset: 0x000970C3
		public IEvidenceFactory Target
		{
			get
			{
				return this.m_targetDomain;
			}
		}

		// Token: 0x06002965 RID: 10597 RVA: 0x00098ECB File Offset: 0x000970CB
		public IEnumerable<EvidenceBase> GetFactorySuppliedEvidence()
		{
			return new EvidenceBase[0];
		}

		// Token: 0x06002966 RID: 10598 RVA: 0x00098ED4 File Offset: 0x000970D4
		[SecuritySafeCritical]
		public EvidenceBase GenerateEvidence(Type evidenceType)
		{
			if (!this.m_targetDomain.IsDefaultAppDomain())
			{
				AppDomain defaultDomain = AppDomain.GetDefaultDomain();
				return defaultDomain.GetHostEvidence(evidenceType);
			}
			if (this.m_entryPointEvidence == null)
			{
				Assembly entryAssembly = Assembly.GetEntryAssembly();
				RuntimeAssembly runtimeAssembly = entryAssembly as RuntimeAssembly;
				if (runtimeAssembly != null)
				{
					this.m_entryPointEvidence = runtimeAssembly.EvidenceNoDemand.Clone();
				}
				else if (entryAssembly != null)
				{
					this.m_entryPointEvidence = entryAssembly.Evidence;
				}
			}
			if (this.m_entryPointEvidence != null)
			{
				return this.m_entryPointEvidence.GetHostEvidence(evidenceType);
			}
			return null;
		}

		// Token: 0x04001100 RID: 4352
		private AppDomain m_targetDomain;

		// Token: 0x04001101 RID: 4353
		private Evidence m_entryPointEvidence;
	}
}
