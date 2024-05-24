using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008B3 RID: 2227
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Method)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class CompilationRelaxationsAttribute : Attribute
	{
		// Token: 0x06005D9F RID: 23967 RVA: 0x0014968C File Offset: 0x0014788C
		[__DynamicallyInvokable]
		public CompilationRelaxationsAttribute(int relaxations)
		{
			this.m_relaxations = relaxations;
		}

		// Token: 0x06005DA0 RID: 23968 RVA: 0x0014969B File Offset: 0x0014789B
		public CompilationRelaxationsAttribute(CompilationRelaxations relaxations)
		{
			this.m_relaxations = (int)relaxations;
		}

		// Token: 0x17001013 RID: 4115
		// (get) Token: 0x06005DA1 RID: 23969 RVA: 0x001496AA File Offset: 0x001478AA
		[__DynamicallyInvokable]
		public int CompilationRelaxations
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_relaxations;
			}
		}

		// Token: 0x04002A0E RID: 10766
		private int m_relaxations;
	}
}
