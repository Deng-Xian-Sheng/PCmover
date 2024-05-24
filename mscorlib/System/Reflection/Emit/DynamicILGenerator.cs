using System;
using System.Diagnostics.SymbolStore;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Reflection.Emit
{
	// Token: 0x02000630 RID: 1584
	internal class DynamicILGenerator : ILGenerator
	{
		// Token: 0x060049D1 RID: 18897 RVA: 0x0010AE9E File Offset: 0x0010909E
		internal DynamicILGenerator(DynamicMethod method, byte[] methodSignature, int size) : base(method, size)
		{
			this.m_scope = new DynamicScope();
			this.m_methodSigToken = this.m_scope.GetTokenFor(methodSignature);
		}

		// Token: 0x060049D2 RID: 18898 RVA: 0x0010AEC5 File Offset: 0x001090C5
		[SecurityCritical]
		internal void GetCallableMethod(RuntimeModule module, DynamicMethod dm)
		{
			dm.m_methodHandle = ModuleHandle.GetDynamicMethod(dm, module, this.m_methodBuilder.Name, (byte[])this.m_scope[this.m_methodSigToken], new DynamicResolver(this));
		}

		// Token: 0x17000B89 RID: 2953
		// (get) Token: 0x060049D3 RID: 18899 RVA: 0x0010AEFB File Offset: 0x001090FB
		private bool ProfileAPICheck
		{
			get
			{
				return ((DynamicMethod)this.m_methodBuilder).ProfileAPICheck;
			}
		}

		// Token: 0x060049D4 RID: 18900 RVA: 0x0010AF10 File Offset: 0x00109110
		public override LocalBuilder DeclareLocal(Type localType, bool pinned)
		{
			if (localType == null)
			{
				throw new ArgumentNullException("localType");
			}
			RuntimeType runtimeType = localType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			if (this.ProfileAPICheck && (runtimeType.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
				{
					runtimeType.FullName
				}));
			}
			LocalBuilder result = new LocalBuilder(this.m_localCount, localType, this.m_methodBuilder);
			this.m_localSignature.AddArgument(localType, pinned);
			this.m_localCount++;
			return result;
		}

		// Token: 0x060049D5 RID: 18901 RVA: 0x0010AFB4 File Offset: 0x001091B4
		[SecuritySafeCritical]
		public override void Emit(OpCode opcode, MethodInfo meth)
		{
			if (meth == null)
			{
				throw new ArgumentNullException("meth");
			}
			int num = 0;
			DynamicMethod dynamicMethod = meth as DynamicMethod;
			int tokenFor;
			if (dynamicMethod == null)
			{
				RuntimeMethodInfo runtimeMethodInfo = meth as RuntimeMethodInfo;
				if (runtimeMethodInfo == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeMethodInfo"), "meth");
				}
				RuntimeType runtimeType = runtimeMethodInfo.GetRuntimeType();
				if (runtimeType != null && (runtimeType.IsGenericType || runtimeType.IsArray))
				{
					tokenFor = this.GetTokenFor(runtimeMethodInfo, runtimeType);
				}
				else
				{
					tokenFor = this.GetTokenFor(runtimeMethodInfo);
				}
			}
			else
			{
				if (opcode.Equals(OpCodes.Ldtoken) || opcode.Equals(OpCodes.Ldftn) || opcode.Equals(OpCodes.Ldvirtftn))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOpCodeOnDynamicMethod"));
				}
				tokenFor = this.GetTokenFor(dynamicMethod);
			}
			base.EnsureCapacity(7);
			base.InternalEmit(opcode);
			if (opcode.StackBehaviourPush == StackBehaviour.Varpush && meth.ReturnType != typeof(void))
			{
				num++;
			}
			if (opcode.StackBehaviourPop == StackBehaviour.Varpop)
			{
				num -= meth.GetParametersNoCopy().Length;
			}
			if (!meth.IsStatic && !opcode.Equals(OpCodes.Newobj) && !opcode.Equals(OpCodes.Ldtoken) && !opcode.Equals(OpCodes.Ldftn))
			{
				num--;
			}
			base.UpdateStackSize(opcode, num);
			base.PutInteger4(tokenFor);
		}

		// Token: 0x060049D6 RID: 18902 RVA: 0x0010B11C File Offset: 0x0010931C
		[ComVisible(true)]
		public override void Emit(OpCode opcode, ConstructorInfo con)
		{
			if (con == null)
			{
				throw new ArgumentNullException("con");
			}
			RuntimeConstructorInfo runtimeConstructorInfo = con as RuntimeConstructorInfo;
			if (runtimeConstructorInfo == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeMethodInfo"), "con");
			}
			RuntimeType runtimeType = runtimeConstructorInfo.GetRuntimeType();
			int tokenFor;
			if (runtimeType != null && (runtimeType.IsGenericType || runtimeType.IsArray))
			{
				tokenFor = this.GetTokenFor(runtimeConstructorInfo, runtimeType);
			}
			else
			{
				tokenFor = this.GetTokenFor(runtimeConstructorInfo);
			}
			base.EnsureCapacity(7);
			base.InternalEmit(opcode);
			base.UpdateStackSize(opcode, 1);
			base.PutInteger4(tokenFor);
		}

		// Token: 0x060049D7 RID: 18903 RVA: 0x0010B1B4 File Offset: 0x001093B4
		public override void Emit(OpCode opcode, Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			RuntimeType runtimeType = type as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			int tokenFor = this.GetTokenFor(runtimeType);
			base.EnsureCapacity(7);
			base.InternalEmit(opcode);
			base.PutInteger4(tokenFor);
		}

		// Token: 0x060049D8 RID: 18904 RVA: 0x0010B214 File Offset: 0x00109414
		public override void Emit(OpCode opcode, FieldInfo field)
		{
			if (field == null)
			{
				throw new ArgumentNullException("field");
			}
			RuntimeFieldInfo runtimeFieldInfo = field as RuntimeFieldInfo;
			if (runtimeFieldInfo == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeFieldInfo"), "field");
			}
			int tokenFor;
			if (field.DeclaringType == null)
			{
				tokenFor = this.GetTokenFor(runtimeFieldInfo);
			}
			else
			{
				tokenFor = this.GetTokenFor(runtimeFieldInfo, runtimeFieldInfo.GetRuntimeType());
			}
			base.EnsureCapacity(7);
			base.InternalEmit(opcode);
			base.PutInteger4(tokenFor);
		}

		// Token: 0x060049D9 RID: 18905 RVA: 0x0010B298 File Offset: 0x00109498
		public override void Emit(OpCode opcode, string str)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			int tokenForString = this.GetTokenForString(str);
			base.EnsureCapacity(7);
			base.InternalEmit(opcode);
			base.PutInteger4(tokenForString);
		}

		// Token: 0x060049DA RID: 18906 RVA: 0x0010B2D0 File Offset: 0x001094D0
		[SecuritySafeCritical]
		public override void EmitCalli(OpCode opcode, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, Type[] optionalParameterTypes)
		{
			int num = 0;
			if (optionalParameterTypes != null && (callingConvention & CallingConventions.VarArgs) == (CallingConventions)0)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotAVarArgCallingConvention"));
			}
			SignatureHelper memberRefSignature = this.GetMemberRefSignature(callingConvention, returnType, parameterTypes, optionalParameterTypes);
			base.EnsureCapacity(7);
			this.Emit(OpCodes.Calli);
			if (returnType != typeof(void))
			{
				num++;
			}
			if (parameterTypes != null)
			{
				num -= parameterTypes.Length;
			}
			if (optionalParameterTypes != null)
			{
				num -= optionalParameterTypes.Length;
			}
			if ((callingConvention & CallingConventions.HasThis) == CallingConventions.HasThis)
			{
				num--;
			}
			num--;
			base.UpdateStackSize(OpCodes.Calli, num);
			int tokenForSig = this.GetTokenForSig(memberRefSignature.GetSignature(true));
			base.PutInteger4(tokenForSig);
		}

		// Token: 0x060049DB RID: 18907 RVA: 0x0010B374 File Offset: 0x00109574
		public override void EmitCalli(OpCode opcode, CallingConvention unmanagedCallConv, Type returnType, Type[] parameterTypes)
		{
			int num = 0;
			int num2 = 0;
			if (parameterTypes != null)
			{
				num2 = parameterTypes.Length;
			}
			SignatureHelper methodSigHelper = SignatureHelper.GetMethodSigHelper(unmanagedCallConv, returnType);
			if (parameterTypes != null)
			{
				for (int i = 0; i < num2; i++)
				{
					methodSigHelper.AddArgument(parameterTypes[i]);
				}
			}
			if (returnType != typeof(void))
			{
				num++;
			}
			if (parameterTypes != null)
			{
				num -= num2;
			}
			num--;
			base.UpdateStackSize(OpCodes.Calli, num);
			base.EnsureCapacity(7);
			this.Emit(OpCodes.Calli);
			int tokenForSig = this.GetTokenForSig(methodSigHelper.GetSignature(true));
			base.PutInteger4(tokenForSig);
		}

		// Token: 0x060049DC RID: 18908 RVA: 0x0010B408 File Offset: 0x00109608
		[SecuritySafeCritical]
		public override void EmitCall(OpCode opcode, MethodInfo methodInfo, Type[] optionalParameterTypes)
		{
			if (methodInfo == null)
			{
				throw new ArgumentNullException("methodInfo");
			}
			if (!opcode.Equals(OpCodes.Call) && !opcode.Equals(OpCodes.Callvirt) && !opcode.Equals(OpCodes.Newobj))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NotMethodCallOpcode"), "opcode");
			}
			if (methodInfo.ContainsGenericParameters)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_GenericsInvalid"), "methodInfo");
			}
			if (methodInfo.DeclaringType != null && methodInfo.DeclaringType.ContainsGenericParameters)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_GenericsInvalid"), "methodInfo");
			}
			int num = 0;
			int memberRefToken = this.GetMemberRefToken(methodInfo, optionalParameterTypes);
			base.EnsureCapacity(7);
			base.InternalEmit(opcode);
			if (methodInfo.ReturnType != typeof(void))
			{
				num++;
			}
			num -= methodInfo.GetParameterTypes().Length;
			if (!(methodInfo is SymbolMethod) && !methodInfo.IsStatic && !opcode.Equals(OpCodes.Newobj))
			{
				num--;
			}
			if (optionalParameterTypes != null)
			{
				num -= optionalParameterTypes.Length;
			}
			base.UpdateStackSize(opcode, num);
			base.PutInteger4(memberRefToken);
		}

		// Token: 0x060049DD RID: 18909 RVA: 0x0010B530 File Offset: 0x00109730
		public override void Emit(OpCode opcode, SignatureHelper signature)
		{
			if (signature == null)
			{
				throw new ArgumentNullException("signature");
			}
			int num = 0;
			base.EnsureCapacity(7);
			base.InternalEmit(opcode);
			if (opcode.StackBehaviourPop == StackBehaviour.Varpop)
			{
				num -= signature.ArgumentCount;
				num--;
				base.UpdateStackSize(opcode, num);
			}
			int tokenForSig = this.GetTokenForSig(signature.GetSignature(true));
			base.PutInteger4(tokenForSig);
		}

		// Token: 0x060049DE RID: 18910 RVA: 0x0010B590 File Offset: 0x00109790
		public override Label BeginExceptionBlock()
		{
			return base.BeginExceptionBlock();
		}

		// Token: 0x060049DF RID: 18911 RVA: 0x0010B598 File Offset: 0x00109798
		public override void EndExceptionBlock()
		{
			base.EndExceptionBlock();
		}

		// Token: 0x060049E0 RID: 18912 RVA: 0x0010B5A0 File Offset: 0x001097A0
		public override void BeginExceptFilterBlock()
		{
			throw new NotSupportedException(Environment.GetResourceString("InvalidOperation_NotAllowedInDynamicMethod"));
		}

		// Token: 0x060049E1 RID: 18913 RVA: 0x0010B5B4 File Offset: 0x001097B4
		public override void BeginCatchBlock(Type exceptionType)
		{
			if (base.CurrExcStackCount == 0)
			{
				throw new NotSupportedException(Environment.GetResourceString("Argument_NotInExceptionBlock"));
			}
			__ExceptionInfo _ExceptionInfo = base.CurrExcStack[base.CurrExcStackCount - 1];
			RuntimeType runtimeType = exceptionType as RuntimeType;
			if (_ExceptionInfo.GetCurrentState() == 1)
			{
				if (exceptionType != null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_ShouldNotSpecifyExceptionType"));
				}
				this.Emit(OpCodes.Endfilter);
			}
			else
			{
				if (exceptionType == null)
				{
					throw new ArgumentNullException("exceptionType");
				}
				if (runtimeType == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
				}
				Label endLabel = _ExceptionInfo.GetEndLabel();
				this.Emit(OpCodes.Leave, endLabel);
				base.UpdateStackSize(OpCodes.Nop, 1);
			}
			_ExceptionInfo.MarkCatchAddr(this.ILOffset, exceptionType);
			_ExceptionInfo.m_filterAddr[_ExceptionInfo.m_currentCatch - 1] = this.GetTokenFor(runtimeType);
		}

		// Token: 0x060049E2 RID: 18914 RVA: 0x0010B68E File Offset: 0x0010988E
		public override void BeginFaultBlock()
		{
			throw new NotSupportedException(Environment.GetResourceString("InvalidOperation_NotAllowedInDynamicMethod"));
		}

		// Token: 0x060049E3 RID: 18915 RVA: 0x0010B69F File Offset: 0x0010989F
		public override void BeginFinallyBlock()
		{
			base.BeginFinallyBlock();
		}

		// Token: 0x060049E4 RID: 18916 RVA: 0x0010B6A7 File Offset: 0x001098A7
		public override void UsingNamespace(string ns)
		{
			throw new NotSupportedException(Environment.GetResourceString("InvalidOperation_NotAllowedInDynamicMethod"));
		}

		// Token: 0x060049E5 RID: 18917 RVA: 0x0010B6B8 File Offset: 0x001098B8
		public override void MarkSequencePoint(ISymbolDocumentWriter document, int startLine, int startColumn, int endLine, int endColumn)
		{
			throw new NotSupportedException(Environment.GetResourceString("InvalidOperation_NotAllowedInDynamicMethod"));
		}

		// Token: 0x060049E6 RID: 18918 RVA: 0x0010B6C9 File Offset: 0x001098C9
		public override void BeginScope()
		{
			throw new NotSupportedException(Environment.GetResourceString("InvalidOperation_NotAllowedInDynamicMethod"));
		}

		// Token: 0x060049E7 RID: 18919 RVA: 0x0010B6DA File Offset: 0x001098DA
		public override void EndScope()
		{
			throw new NotSupportedException(Environment.GetResourceString("InvalidOperation_NotAllowedInDynamicMethod"));
		}

		// Token: 0x060049E8 RID: 18920 RVA: 0x0010B6EC File Offset: 0x001098EC
		[SecurityCritical]
		private int GetMemberRefToken(MethodBase methodInfo, Type[] optionalParameterTypes)
		{
			if (optionalParameterTypes != null && (methodInfo.CallingConvention & CallingConventions.VarArgs) == (CallingConventions)0)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotAVarArgCallingConvention"));
			}
			RuntimeMethodInfo runtimeMethodInfo = methodInfo as RuntimeMethodInfo;
			DynamicMethod dynamicMethod = methodInfo as DynamicMethod;
			if (runtimeMethodInfo == null && dynamicMethod == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeMethodInfo"), "methodInfo");
			}
			ParameterInfo[] parametersNoCopy = methodInfo.GetParametersNoCopy();
			Type[] array;
			if (parametersNoCopy != null && parametersNoCopy.Length != 0)
			{
				array = new Type[parametersNoCopy.Length];
				for (int i = 0; i < parametersNoCopy.Length; i++)
				{
					array[i] = parametersNoCopy[i].ParameterType;
				}
			}
			else
			{
				array = null;
			}
			SignatureHelper memberRefSignature = this.GetMemberRefSignature(methodInfo.CallingConvention, MethodBuilder.GetMethodBaseReturnType(methodInfo), array, optionalParameterTypes);
			if (runtimeMethodInfo != null)
			{
				return this.GetTokenForVarArgMethod(runtimeMethodInfo, memberRefSignature);
			}
			return this.GetTokenForVarArgMethod(dynamicMethod, memberRefSignature);
		}

		// Token: 0x060049E9 RID: 18921 RVA: 0x0010B7B8 File Offset: 0x001099B8
		[SecurityCritical]
		internal override SignatureHelper GetMemberRefSignature(CallingConventions call, Type returnType, Type[] parameterTypes, Type[] optionalParameterTypes)
		{
			int num;
			if (parameterTypes == null)
			{
				num = 0;
			}
			else
			{
				num = parameterTypes.Length;
			}
			SignatureHelper methodSigHelper = SignatureHelper.GetMethodSigHelper(call, returnType);
			for (int i = 0; i < num; i++)
			{
				methodSigHelper.AddArgument(parameterTypes[i]);
			}
			if (optionalParameterTypes != null && optionalParameterTypes.Length != 0)
			{
				methodSigHelper.AddSentinel();
				for (int i = 0; i < optionalParameterTypes.Length; i++)
				{
					methodSigHelper.AddArgument(optionalParameterTypes[i]);
				}
			}
			return methodSigHelper;
		}

		// Token: 0x060049EA RID: 18922 RVA: 0x0010B816 File Offset: 0x00109A16
		internal override void RecordTokenFixup()
		{
		}

		// Token: 0x060049EB RID: 18923 RVA: 0x0010B818 File Offset: 0x00109A18
		private int GetTokenFor(RuntimeType rtType)
		{
			if (this.ProfileAPICheck && (rtType.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
				{
					rtType.FullName
				}));
			}
			return this.m_scope.GetTokenFor(rtType.TypeHandle);
		}

		// Token: 0x060049EC RID: 18924 RVA: 0x0010B868 File Offset: 0x00109A68
		private int GetTokenFor(RuntimeFieldInfo runtimeField)
		{
			if (this.ProfileAPICheck)
			{
				RtFieldInfo rtFieldInfo = runtimeField as RtFieldInfo;
				if (rtFieldInfo != null && (rtFieldInfo.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
					{
						rtFieldInfo.FullName
					}));
				}
			}
			return this.m_scope.GetTokenFor(runtimeField.FieldHandle);
		}

		// Token: 0x060049ED RID: 18925 RVA: 0x0010B8C8 File Offset: 0x00109AC8
		private int GetTokenFor(RuntimeFieldInfo runtimeField, RuntimeType rtType)
		{
			if (this.ProfileAPICheck)
			{
				RtFieldInfo rtFieldInfo = runtimeField as RtFieldInfo;
				if (rtFieldInfo != null && (rtFieldInfo.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
					{
						rtFieldInfo.FullName
					}));
				}
				if ((rtType.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
					{
						rtType.FullName
					}));
				}
			}
			return this.m_scope.GetTokenFor(runtimeField.FieldHandle, rtType.TypeHandle);
		}

		// Token: 0x060049EE RID: 18926 RVA: 0x0010B958 File Offset: 0x00109B58
		private int GetTokenFor(RuntimeConstructorInfo rtMeth)
		{
			if (this.ProfileAPICheck && (rtMeth.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
				{
					rtMeth.FullName
				}));
			}
			return this.m_scope.GetTokenFor(rtMeth.MethodHandle);
		}

		// Token: 0x060049EF RID: 18927 RVA: 0x0010B9A8 File Offset: 0x00109BA8
		private int GetTokenFor(RuntimeConstructorInfo rtMeth, RuntimeType rtType)
		{
			if (this.ProfileAPICheck)
			{
				if ((rtMeth.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
					{
						rtMeth.FullName
					}));
				}
				if ((rtType.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
					{
						rtType.FullName
					}));
				}
			}
			return this.m_scope.GetTokenFor(rtMeth.MethodHandle, rtType.TypeHandle);
		}

		// Token: 0x060049F0 RID: 18928 RVA: 0x0010BA28 File Offset: 0x00109C28
		private int GetTokenFor(RuntimeMethodInfo rtMeth)
		{
			if (this.ProfileAPICheck && (rtMeth.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
				{
					rtMeth.FullName
				}));
			}
			return this.m_scope.GetTokenFor(rtMeth.MethodHandle);
		}

		// Token: 0x060049F1 RID: 18929 RVA: 0x0010BA78 File Offset: 0x00109C78
		private int GetTokenFor(RuntimeMethodInfo rtMeth, RuntimeType rtType)
		{
			if (this.ProfileAPICheck)
			{
				if ((rtMeth.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
					{
						rtMeth.FullName
					}));
				}
				if ((rtType.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
					{
						rtType.FullName
					}));
				}
			}
			return this.m_scope.GetTokenFor(rtMeth.MethodHandle, rtType.TypeHandle);
		}

		// Token: 0x060049F2 RID: 18930 RVA: 0x0010BAF8 File Offset: 0x00109CF8
		private int GetTokenFor(DynamicMethod dm)
		{
			return this.m_scope.GetTokenFor(dm);
		}

		// Token: 0x060049F3 RID: 18931 RVA: 0x0010BB08 File Offset: 0x00109D08
		private int GetTokenForVarArgMethod(RuntimeMethodInfo rtMeth, SignatureHelper sig)
		{
			if (this.ProfileAPICheck && (rtMeth.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
				{
					rtMeth.FullName
				}));
			}
			VarArgMethod varArgMethod = new VarArgMethod(rtMeth, sig);
			return this.m_scope.GetTokenFor(varArgMethod);
		}

		// Token: 0x060049F4 RID: 18932 RVA: 0x0010BB5C File Offset: 0x00109D5C
		private int GetTokenForVarArgMethod(DynamicMethod dm, SignatureHelper sig)
		{
			VarArgMethod varArgMethod = new VarArgMethod(dm, sig);
			return this.m_scope.GetTokenFor(varArgMethod);
		}

		// Token: 0x060049F5 RID: 18933 RVA: 0x0010BB7D File Offset: 0x00109D7D
		private int GetTokenForString(string s)
		{
			return this.m_scope.GetTokenFor(s);
		}

		// Token: 0x060049F6 RID: 18934 RVA: 0x0010BB8B File Offset: 0x00109D8B
		private int GetTokenForSig(byte[] sig)
		{
			return this.m_scope.GetTokenFor(sig);
		}

		// Token: 0x04001E7E RID: 7806
		internal DynamicScope m_scope;

		// Token: 0x04001E7F RID: 7807
		private int m_methodSigToken;
	}
}
