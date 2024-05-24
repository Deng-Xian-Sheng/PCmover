using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Reflection.Emit
{
	// Token: 0x0200065C RID: 1628
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_PropertyBuilder))]
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public sealed class PropertyBuilder : PropertyInfo, _PropertyBuilder
	{
		// Token: 0x06004CCB RID: 19659 RVA: 0x00116EF5 File Offset: 0x001150F5
		private PropertyBuilder()
		{
		}

		// Token: 0x06004CCC RID: 19660 RVA: 0x00116F00 File Offset: 0x00115100
		internal PropertyBuilder(ModuleBuilder mod, string name, SignatureHelper sig, PropertyAttributes attr, Type returnType, PropertyToken prToken, TypeBuilder containingType)
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
				throw new ArgumentException(Environment.GetResourceString("Argument_IllegalName"), "name");
			}
			this.m_name = name;
			this.m_moduleBuilder = mod;
			this.m_signature = sig;
			this.m_attributes = attr;
			this.m_returnType = returnType;
			this.m_prToken = prToken;
			this.m_tkProperty = prToken.Token;
			this.m_containingType = containingType;
		}

		// Token: 0x06004CCD RID: 19661 RVA: 0x00116F9E File Offset: 0x0011519E
		[SecuritySafeCritical]
		public void SetConstant(object defaultValue)
		{
			this.m_containingType.ThrowIfCreated();
			TypeBuilder.SetConstantValue(this.m_moduleBuilder, this.m_prToken.Token, this.m_returnType, defaultValue);
		}

		// Token: 0x17000C0A RID: 3082
		// (get) Token: 0x06004CCE RID: 19662 RVA: 0x00116FC8 File Offset: 0x001151C8
		public PropertyToken PropertyToken
		{
			get
			{
				return this.m_prToken;
			}
		}

		// Token: 0x17000C0B RID: 3083
		// (get) Token: 0x06004CCF RID: 19663 RVA: 0x00116FD0 File Offset: 0x001151D0
		internal int MetadataTokenInternal
		{
			get
			{
				return this.m_tkProperty;
			}
		}

		// Token: 0x17000C0C RID: 3084
		// (get) Token: 0x06004CD0 RID: 19664 RVA: 0x00116FD8 File Offset: 0x001151D8
		public override Module Module
		{
			get
			{
				return this.m_containingType.Module;
			}
		}

		// Token: 0x06004CD1 RID: 19665 RVA: 0x00116FE8 File Offset: 0x001151E8
		[SecurityCritical]
		private void SetMethodSemantics(MethodBuilder mdBuilder, MethodSemanticsAttributes semantics)
		{
			if (mdBuilder == null)
			{
				throw new ArgumentNullException("mdBuilder");
			}
			this.m_containingType.ThrowIfCreated();
			TypeBuilder.DefineMethodSemantics(this.m_moduleBuilder.GetNativeHandle(), this.m_prToken.Token, semantics, mdBuilder.GetToken().Token);
		}

		// Token: 0x06004CD2 RID: 19666 RVA: 0x0011703E File Offset: 0x0011523E
		[SecuritySafeCritical]
		public void SetGetMethod(MethodBuilder mdBuilder)
		{
			this.SetMethodSemantics(mdBuilder, MethodSemanticsAttributes.Getter);
			this.m_getMethod = mdBuilder;
		}

		// Token: 0x06004CD3 RID: 19667 RVA: 0x0011704F File Offset: 0x0011524F
		[SecuritySafeCritical]
		public void SetSetMethod(MethodBuilder mdBuilder)
		{
			this.SetMethodSemantics(mdBuilder, MethodSemanticsAttributes.Setter);
			this.m_setMethod = mdBuilder;
		}

		// Token: 0x06004CD4 RID: 19668 RVA: 0x00117060 File Offset: 0x00115260
		[SecuritySafeCritical]
		public void AddOtherMethod(MethodBuilder mdBuilder)
		{
			this.SetMethodSemantics(mdBuilder, MethodSemanticsAttributes.Other);
		}

		// Token: 0x06004CD5 RID: 19669 RVA: 0x0011706C File Offset: 0x0011526C
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
			this.m_containingType.ThrowIfCreated();
			TypeBuilder.DefineCustomAttribute(this.m_moduleBuilder, this.m_prToken.Token, this.m_moduleBuilder.GetConstructorToken(con).Token, binaryAttribute, false, false);
		}

		// Token: 0x06004CD6 RID: 19670 RVA: 0x001170D3 File Offset: 0x001152D3
		[SecuritySafeCritical]
		public void SetCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			if (customBuilder == null)
			{
				throw new ArgumentNullException("customBuilder");
			}
			this.m_containingType.ThrowIfCreated();
			customBuilder.CreateCustomAttribute(this.m_moduleBuilder, this.m_prToken.Token);
		}

		// Token: 0x06004CD7 RID: 19671 RVA: 0x00117105 File Offset: 0x00115305
		public override object GetValue(object obj, object[] index)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		// Token: 0x06004CD8 RID: 19672 RVA: 0x00117116 File Offset: 0x00115316
		public override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		// Token: 0x06004CD9 RID: 19673 RVA: 0x00117127 File Offset: 0x00115327
		public override void SetValue(object obj, object value, object[] index)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		// Token: 0x06004CDA RID: 19674 RVA: 0x00117138 File Offset: 0x00115338
		public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		// Token: 0x06004CDB RID: 19675 RVA: 0x00117149 File Offset: 0x00115349
		public override MethodInfo[] GetAccessors(bool nonPublic)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		// Token: 0x06004CDC RID: 19676 RVA: 0x0011715A File Offset: 0x0011535A
		public override MethodInfo GetGetMethod(bool nonPublic)
		{
			if (nonPublic || this.m_getMethod == null)
			{
				return this.m_getMethod;
			}
			if ((this.m_getMethod.Attributes & MethodAttributes.Public) == MethodAttributes.Public)
			{
				return this.m_getMethod;
			}
			return null;
		}

		// Token: 0x06004CDD RID: 19677 RVA: 0x0011718C File Offset: 0x0011538C
		public override MethodInfo GetSetMethod(bool nonPublic)
		{
			if (nonPublic || this.m_setMethod == null)
			{
				return this.m_setMethod;
			}
			if ((this.m_setMethod.Attributes & MethodAttributes.Public) == MethodAttributes.Public)
			{
				return this.m_setMethod;
			}
			return null;
		}

		// Token: 0x06004CDE RID: 19678 RVA: 0x001171BE File Offset: 0x001153BE
		public override ParameterInfo[] GetIndexParameters()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		// Token: 0x17000C0D RID: 3085
		// (get) Token: 0x06004CDF RID: 19679 RVA: 0x001171CF File Offset: 0x001153CF
		public override Type PropertyType
		{
			get
			{
				return this.m_returnType;
			}
		}

		// Token: 0x17000C0E RID: 3086
		// (get) Token: 0x06004CE0 RID: 19680 RVA: 0x001171D7 File Offset: 0x001153D7
		public override PropertyAttributes Attributes
		{
			get
			{
				return this.m_attributes;
			}
		}

		// Token: 0x17000C0F RID: 3087
		// (get) Token: 0x06004CE1 RID: 19681 RVA: 0x001171DF File Offset: 0x001153DF
		public override bool CanRead
		{
			get
			{
				return this.m_getMethod != null;
			}
		}

		// Token: 0x17000C10 RID: 3088
		// (get) Token: 0x06004CE2 RID: 19682 RVA: 0x001171F2 File Offset: 0x001153F2
		public override bool CanWrite
		{
			get
			{
				return this.m_setMethod != null;
			}
		}

		// Token: 0x06004CE3 RID: 19683 RVA: 0x00117205 File Offset: 0x00115405
		public override object[] GetCustomAttributes(bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		// Token: 0x06004CE4 RID: 19684 RVA: 0x00117216 File Offset: 0x00115416
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		// Token: 0x06004CE5 RID: 19685 RVA: 0x00117227 File Offset: 0x00115427
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		// Token: 0x06004CE6 RID: 19686 RVA: 0x00117238 File Offset: 0x00115438
		void _PropertyBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004CE7 RID: 19687 RVA: 0x0011723F File Offset: 0x0011543F
		void _PropertyBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004CE8 RID: 19688 RVA: 0x00117246 File Offset: 0x00115446
		void _PropertyBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004CE9 RID: 19689 RVA: 0x0011724D File Offset: 0x0011544D
		void _PropertyBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000C11 RID: 3089
		// (get) Token: 0x06004CEA RID: 19690 RVA: 0x00117254 File Offset: 0x00115454
		public override string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x17000C12 RID: 3090
		// (get) Token: 0x06004CEB RID: 19691 RVA: 0x0011725C File Offset: 0x0011545C
		public override Type DeclaringType
		{
			get
			{
				return this.m_containingType;
			}
		}

		// Token: 0x17000C13 RID: 3091
		// (get) Token: 0x06004CEC RID: 19692 RVA: 0x00117264 File Offset: 0x00115464
		public override Type ReflectedType
		{
			get
			{
				return this.m_containingType;
			}
		}

		// Token: 0x0400218A RID: 8586
		private string m_name;

		// Token: 0x0400218B RID: 8587
		private PropertyToken m_prToken;

		// Token: 0x0400218C RID: 8588
		private int m_tkProperty;

		// Token: 0x0400218D RID: 8589
		private ModuleBuilder m_moduleBuilder;

		// Token: 0x0400218E RID: 8590
		private SignatureHelper m_signature;

		// Token: 0x0400218F RID: 8591
		private PropertyAttributes m_attributes;

		// Token: 0x04002190 RID: 8592
		private Type m_returnType;

		// Token: 0x04002191 RID: 8593
		private MethodInfo m_getMethod;

		// Token: 0x04002192 RID: 8594
		private MethodInfo m_setMethod;

		// Token: 0x04002193 RID: 8595
		private TypeBuilder m_containingType;
	}
}
