using System;
using System.Reflection;

namespace CefSharp.JavascriptBinding
{
	// Token: 0x020000BE RID: 190
	public interface IJavascriptNameConverter
	{
		// Token: 0x060005BB RID: 1467
		string ConvertToJavascript(MemberInfo memberInfo);

		// Token: 0x060005BC RID: 1468
		string ConvertReturnedObjectPropertyAndFieldToNameJavascript(MemberInfo memberInfo);
	}
}
