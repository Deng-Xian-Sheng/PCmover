using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.LayerTree
{
	// Token: 0x02000322 RID: 802
	[DataContract]
	public class PictureTile : DevToolsDomainEntityBase
	{
		// Token: 0x1700084F RID: 2127
		// (get) Token: 0x06001779 RID: 6009 RVA: 0x0001B7F9 File Offset: 0x000199F9
		// (set) Token: 0x0600177A RID: 6010 RVA: 0x0001B801 File Offset: 0x00019A01
		[DataMember(Name = "x", IsRequired = true)]
		public double X { get; set; }

		// Token: 0x17000850 RID: 2128
		// (get) Token: 0x0600177B RID: 6011 RVA: 0x0001B80A File Offset: 0x00019A0A
		// (set) Token: 0x0600177C RID: 6012 RVA: 0x0001B812 File Offset: 0x00019A12
		[DataMember(Name = "y", IsRequired = true)]
		public double Y { get; set; }

		// Token: 0x17000851 RID: 2129
		// (get) Token: 0x0600177D RID: 6013 RVA: 0x0001B81B File Offset: 0x00019A1B
		// (set) Token: 0x0600177E RID: 6014 RVA: 0x0001B823 File Offset: 0x00019A23
		[DataMember(Name = "picture", IsRequired = true)]
		public byte[] Picture { get; set; }
	}
}
