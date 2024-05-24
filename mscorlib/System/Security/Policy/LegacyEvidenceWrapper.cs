using System;
using System.Security.Permissions;

namespace System.Security.Policy
{
	// Token: 0x0200034F RID: 847
	[Serializable]
	internal sealed class LegacyEvidenceWrapper : EvidenceBase, ILegacyEvidenceAdapter
	{
		// Token: 0x06002A3B RID: 10811 RVA: 0x0009CA94 File Offset: 0x0009AC94
		internal LegacyEvidenceWrapper(object legacyEvidence)
		{
			this.m_legacyEvidence = legacyEvidence;
		}

		// Token: 0x17000595 RID: 1429
		// (get) Token: 0x06002A3C RID: 10812 RVA: 0x0009CAA3 File Offset: 0x0009ACA3
		public object EvidenceObject
		{
			get
			{
				return this.m_legacyEvidence;
			}
		}

		// Token: 0x17000596 RID: 1430
		// (get) Token: 0x06002A3D RID: 10813 RVA: 0x0009CAAB File Offset: 0x0009ACAB
		public Type EvidenceType
		{
			get
			{
				return this.m_legacyEvidence.GetType();
			}
		}

		// Token: 0x06002A3E RID: 10814 RVA: 0x0009CAB8 File Offset: 0x0009ACB8
		public override bool Equals(object obj)
		{
			return this.m_legacyEvidence.Equals(obj);
		}

		// Token: 0x06002A3F RID: 10815 RVA: 0x0009CAC6 File Offset: 0x0009ACC6
		public override int GetHashCode()
		{
			return this.m_legacyEvidence.GetHashCode();
		}

		// Token: 0x06002A40 RID: 10816 RVA: 0x0009CAD3 File Offset: 0x0009ACD3
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		public override EvidenceBase Clone()
		{
			return base.Clone();
		}

		// Token: 0x04001135 RID: 4405
		private object m_legacyEvidence;
	}
}
