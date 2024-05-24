using System;

namespace Prism.Modularity
{
	// Token: 0x02000055 RID: 85
	public interface IModuleTypeLoader
	{
		// Token: 0x0600025D RID: 605
		bool CanLoadModuleType(ModuleInfo moduleInfo);

		// Token: 0x0600025E RID: 606
		void LoadModuleType(ModuleInfo moduleInfo);

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x0600025F RID: 607
		// (remove) Token: 0x06000260 RID: 608
		event EventHandler<ModuleDownloadProgressChangedEventArgs> ModuleDownloadProgressChanged;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000261 RID: 609
		// (remove) Token: 0x06000262 RID: 610
		event EventHandler<LoadModuleCompletedEventArgs> LoadModuleCompleted;
	}
}
