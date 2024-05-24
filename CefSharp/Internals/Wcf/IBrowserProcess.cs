using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace CefSharp.Internals.Wcf
{
	// Token: 0x020000F0 RID: 240
	[ServiceContract(SessionMode = SessionMode.Required)]
	[ServiceKnownType(typeof(object[]))]
	[ServiceKnownType(typeof(Dictionary<string, object>))]
	[ServiceKnownType(typeof(JavascriptObject))]
	[ServiceKnownType(typeof(JavascriptMethod))]
	[ServiceKnownType(typeof(JavascriptProperty))]
	[ServiceKnownType(typeof(JavascriptCallback))]
	public interface IBrowserProcess
	{
		// Token: 0x06000716 RID: 1814
		[OperationContract]
		BrowserProcessResponse CallMethod(long objectId, string name, object[] parameters);

		// Token: 0x06000717 RID: 1815
		[OperationContract]
		BrowserProcessResponse GetProperty(long objectId, string name);

		// Token: 0x06000718 RID: 1816
		[OperationContract]
		BrowserProcessResponse SetProperty(long objectId, string name, object value);
	}
}
