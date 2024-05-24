using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;

namespace System.Runtime.InteropServices.TCEAdapterGen
{
	// Token: 0x020009C4 RID: 2500
	internal class TCEAdapterGenerator
	{
		// Token: 0x060063B2 RID: 25522 RVA: 0x001544F4 File Offset: 0x001526F4
		public void Process(ModuleBuilder ModBldr, ArrayList EventItfList)
		{
			this.m_Module = ModBldr;
			int count = EventItfList.Count;
			for (int i = 0; i < count; i++)
			{
				EventItfInfo eventItfInfo = (EventItfInfo)EventItfList[i];
				Type eventItfType = eventItfInfo.GetEventItfType();
				Type srcItfType = eventItfInfo.GetSrcItfType();
				string eventProviderName = eventItfInfo.GetEventProviderName();
				Type sinkHelperType = new EventSinkHelperWriter(this.m_Module, srcItfType, eventItfType).Perform();
				new EventProviderWriter(this.m_Module, eventProviderName, eventItfType, srcItfType, sinkHelperType).Perform();
			}
		}

		// Token: 0x060063B3 RID: 25523 RVA: 0x0015456C File Offset: 0x0015276C
		internal static void SetClassInterfaceTypeToNone(TypeBuilder tb)
		{
			if (TCEAdapterGenerator.s_NoClassItfCABuilder == null)
			{
				Type[] types = new Type[]
				{
					typeof(ClassInterfaceType)
				};
				ConstructorInfo constructor = typeof(ClassInterfaceAttribute).GetConstructor(types);
				TCEAdapterGenerator.s_NoClassItfCABuilder = new CustomAttributeBuilder(constructor, new object[]
				{
					ClassInterfaceType.None
				});
			}
			tb.SetCustomAttribute(TCEAdapterGenerator.s_NoClassItfCABuilder);
		}

		// Token: 0x060063B4 RID: 25524 RVA: 0x001545D4 File Offset: 0x001527D4
		internal static TypeBuilder DefineUniqueType(string strInitFullName, TypeAttributes attrs, Type BaseType, Type[] aInterfaceTypes, ModuleBuilder mb)
		{
			string text = strInitFullName;
			int num = 2;
			while (mb.GetType(text) != null)
			{
				text = strInitFullName + "_" + num.ToString();
				num++;
			}
			return mb.DefineType(text, attrs, BaseType, aInterfaceTypes);
		}

		// Token: 0x060063B5 RID: 25525 RVA: 0x0015461C File Offset: 0x0015281C
		internal static void SetHiddenAttribute(TypeBuilder tb)
		{
			if (TCEAdapterGenerator.s_HiddenCABuilder == null)
			{
				Type[] types = new Type[]
				{
					typeof(TypeLibTypeFlags)
				};
				ConstructorInfo constructor = typeof(TypeLibTypeAttribute).GetConstructor(types);
				TCEAdapterGenerator.s_HiddenCABuilder = new CustomAttributeBuilder(constructor, new object[]
				{
					TypeLibTypeFlags.FHidden
				});
			}
			tb.SetCustomAttribute(TCEAdapterGenerator.s_HiddenCABuilder);
		}

		// Token: 0x060063B6 RID: 25526 RVA: 0x00154684 File Offset: 0x00152884
		internal static MethodInfo[] GetNonPropertyMethods(Type type)
		{
			MethodInfo[] methods = type.GetMethods();
			ArrayList arrayList = new ArrayList(methods);
			PropertyInfo[] properties = type.GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				MethodInfo[] accessors = propertyInfo.GetAccessors();
				foreach (MethodInfo right in accessors)
				{
					for (int k = 0; k < arrayList.Count; k++)
					{
						if ((MethodInfo)arrayList[k] == right)
						{
							arrayList.RemoveAt(k);
						}
					}
				}
			}
			MethodInfo[] array3 = new MethodInfo[arrayList.Count];
			arrayList.CopyTo(array3);
			return array3;
		}

		// Token: 0x060063B7 RID: 25527 RVA: 0x00154734 File Offset: 0x00152934
		internal static MethodInfo[] GetPropertyMethods(Type type)
		{
			MethodInfo[] methods = type.GetMethods();
			ArrayList arrayList = new ArrayList();
			PropertyInfo[] properties = type.GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				MethodInfo[] accessors = propertyInfo.GetAccessors();
				foreach (MethodInfo value in accessors)
				{
					arrayList.Add(value);
				}
			}
			MethodInfo[] array3 = new MethodInfo[arrayList.Count];
			arrayList.CopyTo(array3);
			return array3;
		}

		// Token: 0x04002CCF RID: 11471
		private ModuleBuilder m_Module;

		// Token: 0x04002CD0 RID: 11472
		private Hashtable m_SrcItfToSrcItfInfoMap = new Hashtable();

		// Token: 0x04002CD1 RID: 11473
		private static volatile CustomAttributeBuilder s_NoClassItfCABuilder;

		// Token: 0x04002CD2 RID: 11474
		private static volatile CustomAttributeBuilder s_HiddenCABuilder;
	}
}
