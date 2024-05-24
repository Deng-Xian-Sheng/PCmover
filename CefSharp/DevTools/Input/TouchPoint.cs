using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Input
{
	// Token: 0x0200032F RID: 815
	[DataContract]
	public class TouchPoint : DevToolsDomainEntityBase
	{
		// Token: 0x17000874 RID: 2164
		// (get) Token: 0x060017DE RID: 6110 RVA: 0x0001BE18 File Offset: 0x0001A018
		// (set) Token: 0x060017DF RID: 6111 RVA: 0x0001BE20 File Offset: 0x0001A020
		[DataMember(Name = "x", IsRequired = true)]
		public double X { get; set; }

		// Token: 0x17000875 RID: 2165
		// (get) Token: 0x060017E0 RID: 6112 RVA: 0x0001BE29 File Offset: 0x0001A029
		// (set) Token: 0x060017E1 RID: 6113 RVA: 0x0001BE31 File Offset: 0x0001A031
		[DataMember(Name = "y", IsRequired = true)]
		public double Y { get; set; }

		// Token: 0x17000876 RID: 2166
		// (get) Token: 0x060017E2 RID: 6114 RVA: 0x0001BE3A File Offset: 0x0001A03A
		// (set) Token: 0x060017E3 RID: 6115 RVA: 0x0001BE42 File Offset: 0x0001A042
		[DataMember(Name = "radiusX", IsRequired = false)]
		public double? RadiusX { get; set; }

		// Token: 0x17000877 RID: 2167
		// (get) Token: 0x060017E4 RID: 6116 RVA: 0x0001BE4B File Offset: 0x0001A04B
		// (set) Token: 0x060017E5 RID: 6117 RVA: 0x0001BE53 File Offset: 0x0001A053
		[DataMember(Name = "radiusY", IsRequired = false)]
		public double? RadiusY { get; set; }

		// Token: 0x17000878 RID: 2168
		// (get) Token: 0x060017E6 RID: 6118 RVA: 0x0001BE5C File Offset: 0x0001A05C
		// (set) Token: 0x060017E7 RID: 6119 RVA: 0x0001BE64 File Offset: 0x0001A064
		[DataMember(Name = "rotationAngle", IsRequired = false)]
		public double? RotationAngle { get; set; }

		// Token: 0x17000879 RID: 2169
		// (get) Token: 0x060017E8 RID: 6120 RVA: 0x0001BE6D File Offset: 0x0001A06D
		// (set) Token: 0x060017E9 RID: 6121 RVA: 0x0001BE75 File Offset: 0x0001A075
		[DataMember(Name = "force", IsRequired = false)]
		public double? Force { get; set; }

		// Token: 0x1700087A RID: 2170
		// (get) Token: 0x060017EA RID: 6122 RVA: 0x0001BE7E File Offset: 0x0001A07E
		// (set) Token: 0x060017EB RID: 6123 RVA: 0x0001BE86 File Offset: 0x0001A086
		[DataMember(Name = "tangentialPressure", IsRequired = false)]
		public double? TangentialPressure { get; set; }

		// Token: 0x1700087B RID: 2171
		// (get) Token: 0x060017EC RID: 6124 RVA: 0x0001BE8F File Offset: 0x0001A08F
		// (set) Token: 0x060017ED RID: 6125 RVA: 0x0001BE97 File Offset: 0x0001A097
		[DataMember(Name = "tiltX", IsRequired = false)]
		public int? TiltX { get; set; }

		// Token: 0x1700087C RID: 2172
		// (get) Token: 0x060017EE RID: 6126 RVA: 0x0001BEA0 File Offset: 0x0001A0A0
		// (set) Token: 0x060017EF RID: 6127 RVA: 0x0001BEA8 File Offset: 0x0001A0A8
		[DataMember(Name = "tiltY", IsRequired = false)]
		public int? TiltY { get; set; }

		// Token: 0x1700087D RID: 2173
		// (get) Token: 0x060017F0 RID: 6128 RVA: 0x0001BEB1 File Offset: 0x0001A0B1
		// (set) Token: 0x060017F1 RID: 6129 RVA: 0x0001BEB9 File Offset: 0x0001A0B9
		[DataMember(Name = "twist", IsRequired = false)]
		public int? Twist { get; set; }

		// Token: 0x1700087E RID: 2174
		// (get) Token: 0x060017F2 RID: 6130 RVA: 0x0001BEC2 File Offset: 0x0001A0C2
		// (set) Token: 0x060017F3 RID: 6131 RVA: 0x0001BECA File Offset: 0x0001A0CA
		[DataMember(Name = "id", IsRequired = false)]
		public double? Id { get; set; }
	}
}
