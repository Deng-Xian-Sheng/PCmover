using System;
using System.Collections.Generic;
using System.Reflection;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000483 RID: 1155
	internal class TraceLoggingEventTypes
	{
		// Token: 0x06003733 RID: 14131 RVA: 0x000D493D File Offset: 0x000D2B3D
		internal TraceLoggingEventTypes(string name, EventTags tags, params Type[] types) : this(tags, name, TraceLoggingEventTypes.MakeArray(types))
		{
		}

		// Token: 0x06003734 RID: 14132 RVA: 0x000D494D File Offset: 0x000D2B4D
		internal TraceLoggingEventTypes(string name, EventTags tags, params TraceLoggingTypeInfo[] typeInfos) : this(tags, name, TraceLoggingEventTypes.MakeArray(typeInfos))
		{
		}

		// Token: 0x06003735 RID: 14133 RVA: 0x000D4960 File Offset: 0x000D2B60
		internal TraceLoggingEventTypes(string name, EventTags tags, ParameterInfo[] paramInfos)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.typeInfos = this.MakeArray(paramInfos);
			this.name = name;
			this.tags = tags;
			this.level = 5;
			TraceLoggingMetadataCollector traceLoggingMetadataCollector = new TraceLoggingMetadataCollector();
			for (int i = 0; i < this.typeInfos.Length; i++)
			{
				TraceLoggingTypeInfo traceLoggingTypeInfo = this.typeInfos[i];
				this.level = Statics.Combine((int)traceLoggingTypeInfo.Level, this.level);
				this.opcode = Statics.Combine((int)traceLoggingTypeInfo.Opcode, this.opcode);
				this.keywords |= traceLoggingTypeInfo.Keywords;
				string fieldName = paramInfos[i].Name;
				if (Statics.ShouldOverrideFieldName(fieldName))
				{
					fieldName = traceLoggingTypeInfo.Name;
				}
				traceLoggingTypeInfo.WriteMetadata(traceLoggingMetadataCollector, fieldName, EventFieldFormat.Default);
			}
			this.typeMetadata = traceLoggingMetadataCollector.GetMetadata();
			this.scratchSize = traceLoggingMetadataCollector.ScratchSize;
			this.dataCount = traceLoggingMetadataCollector.DataCount;
			this.pinCount = traceLoggingMetadataCollector.PinCount;
		}

		// Token: 0x06003736 RID: 14134 RVA: 0x000D4A58 File Offset: 0x000D2C58
		private TraceLoggingEventTypes(EventTags tags, string defaultName, TraceLoggingTypeInfo[] typeInfos)
		{
			if (defaultName == null)
			{
				throw new ArgumentNullException("defaultName");
			}
			this.typeInfos = typeInfos;
			this.name = defaultName;
			this.tags = tags;
			this.level = 5;
			TraceLoggingMetadataCollector traceLoggingMetadataCollector = new TraceLoggingMetadataCollector();
			foreach (TraceLoggingTypeInfo traceLoggingTypeInfo in typeInfos)
			{
				this.level = Statics.Combine((int)traceLoggingTypeInfo.Level, this.level);
				this.opcode = Statics.Combine((int)traceLoggingTypeInfo.Opcode, this.opcode);
				this.keywords |= traceLoggingTypeInfo.Keywords;
				traceLoggingTypeInfo.WriteMetadata(traceLoggingMetadataCollector, null, EventFieldFormat.Default);
			}
			this.typeMetadata = traceLoggingMetadataCollector.GetMetadata();
			this.scratchSize = traceLoggingMetadataCollector.ScratchSize;
			this.dataCount = traceLoggingMetadataCollector.DataCount;
			this.pinCount = traceLoggingMetadataCollector.PinCount;
		}

		// Token: 0x1700080D RID: 2061
		// (get) Token: 0x06003737 RID: 14135 RVA: 0x000D4B29 File Offset: 0x000D2D29
		internal string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x1700080E RID: 2062
		// (get) Token: 0x06003738 RID: 14136 RVA: 0x000D4B31 File Offset: 0x000D2D31
		internal EventLevel Level
		{
			get
			{
				return (EventLevel)this.level;
			}
		}

		// Token: 0x1700080F RID: 2063
		// (get) Token: 0x06003739 RID: 14137 RVA: 0x000D4B39 File Offset: 0x000D2D39
		internal EventOpcode Opcode
		{
			get
			{
				return (EventOpcode)this.opcode;
			}
		}

		// Token: 0x17000810 RID: 2064
		// (get) Token: 0x0600373A RID: 14138 RVA: 0x000D4B41 File Offset: 0x000D2D41
		internal EventKeywords Keywords
		{
			get
			{
				return this.keywords;
			}
		}

		// Token: 0x17000811 RID: 2065
		// (get) Token: 0x0600373B RID: 14139 RVA: 0x000D4B49 File Offset: 0x000D2D49
		internal EventTags Tags
		{
			get
			{
				return this.tags;
			}
		}

		// Token: 0x0600373C RID: 14140 RVA: 0x000D4B54 File Offset: 0x000D2D54
		internal NameInfo GetNameInfo(string name, EventTags tags)
		{
			NameInfo nameInfo = this.nameInfos.TryGet(new KeyValuePair<string, EventTags>(name, tags));
			if (nameInfo == null)
			{
				nameInfo = this.nameInfos.GetOrAdd(new NameInfo(name, tags, this.typeMetadata.Length));
			}
			return nameInfo;
		}

		// Token: 0x0600373D RID: 14141 RVA: 0x000D4B94 File Offset: 0x000D2D94
		private TraceLoggingTypeInfo[] MakeArray(ParameterInfo[] paramInfos)
		{
			if (paramInfos == null)
			{
				throw new ArgumentNullException("paramInfos");
			}
			List<Type> recursionCheck = new List<Type>(paramInfos.Length);
			TraceLoggingTypeInfo[] array = new TraceLoggingTypeInfo[paramInfos.Length];
			for (int i = 0; i < paramInfos.Length; i++)
			{
				array[i] = Statics.GetTypeInfoInstance(paramInfos[i].ParameterType, recursionCheck);
			}
			return array;
		}

		// Token: 0x0600373E RID: 14142 RVA: 0x000D4BE4 File Offset: 0x000D2DE4
		private static TraceLoggingTypeInfo[] MakeArray(Type[] types)
		{
			if (types == null)
			{
				throw new ArgumentNullException("types");
			}
			List<Type> recursionCheck = new List<Type>(types.Length);
			TraceLoggingTypeInfo[] array = new TraceLoggingTypeInfo[types.Length];
			for (int i = 0; i < types.Length; i++)
			{
				array[i] = Statics.GetTypeInfoInstance(types[i], recursionCheck);
			}
			return array;
		}

		// Token: 0x0600373F RID: 14143 RVA: 0x000D4C2C File Offset: 0x000D2E2C
		private static TraceLoggingTypeInfo[] MakeArray(TraceLoggingTypeInfo[] typeInfos)
		{
			if (typeInfos == null)
			{
				throw new ArgumentNullException("typeInfos");
			}
			return (TraceLoggingTypeInfo[])typeInfos.Clone();
		}

		// Token: 0x0400188F RID: 6287
		internal readonly TraceLoggingTypeInfo[] typeInfos;

		// Token: 0x04001890 RID: 6288
		internal readonly string name;

		// Token: 0x04001891 RID: 6289
		internal readonly EventTags tags;

		// Token: 0x04001892 RID: 6290
		internal readonly byte level;

		// Token: 0x04001893 RID: 6291
		internal readonly byte opcode;

		// Token: 0x04001894 RID: 6292
		internal readonly EventKeywords keywords;

		// Token: 0x04001895 RID: 6293
		internal readonly byte[] typeMetadata;

		// Token: 0x04001896 RID: 6294
		internal readonly int scratchSize;

		// Token: 0x04001897 RID: 6295
		internal readonly int dataCount;

		// Token: 0x04001898 RID: 6296
		internal readonly int pinCount;

		// Token: 0x04001899 RID: 6297
		private ConcurrentSet<KeyValuePair<string, EventTags>, NameInfo> nameInfos;
	}
}
