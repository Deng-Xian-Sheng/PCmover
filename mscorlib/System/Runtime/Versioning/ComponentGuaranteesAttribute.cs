using System;

namespace System.Runtime.Versioning
{
	// Token: 0x0200071D RID: 1821
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	public sealed class ComponentGuaranteesAttribute : Attribute
	{
		// Token: 0x0600514F RID: 20815 RVA: 0x0011EC40 File Offset: 0x0011CE40
		public ComponentGuaranteesAttribute(ComponentGuaranteesOptions guarantees)
		{
			this._guarantees = guarantees;
		}

		// Token: 0x17000D69 RID: 3433
		// (get) Token: 0x06005150 RID: 20816 RVA: 0x0011EC4F File Offset: 0x0011CE4F
		public ComponentGuaranteesOptions Guarantees
		{
			get
			{
				return this._guarantees;
			}
		}

		// Token: 0x04002407 RID: 9223
		private ComponentGuaranteesOptions _guarantees;
	}
}
