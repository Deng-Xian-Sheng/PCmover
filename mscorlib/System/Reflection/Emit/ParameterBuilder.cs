using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Reflection.Emit
{
	// Token: 0x0200065A RID: 1626
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_ParameterBuilder))]
	[ComVisible(true)]
	public class ParameterBuilder : _ParameterBuilder
	{
		// Token: 0x06004CB1 RID: 19633 RVA: 0x00116C7C File Offset: 0x00114E7C
		[SecuritySafeCritical]
		[Obsolete("An alternate API is available: Emit the MarshalAs custom attribute instead. http://go.microsoft.com/fwlink/?linkid=14202")]
		public virtual void SetMarshal(UnmanagedMarshal unmanagedMarshal)
		{
			if (unmanagedMarshal == null)
			{
				throw new ArgumentNullException("unmanagedMarshal");
			}
			byte[] array = unmanagedMarshal.InternalGetBytes();
			TypeBuilder.SetFieldMarshal(this.m_methodBuilder.GetModuleBuilder().GetNativeHandle(), this.m_pdToken.Token, array, array.Length);
		}

		// Token: 0x06004CB2 RID: 19634 RVA: 0x00116CC4 File Offset: 0x00114EC4
		[SecuritySafeCritical]
		public virtual void SetConstant(object defaultValue)
		{
			TypeBuilder.SetConstantValue(this.m_methodBuilder.GetModuleBuilder(), this.m_pdToken.Token, (this.m_iPosition == 0) ? this.m_methodBuilder.ReturnType : this.m_methodBuilder.m_parameterTypes[this.m_iPosition - 1], defaultValue);
		}

		// Token: 0x06004CB3 RID: 19635 RVA: 0x00116D18 File Offset: 0x00114F18
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
			TypeBuilder.DefineCustomAttribute(this.m_methodBuilder.GetModuleBuilder(), this.m_pdToken.Token, ((ModuleBuilder)this.m_methodBuilder.GetModule()).GetConstructorToken(con).Token, binaryAttribute, false, false);
		}

		// Token: 0x06004CB4 RID: 19636 RVA: 0x00116D83 File Offset: 0x00114F83
		[SecuritySafeCritical]
		public void SetCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			if (customBuilder == null)
			{
				throw new ArgumentNullException("customBuilder");
			}
			customBuilder.CreateCustomAttribute((ModuleBuilder)this.m_methodBuilder.GetModule(), this.m_pdToken.Token);
		}

		// Token: 0x06004CB5 RID: 19637 RVA: 0x00116DB4 File Offset: 0x00114FB4
		private ParameterBuilder()
		{
		}

		// Token: 0x06004CB6 RID: 19638 RVA: 0x00116DBC File Offset: 0x00114FBC
		[SecurityCritical]
		internal ParameterBuilder(MethodBuilder methodBuilder, int sequence, ParameterAttributes attributes, string strParamName)
		{
			this.m_iPosition = sequence;
			this.m_strParamName = strParamName;
			this.m_methodBuilder = methodBuilder;
			this.m_strParamName = strParamName;
			this.m_attributes = attributes;
			this.m_pdToken = new ParameterToken(TypeBuilder.SetParamInfo(this.m_methodBuilder.GetModuleBuilder().GetNativeHandle(), this.m_methodBuilder.GetToken().Token, sequence, attributes, strParamName));
		}

		// Token: 0x06004CB7 RID: 19639 RVA: 0x00116E2B File Offset: 0x0011502B
		public virtual ParameterToken GetToken()
		{
			return this.m_pdToken;
		}

		// Token: 0x06004CB8 RID: 19640 RVA: 0x00116E33 File Offset: 0x00115033
		void _ParameterBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004CB9 RID: 19641 RVA: 0x00116E3A File Offset: 0x0011503A
		void _ParameterBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004CBA RID: 19642 RVA: 0x00116E41 File Offset: 0x00115041
		void _ParameterBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004CBB RID: 19643 RVA: 0x00116E48 File Offset: 0x00115048
		void _ParameterBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000C02 RID: 3074
		// (get) Token: 0x06004CBC RID: 19644 RVA: 0x00116E4F File Offset: 0x0011504F
		internal int MetadataTokenInternal
		{
			get
			{
				return this.m_pdToken.Token;
			}
		}

		// Token: 0x17000C03 RID: 3075
		// (get) Token: 0x06004CBD RID: 19645 RVA: 0x00116E5C File Offset: 0x0011505C
		public virtual string Name
		{
			get
			{
				return this.m_strParamName;
			}
		}

		// Token: 0x17000C04 RID: 3076
		// (get) Token: 0x06004CBE RID: 19646 RVA: 0x00116E64 File Offset: 0x00115064
		public virtual int Position
		{
			get
			{
				return this.m_iPosition;
			}
		}

		// Token: 0x17000C05 RID: 3077
		// (get) Token: 0x06004CBF RID: 19647 RVA: 0x00116E6C File Offset: 0x0011506C
		public virtual int Attributes
		{
			get
			{
				return (int)this.m_attributes;
			}
		}

		// Token: 0x17000C06 RID: 3078
		// (get) Token: 0x06004CC0 RID: 19648 RVA: 0x00116E74 File Offset: 0x00115074
		public bool IsIn
		{
			get
			{
				return (this.m_attributes & ParameterAttributes.In) > ParameterAttributes.None;
			}
		}

		// Token: 0x17000C07 RID: 3079
		// (get) Token: 0x06004CC1 RID: 19649 RVA: 0x00116E81 File Offset: 0x00115081
		public bool IsOut
		{
			get
			{
				return (this.m_attributes & ParameterAttributes.Out) > ParameterAttributes.None;
			}
		}

		// Token: 0x17000C08 RID: 3080
		// (get) Token: 0x06004CC2 RID: 19650 RVA: 0x00116E8E File Offset: 0x0011508E
		public bool IsOptional
		{
			get
			{
				return (this.m_attributes & ParameterAttributes.Optional) > ParameterAttributes.None;
			}
		}

		// Token: 0x04002183 RID: 8579
		private string m_strParamName;

		// Token: 0x04002184 RID: 8580
		private int m_iPosition;

		// Token: 0x04002185 RID: 8581
		private ParameterAttributes m_attributes;

		// Token: 0x04002186 RID: 8582
		private MethodBuilder m_methodBuilder;

		// Token: 0x04002187 RID: 8583
		private ParameterToken m_pdToken;
	}
}
