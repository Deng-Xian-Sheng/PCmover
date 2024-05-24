using System;

namespace Prism.Modularity
{
	// Token: 0x0200006A RID: 106
	public enum ModuleState
	{
		// Token: 0x04000092 RID: 146
		NotStarted,
		// Token: 0x04000093 RID: 147
		LoadingTypes,
		// Token: 0x04000094 RID: 148
		ReadyForInitialization,
		// Token: 0x04000095 RID: 149
		Initializing,
		// Token: 0x04000096 RID: 150
		Initialized
	}
}
