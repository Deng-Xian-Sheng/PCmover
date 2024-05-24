using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008E0 RID: 2272
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false, AllowMultiple = false)]
	[__DynamicallyInvokable]
	public sealed class TypeForwardedFromAttribute : Attribute
	{
		// Token: 0x06005DD5 RID: 24021 RVA: 0x0014990C File Offset: 0x00147B0C
		private TypeForwardedFromAttribute()
		{
		}

		// Token: 0x06005DD6 RID: 24022 RVA: 0x00149914 File Offset: 0x00147B14
		[__DynamicallyInvokable]
		public TypeForwardedFromAttribute(string assemblyFullName)
		{
			if (string.IsNullOrEmpty(assemblyFullName))
			{
				throw new ArgumentNullException("assemblyFullName");
			}
			this.assemblyFullName = assemblyFullName;
		}

		// Token: 0x1700101E RID: 4126
		// (get) Token: 0x06005DD7 RID: 24023 RVA: 0x00149936 File Offset: 0x00147B36
		[__DynamicallyInvokable]
		public string AssemblyFullName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.assemblyFullName;
			}
		}

		// Token: 0x04002A33 RID: 10803
		private string assemblyFullName;
	}
}
