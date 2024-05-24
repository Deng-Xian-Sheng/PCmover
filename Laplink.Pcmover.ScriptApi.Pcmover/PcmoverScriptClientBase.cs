using System;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;

namespace Laplink.Pcmover.ScriptApi.Pcmover
{
	// Token: 0x02000002 RID: 2
	public class PcmoverScriptClientBase : ScriptClientBase
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public PcmoverScriptClientBase(Uri uri, IPcmoverClientEngine client, IPcmoverMonitorCallback monitorCallback, IPcmoverControlCallback controlCallback, LlTraceSource ts) : base(uri, ts)
		{
			this._monitorCallback = monitorCallback;
			this._controlCallback = controlCallback;
			this._client = client;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002071 File Offset: 0x00000271
		public PcmoverScriptClientBase(ScriptChannelBase channelBase, Uri uri, IPcmoverClientEngine client, IPcmoverMonitorCallback monitorCallback, IPcmoverControlCallback controlCallback, LlTraceSource ts) : base(channelBase, uri, ts)
		{
			this._monitorCallback = monitorCallback;
			this._controlCallback = controlCallback;
			this._client = client;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002094 File Offset: 0x00000294
		protected override void FinishOpen()
		{
			if (base.ChannelBase.UriProperties.BaseName == "pcmoverservice")
			{
				base.ChannelBase.DoInvokeScript(PcmoverScripts.IncludeFiles, true);
				base.ChannelBase.DoInvokeScript(PcmoverScripts.InitPcmover, true);
				string text;
				if (base.ChannelBase.DoPoll(PcmoverScripts.GetConnectionStatus, (string scriptText) => scriptText != "2", base.ChannelBase.PollTimeout + TimeSpan.FromSeconds(4.0), true, out text))
				{
					if (text != "1")
					{
						base.ThrowCommunicationException("Unable to connect to PCmover service (connectionStatus=" + text + ")", null);
					}
				}
				else
				{
					base.ThrowCommunicationException("Time out attempting to connect to PCmover service", null);
				}
				if (this._monitorCallback != null)
				{
					base.ChannelBase.DoInvokeScript(PcmoverScripts.StartCollectingEvents, true);
					base.GetPendingEventsScript = PcmoverScripts.GetPendingEvents;
					base.StartEventPolling();
					return;
				}
			}
			else
			{
				base.ThrowCommunicationException("Unable to initialize the script for " + base.ChannelBase.UriProperties.BaseName, null);
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000021B8 File Offset: 0x000003B8
		private ActivityInfo CreateActivityInfo(int handle, ActivityType activityType)
		{
			IPcmoverClientEngine client = this._client;
			ActivityClient activityClient = (client != null) ? client.ActivityClients.FindByHandle(handle) : null;
			ActivityInfo activityInfo = (activityClient != null) ? activityClient.LastInfo : null;
			if (activityInfo != null)
			{
				if (activityInfo.Type == activityType)
				{
					return new ActivityInfo(activityInfo);
				}
				base.Ts.TraceError(string.Format("CreateActivityInfo called for handle {0} type {1}. Info found of the wrong type: {2}", handle, activityType, activityInfo.Type));
			}
			return new ActivityInfo
			{
				Handle = handle,
				Type = activityType,
				State = ActivityState.Active
			};
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002244 File Offset: 0x00000444
		protected override void ProcessEvent(string eventName, string eventData)
		{
			string[] array = eventData.Split(this._commaChars);
			uint num = <PrivateImplementationDetails>.ComputeStringHash(eventName);
			if (num <= 1770709841U)
			{
				if (num <= 416239338U)
				{
					if (num != 345127809U)
					{
						if (num != 416239338U)
						{
							goto IL_4EE;
						}
						if (!(eventName == "UiAuthorizationError"))
						{
							goto IL_4EE;
						}
						goto IL_350;
					}
					else
					{
						if (!(eventName == "PcmoverStatusChanged"))
						{
							goto IL_4EE;
						}
						if (array.Length != 3)
						{
							base.Ts.TraceError("Unexpected eventData for " + eventName + ": " + eventData);
							return;
						}
						try
						{
							PcmoverStatusInfo statusInfo = new PcmoverStatusInfo
							{
								State = (PcmoverState)Enum.Parse(typeof(PcmoverState), array[0]),
								HasController = bool.Parse(array[1]),
								NumCallbacksPending = int.Parse(array[2])
							};
							this._monitorCallback.PcmoverStatusChanged(statusInfo);
							return;
						}
						catch (Exception ex)
						{
							base.Ts.TraceException(ex, "ProcessEvent");
							return;
						}
					}
				}
				else if (num != 1503134778U)
				{
					if (num != 1770709841U)
					{
						goto IL_4EE;
					}
					if (!(eventName == "TransferMethodChanged"))
					{
						goto IL_4EE;
					}
					goto IL_4BE;
				}
				else
				{
					if (!(eventName == "MachineChanged"))
					{
						goto IL_4EE;
					}
					goto IL_41C;
				}
			}
			else if (num <= 2648376232U)
			{
				if (num != 1809959687U)
				{
					if (num != 2648376232U)
					{
						goto IL_4EE;
					}
					if (!(eventName == "ActivityChanged"))
					{
						goto IL_4EE;
					}
				}
				else
				{
					if (!(eventName == "OnDiscoveredMachine"))
					{
						goto IL_4EE;
					}
					goto IL_46A;
				}
			}
			else if (num != 3717084200U)
			{
				if (num != 3764540615U)
				{
					goto IL_4EE;
				}
				if (!(eventName == "ActivityProgress"))
				{
					goto IL_4EE;
				}
				goto IL_288;
			}
			else
			{
				if (!(eventName == "TaskChanged"))
				{
					goto IL_4EE;
				}
				base.Ts.TraceInformation(eventName + " event: " + eventData);
				return;
			}
			try
			{
				MonitorChangeType change = (MonitorChangeType)Enum.Parse(typeof(MonitorChangeType), array[0]);
				ActivityInfo activityInfo = this.CreateActivityInfo(int.Parse(array[1]), (ActivityType)Enum.Parse(typeof(ActivityType), array[4]));
				activityInfo.State = (ActivityState)Enum.Parse(typeof(ActivityState), array[2]);
				activityInfo.Phase = int.Parse(array[3]);
				activityInfo.FailureReason = int.Parse(array[5]);
				activityInfo.Message = (string.IsNullOrWhiteSpace(array[6]) ? null : array[6].Trim());
				this._monitorCallback.ActivityChanged(activityInfo, change);
				return;
			}
			catch (Exception ex2)
			{
				base.Ts.TraceException(ex2, "ProcessEvent");
				return;
			}
			IL_288:
			try
			{
				ActivityType activityType;
				Enum.TryParse<ActivityType>(array[1], out activityType);
				ActivityInfo activityInfo2 = this.CreateActivityInfo(Convert.ToInt32(array[0]), activityType);
				UiCallbackCode taskCode;
				Enum.TryParse<UiCallbackCode>(array[3], out taskCode);
				UiCallbackCode actionCode;
				Enum.TryParse<UiCallbackCode>(array[4], out actionCode);
				UiCallbackCode itemCode;
				Enum.TryParse<UiCallbackCode>(array[5], out itemCode);
				ProgressInfo progressInfo = new ProgressInfo
				{
					TimeStampUtc = Convert.ToDateTime(array[2]),
					TaskCode = taskCode,
					ActionCode = actionCode,
					ItemCode = itemCode,
					Percentage = Convert.ToUInt16(array[6]),
					BytesProcessed = Convert.ToUInt64(array[7]),
					Action = array[8],
					Item = array[9]
				};
				this._monitorCallback.ActivityProgress(activityInfo2, progressInfo);
				return;
			}
			catch (Exception ex3)
			{
				base.Ts.TraceException(ex3, "ProcessEvent");
				return;
			}
			IL_350:
			try
			{
				int replyHandle = Convert.ToInt32(array[0]);
				int transferTaskHandle = Convert.ToInt32(array[6]);
				ActivityState state;
				Enum.TryParse<ActivityState>(array[2], out state);
				ActivityType activityType2;
				Enum.TryParse<ActivityType>(array[4], out activityType2);
				ActivityInfo activityInfo3 = this.CreateActivityInfo(Convert.ToInt32(array[1]), activityType2);
				activityInfo3.State = state;
				activityInfo3.Phase = Convert.ToInt32(array[3]);
				activityInfo3.FailureReason = Convert.ToInt32(array[5]);
				ValidationErrorCode errorCode;
				Enum.TryParse<ValidationErrorCode>(array[8], out errorCode);
				ValidationResult validationResult = new ValidationResult
				{
					IsAuthorized = Convert.ToBoolean(array[7]),
					ErrorCode = errorCode,
					IsPreValidated = Convert.ToBoolean(array[9])
				};
				this._controlCallback.UiAuthorizationError(replyHandle, activityInfo3, transferTaskHandle, validationResult);
				return;
			}
			catch (Exception ex4)
			{
				base.Ts.TraceException(ex4, "ProcessEvent");
				return;
			}
			IL_41C:
			try
			{
				MonitorChangeType change2;
				Enum.TryParse<MonitorChangeType>(array[0], out change2);
				MachineData machineData = new MachineData
				{
					Handle = Convert.ToInt32(array[1])
				};
				this._controlCallback.MachineChanged(machineData, change2);
				return;
			}
			catch (Exception ex5)
			{
				base.Ts.TraceException(ex5, "ProcessEvent");
				return;
			}
			IL_46A:
			try
			{
				int discoveryActivityHandle = Convert.ToInt32(eventData[0]);
				ConnectableMachine machine = new ConnectableMachine
				{
					NetName = array[1],
					IsOld = Convert.ToBoolean(array[2])
				};
				this._controlCallback.OnDiscoveredMachine(discoveryActivityHandle, machine);
				return;
			}
			catch (Exception ex6)
			{
				base.Ts.TraceException(ex6, "ProcessEvent");
				return;
			}
			IL_4BE:
			base.Ts.TraceInformation(eventName + " event: " + eventData);
			return;
			IL_4EE:
			base.Ts.TraceVerbose("Event not supported yet: " + eventName);
		}

		// Token: 0x04000001 RID: 1
		private IPcmoverMonitorCallback _monitorCallback;

		// Token: 0x04000002 RID: 2
		private IPcmoverControlCallback _controlCallback;

		// Token: 0x04000003 RID: 3
		private readonly IPcmoverClientEngine _client;
	}
}
