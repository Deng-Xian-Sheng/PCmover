using System;
using System.Configuration;

namespace Prism.Modularity
{
	// Token: 0x02000049 RID: 73
	public class ConfigurationStore : IConfigurationStore
	{
		// Token: 0x0600022C RID: 556 RVA: 0x000068EC File Offset: 0x00004AEC
		public ModulesConfigurationSection RetrieveModuleConfigurationSection()
		{
			return ConfigurationManager.GetSection("modules") as ModulesConfigurationSection;
		}
	}
}
