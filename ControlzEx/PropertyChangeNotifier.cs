using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace ControlzEx
{
	// Token: 0x02000009 RID: 9
	public sealed class PropertyChangeNotifier : DependencyObject, IDisposable
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00002BEC File Offset: 0x00000DEC
		public PropertyChangeNotifier(DependencyObject propertySource, string path) : this(propertySource, new PropertyPath(path, Array.Empty<object>()))
		{
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002C00 File Offset: 0x00000E00
		public PropertyChangeNotifier(DependencyObject propertySource, DependencyProperty property) : this(propertySource, new PropertyPath(property))
		{
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002C10 File Offset: 0x00000E10
		public PropertyChangeNotifier(DependencyObject propertySource, PropertyPath property)
		{
			if (propertySource == null)
			{
				throw new ArgumentNullException("propertySource");
			}
			if (property == null)
			{
				throw new ArgumentNullException("property");
			}
			this._propertySource = new WeakReference(propertySource);
			Binding binding = new Binding();
			binding.Path = property;
			binding.Mode = BindingMode.OneWay;
			binding.Source = propertySource;
			BindingOperations.SetBinding(this, PropertyChangeNotifier.ValueProperty, binding);
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002C7C File Offset: 0x00000E7C
		public DependencyObject PropertySource
		{
			get
			{
				DependencyObject result;
				try
				{
					result = (this._propertySource.IsAlive ? (this._propertySource.Target as DependencyObject) : null);
				}
				catch
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002CC4 File Offset: 0x00000EC4
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00002CD1 File Offset: 0x00000ED1
		[Description("Returns/sets the value of the property")]
		[Category("Behavior")]
		[Bindable(true)]
		public object Value
		{
			get
			{
				return base.GetValue(PropertyChangeNotifier.ValueProperty);
			}
			set
			{
				base.SetValue(PropertyChangeNotifier.ValueProperty, value);
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002CE0 File Offset: 0x00000EE0
		private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			PropertyChangeNotifier propertyChangeNotifier = (PropertyChangeNotifier)d;
			if (propertyChangeNotifier.RaiseValueChanged)
			{
				EventHandler valueChanged = propertyChangeNotifier.ValueChanged;
				if (valueChanged == null)
				{
					return;
				}
				valueChanged(propertyChangeNotifier.PropertySource, EventArgs.Empty);
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000041 RID: 65 RVA: 0x00002D18 File Offset: 0x00000F18
		// (remove) Token: 0x06000042 RID: 66 RVA: 0x00002D50 File Offset: 0x00000F50
		public event EventHandler ValueChanged;

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002D85 File Offset: 0x00000F85
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00002D8D File Offset: 0x00000F8D
		public bool RaiseValueChanged { get; set; } = true;

		// Token: 0x06000045 RID: 69 RVA: 0x00002D96 File Offset: 0x00000F96
		public void Dispose()
		{
			BindingOperations.ClearBinding(this, PropertyChangeNotifier.ValueProperty);
		}

		// Token: 0x04000024 RID: 36
		private WeakReference _propertySource;

		// Token: 0x04000025 RID: 37
		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(PropertyChangeNotifier), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(PropertyChangeNotifier.OnPropertyChanged)));
	}
}
