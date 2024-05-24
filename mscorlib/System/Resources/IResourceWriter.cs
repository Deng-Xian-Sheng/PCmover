using System;
using System.Runtime.InteropServices;

namespace System.Resources
{
	// Token: 0x0200038E RID: 910
	[ComVisible(true)]
	public interface IResourceWriter : IDisposable
	{
		// Token: 0x06002CEB RID: 11499
		void AddResource(string name, string value);

		// Token: 0x06002CEC RID: 11500
		void AddResource(string name, object value);

		// Token: 0x06002CED RID: 11501
		void AddResource(string name, byte[] value);

		// Token: 0x06002CEE RID: 11502
		void Close();

		// Token: 0x06002CEF RID: 11503
		void Generate();
	}
}
