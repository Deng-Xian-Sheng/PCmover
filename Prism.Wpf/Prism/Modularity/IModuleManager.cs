using System;

namespace Prism.Modularity
{
	// Token: 0x02000054 RID: 84
	public interface IModuleManager
	{
		// Token: 0x06000257 RID: 599
		void Run();

		// Token: 0x06000258 RID: 600
		void LoadModule(string moduleName);

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000259 RID: 601
		// (remove) Token: 0x0600025A RID: 602
		event EventHandler<ModuleDownloadProgressChangedEventArgs> ModuleDownloadProgressChanged;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x0600025B RID: 603
		// (remove) Token: 0x0600025C RID: 604
		event EventHandler<LoadModuleCompletedEventArgs> LoadModuleCompleted;
	}
}
