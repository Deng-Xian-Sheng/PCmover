using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace CefSharp.Internals.Wcf
{
	// Token: 0x020000F1 RID: 241
	internal sealed class JavascriptCallbackEndpointBehavior : IEndpointBehavior
	{
		// Token: 0x06000719 RID: 1817 RVA: 0x0000BBF3 File Offset: 0x00009DF3
		public JavascriptCallbackEndpointBehavior(IJavascriptCallbackFactory callbackFactory)
		{
			this.callbackFactory = callbackFactory;
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x0000BC02 File Offset: 0x00009E02
		public void Validate(ServiceEndpoint endpoint)
		{
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x0000BC04 File Offset: 0x00009E04
		public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
		{
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x0000BC08 File Offset: 0x00009E08
		public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
		{
			foreach (OperationDescription operationDescription in from o in endpoint.Contract.Operations
			where JavascriptCallbackEndpointBehavior.Methods.Contains(o.Name)
			select o)
			{
				operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>().DataContractSurrogate = new JavascriptCallbackSurrogate(this.callbackFactory);
			}
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x0000BC94 File Offset: 0x00009E94
		public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
		{
		}

		// Token: 0x04000398 RID: 920
		private static readonly List<string> Methods = new List<string>
		{
			ReflectionUtils.GetMethodName<IBrowserProcess>((IBrowserProcess p) => p.CallMethod(0L, null, null))
		};

		// Token: 0x04000399 RID: 921
		private readonly IJavascriptCallbackFactory callbackFactory;
	}
}
