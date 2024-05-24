using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Resources;
using Prism.Properties;

namespace Prism.Modularity
{
	// Token: 0x0200005A RID: 90
	[ContentProperty("Items")]
	public class ModuleCatalog : IModuleCatalog
	{
		// Token: 0x06000278 RID: 632 RVA: 0x00006EBF File Offset: 0x000050BF
		public ModuleCatalog()
		{
			this.items = new ModuleCatalog.ModuleCatalogItemCollection();
			this.items.CollectionChanged += this.ItemsCollectionChanged;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00006EEC File Offset: 0x000050EC
		public ModuleCatalog(IEnumerable<ModuleInfo> modules) : this()
		{
			if (modules == null)
			{
				throw new ArgumentNullException("modules");
			}
			foreach (ModuleInfo item in modules)
			{
				this.Items.Add(item);
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600027A RID: 634 RVA: 0x00006F50 File Offset: 0x00005150
		public Collection<IModuleCatalogItem> Items
		{
			get
			{
				return this.items;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600027B RID: 635 RVA: 0x00006F58 File Offset: 0x00005158
		public virtual IEnumerable<ModuleInfo> Modules
		{
			get
			{
				return this.GrouplessModules.Union(this.Groups.SelectMany((ModuleInfoGroup g) => g));
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600027C RID: 636 RVA: 0x00006F8F File Offset: 0x0000518F
		public IEnumerable<ModuleInfoGroup> Groups
		{
			get
			{
				return this.Items.OfType<ModuleInfoGroup>();
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600027D RID: 637 RVA: 0x00006F9C File Offset: 0x0000519C
		// (set) Token: 0x0600027E RID: 638 RVA: 0x00006FA4 File Offset: 0x000051A4
		protected bool Validated { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00006FAD File Offset: 0x000051AD
		protected IEnumerable<ModuleInfo> GrouplessModules
		{
			get
			{
				return this.Items.OfType<ModuleInfo>();
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00006FBA File Offset: 0x000051BA
		public static ModuleCatalog CreateFromXaml(Stream xamlStream)
		{
			if (xamlStream == null)
			{
				throw new ArgumentNullException("xamlStream");
			}
			return XamlReader.Load(xamlStream) as ModuleCatalog;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00006FD8 File Offset: 0x000051D8
		public static ModuleCatalog CreateFromXaml(Uri builderResourceUri)
		{
			StreamResourceInfo resourceStream = Application.GetResourceStream(builderResourceUri);
			if (resourceStream != null && resourceStream.Stream != null)
			{
				return ModuleCatalog.CreateFromXaml(resourceStream.Stream);
			}
			return null;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00007004 File Offset: 0x00005204
		public void Load()
		{
			this.isLoaded = true;
			this.InnerLoad();
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00007013 File Offset: 0x00005213
		public virtual IEnumerable<ModuleInfo> GetDependentModules(ModuleInfo moduleInfo)
		{
			this.EnsureCatalogValidated();
			return this.GetDependentModulesInner(moduleInfo);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00007024 File Offset: 0x00005224
		public virtual IEnumerable<ModuleInfo> CompleteListWithDependencies(IEnumerable<ModuleInfo> modules)
		{
			if (modules == null)
			{
				throw new ArgumentNullException("modules");
			}
			this.EnsureCatalogValidated();
			List<ModuleInfo> list = new List<ModuleInfo>();
			List<ModuleInfo> list2 = modules.ToList<ModuleInfo>();
			while (list2.Count > 0)
			{
				ModuleInfo moduleInfo = list2[0];
				foreach (ModuleInfo item in this.GetDependentModules(moduleInfo))
				{
					if (!list.Contains(item) && !list2.Contains(item))
					{
						list2.Add(item);
					}
				}
				list2.RemoveAt(0);
				list.Add(moduleInfo);
			}
			return this.Sort(list);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x000070D4 File Offset: 0x000052D4
		public virtual void Validate()
		{
			this.ValidateUniqueModules();
			this.ValidateDependencyGraph();
			this.ValidateCrossGroupDependencies();
			this.ValidateDependenciesInitializationMode();
			this.Validated = true;
		}

		// Token: 0x06000286 RID: 646 RVA: 0x000070F5 File Offset: 0x000052F5
		public virtual void AddModule(ModuleInfo moduleInfo)
		{
			this.Items.Add(moduleInfo);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00007103 File Offset: 0x00005303
		public ModuleCatalog AddModule(Type moduleType, params string[] dependsOn)
		{
			return this.AddModule(moduleType, InitializationMode.WhenAvailable, dependsOn);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000710E File Offset: 0x0000530E
		public ModuleCatalog AddModule(Type moduleType, InitializationMode initializationMode, params string[] dependsOn)
		{
			if (moduleType == null)
			{
				throw new ArgumentNullException("moduleType");
			}
			return this.AddModule(moduleType.Name, moduleType.AssemblyQualifiedName, initializationMode, dependsOn);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00007138 File Offset: 0x00005338
		public ModuleCatalog AddModule(string moduleName, string moduleType, params string[] dependsOn)
		{
			return this.AddModule(moduleName, moduleType, InitializationMode.WhenAvailable, dependsOn);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00007144 File Offset: 0x00005344
		public ModuleCatalog AddModule(string moduleName, string moduleType, InitializationMode initializationMode, params string[] dependsOn)
		{
			return this.AddModule(moduleName, moduleType, null, initializationMode, dependsOn);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00007154 File Offset: 0x00005354
		public ModuleCatalog AddModule(string moduleName, string moduleType, string refValue, InitializationMode initializationMode, params string[] dependsOn)
		{
			if (moduleName == null)
			{
				throw new ArgumentNullException("moduleName");
			}
			if (moduleType == null)
			{
				throw new ArgumentNullException("moduleType");
			}
			ModuleInfo moduleInfo = new ModuleInfo(moduleName, moduleType);
			moduleInfo.DependsOn.AddRange(dependsOn);
			moduleInfo.InitializationMode = initializationMode;
			moduleInfo.Ref = refValue;
			this.Items.Add(moduleInfo);
			return this;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x000071AF File Offset: 0x000053AF
		public virtual void Initialize()
		{
			if (!this.isLoaded)
			{
				this.Load();
			}
			this.Validate();
		}

		// Token: 0x0600028D RID: 653 RVA: 0x000071C8 File Offset: 0x000053C8
		public virtual ModuleCatalog AddGroup(InitializationMode initializationMode, string refValue, params ModuleInfo[] moduleInfos)
		{
			if (moduleInfos == null)
			{
				throw new ArgumentNullException("moduleInfos");
			}
			ModuleInfoGroup moduleInfoGroup = new ModuleInfoGroup();
			moduleInfoGroup.InitializationMode = initializationMode;
			moduleInfoGroup.Ref = refValue;
			foreach (ModuleInfo item in moduleInfos)
			{
				moduleInfoGroup.Add(item);
			}
			this.items.Add(moduleInfoGroup);
			return this;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00007220 File Offset: 0x00005420
		protected static string[] SolveDependencies(IEnumerable<ModuleInfo> modules)
		{
			if (modules == null)
			{
				throw new ArgumentNullException("modules");
			}
			ModuleDependencySolver moduleDependencySolver = new ModuleDependencySolver();
			foreach (ModuleInfo moduleInfo in modules)
			{
				moduleDependencySolver.AddModule(moduleInfo.ModuleName);
				if (moduleInfo.DependsOn != null)
				{
					foreach (string dependentModule in moduleInfo.DependsOn)
					{
						moduleDependencySolver.AddDependency(moduleInfo.ModuleName, dependentModule);
					}
				}
			}
			if (moduleDependencySolver.ModuleCount > 0)
			{
				return moduleDependencySolver.Solve();
			}
			return new string[0];
		}

		// Token: 0x0600028F RID: 655 RVA: 0x000072E4 File Offset: 0x000054E4
		protected static void ValidateDependencies(IEnumerable<ModuleInfo> modules)
		{
			if (modules == null)
			{
				throw new ArgumentNullException("modules");
			}
			List<string> second = (from m in modules
			select m.ModuleName).ToList<string>();
			foreach (ModuleInfo moduleInfo in modules)
			{
				if (moduleInfo.DependsOn != null && moduleInfo.DependsOn.Except(second).Any<string>())
				{
					throw new ModularityException(moduleInfo.ModuleName, string.Format(CultureInfo.CurrentCulture, Resources.ModuleDependenciesNotMetInGroup, new object[]
					{
						moduleInfo.ModuleName
					}));
				}
			}
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00002222 File Offset: 0x00000422
		protected virtual void InnerLoad()
		{
		}

		// Token: 0x06000291 RID: 657 RVA: 0x000073A4 File Offset: 0x000055A4
		protected virtual IEnumerable<ModuleInfo> Sort(IEnumerable<ModuleInfo> modules)
		{
			string[] array = ModuleCatalog.SolveDependencies(modules);
			for (int i = 0; i < array.Length; i++)
			{
				string moduleName = array[i];
				yield return modules.First((ModuleInfo m) => m.ModuleName == moduleName);
			}
			array = null;
			yield break;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x000073B4 File Offset: 0x000055B4
		protected virtual void ValidateUniqueModules()
		{
			List<string> moduleNames = (from m in this.Modules
			select m.ModuleName).ToList<string>();
			string text = moduleNames.FirstOrDefault((string m) => moduleNames.Count((string m2) => m2 == m) > 1);
			if (text != null)
			{
				throw new DuplicateModuleException(text, string.Format(CultureInfo.CurrentCulture, Resources.DuplicatedModule, new object[]
				{
					text
				}));
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00007437 File Offset: 0x00005637
		protected virtual void ValidateDependencyGraph()
		{
			ModuleCatalog.SolveDependencies(this.Modules);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00007448 File Offset: 0x00005648
		protected virtual void ValidateCrossGroupDependencies()
		{
			ModuleCatalog.ValidateDependencies(this.GrouplessModules);
			foreach (ModuleInfoGroup second in this.Groups)
			{
				ModuleCatalog.ValidateDependencies(this.GrouplessModules.Union(second));
			}
		}

		// Token: 0x06000295 RID: 661 RVA: 0x000074AC File Offset: 0x000056AC
		protected virtual void ValidateDependenciesInitializationMode()
		{
			ModuleInfo moduleInfo = this.Modules.FirstOrDefault(delegate(ModuleInfo m)
			{
				if (m.InitializationMode == InitializationMode.WhenAvailable)
				{
					return this.GetDependentModulesInner(m).Any((ModuleInfo dependency) => dependency.InitializationMode == InitializationMode.OnDemand);
				}
				return false;
			});
			if (moduleInfo != null)
			{
				throw new ModularityException(moduleInfo.ModuleName, string.Format(CultureInfo.CurrentCulture, Resources.StartupModuleDependsOnAnOnDemandModule, new object[]
				{
					moduleInfo.ModuleName
				}));
			}
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00007500 File Offset: 0x00005700
		protected virtual IEnumerable<ModuleInfo> GetDependentModulesInner(ModuleInfo moduleInfo)
		{
			return from dependantModule in this.Modules
			where moduleInfo.DependsOn.Contains(dependantModule.ModuleName)
			select dependantModule;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00007531 File Offset: 0x00005731
		protected virtual void EnsureCatalogValidated()
		{
			if (!this.Validated)
			{
				this.Validate();
			}
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00007541 File Offset: 0x00005741
		private void ItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (this.Validated)
			{
				this.EnsureCatalogValidated();
			}
		}

		// Token: 0x04000076 RID: 118
		private readonly ModuleCatalog.ModuleCatalogItemCollection items;

		// Token: 0x04000077 RID: 119
		private bool isLoaded;

		// Token: 0x0200009F RID: 159
		private class ModuleCatalogItemCollection : Collection<IModuleCatalogItem>, INotifyCollectionChanged
		{
			// Token: 0x1400001B RID: 27
			// (add) Token: 0x0600042C RID: 1068 RVA: 0x0000A65C File Offset: 0x0000885C
			// (remove) Token: 0x0600042D RID: 1069 RVA: 0x0000A694 File Offset: 0x00008894
			public event NotifyCollectionChangedEventHandler CollectionChanged;

			// Token: 0x0600042E RID: 1070 RVA: 0x0000A6C9 File Offset: 0x000088C9
			protected override void InsertItem(int index, IModuleCatalogItem item)
			{
				base.InsertItem(index, item);
				this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
			}

			// Token: 0x0600042F RID: 1071 RVA: 0x0000A6E1 File Offset: 0x000088E1
			protected void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs eventArgs)
			{
				if (this.CollectionChanged != null)
				{
					this.CollectionChanged(this, eventArgs);
				}
			}
		}
	}
}
