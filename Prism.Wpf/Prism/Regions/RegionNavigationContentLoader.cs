using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Prism.Common;
using Prism.Properties;

namespace Prism.Regions
{
	// Token: 0x0200002A RID: 42
	public class RegionNavigationContentLoader : IRegionNavigationContentLoader
	{
		// Token: 0x06000112 RID: 274 RVA: 0x00003C93 File Offset: 0x00001E93
		public RegionNavigationContentLoader(IServiceLocator serviceLocator)
		{
			this.serviceLocator = serviceLocator;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00003CA4 File Offset: 0x00001EA4
		public object LoadContent(IRegion region, NavigationContext navigationContext)
		{
			if (region == null)
			{
				throw new ArgumentNullException("region");
			}
			if (navigationContext == null)
			{
				throw new ArgumentNullException("navigationContext");
			}
			string contractFromNavigationContext = this.GetContractFromNavigationContext(navigationContext);
			object obj = this.GetCandidatesFromRegion(region, contractFromNavigationContext).Where(delegate(object v)
			{
				INavigationAware navigationAware = v as INavigationAware;
				if (navigationAware != null && !navigationAware.IsNavigationTarget(navigationContext))
				{
					return false;
				}
				FrameworkElement frameworkElement = v as FrameworkElement;
				if (frameworkElement == null)
				{
					return true;
				}
				navigationAware = (frameworkElement.DataContext as INavigationAware);
				return navigationAware == null || navigationAware.IsNavigationTarget(navigationContext);
			}).FirstOrDefault<object>();
			if (obj != null)
			{
				return obj;
			}
			obj = this.CreateNewRegionItem(contractFromNavigationContext);
			region.Add(obj);
			return obj;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00003D24 File Offset: 0x00001F24
		protected virtual object CreateNewRegionItem(string candidateTargetContract)
		{
			object instance;
			try
			{
				instance = this.serviceLocator.GetInstance<object>(candidateTargetContract);
			}
			catch (ActivationException innerException)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotCreateNavigationTarget, new object[]
				{
					candidateTargetContract
				}), innerException);
			}
			return instance;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00003D74 File Offset: 0x00001F74
		protected virtual string GetContractFromNavigationContext(NavigationContext navigationContext)
		{
			if (navigationContext == null)
			{
				throw new ArgumentNullException("navigationContext");
			}
			return UriParsingHelper.GetAbsolutePath(navigationContext.Uri).TrimStart(new char[]
			{
				'/'
			});
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00003DA0 File Offset: 0x00001FA0
		protected virtual IEnumerable<object> GetCandidatesFromRegion(IRegion region, string candidateNavigationContract)
		{
			if (region == null)
			{
				throw new ArgumentNullException("region");
			}
			return from v in region.Views
			where string.Equals(v.GetType().Name, candidateNavigationContract, StringComparison.Ordinal) || string.Equals(v.GetType().FullName, candidateNavigationContract, StringComparison.Ordinal)
			select v;
		}

		// Token: 0x0400002A RID: 42
		private readonly IServiceLocator serviceLocator;
	}
}
