using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200090F RID: 2319
	[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	[ComVisible(false)]
	[__DynamicallyInvokable]
	public sealed class TypeIdentifierAttribute : Attribute
	{
		// Token: 0x06005FEA RID: 24554 RVA: 0x0014B525 File Offset: 0x00149725
		[__DynamicallyInvokable]
		public TypeIdentifierAttribute()
		{
		}

		// Token: 0x06005FEB RID: 24555 RVA: 0x0014B52D File Offset: 0x0014972D
		[__DynamicallyInvokable]
		public TypeIdentifierAttribute(string scope, string identifier)
		{
			this.Scope_ = scope;
			this.Identifier_ = identifier;
		}

		// Token: 0x170010CF RID: 4303
		// (get) Token: 0x06005FEC RID: 24556 RVA: 0x0014B543 File Offset: 0x00149743
		[__DynamicallyInvokable]
		public string Scope
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Scope_;
			}
		}

		// Token: 0x170010D0 RID: 4304
		// (get) Token: 0x06005FED RID: 24557 RVA: 0x0014B54B File Offset: 0x0014974B
		[__DynamicallyInvokable]
		public string Identifier
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Identifier_;
			}
		}

		// Token: 0x04002A5B RID: 10843
		internal string Scope_;

		// Token: 0x04002A5C RID: 10844
		internal string Identifier_;
	}
}
