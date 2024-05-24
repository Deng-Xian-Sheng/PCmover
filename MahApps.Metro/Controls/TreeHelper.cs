using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000095 RID: 149
	public static class TreeHelper
	{
		// Token: 0x06000823 RID: 2083 RVA: 0x00021260 File Offset: 0x0001F460
		public static T TryFindParent<T>(this DependencyObject child) where T : DependencyObject
		{
			DependencyObject parentObject = child.GetParentObject();
			if (parentObject == null)
			{
				return default(T);
			}
			T result;
			if ((result = (parentObject as T)) == null)
			{
				result = parentObject.TryFindParent<T>();
			}
			return result;
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0002129B File Offset: 0x0001F49B
		public static IEnumerable<DependencyObject> GetAncestors(this DependencyObject child)
		{
			for (DependencyObject parent = VisualTreeHelper.GetParent(child); parent != null; parent = VisualTreeHelper.GetParent(parent))
			{
				yield return parent;
			}
			yield break;
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x000212AC File Offset: 0x0001F4AC
		public static T FindChild<T>(this DependencyObject parent, string childName) where T : DependencyObject
		{
			if (parent == null)
			{
				return default(T);
			}
			T t = default(T);
			int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
			for (int i = 0; i < childrenCount; i++)
			{
				DependencyObject child = VisualTreeHelper.GetChild(parent, i);
				if (!(child is T))
				{
					t = child.FindChild(childName);
					if (t != null)
					{
						break;
					}
				}
				else
				{
					if (string.IsNullOrEmpty(childName))
					{
						t = (T)((object)child);
						break;
					}
					IFrameworkInputElement frameworkInputElement = child as IFrameworkInputElement;
					if (frameworkInputElement != null && frameworkInputElement.Name == childName)
					{
						t = (T)((object)child);
						break;
					}
					t = child.FindChild(childName);
					if (t != null)
					{
						break;
					}
				}
			}
			return t;
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x00021360 File Offset: 0x0001F560
		public static DependencyObject GetParentObject(this DependencyObject child)
		{
			if (child == null)
			{
				return null;
			}
			ContentElement contentElement = child as ContentElement;
			if (contentElement != null)
			{
				DependencyObject parent = ContentOperations.GetParent(contentElement);
				if (parent != null)
				{
					return parent;
				}
				FrameworkContentElement frameworkContentElement = contentElement as FrameworkContentElement;
				if (frameworkContentElement == null)
				{
					return null;
				}
				return frameworkContentElement.Parent;
			}
			else
			{
				DependencyObject parent2 = VisualTreeHelper.GetParent(child);
				if (parent2 != null)
				{
					return parent2;
				}
				FrameworkElement frameworkElement = child as FrameworkElement;
				if (frameworkElement != null)
				{
					DependencyObject parent3 = frameworkElement.Parent;
					if (parent3 != null)
					{
						return parent3;
					}
				}
				return null;
			}
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x000213C4 File Offset: 0x0001F5C4
		public static IEnumerable<T> FindChildren<T>(this DependencyObject source, bool forceUsingTheVisualTreeHelper = false) where T : DependencyObject
		{
			if (source != null)
			{
				IEnumerable<DependencyObject> childObjects = source.GetChildObjects(forceUsingTheVisualTreeHelper);
				foreach (DependencyObject child in childObjects)
				{
					if (child != null && child is T)
					{
						yield return (T)((object)child);
					}
					foreach (T t in child.FindChildren(forceUsingTheVisualTreeHelper))
					{
						yield return t;
					}
					IEnumerator<T> enumerator2 = null;
					child = null;
				}
				IEnumerator<DependencyObject> enumerator = null;
			}
			yield break;
			yield break;
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x000213DB File Offset: 0x0001F5DB
		public static IEnumerable<DependencyObject> GetChildObjects(this DependencyObject parent, bool forceUsingTheVisualTreeHelper = false)
		{
			if (parent == null)
			{
				yield break;
			}
			if (!forceUsingTheVisualTreeHelper && (parent is ContentElement || parent is FrameworkElement))
			{
				foreach (object obj in LogicalTreeHelper.GetChildren(parent))
				{
					if (obj is DependencyObject)
					{
						yield return (DependencyObject)obj;
					}
				}
				IEnumerator enumerator = null;
			}
			else if (parent is Visual || parent is Visual3D)
			{
				int count = VisualTreeHelper.GetChildrenCount(parent);
				int num;
				for (int i = 0; i < count; i = num + 1)
				{
					yield return VisualTreeHelper.GetChild(parent, i);
					num = i;
				}
			}
			yield break;
			yield break;
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x000213F4 File Offset: 0x0001F5F4
		public static T TryFindFromPoint<T>(UIElement reference, Point point) where T : DependencyObject
		{
			DependencyObject dependencyObject = reference.InputHitTest(point) as DependencyObject;
			if (dependencyObject == null)
			{
				return default(T);
			}
			if (dependencyObject is T)
			{
				return (T)((object)dependencyObject);
			}
			return dependencyObject.TryFindParent<T>();
		}
	}
}
