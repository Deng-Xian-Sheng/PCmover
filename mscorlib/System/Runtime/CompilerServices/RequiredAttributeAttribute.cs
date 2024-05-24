using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008C1 RID: 2241
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class RequiredAttributeAttribute : Attribute
	{
		// Token: 0x06005DB5 RID: 23989 RVA: 0x00149790 File Offset: 0x00147990
		public RequiredAttributeAttribute(Type requiredContract)
		{
			this.requiredContract = requiredContract;
		}

		// Token: 0x17001019 RID: 4121
		// (get) Token: 0x06005DB6 RID: 23990 RVA: 0x0014979F File Offset: 0x0014799F
		public Type RequiredContract
		{
			get
			{
				return this.requiredContract;
			}
		}

		// Token: 0x04002A24 RID: 10788
		private Type requiredContract;
	}
}
