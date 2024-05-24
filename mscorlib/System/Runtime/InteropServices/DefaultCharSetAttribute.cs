using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200093E RID: 2366
	[AttributeUsage(AttributeTargets.Module, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class DefaultCharSetAttribute : Attribute
	{
		// Token: 0x06006059 RID: 24665 RVA: 0x0014BEB8 File Offset: 0x0014A0B8
		[__DynamicallyInvokable]
		public DefaultCharSetAttribute(CharSet charSet)
		{
			this._CharSet = charSet;
		}

		// Token: 0x170010F3 RID: 4339
		// (get) Token: 0x0600605A RID: 24666 RVA: 0x0014BEC7 File Offset: 0x0014A0C7
		[__DynamicallyInvokable]
		public CharSet CharSet
		{
			[__DynamicallyInvokable]
			get
			{
				return this._CharSet;
			}
		}

		// Token: 0x04002B29 RID: 11049
		internal CharSet _CharSet;
	}
}
