using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Security;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000424 RID: 1060
	[__DynamicallyInvokable]
	public class EventWrittenEventArgs : EventArgs
	{
		// Token: 0x170007D3 RID: 2003
		// (get) Token: 0x0600350C RID: 13580 RVA: 0x000CE319 File Offset: 0x000CC519
		// (set) Token: 0x0600350D RID: 13581 RVA: 0x000CE350 File Offset: 0x000CC550
		[__DynamicallyInvokable]
		public string EventName
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.m_eventName != null || this.EventId < 0)
				{
					return this.m_eventName;
				}
				return this.m_eventSource.m_eventData[this.EventId].Name;
			}
			internal set
			{
				this.m_eventName = value;
			}
		}

		// Token: 0x170007D4 RID: 2004
		// (get) Token: 0x0600350E RID: 13582 RVA: 0x000CE359 File Offset: 0x000CC559
		// (set) Token: 0x0600350F RID: 13583 RVA: 0x000CE361 File Offset: 0x000CC561
		[__DynamicallyInvokable]
		public int EventId { [__DynamicallyInvokable] get; internal set; }

		// Token: 0x170007D5 RID: 2005
		// (get) Token: 0x06003510 RID: 13584 RVA: 0x000CE36C File Offset: 0x000CC56C
		// (set) Token: 0x06003511 RID: 13585 RVA: 0x000CE394 File Offset: 0x000CC594
		[__DynamicallyInvokable]
		public Guid ActivityId
		{
			[SecurityCritical]
			[__DynamicallyInvokable]
			get
			{
				Guid guid = this.m_activityId;
				if (guid == Guid.Empty)
				{
					guid = EventSource.CurrentThreadActivityId;
				}
				return guid;
			}
			internal set
			{
				this.m_activityId = value;
			}
		}

		// Token: 0x170007D6 RID: 2006
		// (get) Token: 0x06003512 RID: 13586 RVA: 0x000CE39D File Offset: 0x000CC59D
		// (set) Token: 0x06003513 RID: 13587 RVA: 0x000CE3A5 File Offset: 0x000CC5A5
		[__DynamicallyInvokable]
		public Guid RelatedActivityId { [SecurityCritical] [__DynamicallyInvokable] get; internal set; }

		// Token: 0x170007D7 RID: 2007
		// (get) Token: 0x06003514 RID: 13588 RVA: 0x000CE3AE File Offset: 0x000CC5AE
		// (set) Token: 0x06003515 RID: 13589 RVA: 0x000CE3B6 File Offset: 0x000CC5B6
		[__DynamicallyInvokable]
		public ReadOnlyCollection<object> Payload { [__DynamicallyInvokable] get; internal set; }

		// Token: 0x170007D8 RID: 2008
		// (get) Token: 0x06003516 RID: 13590 RVA: 0x000CE3C0 File Offset: 0x000CC5C0
		// (set) Token: 0x06003517 RID: 13591 RVA: 0x000CE429 File Offset: 0x000CC629
		[__DynamicallyInvokable]
		public ReadOnlyCollection<string> PayloadNames
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.m_payloadNames == null)
				{
					List<string> list = new List<string>();
					foreach (ParameterInfo parameterInfo in this.m_eventSource.m_eventData[this.EventId].Parameters)
					{
						list.Add(parameterInfo.Name);
					}
					this.m_payloadNames = new ReadOnlyCollection<string>(list);
				}
				return this.m_payloadNames;
			}
			internal set
			{
				this.m_payloadNames = value;
			}
		}

		// Token: 0x170007D9 RID: 2009
		// (get) Token: 0x06003518 RID: 13592 RVA: 0x000CE432 File Offset: 0x000CC632
		[__DynamicallyInvokable]
		public EventSource EventSource
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_eventSource;
			}
		}

		// Token: 0x170007DA RID: 2010
		// (get) Token: 0x06003519 RID: 13593 RVA: 0x000CE43A File Offset: 0x000CC63A
		[__DynamicallyInvokable]
		public EventKeywords Keywords
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.EventId < 0)
				{
					return this.m_keywords;
				}
				return (EventKeywords)this.m_eventSource.m_eventData[this.EventId].Descriptor.Keywords;
			}
		}

		// Token: 0x170007DB RID: 2011
		// (get) Token: 0x0600351A RID: 13594 RVA: 0x000CE46E File Offset: 0x000CC66E
		[__DynamicallyInvokable]
		public EventOpcode Opcode
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.EventId < 0)
				{
					return this.m_opcode;
				}
				return (EventOpcode)this.m_eventSource.m_eventData[this.EventId].Descriptor.Opcode;
			}
		}

		// Token: 0x170007DC RID: 2012
		// (get) Token: 0x0600351B RID: 13595 RVA: 0x000CE4A2 File Offset: 0x000CC6A2
		[__DynamicallyInvokable]
		public EventTask Task
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.EventId < 0)
				{
					return EventTask.None;
				}
				return (EventTask)this.m_eventSource.m_eventData[this.EventId].Descriptor.Task;
			}
		}

		// Token: 0x170007DD RID: 2013
		// (get) Token: 0x0600351C RID: 13596 RVA: 0x000CE4D1 File Offset: 0x000CC6D1
		[__DynamicallyInvokable]
		public EventTags Tags
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.EventId < 0)
				{
					return this.m_tags;
				}
				return this.m_eventSource.m_eventData[this.EventId].Tags;
			}
		}

		// Token: 0x170007DE RID: 2014
		// (get) Token: 0x0600351D RID: 13597 RVA: 0x000CE500 File Offset: 0x000CC700
		// (set) Token: 0x0600351E RID: 13598 RVA: 0x000CE52F File Offset: 0x000CC72F
		[__DynamicallyInvokable]
		public string Message
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.EventId < 0)
				{
					return this.m_message;
				}
				return this.m_eventSource.m_eventData[this.EventId].Message;
			}
			internal set
			{
				this.m_message = value;
			}
		}

		// Token: 0x170007DF RID: 2015
		// (get) Token: 0x0600351F RID: 13599 RVA: 0x000CE538 File Offset: 0x000CC738
		[__DynamicallyInvokable]
		public EventChannel Channel
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.EventId < 0)
				{
					return EventChannel.None;
				}
				return (EventChannel)this.m_eventSource.m_eventData[this.EventId].Descriptor.Channel;
			}
		}

		// Token: 0x170007E0 RID: 2016
		// (get) Token: 0x06003520 RID: 13600 RVA: 0x000CE567 File Offset: 0x000CC767
		[__DynamicallyInvokable]
		public byte Version
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.EventId < 0)
				{
					return 0;
				}
				return this.m_eventSource.m_eventData[this.EventId].Descriptor.Version;
			}
		}

		// Token: 0x170007E1 RID: 2017
		// (get) Token: 0x06003521 RID: 13601 RVA: 0x000CE596 File Offset: 0x000CC796
		[__DynamicallyInvokable]
		public EventLevel Level
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.EventId < 0)
				{
					return this.m_level;
				}
				return (EventLevel)this.m_eventSource.m_eventData[this.EventId].Descriptor.Level;
			}
		}

		// Token: 0x06003522 RID: 13602 RVA: 0x000CE5CA File Offset: 0x000CC7CA
		internal EventWrittenEventArgs(EventSource eventSource)
		{
			this.m_eventSource = eventSource;
		}

		// Token: 0x04001786 RID: 6022
		private string m_message;

		// Token: 0x04001787 RID: 6023
		private string m_eventName;

		// Token: 0x04001788 RID: 6024
		private EventSource m_eventSource;

		// Token: 0x04001789 RID: 6025
		private ReadOnlyCollection<string> m_payloadNames;

		// Token: 0x0400178A RID: 6026
		private Guid m_activityId;

		// Token: 0x0400178B RID: 6027
		internal EventTags m_tags;

		// Token: 0x0400178C RID: 6028
		internal EventOpcode m_opcode;

		// Token: 0x0400178D RID: 6029
		internal EventKeywords m_keywords;

		// Token: 0x0400178E RID: 6030
		internal EventLevel m_level;
	}
}
