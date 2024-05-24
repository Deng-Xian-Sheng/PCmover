using System;
using System.Collections.Generic;
using System.Configuration;

namespace Prism.Modularity
{
	// Token: 0x0200005C RID: 92
	public class ModuleConfigurationElementCollection : ConfigurationElementCollection
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x00007673 File Offset: 0x00005873
		public ModuleConfigurationElementCollection()
		{
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000767C File Offset: 0x0000587C
		public ModuleConfigurationElementCollection(ModuleConfigurationElement[] modules)
		{
			if (modules == null)
			{
				throw new ArgumentNullException("modules");
			}
			foreach (ModuleConfigurationElement element in modules)
			{
				this.BaseAdd(element);
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x000076B8 File Offset: 0x000058B8
		protected override bool ThrowOnDuplicate
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x000076BB File Offset: 0x000058BB
		public override ConfigurationElementCollectionType CollectionType
		{
			get
			{
				return ConfigurationElementCollectionType.BasicMap;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002AA RID: 682 RVA: 0x000076BE File Offset: 0x000058BE
		protected override string ElementName
		{
			get
			{
				return "module";
			}
		}

		// Token: 0x170000A2 RID: 162
		public ModuleConfigurationElement this[int index]
		{
			get
			{
				return (ModuleConfigurationElement)base.BaseGet(index);
			}
		}

		// Token: 0x060002AC RID: 684 RVA: 0x000076D3 File Offset: 0x000058D3
		public void Add(ModuleConfigurationElement module)
		{
			this.BaseAdd(module);
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000076DC File Offset: 0x000058DC
		public bool Contains(string moduleName)
		{
			return base.BaseGet(moduleName) != null;
		}

		// Token: 0x060002AE RID: 686 RVA: 0x000076E8 File Offset: 0x000058E8
		public IList<ModuleConfigurationElement> FindAll(Predicate<ModuleConfigurationElement> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			IList<ModuleConfigurationElement> list = new List<ModuleConfigurationElement>();
			foreach (object obj in this)
			{
				ModuleConfigurationElement moduleConfigurationElement = (ModuleConfigurationElement)obj;
				if (match(moduleConfigurationElement))
				{
					list.Add(moduleConfigurationElement);
				}
			}
			return list;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000775C File Offset: 0x0000595C
		protected override ConfigurationElement CreateNewElement()
		{
			return new ModuleConfigurationElement();
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00007763 File Offset: 0x00005963
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ModuleConfigurationElement)element).ModuleName;
		}
	}
}
