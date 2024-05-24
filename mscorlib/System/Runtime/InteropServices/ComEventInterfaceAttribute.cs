using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200093A RID: 2362
	[AttributeUsage(AttributeTargets.Interface, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class ComEventInterfaceAttribute : Attribute
	{
		// Token: 0x0600604C RID: 24652 RVA: 0x0014BE10 File Offset: 0x0014A010
		[__DynamicallyInvokable]
		public ComEventInterfaceAttribute(Type SourceInterface, Type EventProvider)
		{
			this._SourceInterface = SourceInterface;
			this._EventProvider = EventProvider;
		}

		// Token: 0x170010EA RID: 4330
		// (get) Token: 0x0600604D RID: 24653 RVA: 0x0014BE26 File Offset: 0x0014A026
		[__DynamicallyInvokable]
		public Type SourceInterface
		{
			[__DynamicallyInvokable]
			get
			{
				return this._SourceInterface;
			}
		}

		// Token: 0x170010EB RID: 4331
		// (get) Token: 0x0600604E RID: 24654 RVA: 0x0014BE2E File Offset: 0x0014A02E
		[__DynamicallyInvokable]
		public Type EventProvider
		{
			[__DynamicallyInvokable]
			get
			{
				return this._EventProvider;
			}
		}

		// Token: 0x04002B1F RID: 11039
		internal Type _SourceInterface;

		// Token: 0x04002B20 RID: 11040
		internal Type _EventProvider;
	}
}
