using System;
using System.Collections.ObjectModel;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009F8 RID: 2552
	[ComVisible(false)]
	public class DesignerNamespaceResolveEventArgs : EventArgs
	{
		// Token: 0x1700115C RID: 4444
		// (get) Token: 0x060064E3 RID: 25827 RVA: 0x00157B95 File Offset: 0x00155D95
		public string NamespaceName
		{
			get
			{
				return this._NamespaceName;
			}
		}

		// Token: 0x1700115D RID: 4445
		// (get) Token: 0x060064E4 RID: 25828 RVA: 0x00157B9D File Offset: 0x00155D9D
		public Collection<string> ResolvedAssemblyFiles
		{
			get
			{
				return this._ResolvedAssemblyFiles;
			}
		}

		// Token: 0x060064E5 RID: 25829 RVA: 0x00157BA5 File Offset: 0x00155DA5
		public DesignerNamespaceResolveEventArgs(string namespaceName)
		{
			this._NamespaceName = namespaceName;
			this._ResolvedAssemblyFiles = new Collection<string>();
		}

		// Token: 0x04002D28 RID: 11560
		private string _NamespaceName;

		// Token: 0x04002D29 RID: 11561
		private Collection<string> _ResolvedAssemblyFiles;
	}
}
