using System;
using System.Collections.Generic;

namespace Prism.Modularity
{
	// Token: 0x02000051 RID: 81
	public interface IModuleCatalog
	{
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000251 RID: 593
		IEnumerable<ModuleInfo> Modules { get; }

		// Token: 0x06000252 RID: 594
		IEnumerable<ModuleInfo> GetDependentModules(ModuleInfo moduleInfo);

		// Token: 0x06000253 RID: 595
		IEnumerable<ModuleInfo> CompleteListWithDependencies(IEnumerable<ModuleInfo> modules);

		// Token: 0x06000254 RID: 596
		void Initialize();

		// Token: 0x06000255 RID: 597
		void AddModule(ModuleInfo moduleInfo);
	}
}
