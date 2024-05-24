using System;
using System.Collections.Generic;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000449 RID: 1097
	internal sealed class InvokeTypeInfo<ContainerType> : TraceLoggingTypeInfo<ContainerType>
	{
		// Token: 0x06003640 RID: 13888 RVA: 0x000D2BEC File Offset: 0x000D0DEC
		public InvokeTypeInfo(TypeAnalysis typeAnalysis) : base(typeAnalysis.name, typeAnalysis.level, typeAnalysis.opcode, typeAnalysis.keywords, typeAnalysis.tags)
		{
			if (typeAnalysis.properties.Length != 0)
			{
				this.properties = typeAnalysis.properties;
				this.accessors = new PropertyAccessor<ContainerType>[this.properties.Length];
				for (int i = 0; i < this.accessors.Length; i++)
				{
					this.accessors[i] = PropertyAccessor<ContainerType>.Create(this.properties[i]);
				}
			}
		}

		// Token: 0x06003641 RID: 13889 RVA: 0x000D2C70 File Offset: 0x000D0E70
		public override void WriteMetadata(TraceLoggingMetadataCollector collector, string name, EventFieldFormat format)
		{
			TraceLoggingMetadataCollector traceLoggingMetadataCollector = collector.AddGroup(name);
			if (this.properties != null)
			{
				foreach (PropertyAnalysis propertyAnalysis in this.properties)
				{
					EventFieldFormat format2 = EventFieldFormat.Default;
					EventFieldAttribute fieldAttribute = propertyAnalysis.fieldAttribute;
					if (fieldAttribute != null)
					{
						traceLoggingMetadataCollector.Tags = fieldAttribute.Tags;
						format2 = fieldAttribute.Format;
					}
					propertyAnalysis.typeInfo.WriteMetadata(traceLoggingMetadataCollector, propertyAnalysis.name, format2);
				}
			}
		}

		// Token: 0x06003642 RID: 13890 RVA: 0x000D2CE0 File Offset: 0x000D0EE0
		public override void WriteData(TraceLoggingDataCollector collector, ref ContainerType value)
		{
			if (this.accessors != null)
			{
				foreach (PropertyAccessor<ContainerType> propertyAccessor in this.accessors)
				{
					propertyAccessor.Write(collector, ref value);
				}
			}
		}

		// Token: 0x06003643 RID: 13891 RVA: 0x000D2D18 File Offset: 0x000D0F18
		public override object GetData(object value)
		{
			if (this.properties != null)
			{
				List<string> list = new List<string>();
				List<object> list2 = new List<object>();
				for (int i = 0; i < this.properties.Length; i++)
				{
					object data = this.accessors[i].GetData((ContainerType)((object)value));
					list.Add(this.properties[i].name);
					list2.Add(this.properties[i].typeInfo.GetData(data));
				}
				return new EventPayload(list, list2);
			}
			return null;
		}

		// Token: 0x06003644 RID: 13892 RVA: 0x000D2D98 File Offset: 0x000D0F98
		public override void WriteObjectData(TraceLoggingDataCollector collector, object valueObj)
		{
			if (this.accessors != null)
			{
				ContainerType containerType = (valueObj == null) ? default(ContainerType) : ((ContainerType)((object)valueObj));
				this.WriteData(collector, ref containerType);
			}
		}

		// Token: 0x04001842 RID: 6210
		private readonly PropertyAnalysis[] properties;

		// Token: 0x04001843 RID: 6211
		private readonly PropertyAccessor<ContainerType>[] accessors;
	}
}
