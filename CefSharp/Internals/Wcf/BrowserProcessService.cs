using System;
using System.ServiceModel;

namespace CefSharp.Internals.Wcf
{
	// Token: 0x020000EE RID: 238
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
	internal class BrowserProcessService : IBrowserProcess
	{
		// Token: 0x0600070D RID: 1805 RVA: 0x0000B958 File Offset: 0x00009B58
		public BrowserProcessService()
		{
			OperationContext operationContext = OperationContext.Current;
			this.host = (BrowserProcessServiceHost)operationContext.Host;
			this.javascriptObjectRepository = this.host.JavascriptObjectRepository;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x0000B994 File Offset: 0x00009B94
		public BrowserProcessResponse CallMethod(long objectId, string name, object[] parameters)
		{
			TryCallMethodResult tryCallMethodResult = this.javascriptObjectRepository.TryCallMethod(objectId, name, parameters);
			return new BrowserProcessResponse
			{
				Success = tryCallMethodResult.Success,
				Result = tryCallMethodResult.ReturnValue,
				Message = tryCallMethodResult.Exception
			};
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x0000B9DC File Offset: 0x00009BDC
		public BrowserProcessResponse GetProperty(long objectId, string name)
		{
			object result;
			string message;
			bool success = this.javascriptObjectRepository.TryGetProperty(objectId, name, out result, out message);
			return new BrowserProcessResponse
			{
				Success = success,
				Result = result,
				Message = message
			};
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x0000BA18 File Offset: 0x00009C18
		public BrowserProcessResponse SetProperty(long objectId, string name, object value)
		{
			string message;
			bool success = this.javascriptObjectRepository.TrySetProperty(objectId, name, value, out message);
			return new BrowserProcessResponse
			{
				Success = success,
				Result = null,
				Message = message
			};
		}

		// Token: 0x04000394 RID: 916
		private readonly IJavascriptObjectRepositoryInternal javascriptObjectRepository;

		// Token: 0x04000395 RID: 917
		private readonly BrowserProcessServiceHost host;
	}
}
