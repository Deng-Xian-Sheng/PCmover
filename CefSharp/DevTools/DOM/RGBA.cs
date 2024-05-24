using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000382 RID: 898
	[DataContract]
	public class RGBA : DevToolsDomainEntityBase
	{
		// Token: 0x1700097C RID: 2428
		// (get) Token: 0x06001A6F RID: 6767 RVA: 0x0001EDB9 File Offset: 0x0001CFB9
		// (set) Token: 0x06001A70 RID: 6768 RVA: 0x0001EDC1 File Offset: 0x0001CFC1
		[DataMember(Name = "r", IsRequired = true)]
		public int R { get; set; }

		// Token: 0x1700097D RID: 2429
		// (get) Token: 0x06001A71 RID: 6769 RVA: 0x0001EDCA File Offset: 0x0001CFCA
		// (set) Token: 0x06001A72 RID: 6770 RVA: 0x0001EDD2 File Offset: 0x0001CFD2
		[DataMember(Name = "g", IsRequired = true)]
		public int G { get; set; }

		// Token: 0x1700097E RID: 2430
		// (get) Token: 0x06001A73 RID: 6771 RVA: 0x0001EDDB File Offset: 0x0001CFDB
		// (set) Token: 0x06001A74 RID: 6772 RVA: 0x0001EDE3 File Offset: 0x0001CFE3
		[DataMember(Name = "b", IsRequired = true)]
		public int B { get; set; }

		// Token: 0x1700097F RID: 2431
		// (get) Token: 0x06001A75 RID: 6773 RVA: 0x0001EDEC File Offset: 0x0001CFEC
		// (set) Token: 0x06001A76 RID: 6774 RVA: 0x0001EDF4 File Offset: 0x0001CFF4
		[DataMember(Name = "a", IsRequired = false)]
		public double? A { get; set; }
	}
}
