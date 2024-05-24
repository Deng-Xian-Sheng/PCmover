using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000150 RID: 336
	[DataContract]
	public class GlobalLexicalScopeNamesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x060009B5 RID: 2485 RVA: 0x0000E8D3 File Offset: 0x0000CAD3
		// (set) Token: 0x060009B6 RID: 2486 RVA: 0x0000E8DB File Offset: 0x0000CADB
		[DataMember]
		internal string[] names { get; set; }

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x060009B7 RID: 2487 RVA: 0x0000E8E4 File Offset: 0x0000CAE4
		public string[] Names
		{
			get
			{
				return this.names;
			}
		}
	}
}
