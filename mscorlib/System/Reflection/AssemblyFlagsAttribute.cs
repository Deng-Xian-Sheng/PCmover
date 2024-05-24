using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005C2 RID: 1474
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyFlagsAttribute : Attribute
	{
		// Token: 0x0600446B RID: 17515 RVA: 0x000FC43A File Offset: 0x000FA63A
		[Obsolete("This constructor has been deprecated. Please use AssemblyFlagsAttribute(AssemblyNameFlags) instead. http://go.microsoft.com/fwlink/?linkid=14202")]
		[CLSCompliant(false)]
		public AssemblyFlagsAttribute(uint flags)
		{
			this.m_flags = (AssemblyNameFlags)flags;
		}

		// Token: 0x17000A1E RID: 2590
		// (get) Token: 0x0600446C RID: 17516 RVA: 0x000FC449 File Offset: 0x000FA649
		[Obsolete("This property has been deprecated. Please use AssemblyFlags instead. http://go.microsoft.com/fwlink/?linkid=14202")]
		[CLSCompliant(false)]
		public uint Flags
		{
			get
			{
				return (uint)this.m_flags;
			}
		}

		// Token: 0x17000A1F RID: 2591
		// (get) Token: 0x0600446D RID: 17517 RVA: 0x000FC451 File Offset: 0x000FA651
		[__DynamicallyInvokable]
		public int AssemblyFlags
		{
			[__DynamicallyInvokable]
			get
			{
				return (int)this.m_flags;
			}
		}

		// Token: 0x0600446E RID: 17518 RVA: 0x000FC459 File Offset: 0x000FA659
		[Obsolete("This constructor has been deprecated. Please use AssemblyFlagsAttribute(AssemblyNameFlags) instead. http://go.microsoft.com/fwlink/?linkid=14202")]
		public AssemblyFlagsAttribute(int assemblyFlags)
		{
			this.m_flags = (AssemblyNameFlags)assemblyFlags;
		}

		// Token: 0x0600446F RID: 17519 RVA: 0x000FC468 File Offset: 0x000FA668
		[__DynamicallyInvokable]
		public AssemblyFlagsAttribute(AssemblyNameFlags assemblyFlags)
		{
			this.m_flags = assemblyFlags;
		}

		// Token: 0x04001C05 RID: 7173
		private AssemblyNameFlags m_flags;
	}
}
