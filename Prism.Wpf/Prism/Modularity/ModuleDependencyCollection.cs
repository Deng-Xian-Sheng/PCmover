using System;
using System.Configuration;

namespace Prism.Modularity
{
	// Token: 0x0200005E RID: 94
	public class ModuleDependencyCollection : ConfigurationElementCollection
	{
		// Token: 0x060002B3 RID: 691 RVA: 0x00007673 File Offset: 0x00005873
		public ModuleDependencyCollection()
		{
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00007788 File Offset: 0x00005988
		public ModuleDependencyCollection(ModuleDependencyConfigurationElement[] dependencies)
		{
			if (dependencies == null)
			{
				throw new ArgumentNullException("dependencies");
			}
			foreach (ModuleDependencyConfigurationElement element in dependencies)
			{
				this.BaseAdd(element);
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x000076BB File Offset: 0x000058BB
		public override ConfigurationElementCollectionType CollectionType
		{
			get
			{
				return ConfigurationElementCollectionType.BasicMap;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x000077C4 File Offset: 0x000059C4
		protected override string ElementName
		{
			get
			{
				return "dependency";
			}
		}

		// Token: 0x170000A6 RID: 166
		public ModuleDependencyConfigurationElement this[int index]
		{
			get
			{
				return (ModuleDependencyConfigurationElement)base.BaseGet(index);
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x000077D9 File Offset: 0x000059D9
		protected override ConfigurationElement CreateNewElement()
		{
			return new ModuleDependencyConfigurationElement();
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x000077E0 File Offset: 0x000059E0
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ModuleDependencyConfigurationElement)element).ModuleName;
		}
	}
}
