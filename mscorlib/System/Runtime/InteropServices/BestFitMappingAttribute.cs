using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200093D RID: 2365
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class BestFitMappingAttribute : Attribute
	{
		// Token: 0x06006057 RID: 24663 RVA: 0x0014BEA1 File Offset: 0x0014A0A1
		[__DynamicallyInvokable]
		public BestFitMappingAttribute(bool BestFitMapping)
		{
			this._bestFitMapping = BestFitMapping;
		}

		// Token: 0x170010F2 RID: 4338
		// (get) Token: 0x06006058 RID: 24664 RVA: 0x0014BEB0 File Offset: 0x0014A0B0
		[__DynamicallyInvokable]
		public bool BestFitMapping
		{
			[__DynamicallyInvokable]
			get
			{
				return this._bestFitMapping;
			}
		}

		// Token: 0x04002B27 RID: 11047
		internal bool _bestFitMapping;

		// Token: 0x04002B28 RID: 11048
		[__DynamicallyInvokable]
		public bool ThrowOnUnmappableChar;
	}
}
