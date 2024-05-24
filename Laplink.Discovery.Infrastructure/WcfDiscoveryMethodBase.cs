using System;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Threading;
using Laplink.Tools.Helpers;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x02000010 RID: 16
	public class WcfDiscoveryMethodBase
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002FE3 File Offset: 0x000011E3
		protected IDiscoveryOutput DiscoveryOutput { get; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002FEB File Offset: 0x000011EB
		protected LlTraceSource Ts
		{
			get
			{
				return this.DiscoveryOutput.Ts;
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002FF8 File Offset: 0x000011F8
		protected WcfDiscoveryMethodBase(IDiscoveryOutput discoveryOutput)
		{
			this.DiscoveryOutput = discoveryOutput;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003020 File Offset: 0x00001220
		protected void Find(DiscoveryEndpoint discoveryEndpoint, FindCriteria findCriteria)
		{
			using (DiscoveryClient discoveryClient = new DiscoveryClient(discoveryEndpoint))
			{
				ManualResetEvent discoveryCompleteEvent = new ManualResetEvent(false);
				EventHandler<FindProgressChangedEventArgs> value = delegate(object sender, FindProgressChangedEventArgs e)
				{
					this.DiscoveryOutput.FireEndpointChange(e.EndpointDiscoveryMetadata, DiscoveryEndpointChange.Found);
				};
				EventHandler<FindCompletedEventArgs> value2 = delegate(object sender, FindCompletedEventArgs e)
				{
					discoveryCompleteEvent.Set();
				};
				discoveryClient.FindProgressChanged += value;
				discoveryClient.FindCompleted += value2;
				bool flag = true;
				try
				{
					discoveryClient.FindAsync(findCriteria);
					discoveryCompleteEvent.WaitOne();
				}
				catch (TargetInvocationException ex)
				{
					if (!(ex.InnerException is EndpointNotFoundException))
					{
						this.Ts.TraceException(ex.InnerException ?? ex, "Find");
						throw;
					}
					discoveryCompleteEvent.Set();
					flag = false;
				}
				finally
				{
					discoveryClient.FindCompleted -= value2;
					discoveryClient.FindProgressChanged -= value;
					if (flag)
					{
						CodeHelper.trycatch(this.Ts, delegate()
						{
							discoveryClient.Close();
						}, "Find");
					}
					discoveryCompleteEvent.Dispose();
				}
			}
		}

		// Token: 0x0400002B RID: 43
		protected FindCriteria DefaultFindCriteria = new FindCriteria
		{
			Duration = new TimeSpan(0, 0, 2)
		};
	}
}
