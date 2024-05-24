using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Properties;

namespace Prism.Modularity
{
	// Token: 0x02000063 RID: 99
	public class ModuleInfoGroup : IModuleCatalogItem, IList<ModuleInfo>, ICollection<ModuleInfo>, IEnumerable<ModuleInfo>, IEnumerable, IList, ICollection
	{
		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002DE RID: 734 RVA: 0x00007C78 File Offset: 0x00005E78
		// (set) Token: 0x060002DF RID: 735 RVA: 0x00007C80 File Offset: 0x00005E80
		public InitializationMode InitializationMode { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00007C89 File Offset: 0x00005E89
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x00007C91 File Offset: 0x00005E91
		public string Ref { get; set; }

		// Token: 0x060002E2 RID: 738 RVA: 0x00007C9A File Offset: 0x00005E9A
		public void Add(ModuleInfo item)
		{
			this.ForwardValues(item);
			this.modules.Add(item);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00007CAF File Offset: 0x00005EAF
		protected void ForwardValues(ModuleInfo moduleInfo)
		{
			if (moduleInfo == null)
			{
				throw new ArgumentNullException("moduleInfo");
			}
			if (moduleInfo.Ref == null)
			{
				moduleInfo.Ref = this.Ref;
			}
			if (moduleInfo.InitializationMode == InitializationMode.WhenAvailable && this.InitializationMode != InitializationMode.WhenAvailable)
			{
				moduleInfo.InitializationMode = this.InitializationMode;
			}
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00007CEF File Offset: 0x00005EEF
		public void Clear()
		{
			this.modules.Clear();
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00007CFC File Offset: 0x00005EFC
		public bool Contains(ModuleInfo item)
		{
			return this.modules.Contains(item);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00007D0A File Offset: 0x00005F0A
		public void CopyTo(ModuleInfo[] array, int arrayIndex)
		{
			this.modules.CopyTo(array, arrayIndex);
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x00007D19 File Offset: 0x00005F19
		public int Count
		{
			get
			{
				return this.modules.Count;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x000076BB File Offset: 0x000058BB
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00007D26 File Offset: 0x00005F26
		public bool Remove(ModuleInfo item)
		{
			return this.modules.Remove(item);
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00007D34 File Offset: 0x00005F34
		public IEnumerator<ModuleInfo> GetEnumerator()
		{
			return this.modules.GetEnumerator();
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00007D41 File Offset: 0x00005F41
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00007D49 File Offset: 0x00005F49
		int IList.Add(object value)
		{
			this.Add((ModuleInfo)value);
			return 1;
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00007D58 File Offset: 0x00005F58
		bool IList.Contains(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			ModuleInfo moduleInfo = value as ModuleInfo;
			if (moduleInfo == null)
			{
				throw new ArgumentException(Resources.ValueMustBeOfTypeModuleInfo, "value");
			}
			return this.Contains(moduleInfo);
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00007D94 File Offset: 0x00005F94
		public int IndexOf(object value)
		{
			return this.modules.IndexOf((ModuleInfo)value);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00007DA8 File Offset: 0x00005FA8
		public void Insert(int index, object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			ModuleInfo moduleInfo = value as ModuleInfo;
			if (moduleInfo == null)
			{
				throw new ArgumentException(Resources.ValueMustBeOfTypeModuleInfo, "value");
			}
			this.modules.Insert(index, moduleInfo);
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x000076BB File Offset: 0x000058BB
		public bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00007DEA File Offset: 0x00005FEA
		void IList.Remove(object value)
		{
			this.Remove((ModuleInfo)value);
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00007DF9 File Offset: 0x00005FF9
		public void RemoveAt(int index)
		{
			this.modules.RemoveAt(index);
		}

		// Token: 0x170000B7 RID: 183
		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				this[index] = (ModuleInfo)value;
			}
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00007E1F File Offset: 0x0000601F
		void ICollection.CopyTo(Array array, int index)
		{
			((ICollection)this.modules).CopyTo(array, index);
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x00007E2E File Offset: 0x0000602E
		public bool IsSynchronized
		{
			get
			{
				return ((ICollection)this.modules).IsSynchronized;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x00007E3B File Offset: 0x0000603B
		public object SyncRoot
		{
			get
			{
				return ((ICollection)this.modules).SyncRoot;
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00007E48 File Offset: 0x00006048
		public int IndexOf(ModuleInfo item)
		{
			return this.modules.IndexOf(item);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00007E56 File Offset: 0x00006056
		public void Insert(int index, ModuleInfo item)
		{
			this.modules.Insert(index, item);
		}

		// Token: 0x170000BA RID: 186
		public ModuleInfo this[int index]
		{
			get
			{
				return this.modules[index];
			}
			set
			{
				this.modules[index] = value;
			}
		}

		// Token: 0x04000085 RID: 133
		private readonly Collection<ModuleInfo> modules = new Collection<ModuleInfo>();
	}
}
