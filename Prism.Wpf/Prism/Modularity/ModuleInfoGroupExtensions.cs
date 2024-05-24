using System;
using System.Collections.ObjectModel;

namespace Prism.Modularity
{
	// Token: 0x02000064 RID: 100
	public static class ModuleInfoGroupExtensions
	{
		// Token: 0x060002FD RID: 765 RVA: 0x00007E98 File Offset: 0x00006098
		public static ModuleInfoGroup AddModule(this ModuleInfoGroup moduleInfoGroup, string moduleName, Type moduleType, params string[] dependsOn)
		{
			if (moduleType == null)
			{
				throw new ArgumentNullException("moduleType");
			}
			if (moduleInfoGroup == null)
			{
				throw new ArgumentNullException("moduleInfoGroup");
			}
			ModuleInfo moduleInfo = new ModuleInfo(moduleName, moduleType.AssemblyQualifiedName);
			moduleInfo.DependsOn.AddRange(dependsOn);
			moduleInfoGroup.Add(moduleInfo);
			return moduleInfoGroup;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00007EE9 File Offset: 0x000060E9
		public static ModuleInfoGroup AddModule(this ModuleInfoGroup moduleInfoGroup, Type moduleType, params string[] dependsOn)
		{
			if (moduleType == null)
			{
				throw new ArgumentNullException("moduleType");
			}
			return moduleInfoGroup.AddModule(moduleType.Name, moduleType, dependsOn);
		}
	}
}
