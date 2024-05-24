using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using CefSharp.DevTools.Browser;
using CefSharp.DevTools.DOMDebugger;
using CefSharp.DevTools.Emulation;
using CefSharp.DevTools.Network;

namespace CefSharp.DevTools
{
	// Token: 0x0200011C RID: 284
	public abstract class DevToolsDomainBase
	{
		// Token: 0x06000859 RID: 2137 RVA: 0x0000D5DC File Offset: 0x0000B7DC
		protected string EnumToString(Enum val)
		{
			MemberInfo[] member = val.GetType().GetMember(val.ToString());
			EnumMemberAttribute enumMemberAttribute = (EnumMemberAttribute)Attribute.GetCustomAttribute(member[0], typeof(EnumMemberAttribute), false);
			return enumMemberAttribute.Value;
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x0000D61A File Offset: 0x0000B81A
		protected IEnumerable<string> EnumToString(ContentEncoding[] values)
		{
			foreach (ContentEncoding contentEncoding in values)
			{
				MemberInfo[] member = contentEncoding.GetType().GetMember(contentEncoding.ToString());
				EnumMemberAttribute enumMemberAttribute = (EnumMemberAttribute)Attribute.GetCustomAttribute(member[0], typeof(EnumMemberAttribute), false);
				yield return enumMemberAttribute.Value;
			}
			ContentEncoding[] array = null;
			yield break;
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x0000D62A File Offset: 0x0000B82A
		protected IEnumerable<string> EnumToString(PermissionType[] values)
		{
			foreach (PermissionType permissionType in values)
			{
				MemberInfo[] member = permissionType.GetType().GetMember(permissionType.ToString());
				EnumMemberAttribute enumMemberAttribute = (EnumMemberAttribute)Attribute.GetCustomAttribute(member[0], typeof(EnumMemberAttribute), false);
				yield return enumMemberAttribute.Value;
			}
			PermissionType[] array = null;
			yield break;
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x0000D63A File Offset: 0x0000B83A
		protected IEnumerable<string> EnumToString(DisabledImageType[] values)
		{
			foreach (DisabledImageType disabledImageType in values)
			{
				MemberInfo[] member = disabledImageType.GetType().GetMember(disabledImageType.ToString());
				EnumMemberAttribute enumMemberAttribute = (EnumMemberAttribute)Attribute.GetCustomAttribute(member[0], typeof(EnumMemberAttribute), false);
				yield return enumMemberAttribute.Value;
			}
			DisabledImageType[] array = null;
			yield break;
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x0000D64A File Offset: 0x0000B84A
		protected IEnumerable<string> EnumToString(CSPViolationType[] values)
		{
			foreach (CSPViolationType cspviolationType in values)
			{
				MemberInfo[] member = cspviolationType.GetType().GetMember(cspviolationType.ToString());
				EnumMemberAttribute enumMemberAttribute = (EnumMemberAttribute)Attribute.GetCustomAttribute(member[0], typeof(EnumMemberAttribute), false);
				yield return enumMemberAttribute.Value;
			}
			CSPViolationType[] array = null;
			yield break;
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x0000D65A File Offset: 0x0000B85A
		protected string ToBase64String(byte[] bytes)
		{
			return Convert.ToBase64String(bytes);
		}
	}
}
