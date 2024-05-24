using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;

namespace System.Security.Policy
{
	// Token: 0x02000350 RID: 848
	[Serializable]
	internal sealed class LegacyEvidenceList : EvidenceBase, IEnumerable<EvidenceBase>, IEnumerable, ILegacyEvidenceAdapter
	{
		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x06002A41 RID: 10817 RVA: 0x0009CADB File Offset: 0x0009ACDB
		public object EvidenceObject
		{
			get
			{
				if (this.m_legacyEvidenceList.Count <= 0)
				{
					return null;
				}
				return this.m_legacyEvidenceList[0];
			}
		}

		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x06002A42 RID: 10818 RVA: 0x0009CAFC File Offset: 0x0009ACFC
		public Type EvidenceType
		{
			get
			{
				ILegacyEvidenceAdapter legacyEvidenceAdapter = this.m_legacyEvidenceList[0] as ILegacyEvidenceAdapter;
				if (legacyEvidenceAdapter != null)
				{
					return legacyEvidenceAdapter.EvidenceType;
				}
				return this.m_legacyEvidenceList[0].GetType();
			}
		}

		// Token: 0x06002A43 RID: 10819 RVA: 0x0009CB36 File Offset: 0x0009AD36
		public void Add(EvidenceBase evidence)
		{
			this.m_legacyEvidenceList.Add(evidence);
		}

		// Token: 0x06002A44 RID: 10820 RVA: 0x0009CB44 File Offset: 0x0009AD44
		public IEnumerator<EvidenceBase> GetEnumerator()
		{
			return this.m_legacyEvidenceList.GetEnumerator();
		}

		// Token: 0x06002A45 RID: 10821 RVA: 0x0009CB56 File Offset: 0x0009AD56
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.m_legacyEvidenceList.GetEnumerator();
		}

		// Token: 0x06002A46 RID: 10822 RVA: 0x0009CB68 File Offset: 0x0009AD68
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		public override EvidenceBase Clone()
		{
			return base.Clone();
		}

		// Token: 0x04001136 RID: 4406
		private List<EvidenceBase> m_legacyEvidenceList = new List<EvidenceBase>();
	}
}
