using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x02000664 RID: 1636
	[ComVisible(true)]
	public sealed class GenericTypeParameterBuilder : TypeInfo
	{
		// Token: 0x06004E29 RID: 20009 RVA: 0x0011B43D File Offset: 0x0011963D
		public override bool IsAssignableFrom(TypeInfo typeInfo)
		{
			return !(typeInfo == null) && this.IsAssignableFrom(typeInfo.AsType());
		}

		// Token: 0x06004E2A RID: 20010 RVA: 0x0011B456 File Offset: 0x00119656
		internal GenericTypeParameterBuilder(TypeBuilder type)
		{
			this.m_type = type;
		}

		// Token: 0x06004E2B RID: 20011 RVA: 0x0011B465 File Offset: 0x00119665
		public override string ToString()
		{
			return this.m_type.Name;
		}

		// Token: 0x06004E2C RID: 20012 RVA: 0x0011B474 File Offset: 0x00119674
		public override bool Equals(object o)
		{
			GenericTypeParameterBuilder genericTypeParameterBuilder = o as GenericTypeParameterBuilder;
			return !(genericTypeParameterBuilder == null) && genericTypeParameterBuilder.m_type == this.m_type;
		}

		// Token: 0x06004E2D RID: 20013 RVA: 0x0011B4A1 File Offset: 0x001196A1
		public override int GetHashCode()
		{
			return this.m_type.GetHashCode();
		}

		// Token: 0x17000C47 RID: 3143
		// (get) Token: 0x06004E2E RID: 20014 RVA: 0x0011B4AE File Offset: 0x001196AE
		public override Type DeclaringType
		{
			get
			{
				return this.m_type.DeclaringType;
			}
		}

		// Token: 0x17000C48 RID: 3144
		// (get) Token: 0x06004E2F RID: 20015 RVA: 0x0011B4BB File Offset: 0x001196BB
		public override Type ReflectedType
		{
			get
			{
				return this.m_type.ReflectedType;
			}
		}

		// Token: 0x17000C49 RID: 3145
		// (get) Token: 0x06004E30 RID: 20016 RVA: 0x0011B4C8 File Offset: 0x001196C8
		public override string Name
		{
			get
			{
				return this.m_type.Name;
			}
		}

		// Token: 0x17000C4A RID: 3146
		// (get) Token: 0x06004E31 RID: 20017 RVA: 0x0011B4D5 File Offset: 0x001196D5
		public override Module Module
		{
			get
			{
				return this.m_type.Module;
			}
		}

		// Token: 0x17000C4B RID: 3147
		// (get) Token: 0x06004E32 RID: 20018 RVA: 0x0011B4E2 File Offset: 0x001196E2
		internal int MetadataTokenInternal
		{
			get
			{
				return this.m_type.MetadataTokenInternal;
			}
		}

		// Token: 0x06004E33 RID: 20019 RVA: 0x0011B4EF File Offset: 0x001196EF
		public override Type MakePointerType()
		{
			return SymbolType.FormCompoundType("*".ToCharArray(), this, 0);
		}

		// Token: 0x06004E34 RID: 20020 RVA: 0x0011B502 File Offset: 0x00119702
		public override Type MakeByRefType()
		{
			return SymbolType.FormCompoundType("&".ToCharArray(), this, 0);
		}

		// Token: 0x06004E35 RID: 20021 RVA: 0x0011B515 File Offset: 0x00119715
		public override Type MakeArrayType()
		{
			return SymbolType.FormCompoundType("[]".ToCharArray(), this, 0);
		}

		// Token: 0x06004E36 RID: 20022 RVA: 0x0011B528 File Offset: 0x00119728
		public override Type MakeArrayType(int rank)
		{
			if (rank <= 0)
			{
				throw new IndexOutOfRangeException();
			}
			string text = "";
			if (rank == 1)
			{
				text = "*";
			}
			else
			{
				for (int i = 1; i < rank; i++)
				{
					text += ",";
				}
			}
			string text2 = string.Format(CultureInfo.InvariantCulture, "[{0}]", text);
			return SymbolType.FormCompoundType(text2.ToCharArray(), this, 0) as SymbolType;
		}

		// Token: 0x17000C4C RID: 3148
		// (get) Token: 0x06004E37 RID: 20023 RVA: 0x0011B58E File Offset: 0x0011978E
		public override Guid GUID
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x06004E38 RID: 20024 RVA: 0x0011B595 File Offset: 0x00119795
		public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000C4D RID: 3149
		// (get) Token: 0x06004E39 RID: 20025 RVA: 0x0011B59C File Offset: 0x0011979C
		public override Assembly Assembly
		{
			get
			{
				return this.m_type.Assembly;
			}
		}

		// Token: 0x17000C4E RID: 3150
		// (get) Token: 0x06004E3A RID: 20026 RVA: 0x0011B5A9 File Offset: 0x001197A9
		public override RuntimeTypeHandle TypeHandle
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000C4F RID: 3151
		// (get) Token: 0x06004E3B RID: 20027 RVA: 0x0011B5B0 File Offset: 0x001197B0
		public override string FullName
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000C50 RID: 3152
		// (get) Token: 0x06004E3C RID: 20028 RVA: 0x0011B5B3 File Offset: 0x001197B3
		public override string Namespace
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000C51 RID: 3153
		// (get) Token: 0x06004E3D RID: 20029 RVA: 0x0011B5B6 File Offset: 0x001197B6
		public override string AssemblyQualifiedName
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000C52 RID: 3154
		// (get) Token: 0x06004E3E RID: 20030 RVA: 0x0011B5B9 File Offset: 0x001197B9
		public override Type BaseType
		{
			get
			{
				return this.m_type.BaseType;
			}
		}

		// Token: 0x06004E3F RID: 20031 RVA: 0x0011B5C6 File Offset: 0x001197C6
		protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E40 RID: 20032 RVA: 0x0011B5CD File Offset: 0x001197CD
		[ComVisible(true)]
		public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E41 RID: 20033 RVA: 0x0011B5D4 File Offset: 0x001197D4
		protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E42 RID: 20034 RVA: 0x0011B5DB File Offset: 0x001197DB
		public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E43 RID: 20035 RVA: 0x0011B5E2 File Offset: 0x001197E2
		public override FieldInfo GetField(string name, BindingFlags bindingAttr)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E44 RID: 20036 RVA: 0x0011B5E9 File Offset: 0x001197E9
		public override FieldInfo[] GetFields(BindingFlags bindingAttr)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E45 RID: 20037 RVA: 0x0011B5F0 File Offset: 0x001197F0
		public override Type GetInterface(string name, bool ignoreCase)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E46 RID: 20038 RVA: 0x0011B5F7 File Offset: 0x001197F7
		public override Type[] GetInterfaces()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E47 RID: 20039 RVA: 0x0011B5FE File Offset: 0x001197FE
		public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E48 RID: 20040 RVA: 0x0011B605 File Offset: 0x00119805
		public override EventInfo[] GetEvents()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E49 RID: 20041 RVA: 0x0011B60C File Offset: 0x0011980C
		protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E4A RID: 20042 RVA: 0x0011B613 File Offset: 0x00119813
		public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E4B RID: 20043 RVA: 0x0011B61A File Offset: 0x0011981A
		public override Type[] GetNestedTypes(BindingFlags bindingAttr)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E4C RID: 20044 RVA: 0x0011B621 File Offset: 0x00119821
		public override Type GetNestedType(string name, BindingFlags bindingAttr)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E4D RID: 20045 RVA: 0x0011B628 File Offset: 0x00119828
		public override MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E4E RID: 20046 RVA: 0x0011B62F File Offset: 0x0011982F
		[ComVisible(true)]
		public override InterfaceMapping GetInterfaceMap(Type interfaceType)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E4F RID: 20047 RVA: 0x0011B636 File Offset: 0x00119836
		public override EventInfo[] GetEvents(BindingFlags bindingAttr)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E50 RID: 20048 RVA: 0x0011B63D File Offset: 0x0011983D
		public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E51 RID: 20049 RVA: 0x0011B644 File Offset: 0x00119844
		protected override TypeAttributes GetAttributeFlagsImpl()
		{
			return TypeAttributes.Public;
		}

		// Token: 0x06004E52 RID: 20050 RVA: 0x0011B647 File Offset: 0x00119847
		protected override bool IsArrayImpl()
		{
			return false;
		}

		// Token: 0x06004E53 RID: 20051 RVA: 0x0011B64A File Offset: 0x0011984A
		protected override bool IsByRefImpl()
		{
			return false;
		}

		// Token: 0x06004E54 RID: 20052 RVA: 0x0011B64D File Offset: 0x0011984D
		protected override bool IsPointerImpl()
		{
			return false;
		}

		// Token: 0x06004E55 RID: 20053 RVA: 0x0011B650 File Offset: 0x00119850
		protected override bool IsPrimitiveImpl()
		{
			return false;
		}

		// Token: 0x06004E56 RID: 20054 RVA: 0x0011B653 File Offset: 0x00119853
		protected override bool IsCOMObjectImpl()
		{
			return false;
		}

		// Token: 0x06004E57 RID: 20055 RVA: 0x0011B656 File Offset: 0x00119856
		public override Type GetElementType()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E58 RID: 20056 RVA: 0x0011B65D File Offset: 0x0011985D
		protected override bool HasElementTypeImpl()
		{
			return false;
		}

		// Token: 0x17000C53 RID: 3155
		// (get) Token: 0x06004E59 RID: 20057 RVA: 0x0011B660 File Offset: 0x00119860
		public override Type UnderlyingSystemType
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06004E5A RID: 20058 RVA: 0x0011B663 File Offset: 0x00119863
		public override Type[] GetGenericArguments()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x17000C54 RID: 3156
		// (get) Token: 0x06004E5B RID: 20059 RVA: 0x0011B66A File Offset: 0x0011986A
		public override bool IsGenericTypeDefinition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000C55 RID: 3157
		// (get) Token: 0x06004E5C RID: 20060 RVA: 0x0011B66D File Offset: 0x0011986D
		public override bool IsGenericType
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000C56 RID: 3158
		// (get) Token: 0x06004E5D RID: 20061 RVA: 0x0011B670 File Offset: 0x00119870
		public override bool IsGenericParameter
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000C57 RID: 3159
		// (get) Token: 0x06004E5E RID: 20062 RVA: 0x0011B673 File Offset: 0x00119873
		public override bool IsConstructedGenericType
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000C58 RID: 3160
		// (get) Token: 0x06004E5F RID: 20063 RVA: 0x0011B676 File Offset: 0x00119876
		public override int GenericParameterPosition
		{
			get
			{
				return this.m_type.GenericParameterPosition;
			}
		}

		// Token: 0x17000C59 RID: 3161
		// (get) Token: 0x06004E60 RID: 20064 RVA: 0x0011B683 File Offset: 0x00119883
		public override bool ContainsGenericParameters
		{
			get
			{
				return this.m_type.ContainsGenericParameters;
			}
		}

		// Token: 0x17000C5A RID: 3162
		// (get) Token: 0x06004E61 RID: 20065 RVA: 0x0011B690 File Offset: 0x00119890
		public override GenericParameterAttributes GenericParameterAttributes
		{
			get
			{
				return this.m_type.GenericParameterAttributes;
			}
		}

		// Token: 0x17000C5B RID: 3163
		// (get) Token: 0x06004E62 RID: 20066 RVA: 0x0011B69D File Offset: 0x0011989D
		public override MethodBase DeclaringMethod
		{
			get
			{
				return this.m_type.DeclaringMethod;
			}
		}

		// Token: 0x06004E63 RID: 20067 RVA: 0x0011B6AA File Offset: 0x001198AA
		public override Type GetGenericTypeDefinition()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06004E64 RID: 20068 RVA: 0x0011B6B1 File Offset: 0x001198B1
		public override Type MakeGenericType(params Type[] typeArguments)
		{
			throw new InvalidOperationException(Environment.GetResourceString("Arg_NotGenericTypeDefinition"));
		}

		// Token: 0x06004E65 RID: 20069 RVA: 0x0011B6C2 File Offset: 0x001198C2
		protected override bool IsValueTypeImpl()
		{
			return false;
		}

		// Token: 0x06004E66 RID: 20070 RVA: 0x0011B6C5 File Offset: 0x001198C5
		public override bool IsAssignableFrom(Type c)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E67 RID: 20071 RVA: 0x0011B6CC File Offset: 0x001198CC
		[ComVisible(true)]
		public override bool IsSubclassOf(Type c)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E68 RID: 20072 RVA: 0x0011B6D3 File Offset: 0x001198D3
		public override object[] GetCustomAttributes(bool inherit)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E69 RID: 20073 RVA: 0x0011B6DA File Offset: 0x001198DA
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E6A RID: 20074 RVA: 0x0011B6E1 File Offset: 0x001198E1
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004E6B RID: 20075 RVA: 0x0011B6E8 File Offset: 0x001198E8
		public void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
		{
			this.m_type.SetGenParamCustomAttribute(con, binaryAttribute);
		}

		// Token: 0x06004E6C RID: 20076 RVA: 0x0011B6F7 File Offset: 0x001198F7
		public void SetCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			this.m_type.SetGenParamCustomAttribute(customBuilder);
		}

		// Token: 0x06004E6D RID: 20077 RVA: 0x0011B705 File Offset: 0x00119905
		public void SetBaseTypeConstraint(Type baseTypeConstraint)
		{
			this.m_type.CheckContext(new Type[]
			{
				baseTypeConstraint
			});
			this.m_type.SetParent(baseTypeConstraint);
		}

		// Token: 0x06004E6E RID: 20078 RVA: 0x0011B728 File Offset: 0x00119928
		[ComVisible(true)]
		public void SetInterfaceConstraints(params Type[] interfaceConstraints)
		{
			this.m_type.CheckContext(interfaceConstraints);
			this.m_type.SetInterfaces(interfaceConstraints);
		}

		// Token: 0x06004E6F RID: 20079 RVA: 0x0011B742 File Offset: 0x00119942
		public void SetGenericParameterAttributes(GenericParameterAttributes genericParameterAttributes)
		{
			this.m_type.SetGenParamAttributes(genericParameterAttributes);
		}

		// Token: 0x040021C9 RID: 8649
		internal TypeBuilder m_type;
	}
}
