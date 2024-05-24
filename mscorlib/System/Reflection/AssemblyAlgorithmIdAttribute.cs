using System;
using System.Configuration.Assemblies;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005C1 RID: 1473
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	public sealed class AssemblyAlgorithmIdAttribute : Attribute
	{
		// Token: 0x06004468 RID: 17512 RVA: 0x000FC414 File Offset: 0x000FA614
		public AssemblyAlgorithmIdAttribute(AssemblyHashAlgorithm algorithmId)
		{
			this.m_algId = (uint)algorithmId;
		}

		// Token: 0x06004469 RID: 17513 RVA: 0x000FC423 File Offset: 0x000FA623
		[CLSCompliant(false)]
		public AssemblyAlgorithmIdAttribute(uint algorithmId)
		{
			this.m_algId = algorithmId;
		}

		// Token: 0x17000A1D RID: 2589
		// (get) Token: 0x0600446A RID: 17514 RVA: 0x000FC432 File Offset: 0x000FA632
		[CLSCompliant(false)]
		public uint AlgorithmId
		{
			get
			{
				return this.m_algId;
			}
		}

		// Token: 0x04001C04 RID: 7172
		private uint m_algId;
	}
}
