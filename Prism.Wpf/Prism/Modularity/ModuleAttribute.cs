using System;

namespace Prism.Modularity
{
	// Token: 0x02000059 RID: 89
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class ModuleAttribute : Attribute
	{
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000273 RID: 627 RVA: 0x00006E9D File Offset: 0x0000509D
		// (set) Token: 0x06000274 RID: 628 RVA: 0x00006EA5 File Offset: 0x000050A5
		public string ModuleName { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00006EAE File Offset: 0x000050AE
		// (set) Token: 0x06000276 RID: 630 RVA: 0x00006EB6 File Offset: 0x000050B6
		public bool OnDemand { get; set; }
	}
}
