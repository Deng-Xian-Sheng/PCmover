using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Practices.ServiceLocation.Properties;

namespace Microsoft.Practices.ServiceLocation
{
	// Token: 0x02000005 RID: 5
	public abstract class ServiceLocatorImplBase : IServiceLocator, IServiceProvider
	{
		// Token: 0x0600000D RID: 13 RVA: 0x0000211E File Offset: 0x0000031E
		public virtual object GetService(Type serviceType)
		{
			return this.GetInstance(serviceType, null);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002128 File Offset: 0x00000328
		public virtual object GetInstance(Type serviceType)
		{
			return this.GetInstance(serviceType, null);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002134 File Offset: 0x00000334
		public virtual object GetInstance(Type serviceType, string key)
		{
			object result;
			try
			{
				result = this.DoGetInstance(serviceType, key);
			}
			catch (Exception ex)
			{
				throw new ActivationException(this.FormatActivationExceptionMessage(ex, serviceType, key), ex);
			}
			return result;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002170 File Offset: 0x00000370
		public virtual IEnumerable<object> GetAllInstances(Type serviceType)
		{
			IEnumerable<object> result;
			try
			{
				result = this.DoGetAllInstances(serviceType);
			}
			catch (Exception ex)
			{
				throw new ActivationException(this.FormatActivateAllExceptionMessage(ex, serviceType), ex);
			}
			return result;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000021A8 File Offset: 0x000003A8
		public virtual TService GetInstance<TService>()
		{
			return (TService)((object)this.GetInstance(typeof(TService), null));
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000021C0 File Offset: 0x000003C0
		public virtual TService GetInstance<TService>(string key)
		{
			return (TService)((object)this.GetInstance(typeof(TService), key));
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000237C File Offset: 0x0000057C
		public virtual IEnumerable<TService> GetAllInstances<TService>()
		{
			foreach (object item in this.GetAllInstances(typeof(TService)))
			{
				yield return (TService)((object)item);
			}
			yield break;
		}

		// Token: 0x06000014 RID: 20
		protected abstract object DoGetInstance(Type serviceType, string key);

		// Token: 0x06000015 RID: 21
		protected abstract IEnumerable<object> DoGetAllInstances(Type serviceType);

		// Token: 0x06000016 RID: 22 RVA: 0x0000239C File Offset: 0x0000059C
		protected virtual string FormatActivationExceptionMessage(Exception actualException, Type serviceType, string key)
		{
			return string.Format(CultureInfo.CurrentUICulture, Resources.ActivationExceptionMessage, new object[]
			{
				serviceType.Name,
				key
			});
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000023D0 File Offset: 0x000005D0
		protected virtual string FormatActivateAllExceptionMessage(Exception actualException, Type serviceType)
		{
			return string.Format(CultureInfo.CurrentUICulture, Resources.ActivateAllExceptionMessage, new object[]
			{
				serviceType.Name
			});
		}
	}
}
