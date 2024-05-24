﻿using System;
using System.Reflection;

namespace System.Runtime.InteropServices.Expando
{
	// Token: 0x02000A21 RID: 2593
	[Guid("AFBF15E6-C37C-11d2-B88E-00A0C9B471B8")]
	[ComVisible(true)]
	public interface IExpando : IReflect
	{
		// Token: 0x06006600 RID: 26112
		FieldInfo AddField(string name);

		// Token: 0x06006601 RID: 26113
		PropertyInfo AddProperty(string name);

		// Token: 0x06006602 RID: 26114
		MethodInfo AddMethod(string name, Delegate method);

		// Token: 0x06006603 RID: 26115
		void RemoveMember(MemberInfo m);
	}
}
