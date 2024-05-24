using System;
using System.Globalization;
using System.Windows;
using Prism.Properties;

namespace Prism.Regions.Behaviors
{
	// Token: 0x0200003C RID: 60
	public class DelayedRegionCreationBehavior
	{
		// Token: 0x06000199 RID: 409 RVA: 0x000052DC File Offset: 0x000034DC
		public DelayedRegionCreationBehavior(RegionAdapterMappings regionAdapterMappings)
		{
			this.regionAdapterMappings = regionAdapterMappings;
			this.RegionManagerAccessor = new DefaultRegionManagerAccessor();
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600019A RID: 410 RVA: 0x000052F6 File Offset: 0x000034F6
		// (set) Token: 0x0600019B RID: 411 RVA: 0x000052FE File Offset: 0x000034FE
		public IRegionManagerAccessor RegionManagerAccessor { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600019C RID: 412 RVA: 0x00005307 File Offset: 0x00003507
		// (set) Token: 0x0600019D RID: 413 RVA: 0x00005323 File Offset: 0x00003523
		public DependencyObject TargetElement
		{
			get
			{
				if (this.elementWeakReference == null)
				{
					return null;
				}
				return this.elementWeakReference.Target as DependencyObject;
			}
			set
			{
				this.elementWeakReference = new WeakReference(value);
			}
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00005331 File Offset: 0x00003531
		public void Attach()
		{
			this.RegionManagerAccessor.UpdatingRegions += this.OnUpdatingRegions;
			this.WireUpTargetElement();
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00005350 File Offset: 0x00003550
		public void Detach()
		{
			this.RegionManagerAccessor.UpdatingRegions -= this.OnUpdatingRegions;
			this.UnWireTargetElement();
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0000536F File Offset: 0x0000356F
		public void OnUpdatingRegions(object sender, EventArgs e)
		{
			this.TryCreateRegion();
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00005378 File Offset: 0x00003578
		private void TryCreateRegion()
		{
			DependencyObject targetElement = this.TargetElement;
			if (targetElement == null)
			{
				this.Detach();
				return;
			}
			if (targetElement.CheckAccess())
			{
				this.Detach();
				if (!this.regionCreated)
				{
					string regionName = this.RegionManagerAccessor.GetRegionName(targetElement);
					this.CreateRegion(targetElement, regionName);
					this.regionCreated = true;
				}
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x000053CC File Offset: 0x000035CC
		protected virtual IRegion CreateRegion(DependencyObject targetElement, string regionName)
		{
			if (targetElement == null)
			{
				throw new ArgumentNullException("targetElement");
			}
			IRegion result;
			try
			{
				result = this.regionAdapterMappings.GetMapping(targetElement.GetType()).Initialize(targetElement, regionName);
			}
			catch (Exception ex)
			{
				throw new RegionCreationException(string.Format(CultureInfo.CurrentCulture, Resources.RegionCreationException, new object[]
				{
					regionName,
					ex
				}), ex);
			}
			return result;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000543C File Offset: 0x0000363C
		private void ElementLoaded(object sender, RoutedEventArgs e)
		{
			this.UnWireTargetElement();
			this.TryCreateRegion();
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000544C File Offset: 0x0000364C
		private void WireUpTargetElement()
		{
			FrameworkElement frameworkElement = this.TargetElement as FrameworkElement;
			if (frameworkElement != null)
			{
				frameworkElement.Loaded += this.ElementLoaded;
			}
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000547C File Offset: 0x0000367C
		private void UnWireTargetElement()
		{
			FrameworkElement frameworkElement = this.TargetElement as FrameworkElement;
			if (frameworkElement != null)
			{
				frameworkElement.Loaded -= this.ElementLoaded;
			}
		}

		// Token: 0x0400004F RID: 79
		private readonly RegionAdapterMappings regionAdapterMappings;

		// Token: 0x04000050 RID: 80
		private WeakReference elementWeakReference;

		// Token: 0x04000051 RID: 81
		private bool regionCreated;
	}
}
