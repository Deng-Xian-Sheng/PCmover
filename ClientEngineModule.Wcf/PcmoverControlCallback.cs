using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Pcmover.Proxies;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Events;

namespace ClientEngineModule.Wcf
{
	// Token: 0x02000009 RID: 9
	[CallbackBehavior(IncludeExceptionDetailInFaults = true, UseSynchronizationContext = false, ValidateMustUnderstand = true, ConcurrencyMode = ConcurrencyMode.Reentrant)]
	public class PcmoverControlCallback : PcmoverMonitorCallback, IPcmoverControlCallback, IPcmoverMonitorCallback
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000023 RID: 35 RVA: 0x000026E0 File Offset: 0x000008E0
		private IPcmoverControl ControlInterface
		{
			get
			{
				return base.Engine.ControlInterface;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000024 RID: 36 RVA: 0x000026ED File Offset: 0x000008ED
		private IEventAggregator EventAggregator
		{
			get
			{
				return base.Engine.EventAggregator;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000025 RID: 37 RVA: 0x000026FA File Offset: 0x000008FA
		private IUnityContainer Container
		{
			get
			{
				return base.Engine.Container;
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002707 File Offset: 0x00000907
		public PcmoverControlCallback(PCmoverEngineLive engine) : base(engine)
		{
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000271C File Offset: 0x0000091C
		public void OnDiscoveredMachine(int discoveryActivityHandle, ConnectableMachine machine)
		{
			try
			{
				this.EventAggregator.GetEvent<EngineEvents.ConnectableMachineStatusEvent>().Publish(machine);
			}
			catch (Exception ex)
			{
				base.Engine.Ts.TraceException(ex, "OnDiscoveredMachine");
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002768 File Offset: 0x00000968
		public void OnSetDirection(ConnectableMachine machine)
		{
			try
			{
				this.EventAggregator.GetEvent<EngineEvents.SetDirectionEvent>().Publish(machine);
			}
			catch (Exception ex)
			{
				base.Engine.Ts.TraceException(ex, "OnSetDirection");
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000027B4 File Offset: 0x000009B4
		private Task<int> DisplayMessageBoxAsync(string msg, uint nType, uint nIDHelp, int nDefault)
		{
			PcmoverControlCallback.<DisplayMessageBoxAsync>d__9 <DisplayMessageBoxAsync>d__;
			<DisplayMessageBoxAsync>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<DisplayMessageBoxAsync>d__.<>4__this = this;
			<DisplayMessageBoxAsync>d__.msg = msg;
			<DisplayMessageBoxAsync>d__.nType = nType;
			<DisplayMessageBoxAsync>d__.nIDHelp = nIDHelp;
			<DisplayMessageBoxAsync>d__.nDefault = nDefault;
			<DisplayMessageBoxAsync>d__.<>1__state = -1;
			<DisplayMessageBoxAsync>d__.<>t__builder.Start<PcmoverControlCallback.<DisplayMessageBoxAsync>d__9>(ref <DisplayMessageBoxAsync>d__);
			return <DisplayMessageBoxAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002818 File Offset: 0x00000A18
		private void SendCallbackReply(int replyHandle, int result)
		{
			base.Engine.CatchCommEx(delegate
			{
				this.Engine.ControlInterface.SendCallbackReply(replyHandle, result);
			}, "SendCallbackReply");
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002860 File Offset: 0x00000A60
		public void UiMessageBox(int replyHandle, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			PcmoverControlCallback.<>c__DisplayClass11_0 CS$<>8__locals1 = new PcmoverControlCallback.<>c__DisplayClass11_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.msg = msg;
			CS$<>8__locals1.nType = nType;
			CS$<>8__locals1.nIDHelp = nIDHelp;
			CS$<>8__locals1.nDefault = nDefault;
			CS$<>8__locals1.replyHandle = replyHandle;
			Task.Run(delegate()
			{
				PcmoverControlCallback.<>c__DisplayClass11_0.<<UiMessageBox>b__0>d <<UiMessageBox>b__0>d;
				<<UiMessageBox>b__0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<UiMessageBox>b__0>d.<>4__this = CS$<>8__locals1;
				<<UiMessageBox>b__0>d.<>1__state = -1;
				<<UiMessageBox>b__0>d.<>t__builder.Start<PcmoverControlCallback.<>c__DisplayClass11_0.<<UiMessageBox>b__0>d>(ref <<UiMessageBox>b__0>d);
				return <<UiMessageBox>b__0>d.<>t__builder.Task;
			});
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000028B0 File Offset: 0x00000AB0
		public void UiDisplayUiccMessage(int replyHandle, UiCallbackCode code, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			string resourceString = base.Engine.GetResourceString(code.ToString());
			if (!string.IsNullOrEmpty(resourceString))
			{
				msg = resourceString;
			}
			this.UiMessageBox(replyHandle, msg, nType, nIDHelp, nDefault);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000028EF File Offset: 0x00000AEF
		public void UiDisplayUiccMessage1Param(int replyHandle, UiCallbackCode code, string param, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			this.UiMessageBox(replyHandle, base.Engine.LookupMessage(code, param, msg), nType, nIDHelp, nDefault);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002910 File Offset: 0x00000B10
		public void UiDisplayUiccMessageAndUrl(int replyHandle, UiCallbackCode code, string url, string msg, uint nType, uint nIDHelp, int nDefault)
		{
			PcmoverControlCallback.<>c__DisplayClass14_0 CS$<>8__locals1 = new PcmoverControlCallback.<>c__DisplayClass14_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.msg = msg;
			CS$<>8__locals1.nType = nType;
			CS$<>8__locals1.nIDHelp = nIDHelp;
			CS$<>8__locals1.nDefault = nDefault;
			CS$<>8__locals1.url = url;
			CS$<>8__locals1.replyHandle = replyHandle;
			Task.Run(delegate()
			{
				PcmoverControlCallback.<>c__DisplayClass14_0.<<UiDisplayUiccMessageAndUrl>b__0>d <<UiDisplayUiccMessageAndUrl>b__0>d;
				<<UiDisplayUiccMessageAndUrl>b__0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<UiDisplayUiccMessageAndUrl>b__0>d.<>4__this = CS$<>8__locals1;
				<<UiDisplayUiccMessageAndUrl>b__0>d.<>1__state = -1;
				<<UiDisplayUiccMessageAndUrl>b__0>d.<>t__builder.Start<PcmoverControlCallback.<>c__DisplayClass14_0.<<UiDisplayUiccMessageAndUrl>b__0>d>(ref <<UiDisplayUiccMessageAndUrl>b__0>d);
				return <<UiDisplayUiccMessageAndUrl>b__0>d.<>t__builder.Task;
			});
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002968 File Offset: 0x00000B68
		public void UiDisplaySaveLoadException(int replyHandle, UiExceptionType uxt, int cause, int errorCode, string strFileName, bool bSaving, bool bNetwork, string msg)
		{
			this.UiMessageBox(replyHandle, msg, 48U, 0U, 0);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002977 File Offset: 0x00000B77
		public void UiDisplayWrongEditionError(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, PcmoverEdition otherEdition, PcmoverEdition myEdition, string msg)
		{
			this.UiMessageBox(replyHandle, msg, 0U, 0U, 0);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002988 File Offset: 0x00000B88
		public void UiAssignMissingPassword(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, UserDetail detail)
		{
			base.Engine._customizeTaskHandle = transferTaskHandle;
			Events.MissingPasswordEventArgs payload = new Events.MissingPasswordEventArgs
			{
				ResumeAction = new Action(this.ResumeCallbackThread),
				User = detail
			};
			this.EventAggregator.GetEvent<EngineEvents.AssignMissingPassword>().Publish(payload);
			Task.Run(delegate()
			{
				this._CallbackResetEvent.WaitOne();
				this.SendCallbackReply(replyHandle, 1);
			});
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000029F8 File Offset: 0x00000BF8
		public void UiPromptForProxyAuth(int replyHandle, string proxy)
		{
			EngineEvents.ProxyCredentialsData payload = new EngineEvents.ProxyCredentialsData
			{
				ReplyHandle = replyHandle,
				ProxyServer = proxy
			};
			this.EventAggregator.GetEvent<EngineEvents.ShowProxyCredentialsPopupEvent>().Publish(payload);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002A2A File Offset: 0x00000C2A
		public void UiConfirmUserMatches(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, bool bShowUsersOnly)
		{
			Action <>9__1;
			Task.Run(delegate()
			{
				PcmoverClientEngine<PcmoverControlClient> engine = this.Engine;
				Action func;
				if ((func = <>9__1) == null)
				{
					func = (<>9__1 = delegate()
					{
						this.Engine._customizeTaskHandle = transferTaskHandle;
						this.Engine.RetrieveUsers();
						Action payload = new Action(this.ResumeCallbackThread);
						this.Engine.EventAggregator.GetEvent<EngineEvents.ConfirmUserMatches>().Publish(payload);
						this._CallbackResetEvent.WaitOne();
						this.SendCallbackReply(replyHandle, 1);
					});
				}
				engine.CatchCommEx(func, "UiConfirmUserMatches");
			});
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002A57 File Offset: 0x00000C57
		public void UiDisplayDriveMap(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle)
		{
			Action <>9__1;
			Task.Run(delegate()
			{
				PcmoverClientEngine<PcmoverControlClient> engine = this.Engine;
				Action func;
				if ((func = <>9__1) == null)
				{
					func = (<>9__1 = delegate()
					{
						this.Engine._customizeTaskHandle = transferTaskHandle;
						this.Engine.RetrieveDrives();
						Action payload = new Action(this.ResumeCallbackThread);
						this.EventAggregator.GetEvent<EngineEvents.DisplayDriveMap>().Publish(payload);
						this._CallbackResetEvent.WaitOne();
						this.SendCallbackReply(replyHandle, 1);
					});
				}
				engine.CatchCommEx(func, "UiDisplayDriveMap");
			});
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002A84 File Offset: 0x00000C84
		public void UiDisplayAppSelection(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle)
		{
			PcmoverControlCallback.<>c__DisplayClass21_0 CS$<>8__locals1 = new PcmoverControlCallback.<>c__DisplayClass21_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.transferTaskHandle = transferTaskHandle;
			CS$<>8__locals1.replyHandle = replyHandle;
			Task.Run(delegate()
			{
				PcmoverClientEngine<PcmoverControlClient> engine = CS$<>8__locals1.<>4__this.Engine;
				Func<Task> func;
				if ((func = CS$<>8__locals1.<>9__1) == null)
				{
					func = (CS$<>8__locals1.<>9__1 = delegate()
					{
						PcmoverControlCallback.<>c__DisplayClass21_0.<<UiDisplayAppSelection>b__1>d <<UiDisplayAppSelection>b__1>d;
						<<UiDisplayAppSelection>b__1>d.<>t__builder = AsyncTaskMethodBuilder.Create();
						<<UiDisplayAppSelection>b__1>d.<>4__this = CS$<>8__locals1;
						<<UiDisplayAppSelection>b__1>d.<>1__state = -1;
						<<UiDisplayAppSelection>b__1>d.<>t__builder.Start<PcmoverControlCallback.<>c__DisplayClass21_0.<<UiDisplayAppSelection>b__1>d>(ref <<UiDisplayAppSelection>b__1>d);
						return <<UiDisplayAppSelection>b__1>d.<>t__builder.Task;
					});
				}
				engine.CatchCommExAsync(func, "UiDisplayAppSelection");
			});
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002AB1 File Offset: 0x00000CB1
		public void UiEarlierVersion(int replyHandle, ActivityInfo activityInfo, WindowsVersionData srcWindowsVersion, WindowsVersionData destWindowsVersion)
		{
			PcmoverControlCallback.<>c__DisplayClass22_0 CS$<>8__locals1 = new PcmoverControlCallback.<>c__DisplayClass22_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.srcWindowsVersion = srcWindowsVersion;
			CS$<>8__locals1.destWindowsVersion = destWindowsVersion;
			CS$<>8__locals1.replyHandle = replyHandle;
			Task.Run(delegate()
			{
				PcmoverControlCallback.<>c__DisplayClass22_0.<<UiEarlierVersion>b__0>d <<UiEarlierVersion>b__0>d;
				<<UiEarlierVersion>b__0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<UiEarlierVersion>b__0>d.<>4__this = CS$<>8__locals1;
				<<UiEarlierVersion>b__0>d.<>1__state = -1;
				<<UiEarlierVersion>b__0>d.<>t__builder.Start<PcmoverControlCallback.<>c__DisplayClass22_0.<<UiEarlierVersion>b__0>d>(ref <<UiEarlierVersion>b__0>d);
				return <<UiEarlierVersion>b__0>d.<>t__builder.Task;
			});
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002AE6 File Offset: 0x00000CE6
		public void UiWrongMachine(int replyHandle, ActivityInfo activityInfo, string loadedMachineNetName)
		{
			PcmoverControlCallback.<>c__DisplayClass23_0 CS$<>8__locals1 = new PcmoverControlCallback.<>c__DisplayClass23_0();
			CS$<>8__locals1.activityInfo = activityInfo;
			CS$<>8__locals1.loadedMachineNetName = loadedMachineNetName;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.replyHandle = replyHandle;
			Task.Run(delegate()
			{
				PcmoverControlCallback.<>c__DisplayClass23_0.<<UiWrongMachine>b__0>d <<UiWrongMachine>b__0>d;
				<<UiWrongMachine>b__0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<UiWrongMachine>b__0>d.<>4__this = CS$<>8__locals1;
				<<UiWrongMachine>b__0>d.<>1__state = -1;
				<<UiWrongMachine>b__0>d.<>t__builder.Start<PcmoverControlCallback.<>c__DisplayClass23_0.<<UiWrongMachine>b__0>d>(ref <<UiWrongMachine>b__0>d);
				return <<UiWrongMachine>b__0>d.<>t__builder.Task;
			});
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002B1A File Offset: 0x00000D1A
		public void UiCheckDiskSpace(int replyHandle, ActivityInfo activityInfo, List<DriveSpaceRequired> requiredList)
		{
			PcmoverControlCallback.<>c__DisplayClass24_0 CS$<>8__locals1 = new PcmoverControlCallback.<>c__DisplayClass24_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.requiredList = requiredList;
			CS$<>8__locals1.replyHandle = replyHandle;
			Task.Run(delegate()
			{
				PcmoverControlCallback.<>c__DisplayClass24_0.<<UiCheckDiskSpace>b__0>d <<UiCheckDiskSpace>b__0>d;
				<<UiCheckDiskSpace>b__0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<UiCheckDiskSpace>b__0>d.<>4__this = CS$<>8__locals1;
				<<UiCheckDiskSpace>b__0>d.<>1__state = -1;
				<<UiCheckDiskSpace>b__0>d.<>t__builder.Start<PcmoverControlCallback.<>c__DisplayClass24_0.<<UiCheckDiskSpace>b__0>d>(ref <<UiCheckDiskSpace>b__0>d);
				return <<UiCheckDiskSpace>b__0>d.<>t__builder.Task;
			});
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002B47 File Offset: 0x00000D47
		public void UiDisplaySpanNotification(int replyHandle, UiCallbackCode code, string fileName, string msg, bool showCheckbox)
		{
			PcmoverControlCallback.<>c__DisplayClass25_0 CS$<>8__locals1 = new PcmoverControlCallback.<>c__DisplayClass25_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.code = code;
			CS$<>8__locals1.msg = msg;
			CS$<>8__locals1.fileName = fileName;
			CS$<>8__locals1.replyHandle = replyHandle;
			Task.Run(delegate()
			{
				PcmoverControlCallback.<>c__DisplayClass25_0.<<UiDisplaySpanNotification>b__0>d <<UiDisplaySpanNotification>b__0>d;
				<<UiDisplaySpanNotification>b__0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<UiDisplaySpanNotification>b__0>d.<>4__this = CS$<>8__locals1;
				<<UiDisplaySpanNotification>b__0>d.<>1__state = -1;
				<<UiDisplaySpanNotification>b__0>d.<>t__builder.Start<PcmoverControlCallback.<>c__DisplayClass25_0.<<UiDisplaySpanNotification>b__0>d>(ref <<UiDisplaySpanNotification>b__0>d);
				return <<UiDisplaySpanNotification>b__0>d.<>t__builder.Task;
			});
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002B84 File Offset: 0x00000D84
		private bool DisplayVanPasswordPrompt(out string vanPassword)
		{
			Events.PasswordEventArgs passwordEventArgs = new Events.PasswordEventArgs
			{
				ResumeAction = new Action(this.ResumeCallbackThread)
			};
			this.EventAggregator.GetEvent<EngineEvents.PromptForVanPassword>().Publish(passwordEventArgs);
			this._CallbackResetEvent.WaitOne();
			vanPassword = passwordEventArgs.Password;
			return !passwordEventArgs.Canceled;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002BD7 File Offset: 0x00000DD7
		public void UiPromptForVanPassword(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle)
		{
			Task.Run(delegate()
			{
				string vanPassword;
				if (this.DisplayVanPasswordPrompt(out vanPassword))
				{
					this.Engine.CatchCommEx(delegate
					{
						this.ControlInterface.TaskSetVanPassword(transferTaskHandle, vanPassword);
						this.SendCallbackReply(replyHandle, 1);
					}, "UiPromptForVanPassword");
					return;
				}
				this.SendCallbackReply(replyHandle, 0);
			});
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002C04 File Offset: 0x00000E04
		private void ResumeCallbackThread()
		{
			this._CallbackResetEvent.Set();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002C12 File Offset: 0x00000E12
		private void ResumeAuthorizationCallbackThread(bool Retry)
		{
			this._AuthorizationReply = (Retry ? 1 : 0);
			this._CallbackResetEvent.Set();
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002C2D File Offset: 0x00000E2D
		public void UiAuthorizationError(int replyHandle, ActivityInfo activityInfo, int transferTaskHandle, ValidationResult validationResult)
		{
			Action <>9__1;
			Task.Run(delegate()
			{
				PcmoverClientEngine<PcmoverControlClient> engine = this.Engine;
				Action func;
				if ((func = <>9__1) == null)
				{
					func = (<>9__1 = delegate()
					{
						this.Engine._customizeTaskHandle = transferTaskHandle;
						PcmTaskData taskData = this.ControlInterface.GetTaskData(transferTaskHandle);
						this.Engine.OtherMachine = this.ControlInterface.GetMachineData(taskData.SourceMachineHandle);
						Events.AuthorizationErrorEventArgs payload = new Events.AuthorizationErrorEventArgs
						{
							ResumeAction = new Action<bool>(this.ResumeAuthorizationCallbackThread),
							Result = validationResult
						};
						this.Engine.EventAggregator.GetEvent<EngineEvents.AuthorizationError>().Publish(payload);
						this._CallbackResetEvent.WaitOne();
						this.SendCallbackReply(replyHandle, this._AuthorizationReply);
					});
				}
				engine.CatchCommEx(func, "UiAuthorizationError");
			});
		}

		// Token: 0x04000004 RID: 4
		private readonly AutoResetEvent _CallbackResetEvent = new AutoResetEvent(false);

		// Token: 0x04000005 RID: 5
		private int _AuthorizationReply;
	}
}
