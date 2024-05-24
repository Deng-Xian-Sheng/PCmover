using System;

namespace Prism.Modularity
{
	// Token: 0x0200005D RID: 93
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public sealed class ModuleDependencyAttribute : Attribute
	{
		// Token: 0x060002B1 RID: 689 RVA: 0x00007770 File Offset: 0x00005970
		public ModuleDependencyAttribute(string moduleName)
		{
			this._moduleName = moduleName;
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x0000777F File Offset: 0x0000597F
		public string ModuleName
		{
			get
			{
				return this._moduleName;
			}
		}

		// Token: 0x04000079 RID: 121
		private readonly string _moduleName;
	}
}
