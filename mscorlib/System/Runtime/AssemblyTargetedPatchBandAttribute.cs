using System;

namespace System.Runtime
{
	// Token: 0x02000717 RID: 1815
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public sealed class AssemblyTargetedPatchBandAttribute : Attribute
	{
		// Token: 0x0600512A RID: 20778 RVA: 0x0011E57F File Offset: 0x0011C77F
		public AssemblyTargetedPatchBandAttribute(string targetedPatchBand)
		{
			this.m_targetedPatchBand = targetedPatchBand;
		}

		// Token: 0x17000D59 RID: 3417
		// (get) Token: 0x0600512B RID: 20779 RVA: 0x0011E58E File Offset: 0x0011C78E
		public string TargetedPatchBand
		{
			get
			{
				return this.m_targetedPatchBand;
			}
		}

		// Token: 0x040023F4 RID: 9204
		private string m_targetedPatchBand;
	}
}
