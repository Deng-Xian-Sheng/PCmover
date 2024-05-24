using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200044E RID: 1102
	internal class ClassPropertyWriter<ContainerType, ValueType> : PropertyAccessor<ContainerType>
	{
		// Token: 0x06003655 RID: 13909 RVA: 0x000D309A File Offset: 0x000D129A
		public ClassPropertyWriter(PropertyAnalysis property)
		{
			this.valueTypeInfo = (TraceLoggingTypeInfo<ValueType>)property.typeInfo;
			this.getter = (ClassPropertyWriter<ContainerType, ValueType>.Getter)Statics.CreateDelegate(typeof(ClassPropertyWriter<ContainerType, ValueType>.Getter), property.getterInfo);
		}

		// Token: 0x06003656 RID: 13910 RVA: 0x000D30D4 File Offset: 0x000D12D4
		public override void Write(TraceLoggingDataCollector collector, ref ContainerType container)
		{
			ValueType valueType = (container == null) ? default(ValueType) : this.getter(container);
			this.valueTypeInfo.WriteData(collector, ref valueType);
		}

		// Token: 0x06003657 RID: 13911 RVA: 0x000D311C File Offset: 0x000D131C
		public override object GetData(ContainerType container)
		{
			return (container == null) ? default(ValueType) : this.getter(container);
		}

		// Token: 0x0400184D RID: 6221
		private readonly TraceLoggingTypeInfo<ValueType> valueTypeInfo;

		// Token: 0x0400184E RID: 6222
		private readonly ClassPropertyWriter<ContainerType, ValueType>.Getter getter;

		// Token: 0x02000B9D RID: 2973
		// (Invoke) Token: 0x06006C9E RID: 27806
		private delegate ValueType Getter(ContainerType container);
	}
}
