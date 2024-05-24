using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using WizardModule.ViewModels.Popups;

namespace WizardModule.Views.Popups
{
	// Token: 0x02000048 RID: 72
	public partial class OfficeTrial : UserControl, IHasPopupData
	{
		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x0000A3C9 File Offset: 0x000085C9
		public OfficeTrialViewModel Vm { get; }

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x0000A3D1 File Offset: 0x000085D1
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0000A3E0 File Offset: 0x000085E0
		public OfficeTrial(IUnityContainer container, IEnumerable<ApplicationData> configData)
		{
			this.InitializeComponent();
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			this.Vm = container.Resolve(new ResolverOverride[]
			{
				new ParameterOverride("configData", configData)
			});
			base.DataContext = this.Vm;
			this.Vm.PopupData.Content = this;
		}
	}
}
