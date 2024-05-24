using System;
using System.Reflection;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x020007A3 RID: 1955
	internal sealed class SerObjectInfoCache
	{
		// Token: 0x060054E5 RID: 21733 RVA: 0x0012DF0E File Offset: 0x0012C10E
		internal SerObjectInfoCache(string typeName, string assemblyName, bool hasTypeForwardedFrom)
		{
			this.fullTypeName = typeName;
			this.assemblyString = assemblyName;
			this.hasTypeForwardedFrom = hasTypeForwardedFrom;
		}

		// Token: 0x060054E6 RID: 21734 RVA: 0x0012DF2C File Offset: 0x0012C12C
		internal SerObjectInfoCache(Type type)
		{
			TypeInformation typeInformation = BinaryFormatter.GetTypeInformation(type);
			this.fullTypeName = typeInformation.FullTypeName;
			this.assemblyString = typeInformation.AssemblyString;
			this.hasTypeForwardedFrom = typeInformation.HasTypeForwardedFrom;
		}

		// Token: 0x04002701 RID: 9985
		internal string fullTypeName;

		// Token: 0x04002702 RID: 9986
		internal string assemblyString;

		// Token: 0x04002703 RID: 9987
		internal bool hasTypeForwardedFrom;

		// Token: 0x04002704 RID: 9988
		internal MemberInfo[] memberInfos;

		// Token: 0x04002705 RID: 9989
		internal string[] memberNames;

		// Token: 0x04002706 RID: 9990
		internal Type[] memberTypes;
	}
}
