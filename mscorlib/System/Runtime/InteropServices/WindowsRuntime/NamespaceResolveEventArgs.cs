using System;
using System.Collections.ObjectModel;
using System.Reflection;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009F7 RID: 2551
	[ComVisible(false)]
	public class NamespaceResolveEventArgs : EventArgs
	{
		// Token: 0x17001159 RID: 4441
		// (get) Token: 0x060064DF RID: 25823 RVA: 0x00157B5C File Offset: 0x00155D5C
		public string NamespaceName
		{
			get
			{
				return this._NamespaceName;
			}
		}

		// Token: 0x1700115A RID: 4442
		// (get) Token: 0x060064E0 RID: 25824 RVA: 0x00157B64 File Offset: 0x00155D64
		public Assembly RequestingAssembly
		{
			get
			{
				return this._RequestingAssembly;
			}
		}

		// Token: 0x1700115B RID: 4443
		// (get) Token: 0x060064E1 RID: 25825 RVA: 0x00157B6C File Offset: 0x00155D6C
		public Collection<Assembly> ResolvedAssemblies
		{
			get
			{
				return this._ResolvedAssemblies;
			}
		}

		// Token: 0x060064E2 RID: 25826 RVA: 0x00157B74 File Offset: 0x00155D74
		public NamespaceResolveEventArgs(string namespaceName, Assembly requestingAssembly)
		{
			this._NamespaceName = namespaceName;
			this._RequestingAssembly = requestingAssembly;
			this._ResolvedAssemblies = new Collection<Assembly>();
		}

		// Token: 0x04002D25 RID: 11557
		private string _NamespaceName;

		// Token: 0x04002D26 RID: 11558
		private Assembly _RequestingAssembly;

		// Token: 0x04002D27 RID: 11559
		private Collection<Assembly> _ResolvedAssemblies;
	}
}
