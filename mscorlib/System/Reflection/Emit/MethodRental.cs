using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Reflection.Emit
{
	// Token: 0x0200064D RID: 1613
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_MethodRental))]
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public sealed class MethodRental : _MethodRental
	{
		// Token: 0x06004BF4 RID: 19444 RVA: 0x00112F5C File Offset: 0x0011115C
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void SwapMethodBody(Type cls, int methodtoken, IntPtr rgIL, int methodSize, int flags)
		{
			if (methodSize <= 0 || methodSize >= 4128768)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadSizeForData"), "methodSize");
			}
			if (cls == null)
			{
				throw new ArgumentNullException("cls");
			}
			Module module = cls.Module;
			ModuleBuilder moduleBuilder = module as ModuleBuilder;
			InternalModuleBuilder internalModuleBuilder;
			if (moduleBuilder != null)
			{
				internalModuleBuilder = moduleBuilder.InternalModule;
			}
			else
			{
				internalModuleBuilder = (module as InternalModuleBuilder);
			}
			if (internalModuleBuilder == null)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_NotDynamicModule"));
			}
			RuntimeType runtimeType;
			if (cls is TypeBuilder)
			{
				TypeBuilder typeBuilder = (TypeBuilder)cls;
				if (!typeBuilder.IsCreated())
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_NotAllTypesAreBaked", new object[]
					{
						typeBuilder.Name
					}));
				}
				runtimeType = typeBuilder.BakedRuntimeType;
			}
			else
			{
				runtimeType = (cls as RuntimeType);
			}
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"), "cls");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			RuntimeAssembly runtimeAssembly = internalModuleBuilder.GetRuntimeAssembly();
			object syncRoot = runtimeAssembly.SyncRoot;
			lock (syncRoot)
			{
				MethodRental.SwapMethodBody(runtimeType.GetTypeHandleInternal(), methodtoken, rgIL, methodSize, flags, JitHelpers.GetStackCrawlMarkHandle(ref stackCrawlMark));
			}
		}

		// Token: 0x06004BF5 RID: 19445
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void SwapMethodBody(RuntimeTypeHandle cls, int methodtoken, IntPtr rgIL, int methodSize, int flags, StackCrawlMarkHandle stackMark);

		// Token: 0x06004BF6 RID: 19446 RVA: 0x0011309C File Offset: 0x0011129C
		private MethodRental()
		{
		}

		// Token: 0x06004BF7 RID: 19447 RVA: 0x001130A4 File Offset: 0x001112A4
		void _MethodRental.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004BF8 RID: 19448 RVA: 0x001130AB File Offset: 0x001112AB
		void _MethodRental.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004BF9 RID: 19449 RVA: 0x001130B2 File Offset: 0x001112B2
		void _MethodRental.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004BFA RID: 19450 RVA: 0x001130B9 File Offset: 0x001112B9
		void _MethodRental.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04001F4A RID: 8010
		public const int JitOnDemand = 0;

		// Token: 0x04001F4B RID: 8011
		public const int JitImmediate = 1;
	}
}
