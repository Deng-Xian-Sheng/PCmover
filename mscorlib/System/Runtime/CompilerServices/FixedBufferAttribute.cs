using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008B6 RID: 2230
	[AttributeUsage(AttributeTargets.Field, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class FixedBufferAttribute : Attribute
	{
		// Token: 0x06005DA4 RID: 23972 RVA: 0x001496C2 File Offset: 0x001478C2
		[__DynamicallyInvokable]
		public FixedBufferAttribute(Type elementType, int length)
		{
			this.elementType = elementType;
			this.length = length;
		}

		// Token: 0x17001014 RID: 4116
		// (get) Token: 0x06005DA5 RID: 23973 RVA: 0x001496D8 File Offset: 0x001478D8
		[__DynamicallyInvokable]
		public Type ElementType
		{
			[__DynamicallyInvokable]
			get
			{
				return this.elementType;
			}
		}

		// Token: 0x17001015 RID: 4117
		// (get) Token: 0x06005DA6 RID: 23974 RVA: 0x001496E0 File Offset: 0x001478E0
		[__DynamicallyInvokable]
		public int Length
		{
			[__DynamicallyInvokable]
			get
			{
				return this.length;
			}
		}

		// Token: 0x04002A0F RID: 10767
		private Type elementType;

		// Token: 0x04002A10 RID: 10768
		private int length;
	}
}
