using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000485 RID: 1157
	internal abstract class TraceLoggingTypeInfo
	{
		// Token: 0x06003751 RID: 14161 RVA: 0x000D5012 File Offset: 0x000D3212
		internal TraceLoggingTypeInfo(Type dataType)
		{
			if (dataType == null)
			{
				throw new ArgumentNullException("dataType");
			}
			this.name = dataType.Name;
			this.dataType = dataType;
		}

		// Token: 0x06003752 RID: 14162 RVA: 0x000D5050 File Offset: 0x000D3250
		internal TraceLoggingTypeInfo(Type dataType, string name, EventLevel level, EventOpcode opcode, EventKeywords keywords, EventTags tags)
		{
			if (dataType == null)
			{
				throw new ArgumentNullException("dataType");
			}
			if (name == null)
			{
				throw new ArgumentNullException("eventName");
			}
			Statics.CheckName(name);
			this.name = name;
			this.keywords = keywords;
			this.level = level;
			this.opcode = opcode;
			this.tags = tags;
			this.dataType = dataType;
		}

		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x06003753 RID: 14163 RVA: 0x000D50C6 File Offset: 0x000D32C6
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x06003754 RID: 14164 RVA: 0x000D50CE File Offset: 0x000D32CE
		public EventLevel Level
		{
			get
			{
				return this.level;
			}
		}

		// Token: 0x17000819 RID: 2073
		// (get) Token: 0x06003755 RID: 14165 RVA: 0x000D50D6 File Offset: 0x000D32D6
		public EventOpcode Opcode
		{
			get
			{
				return this.opcode;
			}
		}

		// Token: 0x1700081A RID: 2074
		// (get) Token: 0x06003756 RID: 14166 RVA: 0x000D50DE File Offset: 0x000D32DE
		public EventKeywords Keywords
		{
			get
			{
				return this.keywords;
			}
		}

		// Token: 0x1700081B RID: 2075
		// (get) Token: 0x06003757 RID: 14167 RVA: 0x000D50E6 File Offset: 0x000D32E6
		public EventTags Tags
		{
			get
			{
				return this.tags;
			}
		}

		// Token: 0x1700081C RID: 2076
		// (get) Token: 0x06003758 RID: 14168 RVA: 0x000D50EE File Offset: 0x000D32EE
		internal Type DataType
		{
			get
			{
				return this.dataType;
			}
		}

		// Token: 0x06003759 RID: 14169
		public abstract void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format);

		// Token: 0x0600375A RID: 14170
		public abstract void WriteObjectData(TraceLoggingDataCollector collector, object value);

		// Token: 0x0600375B RID: 14171 RVA: 0x000D50F6 File Offset: 0x000D32F6
		public virtual object GetData(object value)
		{
			return value;
		}

		// Token: 0x0400189E RID: 6302
		private readonly string name;

		// Token: 0x0400189F RID: 6303
		private readonly EventKeywords keywords;

		// Token: 0x040018A0 RID: 6304
		private readonly EventLevel level = (EventLevel)(-1);

		// Token: 0x040018A1 RID: 6305
		private readonly EventOpcode opcode = (EventOpcode)(-1);

		// Token: 0x040018A2 RID: 6306
		private readonly EventTags tags;

		// Token: 0x040018A3 RID: 6307
		private readonly Type dataType;
	}
}
