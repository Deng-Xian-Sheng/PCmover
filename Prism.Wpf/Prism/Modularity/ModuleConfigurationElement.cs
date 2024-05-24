using System;
using System.Configuration;

namespace Prism.Modularity
{
	// Token: 0x0200005B RID: 91
	public class ModuleConfigurationElement : ConfigurationElement
	{
		// Token: 0x0600029A RID: 666 RVA: 0x00007588 File Offset: 0x00005788
		public ModuleConfigurationElement()
		{
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00007590 File Offset: 0x00005790
		public ModuleConfigurationElement(string assemblyFile, string moduleType, string moduleName, bool startupLoaded)
		{
			base["assemblyFile"] = assemblyFile;
			base["moduleType"] = moduleType;
			base["moduleName"] = moduleName;
			base["startupLoaded"] = startupLoaded;
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600029C RID: 668 RVA: 0x000075CE File Offset: 0x000057CE
		// (set) Token: 0x0600029D RID: 669 RVA: 0x000075E0 File Offset: 0x000057E0
		[ConfigurationProperty("assemblyFile", IsRequired = true)]
		public string AssemblyFile
		{
			get
			{
				return (string)base["assemblyFile"];
			}
			set
			{
				base["assemblyFile"] = value;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600029E RID: 670 RVA: 0x000075EE File Offset: 0x000057EE
		// (set) Token: 0x0600029F RID: 671 RVA: 0x00007600 File Offset: 0x00005800
		[ConfigurationProperty("moduleType", IsRequired = true)]
		public string ModuleType
		{
			get
			{
				return (string)base["moduleType"];
			}
			set
			{
				base["moduleType"] = value;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x0000760E File Offset: 0x0000580E
		// (set) Token: 0x060002A1 RID: 673 RVA: 0x00007620 File Offset: 0x00005820
		[ConfigurationProperty("moduleName", IsRequired = true)]
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

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x0000762E File Offset: 0x0000582E
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x00007640 File Offset: 0x00005840
		[ConfigurationProperty("startupLoaded", IsRequired = false, DefaultValue = true)]
		public bool StartupLoaded
		{
			get
			{
				return (bool)base["startupLoaded"];
			}
			set
			{
				base["startupLoaded"] = value;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x00007653 File Offset: 0x00005853
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x00007665 File Offset: 0x00005865
		[ConfigurationProperty("dependencies", IsDefaultCollection = true, IsKey = false)]
		public ModuleDependencyCollection Dependencies
		{
			get
			{
				return (ModuleDependencyCollection)base["dependencies"];
			}
			set
			{
				base["dependencies"] = value;
			}
		}
	}
}
