using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Threading;

namespace System.Reflection.Emit
{
	// Token: 0x02000629 RID: 1577
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_AssemblyBuilder))]
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public sealed class AssemblyBuilder : Assembly, _AssemblyBuilder
	{
		// Token: 0x0600490C RID: 18700
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern RuntimeModule GetInMemoryAssemblyModule(RuntimeAssembly assembly);

		// Token: 0x0600490D RID: 18701 RVA: 0x00107E4A File Offset: 0x0010604A
		[SecurityCritical]
		private Module nGetInMemoryAssemblyModule()
		{
			return AssemblyBuilder.GetInMemoryAssemblyModule(this.GetNativeHandle());
		}

		// Token: 0x0600490E RID: 18702
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern RuntimeModule GetOnDiskAssemblyModule(RuntimeAssembly assembly);

		// Token: 0x0600490F RID: 18703 RVA: 0x00107E58 File Offset: 0x00106058
		[SecurityCritical]
		private ModuleBuilder GetOnDiskAssemblyModuleBuilder()
		{
			if (this.m_onDiskAssemblyModuleBuilder == null)
			{
				Module onDiskAssemblyModule = AssemblyBuilder.GetOnDiskAssemblyModule(this.InternalAssembly.GetNativeHandle());
				ModuleBuilder moduleBuilder = new ModuleBuilder(this, (InternalModuleBuilder)onDiskAssemblyModule);
				moduleBuilder.Init("RefEmit_OnDiskManifestModule", null, 0);
				this.m_onDiskAssemblyModuleBuilder = moduleBuilder;
			}
			return this.m_onDiskAssemblyModuleBuilder;
		}

		// Token: 0x06004910 RID: 18704 RVA: 0x00107EAC File Offset: 0x001060AC
		internal ModuleBuilder GetModuleBuilder(InternalModuleBuilder module)
		{
			object syncRoot = this.SyncRoot;
			ModuleBuilder result;
			lock (syncRoot)
			{
				foreach (ModuleBuilder moduleBuilder in this.m_assemblyData.m_moduleBuilderList)
				{
					if (moduleBuilder.InternalModule == module)
					{
						return moduleBuilder;
					}
				}
				if (this.m_onDiskAssemblyModuleBuilder != null && this.m_onDiskAssemblyModuleBuilder.InternalModule == module)
				{
					result = this.m_onDiskAssemblyModuleBuilder;
				}
				else
				{
					if (!(this.m_manifestModuleBuilder.InternalModule == module))
					{
						throw new ArgumentException("module");
					}
					result = this.m_manifestModuleBuilder;
				}
			}
			return result;
		}

		// Token: 0x17000B6E RID: 2926
		// (get) Token: 0x06004911 RID: 18705 RVA: 0x00107F8C File Offset: 0x0010618C
		internal object SyncRoot
		{
			get
			{
				return this.InternalAssembly.SyncRoot;
			}
		}

		// Token: 0x17000B6F RID: 2927
		// (get) Token: 0x06004912 RID: 18706 RVA: 0x00107F99 File Offset: 0x00106199
		internal InternalAssemblyBuilder InternalAssembly
		{
			get
			{
				return this.m_internalAssemblyBuilder;
			}
		}

		// Token: 0x06004913 RID: 18707 RVA: 0x00107FA1 File Offset: 0x001061A1
		internal RuntimeAssembly GetNativeHandle()
		{
			return this.InternalAssembly.GetNativeHandle();
		}

		// Token: 0x06004914 RID: 18708 RVA: 0x00107FAE File Offset: 0x001061AE
		[SecurityCritical]
		internal Version GetVersion()
		{
			return this.InternalAssembly.GetVersion();
		}

		// Token: 0x17000B70 RID: 2928
		// (get) Token: 0x06004915 RID: 18709 RVA: 0x00107FBB File Offset: 0x001061BB
		internal bool ProfileAPICheck
		{
			get
			{
				return this.m_profileAPICheck;
			}
		}

		// Token: 0x06004916 RID: 18710 RVA: 0x00107FC4 File Offset: 0x001061C4
		[SecurityCritical]
		internal AssemblyBuilder(AppDomain domain, AssemblyName name, AssemblyBuilderAccess access, string dir, Evidence evidence, PermissionSet requiredPermissions, PermissionSet optionalPermissions, PermissionSet refusedPermissions, ref StackCrawlMark stackMark, IEnumerable<CustomAttributeBuilder> unsafeAssemblyAttributes, SecurityContextSource securityContextSource)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (access != AssemblyBuilderAccess.Run && access != AssemblyBuilderAccess.Save && access != AssemblyBuilderAccess.RunAndSave && access != AssemblyBuilderAccess.ReflectionOnly && access != AssemblyBuilderAccess.RunAndCollect)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
				{
					(int)access
				}), "access");
			}
			if (securityContextSource < SecurityContextSource.CurrentAppDomain || securityContextSource > SecurityContextSource.CurrentAssembly)
			{
				throw new ArgumentOutOfRangeException("securityContextSource");
			}
			name = (AssemblyName)name.Clone();
			if (name.KeyPair != null)
			{
				name.SetPublicKey(name.KeyPair.PublicKey);
			}
			if (evidence != null)
			{
				new SecurityPermission(SecurityPermissionFlag.ControlEvidence).Demand();
			}
			if (access == AssemblyBuilderAccess.RunAndCollect)
			{
				new PermissionSet(PermissionState.Unrestricted).Demand();
			}
			List<CustomAttributeBuilder> list = null;
			DynamicAssemblyFlags dynamicAssemblyFlags = DynamicAssemblyFlags.None;
			byte[] array = null;
			byte[] array2 = null;
			if (unsafeAssemblyAttributes != null)
			{
				list = new List<CustomAttributeBuilder>(unsafeAssemblyAttributes);
				foreach (CustomAttributeBuilder customAttributeBuilder in list)
				{
					if (customAttributeBuilder.m_con.DeclaringType == typeof(SecurityTransparentAttribute))
					{
						dynamicAssemblyFlags |= DynamicAssemblyFlags.Transparent;
					}
					else if (customAttributeBuilder.m_con.DeclaringType == typeof(SecurityCriticalAttribute))
					{
						SecurityCriticalScope securityCriticalScope = SecurityCriticalScope.Everything;
						if (customAttributeBuilder.m_constructorArgs != null && customAttributeBuilder.m_constructorArgs.Length == 1 && customAttributeBuilder.m_constructorArgs[0] is SecurityCriticalScope)
						{
							securityCriticalScope = (SecurityCriticalScope)customAttributeBuilder.m_constructorArgs[0];
						}
						dynamicAssemblyFlags |= DynamicAssemblyFlags.Critical;
						if (securityCriticalScope == SecurityCriticalScope.Everything)
						{
							dynamicAssemblyFlags |= DynamicAssemblyFlags.AllCritical;
						}
					}
					else if (customAttributeBuilder.m_con.DeclaringType == typeof(SecurityRulesAttribute))
					{
						array = new byte[customAttributeBuilder.m_blob.Length];
						Array.Copy(customAttributeBuilder.m_blob, array, array.Length);
					}
					else if (customAttributeBuilder.m_con.DeclaringType == typeof(SecurityTreatAsSafeAttribute))
					{
						dynamicAssemblyFlags |= DynamicAssemblyFlags.TreatAsSafe;
					}
					else if (customAttributeBuilder.m_con.DeclaringType == typeof(AllowPartiallyTrustedCallersAttribute))
					{
						dynamicAssemblyFlags |= DynamicAssemblyFlags.Aptca;
						array2 = new byte[customAttributeBuilder.m_blob.Length];
						Array.Copy(customAttributeBuilder.m_blob, array2, array2.Length);
					}
				}
			}
			this.m_internalAssemblyBuilder = (InternalAssemblyBuilder)AssemblyBuilder.nCreateDynamicAssembly(domain, name, evidence, ref stackMark, requiredPermissions, optionalPermissions, refusedPermissions, array, array2, access, dynamicAssemblyFlags, securityContextSource);
			this.m_assemblyData = new AssemblyBuilderData(this.m_internalAssemblyBuilder, name.Name, access, dir);
			this.m_assemblyData.AddPermissionRequests(requiredPermissions, optionalPermissions, refusedPermissions);
			if (AppDomain.ProfileAPICheck)
			{
				RuntimeAssembly executingAssembly = RuntimeAssembly.GetExecutingAssembly(ref stackMark);
				if (executingAssembly != null && !executingAssembly.IsFrameworkAssembly())
				{
					this.m_profileAPICheck = true;
				}
			}
			this.InitManifestModule();
			if (list != null)
			{
				foreach (CustomAttributeBuilder customAttribute in list)
				{
					this.SetCustomAttribute(customAttribute);
				}
			}
		}

		// Token: 0x06004917 RID: 18711 RVA: 0x001082DC File Offset: 0x001064DC
		[SecurityCritical]
		private void InitManifestModule()
		{
			InternalModuleBuilder internalModuleBuilder = (InternalModuleBuilder)this.nGetInMemoryAssemblyModule();
			this.m_manifestModuleBuilder = new ModuleBuilder(this, internalModuleBuilder);
			this.m_manifestModuleBuilder.Init("RefEmit_InMemoryManifestModule", null, 0);
			this.m_fManifestModuleUsedAsDefinedModule = false;
		}

		// Token: 0x06004918 RID: 18712 RVA: 0x0010831C File Offset: 0x0010651C
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return AssemblyBuilder.InternalDefineDynamicAssembly(name, access, null, null, null, null, null, ref stackCrawlMark, null, SecurityContextSource.CurrentAssembly);
		}

		// Token: 0x06004919 RID: 18713 RVA: 0x0010833C File Offset: 0x0010653C
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, IEnumerable<CustomAttributeBuilder> assemblyAttributes)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return AssemblyBuilder.InternalDefineDynamicAssembly(name, access, null, null, null, null, null, ref stackCrawlMark, assemblyAttributes, SecurityContextSource.CurrentAssembly);
		}

		// Token: 0x0600491A RID: 18714
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Assembly nCreateDynamicAssembly(AppDomain domain, AssemblyName name, Evidence identity, ref StackCrawlMark stackMark, PermissionSet requiredPermissions, PermissionSet optionalPermissions, PermissionSet refusedPermissions, byte[] securityRulesBlob, byte[] aptcaBlob, AssemblyBuilderAccess access, DynamicAssemblyFlags flags, SecurityContextSource securityContextSource);

		// Token: 0x0600491B RID: 18715 RVA: 0x0010835C File Offset: 0x0010655C
		[SecurityCritical]
		internal static AssemblyBuilder InternalDefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, string dir, Evidence evidence, PermissionSet requiredPermissions, PermissionSet optionalPermissions, PermissionSet refusedPermissions, ref StackCrawlMark stackMark, IEnumerable<CustomAttributeBuilder> unsafeAssemblyAttributes, SecurityContextSource securityContextSource)
		{
			if (evidence != null && !AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_RequiresCasPolicyExplicit"));
			}
			Type typeFromHandle = typeof(AssemblyBuilder.AssemblyBuilderLock);
			AssemblyBuilder result;
			lock (typeFromHandle)
			{
				result = new AssemblyBuilder(AppDomain.CurrentDomain, name, access, dir, evidence, requiredPermissions, optionalPermissions, refusedPermissions, ref stackMark, unsafeAssemblyAttributes, securityContextSource);
			}
			return result;
		}

		// Token: 0x0600491C RID: 18716 RVA: 0x001083D8 File Offset: 0x001065D8
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public ModuleBuilder DefineDynamicModule(string name)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.DefineDynamicModuleInternal(name, false, ref stackCrawlMark);
		}

		// Token: 0x0600491D RID: 18717 RVA: 0x001083F4 File Offset: 0x001065F4
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public ModuleBuilder DefineDynamicModule(string name, bool emitSymbolInfo)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.DefineDynamicModuleInternal(name, emitSymbolInfo, ref stackCrawlMark);
		}

		// Token: 0x0600491E RID: 18718 RVA: 0x00108410 File Offset: 0x00106610
		[SecurityCritical]
		private ModuleBuilder DefineDynamicModuleInternal(string name, bool emitSymbolInfo, ref StackCrawlMark stackMark)
		{
			object syncRoot = this.SyncRoot;
			ModuleBuilder result;
			lock (syncRoot)
			{
				result = this.DefineDynamicModuleInternalNoLock(name, emitSymbolInfo, ref stackMark);
			}
			return result;
		}

		// Token: 0x0600491F RID: 18719 RVA: 0x00108458 File Offset: 0x00106658
		[SecurityCritical]
		private ModuleBuilder DefineDynamicModuleInternalNoLock(string name, bool emitSymbolInfo, ref StackCrawlMark stackMark)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			if (name[0] == '\0')
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidName"), "name");
			}
			ISymbolWriter symbolWriter = null;
			IntPtr underlyingWriter = 0;
			this.m_assemblyData.CheckNameConflict(name);
			ModuleBuilder moduleBuilder;
			if (this.m_fManifestModuleUsedAsDefinedModule)
			{
				int tkFile;
				InternalModuleBuilder internalModuleBuilder = (InternalModuleBuilder)AssemblyBuilder.DefineDynamicModule(this.InternalAssembly, emitSymbolInfo, name, name, ref stackMark, ref underlyingWriter, true, out tkFile);
				moduleBuilder = new ModuleBuilder(this, internalModuleBuilder);
				moduleBuilder.Init(name, null, tkFile);
			}
			else
			{
				this.m_manifestModuleBuilder.ModifyModuleName(name);
				moduleBuilder = this.m_manifestModuleBuilder;
				if (emitSymbolInfo)
				{
					underlyingWriter = ModuleBuilder.nCreateISymWriterForDynamicModule(moduleBuilder.InternalModule, name);
				}
			}
			if (emitSymbolInfo)
			{
				Assembly assembly = this.LoadISymWrapper();
				Type type = assembly.GetType("System.Diagnostics.SymbolStore.SymWriter", true, false);
				if (type != null && !type.IsVisible)
				{
					type = null;
				}
				if (type == null)
				{
					throw new TypeLoadException(Environment.GetResourceString("MissingType", new object[]
					{
						"SymWriter"
					}));
				}
				new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
				try
				{
					new PermissionSet(PermissionState.Unrestricted).Assert();
					symbolWriter = (ISymbolWriter)Activator.CreateInstance(type);
					symbolWriter.SetUnderlyingWriter(underlyingWriter);
				}
				finally
				{
					CodeAccessPermission.RevertAssert();
				}
			}
			moduleBuilder.SetSymWriter(symbolWriter);
			this.m_assemblyData.AddModule(moduleBuilder);
			if (moduleBuilder == this.m_manifestModuleBuilder)
			{
				this.m_fManifestModuleUsedAsDefinedModule = true;
			}
			return moduleBuilder;
		}

		// Token: 0x06004920 RID: 18720 RVA: 0x001085E8 File Offset: 0x001067E8
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public ModuleBuilder DefineDynamicModule(string name, string fileName)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.DefineDynamicModuleInternal(name, fileName, false, ref stackCrawlMark);
		}

		// Token: 0x06004921 RID: 18721 RVA: 0x00108604 File Offset: 0x00106804
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public ModuleBuilder DefineDynamicModule(string name, string fileName, bool emitSymbolInfo)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.DefineDynamicModuleInternal(name, fileName, emitSymbolInfo, ref stackCrawlMark);
		}

		// Token: 0x06004922 RID: 18722 RVA: 0x00108620 File Offset: 0x00106820
		[SecurityCritical]
		private ModuleBuilder DefineDynamicModuleInternal(string name, string fileName, bool emitSymbolInfo, ref StackCrawlMark stackMark)
		{
			object syncRoot = this.SyncRoot;
			ModuleBuilder result;
			lock (syncRoot)
			{
				result = this.DefineDynamicModuleInternalNoLock(name, fileName, emitSymbolInfo, ref stackMark);
			}
			return result;
		}

		// Token: 0x06004923 RID: 18723 RVA: 0x00108668 File Offset: 0x00106868
		[SecurityCritical]
		private ModuleBuilder DefineDynamicModuleInternalNoLock(string name, string fileName, bool emitSymbolInfo, ref StackCrawlMark stackMark)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			if (name[0] == '\0')
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidName"), "name");
			}
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (fileName.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyFileName"), "fileName");
			}
			if (!string.Equals(fileName, Path.GetFileName(fileName)))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NotSimpleFileName"), "fileName");
			}
			if (this.m_assemblyData.m_access == AssemblyBuilderAccess.Run)
			{
				throw new NotSupportedException(Environment.GetResourceString("Argument_BadPersistableModuleInTransientAssembly"));
			}
			if (this.m_assemblyData.m_isSaved)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotAlterAssembly"));
			}
			ISymbolWriter symbolWriter = null;
			IntPtr underlyingWriter = 0;
			this.m_assemblyData.CheckNameConflict(name);
			this.m_assemblyData.CheckFileNameConflict(fileName);
			int tkFile;
			InternalModuleBuilder internalModuleBuilder = (InternalModuleBuilder)AssemblyBuilder.DefineDynamicModule(this.InternalAssembly, emitSymbolInfo, name, fileName, ref stackMark, ref underlyingWriter, false, out tkFile);
			ModuleBuilder moduleBuilder = new ModuleBuilder(this, internalModuleBuilder);
			moduleBuilder.Init(name, fileName, tkFile);
			if (emitSymbolInfo)
			{
				Assembly assembly = this.LoadISymWrapper();
				Type type = assembly.GetType("System.Diagnostics.SymbolStore.SymWriter", true, false);
				if (type != null && !type.IsVisible)
				{
					type = null;
				}
				if (type == null)
				{
					throw new TypeLoadException(Environment.GetResourceString("MissingType", new object[]
					{
						"SymWriter"
					}));
				}
				try
				{
					new PermissionSet(PermissionState.Unrestricted).Assert();
					symbolWriter = (ISymbolWriter)Activator.CreateInstance(type);
					symbolWriter.SetUnderlyingWriter(underlyingWriter);
				}
				finally
				{
					CodeAccessPermission.RevertAssert();
				}
			}
			moduleBuilder.SetSymWriter(symbolWriter);
			this.m_assemblyData.AddModule(moduleBuilder);
			return moduleBuilder;
		}

		// Token: 0x06004924 RID: 18724 RVA: 0x0010883C File Offset: 0x00106A3C
		private Assembly LoadISymWrapper()
		{
			if (this.m_assemblyData.m_ISymWrapperAssembly != null)
			{
				return this.m_assemblyData.m_ISymWrapperAssembly;
			}
			Assembly assembly = Assembly.Load("ISymWrapper, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
			this.m_assemblyData.m_ISymWrapperAssembly = assembly;
			return assembly;
		}

		// Token: 0x06004925 RID: 18725 RVA: 0x00108880 File Offset: 0x00106A80
		internal void CheckContext(params Type[][] typess)
		{
			if (typess == null)
			{
				return;
			}
			foreach (Type[] array in typess)
			{
				if (array != null)
				{
					this.CheckContext(array);
				}
			}
		}

		// Token: 0x06004926 RID: 18726 RVA: 0x001088B0 File Offset: 0x00106AB0
		internal void CheckContext(params Type[] types)
		{
			if (types == null)
			{
				return;
			}
			foreach (Type type in types)
			{
				if (!(type == null))
				{
					if (type.Module == null || type.Module.Assembly == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_TypeNotValid"));
					}
					if (!(type.Module.Assembly == typeof(object).Module.Assembly))
					{
						if (type.Module.Assembly.ReflectionOnly && !this.ReflectionOnly)
						{
							throw new InvalidOperationException(Environment.GetResourceString("Arugment_EmitMixedContext1", new object[]
							{
								type.AssemblyQualifiedName
							}));
						}
						if (!type.Module.Assembly.ReflectionOnly && this.ReflectionOnly)
						{
							throw new InvalidOperationException(Environment.GetResourceString("Arugment_EmitMixedContext2", new object[]
							{
								type.AssemblyQualifiedName
							}));
						}
					}
				}
			}
		}

		// Token: 0x06004927 RID: 18727 RVA: 0x001089B0 File Offset: 0x00106BB0
		public IResourceWriter DefineResource(string name, string description, string fileName)
		{
			return this.DefineResource(name, description, fileName, ResourceAttributes.Public);
		}

		// Token: 0x06004928 RID: 18728 RVA: 0x001089BC File Offset: 0x00106BBC
		public IResourceWriter DefineResource(string name, string description, string fileName, ResourceAttributes attribute)
		{
			object syncRoot = this.SyncRoot;
			IResourceWriter result;
			lock (syncRoot)
			{
				result = this.DefineResourceNoLock(name, description, fileName, attribute);
			}
			return result;
		}

		// Token: 0x06004929 RID: 18729 RVA: 0x00108A04 File Offset: 0x00106C04
		private IResourceWriter DefineResourceNoLock(string name, string description, string fileName, ResourceAttributes attribute)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), name);
			}
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (fileName.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyFileName"), "fileName");
			}
			if (!string.Equals(fileName, Path.GetFileName(fileName)))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NotSimpleFileName"), "fileName");
			}
			this.m_assemblyData.CheckResNameConflict(name);
			this.m_assemblyData.CheckFileNameConflict(fileName);
			string text;
			ResourceWriter resourceWriter;
			if (this.m_assemblyData.m_strDir == null)
			{
				text = Path.Combine(Environment.CurrentDirectory, fileName);
				resourceWriter = new ResourceWriter(text);
			}
			else
			{
				text = Path.Combine(this.m_assemblyData.m_strDir, fileName);
				resourceWriter = new ResourceWriter(text);
			}
			text = Path.GetFullPath(text);
			fileName = Path.GetFileName(text);
			this.m_assemblyData.AddResWriter(new ResWriterData(resourceWriter, null, name, fileName, text, attribute));
			return resourceWriter;
		}

		// Token: 0x0600492A RID: 18730 RVA: 0x00108B00 File Offset: 0x00106D00
		public void AddResourceFile(string name, string fileName)
		{
			this.AddResourceFile(name, fileName, ResourceAttributes.Public);
		}

		// Token: 0x0600492B RID: 18731 RVA: 0x00108B0C File Offset: 0x00106D0C
		public void AddResourceFile(string name, string fileName, ResourceAttributes attribute)
		{
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.AddResourceFileNoLock(name, fileName, attribute);
			}
		}

		// Token: 0x0600492C RID: 18732 RVA: 0x00108B50 File Offset: 0x00106D50
		[SecuritySafeCritical]
		private void AddResourceFileNoLock(string name, string fileName, ResourceAttributes attribute)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), name);
			}
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (fileName.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyFileName"), fileName);
			}
			if (!string.Equals(fileName, Path.GetFileName(fileName)))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NotSimpleFileName"), "fileName");
			}
			this.m_assemblyData.CheckResNameConflict(name);
			this.m_assemblyData.CheckFileNameConflict(fileName);
			string text;
			if (this.m_assemblyData.m_strDir == null)
			{
				text = Path.Combine(Environment.CurrentDirectory, fileName);
			}
			else
			{
				text = Path.Combine(this.m_assemblyData.m_strDir, fileName);
			}
			text = Path.UnsafeGetFullPath(text);
			fileName = Path.GetFileName(text);
			if (!File.UnsafeExists(text))
			{
				throw new FileNotFoundException(Environment.GetResourceString("IO.FileNotFound_FileName", new object[]
				{
					fileName
				}), fileName);
			}
			this.m_assemblyData.AddResWriter(new ResWriterData(null, null, name, fileName, text, attribute));
		}

		// Token: 0x0600492D RID: 18733 RVA: 0x00108C5B File Offset: 0x00106E5B
		public override bool Equals(object obj)
		{
			return this.InternalAssembly.Equals(obj);
		}

		// Token: 0x0600492E RID: 18734 RVA: 0x00108C69 File Offset: 0x00106E69
		public override int GetHashCode()
		{
			return this.InternalAssembly.GetHashCode();
		}

		// Token: 0x0600492F RID: 18735 RVA: 0x00108C76 File Offset: 0x00106E76
		public override object[] GetCustomAttributes(bool inherit)
		{
			return this.InternalAssembly.GetCustomAttributes(inherit);
		}

		// Token: 0x06004930 RID: 18736 RVA: 0x00108C84 File Offset: 0x00106E84
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return this.InternalAssembly.GetCustomAttributes(attributeType, inherit);
		}

		// Token: 0x06004931 RID: 18737 RVA: 0x00108C93 File Offset: 0x00106E93
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return this.InternalAssembly.IsDefined(attributeType, inherit);
		}

		// Token: 0x06004932 RID: 18738 RVA: 0x00108CA2 File Offset: 0x00106EA2
		public override IList<CustomAttributeData> GetCustomAttributesData()
		{
			return this.InternalAssembly.GetCustomAttributesData();
		}

		// Token: 0x06004933 RID: 18739 RVA: 0x00108CAF File Offset: 0x00106EAF
		public override string[] GetManifestResourceNames()
		{
			return this.InternalAssembly.GetManifestResourceNames();
		}

		// Token: 0x06004934 RID: 18740 RVA: 0x00108CBC File Offset: 0x00106EBC
		public override FileStream GetFile(string name)
		{
			return this.InternalAssembly.GetFile(name);
		}

		// Token: 0x06004935 RID: 18741 RVA: 0x00108CCA File Offset: 0x00106ECA
		public override FileStream[] GetFiles(bool getResourceModules)
		{
			return this.InternalAssembly.GetFiles(getResourceModules);
		}

		// Token: 0x06004936 RID: 18742 RVA: 0x00108CD8 File Offset: 0x00106ED8
		public override Stream GetManifestResourceStream(Type type, string name)
		{
			return this.InternalAssembly.GetManifestResourceStream(type, name);
		}

		// Token: 0x06004937 RID: 18743 RVA: 0x00108CE7 File Offset: 0x00106EE7
		public override Stream GetManifestResourceStream(string name)
		{
			return this.InternalAssembly.GetManifestResourceStream(name);
		}

		// Token: 0x06004938 RID: 18744 RVA: 0x00108CF5 File Offset: 0x00106EF5
		public override ManifestResourceInfo GetManifestResourceInfo(string resourceName)
		{
			return this.InternalAssembly.GetManifestResourceInfo(resourceName);
		}

		// Token: 0x17000B71 RID: 2929
		// (get) Token: 0x06004939 RID: 18745 RVA: 0x00108D03 File Offset: 0x00106F03
		public override string Location
		{
			get
			{
				return this.InternalAssembly.Location;
			}
		}

		// Token: 0x17000B72 RID: 2930
		// (get) Token: 0x0600493A RID: 18746 RVA: 0x00108D10 File Offset: 0x00106F10
		public override string ImageRuntimeVersion
		{
			get
			{
				return this.InternalAssembly.ImageRuntimeVersion;
			}
		}

		// Token: 0x17000B73 RID: 2931
		// (get) Token: 0x0600493B RID: 18747 RVA: 0x00108D1D File Offset: 0x00106F1D
		public override string CodeBase
		{
			get
			{
				return this.InternalAssembly.CodeBase;
			}
		}

		// Token: 0x17000B74 RID: 2932
		// (get) Token: 0x0600493C RID: 18748 RVA: 0x00108D2A File Offset: 0x00106F2A
		public override MethodInfo EntryPoint
		{
			get
			{
				return this.m_assemblyData.m_entryPointMethod;
			}
		}

		// Token: 0x0600493D RID: 18749 RVA: 0x00108D37 File Offset: 0x00106F37
		public override Type[] GetExportedTypes()
		{
			return this.InternalAssembly.GetExportedTypes();
		}

		// Token: 0x0600493E RID: 18750 RVA: 0x00108D44 File Offset: 0x00106F44
		public override AssemblyName GetName(bool copiedName)
		{
			return this.InternalAssembly.GetName(copiedName);
		}

		// Token: 0x17000B75 RID: 2933
		// (get) Token: 0x0600493F RID: 18751 RVA: 0x00108D52 File Offset: 0x00106F52
		public override string FullName
		{
			get
			{
				return this.InternalAssembly.FullName;
			}
		}

		// Token: 0x06004940 RID: 18752 RVA: 0x00108D5F File Offset: 0x00106F5F
		public override Type GetType(string name, bool throwOnError, bool ignoreCase)
		{
			return this.InternalAssembly.GetType(name, throwOnError, ignoreCase);
		}

		// Token: 0x17000B76 RID: 2934
		// (get) Token: 0x06004941 RID: 18753 RVA: 0x00108D6F File Offset: 0x00106F6F
		public override Evidence Evidence
		{
			get
			{
				return this.InternalAssembly.Evidence;
			}
		}

		// Token: 0x17000B77 RID: 2935
		// (get) Token: 0x06004942 RID: 18754 RVA: 0x00108D7C File Offset: 0x00106F7C
		public override PermissionSet PermissionSet
		{
			[SecurityCritical]
			get
			{
				return this.InternalAssembly.PermissionSet;
			}
		}

		// Token: 0x17000B78 RID: 2936
		// (get) Token: 0x06004943 RID: 18755 RVA: 0x00108D89 File Offset: 0x00106F89
		public override SecurityRuleSet SecurityRuleSet
		{
			get
			{
				return this.InternalAssembly.SecurityRuleSet;
			}
		}

		// Token: 0x17000B79 RID: 2937
		// (get) Token: 0x06004944 RID: 18756 RVA: 0x00108D96 File Offset: 0x00106F96
		public override Module ManifestModule
		{
			get
			{
				return this.m_manifestModuleBuilder.InternalModule;
			}
		}

		// Token: 0x17000B7A RID: 2938
		// (get) Token: 0x06004945 RID: 18757 RVA: 0x00108DA3 File Offset: 0x00106FA3
		public override bool ReflectionOnly
		{
			get
			{
				return this.InternalAssembly.ReflectionOnly;
			}
		}

		// Token: 0x06004946 RID: 18758 RVA: 0x00108DB0 File Offset: 0x00106FB0
		public override Module GetModule(string name)
		{
			return this.InternalAssembly.GetModule(name);
		}

		// Token: 0x06004947 RID: 18759 RVA: 0x00108DBE File Offset: 0x00106FBE
		public override AssemblyName[] GetReferencedAssemblies()
		{
			return this.InternalAssembly.GetReferencedAssemblies();
		}

		// Token: 0x17000B7B RID: 2939
		// (get) Token: 0x06004948 RID: 18760 RVA: 0x00108DCB File Offset: 0x00106FCB
		public override bool GlobalAssemblyCache
		{
			get
			{
				return this.InternalAssembly.GlobalAssemblyCache;
			}
		}

		// Token: 0x17000B7C RID: 2940
		// (get) Token: 0x06004949 RID: 18761 RVA: 0x00108DD8 File Offset: 0x00106FD8
		public override long HostContext
		{
			get
			{
				return this.InternalAssembly.HostContext;
			}
		}

		// Token: 0x0600494A RID: 18762 RVA: 0x00108DE5 File Offset: 0x00106FE5
		public override Module[] GetModules(bool getResourceModules)
		{
			return this.InternalAssembly.GetModules(getResourceModules);
		}

		// Token: 0x0600494B RID: 18763 RVA: 0x00108DF3 File Offset: 0x00106FF3
		public override Module[] GetLoadedModules(bool getResourceModules)
		{
			return this.InternalAssembly.GetLoadedModules(getResourceModules);
		}

		// Token: 0x0600494C RID: 18764 RVA: 0x00108E04 File Offset: 0x00107004
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Assembly GetSatelliteAssembly(CultureInfo culture)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.InternalAssembly.InternalGetSatelliteAssembly(culture, null, ref stackCrawlMark);
		}

		// Token: 0x0600494D RID: 18765 RVA: 0x00108E24 File Offset: 0x00107024
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Assembly GetSatelliteAssembly(CultureInfo culture, Version version)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.InternalAssembly.InternalGetSatelliteAssembly(culture, version, ref stackCrawlMark);
		}

		// Token: 0x17000B7D RID: 2941
		// (get) Token: 0x0600494E RID: 18766 RVA: 0x00108E42 File Offset: 0x00107042
		public override bool IsDynamic
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600494F RID: 18767 RVA: 0x00108E48 File Offset: 0x00107048
		public void DefineVersionInfoResource(string product, string productVersion, string company, string copyright, string trademark)
		{
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.DefineVersionInfoResourceNoLock(product, productVersion, company, copyright, trademark);
			}
		}

		// Token: 0x06004950 RID: 18768 RVA: 0x00108E90 File Offset: 0x00107090
		private void DefineVersionInfoResourceNoLock(string product, string productVersion, string company, string copyright, string trademark)
		{
			if (this.m_assemblyData.m_strResourceFileName != null || this.m_assemblyData.m_resourceBytes != null || this.m_assemblyData.m_nativeVersion != null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NativeResourceAlreadyDefined"));
			}
			this.m_assemblyData.m_nativeVersion = new NativeVersionInfo();
			this.m_assemblyData.m_nativeVersion.m_strCopyright = copyright;
			this.m_assemblyData.m_nativeVersion.m_strTrademark = trademark;
			this.m_assemblyData.m_nativeVersion.m_strCompany = company;
			this.m_assemblyData.m_nativeVersion.m_strProduct = product;
			this.m_assemblyData.m_nativeVersion.m_strProductVersion = productVersion;
			this.m_assemblyData.m_hasUnmanagedVersionInfo = true;
			this.m_assemblyData.m_OverrideUnmanagedVersionInfo = true;
		}

		// Token: 0x06004951 RID: 18769 RVA: 0x00108F54 File Offset: 0x00107154
		public void DefineVersionInfoResource()
		{
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.DefineVersionInfoResourceNoLock();
			}
		}

		// Token: 0x06004952 RID: 18770 RVA: 0x00108F94 File Offset: 0x00107194
		private void DefineVersionInfoResourceNoLock()
		{
			if (this.m_assemblyData.m_strResourceFileName != null || this.m_assemblyData.m_resourceBytes != null || this.m_assemblyData.m_nativeVersion != null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NativeResourceAlreadyDefined"));
			}
			this.m_assemblyData.m_hasUnmanagedVersionInfo = true;
			this.m_assemblyData.m_nativeVersion = new NativeVersionInfo();
		}

		// Token: 0x06004953 RID: 18771 RVA: 0x00108FF4 File Offset: 0x001071F4
		public void DefineUnmanagedResource(byte[] resource)
		{
			if (resource == null)
			{
				throw new ArgumentNullException("resource");
			}
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.DefineUnmanagedResourceNoLock(resource);
			}
		}

		// Token: 0x06004954 RID: 18772 RVA: 0x00109044 File Offset: 0x00107244
		private void DefineUnmanagedResourceNoLock(byte[] resource)
		{
			if (this.m_assemblyData.m_strResourceFileName != null || this.m_assemblyData.m_resourceBytes != null || this.m_assemblyData.m_nativeVersion != null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NativeResourceAlreadyDefined"));
			}
			this.m_assemblyData.m_resourceBytes = new byte[resource.Length];
			Array.Copy(resource, this.m_assemblyData.m_resourceBytes, resource.Length);
		}

		// Token: 0x06004955 RID: 18773 RVA: 0x001090B0 File Offset: 0x001072B0
		[SecuritySafeCritical]
		public void DefineUnmanagedResource(string resourceFileName)
		{
			if (resourceFileName == null)
			{
				throw new ArgumentNullException("resourceFileName");
			}
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.DefineUnmanagedResourceNoLock(resourceFileName);
			}
		}

		// Token: 0x06004956 RID: 18774 RVA: 0x00109100 File Offset: 0x00107300
		[SecurityCritical]
		private void DefineUnmanagedResourceNoLock(string resourceFileName)
		{
			if (this.m_assemblyData.m_strResourceFileName != null || this.m_assemblyData.m_resourceBytes != null || this.m_assemblyData.m_nativeVersion != null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NativeResourceAlreadyDefined"));
			}
			string text;
			if (this.m_assemblyData.m_strDir == null)
			{
				text = Path.Combine(Environment.CurrentDirectory, resourceFileName);
			}
			else
			{
				text = Path.Combine(this.m_assemblyData.m_strDir, resourceFileName);
			}
			text = Path.GetFullPath(resourceFileName);
			new FileIOPermission(FileIOPermissionAccess.Read, text).Demand();
			if (!File.Exists(text))
			{
				throw new FileNotFoundException(Environment.GetResourceString("IO.FileNotFound_FileName", new object[]
				{
					resourceFileName
				}), resourceFileName);
			}
			this.m_assemblyData.m_strResourceFileName = text;
		}

		// Token: 0x06004957 RID: 18775 RVA: 0x001091B4 File Offset: 0x001073B4
		public ModuleBuilder GetDynamicModule(string name)
		{
			object syncRoot = this.SyncRoot;
			ModuleBuilder dynamicModuleNoLock;
			lock (syncRoot)
			{
				dynamicModuleNoLock = this.GetDynamicModuleNoLock(name);
			}
			return dynamicModuleNoLock;
		}

		// Token: 0x06004958 RID: 18776 RVA: 0x001091F8 File Offset: 0x001073F8
		private ModuleBuilder GetDynamicModuleNoLock(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			int count = this.m_assemblyData.m_moduleBuilderList.Count;
			for (int i = 0; i < count; i++)
			{
				ModuleBuilder moduleBuilder = this.m_assemblyData.m_moduleBuilderList[i];
				if (moduleBuilder.m_moduleData.m_strModuleName.Equals(name))
				{
					return moduleBuilder;
				}
			}
			return null;
		}

		// Token: 0x06004959 RID: 18777 RVA: 0x00109275 File Offset: 0x00107475
		public void SetEntryPoint(MethodInfo entryMethod)
		{
			this.SetEntryPoint(entryMethod, PEFileKinds.ConsoleApplication);
		}

		// Token: 0x0600495A RID: 18778 RVA: 0x00109280 File Offset: 0x00107480
		public void SetEntryPoint(MethodInfo entryMethod, PEFileKinds fileKind)
		{
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.SetEntryPointNoLock(entryMethod, fileKind);
			}
		}

		// Token: 0x0600495B RID: 18779 RVA: 0x001092C4 File Offset: 0x001074C4
		private void SetEntryPointNoLock(MethodInfo entryMethod, PEFileKinds fileKind)
		{
			if (entryMethod == null)
			{
				throw new ArgumentNullException("entryMethod");
			}
			Module module = entryMethod.Module;
			if (module == null || !this.InternalAssembly.Equals(module.Assembly))
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EntryMethodNotDefinedInAssembly"));
			}
			this.m_assemblyData.m_entryPointMethod = entryMethod;
			this.m_assemblyData.m_peFileKind = fileKind;
			ModuleBuilder moduleBuilder = module as ModuleBuilder;
			if (moduleBuilder != null)
			{
				this.m_assemblyData.m_entryPointModule = moduleBuilder;
			}
			else
			{
				this.m_assemblyData.m_entryPointModule = this.GetModuleBuilder((InternalModuleBuilder)module);
			}
			MethodToken methodToken = this.m_assemblyData.m_entryPointModule.GetMethodToken(entryMethod);
			this.m_assemblyData.m_entryPointModule.SetEntryPoint(methodToken);
		}

		// Token: 0x0600495C RID: 18780 RVA: 0x00109388 File Offset: 0x00107588
		[SecuritySafeCritical]
		[ComVisible(true)]
		public void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
		{
			if (con == null)
			{
				throw new ArgumentNullException("con");
			}
			if (binaryAttribute == null)
			{
				throw new ArgumentNullException("binaryAttribute");
			}
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.SetCustomAttributeNoLock(con, binaryAttribute);
			}
		}

		// Token: 0x0600495D RID: 18781 RVA: 0x001093EC File Offset: 0x001075EC
		[SecurityCritical]
		private void SetCustomAttributeNoLock(ConstructorInfo con, byte[] binaryAttribute)
		{
			TypeBuilder.DefineCustomAttribute(this.m_manifestModuleBuilder, 536870913, this.m_manifestModuleBuilder.GetConstructorToken(con).Token, binaryAttribute, false, typeof(DebuggableAttribute) == con.DeclaringType);
			if (this.m_assemblyData.m_access != AssemblyBuilderAccess.Run)
			{
				this.m_assemblyData.AddCustomAttribute(con, binaryAttribute);
			}
		}

		// Token: 0x0600495E RID: 18782 RVA: 0x00109450 File Offset: 0x00107650
		[SecuritySafeCritical]
		public void SetCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			if (customBuilder == null)
			{
				throw new ArgumentNullException("customBuilder");
			}
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.SetCustomAttributeNoLock(customBuilder);
			}
		}

		// Token: 0x0600495F RID: 18783 RVA: 0x001094A0 File Offset: 0x001076A0
		[SecurityCritical]
		private void SetCustomAttributeNoLock(CustomAttributeBuilder customBuilder)
		{
			customBuilder.CreateCustomAttribute(this.m_manifestModuleBuilder, 536870913);
			if (this.m_assemblyData.m_access != AssemblyBuilderAccess.Run)
			{
				this.m_assemblyData.AddCustomAttribute(customBuilder);
			}
		}

		// Token: 0x06004960 RID: 18784 RVA: 0x001094CD File Offset: 0x001076CD
		public void Save(string assemblyFileName)
		{
			this.Save(assemblyFileName, PortableExecutableKinds.ILOnly, ImageFileMachine.I386);
		}

		// Token: 0x06004961 RID: 18785 RVA: 0x001094DC File Offset: 0x001076DC
		[SecuritySafeCritical]
		public void Save(string assemblyFileName, PortableExecutableKinds portableExecutableKind, ImageFileMachine imageFileMachine)
		{
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.SaveNoLock(assemblyFileName, portableExecutableKind, imageFileMachine);
			}
		}

		// Token: 0x06004962 RID: 18786 RVA: 0x00109520 File Offset: 0x00107720
		[SecurityCritical]
		private void SaveNoLock(string assemblyFileName, PortableExecutableKinds portableExecutableKind, ImageFileMachine imageFileMachine)
		{
			if (assemblyFileName == null)
			{
				throw new ArgumentNullException("assemblyFileName");
			}
			if (assemblyFileName.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyFileName"), "assemblyFileName");
			}
			if (!string.Equals(assemblyFileName, Path.GetFileName(assemblyFileName)))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NotSimpleFileName"), "assemblyFileName");
			}
			int[] array = null;
			int[] array2 = null;
			string text = null;
			try
			{
				if (this.m_assemblyData.m_iCABuilder != 0)
				{
					array = new int[this.m_assemblyData.m_iCABuilder];
				}
				if (this.m_assemblyData.m_iCAs != 0)
				{
					array2 = new int[this.m_assemblyData.m_iCAs];
				}
				if (this.m_assemblyData.m_isSaved)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_AssemblyHasBeenSaved", new object[]
					{
						this.InternalAssembly.GetSimpleName()
					}));
				}
				if ((this.m_assemblyData.m_access & AssemblyBuilderAccess.Save) != AssemblyBuilderAccess.Save)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CantSaveTransientAssembly"));
				}
				ModuleBuilder moduleBuilder = this.m_assemblyData.FindModuleWithFileName(assemblyFileName);
				if (moduleBuilder != null)
				{
					this.m_onDiskAssemblyModuleBuilder = moduleBuilder;
					moduleBuilder.m_moduleData.FileToken = 0;
				}
				else
				{
					this.m_assemblyData.CheckFileNameConflict(assemblyFileName);
				}
				if (this.m_assemblyData.m_strDir == null)
				{
					this.m_assemblyData.m_strDir = Environment.CurrentDirectory;
				}
				else if (!Directory.Exists(this.m_assemblyData.m_strDir))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidDirectory", new object[]
					{
						this.m_assemblyData.m_strDir
					}));
				}
				assemblyFileName = Path.Combine(this.m_assemblyData.m_strDir, assemblyFileName);
				assemblyFileName = Path.GetFullPath(assemblyFileName);
				new FileIOPermission(FileIOPermissionAccess.Write | FileIOPermissionAccess.Append, assemblyFileName).Demand();
				if (moduleBuilder != null)
				{
					for (int i = 0; i < this.m_assemblyData.m_iCABuilder; i++)
					{
						array[i] = this.m_assemblyData.m_CABuilders[i].PrepareCreateCustomAttributeToDisk(moduleBuilder);
					}
					for (int i = 0; i < this.m_assemblyData.m_iCAs; i++)
					{
						array2[i] = moduleBuilder.InternalGetConstructorToken(this.m_assemblyData.m_CACons[i], true).Token;
					}
					moduleBuilder.PreSave(assemblyFileName, portableExecutableKind, imageFileMachine);
				}
				RuntimeModule assemblyModule = (moduleBuilder != null) ? moduleBuilder.ModuleHandle.GetRuntimeModule() : null;
				AssemblyBuilder.PrepareForSavingManifestToDisk(this.GetNativeHandle(), assemblyModule);
				ModuleBuilder onDiskAssemblyModuleBuilder = this.GetOnDiskAssemblyModuleBuilder();
				if (this.m_assemblyData.m_strResourceFileName != null)
				{
					onDiskAssemblyModuleBuilder.DefineUnmanagedResourceFileInternalNoLock(this.m_assemblyData.m_strResourceFileName);
				}
				else if (this.m_assemblyData.m_resourceBytes != null)
				{
					onDiskAssemblyModuleBuilder.DefineUnmanagedResourceInternalNoLock(this.m_assemblyData.m_resourceBytes);
				}
				else if (this.m_assemblyData.m_hasUnmanagedVersionInfo)
				{
					this.m_assemblyData.FillUnmanagedVersionInfo();
					string text2 = this.m_assemblyData.m_nativeVersion.m_strFileVersion;
					if (text2 == null)
					{
						text2 = this.GetVersion().ToString();
					}
					AssemblyBuilder.CreateVersionInfoResource(assemblyFileName, this.m_assemblyData.m_nativeVersion.m_strTitle, null, this.m_assemblyData.m_nativeVersion.m_strDescription, this.m_assemblyData.m_nativeVersion.m_strCopyright, this.m_assemblyData.m_nativeVersion.m_strTrademark, this.m_assemblyData.m_nativeVersion.m_strCompany, this.m_assemblyData.m_nativeVersion.m_strProduct, this.m_assemblyData.m_nativeVersion.m_strProductVersion, text2, this.m_assemblyData.m_nativeVersion.m_lcid, this.m_assemblyData.m_peFileKind == PEFileKinds.Dll, JitHelpers.GetStringHandleOnStack(ref text));
					onDiskAssemblyModuleBuilder.DefineUnmanagedResourceFileInternalNoLock(text);
				}
				if (moduleBuilder == null)
				{
					for (int i = 0; i < this.m_assemblyData.m_iCABuilder; i++)
					{
						array[i] = this.m_assemblyData.m_CABuilders[i].PrepareCreateCustomAttributeToDisk(onDiskAssemblyModuleBuilder);
					}
					for (int i = 0; i < this.m_assemblyData.m_iCAs; i++)
					{
						array2[i] = onDiskAssemblyModuleBuilder.InternalGetConstructorToken(this.m_assemblyData.m_CACons[i], true).Token;
					}
				}
				int count = this.m_assemblyData.m_moduleBuilderList.Count;
				for (int i = 0; i < count; i++)
				{
					ModuleBuilder moduleBuilder2 = this.m_assemblyData.m_moduleBuilderList[i];
					if (!moduleBuilder2.IsTransient() && moduleBuilder2 != moduleBuilder)
					{
						string text3 = moduleBuilder2.m_moduleData.m_strFileName;
						if (this.m_assemblyData.m_strDir != null)
						{
							text3 = Path.Combine(this.m_assemblyData.m_strDir, text3);
							text3 = Path.GetFullPath(text3);
						}
						new FileIOPermission(FileIOPermissionAccess.Write | FileIOPermissionAccess.Append, text3).Demand();
						moduleBuilder2.m_moduleData.FileToken = AssemblyBuilder.AddFile(this.GetNativeHandle(), moduleBuilder2.m_moduleData.m_strFileName);
						moduleBuilder2.PreSave(text3, portableExecutableKind, imageFileMachine);
						moduleBuilder2.Save(text3, false, portableExecutableKind, imageFileMachine);
						AssemblyBuilder.SetFileHashValue(this.GetNativeHandle(), moduleBuilder2.m_moduleData.FileToken, text3);
					}
				}
				for (int i = 0; i < this.m_assemblyData.m_iPublicComTypeCount; i++)
				{
					Type type = this.m_assemblyData.m_publicComTypeList[i];
					if (type is RuntimeType)
					{
						InternalModuleBuilder module = (InternalModuleBuilder)type.Module;
						ModuleBuilder moduleBuilder3 = this.GetModuleBuilder(module);
						if (moduleBuilder3 != moduleBuilder)
						{
							this.DefineNestedComType(type, moduleBuilder3.m_moduleData.FileToken, type.MetadataToken);
						}
					}
					else
					{
						TypeBuilder typeBuilder = (TypeBuilder)type;
						ModuleBuilder moduleBuilder3 = typeBuilder.GetModuleBuilder();
						if (moduleBuilder3 != moduleBuilder)
						{
							this.DefineNestedComType(type, moduleBuilder3.m_moduleData.FileToken, typeBuilder.MetadataTokenInternal);
						}
					}
				}
				if (onDiskAssemblyModuleBuilder != this.m_manifestModuleBuilder)
				{
					for (int i = 0; i < this.m_assemblyData.m_iCABuilder; i++)
					{
						this.m_assemblyData.m_CABuilders[i].CreateCustomAttribute(onDiskAssemblyModuleBuilder, 536870913, array[i], true);
					}
					for (int i = 0; i < this.m_assemblyData.m_iCAs; i++)
					{
						TypeBuilder.DefineCustomAttribute(onDiskAssemblyModuleBuilder, 536870913, array2[i], this.m_assemblyData.m_CABytes[i], true, false);
					}
				}
				if (this.m_assemblyData.m_RequiredPset != null)
				{
					this.AddDeclarativeSecurity(this.m_assemblyData.m_RequiredPset, SecurityAction.RequestMinimum);
				}
				if (this.m_assemblyData.m_RefusedPset != null)
				{
					this.AddDeclarativeSecurity(this.m_assemblyData.m_RefusedPset, SecurityAction.RequestRefuse);
				}
				if (this.m_assemblyData.m_OptionalPset != null)
				{
					this.AddDeclarativeSecurity(this.m_assemblyData.m_OptionalPset, SecurityAction.RequestOptional);
				}
				count = this.m_assemblyData.m_resWriterList.Count;
				for (int i = 0; i < count; i++)
				{
					ResWriterData resWriterData = null;
					try
					{
						resWriterData = this.m_assemblyData.m_resWriterList[i];
						if (resWriterData.m_resWriter != null)
						{
							new FileIOPermission(FileIOPermissionAccess.Write | FileIOPermissionAccess.Append, resWriterData.m_strFullFileName).Demand();
						}
					}
					finally
					{
						if (resWriterData != null && resWriterData.m_resWriter != null)
						{
							resWriterData.m_resWriter.Close();
						}
					}
					AssemblyBuilder.AddStandAloneResource(this.GetNativeHandle(), resWriterData.m_strName, resWriterData.m_strFileName, resWriterData.m_strFullFileName, (int)resWriterData.m_attribute);
				}
				if (moduleBuilder == null)
				{
					onDiskAssemblyModuleBuilder.DefineNativeResource(portableExecutableKind, imageFileMachine);
					int entryPoint = (this.m_assemblyData.m_entryPointModule != null) ? this.m_assemblyData.m_entryPointModule.m_moduleData.FileToken : 0;
					AssemblyBuilder.SaveManifestToDisk(this.GetNativeHandle(), assemblyFileName, entryPoint, (int)this.m_assemblyData.m_peFileKind, (int)portableExecutableKind, (int)imageFileMachine);
				}
				else
				{
					if (this.m_assemblyData.m_entryPointModule != null && this.m_assemblyData.m_entryPointModule != moduleBuilder)
					{
						moduleBuilder.SetEntryPoint(new MethodToken(this.m_assemblyData.m_entryPointModule.m_moduleData.FileToken));
					}
					moduleBuilder.Save(assemblyFileName, true, portableExecutableKind, imageFileMachine);
				}
				this.m_assemblyData.m_isSaved = true;
			}
			finally
			{
				if (text != null)
				{
					File.Delete(text);
				}
			}
		}

		// Token: 0x06004963 RID: 18787 RVA: 0x00109D08 File Offset: 0x00107F08
		[SecurityCritical]
		private void AddDeclarativeSecurity(PermissionSet pset, SecurityAction action)
		{
			byte[] array = pset.EncodeXml();
			AssemblyBuilder.AddDeclarativeSecurity(this.GetNativeHandle(), action, array, array.Length);
		}

		// Token: 0x06004964 RID: 18788 RVA: 0x00109D2C File Offset: 0x00107F2C
		internal bool IsPersistable()
		{
			return (this.m_assemblyData.m_access & AssemblyBuilderAccess.Save) == AssemblyBuilderAccess.Save;
		}

		// Token: 0x06004965 RID: 18789 RVA: 0x00109D44 File Offset: 0x00107F44
		[SecurityCritical]
		private int DefineNestedComType(Type type, int tkResolutionScope, int tkTypeDef)
		{
			Type declaringType = type.DeclaringType;
			if (declaringType == null)
			{
				return AssemblyBuilder.AddExportedTypeOnDisk(this.GetNativeHandle(), type.FullName, tkResolutionScope, tkTypeDef, type.Attributes);
			}
			tkResolutionScope = this.DefineNestedComType(declaringType, tkResolutionScope, tkTypeDef);
			return AssemblyBuilder.AddExportedTypeOnDisk(this.GetNativeHandle(), type.Name, tkResolutionScope, tkTypeDef, type.Attributes);
		}

		// Token: 0x06004966 RID: 18790 RVA: 0x00109DA0 File Offset: 0x00107FA0
		[SecurityCritical]
		internal int DefineExportedTypeInMemory(Type type, int tkResolutionScope, int tkTypeDef)
		{
			Type declaringType = type.DeclaringType;
			if (declaringType == null)
			{
				return AssemblyBuilder.AddExportedTypeInMemory(this.GetNativeHandle(), type.FullName, tkResolutionScope, tkTypeDef, type.Attributes);
			}
			tkResolutionScope = this.DefineExportedTypeInMemory(declaringType, tkResolutionScope, tkTypeDef);
			return AssemblyBuilder.AddExportedTypeInMemory(this.GetNativeHandle(), type.Name, tkResolutionScope, tkTypeDef, type.Attributes);
		}

		// Token: 0x06004967 RID: 18791 RVA: 0x00109DFB File Offset: 0x00107FFB
		private AssemblyBuilder()
		{
		}

		// Token: 0x06004968 RID: 18792 RVA: 0x00109E03 File Offset: 0x00108003
		void _AssemblyBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004969 RID: 18793 RVA: 0x00109E0A File Offset: 0x0010800A
		void _AssemblyBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600496A RID: 18794 RVA: 0x00109E11 File Offset: 0x00108011
		void _AssemblyBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600496B RID: 18795 RVA: 0x00109E18 File Offset: 0x00108018
		void _AssemblyBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600496C RID: 18796
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void DefineDynamicModule(RuntimeAssembly containingAssembly, bool emitSymbolInfo, string name, string filename, StackCrawlMarkHandle stackMark, ref IntPtr pInternalSymWriter, ObjectHandleOnStack retModule, bool fIsTransient, out int tkFile);

		// Token: 0x0600496D RID: 18797 RVA: 0x00109E20 File Offset: 0x00108020
		[SecurityCritical]
		private static Module DefineDynamicModule(RuntimeAssembly containingAssembly, bool emitSymbolInfo, string name, string filename, ref StackCrawlMark stackMark, ref IntPtr pInternalSymWriter, bool fIsTransient, out int tkFile)
		{
			RuntimeModule result = null;
			AssemblyBuilder.DefineDynamicModule(containingAssembly.GetNativeHandle(), emitSymbolInfo, name, filename, JitHelpers.GetStackCrawlMarkHandle(ref stackMark), ref pInternalSymWriter, JitHelpers.GetObjectHandleOnStack<RuntimeModule>(ref result), fIsTransient, out tkFile);
			return result;
		}

		// Token: 0x0600496E RID: 18798
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void PrepareForSavingManifestToDisk(RuntimeAssembly assembly, RuntimeModule assemblyModule);

		// Token: 0x0600496F RID: 18799
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void SaveManifestToDisk(RuntimeAssembly assembly, string strFileName, int entryPoint, int fileKind, int portableExecutableKind, int ImageFileMachine);

		// Token: 0x06004970 RID: 18800
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int AddFile(RuntimeAssembly assembly, string strFileName);

		// Token: 0x06004971 RID: 18801
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void SetFileHashValue(RuntimeAssembly assembly, int tkFile, string strFullFileName);

		// Token: 0x06004972 RID: 18802
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int AddExportedTypeInMemory(RuntimeAssembly assembly, string strComTypeName, int tkAssemblyRef, int tkTypeDef, TypeAttributes flags);

		// Token: 0x06004973 RID: 18803
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int AddExportedTypeOnDisk(RuntimeAssembly assembly, string strComTypeName, int tkAssemblyRef, int tkTypeDef, TypeAttributes flags);

		// Token: 0x06004974 RID: 18804
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void AddStandAloneResource(RuntimeAssembly assembly, string strName, string strFileName, string strFullFileName, int attribute);

		// Token: 0x06004975 RID: 18805
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void AddDeclarativeSecurity(RuntimeAssembly assembly, SecurityAction action, byte[] blob, int length);

		// Token: 0x06004976 RID: 18806
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void CreateVersionInfoResource(string filename, string title, string iconFilename, string description, string copyright, string trademark, string company, string product, string productVersion, string fileVersion, int lcid, bool isDll, StringHandleOnStack retFileName);

		// Token: 0x04001E42 RID: 7746
		internal AssemblyBuilderData m_assemblyData;

		// Token: 0x04001E43 RID: 7747
		private InternalAssemblyBuilder m_internalAssemblyBuilder;

		// Token: 0x04001E44 RID: 7748
		private ModuleBuilder m_manifestModuleBuilder;

		// Token: 0x04001E45 RID: 7749
		private bool m_fManifestModuleUsedAsDefinedModule;

		// Token: 0x04001E46 RID: 7750
		internal const string MANIFEST_MODULE_NAME = "RefEmit_InMemoryManifestModule";

		// Token: 0x04001E47 RID: 7751
		private ModuleBuilder m_onDiskAssemblyModuleBuilder;

		// Token: 0x04001E48 RID: 7752
		private bool m_profileAPICheck;

		// Token: 0x02000C3B RID: 3131
		private class AssemblyBuilderLock
		{
		}
	}
}
