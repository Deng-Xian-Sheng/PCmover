using System;
using System.Configuration;

namespace Prism.Modularity
{
	// Token: 0x0200005F RID: 95
	public class ModuleDependencyConfigurationElement : ConfigurationElement
	{
		// Token: 0x060002BA RID: 698 RVA: 0x00007588 File Offset: 0x00005788
		public ModuleDependencyConfigurationElement()
		{
		}

		// Token: 0x060002BB RID: 699 RVA: 0x000077ED File Offset: 0x000059ED
		public ModuleDependencyConfigurationElement(string moduleName)
		{
			base["moduleName"] = moduleName;
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002BC RID: 700 RVA: 0x0000760E File Offset: 0x0000580E
		// (set) Token: 0x060002BD RID: 701 RVA: 0x00007620 File Offset: 0x00005820
		[ConfigurationProperty("moduleName", IsRequired = true, IsKey = true)]
		public string ModuleName
		{
			get
			{
				return (string)base["moduleName"];
			}
			set
			{
				base["moduleName"] = value;
			}
		}
	}
}
