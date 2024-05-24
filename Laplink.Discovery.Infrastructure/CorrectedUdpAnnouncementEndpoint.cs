using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Discovery;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x02000004 RID: 4
	public class CorrectedUdpAnnouncementEndpoint : UdpAnnouncementEndpoint
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00002548 File Offset: 0x00000748
		public CorrectedUdpAnnouncementEndpoint()
		{
			CustomBinding customBinding = new CustomBinding(base.Binding);
			customBinding.Elements.Insert(customBinding.Elements.Count - 1, new CorrectedUdpAnnouncementEndpoint.DisableIReplyChannelShapeBindingElement());
			base.Binding = customBinding;
		}

		// Token: 0x02000014 RID: 20
		private class DisableIReplyChannelShapeBindingElement : BindingElement
		{
			// Token: 0x06000078 RID: 120 RVA: 0x000035F4 File Offset: 0x000017F4
			public override BindingElement Clone()
			{
				return this;
			}

			// Token: 0x06000079 RID: 121 RVA: 0x000035F8 File Offset: 0x000017F8
			public override T GetProperty<T>(BindingContext context)
			{
				return default(T);
			}

			// Token: 0x0600007A RID: 122 RVA: 0x0000360E File Offset: 0x0000180E
			public override bool CanBuildChannelListener<TChannel>(BindingContext context)
			{
				return !(typeof(TChannel) == typeof(IReplyChannel)) && context.CanBuildInnerChannelListener<TChannel>();
			}
		}
	}
}
