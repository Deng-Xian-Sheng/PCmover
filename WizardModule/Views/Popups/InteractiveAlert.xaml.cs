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
	// Token: 0x02000047 RID: 71
	public partial class InteractiveAlert : UserControl, IHasPopupData
	{
		// Token: 0x0600047F RID: 1151 RVA: 0x0000A318 File Offset: 0x00008518
		public InteractiveAlert(IUnityContainer container)
		{
			this.InitializeComponent();
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			this.Vm = container.Resolve(Array.Empty<ResolverOverride>());
			base.DataContext = this.Vm;
			this.Vm.PopupData.Content = this;
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x0000A37A File Offset: 0x0000857A
		public InteractiveAlertViewModel Vm { get; }

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x0000A382 File Offset: 0x00008582
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}
	}
}
