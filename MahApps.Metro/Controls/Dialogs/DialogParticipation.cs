using System;
using System.Collections.Generic;
using System.Windows;

namespace MahApps.Metro.Controls.Dialogs
{
	// Token: 0x020000A4 RID: 164
	public static class DialogParticipation
	{
		// Token: 0x060008F7 RID: 2295 RVA: 0x0002425B File Offset: 0x0002245B
		private static void RegisterPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			if (dependencyPropertyChangedEventArgs.OldValue != null)
			{
				DialogParticipation.ContextRegistrationIndex.Remove(dependencyPropertyChangedEventArgs.OldValue);
			}
			if (dependencyPropertyChangedEventArgs.NewValue != null)
			{
				DialogParticipation.ContextRegistrationIndex[dependencyPropertyChangedEventArgs.NewValue] = dependencyObject;
			}
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x00024293 File Offset: 0x00022493
		public static void SetRegister(DependencyObject element, object context)
		{
			element.SetValue(DialogParticipation.RegisterProperty, context);
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x000242A1 File Offset: 0x000224A1
		public static object GetRegister(DependencyObject element)
		{
			return element.GetValue(DialogParticipation.RegisterProperty);
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x000242AE File Offset: 0x000224AE
		internal static bool IsRegistered(object context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			return DialogParticipation.ContextRegistrationIndex.ContainsKey(context);
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x000242C9 File Offset: 0x000224C9
		internal static DependencyObject GetAssociation(object context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			return DialogParticipation.ContextRegistrationIndex[context];
		}

		// Token: 0x040003F4 RID: 1012
		private static readonly IDictionary<object, DependencyObject> ContextRegistrationIndex = new Dictionary<object, DependencyObject>();

		// Token: 0x040003F5 RID: 1013
		public static readonly DependencyProperty RegisterProperty = DependencyProperty.RegisterAttached("Register", typeof(object), typeof(DialogParticipation), new PropertyMetadata(null, new PropertyChangedCallback(DialogParticipation.RegisterPropertyChangedCallback)));
	}
}
