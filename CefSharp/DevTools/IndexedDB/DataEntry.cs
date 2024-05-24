using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.IndexedDB
{
	// Token: 0x02000342 RID: 834
	[DataContract]
	public class DataEntry : DevToolsDomainEntityBase
	{
		// Token: 0x1700089C RID: 2204
		// (get) Token: 0x06001846 RID: 6214 RVA: 0x0001CB62 File Offset: 0x0001AD62
		// (set) Token: 0x06001847 RID: 6215 RVA: 0x0001CB6A File Offset: 0x0001AD6A
		[DataMember(Name = "key", IsRequired = true)]
		public RemoteObject Key { get; set; }

		// Token: 0x1700089D RID: 2205
		// (get) Token: 0x06001848 RID: 6216 RVA: 0x0001CB73 File Offset: 0x0001AD73
		// (set) Token: 0x06001849 RID: 6217 RVA: 0x0001CB7B File Offset: 0x0001AD7B
		[DataMember(Name = "primaryKey", IsRequired = true)]
		public RemoteObject PrimaryKey { get; set; }

		// Token: 0x1700089E RID: 2206
		// (get) Token: 0x0600184A RID: 6218 RVA: 0x0001CB84 File Offset: 0x0001AD84
		// (set) Token: 0x0600184B RID: 6219 RVA: 0x0001CB8C File Offset: 0x0001AD8C
		[DataMember(Name = "value", IsRequired = true)]
		public RemoteObject Value { get; set; }
	}
}
