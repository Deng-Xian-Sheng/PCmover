using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x0200060E RID: 1550
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
	[ComVisible(true)]
	public sealed class ObfuscateAssemblyAttribute : Attribute
	{
		// Token: 0x060047E9 RID: 18409 RVA: 0x00105CC4 File Offset: 0x00103EC4
		public ObfuscateAssemblyAttribute(bool assemblyIsPrivate)
		{
			this.m_assemblyIsPrivate = assemblyIsPrivate;
		}

		// Token: 0x17000B10 RID: 2832
		// (get) Token: 0x060047EA RID: 18410 RVA: 0x00105CDA File Offset: 0x00103EDA
		public bool AssemblyIsPrivate
		{
			get
			{
				return this.m_assemblyIsPrivate;
			}
		}

		// Token: 0x17000B11 RID: 2833
		// (get) Token: 0x060047EB RID: 18411 RVA: 0x00105CE2 File Offset: 0x00103EE2
		// (set) Token: 0x060047EC RID: 18412 RVA: 0x00105CEA File Offset: 0x00103EEA
		public bool StripAfterObfuscation
		{
			get
			{
				return this.m_strip;
			}
			set
			{
				this.m_strip = value;
			}
		}

		// Token: 0x04001DBC RID: 7612
		private bool m_assemblyIsPrivate;

		// Token: 0x04001DBD RID: 7613
		private bool m_strip = true;
	}
}
