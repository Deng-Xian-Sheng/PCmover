using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	// Token: 0x020003E4 RID: 996
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class ConditionalAttribute : Attribute
	{
		// Token: 0x060032F4 RID: 13044 RVA: 0x000C4A52 File Offset: 0x000C2C52
		[__DynamicallyInvokable]
		public ConditionalAttribute(string conditionString)
		{
			this.m_conditionString = conditionString;
		}

		// Token: 0x17000770 RID: 1904
		// (get) Token: 0x060032F5 RID: 13045 RVA: 0x000C4A61 File Offset: 0x000C2C61
		[__DynamicallyInvokable]
		public string ConditionString
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_conditionString;
			}
		}

		// Token: 0x04001698 RID: 5784
		private string m_conditionString;
	}
}
