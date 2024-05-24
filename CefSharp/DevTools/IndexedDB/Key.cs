using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.IndexedDB
{
	// Token: 0x02000340 RID: 832
	[DataContract]
	public class Key : DevToolsDomainEntityBase
	{
		// Token: 0x17000892 RID: 2194
		// (get) Token: 0x06001830 RID: 6192 RVA: 0x0001CA8A File Offset: 0x0001AC8A
		// (set) Token: 0x06001831 RID: 6193 RVA: 0x0001CAA6 File Offset: 0x0001ACA6
		public KeyType Type
		{
			get
			{
				return (KeyType)DevToolsDomainEntityBase.StringToEnum(typeof(KeyType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000893 RID: 2195
		// (get) Token: 0x06001832 RID: 6194 RVA: 0x0001CAB9 File Offset: 0x0001ACB9
		// (set) Token: 0x06001833 RID: 6195 RVA: 0x0001CAC1 File Offset: 0x0001ACC1
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x17000894 RID: 2196
		// (get) Token: 0x06001834 RID: 6196 RVA: 0x0001CACA File Offset: 0x0001ACCA
		// (set) Token: 0x06001835 RID: 6197 RVA: 0x0001CAD2 File Offset: 0x0001ACD2
		[DataMember(Name = "number", IsRequired = false)]
		public double? Number { get; set; }

		// Token: 0x17000895 RID: 2197
		// (get) Token: 0x06001836 RID: 6198 RVA: 0x0001CADB File Offset: 0x0001ACDB
		// (set) Token: 0x06001837 RID: 6199 RVA: 0x0001CAE3 File Offset: 0x0001ACE3
		[DataMember(Name = "string", IsRequired = false)]
		public string String { get; set; }

		// Token: 0x17000896 RID: 2198
		// (get) Token: 0x06001838 RID: 6200 RVA: 0x0001CAEC File Offset: 0x0001ACEC
		// (set) Token: 0x06001839 RID: 6201 RVA: 0x0001CAF4 File Offset: 0x0001ACF4
		[DataMember(Name = "date", IsRequired = false)]
		public double? Date { get; set; }

		// Token: 0x17000897 RID: 2199
		// (get) Token: 0x0600183A RID: 6202 RVA: 0x0001CAFD File Offset: 0x0001ACFD
		// (set) Token: 0x0600183B RID: 6203 RVA: 0x0001CB05 File Offset: 0x0001AD05
		[DataMember(Name = "array", IsRequired = false)]
		public IList<Key> Array { get; set; }
	}
}
