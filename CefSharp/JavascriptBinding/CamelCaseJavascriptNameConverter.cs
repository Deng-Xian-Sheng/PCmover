using System;
using System.Linq;
using System.Reflection;

namespace CefSharp.JavascriptBinding
{
	// Token: 0x020000BD RID: 189
	public class CamelCaseJavascriptNameConverter : IJavascriptNameConverter
	{
		// Token: 0x060005B5 RID: 1461 RVA: 0x000092A8 File Offset: 0x000074A8
		string IJavascriptNameConverter.ConvertToJavascript(MemberInfo memberInfo)
		{
			return this.ConvertToJavascript(memberInfo);
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x000092B1 File Offset: 0x000074B1
		protected virtual string ConvertToJavascript(MemberInfo memberInfo)
		{
			return CamelCaseJavascriptNameConverter.ConvertMemberInfoNameToCamelCase(memberInfo);
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x000092B9 File Offset: 0x000074B9
		string IJavascriptNameConverter.ConvertReturnedObjectPropertyAndFieldToNameJavascript(MemberInfo memberInfo)
		{
			return this.ConvertReturnedObjectPropertyAndFieldToNameJavascript(memberInfo);
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x000092C2 File Offset: 0x000074C2
		protected virtual string ConvertReturnedObjectPropertyAndFieldToNameJavascript(MemberInfo memberInfo)
		{
			return CamelCaseJavascriptNameConverter.ConvertMemberInfoNameToCamelCase(memberInfo);
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x000092CC File Offset: 0x000074CC
		protected static string ConvertMemberInfoNameToCamelCase(MemberInfo memberInfo)
		{
			string name = memberInfo.Name;
			if (name.Length == 1)
			{
				return name;
			}
			if (name.All(new Func<char, bool>(char.IsUpper)))
			{
				return name;
			}
			string text = name.Substring(0, 1);
			string str = name.Substring(1);
			return text.ToLowerInvariant() + str;
		}
	}
}
