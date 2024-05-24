using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.LayerTree
{
	// Token: 0x02000324 RID: 804
	[DataContract]
	public class LayerPaintedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000862 RID: 2146
		// (get) Token: 0x060017A1 RID: 6049 RVA: 0x0001B94C File Offset: 0x00019B4C
		// (set) Token: 0x060017A2 RID: 6050 RVA: 0x0001B954 File Offset: 0x00019B54
		[DataMember(Name = "layerId", IsRequired = true)]
		public string LayerId { get; private set; }

		// Token: 0x17000863 RID: 2147
		// (get) Token: 0x060017A3 RID: 6051 RVA: 0x0001B95D File Offset: 0x00019B5D
		// (set) Token: 0x060017A4 RID: 6052 RVA: 0x0001B965 File Offset: 0x00019B65
		[DataMember(Name = "clip", IsRequired = true)]
		public Rect Clip { get; private set; }
	}
}
