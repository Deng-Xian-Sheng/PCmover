using System;
using System.Collections.ObjectModel;

namespace Prism.Modularity
{
	// Token: 0x02000062 RID: 98
	[Serializable]
	public class ModuleInfo : IModuleCatalogItem
	{
		// Token: 0x060002CF RID: 719 RVA: 0x00007B97 File Offset: 0x00005D97
		public ModuleInfo() : this(null, null, new string[0])
		{
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00007BA8 File Offset: 0x00005DA8
		public ModuleInfo(string name, string type, params string[] dependsOn)
		{
			if (dependsOn == null)
			{
				throw new ArgumentNullException("dependsOn");
			}
			this.ModuleName = name;
			this.ModuleType = type;
			this.DependsOn = new Collection<string>();
			foreach (string item in dependsOn)
			{
				this.DependsOn.Add(item);
			}
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00007C02 File Offset: 0x00005E02
		public ModuleInfo(string name, string type) : this(name, type, new string[0])
		{
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x00007C12 File Offset: 0x00005E12
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x00007C1A File Offset: 0x00005E1A
		public string ModuleName { get; set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x00007C23 File Offset: 0x00005E23
		// (set) Token: 0x060002D5 RID: 725 RVA: 0x00007C2B File Offset: 0x00005E2B
		public string ModuleType { get; set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x00007C34 File Offset: 0x00005E34
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x00007C3C File Offset: 0x00005E3C
		public Collection<string> DependsOn { get; set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00007C45 File Offset: 0x00005E45
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x00007C4D File Offset: 0x00005E4D
		public InitializationMode InitializationMode { get; set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002DA RID: 730 RVA: 0x00007C56 File Offset: 0x00005E56
		// (set) Token: 0x060002DB RID: 731 RVA: 0x00007C5E File Offset: 0x00005E5E
		public string Ref { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002DC RID: 732 RVA: 0x00007C67 File Offset: 0x00005E67
		// (set) Token: 0x060002DD RID: 733 RVA: 0x00007C6F File Offset: 0x00005E6F
		public ModuleState State { get; set; }
	}
}
