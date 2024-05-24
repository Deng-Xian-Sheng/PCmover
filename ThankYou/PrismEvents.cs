using System;
using Prism.Events;
using ThankYou.UIData;

namespace ThankYou
{
	// Token: 0x02000004 RID: 4
	public class PrismEvents
	{
		// Token: 0x02000017 RID: 23
		public class SetHeaderTitle : PubSubEvent<string>
		{
		}

		// Token: 0x02000018 RID: 24
		public class UIDownloadComplete : PubSubEvent<MainData>
		{
		}

		// Token: 0x02000019 RID: 25
		public class DontShowCheckChanged : PubSubEvent<bool>
		{
		}

		// Token: 0x0200001A RID: 26
		public class HideFooterChanged : PubSubEvent<bool>
		{
		}
	}
}
