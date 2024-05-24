using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008FC RID: 2300
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class IUnknownConstantAttribute : CustomConstantAttribute
	{
		// Token: 0x17001031 RID: 4145
		// (get) Token: 0x06005E4E RID: 24142 RVA: 0x0014B443 File Offset: 0x00149643
		public override object Value
		{
			get
			{
				return new UnknownWrapper(null);
			}
		}
	}
}
