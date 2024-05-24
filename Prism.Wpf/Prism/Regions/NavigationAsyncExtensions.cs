using System;

namespace Prism.Regions
{
	// Token: 0x0200001D RID: 29
	public static class NavigationAsyncExtensions
	{
		// Token: 0x06000090 RID: 144 RVA: 0x00002703 File Offset: 0x00000903
		public static void RequestNavigate(this INavigateAsync navigation, string target)
		{
			navigation.RequestNavigate(target, delegate(NavigationResult nr)
			{
			});
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000272C File Offset: 0x0000092C
		public static void RequestNavigate(this INavigateAsync navigation, string target, Action<NavigationResult> navigationCallback)
		{
			if (navigation == null)
			{
				throw new ArgumentNullException("navigation");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			Uri target2 = new Uri(target, UriKind.RelativeOrAbsolute);
			navigation.RequestNavigate(target2, navigationCallback);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00002765 File Offset: 0x00000965
		public static void RequestNavigate(this INavigateAsync navigation, Uri target)
		{
			if (navigation == null)
			{
				throw new ArgumentNullException("navigation");
			}
			navigation.RequestNavigate(target, delegate(NavigationResult nr)
			{
			});
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000279C File Offset: 0x0000099C
		public static void RequestNavigate(this INavigateAsync navigation, string target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
		{
			if (navigation == null)
			{
				throw new ArgumentNullException("navigation");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			Uri target2 = new Uri(target, UriKind.RelativeOrAbsolute);
			navigation.RequestNavigate(target2, navigationCallback, navigationParameters);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000027D6 File Offset: 0x000009D6
		public static void RequestNavigate(this INavigateAsync navigation, Uri target, NavigationParameters navigationParameters)
		{
			if (navigation == null)
			{
				throw new ArgumentNullException("navigation");
			}
			navigation.RequestNavigate(target, delegate(NavigationResult nr)
			{
			}, navigationParameters);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00002810 File Offset: 0x00000A10
		public static void RequestNavigate(this INavigateAsync navigation, string target, NavigationParameters navigationParameters)
		{
			if (navigation == null)
			{
				throw new ArgumentNullException("navigation");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			navigation.RequestNavigate(new Uri(target, UriKind.RelativeOrAbsolute), delegate(NavigationResult nr)
			{
			}, navigationParameters);
		}
	}
}
