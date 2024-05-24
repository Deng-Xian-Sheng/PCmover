using System;
using Laplink.Tools.Helpers;
using Laplink.Tools.Popups;
using Laplink.Tools.Ui.Styles;
using Microsoft.Practices.Unity;
using Prism.Events;
using Reconfigurator.Infrastructure;
using Reconfigurator.Views;

namespace Reconfigurator.ViewModels
{
	// Token: 0x02000008 RID: 8
	public class MainWindowViewModel : PopupContainerViewModelBase
	{
		// Token: 0x0600001F RID: 31 RVA: 0x00002315 File Offset: 0x00000515
		public MainWindowViewModel(IUnityContainer container, IEventAggregator eventAggregator, LlTraceSource ts) : base(container, eventAggregator)
		{
			LaplinkStyles.InitResources();
			this.ts = ts;
			eventAggregator.GetEvent<Events.TransferErrorEvent>().Subscribe(new Action<TransferError>(this.OnTransferError), ThreadOption.UIThread);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002344 File Offset: 0x00000544
		private void OnTransferError(TransferError transferError)
		{
			this.eventAggregator.GetEvent<PopupEvents.ShowPopup>().Publish(new PopupEvents.ResolveInfo(typeof(SkipReplaceUserControl), new ParameterOverride("transferError", transferError)));
		}

		// Token: 0x04000009 RID: 9
		private readonly LlTraceSource ts;
	}
}
