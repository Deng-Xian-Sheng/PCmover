using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009CA RID: 2506
	[AttributeUsage(AttributeTargets.Delegate | AttributeTargets.ReturnValue, AllowMultiple = false, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class ReturnValueNameAttribute : Attribute
	{
		// Token: 0x060063C4 RID: 25540 RVA: 0x0015484D File Offset: 0x00152A4D
		[__DynamicallyInvokable]
		public ReturnValueNameAttribute(string name)
		{
			this.m_Name = name;
		}

		// Token: 0x1700113F RID: 4415
		// (get) Token: 0x060063C5 RID: 25541 RVA: 0x0015485C File Offset: 0x00152A5C
		[__DynamicallyInvokable]
		public string Name
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_Name;
			}
		}

		// Token: 0x04002CD9 RID: 11481
		private string m_Name;
	}
}
