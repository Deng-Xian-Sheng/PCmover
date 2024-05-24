using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Reflection.Emit
{
	// Token: 0x0200062F RID: 1583
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_ConstructorBuilder))]
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public sealed class ConstructorBuilder : ConstructorInfo, _ConstructorBuilder
	{
		// Token: 0x060049A7 RID: 18855 RVA: 0x0010AB1F File Offset: 0x00108D1F
		private ConstructorBuilder()
		{
		}

		// Token: 0x060049A8 RID: 18856 RVA: 0x0010AB28 File Offset: 0x00108D28
		[SecurityCritical]
		internal ConstructorBuilder(string name, MethodAttributes attributes, CallingConventions callingConvention, Type[] parameterTypes, Type[][] requiredCustomModifiers, Type[][] optionalCustomModifiers, ModuleBuilder mod, TypeBuilder type)
		{
			this.m_methodBuilder = new MethodBuilder(name, attributes, callingConvention, null, null, null, parameterTypes, requiredCustomModifiers, optionalCustomModifiers, mod, type, false);
			type.m_listMethods.Add(this.m_methodBuilder);
			int num;
			byte[] array = this.m_methodBuilder.GetMethodSignature().InternalGetSignature(out num);
			MethodToken token = this.m_methodBuilder.GetToken();
		}

		// Token: 0x060049A9 RID: 18857 RVA: 0x0010AB88 File Offset: 0x00108D88
		[SecurityCritical]
		internal ConstructorBuilder(string name, MethodAttributes attributes, CallingConventions callingConvention, Type[] parameterTypes, ModuleBuilder mod, TypeBuilder type) : this(name, attributes, callingConvention, parameterTypes, null, null, mod, type)
		{
		}

		// Token: 0x060049AA RID: 18858 RVA: 0x0010ABA6 File Offset: 0x00108DA6
		internal override Type[] GetParameterTypes()
		{
			return this.m_methodBuilder.GetParameterTypes();
		}

		// Token: 0x060049AB RID: 18859 RVA: 0x0010ABB3 File Offset: 0x00108DB3
		private TypeBuilder GetTypeBuilder()
		{
			return this.m_methodBuilder.GetTypeBuilder();
		}

		// Token: 0x060049AC RID: 18860 RVA: 0x0010ABC0 File Offset: 0x00108DC0
		internal ModuleBuilder GetModuleBuilder()
		{
			return this.GetTypeBuilder().GetModuleBuilder();
		}

		// Token: 0x060049AD RID: 18861 RVA: 0x0010ABCD File Offset: 0x00108DCD
		public override string ToString()
		{
			return this.m_methodBuilder.ToString();
		}

		// Token: 0x17000B7E RID: 2942
		// (get) Token: 0x060049AE RID: 18862 RVA: 0x0010ABDA File Offset: 0x00108DDA
		internal int MetadataTokenInternal
		{
			get
			{
				return this.m_methodBuilder.MetadataTokenInternal;
			}
		}

		// Token: 0x17000B7F RID: 2943
		// (get) Token: 0x060049AF RID: 18863 RVA: 0x0010ABE7 File Offset: 0x00108DE7
		public override Module Module
		{
			get
			{
				return this.m_methodBuilder.Module;
			}
		}

		// Token: 0x17000B80 RID: 2944
		// (get) Token: 0x060049B0 RID: 18864 RVA: 0x0010ABF4 File Offset: 0x00108DF4
		public override Type ReflectedType
		{
			get
			{
				return this.m_methodBuilder.ReflectedType;
			}
		}

		// Token: 0x17000B81 RID: 2945
		// (get) Token: 0x060049B1 RID: 18865 RVA: 0x0010AC01 File Offset: 0x00108E01
		public override Type DeclaringType
		{
			get
			{
				return this.m_methodBuilder.DeclaringType;
			}
		}

		// Token: 0x17000B82 RID: 2946
		// (get) Token: 0x060049B2 RID: 18866 RVA: 0x0010AC0E File Offset: 0x00108E0E
		public override string Name
		{
			get
			{
				return this.m_methodBuilder.Name;
			}
		}

		// Token: 0x060049B3 RID: 18867 RVA: 0x0010AC1B File Offset: 0x00108E1B
		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		// Token: 0x060049B4 RID: 18868 RVA: 0x0010AC2C File Offset: 0x00108E2C
		public override ParameterInfo[] GetParameters()
		{
			ConstructorInfo constructor = this.GetTypeBuilder().GetConstructor(this.m_methodBuilder.m_parameterTypes);
			return constructor.GetParameters();
		}

		// Token: 0x17000B83 RID: 2947
		// (get) Token: 0x060049B5 RID: 18869 RVA: 0x0010AC56 File Offset: 0x00108E56
		public override MethodAttributes Attributes
		{
			get
			{
				return this.m_methodBuilder.Attributes;
			}
		}

		// Token: 0x060049B6 RID: 18870 RVA: 0x0010AC63 File Offset: 0x00108E63
		public override MethodImplAttributes GetMethodImplementationFlags()
		{
			return this.m_methodBuilder.GetMethodImplementationFlags();
		}

		// Token: 0x17000B84 RID: 2948
		// (get) Token: 0x060049B7 RID: 18871 RVA: 0x0010AC70 File Offset: 0x00108E70
		public override RuntimeMethodHandle MethodHandle
		{
			get
			{
				return this.m_methodBuilder.MethodHandle;
			}
		}

		// Token: 0x060049B8 RID: 18872 RVA: 0x0010AC7D File Offset: 0x00108E7D
		public override object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		// Token: 0x060049B9 RID: 18873 RVA: 0x0010AC8E File Offset: 0x00108E8E
		public override object[] GetCustomAttributes(bool inherit)
		{
			return this.m_methodBuilder.GetCustomAttributes(inherit);
		}

		// Token: 0x060049BA RID: 18874 RVA: 0x0010AC9C File Offset: 0x00108E9C
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return this.m_methodBuilder.GetCustomAttributes(attributeType, inherit);
		}

		// Token: 0x060049BB RID: 18875 RVA: 0x0010ACAB File Offset: 0x00108EAB
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return this.m_methodBuilder.IsDefined(attributeType, inherit);
		}

		// Token: 0x060049BC RID: 18876 RVA: 0x0010ACBA File Offset: 0x00108EBA
		public MethodToken GetToken()
		{
			return this.m_methodBuilder.GetToken();
		}

		// Token: 0x060049BD RID: 18877 RVA: 0x0010ACC7 File Offset: 0x00108EC7
		public ParameterBuilder DefineParameter(int iSequence, ParameterAttributes attributes, string strParamName)
		{
			attributes &= ~ParameterAttributes.ReservedMask;
			return this.m_methodBuilder.DefineParameter(iSequence, attributes, strParamName);
		}

		// Token: 0x060049BE RID: 18878 RVA: 0x0010ACE0 File Offset: 0x00108EE0
		public void SetSymCustomAttribute(string name, byte[] data)
		{
			this.m_methodBuilder.SetSymCustomAttribute(name, data);
		}

		// Token: 0x060049BF RID: 18879 RVA: 0x0010ACEF File Offset: 0x00108EEF
		public ILGenerator GetILGenerator()
		{
			if (this.m_isDefaultConstructor)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_DefaultConstructorILGen"));
			}
			return this.m_methodBuilder.GetILGenerator();
		}

		// Token: 0x060049C0 RID: 18880 RVA: 0x0010AD14 File Offset: 0x00108F14
		public ILGenerator GetILGenerator(int streamSize)
		{
			if (this.m_isDefaultConstructor)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_DefaultConstructorILGen"));
			}
			return this.m_methodBuilder.GetILGenerator(streamSize);
		}

		// Token: 0x060049C1 RID: 18881 RVA: 0x0010AD3A File Offset: 0x00108F3A
		public void SetMethodBody(byte[] il, int maxStack, byte[] localSignature, IEnumerable<ExceptionHandler> exceptionHandlers, IEnumerable<int> tokenFixups)
		{
			if (this.m_isDefaultConstructor)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_DefaultConstructorDefineBody"));
			}
			this.m_methodBuilder.SetMethodBody(il, maxStack, localSignature, exceptionHandlers, tokenFixups);
		}

		// Token: 0x060049C2 RID: 18882 RVA: 0x0010AD68 File Offset: 0x00108F68
		[SecuritySafeCritical]
		public void AddDeclarativeSecurity(SecurityAction action, PermissionSet pset)
		{
			if (pset == null)
			{
				throw new ArgumentNullException("pset");
			}
			if (!Enum.IsDefined(typeof(SecurityAction), action) || action == SecurityAction.RequestMinimum || action == SecurityAction.RequestOptional || action == SecurityAction.RequestRefuse)
			{
				throw new ArgumentOutOfRangeException("action");
			}
			if (this.m_methodBuilder.IsTypeCreated())
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_TypeHasBeenCreated"));
			}
			byte[] array = pset.EncodeXml();
			TypeBuilder.AddDeclarativeSecurity(this.GetModuleBuilder().GetNativeHandle(), this.GetToken().Token, action, array, array.Length);
		}

		// Token: 0x17000B85 RID: 2949
		// (get) Token: 0x060049C3 RID: 18883 RVA: 0x0010ADFA File Offset: 0x00108FFA
		public override CallingConventions CallingConvention
		{
			get
			{
				if (this.DeclaringType.IsGenericType)
				{
					return CallingConventions.HasThis;
				}
				return CallingConventions.Standard;
			}
		}

		// Token: 0x060049C4 RID: 18884 RVA: 0x0010AE0D File Offset: 0x0010900D
		public Module GetModule()
		{
			return this.m_methodBuilder.GetModule();
		}

		// Token: 0x17000B86 RID: 2950
		// (get) Token: 0x060049C5 RID: 18885 RVA: 0x0010AE1A File Offset: 0x0010901A
		[Obsolete("This property has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		public Type ReturnType
		{
			get
			{
				return this.GetReturnType();
			}
		}

		// Token: 0x060049C6 RID: 18886 RVA: 0x0010AE22 File Offset: 0x00109022
		internal override Type GetReturnType()
		{
			return this.m_methodBuilder.ReturnType;
		}

		// Token: 0x17000B87 RID: 2951
		// (get) Token: 0x060049C7 RID: 18887 RVA: 0x0010AE2F File Offset: 0x0010902F
		public string Signature
		{
			get
			{
				return this.m_methodBuilder.Signature;
			}
		}

		// Token: 0x060049C8 RID: 18888 RVA: 0x0010AE3C File Offset: 0x0010903C
		[ComVisible(true)]
		public void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
		{
			this.m_methodBuilder.SetCustomAttribute(con, binaryAttribute);
		}

		// Token: 0x060049C9 RID: 18889 RVA: 0x0010AE4B File Offset: 0x0010904B
		public void SetCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			this.m_methodBuilder.SetCustomAttribute(customBuilder);
		}

		// Token: 0x060049CA RID: 18890 RVA: 0x0010AE59 File Offset: 0x00109059
		public void SetImplementationFlags(MethodImplAttributes attributes)
		{
			this.m_methodBuilder.SetImplementationFlags(attributes);
		}

		// Token: 0x17000B88 RID: 2952
		// (get) Token: 0x060049CB RID: 18891 RVA: 0x0010AE67 File Offset: 0x00109067
		// (set) Token: 0x060049CC RID: 18892 RVA: 0x0010AE74 File Offset: 0x00109074
		public bool InitLocals
		{
			get
			{
				return this.m_methodBuilder.InitLocals;
			}
			set
			{
				this.m_methodBuilder.InitLocals = value;
			}
		}

		// Token: 0x060049CD RID: 18893 RVA: 0x0010AE82 File Offset: 0x00109082
		void _ConstructorBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060049CE RID: 18894 RVA: 0x0010AE89 File Offset: 0x00109089
		void _ConstructorBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060049CF RID: 18895 RVA: 0x0010AE90 File Offset: 0x00109090
		void _ConstructorBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060049D0 RID: 18896 RVA: 0x0010AE97 File Offset: 0x00109097
		void _ConstructorBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04001E7C RID: 7804
		private readonly MethodBuilder m_methodBuilder;

		// Token: 0x04001E7D RID: 7805
		internal bool m_isDefaultConstructor;
	}
}
