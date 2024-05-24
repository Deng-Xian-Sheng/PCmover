using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Reflection
{
	// Token: 0x020005D2 RID: 1490
	[Serializable]
	internal sealed class RuntimeConstructorInfo : ConstructorInfo, ISerializable, IRuntimeMethodInfo
	{
		// Token: 0x060044F4 RID: 17652 RVA: 0x000FD2FC File Offset: 0x000FB4FC
		private bool IsNonW8PFrameworkAPI()
		{
			if (this.DeclaringType.IsArray && base.IsPublic && !base.IsStatic)
			{
				return false;
			}
			RuntimeAssembly runtimeAssembly = this.GetRuntimeAssembly();
			if (runtimeAssembly.IsFrameworkAssembly())
			{
				int invocableAttributeCtorToken = runtimeAssembly.InvocableAttributeCtorToken;
				if (System.Reflection.MetadataToken.IsNullToken(invocableAttributeCtorToken) || !CustomAttribute.IsAttributeDefined(this.GetRuntimeModule(), this.MetadataToken, invocableAttributeCtorToken))
				{
					return true;
				}
			}
			return this.GetRuntimeType().IsNonW8PFrameworkAPI();
		}

		// Token: 0x17000A33 RID: 2611
		// (get) Token: 0x060044F5 RID: 17653 RVA: 0x000FD36C File Offset: 0x000FB56C
		internal override bool IsDynamicallyInvokable
		{
			get
			{
				return !AppDomain.ProfileAPICheck || !this.IsNonW8PFrameworkAPI();
			}
		}

		// Token: 0x17000A34 RID: 2612
		// (get) Token: 0x060044F6 RID: 17654 RVA: 0x000FD380 File Offset: 0x000FB580
		internal INVOCATION_FLAGS InvocationFlags
		{
			[SecuritySafeCritical]
			get
			{
				if ((this.m_invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_INITIALIZED) == INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					INVOCATION_FLAGS invocation_FLAGS = INVOCATION_FLAGS.INVOCATION_FLAGS_IS_CTOR;
					Type declaringType = this.DeclaringType;
					if (declaringType == typeof(void) || (declaringType != null && declaringType.ContainsGenericParameters) || (this.CallingConvention & CallingConventions.VarArgs) == CallingConventions.VarArgs || (this.Attributes & MethodAttributes.RequireSecObject) == MethodAttributes.RequireSecObject)
					{
						invocation_FLAGS |= INVOCATION_FLAGS.INVOCATION_FLAGS_NO_INVOKE;
					}
					else if (base.IsStatic || (declaringType != null && declaringType.IsAbstract))
					{
						invocation_FLAGS |= INVOCATION_FLAGS.INVOCATION_FLAGS_NO_CTOR_INVOKE;
					}
					else
					{
						invocation_FLAGS |= RuntimeMethodHandle.GetSecurityFlags(this);
						if ((invocation_FLAGS & INVOCATION_FLAGS.INVOCATION_FLAGS_NEED_SECURITY) == INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN && ((this.Attributes & MethodAttributes.MemberAccessMask) != MethodAttributes.Public || (declaringType != null && declaringType.NeedsReflectionSecurityCheck)))
						{
							invocation_FLAGS |= INVOCATION_FLAGS.INVOCATION_FLAGS_NEED_SECURITY;
						}
						if (typeof(Delegate).IsAssignableFrom(this.DeclaringType))
						{
							invocation_FLAGS |= INVOCATION_FLAGS.INVOCATION_FLAGS_IS_DELEGATE_CTOR;
						}
					}
					if (AppDomain.ProfileAPICheck && this.IsNonW8PFrameworkAPI())
					{
						invocation_FLAGS |= INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API;
					}
					this.m_invocationFlags = (invocation_FLAGS | INVOCATION_FLAGS.INVOCATION_FLAGS_INITIALIZED);
				}
				return this.m_invocationFlags;
			}
		}

		// Token: 0x060044F7 RID: 17655 RVA: 0x000FD47A File Offset: 0x000FB67A
		[SecurityCritical]
		internal RuntimeConstructorInfo(RuntimeMethodHandleInternal handle, RuntimeType declaringType, RuntimeType.RuntimeTypeCache reflectedTypeCache, MethodAttributes methodAttributes, BindingFlags bindingFlags)
		{
			this.m_bindingFlags = bindingFlags;
			this.m_reflectedTypeCache = reflectedTypeCache;
			this.m_declaringType = declaringType;
			this.m_handle = handle.Value;
			this.m_methodAttributes = methodAttributes;
		}

		// Token: 0x17000A35 RID: 2613
		// (get) Token: 0x060044F8 RID: 17656 RVA: 0x000FD4B0 File Offset: 0x000FB6B0
		internal RemotingMethodCachedData RemotingCache
		{
			get
			{
				RemotingMethodCachedData remotingMethodCachedData = this.m_cachedData;
				if (remotingMethodCachedData == null)
				{
					remotingMethodCachedData = new RemotingMethodCachedData(this);
					RemotingMethodCachedData remotingMethodCachedData2 = Interlocked.CompareExchange<RemotingMethodCachedData>(ref this.m_cachedData, remotingMethodCachedData, null);
					if (remotingMethodCachedData2 != null)
					{
						remotingMethodCachedData = remotingMethodCachedData2;
					}
				}
				return remotingMethodCachedData;
			}
		}

		// Token: 0x17000A36 RID: 2614
		// (get) Token: 0x060044F9 RID: 17657 RVA: 0x000FD4E2 File Offset: 0x000FB6E2
		RuntimeMethodHandleInternal IRuntimeMethodInfo.Value
		{
			[SecuritySafeCritical]
			get
			{
				return new RuntimeMethodHandleInternal(this.m_handle);
			}
		}

		// Token: 0x060044FA RID: 17658 RVA: 0x000FD4F0 File Offset: 0x000FB6F0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal override bool CacheEquals(object o)
		{
			RuntimeConstructorInfo runtimeConstructorInfo = o as RuntimeConstructorInfo;
			return runtimeConstructorInfo != null && runtimeConstructorInfo.m_handle == this.m_handle;
		}

		// Token: 0x17000A37 RID: 2615
		// (get) Token: 0x060044FB RID: 17659 RVA: 0x000FD51A File Offset: 0x000FB71A
		private Signature Signature
		{
			get
			{
				if (this.m_signature == null)
				{
					this.m_signature = new Signature(this, this.m_declaringType);
				}
				return this.m_signature;
			}
		}

		// Token: 0x17000A38 RID: 2616
		// (get) Token: 0x060044FC RID: 17660 RVA: 0x000FD544 File Offset: 0x000FB744
		private RuntimeType ReflectedTypeInternal
		{
			get
			{
				return this.m_reflectedTypeCache.GetRuntimeType();
			}
		}

		// Token: 0x060044FD RID: 17661 RVA: 0x000FD554 File Offset: 0x000FB754
		private void CheckConsistency(object target)
		{
			if (target == null && base.IsStatic)
			{
				return;
			}
			if (this.m_declaringType.IsInstanceOfType(target))
			{
				return;
			}
			if (target == null)
			{
				throw new TargetException(Environment.GetResourceString("RFLCT.Targ_StatMethReqTarg"));
			}
			throw new TargetException(Environment.GetResourceString("RFLCT.Targ_ITargMismatch"));
		}

		// Token: 0x17000A39 RID: 2617
		// (get) Token: 0x060044FE RID: 17662 RVA: 0x000FD5A0 File Offset: 0x000FB7A0
		internal BindingFlags BindingFlags
		{
			get
			{
				return this.m_bindingFlags;
			}
		}

		// Token: 0x060044FF RID: 17663 RVA: 0x000FD5A8 File Offset: 0x000FB7A8
		internal RuntimeMethodHandle GetMethodHandle()
		{
			return new RuntimeMethodHandle(this);
		}

		// Token: 0x17000A3A RID: 2618
		// (get) Token: 0x06004500 RID: 17664 RVA: 0x000FD5B0 File Offset: 0x000FB7B0
		internal bool IsOverloaded
		{
			get
			{
				return this.m_reflectedTypeCache.GetConstructorList(RuntimeType.MemberListType.CaseSensitive, this.Name).Length > 1;
			}
		}

		// Token: 0x06004501 RID: 17665 RVA: 0x000FD5C9 File Offset: 0x000FB7C9
		public override string ToString()
		{
			if (this.m_toString == null)
			{
				this.m_toString = "Void " + base.FormatNameAndSig();
			}
			return this.m_toString;
		}

		// Token: 0x06004502 RID: 17666 RVA: 0x000FD5EF File Offset: 0x000FB7EF
		public override object[] GetCustomAttributes(bool inherit)
		{
			return CustomAttribute.GetCustomAttributes(this, typeof(object) as RuntimeType);
		}

		// Token: 0x06004503 RID: 17667 RVA: 0x000FD608 File Offset: 0x000FB808
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			RuntimeType runtimeType = attributeType.UnderlyingSystemType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "attributeType");
			}
			return CustomAttribute.GetCustomAttributes(this, runtimeType);
		}

		// Token: 0x06004504 RID: 17668 RVA: 0x000FD65C File Offset: 0x000FB85C
		[SecuritySafeCritical]
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			RuntimeType runtimeType = attributeType.UnderlyingSystemType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "attributeType");
			}
			return CustomAttribute.IsDefined(this, runtimeType);
		}

		// Token: 0x06004505 RID: 17669 RVA: 0x000FD6AE File Offset: 0x000FB8AE
		public override IList<CustomAttributeData> GetCustomAttributesData()
		{
			return CustomAttributeData.GetCustomAttributesInternal(this);
		}

		// Token: 0x17000A3B RID: 2619
		// (get) Token: 0x06004506 RID: 17670 RVA: 0x000FD6B6 File Offset: 0x000FB8B6
		public override string Name
		{
			[SecuritySafeCritical]
			get
			{
				return RuntimeMethodHandle.GetName(this);
			}
		}

		// Token: 0x17000A3C RID: 2620
		// (get) Token: 0x06004507 RID: 17671 RVA: 0x000FD6BE File Offset: 0x000FB8BE
		[ComVisible(true)]
		public override MemberTypes MemberType
		{
			get
			{
				return MemberTypes.Constructor;
			}
		}

		// Token: 0x17000A3D RID: 2621
		// (get) Token: 0x06004508 RID: 17672 RVA: 0x000FD6C1 File Offset: 0x000FB8C1
		public override Type DeclaringType
		{
			get
			{
				if (!this.m_reflectedTypeCache.IsGlobal)
				{
					return this.m_declaringType;
				}
				return null;
			}
		}

		// Token: 0x17000A3E RID: 2622
		// (get) Token: 0x06004509 RID: 17673 RVA: 0x000FD6DA File Offset: 0x000FB8DA
		public override Type ReflectedType
		{
			get
			{
				if (!this.m_reflectedTypeCache.IsGlobal)
				{
					return this.ReflectedTypeInternal;
				}
				return null;
			}
		}

		// Token: 0x17000A3F RID: 2623
		// (get) Token: 0x0600450A RID: 17674 RVA: 0x000FD6F1 File Offset: 0x000FB8F1
		public override int MetadataToken
		{
			[SecuritySafeCritical]
			get
			{
				return RuntimeMethodHandle.GetMethodDef(this);
			}
		}

		// Token: 0x17000A40 RID: 2624
		// (get) Token: 0x0600450B RID: 17675 RVA: 0x000FD6F9 File Offset: 0x000FB8F9
		public override Module Module
		{
			get
			{
				return this.GetRuntimeModule();
			}
		}

		// Token: 0x0600450C RID: 17676 RVA: 0x000FD701 File Offset: 0x000FB901
		internal RuntimeType GetRuntimeType()
		{
			return this.m_declaringType;
		}

		// Token: 0x0600450D RID: 17677 RVA: 0x000FD70B File Offset: 0x000FB90B
		internal RuntimeModule GetRuntimeModule()
		{
			return RuntimeTypeHandle.GetModule(this.m_declaringType);
		}

		// Token: 0x0600450E RID: 17678 RVA: 0x000FD71A File Offset: 0x000FB91A
		internal RuntimeAssembly GetRuntimeAssembly()
		{
			return this.GetRuntimeModule().GetRuntimeAssembly();
		}

		// Token: 0x0600450F RID: 17679 RVA: 0x000FD727 File Offset: 0x000FB927
		internal override Type GetReturnType()
		{
			return this.Signature.ReturnType;
		}

		// Token: 0x06004510 RID: 17680 RVA: 0x000FD734 File Offset: 0x000FB934
		[SecuritySafeCritical]
		internal override ParameterInfo[] GetParametersNoCopy()
		{
			if (this.m_parameters == null)
			{
				this.m_parameters = RuntimeParameterInfo.GetParameters(this, this, this.Signature);
			}
			return this.m_parameters;
		}

		// Token: 0x06004511 RID: 17681 RVA: 0x000FD758 File Offset: 0x000FB958
		public override ParameterInfo[] GetParameters()
		{
			ParameterInfo[] parametersNoCopy = this.GetParametersNoCopy();
			if (parametersNoCopy.Length == 0)
			{
				return parametersNoCopy;
			}
			ParameterInfo[] array = new ParameterInfo[parametersNoCopy.Length];
			Array.Copy(parametersNoCopy, array, parametersNoCopy.Length);
			return array;
		}

		// Token: 0x06004512 RID: 17682 RVA: 0x000FD786 File Offset: 0x000FB986
		public override MethodImplAttributes GetMethodImplementationFlags()
		{
			return RuntimeMethodHandle.GetImplAttributes(this);
		}

		// Token: 0x17000A41 RID: 2625
		// (get) Token: 0x06004513 RID: 17683 RVA: 0x000FD790 File Offset: 0x000FB990
		public override RuntimeMethodHandle MethodHandle
		{
			get
			{
				Type declaringType = this.DeclaringType;
				if ((declaringType == null && this.Module.Assembly.ReflectionOnly) || declaringType is ReflectionOnlyType)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotAllowedInReflectionOnly"));
				}
				return new RuntimeMethodHandle(this);
			}
		}

		// Token: 0x17000A42 RID: 2626
		// (get) Token: 0x06004514 RID: 17684 RVA: 0x000FD7DD File Offset: 0x000FB9DD
		public override MethodAttributes Attributes
		{
			get
			{
				return this.m_methodAttributes;
			}
		}

		// Token: 0x17000A43 RID: 2627
		// (get) Token: 0x06004515 RID: 17685 RVA: 0x000FD7E5 File Offset: 0x000FB9E5
		public override CallingConventions CallingConvention
		{
			get
			{
				return this.Signature.CallingConvention;
			}
		}

		// Token: 0x06004516 RID: 17686 RVA: 0x000FD7F4 File Offset: 0x000FB9F4
		internal static void CheckCanCreateInstance(Type declaringType, bool isVarArg)
		{
			if (declaringType == null)
			{
				throw new ArgumentNullException("declaringType");
			}
			if (declaringType is ReflectionOnlyType)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Arg_ReflectionOnlyInvoke"));
			}
			if (declaringType.IsInterface)
			{
				throw new MemberAccessException(string.Format(CultureInfo.CurrentUICulture, Environment.GetResourceString("Acc_CreateInterfaceEx"), declaringType));
			}
			if (declaringType.IsAbstract)
			{
				throw new MemberAccessException(string.Format(CultureInfo.CurrentUICulture, Environment.GetResourceString("Acc_CreateAbstEx"), declaringType));
			}
			if (declaringType.GetRootElementType() == typeof(ArgIterator))
			{
				throw new NotSupportedException();
			}
			if (isVarArg)
			{
				throw new NotSupportedException();
			}
			if (declaringType.ContainsGenericParameters)
			{
				throw new MemberAccessException(string.Format(CultureInfo.CurrentUICulture, Environment.GetResourceString("Acc_CreateGenericEx"), declaringType));
			}
			if (declaringType == typeof(void))
			{
				throw new MemberAccessException(Environment.GetResourceString("Access_Void"));
			}
		}

		// Token: 0x06004517 RID: 17687 RVA: 0x000FD8DE File Offset: 0x000FBADE
		internal void ThrowNoInvokeException()
		{
			RuntimeConstructorInfo.CheckCanCreateInstance(this.DeclaringType, (this.CallingConvention & CallingConventions.VarArgs) == CallingConventions.VarArgs);
			if ((this.Attributes & MethodAttributes.Static) == MethodAttributes.Static)
			{
				throw new MemberAccessException(Environment.GetResourceString("Acc_NotClassInit"));
			}
			throw new TargetException();
		}

		// Token: 0x06004518 RID: 17688 RVA: 0x000FD918 File Offset: 0x000FBB18
		[SecuritySafeCritical]
		[DebuggerStepThrough]
		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			INVOCATION_FLAGS invocationFlags = this.InvocationFlags;
			if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NO_INVOKE) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				this.ThrowNoInvokeException();
			}
			this.CheckConsistency(obj);
			if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
				RuntimeAssembly executingAssembly = RuntimeAssembly.GetExecutingAssembly(ref stackCrawlMark);
				if (executingAssembly != null && !executingAssembly.IsSafeForReflection())
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
					{
						base.FullName
					}));
				}
			}
			if (obj != null)
			{
				new SecurityPermission(SecurityPermissionFlag.SkipVerification).Demand();
			}
			if ((invocationFlags & (INVOCATION_FLAGS.INVOCATION_FLAGS_NEED_SECURITY | INVOCATION_FLAGS.INVOCATION_FLAGS_RISKY_METHOD)) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_RISKY_METHOD) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					CodeAccessPermission.Demand(PermissionType.ReflectionMemberAccess);
				}
				if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NEED_SECURITY) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					RuntimeMethodHandle.PerformSecurityCheck(obj, this, this.m_declaringType, (uint)this.m_invocationFlags);
				}
			}
			Signature signature = this.Signature;
			int num = signature.Arguments.Length;
			int num2 = (parameters != null) ? parameters.Length : 0;
			if (num != num2)
			{
				throw new TargetParameterCountException(Environment.GetResourceString("Arg_ParmCnt"));
			}
			if (num2 > 0)
			{
				object[] array = base.CheckArguments(parameters, binder, invokeAttr, culture, signature);
				object result = RuntimeMethodHandle.InvokeMethod(obj, array, signature, false);
				for (int i = 0; i < array.Length; i++)
				{
					parameters[i] = array[i];
				}
				return result;
			}
			return RuntimeMethodHandle.InvokeMethod(obj, null, signature, false);
		}

		// Token: 0x06004519 RID: 17689 RVA: 0x000FDA34 File Offset: 0x000FBC34
		[SecuritySafeCritical]
		[ReflectionPermission(SecurityAction.Demand, Flags = ReflectionPermissionFlag.MemberAccess)]
		public override MethodBody GetMethodBody()
		{
			MethodBody methodBody = RuntimeMethodHandle.GetMethodBody(this, this.ReflectedTypeInternal);
			if (methodBody != null)
			{
				methodBody.m_methodBase = this;
			}
			return methodBody;
		}

		// Token: 0x17000A44 RID: 2628
		// (get) Token: 0x0600451A RID: 17690 RVA: 0x000FDA59 File Offset: 0x000FBC59
		public override bool IsSecurityCritical
		{
			get
			{
				return RuntimeMethodHandle.IsSecurityCritical(this);
			}
		}

		// Token: 0x17000A45 RID: 2629
		// (get) Token: 0x0600451B RID: 17691 RVA: 0x000FDA61 File Offset: 0x000FBC61
		public override bool IsSecuritySafeCritical
		{
			get
			{
				return RuntimeMethodHandle.IsSecuritySafeCritical(this);
			}
		}

		// Token: 0x17000A46 RID: 2630
		// (get) Token: 0x0600451C RID: 17692 RVA: 0x000FDA69 File Offset: 0x000FBC69
		public override bool IsSecurityTransparent
		{
			get
			{
				return RuntimeMethodHandle.IsSecurityTransparent(this);
			}
		}

		// Token: 0x17000A47 RID: 2631
		// (get) Token: 0x0600451D RID: 17693 RVA: 0x000FDA71 File Offset: 0x000FBC71
		public override bool ContainsGenericParameters
		{
			get
			{
				return this.DeclaringType != null && this.DeclaringType.ContainsGenericParameters;
			}
		}

		// Token: 0x0600451E RID: 17694 RVA: 0x000FDA90 File Offset: 0x000FBC90
		[SecuritySafeCritical]
		[DebuggerStepThrough]
		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			INVOCATION_FLAGS invocationFlags = this.InvocationFlags;
			RuntimeTypeHandle typeHandle = this.m_declaringType.TypeHandle;
			if ((invocationFlags & (INVOCATION_FLAGS.INVOCATION_FLAGS_NO_INVOKE | INVOCATION_FLAGS.INVOCATION_FLAGS_NO_CTOR_INVOKE | INVOCATION_FLAGS.INVOCATION_FLAGS_CONTAINS_STACK_POINTERS)) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				this.ThrowNoInvokeException();
			}
			if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
				RuntimeAssembly executingAssembly = RuntimeAssembly.GetExecutingAssembly(ref stackCrawlMark);
				if (executingAssembly != null && !executingAssembly.IsSafeForReflection())
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
					{
						base.FullName
					}));
				}
			}
			if ((invocationFlags & (INVOCATION_FLAGS.INVOCATION_FLAGS_NEED_SECURITY | INVOCATION_FLAGS.INVOCATION_FLAGS_RISKY_METHOD | INVOCATION_FLAGS.INVOCATION_FLAGS_IS_DELEGATE_CTOR)) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_RISKY_METHOD) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					CodeAccessPermission.Demand(PermissionType.ReflectionMemberAccess);
				}
				if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NEED_SECURITY) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					RuntimeMethodHandle.PerformSecurityCheck(null, this, this.m_declaringType, (uint)(this.m_invocationFlags | INVOCATION_FLAGS.INVOCATION_FLAGS_CONSTRUCTOR_INVOKE));
				}
				if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_IS_DELEGATE_CTOR) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
				}
			}
			Signature signature = this.Signature;
			int num = signature.Arguments.Length;
			int num2 = (parameters != null) ? parameters.Length : 0;
			if (num != num2)
			{
				throw new TargetParameterCountException(Environment.GetResourceString("Arg_ParmCnt"));
			}
			if (num2 > 0)
			{
				object[] array = base.CheckArguments(parameters, binder, invokeAttr, culture, signature);
				object result = RuntimeMethodHandle.InvokeMethod(null, array, signature, true);
				for (int i = 0; i < array.Length; i++)
				{
					parameters[i] = array[i];
				}
				return result;
			}
			return RuntimeMethodHandle.InvokeMethod(null, null, signature, true);
		}

		// Token: 0x0600451F RID: 17695 RVA: 0x000FDBC5 File Offset: 0x000FBDC5
		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			MemberInfoSerializationHolder.GetSerializationInfo(info, this.Name, this.ReflectedTypeInternal, this.ToString(), this.SerializationToString(), MemberTypes.Constructor, null);
		}

		// Token: 0x06004520 RID: 17696 RVA: 0x000FDBF5 File Offset: 0x000FBDF5
		internal string SerializationToString()
		{
			return this.FormatNameAndSig(true);
		}

		// Token: 0x06004521 RID: 17697 RVA: 0x000FDBFE File Offset: 0x000FBDFE
		internal void SerializationInvoke(object target, SerializationInfo info, StreamingContext context)
		{
			RuntimeMethodHandle.SerializationInvoke(this, target, info, ref context);
		}

		// Token: 0x04001C45 RID: 7237
		private volatile RuntimeType m_declaringType;

		// Token: 0x04001C46 RID: 7238
		private RuntimeType.RuntimeTypeCache m_reflectedTypeCache;

		// Token: 0x04001C47 RID: 7239
		private string m_toString;

		// Token: 0x04001C48 RID: 7240
		private ParameterInfo[] m_parameters;

		// Token: 0x04001C49 RID: 7241
		private object _empty1;

		// Token: 0x04001C4A RID: 7242
		private object _empty2;

		// Token: 0x04001C4B RID: 7243
		private object _empty3;

		// Token: 0x04001C4C RID: 7244
		private IntPtr m_handle;

		// Token: 0x04001C4D RID: 7245
		private MethodAttributes m_methodAttributes;

		// Token: 0x04001C4E RID: 7246
		private BindingFlags m_bindingFlags;

		// Token: 0x04001C4F RID: 7247
		private volatile Signature m_signature;

		// Token: 0x04001C50 RID: 7248
		private INVOCATION_FLAGS m_invocationFlags;

		// Token: 0x04001C51 RID: 7249
		private RemotingMethodCachedData m_cachedData;
	}
}
