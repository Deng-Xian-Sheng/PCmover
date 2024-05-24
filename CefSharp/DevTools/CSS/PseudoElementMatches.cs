using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003BE RID: 958
	[DataContract]
	public class PseudoElementMatches : DevToolsDomainEntityBase
	{
		// Token: 0x17000A03 RID: 2563
		// (get) Token: 0x06001BEE RID: 7150 RVA: 0x00020AC6 File Offset: 0x0001ECC6
		// (set) Token: 0x06001BEF RID: 7151 RVA: 0x00020AE2 File Offset: 0x0001ECE2
		public PseudoType PseudoType
		{
			get
			{
				return (PseudoType)DevToolsDomainEntityBase.StringToEnum(typeof(PseudoType), this.pseudoType);
			}
			set
			{
				this.pseudoType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000A04 RID: 2564
		// (get) Token: 0x06001BF0 RID: 7152 RVA: 0x00020AF5 File Offset: 0x0001ECF5
		// (set) Token: 0x06001BF1 RID: 7153 RVA: 0x00020AFD File Offset: 0x0001ECFD
		[DataMember(Name = "pseudoType", IsRequired = true)]
		internal string pseudoType { get; set; }

		// Token: 0x17000A05 RID: 2565
		// (get) Token: 0x06001BF2 RID: 7154 RVA: 0x00020B06 File Offset: 0x0001ED06
		// (set) Token: 0x06001BF3 RID: 7155 RVA: 0x00020B0E File Offset: 0x0001ED0E
		[DataMember(Name = "matches", IsRequired = true)]
		public IList<RuleMatch> Matches { get; set; }
	}
}
