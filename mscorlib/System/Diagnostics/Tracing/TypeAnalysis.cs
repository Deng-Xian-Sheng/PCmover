using System;
using System.Collections.Generic;
using System.Reflection;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000487 RID: 1159
	internal sealed class TypeAnalysis
	{
		// Token: 0x06003763 RID: 14179 RVA: 0x000D51B0 File Offset: 0x000D33B0
		public TypeAnalysis(Type dataType, EventDataAttribute eventAttrib, List<Type> recursionCheck)
		{
			IEnumerable<PropertyInfo> enumerable = Statics.GetProperties(dataType);
			List<PropertyAnalysis> list = new List<PropertyAnalysis>();
			foreach (PropertyInfo propertyInfo in enumerable)
			{
				if (!Statics.HasCustomAttribute(propertyInfo, typeof(EventIgnoreAttribute)) && propertyInfo.CanRead && propertyInfo.GetIndexParameters().Length == 0)
				{
					MethodInfo getMethod = Statics.GetGetMethod(propertyInfo);
					if (!(getMethod == null) && !getMethod.IsStatic && getMethod.IsPublic)
					{
						Type propertyType = propertyInfo.PropertyType;
						TraceLoggingTypeInfo typeInfoInstance = Statics.GetTypeInfoInstance(propertyType, recursionCheck);
						EventFieldAttribute customAttribute = Statics.GetCustomAttribute<EventFieldAttribute>(propertyInfo);
						string text = (customAttribute != null && customAttribute.Name != null) ? customAttribute.Name : (Statics.ShouldOverrideFieldName(propertyInfo.Name) ? typeInfoInstance.Name : propertyInfo.Name);
						list.Add(new PropertyAnalysis(text, getMethod, typeInfoInstance, customAttribute));
					}
				}
			}
			this.properties = list.ToArray();
			foreach (PropertyAnalysis propertyAnalysis in this.properties)
			{
				TraceLoggingTypeInfo typeInfo = propertyAnalysis.typeInfo;
				this.level = (EventLevel)Statics.Combine((int)typeInfo.Level, (int)this.level);
				this.opcode = (EventOpcode)Statics.Combine((int)typeInfo.Opcode, (int)this.opcode);
				this.keywords |= typeInfo.Keywords;
				this.tags |= typeInfo.Tags;
			}
			if (eventAttrib != null)
			{
				this.level = (EventLevel)Statics.Combine((int)eventAttrib.Level, (int)this.level);
				this.opcode = (EventOpcode)Statics.Combine((int)eventAttrib.Opcode, (int)this.opcode);
				this.keywords |= eventAttrib.Keywords;
				this.tags |= eventAttrib.Tags;
				this.name = eventAttrib.Name;
			}
			if (this.name == null)
			{
				this.name = dataType.Name;
			}
		}

		// Token: 0x040018A5 RID: 6309
		internal readonly PropertyAnalysis[] properties;

		// Token: 0x040018A6 RID: 6310
		internal readonly string name;

		// Token: 0x040018A7 RID: 6311
		internal readonly EventKeywords keywords;

		// Token: 0x040018A8 RID: 6312
		internal readonly EventLevel level = (EventLevel)(-1);

		// Token: 0x040018A9 RID: 6313
		internal readonly EventOpcode opcode = (EventOpcode)(-1);

		// Token: 0x040018AA RID: 6314
		internal readonly EventTags tags;
	}
}
