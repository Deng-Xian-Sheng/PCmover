using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ControlzEx;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200009A RID: 154
	[StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(WindowCommands))]
	public class WindowCommands : ItemsControl, INotifyPropertyChanged
	{
		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000862 RID: 2146 RVA: 0x00022155 File Offset: 0x00020355
		// (set) Token: 0x06000863 RID: 2147 RVA: 0x00022167 File Offset: 0x00020367
		public Theme Theme
		{
			get
			{
				return (Theme)base.GetValue(WindowCommands.ThemeProperty);
			}
			set
			{
				base.SetValue(WindowCommands.ThemeProperty, value);
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000864 RID: 2148 RVA: 0x0002217A File Offset: 0x0002037A
		// (set) Token: 0x06000865 RID: 2149 RVA: 0x0002218C File Offset: 0x0002038C
		public ControlTemplate LightTemplate
		{
			get
			{
				return (ControlTemplate)base.GetValue(WindowCommands.LightTemplateProperty);
			}
			set
			{
				base.SetValue(WindowCommands.LightTemplateProperty, value);
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000866 RID: 2150 RVA: 0x0002219A File Offset: 0x0002039A
		// (set) Token: 0x06000867 RID: 2151 RVA: 0x000221AC File Offset: 0x000203AC
		public ControlTemplate DarkTemplate
		{
			get
			{
				return (ControlTemplate)base.GetValue(WindowCommands.DarkTemplateProperty);
			}
			set
			{
				base.SetValue(WindowCommands.DarkTemplateProperty, value);
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000868 RID: 2152 RVA: 0x000221BA File Offset: 0x000203BA
		// (set) Token: 0x06000869 RID: 2153 RVA: 0x000221CC File Offset: 0x000203CC
		public bool ShowSeparators
		{
			get
			{
				return (bool)base.GetValue(WindowCommands.ShowSeparatorsProperty);
			}
			set
			{
				base.SetValue(WindowCommands.ShowSeparatorsProperty, value);
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x000221DF File Offset: 0x000203DF
		// (set) Token: 0x0600086B RID: 2155 RVA: 0x000221F1 File Offset: 0x000203F1
		public bool ShowLastSeparator
		{
			get
			{
				return (bool)base.GetValue(WindowCommands.ShowLastSeparatorProperty);
			}
			set
			{
				base.SetValue(WindowCommands.ShowLastSeparatorProperty, value);
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x0600086C RID: 2156 RVA: 0x00022204 File Offset: 0x00020404
		// (set) Token: 0x0600086D RID: 2157 RVA: 0x00022216 File Offset: 0x00020416
		public int SeparatorHeight
		{
			get
			{
				return (int)base.GetValue(WindowCommands.SeparatorHeightProperty);
			}
			set
			{
				base.SetValue(WindowCommands.SeparatorHeightProperty, value);
			}
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x0002222C File Offset: 0x0002042C
		private static void OnThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue == e.OldValue)
			{
				return;
			}
			WindowCommands windowCommands = (WindowCommands)d;
			if ((Theme)e.NewValue == Theme.Light)
			{
				if (windowCommands.LightTemplate != null)
				{
					windowCommands.SetValue(Control.TemplateProperty, windowCommands.LightTemplate);
					return;
				}
			}
			else if ((Theme)e.NewValue == Theme.Dark && windowCommands.DarkTemplate != null)
			{
				windowCommands.SetValue(Control.TemplateProperty, windowCommands.DarkTemplate);
			}
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x000222A1 File Offset: 0x000204A1
		private static void OnShowSeparatorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue == e.OldValue)
			{
				return;
			}
			((WindowCommands)d).ResetSeparators(true);
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x000222C0 File Offset: 0x000204C0
		private static void OnShowLastSeparatorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue == e.OldValue)
			{
				return;
			}
			((WindowCommands)d).ResetSeparators(false);
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x000222E0 File Offset: 0x000204E0
		static WindowCommands()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowCommands), new FrameworkPropertyMetadata(typeof(WindowCommands)));
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x00022445 File Offset: 0x00020645
		public WindowCommands()
		{
			base.Loaded += this.WindowCommands_Loaded;
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x0002245F File Offset: 0x0002065F
		protected override DependencyObject GetContainerForItemOverride()
		{
			return new WindowCommandsItem();
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00022466 File Offset: 0x00020666
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is WindowCommandsItem;
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x00022471 File Offset: 0x00020671
		protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
		{
			base.PrepareContainerForItemOverride(element, item);
			this.AttachVisibilityHandler(element as WindowCommandsItem, item as UIElement);
			this.ResetSeparators(true);
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x00022494 File Offset: 0x00020694
		protected override void ClearContainerForItemOverride(DependencyObject element, object item)
		{
			base.ClearContainerForItemOverride(element, item);
			this.DetachVisibilityHandler(element as WindowCommandsItem);
			this.ResetSeparators(false);
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x000224B4 File Offset: 0x000206B4
		private void AttachVisibilityHandler(WindowCommandsItem container, UIElement item)
		{
			if (container != null)
			{
				if (item == null)
				{
					container.ApplyTemplate();
					DataTemplate contentTemplate = container.ContentTemplate;
					if (!(((contentTemplate != null) ? contentTemplate.LoadContent() : null) is UIElement))
					{
						container.Visibility = Visibility.Collapsed;
					}
					return;
				}
				container.Visibility = item.Visibility;
				PropertyChangeNotifier propertyChangeNotifier = new PropertyChangeNotifier(item, UIElement.VisibilityProperty);
				propertyChangeNotifier.ValueChanged += this.VisibilityPropertyChanged;
				container.VisibilityPropertyChangeNotifier = propertyChangeNotifier;
			}
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00022522 File Offset: 0x00020722
		private void DetachVisibilityHandler(WindowCommandsItem container)
		{
			if (container != null)
			{
				container.VisibilityPropertyChangeNotifier = null;
			}
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x00022530 File Offset: 0x00020730
		private void VisibilityPropertyChanged(object sender, EventArgs e)
		{
			UIElement uielement = sender as UIElement;
			if (uielement != null)
			{
				WindowCommandsItem windowCommandsItem = this.GetWindowCommandsItem(uielement);
				if (windowCommandsItem != null)
				{
					windowCommandsItem.Visibility = uielement.Visibility;
					this.ResetSeparators(true);
				}
			}
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x00022565 File Offset: 0x00020765
		protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
		{
			base.OnItemsChanged(e);
			this.ResetSeparators(true);
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x00022578 File Offset: 0x00020778
		private void ResetSeparators(bool reset = true)
		{
			if (base.Items.Count == 0)
			{
				return;
			}
			List<WindowCommandsItem> list = this.GetWindowCommandsItems().ToList<WindowCommandsItem>();
			if (reset)
			{
				foreach (WindowCommandsItem windowCommandsItem in list)
				{
					windowCommandsItem.IsSeparatorVisible = this.ShowSeparators;
				}
			}
			WindowCommandsItem windowCommandsItem2 = list.LastOrDefault((WindowCommandsItem i) => i.IsVisible);
			if (windowCommandsItem2 != null)
			{
				windowCommandsItem2.IsSeparatorVisible = (this.ShowSeparators && this.ShowLastSeparator);
			}
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x00022628 File Offset: 0x00020828
		private WindowCommandsItem GetWindowCommandsItem(object item)
		{
			WindowCommandsItem windowCommandsItem = item as WindowCommandsItem;
			if (windowCommandsItem != null)
			{
				return windowCommandsItem;
			}
			return (WindowCommandsItem)base.ItemContainerGenerator.ContainerFromItem(item);
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x00022654 File Offset: 0x00020854
		private IEnumerable<WindowCommandsItem> GetWindowCommandsItems()
		{
			return from object item in base.Items
			select this.GetWindowCommandsItem(item) into i
			where i != null
			select i;
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x000226A4 File Offset: 0x000208A4
		private void WindowCommands_Loaded(object sender, RoutedEventArgs e)
		{
			base.Loaded -= this.WindowCommands_Loaded;
			if (this.ParentWindow == null)
			{
				this.ParentWindow = this.TryFindParent<Window>();
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x0600087F RID: 2175 RVA: 0x000226D9 File Offset: 0x000208D9
		// (set) Token: 0x06000880 RID: 2176 RVA: 0x000226E1 File Offset: 0x000208E1
		public Window ParentWindow
		{
			get
			{
				return this._parentWindow;
			}
			set
			{
				if (object.Equals(this._parentWindow, value))
				{
					return;
				}
				this._parentWindow = value;
				this.RaisePropertyChanged("ParentWindow");
			}
		}

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x06000881 RID: 2177 RVA: 0x00022704 File Offset: 0x00020904
		// (remove) Token: 0x06000882 RID: 2178 RVA: 0x0002273C File Offset: 0x0002093C
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06000883 RID: 2179 RVA: 0x00022774 File Offset: 0x00020974
		protected virtual void RaisePropertyChanged(string propertyName = null)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		// Token: 0x040003D4 RID: 980
		public static readonly DependencyProperty ThemeProperty = DependencyProperty.Register("Theme", typeof(Theme), typeof(WindowCommands), new PropertyMetadata(Theme.Light, new PropertyChangedCallback(WindowCommands.OnThemeChanged)));

		// Token: 0x040003D5 RID: 981
		public static readonly DependencyProperty LightTemplateProperty = DependencyProperty.Register("LightTemplate", typeof(ControlTemplate), typeof(WindowCommands), new PropertyMetadata(null));

		// Token: 0x040003D6 RID: 982
		public static readonly DependencyProperty DarkTemplateProperty = DependencyProperty.Register("DarkTemplate", typeof(ControlTemplate), typeof(WindowCommands), new PropertyMetadata(null));

		// Token: 0x040003D7 RID: 983
		public static readonly DependencyProperty ShowSeparatorsProperty = DependencyProperty.Register("ShowSeparators", typeof(bool), typeof(WindowCommands), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(WindowCommands.OnShowSeparatorsChanged)));

		// Token: 0x040003D8 RID: 984
		public static readonly DependencyProperty ShowLastSeparatorProperty = DependencyProperty.Register("ShowLastSeparator", typeof(bool), typeof(WindowCommands), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(WindowCommands.OnShowLastSeparatorChanged)));

		// Token: 0x040003D9 RID: 985
		public static readonly DependencyProperty SeparatorHeightProperty = DependencyProperty.Register("SeparatorHeight", typeof(int), typeof(WindowCommands), new FrameworkPropertyMetadata(15, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x040003DA RID: 986
		private Window _parentWindow;
	}
}
