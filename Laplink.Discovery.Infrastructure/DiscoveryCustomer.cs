using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Threading.Tasks;
using Laplink.Tools.Helpers;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x02000002 RID: 2
	public class DiscoveryCustomer : IDiscoveryOutput, IDisposable
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public LlTraceSource Ts { get; }

		// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public DiscoveryCustomer(LlTraceSource ts)
		{
			this.Ts = ts;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002072 File Offset: 0x00000272
		protected virtual void OnDiscoveryBegin()
		{
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002072 File Offset: 0x00000272
		protected virtual void OnDiscoveryEnd()
		{
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002072 File Offset: 0x00000272
		protected virtual void OnEndpointFound(EndpointDiscoveryMetadata edm)
		{
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002072 File Offset: 0x00000272
		protected virtual void OnEndpointLost(EndpointDiscoveryMetadata edm)
		{
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002074 File Offset: 0x00000274
		public virtual void FireEndpointChange(EndpointDiscoveryMetadata edm, DiscoveryEndpointChange change)
		{
			if (change == DiscoveryEndpointChange.Found)
			{
				this.OnEndpointFound(edm);
				return;
			}
			this.OnEndpointLost(edm);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002072 File Offset: 0x00000272
		protected virtual void OnEndpointFound(EndpointAddress address)
		{
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002072 File Offset: 0x00000272
		protected virtual void OnEndpointLost(EndpointAddress address)
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002088 File Offset: 0x00000288
		public virtual void FireEndpointChange(EndpointAddress address, DiscoveryEndpointChange change)
		{
			if (change == DiscoveryEndpointChange.Found)
			{
				this.OnEndpointFound(address);
				return;
			}
			this.OnEndpointLost(address);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000209C File Offset: 0x0000029C
		public void AddDiscoveryMethod(IDiscoveryMethod discoveryMethod)
		{
			if (discoveryMethod == null || !discoveryMethod.IsEnabled)
			{
				return;
			}
			this._discoveryMethods.Add(discoveryMethod);
			discoveryMethod.StartMonitoring();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000020C0 File Offset: 0x000002C0
		public Task FindAsync()
		{
			this.OnDiscoveryBegin();
			List<Task> list = new List<Task>();
			foreach (IDiscoveryMethod discoveryMethod in this._discoveryMethods)
			{
				if (discoveryMethod.UseAsync)
				{
					list.Add(discoveryMethod.FindEndpointsAsync());
				}
				else
				{
					list.Add(Task.Run(new Action(discoveryMethod.FindEndpoints)));
				}
			}
			return Task.WhenAll(list).ContinueWith(delegate(Task t)
			{
				this.OnDiscoveryEnd();
			});
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002160 File Offset: 0x00000360
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposedValue)
			{
				this.disposedValue = true;
				foreach (IDiscoveryMethod discoveryMethod in this._discoveryMethods)
				{
					discoveryMethod.Dispose();
				}
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000021C4 File Offset: 0x000003C4
		~DiscoveryCustomer()
		{
			this.Dispose(false);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021F4 File Offset: 0x000003F4
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x04000002 RID: 2
		private List<IDiscoveryMethod> _discoveryMethods = new List<IDiscoveryMethod>();

		// Token: 0x04000003 RID: 3
		private bool disposedValue;
	}
}
