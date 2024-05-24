using System;
using System.Diagnostics;

namespace System.Runtime.Versioning
{
	// Token: 0x0200071E RID: 1822
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, Inherited = false)]
	[Conditional("RESOURCE_ANNOTATION_WORK")]
	public sealed class ResourceConsumptionAttribute : Attribute
	{
		// Token: 0x06005151 RID: 20817 RVA: 0x0011EC57 File Offset: 0x0011CE57
		public ResourceConsumptionAttribute(ResourceScope resourceScope)
		{
			this._resourceScope = resourceScope;
			this._consumptionScope = this._resourceScope;
		}

		// Token: 0x06005152 RID: 20818 RVA: 0x0011EC72 File Offset: 0x0011CE72
		public ResourceConsumptionAttribute(ResourceScope resourceScope, ResourceScope consumptionScope)
		{
			this._resourceScope = resourceScope;
			this._consumptionScope = consumptionScope;
		}

		// Token: 0x17000D6A RID: 3434
		// (get) Token: 0x06005153 RID: 20819 RVA: 0x0011EC88 File Offset: 0x0011CE88
		public ResourceScope ResourceScope
		{
			get
			{
				return this._resourceScope;
			}
		}

		// Token: 0x17000D6B RID: 3435
		// (get) Token: 0x06005154 RID: 20820 RVA: 0x0011EC90 File Offset: 0x0011CE90
		public ResourceScope ConsumptionScope
		{
			get
			{
				return this._consumptionScope;
			}
		}

		// Token: 0x04002408 RID: 9224
		private ResourceScope _consumptionScope;

		// Token: 0x04002409 RID: 9225
		private ResourceScope _resourceScope;
	}
}
