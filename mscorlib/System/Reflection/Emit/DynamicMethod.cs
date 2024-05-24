using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Reflection.Emit
{
	// Token: 0x02000637 RID: 1591
	[ComVisible(true)]
	public sealed class DynamicMethod : MethodInfo
	{
		// Token: 0x06004A2C RID: 18988 RVA: 0x0010C655 File Offset: 0x0010A855
		private DynamicMethod()
		{
		}

		// Token: 0x06004A2D RID: 18989 RVA: 0x0010C660 File Offset: 0x0010A860
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, Type returnType, Type[] parameterTypes)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.Init(name, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, null, null, false, true, ref stackCrawlMark);
		}

		// Token: 0x06004A2E RID: 18990 RVA: 0x0010C688 File Offset: 0x0010A888
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, Type returnType, Type[] parameterTypes, bool restrictedSkipVisibility)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.Init(name, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, null, null, restrictedSkipVisibility, true, ref stackCrawlMark);
		}

		// Token: 0x06004A2F RID: 18991 RVA: 0x0010C6B0 File Offset: 0x0010A8B0
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, Type returnType, Type[] parameterTypes, Module m)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.PerformSecurityCheck(m, ref stackCrawlMark, false);
			this.Init(name, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, null, m, false, false, ref stackCrawlMark);
		}

		// Token: 0x06004A30 RID: 18992 RVA: 0x0010C6E4 File Offset: 0x0010A8E4
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, Type returnType, Type[] parameterTypes, Module m, bool skipVisibility)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.PerformSecurityCheck(m, ref stackCrawlMark, skipVisibility);
			this.Init(name, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, null, m, skipVisibility, false, ref stackCrawlMark);
		}

		// Token: 0x06004A31 RID: 18993 RVA: 0x0010C71C File Offset: 0x0010A91C
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, Module m, bool skipVisibility)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.PerformSecurityCheck(m, ref stackCrawlMark, skipVisibility);
			this.Init(name, attributes, callingConvention, returnType, parameterTypes, null, m, skipVisibility, false, ref stackCrawlMark);
		}

		// Token: 0x06004A32 RID: 18994 RVA: 0x0010C754 File Offset: 0x0010A954
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, Type returnType, Type[] parameterTypes, Type owner)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.PerformSecurityCheck(owner, ref stackCrawlMark, false);
			this.Init(name, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, owner, null, false, false, ref stackCrawlMark);
		}

		// Token: 0x06004A33 RID: 18995 RVA: 0x0010C788 File Offset: 0x0010A988
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, Type returnType, Type[] parameterTypes, Type owner, bool skipVisibility)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.PerformSecurityCheck(owner, ref stackCrawlMark, skipVisibility);
			this.Init(name, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, owner, null, skipVisibility, false, ref stackCrawlMark);
		}

		// Token: 0x06004A34 RID: 18996 RVA: 0x0010C7C0 File Offset: 0x0010A9C0
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, Type owner, bool skipVisibility)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.PerformSecurityCheck(owner, ref stackCrawlMark, skipVisibility);
			this.Init(name, attributes, callingConvention, returnType, parameterTypes, owner, null, skipVisibility, false, ref stackCrawlMark);
		}

		// Token: 0x06004A35 RID: 18997 RVA: 0x0010C7F8 File Offset: 0x0010A9F8
		private static void CheckConsistency(MethodAttributes attributes, CallingConventions callingConvention)
		{
			if ((attributes & ~MethodAttributes.MemberAccessMask) != MethodAttributes.Static)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicMethodFlags"));
			}
			if ((attributes & MethodAttributes.MemberAccessMask) != MethodAttributes.Public)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicMethodFlags"));
			}
			if (callingConvention != CallingConventions.Standard && callingConvention != CallingConventions.VarArgs)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicMethodFlags"));
			}
			if (callingConvention == CallingConventions.VarArgs)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicMethodFlags"));
			}
		}

		// Token: 0x06004A36 RID: 18998 RVA: 0x0010C860 File Offset: 0x0010AA60
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static RuntimeModule GetDynamicMethodsModule()
		{
			if (DynamicMethod.s_anonymouslyHostedDynamicMethodsModule != null)
			{
				return DynamicMethod.s_anonymouslyHostedDynamicMethodsModule;
			}
			object obj = DynamicMethod.s_anonymouslyHostedDynamicMethodsModuleLock;
			lock (obj)
			{
				if (DynamicMethod.s_anonymouslyHostedDynamicMethodsModule != null)
				{
					return DynamicMethod.s_anonymouslyHostedDynamicMethodsModule;
				}
				ConstructorInfo constructor = typeof(SecurityTransparentAttribute).GetConstructor(Type.EmptyTypes);
				CustomAttributeBuilder item = new CustomAttributeBuilder(constructor, EmptyArray<object>.Value);
				List<CustomAttributeBuilder> list = new List<CustomAttributeBuilder>();
				list.Add(item);
				ConstructorInfo constructor2 = typeof(SecurityRulesAttribute).GetConstructor(new Type[]
				{
					typeof(SecurityRuleSet)
				});
				CustomAttributeBuilder item2 = new CustomAttributeBuilder(constructor2, new object[]
				{
					SecurityRuleSet.Level1
				});
				list.Add(item2);
				AssemblyName name = new AssemblyName("Anonymously Hosted DynamicMethods Assembly");
				StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMe;
				AssemblyBuilder assemblyBuilder = AssemblyBuilder.InternalDefineDynamicAssembly(name, AssemblyBuilderAccess.Run, null, null, null, null, null, ref stackCrawlMark, list, SecurityContextSource.CurrentAssembly);
				AppDomain.PublishAnonymouslyHostedDynamicMethodsAssembly(assemblyBuilder.GetNativeHandle());
				DynamicMethod.s_anonymouslyHostedDynamicMethodsModule = (InternalModuleBuilder)assemblyBuilder.ManifestModule;
			}
			return DynamicMethod.s_anonymouslyHostedDynamicMethodsModule;
		}

		// Token: 0x06004A37 RID: 18999 RVA: 0x0010C990 File Offset: 0x0010AB90
		[SecurityCritical]
		private void Init(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] signature, Type owner, Module m, bool skipVisibility, bool transparentMethod, ref StackCrawlMark stackMark)
		{
			DynamicMethod.CheckConsistency(attributes, callingConvention);
			if (signature != null)
			{
				this.m_parameterTypes = new RuntimeType[signature.Length];
				for (int i = 0; i < signature.Length; i++)
				{
					if (signature[i] == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Arg_InvalidTypeInSignature"));
					}
					this.m_parameterTypes[i] = (signature[i].UnderlyingSystemType as RuntimeType);
					if (this.m_parameterTypes[i] == null || this.m_parameterTypes[i] == null || this.m_parameterTypes[i] == (RuntimeType)typeof(void))
					{
						throw new ArgumentException(Environment.GetResourceString("Arg_InvalidTypeInSignature"));
					}
				}
			}
			else
			{
				this.m_parameterTypes = new RuntimeType[0];
			}
			this.m_returnType = ((returnType == null) ? ((RuntimeType)typeof(void)) : (returnType.UnderlyingSystemType as RuntimeType));
			if (this.m_returnType == null || this.m_returnType == null || this.m_returnType.IsByRef)
			{
				throw new NotSupportedException(Environment.GetResourceString("Arg_InvalidTypeInRetType"));
			}
			if (transparentMethod)
			{
				this.m_module = DynamicMethod.GetDynamicMethodsModule();
				if (skipVisibility)
				{
					this.m_restrictedSkipVisibility = true;
				}
				this.m_creationContext = CompressedStack.Capture();
			}
			else
			{
				if (m != null)
				{
					this.m_module = m.ModuleHandle.GetRuntimeModule();
				}
				else
				{
					RuntimeType runtimeType = null;
					if (owner != null)
					{
						runtimeType = (owner.UnderlyingSystemType as RuntimeType);
					}
					if (runtimeType != null)
					{
						if (runtimeType.HasElementType || runtimeType.ContainsGenericParameters || runtimeType.IsGenericParameter || runtimeType.IsInterface)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_InvalidTypeForDynamicMethod"));
						}
						this.m_typeOwner = runtimeType;
						this.m_module = runtimeType.GetRuntimeModule();
					}
				}
				this.m_skipVisibility = skipVisibility;
			}
			this.m_ilGenerator = null;
			this.m_fInitLocals = true;
			this.m_methodHandle = null;
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (AppDomain.ProfileAPICheck)
			{
				if (this.m_creatorAssembly == null)
				{
					this.m_creatorAssembly = RuntimeAssembly.GetExecutingAssembly(ref stackMark);
				}
				if (this.m_creatorAssembly != null && !this.m_creatorAssembly.IsFrameworkAssembly())
				{
					this.m_profileAPICheck = true;
				}
			}
			this.m_dynMethod = new DynamicMethod.RTDynamicMethod(this, name, attributes, callingConvention);
		}

		// Token: 0x06004A38 RID: 19000 RVA: 0x0010CBE4 File Offset: 0x0010ADE4
		[SecurityCritical]
		private void PerformSecurityCheck(Module m, ref StackCrawlMark stackMark, bool skipVisibility)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			ModuleBuilder moduleBuilder = m as ModuleBuilder;
			RuntimeModule left;
			if (moduleBuilder != null)
			{
				left = moduleBuilder.InternalModule;
			}
			else
			{
				left = (m as RuntimeModule);
			}
			if (left == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeModule"), "m");
			}
			if (left == DynamicMethod.s_anonymouslyHostedDynamicMethodsModule)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidValue"), "m");
			}
			if (skipVisibility)
			{
				new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Demand();
			}
			RuntimeType callerType = RuntimeMethodHandle.GetCallerType(ref stackMark);
			this.m_creatorAssembly = callerType.GetRuntimeAssembly();
			if (m.Assembly != this.m_creatorAssembly)
			{
				CodeAccessSecurityEngine.ReflectionTargetDemandHelper(PermissionType.SecurityControlEvidence, m.Assembly.PermissionSet);
			}
		}

		// Token: 0x06004A39 RID: 19001 RVA: 0x0010CCB0 File Offset: 0x0010AEB0
		[SecurityCritical]
		private void PerformSecurityCheck(Type owner, ref StackCrawlMark stackMark, bool skipVisibility)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner");
			}
			RuntimeType runtimeType = owner as RuntimeType;
			if (runtimeType == null)
			{
				runtimeType = (owner.UnderlyingSystemType as RuntimeType);
			}
			if (runtimeType == null)
			{
				throw new ArgumentNullException("owner", Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			RuntimeType callerType = RuntimeMethodHandle.GetCallerType(ref stackMark);
			if (skipVisibility)
			{
				new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Demand();
			}
			else if (callerType != runtimeType)
			{
				new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Demand();
			}
			this.m_creatorAssembly = callerType.GetRuntimeAssembly();
			if (runtimeType.Assembly != this.m_creatorAssembly)
			{
				CodeAccessSecurityEngine.ReflectionTargetDemandHelper(PermissionType.SecurityControlEvidence, owner.Assembly.PermissionSet);
			}
		}

		// Token: 0x06004A3A RID: 19002 RVA: 0x0010CD68 File Offset: 0x0010AF68
		[SecuritySafeCritical]
		[ComVisible(true)]
		public sealed override Delegate CreateDelegate(Type delegateType)
		{
			if (this.m_restrictedSkipVisibility)
			{
				this.GetMethodDescriptor();
				RuntimeHelpers._CompileMethod(this.m_methodHandle);
			}
			MulticastDelegate multicastDelegate = (MulticastDelegate)Delegate.CreateDelegateNoSecurityCheck(delegateType, null, this.GetMethodDescriptor());
			multicastDelegate.StoreDynamicMethod(this.GetMethodInfo());
			return multicastDelegate;
		}

		// Token: 0x06004A3B RID: 19003 RVA: 0x0010CDB0 File Offset: 0x0010AFB0
		[SecuritySafeCritical]
		[ComVisible(true)]
		public sealed override Delegate CreateDelegate(Type delegateType, object target)
		{
			if (this.m_restrictedSkipVisibility)
			{
				this.GetMethodDescriptor();
				RuntimeHelpers._CompileMethod(this.m_methodHandle);
			}
			MulticastDelegate multicastDelegate = (MulticastDelegate)Delegate.CreateDelegateNoSecurityCheck(delegateType, target, this.GetMethodDescriptor());
			multicastDelegate.StoreDynamicMethod(this.GetMethodInfo());
			return multicastDelegate;
		}

		// Token: 0x17000B91 RID: 2961
		// (get) Token: 0x06004A3C RID: 19004 RVA: 0x0010CDF7 File Offset: 0x0010AFF7
		// (set) Token: 0x06004A3D RID: 19005 RVA: 0x0010CDFF File Offset: 0x0010AFFF
		internal bool ProfileAPICheck
		{
			get
			{
				return this.m_profileAPICheck;
			}
			[FriendAccessAllowed]
			set
			{
				this.m_profileAPICheck = value;
			}
		}

		// Token: 0x06004A3E RID: 19006 RVA: 0x0010CE08 File Offset: 0x0010B008
		[SecurityCritical]
		internal RuntimeMethodHandle GetMethodDescriptor()
		{
			if (this.m_methodHandle == null)
			{
				lock (this)
				{
					if (this.m_methodHandle == null)
					{
						if (this.m_DynamicILInfo != null)
						{
							this.m_DynamicILInfo.GetCallableMethod(this.m_module, this);
						}
						else
						{
							if (this.m_ilGenerator == null || this.m_ilGenerator.ILOffset == 0)
							{
								throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadEmptyMethodBody", new object[]
								{
									this.Name
								}));
							}
							this.m_ilGenerator.GetCallableMethod(this.m_module, this);
						}
					}
				}
			}
			return new RuntimeMethodHandle(this.m_methodHandle);
		}

		// Token: 0x06004A3F RID: 19007 RVA: 0x0010CEC0 File Offset: 0x0010B0C0
		public override string ToString()
		{
			return this.m_dynMethod.ToString();
		}

		// Token: 0x17000B92 RID: 2962
		// (get) Token: 0x06004A40 RID: 19008 RVA: 0x0010CECD File Offset: 0x0010B0CD
		public override string Name
		{
			get
			{
				return this.m_dynMethod.Name;
			}
		}

		// Token: 0x17000B93 RID: 2963
		// (get) Token: 0x06004A41 RID: 19009 RVA: 0x0010CEDA File Offset: 0x0010B0DA
		public override Type DeclaringType
		{
			get
			{
				return this.m_dynMethod.DeclaringType;
			}
		}

		// Token: 0x17000B94 RID: 2964
		// (get) Token: 0x06004A42 RID: 19010 RVA: 0x0010CEE7 File Offset: 0x0010B0E7
		public override Type ReflectedType
		{
			get
			{
				return this.m_dynMethod.ReflectedType;
			}
		}

		// Token: 0x17000B95 RID: 2965
		// (get) Token: 0x06004A43 RID: 19011 RVA: 0x0010CEF4 File Offset: 0x0010B0F4
		public override Module Module
		{
			get
			{
				return this.m_dynMethod.Module;
			}
		}

		// Token: 0x17000B96 RID: 2966
		// (get) Token: 0x06004A44 RID: 19012 RVA: 0x0010CF01 File Offset: 0x0010B101
		public override RuntimeMethodHandle MethodHandle
		{
			get
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotAllowedInDynamicMethod"));
			}
		}

		// Token: 0x17000B97 RID: 2967
		// (get) Token: 0x06004A45 RID: 19013 RVA: 0x0010CF12 File Offset: 0x0010B112
		public override MethodAttributes Attributes
		{
			get
			{
				return this.m_dynMethod.Attributes;
			}
		}

		// Token: 0x17000B98 RID: 2968
		// (get) Token: 0x06004A46 RID: 19014 RVA: 0x0010CF1F File Offset: 0x0010B11F
		public override CallingConventions CallingConvention
		{
			get
			{
				return this.m_dynMethod.CallingConvention;
			}
		}

		// Token: 0x06004A47 RID: 19015 RVA: 0x0010CF2C File Offset: 0x0010B12C
		public override MethodInfo GetBaseDefinition()
		{
			return this;
		}

		// Token: 0x06004A48 RID: 19016 RVA: 0x0010CF2F File Offset: 0x0010B12F
		public override ParameterInfo[] GetParameters()
		{
			return this.m_dynMethod.GetParameters();
		}

		// Token: 0x06004A49 RID: 19017 RVA: 0x0010CF3C File Offset: 0x0010B13C
		public override MethodImplAttributes GetMethodImplementationFlags()
		{
			return this.m_dynMethod.GetMethodImplementationFlags();
		}

		// Token: 0x17000B99 RID: 2969
		// (get) Token: 0x06004A4A RID: 19018 RVA: 0x0010CF4C File Offset: 0x0010B14C
		public override bool IsSecurityCritical
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_methodHandle != null)
				{
					return RuntimeMethodHandle.IsSecurityCritical(this.m_methodHandle);
				}
				if (this.m_typeOwner != null)
				{
					RuntimeAssembly runtimeAssembly = this.m_typeOwner.Assembly as RuntimeAssembly;
					return runtimeAssembly.IsAllSecurityCritical();
				}
				RuntimeAssembly runtimeAssembly2 = this.m_module.Assembly as RuntimeAssembly;
				return runtimeAssembly2.IsAllSecurityCritical();
			}
		}

		// Token: 0x17000B9A RID: 2970
		// (get) Token: 0x06004A4B RID: 19019 RVA: 0x0010CFAC File Offset: 0x0010B1AC
		public override bool IsSecuritySafeCritical
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_methodHandle != null)
				{
					return RuntimeMethodHandle.IsSecuritySafeCritical(this.m_methodHandle);
				}
				if (this.m_typeOwner != null)
				{
					RuntimeAssembly runtimeAssembly = this.m_typeOwner.Assembly as RuntimeAssembly;
					return runtimeAssembly.IsAllPublicAreaSecuritySafeCritical();
				}
				RuntimeAssembly runtimeAssembly2 = this.m_module.Assembly as RuntimeAssembly;
				return runtimeAssembly2.IsAllSecuritySafeCritical();
			}
		}

		// Token: 0x17000B9B RID: 2971
		// (get) Token: 0x06004A4C RID: 19020 RVA: 0x0010D00C File Offset: 0x0010B20C
		public override bool IsSecurityTransparent
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_methodHandle != null)
				{
					return RuntimeMethodHandle.IsSecurityTransparent(this.m_methodHandle);
				}
				if (this.m_typeOwner != null)
				{
					RuntimeAssembly runtimeAssembly = this.m_typeOwner.Assembly as RuntimeAssembly;
					return !runtimeAssembly.IsAllSecurityCritical();
				}
				RuntimeAssembly runtimeAssembly2 = this.m_module.Assembly as RuntimeAssembly;
				return !runtimeAssembly2.IsAllSecurityCritical();
			}
		}

		// Token: 0x06004A4D RID: 19021 RVA: 0x0010D070 File Offset: 0x0010B270
		[SecuritySafeCritical]
		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			if ((this.CallingConvention & CallingConventions.VarArgs) == CallingConventions.VarArgs)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_CallToVarArg"));
			}
			RuntimeMethodHandle methodDescriptor = this.GetMethodDescriptor();
			Signature signature = new Signature(this.m_methodHandle, this.m_parameterTypes, this.m_returnType, this.CallingConvention);
			int num = signature.Arguments.Length;
			int num2 = (parameters != null) ? parameters.Length : 0;
			if (num != num2)
			{
				throw new TargetParameterCountException(Environment.GetResourceString("Arg_ParmCnt"));
			}
			object result;
			if (num2 > 0)
			{
				object[] array = base.CheckArguments(parameters, binder, invokeAttr, culture, signature);
				result = RuntimeMethodHandle.InvokeMethod(null, array, signature, false);
				for (int i = 0; i < array.Length; i++)
				{
					parameters[i] = array[i];
				}
			}
			else
			{
				result = RuntimeMethodHandle.InvokeMethod(null, null, signature, false);
			}
			GC.KeepAlive(this);
			return result;
		}

		// Token: 0x06004A4E RID: 19022 RVA: 0x0010D13A File Offset: 0x0010B33A
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return this.m_dynMethod.GetCustomAttributes(attributeType, inherit);
		}

		// Token: 0x06004A4F RID: 19023 RVA: 0x0010D149 File Offset: 0x0010B349
		public override object[] GetCustomAttributes(bool inherit)
		{
			return this.m_dynMethod.GetCustomAttributes(inherit);
		}

		// Token: 0x06004A50 RID: 19024 RVA: 0x0010D157 File Offset: 0x0010B357
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return this.m_dynMethod.IsDefined(attributeType, inherit);
		}

		// Token: 0x17000B9C RID: 2972
		// (get) Token: 0x06004A51 RID: 19025 RVA: 0x0010D166 File Offset: 0x0010B366
		public override Type ReturnType
		{
			get
			{
				return this.m_dynMethod.ReturnType;
			}
		}

		// Token: 0x17000B9D RID: 2973
		// (get) Token: 0x06004A52 RID: 19026 RVA: 0x0010D173 File Offset: 0x0010B373
		public override ParameterInfo ReturnParameter
		{
			get
			{
				return this.m_dynMethod.ReturnParameter;
			}
		}

		// Token: 0x17000B9E RID: 2974
		// (get) Token: 0x06004A53 RID: 19027 RVA: 0x0010D180 File Offset: 0x0010B380
		public override ICustomAttributeProvider ReturnTypeCustomAttributes
		{
			get
			{
				return this.m_dynMethod.ReturnTypeCustomAttributes;
			}
		}

		// Token: 0x06004A54 RID: 19028 RVA: 0x0010D190 File Offset: 0x0010B390
		public ParameterBuilder DefineParameter(int position, ParameterAttributes attributes, string parameterName)
		{
			if (position < 0 || position > this.m_parameterTypes.Length)
			{
				throw new ArgumentOutOfRangeException(Environment.GetResourceString("ArgumentOutOfRange_ParamSequence"));
			}
			position--;
			if (position >= 0)
			{
				ParameterInfo[] array = this.m_dynMethod.LoadParameters();
				array[position].SetName(parameterName);
				array[position].SetAttributes(attributes);
			}
			return null;
		}

		// Token: 0x06004A55 RID: 19029 RVA: 0x0010D1E4 File Offset: 0x0010B3E4
		[SecuritySafeCritical]
		public DynamicILInfo GetDynamicILInfo()
		{
			new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
			if (this.m_DynamicILInfo != null)
			{
				return this.m_DynamicILInfo;
			}
			return this.GetDynamicILInfo(new DynamicScope());
		}

		// Token: 0x06004A56 RID: 19030 RVA: 0x0010D20C File Offset: 0x0010B40C
		[SecurityCritical]
		internal DynamicILInfo GetDynamicILInfo(DynamicScope scope)
		{
			if (this.m_DynamicILInfo == null)
			{
				Module scope2 = null;
				CallingConventions callingConvention = this.CallingConvention;
				Type returnType = this.ReturnType;
				Type[] requiredReturnTypeCustomModifiers = null;
				Type[] optionalReturnTypeCustomModifiers = null;
				Type[] parameterTypes = this.m_parameterTypes;
				byte[] signature = SignatureHelper.GetMethodSigHelper(scope2, callingConvention, returnType, requiredReturnTypeCustomModifiers, optionalReturnTypeCustomModifiers, parameterTypes, null, null).GetSignature(true);
				this.m_DynamicILInfo = new DynamicILInfo(scope, this, signature);
			}
			return this.m_DynamicILInfo;
		}

		// Token: 0x06004A57 RID: 19031 RVA: 0x0010D25A File Offset: 0x0010B45A
		public ILGenerator GetILGenerator()
		{
			return this.GetILGenerator(64);
		}

		// Token: 0x06004A58 RID: 19032 RVA: 0x0010D264 File Offset: 0x0010B464
		[SecuritySafeCritical]
		public ILGenerator GetILGenerator(int streamSize)
		{
			if (this.m_ilGenerator == null)
			{
				Module scope = null;
				CallingConventions callingConvention = this.CallingConvention;
				Type returnType = this.ReturnType;
				Type[] requiredReturnTypeCustomModifiers = null;
				Type[] optionalReturnTypeCustomModifiers = null;
				Type[] parameterTypes = this.m_parameterTypes;
				byte[] signature = SignatureHelper.GetMethodSigHelper(scope, callingConvention, returnType, requiredReturnTypeCustomModifiers, optionalReturnTypeCustomModifiers, parameterTypes, null, null).GetSignature(true);
				this.m_ilGenerator = new DynamicILGenerator(this, signature, streamSize);
			}
			return this.m_ilGenerator;
		}

		// Token: 0x17000B9F RID: 2975
		// (get) Token: 0x06004A59 RID: 19033 RVA: 0x0010D2B2 File Offset: 0x0010B4B2
		// (set) Token: 0x06004A5A RID: 19034 RVA: 0x0010D2BA File Offset: 0x0010B4BA
		public bool InitLocals
		{
			get
			{
				return this.m_fInitLocals;
			}
			set
			{
				this.m_fInitLocals = value;
			}
		}

		// Token: 0x06004A5B RID: 19035 RVA: 0x0010D2C3 File Offset: 0x0010B4C3
		internal MethodInfo GetMethodInfo()
		{
			return this.m_dynMethod;
		}

		// Token: 0x04001E96 RID: 7830
		private RuntimeType[] m_parameterTypes;

		// Token: 0x04001E97 RID: 7831
		internal IRuntimeMethodInfo m_methodHandle;

		// Token: 0x04001E98 RID: 7832
		private RuntimeType m_returnType;

		// Token: 0x04001E99 RID: 7833
		private DynamicILGenerator m_ilGenerator;

		// Token: 0x04001E9A RID: 7834
		private DynamicILInfo m_DynamicILInfo;

		// Token: 0x04001E9B RID: 7835
		private bool m_fInitLocals;

		// Token: 0x04001E9C RID: 7836
		private RuntimeModule m_module;

		// Token: 0x04001E9D RID: 7837
		internal bool m_skipVisibility;

		// Token: 0x04001E9E RID: 7838
		internal RuntimeType m_typeOwner;

		// Token: 0x04001E9F RID: 7839
		private DynamicMethod.RTDynamicMethod m_dynMethod;

		// Token: 0x04001EA0 RID: 7840
		internal DynamicResolver m_resolver;

		// Token: 0x04001EA1 RID: 7841
		private bool m_profileAPICheck;

		// Token: 0x04001EA2 RID: 7842
		private RuntimeAssembly m_creatorAssembly;

		// Token: 0x04001EA3 RID: 7843
		internal bool m_restrictedSkipVisibility;

		// Token: 0x04001EA4 RID: 7844
		internal CompressedStack m_creationContext;

		// Token: 0x04001EA5 RID: 7845
		private static volatile InternalModuleBuilder s_anonymouslyHostedDynamicMethodsModule;

		// Token: 0x04001EA6 RID: 7846
		private static readonly object s_anonymouslyHostedDynamicMethodsModuleLock = new object();

		// Token: 0x02000C3F RID: 3135
		internal class RTDynamicMethod : MethodInfo
		{
			// Token: 0x06007049 RID: 28745 RVA: 0x00182FAC File Offset: 0x001811AC
			private RTDynamicMethod()
			{
			}

			// Token: 0x0600704A RID: 28746 RVA: 0x00182FB4 File Offset: 0x001811B4
			internal RTDynamicMethod(DynamicMethod owner, string name, MethodAttributes attributes, CallingConventions callingConvention)
			{
				this.m_owner = owner;
				this.m_name = name;
				this.m_attributes = attributes;
				this.m_callingConvention = callingConvention;
			}

			// Token: 0x0600704B RID: 28747 RVA: 0x00182FD9 File Offset: 0x001811D9
			public override string ToString()
			{
				return this.ReturnType.FormatTypeName() + " " + base.FormatNameAndSig();
			}

			// Token: 0x17001342 RID: 4930
			// (get) Token: 0x0600704C RID: 28748 RVA: 0x00182FF6 File Offset: 0x001811F6
			public override string Name
			{
				get
				{
					return this.m_name;
				}
			}

			// Token: 0x17001343 RID: 4931
			// (get) Token: 0x0600704D RID: 28749 RVA: 0x00182FFE File Offset: 0x001811FE
			public override Type DeclaringType
			{
				get
				{
					return null;
				}
			}

			// Token: 0x17001344 RID: 4932
			// (get) Token: 0x0600704E RID: 28750 RVA: 0x00183001 File Offset: 0x00181201
			public override Type ReflectedType
			{
				get
				{
					return null;
				}
			}

			// Token: 0x17001345 RID: 4933
			// (get) Token: 0x0600704F RID: 28751 RVA: 0x00183004 File Offset: 0x00181204
			public override Module Module
			{
				get
				{
					return this.m_owner.m_module;
				}
			}

			// Token: 0x17001346 RID: 4934
			// (get) Token: 0x06007050 RID: 28752 RVA: 0x00183011 File Offset: 0x00181211
			public override RuntimeMethodHandle MethodHandle
			{
				get
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotAllowedInDynamicMethod"));
				}
			}

			// Token: 0x17001347 RID: 4935
			// (get) Token: 0x06007051 RID: 28753 RVA: 0x00183022 File Offset: 0x00181222
			public override MethodAttributes Attributes
			{
				get
				{
					return this.m_attributes;
				}
			}

			// Token: 0x17001348 RID: 4936
			// (get) Token: 0x06007052 RID: 28754 RVA: 0x0018302A File Offset: 0x0018122A
			public override CallingConventions CallingConvention
			{
				get
				{
					return this.m_callingConvention;
				}
			}

			// Token: 0x06007053 RID: 28755 RVA: 0x00183032 File Offset: 0x00181232
			public override MethodInfo GetBaseDefinition()
			{
				return this;
			}

			// Token: 0x06007054 RID: 28756 RVA: 0x00183038 File Offset: 0x00181238
			public override ParameterInfo[] GetParameters()
			{
				ParameterInfo[] array = this.LoadParameters();
				ParameterInfo[] array2 = new ParameterInfo[array.Length];
				Array.Copy(array, array2, array.Length);
				return array2;
			}

			// Token: 0x06007055 RID: 28757 RVA: 0x00183060 File Offset: 0x00181260
			public override MethodImplAttributes GetMethodImplementationFlags()
			{
				return MethodImplAttributes.NoInlining;
			}

			// Token: 0x06007056 RID: 28758 RVA: 0x00183063 File Offset: 0x00181263
			public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeMethodInfo"), "this");
			}

			// Token: 0x06007057 RID: 28759 RVA: 0x0018307C File Offset: 0x0018127C
			public override object[] GetCustomAttributes(Type attributeType, bool inherit)
			{
				if (attributeType == null)
				{
					throw new ArgumentNullException("attributeType");
				}
				if (attributeType.IsAssignableFrom(typeof(MethodImplAttribute)))
				{
					return new object[]
					{
						new MethodImplAttribute(this.GetMethodImplementationFlags())
					};
				}
				return EmptyArray<object>.Value;
			}

			// Token: 0x06007058 RID: 28760 RVA: 0x001830C9 File Offset: 0x001812C9
			public override object[] GetCustomAttributes(bool inherit)
			{
				return new object[]
				{
					new MethodImplAttribute(this.GetMethodImplementationFlags())
				};
			}

			// Token: 0x06007059 RID: 28761 RVA: 0x001830DF File Offset: 0x001812DF
			public override bool IsDefined(Type attributeType, bool inherit)
			{
				if (attributeType == null)
				{
					throw new ArgumentNullException("attributeType");
				}
				return attributeType.IsAssignableFrom(typeof(MethodImplAttribute));
			}

			// Token: 0x17001349 RID: 4937
			// (get) Token: 0x0600705A RID: 28762 RVA: 0x0018310A File Offset: 0x0018130A
			public override bool IsSecurityCritical
			{
				get
				{
					return this.m_owner.IsSecurityCritical;
				}
			}

			// Token: 0x1700134A RID: 4938
			// (get) Token: 0x0600705B RID: 28763 RVA: 0x00183117 File Offset: 0x00181317
			public override bool IsSecuritySafeCritical
			{
				get
				{
					return this.m_owner.IsSecuritySafeCritical;
				}
			}

			// Token: 0x1700134B RID: 4939
			// (get) Token: 0x0600705C RID: 28764 RVA: 0x00183124 File Offset: 0x00181324
			public override bool IsSecurityTransparent
			{
				get
				{
					return this.m_owner.IsSecurityTransparent;
				}
			}

			// Token: 0x1700134C RID: 4940
			// (get) Token: 0x0600705D RID: 28765 RVA: 0x00183131 File Offset: 0x00181331
			public override Type ReturnType
			{
				get
				{
					return this.m_owner.m_returnType;
				}
			}

			// Token: 0x1700134D RID: 4941
			// (get) Token: 0x0600705E RID: 28766 RVA: 0x0018313E File Offset: 0x0018133E
			public override ParameterInfo ReturnParameter
			{
				get
				{
					return null;
				}
			}

			// Token: 0x1700134E RID: 4942
			// (get) Token: 0x0600705F RID: 28767 RVA: 0x00183141 File Offset: 0x00181341
			public override ICustomAttributeProvider ReturnTypeCustomAttributes
			{
				get
				{
					return this.GetEmptyCAHolder();
				}
			}

			// Token: 0x06007060 RID: 28768 RVA: 0x0018314C File Offset: 0x0018134C
			internal ParameterInfo[] LoadParameters()
			{
				if (this.m_parameters == null)
				{
					Type[] parameterTypes = this.m_owner.m_parameterTypes;
					Type[] array = parameterTypes;
					ParameterInfo[] array2 = new ParameterInfo[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						array2[i] = new RuntimeParameterInfo(this, null, array[i], i);
					}
					if (this.m_parameters == null)
					{
						this.m_parameters = array2;
					}
				}
				return this.m_parameters;
			}

			// Token: 0x06007061 RID: 28769 RVA: 0x001831A9 File Offset: 0x001813A9
			private ICustomAttributeProvider GetEmptyCAHolder()
			{
				return new DynamicMethod.RTDynamicMethod.EmptyCAHolder();
			}

			// Token: 0x0400374D RID: 14157
			internal DynamicMethod m_owner;

			// Token: 0x0400374E RID: 14158
			private ParameterInfo[] m_parameters;

			// Token: 0x0400374F RID: 14159
			private string m_name;

			// Token: 0x04003750 RID: 14160
			private MethodAttributes m_attributes;

			// Token: 0x04003751 RID: 14161
			private CallingConventions m_callingConvention;

			// Token: 0x02000D0D RID: 3341
			private class EmptyCAHolder : ICustomAttributeProvider
			{
				// Token: 0x0600721F RID: 29215 RVA: 0x00189583 File Offset: 0x00187783
				internal EmptyCAHolder()
				{
				}

				// Token: 0x06007220 RID: 29216 RVA: 0x0018958B File Offset: 0x0018778B
				object[] ICustomAttributeProvider.GetCustomAttributes(Type attributeType, bool inherit)
				{
					return EmptyArray<object>.Value;
				}

				// Token: 0x06007221 RID: 29217 RVA: 0x00189592 File Offset: 0x00187792
				object[] ICustomAttributeProvider.GetCustomAttributes(bool inherit)
				{
					return EmptyArray<object>.Value;
				}

				// Token: 0x06007222 RID: 29218 RVA: 0x00189599 File Offset: 0x00187799
				bool ICustomAttributeProvider.IsDefined(Type attributeType, bool inherit)
				{
					return false;
				}
			}
		}
	}
}
