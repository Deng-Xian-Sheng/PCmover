using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Prism.Properties;

namespace Prism.Modularity
{
	// Token: 0x02000048 RID: 72
	public class ConfigurationModuleCatalog : ModuleCatalog
	{
		// Token: 0x06000226 RID: 550 RVA: 0x00006750 File Offset: 0x00004950
		public ConfigurationModuleCatalog()
		{
			this.Store = new ConfigurationStore();
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000227 RID: 551 RVA: 0x00006763 File Offset: 0x00004963
		// (set) Token: 0x06000228 RID: 552 RVA: 0x0000676B File Offset: 0x0000496B
		public IConfigurationStore Store { get; set; }

		// Token: 0x06000229 RID: 553 RVA: 0x00006774 File Offset: 0x00004974
		protected override void InnerLoad()
		{
			if (this.Store == null)
			{
				throw new InvalidOperationException(Resources.ConfigurationStoreCannotBeNull);
			}
			this.EnsureModulesDiscovered();
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000678F File Offset: 0x0000498F
		private static string GetFileAbsoluteUri(string filePath)
		{
			return new UriBuilder
			{
				Host = string.Empty,
				Scheme = Uri.UriSchemeFile,
				Path = Path.GetFullPath(filePath)
			}.Uri.ToString();
		}

		// Token: 0x0600022B RID: 555 RVA: 0x000067C4 File Offset: 0x000049C4
		private void EnsureModulesDiscovered()
		{
			ModulesConfigurationSection modulesConfigurationSection = this.Store.RetrieveModuleConfigurationSection();
			if (modulesConfigurationSection != null)
			{
				foreach (object obj in modulesConfigurationSection.Modules)
				{
					ModuleConfigurationElement moduleConfigurationElement = (ModuleConfigurationElement)obj;
					IList<string> list = new List<string>();
					if (moduleConfigurationElement.Dependencies.Count > 0)
					{
						foreach (object obj2 in moduleConfigurationElement.Dependencies)
						{
							ModuleDependencyConfigurationElement moduleDependencyConfigurationElement = (ModuleDependencyConfigurationElement)obj2;
							list.Add(moduleDependencyConfigurationElement.ModuleName);
						}
					}
					ModuleInfo moduleInfo = new ModuleInfo(moduleConfigurationElement.ModuleName, moduleConfigurationElement.ModuleType)
					{
						Ref = ConfigurationModuleCatalog.GetFileAbsoluteUri(moduleConfigurationElement.AssemblyFile),
						InitializationMode = (moduleConfigurationElement.StartupLoaded ? InitializationMode.WhenAvailable : InitializationMode.OnDemand)
					};
					moduleInfo.DependsOn.AddRange(list.ToArray<string>());
					this.AddModule(moduleInfo);
				}
			}
		}
	}
}
