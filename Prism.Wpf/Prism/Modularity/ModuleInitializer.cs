using System;
using System.Globalization;
using Microsoft.Practices.ServiceLocation;
using Prism.Logging;
using Prism.Properties;

namespace Prism.Modularity
{
	// Token: 0x02000066 RID: 102
	public class ModuleInitializer : IModuleInitializer
	{
		// Token: 0x06000306 RID: 774 RVA: 0x00007F6C File Offset: 0x0000616C
		public ModuleInitializer(IServiceLocator serviceLocator, ILoggerFacade loggerFacade)
		{
			if (serviceLocator == null)
			{
				throw new ArgumentNullException("serviceLocator");
			}
			if (loggerFacade == null)
			{
				throw new ArgumentNullException("loggerFacade");
			}
			this.serviceLocator = serviceLocator;
			this.loggerFacade = loggerFacade;
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00007FA0 File Offset: 0x000061A0
		public void Initialize(ModuleInfo moduleInfo)
		{
			if (moduleInfo == null)
			{
				throw new ArgumentNullException("moduleInfo");
			}
			IModule module = null;
			try
			{
				module = this.CreateModule(moduleInfo);
				if (module != null)
				{
					module.Initialize();
				}
			}
			catch (Exception exception)
			{
				this.HandleModuleInitializationError(moduleInfo, (module != null) ? module.GetType().Assembly.FullName : null, exception);
			}
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00008004 File Offset: 0x00006204
		public virtual void HandleModuleInitializationError(ModuleInfo moduleInfo, string assemblyName, Exception exception)
		{
			if (moduleInfo == null)
			{
				throw new ArgumentNullException("moduleInfo");
			}
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			Exception ex;
			if (exception is ModuleInitializeException)
			{
				ex = exception;
			}
			else if (!string.IsNullOrEmpty(assemblyName))
			{
				ex = new ModuleInitializeException(moduleInfo.ModuleName, assemblyName, exception.Message, exception);
			}
			else
			{
				ex = new ModuleInitializeException(moduleInfo.ModuleName, exception.Message, exception);
			}
			this.loggerFacade.Log(ex.ToString(), Category.Exception, Priority.High);
			throw ex;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000807E File Offset: 0x0000627E
		protected virtual IModule CreateModule(ModuleInfo moduleInfo)
		{
			if (moduleInfo == null)
			{
				throw new ArgumentNullException("moduleInfo");
			}
			return this.CreateModule(moduleInfo.ModuleType);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000809C File Offset: 0x0000629C
		protected virtual IModule CreateModule(string typeName)
		{
			Type type = Type.GetType(typeName);
			if (type == null)
			{
				throw new ModuleInitializeException(string.Format(CultureInfo.CurrentCulture, Resources.FailedToGetType, new object[]
				{
					typeName
				}));
			}
			return (IModule)this.serviceLocator.GetInstance(type);
		}

		// Token: 0x04000088 RID: 136
		private readonly IServiceLocator serviceLocator;

		// Token: 0x04000089 RID: 137
		private readonly ILoggerFacade loggerFacade;
	}
}
