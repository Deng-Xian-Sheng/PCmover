using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002AC RID: 684
	[DataContract]
	public class ResourceTiming : DevToolsDomainEntityBase
	{
		// Token: 0x170006A0 RID: 1696
		// (get) Token: 0x06001367 RID: 4967 RVA: 0x00018290 File Offset: 0x00016490
		// (set) Token: 0x06001368 RID: 4968 RVA: 0x00018298 File Offset: 0x00016498
		[DataMember(Name = "requestTime", IsRequired = true)]
		public double RequestTime { get; set; }

		// Token: 0x170006A1 RID: 1697
		// (get) Token: 0x06001369 RID: 4969 RVA: 0x000182A1 File Offset: 0x000164A1
		// (set) Token: 0x0600136A RID: 4970 RVA: 0x000182A9 File Offset: 0x000164A9
		[DataMember(Name = "proxyStart", IsRequired = true)]
		public double ProxyStart { get; set; }

		// Token: 0x170006A2 RID: 1698
		// (get) Token: 0x0600136B RID: 4971 RVA: 0x000182B2 File Offset: 0x000164B2
		// (set) Token: 0x0600136C RID: 4972 RVA: 0x000182BA File Offset: 0x000164BA
		[DataMember(Name = "proxyEnd", IsRequired = true)]
		public double ProxyEnd { get; set; }

		// Token: 0x170006A3 RID: 1699
		// (get) Token: 0x0600136D RID: 4973 RVA: 0x000182C3 File Offset: 0x000164C3
		// (set) Token: 0x0600136E RID: 4974 RVA: 0x000182CB File Offset: 0x000164CB
		[DataMember(Name = "dnsStart", IsRequired = true)]
		public double DnsStart { get; set; }

		// Token: 0x170006A4 RID: 1700
		// (get) Token: 0x0600136F RID: 4975 RVA: 0x000182D4 File Offset: 0x000164D4
		// (set) Token: 0x06001370 RID: 4976 RVA: 0x000182DC File Offset: 0x000164DC
		[DataMember(Name = "dnsEnd", IsRequired = true)]
		public double DnsEnd { get; set; }

		// Token: 0x170006A5 RID: 1701
		// (get) Token: 0x06001371 RID: 4977 RVA: 0x000182E5 File Offset: 0x000164E5
		// (set) Token: 0x06001372 RID: 4978 RVA: 0x000182ED File Offset: 0x000164ED
		[DataMember(Name = "connectStart", IsRequired = true)]
		public double ConnectStart { get; set; }

		// Token: 0x170006A6 RID: 1702
		// (get) Token: 0x06001373 RID: 4979 RVA: 0x000182F6 File Offset: 0x000164F6
		// (set) Token: 0x06001374 RID: 4980 RVA: 0x000182FE File Offset: 0x000164FE
		[DataMember(Name = "connectEnd", IsRequired = true)]
		public double ConnectEnd { get; set; }

		// Token: 0x170006A7 RID: 1703
		// (get) Token: 0x06001375 RID: 4981 RVA: 0x00018307 File Offset: 0x00016507
		// (set) Token: 0x06001376 RID: 4982 RVA: 0x0001830F File Offset: 0x0001650F
		[DataMember(Name = "sslStart", IsRequired = true)]
		public double SslStart { get; set; }

		// Token: 0x170006A8 RID: 1704
		// (get) Token: 0x06001377 RID: 4983 RVA: 0x00018318 File Offset: 0x00016518
		// (set) Token: 0x06001378 RID: 4984 RVA: 0x00018320 File Offset: 0x00016520
		[DataMember(Name = "sslEnd", IsRequired = true)]
		public double SslEnd { get; set; }

		// Token: 0x170006A9 RID: 1705
		// (get) Token: 0x06001379 RID: 4985 RVA: 0x00018329 File Offset: 0x00016529
		// (set) Token: 0x0600137A RID: 4986 RVA: 0x00018331 File Offset: 0x00016531
		[DataMember(Name = "workerStart", IsRequired = true)]
		public double WorkerStart { get; set; }

		// Token: 0x170006AA RID: 1706
		// (get) Token: 0x0600137B RID: 4987 RVA: 0x0001833A File Offset: 0x0001653A
		// (set) Token: 0x0600137C RID: 4988 RVA: 0x00018342 File Offset: 0x00016542
		[DataMember(Name = "workerReady", IsRequired = true)]
		public double WorkerReady { get; set; }

		// Token: 0x170006AB RID: 1707
		// (get) Token: 0x0600137D RID: 4989 RVA: 0x0001834B File Offset: 0x0001654B
		// (set) Token: 0x0600137E RID: 4990 RVA: 0x00018353 File Offset: 0x00016553
		[DataMember(Name = "workerFetchStart", IsRequired = true)]
		public double WorkerFetchStart { get; set; }

		// Token: 0x170006AC RID: 1708
		// (get) Token: 0x0600137F RID: 4991 RVA: 0x0001835C File Offset: 0x0001655C
		// (set) Token: 0x06001380 RID: 4992 RVA: 0x00018364 File Offset: 0x00016564
		[DataMember(Name = "workerRespondWithSettled", IsRequired = true)]
		public double WorkerRespondWithSettled { get; set; }

		// Token: 0x170006AD RID: 1709
		// (get) Token: 0x06001381 RID: 4993 RVA: 0x0001836D File Offset: 0x0001656D
		// (set) Token: 0x06001382 RID: 4994 RVA: 0x00018375 File Offset: 0x00016575
		[DataMember(Name = "sendStart", IsRequired = true)]
		public double SendStart { get; set; }

		// Token: 0x170006AE RID: 1710
		// (get) Token: 0x06001383 RID: 4995 RVA: 0x0001837E File Offset: 0x0001657E
		// (set) Token: 0x06001384 RID: 4996 RVA: 0x00018386 File Offset: 0x00016586
		[DataMember(Name = "sendEnd", IsRequired = true)]
		public double SendEnd { get; set; }

		// Token: 0x170006AF RID: 1711
		// (get) Token: 0x06001385 RID: 4997 RVA: 0x0001838F File Offset: 0x0001658F
		// (set) Token: 0x06001386 RID: 4998 RVA: 0x00018397 File Offset: 0x00016597
		[DataMember(Name = "pushStart", IsRequired = true)]
		public double PushStart { get; set; }

		// Token: 0x170006B0 RID: 1712
		// (get) Token: 0x06001387 RID: 4999 RVA: 0x000183A0 File Offset: 0x000165A0
		// (set) Token: 0x06001388 RID: 5000 RVA: 0x000183A8 File Offset: 0x000165A8
		[DataMember(Name = "pushEnd", IsRequired = true)]
		public double PushEnd { get; set; }

		// Token: 0x170006B1 RID: 1713
		// (get) Token: 0x06001389 RID: 5001 RVA: 0x000183B1 File Offset: 0x000165B1
		// (set) Token: 0x0600138A RID: 5002 RVA: 0x000183B9 File Offset: 0x000165B9
		[DataMember(Name = "receiveHeadersEnd", IsRequired = true)]
		public double ReceiveHeadersEnd { get; set; }
	}
}
