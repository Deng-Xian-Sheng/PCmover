using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls.Primitives;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Commands;
using WizardModule.Properties;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000A7 RID: 167
	public class OfficeTrialViewModel : PopupViewModelBase
	{
		// Token: 0x06000EA9 RID: 3753 RVA: 0x00027504 File Offset: 0x00025704
		[Obsolete("For design only")]
		public OfficeTrialViewModel()
		{
			this._machineName = "DesignMachine";
		}

		// Token: 0x06000EAA RID: 3754 RVA: 0x00027518 File Offset: 0x00025718
		public OfficeTrialViewModel(IUnityContainer container, IPCmoverEngine engine, DefaultPolicy policy, IEnumerable<ApplicationData> configData)
		{
			this._container = container;
			this._policy = policy;
			string machineName;
			if (engine == null)
			{
				machineName = null;
			}
			else
			{
				MachineData thisMachine = engine.ThisMachine;
				machineName = ((thisMachine != null) ? thisMachine.NetName : null);
			}
			this._machineName = machineName;
			this.AppList = new ObservableCollection<ApplicationData>(configData);
			base.PopupData.Animation = PopupAnimation.Scroll;
			this.OnOfficeHelp = new DelegateCommand<string>(new Action<string>(this.OnOfficeHelpCommand), new Func<string, bool>(this.CanOnOfficeHelpCommand));
		}

		// Token: 0x17000680 RID: 1664
		// (get) Token: 0x06000EAB RID: 3755 RVA: 0x00027593 File Offset: 0x00025793
		public string OfficeTrialMessage
		{
			get
			{
				return string.Format(WizardModule.Properties.Resources.OfficeTrial, this._machineName);
			}
		}

		// Token: 0x17000681 RID: 1665
		// (get) Token: 0x06000EAC RID: 3756 RVA: 0x000275A5 File Offset: 0x000257A5
		// (set) Token: 0x06000EAD RID: 3757 RVA: 0x000275AD File Offset: 0x000257AD
		public ObservableCollection<ApplicationData> AppList
		{
			get
			{
				return this._AppList;
			}
			set
			{
				this.SetProperty<ObservableCollection<ApplicationData>>(ref this._AppList, value, "AppList");
			}
		}

		// Token: 0x17000682 RID: 1666
		// (get) Token: 0x06000EAE RID: 3758 RVA: 0x000275C2 File Offset: 0x000257C2
		public string OnlineSupport
		{
			get
			{
				if (!string.IsNullOrEmpty(PcmBrandUI.Properties.Resources.URL_OnlineSupport))
				{
					return PcmBrandUI.Properties.Resources.URL_OnlineSupport;
				}
				DefaultPolicy policy = this._policy;
				if (policy == null)
				{
					return null;
				}
				return policy.SupportEmail;
			}
		}

		// Token: 0x17000683 RID: 1667
		// (get) Token: 0x06000EAF RID: 3759 RVA: 0x000275E7 File Offset: 0x000257E7
		public string OnlineSupportDisplayURL
		{
			get
			{
				if (!string.IsNullOrEmpty(PcmBrandUI.Properties.Resources.URL_supportLink))
				{
					return PcmBrandUI.Properties.Resources.URL_supportLink;
				}
				DefaultPolicy policy = this._policy;
				if (policy == null)
				{
					return null;
				}
				return policy.SupportEmail;
			}
		}

		// Token: 0x17000684 RID: 1668
		// (get) Token: 0x06000EB0 RID: 3760 RVA: 0x0002760C File Offset: 0x0002580C
		public DelegateCommand<string> OnOfficeHelp { get; }

		// Token: 0x06000EB1 RID: 3761 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnOfficeHelpCommand(string arg)
		{
			return true;
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x00027614 File Offset: 0x00025814
		private void OnOfficeHelpCommand(string url)
		{
			OfficeTrialViewModel.<OnOfficeHelpCommand>d__19 <OnOfficeHelpCommand>d__;
			<OnOfficeHelpCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnOfficeHelpCommand>d__.<>4__this = this;
			<OnOfficeHelpCommand>d__.url = url;
			<OnOfficeHelpCommand>d__.<>1__state = -1;
			<OnOfficeHelpCommand>d__.<>t__builder.Start<OfficeTrialViewModel.<OnOfficeHelpCommand>d__19>(ref <OnOfficeHelpCommand>d__);
		}

		// Token: 0x040004F5 RID: 1269
		private readonly IUnityContainer _container;

		// Token: 0x040004F6 RID: 1270
		private readonly DefaultPolicy _policy;

		// Token: 0x040004F7 RID: 1271
		private string _machineName;

		// Token: 0x040004F8 RID: 1272
		private ObservableCollection<ApplicationData> _AppList;
	}
}
