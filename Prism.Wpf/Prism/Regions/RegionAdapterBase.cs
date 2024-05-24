using System;
using System.Globalization;
using System.Windows;
using Prism.Properties;
using Prism.Regions.Behaviors;

namespace Prism.Regions
{
	// Token: 0x02000022 RID: 34
	public abstract class RegionAdapterBase<T> : IRegionAdapter where T : class
	{
		// Token: 0x060000CF RID: 207 RVA: 0x00003280 File Offset: 0x00001480
		protected RegionAdapterBase(IRegionBehaviorFactory regionBehaviorFactory)
		{
			this.RegionBehaviorFactory = regionBehaviorFactory;
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x0000328F File Offset: 0x0000148F
		// (set) Token: 0x060000D1 RID: 209 RVA: 0x00003297 File Offset: 0x00001497
		protected IRegionBehaviorFactory RegionBehaviorFactory { get; set; }

		// Token: 0x060000D2 RID: 210 RVA: 0x000032A0 File Offset: 0x000014A0
		public IRegion Initialize(T regionTarget, string regionName)
		{
			if (regionName == null)
			{
				throw new ArgumentNullException("regionName");
			}
			IRegion region = this.CreateRegion();
			region.Name = regionName;
			RegionAdapterBase<T>.SetObservableRegionOnHostingControl(region, regionTarget);
			this.Adapt(region, regionTarget);
			this.AttachBehaviors(region, regionTarget);
			this.AttachDefaultBehaviors(region, regionTarget);
			return region;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000032E9 File Offset: 0x000014E9
		IRegion IRegionAdapter.Initialize(object regionTarget, string regionName)
		{
			return this.Initialize(RegionAdapterBase<T>.GetCastedObject(regionTarget), regionName);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000032F8 File Offset: 0x000014F8
		protected virtual void AttachDefaultBehaviors(IRegion region, T regionTarget)
		{
			if (region == null)
			{
				throw new ArgumentNullException("region");
			}
			if (regionTarget == null)
			{
				throw new ArgumentNullException("regionTarget");
			}
			IRegionBehaviorFactory regionBehaviorFactory = this.RegionBehaviorFactory;
			if (regionBehaviorFactory != null)
			{
				DependencyObject dependencyObject = regionTarget as DependencyObject;
				foreach (string key in regionBehaviorFactory)
				{
					if (!region.Behaviors.ContainsKey(key))
					{
						IRegionBehavior regionBehavior = regionBehaviorFactory.CreateFromKey(key);
						if (dependencyObject != null)
						{
							IHostAwareRegionBehavior hostAwareRegionBehavior = regionBehavior as IHostAwareRegionBehavior;
							if (hostAwareRegionBehavior != null)
							{
								hostAwareRegionBehavior.HostControl = dependencyObject;
							}
						}
						region.Behaviors.Add(key, regionBehavior);
					}
				}
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00002222 File Offset: 0x00000422
		protected virtual void AttachBehaviors(IRegion region, T regionTarget)
		{
		}

		// Token: 0x060000D6 RID: 214
		protected abstract void Adapt(IRegion region, T regionTarget);

		// Token: 0x060000D7 RID: 215
		protected abstract IRegion CreateRegion();

		// Token: 0x060000D8 RID: 216 RVA: 0x000033B0 File Offset: 0x000015B0
		private static T GetCastedObject(object regionTarget)
		{
			if (regionTarget == null)
			{
				throw new ArgumentNullException("regionTarget");
			}
			T t = regionTarget as T;
			if (t == null)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.AdapterInvalidTypeException, new object[]
				{
					typeof(T).Name
				}));
			}
			return t;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00003410 File Offset: 0x00001610
		private static void SetObservableRegionOnHostingControl(IRegion region, T regionTarget)
		{
			DependencyObject dependencyObject = regionTarget as DependencyObject;
			if (dependencyObject != null)
			{
				RegionManager.GetObservableRegion(dependencyObject).Value = region;
			}
		}
	}
}
