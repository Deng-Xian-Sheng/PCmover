using System;
using System.IO;
using System.Windows;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using WizardModule.Engine;
using WizardModule.Migration;
using WizardModule.Properties;
using WizardModule.Views;
using WizardModule.Views.Compact;
using WizardModule.Views.Dialogs;

namespace WizardModule
{
	// Token: 0x02000006 RID: 6
	public class WizardModuleModule : IPcmoverModule, IModule, IWizardModuleModule
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002971 File Offset: 0x00000B71
		// (set) Token: 0x06000064 RID: 100 RVA: 0x00002979 File Offset: 0x00000B79
		public Uri WelcomeUri { get; set; }

		// Token: 0x06000065 RID: 101 RVA: 0x00002982 File Offset: 0x00000B82
		public WizardModuleModule(IUnityContainer container)
		{
			this._originalContainer = container;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00002991 File Offset: 0x00000B91
		public void Initialize()
		{
			this._originalContainer.RegisterInstance(this);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000029A0 File Offset: 0x00000BA0
		public bool DeferredInitialize(IUnityContainer container)
		{
			LlTraceSource ts = container.Resolve(Array.Empty<ResolverOverride>());
			WizardParameters wizardParameters = container.Resolve(Array.Empty<ResolverOverride>());
			container.RegisterInstance(this, new ContainerControlledLifetimeManager());
			if (!container.IsRegistered(typeof(IMigrationDefinition)))
			{
				container.RegisterType(new ContainerControlledLifetimeManager(), Array.Empty<InjectionMember>());
			}
			MigrationDefinition migrationDefinition = container.Resolve(Array.Empty<ResolverOverride>());
			if (!container.IsRegistered(typeof(NavigationHelper)))
			{
				container.RegisterType(new ContainerControlledLifetimeManager(), Array.Empty<InjectionMember>());
			}
			NavigationHelper navigationHelper = container.Resolve(Array.Empty<ResolverOverride>());
			navigationHelper.IsPlayingBackRecordedPolicy = migrationDefinition.UseRecordedPolicy;
			if (wizardParameters.AuthInfo == null)
			{
				wizardParameters.AuthInfo = new AuthorizationRequestData();
			}
			if (wizardParameters.PolicyInfo == null)
			{
				wizardParameters.PolicyInfo = new PolicyInfo();
			}
			if (wizardParameters.ServiceEnvironment == null)
			{
				wizardParameters.ServiceEnvironment = new EnvLookup(Environment.GetEnvironmentVariables());
			}
			container.RegisterInstance(wizardParameters, new ContainerControlledLifetimeManager());
			DefaultPolicy defaultPolicy = wizardParameters.PolicyInfo.Policy;
			if (defaultPolicy == null)
			{
				try
				{
					string text = string.Empty;
					PolicyInfo policyInfo = wizardParameters.PolicyInfo;
					if (!string.IsNullOrEmpty((policyInfo != null) ? policyInfo.PolicyPath : null))
					{
						text = wizardParameters.PolicyInfo.PolicyPath;
					}
					else if (migrationDefinition.UseRecordedPolicy)
					{
						text = DefaultPolicy.RecordedPolicyPath;
					}
					else if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Policy.pol")))
					{
						text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Policy.pol");
					}
					if (string.IsNullOrEmpty(text))
					{
						defaultPolicy = new DefaultPolicy(DefaultPolicy.DefaultPolicyType);
					}
					else
					{
						defaultPolicy = DefaultPolicy.Load(text);
						if (defaultPolicy == null && File.Exists(text))
						{
							throw new InvalidPolicyFormatException();
						}
						if (!defaultPolicy.IsValidPolicyVersion)
						{
							throw new InvalidPolicyVersionException();
						}
					}
				}
				catch (InvalidPolicyVersionException)
				{
					SplashScreen splashScreen = wizardParameters.SplashScreen;
					if (splashScreen != null)
					{
						splashScreen.Close(new TimeSpan(0L));
					}
					MessageBox.Show(string.Format(Resources.ERROR_CantOpenPolicyVersion, defaultPolicy.SupportEmail), Resources.ERROR);
					throw;
				}
				catch (InvalidPolicyFormatException)
				{
					SplashScreen splashScreen2 = wizardParameters.SplashScreen;
					if (splashScreen2 != null)
					{
						splashScreen2.Close(new TimeSpan(0L));
					}
					MessageBox.Show(string.Format(Resources.ERROR_CantOpenFormat, wizardParameters.PolicyInfo.PolicyPath, defaultPolicy.SupportEmail), Resources.ERROR);
					throw;
				}
			}
			if (defaultPolicy == null)
			{
				SplashScreen splashScreen3 = wizardParameters.SplashScreen;
				if (splashScreen3 != null)
				{
					splashScreen3.Close(new TimeSpan(0L));
				}
				return false;
			}
			if (defaultPolicy.PolicyType == DefaultPolicy.DefaultType.MSFTProfile || defaultPolicy.PolicyType == DefaultPolicy.DefaultType.Profile)
			{
				migrationDefinition.IsSelfTransfer = true;
			}
			if (defaultPolicy.DoRecord)
			{
				defaultPolicy.DoRecord = !wizardParameters.DisableRecord;
			}
			defaultPolicy.MinUI = wizardParameters.MinUI;
			if (wizardParameters.ForceSimMode)
			{
				defaultPolicy.GnSimMode = true;
			}
			if (wizardParameters.Newpol)
			{
				defaultPolicy.SupressRunPolicyPrompt = true;
			}
			container.RegisterInstance(defaultPolicy, new ContainerControlledLifetimeManager());
			container.RegisterInstance(defaultPolicy, new ContainerControlledLifetimeManager());
			container.Resolve(Array.Empty<ResolverOverride>()).GetEvent<Events.PolicyInitialized>().Publish(defaultPolicy);
			if (defaultPolicy.enginePolicy.Connection.File.Settings.CloudBased != "Local")
			{
				container.RegisterInstance(new CloudAuthentication(defaultPolicy));
			}
			IPCmoverEngine ipcmoverEngine = container.Resolve(Array.Empty<ResolverOverride>());
			container.RegisterType(new ContainerControlledLifetimeManager(), Array.Empty<InjectionMember>());
			container.Resolve(Array.Empty<ResolverOverride>());
			IRegionViewRegistry regionViewRegistry = container.Resolve(Array.Empty<ResolverOverride>());
			if (wizardParameters.LaunchDownloadManager)
			{
				migrationDefinition.LaunchDownloadManager = true;
				regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			}
			else if (!string.IsNullOrWhiteSpace(wizardParameters.DeferredVan))
			{
				regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			}
			else
			{
				if (ipcmoverEngine.IsRemoteUI)
				{
					this.WelcomeUri = new Uri("AdvancedOptions", UriKind.Relative);
					bool? singleMachineMode = wizardParameters.SingleMachineMode;
					bool flag = true;
					if (singleMachineMode.GetValueOrDefault() == flag & singleMachineMode != null)
					{
						regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
						regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
					}
					else
					{
						regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
						regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
					}
				}
				else if (defaultPolicy.StartOnAdvancedOptionsPage)
				{
					this.WelcomeUri = new Uri("AdvancedOptions", UriKind.Relative);
					regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
					regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
				}
				else
				{
					this.WelcomeUri = new Uri("WelcomePage", UriKind.Relative);
					regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
					regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
				}
				this.InitRegions(container, wizardParameters.CompactUI);
				navigationHelper.Init(container, defaultPolicy, ts);
			}
			return true;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002F64 File Offset: 0x00001164
		private void InitRegions(IUnityContainer container, bool compactUI)
		{
			IRegionViewRegistry regionViewRegistry = container.Resolve(Array.Empty<ResolverOverride>());
			if (compactUI)
			{
				regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionFileBased, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionImageAndDrive, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionUpgradeAssistant, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionProfile, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionTransfer, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionChooseTransferEverything, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionChooseTransferOnly, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionChooseFilesOnly, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionChooseLetMeChoose, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.SummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.SummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.SummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.SummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.SummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.TransferCompleteDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.TransferCompleteDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.TransferCompleteDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.TransferCompleteDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.TransferCompleteDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedCustomizeDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedCustomizeDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedCustomizeDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedCustomizeDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedCustomizeDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedSummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedSummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedSummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedSummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedSummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
			}
			else
			{
				regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionFileBased, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionImageAndDrive, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionUpgradeAssistant, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionProfile, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionTransfer, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionChooseTransferEverything, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionChooseTransferOnly, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionChooseFilesOnly, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionChooseLetMeChoose, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.SummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.SummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.SummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.SummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.SummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.TransferCompleteDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.TransferCompleteDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.TransferCompleteDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.TransferCompleteDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.TransferCompleteDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedCustomizeDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedCustomizeDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedCustomizeDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedCustomizeDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedCustomizeDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedSummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedSummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedSummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedSummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
				regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedSummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
			}
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.WizardRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.SummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.TransferCompleteDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedCustomizeDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedSummaryDetailButtons, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedCustomizationRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedCustomizationRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.FilesBasedCustomizationRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionOverlayPopup, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionOverlayPopup, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionOverlayPopup, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionOverlayPopup, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionOverlayPopup, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.SslConfiguration, () => container.Resolve(Array.Empty<ResolverOverride>()));
		}

		// Token: 0x04000028 RID: 40
		private readonly IUnityContainer _originalContainer;
	}
}
