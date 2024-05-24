using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Prism.Properties;

namespace Prism.Regions
{
	// Token: 0x02000021 RID: 33
	public class Region : IRegion, INavigateAsync, INotifyPropertyChanged
	{
		// Token: 0x060000AE RID: 174 RVA: 0x00002C23 File Offset: 0x00000E23
		public Region()
		{
			this.Behaviors = new RegionBehaviorCollection(this);
			this.sort = new Comparison<object>(Region.DefaultSortComparison);
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060000AF RID: 175 RVA: 0x00002C4C File Offset: 0x00000E4C
		// (remove) Token: 0x060000B0 RID: 176 RVA: 0x00002C84 File Offset: 0x00000E84
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x00002CB9 File Offset: 0x00000EB9
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x00002CC1 File Offset: 0x00000EC1
		public IRegionBehaviorCollection Behaviors { get; private set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00002CCA File Offset: 0x00000ECA
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x00002CD2 File Offset: 0x00000ED2
		public object Context
		{
			get
			{
				return this.context;
			}
			set
			{
				if (this.context != value)
				{
					this.context = value;
					this.OnPropertyChanged("Context");
				}
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00002CEF File Offset: 0x00000EEF
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x00002CF8 File Offset: 0x00000EF8
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				if (this.name != null && this.name != value)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotChangeRegionNameException, new object[]
					{
						this.name
					}));
				}
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(Resources.RegionNameCannotBeEmptyException);
				}
				this.name = value;
				this.OnPropertyChanged("Name");
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00002D64 File Offset: 0x00000F64
		public virtual IViewsCollection Views
		{
			get
			{
				if (this.views == null)
				{
					this.views = new ViewsCollection(this.ItemMetadataCollection, (ItemMetadata x) => true);
					this.views.SortComparison = this.sort;
				}
				return this.views;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x00002DC0 File Offset: 0x00000FC0
		public virtual IViewsCollection ActiveViews
		{
			get
			{
				if (this.activeViews == null)
				{
					this.activeViews = new ViewsCollection(this.ItemMetadataCollection, (ItemMetadata x) => x.IsActive);
					this.activeViews.SortComparison = this.sort;
				}
				return this.activeViews;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00002E1C File Offset: 0x0000101C
		// (set) Token: 0x060000BA RID: 186 RVA: 0x00002E24 File Offset: 0x00001024
		public Comparison<object> SortComparison
		{
			get
			{
				return this.sort;
			}
			set
			{
				this.sort = value;
				if (this.activeViews != null)
				{
					this.activeViews.SortComparison = this.sort;
				}
				if (this.views != null)
				{
					this.views.SortComparison = this.sort;
				}
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00002E5F File Offset: 0x0000105F
		// (set) Token: 0x060000BC RID: 188 RVA: 0x00002E67 File Offset: 0x00001067
		public IRegionManager RegionManager
		{
			get
			{
				return this.regionManager;
			}
			set
			{
				if (this.regionManager != value)
				{
					this.regionManager = value;
					this.OnPropertyChanged("RegionManager");
				}
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00002E84 File Offset: 0x00001084
		// (set) Token: 0x060000BE RID: 190 RVA: 0x00002EB0 File Offset: 0x000010B0
		public IRegionNavigationService NavigationService
		{
			get
			{
				if (this.regionNavigationService == null)
				{
					this.regionNavigationService = ServiceLocator.Current.GetInstance<IRegionNavigationService>();
					this.regionNavigationService.Region = this;
				}
				return this.regionNavigationService;
			}
			set
			{
				this.regionNavigationService = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00002EB9 File Offset: 0x000010B9
		protected virtual ObservableCollection<ItemMetadata> ItemMetadataCollection
		{
			get
			{
				if (this.itemMetadataCollection == null)
				{
					this.itemMetadataCollection = new ObservableCollection<ItemMetadata>();
				}
				return this.itemMetadataCollection;
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00002ED4 File Offset: 0x000010D4
		public IRegionManager Add(object view)
		{
			return this.Add(view, null, false);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00002EDF File Offset: 0x000010DF
		public IRegionManager Add(object view, string viewName)
		{
			if (string.IsNullOrEmpty(viewName))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.StringCannotBeNullOrEmpty, new object[]
				{
					"viewName"
				}));
			}
			return this.Add(view, viewName, false);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00002F18 File Offset: 0x00001118
		public virtual IRegionManager Add(object view, string viewName, bool createRegionManagerScope)
		{
			IRegionManager regionManager = createRegionManagerScope ? this.RegionManager.CreateRegionManager() : this.RegionManager;
			this.InnerAdd(view, viewName, regionManager);
			return regionManager;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00002F48 File Offset: 0x00001148
		public virtual void Remove(object view)
		{
			ItemMetadata itemMetadataOrThrow = this.GetItemMetadataOrThrow(view);
			this.ItemMetadataCollection.Remove(itemMetadataOrThrow);
			DependencyObject dependencyObject = view as DependencyObject;
			if (dependencyObject != null && Prism.Regions.RegionManager.GetRegionManager(dependencyObject) == this.RegionManager)
			{
				dependencyObject.ClearValue(Prism.Regions.RegionManager.RegionManagerProperty);
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00002F90 File Offset: 0x00001190
		public void RemoveAll()
		{
			foreach (object view in this.Views)
			{
				this.Remove(view);
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00002FE0 File Offset: 0x000011E0
		public virtual void Activate(object view)
		{
			ItemMetadata itemMetadataOrThrow = this.GetItemMetadataOrThrow(view);
			if (!itemMetadataOrThrow.IsActive)
			{
				itemMetadataOrThrow.IsActive = true;
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00003004 File Offset: 0x00001204
		public virtual void Deactivate(object view)
		{
			ItemMetadata itemMetadataOrThrow = this.GetItemMetadataOrThrow(view);
			if (itemMetadataOrThrow.IsActive)
			{
				itemMetadataOrThrow.IsActive = false;
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003028 File Offset: 0x00001228
		public virtual object GetView(string viewName)
		{
			if (string.IsNullOrEmpty(viewName))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.StringCannotBeNullOrEmpty, new object[]
				{
					"viewName"
				}));
			}
			ItemMetadata itemMetadata = this.ItemMetadataCollection.FirstOrDefault((ItemMetadata x) => x.Name == viewName);
			if (itemMetadata != null)
			{
				return itemMetadata.Item;
			}
			return null;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003095 File Offset: 0x00001295
		public void RequestNavigate(Uri target, Action<NavigationResult> navigationCallback)
		{
			this.RequestNavigate(target, navigationCallback, null);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000030A0 File Offset: 0x000012A0
		public void RequestNavigate(Uri target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
		{
			this.NavigationService.RequestNavigate(target, navigationCallback, navigationParameters);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000030B0 File Offset: 0x000012B0
		private void InnerAdd(object view, string viewName, IRegionManager scopedRegionManager)
		{
			if (this.ItemMetadataCollection.FirstOrDefault((ItemMetadata x) => x.Item == view) != null)
			{
				throw new InvalidOperationException(Resources.RegionViewExistsException);
			}
			ItemMetadata itemMetadata = new ItemMetadata(view);
			if (!string.IsNullOrEmpty(viewName))
			{
				if (this.ItemMetadataCollection.FirstOrDefault((ItemMetadata x) => x.Name == viewName) != null)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.RegionViewNameExistsException, new object[]
					{
						viewName
					}));
				}
				itemMetadata.Name = viewName;
			}
			DependencyObject dependencyObject = view as DependencyObject;
			if (dependencyObject != null)
			{
				Prism.Regions.RegionManager.SetRegionManager(dependencyObject, scopedRegionManager);
			}
			this.ItemMetadataCollection.Add(itemMetadata);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000317C File Offset: 0x0000137C
		private ItemMetadata GetItemMetadataOrThrow(object view)
		{
			if (view == null)
			{
				throw new ArgumentNullException("view");
			}
			ItemMetadata itemMetadata = this.ItemMetadataCollection.FirstOrDefault((ItemMetadata x) => x.Item == view);
			if (itemMetadata == null)
			{
				throw new ArgumentException(Resources.ViewNotInRegionException, "view");
			}
			return itemMetadata;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000031D4 File Offset: 0x000013D4
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000031F8 File Offset: 0x000013F8
		public static int DefaultSortComparison(object x, object y)
		{
			if (x == null)
			{
				if (y == null)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (y == null)
				{
					return 1;
				}
				MemberInfo type = x.GetType();
				Type type2 = y.GetType();
				ViewSortHintAttribute x2 = type.GetCustomAttributes(typeof(ViewSortHintAttribute), true).FirstOrDefault<object>() as ViewSortHintAttribute;
				ViewSortHintAttribute y2 = type2.GetCustomAttributes(typeof(ViewSortHintAttribute), true).FirstOrDefault<object>() as ViewSortHintAttribute;
				return Region.ViewSortHintAttributeComparison(x2, y2);
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000325D File Offset: 0x0000145D
		private static int ViewSortHintAttributeComparison(ViewSortHintAttribute x, ViewSortHintAttribute y)
		{
			if (x == null)
			{
				if (y == null)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (y == null)
				{
					return 1;
				}
				return string.Compare(x.Hint, y.Hint, StringComparison.Ordinal);
			}
		}

		// Token: 0x04000010 RID: 16
		private ObservableCollection<ItemMetadata> itemMetadataCollection;

		// Token: 0x04000011 RID: 17
		private string name;

		// Token: 0x04000012 RID: 18
		private ViewsCollection views;

		// Token: 0x04000013 RID: 19
		private ViewsCollection activeViews;

		// Token: 0x04000014 RID: 20
		private object context;

		// Token: 0x04000015 RID: 21
		private IRegionManager regionManager;

		// Token: 0x04000016 RID: 22
		private IRegionNavigationService regionNavigationService;

		// Token: 0x04000017 RID: 23
		private Comparison<object> sort;
	}
}
