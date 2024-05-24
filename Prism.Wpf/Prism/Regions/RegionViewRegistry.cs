using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Microsoft.Practices.ServiceLocation;
using Prism.Common;
using Prism.Events;
using Prism.Properties;

namespace Prism.Regions
{
	// Token: 0x02000030 RID: 48
	public class RegionViewRegistry : IRegionViewRegistry
	{
		// Token: 0x0600014A RID: 330 RVA: 0x00004634 File Offset: 0x00002834
		public RegionViewRegistry(IServiceLocator locator)
		{
			this.locator = locator;
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x0600014B RID: 331 RVA: 0x00004659 File Offset: 0x00002859
		// (remove) Token: 0x0600014C RID: 332 RVA: 0x00004667 File Offset: 0x00002867
		public event EventHandler<ViewRegisteredEventArgs> ContentRegistered
		{
			add
			{
				this.contentRegisteredListeners.AddListener(value);
			}
			remove
			{
				this.contentRegisteredListeners.RemoveListener(value);
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00004678 File Offset: 0x00002878
		public IEnumerable<object> GetContents(string regionName)
		{
			List<object> list = new List<object>();
			foreach (Func<object> func in this.registeredContent[regionName])
			{
				list.Add(func());
			}
			return list;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000046D8 File Offset: 0x000028D8
		public void RegisterViewWithRegion(string regionName, Type viewType)
		{
			this.RegisterViewWithRegion(regionName, () => this.CreateInstance(viewType));
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000470C File Offset: 0x0000290C
		public void RegisterViewWithRegion(string regionName, Func<object> getContentDelegate)
		{
			this.registeredContent.Add(regionName, getContentDelegate);
			this.OnContentRegistered(new ViewRegisteredEventArgs(regionName, getContentDelegate));
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00004728 File Offset: 0x00002928
		protected virtual object CreateInstance(Type type)
		{
			return this.locator.GetInstance(type);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00004738 File Offset: 0x00002938
		private void OnContentRegistered(ViewRegisteredEventArgs e)
		{
			try
			{
				this.contentRegisteredListeners.Raise(new object[]
				{
					this,
					e
				});
			}
			catch (TargetInvocationException ex)
			{
				Exception rootException;
				if (ex.InnerException != null)
				{
					rootException = ex.InnerException.GetRootException();
				}
				else
				{
					rootException = ex.GetRootException();
				}
				throw new ViewRegistrationException(string.Format(CultureInfo.CurrentCulture, Resources.OnViewRegisteredException, new object[]
				{
					e.RegionName,
					rootException
				}), ex.InnerException);
			}
		}

		// Token: 0x0400003D RID: 61
		private readonly IServiceLocator locator;

		// Token: 0x0400003E RID: 62
		private readonly ListDictionary<string, Func<object>> registeredContent = new ListDictionary<string, Func<object>>();

		// Token: 0x0400003F RID: 63
		private readonly WeakDelegatesManager contentRegisteredListeners = new WeakDelegatesManager();
	}
}
