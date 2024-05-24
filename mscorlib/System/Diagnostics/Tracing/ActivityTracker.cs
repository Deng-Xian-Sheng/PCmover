using System;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200041A RID: 1050
	internal class ActivityTracker
	{
		// Token: 0x06003434 RID: 13364 RVA: 0x000C6CD0 File Offset: 0x000C4ED0
		public void OnStart(string providerName, string activityName, int task, ref Guid activityId, ref Guid relatedActivityId, EventActivityOptions options)
		{
			if (this.m_current == null)
			{
				if (this.m_checkedForEnable)
				{
					return;
				}
				this.m_checkedForEnable = true;
				if (TplEtwProvider.Log.IsEnabled(EventLevel.Informational, (EventKeywords)128L))
				{
					this.Enable();
				}
				if (this.m_current == null)
				{
					return;
				}
			}
			ActivityTracker.ActivityInfo value = this.m_current.Value;
			string text = this.NormalizeActivityName(providerName, activityName, task);
			TplEtwProvider log = TplEtwProvider.Log;
			if (log.Debug)
			{
				log.DebugFacilityMessage("OnStartEnter", text);
				log.DebugFacilityMessage("OnStartEnterActivityState", ActivityTracker.ActivityInfo.LiveActivities(value));
			}
			if (value != null)
			{
				if (value.m_level >= 100)
				{
					activityId = Guid.Empty;
					relatedActivityId = Guid.Empty;
					if (log.Debug)
					{
						log.DebugFacilityMessage("OnStartRET", "Fail");
					}
					return;
				}
				if ((options & EventActivityOptions.Recursive) == EventActivityOptions.None)
				{
					ActivityTracker.ActivityInfo activityInfo = this.FindActiveActivity(text, value);
					if (activityInfo != null)
					{
						this.OnStop(providerName, activityName, task, ref activityId);
						value = this.m_current.Value;
					}
				}
			}
			long uniqueId;
			if (value == null)
			{
				uniqueId = Interlocked.Increment(ref ActivityTracker.m_nextId);
			}
			else
			{
				uniqueId = Interlocked.Increment(ref value.m_lastChildID);
			}
			relatedActivityId = EventSource.CurrentThreadActivityId;
			ActivityTracker.ActivityInfo activityInfo2 = new ActivityTracker.ActivityInfo(text, uniqueId, value, relatedActivityId, options);
			this.m_current.Value = activityInfo2;
			activityId = activityInfo2.ActivityId;
			if (log.Debug)
			{
				log.DebugFacilityMessage("OnStartRetActivityState", ActivityTracker.ActivityInfo.LiveActivities(activityInfo2));
				log.DebugFacilityMessage1("OnStartRet", activityId.ToString(), relatedActivityId.ToString());
			}
		}

		// Token: 0x06003435 RID: 13365 RVA: 0x000C6E58 File Offset: 0x000C5058
		public void OnStop(string providerName, string activityName, int task, ref Guid activityId)
		{
			if (this.m_current == null)
			{
				return;
			}
			string text = this.NormalizeActivityName(providerName, activityName, task);
			TplEtwProvider log = TplEtwProvider.Log;
			if (log.Debug)
			{
				log.DebugFacilityMessage("OnStopEnter", text);
				log.DebugFacilityMessage("OnStopEnterActivityState", ActivityTracker.ActivityInfo.LiveActivities(this.m_current.Value));
			}
			ActivityTracker.ActivityInfo activityInfo;
			for (;;)
			{
				ActivityTracker.ActivityInfo value = this.m_current.Value;
				activityInfo = null;
				ActivityTracker.ActivityInfo activityInfo2 = this.FindActiveActivity(text, value);
				if (activityInfo2 == null)
				{
					break;
				}
				activityId = activityInfo2.ActivityId;
				ActivityTracker.ActivityInfo activityInfo3 = value;
				while (activityInfo3 != activityInfo2 && activityInfo3 != null)
				{
					if (activityInfo3.m_stopped != 0)
					{
						activityInfo3 = activityInfo3.m_creator;
					}
					else
					{
						if (activityInfo3.CanBeOrphan())
						{
							if (activityInfo == null)
							{
								activityInfo = activityInfo3;
							}
						}
						else
						{
							activityInfo3.m_stopped = 1;
						}
						activityInfo3 = activityInfo3.m_creator;
					}
				}
				if (Interlocked.CompareExchange(ref activityInfo2.m_stopped, 1, 0) == 0)
				{
					goto Block_9;
				}
			}
			activityId = Guid.Empty;
			if (log.Debug)
			{
				log.DebugFacilityMessage("OnStopRET", "Fail");
			}
			return;
			Block_9:
			if (activityInfo == null)
			{
				ActivityTracker.ActivityInfo activityInfo2;
				activityInfo = activityInfo2.m_creator;
			}
			this.m_current.Value = activityInfo;
			if (log.Debug)
			{
				log.DebugFacilityMessage("OnStopRetActivityState", ActivityTracker.ActivityInfo.LiveActivities(activityInfo));
				log.DebugFacilityMessage("OnStopRet", activityId.ToString());
			}
		}

		// Token: 0x06003436 RID: 13366 RVA: 0x000C6F9C File Offset: 0x000C519C
		[SecuritySafeCritical]
		public void Enable()
		{
			if (this.m_current == null)
			{
				this.m_current = new AsyncLocal<ActivityTracker.ActivityInfo>(new Action<AsyncLocalValueChangedArgs<ActivityTracker.ActivityInfo>>(this.ActivityChanging));
			}
		}

		// Token: 0x170007B9 RID: 1977
		// (get) Token: 0x06003437 RID: 13367 RVA: 0x000C6FBD File Offset: 0x000C51BD
		public static ActivityTracker Instance
		{
			get
			{
				return ActivityTracker.s_activityTrackerInstance;
			}
		}

		// Token: 0x170007BA RID: 1978
		// (get) Token: 0x06003438 RID: 13368 RVA: 0x000C6FC4 File Offset: 0x000C51C4
		private Guid CurrentActivityId
		{
			get
			{
				return this.m_current.Value.ActivityId;
			}
		}

		// Token: 0x06003439 RID: 13369 RVA: 0x000C6FD8 File Offset: 0x000C51D8
		private ActivityTracker.ActivityInfo FindActiveActivity(string name, ActivityTracker.ActivityInfo startLocation)
		{
			for (ActivityTracker.ActivityInfo activityInfo = startLocation; activityInfo != null; activityInfo = activityInfo.m_creator)
			{
				if (name == activityInfo.m_name && activityInfo.m_stopped == 0)
				{
					return activityInfo;
				}
			}
			return null;
		}

		// Token: 0x0600343A RID: 13370 RVA: 0x000C700C File Offset: 0x000C520C
		private string NormalizeActivityName(string providerName, string activityName, int task)
		{
			if (activityName.EndsWith("Start"))
			{
				activityName = activityName.Substring(0, activityName.Length - "Start".Length);
			}
			else if (activityName.EndsWith("Stop"))
			{
				activityName = activityName.Substring(0, activityName.Length - "Stop".Length);
			}
			else if (task != 0)
			{
				activityName = "task" + task.ToString();
			}
			return providerName + activityName;
		}

		// Token: 0x0600343B RID: 13371 RVA: 0x000C7088 File Offset: 0x000C5288
		private void ActivityChanging(AsyncLocalValueChangedArgs<ActivityTracker.ActivityInfo> args)
		{
			ActivityTracker.ActivityInfo activityInfo = args.CurrentValue;
			ActivityTracker.ActivityInfo previousValue = args.PreviousValue;
			if (previousValue != null && previousValue.m_creator == activityInfo && (activityInfo == null || previousValue.m_activityIdToRestore != activityInfo.ActivityId))
			{
				EventSource.SetCurrentThreadActivityId(previousValue.m_activityIdToRestore);
				return;
			}
			while (activityInfo != null)
			{
				if (activityInfo.m_stopped == 0)
				{
					EventSource.SetCurrentThreadActivityId(activityInfo.ActivityId);
					return;
				}
				activityInfo = activityInfo.m_creator;
			}
		}

		// Token: 0x04001720 RID: 5920
		private AsyncLocal<ActivityTracker.ActivityInfo> m_current;

		// Token: 0x04001721 RID: 5921
		private bool m_checkedForEnable;

		// Token: 0x04001722 RID: 5922
		private static ActivityTracker s_activityTrackerInstance = new ActivityTracker();

		// Token: 0x04001723 RID: 5923
		private static long m_nextId = 0L;

		// Token: 0x04001724 RID: 5924
		private const ushort MAX_ACTIVITY_DEPTH = 100;

		// Token: 0x02000B83 RID: 2947
		private class ActivityInfo
		{
			// Token: 0x06006C5B RID: 27739 RVA: 0x001773AC File Offset: 0x001755AC
			public ActivityInfo(string name, long uniqueId, ActivityTracker.ActivityInfo creator, Guid activityIDToRestore, EventActivityOptions options)
			{
				this.m_name = name;
				this.m_eventOptions = options;
				this.m_creator = creator;
				this.m_uniqueId = uniqueId;
				this.m_level = ((creator != null) ? (creator.m_level + 1) : 0);
				this.m_activityIdToRestore = activityIDToRestore;
				this.CreateActivityPathGuid(out this.m_guid, out this.m_activityPathGuidOffset);
			}

			// Token: 0x1700125B RID: 4699
			// (get) Token: 0x06006C5C RID: 27740 RVA: 0x0017740A File Offset: 0x0017560A
			public Guid ActivityId
			{
				get
				{
					return this.m_guid;
				}
			}

			// Token: 0x06006C5D RID: 27741 RVA: 0x00177414 File Offset: 0x00175614
			public static string Path(ActivityTracker.ActivityInfo activityInfo)
			{
				if (activityInfo == null)
				{
					return "";
				}
				return ActivityTracker.ActivityInfo.Path(activityInfo.m_creator) + "/" + activityInfo.m_uniqueId.ToString();
			}

			// Token: 0x06006C5E RID: 27742 RVA: 0x00177450 File Offset: 0x00175650
			public override string ToString()
			{
				string text = "";
				if (this.m_stopped != 0)
				{
					text = ",DEAD";
				}
				return string.Concat(new string[]
				{
					this.m_name,
					"(",
					ActivityTracker.ActivityInfo.Path(this),
					text,
					")"
				});
			}

			// Token: 0x06006C5F RID: 27743 RVA: 0x001774A2 File Offset: 0x001756A2
			public static string LiveActivities(ActivityTracker.ActivityInfo list)
			{
				if (list == null)
				{
					return "";
				}
				return list.ToString() + ";" + ActivityTracker.ActivityInfo.LiveActivities(list.m_creator);
			}

			// Token: 0x06006C60 RID: 27744 RVA: 0x001774C8 File Offset: 0x001756C8
			public bool CanBeOrphan()
			{
				return (this.m_eventOptions & EventActivityOptions.Detachable) != EventActivityOptions.None;
			}

			// Token: 0x06006C61 RID: 27745 RVA: 0x001774D8 File Offset: 0x001756D8
			[SecuritySafeCritical]
			private unsafe void CreateActivityPathGuid(out Guid idRet, out int activityPathGuidOffset)
			{
				fixed (Guid* ptr = &idRet)
				{
					Guid* outPtr = ptr;
					int whereToAddId = 0;
					if (this.m_creator != null)
					{
						whereToAddId = this.m_creator.m_activityPathGuidOffset;
						idRet = this.m_creator.m_guid;
					}
					else
					{
						int domainID = Thread.GetDomainID();
						whereToAddId = ActivityTracker.ActivityInfo.AddIdToGuid(outPtr, whereToAddId, (uint)domainID, false);
					}
					activityPathGuidOffset = ActivityTracker.ActivityInfo.AddIdToGuid(outPtr, whereToAddId, (uint)this.m_uniqueId, false);
					if (12 < activityPathGuidOffset)
					{
						this.CreateOverflowGuid(outPtr);
					}
				}
			}

			// Token: 0x06006C62 RID: 27746 RVA: 0x00177548 File Offset: 0x00175748
			[SecurityCritical]
			private unsafe void CreateOverflowGuid(Guid* outPtr)
			{
				for (ActivityTracker.ActivityInfo creator = this.m_creator; creator != null; creator = creator.m_creator)
				{
					if (creator.m_activityPathGuidOffset <= 10)
					{
						uint id = (uint)Interlocked.Increment(ref creator.m_lastChildID);
						*outPtr = creator.m_guid;
						int num = ActivityTracker.ActivityInfo.AddIdToGuid(outPtr, creator.m_activityPathGuidOffset, id, true);
						if (num <= 12)
						{
							break;
						}
					}
				}
			}

			// Token: 0x06006C63 RID: 27747 RVA: 0x001775A0 File Offset: 0x001757A0
			[SecurityCritical]
			private unsafe static int AddIdToGuid(Guid* outPtr, int whereToAddId, uint id, bool overflow = false)
			{
				byte* ptr = (byte*)outPtr;
				byte* ptr2 = ptr + 12;
				ptr += whereToAddId;
				if (ptr2 == ptr)
				{
					return 13;
				}
				if (0U < id && id <= 10U && !overflow)
				{
					ActivityTracker.ActivityInfo.WriteNibble(ref ptr, ptr2, id);
				}
				else
				{
					uint num = 4U;
					if (id <= 255U)
					{
						num = 1U;
					}
					else if (id <= 65535U)
					{
						num = 2U;
					}
					else if (id <= 16777215U)
					{
						num = 3U;
					}
					if (overflow)
					{
						if (ptr2 == ptr + 2)
						{
							return 13;
						}
						ActivityTracker.ActivityInfo.WriteNibble(ref ptr, ptr2, 11U);
					}
					ActivityTracker.ActivityInfo.WriteNibble(ref ptr, ptr2, 12U + (num - 1U));
					if (ptr < ptr2 && *ptr != 0)
					{
						if (id < 4096U)
						{
							*ptr = (byte)(192U + (id >> 8));
							id &= 255U;
						}
						ptr++;
					}
					while (0U < num)
					{
						if (ptr2 == ptr)
						{
							ptr++;
							break;
						}
						*(ptr++) = (byte)id;
						id >>= 8;
						num -= 1U;
					}
				}
				*(int*)(outPtr + (IntPtr)3 * 4 / (IntPtr)sizeof(Guid)) = (int)(*(uint*)outPtr + *(uint*)(outPtr + 4 / sizeof(Guid)) + *(uint*)(outPtr + (IntPtr)2 * 4 / (IntPtr)sizeof(Guid)) + 1503500717U);
				return (int)((long)((byte*)ptr - (byte*)outPtr));
			}

			// Token: 0x06006C64 RID: 27748 RVA: 0x00177690 File Offset: 0x00175890
			[SecurityCritical]
			private unsafe static void WriteNibble(ref byte* ptr, byte* endPtr, uint value)
			{
				if (*ptr != 0)
				{
					byte* ptr2 = ptr;
					ptr = ptr2 + 1;
					byte* ptr3 = ptr2;
					*ptr3 |= (byte)value;
					return;
				}
				*ptr = (byte)(value << 4);
			}

			// Token: 0x040034DC RID: 13532
			internal readonly string m_name;

			// Token: 0x040034DD RID: 13533
			private readonly long m_uniqueId;

			// Token: 0x040034DE RID: 13534
			internal readonly Guid m_guid;

			// Token: 0x040034DF RID: 13535
			internal readonly int m_activityPathGuidOffset;

			// Token: 0x040034E0 RID: 13536
			internal readonly int m_level;

			// Token: 0x040034E1 RID: 13537
			internal readonly EventActivityOptions m_eventOptions;

			// Token: 0x040034E2 RID: 13538
			internal long m_lastChildID;

			// Token: 0x040034E3 RID: 13539
			internal int m_stopped;

			// Token: 0x040034E4 RID: 13540
			internal readonly ActivityTracker.ActivityInfo m_creator;

			// Token: 0x040034E5 RID: 13541
			internal readonly Guid m_activityIdToRestore;

			// Token: 0x02000D01 RID: 3329
			private enum NumberListCodes : byte
			{
				// Token: 0x0400392D RID: 14637
				End,
				// Token: 0x0400392E RID: 14638
				LastImmediateValue = 10,
				// Token: 0x0400392F RID: 14639
				PrefixCode,
				// Token: 0x04003930 RID: 14640
				MultiByte1
			}
		}
	}
}
