using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000937 RID: 2359
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface, Inherited = false)]
	[ComVisible(true)]
	public sealed class AutomationProxyAttribute : Attribute
	{
		// Token: 0x06006045 RID: 24645 RVA: 0x0014BDBC File Offset: 0x00149FBC
		public AutomationProxyAttribute(bool val)
		{
			this._val = val;
		}

		// Token: 0x170010E6 RID: 4326
		// (get) Token: 0x06006046 RID: 24646 RVA: 0x0014BDCB File Offset: 0x00149FCB
		public bool Value
		{
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002B1B RID: 11035
		internal bool _val;
	}
}
