using System;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;

namespace PCmover.Infrastructure
{
	// Token: 0x02000005 RID: 5
	public class BindablePcmoverEngineBase : BindableBase
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000021DA File Offset: 0x000003DA
		// (set) Token: 0x06000017 RID: 23 RVA: 0x000021E2 File Offset: 0x000003E2
		private protected IPCmoverEngine pcmoverEngine { protected get; private set; }

		// Token: 0x06000018 RID: 24 RVA: 0x000021EB File Offset: 0x000003EB
		public BindablePcmoverEngineBase(IUnityContainer container, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine)
		{
			this.container = container;
			this.eventAggregator = eventAggregator;
			this.pcmoverEngine = pcmoverEngine;
			if (eventAggregator != null)
			{
				eventAggregator.GetEvent<Events.EngineChanged>().Subscribe(new Action(this.OnEngineChanged));
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002223 File Offset: 0x00000423
		private void OnEngineChanged()
		{
			this.pcmoverEngine = this.container.Resolve(Array.Empty<ResolverOverride>());
		}

		// Token: 0x04000009 RID: 9
		protected readonly IUnityContainer container;

		// Token: 0x0400000A RID: 10
		protected readonly IEventAggregator eventAggregator;
	}
}
