using System;
using System.Configuration;

namespace Prism.Modularity
{
	// Token: 0x02000069 RID: 105
	public class ModulesConfigurationSection : ConfigurationSection
	{
		// Token: 0x170000BD RID: 189
		// (get) Token: 0x0600032B RID: 811 RVA: 0x0000873F File Offset: 0x0000693F
		// (set) Token: 0x0600032C RID: 812 RVA: 0x00008751 File Offset: 0x00006951
		[ConfigurationProperty("", IsDefaultCollection = true, IsKey = false)]
		public ModuleConfigurationElementCollection Modules
		{
			get
			{
				return (ModuleConfigurationElementCollection)base[""];
			}
			set
			{
				base[""] = value;
			}
		}
	}
}
