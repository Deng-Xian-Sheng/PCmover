using System;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace MenuModule.ViewModels
{
	// Token: 0x02000007 RID: 7
	public class GodModeViewModel : BindableBase, INavigationAware
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002419 File Offset: 0x00000619
		// (set) Token: 0x06000011 RID: 17 RVA: 0x00002421 File Offset: 0x00000621
		public DelegateCommand<string> NavigateCommand { get; set; }

		// Token: 0x06000012 RID: 18 RVA: 0x0000242C File Offset: 0x0000062C
		public GodModeViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.pcmoverEngine = pcmoverEngine;
			this.OnUpdate = new DelegateCommand(new Action(this.OnUpdateCommand));
			this.NavigateCommand = new DelegateCommand<string>(new Action<string>(this.DoNavigate));
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002482 File Offset: 0x00000682
		private void DoNavigate(string navigationPath)
		{
			this.regionManager.RequestNavigate("RegionGMTabControl", navigationPath);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002495 File Offset: 0x00000695
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.regionManager.RequestNavigate("RegionGMTabControl", "MockConfig");
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000024AC File Offset: 0x000006AC
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000024AF File Offset: 0x000006AF
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000024B1 File Offset: 0x000006B1
		// (set) Token: 0x06000018 RID: 24 RVA: 0x000024B9 File Offset: 0x000006B9
		public DelegateCommand OnUpdate { get; private set; }

		// Token: 0x06000019 RID: 25 RVA: 0x000024C2 File Offset: 0x000006C2
		private void OnUpdateCommand()
		{
			this.eventAggregator.GetEvent<Events.MigrationDefinitionChange>().Publish(this.pcmoverEngine.GodMode);
		}

		// Token: 0x0400001F RID: 31
		private readonly IRegionManager regionManager;

		// Token: 0x04000020 RID: 32
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000021 RID: 33
		private readonly IPCmoverEngine pcmoverEngine;
	}
}
