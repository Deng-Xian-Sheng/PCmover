using System;
using System.Reflection;
using System.Security;
using System.Text;

namespace System.Runtime.Remoting
{
	// Token: 0x020007CD RID: 1997
	internal static class XmlNamespaceEncoder
	{
		// Token: 0x060056BD RID: 22205 RVA: 0x00134094 File Offset: 0x00132294
		[SecurityCritical]
		internal static string GetXmlNamespaceForType(RuntimeType type, string dynamicUrl)
		{
			string fullName = type.FullName;
			RuntimeAssembly runtimeAssembly = type.GetRuntimeAssembly();
			StringBuilder stringBuilder = new StringBuilder(256);
			Assembly assembly = typeof(string).Module.Assembly;
			if (runtimeAssembly == assembly)
			{
				stringBuilder.Append(SoapServices.namespaceNS);
				stringBuilder.Append(fullName);
			}
			else
			{
				stringBuilder.Append(SoapServices.fullNS);
				stringBuilder.Append(fullName);
				stringBuilder.Append('/');
				stringBuilder.Append(runtimeAssembly.GetSimpleName());
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060056BE RID: 22206 RVA: 0x00134120 File Offset: 0x00132320
		[SecurityCritical]
		internal static string GetXmlNamespaceForTypeNamespace(RuntimeType type, string dynamicUrl)
		{
			string @namespace = type.Namespace;
			RuntimeAssembly runtimeAssembly = type.GetRuntimeAssembly();
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			Assembly assembly = typeof(string).Module.Assembly;
			if (runtimeAssembly == assembly)
			{
				stringBuilder.Append(SoapServices.namespaceNS);
				stringBuilder.Append(@namespace);
			}
			else
			{
				stringBuilder.Append(SoapServices.fullNS);
				stringBuilder.Append(@namespace);
				stringBuilder.Append('/');
				stringBuilder.Append(runtimeAssembly.GetSimpleName());
			}
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		// Token: 0x060056BF RID: 22207 RVA: 0x001341AC File Offset: 0x001323AC
		[SecurityCritical]
		internal static string GetTypeNameForSoapActionNamespace(string uri, out bool assemblyIncluded)
		{
			assemblyIncluded = false;
			string fullNS = SoapServices.fullNS;
			string namespaceNS = SoapServices.namespaceNS;
			if (uri.StartsWith(fullNS, StringComparison.Ordinal))
			{
				uri = uri.Substring(fullNS.Length);
				char[] separator = new char[]
				{
					'/'
				};
				string[] array = uri.Split(separator);
				if (array.Length != 2)
				{
					return null;
				}
				assemblyIncluded = true;
				return array[0] + ", " + array[1];
			}
			else
			{
				if (uri.StartsWith(namespaceNS, StringComparison.Ordinal))
				{
					string simpleName = ((RuntimeAssembly)typeof(string).Module.Assembly).GetSimpleName();
					assemblyIncluded = true;
					return uri.Substring(namespaceNS.Length) + ", " + simpleName;
				}
				return null;
			}
		}
	}
}
