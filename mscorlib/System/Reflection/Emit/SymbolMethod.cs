using System;
using System.Globalization;
using System.Security;

namespace System.Reflection.Emit
{
	// Token: 0x0200064B RID: 1611
	internal sealed class SymbolMethod : MethodInfo
	{
		// Token: 0x06004BCF RID: 19407 RVA: 0x001121F4 File Offset: 0x001103F4
		[SecurityCritical]
		internal SymbolMethod(ModuleBuilder mod, MethodToken token, Type arrayClass, string methodName, CallingConventions callingConvention, Type returnType, Type[] parameterTypes)
		{
			this.m_mdMethod = token;
			this.m_returnType = returnType;
			if (parameterTypes != null)
			{
				this.m_parameterTypes = new Type[parameterTypes.Length];
				Array.Copy(parameterTypes, this.m_parameterTypes, parameterTypes.Length);
			}
			else
			{
				this.m_parameterTypes = EmptyArray<Type>.Value;
			}
			this.m_module = mod;
			this.m_containingType = arrayClass;
			this.m_name = methodName;
			this.m_callingConvention = callingConvention;
			this.m_signature = SignatureHelper.GetMethodSigHelper(mod, callingConvention, returnType, null, null, parameterTypes, null, null);
		}

		// Token: 0x06004BD0 RID: 19408 RVA: 0x0011227B File Offset: 0x0011047B
		internal override Type[] GetParameterTypes()
		{
			return this.m_parameterTypes;
		}

		// Token: 0x06004BD1 RID: 19409 RVA: 0x00112283 File Offset: 0x00110483
		internal MethodToken GetToken(ModuleBuilder mod)
		{
			return mod.GetArrayMethodToken(this.m_containingType, this.m_name, this.m_callingConvention, this.m_returnType, this.m_parameterTypes);
		}

		// Token: 0x17000BE5 RID: 3045
		// (get) Token: 0x06004BD2 RID: 19410 RVA: 0x001122A9 File Offset: 0x001104A9
		public override Module Module
		{
			get
			{
				return this.m_module;
			}
		}

		// Token: 0x17000BE6 RID: 3046
		// (get) Token: 0x06004BD3 RID: 19411 RVA: 0x001122B1 File Offset: 0x001104B1
		public override Type ReflectedType
		{
			get
			{
				return this.m_containingType;
			}
		}

		// Token: 0x17000BE7 RID: 3047
		// (get) Token: 0x06004BD4 RID: 19412 RVA: 0x001122B9 File Offset: 0x001104B9
		public override string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x17000BE8 RID: 3048
		// (get) Token: 0x06004BD5 RID: 19413 RVA: 0x001122C1 File Offset: 0x001104C1
		public override Type DeclaringType
		{
			get
			{
				return this.m_containingType;
			}
		}

		// Token: 0x06004BD6 RID: 19414 RVA: 0x001122C9 File Offset: 0x001104C9
		public override ParameterInfo[] GetParameters()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SymbolMethod"));
		}

		// Token: 0x06004BD7 RID: 19415 RVA: 0x001122DA File Offset: 0x001104DA
		public override MethodImplAttributes GetMethodImplementationFlags()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SymbolMethod"));
		}

		// Token: 0x17000BE9 RID: 3049
		// (get) Token: 0x06004BD8 RID: 19416 RVA: 0x001122EB File Offset: 0x001104EB
		public override MethodAttributes Attributes
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_SymbolMethod"));
			}
		}

		// Token: 0x17000BEA RID: 3050
		// (get) Token: 0x06004BD9 RID: 19417 RVA: 0x001122FC File Offset: 0x001104FC
		public override CallingConventions CallingConvention
		{
			get
			{
				return this.m_callingConvention;
			}
		}

		// Token: 0x17000BEB RID: 3051
		// (get) Token: 0x06004BDA RID: 19418 RVA: 0x00112304 File Offset: 0x00110504
		public override RuntimeMethodHandle MethodHandle
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_SymbolMethod"));
			}
		}

		// Token: 0x17000BEC RID: 3052
		// (get) Token: 0x06004BDB RID: 19419 RVA: 0x00112315 File Offset: 0x00110515
		public override Type ReturnType
		{
			get
			{
				return this.m_returnType;
			}
		}

		// Token: 0x17000BED RID: 3053
		// (get) Token: 0x06004BDC RID: 19420 RVA: 0x0011231D File Offset: 0x0011051D
		public override ICustomAttributeProvider ReturnTypeCustomAttributes
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06004BDD RID: 19421 RVA: 0x00112320 File Offset: 0x00110520
		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SymbolMethod"));
		}

		// Token: 0x06004BDE RID: 19422 RVA: 0x00112331 File Offset: 0x00110531
		public override MethodInfo GetBaseDefinition()
		{
			return this;
		}

		// Token: 0x06004BDF RID: 19423 RVA: 0x00112334 File Offset: 0x00110534
		public override object[] GetCustomAttributes(bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SymbolMethod"));
		}

		// Token: 0x06004BE0 RID: 19424 RVA: 0x00112345 File Offset: 0x00110545
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SymbolMethod"));
		}

		// Token: 0x06004BE1 RID: 19425 RVA: 0x00112356 File Offset: 0x00110556
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SymbolMethod"));
		}

		// Token: 0x06004BE2 RID: 19426 RVA: 0x00112367 File Offset: 0x00110567
		public Module GetModule()
		{
			return this.m_module;
		}

		// Token: 0x06004BE3 RID: 19427 RVA: 0x0011236F File Offset: 0x0011056F
		public MethodToken GetToken()
		{
			return this.m_mdMethod;
		}

		// Token: 0x04001F3F RID: 7999
		private ModuleBuilder m_module;

		// Token: 0x04001F40 RID: 8000
		private Type m_containingType;

		// Token: 0x04001F41 RID: 8001
		private string m_name;

		// Token: 0x04001F42 RID: 8002
		private CallingConventions m_callingConvention;

		// Token: 0x04001F43 RID: 8003
		private Type m_returnType;

		// Token: 0x04001F44 RID: 8004
		private MethodToken m_mdMethod;

		// Token: 0x04001F45 RID: 8005
		private Type[] m_parameterTypes;

		// Token: 0x04001F46 RID: 8006
		private SignatureHelper m_signature;
	}
}
