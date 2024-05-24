using System;

namespace System.Reflection
{
	// Token: 0x020005C4 RID: 1476
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
	[__DynamicallyInvokable]
	public sealed class AssemblySignatureKeyAttribute : Attribute
	{
		// Token: 0x06004473 RID: 17523 RVA: 0x000FC49D File Offset: 0x000FA69D
		[__DynamicallyInvokable]
		public AssemblySignatureKeyAttribute(string publicKey, string countersignature)
		{
			this._publicKey = publicKey;
			this._countersignature = countersignature;
		}

		// Token: 0x17000A22 RID: 2594
		// (get) Token: 0x06004474 RID: 17524 RVA: 0x000FC4B3 File Offset: 0x000FA6B3
		[__DynamicallyInvokable]
		public string PublicKey
		{
			[__DynamicallyInvokable]
			get
			{
				return this._publicKey;
			}
		}

		// Token: 0x17000A23 RID: 2595
		// (get) Token: 0x06004475 RID: 17525 RVA: 0x000FC4BB File Offset: 0x000FA6BB
		[__DynamicallyInvokable]
		public string Countersignature
		{
			[__DynamicallyInvokable]
			get
			{
				return this._countersignature;
			}
		}

		// Token: 0x04001C08 RID: 7176
		private string _publicKey;

		// Token: 0x04001C09 RID: 7177
		private string _countersignature;
	}
}
