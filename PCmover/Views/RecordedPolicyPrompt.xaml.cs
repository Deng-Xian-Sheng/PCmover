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
using PCmover.ViewModels;

namespace PCmover.Views
{
	// Token: 0x02000007 RID: 7
	public partial class RecordedPolicyPrompt : UserControl, IHasPopupData
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002B12 File Offset: 0x00000D12
		public RecordedPolicyPromptViewModel Vm { get; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002B1A File Offset: 0x00000D1A
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002B28 File Offset: 0x00000D28
		public RecordedPolicyPrompt(IUnityContainer container, RecordedPolicyPromptData data)
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
