using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009FD RID: 2557
	internal class IStringableHelper
	{
		// Token: 0x060064EC RID: 25836 RVA: 0x00157C08 File Offset: 0x00155E08
		internal static string ToString(object obj)
		{
			IStringable stringable = obj as IStringable;
			if (stringable != null)
			{
				return stringable.ToString();
			}
			return obj.ToString();
		}
	}
}
