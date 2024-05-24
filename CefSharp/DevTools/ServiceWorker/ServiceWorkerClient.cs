using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.ServiceWorker
{
	// Token: 0x02000214 RID: 532
	public class ServiceWorkerClient : DevToolsDomainBase
	{
		// Token: 0x06000F3F RID: 3903 RVA: 0x00014368 File Offset: 0x00012568
		public ServiceWorkerClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000050 RID: 80
		// (add) Token: 0x06000F40 RID: 3904 RVA: 0x00014377 File Offset: 0x00012577
		// (remove) Token: 0x06000F41 RID: 3905 RVA: 0x0001438A File Offset: 0x0001258A
		public event EventHandler<WorkerErrorReportedEventArgs> WorkerErrorReported
		{
			add
			{
				this._client.AddEventHandler<WorkerErrorReportedEventArgs>("ServiceWorker.workerErrorReported", value);
			}
			remove
			{
				this._client.RemoveEventHandler<WorkerErrorReportedEventArgs>("ServiceWorker.workerErrorReported", value);
			}
		}

		// Token: 0x14000051 RID: 81
		// (add) Token: 0x06000F42 RID: 3906 RVA: 0x0001439E File Offset: 0x0001259E
		// (remove) Token: 0x06000F43 RID: 3907 RVA: 0x000143B1 File Offset: 0x000125B1
		public event EventHandler<WorkerRegistrationUpdatedEventArgs> WorkerRegistrationUpdated
		{
			add
			{
				this._client.AddEventHandler<WorkerRegistrationUpdatedEventArgs>("ServiceWorker.workerRegistrationUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<WorkerRegistrationUpdatedEventArgs>("ServiceWorker.workerRegistrationUpdated", value);
			}
		}

		// Token: 0x14000052 RID: 82
		// (add) Token: 0x06000F44 RID: 3908 RVA: 0x000143C5 File Offset: 0x000125C5
		// (remove) Token: 0x06000F45 RID: 3909 RVA: 0x000143D8 File Offset: 0x000125D8
		public event EventHandler<WorkerVersionUpdatedEventArgs> WorkerVersionUpdated
		{
			add
			{
				this._client.AddEventHandler<WorkerVersionUpdatedEventArgs>("ServiceWorker.workerVersionUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<WorkerVersionUpdatedEventArgs>("ServiceWorker.workerVersionUpdated", value);
			}
		}

		// Token: 0x06000F46 RID: 3910 RVA: 0x000143EC File Offset: 0x000125EC
		public Task<DevToolsMethodResponse> DeliverPushMessageAsync(string origin, string registrationId, string data)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("origin", origin);
			dictionary.Add("registrationId", registrationId);
			dictionary.Add("data", data);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("ServiceWorker.deliverPushMessage", dictionary);
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x00014434 File Offset: 0x00012634
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("ServiceWorker.disable", parameters);
		}

		// Token: 0x06000F48 RID: 3912 RVA: 0x00014454 File Offset: 0x00012654
		public Task<DevToolsMethodResponse> DispatchSyncEventAsync(string origin, string registrationId, string tag, bool lastChance)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("origin", origin);
			dictionary.Add("registrationId", registrationId);
			dictionary.Add("tag", tag);
			dictionary.Add("lastChance", lastChance);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("ServiceWorker.dispatchSyncEvent", dictionary);
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x000144B0 File Offset: 0x000126B0
		public Task<DevToolsMethodResponse> DispatchPeriodicSyncEventAsync(string origin, string registrationId, string tag)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("origin", origin);
			dictionary.Add("registrationId", registrationId);
			dictionary.Add("tag", tag);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("ServiceWorker.dispatchPeriodicSyncEvent", dictionary);
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x000144F8 File Offset: 0x000126F8
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("ServiceWorker.enable", parameters);
		}

		// Token: 0x06000F4B RID: 3915 RVA: 0x00014518 File Offset: 0x00012718
		public Task<DevToolsMethodResponse> InspectWorkerAsync(string versionId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("versionId", versionId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("ServiceWorker.inspectWorker", dictionary);
		}

		// Token: 0x06000F4C RID: 3916 RVA: 0x00014548 File Offset: 0x00012748
		public Task<DevToolsMethodResponse> SetForceUpdateOnPageLoadAsync(bool forceUpdateOnPageLoad)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("forceUpdateOnPageLoad", forceUpdateOnPageLoad);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("ServiceWorker.setForceUpdateOnPageLoad", dictionary);
		}

		// Token: 0x06000F4D RID: 3917 RVA: 0x00014580 File Offset: 0x00012780
		public Task<DevToolsMethodResponse> SkipWaitingAsync(string scopeURL)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("scopeURL", scopeURL);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("ServiceWorker.skipWaiting", dictionary);
		}

		// Token: 0x06000F4E RID: 3918 RVA: 0x000145B0 File Offset: 0x000127B0
		public Task<DevToolsMethodResponse> StartWorkerAsync(string scopeURL)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("scopeURL", scopeURL);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("ServiceWorker.startWorker", dictionary);
		}

		// Token: 0x06000F4F RID: 3919 RVA: 0x000145E0 File Offset: 0x000127E0
		public Task<DevToolsMethodResponse> StopAllWorkersAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("ServiceWorker.stopAllWorkers", parameters);
		}

		// Token: 0x06000F50 RID: 3920 RVA: 0x00014600 File Offset: 0x00012800
		public Task<DevToolsMethodResponse> StopWorkerAsync(string versionId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("versionId", versionId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("ServiceWorker.stopWorker", dictionary);
		}

		// Token: 0x06000F51 RID: 3921 RVA: 0x00014630 File Offset: 0x00012830
		public Task<DevToolsMethodResponse> UnregisterAsync(string scopeURL)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("scopeURL", scopeURL);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("ServiceWorker.unregister", dictionary);
		}

		// Token: 0x06000F52 RID: 3922 RVA: 0x00014660 File Offset: 0x00012860
		public Task<DevToolsMethodResponse> UpdateRegistrationAsync(string scopeURL)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("scopeURL", scopeURL);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("ServiceWorker.updateRegistration", dictionary);
		}

		// Token: 0x040007C8 RID: 1992
		private IDevToolsClient _client;
	}
}
