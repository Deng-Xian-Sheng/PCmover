using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Emulation
{
	// Token: 0x02000350 RID: 848
	[DataContract]
	public class ScreenOrientation : DevToolsDomainEntityBase
	{
		// Token: 0x170008B7 RID: 2231
		// (get) Token: 0x0600188B RID: 6283 RVA: 0x0001D0D0 File Offset: 0x0001B2D0
		// (set) Token: 0x0600188C RID: 6284 RVA: 0x0001D0EC File Offset: 0x0001B2EC
		public ScreenOrientationType Type
		{
			get
			{
				return (ScreenOrientationType)DevToolsDomainEntityBase.StringToEnum(typeof(ScreenOrientationType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170008B8 RID: 2232
		// (get) Token: 0x0600188D RID: 6285 RVA: 0x0001D0FF File Offset: 0x0001B2FF
		// (set) Token: 0x0600188E RID: 6286 RVA: 0x0001D107 File Offset: 0x0001B307
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x170008B9 RID: 2233
		// (get) Token: 0x0600188F RID: 6287 RVA: 0x0001D110 File Offset: 0x0001B310
		// (set) Token: 0x06001890 RID: 6288 RVA: 0x0001D118 File Offset: 0x0001B318
		[DataMember(Name = "angle", IsRequired = true)]
		public int Angle { get; set; }
	}
}
