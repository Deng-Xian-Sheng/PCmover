using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008E1 RID: 2273
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class ReferenceAssemblyAttribute : Attribute
	{
		// Token: 0x06005DD8 RID: 24024 RVA: 0x0014993E File Offset: 0x00147B3E
		[__DynamicallyInvokable]
		public ReferenceAssemblyAttribute()
		{
		}

		// Token: 0x06005DD9 RID: 24025 RVA: 0x00149946 File Offset: 0x00147B46
		[__DynamicallyInvokable]
		public ReferenceAssemblyAttribute(string description)
		{
			this._description = description;
		}

		// Token: 0x1700101F RID: 4127
		// (get) Token: 0x06005DDA RID: 24026 RVA: 0x00149955 File Offset: 0x00147B55
		[__DynamicallyInvokable]
		public string Description
		{
			[__DynamicallyInvokable]
			get
			{
				return this._description;
			}
		}

		// Token: 0x04002A34 RID: 10804
		private string _description;
	}
}
