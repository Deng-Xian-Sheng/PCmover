using System;
using System.Globalization;
using System.Reflection;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A32 RID: 2610
	[Guid("AFBF15E5-C37C-11d2-B88E-00A0C9B471B8")]
	internal interface IReflect
	{
		// Token: 0x0600664B RID: 26187
		MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers);

		// Token: 0x0600664C RID: 26188
		MethodInfo GetMethod(string name, BindingFlags bindingAttr);

		// Token: 0x0600664D RID: 26189
		MethodInfo[] GetMethods(BindingFlags bindingAttr);

		// Token: 0x0600664E RID: 26190
		FieldInfo GetField(string name, BindingFlags bindingAttr);

		// Token: 0x0600664F RID: 26191
		FieldInfo[] GetFields(BindingFlags bindingAttr);

		// Token: 0x06006650 RID: 26192
		PropertyInfo GetProperty(string name, BindingFlags bindingAttr);

		// Token: 0x06006651 RID: 26193
		PropertyInfo GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers);

		// Token: 0x06006652 RID: 26194
		PropertyInfo[] GetProperties(BindingFlags bindingAttr);

		// Token: 0x06006653 RID: 26195
		MemberInfo[] GetMember(string name, BindingFlags bindingAttr);

		// Token: 0x06006654 RID: 26196
		MemberInfo[] GetMembers(BindingFlags bindingAttr);

		// Token: 0x06006655 RID: 26197
		object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters);

		// Token: 0x1700118B RID: 4491
		// (get) Token: 0x06006656 RID: 26198
		Type UnderlyingSystemType { get; }
	}
}
