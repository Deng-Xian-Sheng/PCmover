using System;
using System.ComponentModel;
using System.Windows;
using Prism.Properties;

namespace Prism.Regions.Behaviors
{
	// Token: 0x02000040 RID: 64
	public class RegionManagerRegistrationBehavior : RegionBehavior, IHostAwareRegionBehavior, IRegionBehavior
	{
		// Token: 0x060001B5 RID: 437 RVA: 0x00005718 File Offset: 0x00003918
		public RegionManagerRegistrationBehavior()
		{
			this.RegionManagerAccessor = new DefaultRegionManagerAccessor();
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x0000572B File Offset: 0x0000392B
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x00005733 File Offset: 0x00003933
		public IRegionManagerAccessor RegionManagerAccessor { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x0000573C File Offset: 0x0000393C
		// (set) Token: 0x060001B9 RID: 441 RVA: 0x00005744 File Offset: 0x00003944
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

		// Token: 0x060001BA RID: 442 RVA: 0x00005760 File Offset: 0x00003960
		protected override void OnAttach()
		{
			if (string.IsNullOrEmpty(base.Region.Name))
			{
				base.Region.PropertyChanged += this.Region_PropertyChanged;
				return;
			}
			this.StartMonitoringRegionManager();
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00005794 File Offset: 0x00003994
		private void Region_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Name" && !string.IsNullOrEmpty(base.Region.Name))
			{
				base.Region.PropertyChanged -= this.Region_PropertyChanged;
				this.StartMonitoringRegionManager();
			}
		}

		// Token: 0x060001BC RID: 444 RVA: 0x000057E2 File Offset: 0x000039E2
		private void StartMonitoringRegionManager()
		{
			this.RegionManagerAccessor.UpdatingRegions += this.OnUpdatingRegions;
			this.TryRegisterRegion();
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00005804 File Offset: 0x00003A04
		private void TryRegisterRegion()
		{
			DependencyObject dependencyObject = this.HostControl;
			if (dependencyObject.CheckAccess())
			{
				IRegionManager regionManager = this.FindRegionManager(dependencyObject);
				IRegionManager attachedRegionManager = this.GetAttachedRegionManager();
				if (regionManager != attachedRegionManager)
				{
					if (attachedRegionManager != null)
					{
						this.attachedRegionManagerWeakReference = null;
						attachedRegionManager.Regions.Remove(base.Region.Name);
					}
					if (regionManager != null)
					{
						this.attachedRegionManagerWeakReference = new WeakReference(regionManager);
						regionManager.Regions.Add(base.Region);
					}
				}
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00005874 File Offset: 0x00003A74
		public void OnUpdatingRegions(object sender, EventArgs e)
		{
			this.TryRegisterRegion();
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000587C File Offset: 0x00003A7C
		private IRegionManager FindRegionManager(DependencyObject dependencyObject)
		{
			IRegionManager regionManager = this.RegionManagerAccessor.GetRegionManager(dependencyObject);
			if (regionManager != null)
			{
				return regionManager;
			}
			DependencyObject parent = LogicalTreeHelper.GetParent(dependencyObject);
			if (parent != null)
			{
				return this.FindRegionManager(parent);
			}
			return null;
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x000058B0 File Offset: 0x00003AB0
		private IRegionManager GetAttachedRegionManager()
		{
			if (this.attachedRegionManagerWeakReference != null)
			{
				return this.attachedRegionManagerWeakReference.Target as IRegionManager;
			}
			return null;
		}

		// Token: 0x04000055 RID: 85
		public static readonly string BehaviorKey = "RegionManagerRegistration";

		// Token: 0x04000056 RID: 86
		private WeakReference attachedRegionManagerWeakReference;

		// Token: 0x04000057 RID: 87
		private DependencyObject hostControl;
	}
}
