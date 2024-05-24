using System;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.Contracts;
using PCmover.Infrastructure;

namespace ClientEngineModule.Wcf
{
	// Token: 0x02000008 RID: 8
	public class ImageMachineAppInvActivityClient : AppInvActivityClient
	{
		// Token: 0x0600001F RID: 31 RVA: 0x0000266F File Offset: 0x0000086F
		public ImageMachineAppInvActivityClient(PCmoverEngineLive engine) : base(engine)
		{
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002678 File Offset: 0x00000878
		public override void OnProgress(ActivityInfo activityInfo, ProgressInfo progressInfo)
		{
			base.Engine.EventAggregator.GetEvent<EngineEvents.ImageAppInventoryProgressChanged>().Publish(progressInfo);
			base.OnProgress(activityInfo, progressInfo);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002698 File Offset: 0x00000898
		public override void OnSucceeded(ActivityInfo info)
		{
			ImageMachineAppInvActivityClient.<OnSucceeded>d__2 <OnSucceeded>d__;
			<OnSucceeded>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnSucceeded>d__.<>4__this = this;
			<OnSucceeded>d__.info = info;
			<OnSucceeded>d__.<>1__state = -1;
			<OnSucceeded>d__.<>t__builder.Start<ImageMachineAppInvActivityClient.<OnSucceeded>d__2>(ref <OnSucceeded>d__);
		}
	}
}
