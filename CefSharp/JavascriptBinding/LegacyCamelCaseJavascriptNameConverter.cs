using System;
using System.Reflection;

namespace CefSharp.JavascriptBinding
{
	// Token: 0x020000C0 RID: 192
	public class LegacyCamelCaseJavascriptNameConverter : IJavascriptNameConverter
	{
		// Token: 0x060005C6 RID: 1478 RVA: 0x000093B8 File Offset: 0x000075B8
		string IJavascriptNameConverter.ConvertReturnedObjectPropertyAndFieldToNameJavascript(MemberInfo memberInfo)
		{
			return memberInfo.Name;
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x000093C0 File Offset: 0x000075C0
		string IJavascriptNameConverter.ConvertToJavascript(MemberInfo memberInfo)
		{
			string name = memberInfo.Name;
			return char.ToLowerInvariant(name[0]).ToString() + name.Substring(1);
		}
	}
}
