using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008A1 RID: 2209
	[AttributeUsage(AttributeTargets.Field)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AccessedThroughPropertyAttribute : Attribute
	{
		// Token: 0x06005D72 RID: 23922 RVA: 0x00149236 File Offset: 0x00147436
		[__DynamicallyInvokable]
		public AccessedThroughPropertyAttribute(string propertyName)
		{
			this.propertyName = propertyName;
		}

		// Token: 0x1700100E RID: 4110
		// (get) Token: 0x06005D73 RID: 23923 RVA: 0x00149245 File Offset: 0x00147445
		[__DynamicallyInvokable]
		public string PropertyName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.propertyName;
			}
		}

		// Token: 0x04002A08 RID: 10760
		private readonly string propertyName;
	}
}
