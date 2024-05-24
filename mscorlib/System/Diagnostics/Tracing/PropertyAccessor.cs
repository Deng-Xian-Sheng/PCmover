using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200044B RID: 1099
	internal abstract class PropertyAccessor<ContainerType>
	{
		// Token: 0x0600364B RID: 13899
		public abstract void Write(TraceLoggingDataCollector collector, ref ContainerType value);

		// Token: 0x0600364C RID: 13900
		public abstract object GetData(ContainerType value);

		// Token: 0x0600364D RID: 13901 RVA: 0x000D2EE8 File Offset: 0x000D10E8
		public static PropertyAccessor<ContainerType> Create(PropertyAnalysis property)
		{
			Type returnType = property.getterInfo.ReturnType;
			if (!Statics.IsValueType(typeof(ContainerType)))
			{
				if (returnType == typeof(int))
				{
					return new ClassPropertyWriter<ContainerType, int>(property);
				}
				if (returnType == typeof(long))
				{
					return new ClassPropertyWriter<ContainerType, long>(property);
				}
				if (returnType == typeof(string))
				{
					return new ClassPropertyWriter<ContainerType, string>(property);
				}
			}
			return new NonGenericProperytWriter<ContainerType>(property);
		}
	}
}
