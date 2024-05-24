using System;
using System.Globalization;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000989 RID: 2441
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IReflect instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("AFBF15E5-C37C-11d2-B88E-00A0C9B471B8")]
	internal interface UCOMIReflect
	{
		// Token: 0x060062B8 RID: 25272
		MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers);

		// Token: 0x060062B9 RID: 25273
		MethodInfo GetMethod(string name, BindingFlags bindingAttr);

		// Token: 0x060062BA RID: 25274
		MethodInfo[] GetMethods(BindingFlags bindingAttr);

		// Token: 0x060062BB RID: 25275
		FieldInfo GetField(string name, BindingFlags bindingAttr);

		// Token: 0x060062BC RID: 25276
		FieldInfo[] GetFields(BindingFlags bindingAttr);

		// Token: 0x060062BD RID: 25277
		PropertyInfo GetProperty(string name, BindingFlags bindingAttr);

		// Token: 0x060062BE RID: 25278
		PropertyInfo GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers);

		// Token: 0x060062BF RID: 25279
		PropertyInfo[] GetProperties(BindingFlags bindingAttr);

		// Token: 0x060062C0 RID: 25280
		MemberInfo[] GetMember(string name, BindingFlags bindingAttr);

		// Token: 0x060062C1 RID: 25281
		MemberInfo[] GetMembers(BindingFlags bindingAttr);

		// Token: 0x060062C2 RID: 25282
		object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters);

		// Token: 0x17001117 RID: 4375
		// (get) Token: 0x060062C3 RID: 25283
		Type UnderlyingSystemType { get; }
	}
}
