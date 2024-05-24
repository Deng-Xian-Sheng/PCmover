using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x0200064A RID: 1610
	internal sealed class SymbolType : TypeInfo
	{
		// Token: 0x06004B98 RID: 19352 RVA: 0x00111AA5 File Offset: 0x0010FCA5
		public override bool IsAssignableFrom(TypeInfo typeInfo)
		{
			return !(typeInfo == null) && this.IsAssignableFrom(typeInfo.AsType());
		}

		// Token: 0x06004B99 RID: 19353 RVA: 0x00111AC0 File Offset: 0x0010FCC0
		internal static Type FormCompoundType(char[] bFormat, Type baseType, int curIndex)
		{
			if (bFormat == null || curIndex == bFormat.Length)
			{
				return baseType;
			}
			if (bFormat[curIndex] == '&')
			{
				SymbolType symbolType = new SymbolType(TypeKind.IsByRef);
				symbolType.SetFormat(bFormat, curIndex, 1);
				curIndex++;
				if (curIndex != bFormat.Length)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_BadSigFormat"));
				}
				symbolType.SetElementType(baseType);
				return symbolType;
			}
			else
			{
				if (bFormat[curIndex] == '[')
				{
					SymbolType symbolType = new SymbolType(TypeKind.IsArray);
					int num = curIndex;
					curIndex++;
					int num2 = 0;
					int num3 = -1;
					while (bFormat[curIndex] != ']')
					{
						if (bFormat[curIndex] == '*')
						{
							symbolType.m_isSzArray = false;
							curIndex++;
						}
						if ((bFormat[curIndex] >= '0' && bFormat[curIndex] <= '9') || bFormat[curIndex] == '-')
						{
							bool flag = false;
							if (bFormat[curIndex] == '-')
							{
								flag = true;
								curIndex++;
							}
							while (bFormat[curIndex] >= '0' && bFormat[curIndex] <= '9')
							{
								num2 *= 10;
								num2 += (int)(bFormat[curIndex] - '0');
								curIndex++;
							}
							if (flag)
							{
								num2 = 0 - num2;
							}
							num3 = num2 - 1;
						}
						if (bFormat[curIndex] == '.')
						{
							curIndex++;
							if (bFormat[curIndex] != '.')
							{
								throw new ArgumentException(Environment.GetResourceString("Argument_BadSigFormat"));
							}
							curIndex++;
							if ((bFormat[curIndex] >= '0' && bFormat[curIndex] <= '9') || bFormat[curIndex] == '-')
							{
								bool flag2 = false;
								num3 = 0;
								if (bFormat[curIndex] == '-')
								{
									flag2 = true;
									curIndex++;
								}
								while (bFormat[curIndex] >= '0' && bFormat[curIndex] <= '9')
								{
									num3 *= 10;
									num3 += (int)(bFormat[curIndex] - '0');
									curIndex++;
								}
								if (flag2)
								{
									num3 = 0 - num3;
								}
								if (num3 < num2)
								{
									throw new ArgumentException(Environment.GetResourceString("Argument_BadSigFormat"));
								}
							}
						}
						if (bFormat[curIndex] == ',')
						{
							curIndex++;
							symbolType.SetBounds(num2, num3);
							num2 = 0;
							num3 = -1;
						}
						else if (bFormat[curIndex] != ']')
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_BadSigFormat"));
						}
					}
					symbolType.SetBounds(num2, num3);
					curIndex++;
					symbolType.SetFormat(bFormat, num, curIndex - num);
					symbolType.SetElementType(baseType);
					return SymbolType.FormCompoundType(bFormat, symbolType, curIndex);
				}
				if (bFormat[curIndex] == '*')
				{
					SymbolType symbolType = new SymbolType(TypeKind.IsPointer);
					symbolType.SetFormat(bFormat, curIndex, 1);
					curIndex++;
					symbolType.SetElementType(baseType);
					return SymbolType.FormCompoundType(bFormat, symbolType, curIndex);
				}
				return null;
			}
		}

		// Token: 0x06004B9A RID: 19354 RVA: 0x00111CC0 File Offset: 0x0010FEC0
		internal SymbolType(TypeKind typeKind)
		{
			this.m_typeKind = typeKind;
			this.m_iaLowerBound = new int[4];
			this.m_iaUpperBound = new int[4];
		}

		// Token: 0x06004B9B RID: 19355 RVA: 0x00111CEE File Offset: 0x0010FEEE
		internal void SetElementType(Type baseType)
		{
			if (baseType == null)
			{
				throw new ArgumentNullException("baseType");
			}
			this.m_baseType = baseType;
		}

		// Token: 0x06004B9C RID: 19356 RVA: 0x00111D0C File Offset: 0x0010FF0C
		private void SetBounds(int lower, int upper)
		{
			if (lower != 0 || upper != -1)
			{
				this.m_isSzArray = false;
			}
			if (this.m_iaLowerBound.Length <= this.m_cRank)
			{
				int[] array = new int[this.m_cRank * 2];
				Array.Copy(this.m_iaLowerBound, array, this.m_cRank);
				this.m_iaLowerBound = array;
				Array.Copy(this.m_iaUpperBound, array, this.m_cRank);
				this.m_iaUpperBound = array;
			}
			this.m_iaLowerBound[this.m_cRank] = lower;
			this.m_iaUpperBound[this.m_cRank] = upper;
			this.m_cRank++;
		}

		// Token: 0x06004B9D RID: 19357 RVA: 0x00111DA4 File Offset: 0x0010FFA4
		internal void SetFormat(char[] bFormat, int curIndex, int length)
		{
			char[] array = new char[length];
			Array.Copy(bFormat, curIndex, array, 0, length);
			this.m_bFormat = array;
		}

		// Token: 0x17000BD9 RID: 3033
		// (get) Token: 0x06004B9E RID: 19358 RVA: 0x00111DC9 File Offset: 0x0010FFC9
		internal override bool IsSzArray
		{
			get
			{
				return this.m_cRank <= 1 && this.m_isSzArray;
			}
		}

		// Token: 0x06004B9F RID: 19359 RVA: 0x00111DDC File Offset: 0x0010FFDC
		public override Type MakePointerType()
		{
			return SymbolType.FormCompoundType((new string(this.m_bFormat) + "*").ToCharArray(), this.m_baseType, 0);
		}

		// Token: 0x06004BA0 RID: 19360 RVA: 0x00111E04 File Offset: 0x00110004
		public override Type MakeByRefType()
		{
			return SymbolType.FormCompoundType((new string(this.m_bFormat) + "&").ToCharArray(), this.m_baseType, 0);
		}

		// Token: 0x06004BA1 RID: 19361 RVA: 0x00111E2C File Offset: 0x0011002C
		public override Type MakeArrayType()
		{
			return SymbolType.FormCompoundType((new string(this.m_bFormat) + "[]").ToCharArray(), this.m_baseType, 0);
		}

		// Token: 0x06004BA2 RID: 19362 RVA: 0x00111E54 File Offset: 0x00110054
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
			string str = string.Format(CultureInfo.InvariantCulture, "[{0}]", text);
			return SymbolType.FormCompoundType((new string(this.m_bFormat) + str).ToCharArray(), this.m_baseType, 0) as SymbolType;
		}

		// Token: 0x06004BA3 RID: 19363 RVA: 0x00111ECF File Offset: 0x001100CF
		public override int GetArrayRank()
		{
			if (!base.IsArray)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
			}
			return this.m_cRank;
		}

		// Token: 0x17000BDA RID: 3034
		// (get) Token: 0x06004BA4 RID: 19364 RVA: 0x00111EEF File Offset: 0x001100EF
		public override Guid GUID
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
			}
		}

		// Token: 0x06004BA5 RID: 19365 RVA: 0x00111F00 File Offset: 0x00110100
		public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x17000BDB RID: 3035
		// (get) Token: 0x06004BA6 RID: 19366 RVA: 0x00111F14 File Offset: 0x00110114
		public override Module Module
		{
			get
			{
				Type baseType = this.m_baseType;
				while (baseType is SymbolType)
				{
					baseType = ((SymbolType)baseType).m_baseType;
				}
				return baseType.Module;
			}
		}

		// Token: 0x17000BDC RID: 3036
		// (get) Token: 0x06004BA7 RID: 19367 RVA: 0x00111F44 File Offset: 0x00110144
		public override Assembly Assembly
		{
			get
			{
				Type baseType = this.m_baseType;
				while (baseType is SymbolType)
				{
					baseType = ((SymbolType)baseType).m_baseType;
				}
				return baseType.Assembly;
			}
		}

		// Token: 0x17000BDD RID: 3037
		// (get) Token: 0x06004BA8 RID: 19368 RVA: 0x00111F74 File Offset: 0x00110174
		public override RuntimeTypeHandle TypeHandle
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
			}
		}

		// Token: 0x17000BDE RID: 3038
		// (get) Token: 0x06004BA9 RID: 19369 RVA: 0x00111F88 File Offset: 0x00110188
		public override string Name
		{
			get
			{
				string str = new string(this.m_bFormat);
				Type baseType = this.m_baseType;
				while (baseType is SymbolType)
				{
					str = new string(((SymbolType)baseType).m_bFormat) + str;
					baseType = ((SymbolType)baseType).m_baseType;
				}
				return baseType.Name + str;
			}
		}

		// Token: 0x17000BDF RID: 3039
		// (get) Token: 0x06004BAA RID: 19370 RVA: 0x00111FE1 File Offset: 0x001101E1
		public override string FullName
		{
			get
			{
				return TypeNameBuilder.ToString(this, TypeNameBuilder.Format.FullName);
			}
		}

		// Token: 0x17000BE0 RID: 3040
		// (get) Token: 0x06004BAB RID: 19371 RVA: 0x00111FEA File Offset: 0x001101EA
		public override string AssemblyQualifiedName
		{
			get
			{
				return TypeNameBuilder.ToString(this, TypeNameBuilder.Format.AssemblyQualifiedName);
			}
		}

		// Token: 0x06004BAC RID: 19372 RVA: 0x00111FF3 File Offset: 0x001101F3
		public override string ToString()
		{
			return TypeNameBuilder.ToString(this, TypeNameBuilder.Format.ToString);
		}

		// Token: 0x17000BE1 RID: 3041
		// (get) Token: 0x06004BAD RID: 19373 RVA: 0x00111FFC File Offset: 0x001101FC
		public override string Namespace
		{
			get
			{
				return this.m_baseType.Namespace;
			}
		}

		// Token: 0x17000BE2 RID: 3042
		// (get) Token: 0x06004BAE RID: 19374 RVA: 0x00112009 File Offset: 0x00110209
		public override Type BaseType
		{
			get
			{
				return typeof(Array);
			}
		}

		// Token: 0x06004BAF RID: 19375 RVA: 0x00112015 File Offset: 0x00110215
		protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BB0 RID: 19376 RVA: 0x00112026 File Offset: 0x00110226
		[ComVisible(true)]
		public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BB1 RID: 19377 RVA: 0x00112037 File Offset: 0x00110237
		protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BB2 RID: 19378 RVA: 0x00112048 File Offset: 0x00110248
		public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BB3 RID: 19379 RVA: 0x00112059 File Offset: 0x00110259
		public override FieldInfo GetField(string name, BindingFlags bindingAttr)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BB4 RID: 19380 RVA: 0x0011206A File Offset: 0x0011026A
		public override FieldInfo[] GetFields(BindingFlags bindingAttr)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BB5 RID: 19381 RVA: 0x0011207B File Offset: 0x0011027B
		public override Type GetInterface(string name, bool ignoreCase)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BB6 RID: 19382 RVA: 0x0011208C File Offset: 0x0011028C
		public override Type[] GetInterfaces()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BB7 RID: 19383 RVA: 0x0011209D File Offset: 0x0011029D
		public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BB8 RID: 19384 RVA: 0x001120AE File Offset: 0x001102AE
		public override EventInfo[] GetEvents()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BB9 RID: 19385 RVA: 0x001120BF File Offset: 0x001102BF
		protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BBA RID: 19386 RVA: 0x001120D0 File Offset: 0x001102D0
		public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BBB RID: 19387 RVA: 0x001120E1 File Offset: 0x001102E1
		public override Type[] GetNestedTypes(BindingFlags bindingAttr)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BBC RID: 19388 RVA: 0x001120F2 File Offset: 0x001102F2
		public override Type GetNestedType(string name, BindingFlags bindingAttr)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BBD RID: 19389 RVA: 0x00112103 File Offset: 0x00110303
		public override MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BBE RID: 19390 RVA: 0x00112114 File Offset: 0x00110314
		public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BBF RID: 19391 RVA: 0x00112125 File Offset: 0x00110325
		[ComVisible(true)]
		public override InterfaceMapping GetInterfaceMap(Type interfaceType)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BC0 RID: 19392 RVA: 0x00112136 File Offset: 0x00110336
		public override EventInfo[] GetEvents(BindingFlags bindingAttr)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BC1 RID: 19393 RVA: 0x00112148 File Offset: 0x00110348
		protected override TypeAttributes GetAttributeFlagsImpl()
		{
			Type baseType = this.m_baseType;
			while (baseType is SymbolType)
			{
				baseType = ((SymbolType)baseType).m_baseType;
			}
			return baseType.Attributes;
		}

		// Token: 0x06004BC2 RID: 19394 RVA: 0x00112178 File Offset: 0x00110378
		protected override bool IsArrayImpl()
		{
			return this.m_typeKind == TypeKind.IsArray;
		}

		// Token: 0x06004BC3 RID: 19395 RVA: 0x00112183 File Offset: 0x00110383
		protected override bool IsPointerImpl()
		{
			return this.m_typeKind == TypeKind.IsPointer;
		}

		// Token: 0x06004BC4 RID: 19396 RVA: 0x0011218E File Offset: 0x0011038E
		protected override bool IsByRefImpl()
		{
			return this.m_typeKind == TypeKind.IsByRef;
		}

		// Token: 0x06004BC5 RID: 19397 RVA: 0x00112199 File Offset: 0x00110399
		protected override bool IsPrimitiveImpl()
		{
			return false;
		}

		// Token: 0x06004BC6 RID: 19398 RVA: 0x0011219C File Offset: 0x0011039C
		protected override bool IsValueTypeImpl()
		{
			return false;
		}

		// Token: 0x06004BC7 RID: 19399 RVA: 0x0011219F File Offset: 0x0011039F
		protected override bool IsCOMObjectImpl()
		{
			return false;
		}

		// Token: 0x17000BE3 RID: 3043
		// (get) Token: 0x06004BC8 RID: 19400 RVA: 0x001121A2 File Offset: 0x001103A2
		public override bool IsConstructedGenericType
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06004BC9 RID: 19401 RVA: 0x001121A5 File Offset: 0x001103A5
		public override Type GetElementType()
		{
			return this.m_baseType;
		}

		// Token: 0x06004BCA RID: 19402 RVA: 0x001121AD File Offset: 0x001103AD
		protected override bool HasElementTypeImpl()
		{
			return this.m_baseType != null;
		}

		// Token: 0x17000BE4 RID: 3044
		// (get) Token: 0x06004BCB RID: 19403 RVA: 0x001121BB File Offset: 0x001103BB
		public override Type UnderlyingSystemType
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06004BCC RID: 19404 RVA: 0x001121BE File Offset: 0x001103BE
		public override object[] GetCustomAttributes(bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BCD RID: 19405 RVA: 0x001121CF File Offset: 0x001103CF
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x06004BCE RID: 19406 RVA: 0x001121E0 File Offset: 0x001103E0
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonReflectedType"));
		}

		// Token: 0x04001F38 RID: 7992
		internal TypeKind m_typeKind;

		// Token: 0x04001F39 RID: 7993
		internal Type m_baseType;

		// Token: 0x04001F3A RID: 7994
		internal int m_cRank;

		// Token: 0x04001F3B RID: 7995
		internal int[] m_iaLowerBound;

		// Token: 0x04001F3C RID: 7996
		internal int[] m_iaUpperBound;

		// Token: 0x04001F3D RID: 7997
		private char[] m_bFormat;

		// Token: 0x04001F3E RID: 7998
		private bool m_isSzArray = true;
	}
}
