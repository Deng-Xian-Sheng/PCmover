using System;
using System.ComponentModel;
using System.Windows;
using Prism.Common;
using Prism.Properties;

namespace Prism.Regions.Behaviors
{
	// Token: 0x02000043 RID: 67
	public class SyncRegionContextWithHostBehavior : RegionBehavior, IHostAwareRegionBehavior, IRegionBehavior
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x00005E60 File Offset: 0x00004060
		private ObservableObject<object> HostControlRegionContext
		{
			get
			{
				return RegionContext.GetObservableContext(this.hostControl);
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x00005E6D File Offset: 0x0000406D
		// (set) Token: 0x060001D3 RID: 467 RVA: 0x00005E75 File Offset: 0x00004075
		public DependencyObject HostControl
		{
			get
			{
				return this.hostControl;
			}
			set
			{
				if (base.IsAttached)
				{
					throw new InvalidOperationException(Resources.HostControlCannotBeSetAfterAttach);
				}
				this.hostControl = value;
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00005E91 File Offset: 0x00004091
		protected override void OnAttach()
		{
			if (this.HostControl != null)
			{
				this.SynchronizeRegionContext();
				this.HostControlRegionContext.PropertyChanged += this.RegionContextObservableObject_PropertyChanged;
				base.Region.PropertyChanged += this.Region_PropertyChanged;
			}
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00005ED0 File Offset: 0x000040D0
		private void Region_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Context" && RegionManager.GetRegionContext(this.HostControl) != base.Region.Context)
			{
				RegionManager.SetRegionContext(this.hostControl, base.Region.Context);
			}
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00005F1D File Offset: 0x0000411D
		private void RegionContextObservableObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Value")
			{
				this.SynchronizeRegionContext();
			}
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00005F38 File Offset: 0x00004138
		private void SynchronizeRegionContext()
		{
			if (base.Region.Context != this.HostControlRegionContext.Value)
			{
				base.Region.Context = this.HostControlRegionContext.Value;
			}
			if (RegionManager.GetRegionContext(this.HostControl) != this.HostControlRegionContext.Value)
			{
				RegionManager.SetRegionContext(this.HostControl, this.HostControlRegionContext.Value);
			}
		}

		// Token: 0x0400005D RID: 93
		private const string RegionContextPropertyName = "Context";

		// Token: 0x0400005E RID: 94
		private DependencyObject hostControl;

		// Token: 0x0400005F RID: 95
		public static readonly string BehaviorKey = "SyncRegionContextWithHost";
	}
}
