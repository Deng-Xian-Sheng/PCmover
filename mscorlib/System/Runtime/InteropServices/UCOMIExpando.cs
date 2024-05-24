using System;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000985 RID: 2437
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IExpando instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("AFBF15E6-C37C-11d2-B88E-00A0C9B471B8")]
	internal interface UCOMIExpando : UCOMIReflect
	{
		// Token: 0x0600629A RID: 25242
		FieldInfo AddField(string name);

		// Token: 0x0600629B RID: 25243
		PropertyInfo AddProperty(string name);

		// Token: 0x0600629C RID: 25244
		MethodInfo AddMethod(string name, Delegate method);

		// Token: 0x0600629D RID: 25245
		void RemoveMember(MemberInfo m);
	}
}
