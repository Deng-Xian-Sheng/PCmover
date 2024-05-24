using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using WizardModule.ViewModels.Popups;

namespace WizardModule.Views.Popups
{
	// Token: 0x0200004B RID: 75
	public partial class RebootPending : UserControl, IHasPopupData
	{
		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x0000A649 File Offset: 0x00008849
		public RebootPendingViewModel Vm { get; }

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000494 RID: 1172 RVA: 0x0000A651 File Offset: 0x00008851
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0000A660 File Offset: 0x00008860
		public RebootPending(IUnityContainer container, RebootPendingData data)
		{
			this.InitializeComponent();
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			this.Vm = container.Resolve(new ResolverOverride[]
			{
				new ParameterOverride("data", data)
			});
			base.DataContext = this.Vm;
			this.Vm.PopupData.Content = this;
		}
	}
}
