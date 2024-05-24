using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.LayerTree
{
	// Token: 0x02000320 RID: 800
	[DataContract]
	public class ScrollRect : DevToolsDomainEntityBase
	{
		// Token: 0x17000848 RID: 2120
		// (get) Token: 0x06001769 RID: 5993 RVA: 0x0001B754 File Offset: 0x00019954
		// (set) Token: 0x0600176A RID: 5994 RVA: 0x0001B75C File Offset: 0x0001995C
		[DataMember(Name = "rect", IsRequired = true)]
		public Rect Rect { get; set; }

		// Token: 0x17000849 RID: 2121
		// (get) Token: 0x0600176B RID: 5995 RVA: 0x0001B765 File Offset: 0x00019965
		// (set) Token: 0x0600176C RID: 5996 RVA: 0x0001B781 File Offset: 0x00019981
		public ScrollRectType Type
		{
			get
			{
				return (ScrollRectType)DevToolsDomainEntityBase.StringToEnum(typeof(ScrollRectType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700084A RID: 2122
		// (get) Token: 0x0600176D RID: 5997 RVA: 0x0001B794 File Offset: 0x00019994
		// (set) Token: 0x0600176E RID: 5998 RVA: 0x0001B79C File Offset: 0x0001999C
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }
	}
}
