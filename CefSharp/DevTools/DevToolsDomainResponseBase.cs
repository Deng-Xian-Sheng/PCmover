using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools
{
	// Token: 0x02000120 RID: 288
	[DataContract]
	public abstract class DevToolsDomainResponseBase
	{
		// Token: 0x06000870 RID: 2160 RVA: 0x0000DA98 File Offset: 0x0000BC98
		public byte[] Convert(string data)
		{
			return System.Convert.FromBase64String(data);
		}
	}
}
