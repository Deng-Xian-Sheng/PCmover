using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200001C RID: 28
	internal class ListenActivity : PcmActivity, ITaskActivity, ITransferMethodsActivity
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x0000DCE2 File Offset: 0x0000BEE2
		// (set) Token: 0x060001B9 RID: 441 RVA: 0x0000DCEA File Offset: 0x0000BEEA
		public ServiceTask ActivityServiceTask { get; private set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060001BA RID: 442 RVA: 0x0000DCF3 File Offset: 0x0000BEF3
		public IEnumerable<ServiceTransferMethod> ActivityServiceTransferMethods
		{
			get
			{
				return this._listeningStms;
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000DCFB File Offset: 0x0000BEFB
		public bool OKtoProceed()
		{
			return this.m_bProceed;
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0000DD03 File Offset: 0x0000BF03
		public ListenActivity(PcmoverManager manager, List<ServiceTransferMethod> stms) : base(ActivityType.Listen, manager)
		{
			this._listeningStms = stms;
			this.m_bAsync = true;
			this._taskList = new List<Task>();
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0000DD26 File Offset: 0x0000BF26
		protected override void Dispose(bool disposing)
		{
			if (!this.disposedValue)
			{
				if (disposing)
				{
					this.cleanup();
				}
				this.disposedValue = true;
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000DD48 File Offset: 0x0000BF48
		public override bool Start()
		{
			bool result;
			lock (this)
			{
				result = base.Start();
			}
			return result;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000DD88 File Offset: 0x0000BF88
		private void UpdatePhase(ListenActivityPhase newPhase, string message = null)
		{
			ActivityInfo info = this.Info;
			lock (info)
			{
				this.Info.Phase = (int)newPhase;
				this.Info.Message = message;
			}
			base.NotifyActivityInfoChanged();
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0000DDE0 File Offset: 0x0000BFE0
		protected virtual void cleanup()
		{
			foreach (ServiceTransferMethod serviceTransferMethod in this._listeningStms)
			{
				ConnectionMethod connectionMethod = serviceTransferMethod.GetConnectionMethod();
				if (connectionMethod != null && connectionMethod.IsOpen())
				{
					connectionMethod.CloseConnection();
				}
			}
			if (this._newStms != null)
			{
				foreach (ServiceTransferMethod serviceTransferMethod2 in this._newStms)
				{
					ConnectionMethod connectionMethod2 = serviceTransferMethod2.GetConnectionMethod();
					if (connectionMethod2 != null && connectionMethod2.IsOpen())
					{
						connectionMethod2.CloseConnection();
					}
				}
			}
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000DEA0 File Offset: 0x0000C0A0
		protected override void OnCancel()
		{
			foreach (ServiceTransferMethod serviceTransferMethod in this._listeningStms)
			{
				ConnectionMethod connectionMethod = serviceTransferMethod.GetConnectionMethod();
				if (connectionMethod != null)
				{
					connectionMethod.Cancel();
				}
			}
			if (this._newTaskList != null)
			{
				this._newTaskList.Clear();
				this._newTaskList = null;
				foreach (ServiceTransferMethod serviceTransferMethod2 in this._newStms)
				{
					ConnectionMethod connectionMethod2 = serviceTransferMethod2.GetConnectionMethod();
					if (connectionMethod2 != null)
					{
						connectionMethod2.Cancel();
					}
				}
				this._newStms.Clear();
				this._newStms = null;
			}
			base.OnCancel();
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000DF78 File Offset: 0x0000C178
		protected override void OnTaskComplete()
		{
			this.cleanup();
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0000DF80 File Offset: 0x0000C180
		protected override void OnTaskStopped()
		{
			if (this.m_protocol != null)
			{
				this.m_protocol.bCancel = false;
				this.m_protocol.detach();
				this.m_protocol = null;
			}
			this.cleanup();
			this.m_connectionMethod = null;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000DFB8 File Offset: 0x0000C1B8
		public void GetLocalSslInfo(SslInfo info)
		{
			lock (this)
			{
				if (this.m_connectionMethod != null)
				{
					if (this.m_connectionMethod.TransferMethod == ENUM_TRANSFERMETHOD.TM_NETWORK)
					{
						NetworkTransferMethod networkTransferMethod = (NetworkTransferMethod)this.m_connectionMethod;
						if (networkTransferMethod.bSecure)
						{
							info.State = (SSLState)networkTransferMethod.SSLState;
							info.IsSecure = (info.State == SSLState.ConnectedUntrusted || info.State == SSLState.ConnectedTrusted);
							info.IsSSLClient = networkTransferMethod.bSSLClient;
							info.IsCertificateValid = networkTransferMethod.bValidCertificate;
							info.LocalCertificate = networkTransferMethod.LocalCertificate;
							info.PeerCertificate = networkTransferMethod.PeerCertificate;
						}
					}
					else if (this.m_connectionMethod.TransferMethod == ENUM_TRANSFERMETHOD.TM_USB)
					{
						USBTransferMethod usbtransferMethod = (USBTransferMethod)this.m_connectionMethod;
						if (usbtransferMethod.SSLState == SSL_STATE.ConnectedTrusted || usbtransferMethod.SSLState == SSL_STATE.ConnectedUntrusted)
						{
							info.State = (SSLState)usbtransferMethod.SSLState;
							info.IsSecure = true;
							info.IsSSLClient = usbtransferMethod.bSSLClient;
							info.IsCertificateValid = usbtransferMethod.bValidCertificate;
							info.LocalCertificate = usbtransferMethod.LocalCertificate;
							info.PeerCertificate = usbtransferMethod.PeerCertificate;
						}
					}
				}
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00002B6C File Offset: 0x00000D6C
		protected override void Run()
		{
			this.RunAsync().Wait();
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0000E0F4 File Offset: 0x0000C2F4
		protected override Task RunAsync()
		{
			ListenActivity.<RunAsync>d__29 <RunAsync>d__;
			<RunAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<RunAsync>d__.<>4__this = this;
			<RunAsync>d__.<>1__state = -1;
			<RunAsync>d__.<>t__builder.Start<ListenActivity.<RunAsync>d__29>(ref <RunAsync>d__);
			return <RunAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000E138 File Offset: 0x0000C338
		private void CloseAll(ConnectionMethod dontClose = null)
		{
			foreach (ServiceTransferMethod serviceTransferMethod in this._listeningStms)
			{
				ConnectionMethod connectionMethod = serviceTransferMethod.GetConnectionMethod();
				if (connectionMethod != null && connectionMethod != dontClose)
				{
					serviceTransferMethod.Cancel();
				}
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000E198 File Offset: 0x0000C398
		public bool SetDirection(ServiceTransferMethod stm_, ConnectableMachine remoteMachine)
		{
			ConnectionMethod connectionMethod = stm_.GetConnectionMethod();
			ServiceNetworkTransferMethod networkStm = null;
			if (stm_ is ServiceNetworkTransferMethod)
			{
				networkStm = (ServiceNetworkTransferMethod)stm_;
			}
			new Thread(delegate()
			{
				try
				{
					bool flag = remoteMachine.Status == DiscoveredMachineStatus.MachineFound;
					CommandType type = flag ? CommandType.CMD_NOTIFY_DIRECTION : CommandType.CMD_SWITCH_DIRECTION;
					if (!flag && remoteMachine.IsOld && connectionMethod.IsOpen() && networkStm != null)
					{
						NetworkTransferMethod networkTransferMethod = networkStm.NetworkTransferMethod;
						int transferMethodHandle = this.Manager.CreateTransferMethodInternal(networkTransferMethod.bSecure ? TransferMethodType.SSL : TransferMethodType.Network);
						ServiceNetworkTransferMethod serviceNetworkTransferMethod = (ServiceNetworkTransferMethod)this.Manager.GetServiceTransferMethod(transferMethodHandle);
						serviceNetworkTransferMethod.Password = networkStm.GetPassword();
						ListenActivity <>4__this = this;
						lock (<>4__this)
						{
							this._newTaskList = null;
							this._newStms = null;
							this.CloseAll(null);
						}
						Thread.Sleep(1000);
						networkStm = serviceNetworkTransferMethod;
						remoteMachine.TransferMethodHandle = serviceNetworkTransferMethod.Handle;
						remoteMachine.Status = DiscoveredMachineStatus.UpdateTransferMethodHandle;
						this.Manager.NotifyOnDiscoveredMachine(0, remoteMachine);
						connectionMethod = (ConnectionMethod)networkTransferMethod;
					}
					if (!connectionMethod.IsOpen())
					{
						if (networkStm != null)
						{
							try
							{
								NetworkTransferMethod networkTransferMethod2 = networkStm.NetworkTransferMethod;
								networkTransferMethod2.bSecure = !string.IsNullOrEmpty(remoteMachine.CertificateName);
								if (networkTransferMethod2.RemoteMachine != remoteMachine.NetName)
								{
									remoteMachine.Status = DiscoveredMachineStatus.FindingRemoteComputer;
									this.Manager.NotifyOnDiscoveredMachine(0, remoteMachine);
									networkTransferMethod2.RemoteMachine = remoteMachine.NetName;
									networkTransferMethod2.RemoteCertificateName = remoteMachine.CertificateName;
								}
							}
							catch (Exception ex)
							{
								remoteMachine.Status = DiscoveredMachineStatus.MachineNotFound;
								this.Manager.NotifyOnDiscoveredMachine(0, remoteMachine);
								this.m_ts.TraceException(ex, "SetDirection");
								return;
							}
						}
						remoteMachine.Status = DiscoveredMachineStatus.Connecting;
						this.Manager.NotifyOnDiscoveredMachine(0, remoteMachine);
						connectionMethod.bOutgoing = true;
						if (!connectionMethod.MakeConnection())
						{
							remoteMachine.Status = DiscoveredMachineStatus.ConnectFailed;
							this.Manager.NotifyOnDiscoveredMachine(0, remoteMachine);
							return;
						}
					}
					byte[] utf = this.Manager.UserData.GetUTF8(true, !remoteMachine.IsOld);
					remoteMachine.Status = DiscoveredMachineStatus.SettingDirection;
					this.Manager.NotifyOnDiscoveredMachine(0, remoteMachine);
					PcmProtocol pcmProtocol = connectionMethod.GetPcmProtocol();
					remoteMachine.Status = DiscoveredMachineStatus.DirectionSet;
					if (!pcmProtocol.SendCommandWithData(type, ref utf[0], (uint)utf.Length) || !pcmProtocol.GetAck())
					{
						remoteMachine.Status = DiscoveredMachineStatus.CommunicationError;
					}
					if (remoteMachine.Status == DiscoveredMachineStatus.CommunicationError || flag || remoteMachine.IsOld)
					{
						connectionMethod.CloseConnection();
						this.Manager.NotifyOnDiscoveredMachine(0, remoteMachine);
					}
					else
					{
						this.Manager.NotifyOnDiscoveredMachine(0, remoteMachine);
						if (networkStm != null)
						{
							TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
							ListenActivity <>4__this = this;
							lock (<>4__this)
							{
								this._newStms = new List<ServiceTransferMethod>
								{
									networkStm
								};
								this._newTaskList = new List<Task>
								{
									taskCompletionSource.Task
								};
							}
							try
							{
								this.CloseAll(null);
								string password = null;
								connectionMethod = networkStm.GetConnectionMethod();
								if (connectionMethod.TransferMethod == ENUM_TRANSFERMETHOD.TM_NETWORK)
								{
									password = networkStm.GetPassword();
								}
								networkStm.InitCancellationToken();
								this.HandleConnections(connectionMethod, connectionMethod.GetPcmProtocol(), networkStm.CancellationToken, password);
							}
							catch (Exception ex2)
							{
								this.m_ts.TraceException(ex2, "SetDirection");
								taskCompletionSource.TrySetResult(false);
							}
							finally
							{
								taskCompletionSource.TrySetResult(true);
							}
						}
					}
				}
				catch (Exception ex3)
				{
					this.Manager.Ts.TraceInformation("Exception in ListenActivity::SetDirection: " + ex3.Message);
					remoteMachine.Status = DiscoveredMachineStatus.Exception;
					this.Manager.NotifyOnDiscoveredMachine(0, remoteMachine);
				}
			}).Start();
			return true;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000E1F8 File Offset: 0x0000C3F8
		private void HandleConnections(ConnectionMethod connectionMethod, PcmProtocol protocol, CancellationToken ct, string password)
		{
			ProgressBase progressBase = null;
			Task task = null;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = true;
			bool flag4 = !string.IsNullOrEmpty(password);
			if (flag4)
			{
				flag3 = false;
				connectionMethod.PasswordRequired = true;
			}
			try
			{
				while (!this.m_bCancel && !this.m_bDone)
				{
					if (!connectionMethod.IsOpen())
					{
						flag2 = false;
						flag3 = !flag4;
						this.UpdatePhase(ListenActivityPhase.WaitingForConnection, null);
						if (!connectionMethod.MakeConnection())
						{
							if (!this.m_bCancel && flag)
							{
								this.m_bSuccess = false;
								this.Info.FailureReason = 4;
								break;
							}
							break;
						}
					}
					CommandPacket commandPacket = null;
					try
					{
						this.UpdatePhase(ListenActivityPhase.WaitingForCommand, null);
						commandPacket = protocol.ReceiveCommand();
						if (commandPacket == null)
						{
							ListenActivity obj = this;
							lock (obj)
							{
								if (connectionMethod.IsOpen())
								{
									connectionMethod.CloseConnection();
								}
							}
							if (ct != CancellationToken.None && ct.IsCancellationRequested)
							{
								break;
							}
						}
						else
						{
							bool flag6 = false;
							bool flag7 = false;
							this.UpdatePhase(ListenActivityPhase.ProcessingCommand, commandPacket.Type.ToString());
							CommandType type = commandPacket.Type;
							switch (type)
							{
							case CommandType.CMD_AUTHORIZETRANSFER:
							{
								object registrationLock = base.Manager._registrationLock;
								lock (registrationLock)
								{
									protocol.HandleAuthorizeTransferPacket(commandPacket);
									goto IL_6F3;
								}
								goto IL_5CB;
							}
							case (CommandType)66:
							case CommandType.CMD_DISCOVERY:
							case (CommandType)71:
							case (CommandType)72:
							case (CommandType)75:
							case (CommandType)77:
							case CommandType.CMD_NACK:
								goto IL_6C1;
							case CommandType.CMD_SYNC:
								break;
							case CommandType.CMD_END:
								this.UpdatePhase(ListenActivityPhase.EndReceived, null);
								if (task != null)
								{
									task.Wait();
									task = null;
								}
								protocol.HandleEndCommand();
								this.m_bDone = true;
								this.m_bProceed = true;
								goto IL_6F3;
							case CommandType.CMD_FILL:
							{
								if (!flag2 || !flag3 || this._fillTask == null)
								{
									flag6 = true;
									goto IL_6F3;
								}
								this.UpdatePhase(ListenActivityPhase.StartingTransfer, null);
								FillPacket fillPacket = (FillPacket)commandPacket;
								this.m_ts.TraceInformation("Fill packet detail: " + fillPacket.detail.ToString());
								protocol.SendAck();
								this.m_app.CurMigrationStatus.activeState = MS_ACTIVE_STATE.ACTIVE_STATE_TRANSFER;
								if (this._fillTask.FillMovingVan((TransferMethod)connectionMethod, fillPacket.detail))
								{
									this.UpdatePhase(ListenActivityPhase.FinishedTransfer, null);
									this.m_bSuccess = true;
								}
								else
								{
									this.UpdatePhase(ListenActivityPhase.FinishedTransferWithError, null);
								}
								this.UpdatePhase(ListenActivityPhase.SavingLog, null);
								FillVanTask fillTaskTemp = this._fillTask;
								task = Task.Factory.StartNew(delegate()
								{
									fillTaskTemp.CreateTaskFiles((TASK_FILES)3 | (this.m_bSuccess ? TASK_FILES.TF_FAILURES : ((TASK_FILES)0)));
									this.m_app.CurMigrationStatus.activeState = (fillTaskTemp.IsTransferSuccessful() ? MS_ACTIVE_STATE.ACTIVE_STATE_COMPLETE : MS_ACTIVE_STATE.ACTIVE_STATE_ERROR);
								}, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
								if (fillPacket.endWhenDone)
								{
									this.m_bDone = true;
									this.m_bProceed = true;
									goto IL_6F3;
								}
								goto IL_6F3;
							}
							case CommandType.CMD_GETINFO:
							{
								ENUM_INFOVALIDATION enum_INFOVALIDATION = protocol.HandleGetInfoPacket(commandPacket);
								if (enum_INFOVALIDATION != ENUM_INFOVALIDATION.INFO_OK)
								{
									if (enum_INFOVALIDATION == ENUM_INFOVALIDATION.INFO_VERSION_MISMATCH)
									{
										this.UpdatePhase(ListenActivityPhase.VersionError, null);
									}
									connectionMethod.CloseConnection();
									goto IL_6F3;
								}
								flag2 = true;
								if (!flag)
								{
									ListenActivity obj = this;
									lock (obj)
									{
										if (this.m_connectionMethod != null)
										{
											connectionMethod.CloseConnection();
											return;
										}
										flag = true;
										this._bAnyMethodConnected = true;
										this.m_connectionMethod = connectionMethod;
										this.m_protocol = protocol;
										progressBase = this.m_app.CreateProgressBase();
										if (progressBase != null)
										{
											progressBase.SetProgressHandlers(this);
										}
										if (progressBase != null)
										{
											progressBase.Set();
										}
										this.m_progressBase = progressBase;
									}
									this.CloseAll(connectionMethod);
									this.UpdatePhase(ListenActivityPhase.ConnectedOn, connectionMethod.TransferMethod.ToString());
									goto IL_6F3;
								}
								goto IL_6F3;
							}
							case CommandType.CMD_ACCEPTJOURNAL:
								if (!flag2 || !flag3)
								{
									flag6 = true;
									goto IL_6F3;
								}
								if (this._fillTask != null)
								{
									base.Manager.DoDeleteTask(this.ActivityServiceTask.Handle);
									this._fillTask = null;
									this.ActivityServiceTask = null;
								}
								this.UpdatePhase(ListenActivityPhase.ReceivingTransferInstructions, null);
								protocol.SendAck();
								this._fillTask = this.m_app.CreateFillVanTask();
								if (this._fillTask.Load((TransferMethod)connectionMethod))
								{
									protocol.SendAck();
									this.UpdatePhase(ListenActivityPhase.WaitingToTransferData, null);
									this.ActivityServiceTask = base.Manager.AddServiceTask(this._fillTask, null, null);
									goto IL_6F3;
								}
								flag7 = true;
								goto IL_6F3;
							case CommandType.CMD_SENDPASSWORD:
								flag3 = protocol.HandleSendPasswordCommand(commandPacket, password);
								goto IL_6F3;
							case CommandType.CMD_OPTIONALDATA:
							{
								protocol.SendAck();
								uint extraDataLength = commandPacket.extraDataLength;
								if (extraDataLength == 0U)
								{
									goto IL_6F3;
								}
								byte[] array = new byte[extraDataLength];
								commandPacket.GetExtraData(ref extraDataLength, ref array[0]);
								string @string = UserData.encoding.GetString(array);
								try
								{
									XElement xelement = XDocument.Parse(@string).Element("OptionalData");
									if (xelement != null)
									{
										try
										{
											XElement xelement2 = xelement.Element("fn");
											if (xelement2 != null && xelement2.Value != null)
											{
												string message = UserData.unescapeCDATA(xelement2.Value);
												this.UpdatePhase(ListenActivityPhase.RemoteMachineNameReceived, message);
											}
										}
										catch
										{
										}
									}
									goto IL_6F3;
								}
								catch
								{
									goto IL_6F3;
								}
								break;
							}
							default:
								switch (type)
								{
								case CommandType.CMD_TEST:
									protocol.SendAck();
									this.UpdatePhase(ListenActivityPhase.CommTest, null);
									this.UpdatePhase(protocol.DoTest() ? ListenActivityPhase.CommTestSucceeded : ListenActivityPhase.CommTestFailed, null);
									connectionMethod.CloseConnection();
									this.m_bDone = true;
									this.m_bProceed = true;
									goto IL_6F3;
								case CommandType.CMD_TAKESNAPSHOT:
								{
									if (!flag2 || !flag3)
									{
										flag6 = true;
										goto IL_6F3;
									}
									Machine thisMachine = this.m_app.ThisMachine;
									if (thisMachine == null)
									{
										protocol.SendNack();
										goto IL_6F3;
									}
									if (thisMachine.AppInvState != APPINVENTORY_STATE.APPINV_SCANOTHERS_DONE)
									{
										protocol.SendNack();
										goto IL_6F3;
									}
									this.UpdatePhase(ListenActivityPhase.AnalyzingPC, null);
									protocol.SendAck();
									if (this.m_app.ThisMachine.Save((TransferMethod)connectionMethod))
									{
										this.UpdatePhase(ListenActivityPhase.WaitingToCompleteTransfer, null);
										goto IL_6F3;
									}
									flag7 = true;
									goto IL_6F3;
								}
								case CommandType.CMD_UNLOAD:
								case (CommandType)86:
									goto IL_6C1;
								case CommandType.CMD_SWITCH_DIRECTION:
									break;
								case CommandType.CMD_EXTENDED_DISCOVERY:
									goto IL_5CB;
								default:
									if (type != CommandType.CMD_NOTIFY_DIRECTION)
									{
										goto IL_6C1;
									}
									break;
								}
								try
								{
									bool flag8 = commandPacket.Type == CommandType.CMD_SWITCH_DIRECTION;
									ConnectableMachine connectableMachine = this.HandleUserData(connectionMethod, commandPacket, flag8, flag8);
									if (connectableMachine == null)
									{
										protocol.SendNack();
									}
									else
									{
										protocol.SendAck();
										base.Manager.NotifyOnSetDirection(connectableMachine);
										if (flag8 && connectableMachine.IsOld)
										{
											this.UpdatePhase(ListenActivityPhase.SetDirection, connectableMachine.NetName);
											return;
										}
									}
									goto IL_6F3;
								}
								catch
								{
									connectionMethod.CloseConnection();
									goto IL_6F3;
								}
								goto IL_6C1;
							}
							protocol.SendAck();
							goto IL_6F3;
							IL_5CB:
							try
							{
								UserData userData = base.Manager.UserData;
								if (userData == null)
								{
									userData = new UserData(this.m_app, string.Empty);
								}
								protocol.SendCommandWithData(CommandType.CMD_EXTENDED_DISCOVERYREPLY, ref userData.UserDataUTF8[0], (uint)userData.UserDataUTF8.Length);
								ConnectableMachine connectableMachine2 = this.HandleUserData(connectionMethod, commandPacket, true, false);
								if (connectableMachine2 != null)
								{
									connectableMachine2.Status = DiscoveredMachineStatus.RemoteManualConnection;
									connectableMachine2 = base.Manager.AddOrUpdateManualMachine(connectableMachine2);
									base.Manager.NotifyOnDiscoveredMachine(0, connectableMachine2);
								}
							}
							catch
							{
							}
							connectionMethod.CloseConnection();
							goto IL_6F3;
							IL_6C1:
							this.UpdatePhase(ListenActivityPhase.InvalidCommand, commandPacket.Type.ToString());
							protocol.InvalidCommand(commandPacket);
							connectionMethod.CloseConnection();
							break;
							IL_6F3:
							if (flag6)
							{
								protocol.SendNack();
								connectionMethod.CloseConnection();
							}
							else if (flag7)
							{
								connectionMethod.CloseConnection();
								break;
							}
						}
					}
					catch (Exception ex)
					{
						base.TerminateOnException(ex, "HandleConnections");
						this.m_bDone = true;
					}
					finally
					{
						if (commandPacket != null)
						{
							commandPacket.dispose();
						}
					}
				}
			}
			finally
			{
				ListenActivity obj = this;
				lock (obj)
				{
					if (flag)
					{
						PcmProtocol protocol2 = this.m_protocol;
						if (protocol2 != null)
						{
							protocol2.bCancel = false;
							protocol2.detach();
							this.m_protocol = null;
						}
						this.m_connectionMethod = null;
					}
				}
				if (task != null)
				{
					task.Wait();
				}
				if (progressBase != null)
				{
					progressBase.Reset();
				}
				if (progressBase != null)
				{
					progressBase.SetProgressHandlers(null);
				}
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000EACC File Offset: 0x0000CCCC
		private ConnectableMachine HandleUserData(ConnectionMethod connectionMethod, CommandPacket packet, bool bAddManualMachine = true, bool bSetDirection = false)
		{
			uint extraDataLength = packet.extraDataLength;
			if (extraDataLength != 0U)
			{
				byte[] array = new byte[extraDataLength];
				packet.GetExtraData(ref extraDataLength, ref array[0]);
				ServiceTransferMethod serviceTransferMethod = this._listeningStms.FirstOrDefault((ServiceTransferMethod x) => x.GetConnectionMethod() == connectionMethod);
				if (serviceTransferMethod != null)
				{
					ConnectableMachine connectableMachine = new ConnectableMachine
					{
						NetName = "Manual Connection",
						Method = TransferMethodType.Network,
						SerialNumber = "",
						CreationTime = DateTime.UtcNow,
						ConnectionName = "Network",
						Status = (bAddManualMachine ? DiscoveredMachineStatus.RemoteManualConnection : DiscoveredMachineStatus.DirectionNotification)
					};
					if (serviceTransferMethod is ServiceUsbTransferMethod)
					{
						connectableMachine.Method = TransferMethodType.Usb;
						connectableMachine.ConnectionName = "USB";
					}
					UserData.parse(array, connectableMachine);
					if (string.IsNullOrEmpty(connectableMachine.FriendlyName))
					{
						connectableMachine.FriendlyName = connectableMachine.NetName;
					}
					if (!string.Equals(connectableMachine.NetName, connectableMachine.FriendlyName, StringComparison.CurrentCultureIgnoreCase))
					{
						connectableMachine.DisplayName = connectableMachine.NetName + " (" + connectableMachine.FriendlyName + ")";
					}
					else
					{
						connectableMachine.DisplayName = connectableMachine.FriendlyName;
					}
					if (bAddManualMachine && connectableMachine.Method != TransferMethodType.Usb)
					{
						if (!(serviceTransferMethod is ServiceNetworkTransferMethod))
						{
							return null;
						}
						NetworkTransferMethod networkTransferMethod = ((ServiceNetworkTransferMethod)serviceTransferMethod).NetworkTransferMethod;
						connectableMachine.TransferMethodHandle = serviceTransferMethod.Handle;
						connectableMachine = base.Manager.AddOrUpdateManualMachine(connectableMachine);
						networkTransferMethod.UpdateRemoteMachineName(connectableMachine.NetName);
						if (bSetDirection && connectableMachine.IsOld)
						{
							try
							{
								int transferMethodHandle = base.Manager.CreateTransferMethodInternal(networkTransferMethod.bSecure ? TransferMethodType.SSL : TransferMethodType.Network);
								ServiceNetworkTransferMethod serviceNetworkTransferMethod = (ServiceNetworkTransferMethod)base.Manager.GetServiceTransferMethod(transferMethodHandle);
								serviceNetworkTransferMethod.Password = serviceTransferMethod.GetPassword();
								serviceNetworkTransferMethod.NetworkTransferMethod.bOutgoing = false;
								lock (this)
								{
									this._listeningStms.Remove(serviceTransferMethod);
									this._stms.Remove(serviceTransferMethod);
									this._stms.Add(serviceNetworkTransferMethod);
									this.CloseAll(null);
								}
							}
							catch (Exception ex)
							{
								this.m_ts.TraceException(ex, "SetDirection");
							}
						}
					}
					return connectableMachine;
				}
			}
			return null;
		}

		// Token: 0x0400006E RID: 110
		private ConnectionMethod m_connectionMethod;

		// Token: 0x0400006F RID: 111
		private PcmProtocol m_protocol;

		// Token: 0x04000070 RID: 112
		private List<ServiceTransferMethod> _listeningStms;

		// Token: 0x04000071 RID: 113
		private List<ServiceTransferMethod> _newStms;

		// Token: 0x04000072 RID: 114
		private List<ServiceTransferMethod> _stms;

		// Token: 0x04000073 RID: 115
		private FillVanTask _fillTask;

		// Token: 0x04000075 RID: 117
		private bool _bAnyMethodConnected;

		// Token: 0x04000076 RID: 118
		private List<Task> _taskList;

		// Token: 0x04000077 RID: 119
		private List<Task> _newTaskList;

		// Token: 0x04000078 RID: 120
		private bool m_bProceed;

		// Token: 0x04000079 RID: 121
		private new bool m_bDone;

		// Token: 0x0400007A RID: 122
		private bool disposedValue;
	}
}
