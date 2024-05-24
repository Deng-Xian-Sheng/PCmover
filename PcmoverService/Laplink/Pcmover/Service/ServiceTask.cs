using System;
using System.Diagnostics;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000023 RID: 35
	public class ServiceTask : IDisposable
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x0000F3BE File Offset: 0x0000D5BE
		// (set) Token: 0x060001EA RID: 490 RVA: 0x0000F3C6 File Offset: 0x0000D5C6
		public IPcmTask Task { get; private set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001EB RID: 491 RVA: 0x0000F3CF File Offset: 0x0000D5CF
		// (set) Token: 0x060001EC RID: 492 RVA: 0x0000F402 File Offset: 0x0000D602
		public ServiceMachine SrcServiceMachine
		{
			get
			{
				if (this._srcServiceMachine == null)
				{
					PcmoverManager manager = this._manager;
					IPcmTask task = this.Task;
					this._srcServiceMachine = manager.GetServiceMachine((task != null) ? task.srcMachine : null);
				}
				return this._srcServiceMachine;
			}
			private set
			{
				this._srcServiceMachine = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001ED RID: 493 RVA: 0x0000F40B File Offset: 0x0000D60B
		// (set) Token: 0x060001EE RID: 494 RVA: 0x0000F43E File Offset: 0x0000D63E
		public ServiceMachine DstServiceMachine
		{
			get
			{
				if (this._dstServiceMachine == null)
				{
					PcmoverManager manager = this._manager;
					IPcmTask task = this.Task;
					this._dstServiceMachine = manager.GetServiceMachine((task != null) ? task.destMachine : null);
				}
				return this._dstServiceMachine;
			}
			private set
			{
				this._dstServiceMachine = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001EF RID: 495 RVA: 0x0000F447 File Offset: 0x0000D647
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x0000F44F File Offset: 0x0000D64F
		public int Handle { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x0000F458 File Offset: 0x0000D658
		// (set) Token: 0x060001F2 RID: 498 RVA: 0x0000F460 File Offset: 0x0000D660
		public bool RebuildRules
		{
			get
			{
				return this._updateRules;
			}
			set
			{
				if (value)
				{
					if (!this._updateRules)
					{
						this._updateRules = true;
						this._manager.Ts.TraceCaller(TraceEventType.Verbose, "Mark change lists to be recreated", "RebuildRules");
						this.RecreateChangeLists = true;
						this.RebuildDrives = true;
						return;
					}
				}
				else
				{
					this._updateRules = false;
				}
			}
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000F4B1 File Offset: 0x0000D6B1
		public ServiceTask(PcmoverManager manager, IPcmTask task, ServiceMachine srcServiceMachine, ServiceMachine dstServiceMachine)
		{
			this._manager = manager;
			this.Task = task;
			this.SrcServiceMachine = srcServiceMachine;
			this.DstServiceMachine = dstServiceMachine;
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0000F4D8 File Offset: 0x0000D6D8
		public void GetApps()
		{
			if (this.RematchApps)
			{
				FillVanTask fillVanTask = this.Task as FillVanTask;
				if (fillVanTask != null)
				{
					lock (this)
					{
						if (this.RematchApps)
						{
							fillVanTask.RematchApps();
							this.RematchApps = false;
						}
					}
				}
			}
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0000F53C File Offset: 0x0000D73C
		public void GetRules()
		{
			this.GetApps();
			if (this.RebuildRules)
			{
				FillVanTask fillVanTask = this.Task as FillVanTask;
				if (fillVanTask != null)
				{
					lock (this)
					{
						if (this.RebuildRules)
						{
							fillVanTask.UpdateRules();
							this.RebuildRules = false;
						}
					}
				}
			}
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0000F5A4 File Offset: 0x0000D7A4
		public void GetDrives()
		{
			this.GetRules();
			if (this.RebuildDrives && this.Task is FillVanTask)
			{
				lock (this)
				{
					if (this.RebuildDrives)
					{
						this.RebuildDrives = false;
					}
				}
			}
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000F604 File Offset: 0x0000D804
		public void GetChangeLists()
		{
			this.GetDrives();
			if (this.RecreateChangeLists)
			{
				FillVanTask fillVanTask = this.Task as FillVanTask;
				if (fillVanTask != null)
				{
					ServiceTask obj = this;
					lock (obj)
					{
						if (this.RecreateChangeLists)
						{
							this._manager.Ts.TraceCaller(TraceEventType.Verbose, "Call RecreateChangeLists", "GetChangeLists");
							fillVanTask.RecreateChangeLists();
							this.RecreateChangeLists = false;
							this.RebuildDiskItems = false;
							this.RebuildRegistryItems = false;
						}
					}
				}
				return;
			}
			if (this.RebuildDiskItems)
			{
				ServiceTask obj = this;
				lock (obj)
				{
					if (this.RebuildDiskItems)
					{
						this.Task.get_TaskItemRoot(ENUM_TTID.DISK_TTID).ResetChangeLists();
						this.RebuildDiskItems = false;
					}
				}
			}
			if (this.RebuildRegistryItems)
			{
				ServiceTask obj = this;
				lock (obj)
				{
					if (this.RebuildRegistryItems)
					{
						this.Task.get_TaskItemRoot(ENUM_TTID.REG_TTID).ResetChangeLists();
						this.RebuildRegistryItems = false;
					}
				}
			}
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000F734 File Offset: 0x0000D934
		public bool ContainsMachine(Machine machine)
		{
			if (machine == null)
			{
				return false;
			}
			ulong id = machine.Id;
			return (this.SrcServiceMachine != null && id == this.SrcServiceMachine.PcmMachine.Id) || (this.DstServiceMachine != null && id == this.DstServiceMachine.PcmMachine.Id);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000F788 File Offset: 0x0000D988
		public void Dispose()
		{
			this.Task.dispose();
		}

		// Token: 0x04000085 RID: 133
		private readonly PcmoverManager _manager;

		// Token: 0x04000087 RID: 135
		private ServiceMachine _srcServiceMachine;

		// Token: 0x04000088 RID: 136
		private ServiceMachine _dstServiceMachine;

		// Token: 0x0400008A RID: 138
		public AuthorizationRequestData AuthRequest;

		// Token: 0x0400008B RID: 139
		public bool RecreateChangeLists;

		// Token: 0x0400008C RID: 140
		public bool RebuildDiskItems;

		// Token: 0x0400008D RID: 141
		public bool RebuildRegistryItems;

		// Token: 0x0400008E RID: 142
		public bool RematchApps;

		// Token: 0x0400008F RID: 143
		public bool RebuildDrives;

		// Token: 0x04000090 RID: 144
		private bool _updateRules;
	}
}
