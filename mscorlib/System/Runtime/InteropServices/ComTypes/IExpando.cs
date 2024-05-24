using System;
using System.Reflection;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A2E RID: 2606
	[Guid("AFBF15E6-C37C-11d2-B88E-00A0C9B471B8")]
	internal interface IExpando : IReflect
	{
		// Token: 0x0600662D RID: 26157
		FieldInfo AddField(string name);

		// Token: 0x0600662E RID: 26158
		PropertyInfo AddProperty(string name);

		// Token: 0x0600662F RID: 26159
		MethodInfo AddMethod(string name, Delegate method);

		// Token: 0x06006630 RID: 26160
		void RemoveMember(MemberInfo m);
	}
}
