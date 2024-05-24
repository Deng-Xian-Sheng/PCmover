using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005EF RID: 1519
	[Guid("AFBF15E5-C37C-11d2-B88E-00A0C9B471B8")]
	[ComVisible(true)]
	public interface IReflect
	{
		// Token: 0x0600465F RID: 18015
		MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers);

		// Token: 0x06004660 RID: 18016
		MethodInfo GetMethod(string name, BindingFlags bindingAttr);

		// Token: 0x06004661 RID: 18017
		MethodInfo[] GetMethods(BindingFlags bindingAttr);

		// Token: 0x06004662 RID: 18018
		FieldInfo GetField(string name, BindingFlags bindingAttr);

		// Token: 0x06004663 RID: 18019
		FieldInfo[] GetFields(BindingFlags bindingAttr);

		// Token: 0x06004664 RID: 18020
		PropertyInfo GetProperty(string name, BindingFlags bindingAttr);

		// Token: 0x06004665 RID: 18021
		PropertyInfo GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers);

		// Token: 0x06004666 RID: 18022
		PropertyInfo[] GetProperties(BindingFlags bindingAttr);

		// Token: 0x06004667 RID: 18023
		MemberInfo[] GetMember(string name, BindingFlags bindingAttr);

		// Token: 0x06004668 RID: 18024
		MemberInfo[] GetMembers(BindingFlags bindingAttr);

		// Token: 0x06004669 RID: 18025
		object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters);

		// Token: 0x17000A99 RID: 2713
		// (get) Token: 0x0600466A RID: 18026
		Type UnderlyingSystemType { get; }
	}
}
