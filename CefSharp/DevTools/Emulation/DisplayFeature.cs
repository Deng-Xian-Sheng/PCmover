using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Emulation
{
	// Token: 0x02000352 RID: 850
	[DataContract]
	public class DisplayFeature : DevToolsDomainEntityBase
	{
		// Token: 0x170008BA RID: 2234
		// (get) Token: 0x06001892 RID: 6290 RVA: 0x0001D129 File Offset: 0x0001B329
		// (set) Token: 0x06001893 RID: 6291 RVA: 0x0001D145 File Offset: 0x0001B345
		public DisplayFeatureOrientation Orientation
		{
			get
			{
				return (DisplayFeatureOrientation)DevToolsDomainEntityBase.StringToEnum(typeof(DisplayFeatureOrientation), this.orientation);
			}
			set
			{
				this.orientation = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170008BB RID: 2235
		// (get) Token: 0x06001894 RID: 6292 RVA: 0x0001D158 File Offset: 0x0001B358
		// (set) Token: 0x06001895 RID: 6293 RVA: 0x0001D160 File Offset: 0x0001B360
		[DataMember(Name = "orientation", IsRequired = true)]
		internal string orientation { get; set; }

		// Token: 0x170008BC RID: 2236
		// (get) Token: 0x06001896 RID: 6294 RVA: 0x0001D169 File Offset: 0x0001B369
		// (set) Token: 0x06001897 RID: 6295 RVA: 0x0001D171 File Offset: 0x0001B371
		[DataMember(Name = "offset", IsRequired = true)]
		public int Offset { get; set; }

		// Token: 0x170008BD RID: 2237
		// (get) Token: 0x06001898 RID: 6296 RVA: 0x0001D17A File Offset: 0x0001B37A
		// (set) Token: 0x06001899 RID: 6297 RVA: 0x0001D182 File Offset: 0x0001B382
		[DataMember(Name = "maskLength", IsRequired = true)]
		public int MaskLength { get; set; }
	}
}
