using System;
using System.Collections.Generic;

namespace IntelEMA
{
	// Token: 0x0200000F RID: 15
	public class MultipleResults
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000095 RID: 149 RVA: 0x000025F5 File Offset: 0x000007F5
		// (set) Token: 0x06000096 RID: 150 RVA: 0x000025FD File Offset: 0x000007FD
		public List<EndpointIdContainer> Accepted { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00002606 File Offset: 0x00000806
		// (set) Token: 0x06000098 RID: 152 RVA: 0x0000260E File Offset: 0x0000080E
		public List<EndpointIdContainer> Forbidden { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00002617 File Offset: 0x00000817
		// (set) Token: 0x0600009A RID: 154 RVA: 0x0000261F File Offset: 0x0000081F
		public List<EndpointIdContainer> NotFound { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00002628 File Offset: 0x00000828
		// (set) Token: 0x0600009C RID: 156 RVA: 0x00002630 File Offset: 0x00000830
		public List<EndpointIdContainer> BadRequest { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00002639 File Offset: 0x00000839
		// (set) Token: 0x0600009E RID: 158 RVA: 0x00002641 File Offset: 0x00000841
		public List<EndpointIdContainer> InternalServerError { get; set; }
	}
}
