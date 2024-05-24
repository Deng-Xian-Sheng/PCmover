using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ServiceModel.Discovery;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using WizardModule;

namespace MenuModule.ViewModels
{
	// Token: 0x0200000A RID: 10
	public class RemoteMenuViewModel : BindableBase, INavigationAware
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000080 RID: 128 RVA: 0x0000354A File Offset: 0x0000174A
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00003552 File Offset: 0x00001752
		public EndpointDiscoveryMetadata CurrentSelectedEndpointAddress
		{
			get
			{
				return this._CurrentSelectedEndpointAddress;
			}
			set
			{
				this.SetProperty<EndpointDiscoveryMetadata>(ref this._CurrentSelectedEndpointAddress, value, "CurrentSelectedEndpointAddress");
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00003567 File Offset: 0x00001767
		// (set) Token: 0x06000083 RID: 131 RVA: 0x0000356F File Offset: 0x0000176F
		public ObservableCollection<EndpointDiscoveryMetadata> Endpoints
		{
			get
			{
				return this._Endpoints;
			}
			private set
			{
				this.SetProperty<ObservableCollection<EndpointDiscoveryMetadata>>(ref this._Endpoints, value, "Endpoints");
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003584 File Offset: 0x00001784
		public RemoteMenuViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IWizardParameters wizardParameters)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.pcmoverEngine = pcmoverEngine;
			this.container = container;
			this._wizardParameters = wizardParameters;
			this.Endpoints = new ObservableCollection<EndpointDiscoveryMetadata>();
			this.OnConnect = new DelegateCommand(new Action(this.OnConnectCommand));
			this.OnCancel = new DelegateCommand(new Action(this.OnCancelCommand));
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000035F8 File Offset: 0x000017F8
		private void resetEndpoint()
		{
			if (this.pcmoverEngine.IsLive)
			{
				foreach (ContainerRegistration containerRegistration in this.container.Registrations)
				{
					if (containerRegistration.RegisteredType == typeof(IPCmoverEngine) && containerRegistration.LifetimeManagerType == typeof(ContainerControlledLifetimeManager))
					{
						containerRegistration.LifetimeManager.RemoveValue();
					}
				}
				this._wizardParameters.PcmoverServiceAddress = this.CurrentSelectedEndpointAddress.Address;
				this.container.Resolve(Array.Empty<ResolverOverride>()).RegisterPcmoverEngine(this.container);
				this.pcmoverEngine = this.container.Resolve(Array.Empty<ResolverOverride>());
				this.pcmoverEngine.Ts.TraceInformation("Connect to PCmover service from RemoteMenuViewModel.resetEndpoint constructor");
				Task.Run<bool>(() => this.pcmoverEngine.ConnectToPcmoverServiceAsync());
				this.eventAggregator.GetEvent<Events.EngineChanged>().Publish();
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000086 RID: 134 RVA: 0x0000370C File Offset: 0x0000190C
		// (set) Token: 0x06000087 RID: 135 RVA: 0x00003714 File Offset: 0x00001914
		public DelegateCommand OnConnect { get; private set; }

		// Token: 0x06000088 RID: 136 RVA: 0x00003720 File Offset: 0x00001920
		private void OnConnectCommand()
		{
			this.resetEndpoint();
			this.pcmoverEngine.GodMode = false;
			this.eventAggregator.GetEvent<Events.MigrationDefinitionChange>().Publish(false);
			this.eventAggregator.GetEvent<Events.UpdateProgramTitle>().Publish(this.CurrentSelectedEndpointAddress.Address.Uri.Host);
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00003775 File Offset: 0x00001975
		// (set) Token: 0x0600008A RID: 138 RVA: 0x0000377D File Offset: 0x0000197D
		public DelegateCommand OnCancel { get; private set; }

		// Token: 0x0600008B RID: 139 RVA: 0x00003786 File Offset: 0x00001986
		private void OnCancelCommand()
		{
			this.pcmoverEngine.GodMode = false;
			this.eventAggregator.GetEvent<Events.MigrationDefinitionChange>().Publish(false);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000024AC File Offset: 0x000006AC
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000024AF File Offset: 0x000006AF
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000037A8 File Offset: 0x000019A8
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			RemoteMenuViewModel.<OnNavigatedTo>d__27 <OnNavigatedTo>d__;
			<OnNavigatedTo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNavigatedTo>d__.<>4__this = this;
			<OnNavigatedTo>d__.<>1__state = -1;
			<OnNavigatedTo>d__.<>t__builder.Start<RemoteMenuViewModel.<OnNavigatedTo>d__27>(ref <OnNavigatedTo>d__);
		}

		// Token: 0x04000050 RID: 80
		private readonly IRegionManager regionManager;

		// Token: 0x04000051 RID: 81
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000052 RID: 82
		private IPCmoverEngine pcmoverEngine;

		// Token: 0x04000053 RID: 83
		private readonly IUnityContainer container;

		// Token: 0x04000054 RID: 84
		private readonly IWizardParameters _wizardParameters;

		// Token: 0x04000055 RID: 85
		private EndpointDiscoveryMetadata _CurrentSelectedEndpointAddress;

		// Token: 0x04000056 RID: 86
		private ObservableCollection<EndpointDiscoveryMetadata> _Endpoints;
	}
}
