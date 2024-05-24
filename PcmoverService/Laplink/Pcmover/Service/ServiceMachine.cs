using System;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000020 RID: 32
	public class ServiceMachine : IDisposable
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001DB RID: 475 RVA: 0x0000F047 File Offset: 0x0000D247
		public Machine PcmMachine { get; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001DC RID: 476 RVA: 0x0000F050 File Offset: 0x0000D250
		public MachineData Data
		{
			get
			{
				if (this._data == null)
				{
					MachineType type;
					if (this.PcmMachine.IsThisMachine)
					{
						type = MachineType.This;
					}
					else if (this.PcmMachine.TreeStatus == TREE_STATUS.TS_NOSNAP)
					{
						type = MachineType.Any;
					}
					else if (this.PcmMachine.IsLive)
					{
						type = MachineType.Image;
					}
					else
					{
						type = MachineType.Snapshot;
					}
					this._data = new MachineData
					{
						Handle = this.Handle,
						Type = type,
						NetName = this.PcmMachine.NetName,
						FriendlyName = this.PcmMachine.FriendlyName,
						MachineId = this.PcmMachine.MachineId,
						Manufacturer = this.PcmMachine.Manufacturer,
						WindowsVersion = this.WindowsVersion,
						JoinedDomain = this.PcmMachine.JoinedDomain,
						IsJoinedToAzureAd = this.PcmMachine.IsJoinedToAzureAd,
						IsEngineRunningAsAdmin = this.PcmMachine.EngineRunningAsAdmin,
						Age = (this.PcmMachine.IsThisMachine ? MachineAge.GetMyCreationTime() : DateTime.Now),
						OemId = this.PcmMachine.OemId
					};
				}
				return this._data;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001DD RID: 477 RVA: 0x0000F175 File Offset: 0x0000D375
		// (set) Token: 0x060001DE RID: 478 RVA: 0x0000F17D File Offset: 0x0000D37D
		public int Handle { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001DF RID: 479 RVA: 0x0000F188 File Offset: 0x0000D388
		private WindowsVersionData WindowsVersion
		{
			get
			{
				int major;
				int minor;
				int build;
				int platform;
				int num;
				int num2;
				int num3;
				uint enablePreviewBuilds;
				bool is64Bit;
				string text;
				this.PcmMachine.GetOsVersionVariables(out major, out minor, out build, out platform, out num, out num2, out num3, out enablePreviewBuilds, out is64Bit, out text);
				WindowsVersionData windowsVersionData = new WindowsVersionData();
				windowsVersionData.Platform = platform;
				if (num2 == 0)
				{
					windowsVersionData.ServicePack = "";
				}
				else
				{
					windowsVersionData.ServicePack = string.Format("{0}.{1}", num2, num3);
				}
				windowsVersionData.Version = new Version(major, minor, build);
				windowsVersionData.VersionString = this.PcmMachine.WindowsVersionText;
				windowsVersionData.Is64Bit = is64Bit;
				if (num != 2)
				{
					if (num != 3)
					{
						windowsVersionData.ProductType = ProductType.Workstation;
					}
					else
					{
						windowsVersionData.ProductType = ProductType.Server;
					}
				}
				else
				{
					windowsVersionData.ProductType = ProductType.DomainController;
				}
				windowsVersionData.EnablePreviewBuilds = enablePreviewBuilds;
				windowsVersionData.WindowsEdition = this.PcmMachine.WindowsEdition;
				return windowsVersionData;
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0000F263 File Offset: 0x0000D463
		public ServiceMachine(Machine machine)
		{
			this.PcmMachine = machine;
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0000F272 File Offset: 0x0000D472
		public void Dispose()
		{
			this.PcmMachine.dispose();
		}

		// Token: 0x04000083 RID: 131
		private MachineData _data;
	}
}
