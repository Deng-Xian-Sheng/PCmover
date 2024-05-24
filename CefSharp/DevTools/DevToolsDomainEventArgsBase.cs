using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools
{
	// Token: 0x0200011F RID: 287
	[DataContract]
	public abstract class DevToolsDomainEventArgsBase : EventArgs
	{
		// Token: 0x0600086D RID: 2157 RVA: 0x0000DA7F File Offset: 0x0000BC7F
		public static object StringToEnum(Type enumType, string input)
		{
			return DevToolsDomainEntityBase.StringToEnum(enumType, input);
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x0000DA88 File Offset: 0x0000BC88
		public static string EnumToString(Enum e)
		{
			return DevToolsDomainEntityBase.EnumToString(e);
		}
	}
}
