using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000383 RID: 899
	[DataContract]
	public class BoxModel : DevToolsDomainEntityBase
	{
		// Token: 0x17000980 RID: 2432
		// (get) Token: 0x06001A78 RID: 6776 RVA: 0x0001EE05 File Offset: 0x0001D005
		// (set) Token: 0x06001A79 RID: 6777 RVA: 0x0001EE0D File Offset: 0x0001D00D
		[DataMember(Name = "content", IsRequired = true)]
		public double[] Content { get; set; }

		// Token: 0x17000981 RID: 2433
		// (get) Token: 0x06001A7A RID: 6778 RVA: 0x0001EE16 File Offset: 0x0001D016
		// (set) Token: 0x06001A7B RID: 6779 RVA: 0x0001EE1E File Offset: 0x0001D01E
		[DataMember(Name = "padding", IsRequired = true)]
		public double[] Padding { get; set; }

		// Token: 0x17000982 RID: 2434
		// (get) Token: 0x06001A7C RID: 6780 RVA: 0x0001EE27 File Offset: 0x0001D027
		// (set) Token: 0x06001A7D RID: 6781 RVA: 0x0001EE2F File Offset: 0x0001D02F
		[DataMember(Name = "border", IsRequired = true)]
		public double[] Border { get; set; }

		// Token: 0x17000983 RID: 2435
		// (get) Token: 0x06001A7E RID: 6782 RVA: 0x0001EE38 File Offset: 0x0001D038
		// (set) Token: 0x06001A7F RID: 6783 RVA: 0x0001EE40 File Offset: 0x0001D040
		[DataMember(Name = "margin", IsRequired = true)]
		public double[] Margin { get; set; }

		// Token: 0x17000984 RID: 2436
		// (get) Token: 0x06001A80 RID: 6784 RVA: 0x0001EE49 File Offset: 0x0001D049
		// (set) Token: 0x06001A81 RID: 6785 RVA: 0x0001EE51 File Offset: 0x0001D051
		[DataMember(Name = "width", IsRequired = true)]
		public int Width { get; set; }

		// Token: 0x17000985 RID: 2437
		// (get) Token: 0x06001A82 RID: 6786 RVA: 0x0001EE5A File Offset: 0x0001D05A
		// (set) Token: 0x06001A83 RID: 6787 RVA: 0x0001EE62 File Offset: 0x0001D062
		[DataMember(Name = "height", IsRequired = true)]
		public int Height { get; set; }

		// Token: 0x17000986 RID: 2438
		// (get) Token: 0x06001A84 RID: 6788 RVA: 0x0001EE6B File Offset: 0x0001D06B
		// (set) Token: 0x06001A85 RID: 6789 RVA: 0x0001EE73 File Offset: 0x0001D073
		[DataMember(Name = "shapeOutside", IsRequired = false)]
		public ShapeOutsideInfo ShapeOutside { get; set; }
	}
}
