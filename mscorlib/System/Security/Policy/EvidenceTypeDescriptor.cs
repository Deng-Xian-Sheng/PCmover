using System;

namespace System.Security.Policy
{
	// Token: 0x02000351 RID: 849
	[Serializable]
	internal sealed class EvidenceTypeDescriptor
	{
		// Token: 0x06002A48 RID: 10824 RVA: 0x0009CB83 File Offset: 0x0009AD83
		public EvidenceTypeDescriptor()
		{
		}

		// Token: 0x06002A49 RID: 10825 RVA: 0x0009CB8C File Offset: 0x0009AD8C
		private EvidenceTypeDescriptor(EvidenceTypeDescriptor descriptor)
		{
			this.m_hostCanGenerate = descriptor.m_hostCanGenerate;
			if (descriptor.m_assemblyEvidence != null)
			{
				this.m_assemblyEvidence = descriptor.m_assemblyEvidence.Clone();
			}
			if (descriptor.m_hostEvidence != null)
			{
				this.m_hostEvidence = descriptor.m_hostEvidence.Clone();
			}
		}

		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x06002A4A RID: 10826 RVA: 0x0009CBDD File Offset: 0x0009ADDD
		// (set) Token: 0x06002A4B RID: 10827 RVA: 0x0009CBE5 File Offset: 0x0009ADE5
		public EvidenceBase AssemblyEvidence
		{
			get
			{
				return this.m_assemblyEvidence;
			}
			set
			{
				this.m_assemblyEvidence = value;
			}
		}

		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x06002A4C RID: 10828 RVA: 0x0009CBEE File Offset: 0x0009ADEE
		// (set) Token: 0x06002A4D RID: 10829 RVA: 0x0009CBF6 File Offset: 0x0009ADF6
		public bool Generated
		{
			get
			{
				return this.m_generated;
			}
			set
			{
				this.m_generated = value;
			}
		}

		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x06002A4E RID: 10830 RVA: 0x0009CBFF File Offset: 0x0009ADFF
		// (set) Token: 0x06002A4F RID: 10831 RVA: 0x0009CC07 File Offset: 0x0009AE07
		public bool HostCanGenerate
		{
			get
			{
				return this.m_hostCanGenerate;
			}
			set
			{
				this.m_hostCanGenerate = value;
			}
		}

		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x06002A50 RID: 10832 RVA: 0x0009CC10 File Offset: 0x0009AE10
		// (set) Token: 0x06002A51 RID: 10833 RVA: 0x0009CC18 File Offset: 0x0009AE18
		public EvidenceBase HostEvidence
		{
			get
			{
				return this.m_hostEvidence;
			}
			set
			{
				this.m_hostEvidence = value;
			}
		}

		// Token: 0x06002A52 RID: 10834 RVA: 0x0009CC21 File Offset: 0x0009AE21
		public EvidenceTypeDescriptor Clone()
		{
			return new EvidenceTypeDescriptor(this);
		}

		// Token: 0x04001137 RID: 4407
		[NonSerialized]
		private bool m_hostCanGenerate;

		// Token: 0x04001138 RID: 4408
		[NonSerialized]
		private bool m_generated;

		// Token: 0x04001139 RID: 4409
		private EvidenceBase m_hostEvidence;

		// Token: 0x0400113A RID: 4410
		private EvidenceBase m_assemblyEvidence;
	}
}
