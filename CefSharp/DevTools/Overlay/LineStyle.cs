using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x02000290 RID: 656
	[DataContract]
	public class LineStyle : DevToolsDomainEntityBase
	{
		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x060012C3 RID: 4803 RVA: 0x00017586 File Offset: 0x00015786
		// (set) Token: 0x060012C4 RID: 4804 RVA: 0x0001758E File Offset: 0x0001578E
		[DataMember(Name = "color", IsRequired = false)]
		public RGBA Color { get; set; }

		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x060012C5 RID: 4805 RVA: 0x00017597 File Offset: 0x00015797
		// (set) Token: 0x060012C6 RID: 4806 RVA: 0x000175B3 File Offset: 0x000157B3
		public LineStylePattern? Pattern
		{
			get
			{
				return (LineStylePattern?)DevToolsDomainEntityBase.StringToEnum(typeof(LineStylePattern?), this.pattern);
			}
			set
			{
				this.pattern = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x060012C7 RID: 4807 RVA: 0x000175C6 File Offset: 0x000157C6
		// (set) Token: 0x060012C8 RID: 4808 RVA: 0x000175CE File Offset: 0x000157CE
		[DataMember(Name = "pattern", IsRequired = false)]
		internal string pattern { get; set; }
	}
}
