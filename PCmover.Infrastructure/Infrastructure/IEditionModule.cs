using System;
using Prism.Modularity;

namespace PCmover.Infrastructure
{
	// Token: 0x02000025 RID: 37
	public interface IEditionModule : IPcmoverModule, IModule
	{
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060001C8 RID: 456
		IEditionData Data { get; }

		// Token: 0x060001C9 RID: 457
		void InitData(DefaultPolicy policy);
	}
}
