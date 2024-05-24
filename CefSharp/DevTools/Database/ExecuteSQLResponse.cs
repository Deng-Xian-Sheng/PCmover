using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Database
{
	// Token: 0x02000360 RID: 864
	[DataContract]
	public class ExecuteSQLResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170008D5 RID: 2261
		// (get) Token: 0x060018EB RID: 6379 RVA: 0x0001DB25 File Offset: 0x0001BD25
		// (set) Token: 0x060018EC RID: 6380 RVA: 0x0001DB2D File Offset: 0x0001BD2D
		[DataMember]
		internal string[] columnNames { get; set; }

		// Token: 0x170008D6 RID: 2262
		// (get) Token: 0x060018ED RID: 6381 RVA: 0x0001DB36 File Offset: 0x0001BD36
		public string[] ColumnNames
		{
			get
			{
				return this.columnNames;
			}
		}

		// Token: 0x170008D7 RID: 2263
		// (get) Token: 0x060018EE RID: 6382 RVA: 0x0001DB3E File Offset: 0x0001BD3E
		// (set) Token: 0x060018EF RID: 6383 RVA: 0x0001DB46 File Offset: 0x0001BD46
		[DataMember]
		internal object[] values { get; set; }

		// Token: 0x170008D8 RID: 2264
		// (get) Token: 0x060018F0 RID: 6384 RVA: 0x0001DB4F File Offset: 0x0001BD4F
		public object[] Values
		{
			get
			{
				return this.values;
			}
		}

		// Token: 0x170008D9 RID: 2265
		// (get) Token: 0x060018F1 RID: 6385 RVA: 0x0001DB57 File Offset: 0x0001BD57
		// (set) Token: 0x060018F2 RID: 6386 RVA: 0x0001DB5F File Offset: 0x0001BD5F
		[DataMember]
		internal Error sqlError { get; set; }

		// Token: 0x170008DA RID: 2266
		// (get) Token: 0x060018F3 RID: 6387 RVA: 0x0001DB68 File Offset: 0x0001BD68
		public Error SqlError
		{
			get
			{
				return this.sqlError;
			}
		}
	}
}
