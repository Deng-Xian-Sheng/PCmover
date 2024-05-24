using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Threading;

namespace System.Reflection
{
	// Token: 0x020005B0 RID: 1456
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_Assembly))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
	[Serializable]
	public abstract class Assembly : _Assembly, IEvidenceFactory, ICustomAttributeProvider, ISerializable
	{
		// Token: 0x0600436E RID: 17262 RVA: 0x000FA709 File Offset: 0x000F8909
		public static string CreateQualifiedName(string assemblyName, string typeName)
		{
			return typeName + ", " + assemblyName;
		}

		// Token: 0x0600436F RID: 17263 RVA: 0x000FA718 File Offset: 0x000F8918
		public static Assembly GetAssembly(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			Module module = type.Module;
			if (module == null)
			{
				return null;
			}
			return module.Assembly;
		}

		// Token: 0x06004370 RID: 17264 RVA: 0x000FA751 File Offset: 0x000F8951
		[__DynamicallyInvokable]
		public static bool operator ==(Assembly left, Assembly right)
		{
			return left == right || (left != null && right != null && !(left is RuntimeAssembly) && !(right is RuntimeAssembly) && left.Equals(right));
		}

		// Token: 0x06004371 RID: 17265 RVA: 0x000FA778 File Offset: 0x000F8978
		[__DynamicallyInvokable]
		public static bool operator !=(Assembly left, Assembly right)
		{
			return !(left == right);
		}

		// Token: 0x06004372 RID: 17266 RVA: 0x000FA784 File Offset: 0x000F8984
		[__DynamicallyInvokable]
		public override bool Equals(object o)
		{
			return base.Equals(o);
		}

		// Token: 0x06004373 RID: 17267 RVA: 0x000FA78D File Offset: 0x000F898D
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x06004374 RID: 17268 RVA: 0x000FA798 File Offset: 0x000F8998
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly LoadFrom(string assemblyFile)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadFrom(assemblyFile, null, null, AssemblyHashAlgorithm.None, false, false, ref stackCrawlMark);
		}

		// Token: 0x06004375 RID: 17269 RVA: 0x000FA7B4 File Offset: 0x000F89B4
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly ReflectionOnlyLoadFrom(string assemblyFile)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadFrom(assemblyFile, null, null, AssemblyHashAlgorithm.None, true, false, ref stackCrawlMark);
		}

		// Token: 0x06004376 RID: 17270 RVA: 0x000FA7D0 File Offset: 0x000F89D0
		[SecuritySafeCritical]
		[Obsolete("This method is obsolete and will be removed in a future release of the .NET Framework. Please use an overload of LoadFrom which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly LoadFrom(string assemblyFile, Evidence securityEvidence)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadFrom(assemblyFile, securityEvidence, null, AssemblyHashAlgorithm.None, false, false, ref stackCrawlMark);
		}

		// Token: 0x06004377 RID: 17271 RVA: 0x000FA7EC File Offset: 0x000F89EC
		[SecuritySafeCritical]
		[Obsolete("This method is obsolete and will be removed in a future release of the .NET Framework. Please use an overload of LoadFrom which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly LoadFrom(string assemblyFile, Evidence securityEvidence, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadFrom(assemblyFile, securityEvidence, hashValue, hashAlgorithm, false, false, ref stackCrawlMark);
		}

		// Token: 0x06004378 RID: 17272 RVA: 0x000FA808 File Offset: 0x000F8A08
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly LoadFrom(string assemblyFile, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadFrom(assemblyFile, null, hashValue, hashAlgorithm, false, false, ref stackCrawlMark);
		}

		// Token: 0x06004379 RID: 17273 RVA: 0x000FA824 File Offset: 0x000F8A24
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly UnsafeLoadFrom(string assemblyFile)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadFrom(assemblyFile, null, null, AssemblyHashAlgorithm.None, false, true, ref stackCrawlMark);
		}

		// Token: 0x0600437A RID: 17274 RVA: 0x000FA840 File Offset: 0x000F8A40
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(string assemblyString)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoad(assemblyString, null, ref stackCrawlMark, false);
		}

		// Token: 0x0600437B RID: 17275 RVA: 0x000FA85C File Offset: 0x000F8A5C
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type GetType_Compat(string assemblyString, string typeName)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			RuntimeAssembly runtimeAssembly;
			AssemblyName assemblyName = RuntimeAssembly.CreateAssemblyName(assemblyString, false, out runtimeAssembly);
			if (runtimeAssembly == null)
			{
				if (assemblyName.ContentType == AssemblyContentType.WindowsRuntime)
				{
					return Type.GetType(typeName + ", " + assemblyString, true, false);
				}
				runtimeAssembly = RuntimeAssembly.InternalLoadAssemblyName(assemblyName, null, null, ref stackCrawlMark, true, false, false);
			}
			return runtimeAssembly.GetType(typeName, true, false);
		}

		// Token: 0x0600437C RID: 17276 RVA: 0x000FA8B4 File Offset: 0x000F8AB4
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly ReflectionOnlyLoad(string assemblyString)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoad(assemblyString, null, ref stackCrawlMark, true);
		}

		// Token: 0x0600437D RID: 17277 RVA: 0x000FA8D0 File Offset: 0x000F8AD0
		[SecuritySafeCritical]
		[Obsolete("This method is obsolete and will be removed in a future release of the .NET Framework. Please use an overload of Load which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(string assemblyString, Evidence assemblySecurity)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoad(assemblyString, assemblySecurity, ref stackCrawlMark, false);
		}

		// Token: 0x0600437E RID: 17278 RVA: 0x000FA8EC File Offset: 0x000F8AEC
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(AssemblyName assemblyRef)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadAssemblyName(assemblyRef, null, null, ref stackCrawlMark, true, false, false);
		}

		// Token: 0x0600437F RID: 17279 RVA: 0x000FA908 File Offset: 0x000F8B08
		[SecuritySafeCritical]
		[Obsolete("This method is obsolete and will be removed in a future release of the .NET Framework. Please use an overload of Load which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(AssemblyName assemblyRef, Evidence assemblySecurity)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadAssemblyName(assemblyRef, assemblySecurity, null, ref stackCrawlMark, true, false, false);
		}

		// Token: 0x06004380 RID: 17280 RVA: 0x000FA924 File Offset: 0x000F8B24
		[SecuritySafeCritical]
		[Obsolete("This method has been deprecated. Please use Assembly.Load() instead. http://go.microsoft.com/fwlink/?linkid=14202")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly LoadWithPartialName(string partialName)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.LoadWithPartialNameInternal(partialName, null, ref stackCrawlMark);
		}

		// Token: 0x06004381 RID: 17281 RVA: 0x000FA93C File Offset: 0x000F8B3C
		[SecuritySafeCritical]
		[Obsolete("This method has been deprecated. Please use Assembly.Load() instead. http://go.microsoft.com/fwlink/?linkid=14202")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly LoadWithPartialName(string partialName, Evidence securityEvidence)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.LoadWithPartialNameInternal(partialName, securityEvidence, ref stackCrawlMark);
		}

		// Token: 0x06004382 RID: 17282 RVA: 0x000FA954 File Offset: 0x000F8B54
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(byte[] rawAssembly)
		{
			AppDomain.CheckLoadByteArraySupported();
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.nLoadImage(rawAssembly, null, null, ref stackCrawlMark, false, false, SecurityContextSource.CurrentAssembly);
		}

		// Token: 0x06004383 RID: 17283 RVA: 0x000FA978 File Offset: 0x000F8B78
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly ReflectionOnlyLoad(byte[] rawAssembly)
		{
			AppDomain.CheckReflectionOnlyLoadSupported();
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.nLoadImage(rawAssembly, null, null, ref stackCrawlMark, true, false, SecurityContextSource.CurrentAssembly);
		}

		// Token: 0x06004384 RID: 17284 RVA: 0x000FA99C File Offset: 0x000F8B9C
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(byte[] rawAssembly, byte[] rawSymbolStore)
		{
			AppDomain.CheckLoadByteArraySupported();
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.nLoadImage(rawAssembly, rawSymbolStore, null, ref stackCrawlMark, false, false, SecurityContextSource.CurrentAssembly);
		}

		// Token: 0x06004385 RID: 17285 RVA: 0x000FA9C0 File Offset: 0x000F8BC0
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(byte[] rawAssembly, byte[] rawSymbolStore, SecurityContextSource securityContextSource)
		{
			AppDomain.CheckLoadByteArraySupported();
			if (securityContextSource < SecurityContextSource.CurrentAppDomain || securityContextSource > SecurityContextSource.CurrentAssembly)
			{
				throw new ArgumentOutOfRangeException("securityContextSource");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.nLoadImage(rawAssembly, rawSymbolStore, null, ref stackCrawlMark, false, false, securityContextSource);
		}

		// Token: 0x06004386 RID: 17286 RVA: 0x000FA9F4 File Offset: 0x000F8BF4
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Assembly LoadImageSkipIntegrityCheck(byte[] rawAssembly, byte[] rawSymbolStore, SecurityContextSource securityContextSource)
		{
			AppDomain.CheckLoadByteArraySupported();
			if (securityContextSource < SecurityContextSource.CurrentAppDomain || securityContextSource > SecurityContextSource.CurrentAssembly)
			{
				throw new ArgumentOutOfRangeException("securityContextSource");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.nLoadImage(rawAssembly, rawSymbolStore, null, ref stackCrawlMark, false, true, securityContextSource);
		}

		// Token: 0x06004387 RID: 17287 RVA: 0x000FAA28 File Offset: 0x000F8C28
		[SecuritySafeCritical]
		[Obsolete("This method is obsolete and will be removed in a future release of the .NET Framework. Please use an overload of Load which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlEvidence)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(byte[] rawAssembly, byte[] rawSymbolStore, Evidence securityEvidence)
		{
			AppDomain.CheckLoadByteArraySupported();
			if (securityEvidence != null && !AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled)
			{
				Zone hostEvidence = securityEvidence.GetHostEvidence<Zone>();
				if (hostEvidence == null || hostEvidence.SecurityZone != SecurityZone.MyComputer)
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_RequiresCasPolicyImplicit"));
				}
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.nLoadImage(rawAssembly, rawSymbolStore, securityEvidence, ref stackCrawlMark, false, false, SecurityContextSource.CurrentAssembly);
		}

		// Token: 0x06004388 RID: 17288 RVA: 0x000FAA7A File Offset: 0x000F8C7A
		[SecuritySafeCritical]
		public static Assembly LoadFile(string path)
		{
			AppDomain.CheckLoadFileSupported();
			new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.PathDiscovery, path).Demand();
			return RuntimeAssembly.nLoadFile(path, null);
		}

		// Token: 0x06004389 RID: 17289 RVA: 0x000FAA95 File Offset: 0x000F8C95
		[SecuritySafeCritical]
		[Obsolete("This method is obsolete and will be removed in a future release of the .NET Framework. Please use an overload of LoadFile which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlEvidence)]
		public static Assembly LoadFile(string path, Evidence securityEvidence)
		{
			AppDomain.CheckLoadFileSupported();
			if (securityEvidence != null && !AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_RequiresCasPolicyImplicit"));
			}
			new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.PathDiscovery, path).Demand();
			return RuntimeAssembly.nLoadFile(path, securityEvidence);
		}

		// Token: 0x0600438A RID: 17290 RVA: 0x000FAAD0 File Offset: 0x000F8CD0
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly GetExecutingAssembly()
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.GetExecutingAssembly(ref stackCrawlMark);
		}

		// Token: 0x0600438B RID: 17291 RVA: 0x000FAAE8 File Offset: 0x000F8CE8
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly GetCallingAssembly()
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCallersCaller;
			return RuntimeAssembly.GetExecutingAssembly(ref stackCrawlMark);
		}

		// Token: 0x0600438C RID: 17292 RVA: 0x000FAB00 File Offset: 0x000F8D00
		[SecuritySafeCritical]
		public static Assembly GetEntryAssembly()
		{
			AppDomainManager appDomainManager = AppDomain.CurrentDomain.DomainManager;
			if (appDomainManager == null)
			{
				appDomainManager = new AppDomainManager();
			}
			return appDomainManager.EntryAssembly;
		}

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x0600438D RID: 17293 RVA: 0x000FAB27 File Offset: 0x000F8D27
		// (remove) Token: 0x0600438E RID: 17294 RVA: 0x000FAB2E File Offset: 0x000F8D2E
		public virtual event ModuleResolveEventHandler ModuleResolve
		{
			[SecurityCritical]
			add
			{
				throw new NotImplementedException();
			}
			[SecurityCritical]
			remove
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170009E9 RID: 2537
		// (get) Token: 0x0600438F RID: 17295 RVA: 0x000FAB35 File Offset: 0x000F8D35
		public virtual string CodeBase
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170009EA RID: 2538
		// (get) Token: 0x06004390 RID: 17296 RVA: 0x000FAB3C File Offset: 0x000F8D3C
		public virtual string EscapedCodeBase
		{
			[SecuritySafeCritical]
			get
			{
				return AssemblyName.EscapeCodeBase(this.CodeBase);
			}
		}

		// Token: 0x06004391 RID: 17297 RVA: 0x000FAB49 File Offset: 0x000F8D49
		[__DynamicallyInvokable]
		public virtual AssemblyName GetName()
		{
			return this.GetName(false);
		}

		// Token: 0x06004392 RID: 17298 RVA: 0x000FAB52 File Offset: 0x000F8D52
		public virtual AssemblyName GetName(bool copiedName)
		{
			throw new NotImplementedException();
		}

		// Token: 0x170009EB RID: 2539
		// (get) Token: 0x06004393 RID: 17299 RVA: 0x000FAB59 File Offset: 0x000F8D59
		[__DynamicallyInvokable]
		public virtual string FullName
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170009EC RID: 2540
		// (get) Token: 0x06004394 RID: 17300 RVA: 0x000FAB60 File Offset: 0x000F8D60
		[__DynamicallyInvokable]
		public virtual MethodInfo EntryPoint
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06004395 RID: 17301 RVA: 0x000FAB67 File Offset: 0x000F8D67
		Type _Assembly.GetType()
		{
			return base.GetType();
		}

		// Token: 0x06004396 RID: 17302 RVA: 0x000FAB6F File Offset: 0x000F8D6F
		[__DynamicallyInvokable]
		public virtual Type GetType(string name)
		{
			return this.GetType(name, false, false);
		}

		// Token: 0x06004397 RID: 17303 RVA: 0x000FAB7A File Offset: 0x000F8D7A
		[__DynamicallyInvokable]
		public virtual Type GetType(string name, bool throwOnError)
		{
			return this.GetType(name, throwOnError, false);
		}

		// Token: 0x06004398 RID: 17304 RVA: 0x000FAB85 File Offset: 0x000F8D85
		[__DynamicallyInvokable]
		public virtual Type GetType(string name, bool throwOnError, bool ignoreCase)
		{
			throw new NotImplementedException();
		}

		// Token: 0x170009ED RID: 2541
		// (get) Token: 0x06004399 RID: 17305 RVA: 0x000FAB8C File Offset: 0x000F8D8C
		[__DynamicallyInvokable]
		public virtual IEnumerable<Type> ExportedTypes
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetExportedTypes();
			}
		}

		// Token: 0x0600439A RID: 17306 RVA: 0x000FAB94 File Offset: 0x000F8D94
		[__DynamicallyInvokable]
		public virtual Type[] GetExportedTypes()
		{
			throw new NotImplementedException();
		}

		// Token: 0x170009EE RID: 2542
		// (get) Token: 0x0600439B RID: 17307 RVA: 0x000FAB9C File Offset: 0x000F8D9C
		[__DynamicallyInvokable]
		public virtual IEnumerable<TypeInfo> DefinedTypes
		{
			[__DynamicallyInvokable]
			get
			{
				Type[] types = this.GetTypes();
				TypeInfo[] array = new TypeInfo[types.Length];
				for (int i = 0; i < types.Length; i++)
				{
					TypeInfo typeInfo = types[i].GetTypeInfo();
					if (typeInfo == null)
					{
						throw new NotSupportedException(Environment.GetResourceString("NotSupported_NoTypeInfo", new object[]
						{
							types[i].FullName
						}));
					}
					array[i] = typeInfo;
				}
				return array;
			}
		}

		// Token: 0x0600439C RID: 17308 RVA: 0x000FAC00 File Offset: 0x000F8E00
		[__DynamicallyInvokable]
		public virtual Type[] GetTypes()
		{
			Module[] modules = this.GetModules(false);
			int num = modules.Length;
			int num2 = 0;
			Type[][] array = new Type[num][];
			for (int i = 0; i < num; i++)
			{
				array[i] = modules[i].GetTypes();
				num2 += array[i].Length;
			}
			int num3 = 0;
			Type[] array2 = new Type[num2];
			for (int j = 0; j < num; j++)
			{
				int num4 = array[j].Length;
				Array.Copy(array[j], 0, array2, num3, num4);
				num3 += num4;
			}
			return array2;
		}

		// Token: 0x0600439D RID: 17309 RVA: 0x000FAC84 File Offset: 0x000F8E84
		[__DynamicallyInvokable]
		public virtual Stream GetManifestResourceStream(Type type, string name)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600439E RID: 17310 RVA: 0x000FAC8B File Offset: 0x000F8E8B
		[__DynamicallyInvokable]
		public virtual Stream GetManifestResourceStream(string name)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600439F RID: 17311 RVA: 0x000FAC92 File Offset: 0x000F8E92
		public virtual Assembly GetSatelliteAssembly(CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060043A0 RID: 17312 RVA: 0x000FAC99 File Offset: 0x000F8E99
		public virtual Assembly GetSatelliteAssembly(CultureInfo culture, Version version)
		{
			throw new NotImplementedException();
		}

		// Token: 0x170009EF RID: 2543
		// (get) Token: 0x060043A1 RID: 17313 RVA: 0x000FACA0 File Offset: 0x000F8EA0
		public virtual Evidence Evidence
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170009F0 RID: 2544
		// (get) Token: 0x060043A2 RID: 17314 RVA: 0x000FACA7 File Offset: 0x000F8EA7
		public virtual PermissionSet PermissionSet
		{
			[SecurityCritical]
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170009F1 RID: 2545
		// (get) Token: 0x060043A3 RID: 17315 RVA: 0x000FACAE File Offset: 0x000F8EAE
		public bool IsFullyTrusted
		{
			[SecuritySafeCritical]
			get
			{
				return this.PermissionSet.IsUnrestricted();
			}
		}

		// Token: 0x170009F2 RID: 2546
		// (get) Token: 0x060043A4 RID: 17316 RVA: 0x000FACBB File Offset: 0x000F8EBB
		public virtual SecurityRuleSet SecurityRuleSet
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060043A5 RID: 17317 RVA: 0x000FACC2 File Offset: 0x000F8EC2
		[SecurityCritical]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new NotImplementedException();
		}

		// Token: 0x170009F3 RID: 2547
		// (get) Token: 0x060043A6 RID: 17318 RVA: 0x000FACCC File Offset: 0x000F8ECC
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public virtual Module ManifestModule
		{
			[__DynamicallyInvokable]
			get
			{
				RuntimeAssembly runtimeAssembly = this as RuntimeAssembly;
				if (runtimeAssembly != null)
				{
					return runtimeAssembly.ManifestModule;
				}
				throw new NotImplementedException();
			}
		}

		// Token: 0x170009F4 RID: 2548
		// (get) Token: 0x060043A7 RID: 17319 RVA: 0x000FACF5 File Offset: 0x000F8EF5
		[__DynamicallyInvokable]
		public virtual IEnumerable<CustomAttributeData> CustomAttributes
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetCustomAttributesData();
			}
		}

		// Token: 0x060043A8 RID: 17320 RVA: 0x000FACFD File Offset: 0x000F8EFD
		[__DynamicallyInvokable]
		public virtual object[] GetCustomAttributes(bool inherit)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060043A9 RID: 17321 RVA: 0x000FAD04 File Offset: 0x000F8F04
		[__DynamicallyInvokable]
		public virtual object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060043AA RID: 17322 RVA: 0x000FAD0B File Offset: 0x000F8F0B
		[__DynamicallyInvokable]
		public virtual bool IsDefined(Type attributeType, bool inherit)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060043AB RID: 17323 RVA: 0x000FAD12 File Offset: 0x000F8F12
		public virtual IList<CustomAttributeData> GetCustomAttributesData()
		{
			throw new NotImplementedException();
		}

		// Token: 0x170009F5 RID: 2549
		// (get) Token: 0x060043AC RID: 17324 RVA: 0x000FAD19 File Offset: 0x000F8F19
		[ComVisible(false)]
		public virtual bool ReflectionOnly
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060043AD RID: 17325 RVA: 0x000FAD20 File Offset: 0x000F8F20
		public Module LoadModule(string moduleName, byte[] rawModule)
		{
			return this.LoadModule(moduleName, rawModule, null);
		}

		// Token: 0x060043AE RID: 17326 RVA: 0x000FAD2B File Offset: 0x000F8F2B
		public virtual Module LoadModule(string moduleName, byte[] rawModule, byte[] rawSymbolStore)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060043AF RID: 17327 RVA: 0x000FAD32 File Offset: 0x000F8F32
		public object CreateInstance(string typeName)
		{
			return this.CreateInstance(typeName, false, BindingFlags.Instance | BindingFlags.Public, null, null, null, null);
		}

		// Token: 0x060043B0 RID: 17328 RVA: 0x000FAD42 File Offset: 0x000F8F42
		public object CreateInstance(string typeName, bool ignoreCase)
		{
			return this.CreateInstance(typeName, ignoreCase, BindingFlags.Instance | BindingFlags.Public, null, null, null, null);
		}

		// Token: 0x060043B1 RID: 17329 RVA: 0x000FAD54 File Offset: 0x000F8F54
		public virtual object CreateInstance(string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
		{
			Type type = this.GetType(typeName, false, ignoreCase);
			if (type == null)
			{
				return null;
			}
			return Activator.CreateInstance(type, bindingAttr, binder, args, culture, activationAttributes);
		}

		// Token: 0x170009F6 RID: 2550
		// (get) Token: 0x060043B2 RID: 17330 RVA: 0x000FAD85 File Offset: 0x000F8F85
		[__DynamicallyInvokable]
		public virtual IEnumerable<Module> Modules
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetLoadedModules(true);
			}
		}

		// Token: 0x060043B3 RID: 17331 RVA: 0x000FAD8E File Offset: 0x000F8F8E
		public Module[] GetLoadedModules()
		{
			return this.GetLoadedModules(false);
		}

		// Token: 0x060043B4 RID: 17332 RVA: 0x000FAD97 File Offset: 0x000F8F97
		public virtual Module[] GetLoadedModules(bool getResourceModules)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060043B5 RID: 17333 RVA: 0x000FAD9E File Offset: 0x000F8F9E
		[__DynamicallyInvokable]
		public Module[] GetModules()
		{
			return this.GetModules(false);
		}

		// Token: 0x060043B6 RID: 17334 RVA: 0x000FADA7 File Offset: 0x000F8FA7
		public virtual Module[] GetModules(bool getResourceModules)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060043B7 RID: 17335 RVA: 0x000FADAE File Offset: 0x000F8FAE
		public virtual Module GetModule(string name)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060043B8 RID: 17336 RVA: 0x000FADB5 File Offset: 0x000F8FB5
		public virtual FileStream GetFile(string name)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060043B9 RID: 17337 RVA: 0x000FADBC File Offset: 0x000F8FBC
		public virtual FileStream[] GetFiles()
		{
			return this.GetFiles(false);
		}

		// Token: 0x060043BA RID: 17338 RVA: 0x000FADC5 File Offset: 0x000F8FC5
		public virtual FileStream[] GetFiles(bool getResourceModules)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060043BB RID: 17339 RVA: 0x000FADCC File Offset: 0x000F8FCC
		[__DynamicallyInvokable]
		public virtual string[] GetManifestResourceNames()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060043BC RID: 17340 RVA: 0x000FADD3 File Offset: 0x000F8FD3
		public virtual AssemblyName[] GetReferencedAssemblies()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060043BD RID: 17341 RVA: 0x000FADDA File Offset: 0x000F8FDA
		[__DynamicallyInvokable]
		public virtual ManifestResourceInfo GetManifestResourceInfo(string resourceName)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060043BE RID: 17342 RVA: 0x000FADE4 File Offset: 0x000F8FE4
		[__DynamicallyInvokable]
		public override string ToString()
		{
			string fullName = this.FullName;
			if (fullName == null)
			{
				return base.ToString();
			}
			return fullName;
		}

		// Token: 0x170009F7 RID: 2551
		// (get) Token: 0x060043BF RID: 17343 RVA: 0x000FAE03 File Offset: 0x000F9003
		public virtual string Location
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170009F8 RID: 2552
		// (get) Token: 0x060043C0 RID: 17344 RVA: 0x000FAE0A File Offset: 0x000F900A
		[ComVisible(false)]
		public virtual string ImageRuntimeVersion
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170009F9 RID: 2553
		// (get) Token: 0x060043C1 RID: 17345 RVA: 0x000FAE11 File Offset: 0x000F9011
		public virtual bool GlobalAssemblyCache
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170009FA RID: 2554
		// (get) Token: 0x060043C2 RID: 17346 RVA: 0x000FAE18 File Offset: 0x000F9018
		[ComVisible(false)]
		public virtual long HostContext
		{
			get
			{
				RuntimeAssembly runtimeAssembly = this as RuntimeAssembly;
				if (runtimeAssembly != null)
				{
					return runtimeAssembly.HostContext;
				}
				throw new NotImplementedException();
			}
		}

		// Token: 0x170009FB RID: 2555
		// (get) Token: 0x060043C3 RID: 17347 RVA: 0x000FAE41 File Offset: 0x000F9041
		[__DynamicallyInvokable]
		public virtual bool IsDynamic
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}
	}
}
