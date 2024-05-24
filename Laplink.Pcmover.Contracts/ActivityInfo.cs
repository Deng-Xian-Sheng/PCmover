using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000002 RID: 2
	public class ActivityInfo
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public ActivityInfo()
		{
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public ActivityInfo(ActivityInfo other)
		{
			this.Handle = other.Handle;
			this.Type = other.Type;
			this.State = other.State;
			this.Phase = other.Phase;
			this.FailureReason = other.FailureReason;
			this.Message = other.Message;
			this.StartTimeUtc = other.StartTimeUtc;
			this.EndTimeUtc = other.EndTimeUtc;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020CB File Offset: 0x000002CB
		// (set) Token: 0x06000004 RID: 4 RVA: 0x000020D3 File Offset: 0x000002D3
		public int Handle { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020DC File Offset: 0x000002DC
		// (set) Token: 0x06000006 RID: 6 RVA: 0x000020E4 File Offset: 0x000002E4
		public ActivityType Type { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020ED File Offset: 0x000002ED
		// (set) Token: 0x06000008 RID: 8 RVA: 0x000020F5 File Offset: 0x000002F5
		public ActivityState State { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020FE File Offset: 0x000002FE
		// (set) Token: 0x0600000A RID: 10 RVA: 0x00002106 File Offset: 0x00000306
		public int Phase { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000210F File Offset: 0x0000030F
		// (set) Token: 0x0600000C RID: 12 RVA: 0x00002117 File Offset: 0x00000317
		public int FailureReason { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002120 File Offset: 0x00000320
		// (set) Token: 0x0600000E RID: 14 RVA: 0x00002128 File Offset: 0x00000328
		public string Message { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002131 File Offset: 0x00000331
		// (set) Token: 0x06000010 RID: 16 RVA: 0x00002139 File Offset: 0x00000339
		public DateTime StartTimeUtc { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002142 File Offset: 0x00000342
		// (set) Token: 0x06000012 RID: 18 RVA: 0x0000214A File Offset: 0x0000034A
		public DateTime EndTimeUtc { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002153 File Offset: 0x00000353
		public bool IsDone
		{
			get
			{
				return this.State == ActivityState.Success || this.State == ActivityState.Failure;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002169 File Offset: 0x00000369
		public bool IsSucceeded
		{
			get
			{
				return this.State == ActivityState.Success;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002174 File Offset: 0x00000374
		public string FailureReasonString
		{
			get
			{
				string result;
				try
				{
					if (this.State == ActivityState.CreationFailed)
					{
						result = Enum.GetName(typeof(CreationFailedReason), this.FailureReason);
					}
					else
					{
						switch (this.Type)
						{
						case ActivityType.AppInventory:
							return Enum.GetName(typeof(ActivityFailureReason), this.FailureReason);
						case ActivityType.GetSnapshot:
							return Enum.GetName(typeof(GetSnapshotActivityFailureReason), this.FailureReason);
						case ActivityType.Transfer:
							return Enum.GetName(typeof(TransferActivityFailureReason), this.FailureReason);
						case ActivityType.Listen:
							return Enum.GetName(typeof(ListenActivityFailureReason), this.FailureReason);
						case ActivityType.Undo:
							return Enum.GetName(typeof(UndoActivityFailureReason), this.FailureReason);
						}
						result = Enum.GetName(typeof(ActivityFailureReason), this.FailureReason);
					}
				}
				catch (Exception ex)
				{
					result = ex.Message;
				}
				return result;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000022B8 File Offset: 0x000004B8
		public string PhaseString
		{
			get
			{
				string result;
				try
				{
					switch (this.Type)
					{
					case ActivityType.AppInventory:
						return Enum.GetName(typeof(AppInventoryActivityPhase), this.Phase);
					case ActivityType.GetSnapshot:
						return Enum.GetName(typeof(GetSnapshotActivityPhase), this.Phase);
					case ActivityType.BuildChangeLists:
						return Enum.GetName(typeof(BuildChangeListsActivityPhase), this.Phase);
					case ActivityType.SaveMovingVan:
						return Enum.GetName(typeof(SaveMovingVanActivityPhase), this.Phase);
					case ActivityType.Transfer:
						return Enum.GetName(typeof(TransferActivityPhase), this.Phase);
					case ActivityType.Listen:
						return Enum.GetName(typeof(ListenActivityPhase), this.Phase);
					case ActivityType.Undo:
						return Enum.GetName(typeof(UndoActivityPhase), this.Phase);
					case ActivityType.ExpandSnapshot:
						return Enum.GetName(typeof(ExpandSnapshotActivityPhase), this.Phase);
					}
					result = Enum.GetName(typeof(ActivityPhase), this.Phase);
				}
				catch (Exception ex)
				{
					result = ex.Message;
				}
				return result;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002438 File Offset: 0x00000638
		public string StateString
		{
			get
			{
				if (this.State != ActivityState.Failure)
				{
					return this.State.ToString();
				}
				return "Failure " + this.FailureReasonString;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002474 File Offset: 0x00000674
		public override string ToString()
		{
			string text = string.Format("{0} handle {1}, {2}", this.Type, this.Handle, this.StateString);
			if (!this.IsDone)
			{
				text = text + ", Phase " + this.PhaseString;
			}
			if (!string.IsNullOrWhiteSpace(this.Message))
			{
				text = text + " " + this.Message;
			}
			return text;
		}
	}
}
