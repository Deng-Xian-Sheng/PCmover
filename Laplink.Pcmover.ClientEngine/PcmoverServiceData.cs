using System;
using System.Collections.Generic;
using System.Linq;
using Laplink.Download.Contracts;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;

namespace Laplink.Pcmover.ClientEngine
{
	// Token: 0x0200000F RID: 15
	public class PcmoverServiceData : PcmoverServiceAnalysis, IPcmoverServiceData
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00003FBA File Offset: 0x000021BA
		public bool IsIdle
		{
			get
			{
				return this.PcmoverInfo.State == PcmoverState.idle;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00003FCA File Offset: 0x000021CA
		// (set) Token: 0x060000BC RID: 188 RVA: 0x00003FD2 File Offset: 0x000021D2
		public Version PcmoverVersion { get; private set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00003FDB File Offset: 0x000021DB
		// (set) Token: 0x060000BE RID: 190 RVA: 0x00003FE3 File Offset: 0x000021E3
		public PcmoverStatusInfo PcmoverInfo { get; private set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00003FEC File Offset: 0x000021EC
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x00003FF4 File Offset: 0x000021F4
		public DownloadStatusInfo DownloadInfo { get; private set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00003FFD File Offset: 0x000021FD
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x00004005 File Offset: 0x00002205
		public IEnumerable<ActivityInfo> Activities { get; private set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x0000400E File Offset: 0x0000220E
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x00004016 File Offset: 0x00002216
		public IEnumerable<MachineData> Machines { get; private set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x0000401F File Offset: 0x0000221F
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00004027 File Offset: 0x00002227
		public IEnumerable<PcmTaskData> Tasks { get; private set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00004030 File Offset: 0x00002230
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00004038 File Offset: 0x00002238
		public IEnumerable<TransferMethodData> TransferMethods { get; private set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00004041 File Offset: 0x00002241
		// (set) Token: 0x060000CA RID: 202 RVA: 0x00004049 File Offset: 0x00002249
		private IPcmoverQuery Query { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00004052 File Offset: 0x00002252
		// (set) Token: 0x060000CC RID: 204 RVA: 0x0000405A File Offset: 0x0000225A
		private IDownloadQuery DownloadQuery { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00004063 File Offset: 0x00002263
		public string HostName { get; }

		// Token: 0x060000CE RID: 206 RVA: 0x0000406B File Offset: 0x0000226B
		public PcmoverServiceData(LlTraceSource ts) : base(ts)
		{
			base.Data = this;
			this.PcmoverInfo = new PcmoverStatusInfo
			{
				State = PcmoverState.idle,
				HasController = false
			};
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00004094 File Offset: 0x00002294
		public PcmoverServiceData(IPcmoverQuery query, IDownloadQuery downloadQuery, string hostName, LlTraceSource ts) : base(ts)
		{
			this.HostName = hostName;
			base.Data = this;
			this.PerformQuery(query, downloadQuery);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000040B4 File Offset: 0x000022B4
		public void PerformQuery(IPcmoverQuery query, IDownloadQuery downloadQuery)
		{
			this.Query = query;
			this.DownloadQuery = downloadQuery;
			this.QueryBasicProperties();
			base.Analyze();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000040D0 File Offset: 0x000022D0
		public void QueryBasicProperties()
		{
			this.PcmoverVersion = this.Query.GetPcmoverVersion();
			this.PcmoverInfo = this.Query.GetPcmoverStatus();
			if (this.DownloadQuery == null)
			{
				this.DownloadInfo = new DownloadStatusInfo
				{
					State = DownloadState.Idle,
					HasController = false
				};
			}
			else
			{
				this.DownloadInfo = this.DownloadQuery.GetDownloadStatus();
			}
			if (this.PcmoverInfo.State.IsActive())
			{
				base.Ts.TraceCaller("Retrieving active state", "QueryBasicProperties");
				base.Ts.TraceInformation(string.Format("State: {0}", this.PcmoverInfo.State));
				this.Activities = this.Query.GetAllActivityInfo();
				if (this.Activities.Any<ActivityInfo>())
				{
					using (IEnumerator<ActivityInfo> enumerator = this.Activities.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ActivityInfo activityInfo = enumerator.Current;
							base.Ts.TraceInformation("Activity: " + activityInfo.ToString());
						}
						goto IL_117;
					}
				}
				base.Ts.TraceInformation("No activities");
				IL_117:
				this.Tasks = this.Query.GetAllTaskData();
				if (this.Tasks.Any<PcmTaskData>())
				{
					using (IEnumerator<PcmTaskData> enumerator2 = this.Tasks.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							PcmTaskData pcmTaskData = enumerator2.Current;
							base.Ts.TraceInformation(string.Format("Task: {0} handle {1}", pcmTaskData.TaskType, pcmTaskData.Handle));
						}
						goto IL_199;
					}
				}
				base.Ts.TraceInformation("No tasks");
				IL_199:
				this.Machines = this.Query.GetAllMachineData();
				if (this.Machines.Any<MachineData>())
				{
					using (IEnumerator<MachineData> enumerator3 = this.Machines.GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							MachineData machineData = enumerator3.Current;
							base.Ts.TraceInformation(string.Format("Machine: {0} handle {1}", machineData.NetName, machineData.Handle));
						}
						goto IL_21E;
					}
				}
				base.Ts.TraceInformation("No machines");
				IL_21E:
				this.TransferMethods = this.Query.GetAllTransferMethodData();
				if (this.TransferMethods.Any<TransferMethodData>())
				{
					using (IEnumerator<TransferMethodData> enumerator4 = this.TransferMethods.GetEnumerator())
					{
						while (enumerator4.MoveNext())
						{
							TransferMethodData transferMethodData = enumerator4.Current;
							base.Ts.TraceInformation(string.Format("TransferMethod: {0} handle {1}", transferMethodData.TransferMethodType, transferMethodData.Handle));
						}
						goto IL_2A8;
					}
				}
				base.Ts.TraceInformation("No transfer methods");
				IL_2A8:
				this._publicProperties = this.Query.GetAllPublicProperties();
				if (this._publicProperties.Any<KeyValuePair<string, string>>())
				{
					using (IEnumerator<KeyValuePair<string, string>> enumerator5 = this._publicProperties.GetEnumerator())
					{
						while (enumerator5.MoveNext())
						{
							KeyValuePair<string, string> keyValuePair = enumerator5.Current;
							base.Ts.TraceInformation("Public property: " + keyValuePair.Key + "=" + keyValuePair.Value);
						}
						return;
					}
				}
				base.Ts.TraceInformation("No public properties");
				return;
			}
			this.Activities = new List<ActivityInfo>();
			this.Machines = new List<MachineData>();
			this.Tasks = new List<PcmTaskData>();
			this.TransferMethods = new List<TransferMethodData>();
			this._publicProperties = new Dictionary<string, string>();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004484 File Offset: 0x00002684
		public string GetPublicProperty(string key)
		{
			string result = null;
			if (key != null)
			{
				IDictionary<string, string> publicProperties = this._publicProperties;
				lock (publicProperties)
				{
					this._publicProperties.TryGetValue(key, out result);
				}
			}
			return result;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000044D4 File Offset: 0x000026D4
		public TransferActivityParameters GetTransferActivityParameters(int transferActivityHandle)
		{
			return this.Query.GetTransferActivityParameters(transferActivityHandle);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000044E2 File Offset: 0x000026E2
		public TaskSummaryData GetTaskSummaryData(int taskHandle, bool regularUsersOnly)
		{
			return this.Query.GetTaskSummaryData(taskHandle, regularUsersOnly);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000044F1 File Offset: 0x000026F1
		public int GetActivityTaskHandle(int taskActivityHandle)
		{
			return this.Query.GetActivityTaskHandle(taskActivityHandle);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x000044FF File Offset: 0x000026FF
		public int GetActivityTransferMethodHandle(int transferMethodActivityHandle)
		{
			return this.Query.GetActivityTransferMethodHandle(transferMethodActivityHandle);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000450D File Offset: 0x0000270D
		public int GetActivityMachineHandle(int machineActivityHandle)
		{
			return this.Query.GetActivityMachineHandle(machineActivityHandle);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000451B File Offset: 0x0000271B
		public NetworkTransferMethodInfo GetNetworkTransferMethodInfo(int networkTransferMethodHandle)
		{
			return this.Query.GetNetworkTransferMethodInfo(networkTransferMethodHandle);
		}

		// Token: 0x04000033 RID: 51
		private IDictionary<string, string> _publicProperties;
	}
}
