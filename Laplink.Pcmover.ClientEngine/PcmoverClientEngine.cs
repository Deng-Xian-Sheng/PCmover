using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Threading.Tasks;
using Laplink.Download.Contracts;
using Laplink.Pcmover.Contracts;
using Laplink.Service.Contracts;
using Laplink.Tools.Helpers;

namespace Laplink.Pcmover.ClientEngine
{
	// Token: 0x0200000A RID: 10
	public class PcmoverClientEngine<IPcmoverControlProxy> : IPcmoverClientEngine, IPcmoverController where IPcmoverControlProxy : IPcmoverControl
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000056 RID: 86 RVA: 0x000028C6 File Offset: 0x00000AC6
		private ServiceInterfaces<IPcmoverControl, IPcmoverQuery> PcmoverInterfaces { get; } = new ServiceInterfaces<IPcmoverControl, IPcmoverQuery>();

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000057 RID: 87 RVA: 0x000028CE File Offset: 0x00000ACE
		// (set) Token: 0x06000058 RID: 88 RVA: 0x000028DB File Offset: 0x00000ADB
		public virtual IPcmoverControl ControlInterface
		{
			get
			{
				return this.PcmoverInterfaces.ControlInterface;
			}
			protected set
			{
				this.PcmoverInterfaces.ControlInterface = value;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000059 RID: 89 RVA: 0x000028E9 File Offset: 0x00000AE9
		protected virtual bool HasControlInterface
		{
			get
			{
				return this.PcmoverInterfaces.HasControlInterface;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600005A RID: 90 RVA: 0x000028F6 File Offset: 0x00000AF6
		// (set) Token: 0x0600005B RID: 91 RVA: 0x000028FE File Offset: 0x00000AFE
		public virtual IPcmoverControlCallback PcmoverControlCallback { get; protected set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002907 File Offset: 0x00000B07
		// (set) Token: 0x0600005D RID: 93 RVA: 0x0000290F File Offset: 0x00000B0F
		public virtual IPcmoverControlProxy PcmoverControlProxy
		{
			get
			{
				return this._pcmoverControlProxy;
			}
			set
			{
				this._pcmoverControlProxy = value;
				this.ControlInterface = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002924 File Offset: 0x00000B24
		protected ServiceInterfaces<IDownloadControl, IDownloadQuery> DownloadInterfaces { get; } = new ServiceInterfaces<IDownloadControl, IDownloadQuery>();

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600005F RID: 95 RVA: 0x0000292C File Offset: 0x00000B2C
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00002939 File Offset: 0x00000B39
		public IDownloadControl DownloadControlInterface
		{
			get
			{
				return this.DownloadInterfaces.ControlInterface;
			}
			protected set
			{
				this.DownloadInterfaces.ControlInterface = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00002947 File Offset: 0x00000B47
		protected bool HasDownloadControlInterface
		{
			get
			{
				return this.DownloadInterfaces.HasControlInterface;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00002954 File Offset: 0x00000B54
		// (set) Token: 0x06000063 RID: 99 RVA: 0x0000295C File Offset: 0x00000B5C
		public string HostName { get; protected set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00002965 File Offset: 0x00000B65
		public ActivityClients ActivityClients { get; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000065 RID: 101 RVA: 0x0000296D File Offset: 0x00000B6D
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00002975 File Offset: 0x00000B75
		public MachineData ThisMachine { get; protected set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000067 RID: 103 RVA: 0x0000297E File Offset: 0x00000B7E
		public LlTraceSource Ts { get; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00002986 File Offset: 0x00000B86
		// (set) Token: 0x06000069 RID: 105 RVA: 0x0000298E File Offset: 0x00000B8E
		public PcmoverServiceData ServiceData { get; protected set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002997 File Offset: 0x00000B97
		// (set) Token: 0x0600006B RID: 107 RVA: 0x000029A0 File Offset: 0x00000BA0
		public bool IsResuming
		{
			get
			{
				return this._isResuming;
			}
			set
			{
				bool isResuming = this._isResuming;
				this._isResuming = value;
				if (isResuming && !this._isResuming)
				{
					this.Ts.TraceInformation("Turning off IsResuming ");
					if (this.HasControlInterface)
					{
						this.Ts.TraceInformation("Activating callbacks");
						this.ControlInterface.ConfigureMonitorCallbacks(CallbackState.Active);
						this.ControlInterface.ConfigureControlCallbacks(CallbackState.Active);
					}
				}
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002A04 File Offset: 0x00000C04
		public PcmoverClientEngine(LlTraceSource ts)
		{
			this.Ts = ts;
			this.ActivityClients = new ActivityClients(this);
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00002A56 File Offset: 0x00000C56
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00002A5E File Offset: 0x00000C5E
		protected string PcmoverHost32 { get; set; } = "PcmoverHost.exe";

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002A67 File Offset: 0x00000C67
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00002A6F File Offset: 0x00000C6F
		protected string PcmoverHost64 { get; set; } = "PcmoverHost64.exe";

		// Token: 0x06000071 RID: 113 RVA: 0x00002A78 File Offset: 0x00000C78
		protected virtual string GetPcmoverHostPath()
		{
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string result = Path.Combine(baseDirectory, this.PcmoverHost32);
			if (Environment.Is64BitOperatingSystem)
			{
				string text = Path.Combine(baseDirectory, this.PcmoverHost64);
				if (File.Exists(text))
				{
					result = text;
				}
			}
			return result;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002ABC File Offset: 0x00000CBC
		protected List<int> CreateTransferMethods(IEnumerable<TransferMethodType> tms, string networkPassword)
		{
			List<int> list = new List<int>();
			if (tms != null)
			{
				foreach (TransferMethodType transferMethodType in tms)
				{
					int num = 0;
					if (this.IsResuming)
					{
						TransferMethodData transferMethodData = this.ServiceData.GetTransferMethodData(transferMethodType);
						if (transferMethodData != null)
						{
							num = transferMethodData.Handle;
						}
					}
					if (num == 0)
					{
						num = this.ControlInterface.CreateTransferMethod(transferMethodType);
						if (num != 0 && (transferMethodType == TransferMethodType.SSL || transferMethodType == TransferMethodType.Network) && networkPassword != null)
						{
							this.ControlInterface.SetNetworkTransferMethodInfo(num, new NetworkTransferMethodInfo
							{
								Password = networkPassword
							});
						}
					}
					if (num == 0)
					{
						this.Ts.TraceCaller(string.Format("Cannot create {0} transfer method", transferMethodType), "CreateTransferMethods");
					}
					else
					{
						list.Add(num);
					}
				}
			}
			return list;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002B9C File Offset: 0x00000D9C
		public PcmoverServiceData GetPcmoverServiceData()
		{
			PcmoverServiceData psd = null;
			this.CatchCommEx(delegate
			{
				psd = new PcmoverServiceData(this.PcmoverInterfaces.QueryInterface, this.DownloadInterfaces.QueryInterfaceValue, this.HostName, this.Ts);
			}, "GetPcmoverServiceData");
			return psd;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002BDB File Offset: 0x00000DDB
		public virtual void OnCommunicationException(Exception ex)
		{
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002BE0 File Offset: 0x00000DE0
		private string FuncName(Delegate func)
		{
			if (func == null)
			{
				return null;
			}
			MethodInfo method = func.Method;
			Type reflectedType = method.ReflectedType;
			return string.Format("{0}.{1}", reflectedType, method.Name);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002C14 File Offset: 0x00000E14
		public bool CatchCommEx(Action func, [CallerMemberName] string caller = "")
		{
			bool result;
			try
			{
				func();
				result = true;
			}
			catch (Exception ex) when (ex is CommunicationException || ex is TimeoutException)
			{
				this.Ts.TraceException(ex, caller + " CatchCommEx " + this.FuncName(func));
				this.OnCommunicationException(ex);
				result = false;
			}
			catch (ObjectDisposedException ex2)
			{
				this.Ts.TraceException(ex2, caller + " CatchCommEx ObjectDisposed " + this.FuncName(func));
				result = false;
			}
			return result;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002CBC File Offset: 0x00000EBC
		public Task<bool> CatchCommExAsync(Func<Task> func, [CallerMemberName] string caller = "")
		{
			PcmoverClientEngine<IPcmoverControlProxy>.<CatchCommExAsync>d__61 <CatchCommExAsync>d__;
			<CatchCommExAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<CatchCommExAsync>d__.<>4__this = this;
			<CatchCommExAsync>d__.func = func;
			<CatchCommExAsync>d__.caller = caller;
			<CatchCommExAsync>d__.<>1__state = -1;
			<CatchCommExAsync>d__.<>t__builder.Start<PcmoverClientEngine<IPcmoverControlProxy>.<CatchCommExAsync>d__61>(ref <CatchCommExAsync>d__);
			return <CatchCommExAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002D10 File Offset: 0x00000F10
		public bool SetPolicy(string policyString)
		{
			if (!string.IsNullOrWhiteSpace(policyString))
			{
				int length = policyString.Length;
				RequestedPage requestedPage = new RequestedPage(30000);
				bool flag = false;
				while (!flag)
				{
					int num = length - requestedPage.StartIndex;
					if (num <= requestedPage.MaxCount)
					{
						requestedPage.MaxCount = num;
						flag = true;
					}
					if (!this.ControlInterface.SetPolicy(policyString.Substring(requestedPage.StartIndex, requestedPage.MaxCount), length, requestedPage.StartIndex == 0, flag))
					{
						this.Ts.TraceCaller("Unexpected error setting policy", "SetPolicy");
						return false;
					}
					requestedPage.NextPage();
				}
			}
			return true;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002DA1 File Offset: 0x00000FA1
		public string GetDefaultCertificateName()
		{
			return this.ControlInterface.GetDefaultCertificateName();
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002DAE File Offset: 0x00000FAE
		public virtual void FireActivityInfoEvent(ActivityInfo info)
		{
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00002DB0 File Offset: 0x00000FB0
		public void OnActivityChanged(ActivityInfo activityInfo, MonitorChangeType change)
		{
			if (change == MonitorChangeType.Changed)
			{
				this.ActivityClients.OnActivityInfoChanged(activityInfo);
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002DC3 File Offset: 0x00000FC3
		public void Progress(ActivityInfo activityInfo, ProgressInfo progressInfo)
		{
			if (this.ActivityClients.OnProgress(activityInfo, progressInfo))
			{
				return;
			}
			this.Ts.TraceError(string.Format("Unexpected progress {0} for {1}", progressInfo, activityInfo));
		}

		// Token: 0x0400001E RID: 30
		private IPcmoverControlProxy _pcmoverControlProxy;

		// Token: 0x04000025 RID: 37
		private bool _isResuming;
	}
}
