using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Serialization.Formatters
{
	// Token: 0x0200075F RID: 1887
	[ComVisible(true)]
	public interface ISoapMessage
	{
		// Token: 0x17000DB8 RID: 3512
		// (get) Token: 0x060052F3 RID: 21235
		// (set) Token: 0x060052F4 RID: 21236
		string[] ParamNames { get; set; }

		// Token: 0x17000DB9 RID: 3513
		// (get) Token: 0x060052F5 RID: 21237
		// (set) Token: 0x060052F6 RID: 21238
		object[] ParamValues { get; set; }

		// Token: 0x17000DBA RID: 3514
		// (get) Token: 0x060052F7 RID: 21239
		// (set) Token: 0x060052F8 RID: 21240
		Type[] ParamTypes { get; set; }

		// Token: 0x17000DBB RID: 3515
		// (get) Token: 0x060052F9 RID: 21241
		// (set) Token: 0x060052FA RID: 21242
		string MethodName { get; set; }

		// Token: 0x17000DBC RID: 3516
		// (get) Token: 0x060052FB RID: 21243
		// (set) Token: 0x060052FC RID: 21244
		string XmlNameSpace { get; set; }

		// Token: 0x17000DBD RID: 3517
		// (get) Token: 0x060052FD RID: 21245
		// (set) Token: 0x060052FE RID: 21246
		Header[] Headers { get; set; }
	}
}
