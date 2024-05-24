using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Threading.Tasks
{
	// Token: 0x02000586 RID: 1414
	[EventSource(Name = "System.Threading.Tasks.TplEventSource", Guid = "2e5dba47-a3d2-4d16-8ee0-6671ffdcd7b5", LocalizationResources = "mscorlib")]
	internal sealed class TplEtwProvider : EventSource
	{
		// Token: 0x06004276 RID: 17014 RVA: 0x000F7918 File Offset: 0x000F5B18
		protected override void OnEventCommand(EventCommandEventArgs command)
		{
			if (command.Command == EventCommand.Enable)
			{
				AsyncCausalityTracer.EnableToETW(true);
			}
			else if (command.Command == EventCommand.Disable)
			{
				AsyncCausalityTracer.EnableToETW(false);
			}
			if (base.IsEnabled(EventLevel.Informational, (EventKeywords)128L))
			{
				ActivityTracker.Instance.Enable();
			}
			else
			{
				this.TasksSetActivityIds = base.IsEnabled(EventLevel.Informational, (EventKeywords)65536L);
			}
			this.Debug = base.IsEnabled(EventLevel.Informational, (EventKeywords)131072L);
			this.DebugActivityId = base.IsEnabled(EventLevel.Informational, (EventKeywords)262144L);
		}

		// Token: 0x06004277 RID: 17015 RVA: 0x000F799B File Offset: 0x000F5B9B
		private TplEtwProvider()
		{
		}

		// Token: 0x06004278 RID: 17016 RVA: 0x000F79A4 File Offset: 0x000F5BA4
		[SecuritySafeCritical]
		[Event(1, Level = EventLevel.Informational, ActivityOptions = EventActivityOptions.Recursive, Task = (EventTask)1, Opcode = EventOpcode.Start)]
		public unsafe void ParallelLoopBegin(int OriginatingTaskSchedulerID, int OriginatingTaskID, int ForkJoinContextID, TplEtwProvider.ForkJoinOperationType OperationType, long InclusiveFrom, long ExclusiveTo)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Informational, (EventKeywords)4L))
			{
				EventSource.EventData* ptr = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)6) * (UIntPtr)sizeof(EventSource.EventData))];
				ptr->Size = 4;
				ptr->DataPointer = (IntPtr)((void*)(&OriginatingTaskSchedulerID));
				ptr[1].Size = 4;
				ptr[1].DataPointer = (IntPtr)((void*)(&OriginatingTaskID));
				ptr[2].Size = 4;
				ptr[2].DataPointer = (IntPtr)((void*)(&ForkJoinContextID));
				ptr[3].Size = 4;
				ptr[3].DataPointer = (IntPtr)((void*)(&OperationType));
				ptr[4].Size = 8;
				ptr[4].DataPointer = (IntPtr)((void*)(&InclusiveFrom));
				ptr[5].Size = 8;
				ptr[5].DataPointer = (IntPtr)((void*)(&ExclusiveTo));
				base.WriteEventCore(1, 6, ptr);
			}
		}

		// Token: 0x06004279 RID: 17017 RVA: 0x000F7ABC File Offset: 0x000F5CBC
		[SecuritySafeCritical]
		[Event(2, Level = EventLevel.Informational, Task = (EventTask)1, Opcode = EventOpcode.Stop)]
		public unsafe void ParallelLoopEnd(int OriginatingTaskSchedulerID, int OriginatingTaskID, int ForkJoinContextID, long TotalIterations)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Informational, (EventKeywords)4L))
			{
				EventSource.EventData* ptr = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)4) * (UIntPtr)sizeof(EventSource.EventData))];
				ptr->Size = 4;
				ptr->DataPointer = (IntPtr)((void*)(&OriginatingTaskSchedulerID));
				ptr[1].Size = 4;
				ptr[1].DataPointer = (IntPtr)((void*)(&OriginatingTaskID));
				ptr[2].Size = 4;
				ptr[2].DataPointer = (IntPtr)((void*)(&ForkJoinContextID));
				ptr[3].Size = 8;
				ptr[3].DataPointer = (IntPtr)((void*)(&TotalIterations));
				base.WriteEventCore(2, 4, ptr);
			}
		}

		// Token: 0x0600427A RID: 17018 RVA: 0x000F7B84 File Offset: 0x000F5D84
		[SecuritySafeCritical]
		[Event(3, Level = EventLevel.Informational, ActivityOptions = EventActivityOptions.Recursive, Task = (EventTask)2, Opcode = EventOpcode.Start)]
		public unsafe void ParallelInvokeBegin(int OriginatingTaskSchedulerID, int OriginatingTaskID, int ForkJoinContextID, TplEtwProvider.ForkJoinOperationType OperationType, int ActionCount)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Informational, (EventKeywords)4L))
			{
				EventSource.EventData* ptr = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)5) * (UIntPtr)sizeof(EventSource.EventData))];
				ptr->Size = 4;
				ptr->DataPointer = (IntPtr)((void*)(&OriginatingTaskSchedulerID));
				ptr[1].Size = 4;
				ptr[1].DataPointer = (IntPtr)((void*)(&OriginatingTaskID));
				ptr[2].Size = 4;
				ptr[2].DataPointer = (IntPtr)((void*)(&ForkJoinContextID));
				ptr[3].Size = 4;
				ptr[3].DataPointer = (IntPtr)((void*)(&OperationType));
				ptr[4].Size = 4;
				ptr[4].DataPointer = (IntPtr)((void*)(&ActionCount));
				base.WriteEventCore(3, 5, ptr);
			}
		}

		// Token: 0x0600427B RID: 17019 RVA: 0x000F7C72 File Offset: 0x000F5E72
		[Event(4, Level = EventLevel.Informational, Task = (EventTask)2, Opcode = EventOpcode.Stop)]
		public void ParallelInvokeEnd(int OriginatingTaskSchedulerID, int OriginatingTaskID, int ForkJoinContextID)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Informational, (EventKeywords)4L))
			{
				base.WriteEvent(4, OriginatingTaskSchedulerID, OriginatingTaskID, ForkJoinContextID);
			}
		}

		// Token: 0x0600427C RID: 17020 RVA: 0x000F7C91 File Offset: 0x000F5E91
		[Event(5, Level = EventLevel.Verbose, ActivityOptions = EventActivityOptions.Recursive, Task = (EventTask)5, Opcode = EventOpcode.Start)]
		public void ParallelFork(int OriginatingTaskSchedulerID, int OriginatingTaskID, int ForkJoinContextID)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Verbose, (EventKeywords)4L))
			{
				base.WriteEvent(5, OriginatingTaskSchedulerID, OriginatingTaskID, ForkJoinContextID);
			}
		}

		// Token: 0x0600427D RID: 17021 RVA: 0x000F7CB0 File Offset: 0x000F5EB0
		[Event(6, Level = EventLevel.Verbose, Task = (EventTask)5, Opcode = EventOpcode.Stop)]
		public void ParallelJoin(int OriginatingTaskSchedulerID, int OriginatingTaskID, int ForkJoinContextID)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Verbose, (EventKeywords)4L))
			{
				base.WriteEvent(6, OriginatingTaskSchedulerID, OriginatingTaskID, ForkJoinContextID);
			}
		}

		// Token: 0x0600427E RID: 17022 RVA: 0x000F7CD0 File Offset: 0x000F5ED0
		[SecuritySafeCritical]
		[Event(7, Task = (EventTask)6, Version = 1, Opcode = EventOpcode.Send, Level = EventLevel.Informational, Keywords = (EventKeywords)3L)]
		public unsafe void TaskScheduled(int OriginatingTaskSchedulerID, int OriginatingTaskID, int TaskID, int CreatingTaskID, int TaskCreationOptions, int appDomain)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Informational, (EventKeywords)3L))
			{
				EventSource.EventData* ptr = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)5) * (UIntPtr)sizeof(EventSource.EventData))];
				ptr->Size = 4;
				ptr->DataPointer = (IntPtr)((void*)(&OriginatingTaskSchedulerID));
				ptr[1].Size = 4;
				ptr[1].DataPointer = (IntPtr)((void*)(&OriginatingTaskID));
				ptr[2].Size = 4;
				ptr[2].DataPointer = (IntPtr)((void*)(&TaskID));
				ptr[3].Size = 4;
				ptr[3].DataPointer = (IntPtr)((void*)(&CreatingTaskID));
				ptr[4].Size = 4;
				ptr[4].DataPointer = (IntPtr)((void*)(&TaskCreationOptions));
				if (this.TasksSetActivityIds)
				{
					Guid guid = TplEtwProvider.CreateGuidForTaskID(TaskID);
					base.WriteEventWithRelatedActivityIdCore(7, &guid, 5, ptr);
					return;
				}
				base.WriteEventCore(7, 5, ptr);
			}
		}

		// Token: 0x0600427F RID: 17023 RVA: 0x000F7DDA File Offset: 0x000F5FDA
		[Event(8, Level = EventLevel.Informational, Keywords = (EventKeywords)2L)]
		public void TaskStarted(int OriginatingTaskSchedulerID, int OriginatingTaskID, int TaskID)
		{
			if (base.IsEnabled(EventLevel.Informational, (EventKeywords)2L))
			{
				base.WriteEvent(8, OriginatingTaskSchedulerID, OriginatingTaskID, TaskID);
			}
		}

		// Token: 0x06004280 RID: 17024 RVA: 0x000F7DF4 File Offset: 0x000F5FF4
		[SecuritySafeCritical]
		[Event(9, Version = 1, Level = EventLevel.Informational, Keywords = (EventKeywords)64L)]
		public unsafe void TaskCompleted(int OriginatingTaskSchedulerID, int OriginatingTaskID, int TaskID, bool IsExceptional)
		{
			if (base.IsEnabled(EventLevel.Informational, (EventKeywords)2L))
			{
				EventSource.EventData* ptr = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)4) * (UIntPtr)sizeof(EventSource.EventData))];
				int num = IsExceptional ? 1 : 0;
				ptr->Size = 4;
				ptr->DataPointer = (IntPtr)((void*)(&OriginatingTaskSchedulerID));
				ptr[1].Size = 4;
				ptr[1].DataPointer = (IntPtr)((void*)(&OriginatingTaskID));
				ptr[2].Size = 4;
				ptr[2].DataPointer = (IntPtr)((void*)(&TaskID));
				ptr[3].Size = 4;
				ptr[3].DataPointer = (IntPtr)((void*)(&num));
				base.WriteEventCore(9, 4, ptr);
			}
		}

		// Token: 0x06004281 RID: 17025 RVA: 0x000F7EB8 File Offset: 0x000F60B8
		[SecuritySafeCritical]
		[Event(10, Version = 3, Task = (EventTask)4, Opcode = EventOpcode.Send, Level = EventLevel.Informational, Keywords = (EventKeywords)3L)]
		public unsafe void TaskWaitBegin(int OriginatingTaskSchedulerID, int OriginatingTaskID, int TaskID, TplEtwProvider.TaskWaitBehavior Behavior, int ContinueWithTaskID, int appDomain)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Informational, (EventKeywords)3L))
			{
				EventSource.EventData* ptr = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)5) * (UIntPtr)sizeof(EventSource.EventData))];
				ptr->Size = 4;
				ptr->DataPointer = (IntPtr)((void*)(&OriginatingTaskSchedulerID));
				ptr[1].Size = 4;
				ptr[1].DataPointer = (IntPtr)((void*)(&OriginatingTaskID));
				ptr[2].Size = 4;
				ptr[2].DataPointer = (IntPtr)((void*)(&TaskID));
				ptr[3].Size = 4;
				ptr[3].DataPointer = (IntPtr)((void*)(&Behavior));
				ptr[4].Size = 4;
				ptr[4].DataPointer = (IntPtr)((void*)(&ContinueWithTaskID));
				if (this.TasksSetActivityIds)
				{
					Guid guid = TplEtwProvider.CreateGuidForTaskID(TaskID);
					base.WriteEventWithRelatedActivityIdCore(10, &guid, 5, ptr);
					return;
				}
				base.WriteEventCore(10, 5, ptr);
			}
		}

		// Token: 0x06004282 RID: 17026 RVA: 0x000F7FC4 File Offset: 0x000F61C4
		[Event(11, Level = EventLevel.Verbose, Keywords = (EventKeywords)2L)]
		public void TaskWaitEnd(int OriginatingTaskSchedulerID, int OriginatingTaskID, int TaskID)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Verbose, (EventKeywords)2L))
			{
				base.WriteEvent(11, OriginatingTaskSchedulerID, OriginatingTaskID, TaskID);
			}
		}

		// Token: 0x06004283 RID: 17027 RVA: 0x000F7FE4 File Offset: 0x000F61E4
		[Event(13, Level = EventLevel.Verbose, Keywords = (EventKeywords)64L)]
		public void TaskWaitContinuationComplete(int TaskID)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Verbose, (EventKeywords)2L))
			{
				base.WriteEvent(13, TaskID);
			}
		}

		// Token: 0x06004284 RID: 17028 RVA: 0x000F8002 File Offset: 0x000F6202
		[Event(19, Level = EventLevel.Verbose, Keywords = (EventKeywords)64L)]
		public void TaskWaitContinuationStarted(int TaskID)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Verbose, (EventKeywords)2L))
			{
				base.WriteEvent(19, TaskID);
			}
		}

		// Token: 0x06004285 RID: 17029 RVA: 0x000F8020 File Offset: 0x000F6220
		[SecuritySafeCritical]
		[Event(12, Task = (EventTask)7, Opcode = EventOpcode.Send, Level = EventLevel.Informational, Keywords = (EventKeywords)3L)]
		public unsafe void AwaitTaskContinuationScheduled(int OriginatingTaskSchedulerID, int OriginatingTaskID, int ContinuwWithTaskId)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Informational, (EventKeywords)3L))
			{
				EventSource.EventData* ptr = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)3) * (UIntPtr)sizeof(EventSource.EventData))];
				ptr->Size = 4;
				ptr->DataPointer = (IntPtr)((void*)(&OriginatingTaskSchedulerID));
				ptr[1].Size = 4;
				ptr[1].DataPointer = (IntPtr)((void*)(&OriginatingTaskID));
				ptr[2].Size = 4;
				ptr[2].DataPointer = (IntPtr)((void*)(&ContinuwWithTaskId));
				if (this.TasksSetActivityIds)
				{
					Guid guid = TplEtwProvider.CreateGuidForTaskID(ContinuwWithTaskId);
					base.WriteEventWithRelatedActivityIdCore(12, &guid, 3, ptr);
					return;
				}
				base.WriteEventCore(12, 3, ptr);
			}
		}

		// Token: 0x06004286 RID: 17030 RVA: 0x000F80DC File Offset: 0x000F62DC
		[SecuritySafeCritical]
		[Event(14, Version = 1, Level = EventLevel.Informational, Keywords = (EventKeywords)8L)]
		public unsafe void TraceOperationBegin(int TaskID, string OperationName, long RelatedContext)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Informational, (EventKeywords)8L))
			{
				fixed (string text = OperationName)
				{
					char* ptr = text;
					if (ptr != null)
					{
						ptr += RuntimeHelpers.OffsetToStringData / 2;
					}
					EventSource.EventData* ptr2 = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)3) * (UIntPtr)sizeof(EventSource.EventData))];
					ptr2->Size = 4;
					ptr2->DataPointer = (IntPtr)((void*)(&TaskID));
					ptr2[1].Size = (OperationName.Length + 1) * 2;
					ptr2[1].DataPointer = (IntPtr)((void*)ptr);
					ptr2[2].Size = 8;
					ptr2[2].DataPointer = (IntPtr)((void*)(&RelatedContext));
					base.WriteEventCore(14, 3, ptr2);
				}
			}
		}

		// Token: 0x06004287 RID: 17031 RVA: 0x000F8192 File Offset: 0x000F6392
		[SecuritySafeCritical]
		[Event(16, Version = 1, Level = EventLevel.Informational, Keywords = (EventKeywords)16L)]
		public void TraceOperationRelation(int TaskID, CausalityRelation Relation)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Informational, (EventKeywords)16L))
			{
				base.WriteEvent(16, TaskID, (int)Relation);
			}
		}

		// Token: 0x06004288 RID: 17032 RVA: 0x000F81B2 File Offset: 0x000F63B2
		[SecuritySafeCritical]
		[Event(15, Version = 1, Level = EventLevel.Informational, Keywords = (EventKeywords)8L)]
		public void TraceOperationEnd(int TaskID, AsyncCausalityStatus Status)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Informational, (EventKeywords)8L))
			{
				base.WriteEvent(15, TaskID, (int)Status);
			}
		}

		// Token: 0x06004289 RID: 17033 RVA: 0x000F81D1 File Offset: 0x000F63D1
		[SecuritySafeCritical]
		[Event(17, Version = 1, Level = EventLevel.Informational, Keywords = (EventKeywords)32L)]
		public void TraceSynchronousWorkBegin(int TaskID, CausalitySynchronousWork Work)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Informational, (EventKeywords)32L))
			{
				base.WriteEvent(17, TaskID, (int)Work);
			}
		}

		// Token: 0x0600428A RID: 17034 RVA: 0x000F81F4 File Offset: 0x000F63F4
		[SecuritySafeCritical]
		[Event(18, Version = 1, Level = EventLevel.Informational, Keywords = (EventKeywords)32L)]
		public unsafe void TraceSynchronousWorkEnd(CausalitySynchronousWork Work)
		{
			if (base.IsEnabled() && base.IsEnabled(EventLevel.Informational, (EventKeywords)32L))
			{
				EventSource.EventData* ptr = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)1) * (UIntPtr)sizeof(EventSource.EventData))];
				ptr->Size = 4;
				ptr->DataPointer = (IntPtr)((void*)(&Work));
				base.WriteEventCore(18, 1, ptr);
			}
		}

		// Token: 0x0600428B RID: 17035 RVA: 0x000F8240 File Offset: 0x000F6440
		[NonEvent]
		[SecuritySafeCritical]
		public unsafe void RunningContinuation(int TaskID, object Object)
		{
			this.RunningContinuation(TaskID, (long)((ulong)(*(IntPtr*)((void*)JitHelpers.UnsafeCastToStackPointer<object>(ref Object)))));
		}

		// Token: 0x0600428C RID: 17036 RVA: 0x000F8257 File Offset: 0x000F6457
		[Event(20, Keywords = (EventKeywords)131072L)]
		private void RunningContinuation(int TaskID, long Object)
		{
			if (this.Debug)
			{
				base.WriteEvent(20, (long)TaskID, Object);
			}
		}

		// Token: 0x0600428D RID: 17037 RVA: 0x000F826C File Offset: 0x000F646C
		[NonEvent]
		[SecuritySafeCritical]
		public unsafe void RunningContinuationList(int TaskID, int Index, object Object)
		{
			this.RunningContinuationList(TaskID, Index, (long)((ulong)(*(IntPtr*)((void*)JitHelpers.UnsafeCastToStackPointer<object>(ref Object)))));
		}

		// Token: 0x0600428E RID: 17038 RVA: 0x000F8284 File Offset: 0x000F6484
		[Event(21, Keywords = (EventKeywords)131072L)]
		public void RunningContinuationList(int TaskID, int Index, long Object)
		{
			if (this.Debug)
			{
				base.WriteEvent(21, (long)TaskID, (long)Index, Object);
			}
		}

		// Token: 0x0600428F RID: 17039 RVA: 0x000F829B File Offset: 0x000F649B
		[Event(22, Keywords = (EventKeywords)131072L)]
		public void DebugMessage(string Message)
		{
			base.WriteEvent(22, Message);
		}

		// Token: 0x06004290 RID: 17040 RVA: 0x000F82A6 File Offset: 0x000F64A6
		[Event(23, Keywords = (EventKeywords)131072L)]
		public void DebugFacilityMessage(string Facility, string Message)
		{
			base.WriteEvent(23, Facility, Message);
		}

		// Token: 0x06004291 RID: 17041 RVA: 0x000F82B2 File Offset: 0x000F64B2
		[Event(24, Keywords = (EventKeywords)131072L)]
		public void DebugFacilityMessage1(string Facility, string Message, string Value1)
		{
			base.WriteEvent(24, Facility, Message, Value1);
		}

		// Token: 0x06004292 RID: 17042 RVA: 0x000F82BF File Offset: 0x000F64BF
		[Event(25, Keywords = (EventKeywords)262144L)]
		public void SetActivityId(Guid NewId)
		{
			if (this.DebugActivityId)
			{
				base.WriteEvent(25, new object[]
				{
					NewId
				});
			}
		}

		// Token: 0x06004293 RID: 17043 RVA: 0x000F82E0 File Offset: 0x000F64E0
		[Event(26, Keywords = (EventKeywords)131072L)]
		public void NewID(int TaskID)
		{
			if (this.Debug)
			{
				base.WriteEvent(26, TaskID);
			}
		}

		// Token: 0x06004294 RID: 17044 RVA: 0x000F82F4 File Offset: 0x000F64F4
		internal static Guid CreateGuidForTaskID(int taskID)
		{
			uint s_currentPid = EventSource.s_currentPid;
			int domainID = Thread.GetDomainID();
			return new Guid(taskID, (short)domainID, (short)(domainID >> 16), (byte)s_currentPid, (byte)(s_currentPid >> 8), (byte)(s_currentPid >> 16), (byte)(s_currentPid >> 24), byte.MaxValue, 220, 215, 181);
		}

		// Token: 0x04001B99 RID: 7065
		internal bool TasksSetActivityIds;

		// Token: 0x04001B9A RID: 7066
		internal bool Debug;

		// Token: 0x04001B9B RID: 7067
		private bool DebugActivityId;

		// Token: 0x04001B9C RID: 7068
		public static TplEtwProvider Log = new TplEtwProvider();

		// Token: 0x04001B9D RID: 7069
		private const EventKeywords ALL_KEYWORDS = EventKeywords.All;

		// Token: 0x04001B9E RID: 7070
		private const int PARALLELLOOPBEGIN_ID = 1;

		// Token: 0x04001B9F RID: 7071
		private const int PARALLELLOOPEND_ID = 2;

		// Token: 0x04001BA0 RID: 7072
		private const int PARALLELINVOKEBEGIN_ID = 3;

		// Token: 0x04001BA1 RID: 7073
		private const int PARALLELINVOKEEND_ID = 4;

		// Token: 0x04001BA2 RID: 7074
		private const int PARALLELFORK_ID = 5;

		// Token: 0x04001BA3 RID: 7075
		private const int PARALLELJOIN_ID = 6;

		// Token: 0x04001BA4 RID: 7076
		private const int TASKSCHEDULED_ID = 7;

		// Token: 0x04001BA5 RID: 7077
		private const int TASKSTARTED_ID = 8;

		// Token: 0x04001BA6 RID: 7078
		private const int TASKCOMPLETED_ID = 9;

		// Token: 0x04001BA7 RID: 7079
		private const int TASKWAITBEGIN_ID = 10;

		// Token: 0x04001BA8 RID: 7080
		private const int TASKWAITEND_ID = 11;

		// Token: 0x04001BA9 RID: 7081
		private const int AWAITTASKCONTINUATIONSCHEDULED_ID = 12;

		// Token: 0x04001BAA RID: 7082
		private const int TASKWAITCONTINUATIONCOMPLETE_ID = 13;

		// Token: 0x04001BAB RID: 7083
		private const int TASKWAITCONTINUATIONSTARTED_ID = 19;

		// Token: 0x04001BAC RID: 7084
		private const int TRACEOPERATIONSTART_ID = 14;

		// Token: 0x04001BAD RID: 7085
		private const int TRACEOPERATIONSTOP_ID = 15;

		// Token: 0x04001BAE RID: 7086
		private const int TRACEOPERATIONRELATION_ID = 16;

		// Token: 0x04001BAF RID: 7087
		private const int TRACESYNCHRONOUSWORKSTART_ID = 17;

		// Token: 0x04001BB0 RID: 7088
		private const int TRACESYNCHRONOUSWORKSTOP_ID = 18;

		// Token: 0x02000C2D RID: 3117
		public enum ForkJoinOperationType
		{
			// Token: 0x040036FF RID: 14079
			ParallelInvoke = 1,
			// Token: 0x04003700 RID: 14080
			ParallelFor,
			// Token: 0x04003701 RID: 14081
			ParallelForEach
		}

		// Token: 0x02000C2E RID: 3118
		public enum TaskWaitBehavior
		{
			// Token: 0x04003703 RID: 14083
			Synchronous = 1,
			// Token: 0x04003704 RID: 14084
			Asynchronous
		}

		// Token: 0x02000C2F RID: 3119
		public class Tasks
		{
			// Token: 0x04003705 RID: 14085
			public const EventTask Loop = (EventTask)1;

			// Token: 0x04003706 RID: 14086
			public const EventTask Invoke = (EventTask)2;

			// Token: 0x04003707 RID: 14087
			public const EventTask TaskExecute = (EventTask)3;

			// Token: 0x04003708 RID: 14088
			public const EventTask TaskWait = (EventTask)4;

			// Token: 0x04003709 RID: 14089
			public const EventTask ForkJoin = (EventTask)5;

			// Token: 0x0400370A RID: 14090
			public const EventTask TaskScheduled = (EventTask)6;

			// Token: 0x0400370B RID: 14091
			public const EventTask AwaitTaskContinuationScheduled = (EventTask)7;

			// Token: 0x0400370C RID: 14092
			public const EventTask TraceOperation = (EventTask)8;

			// Token: 0x0400370D RID: 14093
			public const EventTask TraceSynchronousWork = (EventTask)9;
		}

		// Token: 0x02000C30 RID: 3120
		public class Keywords
		{
			// Token: 0x0400370E RID: 14094
			public const EventKeywords TaskTransfer = (EventKeywords)1L;

			// Token: 0x0400370F RID: 14095
			public const EventKeywords Tasks = (EventKeywords)2L;

			// Token: 0x04003710 RID: 14096
			public const EventKeywords Parallel = (EventKeywords)4L;

			// Token: 0x04003711 RID: 14097
			public const EventKeywords AsyncCausalityOperation = (EventKeywords)8L;

			// Token: 0x04003712 RID: 14098
			public const EventKeywords AsyncCausalityRelation = (EventKeywords)16L;

			// Token: 0x04003713 RID: 14099
			public const EventKeywords AsyncCausalitySynchronousWork = (EventKeywords)32L;

			// Token: 0x04003714 RID: 14100
			public const EventKeywords TaskStops = (EventKeywords)64L;

			// Token: 0x04003715 RID: 14101
			public const EventKeywords TasksFlowActivityIds = (EventKeywords)128L;

			// Token: 0x04003716 RID: 14102
			public const EventKeywords TasksSetActivityIds = (EventKeywords)65536L;

			// Token: 0x04003717 RID: 14103
			public const EventKeywords Debug = (EventKeywords)131072L;

			// Token: 0x04003718 RID: 14104
			public const EventKeywords DebugActivityId = (EventKeywords)262144L;
		}
	}
}
