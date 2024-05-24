using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000914 RID: 2324
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class ComDefaultInterfaceAttribute : Attribute
	{
		// Token: 0x06005FF4 RID: 24564 RVA: 0x0014B598 File Offset: 0x00149798
		[__DynamicallyInvokable]
		public ComDefaultInterfaceAttribute(Type defaultInterface)
		{
			this._val = defaultInterface;
		}

		// Token: 0x170010D3 RID: 4307
		// (get) Token: 0x06005FF5 RID: 24565 RVA: 0x0014B5A7 File Offset: 0x001497A7
		[__DynamicallyInvokable]
		public Type Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A64 RID: 10852
		internal Type _val;
	}
}
