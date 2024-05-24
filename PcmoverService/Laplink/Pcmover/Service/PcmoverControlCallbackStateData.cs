using System;
using Laplink.Pcmover.Contracts;
using Laplink.Service.Contracts;
using Laplink.Service.Infrastructure;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000015 RID: 21
	public class PcmoverControlCallbackStateData : ControlCallbackStateData<IPcmoverControlCallback>
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00004086 File Offset: 0x00002286
		public override bool CanSendControlCallback
		{
			get
			{
				return base.CanSendControlCallback && this._manager.State.IsActive();
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000040A2 File Offset: 0x000022A2
		public PcmoverControlCallbackStateData(PcmoverManager manager) : base(manager)
		{
			this._manager = manager;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000040B2 File Offset: 0x000022B2
		protected override void OnControlCallbackChanged(IPcmoverControlCallback oldVal, IPcmoverControlCallback newVal)
		{
			this._manager.NotifyStatusInfoChanged();
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000040BF File Offset: 0x000022BF
		protected override void OnControlCallbackStateChanged(CallbackState oldVal, CallbackState newVal)
		{
			this._manager.CallbackReplies.CallForEach(delegate(CallbackReply reply)
			{
				reply.Refresh();
			});
		}

		// Token: 0x04000035 RID: 53
		private PcmoverManager _manager;
	}
}
