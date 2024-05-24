using System;
using System.ComponentModel;
using System.Windows;

namespace Prism.Common
{
	// Token: 0x02000081 RID: 129
	public class ObservableObject<T> : FrameworkElement, INotifyPropertyChanged
	{
		// Token: 0x14000019 RID: 25
		// (add) Token: 0x060003C1 RID: 961 RVA: 0x000099DC File Offset: 0x00007BDC
		// (remove) Token: 0x060003C2 RID: 962 RVA: 0x00009A14 File Offset: 0x00007C14
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x00009A49 File Offset: 0x00007C49
		// (set) Token: 0x060003C4 RID: 964 RVA: 0x00009A5B File Offset: 0x00007C5B
		public T Value
		{
			get
			{
				return (T)((object)base.GetValue(ObservableObject<T>.ValueProperty));
			}
			set
			{
				base.SetValue(ObservableObject<T>.ValueProperty, value);
			}
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00009A70 File Offset: 0x00007C70
		private static void ValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ObservableObject<T> observableObject = (ObservableObject<T>)d;
			PropertyChangedEventHandler propertyChanged = observableObject.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(observableObject, new PropertyChangedEventArgs("Value"));
			}
		}

		// Token: 0x040000B8 RID: 184
		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(T), typeof(ObservableObject<T>), new PropertyMetadata(new PropertyChangedCallback(ObservableObject<T>.ValueChangedCallback)));
	}
}
