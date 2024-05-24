using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Prism.Logging;
using Prism.Properties;

namespace Prism.Modularity
{
	// Token: 0x02000067 RID: 103
	public class ModuleManager : IModuleManager, IDisposable
	{
		// Token: 0x0600030B RID: 779 RVA: 0x000080EC File Offset: 0x000062EC
		public ModuleManager(IModuleInitializer moduleInitializer, IModuleCatalog moduleCatalog, ILoggerFacade loggerFacade)
		{
			if (moduleInitializer == null)
			{
				throw new ArgumentNullException("moduleInitializer");
			}
			if (moduleCatalog == null)
			{
				throw new ArgumentNullException("moduleCatalog");
			}
			if (loggerFacade == null)
			{
				throw new ArgumentNullException("loggerFacade");
			}
			this.moduleInitializer = moduleInitializer;
			this.moduleCatalog = moduleCatalog;
			this.loggerFacade = loggerFacade;
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600030C RID: 780 RVA: 0x00008149 File Offset: 0x00006349
		protected IModuleCatalog ModuleCatalog
		{
			get
			{
				return this.moduleCatalog;
			}
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x0600030D RID: 781 RVA: 0x00008154 File Offset: 0x00006354
		// (remove) Token: 0x0600030E RID: 782 RVA: 0x0000818C File Offset: 0x0000638C
		public event EventHandler<ModuleDownloadProgressChangedEventArgs> ModuleDownloadProgressChanged;

		// Token: 0x0600030F RID: 783 RVA: 0x000081C1 File Offset: 0x000063C1
		private void RaiseModuleDownloadProgressChanged(ModuleDownloadProgressChangedEventArgs e)
		{
			if (this.ModuleDownloadProgressChanged != null)
			{
				this.ModuleDownloadProgressChanged(this, e);
			}
		}

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000310 RID: 784 RVA: 0x000081D8 File Offset: 0x000063D8
		// (remove) Token: 0x06000311 RID: 785 RVA: 0x00008210 File Offset: 0x00006410
		public event EventHandler<LoadModuleCompletedEventArgs> LoadModuleCompleted;

		// Token: 0x06000312 RID: 786 RVA: 0x00008245 File Offset: 0x00006445
		private void RaiseLoadModuleCompleted(ModuleInfo moduleInfo, Exception error)
		{
			this.RaiseLoadModuleCompleted(new LoadModuleCompletedEventArgs(moduleInfo, error));
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00008254 File Offset: 0x00006454
		private void RaiseLoadModuleCompleted(LoadModuleCompletedEventArgs e)
		{
			if (this.LoadModuleCompleted != null)
			{
				this.LoadModuleCompleted(this, e);
			}
		}

		// Token: 0x06000314 RID: 788 RVA: 0x0000826B File Offset: 0x0000646B
		public void Run()
		{
			this.moduleCatalog.Initialize();
			this.LoadModulesWhenAvailable();
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00008280 File Offset: 0x00006480
		public void LoadModule(string moduleName)
		{
			IEnumerable<ModuleInfo> enumerable = from m in this.moduleCatalog.Modules
			where m.ModuleName == moduleName
			select m;
			if (enumerable == null || enumerable.Count<ModuleInfo>() != 1)
			{
				throw new ModuleNotFoundException(moduleName, string.Format(CultureInfo.CurrentCulture, Resources.ModuleNotFound, new object[]
				{
					moduleName
				}));
			}
			IEnumerable<ModuleInfo> moduleInfos = this.moduleCatalog.CompleteListWithDependencies(enumerable);
			this.LoadModuleTypes(moduleInfos);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00008301 File Offset: 0x00006501
		protected virtual bool ModuleNeedsRetrieval(ModuleInfo moduleInfo)
		{
			if (moduleInfo == null)
			{
				throw new ArgumentNullException("moduleInfo");
			}
			if (moduleInfo.State == ModuleState.NotStarted)
			{
				bool flag = Type.GetType(moduleInfo.ModuleType) != null;
				if (flag)
				{
					moduleInfo.State = ModuleState.ReadyForInitialization;
				}
				return !flag;
			}
			return false;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0000833C File Offset: 0x0000653C
		private void LoadModulesWhenAvailable()
		{
			IEnumerable<ModuleInfo> modules = from m in this.moduleCatalog.Modules
			where m.InitializationMode == InitializationMode.WhenAvailable
			select m;
			IEnumerable<ModuleInfo> enumerable = this.moduleCatalog.CompleteListWithDependencies(modules);
			if (enumerable != null)
			{
				this.LoadModuleTypes(enumerable);
			}
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00008390 File Offset: 0x00006590
		private void LoadModuleTypes(IEnumerable<ModuleInfo> moduleInfos)
		{
			if (moduleInfos == null)
			{
				return;
			}
			foreach (ModuleInfo moduleInfo in moduleInfos)
			{
				if (moduleInfo.State == ModuleState.NotStarted)
				{
					if (this.ModuleNeedsRetrieval(moduleInfo))
					{
						this.BeginRetrievingModule(moduleInfo);
					}
					else
					{
						moduleInfo.State = ModuleState.ReadyForInitialization;
					}
				}
			}
			this.LoadModulesThatAreReadyForLoad();
		}

		// Token: 0x06000319 RID: 793 RVA: 0x000083FC File Offset: 0x000065FC
		protected virtual void LoadModulesThatAreReadyForLoad()
		{
			bool flag = true;
			while (flag)
			{
				flag = false;
				foreach (ModuleInfo moduleInfo in from m in this.moduleCatalog.Modules
				where m.State == ModuleState.ReadyForInitialization
				select m)
				{
					if (moduleInfo.State != ModuleState.Initialized && this.AreDependenciesLoaded(moduleInfo))
					{
						moduleInfo.State = ModuleState.Initializing;
						this.InitializeModule(moduleInfo);
						flag = true;
						break;
					}
				}
			}
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00008498 File Offset: 0x00006698
		private void BeginRetrievingModule(ModuleInfo moduleInfo)
		{
			IModuleTypeLoader typeLoaderForModule = this.GetTypeLoaderForModule(moduleInfo);
			moduleInfo.State = ModuleState.LoadingTypes;
			if (!this.subscribedToModuleTypeLoaders.Contains(typeLoaderForModule))
			{
				typeLoaderForModule.ModuleDownloadProgressChanged += this.IModuleTypeLoader_ModuleDownloadProgressChanged;
				typeLoaderForModule.LoadModuleCompleted += this.IModuleTypeLoader_LoadModuleCompleted;
				this.subscribedToModuleTypeLoaders.Add(typeLoaderForModule);
			}
			typeLoaderForModule.LoadModuleType(moduleInfo);
		}

		// Token: 0x0600031B RID: 795 RVA: 0x000084FC File Offset: 0x000066FC
		private void IModuleTypeLoader_ModuleDownloadProgressChanged(object sender, ModuleDownloadProgressChangedEventArgs e)
		{
			this.RaiseModuleDownloadProgressChanged(e);
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00008508 File Offset: 0x00006708
		private void IModuleTypeLoader_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				if (e.ModuleInfo.State != ModuleState.Initializing && e.ModuleInfo.State != ModuleState.Initialized)
				{
					e.ModuleInfo.State = ModuleState.ReadyForInitialization;
				}
				this.LoadModulesThatAreReadyForLoad();
				return;
			}
			this.RaiseLoadModuleCompleted(e);
			if (!e.IsErrorHandled)
			{
				this.HandleModuleTypeLoadingError(e.ModuleInfo, e.Error);
			}
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00008570 File Offset: 0x00006770
		protected virtual void HandleModuleTypeLoadingError(ModuleInfo moduleInfo, Exception exception)
		{
			if (moduleInfo == null)
			{
				throw new ArgumentNullException("moduleInfo");
			}
			ModuleTypeLoadingException ex = exception as ModuleTypeLoadingException;
			if (ex == null)
			{
				ex = new ModuleTypeLoadingException(moduleInfo.ModuleName, exception.Message, exception);
			}
			this.loggerFacade.Log(ex.Message, Category.Exception, Priority.High);
			throw ex;
		}

		// Token: 0x0600031E RID: 798 RVA: 0x000085BC File Offset: 0x000067BC
		private bool AreDependenciesLoaded(ModuleInfo moduleInfo)
		{
			IEnumerable<ModuleInfo> dependentModules = this.moduleCatalog.GetDependentModules(moduleInfo);
			if (dependentModules == null)
			{
				return true;
			}
			return dependentModules.Count((ModuleInfo requiredModule) => requiredModule.State != ModuleState.Initialized) == 0;
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00008604 File Offset: 0x00006804
		private IModuleTypeLoader GetTypeLoaderForModule(ModuleInfo moduleInfo)
		{
			foreach (IModuleTypeLoader moduleTypeLoader in this.ModuleTypeLoaders)
			{
				if (moduleTypeLoader.CanLoadModuleType(moduleInfo))
				{
					return moduleTypeLoader;
				}
			}
			throw new ModuleTypeLoaderNotFoundException(moduleInfo.ModuleName, string.Format(CultureInfo.CurrentCulture, Resources.NoRetrieverCanRetrieveModule, new object[]
			{
				moduleInfo.ModuleName
			}), null);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00008684 File Offset: 0x00006884
		private void InitializeModule(ModuleInfo moduleInfo)
		{
			if (moduleInfo.State == ModuleState.Initializing)
			{
				this.moduleInitializer.Initialize(moduleInfo);
				moduleInfo.State = ModuleState.Initialized;
				this.RaiseLoadModuleCompleted(moduleInfo, null);
			}
		}

		// Token: 0x06000321 RID: 801 RVA: 0x000086AA File Offset: 0x000068AA
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x000086BC File Offset: 0x000068BC
		protected virtual void Dispose(bool disposing)
		{
			foreach (IModuleTypeLoader moduleTypeLoader in this.ModuleTypeLoaders)
			{
				IDisposable disposable = moduleTypeLoader as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000323 RID: 803 RVA: 0x00008710 File Offset: 0x00006910
		// (set) Token: 0x06000324 RID: 804 RVA: 0x00008736 File Offset: 0x00006936
		public virtual IEnumerable<IModuleTypeLoader> ModuleTypeLoaders
		{
			get
			{
				if (this.typeLoaders == null)
				{
					this.typeLoaders = new List<IModuleTypeLoader>
					{
						new FileModuleTypeLoader()
					};
				}
				return this.typeLoaders;
			}
			set
			{
				this.typeLoaders = value;
			}
		}

		// Token: 0x0400008A RID: 138
		private readonly IModuleInitializer moduleInitializer;

		// Token: 0x0400008B RID: 139
		private readonly IModuleCatalog moduleCatalog;

		// Token: 0x0400008C RID: 140
		private readonly ILoggerFacade loggerFacade;

		// Token: 0x0400008D RID: 141
		private IEnumerable<IModuleTypeLoader> typeLoaders;

		// Token: 0x0400008E RID: 142
		private HashSet<IModuleTypeLoader> subscribedToModuleTypeLoaders = new HashSet<IModuleTypeLoader>();
	}
}
