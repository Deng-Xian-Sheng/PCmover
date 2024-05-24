using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CertificateServer;
using Laplink.Discovery.Infrastructure;
using Laplink.Download.Contracts;
using Laplink.Pcmover.Contracts;
using Laplink.Service.Contracts;
using Laplink.Service.Infrastructure;
using Laplink.Tools.Helpers;
using Laplink.Tools.Helpers.Wcf;
using Laplink.Tools.NativeMethods;
using Microsoft.Win32;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200001B RID: 27
	[ServiceBehavior(Namespace = "http://laplink.com/services/contracts/v2.0056", InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, IncludeExceptionDetailInFaults = true)]
	public class PcmoverManager : IPcmoverControl, IPcmoverMonitor, IPcmoverQuery, AppCallbacks, IAppCallbacks, IServiceManager, IUiCallbackControl, ILlTraceSource
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600008F RID: 143 RVA: 0x0000446B File Offset: 0x0000266B
		public PcmoverControlCallbackStateData PcmoverCcs { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00004473 File Offset: 0x00002673
		public ControlCallbackManager<IPcmoverControlCallback> PcmoverCcm { get; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000091 RID: 145 RVA: 0x0000447B File Offset: 0x0000267B
		public IPcmoverControlCallback ControlCallback
		{
			get
			{
				return this.PcmoverCcs.ControlCallback;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00004488 File Offset: 0x00002688
		// (set) Token: 0x06000093 RID: 147 RVA: 0x00004490 File Offset: 0x00002690
		public ManualResetEvent ExitEvent { private get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00004499 File Offset: 0x00002699
		private bool TerminateWhenExiting
		{
			get
			{
				return this.ExitEvent != null;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000095 RID: 149 RVA: 0x000044A4 File Offset: 0x000026A4
		// (set) Token: 0x06000096 RID: 150 RVA: 0x000044AC File Offset: 0x000026AC
		public IDictionary InvokerEnvironment { private get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000097 RID: 151 RVA: 0x000044B5 File Offset: 0x000026B5
		public IServiceManager ServiceManager
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000098 RID: 152 RVA: 0x000044B8 File Offset: 0x000026B8
		public PcmoverStatusInfo StatusInfo
		{
			get
			{
				return new PcmoverStatusInfo(this.State, this.PcmoverCcs.HasController, this.CallbackReplies.Count);
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000099 RID: 153 RVA: 0x000044DB File Offset: 0x000026DB
		// (set) Token: 0x0600009A RID: 154 RVA: 0x000044E4 File Offset: 0x000026E4
		public PcmoverState State
		{
			get
			{
				return this._state;
			}
			private set
			{
				if (this._state != value)
				{
					if (this._state == PcmoverState.rebooting)
					{
						this.Ts.TraceWarning(string.Format("Attempting to change state to {0} while state is Rebooting. Ignoring state change.", value));
						return;
					}
					this._state = value;
					this.Ts.TraceInformation(string.Format("PcmoverState: {0}", value));
					this.NotifyStatusInfoChanged();
				}
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00004547 File Offset: 0x00002747
		internal EnginePolicy EnginePolicy
		{
			get
			{
				return this._enginePolicy;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600009C RID: 156 RVA: 0x0000454F File Offset: 0x0000274F
		internal ServiceMachine ThisServiceMachine
		{
			get
			{
				if (this._thisServiceMachine == null && this._app != null)
				{
					this._thisServiceMachine = this.GetServiceMachine(this._app.ThisMachine);
				}
				return this._thisServiceMachine;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600009D RID: 157 RVA: 0x0000457E File Offset: 0x0000277E
		private Dictionary<string, string> ControllerProperties { get; } = new Dictionary<string, string>();

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00004586 File Offset: 0x00002786
		private Dictionary<string, string> PublicProperties { get; } = new Dictionary<string, string>();

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600009F RID: 159 RVA: 0x0000458E File Offset: 0x0000278E
		public bool CanSendUiCallback
		{
			get
			{
				return this.PcmoverCcs.CanSendControlCallback;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x0000459B File Offset: 0x0000279B
		public bool UseDefaultUiResponse
		{
			get
			{
				return this.PcmoverCcs.ControlCallbackState == CallbackState.Inactive || !this.State.IsActive();
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x000045BA File Offset: 0x000027BA
		private MonitorCallbackManager<IPcmoverMonitorCallback> MonitorCallbackManager
		{
			get
			{
				if (this._monitorCallbackManager == null)
				{
					this._monitorCallbackManager = new MonitorCallbackManager<IPcmoverMonitorCallback>(this.Ts);
				}
				return this._monitorCallbackManager;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x000045DB File Offset: 0x000027DB
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x000045E3 File Offset: 0x000027E3
		internal UserData UserData { get; private set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x000045EC File Offset: 0x000027EC
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x000045F4 File Offset: 0x000027F4
		internal AuthorizationRequestData AuthRequest { get; private set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x000045FD File Offset: 0x000027FD
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x00004605 File Offset: 0x00002805
		public string EnabledSettingName { get; set; } = "LoggingEnabled";

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x0000460E File Offset: 0x0000280E
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x00004616 File Offset: 0x00002816
		public string PreviousLogFileSettingName { get; set; } = "PreviousLogFile";

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00004620 File Offset: 0x00002820
		public LlTraceSource Ts
		{
			get
			{
				if (this._ts == null)
				{
					this._ts = new LlTraceSource("PcmoverService")
					{
						EnabledSettingName = this.EnabledSettingName,
						PreviousLogFileSettingName = this.PreviousLogFileSettingName
					};
					this._ts.InitLoggingFromAppData("Laplink\\PCmover\\PcmoverService.log");
				}
				return this._ts;
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00004673 File Offset: 0x00002873
		internal void TraceCallerError(string msg, [CallerMemberName] string caller = "")
		{
			this.Ts.TraceCaller(TraceEventType.Error, msg, caller);
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00004683 File Offset: 0x00002883
		// (set) Token: 0x060000AD RID: 173 RVA: 0x0000468C File Offset: 0x0000288C
		public WindowsIdentity InvokerIdentity
		{
			get
			{
				return this._invokerIdentity;
			}
			set
			{
				this._invokerIdentity = value;
				if (this._invokerIdentity == null)
				{
					this.Ts.TraceInformation("Invoked by a null identity");
					return;
				}
				this.Ts.TraceInformation("Invoked by " + this._invokerIdentity.Name);
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000AE RID: 174 RVA: 0x000046D9 File Offset: 0x000028D9
		// (set) Token: 0x060000AF RID: 175 RVA: 0x000046E1 File Offset: 0x000028E1
		public string InvokerScheme { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x000046EA File Offset: 0x000028EA
		private WindowsIdentity UserIdentity
		{
			get
			{
				return this.InvokerIdentity ?? this.PcmoverCcs.ControllerWindowsIdentity;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x00004701 File Offset: 0x00002901
		public HandleManager<CallbackReply> CallbackReplies { get; } = new HandleManager<CallbackReply>(50001, null);

		// Token: 0x060000B2 RID: 178 RVA: 0x0000470C File Offset: 0x0000290C
		public PcmoverManager()
		{
			this.PcmoverCcs = new PcmoverControlCallbackStateData(this);
			this.PcmoverCcm = new ControlCallbackManager<IPcmoverControlCallback>(this.PcmoverCcs);
			this.ServiceTasks = new ServiceTaskHandleManager(20001, this);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004809 File Offset: 0x00002A09
		public void OnStart()
		{
			this.Ts.TraceInformation("PCmover contracts namespace = http://laplink.com/services/contracts/v2.0056");
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000481B File Offset: 0x00002A1B
		public void OnStop()
		{
			this.Ts.TraceInformation("OnStop");
			this.CleanupPcmoverIfActive(this.TerminateWhenExiting);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004839 File Offset: 0x00002A39
		public ServiceHost CreateServiceHost()
		{
			this.OnStart();
			this._serviceHost = LlServiceHostWithDiscovery.CreateDiscoveryHost<PcmoverServiceHost>(() => new PcmoverServiceHost(this, this.Ts), true);
			return this._serviceHost;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004860 File Offset: 0x00002A60
		public bool BecomeController(CallbackState controlCallbackState)
		{
			ControlCallbackManager<IPcmoverControlCallback> pcmoverCcm = this.PcmoverCcm;
			IPcmoverControlCallback callbackChannel = OperationContext.Current.GetCallbackChannel<IPcmoverControlCallback>();
			ServiceSecurityContext serviceSecurityContext = ServiceSecurityContext.Current;
			IIdentity identity = (serviceSecurityContext != null) ? serviceSecurityContext.PrimaryIdentity : null;
			ServiceSecurityContext serviceSecurityContext2 = ServiceSecurityContext.Current;
			WindowsIdentity windowsIdentity = (serviceSecurityContext2 != null) ? serviceSecurityContext2.WindowsIdentity : null;
			OperationContext operationContext = OperationContext.Current;
			return pcmoverCcm.SetController(callbackChannel, identity, windowsIdentity, (operationContext != null) ? operationContext.Channel.LocalAddress.Uri.Scheme : null, controlCallbackState);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000048C5 File Offset: 0x00002AC5
		public void StopBeingController()
		{
			this.PcmoverCcm.StopBeingController();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000048D2 File Offset: 0x00002AD2
		public void ConfigureControlCallbacks(CallbackState controlCallbackState)
		{
			this.PcmoverCcm.ConfigureControlCallbacks(controlCallbackState);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000048E0 File Offset: 0x00002AE0
		public TestResultData RunTest(TestParameterData p)
		{
			if (p == null)
			{
				return null;
			}
			if (p.S == null)
			{
				return null;
			}
			return new TestResultData
			{
				S = p.S
			};
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00004904 File Offset: 0x00002B04
		private void GetInterestingData()
		{
			WindowsIdentity current = WindowsIdentity.GetCurrent();
			IdentityHelper.ExamineRoles(current);
			IdentityHelper.ExamineClaims(current);
			ServiceSecurityContext serviceSecurityContext = ServiceSecurityContext.Current;
			ServiceSecurityContext serviceSecurityContext2 = ServiceSecurityContext.Current;
			if (serviceSecurityContext2 != null)
			{
				IIdentity primaryIdentity = serviceSecurityContext2.PrimaryIdentity;
			}
			ServiceSecurityContext serviceSecurityContext3 = ServiceSecurityContext.Current;
			WindowsIdentity windowsIdentity = (serviceSecurityContext3 != null) ? serviceSecurityContext3.WindowsIdentity : null;
			IPrincipal currentPrincipal = Thread.CurrentPrincipal;
			IIdentity identity = Thread.CurrentPrincipal.Identity;
			WcfHelper.ExamineOperationContext();
			ServiceSecurityContext serviceSecurityContext4 = ServiceSecurityContext.Current;
			if (serviceSecurityContext4 != null)
			{
				IIdentity primaryIdentity2 = serviceSecurityContext4.PrimaryIdentity;
				if (primaryIdentity2 != null)
				{
					string name = primaryIdentity2.Name;
				}
			}
			if (windowsIdentity != null)
			{
				IdentityHelper.ExamineRoles(windowsIdentity);
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00004985 File Offset: 0x00002B85
		public void VerifyControl([CallerMemberName] string caller = "")
		{
			this.PcmoverCcm.VerifyControl(caller);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00004994 File Offset: 0x00002B94
		public void SendCallbackReply(int replyHandle, int result)
		{
			this.VerifyControl("SendCallbackReply");
			HandleManager<CallbackReply> callbackReplies = this.CallbackReplies;
			lock (callbackReplies)
			{
				CallbackReply callbackReply = this.CallbackReplies.Get(replyHandle);
				if (callbackReply != null)
				{
					callbackReply.SetResult(result);
				}
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000049F0 File Offset: 0x00002BF0
		public bool SetPolicy(string p, int fullSize, bool firstPage, bool lastPage)
		{
			this.VerifyControl("SetPolicy");
			if (firstPage)
			{
				this._policy = p;
			}
			else
			{
				this._policy += p;
			}
			return true;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00004A1C File Offset: 0x00002C1C
		public string GetPolicy(RequestedPage page)
		{
			this.VerifyControl("GetPolicy");
			if (this._policy == null)
			{
				return string.Empty;
			}
			int length = this._policy.Length;
			if (page.StartIndex >= length)
			{
				return string.Empty;
			}
			int length2 = Math.Min(length - page.StartIndex, page.MaxCount);
			return this._policy.Substring(page.StartIndex, length2);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00004A84 File Offset: 0x00002C84
		public PcmoverState InitPcmoverApp(InitPcmoverData data)
		{
			this.VerifyControl("InitPcmoverApp");
			PcmoverState state = this.State;
			if (state.CanInitialize())
			{
				this.State = PcmoverState.initInProgress;
				state = this.State;
				Thread thread = new Thread(delegate()
				{
					this.Init(data);
				});
				thread.SetApartmentState(ApartmentState.MTA);
				thread.Start();
			}
			return state;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004AEC File Offset: 0x00002CEC
		public PcmoverState ShutdownPcmoverApp(bool terminateService)
		{
			this.VerifyControl("ShutdownPcmoverApp");
			this.Ts.TraceCaller("Shutdown requested by client", "ShutdownPcmoverApp");
			if (this.State.CanShutdown())
			{
				this.State = PcmoverState.shutdownInProgress;
				this.CallbackReplies.CallForEach(delegate(CallbackReply reply)
				{
					reply.Refresh();
				});
				Task.Run(delegate()
				{
					try
					{
						this.CleanupPcmover(terminateService && this.TerminateWhenExiting);
					}
					catch (Exception ex)
					{
						this.Ts.TraceException(ex, "ShutdownPcmoverApp");
						this.State = ((this._app == null) ? PcmoverState.idle : PcmoverState.initialized);
					}
				});
			}
			return this.State;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004B84 File Offset: 0x00002D84
		private void GetUserFromWmi(out string sid, out string domain, out string name)
		{
			sid = null;
			domain = null;
			name = null;
			try
			{
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Process where Name = 'explorer.exe'"))
				{
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							ManagementObject managementObject = (ManagementObject)enumerator.Current;
							string[] array = new string[2];
							string methodName = "GetOwner";
							object[] args = array;
							managementObject.InvokeMethod(methodName, args);
							name = array[0];
							if (array.Count<string>() > 1)
							{
								domain = array[1];
							}
							else
							{
								domain = null;
							}
							string[] array2 = new string[1];
							string methodName2 = "GetOwnerSid";
							args = array2;
							managementObject.InvokeMethod(methodName2, args);
							sid = array2[0];
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "GetUserFromWmi");
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004C6C File Offset: 0x00002E6C
		private void Init(InitPcmoverData data)
		{
			if (this.DoInit(data))
			{
				this.State = PcmoverState.initialized;
				return;
			}
			this.State = PcmoverState.initializationFailed;
			this.CleanupPcmover(this.TerminateWhenExiting);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004C94 File Offset: 0x00002E94
		private bool DoInit(InitPcmoverData data)
		{
			if (this._app != null)
			{
				return true;
			}
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			uint num;
			if (this._pcmComContext == null)
			{
				WindowsIdentity userIdentity = this.UserIdentity;
				string text;
				using ((userIdentity != null) ? userIdentity.Impersonate() : null)
				{
					text = (Environment.Is64BitProcess ? "PcmCom64.dll" : "PcmCom.dll");
					this._pcmComContext = new RegFreeCOMObject(text, directoryName, ref num);
				}
				if (num != 0U)
				{
					this._pcmComContext = null;
					string text2 = string.Format("Unable to load {0}, Error={1}", text, num);
					this.Ts.TraceCaller(TraceEventType.Critical, text2, "DoInit");
					this.DisplayUiccMessage1Param(UiCallbackCode.InitError_CannotLoadPcmCom, num.ToString(), text2, 0U, uint.MaxValue, 0);
					return false;
				}
			}
			if (this._certificateContext == null)
			{
				WindowsIdentity userIdentity2 = this.UserIdentity;
				string text;
				using ((userIdentity2 != null) ? userIdentity2.Impersonate() : null)
				{
					text = (Environment.Is64BitProcess ? "LLCertificateServer64.dll" : "LLCertificateServer.dll");
					this._certificateContext = new RegFreeCOMObject(text, directoryName, ref num);
				}
				if (num != 0U)
				{
					this._certificateContext = null;
					string text3 = string.Format("Unable to load {0}, Error={1}", text, num);
					this.Ts.TraceCaller(TraceEventType.Critical, text3, "DoInit");
					this.DisplayUiccMessage1Param(UiCallbackCode.InitError_CannotFindCertificateService, num.ToString(), text3, 0U, uint.MaxValue, 0);
					return false;
				}
			}
			this._initPcmoverData = data;
			bool result;
			try
			{
				WindowsIdentity userIdentity3 = this.UserIdentity;
				using ((userIdentity3 != null) ? userIdentity3.Impersonate() : null)
				{
					this._pcmComContext.CallInContext(delegate
					{
						this._app = (PCmoverApp)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("AF11A366-30CA-40AF-AAC2-90016C92B1DA")));
					});
				}
				this.Ts.TraceInformation("_app is set");
				this._app.SetAppCallbacks(this);
				this._app.PolicyFileBuffer = (string.IsNullOrWhiteSpace(this._policy) ? null : Encoding.UTF8.GetBytes(this._policy));
				string a;
				if (this.InvokerIdentity != null)
				{
					a = this.InvokerScheme;
				}
				else
				{
					a = this.PcmoverCcs.ControllerScheme;
				}
				string value;
				string strCurrentUserDomain;
				string strCurrentUserName;
				if (a == Uri.UriSchemeNetPipe && this.UserIdentity != null)
				{
					value = this.UserIdentity.User.Value;
					this.SplitIdentifyingName(this.UserIdentity.Name, out strCurrentUserDomain, out strCurrentUserName);
				}
				else
				{
					this.GetUserFromWmi(out value, out strCurrentUserDomain, out strCurrentUserName);
				}
				string pEnvironment = null;
				IDictionary dictionary = data.ControllerEnvironment ?? this.InvokerEnvironment;
				if (dictionary != null)
				{
					pEnvironment = new EnvLookup(dictionary).Remove6432Vars().CreateEnvironmentBlock();
					data.ControllerEnvironment = null;
				}
				try
				{
					this._app.Init(pEnvironment, data.PolicyId, data.PolicyFile, data.Deferred, data.CreateRulesOnly, value, strCurrentUserDomain, strCurrentUserName);
				}
				catch (Exception ex)
				{
					this.Ts.TraceException(ex, "AppInit");
					return false;
				}
				this._app.PolicyFileBuffer = null;
				this._enginePolicy = this._app.EnginePolicy;
				if (this._enginePolicy.nEdition != (uint)data.Edition)
				{
					PcmoverEdition nEdition = (PcmoverEdition)this._enginePolicy.nEdition;
					string msg = string.Format("Mismatched edition. Client requested {0}. Engine is {1}.", data.Edition, nEdition);
					this.DisplayUiccMessage1Param(UiCallbackCode.InitError_EngineWrongEditionId, nEdition.ToString(), msg, 0U, uint.MaxValue, 0);
					result = false;
				}
				else
				{
					BrandEnginePolicy brandEnginePolicy = this._enginePolicy.BrandEnginePolicy;
					string b = data.Oem ?? "";
					if (brandEnginePolicy.strOem != b)
					{
						this.DisplayUiccMessage1Param(UiCallbackCode.InitError_EngineWrongOem, brandEnginePolicy.strOem, string.Concat(new string[]
						{
							"Mismatched OEM. Client requested ",
							data.Oem,
							". Engine is ",
							brandEnginePolicy.strOem,
							"."
						}), 0U, uint.MaxValue, 0);
						result = false;
					}
					else
					{
						this._connectionPolicy = this._app.Policy.ConnectionPolicy;
						this._needCertificate = ((this._connectionPolicy.SSLFlags & (SSL_FLAGS)21) == SSL_FLAGS.DefaultSSLFlags);
						ushort num2;
						ushort num3;
						ushort num4;
						ushort num5;
						this._app.GetVersionVariables(out num2, out num3, out num4, out num5);
						this.Ts.TraceInformation("PcmCom Version: {0}.{1}.{2}.{3}", new object[]
						{
							num2,
							num3,
							num4,
							num5
						});
						if (this._suspendSleep == null)
						{
							this._suspendSleep = new SuspendSleep(this.Ts);
						}
						this.InitAuthRequest();
						if (!string.IsNullOrEmpty(data.Language) && !string.IsNullOrEmpty(data.Country))
						{
							this._language = data.Language;
							this._country = data.Country;
							this.GetAppUpdateData();
						}
						result = true;
					}
				}
			}
			catch (Exception ex2)
			{
				this.Ts.TraceException(ex2, "DoInit");
				string text4 = "";
				text4 += string.Format("Exception creating PCmoverApp {0}: {1}", ex2.GetType(), ex2.Message);
				this.DisplayUiccMessage(UiCallbackCode.InitError_UnexpectedException, text4, 0U, uint.MaxValue, 0);
				result = false;
			}
			return result;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000520C File Offset: 0x0000340C
		private AppUpdateData GetAppUpdateData()
		{
			if (this._appUpdateData == null)
			{
				if (this._app.Policy.StartPolicy.bOfferUpdate)
				{
					object registrationLock = this._registrationLock;
					lock (registrationLock)
					{
						this._app.SetProductIdCulture(this._language, this._country);
						this._appUpdateInfo = this._app.RegistrationServer.CheckForUpdate();
						this._appUpdateData = new AppUpdateData
						{
							Checked = this._appUpdateInfo.Checked,
							AppUpdateUrl = this._appUpdateInfo.AppUpdateUrl,
							AppUpdateAvailable = this._appUpdateInfo.AppUpdateAvailable,
							AppUpdateRequired = this._appUpdateInfo.AppUpdateRequired,
							DataUpdateAvailable = this._appUpdateInfo.DataUpdateAvailable,
							DataUpdateRequired = this._appUpdateInfo.DataUpdateRequired
						};
						goto IL_EB;
					}
				}
				this._appUpdateData = new AppUpdateData();
			}
			IL_EB:
			return this._appUpdateData;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000531C File Offset: 0x0000351C
		public InitPcmoverData GetInitPcmoverData()
		{
			if (this._app == null)
			{
				return null;
			}
			return this._initPcmoverData;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00005330 File Offset: 0x00003530
		private void FreePcmoverObjects()
		{
			this.CallbackReplies.CallForEach(delegate(CallbackReply reply)
			{
				reply.Refresh();
			});
			this.Activities.CallForEach(delegate(PcmActivity activity)
			{
				activity.Cancel();
			});
			this.Activities.CallForEach(delegate(PcmActivity activity)
			{
				activity.stop();
			});
			this.Activities.CallForEach(delegate(PcmActivity activity)
			{
				this.NotifyActivityChanged(activity, MonitorChangeType.Deleted);
				activity.Dispose();
			});
			this.Activities.DeleteAll();
			this.CallbackReplies.DeleteAll();
			this.ServiceTasks.CallForEach(delegate(ServiceTask serviceTask)
			{
				this.NotifyTaskChanged(serviceTask, MonitorChangeType.Deleted);
				serviceTask.Dispose();
			});
			this.ServiceTasks.DeleteAll();
			this.ServiceMachines.CallForEach(delegate(ServiceMachine serviceMachine)
			{
				this.NotifyMachineChanged(serviceMachine, MonitorChangeType.Deleted);
				serviceMachine.Dispose();
			});
			this.ServiceMachines.DeleteAll();
			this._thisServiceMachine = null;
			this.TransferMethods.CallForEach(delegate(ServiceTransferMethod stm)
			{
				this.NotifyServiceTransferMethodChanged(stm, MonitorChangeType.Deleted);
				ConnectionMethod connectionMethod = stm.GetConnectionMethod();
				if (connectionMethod != null && connectionMethod.IsOpen())
				{
					connectionMethod.CloseConnection();
				}
			});
			this.TransferMethods.DeleteAll();
			this._appProfileDatabaseRefCnt = 1;
			this.CloseAppProfileDatabase();
			this._appUpdateData = null;
			this._appUpdateInfo = null;
			this._connectionPolicy = null;
			this._enginePolicy = null;
			this.AuthRequest = null;
			this.Ts.TraceInformation("GcExtreme before disposing app, FWIW");
			this.GcExtreme();
			if (this._app != null)
			{
				this._app.dispose();
				this._app = null;
				this.Ts.TraceInformation("_app is cleared in FreeObjects");
			}
			this._pcmComContext = null;
			this._certificateContext = null;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000054D8 File Offset: 0x000036D8
		private void UnloadComLibrary()
		{
			try
			{
				Thread.Sleep(10);
				this.Ts.TraceInformation("UnloadComLibrary GcExtreme");
				this.GcExtreme();
				this.Ts.TraceInformation("UnloadComLibrary Free Libraries");
				Ole32.CoFreeUnusedLibrariesEx(0U, 0U);
				Thread.Sleep(10);
				Ole32.CoFreeUnusedLibrariesEx(0U, 0U);
				this.Ts.TraceInformation("UnloadComLibrary done");
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "UnloadComLibrary");
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00005560 File Offset: 0x00003760
		private void FinalUnloadComLibrary(bool terminate)
		{
			this.Ts.TraceInformation("Try unloading COM library in another thread");
			this.UnloadComLibrary();
			this.Exit(terminate);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000557F File Offset: 0x0000377F
		private void Exit(bool terminate)
		{
			if (!terminate)
			{
				this.State = PcmoverState.idle;
				return;
			}
			this.State = PcmoverState.terminated;
			ManualResetEvent exitEvent = this.ExitEvent;
			if (exitEvent == null)
			{
				return;
			}
			exitEvent.Set();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000055A4 File Offset: 0x000037A4
		private void CleanupPcmoverIfActive(bool terminate)
		{
			if (this.State.IsActive())
			{
				this.CleanupPcmover(terminate);
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000055BC File Offset: 0x000037BC
		private void CleanupPcmover(bool terminate)
		{
			this.State = PcmoverState.shutdownInProgress;
			while (this._waitingForReboot)
			{
				Thread.Sleep(1000);
			}
			try
			{
				this.FreePcmoverObjects();
				this.UnloadComLibrary();
				Task.Factory.StartNew(delegate()
				{
					this.FinalUnloadComLibrary(terminate);
				}, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
				SuspendSleep suspendSleep = this._suspendSleep;
				if (suspendSleep != null)
				{
					suspendSleep.Dispose();
				}
				this._suspendSleep = null;
			}
			catch (Exception ex)
			{
				this.Ts.TraceInformation("Exception during cleanup: " + ex.Message);
				this.State = PcmoverState.initialized;
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00005678 File Offset: 0x00003878
		private void GcExtreme()
		{
			int num = 2;
			while (num-- > 0)
			{
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000569C File Offset: 0x0000389C
		public string GetDownloadManagerEndpointAddress(ServiceType serviceType)
		{
			Uri via = OperationContext.Current.IncomingMessageProperties.Via;
			LlEndpoint llEndpoint = new LlEndpoint(new ServiceBindingFactories_Framework())
			{
				Uri = via
			};
			Type type = null;
			switch (serviceType)
			{
			case ServiceType.Query:
				type = typeof(IDownloadQuery);
				break;
			case ServiceType.Monitor:
				type = typeof(IDownloadMonitor);
				break;
			case ServiceType.Control:
				type = typeof(IDownloadControl);
				break;
			}
			llEndpoint.Contract = new ContractInfo(type, "control", "v2.0056");
			llEndpoint.BaseName = "lldownload";
			llEndpoint.SetPort(Uri.UriSchemeNetTcp, 29723);
			Uri uri = llEndpoint.Uri;
			if (uri == null)
			{
				return null;
			}
			return uri.AbsoluteUri;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00005748 File Offset: 0x00003948
		public IDictionary<string, string> GetAllControllerProperties()
		{
			this.VerifyControl("GetAllControllerProperties");
			Dictionary<string, string> controllerProperties = this.ControllerProperties;
			IDictionary<string, string> result;
			lock (controllerProperties)
			{
				result = new Dictionary<string, string>(this.ControllerProperties);
			}
			return result;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000579C File Offset: 0x0000399C
		public string GetControllerProperty(string key)
		{
			this.VerifyControl("GetControllerProperty");
			string result = null;
			if (key != null)
			{
				Dictionary<string, string> controllerProperties = this.ControllerProperties;
				lock (controllerProperties)
				{
					this.ControllerProperties.TryGetValue(key, out result);
				}
			}
			return result;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000057F8 File Offset: 0x000039F8
		public IDictionary<string, string> GetAllPublicProperties()
		{
			Dictionary<string, string> publicProperties = this.PublicProperties;
			IDictionary<string, string> result;
			lock (publicProperties)
			{
				result = new Dictionary<string, string>(this.PublicProperties);
			}
			return result;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00005840 File Offset: 0x00003A40
		public string GetPublicProperty(string key)
		{
			string result = null;
			if (key != null)
			{
				Dictionary<string, string> publicProperties = this.PublicProperties;
				lock (publicProperties)
				{
					this.PublicProperties.TryGetValue(key, out result);
				}
			}
			return result;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00005890 File Offset: 0x00003A90
		public void SetControllerProperty(string key, string value)
		{
			this.VerifyControl("SetControllerProperty");
			if (key != null)
			{
				Dictionary<string, string> controllerProperties = this.ControllerProperties;
				lock (controllerProperties)
				{
					if (value == null)
					{
						this.ControllerProperties.Remove(key);
					}
					else
					{
						this.ControllerProperties[key] = value;
					}
				}
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000058F8 File Offset: 0x00003AF8
		public void SetPublicProperty(string key, string value)
		{
			this.VerifyControl("SetPublicProperty");
			if (key != null)
			{
				Dictionary<string, string> publicProperties = this.PublicProperties;
				lock (publicProperties)
				{
					if (value == null)
					{
						this.PublicProperties.Remove(key);
					}
					else
					{
						this.PublicProperties[key] = value;
					}
				}
				this.CallMonitorCallbacks(delegate(IPcmoverMonitorCallback cb)
				{
					cb.PublicPropertyChanged(key, value);
				}, false);
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000059A0 File Offset: 0x00003BA0
		public void ClearAllProperties()
		{
			this.VerifyControl("ClearAllProperties");
			Dictionary<string, string> obj = this.ControllerProperties;
			lock (obj)
			{
				this.ControllerProperties.Clear();
			}
			obj = this.PublicProperties;
			Dictionary<string, string> dictionary;
			lock (obj)
			{
				dictionary = new Dictionary<string, string>(this.PublicProperties);
				this.PublicProperties.Clear();
			}
			using (Dictionary<string, string>.Enumerator enumerator = dictionary.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, string> pair = enumerator.Current;
					this.CallMonitorCallbacks(delegate(IPcmoverMonitorCallback cb)
					{
						cb.PublicPropertyChanged(pair.Key, pair.Value);
					}, false);
				}
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00005A88 File Offset: 0x00003C88
		private EnginePolicyData GetEnginePolicyData()
		{
			return new EnginePolicyData
			{
				OemId = this._enginePolicy.nOemId,
				VerifyOemOnNew = this._enginePolicy.bVerifyHardwareOemOnNew,
				VerifyOemOnOld = this._enginePolicy.bVerifyHardwareOemOnOld,
				GetSerialNumberFromServer = this._enginePolicy.bGetSerialNumberFromServer,
				RequireSerialNumber = this._enginePolicy.bRequireSerialNumber,
				ValidateSerialNumber = this._enginePolicy.bValidateSerialNumber
			};
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00005B00 File Offset: 0x00003D00
		private SettingsPolicyData GetSettingsPolicyData()
		{
			return new SettingsPolicyData
			{
				DisplayUi = this._app.Policy.PolicySettings.bDisplayUI
			};
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00005B24 File Offset: 0x00003D24
		private static bool? TriboolToNullableBool(TRIBOOL_VALUE tbv)
		{
			bool? result = null;
			if (tbv != TRIBOOL_VALUE.TBV_FALSE)
			{
				if (tbv == TRIBOOL_VALUE.TBV_TRUE)
				{
					result = new bool?(true);
				}
			}
			else
			{
				result = new bool?(false);
			}
			return result;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00005B58 File Offset: 0x00003D58
		private ConnectionPolicyData GetConnectionPolicyData()
		{
			FileConnectionPolicy fileConnectionPolicy = this._app.Policy.ConnectionPolicy.FileConnectionPolicy;
			PasswordPolicy vanPasswordPolicy = fileConnectionPolicy.VanPasswordPolicy;
			VanPasswordPolicyData vanPassword = new VanPasswordPolicyData
			{
				CanModify = vanPasswordPolicy.bModify,
				IsRequired = vanPasswordPolicy.bRequired,
				HasPassword = !string.IsNullOrEmpty(vanPasswordPolicy.strPw)
			};
			FileConnectionPolicyData file = new FileConnectionPolicyData
			{
				Van = fileConnectionPolicy.VanNamePolicy.strFileName,
				VanPassword = vanPassword,
				IsMachineOld = PcmoverManager.TriboolToNullableBool(fileConnectionPolicy.IsMachineOld)
			};
			NetworkConnectionPolicyData network = new NetworkConnectionPolicyData
			{
				SslFlags = (SSLFlags)this._connectionPolicy.SSLFlags,
				Target = this._connectionPolicy.strNetworkTarget,
				IsMachineOld = PcmoverManager.TriboolToNullableBool(this._connectionPolicy.IsNetworkMachineOld)
			};
			return new ConnectionPolicyData
			{
				EnabledMethods = (ConnectionPolicyMethods)this._connectionPolicy.Methods,
				File = file,
				Network = network
			};
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00005C48 File Offset: 0x00003E48
		private ImageMapData GetMigrationTypeImageData()
		{
			ImagePolicy imagePolicy = this._app.Policy.MigTypeCustomization.ImagePolicy;
			VirtualPhysicalMapping virtualPhysicalMapping = imagePolicy.VirtualPhysicalMapping;
			List<ImageFolderMapping> list = new List<ImageFolderMapping>();
			uint num = 0U;
			for (;;)
			{
				string text;
				string pstr;
				virtualPhysicalMapping.GetPair(num, out text, out pstr);
				if (text == null)
				{
					break;
				}
				list.Add(new ImageFolderMapping
				{
					VStr = text,
					PStr = pstr
				});
				num += 1U;
			}
			return new ImageMapData
			{
				ImageName = imagePolicy.ImageName,
				WinDir = imagePolicy.WindowsDir,
				Folders = list
			};
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00005CCE File Offset: 0x00003ECE
		private MigrationTypePolicyData GetMigrationTypePolicyData()
		{
			return new MigrationTypePolicyData
			{
				Image = this.GetMigrationTypeImageData(),
				DefaultOption = (MigrationTypeOption)this._app.Policy.MigTypeCustomization.DefaultOption
			};
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00005CFC File Offset: 0x00003EFC
		private MigrationItemsPolicyData GetMigrationItemsPolicyData()
		{
			MigItemsCustomization migItemsCustomization = this._app.Policy.MigItemsCustomization;
			MigrationItemsEnabled migrationItemsEnabled = MigrationItemsEnabled.None;
			MIGITEMS_ENABLED enabledItems = migItemsCustomization.EnabledItems;
			if (enabledItems.HasFlag(MIGITEMS_ENABLED.ENABLE_FULL))
			{
				migrationItemsEnabled |= MigrationItemsEnabled.All;
			}
			if (enabledItems.HasFlag(MIGITEMS_ENABLED.ENABLE_FILESANDSETTINGS))
			{
				migrationItemsEnabled |= MigrationItemsEnabled.FilesAndSettings;
			}
			if (enabledItems.HasFlag(MIGITEMS_ENABLED.ENABLE_FILESONLY))
			{
				migrationItemsEnabled |= MigrationItemsEnabled.FilesOnly;
			}
			MigrationItemsOption defaultOption = MigrationItemsOption.All;
			switch (migItemsCustomization.DefaultOption)
			{
			case MIGITEMS_OPTIONS.MIGITEMS_FULL:
				defaultOption = MigrationItemsOption.All;
				break;
			case MIGITEMS_OPTIONS.MIGITEMS_FILESANDSETTINGS:
				defaultOption = MigrationItemsOption.FilesAndSettings;
				break;
			case MIGITEMS_OPTIONS.MIGITEMS_FILESONLY:
				defaultOption = MigrationItemsOption.FilesOnly;
				break;
			}
			return new MigrationItemsPolicyData
			{
				DefaultOption = defaultOption,
				Enabled = migrationItemsEnabled
			};
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00005DA0 File Offset: 0x00003FA0
		private TransferCompletePolicyData GetTransferCompletePolicyData()
		{
			return new TransferCompletePolicyData
			{
				Reboot = this._app.Policy.DonePolicy.bReboot,
				UploadReport = this._app.Policy.DonePolicy.bUploadReport
			};
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00005DE0 File Offset: 0x00003FE0
		private Dictionary<string, string> GetPropertiesPolicyData()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			StringMap propertiesPolicy = this._app.Policy.PropertiesPolicy;
			int count = propertiesPolicy.Count;
			for (int i = 0; i < count; i++)
			{
				string text;
				string value;
				propertiesPolicy.GetByIndex(i, out text, out value);
				if (text != null)
				{
					dictionary[text] = value;
				}
			}
			return dictionary;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00005E34 File Offset: 0x00004034
		private InteractivePolicyData GetInteractivePolicyData()
		{
			Policy policy = this._app.Policy;
			InteractiveCustomizationPolicyData customization = new InteractiveCustomizationPolicyData
			{
				Applications = policy.AppSelCustomization.bInteractive,
				DirFilters = policy.IsDirFiltersInteractive,
				DriveMap = policy.IsDriveMapInteractive,
				FileFilters = policy.IsFileFiltersInteractive,
				MigMod = policy.IsMigModInteractive,
				UserMap = policy.UserMapCustomization.bInteractive
			};
			bool transferFile = true;
			FileNamePolicy vanNamePolicy = policy.ConnectionPolicy.FileConnectionPolicy.VanNamePolicy;
			if (vanNamePolicy != null)
			{
				transferFile = vanNamePolicy.bModify;
			}
			return new InteractivePolicyData
			{
				Customization = customization,
				ImageTransfer = policy.MigTypeCustomization.ImagePolicy.bInteractive,
				MigItems = policy.MigItemsCustomization.bInteractive,
				TransferComplete = policy.DonePolicy.bInteractive,
				TransferFile = transferFile,
				WarningPage = policy.PolicySettings.bDisplayWarningPage
			};
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00005F20 File Offset: 0x00004120
		private ClientReportPolicyData GetClientReportPolicyData()
		{
			ReportsPolicy reportsPolicy = this._app.Policy.ReportsPolicy;
			List<ReportData> list = new List<ReportData>();
			uint num = 0U;
			for (;;)
			{
				ReportPolicy reportPolicy = reportsPolicy.get_ReportPolicies(num++);
				if (reportPolicy == null)
				{
					break;
				}
				if (reportPolicy.Generator == REPORT_GENERATOR.RG_CLIENT)
				{
					ReportData item = new ReportData
					{
						FileName = reportPolicy.strFileName,
						Type = (ReportType)reportPolicy.Type,
						Format = (ReportFormat)reportPolicy.Format,
						Append = reportPolicy.bAppend,
						IncludeExceptionsOnly = reportPolicy.bExceptionsOnly,
						IncludeTimestamp = reportPolicy.bTimeStamp,
						Mask = reportPolicy.Mask,
						Items = (ReportItems)reportPolicy.nItems,
						Migrated = reportPolicy.bMigrated,
						ShowComponents = reportPolicy.bShowComponents,
						Generator = ReportGenerator.Client
					};
					list.Add(item);
				}
			}
			return new ClientReportPolicyData
			{
				BaseDir = reportsPolicy.strBaseDir,
				GenerateDefaultReports = reportsPolicy.bDefaultClientReports,
				Reports = list
			};
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00006018 File Offset: 0x00004218
		public PolicyData GetPolicyData()
		{
			this.VerifyControl("GetPolicyData");
			if (this._app == null)
			{
				this.TraceCallerError("App not initialized", "GetPolicyData");
				return null;
			}
			return new PolicyData
			{
				Engine = this.GetEnginePolicyData(),
				Settings = this.GetSettingsPolicyData(),
				Connection = this.GetConnectionPolicyData(),
				MigrationType = this.GetMigrationTypePolicyData(),
				MigrationItems = this.GetMigrationItemsPolicyData(),
				TransferComplete = this.GetTransferCompletePolicyData(),
				Properties = this.GetPropertiesPolicyData(),
				Interactive = this.GetInteractivePolicyData(),
				ClientReports = this.GetClientReportPolicyData()
			};
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000060BC File Offset: 0x000042BC
		public void SetProductCulture(string language, string country)
		{
			this.VerifyControl("SetProductCulture");
			this._language = language;
			this._country = country;
			if (this._app != null)
			{
				object registrationLock = this._registrationLock;
				lock (registrationLock)
				{
					this._app.SetProductIdCulture(language, country);
				}
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00006124 File Offset: 0x00004324
		public AuthorizationRequestData GetAuthorizationData()
		{
			this.VerifyControl("GetAuthorizationData");
			return this.AuthRequest;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00006137 File Offset: 0x00004337
		private string DefinedString(string first, string second)
		{
			if (!string.IsNullOrWhiteSpace(first))
			{
				return first;
			}
			return second;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00006144 File Offset: 0x00004344
		private void InitAuthRequest()
		{
			PCmoverApp app = this._app;
			RegistrationServer registrationServer = (app != null) ? app.RegistrationServer : null;
			if (registrationServer == null)
			{
				this.TraceCallerError("No RegistrationServer available", "InitAuthRequest");
				return;
			}
			if (this.AuthRequest != null)
			{
				this.TraceCallerError("AuthRequest already initialized, perhaps too early?", "InitAuthRequest");
				return;
			}
			RegistrationPolicy registrationPolicy = this._app.Policy.RegistrationPolicy;
			object registrationLock = this._registrationLock;
			lock (registrationLock)
			{
				string validationCode = registrationServer.ValidationCode;
				bool isSerialNumberFromPolicy = false;
				string text = registrationPolicy.strSerialNumber;
				if (string.IsNullOrWhiteSpace(text))
				{
					text = registrationServer.SerialNumber;
				}
				else
				{
					isSerialNumberFromPolicy = true;
					if (text != registrationServer.SerialNumber)
					{
						validationCode = string.Empty;
					}
				}
				this.AuthRequest = new AuthorizationRequestData
				{
					SerialNumber = text,
					ValidationCode = validationCode,
					User = this.DefinedString(registrationPolicy.strName, registrationServer.UserName),
					Email = this.DefinedString(registrationPolicy.strEmail, registrationServer.UserEmail),
					IsSerialNumberFromPolicy = isSerialNumberFromPolicy,
					PreviousTransferOldMachine = registrationServer.OldMachineName,
					PreviousTransferNewMachine = registrationServer.MachineName
				};
				this.Ts.TraceCaller(this.AuthRequest.ToString(), "InitAuthRequest");
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00006294 File Offset: 0x00004494
		public bool SetAuthorizationData(AuthorizationRequestData authRequest)
		{
			this.VerifyControl("SetAuthorizationData");
			if (authRequest == null)
			{
				this.Ts.TraceError("SetAuthorizationData called with no authRequest");
				return false;
			}
			this.AuthRequest = authRequest;
			return true;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000062C0 File Offset: 0x000044C0
		public SerialNumberInfo GetSerialNumberInfo(string serialNumber)
		{
			this.VerifyControl("GetSerialNumberInfo");
			SerialNumberInfo serialNumberInfo = new SerialNumberInfo
			{
				NormalizedKey = serialNumber
			};
			if (string.IsNullOrWhiteSpace(serialNumber))
			{
				serialNumberInfo.Result = SerialNumberInfoResult.InvalidSerialNumber;
			}
			else
			{
				PCmoverApp app = this._app;
				RegistrationServer registrationServer = (app != null) ? app.RegistrationServer : null;
				if (registrationServer == null)
				{
					serialNumberInfo.Result = SerialNumberInfoResult.NotInitialized;
				}
				else
				{
					object registrationLock = this._registrationLock;
					lock (registrationLock)
					{
						bool flag2;
						string normalizedKey;
						int numLicenses;
						int numUsed;
						int licenseType;
						int matchedType;
						string endDate;
						bool expired;
						if (this.IsTransferValidationCode(serialNumber))
						{
							serialNumberInfo.Result = SerialNumberInfoResult.IsValidationCode;
						}
						else if (registrationServer.GetSerialNumberInfo(serialNumber, out flag2, out normalizedKey, out numLicenses, out numUsed, out licenseType, out matchedType, out endDate, out expired))
						{
							serialNumberInfo.NormalizedKey = normalizedKey;
							if (flag2)
							{
								serialNumberInfo.Result = SerialNumberInfoResult.ValidSerialNumber;
								serialNumberInfo.NumLicenses = numLicenses;
								serialNumberInfo.NumUsed = numUsed;
								serialNumberInfo.LicenseType = licenseType;
								serialNumberInfo.MatchedType = matchedType;
								serialNumberInfo.EndDate = endDate;
								serialNumberInfo.Expired = expired;
								if (serialNumberInfo.IsValid)
								{
									registrationServer.SerialNumber = serialNumber;
								}
							}
							else
							{
								serialNumberInfo.Result = SerialNumberInfoResult.InvalidSerialNumber;
							}
						}
						else if (registrationServer.LastHttpStatus != 407U)
						{
							serialNumberInfo.Result = SerialNumberInfoResult.InternetAccessProblem;
						}
						else
						{
							serialNumberInfo.Result = SerialNumberInfoResult.ProxyAuthRequired;
							serialNumberInfo.ProxyUrl = registrationServer.ProxyUrl;
						}
					}
				}
			}
			this.Ts.TraceCaller(serialNumberInfo.Result.ToString(), "GetSerialNumberInfo");
			return serialNumberInfo;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00006424 File Offset: 0x00004624
		private uint CreateCertificate()
		{
			uint result = 500U;
			if (this._needCertificate)
			{
				string text;
				if (this._enginePolicy.bGetSerialNumberFromServer)
				{
					text = "PMEVAL-D6778K-040";
				}
				else
				{
					text = this.AuthRequest.SerialNumber;
				}
				string email = this.AuthRequest.Email;
				if (text != this._certSn && email != this._certEmail)
				{
					object certLock = this._certLock;
					lock (certLock)
					{
						if (text != this._certSn || email != this._certEmail)
						{
							result = this.CreateCertificate(text, this.AuthRequest.Email, "ca.pcmover.laplink.com");
							this._certSn = text;
							this._certEmail = email;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00006500 File Offset: 0x00004700
		private uint CreateCertificate(string serialNumber, string email, string caServer)
		{
			this.Ts.TraceCaller(TraceEventType.Verbose, "Start", "CreateCertificate");
			uint num = 500U;
			CertificateService service = null;
			try
			{
				WindowsIdentity userIdentity = this.UserIdentity;
				using ((userIdentity != null) ? userIdentity.Impersonate() : null)
				{
					this._certificateContext.CallInContext(delegate
					{
						CertificateService certificateService = (CertificateService)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("A4BD43CF-6776-4FD7-9725-20A41419A519")));
						certificateService.Logging = true;
						service = certificateService;
					});
				}
				service.Application = "PCmover";
				if (caServer != null)
				{
					service.CAServer = caServer;
				}
				this.Ts.TraceCaller(TraceEventType.Verbose, "Service object created", "CreateCertificate");
				bool flag = true;
				byte[] certificate = service.Certificate;
				if (certificate != null)
				{
					try
					{
						X509Certificate2 x509Certificate = new X509Certificate2(certificate);
						string[] array = Regex.Split(x509Certificate.Subject, " \\+ ");
						for (int i = 0; i < array.Length; i++)
						{
							foreach (DistinguishedName.Part part in DistinguishedName.Parse(array[i]))
							{
								if (part.Name == "SERIALNUMBER" && string.Compare(part.Value, serialNumber, StringComparison.OrdinalIgnoreCase) == 0)
								{
									this.Ts.TraceCaller(TraceEventType.Verbose, "Don't request certificate because found serial number", "CreateCertificate");
									flag = false;
									break;
								}
							}
							if (!flag)
							{
								break;
							}
						}
						if (!flag)
						{
							string nameInfo = x509Certificate.GetNameInfo(X509NameType.EmailName, false);
							if (nameInfo == null || string.Compare(nameInfo, email, StringComparison.OrdinalIgnoreCase) != 0)
							{
								this.Ts.TraceCaller(TraceEventType.Verbose, "Do request certificate because bad email", "CreateCertificate");
								flag = true;
							}
						}
						if (!flag)
						{
							DateTime notAfter = x509Certificate.NotAfter;
							if (DateTime.Now > notAfter)
							{
								this.Ts.TraceCaller(TraceEventType.Verbose, "Do request certificate because it's expired", "CreateCertificate");
								flag = true;
							}
						}
						goto IL_204;
					}
					catch (Exception ex)
					{
						this.Ts.TraceCaller(TraceEventType.Verbose, string.Format("Do request certificate because of unexpected exception {0}: {1}", ex.GetType(), ex.Message), "CreateCertificate");
						flag = true;
						goto IL_204;
					}
				}
				this.Ts.TraceCaller(TraceEventType.Verbose, "Certificate is null", "CreateCertificate");
				IL_204:
				if (flag)
				{
					string text = "https://" + service.CAServer;
					text += service.CASignPath;
					string proxyForUrl = this.GetProxyForUrl(text);
					if (!string.IsNullOrWhiteSpace(proxyForUrl))
					{
						this.Ts.TraceCaller("Using proxy: " + proxyForUrl, "CreateCertificate");
					}
					service.ProxyUrl = proxyForUrl;
					int num2 = 0;
					do
					{
						this.Ts.TraceCaller(TraceEventType.Verbose, "Requesting certificate", "CreateCertificate");
						if (!string.IsNullOrWhiteSpace(this.m_proxyUsername))
						{
							service.ProxyUser = this.m_proxyUsername;
						}
						if (!string.IsNullOrWhiteSpace(this.m_proxyPassword))
						{
							service.ProxyPassword = this.m_proxyPassword;
						}
						byte[] array2;
						num = service.RequestCertificate(email, serialNumber, out array2);
					}
					while (num == 407U && this.PromptForProxyAuth(proxyForUrl) && ++num2 < 5);
					this.Ts.TraceCaller(TraceEventType.Verbose, string.Format("Return code: {0}", num), "CreateCertificate");
					if (num == 200U)
					{
						service.DownloadCACertificate();
					}
				}
			}
			catch (Exception ex2)
			{
				num = 500U;
				this.Ts.TraceException(ex2, "CreateCertificate");
			}
			CodeHelper.trycatch(delegate()
			{
				CertificateService service = service;
				if (service == null)
				{
					return;
				}
				service.Dispose();
			});
			return num;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000068CC File Offset: 0x00004ACC
		public string GetDefaultCertificateName()
		{
			this.VerifyControl("GetDefaultCertificateName");
			this.CreateCertificate();
			PCmoverApp app = this._app;
			if (app == null)
			{
				return null;
			}
			return app.CertificateName;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000068F4 File Offset: 0x00004AF4
		public string GetProxyForUrl(string url)
		{
			this.Ts.TraceCaller(this.HideSnInUrl(url), "GetProxyForUrl");
			string text = null;
			Uri uri = new Uri(url);
			bool flag = this.ImpersonateUser();
			try
			{
				IWebProxy systemWebProxy = WebRequest.GetSystemWebProxy();
				if (!systemWebProxy.IsBypassed(uri))
				{
					text = systemWebProxy.GetProxy(uri).AbsoluteUri;
					this.Ts.TraceCaller("New url = " + this.HideSnInUrl(text), "GetProxyForUrl");
				}
				else
				{
					this.Ts.TraceCaller("It is bypassed, and so we don't use the proxy", "GetProxyForUrl");
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "GetProxyForUrl");
				this.Ts.TraceError("Uri: " + this.HideSnInUrl(uri.ToString()));
			}
			if (flag)
			{
				this.StopImpersonating();
			}
			return text;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000069D0 File Offset: 0x00004BD0
		public AppUpdateData CheckForUpdate()
		{
			this.VerifyControl("CheckForUpdate");
			if (this._app == null)
			{
				return null;
			}
			return this.GetAppUpdateData();
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000069F0 File Offset: 0x00004BF0
		public bool ApplyDataUpdate()
		{
			this.VerifyControl("ApplyDataUpdate");
			string text;
			return this._app != null && (!this.GetAppUpdateData().DataUpdateAvailable || this._app.ProcessDataUpdates(this._appUpdateInfo, out text));
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00006A3C File Offset: 0x00004C3C
		public void SetEngineLogData(EngineLogData data)
		{
			this.VerifyControl("SetEngineLogData");
			if (data == null)
			{
				return;
			}
			using (RegistryKey registryKey = this.CreateLogKey())
			{
				if (registryKey != null)
				{
					registryKey.SetValue("LogType", data.Type, RegistryValueKind.DWord);
					registryKey.SetValue("LogMethod", data.Method, RegistryValueKind.DWord);
					registryKey.SetValue("LogFile", data.FileName, RegistryValueKind.String);
				}
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00006AC0 File Offset: 0x00004CC0
		private uint GetRegUint(RegistryKey key, string valueName, uint defaultValue)
		{
			if (key == null)
			{
				return defaultValue;
			}
			object value = key.GetValue(valueName);
			if (value == null)
			{
				return defaultValue;
			}
			if (key.GetValueKind(valueName) != RegistryValueKind.DWord)
			{
				return defaultValue;
			}
			return Convert.ToUInt32(value);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00006AF4 File Offset: 0x00004CF4
		private string GetRegString(RegistryKey key, string valueName, string defaultValue)
		{
			if (key == null)
			{
				return defaultValue;
			}
			object value = key.GetValue(valueName);
			if (value == null)
			{
				return defaultValue;
			}
			return value.ToString();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00006B1C File Offset: 0x00004D1C
		private RegistryKey OpenLogKey()
		{
			RegistryKey result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
			{
				if (registryKey == null)
				{
					result = null;
				}
				else
				{
					result = registryKey.OpenSubKey("Software\\Laplink\\PCmover\\Settings");
				}
			}
			return result;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00006B6C File Offset: 0x00004D6C
		private RegistryKey CreateLogKey()
		{
			RegistryKey result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
			{
				if (registryKey == null)
				{
					result = null;
				}
				else
				{
					result = registryKey.CreateSubKey("Software\\Laplink\\PCmover\\Settings");
				}
			}
			return result;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00006BBC File Offset: 0x00004DBC
		public EngineLogData GetEngineLogData()
		{
			this.VerifyControl("GetEngineLogData");
			EngineLogData engineLogData = new EngineLogData();
			using (RegistryKey registryKey = this.OpenLogKey())
			{
				if (registryKey != null)
				{
					uint regUint = this.GetRegUint(registryKey, "LogType", 0U);
					uint regUint2 = this.GetRegUint(registryKey, "LogMethod", 0U);
					string regString = this.GetRegString(registryKey, "LogFile", "");
					engineLogData.Type = (SpInfoBox_Type)regUint;
					engineLogData.Method = (SpInfoBox_Method)regUint2;
					engineLogData.FileName = regString;
				}
			}
			return engineLogData;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00006C48 File Offset: 0x00004E48
		public DateTime GetUndoTime()
		{
			this.VerifyControl("GetUndoTime");
			if (this._app == null)
			{
				return default(DateTime);
			}
			double undoOADate = this._app.UndoOADate;
			if (undoOADate == 0.0)
			{
				return default(DateTime);
			}
			return DateTime.FromOADate(undoOADate);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00006C9A File Offset: 0x00004E9A
		public string GetWindowsOld()
		{
			this.VerifyControl("GetWindowsOld");
			if (this._app == null)
			{
				return null;
			}
			return this._app.strWindowsOldDir;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00006CBC File Offset: 0x00004EBC
		public SecurityProductsData GetSecurityProducts()
		{
			this.VerifyControl("GetSecurityProducts");
			if (this._app == null)
			{
				return null;
			}
			return new SecurityProductsData
			{
				AntivirusProduct = this._app.AntivirusProduct,
				FirewallProduct = this._app.FirewallProduct
			};
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00006CFA File Offset: 0x00004EFA
		public bool SuspendSleep(bool suspend)
		{
			this.VerifyControl("SuspendSleep");
			if (this._suspendSleep == null)
			{
				return false;
			}
			this._suspendSleep.Suspend(suspend);
			return true;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00006D20 File Offset: 0x00004F20
		private ResXResourceSet GetMigModResourceSet(CultureInfo culture)
		{
			if (File.Exists(string.Concat(new string[]
			{
				AppDomain.CurrentDomain.BaseDirectory,
				"\\",
				culture.Name,
				"\\MigMod.",
				culture.Name,
				".resx"
			})))
			{
				return new ResXResourceSet(string.Concat(new string[]
				{
					AppDomain.CurrentDomain.BaseDirectory,
					"\\",
					culture.Name,
					"\\MigMod.",
					culture.Name,
					".resx"
				}));
			}
			string[] array = new string[6];
			array[0] = AppDomain.CurrentDomain.BaseDirectory;
			array[1] = "\\";
			int num = 2;
			CultureInfo parent = culture.Parent;
			array[num] = ((parent != null) ? parent.ToString() : null);
			array[3] = "\\MigMod.";
			int num2 = 4;
			CultureInfo parent2 = culture.Parent;
			array[num2] = ((parent2 != null) ? parent2.ToString() : null);
			array[5] = ".resx";
			if (File.Exists(string.Concat(array)))
			{
				string[] array2 = new string[6];
				array2[0] = AppDomain.CurrentDomain.BaseDirectory;
				array2[1] = "\\";
				int num3 = 2;
				CultureInfo parent3 = culture.Parent;
				array2[num3] = ((parent3 != null) ? parent3.ToString() : null);
				array2[3] = "\\MigMod.";
				int num4 = 4;
				CultureInfo parent4 = culture.Parent;
				array2[num4] = ((parent4 != null) ? parent4.ToString() : null);
				array2[5] = ".resx";
				return new ResXResourceSet(string.Concat(array2));
			}
			if (this._country.ToUpper() == "CS" && File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\zh-Hans\\MigMod.zh-Hans.resx"))
			{
				return new ResXResourceSet(AppDomain.CurrentDomain.BaseDirectory + "\\zh-Hans\\MigMod.zh-Hans.resx");
			}
			if (this._country.ToUpper() == "CT" && File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\zh-Hant\\MigMod.zh-Hant.resx"))
			{
				return new ResXResourceSet(AppDomain.CurrentDomain.BaseDirectory + "\\zh-Hant\\MigMod.zh-Hant.resx");
			}
			return null;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00006F18 File Offset: 0x00005118
		private string HideSnInUrl(string url)
		{
			string result = url;
			try
			{
				if (url.Contains("key="))
				{
					int num = url.IndexOf("key=") + 4;
					int num2 = url.IndexOf("&", num);
					if (num2 > num)
					{
						result = url.Substring(0, num) + "*******-******-****" + url.Substring(num2);
					}
					else
					{
						result = url.Substring(0, num) + "*******-******-****";
					}
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "HideSnInUrl");
			}
			return result;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00006FAC File Offset: 0x000051AC
		internal ServiceMachine GetServiceMachine(Machine machine)
		{
			if (machine == null)
			{
				return null;
			}
			bool flag;
			ServiceMachine serviceMachine = this.ServiceMachines.AddMachine(machine, out flag);
			if (flag)
			{
				this.NotifyMachineChanged(serviceMachine, MonitorChangeType.Added);
			}
			return serviceMachine;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00006FD9 File Offset: 0x000051D9
		internal bool RemoveServiceMachine(ServiceMachine serviceMachine)
		{
			if (serviceMachine == null)
			{
				return false;
			}
			if (!this.ServiceMachines.Delete(serviceMachine.Handle))
			{
				return false;
			}
			this.NotifyMachineChanged(serviceMachine, MonitorChangeType.Deleted);
			return true;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00006FFE File Offset: 0x000051FE
		internal ServiceMachine GetServiceMachine(int machineHandle)
		{
			return this.ServiceMachines.Get(machineHandle);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000700C File Offset: 0x0000520C
		public MachineData GetThisMachine()
		{
			MachineData result;
			try
			{
				this.Ts.TraceInformation("GetThisMachine");
				ServiceMachine thisServiceMachine = this.ThisServiceMachine;
				MachineData machineData = (thisServiceMachine != null) ? thisServiceMachine.Data : null;
				if (machineData == null)
				{
					this.Ts.TraceInformation("No machine");
				}
				else
				{
					this.Ts.TraceInformation(machineData.ToString());
				}
				result = machineData;
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, LlTraceSource.ExceptionDetails.All, "GetThisMachine");
				result = null;
			}
			return result;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00007090 File Offset: 0x00005290
		public bool DeleteMachine(int machineHandle)
		{
			this.VerifyControl("DeleteMachine");
			if (this.ThisServiceMachine != null && machineHandle == this.ThisServiceMachine.Handle)
			{
				this.TraceCallerError("Cannot delete this machine", "DeleteMachine");
				return false;
			}
			ServiceMachine serviceMachine = this.GetServiceMachine(machineHandle);
			if (serviceMachine == null)
			{
				this.TraceCallerError(string.Format("Invalid machine {0}", machineHandle), "DeleteMachine");
				return false;
			}
			if (this.ServiceTasks.FindTask(serviceMachine.PcmMachine) != null)
			{
				this.TraceCallerError("Cannot delete machine " + serviceMachine.Data.NetName + ". It is being used by a task.", "DeleteMachine");
				return false;
			}
			serviceMachine.Dispose();
			return this.RemoveServiceMachine(serviceMachine);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000713F File Offset: 0x0000533F
		private ENUM_TTID ItemTypeToTreeType(ItemType type)
		{
			if (type != ItemType.Disk)
			{
				return ENUM_TTID.REG_TTID;
			}
			return ENUM_TTID.DISK_TTID;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000714C File Offset: 0x0000534C
		internal PcmoverObjectWrapper<TreeRoot> GetTreeRootWrapper(Machine machine, ItemType type)
		{
			if (machine == null)
			{
				return null;
			}
			PcmoverObjectWrapper<TreeRoot> result;
			using (PcmoverObjectWrapper<TreeRoots> pcmoverObjectWrapper = new PcmoverObjectWrapper<TreeRoots>(machine.TreeRoots))
			{
				result = new PcmoverObjectWrapper<TreeRoot>(pcmoverObjectWrapper.Value.GetTreeRoot(this.ItemTypeToTreeType(type)));
			}
			return result;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000071A0 File Offset: 0x000053A0
		internal PcmoverObjectWrapper<TreeRoot> GetTreeRootWrapper(ServiceMachine serviceMachine, ItemType type)
		{
			return this.GetTreeRootWrapper((serviceMachine != null) ? serviceMachine.PcmMachine : null, type);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000071B5 File Offset: 0x000053B5
		private PcmoverObjectWrapper<TreeRoot> GetTreeRootWrapper(int machineHandle, ItemType type)
		{
			return this.GetTreeRootWrapper(this.GetServiceMachine(machineHandle), type);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000071C8 File Offset: 0x000053C8
		private TreeBranches GetBranches(int machineHandle, ItemType type)
		{
			TreeBranches result;
			using (PcmoverObjectWrapper<TreeRoot> treeRootWrapper = this.GetTreeRootWrapper(machineHandle, type))
			{
				if (((treeRootWrapper != null) ? treeRootWrapper.Value : null) == null)
				{
					result = null;
				}
				else
				{
					result = treeRootWrapper.Value.Branches;
				}
			}
			return result;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000721C File Offset: 0x0000541C
		private void InitializeCategoryDefinition(CategoryDefinition cat, TreeBranch branch, NetUser user)
		{
			cat.Name = branch.strId;
			cat.Group = branch.GroupId;
			cat.FullPath = branch.strRootPath;
			cat.UserAccountName = this.GetUserAccountName(user);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00007250 File Offset: 0x00005450
		public IEnumerable<CategoryDefinition> MachineGetCategories(int machineHandle, CategoryParameters categoryParameters, RequestedPage page)
		{
			this.VerifyControl("MachineGetCategories");
			if (categoryParameters == null || page == null)
			{
				this.TraceCallerError("Invalid parameters", "MachineGetCategories");
				return null;
			}
			TreeBranches branches = this.GetBranches(machineHandle, categoryParameters.Type);
			if (branches == null)
			{
				this.TraceCallerError("Branches not found", "MachineGetCategories");
				return null;
			}
			List<CategoryDefinition> list = new List<CategoryDefinition>();
			if (page.MaxCount == 0)
			{
				return list;
			}
			try
			{
				int count = branches.Count;
				int num = 0;
				for (int i = 1; i <= count; i++)
				{
					TreeBranch treeBranch = branches[i];
					NetUser user = treeBranch.User;
					if ((!categoryParameters.RegularUsersOnly || user == null || user.IsRegularUser) && num++ >= page.StartIndex)
					{
						CategoryDefinition categoryDefinition = new CategoryDefinition();
						this.InitializeCategoryDefinition(categoryDefinition, treeBranch, user);
						if (categoryParameters.IncludeCounts)
						{
							TreeImpl tree = treeBranch.Tree;
							if (tree != null)
							{
								this.SetStats(categoryDefinition, tree.GetStats(true, categoryParameters.AllAppsOnly));
							}
						}
						list.Add(categoryDefinition);
						if (list.Count >= page.MaxCount)
						{
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "MachineGetCategories");
				list = null;
			}
			return list;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00007388 File Offset: 0x00005588
		public IEnumerable<DriveSpaceData> MachineGetDriveSpace(int machineHandle)
		{
			this.VerifyControl("MachineGetDriveSpace");
			ServiceMachine serviceMachine = this.GetServiceMachine(machineHandle);
			if (serviceMachine == null)
			{
				this.TraceCallerError(string.Format("Invalid machine handle: {0}", machineHandle), "MachineGetDriveSpace");
				return null;
			}
			List<DriveSpaceData> list = new List<DriveSpaceData>();
			DriveSizeMap driveSizeMap = serviceMachine.PcmMachine.DriveSizeMap;
			if (driveSizeMap != null)
			{
				int firstDrive = driveSizeMap.FirstDrive;
				if (firstDrive != -1)
				{
					int lastDrive = driveSizeMap.LastDrive;
					for (int i = firstDrive; i <= lastDrive; i++)
					{
						ulong num;
						ulong freeBytes;
						driveSizeMap.GetSize(i, out num, out freeBytes);
						if (num != 0UL)
						{
							list.Add(new DriveSpaceData
							{
								Drive = string.Format("{0}:\\", (char)(65 + i)),
								TotalBytes = num,
								FreeBytes = freeBytes
							});
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00007448 File Offset: 0x00005648
		public MachineDriveInfo MachineGetDriveInfo(int machineHandle)
		{
			this.VerifyControl("MachineGetDriveInfo");
			ServiceMachine serviceMachine = this.GetServiceMachine(machineHandle);
			if (serviceMachine == null)
			{
				this.TraceCallerError(string.Format("Invalid machine: {0}", machineHandle), "MachineGetDriveInfo");
				return null;
			}
			Machine pcmMachine = serviceMachine.PcmMachine;
			return new MachineDriveInfo
			{
				HardDrives = pcmMachine.HardDrives,
				UsbDrives = pcmMachine.UsbDrives,
				VirtualDrives = pcmMachine.VirtualDrives
			};
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000074B8 File Offset: 0x000056B8
		private void SetStats(ContainerStats stats, TreeStats psmStats)
		{
			stats.NumContainers = psmStats.nTrees;
			stats.NumItems = psmStats.nLeaves;
			stats.TotalSize = psmStats.nBytes;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000074E0 File Offset: 0x000056E0
		public IEnumerable<ApplicationData> MachineGetApplications(int machineHandle, GetApplicationsParameters p, RequestedPage page)
		{
			this.VerifyControl("MachineGetApplications");
			ServiceMachine serviceMachine = this.GetServiceMachine(machineHandle);
			if (serviceMachine == null)
			{
				this.TraceCallerError(string.Format("Invalid machine: {0}", machineHandle), "MachineGetApplications");
				return null;
			}
			return this.GetApplications(serviceMachine.PcmMachine, null, p, page);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00007530 File Offset: 0x00005730
		public IEnumerable<ApplicationData> MachineGetMicrosoftOfficeTrialApps(int machineHandle, GetApplicationsParameters p)
		{
			this.VerifyControl("MachineGetMicrosoftOfficeTrialApps");
			ServiceMachine serviceMachine = this.GetServiceMachine(machineHandle);
			Machine machine = (serviceMachine != null) ? serviceMachine.PcmMachine : null;
			if (machine == null)
			{
				this.TraceCallerError(string.Format("Invalid machine: {0}", machineHandle), "MachineGetMicrosoftOfficeTrialApps");
				return null;
			}
			List<ApplicationData> list = new List<ApplicationData>();
			try
			{
				using (PcmoverObjectWrapper<AppInventory> pcmoverObjectWrapper = new PcmoverObjectWrapper<AppInventory>(machine.AppInventory))
				{
					int num = (pcmoverObjectWrapper.Value != null) ? pcmoverObjectWrapper.Value.Count : 0;
					for (int i = 1; i <= num; i++)
					{
						using (PcmoverObjectWrapper<AppProfile> pcmoverObjectWrapper2 = new PcmoverObjectWrapper<AppProfile>(pcmoverObjectWrapper.Value[i]))
						{
							AppProfile value = pcmoverObjectWrapper2.Value;
							if (this.UseThisApp(value, null, p) && value.IsMicrosoftOffice && value.IsTrialVersion)
							{
								list.Add(this.CreateApplicationData(null, value, p.IncludeBitmap));
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "MachineGetMicrosoftOfficeTrialApps");
				list = null;
			}
			return list;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00007664 File Offset: 0x00005864
		internal int AddServiceTransferMethod(ServiceTransferMethod stm)
		{
			if (stm == null)
			{
				return 0;
			}
			stm.Handle = this.TransferMethods.Add(stm);
			this.NotifyServiceTransferMethodChanged(stm, MonitorChangeType.Added);
			return stm.Handle;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000768B File Offset: 0x0000588B
		internal ServiceTransferMethod GetServiceTransferMethod(int transferMethodHandle)
		{
			return this.TransferMethods.Get(transferMethodHandle);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000769C File Offset: 0x0000589C
		internal bool RemoveServiceTransferMethod(int transferMethodHandle)
		{
			ServiceTransferMethod serviceTransferMethod = this.GetServiceTransferMethod(transferMethodHandle);
			if (serviceTransferMethod == null)
			{
				return false;
			}
			if (!this.TransferMethods.Delete(serviceTransferMethod.Handle))
			{
				return false;
			}
			this.NotifyServiceTransferMethodChanged(serviceTransferMethod, MonitorChangeType.Deleted);
			return true;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000076D4 File Offset: 0x000058D4
		public int CreateTransferMethod(TransferMethodType tm)
		{
			this.VerifyControl("CreateTransferMethod");
			return this.CreateTransferMethodInternal(tm);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000076E8 File Offset: 0x000058E8
		internal int CreateTransferMethodInternal(TransferMethodType tm)
		{
			if (this._app == null)
			{
				return 0;
			}
			ServiceTransferMethod serviceTransferMethod = null;
			if (tm <= TransferMethodType.Image)
			{
				if (tm != TransferMethodType.File)
				{
					if (tm == TransferMethodType.Image)
					{
						if (this._connectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_IMAGE) || this._connectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_SELF))
						{
							serviceTransferMethod = new ServiceImageTransferMethod
							{
								ImageMap = this.GetMigrationTypeImageData()
							};
						}
					}
				}
				else if (this._connectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_FILE))
				{
					serviceTransferMethod = new ServiceFileTransferMethod
					{
						FileTransferMethod = (FileTransferMethod)this._app.CreateTransferMethod(ENUM_TRANSFERMETHOD.TM_FILE)
					};
				}
			}
			else if (tm != TransferMethodType.Network)
			{
				switch (tm)
				{
				case TransferMethodType.SSL:
					if (!this._connectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_TCP_OR_UDP))
					{
						goto IL_1E3;
					}
					try
					{
						this.CreateCertificate();
						serviceTransferMethod = new ServiceNetworkTransferMethod
						{
							NetworkTransferMethod = (NetworkTransferMethod)this._app.CreateTransferMethod(ENUM_TRANSFERMETHOD.TM_NETWORK),
							NetworkTransferMethod = 
							{
								bSecure = true
							}
						};
						goto IL_1E3;
					}
					catch (Exception ex)
					{
						this.TraceCallerError("Exception enabling SSL " + ex.Message, "CreateTransferMethodInternal");
						goto IL_1E3;
					}
					break;
				case (TransferMethodType)84:
				case (TransferMethodType)86:
					goto IL_1E3;
				case TransferMethodType.Usb:
					break;
				case TransferMethodType.WinUpgrade:
					if (this._connectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_IMAGE))
					{
						serviceTransferMethod = new ServiceWinUpgradeTransferMethod
						{
							WindowsOld = this._app.strWindowsOldDir,
							ImageMap = new ImageMapData
							{
								Folders = new List<ImageFolderMapping>(),
								WinDir = "C:\\Windows",
								ImageName = "Prev"
							}
						};
						goto IL_1E3;
					}
					goto IL_1E3;
				default:
					goto IL_1E3;
				}
				if (this._connectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_USB))
				{
					this.CreateCertificate();
					serviceTransferMethod = new ServiceUsbTransferMethod
					{
						UsbTransferMethod = (USBTransferMethod)this._app.CreateTransferMethod(ENUM_TRANSFERMETHOD.TM_USB)
					};
				}
			}
			else if (this._connectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_TCP_OR_UDP))
			{
				this.CreateCertificate();
				serviceTransferMethod = new ServiceNetworkTransferMethod
				{
					NetworkTransferMethod = (NetworkTransferMethod)this._app.CreateTransferMethod(ENUM_TRANSFERMETHOD.TM_NETWORK)
				};
			}
			IL_1E3:
			if (serviceTransferMethod == null)
			{
				this.TraceCallerError(string.Format("Unable to create {0}", tm), "CreateTransferMethodInternal");
				return 0;
			}
			serviceTransferMethod.TransferMethodType = tm;
			this.AddServiceTransferMethod(serviceTransferMethod);
			return serviceTransferMethod.Handle;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00007920 File Offset: 0x00005B20
		public IEnumerable<TransferMethodType> GetDiscoveryTransferMethods()
		{
			this.VerifyControl("GetDiscoveryTransferMethods");
			if (this._app == null)
			{
				return null;
			}
			List<TransferMethodType> list = new List<TransferMethodType>();
			if (this._connectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_TCP_OR_UDP))
			{
				list.Add(TransferMethodType.Network);
			}
			if (this._connectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_USB))
			{
				list.Add(TransferMethodType.Usb);
			}
			return list;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00007975 File Offset: 0x00005B75
		public bool DeleteTransferMethod(int transferMethodHandle)
		{
			this.VerifyControl("DeleteTransferMethod");
			return this.RemoveServiceTransferMethod(transferMethodHandle);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000798C File Offset: 0x00005B8C
		public bool SetNetworkTransferMethodInfo(int networkTransferMethodHandle, NetworkTransferMethodInfo info)
		{
			this.VerifyControl("SetNetworkTransferMethodInfo");
			ServiceNetworkTransferMethod serviceNetworkTransferMethod = this.GetServiceTransferMethod(networkTransferMethodHandle) as ServiceNetworkTransferMethod;
			if (serviceNetworkTransferMethod == null)
			{
				this.TraceCallerError(string.Format("Invalid network transfer method handle {0}", networkTransferMethodHandle), "SetNetworkTransferMethodInfo");
				return false;
			}
			try
			{
				if (info.Target != null)
				{
					serviceNetworkTransferMethod.NetworkTransferMethod.RemoteMachine = info.Target;
					if (info.bSecure)
					{
						try
						{
							serviceNetworkTransferMethod.NetworkTransferMethod.RemoteCertificateName = info.CertificateName;
							serviceNetworkTransferMethod.NetworkTransferMethod.bSecure = true;
						}
						catch (Exception ex)
						{
							this.TraceCallerError("Exception enabling SSL: " + ex.Message, "SetNetworkTransferMethodInfo");
							return false;
						}
					}
				}
				if (info.Password != null)
				{
					serviceNetworkTransferMethod.Password = info.Password;
				}
			}
			catch (Exception ex2)
			{
				this.TraceCallerError("Exception setting RemoteMachine: " + ex2.Message, "SetNetworkTransferMethodInfo");
				return false;
			}
			return true;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00007A88 File Offset: 0x00005C88
		public SslInfo GetSslInfo(int transferMethodHandle)
		{
			this.VerifyControl("GetSslInfo");
			ServiceNetworkTransferMethod serviceNetworkTransferMethod = this.GetServiceTransferMethod(transferMethodHandle) as ServiceNetworkTransferMethod;
			if (serviceNetworkTransferMethod != null)
			{
				NetworkTransferMethod networkTransferMethod = serviceNetworkTransferMethod.NetworkTransferMethod;
				SslInfo sslInfo = new SslInfo
				{
					IsSecure = networkTransferMethod.bSecure,
					State = SSLState.SSLInvalid
				};
				if (sslInfo.IsSecure)
				{
					sslInfo.State = (SSLState)networkTransferMethod.SSLState;
					sslInfo.IsSSLClient = networkTransferMethod.bSSLClient;
					sslInfo.IsCertificateValid = networkTransferMethod.bValidCertificate;
					sslInfo.LocalCertificate = networkTransferMethod.LocalCertificate;
					sslInfo.PeerCertificate = networkTransferMethod.PeerCertificate;
				}
				return sslInfo;
			}
			ServiceUsbTransferMethod serviceUsbTransferMethod = this.GetServiceTransferMethod(transferMethodHandle) as ServiceUsbTransferMethod;
			if (serviceUsbTransferMethod != null)
			{
				USBTransferMethod usbTransferMethod = serviceUsbTransferMethod.UsbTransferMethod;
				SslInfo sslInfo2 = new SslInfo
				{
					IsSecure = false,
					State = (SSLState)usbTransferMethod.SSLState
				};
				if (sslInfo2.State == SSLState.ConnectedUntrusted || sslInfo2.State == SSLState.ConnectedTrusted)
				{
					sslInfo2.IsSecure = true;
					sslInfo2.IsSSLClient = usbTransferMethod.bSSLClient;
					sslInfo2.IsCertificateValid = usbTransferMethod.bValidCertificate;
					sslInfo2.LocalCertificate = usbTransferMethod.LocalCertificate;
					sslInfo2.PeerCertificate = usbTransferMethod.PeerCertificate;
				}
				return sslInfo2;
			}
			this.Ts.TraceCaller(string.Format("Invalid network transfer method handle {0}", transferMethodHandle), "GetSslInfo");
			return null;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00007BC4 File Offset: 0x00005DC4
		public SslInfo GetLocalSslInfo()
		{
			this.VerifyControl("GetLocalSslInfo");
			SslInfo sslInfo = new SslInfo
			{
				IsSecure = false,
				State = SSLState.SSLInvalid
			};
			ListenActivity listenActivity = this.FindActivity(ActivityType.Listen) as ListenActivity;
			if (listenActivity != null)
			{
				listenActivity.GetLocalSslInfo(sslInfo);
			}
			return sslInfo;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00007C08 File Offset: 0x00005E08
		public bool SetFileTransferMethodInfo(int fileTransferMethodHandle, FileTransferMethodInfo info)
		{
			this.VerifyControl("SetFileTransferMethodInfo");
			ServiceFileTransferMethod serviceFileTransferMethod = this.GetServiceTransferMethod(fileTransferMethodHandle) as ServiceFileTransferMethod;
			if (serviceFileTransferMethod == null)
			{
				this.TraceCallerError(string.Format("Invalid file transfer method handle: {0}", fileTransferMethodHandle), "SetFileTransferMethodInfo");
				return false;
			}
			FileTransferMethod fileTransferMethod = serviceFileTransferMethod.FileTransferMethod;
			if (!string.IsNullOrWhiteSpace(info.FileName))
			{
				this.Ts.TraceCaller(string.Format("Setting filename for transfer method {0} to {1}", fileTransferMethodHandle, info.FileName), "SetFileTransferMethodInfo");
				fileTransferMethod.FileName = info.FileName;
			}
			if (info.AnyMachineName != null)
			{
				this.Ts.TraceCaller(string.Format("Setting AnyMachineName for transfer method {0} to {1}", fileTransferMethodHandle, info.AnyMachineName), "SetFileTransferMethodInfo");
				serviceFileTransferMethod.AnyMachineName = info.AnyMachineName;
			}
			fileTransferMethod.Span = info.CanSpan;
			fileTransferMethod.SpanSize = info.SpanSize;
			fileTransferMethod.SpanNotify = info.NotifySpan;
			if (info.CloudToken != null)
			{
				this.Ts.TraceCaller(string.Format("Setting CloudToken for transfer method {0}", fileTransferMethodHandle), "SetFileTransferMethodInfo");
				fileTransferMethod.CloudToken = info.CloudToken;
			}
			return true;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00007D28 File Offset: 0x00005F28
		public bool SetImageTransferMethodInfo(int imageTransferMethodHandle, ImageMapData imageMapData)
		{
			this.VerifyControl("SetImageTransferMethodInfo");
			ServiceImageTransferMethod serviceImageTransferMethod = this.GetServiceTransferMethod(imageTransferMethodHandle) as ServiceImageTransferMethod;
			if (serviceImageTransferMethod == null)
			{
				this.TraceCallerError(string.Format("Invalid image transfer method handle {0}", imageTransferMethodHandle), "SetImageTransferMethodInfo");
				return false;
			}
			if (!this._connectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_IMAGE))
			{
				this.TraceCallerError("Image transfers not enabled", "SetImageTransferMethodInfo");
				return false;
			}
			if (imageMapData == null)
			{
				this.TraceCallerError("no imageMapData specified", "SetImageTransferMethodInfo");
				return false;
			}
			if (string.IsNullOrWhiteSpace(imageMapData.WinDir))
			{
				imageMapData.WinDir = this._app.Policy.MigTypeCustomization.ImagePolicy.WindowsDir;
			}
			if (string.IsNullOrWhiteSpace(imageMapData.ImageName))
			{
				imageMapData.ImageName = this._app.Policy.MigTypeCustomization.ImagePolicy.ImageName;
			}
			serviceImageTransferMethod.ImageMap = imageMapData;
			this.Ts.TraceInformation(string.Format("Setting image data for handle {0}", imageTransferMethodHandle));
			if (imageMapData.Folders == null)
			{
				this.Ts.TraceInformation("No mapping defined");
			}
			else
			{
				foreach (ImageFolderMapping imageFolderMapping in imageMapData.Folders)
				{
					this.Ts.TraceInformation(imageFolderMapping.VStr + " -> " + imageFolderMapping.PStr);
				}
			}
			return true;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00007E94 File Offset: 0x00006094
		public bool SetWinUpgradeTransferMethodInfo(int winUpgradeTransferMethodHandle, WinUpgradeTransferMethodInfo info)
		{
			this.VerifyControl("SetWinUpgradeTransferMethodInfo");
			ServiceWinUpgradeTransferMethod serviceWinUpgradeTransferMethod = this.GetServiceTransferMethod(winUpgradeTransferMethodHandle) as ServiceWinUpgradeTransferMethod;
			if (serviceWinUpgradeTransferMethod == null)
			{
				this.TraceCallerError(string.Format("Invalid WinUpgrade transfer method handle {0}", winUpgradeTransferMethodHandle), "SetWinUpgradeTransferMethodInfo");
				return false;
			}
			serviceWinUpgradeTransferMethod.WindowsOld = info.WindowsOld;
			return true;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00007EE6 File Offset: 0x000060E6
		public bool RefreshNetworkAdapters()
		{
			this.VerifyControl("RefreshNetworkAdapters");
			if (this._app == null)
			{
				return false;
			}
			this._app.RefreshNetworkAdapters();
			return true;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00007F09 File Offset: 0x00006109
		public uint GetValidNetworkAdapterCount()
		{
			this.VerifyControl("GetValidNetworkAdapterCount");
			if (this._app == null)
			{
				return 0U;
			}
			return this._app.ValidNetworkAdapterCount;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00007F2C File Offset: 0x0000612C
		public ActivityInfo StartActivity(int activityHandle)
		{
			this.VerifyControl("StartActivity");
			PcmActivity pcmActivity = this.Activities.Get(activityHandle);
			if (pcmActivity == null)
			{
				this.TraceCallerError(string.Format("Invalid activity handle {0}", activityHandle), "StartActivity");
				return null;
			}
			if (pcmActivity.Info.State == ActivityState.Idle)
			{
				pcmActivity.Start();
			}
			return pcmActivity.Info;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00007F8C File Offset: 0x0000618C
		public ActivityInfo StopActivity(int activityHandle)
		{
			this.VerifyControl("StopActivity");
			PcmActivity pcmActivity = this.Activities.Get(activityHandle);
			if (pcmActivity == null)
			{
				this.TraceCallerError(string.Format("Invalid activity handle: {0}", activityHandle), "StopActivity");
				return null;
			}
			this.Ts.TraceInformation(string.Format("Stopping {0}", pcmActivity.Info.Type));
			pcmActivity.Cancel();
			return pcmActivity.Info;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00008004 File Offset: 0x00006204
		public bool DeleteActivity(int activityHandle)
		{
			this.VerifyControl("DeleteActivity");
			PcmActivity pcmActivity = this.Activities.Get(activityHandle);
			if (pcmActivity == null)
			{
				return false;
			}
			pcmActivity.stop();
			if (!this.Activities.Delete(activityHandle))
			{
				return false;
			}
			this.NotifyActivityChanged(pcmActivity, MonitorChangeType.Deleted);
			pcmActivity.Dispose();
			return true;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00008054 File Offset: 0x00006254
		private void AddActivity(PcmActivity activity)
		{
			activity.Info.Handle = this.Activities.Add(activity);
			this.NotifyActivityChanged(activity, MonitorChangeType.Added);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00008078 File Offset: 0x00006278
		private PcmActivity FindActivity(ActivityType type)
		{
			return this.Activities.Find((PcmActivity activity) => activity.Info.Type == type);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000080AC File Offset: 0x000062AC
		private PcmActivity FindTransferActivity(ulong taskId)
		{
			return this.Activities.Find(delegate(PcmActivity activity)
			{
				ITaskActivity taskActivity = activity as ITaskActivity;
				if (taskActivity != null)
				{
					ServiceTask activityServiceTask = taskActivity.ActivityServiceTask;
					if (activityServiceTask != null && activityServiceTask.Task.Id == taskId)
					{
						return true;
					}
				}
				return false;
			});
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000080E0 File Offset: 0x000062E0
		private ActivityInfo NewCreationFailedActivityInfo(ActivityType type, CreationFailedReason reason, string message = null)
		{
			this.Ts.TraceInformation(string.Format("CreateActivity failure for activity {0}: {1}, {2}", type, reason, message ?? ""));
			return new ActivityInfo
			{
				Handle = 0,
				Type = type,
				State = ActivityState.CreationFailed,
				FailureReason = (int)reason,
				Message = message
			};
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00008140 File Offset: 0x00006340
		private ActivityInfo NewCreationExceptionActivityInfo(ActivityType type, Exception ex)
		{
			return this.NewCreationFailedActivityInfo(type, CreationFailedReason.Exception, ex.Message);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00008150 File Offset: 0x00006350
		public ActivityInfo CreateAppInventoryActivity(int machineHandle, AppInventoryAmount amount)
		{
			this.VerifyControl("CreateAppInventoryActivity");
			ActivityType type = ActivityType.AppInventory;
			if (this._app == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.EngineNotInitialized, null);
			}
			ServiceMachine serviceMachine = this.GetServiceMachine(machineHandle);
			if (serviceMachine == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, "CreateAppInventoryActivity invalid machine handle");
			}
			ulong machineId = serviceMachine.PcmMachine.Id;
			if (this.Activities.Find(delegate(PcmActivity activity)
			{
				if (activity.Info.Type == ActivityType.AppInventory)
				{
					AppInventoryActivity appInventoryActivity2 = activity as AppInventoryActivity;
					if (appInventoryActivity2 != null && machineId == appInventoryActivity2.ActivityServiceMachine.PcmMachine.Id)
					{
						return true;
					}
				}
				return false;
			}) != null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.SingletonActivityActive, null);
			}
			ActivityInfo result;
			try
			{
				AppInventoryActivity appInventoryActivity = new AppInventoryActivity(this, serviceMachine, amount);
				this.AddActivity(appInventoryActivity);
				result = appInventoryActivity.Info;
			}
			catch (Exception ex)
			{
				result = this.NewCreationExceptionActivityInfo(type, ex);
			}
			return result;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000820C File Offset: 0x0000640C
		public bool ConfigureAppInventoryActivity(int appInventoryActivityHandle, AppInventoryAmount amount)
		{
			this.VerifyControl("ConfigureAppInventoryActivity");
			AppInventoryActivity appInventoryActivity = this.Activities.Get(appInventoryActivityHandle) as AppInventoryActivity;
			if (appInventoryActivity == null)
			{
				return false;
			}
			appInventoryActivity.AmountToDo = amount;
			return true;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00008244 File Offset: 0x00006444
		public ActivityInfo CreateDiscoveryActivity(IEnumerable<int> transferMethodHandles, int timeout, string discoveryId)
		{
			this.VerifyControl("CreateDiscoveryActivity");
			ActivityType type = ActivityType.Discovery;
			if (this._app == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.EngineNotInitialized, null);
			}
			if (this.FindActivity(ActivityType.Discovery) != null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.SingletonActivityActive, null);
			}
			if (transferMethodHandles == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, "Invalid transfer method handle list for CreateDiscoveryActivity");
			}
			this.UserData = new UserData(this._app, discoveryId)
			{
				IncludeNetName = true
			};
			List<ServiceTransferMethod> list = new List<ServiceTransferMethod>();
			foreach (int num in transferMethodHandles)
			{
				ServiceTransferMethod serviceTransferMethod = this.GetServiceTransferMethod(num);
				if (serviceTransferMethod == null)
				{
					return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, string.Format("Invalid transfer method handle {0} passed into CreateDiscoveryActivity", num));
				}
				if (serviceTransferMethod is ServiceNetworkTransferMethod)
				{
					if (!this._app.Policy.ConnectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_TCP_OR_UDP))
					{
						continue;
					}
				}
				else
				{
					if (!(serviceTransferMethod is ServiceUsbTransferMethod))
					{
						return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, "CreateDiscoveryActivity can only accept Network or USB transfer method handles");
					}
					if (!this._app.Policy.ConnectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_USB))
					{
						continue;
					}
				}
				list.Add(serviceTransferMethod);
			}
			ActivityInfo result;
			try
			{
				PcmActivity pcmActivity = new DiscoveryActivity(this, list, timeout, discoveryId);
				this.AddActivity(pcmActivity);
				result = pcmActivity.Info;
			}
			catch (Exception ex)
			{
				result = this.NewCreationExceptionActivityInfo(type, ex);
			}
			return result;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000083B4 File Offset: 0x000065B4
		public IEnumerable<ConnectableMachine> GetConnectableMachines(int discoveryActivityHandle)
		{
			this.VerifyControl("GetConnectableMachines");
			List<ConnectableMachine> list = null;
			lock (this)
			{
				if (this._manualMachines.Count > 0)
				{
					list = this._manualMachines.GetRange(0, this._manualMachines.Count);
				}
			}
			if (discoveryActivityHandle == 0)
			{
				return list;
			}
			DiscoveryActivity discoveryActivity = this.Activities.Get(discoveryActivityHandle) as DiscoveryActivity;
			if (discoveryActivity == null)
			{
				this.Ts.TraceInformation("Invalid activity handle in GetConnectableMachines");
				return list;
			}
			List<ConnectableMachine> connectableMachines = discoveryActivity.ConnectableMachines;
			if (list != null)
			{
				connectableMachines.AddRange(list);
			}
			return connectableMachines;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000845C File Offset: 0x0000665C
		public bool AddRemoteMachine(ConnectableMachine machine, string discoveryId, bool bSecure)
		{
			this.VerifyControl("AddRemoteMachine");
			if (this.UserData == null)
			{
				this.UserData = new UserData(this._app, discoveryId ?? string.Empty)
				{
					IncludeNetName = true
				};
			}
			return DiscoveryActivity.AddRemoteMachine(this, machine, bSecure);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000849C File Offset: 0x0000669C
		public ActivityInfo CreateListenActivity(IEnumerable<int> transferMethodHandles, string discoveryId)
		{
			this.VerifyControl("CreateListenActivity");
			ActivityType type = ActivityType.Listen;
			if (this._app == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.EngineNotInitialized, null);
			}
			if (this.FindActivity(ActivityType.Listen) != null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.SingletonActivityActive, null);
			}
			if (this.UserData == null)
			{
				this.UserData = new UserData(this._app, discoveryId ?? string.Empty)
				{
					IncludeNetName = true
				};
			}
			List<ServiceTransferMethod> list = null;
			ActivityInfo result;
			try
			{
				list = new List<ServiceTransferMethod>();
				foreach (int num in transferMethodHandles)
				{
					ServiceTransferMethod serviceTransferMethod = this.GetServiceTransferMethod(num);
					if (serviceTransferMethod == null)
					{
						return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, string.Format("Invalid transfer method handle {0} in CreateListenActivity", num));
					}
					if (serviceTransferMethod is ServiceNetworkTransferMethod)
					{
						if (!this._app.Policy.ConnectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_TCP_OR_UDP))
						{
							continue;
						}
					}
					else
					{
						if (!(serviceTransferMethod is ServiceUsbTransferMethod))
						{
							return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, "CreateListenActivity transfer method must be Network, SSL or Usb");
						}
						if (!this._app.Policy.ConnectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_USB))
						{
							continue;
						}
					}
					list.Add(serviceTransferMethod);
				}
				PcmActivity pcmActivity = new ListenActivity(this, list);
				this.AddActivity(pcmActivity);
				result = pcmActivity.Info;
			}
			catch (Exception ex)
			{
				if (list != null)
				{
					list.Clear();
				}
				result = this.NewCreationExceptionActivityInfo(type, ex);
			}
			return result;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00008614 File Offset: 0x00006814
		public bool SetDirection(ConnectableMachine remoteMachine)
		{
			this.VerifyControl("SetDirection");
			ListenActivity listenActivity = this.FindActivity(ActivityType.Listen) as ListenActivity;
			if (listenActivity == null)
			{
				this.Ts.TraceInformation("No Listen Activity found in SetDirection");
				return false;
			}
			try
			{
				ServiceTransferMethod serviceTransferMethod = this.GetServiceTransferMethod(remoteMachine.TransferMethodHandle);
				if (serviceTransferMethod == null)
				{
					this.Ts.TraceInformation("Invalid transfer method handle in SetDirection");
					return false;
				}
				return listenActivity.SetDirection(serviceTransferMethod, remoteMachine);
			}
			catch (Exception ex)
			{
				this.Ts.TraceInformation("Exception in SetDirection: " + ex.Message);
			}
			return false;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000086B0 File Offset: 0x000068B0
		public ActivityInfo CreateSaveSnapshotActivity(int fileTransferMethodHandle, int machineHandle)
		{
			this.VerifyControl("CreateSaveSnapshotActivity");
			ActivityType type = ActivityType.SaveSnapshot;
			if (this._app == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.EngineNotInitialized, null);
			}
			ActivityInfo result;
			try
			{
				ServiceTransferMethod serviceTransferMethod = this.GetServiceTransferMethod(fileTransferMethodHandle);
				if (serviceTransferMethod == null)
				{
					result = this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, string.Format("Invalid transfer method handle {0} in CreateSaveSnapshotActivity", fileTransferMethodHandle));
				}
				else if (serviceTransferMethod.TransferMethodType != TransferMethodType.File)
				{
					result = this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, "Transfer method passed to CreateSaveSnapshotActivity must be type File");
				}
				else
				{
					ServiceFileTransferMethod ftm = serviceTransferMethod as ServiceFileTransferMethod;
					ServiceMachine serviceMachine = this.GetServiceMachine(machineHandle);
					if (serviceMachine == null)
					{
						result = this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, "CreateSaveSnapshotActivity invalid machine handle");
					}
					else
					{
						PcmActivity pcmActivity = new SaveSnapshotActivity(this, ftm, serviceMachine);
						this.AddActivity(pcmActivity);
						result = pcmActivity.Info;
					}
				}
			}
			catch (Exception ex)
			{
				result = this.NewCreationExceptionActivityInfo(type, ex);
			}
			return result;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00008780 File Offset: 0x00006980
		public ActivityInfo CreateGetSnapshotActivity(int transferMethodHandle)
		{
			this.VerifyControl("CreateGetSnapshotActivity");
			ActivityType type = ActivityType.GetSnapshot;
			if (this._app == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.EngineNotInitialized, null);
			}
			ActivityInfo result;
			try
			{
				ServiceTransferMethod serviceTransferMethod = this.GetServiceTransferMethod(transferMethodHandle);
				if (serviceTransferMethod == null)
				{
					result = this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, string.Format("Invalid transfer method handle {0} in CreateGetSnapshotActivity", transferMethodHandle));
				}
				else
				{
					PcmActivity pcmActivity;
					if (serviceTransferMethod.TransferMethodType == TransferMethodType.Image || serviceTransferMethod.TransferMethodType == TransferMethodType.WinUpgrade)
					{
						pcmActivity = new CreateImageMachineActivity(this, serviceTransferMethod as ServiceImageTransferMethod);
					}
					else if (serviceTransferMethod.TransferMethodType == TransferMethodType.File)
					{
						ServiceFileTransferMethod serviceFileTransferMethod = serviceTransferMethod as ServiceFileTransferMethod;
						if (!string.IsNullOrEmpty(serviceFileTransferMethod.FileTransferMethod.FileName))
						{
							return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, "CreateGetSnapshotActivity does not yet support file-based transfers except for the null Any machine");
						}
						pcmActivity = new CreateAnyMachineActivity(this, serviceFileTransferMethod);
					}
					else
					{
						if (serviceTransferMethod.TransferMethodType != TransferMethodType.Network && serviceTransferMethod.TransferMethodType != TransferMethodType.SSL && serviceTransferMethod.TransferMethodType != TransferMethodType.Usb)
						{
							return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, "Invalid transfer method type passed to CreateGetSnapshotActivity");
						}
						pcmActivity = new GetSnapshotActivity(this, serviceTransferMethod);
					}
					this.AddActivity(pcmActivity);
					result = pcmActivity.Info;
				}
			}
			catch (Exception ex)
			{
				result = this.NewCreationExceptionActivityInfo(type, ex);
			}
			return result;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000088A4 File Offset: 0x00006AA4
		public ActivityInfo CreateBuildChangeListsActivity(int fillTaskHandle)
		{
			this.VerifyControl("CreateBuildChangeListsActivity");
			ActivityType type = ActivityType.BuildChangeLists;
			if (this._app == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.EngineNotInitialized, null);
			}
			ServiceTask serviceTask = this.GetServiceTask(fillTaskHandle);
			if (serviceTask == null || serviceTask.Task.taskType != ENUM_TASK_TYPE.CTASK_FILLVAN)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, string.Format("CreateBuildChangeListsActivity invalid fill task handle: {0}", fillTaskHandle));
			}
			ActivityInfo result;
			try
			{
				PcmActivity pcmActivity = new BuildChangeListsActivity(this, serviceTask);
				this.AddActivity(pcmActivity);
				result = pcmActivity.Info;
			}
			catch (Exception ex)
			{
				result = this.NewCreationExceptionActivityInfo(type, ex);
			}
			return result;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000893C File Offset: 0x00006B3C
		public ActivityInfo CreateSaveMovingVanActivity(int fileTransferMethodHandle, int fillTaskHandle)
		{
			this.VerifyControl("CreateSaveMovingVanActivity");
			ActivityType type = ActivityType.SaveMovingVan;
			if (this._app == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.EngineNotInitialized, null);
			}
			ActivityInfo result;
			try
			{
				ServiceTransferMethod serviceTransferMethod = this.GetServiceTransferMethod(fileTransferMethodHandle);
				if (serviceTransferMethod == null)
				{
					result = this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, string.Format("Invalid transfer method handle {0} in CreateSaveMovingVanActivity", fileTransferMethodHandle));
				}
				else if (serviceTransferMethod.TransferMethodType != TransferMethodType.File)
				{
					result = this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, "Transfer method passed to CreateSaveMovingVanActivity must be type File");
				}
				else
				{
					ServiceFileTransferMethod ftm = serviceTransferMethod as ServiceFileTransferMethod;
					ServiceTask serviceTask = this.GetServiceTask(fillTaskHandle);
					if (serviceTask == null || serviceTask.Task.taskType != ENUM_TASK_TYPE.CTASK_FILLVAN)
					{
						result = this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, string.Format("CreateSaveMovingVanActivity invalid fill task handle: {0}", fillTaskHandle));
					}
					else
					{
						PcmActivity pcmActivity = new SaveMovingVanActivity(this, ftm, serviceTask);
						this.AddActivity(pcmActivity);
						result = pcmActivity.Info;
					}
				}
			}
			catch (Exception ex)
			{
				result = this.NewCreationExceptionActivityInfo(type, ex);
			}
			return result;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00008A28 File Offset: 0x00006C28
		public ActivityInfo CreateTransferActivity(TransferActivityParameters transferActivityParameters)
		{
			this.VerifyControl("CreateTransferActivity");
			ActivityType type = ActivityType.Transfer;
			if (this._app == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.EngineNotInitialized, null);
			}
			if (transferActivityParameters == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, "TransferActivityParameters are null");
			}
			ServiceTransferMethod serviceTransferMethod = this.GetServiceTransferMethod(transferActivityParameters.TransferMethodHandle);
			if (serviceTransferMethod == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, string.Format("Invalid transfer method handle {0} in CreateTransferActivity", transferActivityParameters.TransferMethodHandle));
			}
			ServiceTask serviceTask = null;
			if (serviceTransferMethod.TransferMethodType != TransferMethodType.File)
			{
				serviceTask = this.GetServiceTask(transferActivityParameters.FillTaskHandle);
				if (!(((serviceTask != null) ? serviceTask.Task : null) is FillVanTask))
				{
					return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, string.Format("CreateTransferActivity invalid fill task handle: {0}", transferActivityParameters.FillTaskHandle));
				}
			}
			ActivityInfo result;
			try
			{
				PcmActivity pcmActivity;
				if (serviceTransferMethod.TransferMethodType == TransferMethodType.Image)
				{
					pcmActivity = new ImageTransferActivity(this, serviceTask, transferActivityParameters.AllowUndo, serviceTransferMethod);
				}
				else if (serviceTransferMethod.TransferMethodType == TransferMethodType.File)
				{
					ServiceFileTransferMethod ftm = (ServiceFileTransferMethod)serviceTransferMethod;
					pcmActivity = new FileTransferActivity(this, ftm, transferActivityParameters.AllowUndo);
				}
				else
				{
					if (serviceTransferMethod.TransferMethodType != TransferMethodType.Network && serviceTransferMethod.TransferMethodType != TransferMethodType.SSL && serviceTransferMethod.TransferMethodType != TransferMethodType.Usb)
					{
						return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, "Invalid CreateTransferActivity transfer method");
					}
					ServiceNetworkTransferMethod serviceNetworkTransferMethod = serviceTransferMethod as ServiceNetworkTransferMethod;
					if (serviceNetworkTransferMethod != null)
					{
						this.Ts.TraceInformation("Creating transfer activity with a network connection to " + serviceNetworkTransferMethod.NetworkTransferMethod.RemoteMachine);
					}
					pcmActivity = new TransferActivity(this, serviceTransferMethod, serviceTask, transferActivityParameters.AllowUndo);
				}
				this.AddActivity(pcmActivity);
				result = pcmActivity.Info;
			}
			catch (Exception ex)
			{
				result = this.NewCreationExceptionActivityInfo(type, ex);
			}
			return result;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00008BC0 File Offset: 0x00006DC0
		public ActivityInfo CreateUndoActivity()
		{
			this.VerifyControl("CreateUndoActivity");
			ActivityType type = ActivityType.Undo;
			if (this._app == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.EngineNotInitialized, null);
			}
			if (this.FindActivity(ActivityType.Undo) != null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.SingletonActivityActive, null);
			}
			ActivityInfo result;
			try
			{
				PcmActivity pcmActivity = new UndoActivity(this);
				this.AddActivity(pcmActivity);
				result = pcmActivity.Info;
			}
			catch (Exception ex)
			{
				result = this.NewCreationExceptionActivityInfo(type, ex);
			}
			return result;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00008C38 File Offset: 0x00006E38
		public ActivityInfo CreateExpandSnapshotActivity(ExpandSnapshotActivityParameters esaParameters)
		{
			this.VerifyControl("CreateExpandSnapshotActivity");
			ActivityType type = ActivityType.ExpandSnapshot;
			if (this._app == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.EngineNotInitialized, null);
			}
			if (esaParameters == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, "No ExpandSnapshotActivityParameters");
			}
			ServiceMachine serviceMachine = this.GetServiceMachine(esaParameters.MachineHandle);
			if (serviceMachine == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, "CreateExpandSnapshotActivity invalid machine handle");
			}
			ActivityInfo result;
			try
			{
				ExpandSnapshotActivity expandSnapshotActivity = new ExpandSnapshotActivity(this, esaParameters.ItemType, esaParameters.RegularUsersOnly, esaParameters.ExpandGlobalCategories, serviceMachine);
				this.AddActivity(expandSnapshotActivity);
				result = expandSnapshotActivity.Info;
			}
			catch (Exception ex)
			{
				result = this.NewCreationExceptionActivityInfo(type, ex);
			}
			return result;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00008CE0 File Offset: 0x00006EE0
		public ActivityInfo CreateGenerateReportsActivity(int taskHandle, IEnumerable<ReportData> reports)
		{
			this.VerifyControl("CreateGenerateReportsActivity");
			ActivityType type = ActivityType.GenerateReports;
			if (this._app == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.EngineNotInitialized, null);
			}
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, string.Format("CreateGenerateReportsActivity invalid task handle: {0}", taskHandle));
			}
			if (serviceTask.SrcServiceMachine == null || serviceTask.DstServiceMachine == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, string.Format("CreateGenerateReportsActivity task {0} does not have 2 valid machines", taskHandle));
			}
			ActivityInfo result;
			try
			{
				PcmActivity pcmActivity = new GenerateReportsActivity(this, serviceTask, reports);
				this.AddActivity(pcmActivity);
				result = pcmActivity.Info;
			}
			catch (Exception ex)
			{
				result = this.NewCreationExceptionActivityInfo(type, ex);
			}
			return result;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00008D94 File Offset: 0x00006F94
		public ActivityInfo CreateLoadMovingJournalActivity(int transferMethodHandle)
		{
			this.VerifyControl("CreateLoadMovingJournalActivity");
			ActivityType type = ActivityType.LoadMovingJournal;
			if (this._app == null)
			{
				return this.NewCreationFailedActivityInfo(type, CreationFailedReason.EngineNotInitialized, null);
			}
			ActivityInfo result;
			try
			{
				ServiceTransferMethod serviceTransferMethod = this.GetServiceTransferMethod(transferMethodHandle);
				if (serviceTransferMethod == null)
				{
					result = this.NewCreationFailedActivityInfo(type, CreationFailedReason.InvalidParameter, string.Format("Invalid transfer method handle {0} in CreateLoadMovingJournalActivity", transferMethodHandle));
				}
				else
				{
					PcmActivity pcmActivity = new LoadMovingJournalActivity(this, serviceTransferMethod);
					this.AddActivity(pcmActivity);
					result = pcmActivity.Info;
				}
			}
			catch (Exception ex)
			{
				result = this.NewCreationExceptionActivityInfo(type, ex);
			}
			return result;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00008E20 File Offset: 0x00007020
		internal ServiceTask AddServiceTask(IPcmTask task, ServiceMachine srcServiceMachine, ServiceMachine dstServiceMachine)
		{
			if (task == null)
			{
				return null;
			}
			ServiceTask serviceTask = this.ServiceTasks.AddTask(task, srcServiceMachine, dstServiceMachine);
			this.NotifyTaskChanged(serviceTask, MonitorChangeType.Added);
			return serviceTask;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00008E4A File Offset: 0x0000704A
		internal ServiceTask GetServiceTask(int taskHandle)
		{
			return this.ServiceTasks.Get(taskHandle);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00008E58 File Offset: 0x00007058
		internal bool RemoveServiceTask(ServiceTask serviceTask)
		{
			if (serviceTask == null)
			{
				return false;
			}
			if (!this.ServiceTasks.Delete(serviceTask.Handle))
			{
				return false;
			}
			this.NotifyTaskChanged(serviceTask, MonitorChangeType.Deleted);
			return true;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00008E7D File Offset: 0x0000707D
		private FillTaskData FillTaskError(FillTaskResult fillTaskResult, string message, [CallerMemberName] string caller = "")
		{
			this.TraceCallerError(message, caller);
			return new FillTaskData(fillTaskResult, message);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00008E90 File Offset: 0x00007090
		public FillTaskData CreateFillTask(int oldMachineHandle, int newMachineHandle, int transferMethodHandle, string selectionRoots)
		{
			this.VerifyControl("CreateFillTask");
			if (this._app == null)
			{
				return this.FillTaskError(FillTaskResult.NotInitialized, "PCmover not initialized", "CreateFillTask");
			}
			if (oldMachineHandle == newMachineHandle && oldMachineHandle != 0 && !this._connectionPolicy.IsEnabled(CONNECTION_POLICY_METHODS.CPM_SELF))
			{
				return this.FillTaskError(FillTaskResult.SelfTransferDisallowed, "Self transfer not enabled", "CreateFillTask");
			}
			ServiceMachine serviceMachine = this.GetServiceMachine(oldMachineHandle);
			ServiceMachine serviceMachine2 = this.GetServiceMachine(newMachineHandle);
			if (serviceMachine == null || serviceMachine2 == null)
			{
				return this.FillTaskError(FillTaskResult.InvalidMachineHandle, string.Format("Invalid machine handle, {0} or {1}", oldMachineHandle, newMachineHandle), "CreateFillTask");
			}
			if (this._app.Policy.PolicySettings.OnlySameDomain && serviceMachine2.Data.Type != MachineType.Any && serviceMachine.Data.JoinedDomain != serviceMachine2.Data.JoinedDomain)
			{
				return this.FillTaskError(FillTaskResult.DomainsDoNotMatch, string.Concat(new string[]
				{
					"Domains do not match: \"",
					serviceMachine.Data.JoinedDomain,
					"\" and \"",
					serviceMachine2.Data.JoinedDomain,
					"\""
				}), "CreateFillTask");
			}
			if (this._enginePolicy != null)
			{
				uint nOemId = this._enginePolicy.nOemId;
				if (this._enginePolicy.bVerifyHardwareOemOnOld && serviceMachine.Data.OemId != nOemId)
				{
					return this.FillTaskError(FillTaskResult.UnverifiedHardwareOemOnOld, "Old computer hardware OEM not verified", "CreateFillTask");
				}
				if (this._enginePolicy.bVerifyHardwareOemOnNew && serviceMachine2.Data.OemId != nOemId)
				{
					return this.FillTaskError(FillTaskResult.UnverifiedHardwareOemOnNew, "New computer hardware OEM not verified", "CreateFillTask");
				}
			}
			ENUM_TRANSFERMETHOD enum_TRANSFERMETHOD = ENUM_TRANSFERMETHOD.TM_NONE;
			ServiceTransferMethod serviceTransferMethod = this.GetServiceTransferMethod(transferMethodHandle);
			if (serviceTransferMethod != null)
			{
				enum_TRANSFERMETHOD = this.CastToEnumTransferMethod(serviceTransferMethod.TransferMethodType);
			}
			FillVanTask fillVanTask = null;
			FillTaskData result;
			try
			{
				fillVanTask = this._app.CreateClientFillVanTask(serviceMachine.PcmMachine, serviceMachine2.PcmMachine, enum_TRANSFERMETHOD, selectionRoots);
				if (fillVanTask == null)
				{
					result = this.FillTaskError(FillTaskResult.CreateFailed, "Unable to create FillTask for " + serviceMachine.Data.NetName + " and " + serviceMachine2.Data.NetName, "CreateFillTask");
				}
				else if (!fillVanTask.Configure())
				{
					fillVanTask.dispose();
					result = this.FillTaskError(FillTaskResult.ConfigureFailed, "Unable to configure FillTask for " + serviceMachine.Data.NetName + " and " + serviceMachine2.Data.NetName, "CreateFillTask");
				}
				else
				{
					if (enum_TRANSFERMETHOD == ENUM_TRANSFERMETHOD.TM_FILE)
					{
						fillVanTask.VanPassword = this._app.Policy.ConnectionPolicy.FileConnectionPolicy.VanPasswordPolicy.strPw;
					}
					result = new FillTaskData(this.AddServiceTask(fillVanTask, serviceMachine, serviceMachine2).Handle);
				}
			}
			catch (Exception ex)
			{
				if (fillVanTask != null)
				{
					fillVanTask.dispose();
				}
				result = this.FillTaskError(FillTaskResult.UnexpectedException, string.Format("Unexpected {0} creating FillTask with {1} and {2}: {3}", new object[]
				{
					ex.GetType(),
					serviceMachine.Data.NetName,
					serviceMachine2.Data.NetName,
					ex.Message
				}), "CreateFillTask");
			}
			return result;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00009194 File Offset: 0x00007394
		public bool DeleteTask(int taskHandle)
		{
			this.VerifyControl("DeleteTask");
			return this.DoDeleteTask(taskHandle);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000091A8 File Offset: 0x000073A8
		public bool DoDeleteTask(int taskHandle)
		{
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				return false;
			}
			if (!this.RemoveServiceTask(serviceTask))
			{
				return false;
			}
			serviceTask.Dispose();
			return true;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000091D4 File Offset: 0x000073D4
		private CustomizationData CreateInvalidTaskCustomizationData(int taskHandle, [CallerMemberName] string caller = "")
		{
			string text = string.Format("Invalid task: {0}", taskHandle);
			this.TraceCallerError(text, caller);
			return new CustomizationData
			{
				Result = CustomizationResult.InvalidTaskFailure,
				Message = text
			};
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000920D File Offset: 0x0000740D
		private CustomizationData CreateFailureCustomizationData(string message, [CallerMemberName] string caller = "")
		{
			this.TraceCallerError(message, caller);
			return new CustomizationData
			{
				Result = CustomizationResult.OtherFailure,
				Message = message
			};
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000922A File Offset: 0x0000742A
		private CustomizationData CreateExceptionCustomizationData(Exception ex, [CallerMemberName] string caller = "")
		{
			this.Ts.TraceException(ex, caller);
			return new CustomizationData
			{
				Result = CustomizationResult.Exception,
				Message = ex.Message
			};
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00009251 File Offset: 0x00007451
		private CustomizationData CreateSuccessCustomizationData(CustomizationAffects affects)
		{
			return new CustomizationData
			{
				Result = CustomizationResult.Success,
				Affects = affects
			};
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00009268 File Offset: 0x00007468
		public MigrationItemsOption? TaskGetMigrationItems(int fillTaskHandle)
		{
			this.VerifyControl("TaskGetMigrationItems");
			ServiceTask serviceTask = this.GetServiceTask(fillTaskHandle);
			FillVanTask fillVanTask = ((serviceTask != null) ? serviceTask.Task : null) as FillVanTask;
			if (fillVanTask == null)
			{
				this.TraceCallerError(string.Format("Invalid task handle: {0}", fillTaskHandle), "TaskGetMigrationItems");
				return null;
			}
			return new MigrationItemsOption?((MigrationItemsOption)fillVanTask.MigItemsOptions);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000092CC File Offset: 0x000074CC
		public CustomizationData TaskChangeMigrationItems(int fillTaskHandle, MigrationItemsOption items)
		{
			this.VerifyControl("TaskChangeMigrationItems");
			ServiceTask serviceTask = this.GetServiceTask(fillTaskHandle);
			FillVanTask fillVanTask = ((serviceTask != null) ? serviceTask.Task : null) as FillVanTask;
			if (fillVanTask == null)
			{
				return this.CreateInvalidTaskCustomizationData(fillTaskHandle, "TaskChangeMigrationItems");
			}
			CustomizationAffects customizationAffects = CustomizationAffects.None;
			if (fillVanTask.MigItemsOptions != (MIGITEMS_OPTIONS)items)
			{
				customizationAffects |= (CustomizationAffects.Applications | CustomizationAffects.Drives | CustomizationAffects.DiskItems | CustomizationAffects.RegistryItems);
				serviceTask.RebuildRules = true;
				serviceTask.RematchApps = true;
				fillVanTask.MigItemsOptions = (MIGITEMS_OPTIONS)items;
			}
			return this.CreateSuccessCustomizationData(customizationAffects);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000933C File Offset: 0x0000753C
		public MiscSettingsData TaskGetMiscSettings(int fillTaskHandle, string uiCultureName)
		{
			this.VerifyControl("TaskGetMiscSettings");
			ServiceTask serviceTask = this.GetServiceTask(fillTaskHandle);
			FillVanTask fillVanTask = ((serviceTask != null) ? serviceTask.Task : null) as FillVanTask;
			if (fillVanTask == null)
			{
				this.TraceCallerError(string.Format("Invalid task handle: {0}", fillTaskHandle), "TaskGetMiscSettings");
				return null;
			}
			MiscSettingsData result;
			try
			{
				this.Ts.TraceCaller(TraceEventType.Verbose, fillTaskHandle.ToString(), "TaskGetMiscSettings");
				CultureInfo culture = (uiCultureName == null) ? CultureInfo.CurrentUICulture : new CultureInfo(uiCultureName);
				using (ResXResourceSet migModResourceSet = this.GetMigModResourceSet(culture))
				{
					List<MiscSettingsGroupData> list = new List<MiscSettingsGroupData>();
					result = new MiscSettingsData
					{
						Groups = list
					};
					MiscSettingsGroups miscSettings = fillVanTask.MiscSettings;
					foreach (object obj in miscSettings)
					{
						MiscSettingsGroup miscSettingsGroup = (MiscSettingsGroup)obj;
						this.Ts.TraceVerbose(miscSettingsGroup.Name);
						List<MiscSettingData> list2 = new List<MiscSettingData>();
						MiscSettingsGroupData item = new MiscSettingsGroupData
						{
							Name = miscSettingsGroup.Name,
							DisplayName = ((migModResourceSet == null) ? miscSettingsGroup.DisplayName : migModResourceSet.GetString(miscSettingsGroup.Name.Replace(" ", "") + "MenuText")),
							Settings = list2
						};
						foreach (object obj2 in miscSettingsGroup.Settings)
						{
							MiscSetting miscSetting = (MiscSetting)obj2;
							if (miscSetting.Modify)
							{
								MiscSettingData item2 = new MiscSettingData
								{
									Name = miscSetting.Name,
									Text = ((migModResourceSet == null) ? miscSetting.Text : migModResourceSet.GetString(miscSetting.Name.Replace(" ", "") + "Text")),
									Help = ((migModResourceSet == null) ? miscSetting.Help : migModResourceSet.GetString(miscSetting.Name.Replace(" ", "") + "Help")),
									Selected = miscSetting.Selected
								};
								list2.Add(item2);
							}
							miscSetting.dispose();
						}
						list.Add(item);
						miscSettingsGroup.dispose();
					}
					miscSettings.dispose();
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "TaskGetMiscSettings");
				result = null;
			}
			this.Ts.TraceVerbose("Complete");
			return result;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000962C File Offset: 0x0000782C
		public CustomizationData TaskChangeMiscSetting(int fillTaskHandle, MiscSettingData setting)
		{
			this.VerifyControl("TaskChangeMiscSetting");
			ServiceTask serviceTask = this.GetServiceTask(fillTaskHandle);
			FillVanTask fillVanTask = ((serviceTask != null) ? serviceTask.Task : null) as FillVanTask;
			if (fillVanTask == null)
			{
				return this.CreateInvalidTaskCustomizationData(fillTaskHandle, "TaskChangeMiscSetting");
			}
			if (setting == null || setting.Name == null)
			{
				return this.CreateFailureCustomizationData("Invalid MiscSettingData specified", "TaskChangeMiscSetting");
			}
			MiscSettingsGroups miscSettings = fillVanTask.MiscSettings;
			MiscSetting miscSetting = miscSettings.FindMigMod(setting.Name);
			miscSettings.dispose();
			if (miscSetting == null)
			{
				return this.CreateFailureCustomizationData(string.Format("MiscSetting {0} not found", setting.Name), "TaskChangeMiscSetting");
			}
			CustomizationAffects customizationAffects = CustomizationAffects.None;
			if (miscSetting.Selected != setting.Selected)
			{
				customizationAffects |= (CustomizationAffects.Drives | CustomizationAffects.DiskItems | CustomizationAffects.RegistryItems);
				serviceTask.RebuildRules = true;
				miscSetting.Selected = setting.Selected;
			}
			miscSetting.dispose();
			return this.CreateSuccessCustomizationData(customizationAffects);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x000096F8 File Offset: 0x000078F8
		private ApplicationData CreateApplicationData(AppSelMatch match, AppProfile app, bool includeBitmap)
		{
			bool isSelected;
			SELECTED_REASON reason;
			string message;
			bool defaultSelected;
			MIGRATION_SAFETY safety;
			bool isMatching;
			bool isModifiable;
			if (match != null)
			{
				match.GetSelectionInfo(app, out isSelected, out reason, out message, out defaultSelected, out safety);
				isMatching = match.MatchSameVersionAppExists(app);
				isModifiable = match.CanModify(app, true);
			}
			else
			{
				isSelected = app.IsSelected;
				defaultSelected = isSelected;
				reason = SELECTED_REASON.SELREASON_DEFAULT;
				message = null;
				safety = (isSelected ? MIGRATION_SAFETY.SAFETY_HIGH : MIGRATION_SAFETY.SAFETY_LOW);
				isMatching = false;
				isModifiable = !app.IsSelectionLocked;
			}
			ApplicationData applicationData = new ApplicationData
			{
				AppId = app.AppId,
				User = app.UserName,
				Id = app.Id,
				Name = app.DisplayName,
				Publisher = app.Publisher,
				Selected = isSelected,
				Safety = (TransferSafety)safety,
				Message = message,
				Reason = (SelectedReason)reason,
				DefaultSelected = defaultSelected,
				IsDisplayable = app.IsDisplayed,
				IsMatching = isMatching,
				IsComponent = app.IsComponent,
				IsModifiable = isModifiable,
				AppDiskSpace = app.AppDiskSpace
			};
			if (includeBitmap)
			{
				Bitmap bitmap = null;
				IntPtr intPtr = app.LargeIcon;
				if (intPtr == IntPtr.Zero)
				{
					intPtr = app.SmallIcon;
				}
				if (intPtr != IntPtr.Zero)
				{
					try
					{
						bitmap = Icon.FromHandle(intPtr).ToBitmap();
					}
					catch (Exception)
					{
						bitmap = null;
					}
				}
				applicationData.Bitmap = bitmap;
			}
			return applicationData;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00009850 File Offset: 0x00007A50
		public IEnumerable<ApplicationData> TaskGetApplications(int taskHandle, GetApplicationsParameters p, RequestedPage page)
		{
			this.VerifyControl("TaskGetApplications");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				this.TraceCallerError(string.Format("Invalid taskHandle: {0}", taskHandle), "TaskGetApplications");
				return null;
			}
			serviceTask.GetApps();
			ServiceMachine srcServiceMachine = serviceTask.SrcServiceMachine;
			return this.GetApplications((srcServiceMachine != null) ? srcServiceMachine.PcmMachine : null, serviceTask.Task.AppSelMatch, p, page);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000098BC File Offset: 0x00007ABC
		private bool UseThisApp(AppProfile app, AppSelMatch match, GetApplicationsParameters p)
		{
			bool result = true;
			if (p.DisplayableOnly && !app.IsDisplayed)
			{
				result = false;
			}
			else if (!p.ComponentsAlso && app.IsComponent)
			{
				result = false;
			}
			else if (match == null)
			{
				if (p.ModifiableOnly && app.IsSelectionLocked)
				{
					result = false;
				}
			}
			else if (p.NotMatchingOnly && match.MatchSameVersionAppExists(app))
			{
				result = false;
			}
			else if (p.ModifiableOnly && !match.CanModify(app, true))
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00009934 File Offset: 0x00007B34
		private IEnumerable<ApplicationData> GetApplications(Machine machine, AppSelMatch match, GetApplicationsParameters p, RequestedPage page)
		{
			if (p == null || page == null)
			{
				this.TraceCallerError("Invalid parameters", "GetApplications");
				return null;
			}
			if (machine == null)
			{
				this.TraceCallerError("Invalid machine", "GetApplications");
				return null;
			}
			List<ApplicationData> list = new List<ApplicationData>();
			if (page.MaxCount == 0)
			{
				return list;
			}
			try
			{
				using (PcmoverObjectWrapper<AppInventory> pcmoverObjectWrapper = new PcmoverObjectWrapper<AppInventory>(machine.AppInventory))
				{
					int num = (pcmoverObjectWrapper.Value != null) ? pcmoverObjectWrapper.Value.Count : 0;
					int num2 = 0;
					for (int i = 1; i <= num; i++)
					{
						using (PcmoverObjectWrapper<AppProfile> pcmoverObjectWrapper2 = new PcmoverObjectWrapper<AppProfile>(pcmoverObjectWrapper.Value[i]))
						{
							AppProfile value = pcmoverObjectWrapper2.Value;
							if (this.UseThisApp(value, match, p) && num2++ >= page.StartIndex)
							{
								list.Add(this.CreateApplicationData(match, value, p.IncludeBitmap));
								if (list.Count >= page.MaxCount)
								{
									break;
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "GetApplications");
				list = null;
			}
			return list;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00009A70 File Offset: 0x00007C70
		public ApplicationData TaskGetApplicationData(int taskHandle, ulong applicationId)
		{
			this.VerifyControl("TaskGetApplicationData");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				this.TraceCallerError(string.Format("Invalid task handle {0}", taskHandle), "TaskGetApplicationData");
				return null;
			}
			ServiceMachine srcServiceMachine = serviceTask.SrcServiceMachine;
			using (PcmoverObjectWrapper<AppInventory> pcmoverObjectWrapper = new PcmoverObjectWrapper<AppInventory>((srcServiceMachine != null) ? srcServiceMachine.PcmMachine.AppInventory : null))
			{
				if (pcmoverObjectWrapper.Value != null)
				{
					using (PcmoverObjectWrapper<AppProfile> pcmoverObjectWrapper2 = new PcmoverObjectWrapper<AppProfile>(pcmoverObjectWrapper.Value.FindAppById(applicationId)))
					{
						if (pcmoverObjectWrapper2.Value != null)
						{
							return this.CreateApplicationData(serviceTask.Task.AppSelMatch, pcmoverObjectWrapper2.Value, true);
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00009B44 File Offset: 0x00007D44
		public CustomizationData TaskChangeApplicationData(int taskHandle, ApplicationData data)
		{
			this.VerifyControl("TaskChangeApplicationData");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				return this.CreateInvalidTaskCustomizationData(taskHandle, "TaskChangeApplicationData");
			}
			ServiceMachine srcServiceMachine = serviceTask.SrcServiceMachine;
			using (PcmoverObjectWrapper<AppInventory> pcmoverObjectWrapper = new PcmoverObjectWrapper<AppInventory>((srcServiceMachine != null) ? srcServiceMachine.PcmMachine.AppInventory : null))
			{
				AppInventory value = pcmoverObjectWrapper.Value;
				using (PcmoverObjectWrapper<AppProfile> pcmoverObjectWrapper2 = new PcmoverObjectWrapper<AppProfile>((value != null) ? value.FindAppById(data.Id) : null))
				{
					AppProfile value2 = pcmoverObjectWrapper2.Value;
					if (value2 != null)
					{
						CustomizationAffects customizationAffects = CustomizationAffects.None;
						AppSelMatch appSelMatch = serviceTask.Task.AppSelMatch;
						if (appSelMatch.IsSelected(value2) != data.Selected)
						{
							appSelMatch.UserSelect(value2, data.Selected);
							if (appSelMatch.SelectionChangesRuleSets(value2))
							{
								customizationAffects |= (CustomizationAffects.DiskItems | CustomizationAffects.RegistryItems);
								serviceTask.RebuildRules = true;
							}
							serviceTask.RebuildDiskItems = true;
							serviceTask.RebuildRegistryItems = true;
						}
						return this.CreateSuccessCustomizationData(customizationAffects);
					}
				}
			}
			return this.CreateFailureCustomizationData("Invalid application specified", "TaskChangeApplicationData");
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00009C60 File Offset: 0x00007E60
		private string GetUserAccountName(NetUser user)
		{
			if (user == null)
			{
				return null;
			}
			return user.IdentifyingName;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00009C70 File Offset: 0x00007E70
		public UserDetail CreateUserDetail(NetUser user)
		{
			if (user == null)
			{
				return null;
			}
			UserType userType = UserType.None;
			string keyGroups = user.KeyGroups;
			if (keyGroups.Contains("A"))
			{
				userType = UserType.Administrator;
			}
			else if (keyGroups.Contains("U"))
			{
				userType = UserType.Standard;
			}
			else if (keyGroups.Contains("G"))
			{
				userType = UserType.Guest;
			}
			UserDetail userDetail = new UserDetail
			{
				AccountName = user.IdentifyingName,
				FullName = user.FullName,
				FriendlyName = user.DisplayableName,
				UserType = userType,
				IsCurrentUser = user.IsCurrentUser,
				IsAzureAdUser = user.IsAzureAdUser,
				IsRegularUser = user.IsRegularUser
			};
			List<MapiProfile> list = new List<MapiProfile>();
			uint num = 0U;
			for (;;)
			{
				string text;
				string sourceMachineName;
				string sourceUserName;
				string sourceProfileName;
				user.GetMapiProfile(num++, out text, out sourceMachineName, out sourceUserName, out sourceProfileName);
				if (text == null)
				{
					break;
				}
				list.Add(new MapiProfile(text, sourceMachineName, sourceUserName, sourceProfileName));
			}
			userDetail.MapiProfiles = list;
			return userDetail;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00009D50 File Offset: 0x00007F50
		public IEnumerable<UserDetail> GetMachineUsers(int machineHandle)
		{
			ServiceMachine serviceMachine = this.GetServiceMachine(machineHandle);
			if (serviceMachine == null)
			{
				this.TraceCallerError(string.Format("Invalid machine handle: {0}", machineHandle), "GetMachineUsers");
				return null;
			}
			NetUserMgr netUserMgr = serviceMachine.PcmMachine.NetUserMgr;
			if (netUserMgr == null)
			{
				this.TraceCallerError(string.Format("No user manager for {0}", machineHandle), "GetMachineUsers");
				return null;
			}
			List<UserDetail> list = new List<UserDetail>();
			uint num = 0U;
			for (;;)
			{
				NetUser netUser = netUserMgr.get_Accts(num++);
				if (netUser == null)
				{
					break;
				}
				list.Add(this.CreateUserDetail(netUser));
				netUser.dispose();
			}
			return list;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00009DE4 File Offset: 0x00007FE4
		public UserMappings TaskGetUserMappings(int taskHandle, bool regularUsersOnly)
		{
			this.VerifyControl("TaskGetUserMappings");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				this.TraceCallerError(string.Format("Invalid taskHandle: {0}", taskHandle), "TaskGetUserMappings");
				return null;
			}
			return this.GetUserMappings(serviceTask, regularUsersOnly);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00009E2C File Offset: 0x0000802C
		public UserMappings GetUserMappings(ServiceTask serviceTask, bool regularUsersOnly)
		{
			UserMappings result;
			try
			{
				List<UserMapping> list = new List<UserMapping>();
				List<UserDetail> list2 = new List<UserDetail>();
				List<UserDetail> list3 = new List<UserDetail>();
				Dictionary<string, NetUser> dictionary = new Dictionary<string, NetUser>();
				ServiceMachine dstServiceMachine = serviceTask.DstServiceMachine;
				NetUserMgr netUserMgr = (dstServiceMachine != null) ? dstServiceMachine.PcmMachine.NetUserMgr : null;
				uint num = 0U;
				if (netUserMgr != null)
				{
					for (;;)
					{
						NetUser netUser = netUserMgr.get_Accts(num++);
						if (netUser == null)
						{
							break;
						}
						bool flag = false;
						if (!regularUsersOnly || netUser.IsRegularUser)
						{
							if (dictionary.ContainsKey(netUser.IdentifyingName))
							{
								this.TraceCallerError(string.Format("Duplicate IdentifyingName at offset {0}: {1}", num - 1U, netUser.IdentifyingName), "GetUserMappings");
							}
							else
							{
								dictionary.Add(netUser.IdentifyingName, netUser);
								flag = true;
							}
						}
						if (!flag)
						{
							netUser.dispose();
						}
					}
				}
				UserMatchMgr userMatchMgr = serviceTask.Task.UserMatchMgr;
				ServiceMachine srcServiceMachine = serviceTask.SrcServiceMachine;
				NetUserMgr netUserMgr2 = (srcServiceMachine != null) ? srcServiceMachine.PcmMachine.NetUserMgr : null;
				if (netUserMgr2 != null)
				{
					num = 0U;
					for (;;)
					{
						NetUser netUser2 = netUserMgr2.get_Accts(num++);
						if (netUser2 == null)
						{
							break;
						}
						if (!regularUsersOnly || netUser2.IsRegularUser)
						{
							UserDetail userDetail = this.CreateUserDetail(netUser2);
							UserMatch matchByName = userMatchMgr.GetMatchByName(userDetail.AccountName);
							NetUser netUser3 = (matchByName != null) ? matchByName.DstUser : null;
							if (netUser3 == null)
							{
								list2.Add(userDetail);
							}
							else
							{
								string identifyingName = netUser3.IdentifyingName;
								if (dictionary.ContainsKey(identifyingName))
								{
									dictionary[identifyingName].dispose();
									dictionary.Remove(netUser3.IdentifyingName);
								}
							}
							if (matchByName != null)
							{
								UserMapping userMapping = new UserMapping
								{
									Old = userDetail,
									New = this.CreateUserDetail(netUser3),
									Create = (netUser3 != null && netUser3.bCreated),
									MoveFiles = userMatchMgr.get_MoveFiles(netUser2)
								};
								if (netUser3 != null)
								{
									this.AddProfileInfo(userMapping, matchByName);
								}
								list.Add(userMapping);
							}
						}
					}
				}
				foreach (KeyValuePair<string, NetUser> keyValuePair in dictionary)
				{
					list3.Add(this.CreateUserDetail(keyValuePair.Value));
					keyValuePair.Value.dispose();
				}
				result = new UserMappings(new UserMapSettings
				{
					RequireJoinedDomain = userMatchMgr.RequireJoinedDomain
				}, list, list3);
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "GetUserMappings");
				result = null;
			}
			return result;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000A0BC File Offset: 0x000082BC
		private void AddProfileInfo(UserMapping mapping, UserMatch userMatch)
		{
			List<string> list = new List<string>();
			uint num = 0U;
			for (;;)
			{
				string text = userMatch.get_AvailableProfiles(num++);
				if (text == null)
				{
					break;
				}
				list.Add(text);
			}
			mapping.AvailableProfiles = list;
			List<MapiProfileMapping> list2 = new List<MapiProfileMapping>();
			num = 0U;
			for (;;)
			{
				string text2;
				string newProfile;
				userMatch.GetProfileMapping(num++, out text2, out newProfile);
				if (text2 == null)
				{
					break;
				}
				list2.Add(new MapiProfileMapping(text2, newProfile));
			}
			mapping.MapiProfileMappings = list2;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000A124 File Offset: 0x00008324
		private bool SplitIdentifyingName(string identifyingName, out string domain, out string name)
		{
			char[] separator = new char[]
			{
				'\\'
			};
			string[] array = identifyingName.Split(separator);
			if (array.Length == 1)
			{
				domain = "";
				name = array[0];
				return true;
			}
			if (array.Length == 2)
			{
				domain = array[0];
				name = array[1];
				return true;
			}
			domain = null;
			name = null;
			return false;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000A174 File Offset: 0x00008374
		public CustomizationData TaskChangeUserMapping(int taskHandle, UserMapping userMapping)
		{
			this.VerifyControl("TaskChangeUserMapping");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				return this.CreateInvalidTaskCustomizationData(taskHandle, "TaskChangeUserMapping");
			}
			string value;
			if (userMapping == null)
			{
				value = null;
			}
			else
			{
				UserDetail old = userMapping.Old;
				value = ((old != null) ? old.AccountName : null);
			}
			if (string.IsNullOrWhiteSpace(value))
			{
				return this.CreateFailureCustomizationData("Old user account name not specified", "TaskChangeUserMapping");
			}
			if (serviceTask.SrcServiceMachine == null || serviceTask.DstServiceMachine == null)
			{
				return this.CreateFailureCustomizationData("Task does not contain 2 machines", "TaskChangeUserMapping");
			}
			NetUser netUser = serviceTask.SrcServiceMachine.PcmMachine.NetUserMgr.FindUser(userMapping.Old.AccountName);
			if (netUser == null)
			{
				return this.CreateFailureCustomizationData("Old user not found", "TaskChangeUserMapping");
			}
			UserMatchMgr userMatchMgr = serviceTask.Task.UserMatchMgr;
			NetUser netUser2 = null;
			if (userMapping.Create)
			{
				UserDetail @new = userMapping.New;
				if (@new == null)
				{
					return this.CreateFailureCustomizationData("New user not specified for Create", "TaskChangeUserMapping");
				}
				if (string.IsNullOrWhiteSpace(@new.AccountName))
				{
					return this.CreateFailureCustomizationData("New user account name not specified", "TaskChangeUserMapping");
				}
				if (serviceTask.DstServiceMachine.PcmMachine.NetUserMgr.FindUser(@new.AccountName) != null)
				{
					return this.CreateFailureCustomizationData("New user already exists for Create", "TaskChangeUserMapping");
				}
				string text;
				string bstrName;
				if (!this.SplitIdentifyingName(@new.AccountName, out text, out bstrName))
				{
					return this.CreateFailureCustomizationData("New user account name for Create is invalid", "TaskChangeUserMapping");
				}
				netUser2 = userMatchMgr.CreateNewUser(netUser, text, bstrName);
				if (netUser2 == null)
				{
					return this.CreateFailureCustomizationData("Could not create new user", "TaskChangeUserMapping");
				}
				if (text == "")
				{
					if (string.IsNullOrWhiteSpace(@new.FriendlyName))
					{
						netUser2.FullName = netUser.FullName;
					}
					else
					{
						netUser2.FullName = @new.FriendlyName;
					}
				}
				string keyGroups = "";
				switch (@new.UserType)
				{
				case UserType.Administrator:
					keyGroups = "A";
					break;
				case UserType.Standard:
					keyGroups = "U";
					break;
				case UserType.Guest:
					keyGroups = "G";
					break;
				}
				netUser2.KeyGroups = keyGroups;
			}
			else if (userMapping.New != null)
			{
				Machine pcmMachine = serviceTask.DstServiceMachine.PcmMachine;
				netUser2 = pcmMachine.NetUserMgr.FindUser(userMapping.New.AccountName);
				if (netUser2 == null)
				{
					if (pcmMachine.TreeStatus != TREE_STATUS.TS_NOSNAP)
					{
						return this.CreateFailureCustomizationData("New user does not exist", "TaskChangeUserMapping");
					}
					if (!(userMapping.Old.AccountName == userMapping.New.AccountName))
					{
						return this.CreateFailureCustomizationData("Invalid New user for NoSnap user selection", "TaskChangeUserMapping");
					}
					netUser2 = netUser;
				}
			}
			UserMatch matchByName = userMatchMgr.GetMatchByName(userMapping.Old.AccountName);
			if (matchByName != null)
			{
				matchByName.DstUser = netUser2;
				if (userMatchMgr.get_MoveFiles(netUser) != userMapping.MoveFiles)
				{
					this.Ts.TraceInformation(string.Format("Changing MoveFiles for {0} to {1}", userMapping.Old.FriendlyName, userMapping.MoveFiles));
					userMatchMgr.set_MoveFiles(netUser, userMapping.MoveFiles);
				}
				if (userMapping.MapiProfileMappings == null)
				{
					goto IL_357;
				}
				matchByName.ClearProfileMappings();
				using (IEnumerator<MapiProfileMapping> enumerator = userMapping.MapiProfileMappings.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						MapiProfileMapping mapiProfileMapping = enumerator.Current;
						if (!string.IsNullOrWhiteSpace(mapiProfileMapping.OldProfile))
						{
							matchByName.set_ProfileMappings(mapiProfileMapping.OldProfile, mapiProfileMapping.NewProfile);
						}
					}
					goto IL_357;
				}
			}
			this.Ts.TraceError("Cannot find user match for " + userMapping.Old.AccountName);
			IL_357:
			serviceTask.RematchApps = true;
			this.Ts.TraceCaller(TraceEventType.Verbose, "Mark change lists to be recreated", "TaskChangeUserMapping");
			serviceTask.RecreateChangeLists = true;
			serviceTask.RebuildRules = true;
			return this.CreateSuccessCustomizationData(CustomizationAffects.Applications | CustomizationAffects.DiskItems | CustomizationAffects.RegistryItems);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000A51C File Offset: 0x0000871C
		public CustomizationData TaskSetUserPassword(int taskHandle, UserDetail user, string password)
		{
			this.VerifyControl("TaskSetUserPassword");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				return this.CreateInvalidTaskCustomizationData(taskHandle, "TaskSetUserPassword");
			}
			if (user == null)
			{
				return this.CreateFailureCustomizationData("No UserDetail specified", "TaskSetUserPassword");
			}
			if (password == null)
			{
				return this.CreateFailureCustomizationData("No password specified", "TaskSetUserPassword");
			}
			if (string.IsNullOrWhiteSpace(user.AccountName))
			{
				return this.CreateFailureCustomizationData("User account name not specified", "TaskSetUserPassword");
			}
			ServiceMachine dstServiceMachine = serviceTask.DstServiceMachine;
			using (PcmoverObjectWrapper<NetUser> pcmoverObjectWrapper = new PcmoverObjectWrapper<NetUser>((dstServiceMachine != null) ? dstServiceMachine.PcmMachine.NetUserMgr.FindUser(user.AccountName) : null))
			{
				if (pcmoverObjectWrapper.Value == null)
				{
					return this.CreateFailureCustomizationData("User not found", "TaskSetUserPassword");
				}
				if (!pcmoverObjectWrapper.Value.SetPassword(password))
				{
					return this.CreateFailureCustomizationData("SetPassword failed", "TaskSetUserPassword");
				}
			}
			return this.CreateSuccessCustomizationData(CustomizationAffects.None);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000A61C File Offset: 0x0000881C
		public DriveData TaskGetDriveData(int taskHandle)
		{
			this.VerifyControl("TaskGetDriveData");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				this.TraceCallerError(string.Format("Invalid taskHandle: {0}", taskHandle), "TaskGetDriveData");
				return null;
			}
			DriveData result;
			try
			{
				serviceTask.GetDrives();
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<DrivePair> list3 = new List<DrivePair>();
				DriveMatch driveMatch = serviceTask.Task.DriveMatch;
				foreach (object obj in driveMatch.OldDrives)
				{
					string text = (string)obj;
					list.Add(text);
					DrivePair item = new DrivePair
					{
						OldDrive = text,
						NewDrive = driveMatch.get_Match(text)
					};
					list3.Add(item);
				}
				foreach (object obj2 in driveMatch.NewDrives)
				{
					string item2 = (string)obj2;
					list2.Add(item2);
				}
				result = new DriveData
				{
					Matches = list3,
					OldDrives = list,
					NewDrives = list2
				};
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "TaskGetDriveData");
				result = null;
			}
			return result;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000A798 File Offset: 0x00008998
		public CustomizationData TaskChangeDriveMapping(int taskHandle, DrivePair drivePair)
		{
			this.VerifyControl("TaskChangeDriveMapping");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				return this.CreateInvalidTaskCustomizationData(taskHandle, "TaskChangeDriveMapping");
			}
			if (drivePair == null)
			{
				return this.CreateFailureCustomizationData("No DrivePair specified", "TaskChangeDriveMapping");
			}
			if (string.IsNullOrWhiteSpace(drivePair.OldDrive))
			{
				return this.CreateFailureCustomizationData("No OldDrive specified", "TaskChangeDriveMapping");
			}
			CustomizationAffects customizationAffects = CustomizationAffects.None;
			try
			{
				DriveMatch driveMatch = serviceTask.Task.DriveMatch;
				if (drivePair.NewDrive != driveMatch.get_Match(drivePair.OldDrive))
				{
					driveMatch.set_Match(drivePair.OldDrive, drivePair.NewDrive);
					customizationAffects |= CustomizationAffects.DiskItems;
					this.Ts.TraceCaller(TraceEventType.Verbose, "Mark change lists to be recreated", "TaskChangeDriveMapping");
					serviceTask.RecreateChangeLists = true;
				}
			}
			catch (Exception ex)
			{
				return this.CreateFailureCustomizationData(ex.Message, "TaskChangeDriveMapping");
			}
			return this.CreateSuccessCustomizationData(customizationAffects);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000A888 File Offset: 0x00008A88
		private void DetermineTransferrableAndTarget(IPcmTask task, TreeNode node, out Transferrable transferrable, out string target)
		{
			bool flag;
			task.GetIsIgnoredAndTarget(node, out flag, out target);
			if (flag)
			{
				transferrable = Transferrable.RuleExcluded;
				return;
			}
			if (task.IsDiskNodeFiltered(node))
			{
				transferrable = Transferrable.Filtered;
				return;
			}
			transferrable = Transferrable.Transfer;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000A8B8 File Offset: 0x00008AB8
		public TransferrableContainerData TaskGetTransferrableContainerData(int taskHandle, ItemType type, string path, bool withinBranch, CountDetail countDetail, bool includeTargets, bool allAppsOnly, RequestedPage page)
		{
			this.VerifyControl("TaskGetTransferrableContainerData");
			TransferrableContainerData result;
			try
			{
				if (page == null)
				{
					this.TraceCallerError("No page parameter specified", "TaskGetTransferrableContainerData");
					result = null;
				}
				else
				{
					ServiceTask serviceTask = this.GetServiceTask(taskHandle);
					if (serviceTask == null)
					{
						this.TraceCallerError(string.Format("Invalid task handle {0}", taskHandle), "TaskGetTransferrableContainerData");
						result = null;
					}
					else
					{
						TreeImpl treeImpl = null;
						using (PcmoverObjectWrapper<TreeRoot> treeRootWrapper = this.GetTreeRootWrapper(serviceTask.SrcServiceMachine, type))
						{
							if (((treeRootWrapper != null) ? treeRootWrapper.Value : null) == null)
							{
								this.TraceCallerError(string.Format("Null tree root for {0} in task handle {1}", type, taskHandle), "TaskGetTransferrableContainerData");
								return null;
							}
							TreeImpl tree = treeRootWrapper.Value.Tree;
							if (tree == null)
							{
								this.TraceCallerError(string.Format("Null tree root tree for type {0} in task handle {1}", type, taskHandle), "TaskGetTransferrableContainerData");
								return null;
							}
							treeImpl = tree.FindTreeFromPath(path);
							if (treeImpl == null)
							{
								this.TraceCallerError(string.Format("Path {0} not found in task handle {1}", path, taskHandle), "TaskGetTransferrableContainerData");
								return null;
							}
						}
						serviceTask.GetChangeLists();
						ulong num = withinBranch ? treeImpl.Branch.Id : 0UL;
						TreeNode node = (TreeNode)treeImpl;
						IPcmTask task = serviceTask.Task;
						Transferrable transferrable;
						string target;
						this.DetermineTransferrableAndTarget(task, node, out transferrable, out target);
						List<TransferrableContainerInfo> list = new List<TransferrableContainerInfo>();
						List<TransferrableItemDefinition> list2 = new List<TransferrableItemDefinition>();
						TransferrableContainerData transferrableContainerData = new TransferrableContainerData
						{
							FullPath = path,
							Transferrable = transferrable,
							Containers = list,
							Items = list2
						};
						if (includeTargets)
						{
							transferrableContainerData.Target = target;
						}
						if (countDetail != CountDetail.None)
						{
							this.SetStats(transferrableContainerData, treeImpl.GetStats(withinBranch, allAppsOnly));
						}
						int num2 = 0;
						uint num3 = 0U;
						while (page.MaxCount > 0)
						{
							TreeNode treeNode = treeImpl.get_Child(num3);
							if (treeNode == null)
							{
								break;
							}
							if (!withinBranch || num == treeNode.Branch.Id)
							{
								if (treeNode.IsTree)
								{
									if (num2++ >= page.StartIndex)
									{
										this.DetermineTransferrableAndTarget(task, treeNode, out transferrable, out target);
										TransferrableContainerInfo transferrableContainerInfo = new TransferrableContainerInfo
										{
											FullPath = Path.Combine(path, treeNode.Name),
											Transferrable = transferrable
										};
										if (countDetail == CountDetail.All)
										{
											TreeImpl treeImpl2 = (TreeImpl)treeNode;
											this.SetStats(transferrableContainerInfo, treeImpl2.GetStats(withinBranch, allAppsOnly));
										}
										if (includeTargets)
										{
											transferrableContainerInfo.Target = target;
										}
										list.Add(transferrableContainerInfo);
										int maxCount = page.MaxCount - 1;
										page.MaxCount = maxCount;
									}
								}
								else if ((!allAppsOnly || treeNode.BelongsToAllApps) && num2++ >= page.StartIndex)
								{
									this.DetermineTransferrableAndTarget(task, treeNode, out transferrable, out target);
									TransferrableItemDefinition transferrableItemDefinition = new TransferrableItemDefinition
									{
										Name = treeNode.Name,
										Size = treeNode.NumBytes,
										Transferrable = transferrable
									};
									if (includeTargets)
									{
										transferrableItemDefinition.Target = target;
									}
									list2.Add(transferrableItemDefinition);
									int maxCount = page.MaxCount - 1;
									page.MaxCount = maxCount;
								}
							}
							num3 += 1U;
						}
						result = transferrableContainerData;
					}
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "TaskGetTransferrableContainerData");
				result = null;
			}
			return result;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000AC1C File Offset: 0x00008E1C
		public CustomizationData TaskChangeContainerData(int taskHandle, ItemType type, string containerPath, string itemName, bool isContainer, bool? userSelected, string target, bool containerAllAppsOnly)
		{
			this.VerifyControl("TaskChangeContainerData");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				return this.CreateInvalidTaskCustomizationData(taskHandle, "TaskChangeContainerData");
			}
			if (type != ItemType.Disk)
			{
				return this.CreateFailureCustomizationData("Only disk filters can be changed", "TaskChangeContainerData");
			}
			string bstrPath = containerPath;
			IPcmTask task = serviceTask.Task;
			CustomizationAffects customizationAffects = CustomizationAffects.None;
			try
			{
				if (isContainer)
				{
					if (userSelected != null && task.SetDirectoryFilter(containerPath, userSelected.Value))
					{
						customizationAffects |= CustomizationAffects.DiskItems;
					}
					if (!string.IsNullOrWhiteSpace(target) && task.SetDirectoryTarget(containerPath, target, containerAllAppsOnly))
					{
						customizationAffects |= CustomizationAffects.DiskItems;
					}
				}
				else
				{
					bstrPath = Path.Combine(containerPath, itemName);
					bool flag = userSelected != null;
					if (flag || !string.IsNullOrWhiteSpace(target))
					{
						task.SetFileFilter(containerPath, itemName, flag, !flag || userSelected.Value, target);
						customizationAffects |= CustomizationAffects.FileFilters;
					}
				}
				if (customizationAffects != CustomizationAffects.None)
				{
					task.InvalidateChangeNode(bstrPath, ENUM_TTID.DISK_TTID);
				}
			}
			catch (Exception ex)
			{
				return this.CreateExceptionCustomizationData(ex, "TaskChangeContainerData");
			}
			this.Ts.TraceCaller(TraceEventType.Verbose, string.Format("{0} {1} Folder:{2} Selected:{3} Target:{4} AllAppsOnly:{5} Affects:{6}", new object[]
			{
				containerPath,
				itemName,
				isContainer,
				userSelected,
				target,
				containerAllAppsOnly,
				customizationAffects
			}), "TaskChangeContainerData");
			return this.CreateSuccessCustomizationData(customizationAffects);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000AD80 File Offset: 0x00008F80
		public CustomizationData TaskRemoveRedirection(int taskHandle, ItemType type, string containerPath, string itemName, bool isContainer, bool containerAllAppsOnly)
		{
			this.VerifyControl("TaskRemoveRedirection");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				return this.CreateInvalidTaskCustomizationData(taskHandle, "TaskRemoveRedirection");
			}
			if (type != ItemType.Disk)
			{
				return this.CreateFailureCustomizationData("Only disk filters can be changed", "TaskRemoveRedirection");
			}
			string text = containerPath;
			IPcmTask task = serviceTask.Task;
			CustomizationAffects customizationAffects = CustomizationAffects.None;
			try
			{
				if (isContainer)
				{
					if (task.SetDirectoryTarget(containerPath, "", containerAllAppsOnly))
					{
						customizationAffects |= CustomizationAffects.DiskItems;
					}
				}
				else
				{
					using (PcmoverObjectWrapper<LeafFilters> pcmoverObjectWrapper = new PcmoverObjectWrapper<LeafFilters>(task.FileFilters))
					{
						if (((pcmoverObjectWrapper != null) ? pcmoverObjectWrapper.Value : null) != null)
						{
							text = Path.Combine(containerPath, itemName);
							List<int> list = new List<int>();
							int num = 0;
							foreach (object obj in pcmoverObjectWrapper.Value)
							{
								LeafFilter leafFilter = (LeafFilter)obj;
								if (leafFilter.Modify && string.Compare(leafFilter.FullName, text, true) == 0 && !string.IsNullOrWhiteSpace(leafFilter.Target))
								{
									customizationAffects |= CustomizationAffects.DiskItems;
									if (leafFilter.Migrate == TriBool.indeterminate_value)
									{
										list.Insert(0, num);
									}
									else
									{
										leafFilter.Target = "";
									}
								}
								num++;
							}
							foreach (int index in list)
							{
								pcmoverObjectWrapper.Value.Delete(index);
							}
						}
					}
				}
				if (customizationAffects != CustomizationAffects.None)
				{
					task.InvalidateChangeNode(text, ENUM_TTID.DISK_TTID);
				}
			}
			catch (Exception ex)
			{
				return this.CreateExceptionCustomizationData(ex, "TaskRemoveRedirection");
			}
			this.Ts.TraceCaller(TraceEventType.Verbose, string.Format("{0} {1} Folder:{2} AllAppsOnly:{3} Affects:{4}", new object[]
			{
				containerPath,
				itemName,
				isContainer,
				containerAllAppsOnly,
				customizationAffects
			}), "TaskRemoveRedirection");
			return this.CreateSuccessCustomizationData(customizationAffects);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000AFD8 File Offset: 0x000091D8
		private bool? ConvertTribool(TriBool val)
		{
			if (val == TriBool.false_value)
			{
				return new bool?(false);
			}
			if (val != TriBool.true_value)
			{
				return null;
			}
			return new bool?(true);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000B005 File Offset: 0x00009205
		private TriBool ConvertToTribool(bool? val)
		{
			if (val == null)
			{
				return TriBool.indeterminate_value;
			}
			if (!val.Value)
			{
				return TriBool.false_value;
			}
			return TriBool.true_value;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000B020 File Offset: 0x00009220
		public IEnumerable<ItemFilterData> TaskGetItemFilters(int taskHandle, ItemType type)
		{
			this.VerifyControl("TaskGetItemFilters");
			if (type != ItemType.Disk)
			{
				this.TraceCallerError(string.Format("Invalid ItemType: {0}", type), "TaskGetItemFilters");
				return null;
			}
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				this.TraceCallerError(string.Format("Invalid task handle: {0}", taskHandle), "TaskGetItemFilters");
				return null;
			}
			List<ItemFilterData> list = new List<ItemFilterData>();
			using (PcmoverObjectWrapper<LeafFilters> pcmoverObjectWrapper = new PcmoverObjectWrapper<LeafFilters>(serviceTask.Task.FileFilters))
			{
				if (((pcmoverObjectWrapper != null) ? pcmoverObjectWrapper.Value : null) != null)
				{
					foreach (object obj in pcmoverObjectWrapper.Value)
					{
						LeafFilter leafFilter = (LeafFilter)obj;
						if (leafFilter.Modify)
						{
							ItemFilterData item = new ItemFilterData
							{
								SourceMask = leafFilter.FullName,
								Target = leafFilter.Target,
								Transfer = this.ConvertTribool(leafFilter.Migrate)
							};
							list.Add(item);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000B14C File Offset: 0x0000934C
		private int GetRealIndex(LeafFilters filters, int modifiableIndex)
		{
			if (modifiableIndex < 0)
			{
				return modifiableIndex;
			}
			int num = 0;
			using (IEnumerator enumerator = filters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (((LeafFilter)enumerator.Current).Modify && modifiableIndex-- == 0)
					{
						return num;
					}
					num++;
				}
			}
			return -1;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000B1BC File Offset: 0x000093BC
		private CustomizationData ChangeFileFilter(LeafFilters filters, int index, ItemFilterData itemFilter)
		{
			try
			{
				if (index == -1)
				{
					if (itemFilter == null)
					{
						return this.CreateFailureCustomizationData("No filter specified for Add", "ChangeFileFilter");
					}
					filters.Add(itemFilter.SourceMask, itemFilter.Target, this.ConvertToTribool(itemFilter.Transfer), true);
				}
				else
				{
					int realIndex = this.GetRealIndex(filters, index);
					if (realIndex == -1)
					{
						return this.CreateFailureCustomizationData("Invalid filter index", "ChangeFileFilter");
					}
					if (itemFilter == null)
					{
						filters.Delete(realIndex);
					}
					else
					{
						LeafFilter leafFilter = filters[realIndex + 1];
						if (leafFilter == null)
						{
							return this.CreateFailureCustomizationData("Unexpected failure to find the filter", "ChangeFileFilter");
						}
						leafFilter.FullName = itemFilter.SourceMask;
						leafFilter.Target = itemFilter.Target;
						leafFilter.Migrate = this.ConvertToTribool(itemFilter.Transfer);
					}
				}
			}
			catch (Exception ex)
			{
				return this.CreateFailureCustomizationData("Unexpected exception: " + ex.Message, "ChangeFileFilter");
			}
			return this.CreateSuccessCustomizationData(CustomizationAffects.DiskItems);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000B2BC File Offset: 0x000094BC
		public CustomizationData TaskChangeItemFilter(int taskHandle, ItemType type, int index, ItemFilterData itemFilter)
		{
			this.VerifyControl("TaskChangeItemFilter");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				return this.CreateInvalidTaskCustomizationData(taskHandle, "TaskChangeItemFilter");
			}
			if (type != ItemType.Disk)
			{
				return this.CreateFailureCustomizationData("Only disk filters can be changed", "TaskChangeItemFilter");
			}
			CustomizationData result;
			using (PcmoverObjectWrapper<LeafFilters> pcmoverObjectWrapper = new PcmoverObjectWrapper<LeafFilters>(serviceTask.Task.FileFilters))
			{
				if (((pcmoverObjectWrapper != null) ? pcmoverObjectWrapper.Value : null) == null)
				{
					result = this.CreateFailureCustomizationData("Internal error, no File Filters", "TaskChangeItemFilter");
				}
				else
				{
					CustomizationData customizationData = this.ChangeFileFilter(pcmoverObjectWrapper.Value, index, itemFilter);
					if (customizationData.Result == CustomizationResult.Success)
					{
						serviceTask.RebuildDiskItems = true;
					}
					result = customizationData;
				}
			}
			return result;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0000B370 File Offset: 0x00009570
		public CustomizationData TaskSwapItemFilters(int taskHandle, ItemType type, int index1, int index2)
		{
			this.VerifyControl("TaskSwapItemFilters");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				return this.CreateInvalidTaskCustomizationData(taskHandle, "TaskSwapItemFilters");
			}
			if (type != ItemType.Disk)
			{
				return this.CreateFailureCustomizationData("Only disk filters can be changed", "TaskSwapItemFilters");
			}
			CustomizationData result;
			using (PcmoverObjectWrapper<LeafFilters> pcmoverObjectWrapper = new PcmoverObjectWrapper<LeafFilters>(serviceTask.Task.FileFilters))
			{
				if (((pcmoverObjectWrapper != null) ? pcmoverObjectWrapper.Value : null) == null)
				{
					result = this.CreateFailureCustomizationData("Internal error, no File Filters", "TaskSwapItemFilters");
				}
				else
				{
					int realIndex = this.GetRealIndex(pcmoverObjectWrapper.Value, index1);
					int realIndex2 = this.GetRealIndex(pcmoverObjectWrapper.Value, index2);
					CustomizationData customizationData;
					if (realIndex < 0 || realIndex2 < 0)
					{
						customizationData = this.CreateFailureCustomizationData("Invalid index", "TaskSwapItemFilters");
					}
					else
					{
						pcmoverObjectWrapper.Value.Swap(realIndex, realIndex2);
						customizationData = this.CreateSuccessCustomizationData(CustomizationAffects.DiskItems);
						serviceTask.RebuildDiskItems = true;
					}
					result = customizationData;
				}
			}
			return result;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0000B460 File Offset: 0x00009660
		internal List<DriveSpaceRequired> ConvertRequiredMap(DriveSpaceRequiredMap requiredMap)
		{
			List<DriveSpaceRequired> list = new List<DriveSpaceRequired>();
			int firstDrive = requiredMap.FirstDrive;
			if (firstDrive != -1)
			{
				int lastDrive = requiredMap.LastDrive;
				for (int i = firstDrive; i <= lastDrive; i++)
				{
					ulong num = requiredMap.get_Bytes(i);
					if (num != 0UL)
					{
						list.Add(new DriveSpaceRequired
						{
							Drive = string.Format("{0}:\\", (char)(65 + i)),
							Required = num
						});
					}
				}
			}
			return list;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000B4CC File Offset: 0x000096CC
		public bool TaskSetVanPassword(int taskHandle, string password)
		{
			this.VerifyControl("TaskSetVanPassword");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			IPcmTask pcmTask = (serviceTask != null) ? serviceTask.Task : null;
			if (pcmTask == null)
			{
				return false;
			}
			pcmTask.VanPassword = password;
			return true;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000B508 File Offset: 0x00009708
		public TaskStats TaskGetStats(int taskHandle, bool includeDriveSpace)
		{
			this.VerifyControl("TaskGetStats");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			IPcmTask pcmTask = (serviceTask != null) ? serviceTask.Task : null;
			if (pcmTask == null)
			{
				this.TraceCallerError(string.Format("Invalid taskHandle: {0}", taskHandle), "TaskGetStats");
				return null;
			}
			TaskItemRoot taskItemRoot = pcmTask.get_TaskItemRoot(ENUM_TTID.DISK_TTID);
			if (taskItemRoot == null)
			{
				return null;
			}
			TaskItemRoot taskItemRoot2 = pcmTask.get_TaskItemRoot(ENUM_TTID.REG_TTID);
			if (taskItemRoot2 == null)
			{
				return null;
			}
			TaskStats taskStats = new TaskStats
			{
				Disk = new ContainerStats(),
				Registry = new ContainerStats()
			};
			if (includeDriveSpace)
			{
				TreeStats psmStats;
				DriveSpaceRequiredMap requiredMap;
				taskItemRoot.CopyStats(out psmStats, out requiredMap);
				this.SetStats(taskStats.Disk, psmStats);
				taskStats.DriveSpaceRequired = this.ConvertRequiredMap(requiredMap);
				if (taskStats.DriveSpaceRequired == null)
				{
					goto IL_14A;
				}
				this.Ts.TraceInformation(string.Format("TaskGetStats: Drives receiving data: {0}", taskStats.DriveSpaceRequired.Count<DriveSpaceRequired>()));
				using (IEnumerator<DriveSpaceRequired> enumerator = taskStats.DriveSpaceRequired.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DriveSpaceRequired driveSpaceRequired = enumerator.Current;
						this.Ts.TraceInformation("TaskGetStats: " + driveSpaceRequired.Drive + " requires " + driveSpaceRequired.Required.ToString("N0"));
					}
					goto IL_14A;
				}
			}
			this.SetStats(taskStats.Disk, taskItemRoot.TreeStats);
			IL_14A:
			this.SetStats(taskStats.Registry, taskItemRoot2.TreeStats);
			return taskStats;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000B684 File Offset: 0x00009884
		public IEnumerable<TransferrableCategoryDefinition> TaskGetCategories(int taskHandle, CategoryParameters categoryParameters, RequestedPage page)
		{
			this.VerifyControl("TaskGetCategories");
			if (categoryParameters == null || page == null)
			{
				this.TraceCallerError("Invalid parameters", "TaskGetCategories");
				return null;
			}
			this.Ts.TraceCaller(TraceEventType.Verbose, string.Format("task {0} type {1}, startIndex: {2}, maxCount: {3}", new object[]
			{
				taskHandle,
				categoryParameters.Type,
				page.StartIndex,
				page.MaxCount
			}), "TaskGetCategories");
			IEnumerable<TransferrableCategoryDefinition> result;
			try
			{
				ServiceTask serviceTask = this.GetServiceTask(taskHandle);
				if (serviceTask == null)
				{
					this.TraceCallerError(string.Format("Invalid task handle {0}", taskHandle), "TaskGetCategories");
					result = null;
				}
				else
				{
					using (PcmoverObjectWrapper<TreeRoot> treeRootWrapper = this.GetTreeRootWrapper(serviceTask.SrcServiceMachine, categoryParameters.Type))
					{
						if (((treeRootWrapper != null) ? treeRootWrapper.Value : null) == null)
						{
							this.TraceCallerError(string.Format("Null tree root for {0} in task handle {1}", categoryParameters.Type, taskHandle), "TaskGetCategories");
							result = null;
						}
						else
						{
							TreeBranches branches = treeRootWrapper.Value.Branches;
							if (branches == null)
							{
								this.TraceCallerError(string.Format("No categories for {0} in task handle {1}", categoryParameters.Type, taskHandle), "TaskGetCategories");
								result = null;
							}
							else
							{
								serviceTask.GetChangeLists();
								IPcmTask task = serviceTask.Task;
								ITaskItemRoot taskItemRoot = task.get_TaskItemRoot(this.ItemTypeToTreeType(categoryParameters.Type));
								if (taskItemRoot == null)
								{
									this.TraceCallerError(string.Format("No TaskItemRoot for {0} in {1}", categoryParameters.Type, taskHandle), "TaskGetCategories");
									result = null;
								}
								else
								{
									List<TransferrableCategoryDefinition> list = new List<TransferrableCategoryDefinition>();
									if (page.MaxCount == 0)
									{
										result = list;
									}
									else
									{
										int count = branches.Count;
										int num = 0;
										for (int i = 1; i <= count; i++)
										{
											TreeBranch treeBranch = branches[i];
											NetUser user = treeBranch.User;
											if ((!categoryParameters.RegularUsersOnly || user == null || user.IsRegularUser) && num++ >= page.StartIndex)
											{
												TransferrableCategoryDefinition transferrableCategoryDefinition = new TransferrableCategoryDefinition();
												this.InitializeCategoryDefinition(transferrableCategoryDefinition, treeBranch, user);
												TreeImpl tree = treeBranch.Tree;
												if (tree != null)
												{
													if (categoryParameters.IncludeCounts && !taskItemRoot.IsExcluded(treeBranch))
													{
														this.SetStats(transferrableCategoryDefinition, tree.GetStats(true, categoryParameters.AllAppsOnly));
													}
													Transferrable transferrable;
													string target;
													this.DetermineTransferrableAndTarget(task, (TreeNode)tree, out transferrable, out target);
													transferrableCategoryDefinition.Transferrable = transferrable;
													transferrableCategoryDefinition.Target = target;
												}
												list.Add(transferrableCategoryDefinition);
												if (list.Count >= page.MaxCount)
												{
													break;
												}
											}
										}
										result = list;
									}
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "TaskGetCategories");
				result = null;
			}
			return result;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000B96C File Offset: 0x00009B6C
		public TransferContainerData TaskGetTransferContainerData(int taskHandle, ItemType type, CategoryDefinition category, string path, CountDetail countDetail, RequestedPage page)
		{
			this.VerifyControl("TaskGetTransferContainerData");
			TransferContainerData result;
			try
			{
				if (category == null || page == null)
				{
					this.TraceCallerError("Invalid parameter", "TaskGetTransferContainerData");
					result = null;
				}
				else
				{
					ServiceTask serviceTask = this.GetServiceTask(taskHandle);
					if (serviceTask == null)
					{
						this.TraceCallerError(string.Format("Invalid task: {0}", taskHandle), "TaskGetTransferContainerData");
						result = null;
					}
					else
					{
						IPcmTask task = serviceTask.Task;
						if (task == null)
						{
							result = null;
						}
						else
						{
							serviceTask.GetChangeLists();
							TaskItemRoot taskItemRoot = task.get_TaskItemRoot(this.ItemTypeToTreeType(type));
							result = null;
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "TaskGetTransferContainerData");
				result = null;
			}
			return result;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000BA18 File Offset: 0x00009C18
		public bool TaskUploadApplicationReport(int taskHandle)
		{
			this.VerifyControl("TaskUploadApplicationReport");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			IPcmTask pcmTask = (serviceTask != null) ? serviceTask.Task : null;
			return pcmTask != null && pcmTask.UploadXmlReport();
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000BA50 File Offset: 0x00009C50
		public IEnumerable<string> TaskGetRedistPackages(int unloadTaskHandle)
		{
			this.VerifyControl("TaskGetRedistPackages");
			ServiceTask serviceTask = this.GetServiceTask(unloadTaskHandle);
			UnloadVanTask unloadVanTask = ((serviceTask != null) ? serviceTask.Task : null) as UnloadVanTask;
			if (unloadVanTask == null)
			{
				this.TraceCallerError(string.Format("Invalid unloadTaskHandle: {0}", unloadTaskHandle), "TaskGetRedistPackages");
				return null;
			}
			List<string> list = new List<string>();
			PcmStringList redistPackages = unloadVanTask.RedistPackages;
			if (redistPackages != null)
			{
				foreach (object obj in redistPackages)
				{
					string item = (string)obj;
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000BB00 File Offset: 0x00009D00
		public FinishTransferData TaskPerformPostTransferActions(int taskHandle, bool dlmgrReboot)
		{
			this.VerifyControl("TaskPerformPostTransferActions");
			this.Ts.TraceCaller(string.Format("task {0}, reboot {1}", taskHandle, dlmgrReboot), "TaskPerformPostTransferActions");
			FinishTransferData finishTransferData = new FinishTransferData();
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			IPcmTask pcmTask = (serviceTask != null) ? serviceTask.Task : null;
			if (pcmTask == null)
			{
				finishTransferData.FailureReason = "Invalid taskHandle";
				return finishTransferData;
			}
			string text;
			string arguments;
			if (!pcmTask.SaveDlMgrCmd(dlmgrReboot, out text, out arguments))
			{
				finishTransferData.FailureReason = "Unable to save DlMgr command";
				return finishTransferData;
			}
			finishTransferData.Succeeded = true;
			if (text != null)
			{
				finishTransferData.LaunchExe = true;
				finishTransferData.ExeFileName = text;
				finishTransferData.Arguments = arguments;
			}
			return finishTransferData;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000BBA4 File Offset: 0x00009DA4
		private void DelayedReboot(TimeSpan delayTime)
		{
			PcmoverManager.<DelayedReboot>d__287 <DelayedReboot>d__;
			<DelayedReboot>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<DelayedReboot>d__.<>4__this = this;
			<DelayedReboot>d__.delayTime = delayTime;
			<DelayedReboot>d__.<>1__state = -1;
			<DelayedReboot>d__.<>t__builder.Start<PcmoverManager.<DelayedReboot>d__287>(ref <DelayedReboot>d__);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000BBE4 File Offset: 0x00009DE4
		public bool Reboot(uint delay)
		{
			this.VerifyControl("Reboot");
			this.Ts.TraceCaller(string.Format("Reboot service operation called, requesting reboot in {0} ms", delay), "Reboot");
			this._waitingForReboot = true;
			Task.Run(delegate()
			{
				this.DelayedReboot(TimeSpan.FromMilliseconds(delay));
			});
			return true;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000BC4F File Offset: 0x00009E4F
		public bool SetProxyAuth(string proxy, string username, string password)
		{
			this.VerifyControl("SetProxyAuth");
			this.m_proxy = proxy;
			this.m_proxyUsername = username;
			this.m_proxyPassword = password;
			PCmoverApp app = this._app;
			if (app != null)
			{
				app.SetProxyAuth(this.m_proxyUsername, this.m_proxyPassword);
			}
			return true;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000BC90 File Offset: 0x00009E90
		public IEnumerable<NetworkInfo> GetNetworkInfos()
		{
			this.VerifyControl("GetNetworkInfos");
			IEnumerable<NetworkInfo> result;
			try
			{
				List<NetworkInfo> list = new List<NetworkInfo>();
				foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
				{
					list.Add(new NetworkInfo(nic));
				}
				result = list;
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "GetNetworkInfos");
				result = null;
			}
			return result;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000BD04 File Offset: 0x00009F04
		public RebootPendingReasons CheckRebootPending()
		{
			this.VerifyControl("CheckRebootPending");
			RebootPendingReasons rebootPendingReasons = CheckRebootHelper.GetRebootPendingReasons(this.Ts);
			this.Ts.TraceCaller(rebootPendingReasons.ToString(), "CheckRebootPending");
			return rebootPendingReasons;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000BD46 File Offset: 0x00009F46
		public bool LaunchStartupAutoRun()
		{
			this.VerifyControl("LaunchStartupAutoRun");
			if (this._app == null)
			{
				return false;
			}
			this._app.LaunchStartupAutoRun();
			return true;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000BD6C File Offset: 0x00009F6C
		public bool MarkUserDeferredComplete(string userName, string userSid)
		{
			this.VerifyControl("MarkUserDeferredComplete");
			if (this._app == null)
			{
				this.TraceCallerError("App not initialized", "MarkUserDeferredComplete");
				return false;
			}
			if (string.IsNullOrWhiteSpace(userName) && string.IsNullOrWhiteSpace(userSid))
			{
				this.TraceCallerError("No user specified", "MarkUserDeferredComplete");
				return false;
			}
			bool result;
			try
			{
				NetUserMgr netUserMgr = this.ThisServiceMachine.PcmMachine.NetUserMgr;
				string str;
				NetUser netUser;
				if (string.IsNullOrWhiteSpace(userName))
				{
					str = "SID " + userSid;
					netUser = netUserMgr.FindUserBySid(userSid);
				}
				else
				{
					str = "User named " + userName;
					netUser = netUserMgr.FindUser(userName);
				}
				if (netUser == null)
				{
					this.TraceCallerError(str + " not found", "MarkUserDeferredComplete");
					result = false;
				}
				else
				{
					string sid = netUser.Sid;
					if (string.IsNullOrWhiteSpace(sid))
					{
						this.TraceCallerError(str + " has no SID", "MarkUserDeferredComplete");
						result = false;
					}
					else
					{
						Registry.SetValue("HKEY_USERS\\" + sid + "\\Software\\Laplink\\PCmover\\Settings", "DeferredComplete", 1, RegistryValueKind.DWord);
						result = true;
					}
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "MarkUserDeferredComplete");
				result = false;
			}
			return result;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000BEA4 File Offset: 0x0000A0A4
		private TransferMethodType CastToTransferMethodEnum(ENUM_TRANSFERMETHOD etm)
		{
			if (etm <= ENUM_TRANSFERMETHOD.TM_LIVE)
			{
				if (etm == ENUM_TRANSFERMETHOD.TM_FILE)
				{
					return TransferMethodType.File;
				}
				if (etm == ENUM_TRANSFERMETHOD.TM_LIVE)
				{
					return TransferMethodType.Image;
				}
			}
			else
			{
				if (etm == ENUM_TRANSFERMETHOD.TM_NETWORK)
				{
					return TransferMethodType.Network;
				}
				if (etm == ENUM_TRANSFERMETHOD.TM_USB)
				{
					return TransferMethodType.Usb;
				}
			}
			return TransferMethodType.None;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000BED0 File Offset: 0x0000A0D0
		private ENUM_TRANSFERMETHOD CastToEnumTransferMethod(TransferMethodType tme)
		{
			if (tme <= TransferMethodType.Image)
			{
				if (tme == TransferMethodType.File)
				{
					return ENUM_TRANSFERMETHOD.TM_FILE;
				}
				if (tme == TransferMethodType.Image)
				{
					return ENUM_TRANSFERMETHOD.TM_LIVE;
				}
			}
			else
			{
				if (tme == TransferMethodType.Network)
				{
					return ENUM_TRANSFERMETHOD.TM_NETWORK;
				}
				if (tme == TransferMethodType.SSL)
				{
					return ENUM_TRANSFERMETHOD.TM_NETWORK;
				}
				if (tme == TransferMethodType.Usb)
				{
					return ENUM_TRANSFERMETHOD.TM_USB;
				}
			}
			return ENUM_TRANSFERMETHOD.TM_NONE;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000BF04 File Offset: 0x0000A104
		public AuthorizationInfo TaskGetAuthorizationInfo(int taskHandle)
		{
			this.VerifyControl("TaskGetAuthorizationInfo");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				this.TraceCallerError(string.Format("Invalid taskHandle {0}", taskHandle), "TaskGetAuthorizationInfo");
				return null;
			}
			AuthorizationRequestData authorizationRequestData = serviceTask.AuthRequest ?? this.AuthRequest;
			AuthorizationInfo authorizationInfo = new AuthorizationInfo();
			authorizationInfo.SerialNumber = authorizationRequestData.SerialNumber;
			ServiceMachine srcServiceMachine = serviceTask.SrcServiceMachine;
			Machine machine = (srcServiceMachine != null) ? srcServiceMachine.PcmMachine : null;
			ServiceMachine dstServiceMachine = serviceTask.DstServiceMachine;
			Machine machine2 = (dstServiceMachine != null) ? dstServiceMachine.PcmMachine : null;
			if (machine != null && machine2 != null)
			{
				string strValidationPrefix = this._enginePolicy.strValidationPrefix;
				if (!string.IsNullOrWhiteSpace(strValidationPrefix))
				{
					uint validationId = machine.ValidationId;
					uint validationId2 = machine2.ValidationId;
					string text = string.Format("{0}{1}{2}", strValidationPrefix, validationId.ToString("D2"), validationId2.ToString("D2"));
					string netName = machine.NetName;
					string netName2 = machine2.NetName;
					uint num = ValidationCode.CalcChecksum(text + netName + netName2);
					authorizationInfo.SessionCode = string.Format("{0}{1}", text, (num % 100U).ToString("D2"));
					authorizationInfo.WebValidatorShortcut = this.EnginePolicy.WebValidatorShortcut;
					if (authorizationInfo.WebValidatorShortcut == "-")
					{
						authorizationInfo.WebValidatorShortcut = string.Empty;
					}
					authorizationInfo.WebValidatorQrCodeUrl = string.Concat(new string[]
					{
						this.EnginePolicy.strValidationServer,
						"/authtransfer.php?prd=PRDMMP1&qr=1&srcname=",
						Uri.EscapeDataString(netName),
						"&dstname=",
						Uri.EscapeDataString(netName2),
						"&code=",
						authorizationInfo.SessionCode,
						"&key=",
						Uri.EscapeDataString(authorizationInfo.SerialNumber),
						"&user=",
						Uri.EscapeDataString(authorizationRequestData.User),
						"&email=",
						Uri.EscapeDataString(authorizationRequestData.Email)
					});
				}
			}
			authorizationInfo.IsAuthorized = serviceTask.Task.IsAuthorized;
			authorizationInfo.IsPreValidated = serviceTask.Task.IsPreValidated;
			if (authorizationInfo.IsAuthorized)
			{
				this.Ts.TraceCaller(string.Format("Task {0} is authorized", taskHandle), "TaskGetAuthorizationInfo");
			}
			else
			{
				this.Ts.TraceCaller(string.Format("Task {0} is not authorized", taskHandle), "TaskGetAuthorizationInfo");
			}
			return authorizationInfo;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000C16C File Offset: 0x0000A36C
		public bool TaskPrepareAuthorization(int taskHandle, AuthorizationRequestData authRequest)
		{
			this.VerifyControl("TaskPrepareAuthorization");
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				this.TraceCallerError(string.Format("Invalid task handle {0}", taskHandle), "TaskPrepareAuthorization");
				return false;
			}
			serviceTask.AuthRequest = authRequest;
			this.Ts.TraceCaller(taskHandle.ToString(), "TaskPrepareAuthorization");
			return true;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000C1CC File Offset: 0x0000A3CC
		public TaskAlertData PolicyGetInteractiveAlert(TaskAlertData.AlertType alertType)
		{
			this.VerifyControl("PolicyGetInteractiveAlert");
			PCmoverApp app = this._app;
			Policy policy = (app != null) ? app.Policy : null;
			if (policy == null)
			{
				this.TraceCallerError("PCmover not initialized", "PolicyGetInteractiveAlert");
				return null;
			}
			if (alertType != TaskAlertData.AlertType.Done)
			{
				this.TraceCallerError(string.Format("Invalid alert type: {0}", alertType), "PolicyGetInteractiveAlert");
				return null;
			}
			ALERT_TYPE type = ALERT_TYPE.AT_DONE;
			AlertPolicy alertPolicy = policy.get_AlertPolicy(type, 0U);
			if (alertPolicy == null)
			{
				return new TaskAlertData();
			}
			if (!alertPolicy.bInteractive)
			{
				return null;
			}
			return new TaskAlertData(alertPolicy.strName, alertPolicy.strEmail, alertPolicy.strMessage, TaskAlertData.AlertType.Done);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000C268 File Offset: 0x0000A468
		public bool TaskPostAlerts(int taskHandle, TaskAlertData.AlertType alertType, TaskAlertData interactiveAlert, string statusMessage)
		{
			PcmoverManager.<>c__DisplayClass299_0 CS$<>8__locals1 = new PcmoverManager.<>c__DisplayClass299_0();
			CS$<>8__locals1.interactiveAlert = interactiveAlert;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.statusMessage = statusMessage;
			this.VerifyControl("TaskPostAlerts");
			PcmoverManager.<>c__DisplayClass299_0 CS$<>8__locals2 = CS$<>8__locals1;
			PCmoverApp app = this._app;
			CS$<>8__locals2.policy = ((app != null) ? app.Policy : null);
			if (CS$<>8__locals1.policy == null)
			{
				this.TraceCallerError("PCmover not initialized", "TaskPostAlerts");
				return false;
			}
			if (alertType != TaskAlertData.AlertType.Done)
			{
				this.TraceCallerError(string.Format("Invalid alert type: {0}", alertType), "TaskPostAlerts");
				return false;
			}
			CS$<>8__locals1.policyAlertType = ALERT_TYPE.AT_DONE;
			if (string.IsNullOrWhiteSpace(CS$<>8__locals1.statusMessage))
			{
				this.TraceCallerError("No status message specified", "TaskPostAlerts");
				return false;
			}
			if (this.GetServiceTask(taskHandle) == null)
			{
				this.TraceCallerError(string.Format("Invalid task handle {0}", taskHandle), "TaskPostAlerts");
				return false;
			}
			CS$<>8__locals1.alertNum = 0U;
			CS$<>8__locals1.policyAlert = CS$<>8__locals1.policy.get_AlertPolicy(CS$<>8__locals1.policyAlertType, 0U);
			if (CS$<>8__locals1.policyAlert != null)
			{
				if (CS$<>8__locals1.policyAlert.bInteractive)
				{
					CS$<>8__locals1.alertNum = 1U;
				}
				else
				{
					TaskAlertData interactiveAlert2 = CS$<>8__locals1.interactiveAlert;
					if (!string.IsNullOrEmpty((interactiveAlert2 != null) ? interactiveAlert2.Email : null))
					{
						this.TraceCallerError("Interactive alerts are disallowed, ignoring alert requested for " + CS$<>8__locals1.interactiveAlert.Email, "TaskPostAlerts");
					}
					CS$<>8__locals1.interactiveAlert = null;
				}
			}
			Task.Run(delegate()
			{
				if (CS$<>8__locals1.interactiveAlert != null)
				{
					CS$<>8__locals1.<>4__this.SendAlert(CS$<>8__locals1.interactiveAlert.User, CS$<>8__locals1.interactiveAlert.Email, CS$<>8__locals1.statusMessage, CS$<>8__locals1.interactiveAlert.Message);
				}
				if (CS$<>8__locals1.policyAlert != null)
				{
					for (;;)
					{
						IPolicy policy = CS$<>8__locals1.policy;
						ALERT_TYPE policyAlertType = CS$<>8__locals1.policyAlertType;
						uint alertNum = CS$<>8__locals1.alertNum;
						CS$<>8__locals1.alertNum = alertNum + 1U;
						CS$<>8__locals1.policyAlert = policy.get_AlertPolicy(policyAlertType, alertNum);
						if (CS$<>8__locals1.policyAlert == null)
						{
							break;
						}
						CS$<>8__locals1.<>4__this.SendAlert(CS$<>8__locals1.policyAlert.strName, CS$<>8__locals1.policyAlert.strEmail, CS$<>8__locals1.statusMessage, CS$<>8__locals1.policyAlert.strMessage);
					}
				}
			});
			this.Ts.TraceCaller("Alerts queued", "TaskPostAlerts");
			return true;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000C3E4 File Offset: 0x0000A5E4
		private void SendAlert(string user, string email, string status, string message)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(message))
				{
					this.TraceCallerError("Name not specified", "SendAlert");
				}
				return;
			}
			if (string.IsNullOrWhiteSpace(email))
			{
				if (!string.IsNullOrEmpty(user) || !string.IsNullOrEmpty(message))
				{
					this.TraceCallerError("Email not specified", "SendAlert");
				}
				return;
			}
			if (this._app.RegistrationServer.EmailAlert("DONE", user, email, status, message ?? string.Empty))
			{
				this.Ts.TraceCaller("Alert sent successfully to " + email, "SendAlert");
				return;
			}
			this.Ts.TraceCaller("Error sending Alert", "SendAlert");
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000C49C File Offset: 0x0000A69C
		public Version GetPcmoverVersion()
		{
			Version result = null;
			try
			{
				if (this.State != PcmoverState.idle && this._app != null)
				{
					ushort major;
					ushort minor;
					ushort build;
					ushort revision;
					this._app.GetVersionVariables(out major, out minor, out build, out revision);
					result = new Version((int)major, (int)minor, (int)build, (int)revision);
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "GetPcmoverVersion");
				result = null;
			}
			return result;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000C504 File Offset: 0x0000A704
		public PcmoverStatusInfo GetPcmoverStatus()
		{
			this.PcmoverCcs.ValidateControlCallback();
			return this.StatusInfo;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000C518 File Offset: 0x0000A718
		public void ConfigureMonitorCallbacks(CallbackState monitorCallbackState)
		{
			this.MonitorCallbackManager.Configure(monitorCallbackState, OperationContext.Current.SessionId, OperationContext.Current.GetCallbackChannel<IPcmoverMonitorCallback>());
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000C53C File Offset: 0x0000A73C
		public IEnumerable<ActivityInfo> GetAllActivityInfo()
		{
			List<ActivityInfo> list = new List<ActivityInfo>();
			this.Activities.CallForEach(delegate(PcmActivity activity)
			{
				list.Add(activity.Info);
			});
			return list;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000C578 File Offset: 0x0000A778
		public ActivityInfo GetActivityInfo(int activityHandle)
		{
			PcmActivity pcmActivity = this.Activities.Get(activityHandle);
			if (pcmActivity == null)
			{
				return null;
			}
			return pcmActivity.Info;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000C5A0 File Offset: 0x0000A7A0
		public ProgressInfo GetActivityProgressInfo(int activityHandle)
		{
			PcmActivity pcmActivity = this.Activities.Get(activityHandle);
			if (pcmActivity == null)
			{
				return null;
			}
			return pcmActivity.Progress;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000C5C8 File Offset: 0x0000A7C8
		public int GetActivityTaskHandle(int activityHandle)
		{
			ITaskActivity taskActivity = this.Activities.Get(activityHandle) as ITaskActivity;
			if (taskActivity == null)
			{
				this.TraceCallerError(string.Format("Invalid activity {0}", activityHandle), "GetActivityTaskHandle");
				return 0;
			}
			ServiceTask activityServiceTask = taskActivity.ActivityServiceTask;
			if (activityServiceTask == null)
			{
				this.TraceCallerError(string.Format("No task available for activity {0}", activityHandle), "GetActivityTaskHandle");
				return 0;
			}
			return activityServiceTask.Handle;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000C634 File Offset: 0x0000A834
		public int GetActivityMachineHandle(int activityHandle)
		{
			IMachineActivity machineActivity = this.Activities.Get(activityHandle) as IMachineActivity;
			if (machineActivity == null)
			{
				this.TraceCallerError(string.Format("Invalid activity {0}", activityHandle), "GetActivityMachineHandle");
				return 0;
			}
			ServiceMachine activityServiceMachine = machineActivity.ActivityServiceMachine;
			if (activityServiceMachine == null)
			{
				this.TraceCallerError("No machine available", "GetActivityMachineHandle");
				return 0;
			}
			return activityServiceMachine.Handle;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000C698 File Offset: 0x0000A898
		public int GetActivityTransferMethodHandle(int activityHandle)
		{
			ITransferMethodActivity transferMethodActivity = this.Activities.Get(activityHandle) as ITransferMethodActivity;
			if (transferMethodActivity == null)
			{
				this.TraceCallerError(string.Format("Invalid activity {0}", activityHandle), "GetActivityTransferMethodHandle");
				return 0;
			}
			ServiceTransferMethod activityServiceTransferMethod = transferMethodActivity.ActivityServiceTransferMethod;
			if (activityServiceTransferMethod == null)
			{
				this.TraceCallerError("No transfer method available", "GetActivityTransferMethodHandle");
				return 0;
			}
			return activityServiceTransferMethod.Handle;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000C6FC File Offset: 0x0000A8FC
		public IEnumerable<int> GetActivityTransferMethodHandles(int activityHandle)
		{
			ITransferMethodsActivity transferMethodsActivity = this.Activities.Get(activityHandle) as ITransferMethodsActivity;
			if (transferMethodsActivity == null)
			{
				this.TraceCallerError(string.Format("Invalid activity {0}", activityHandle), "GetActivityTransferMethodHandles");
				return null;
			}
			IEnumerable<ServiceTransferMethod> activityServiceTransferMethods = transferMethodsActivity.ActivityServiceTransferMethods;
			if (activityServiceTransferMethods == null)
			{
				this.TraceCallerError("No transfer methods available", "GetActivityTransferMethodHandles");
				return null;
			}
			return from tm in activityServiceTransferMethods
			select tm.Handle;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000C77C File Offset: 0x0000A97C
		public AppInventoryStatus GetAppInventoryActivityStatus(int appInventoryActivityHandle)
		{
			AppInventoryActivity appInventoryActivity = this.Activities.Get(appInventoryActivityHandle) as AppInventoryActivity;
			if (appInventoryActivity == null)
			{
				this.TraceCallerError(string.Format("Invalid AppInventory activity handle {0}", appInventoryActivityHandle), "GetAppInventoryActivityStatus");
				return null;
			}
			return new AppInventoryStatus
			{
				Configuration = appInventoryActivity.AmountToDo,
				Completed = appInventoryActivity.AmountCompleted
			};
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000C7D8 File Offset: 0x0000A9D8
		public TransferActivityParameters GetTransferActivityParameters(int transferActivityHandle)
		{
			ITransferParametersActivity transferParametersActivity = this.Activities.Get(transferActivityHandle) as ITransferParametersActivity;
			if (transferParametersActivity == null)
			{
				this.TraceCallerError(string.Format("Invalid activity {0}", transferActivityHandle), "GetTransferActivityParameters");
				return null;
			}
			return new TransferActivityParameters
			{
				TransferMethodHandle = ((transferParametersActivity.ActivityServiceTransferMethod == null) ? 0 : transferParametersActivity.ActivityServiceTransferMethod.Handle),
				FillTaskHandle = ((transferParametersActivity.ActivityFillServiceTask == null) ? 0 : transferParametersActivity.ActivityFillServiceTask.Handle),
				AllowUndo = transferParametersActivity.ActivityAllowUndo
			};
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000C860 File Offset: 0x0000AA60
		public ExpandSnapshotActivityParameters GetExpandSnapshotActivityParameters(int expandSnapshotActivityHandle)
		{
			ExpandSnapshotActivity expandSnapshotActivity = this.Activities.Get(expandSnapshotActivityHandle) as ExpandSnapshotActivity;
			if (expandSnapshotActivity == null)
			{
				this.TraceCallerError(string.Format("Invalid activity {0}", expandSnapshotActivityHandle), "GetExpandSnapshotActivityParameters");
				return null;
			}
			return new ExpandSnapshotActivityParameters
			{
				MachineHandle = expandSnapshotActivity.ActivityServiceMachine.Handle,
				ItemType = expandSnapshotActivity.ItemType,
				RegularUsersOnly = expandSnapshotActivity.RegularUsersOnly,
				ExpandGlobalCategories = expandSnapshotActivity.ExpandGlobalCategories
			};
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000C8DC File Offset: 0x0000AADC
		public IEnumerable<ReportData> GetGenerateReportsActivityData(int generateReportsActivityHandle)
		{
			GenerateReportsActivity generateReportsActivity = this.Activities.Get(generateReportsActivityHandle) as GenerateReportsActivity;
			if (generateReportsActivity == null)
			{
				this.TraceCallerError(string.Format("Invalid activity {0}", generateReportsActivityHandle), "GetGenerateReportsActivityData");
				return null;
			}
			return generateReportsActivity.Reports;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000C921 File Offset: 0x0000AB21
		public TransferSpeeds GetTransferSpeeds(int transferActivityHandle)
		{
			PcmProtocolBase pcmProtocolBase = this.Activities.Get(transferActivityHandle) as PcmProtocolBase;
			if (pcmProtocolBase == null)
			{
				return null;
			}
			return pcmProtocolBase.GetNetSpeeds();
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000C93F File Offset: 0x0000AB3F
		public MachineData GetMachineData(int machineHandle)
		{
			ServiceMachine serviceMachine = this.GetServiceMachine(machineHandle);
			if (serviceMachine == null)
			{
				return null;
			}
			return serviceMachine.Data;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000C954 File Offset: 0x0000AB54
		public IEnumerable<MachineData> GetAllMachineData()
		{
			List<MachineData> list = new List<MachineData>();
			this.ServiceMachines.CallForEach(delegate(ServiceMachine serviceMachine)
			{
				list.Add(serviceMachine.Data);
			});
			return list;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000C990 File Offset: 0x0000AB90
		public AppInventoryAmount? GetMachineAppInventoryAmount(int machineHandle)
		{
			ServiceMachine serviceMachine = this.GetServiceMachine(machineHandle);
			if (serviceMachine == null)
			{
				this.TraceCallerError(string.Format("Invalid machine {0}", machineHandle), "GetMachineAppInventoryAmount");
				return null;
			}
			ENUM_APPSEL_STAGE completedAppSelStage = serviceMachine.PcmMachine.CompletedAppSelStage;
			if (completedAppSelStage.HasFlag(ENUM_APPSEL_STAGE.AS_SCANOTHERS))
			{
				return new AppInventoryAmount?(AppInventoryAmount.OldComputer);
			}
			if (completedAppSelStage.HasFlag(ENUM_APPSEL_STAGE.AS_SCANSHORTCUTS))
			{
				return new AppInventoryAmount?(AppInventoryAmount.NewComputer);
			}
			if (completedAppSelStage.HasFlag(ENUM_APPSEL_STAGE.AS_INIT))
			{
				return new AppInventoryAmount?(AppInventoryAmount.Minimum);
			}
			return new AppInventoryAmount?(AppInventoryAmount.None);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000CA30 File Offset: 0x0000AC30
		public IEnumerable<PcmTaskData> GetAllTaskData()
		{
			List<PcmTaskData> list = new List<PcmTaskData>();
			this.ServiceTasks.CallForEach(delegate(ServiceTask serviceTask)
			{
				list.Add(this.GetTaskData(serviceTask));
			});
			return list;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000CA74 File Offset: 0x0000AC74
		private PcmTaskData GetTaskData(ServiceTask serviceTask)
		{
			ServiceMachine serviceMachine = serviceTask.SrcServiceMachine;
			int sourceMachineHandle = (serviceMachine == null) ? 0 : serviceMachine.Handle;
			serviceMachine = serviceTask.DstServiceMachine;
			int destMachineHandle = (serviceMachine == null) ? 0 : serviceMachine.Handle;
			return new PcmTaskData
			{
				Handle = serviceTask.Handle,
				TaskType = (PcmTaskType)serviceTask.Task.taskType,
				SourceMachineHandle = sourceMachineHandle,
				DestMachineHandle = destMachineHandle,
				IsReady = serviceTask.Task.IsReady
			};
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000CAEC File Offset: 0x0000ACEC
		public PcmTaskData GetTaskData(int taskHandle)
		{
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			if (serviceTask == null)
			{
				this.TraceCallerError(string.Format("Invalid task handle: {0}", taskHandle), "GetTaskData");
				return null;
			}
			return this.GetTaskData(serviceTask);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000CB28 File Offset: 0x0000AD28
		public TransferProcessResult GetTaskTransferResult(int taskHandle)
		{
			ServiceTask serviceTask = this.GetServiceTask(taskHandle);
			IPcmTask pcmTask = (serviceTask != null) ? serviceTask.Task : null;
			if (pcmTask == null)
			{
				this.TraceCallerError(string.Format("Invalid task handle: {0}", taskHandle), "GetTaskTransferResult");
				return TransferProcessResult.InvalidTask;
			}
			return (TransferProcessResult)pcmTask.TransferResult;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000CB70 File Offset: 0x0000AD70
		public TaskSummaryData GetTaskSummaryData(int taskHandle, bool regularUsersOnly)
		{
			TaskSummaryData result;
			try
			{
				ServiceTask serviceTask = this.GetServiceTask(taskHandle);
				if (serviceTask == null)
				{
					this.TraceCallerError(string.Format("Invalid taskHandle {0}", taskHandle), "GetTaskSummaryData");
					result = null;
				}
				else
				{
					IPcmTask task = serviceTask.Task;
					if (!task.IsReady)
					{
						this.TraceCallerError(string.Format("Task {0} is not ready", taskHandle), "GetTaskSummaryData");
						result = null;
					}
					else
					{
						TaskSummaryData taskSummaryData = new TaskSummaryData();
						ushort major;
						ushort minor;
						ushort build;
						ushort revision;
						task.GetVersionVariables(out major, out minor, out build, out revision);
						taskSummaryData.Version = new Version((int)major, (int)minor, (int)build, (int)revision);
						taskSummaryData.StartTime = DateTime.FromOADate(task.StartOADate);
						taskSummaryData.FinishTime = DateTime.FromOADate(task.FinishOADate);
						taskSummaryData.Status = (TransferProcessResult)task.TransferResult;
						ServiceMachine serviceMachine = serviceTask.SrcServiceMachine;
						taskSummaryData.SrcMachine = serviceMachine.Data;
						taskSummaryData.SrcUser = this.CreateUserDetail(serviceMachine.PcmMachine.NetUserMgr.CurrentUser);
						serviceMachine = serviceTask.DstServiceMachine;
						taskSummaryData.DestMachine = serviceMachine.Data;
						taskSummaryData.DestUser = this.CreateUserDetail(serviceMachine.PcmMachine.NetUserMgr.CurrentUser);
						ENUM_TASK_TYPE taskType = task.taskType;
						if (taskType != ENUM_TASK_TYPE.CTASK_FILLVAN)
						{
							if (taskType != ENUM_TASK_TYPE.CTASK_UNLOADVAN)
							{
								taskSummaryData.Action = TaskAction.Unknown;
							}
							else if (task.LstSig == 1282634837U)
							{
								taskSummaryData.Action = TaskAction.Receive;
							}
							else
							{
								taskSummaryData.Action = TaskAction.Undo;
							}
						}
						else
						{
							taskSummaryData.Action = TaskAction.Send;
						}
						taskSummaryData.TransferMethodType = this.CastToTransferMethodEnum(task.TransferMethod);
						UserMappings userMappings = this.GetUserMappings(serviceTask, regularUsersOnly);
						IEnumerable<UserMapping> enumerable = (userMappings != null) ? userMappings.Mappings : null;
						if (enumerable == null)
						{
							taskSummaryData.UsersTransferred = 0U;
							taskSummaryData.UsersCreated = 0U;
						}
						else
						{
							taskSummaryData.UsersTransferred = (uint)enumerable.Count<UserMapping>();
							taskSummaryData.UsersCreated = (uint)(from m in enumerable
							where m.Create
							select m).Count<UserMapping>();
						}
						taskSummaryData.Applications = task.nMigratedApps(false);
						result = taskSummaryData;
					}
				}
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "GetTaskSummaryData");
				result = null;
			}
			return result;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000CD98 File Offset: 0x0000AF98
		private TransferMethodData GetTransferMethodData(ServiceTransferMethod stm)
		{
			if (stm == null)
			{
				return null;
			}
			return new TransferMethodData
			{
				Handle = stm.Handle,
				TransferMethodType = stm.TransferMethodType
			};
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000CDBC File Offset: 0x0000AFBC
		public TransferMethodData GetTransferMethodData(int transferMethodHandle)
		{
			return this.GetTransferMethodData(this.GetServiceTransferMethod(transferMethodHandle));
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000CDCC File Offset: 0x0000AFCC
		public IEnumerable<TransferMethodData> GetAllTransferMethodData()
		{
			List<TransferMethodData> list = new List<TransferMethodData>();
			this.TransferMethods.CallForEach(delegate(ServiceTransferMethod stm)
			{
				list.Add(this.GetTransferMethodData(stm));
			});
			return list;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000CE10 File Offset: 0x0000B010
		public NetworkTransferMethodInfo GetNetworkTransferMethodInfo(int networkTransferMethodHandle)
		{
			ServiceNetworkTransferMethod serviceNetworkTransferMethod = this.GetServiceTransferMethod(networkTransferMethodHandle) as ServiceNetworkTransferMethod;
			if (serviceNetworkTransferMethod == null)
			{
				this.TraceCallerError(string.Format("Invalid network transfer method handle {0}", networkTransferMethodHandle), "GetNetworkTransferMethodInfo");
				return null;
			}
			return new NetworkTransferMethodInfo
			{
				Target = serviceNetworkTransferMethod.NetworkTransferMethod.RemoteMachine,
				bSecure = serviceNetworkTransferMethod.NetworkTransferMethod.bSecure
			};
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000CE74 File Offset: 0x0000B074
		public ImageMapData GetImageTransferMethodInfo(int imageTransferMethodHandle)
		{
			ServiceImageTransferMethod serviceImageTransferMethod = this.GetServiceTransferMethod(imageTransferMethodHandle) as ServiceImageTransferMethod;
			if (serviceImageTransferMethod == null)
			{
				this.TraceCallerError(string.Format("Invalid image transfer method handle {0}", imageTransferMethodHandle), "GetImageTransferMethodInfo");
				return null;
			}
			return serviceImageTransferMethod.ImageMap;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000CEB4 File Offset: 0x0000B0B4
		public WinUpgradeTransferMethodInfo GetWinUpgradeTransferMethodInfo(int winUpgradeTransferMethodHandle)
		{
			ServiceWinUpgradeTransferMethod serviceWinUpgradeTransferMethod = this.GetServiceTransferMethod(winUpgradeTransferMethodHandle) as ServiceWinUpgradeTransferMethod;
			if (serviceWinUpgradeTransferMethod == null)
			{
				this.TraceCallerError(string.Format("Invalid WinUpgrade transfer method handle {0}", winUpgradeTransferMethodHandle), "GetWinUpgradeTransferMethodInfo");
				return null;
			}
			return new WinUpgradeTransferMethodInfo
			{
				WindowsOld = serviceWinUpgradeTransferMethod.WindowsOld
			};
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000CF00 File Offset: 0x0000B100
		public FileTransferMethodInfo GetFileTransferMethodInfo(int fileTransferMethodHandle)
		{
			ServiceFileTransferMethod serviceFileTransferMethod = this.GetServiceTransferMethod(fileTransferMethodHandle) as ServiceFileTransferMethod;
			if (serviceFileTransferMethod == null)
			{
				this.TraceCallerError(string.Format("Invalid file transfer method handle: {0}", fileTransferMethodHandle), "GetFileTransferMethodInfo");
				return null;
			}
			FileTransferMethod fileTransferMethod = serviceFileTransferMethod.FileTransferMethod;
			return new FileTransferMethodInfo
			{
				FileName = fileTransferMethod.FileName,
				AnyMachineName = serviceFileTransferMethod.AnyMachineName,
				CanSpan = fileTransferMethod.Span,
				SpanSize = fileTransferMethod.SpanSize,
				NotifySpan = fileTransferMethod.SpanNotify
			};
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000CF84 File Offset: 0x0000B184
		public NetworkStatsData GetNetworkStats()
		{
			try
			{
				NetworkStats networkStats = default(NetworkStats);
				this._app.GetNetworkStats(out networkStats);
				return new NetworkStatsData
				{
					TotalUDPBytes = networkStats.totalBytes,
					TotalUDPPackets = networkStats.TxPackets + networkStats.RxPackets,
					TotalUDPTries = networkStats.TxTries + networkStats.RxTries,
					TotalUDPErrors = networkStats.TotalRxErrors,
					Ieee80211 = networkStats.ieee80211,
					Hardwired = networkStats.hardwired,
					USBState = (USBState)this._USBState
				};
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "GetNetworkStats");
			}
			return null;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000D038 File Offset: 0x0000B238
		public void NotifyOnDiscoveredMachine(int discoveryActivityHandle, ConnectableMachine machine)
		{
			this.Ts.TraceInformation("NotifyOnDiscoveredMachine: {0} {1} ({2})", new object[]
			{
				machine.Status.ToString(),
				machine.NetName,
				(machine.Method == TransferMethodType.Usb) ? "USB" : "Network"
			});
			if (machine.Status == DiscoveredMachineStatus.UpdateTransferMethodHandle)
			{
				lock (this)
				{
					ConnectableMachine connectableMachine = this._manualMachines.FirstOrDefault((ConnectableMachine left) => left.UniqueId == machine.UniqueId);
					if (connectableMachine != null)
					{
						connectableMachine.TransferMethodHandle = machine.TransferMethodHandle;
					}
				}
			}
			this.PcmoverCcs.CallControlCallback(delegate(IPcmoverControlCallback cb)
			{
				cb.OnDiscoveredMachine(discoveryActivityHandle, machine);
			});
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000D134 File Offset: 0x0000B334
		internal void NotifyOnSetDirection(ConnectableMachine machine)
		{
			this.Ts.TraceInformation("NotifyOnSetDirection: " + machine.NetName);
			this.PcmoverCcs.CallControlCallback(delegate(IPcmoverControlCallback cb)
			{
				cb.OnSetDirection(machine);
			});
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000D188 File Offset: 0x0000B388
		internal ConnectableMachine AddOrUpdateManualMachine(ConnectableMachine machine)
		{
			if (string.IsNullOrWhiteSpace(machine.DisplayName))
			{
				machine.DisplayName = machine.FriendlyName;
			}
			ConnectableMachine result;
			lock (this)
			{
				int num = this._manualMachines.FindIndex((ConnectableMachine left) => left.UniqueId == machine.UniqueId);
				if (num < 0)
				{
					this._manualMachines.Add(machine);
					result = machine;
				}
				else
				{
					if (this._manualMachines[num].Status == DiscoveredMachineStatus.RemoteManualConnection)
					{
						this._manualMachines[num] = machine;
					}
					else
					{
						this._manualMachines[num].IsOld = machine.IsOld;
					}
					result = this._manualMachines[num];
				}
			}
			return result;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000D280 File Offset: 0x0000B480
		public void NotifyUSBStateChanged(USB_STATE newState)
		{
			this._USBState = newState;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0000D28C File Offset: 0x0000B48C
		private Task<int> CallUiControlCallbackAsync(Action<int> func, int defaultResult)
		{
			PcmoverManager.<CallUiControlCallbackAsync>d__336 <CallUiControlCallbackAsync>d__;
			<CallUiControlCallbackAsync>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<CallUiControlCallbackAsync>d__.<>4__this = this;
			<CallUiControlCallbackAsync>d__.func = func;
			<CallUiControlCallbackAsync>d__.defaultResult = defaultResult;
			<CallUiControlCallbackAsync>d__.<>1__state = -1;
			<CallUiControlCallbackAsync>d__.<>t__builder.Start<PcmoverManager.<CallUiControlCallbackAsync>d__336>(ref <CallUiControlCallbackAsync>d__);
			return <CallUiControlCallbackAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0000D2E0 File Offset: 0x0000B4E0
		public int CallUiControlCallback(Action<int> func, int defaultResult = 0, [CallerMemberName] string caller = "")
		{
			this.Ts.TraceCaller(caller, "CallUiControlCallback");
			int result = this.CallUiControlCallbackAsync(func, defaultResult).Result;
			this.Ts.TraceCaller(string.Format("{0} result: {1}", caller, result), "CallUiControlCallback");
			return result;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000D330 File Offset: 0x0000B530
		public int DisplayMessageBox(string msg, uint nType, uint nIDHelp, int nDefault)
		{
			this.Ts.TraceCaller(msg, "DisplayMessageBox");
			return this.CallUiControlCallback(delegate(int replyHandle)
			{
				this.ControlCallback.UiMessageBox(replyHandle, msg, nType, nIDHelp, nDefault);
			}, nDefault, "DisplayMessageBox");
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000D39A File Offset: 0x0000B59A
		public int DisplayUiccMessage(UI_CALLBACK_CODE code, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			return this.DisplayUiccMessage((UiCallbackCode)code, msg, nType, nIDHelp, nDefault);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000D3AC File Offset: 0x0000B5AC
		internal int DisplayUiccMessage(UiCallbackCode code, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			this.Ts.TraceCaller(msg, "DisplayUiccMessage");
			return this.CallUiControlCallback(delegate(int replyHandle)
			{
				this.ControlCallback.UiDisplayUiccMessage(replyHandle, code, msg, nType, nIDHelp, nDefault);
			}, nDefault, "DisplayUiccMessage");
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000D41E File Offset: 0x0000B61E
		public int DisplayUiccMessage1Param(UI_CALLBACK_CODE code, string param, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			return this.DisplayUiccMessage1Param((UiCallbackCode)code, param, msg, nType, nIDHelp, nDefault);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000D430 File Offset: 0x0000B630
		internal int DisplayUiccMessage1Param(UiCallbackCode code, string param, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			this.Ts.TraceCaller(msg, "DisplayUiccMessage1Param");
			return this.CallUiControlCallback(delegate(int replyHandle)
			{
				this.ControlCallback.UiDisplayUiccMessage1Param(replyHandle, code, param, msg, nType, nIDHelp, nDefault);
			}, nDefault, "DisplayUiccMessage1Param");
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0000D4AC File Offset: 0x0000B6AC
		public int DisplayUiccMessageAndUrl(UI_CALLBACK_CODE code, string url, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			this.Ts.TraceCaller(msg, "DisplayUiccMessageAndUrl");
			return this.CallUiControlCallback(delegate(int replyHandle)
			{
				this.ControlCallback.UiDisplayUiccMessageAndUrl(replyHandle, (UiCallbackCode)code, url, msg, nType, nIDHelp, nDefault);
			}, nDefault, "DisplayUiccMessageAndUrl");
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000D528 File Offset: 0x0000B728
		public void DisplayWrongEditionError(ulong taskId, uint otherEdition, uint thisEdition, string msg)
		{
			PcmActivity activity = this.FindTransferActivity(taskId);
			if (activity == null)
			{
				this.Ts.TraceInformation("Cannot find transfer activity in DisplayWrongEditionError");
				return;
			}
			int transferTaskHandle = 0;
			ITaskActivity taskActivity = activity as ITaskActivity;
			if (taskActivity != null)
			{
				ServiceTask activityServiceTask = taskActivity.ActivityServiceTask;
				if (activityServiceTask != null)
				{
					transferTaskHandle = activityServiceTask.Handle;
				}
			}
			this.Ts.TraceCaller(msg, "DisplayWrongEditionError");
			this.CallUiControlCallback(delegate(int replyHandle)
			{
				this.ControlCallback.UiDisplayWrongEditionError(replyHandle, activity.Info, transferTaskHandle, (PcmoverEdition)otherEdition, (PcmoverEdition)thisEdition, msg);
			}, 0, "DisplayWrongEditionError");
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0000D5DC File Offset: 0x0000B7DC
		public void DisplaySaveLoadException(UI_EXCEPTION_TYPE uxt, int cause, int errorCode, string strFileName, bool bSaving, bool bNetwork, string strFormattedMessage)
		{
			this.Ts.TraceCaller(strFormattedMessage, "DisplaySaveLoadException");
			this.CallUiControlCallback(delegate(int replyHandle)
			{
				this.ControlCallback.UiDisplaySaveLoadException(replyHandle, (UiExceptionType)uxt, cause, errorCode, strFileName, bSaving, bNetwork, strFormattedMessage);
			}, 0, "DisplaySaveLoadException");
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000D65C File Offset: 0x0000B85C
		public bool DisplaySpanNotification(UI_CALLBACK_CODE code, string fileName, string msg, bool showCheckbox, out bool dontNotify)
		{
			this.Ts.TraceCaller(msg, "DisplaySpanNotification");
			int num = this.CallUiControlCallback(delegate(int replyHandle)
			{
				this.ControlCallback.UiDisplaySpanNotification(replyHandle, (UiCallbackCode)code, fileName, msg, showCheckbox);
			}, 0, "DisplaySpanNotification");
			dontNotify = ((num & 2) == 0);
			return (num & 1) != 0;
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0000D6D4 File Offset: 0x0000B8D4
		public bool ImpersonateUser()
		{
			WindowsIdentity userIdentity = this.UserIdentity;
			if (userIdentity == null)
			{
				return false;
			}
			if (this._threadImpersonationContext.Value != null)
			{
				this.Ts.TraceVerbose("Already impersonated");
				return false;
			}
			try
			{
				this._threadImpersonationContext.Value = userIdentity.Impersonate();
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "ImpersonateUser");
				return false;
			}
			return true;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0000D74C File Offset: 0x0000B94C
		public void StopImpersonating()
		{
			if (this._threadImpersonationContext.Value != null)
			{
				this._threadImpersonationContext.Value.Dispose();
				this._threadImpersonationContext.Value = null;
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0000D778 File Offset: 0x0000B978
		public bool PromptForVanPassword(ulong taskId)
		{
			PcmActivity activity = this.FindTransferActivity(taskId);
			if (activity == null)
			{
				this.Ts.TraceInformation("Cannot find transfer activity in PromptForVanPassword");
				return false;
			}
			int transferTaskHandle = 0;
			ITaskActivity taskActivity = activity as ITaskActivity;
			if (taskActivity != null)
			{
				ServiceTask activityServiceTask = taskActivity.ActivityServiceTask;
				if (activityServiceTask != null)
				{
					transferTaskHandle = activityServiceTask.Handle;
				}
			}
			this.Ts.TraceCaller(null, "PromptForVanPassword");
			return this.CallUiControlCallback(delegate(int replyHandle)
			{
				this.ControlCallback.UiPromptForVanPassword(replyHandle, activity.Info, transferTaskHandle);
			}, 0, "PromptForVanPassword") != 0;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000D814 File Offset: 0x0000BA14
		public bool PromptForProxyAuth(string proxy)
		{
			if (string.IsNullOrWhiteSpace(proxy))
			{
				this.TraceCallerError("Empty proxy in PromptForProxyAuth", "PromptForProxyAuth");
				return false;
			}
			this.Ts.TraceCaller(null, "PromptForProxyAuth");
			return this.CallUiControlCallback(delegate(int replyHandle)
			{
				this.ControlCallback.UiPromptForProxyAuth(replyHandle, proxy);
			}, 0, "PromptForProxyAuth") != 0;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000D880 File Offset: 0x0000BA80
		public bool IsTransferValidationCode(string tvc)
		{
			return ValidationCodeTransfer.LooksLikeCode(tvc);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000D888 File Offset: 0x0000BA88
		public uint GetTransferId(string tvc, string editionString, string srcNetName, uint srcId, string dstNetName, uint dstId)
		{
			return new ValidationCodeTransfer(editionString, srcNetName, srcId, dstNetName, dstId)
			{
				ValidationCode = tvc
			}.TransferId;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000D8A3 File Offset: 0x0000BAA3
		public string GetTransferValidationCode(uint transferId, string editionString, string srcNetName, uint srcId, string dstNetName, uint dstId)
		{
			return new ValidationCodeTransfer(editionString, srcNetName, srcId, dstNetName, dstId)
			{
				TransferId = transferId
			}.ValidationCode;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000D8C0 File Offset: 0x0000BAC0
		public bool OpenAppProfileDatabase(string fullName)
		{
			object appProfileDatabaseLock = this._appProfileDatabaseLock;
			bool result;
			lock (appProfileDatabaseLock)
			{
				if (this._appProfileDatabase != null)
				{
					this._appProfileDatabaseRefCnt++;
					result = true;
				}
				else
				{
					AppProfileZipFile appProfileZipFile = new AppProfileZipFile();
					try
					{
						if (appProfileZipFile.Open(fullName))
						{
							this._appProfileDatabase = appProfileZipFile;
							this._appProfileDatabaseRefCnt = 1;
							return true;
						}
					}
					catch
					{
					}
					appProfileZipFile.Dispose();
					result = false;
				}
			}
			return result;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000D950 File Offset: 0x0000BB50
		public byte[] LookupAppProfileFile(string folderName, string fileName)
		{
			if (this._appProfileDatabase == null)
			{
				return null;
			}
			return this._appProfileDatabase.GetFile(folderName, fileName);
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000D96C File Offset: 0x0000BB6C
		public string GetAppProfileFileList(string folderName)
		{
			if (this._appProfileDatabase == null)
			{
				return null;
			}
			IEnumerable<string> fileList = this._appProfileDatabase.GetFileList(folderName);
			if (fileList == null)
			{
				return null;
			}
			return string.Join(";", fileList);
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000D9A0 File Offset: 0x0000BBA0
		public void CloseAppProfileDatabase()
		{
			object appProfileDatabaseLock = this._appProfileDatabaseLock;
			lock (appProfileDatabaseLock)
			{
				if (this._appProfileDatabase != null)
				{
					int num = this._appProfileDatabaseRefCnt - 1;
					this._appProfileDatabaseRefCnt = num;
					if (num <= 0)
					{
						this._appProfileDatabase.Close();
						this._appProfileDatabase = null;
						this._appProfileDatabaseRefCnt = 0;
					}
				}
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000DA10 File Offset: 0x0000BC10
		private void CallMonitorCallbacks(Action<IPcmoverMonitorCallback> func, bool isProgress = false)
		{
			this._monitorCallbackManager.Call(func, isProgress);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000DA20 File Offset: 0x0000BC20
		public void NotifyStatusInfoChanged()
		{
			PcmoverStatusInfo statusInfo = this.StatusInfo;
			this.Ts.TraceCaller(statusInfo.ToString(), "NotifyStatusInfoChanged");
			this.CallMonitorCallbacks(delegate(IPcmoverMonitorCallback cb)
			{
				cb.PcmoverStatusChanged(statusInfo);
			}, false);
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000DA70 File Offset: 0x0000BC70
		public void NotifyActivityChanged(PcmActivity activity, MonitorChangeType change)
		{
			ActivityInfo info = (activity != null) ? activity.Info : null;
			if (info == null || info.Handle == 0)
			{
				return;
			}
			this.Ts.TraceCaller(string.Format("{0} {1}", change, info), "NotifyActivityChanged");
			this.CallMonitorCallbacks(delegate(IPcmoverMonitorCallback cb)
			{
				cb.ActivityChanged(info, change);
			}, false);
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000DAF0 File Offset: 0x0000BCF0
		public void ProgressChanged(PcmActivity activity, ProgressInfo progressInfo)
		{
			ActivityInfo info = (activity != null) ? activity.Info : null;
			if (info == null || info.Handle == 0)
			{
				return;
			}
			this.Ts.TraceCaller(TraceEventType.Verbose, string.Format("{0} {1}", info.Handle, progressInfo), "ProgressChanged");
			this.CallMonitorCallbacks(delegate(IPcmoverMonitorCallback cb)
			{
				cb.ActivityProgress(info, progressInfo);
			}, true);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000DB78 File Offset: 0x0000BD78
		internal void NotifyMachineChanged(ServiceMachine serviceMachine, MonitorChangeType change)
		{
			MachineData data = (serviceMachine != null) ? serviceMachine.Data : null;
			if (data == null)
			{
				return;
			}
			this.CallMonitorCallbacks(delegate(IPcmoverMonitorCallback cb)
			{
				cb.MachineChanged(data, change);
			}, false);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000DBC0 File Offset: 0x0000BDC0
		internal void NotifyServiceTransferMethodChanged(ServiceTransferMethod stm, MonitorChangeType change)
		{
			if (stm == null)
			{
				return;
			}
			TransferMethodData tmd = new TransferMethodData
			{
				Handle = stm.Handle,
				TransferMethodType = stm.TransferMethodType
			};
			this.CallMonitorCallbacks(delegate(IPcmoverMonitorCallback cb)
			{
				cb.TransferMethodChanged(tmd, change);
			}, false);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000DC14 File Offset: 0x0000BE14
		internal void NotifyTaskChanged(ServiceTask serviceTask, MonitorChangeType change)
		{
			if (serviceTask == null)
			{
				return;
			}
			PcmTaskData taskData = this.GetTaskData(serviceTask);
			this.CallMonitorCallbacks(delegate(IPcmoverMonitorCallback cb)
			{
				cb.TaskChanged(taskData, change);
			}, false);
		}

		// Token: 0x04000041 RID: 65
		private PcmoverState _state;

		// Token: 0x04000042 RID: 66
		private EnginePolicy _enginePolicy;

		// Token: 0x04000043 RID: 67
		private ServiceMachine _thisServiceMachine;

		// Token: 0x04000046 RID: 70
		private MonitorCallbackManager<IPcmoverMonitorCallback> _monitorCallbackManager;

		// Token: 0x0400004B RID: 75
		private LlTraceSource _ts;

		// Token: 0x0400004C RID: 76
		private WindowsIdentity _invokerIdentity;

		// Token: 0x0400004E RID: 78
		private readonly ThreadLocal<WindowsImpersonationContext> _threadImpersonationContext = new ThreadLocal<WindowsImpersonationContext>();

		// Token: 0x0400004F RID: 79
		private RegFreeCOMObject _pcmComContext;

		// Token: 0x04000050 RID: 80
		private RegFreeCOMObject _certificateContext;

		// Token: 0x04000051 RID: 81
		internal PCmoverApp _app;

		// Token: 0x04000052 RID: 82
		private ConnectionPolicy _connectionPolicy;

		// Token: 0x04000053 RID: 83
		private readonly object _appProfileDatabaseLock = new object();

		// Token: 0x04000054 RID: 84
		private AppProfileZipFile _appProfileDatabase;

		// Token: 0x04000055 RID: 85
		private int _appProfileDatabaseRefCnt;

		// Token: 0x04000056 RID: 86
		internal object _registrationLock = new object();

		// Token: 0x04000057 RID: 87
		private readonly ServiceMachineHandleManager ServiceMachines = new ServiceMachineHandleManager(10001);

		// Token: 0x04000058 RID: 88
		internal ServiceTaskHandleManager ServiceTasks;

		// Token: 0x04000059 RID: 89
		private readonly HandleManager<ServiceTransferMethod> TransferMethods = new HandleManager<ServiceTransferMethod>(30001, null);

		// Token: 0x0400005A RID: 90
		private readonly HandleManager<PcmActivity> Activities = new HandleManager<PcmActivity>(40001, null);

		// Token: 0x0400005C RID: 92
		private AppUpdateInfo _appUpdateInfo;

		// Token: 0x0400005D RID: 93
		private AppUpdateData _appUpdateData;

		// Token: 0x0400005E RID: 94
		private USB_STATE _USBState;

		// Token: 0x0400005F RID: 95
		private List<ConnectableMachine> _manualMachines = new List<ConnectableMachine>();

		// Token: 0x04000060 RID: 96
		private string _language = "ENG";

		// Token: 0x04000061 RID: 97
		private string _country = "US";

		// Token: 0x04000062 RID: 98
		private SuspendSleep _suspendSleep;

		// Token: 0x04000063 RID: 99
		private string m_proxy;

		// Token: 0x04000064 RID: 100
		private string m_proxyUsername;

		// Token: 0x04000065 RID: 101
		private string m_proxyPassword;

		// Token: 0x04000066 RID: 102
		private string _policy;

		// Token: 0x04000067 RID: 103
		private PcmoverServiceHost _serviceHost;

		// Token: 0x04000068 RID: 104
		private InitPcmoverData _initPcmoverData;

		// Token: 0x04000069 RID: 105
		private bool _waitingForReboot;

		// Token: 0x0400006A RID: 106
		private bool _needCertificate;

		// Token: 0x0400006B RID: 107
		private object _certLock = new object();

		// Token: 0x0400006C RID: 108
		private string _certSn;

		// Token: 0x0400006D RID: 109
		private string _certEmail;
	}
}
