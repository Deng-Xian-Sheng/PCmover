using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Laplink.Download.Contracts;
using Laplink.Service.Contracts;

namespace Laplink.Download.Proxies
{
	// Token: 0x02000002 RID: 2
	public class DownloadControlClient : DownloadMonitorClient<IDownloadControl>, IDownloadControl, IDownloadMonitor, IDownloadQuery
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public DownloadControlClient(InstanceContext callbackInstance, Binding binding, EndpointAddress remoteAddress) : base(callbackInstance, binding, remoteAddress)
		{
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205B File Offset: 0x0000025B
		public DownloadControlClient(InstanceContext callbackInstance, string endpointConfigurationName) : base(callbackInstance, endpointConfigurationName)
		{
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002065 File Offset: 0x00000265
		public bool BecomeController(CallbackState controlCallbackState)
		{
			return base.Channel.BecomeController(controlCallbackState);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002073 File Offset: 0x00000273
		public void StopBeingController()
		{
			base.Channel.StopBeingController();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002080 File Offset: 0x00000280
		public void ConfigureControlCallbacks(CallbackState controlCallbackState)
		{
			base.Channel.ConfigureControlCallbacks(controlCallbackState);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000208E File Offset: 0x0000028E
		public void PerformPendingReboot()
		{
			base.Channel.PerformPendingReboot();
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000209B File Offset: 0x0000029B
		public ObservableCollection<DownloadPackage> GetDownloadPackages()
		{
			return base.Channel.GetDownloadPackages();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020A8 File Offset: 0x000002A8
		public void CancelPackage(string Id)
		{
			base.Channel.CancelPackage(Id);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020B6 File Offset: 0x000002B6
		public void ProcessAll()
		{
			base.Channel.ProcessAll();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020C3 File Offset: 0x000002C3
		public void SetDataFile(string DataFile)
		{
			base.Channel.SetDataFile(DataFile);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000020D1 File Offset: 0x000002D1
		public void UpdateRunKey(string ValueName, string Value, bool Remove)
		{
			base.Channel.UpdateRunKey(ValueName, Value, Remove);
		}
	}
}
