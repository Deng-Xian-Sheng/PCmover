using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005B3 RID: 1459
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyCopyrightAttribute : Attribute
	{
		// Token: 0x0600444C RID: 17484 RVA: 0x000FC2C4 File Offset: 0x000FA4C4
		[__DynamicallyInvokable]
		public AssemblyCopyrightAttribute(string copyright)
		{
			this.m_copyright = copyright;
		}

		// Token: 0x17000A0F RID: 2575
		// (get) Token: 0x0600444D RID: 17485 RVA: 0x000FC2D3 File Offset: 0x000FA4D3
		[__DynamicallyInvokable]
		public string Copyright
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_copyright;
			}
		}

		// Token: 0x04001BF6 RID: 7158
		private string m_copyright;
	}
}
