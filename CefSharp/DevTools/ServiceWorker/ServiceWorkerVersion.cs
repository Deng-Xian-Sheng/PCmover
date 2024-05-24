using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.ServiceWorker
{
	// Token: 0x0200020F RID: 527
	[DataContract]
	public class ServiceWorkerVersion : DevToolsDomainEntityBase
	{
		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06000F12 RID: 3858 RVA: 0x000141B0 File Offset: 0x000123B0
		// (set) Token: 0x06000F13 RID: 3859 RVA: 0x000141B8 File Offset: 0x000123B8
		[DataMember(Name = "versionId", IsRequired = true)]
		public string VersionId { get; set; }

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06000F14 RID: 3860 RVA: 0x000141C1 File Offset: 0x000123C1
		// (set) Token: 0x06000F15 RID: 3861 RVA: 0x000141C9 File Offset: 0x000123C9
		[DataMember(Name = "registrationId", IsRequired = true)]
		public string RegistrationId { get; set; }

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06000F16 RID: 3862 RVA: 0x000141D2 File Offset: 0x000123D2
		// (set) Token: 0x06000F17 RID: 3863 RVA: 0x000141DA File Offset: 0x000123DA
		[DataMember(Name = "scriptURL", IsRequired = true)]
		public string ScriptURL { get; set; }

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06000F18 RID: 3864 RVA: 0x000141E3 File Offset: 0x000123E3
		// (set) Token: 0x06000F19 RID: 3865 RVA: 0x000141FF File Offset: 0x000123FF
		public ServiceWorkerVersionRunningStatus RunningStatus
		{
			get
			{
				return (ServiceWorkerVersionRunningStatus)DevToolsDomainEntityBase.StringToEnum(typeof(ServiceWorkerVersionRunningStatus), this.runningStatus);
			}
			set
			{
				this.runningStatus = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06000F1A RID: 3866 RVA: 0x00014212 File Offset: 0x00012412
		// (set) Token: 0x06000F1B RID: 3867 RVA: 0x0001421A File Offset: 0x0001241A
		[DataMember(Name = "runningStatus", IsRequired = true)]
		internal string runningStatus { get; set; }

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06000F1C RID: 3868 RVA: 0x00014223 File Offset: 0x00012423
		// (set) Token: 0x06000F1D RID: 3869 RVA: 0x0001423F File Offset: 0x0001243F
		public ServiceWorkerVersionStatus Status
		{
			get
			{
				return (ServiceWorkerVersionStatus)DevToolsDomainEntityBase.StringToEnum(typeof(ServiceWorkerVersionStatus), this.status);
			}
			set
			{
				this.status = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06000F1E RID: 3870 RVA: 0x00014252 File Offset: 0x00012452
		// (set) Token: 0x06000F1F RID: 3871 RVA: 0x0001425A File Offset: 0x0001245A
		[DataMember(Name = "status", IsRequired = true)]
		internal string status { get; set; }

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06000F20 RID: 3872 RVA: 0x00014263 File Offset: 0x00012463
		// (set) Token: 0x06000F21 RID: 3873 RVA: 0x0001426B File Offset: 0x0001246B
		[DataMember(Name = "scriptLastModified", IsRequired = false)]
		public double? ScriptLastModified { get; set; }

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06000F22 RID: 3874 RVA: 0x00014274 File Offset: 0x00012474
		// (set) Token: 0x06000F23 RID: 3875 RVA: 0x0001427C File Offset: 0x0001247C
		[DataMember(Name = "scriptResponseTime", IsRequired = false)]
		public double? ScriptResponseTime { get; set; }

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06000F24 RID: 3876 RVA: 0x00014285 File Offset: 0x00012485
		// (set) Token: 0x06000F25 RID: 3877 RVA: 0x0001428D File Offset: 0x0001248D
		[DataMember(Name = "controlledClients", IsRequired = false)]
		public string[] ControlledClients { get; set; }

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06000F26 RID: 3878 RVA: 0x00014296 File Offset: 0x00012496
		// (set) Token: 0x06000F27 RID: 3879 RVA: 0x0001429E File Offset: 0x0001249E
		[DataMember(Name = "targetId", IsRequired = false)]
		public string TargetId { get; set; }
	}
}
