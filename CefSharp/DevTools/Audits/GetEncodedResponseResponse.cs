using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000430 RID: 1072
	[DataContract]
	public class GetEncodedResponseResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000B65 RID: 2917
		// (get) Token: 0x06001F26 RID: 7974 RVA: 0x000233A1 File Offset: 0x000215A1
		// (set) Token: 0x06001F27 RID: 7975 RVA: 0x000233A9 File Offset: 0x000215A9
		[DataMember]
		internal string body { get; set; }

		// Token: 0x17000B66 RID: 2918
		// (get) Token: 0x06001F28 RID: 7976 RVA: 0x000233B2 File Offset: 0x000215B2
		public byte[] Body
		{
			get
			{
				return base.Convert(this.body);
			}
		}

		// Token: 0x17000B67 RID: 2919
		// (get) Token: 0x06001F29 RID: 7977 RVA: 0x000233C0 File Offset: 0x000215C0
		// (set) Token: 0x06001F2A RID: 7978 RVA: 0x000233C8 File Offset: 0x000215C8
		[DataMember]
		internal int originalSize { get; set; }

		// Token: 0x17000B68 RID: 2920
		// (get) Token: 0x06001F2B RID: 7979 RVA: 0x000233D1 File Offset: 0x000215D1
		public int OriginalSize
		{
			get
			{
				return this.originalSize;
			}
		}

		// Token: 0x17000B69 RID: 2921
		// (get) Token: 0x06001F2C RID: 7980 RVA: 0x000233D9 File Offset: 0x000215D9
		// (set) Token: 0x06001F2D RID: 7981 RVA: 0x000233E1 File Offset: 0x000215E1
		[DataMember]
		internal int encodedSize { get; set; }

		// Token: 0x17000B6A RID: 2922
		// (get) Token: 0x06001F2E RID: 7982 RVA: 0x000233EA File Offset: 0x000215EA
		public int EncodedSize
		{
			get
			{
				return this.encodedSize;
			}
		}
	}
}
