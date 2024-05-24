using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Prism.Common;
using Prism.Events;
using Prism.Properties;
using Prism.Regions.Behaviors;

namespace Prism.Regions
{
	// Token: 0x02000028 RID: 40
	public class RegionManager : IRegionManager
	{
		// Token: 0x060000F2 RID: 242 RVA: 0x000037B0 File Offset: 0x000019B0
		public static void SetRegionName(DependencyObject regionTarget, string regionName)
		{
			if (regionTarget == null)
			{
				throw new ArgumentNullException("regionTarget");
			}
			regionTarget.SetValue(RegionManager.RegionNameProperty, regionName);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000037CC File Offset: 0x000019CC
		public static string GetRegionName(DependencyObject regionTarget)
		{
			if (regionTarget == null)
			{
				throw new ArgumentNullException("regionTarget");
			}
			return regionTarget.GetValue(RegionManager.RegionNameProperty) as string;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000037EC File Offset: 0x000019EC
		public static ObservableObject<IRegion> GetObservableRegion(DependencyObject view)
		{
			if (view == null)
			{
				throw new ArgumentNullException("view");
			}
			ObservableObject<IRegion> observableObject = view.GetValue(RegionManager.ObservableRegionProperty) as ObservableObject<IRegion>;
			if (observableObject == null)
			{
				observableObject = new ObservableObject<IRegion>();
				view.SetValue(RegionManager.ObservableRegionProperty, observableObject);
			}
			return observableObject;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000382E File Offset: 0x00001A2E
		private static void OnSetRegionNameCallback(DependencyObject element, DependencyPropertyChangedEventArgs args)
		{
			if (!RegionManager.IsInDesignMode(element))
			{
				RegionManager.CreateRegion(element);
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000383E File Offset: 0x00001A3E
		private static void CreateRegion(DependencyObject element)
		{
			DelayedRegionCreationBehavior instance = ServiceLocator.Current.GetInstance<DelayedRegionCreationBehavior>();
			instance.TargetElement = element;
			instance.Attach();
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00003856 File Offset: 0x00001A56
		public static IRegionManager GetRegionManager(DependencyObject target)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			return (IRegionManager)target.GetValue(RegionManager.RegionManagerProperty);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00003876 File Offset: 0x00001A76
		public static void SetRegionManager(DependencyObject target, IRegionManager value)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			target.SetValue(RegionManager.RegionManagerProperty, value);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00003892 File Offset: 0x00001A92
		private static void OnRegionContextChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
		{
			if (RegionContext.GetObservableContext(depObj).Value != e.NewValue)
			{
				RegionContext.GetObservableContext(depObj).Value = e.NewValue;
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000038BA File Offset: 0x00001ABA
		public static object GetRegionContext(DependencyObject target)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			return target.GetValue(RegionManager.RegionContextProperty);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000038D5 File Offset: 0x00001AD5
		public static void SetRegionContext(DependencyObject target, object value)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			target.SetValue(RegionManager.RegionContextProperty, value);
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060000FC RID: 252 RVA: 0x000038F1 File Offset: 0x00001AF1
		// (remove) Token: 0x060000FD RID: 253 RVA: 0x000038FE File Offset: 0x00001AFE
		public static event EventHandler UpdatingRegions
		{
			add
			{
				RegionManager.updatingRegionsListeners.AddListener(value);
			}
			remove
			{
				RegionManager.updatingRegionsListeners.RemoveListener(value);
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000390C File Offset: 0x00001B0C
		public static void UpdateRegions()
		{
			try
			{
				RegionManager.updatingRegionsListeners.Raise(new object[]
				{
					null,
					EventArgs.Empty
				});
			}
			catch (TargetInvocationException ex)
			{
				Exception rootException = ex.GetRootException();
				throw new UpdateRegionsException(string.Format(CultureInfo.CurrentCulture, Resources.UpdateRegionException, new object[]
				{
					rootException
				}), ex.InnerException);
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00003970 File Offset: 0x00001B70
		private static bool IsInDesignMode(DependencyObject element)
		{
			return DesignerProperties.GetIsInDesignMode(element);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00003978 File Offset: 0x00001B78
		public RegionManager()
		{
			this.regionCollection = new RegionManager.RegionCollection(this);
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000101 RID: 257 RVA: 0x0000398C File Offset: 0x00001B8C
		public IRegionCollection Regions
		{
			get
			{
				return this.regionCollection;
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00003994 File Offset: 0x00001B94
		public IRegionManager CreateRegionManager()
		{
			return new RegionManager();
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000399C File Offset: 0x00001B9C
		public IRegionManager AddToRegion(string regionName, object view)
		{
			if (!this.Regions.ContainsRegionWithName(regionName))
			{
				throw new ArgumentException(string.Format(Thread.CurrentThread.CurrentCulture, Resources.RegionNotFound, new object[]
				{
					regionName
				}), "regionName");
			}
			return this.Regions[regionName].Add(view);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000039F2 File Offset: 0x00001BF2
		public IRegionManager RegisterViewWithRegion(string regionName, Type viewType)
		{
			ServiceLocator.Current.GetInstance<IRegionViewRegistry>().RegisterViewWithRegion(regionName, viewType);
			return this;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00003A06 File Offset: 0x00001C06
		public IRegionManager RegisterViewWithRegion(string regionName, Func<object> getContentDelegate)
		{
			ServiceLocator.Current.GetInstance<IRegionViewRegistry>().RegisterViewWithRegion(regionName, getContentDelegate);
			return this;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00003A1C File Offset: 0x00001C1C
		public void RequestNavigate(string regionName, Uri source, Action<NavigationResult> navigationCallback)
		{
			if (navigationCallback == null)
			{
				throw new ArgumentNullException("navigationCallback");
			}
			if (this.Regions.ContainsRegionWithName(regionName))
			{
				this.Regions[regionName].RequestNavigate(source, navigationCallback);
				return;
			}
			navigationCallback(new NavigationResult(new NavigationContext(null, source), new bool?(false)));
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00003A71 File Offset: 0x00001C71
		public void RequestNavigate(string regionName, Uri source)
		{
			this.RequestNavigate(regionName, source, delegate(NavigationResult nr)
			{
			});
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00003A9A File Offset: 0x00001C9A
		public void RequestNavigate(string regionName, string source, Action<NavigationResult> navigationCallback)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			this.RequestNavigate(regionName, new Uri(source, UriKind.RelativeOrAbsolute), navigationCallback);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00003AB9 File Offset: 0x00001CB9
		public void RequestNavigate(string regionName, string source)
		{
			this.RequestNavigate(regionName, source, delegate(NavigationResult nr)
			{
			});
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00003AE4 File Offset: 0x00001CE4
		public void RequestNavigate(string regionName, Uri target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
		{
			if (navigationCallback == null)
			{
				throw new ArgumentNullException("navigationCallback");
			}
			if (this.Regions.ContainsRegionWithName(regionName))
			{
				this.Regions[regionName].RequestNavigate(target, navigationCallback, navigationParameters);
				return;
			}
			navigationCallback(new NavigationResult(new NavigationContext(null, target, navigationParameters), new bool?(false)));
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00003B3D File Offset: 0x00001D3D
		public void RequestNavigate(string regionName, string target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
		{
			this.RequestNavigate(regionName, new Uri(target, UriKind.RelativeOrAbsolute), navigationCallback, navigationParameters);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00003B50 File Offset: 0x00001D50
		public void RequestNavigate(string regionName, Uri target, NavigationParameters navigationParameters)
		{
			this.RequestNavigate(regionName, target, delegate(NavigationResult nr)
			{
			}, navigationParameters);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00003B7A File Offset: 0x00001D7A
		public void RequestNavigate(string regionName, string target, NavigationParameters navigationParameters)
		{
			this.RequestNavigate(regionName, new Uri(target, UriKind.RelativeOrAbsolute), delegate(NavigationResult nr)
			{
			}, navigationParameters);
		}

		// Token: 0x04000023 RID: 35
		private static readonly WeakDelegatesManager updatingRegionsListeners = new WeakDelegatesManager();

		// Token: 0x04000024 RID: 36
		public static readonly DependencyProperty RegionNameProperty = DependencyProperty.RegisterAttached("RegionName", typeof(string), typeof(RegionManager), new PropertyMetadata(new PropertyChangedCallback(RegionManager.OnSetRegionNameCallback)));

		// Token: 0x04000025 RID: 37
		private static readonly DependencyProperty ObservableRegionProperty = DependencyProperty.RegisterAttached("ObservableRegion", typeof(ObservableObject<IRegion>), typeof(RegionManager), null);

		// Token: 0x04000026 RID: 38
		public static readonly DependencyProperty RegionManagerProperty = DependencyProperty.RegisterAttached("RegionManager", typeof(IRegionManager), typeof(RegionManager), null);

		// Token: 0x04000027 RID: 39
		public static readonly DependencyProperty RegionContextProperty = DependencyProperty.RegisterAttached("RegionContext", typeof(object), typeof(RegionManager), new PropertyMetadata(new PropertyChangedCallback(RegionManager.OnRegionContextChanged)));

		// Token: 0x04000028 RID: 40
		private readonly RegionManager.RegionCollection regionCollection;

		// Token: 0x0200008A RID: 138
		private class RegionCollection : IRegionCollection, IEnumerable<IRegion>, IEnumerable, INotifyCollectionChanged
		{
			// Token: 0x060003E3 RID: 995 RVA: 0x00009C29 File Offset: 0x00007E29
			public RegionCollection(IRegionManager regionManager)
			{
				this.regionManager = regionManager;
				this.regions = new List<IRegion>();
			}

			// Token: 0x1400001A RID: 26
			// (add) Token: 0x060003E4 RID: 996 RVA: 0x00009C44 File Offset: 0x00007E44
			// (remove) Token: 0x060003E5 RID: 997 RVA: 0x00009C7C File Offset: 0x00007E7C
			public event NotifyCollectionChangedEventHandler CollectionChanged;

			// Token: 0x060003E6 RID: 998 RVA: 0x00009CB1 File Offset: 0x00007EB1
			public IEnumerator<IRegion> GetEnumerator()
			{
				RegionManager.UpdateRegions();
				return this.regions.GetEnumerator();
			}

			// Token: 0x060003E7 RID: 999 RVA: 0x00009CC8 File Offset: 0x00007EC8
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x170000DF RID: 223
			public IRegion this[string regionName]
			{
				get
				{
					RegionManager.UpdateRegions();
					IRegion regionByName = this.GetRegionByName(regionName);
					if (regionByName == null)
					{
						throw new KeyNotFoundException(string.Format(CultureInfo.CurrentUICulture, Resources.RegionNotInRegionManagerException, new object[]
						{
							regionName
						}));
					}
					return regionByName;
				}
			}

			// Token: 0x060003E9 RID: 1001 RVA: 0x00009D10 File Offset: 0x00007F10
			public void Add(IRegion region)
			{
				if (region == null)
				{
					throw new ArgumentNullException("region");
				}
				RegionManager.UpdateRegions();
				if (region.Name == null)
				{
					throw new InvalidOperationException(Resources.RegionNameCannotBeEmptyException);
				}
				if (this.GetRegionByName(region.Name) != null)
				{
					throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.RegionNameExistsException, new object[]
					{
						region.Name
					}));
				}
				this.regions.Add(region);
				region.RegionManager = this.regionManager;
				this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, region, 0));
			}

			// Token: 0x060003EA RID: 1002 RVA: 0x00009D9C File Offset: 0x00007F9C
			public bool Remove(string regionName)
			{
				RegionManager.UpdateRegions();
				bool result = false;
				IRegion regionByName = this.GetRegionByName(regionName);
				if (regionByName != null)
				{
					result = true;
					this.regions.Remove(regionByName);
					regionByName.RegionManager = null;
					this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, regionByName, 0));
				}
				return result;
			}

			// Token: 0x060003EB RID: 1003 RVA: 0x00009DE0 File Offset: 0x00007FE0
			public bool ContainsRegionWithName(string regionName)
			{
				RegionManager.UpdateRegions();
				return this.GetRegionByName(regionName) != null;
			}

			// Token: 0x060003EC RID: 1004 RVA: 0x00009DF4 File Offset: 0x00007FF4
			public void Add(string regionName, IRegion region)
			{
				if (region == null)
				{
					throw new ArgumentNullException("region");
				}
				if (region.Name != null && region.Name != regionName)
				{
					throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.RegionManagerWithDifferentNameException, new object[]
					{
						region.Name,
						regionName
					}), "regionName");
				}
				if (region.Name == null)
				{
					region.Name = regionName;
				}
				this.Add(region);
			}

			// Token: 0x060003ED RID: 1005 RVA: 0x00009E68 File Offset: 0x00008068
			private IRegion GetRegionByName(string regionName)
			{
				return this.regions.FirstOrDefault((IRegion r) => r.Name == regionName);
			}

			// Token: 0x060003EE RID: 1006 RVA: 0x00009E9C File Offset: 0x0000809C
			private void OnCollectionChanged(NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
			{
				NotifyCollectionChangedEventHandler collectionChanged = this.CollectionChanged;
				if (collectionChanged != null)
				{
					collectionChanged(this, notifyCollectionChangedEventArgs);
				}
			}

			// Token: 0x040000CA RID: 202
			private readonly IRegionManager regionManager;

			// Token: 0x040000CB RID: 203
			private readonly List<IRegion> regions;
		}
	}
}
