using System;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Shapes;

namespace MahApps.Metro.Behaviours
{
	// Token: 0x020000B3 RID: 179
	public class BindableResourceBehavior : Behavior<Shape>
	{
		// Token: 0x060009D0 RID: 2512 RVA: 0x00026085 File Offset: 0x00024285
		protected override void OnAttached()
		{
			base.AssociatedObject.SetResourceReference(this.Property, this.ResourceName);
			base.OnAttached();
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x060009D1 RID: 2513 RVA: 0x000260A4 File Offset: 0x000242A4
		// (set) Token: 0x060009D2 RID: 2514 RVA: 0x000260B6 File Offset: 0x000242B6
		public string ResourceName
		{
			get
			{
				return (string)base.GetValue(BindableResourceBehavior.ResourceNameProperty);
			}
			set
			{
				base.SetValue(BindableResourceBehavior.ResourceNameProperty, value);
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x060009D3 RID: 2515 RVA: 0x000260C4 File Offset: 0x000242C4
		// (set) Token: 0x060009D4 RID: 2516 RVA: 0x000260D6 File Offset: 0x000242D6
		public DependencyProperty Property
		{
			get
			{
				return (DependencyProperty)base.GetValue(BindableResourceBehavior.PropertyProperty);
			}
			set
			{
				base.SetValue(BindableResourceBehavior.PropertyProperty, value);
			}
		}

		// Token: 0x0400045B RID: 1115
		public static readonly DependencyProperty ResourceNameProperty = DependencyProperty.Register("ResourceName", typeof(string), typeof(BindableResourceBehavior), new PropertyMetadata(null));

		// Token: 0x0400045C RID: 1116
		public static readonly DependencyProperty PropertyProperty = DependencyProperty.Register("Property", typeof(DependencyProperty), typeof(BindableResourceBehavior), new PropertyMetadata(null));
	}
}
