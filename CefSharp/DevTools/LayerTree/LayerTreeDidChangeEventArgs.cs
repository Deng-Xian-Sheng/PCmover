using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.LayerTree
{
	// Token: 0x02000325 RID: 805
	[DataContract]
	public class LayerTreeDidChangeEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000864 RID: 2148
		// (get) Token: 0x060017A6 RID: 6054 RVA: 0x0001B976 File Offset: 0x00019B76
		// (set) Token: 0x060017A7 RID: 6055 RVA: 0x0001B97E File Offset: 0x00019B7E
		[DataMember(Name = "layers", IsRequired = false)]
		public IList<Layer> Layers { get; private set; }
	}
}
