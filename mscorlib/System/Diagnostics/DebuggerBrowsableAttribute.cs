using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	// Token: 0x020003EC RID: 1004
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class DebuggerBrowsableAttribute : Attribute
	{
		// Token: 0x0600330B RID: 13067 RVA: 0x000C4BCA File Offset: 0x000C2DCA
		[__DynamicallyInvokable]
		public DebuggerBrowsableAttribute(DebuggerBrowsableState state)
		{
			if (state < DebuggerBrowsableState.Never || state > DebuggerBrowsableState.RootHidden)
			{
				throw new ArgumentOutOfRangeException("state");
			}
			this.state = state;
		}

		// Token: 0x17000775 RID: 1909
		// (get) Token: 0x0600330C RID: 13068 RVA: 0x000C4BEC File Offset: 0x000C2DEC
		[__DynamicallyInvokable]
		public DebuggerBrowsableState State
		{
			[__DynamicallyInvokable]
			get
			{
				return this.state;
			}
		}

		// Token: 0x040016A0 RID: 5792
		private DebuggerBrowsableState state;
	}
}
