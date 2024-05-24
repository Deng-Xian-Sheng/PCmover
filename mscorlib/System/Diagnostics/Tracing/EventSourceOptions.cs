using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000447 RID: 1095
	[__DynamicallyInvokable]
	public struct EventSourceOptions
	{
		// Token: 0x17000806 RID: 2054
		// (get) Token: 0x0600362F RID: 13871 RVA: 0x000D28CA File Offset: 0x000D0ACA
		// (set) Token: 0x06003630 RID: 13872 RVA: 0x000D28D2 File Offset: 0x000D0AD2
		[__DynamicallyInvokable]
		public EventLevel Level
		{
			[__DynamicallyInvokable]
			get
			{
				return (EventLevel)this.level;
			}
			[__DynamicallyInvokable]
			set
			{
				this.level = checked((byte)value);
				this.valuesSet |= 4;
			}
		}

		// Token: 0x17000807 RID: 2055
		// (get) Token: 0x06003631 RID: 13873 RVA: 0x000D28EB File Offset: 0x000D0AEB
		// (set) Token: 0x06003632 RID: 13874 RVA: 0x000D28F3 File Offset: 0x000D0AF3
		[__DynamicallyInvokable]
		public EventOpcode Opcode
		{
			[__DynamicallyInvokable]
			get
			{
				return (EventOpcode)this.opcode;
			}
			[__DynamicallyInvokable]
			set
			{
				this.opcode = checked((byte)value);
				this.valuesSet |= 8;
			}
		}

		// Token: 0x17000808 RID: 2056
		// (get) Token: 0x06003633 RID: 13875 RVA: 0x000D290C File Offset: 0x000D0B0C
		internal bool IsOpcodeSet
		{
			get
			{
				return (this.valuesSet & 8) > 0;
			}
		}

		// Token: 0x17000809 RID: 2057
		// (get) Token: 0x06003634 RID: 13876 RVA: 0x000D2919 File Offset: 0x000D0B19
		// (set) Token: 0x06003635 RID: 13877 RVA: 0x000D2921 File Offset: 0x000D0B21
		[__DynamicallyInvokable]
		public EventKeywords Keywords
		{
			[__DynamicallyInvokable]
			get
			{
				return this.keywords;
			}
			[__DynamicallyInvokable]
			set
			{
				this.keywords = value;
				this.valuesSet |= 1;
			}
		}

		// Token: 0x1700080A RID: 2058
		// (get) Token: 0x06003636 RID: 13878 RVA: 0x000D2939 File Offset: 0x000D0B39
		// (set) Token: 0x06003637 RID: 13879 RVA: 0x000D2941 File Offset: 0x000D0B41
		[__DynamicallyInvokable]
		public EventTags Tags
		{
			[__DynamicallyInvokable]
			get
			{
				return this.tags;
			}
			[__DynamicallyInvokable]
			set
			{
				this.tags = value;
				this.valuesSet |= 2;
			}
		}

		// Token: 0x1700080B RID: 2059
		// (get) Token: 0x06003638 RID: 13880 RVA: 0x000D2959 File Offset: 0x000D0B59
		// (set) Token: 0x06003639 RID: 13881 RVA: 0x000D2961 File Offset: 0x000D0B61
		[__DynamicallyInvokable]
		public EventActivityOptions ActivityOptions
		{
			[__DynamicallyInvokable]
			get
			{
				return this.activityOptions;
			}
			[__DynamicallyInvokable]
			set
			{
				this.activityOptions = value;
				this.valuesSet |= 16;
			}
		}

		// Token: 0x04001830 RID: 6192
		internal EventKeywords keywords;

		// Token: 0x04001831 RID: 6193
		internal EventTags tags;

		// Token: 0x04001832 RID: 6194
		internal EventActivityOptions activityOptions;

		// Token: 0x04001833 RID: 6195
		internal byte level;

		// Token: 0x04001834 RID: 6196
		internal byte opcode;

		// Token: 0x04001835 RID: 6197
		internal byte valuesSet;

		// Token: 0x04001836 RID: 6198
		internal const byte keywordsSet = 1;

		// Token: 0x04001837 RID: 6199
		internal const byte tagsSet = 2;

		// Token: 0x04001838 RID: 6200
		internal const byte levelSet = 4;

		// Token: 0x04001839 RID: 6201
		internal const byte opcodeSet = 8;

		// Token: 0x0400183A RID: 6202
		internal const byte activityOptionsSet = 16;
	}
}
