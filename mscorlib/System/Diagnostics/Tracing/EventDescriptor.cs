using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200041C RID: 1052
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	internal struct EventDescriptor
	{
		// Token: 0x0600343E RID: 13374 RVA: 0x000C710C File Offset: 0x000C530C
		public EventDescriptor(int traceloggingId, byte level, byte opcode, long keywords)
		{
			this.m_id = 0;
			this.m_version = 0;
			this.m_channel = 0;
			this.m_traceloggingId = traceloggingId;
			this.m_level = level;
			this.m_opcode = opcode;
			this.m_task = 0;
			this.m_keywords = keywords;
		}

		// Token: 0x0600343F RID: 13375 RVA: 0x000C7148 File Offset: 0x000C5348
		public EventDescriptor(int id, byte version, byte channel, byte level, byte opcode, int task, long keywords)
		{
			if (id < 0)
			{
				throw new ArgumentOutOfRangeException("id", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (id > 65535)
			{
				throw new ArgumentOutOfRangeException("id", Environment.GetResourceString("ArgumentOutOfRange_NeedValidId", new object[]
				{
					1,
					ushort.MaxValue
				}));
			}
			this.m_traceloggingId = 0;
			this.m_id = (ushort)id;
			this.m_version = version;
			this.m_channel = channel;
			this.m_level = level;
			this.m_opcode = opcode;
			this.m_keywords = keywords;
			if (task < 0)
			{
				throw new ArgumentOutOfRangeException("task", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (task > 65535)
			{
				throw new ArgumentOutOfRangeException("task", Environment.GetResourceString("ArgumentOutOfRange_NeedValidId", new object[]
				{
					1,
					ushort.MaxValue
				}));
			}
			this.m_task = (ushort)task;
		}

		// Token: 0x170007BB RID: 1979
		// (get) Token: 0x06003440 RID: 13376 RVA: 0x000C7239 File Offset: 0x000C5439
		public int EventId
		{
			get
			{
				return (int)this.m_id;
			}
		}

		// Token: 0x170007BC RID: 1980
		// (get) Token: 0x06003441 RID: 13377 RVA: 0x000C7241 File Offset: 0x000C5441
		public byte Version
		{
			get
			{
				return this.m_version;
			}
		}

		// Token: 0x170007BD RID: 1981
		// (get) Token: 0x06003442 RID: 13378 RVA: 0x000C7249 File Offset: 0x000C5449
		public byte Channel
		{
			get
			{
				return this.m_channel;
			}
		}

		// Token: 0x170007BE RID: 1982
		// (get) Token: 0x06003443 RID: 13379 RVA: 0x000C7251 File Offset: 0x000C5451
		public byte Level
		{
			get
			{
				return this.m_level;
			}
		}

		// Token: 0x170007BF RID: 1983
		// (get) Token: 0x06003444 RID: 13380 RVA: 0x000C7259 File Offset: 0x000C5459
		public byte Opcode
		{
			get
			{
				return this.m_opcode;
			}
		}

		// Token: 0x170007C0 RID: 1984
		// (get) Token: 0x06003445 RID: 13381 RVA: 0x000C7261 File Offset: 0x000C5461
		public int Task
		{
			get
			{
				return (int)this.m_task;
			}
		}

		// Token: 0x170007C1 RID: 1985
		// (get) Token: 0x06003446 RID: 13382 RVA: 0x000C7269 File Offset: 0x000C5469
		public long Keywords
		{
			get
			{
				return this.m_keywords;
			}
		}

		// Token: 0x06003447 RID: 13383 RVA: 0x000C7271 File Offset: 0x000C5471
		public override bool Equals(object obj)
		{
			return obj is EventDescriptor && this.Equals((EventDescriptor)obj);
		}

		// Token: 0x06003448 RID: 13384 RVA: 0x000C7289 File Offset: 0x000C5489
		public override int GetHashCode()
		{
			return (int)(this.m_id ^ (ushort)this.m_version ^ (ushort)this.m_channel ^ (ushort)this.m_level ^ (ushort)this.m_opcode ^ this.m_task) ^ (int)this.m_keywords;
		}

		// Token: 0x06003449 RID: 13385 RVA: 0x000C72BC File Offset: 0x000C54BC
		public bool Equals(EventDescriptor other)
		{
			return this.m_id == other.m_id && this.m_version == other.m_version && this.m_channel == other.m_channel && this.m_level == other.m_level && this.m_opcode == other.m_opcode && this.m_task == other.m_task && this.m_keywords == other.m_keywords;
		}

		// Token: 0x0600344A RID: 13386 RVA: 0x000C732E File Offset: 0x000C552E
		public static bool operator ==(EventDescriptor event1, EventDescriptor event2)
		{
			return event1.Equals(event2);
		}

		// Token: 0x0600344B RID: 13387 RVA: 0x000C7338 File Offset: 0x000C5538
		public static bool operator !=(EventDescriptor event1, EventDescriptor event2)
		{
			return !event1.Equals(event2);
		}

		// Token: 0x0400172A RID: 5930
		[FieldOffset(0)]
		private int m_traceloggingId;

		// Token: 0x0400172B RID: 5931
		[FieldOffset(0)]
		private ushort m_id;

		// Token: 0x0400172C RID: 5932
		[FieldOffset(2)]
		private byte m_version;

		// Token: 0x0400172D RID: 5933
		[FieldOffset(3)]
		private byte m_channel;

		// Token: 0x0400172E RID: 5934
		[FieldOffset(4)]
		private byte m_level;

		// Token: 0x0400172F RID: 5935
		[FieldOffset(5)]
		private byte m_opcode;

		// Token: 0x04001730 RID: 5936
		[FieldOffset(6)]
		private ushort m_task;

		// Token: 0x04001731 RID: 5937
		[FieldOffset(8)]
		private long m_keywords;
	}
}
