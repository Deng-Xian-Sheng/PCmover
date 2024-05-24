using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Laplink.Tools.Helpers.Wcf
{
	// Token: 0x02000002 RID: 2
	public abstract class BindingFactory
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public string Scheme { get; protected set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002061 File Offset: 0x00000261
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00000269
		public Type Type { get; protected set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002072 File Offset: 0x00000272
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000207A File Offset: 0x0000027A
		public TimeSpan CloseTimeout { get; set; } = TimeSpan.FromMinutes(1.0);

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002083 File Offset: 0x00000283
		// (set) Token: 0x06000008 RID: 8 RVA: 0x0000208B File Offset: 0x0000028B
		public TimeSpan OpenTimeout { get; set; } = TimeSpan.FromSeconds(5.0);

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002094 File Offset: 0x00000294
		// (set) Token: 0x0600000A RID: 10 RVA: 0x0000209C File Offset: 0x0000029C
		public TimeSpan ReceiveTimeout { get; set; } = TimeSpan.MaxValue;

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020A5 File Offset: 0x000002A5
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020AD File Offset: 0x000002AD
		public TimeSpan SendTimeout { get; set; } = TimeSpan.FromMinutes(2.0);

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000020B6 File Offset: 0x000002B6
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000020BE File Offset: 0x000002BE
		public long MaxReceivedMessageSize { get; set; } = 10000000L;

		// Token: 0x0600000F RID: 15 RVA: 0x000020C8 File Offset: 0x000002C8
		public Binding CreateBinding(string parameters)
		{
			Binding binding = this.Create(parameters);
			this.SetBindingTimeouts(binding);
			return binding;
		}

		// Token: 0x06000010 RID: 16
		protected abstract Binding Create(string parameters);

		// Token: 0x06000011 RID: 17 RVA: 0x000020E5 File Offset: 0x000002E5
		public virtual EndpointAddress CreateEndpoint(Uri uri, Binding binding)
		{
			return new EndpointAddress(uri, Array.Empty<AddressHeader>());
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000020F2 File Offset: 0x000002F2
		public virtual string GetParameters(Binding binding)
		{
			return string.Empty;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000020F9 File Offset: 0x000002F9
		public void SetBindingTimeouts(Binding binding)
		{
			if (binding != null)
			{
				binding.CloseTimeout = this.CloseTimeout;
				binding.OpenTimeout = this.OpenTimeout;
				binding.SendTimeout = this.SendTimeout;
				binding.ReceiveTimeout = this.ReceiveTimeout;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000014 RID: 20 RVA: 0x0000212E File Offset: 0x0000032E
		public virtual string LocalHostName
		{
			get
			{
				return NetworkHelper.LocalHostName;
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002135 File Offset: 0x00000335
		public virtual LlUriProperties GetUriProperties()
		{
			return new LlUriProperties(this.Scheme);
		}
	}
}
