using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200044D RID: 1101
	internal class StructPropertyWriter<ContainerType, ValueType> : PropertyAccessor<ContainerType>
	{
		// Token: 0x06003652 RID: 13906 RVA: 0x000D2FEC File Offset: 0x000D11EC
		public StructPropertyWriter(PropertyAnalysis property)
		{
			this.valueTypeInfo = (TraceLoggingTypeInfo<ValueType>)property.typeInfo;
			this.getter = (StructPropertyWriter<ContainerType, ValueType>.Getter)Statics.CreateDelegate(typeof(StructPropertyWriter<ContainerType, ValueType>.Getter), property.getterInfo);
		}

		// Token: 0x06003653 RID: 13907 RVA: 0x000D3028 File Offset: 0x000D1228
		public override void Write(TraceLoggingDataCollector collector, ref ContainerType container)
		{
			ValueType valueType = (container == null) ? default(ValueType) : this.getter(ref container);
			this.valueTypeInfo.WriteData(collector, ref valueType);
		}

		// Token: 0x06003654 RID: 13908 RVA: 0x000D3068 File Offset: 0x000D1268
		public override object GetData(ContainerType container)
		{
			return (container == null) ? default(ValueType) : this.getter(ref container);
		}

		// Token: 0x0400184B RID: 6219
		private readonly TraceLoggingTypeInfo<ValueType> valueTypeInfo;

		// Token: 0x0400184C RID: 6220
		private readonly StructPropertyWriter<ContainerType, ValueType>.Getter getter;

		// Token: 0x02000B9C RID: 2972
		// (Invoke) Token: 0x06006C9A RID: 27802
		private delegate ValueType Getter(ref ContainerType container);
	}
}
