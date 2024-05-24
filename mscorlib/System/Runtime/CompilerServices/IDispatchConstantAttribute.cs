using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008FB RID: 2299
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class IDispatchConstantAttribute : CustomConstantAttribute
	{
		// Token: 0x17001030 RID: 4144
		// (get) Token: 0x06005E4C RID: 24140 RVA: 0x0014B433 File Offset: 0x00149633
		public override object Value
		{
			get
			{
				return new DispatchWrapper(null);
			}
		}
	}
}
