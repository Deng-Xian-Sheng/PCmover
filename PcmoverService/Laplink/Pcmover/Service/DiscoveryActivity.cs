using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000007 RID: 7
	internal class DiscoveryActivity : PcmActivity, DiscoveryCallbacks, IDiscoveryCallbacks, ITransferMethodsActivity
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00002A58 File Offset: 0x00000C58
		public IEnumerable<ServiceTransferMethod> ActivityServiceTransferMethods { get; }

		// Token: 0x06000020 RID: 32 RVA: 0x00002A60 File Offset: 0x00000C60
		public DiscoveryActivity(PcmoverManager manager, List<ServiceTransferMethod> transferMethods, int timeout, string serialNumber) : base(ActivityType.Discovery, manager)
		{
			this.m_timeout = timeout;
			this.m_serialNumber = serialNumber;
			this.m_bAsync = true;
			this.ActivityServiceTransferMethods = transferMethods;
			foreach (ServiceTransferMethod serviceTransferMethod in transferMethods)
			{
				if (this.m_ntm == null && serviceTransferMethod is ServiceNetworkTransferMethod)
				{
					this.m_ntm = (serviceTransferMethod as ServiceNetworkTransferMethod);
				}
				else if (this.m_utm == null && serviceTransferMethod is ServiceUsbTransferMethod)
				{
					this.m_utm = (serviceTransferMethod as ServiceUsbTransferMethod);
				}
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002B24 File Offset: 0x00000D24
		public List<ConnectableMachine> ConnectableMachines
		{
			get
			{
				object @lock = this.m_lock;
				List<ConnectableMachine> result;
				lock (@lock)
				{
					result = new List<ConnectableMachine>(this.m_machines);
				}
				return result;
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002B6C File Offset: 0x00000D6C
		protected override void Run()
		{
			this.RunAsync().Wait();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002B7C File Offset: 0x00000D7C
		protected override Task RunAsync()
		{
			DiscoveryActivity.<RunAsync>d__14 <RunAsync>d__;
			<RunAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<RunAsync>d__.<>4__this = this;
			<RunAsync>d__.<>1__state = -1;
			<RunAsync>d__.<>t__builder.Start<DiscoveryActivity.<RunAsync>d__14>(ref <RunAsync>d__);
			return <RunAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002BC0 File Offset: 0x00000DC0
		public void OnMachineFound(RemoteMachine machine)
		{
			if (!this.m_bCancel && this.m_bCallbacksEnabled)
			{
				object @lock = this.m_lock;
				lock (@lock)
				{
					if (this.FindConnectableMachine(machine) == null)
					{
						this.AddConnectableMachine(this.CreateConnectableMachine(machine));
					}
				}
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002C20 File Offset: 0x00000E20
		public void OnMachineLost(RemoteMachine remoteMachine)
		{
			if (!this.m_bCancel && this.m_bCallbacksEnabled)
			{
				object @lock = this.m_lock;
				lock (@lock)
				{
					ConnectableMachine connectableMachine = this.FindConnectableMachine(remoteMachine);
					if (connectableMachine != null)
					{
						this.RemoveConnectableMachine(connectableMachine);
					}
				}
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002C7C File Offset: 0x00000E7C
		public void OnUSBStateChanged(USB_STATE newState)
		{
			base.Manager.NotifyUSBStateChanged(newState);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002C8A File Offset: 0x00000E8A
		private void AddConnectableMachine(ConnectableMachine connectable)
		{
			this.m_machines.Add(connectable);
			base.Manager.NotifyOnDiscoveredMachine(this.Info.Handle, connectable);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002CB0 File Offset: 0x00000EB0
		public static bool AddRemoteMachine(PcmoverManager Manager, ConnectableMachine machine, bool bSecure)
		{
			bool result;
			try
			{
				machine.TransferMethodHandle = Manager.CreateTransferMethodInternal(bSecure ? TransferMethodType.SSL : TransferMethodType.Network);
				ServiceTransferMethod serviceTransferMethod = Manager.GetServiceTransferMethod(machine.TransferMethodHandle);
				ServiceNetworkTransferMethod stm = serviceTransferMethod as ServiceNetworkTransferMethod;
				if (stm == null)
				{
					result = false;
				}
				else
				{
					ConnectionMethod connectionMethod = stm.GetConnectionMethod();
					if (connectionMethod == null)
					{
						result = false;
					}
					else
					{
						PcmProtocol protocol = connectionMethod.GetPcmProtocol();
						if (protocol == null)
						{
							result = false;
						}
						else
						{
							new Thread(delegate()
							{
								machine.Status = DiscoveredMachineStatus.FindingRemoteComputer;
								Manager.NotifyOnDiscoveredMachine(0, machine);
								try
								{
									stm.NetworkTransferMethod.RemoteMachine = machine.NetName;
									if (bSecure)
									{
										stm.NetworkTransferMethod.RemoteCertificateName = machine.CertificateName;
										stm.NetworkTransferMethod.bSecure = true;
									}
								}
								catch
								{
									machine.Status = DiscoveredMachineStatus.MachineNotFound;
									Manager.NotifyOnDiscoveredMachine(0, machine);
									return;
								}
								try
								{
									if (!connectionMethod.IsOpen())
									{
										machine.Status = DiscoveredMachineStatus.Connecting;
										Manager.NotifyOnDiscoveredMachine(0, machine);
										if (!connectionMethod.MakeConnection())
										{
											machine.Status = DiscoveredMachineStatus.ConnectFailed;
											Manager.NotifyOnDiscoveredMachine(0, machine);
											return;
										}
									}
									byte[] userDataUTF = Manager.UserData.UserDataUTF8;
									machine.Status = DiscoveredMachineStatus.GetUserData;
									Manager.NotifyOnDiscoveredMachine(0, machine);
									if (protocol.SendCommandWithData(CommandType.CMD_EXTENDED_DISCOVERY, ref userDataUTF[0], (uint)userDataUTF.Length))
									{
										CommandPacket commandPacket = protocol.ReceiveCommand();
										if (commandPacket != null && commandPacket.Type == CommandType.CMD_EXTENDED_DISCOVERYREPLY && commandPacket.extraDataLength != 0U)
										{
											uint extraDataLength = commandPacket.extraDataLength;
											byte[] array = new byte[extraDataLength];
											commandPacket.GetExtraData(ref extraDataLength, ref array[0]);
											ConnectableMachine connectableMachine = new ConnectableMachine
											{
												FriendlyName = machine.NetName,
												CertificateName = machine.CertificateName,
												TransferMethodHandle = machine.TransferMethodHandle,
												Method = machine.Method,
												SerialNumber = "",
												CreationTime = DateTime.UtcNow,
												IsOld = true,
												ConnectionName = "Network",
												Status = DiscoveredMachineStatus.ManualConnection
											};
											machine.TransferMethodHandle = 0;
											UserData.parse(array, connectableMachine);
											connectableMachine.NetName = machine.NetName;
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
											connectionMethod.CloseConnection();
											connectableMachine = Manager.AddOrUpdateManualMachine(connectableMachine);
											Manager.NotifyOnDiscoveredMachine(0, connectableMachine);
											return;
										}
									}
									machine.Status = DiscoveredMachineStatus.CommunicationError;
									Manager.NotifyOnDiscoveredMachine(0, machine);
									connectionMethod.CloseConnection();
								}
								catch (Exception ex2)
								{
									Manager.Ts.TraceInformation("Exception in DiscoveryActivity::AddRemoteMachine: " + ex2.Message);
									machine.Status = DiscoveredMachineStatus.Exception;
									Manager.NotifyOnDiscoveredMachine(0, machine);
								}
								finally
								{
									if (machine.TransferMethodHandle != 0)
									{
										Manager.RemoveServiceTransferMethod(machine.TransferMethodHandle);
									}
								}
							}).Start();
							result = true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Manager.Ts.TraceInformation("Exception in AddRemoteMachine: " + ex.Message);
				machine.Status = DiscoveredMachineStatus.Exception;
				Manager.NotifyOnDiscoveredMachine(0, machine);
				result = false;
			}
			return result;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002DD8 File Offset: 0x00000FD8
		private ConnectableMachine FindConnectableMachine(RemoteMachine remoteMachine)
		{
			foreach (ConnectableMachine connectableMachine in this.m_machines)
			{
				if (connectableMachine.NetName == remoteMachine.Name && connectableMachine.Method == (remoteMachine.bUSB ? TransferMethodType.Usb : TransferMethodType.Network))
				{
					return connectableMachine;
				}
			}
			return null;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002E54 File Offset: 0x00001054
		private void RemoveConnectableMachine(ConnectableMachine connectable)
		{
			this.m_machines.Remove(connectable);
			connectable.Status = DiscoveredMachineStatus.MachineLost;
			base.Manager.NotifyOnDiscoveredMachine(this.Info.Handle, connectable);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002E81 File Offset: 0x00001081
		private ulong GetLinkSpeed(IConnectionMethod connectionMethod)
		{
			return Math.Min(connectionMethod.TransmitLinkSpeed, connectionMethod.ReceiveLinkSpeed);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002E94 File Offset: 0x00001094
		private ConnectableMachine CreateConnectableMachine(RemoteMachine machine)
		{
			ConnectableMachine connectableMachine = new ConnectableMachine
			{
				NetName = machine.Name,
				FriendlyName = machine.Name,
				CreationTime = DateTime.UtcNow,
				IsOld = true,
				SerialNumber = "",
				Status = DiscoveredMachineStatus.MachineFound
			};
			if (machine.bUSB)
			{
				connectableMachine.Method = TransferMethodType.Usb;
				connectableMachine.TransferMethodHandle = this.m_utm.Handle;
				connectableMachine.ConnectionName = "USB";
				connectableMachine.LinkSpeed = this.GetLinkSpeed(this.m_utm.UsbTransferMethod);
			}
			else
			{
				connectableMachine.Method = TransferMethodType.Network;
				connectableMachine.TransferMethodHandle = this.m_ntm.Handle;
				if (machine.bBonjour)
				{
					connectableMachine.ConnectionName = "Thunderbolt";
					connectableMachine.LinkSpeed = 20000000000UL;
				}
				else
				{
					connectableMachine.ConnectionName = "Network";
					connectableMachine.LinkSpeed = Math.Min(this.GetLinkSpeed(this.m_ntm.NetworkTransferMethod), 1000000000UL);
				}
			}
			if (machine.userDataLength != 0U)
			{
				UserData.parse(machine.UserData, connectableMachine);
			}
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
			return connectableMachine;
		}

		// Token: 0x0400000D RID: 13
		private ServiceNetworkTransferMethod m_ntm;

		// Token: 0x0400000E RID: 14
		private ServiceUsbTransferMethod m_utm;

		// Token: 0x0400000F RID: 15
		private List<ConnectableMachine> m_machines = new List<ConnectableMachine>();

		// Token: 0x04000010 RID: 16
		private object m_lock = new object();

		// Token: 0x04000011 RID: 17
		private bool m_bCallbacksEnabled;

		// Token: 0x04000012 RID: 18
		private int m_timeout = -1;

		// Token: 0x04000013 RID: 19
		private string m_serialNumber;
	}
}
