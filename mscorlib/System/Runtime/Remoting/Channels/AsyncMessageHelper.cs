using System;
using System.Reflection;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000832 RID: 2098
	internal static class AsyncMessageHelper
	{
		// Token: 0x060059B7 RID: 22967 RVA: 0x0013C4D0 File Offset: 0x0013A6D0
		internal static void GetOutArgs(ParameterInfo[] syncParams, object[] syncArgs, object[] endArgs)
		{
			int num = 0;
			for (int i = 0; i < syncParams.Length; i++)
			{
				if (syncParams[i].IsOut || syncParams[i].ParameterType.IsByRef)
				{
					endArgs[num++] = syncArgs[i];
				}
			}
		}
	}
}
