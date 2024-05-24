using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Converters
{
	// Token: 0x02000022 RID: 34
	public static class TreeViewItemExtensions
	{
		// Token: 0x060000BC RID: 188 RVA: 0x00003C99 File Offset: 0x00001E99
		public static int GetDepth(this TreeViewItem item)
		{
			return item.GetAncestors().TakeWhile((DependencyObject e) => !(e is TreeView)).OfType<TreeViewItem>().Count<TreeViewItem>();
		}
	}
}
