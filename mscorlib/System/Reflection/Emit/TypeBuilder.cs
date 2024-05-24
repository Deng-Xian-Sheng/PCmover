﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Reflection.Emit
{
	// Token: 0x02000662 RID: 1634
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_TypeBuilder))]
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public sealed class TypeBuilder : TypeInfo, _TypeBuilder
	{
		// Token: 0x06004D3C RID: 19772 RVA: 0x00118557 File Offset: 0x00116757
		public override bool IsAssignableFrom(TypeInfo typeInfo)
		{
			return !(typeInfo == null) && this.IsAssignableFrom(typeInfo.AsType());
		}

		// Token: 0x06004D3D RID: 19773 RVA: 0x00118570 File Offset: 0x00116770
		public static MethodInfo GetMethod(Type type, MethodInfo method)
		{
			if (!(type is TypeBuilder) && !(type is TypeBuilderInstantiation))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeTypeBuilder"));
			}
			if (method.IsGenericMethod && !method.IsGenericMethodDefinition)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedGenericMethodDefinition"), "method");
			}
			if (method.DeclaringType == null || !method.DeclaringType.IsGenericTypeDefinition)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MethodNeedGenericDeclaringType"), "method");
			}
			if (type.GetGenericTypeDefinition() != method.DeclaringType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidMethodDeclaringType"), "type");
			}
			if (type.IsGenericTypeDefinition)
			{
				type = type.MakeGenericType(type.GetGenericArguments());
			}
			if (!(type is TypeBuilderInstantiation))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "type");
			}
			return MethodOnTypeBuilderInstantiation.GetMethod(method, type as TypeBuilderInstantiation);
		}

		// Token: 0x06004D3E RID: 19774 RVA: 0x0011865C File Offset: 0x0011685C
		public static ConstructorInfo GetConstructor(Type type, ConstructorInfo constructor)
		{
			if (!(type is TypeBuilder) && !(type is TypeBuilderInstantiation))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeTypeBuilder"));
			}
			if (!constructor.DeclaringType.IsGenericTypeDefinition)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ConstructorNeedGenericDeclaringType"), "constructor");
			}
			if (!(type is TypeBuilderInstantiation))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "type");
			}
			if (type is TypeBuilder && type.IsGenericTypeDefinition)
			{
				type = type.MakeGenericType(type.GetGenericArguments());
			}
			if (type.GetGenericTypeDefinition() != constructor.DeclaringType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidConstructorDeclaringType"), "type");
			}
			return ConstructorOnTypeBuilderInstantiation.GetConstructor(constructor, type as TypeBuilderInstantiation);
		}

		// Token: 0x06004D3F RID: 19775 RVA: 0x0011871C File Offset: 0x0011691C
		public static FieldInfo GetField(Type type, FieldInfo field)
		{
			if (!(type is TypeBuilder) && !(type is TypeBuilderInstantiation))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeTypeBuilder"));
			}
			if (!field.DeclaringType.IsGenericTypeDefinition)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_FieldNeedGenericDeclaringType"), "field");
			}
			if (!(type is TypeBuilderInstantiation))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "type");
			}
			if (type is TypeBuilder && type.IsGenericTypeDefinition)
			{
				type = type.MakeGenericType(type.GetGenericArguments());
			}
			if (type.GetGenericTypeDefinition() != field.DeclaringType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidFieldDeclaringType"), "type");
			}
			return FieldOnTypeBuilderInstantiation.GetField(field, type as TypeBuilderInstantiation);
		}

		// Token: 0x06004D40 RID: 19776
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void SetParentType(RuntimeModule module, int tdTypeDef, int tkParent);

		// Token: 0x06004D41 RID: 19777
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void AddInterfaceImpl(RuntimeModule module, int tdTypeDef, int tkInterface);

		// Token: 0x06004D42 RID: 19778
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int DefineMethod(RuntimeModule module, int tkParent, string name, byte[] signature, int sigLength, MethodAttributes attributes);

		// Token: 0x06004D43 RID: 19779
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int DefineMethodSpec(RuntimeModule module, int tkParent, byte[] signature, int sigLength);

		// Token: 0x06004D44 RID: 19780
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int DefineField(RuntimeModule module, int tkParent, string name, byte[] signature, int sigLength, FieldAttributes attributes);

		// Token: 0x06004D45 RID: 19781
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void SetMethodIL(RuntimeModule module, int tk, bool isInitLocals, byte[] body, int bodyLength, byte[] LocalSig, int sigLength, int maxStackSize, ExceptionHandler[] exceptions, int numExceptions, int[] tokenFixups, int numTokenFixups);

		// Token: 0x06004D46 RID: 19782
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void DefineCustomAttribute(RuntimeModule module, int tkAssociate, int tkConstructor, byte[] attr, int attrLength, bool toDisk, bool updateCompilerFlags);

		// Token: 0x06004D47 RID: 19783 RVA: 0x001187DC File Offset: 0x001169DC
		[SecurityCritical]
		internal static void DefineCustomAttribute(ModuleBuilder module, int tkAssociate, int tkConstructor, byte[] attr, bool toDisk, bool updateCompilerFlags)
		{
			byte[] array = null;
			if (attr != null)
			{
				array = new byte[attr.Length];
				Array.Copy(attr, array, attr.Length);
			}
			TypeBuilder.DefineCustomAttribute(module.GetNativeHandle(), tkAssociate, tkConstructor, array, (array != null) ? array.Length : 0, toDisk, updateCompilerFlags);
		}

		// Token: 0x06004D48 RID: 19784
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void SetPInvokeData(RuntimeModule module, string DllName, string name, int token, int linkFlags);

		// Token: 0x06004D49 RID: 19785
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int DefineProperty(RuntimeModule module, int tkParent, string name, PropertyAttributes attributes, byte[] signature, int sigLength);

		// Token: 0x06004D4A RID: 19786
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int DefineEvent(RuntimeModule module, int tkParent, string name, EventAttributes attributes, int tkEventType);

		// Token: 0x06004D4B RID: 19787
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void DefineMethodSemantics(RuntimeModule module, int tkAssociation, MethodSemanticsAttributes semantics, int tkMethod);

		// Token: 0x06004D4C RID: 19788
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void DefineMethodImpl(RuntimeModule module, int tkType, int tkBody, int tkDecl);

		// Token: 0x06004D4D RID: 19789
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void SetMethodImpl(RuntimeModule module, int tkMethod, MethodImplAttributes MethodImplAttributes);

		// Token: 0x06004D4E RID: 19790
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int SetParamInfo(RuntimeModule module, int tkMethod, int iSequence, ParameterAttributes iParamAttributes, string strParamName);

		// Token: 0x06004D4F RID: 19791
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int GetTokenFromSig(RuntimeModule module, byte[] signature, int sigLength);

		// Token: 0x06004D50 RID: 19792
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void SetFieldLayoutOffset(RuntimeModule module, int fdToken, int iOffset);

		// Token: 0x06004D51 RID: 19793
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void SetClassLayout(RuntimeModule module, int tk, PackingSize iPackingSize, int iTypeSize);

		// Token: 0x06004D52 RID: 19794
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void SetFieldMarshal(RuntimeModule module, int tk, byte[] ubMarshal, int ubSize);

		// Token: 0x06004D53 RID: 19795
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private unsafe static extern void SetConstantValue(RuntimeModule module, int tk, int corType, void* pValue);

		// Token: 0x06004D54 RID: 19796
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void AddDeclarativeSecurity(RuntimeModule module, int parent, SecurityAction action, byte[] blob, int cb);

		// Token: 0x06004D55 RID: 19797 RVA: 0x0011881C File Offset: 0x00116A1C
		private static bool IsPublicComType(Type type)
		{
			Type declaringType = type.DeclaringType;
			if (declaringType != null)
			{
				if (TypeBuilder.IsPublicComType(declaringType) && (type.Attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NestedPublic)
				{
					return true;
				}
			}
			else if ((type.Attributes & TypeAttributes.VisibilityMask) == TypeAttributes.Public)
			{
				return true;
			}
			return false;
		}

		// Token: 0x06004D56 RID: 19798 RVA: 0x0011885C File Offset: 0x00116A5C
		internal static bool IsTypeEqual(Type t1, Type t2)
		{
			if (t1 == t2)
			{
				return true;
			}
			TypeBuilder typeBuilder = null;
			TypeBuilder typeBuilder2 = null;
			Type left;
			if (t1 is TypeBuilder)
			{
				typeBuilder = (TypeBuilder)t1;
				left = typeBuilder.m_bakedRuntimeType;
			}
			else
			{
				left = t1;
			}
			Type type;
			if (t2 is TypeBuilder)
			{
				typeBuilder2 = (TypeBuilder)t2;
				type = typeBuilder2.m_bakedRuntimeType;
			}
			else
			{
				type = t2;
			}
			return (typeBuilder != null && typeBuilder2 != null && typeBuilder == typeBuilder2) || (left != null && type != null && left == type);
		}

		// Token: 0x06004D57 RID: 19799 RVA: 0x001188E8 File Offset: 0x00116AE8
		[SecurityCritical]
		internal unsafe static void SetConstantValue(ModuleBuilder module, int tk, Type destType, object value)
		{
			if (value != null)
			{
				Type type = value.GetType();
				if (destType.IsByRef)
				{
					destType = destType.GetElementType();
				}
				if (destType.IsEnum)
				{
					EnumBuilder enumBuilder;
					Type type2;
					TypeBuilder typeBuilder;
					if ((enumBuilder = (destType as EnumBuilder)) != null)
					{
						type2 = enumBuilder.GetEnumUnderlyingType();
						if (type != enumBuilder.m_typeBuilder.m_bakedRuntimeType && type != type2)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_ConstantDoesntMatch"));
						}
					}
					else if ((typeBuilder = (destType as TypeBuilder)) != null)
					{
						type2 = typeBuilder.m_enumUnderlyingType;
						if (type2 == null || (type != typeBuilder.UnderlyingSystemType && type != type2))
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_ConstantDoesntMatch"));
						}
					}
					else
					{
						type2 = Enum.GetUnderlyingType(destType);
						if (type != destType && type != type2)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_ConstantDoesntMatch"));
						}
					}
					type = type2;
				}
				else if (!destType.IsAssignableFrom(type))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_ConstantDoesntMatch"));
				}
				CorElementType corElementType = RuntimeTypeHandle.GetCorElementType((RuntimeType)type);
				if (corElementType - CorElementType.Boolean <= 11)
				{
					fixed (byte* ptr = &JitHelpers.GetPinningHelper(value).m_data)
					{
						byte* pValue = ptr;
						TypeBuilder.SetConstantValue(module.GetNativeHandle(), tk, (int)corElementType, (void*)pValue);
					}
					return;
				}
				if (type == typeof(string))
				{
					fixed (string text = (string)value)
					{
						char* ptr2 = text;
						if (ptr2 != null)
						{
							ptr2 += RuntimeHelpers.OffsetToStringData / 2;
						}
						TypeBuilder.SetConstantValue(module.GetNativeHandle(), tk, 14, (void*)ptr2);
					}
					return;
				}
				if (type == typeof(DateTime))
				{
					long ticks = ((DateTime)value).Ticks;
					TypeBuilder.SetConstantValue(module.GetNativeHandle(), tk, 10, (void*)(&ticks));
					return;
				}
				throw new ArgumentException(Environment.GetResourceString("Argument_ConstantNotSupported", new object[]
				{
					type.ToString()
				}));
			}
			else
			{
				if (destType.IsValueType && (!destType.IsGenericType || !(destType.GetGenericTypeDefinition() == typeof(Nullable<>))))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_ConstantNull"));
				}
				TypeBuilder.SetConstantValue(module.GetNativeHandle(), tk, 18, null);
				return;
			}
		}

		// Token: 0x06004D58 RID: 19800 RVA: 0x00118B0B File Offset: 0x00116D0B
		internal TypeBuilder(ModuleBuilder module)
		{
			this.m_tdType = new TypeToken(33554432);
			this.m_isHiddenGlobalType = true;
			this.m_module = module;
			this.m_listMethods = new List<MethodBuilder>();
			this.m_lastTokenizedMethod = -1;
		}

		// Token: 0x06004D59 RID: 19801 RVA: 0x00118B43 File Offset: 0x00116D43
		internal TypeBuilder(string szName, int genParamPos, MethodBuilder declMeth)
		{
			this.m_declMeth = declMeth;
			this.m_DeclaringType = this.m_declMeth.GetTypeBuilder();
			this.m_module = declMeth.GetModuleBuilder();
			this.InitAsGenericParam(szName, genParamPos);
		}

		// Token: 0x06004D5A RID: 19802 RVA: 0x00118B77 File Offset: 0x00116D77
		private TypeBuilder(string szName, int genParamPos, TypeBuilder declType)
		{
			this.m_DeclaringType = declType;
			this.m_module = declType.GetModuleBuilder();
			this.InitAsGenericParam(szName, genParamPos);
		}

		// Token: 0x06004D5B RID: 19803 RVA: 0x00118B9A File Offset: 0x00116D9A
		private void InitAsGenericParam(string szName, int genParamPos)
		{
			this.m_strName = szName;
			this.m_genParamPos = genParamPos;
			this.m_bIsGenParam = true;
			this.m_typeInterfaces = new List<Type>();
		}

		// Token: 0x06004D5C RID: 19804 RVA: 0x00118BBC File Offset: 0x00116DBC
		[SecurityCritical]
		internal TypeBuilder(string name, TypeAttributes attr, Type parent, Type[] interfaces, ModuleBuilder module, PackingSize iPackingSize, int iTypeSize, TypeBuilder enclosingType)
		{
			this.Init(name, attr, parent, interfaces, module, iPackingSize, iTypeSize, enclosingType);
		}

		// Token: 0x06004D5D RID: 19805 RVA: 0x00118BE4 File Offset: 0x00116DE4
		[SecurityCritical]
		private void Init(string fullname, TypeAttributes attr, Type parent, Type[] interfaces, ModuleBuilder module, PackingSize iPackingSize, int iTypeSize, TypeBuilder enclosingType)
		{
			if (fullname == null)
			{
				throw new ArgumentNullException("fullname");
			}
			if (fullname.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "fullname");
			}
			if (fullname[0] == '\0')
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_IllegalName"), "fullname");
			}
			if (fullname.Length > 1023)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_TypeNameTooLong"), "fullname");
			}
			this.m_module = module;
			this.m_DeclaringType = enclosingType;
			AssemblyBuilder containingAssemblyBuilder = this.m_module.ContainingAssemblyBuilder;
			containingAssemblyBuilder.m_assemblyData.CheckTypeNameConflict(fullname, enclosingType);
			if (enclosingType != null && ((attr & TypeAttributes.VisibilityMask) == TypeAttributes.Public || (attr & TypeAttributes.VisibilityMask) == TypeAttributes.NotPublic))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadNestedTypeFlags"), "attr");
			}
			int[] array = null;
			if (interfaces != null)
			{
				for (int i = 0; i < interfaces.Length; i++)
				{
					if (interfaces[i] == null)
					{
						throw new ArgumentNullException("interfaces");
					}
				}
				array = new int[interfaces.Length + 1];
				for (int i = 0; i < interfaces.Length; i++)
				{
					array[i] = this.m_module.GetTypeTokenInternal(interfaces[i]).Token;
				}
			}
			int num = fullname.LastIndexOf('.');
			if (num == -1 || num == 0)
			{
				this.m_strNameSpace = string.Empty;
				this.m_strName = fullname;
			}
			else
			{
				this.m_strNameSpace = fullname.Substring(0, num);
				this.m_strName = fullname.Substring(num + 1);
			}
			this.VerifyTypeAttributes(attr);
			this.m_iAttr = attr;
			this.SetParent(parent);
			this.m_listMethods = new List<MethodBuilder>();
			this.m_lastTokenizedMethod = -1;
			this.SetInterfaces(interfaces);
			int tkParent = 0;
			if (this.m_typeParent != null)
			{
				tkParent = this.m_module.GetTypeTokenInternal(this.m_typeParent).Token;
			}
			int tkEnclosingType = 0;
			if (enclosingType != null)
			{
				tkEnclosingType = enclosingType.m_tdType.Token;
			}
			this.m_tdType = new TypeToken(TypeBuilder.DefineType(this.m_module.GetNativeHandle(), fullname, tkParent, this.m_iAttr, tkEnclosingType, array));
			this.m_iPackingSize = iPackingSize;
			this.m_iTypeSize = iTypeSize;
			if (this.m_iPackingSize != PackingSize.Unspecified || this.m_iTypeSize != 0)
			{
				TypeBuilder.SetClassLayout(this.GetModuleBuilder().GetNativeHandle(), this.m_tdType.Token, this.m_iPackingSize, this.m_iTypeSize);
			}
			if (TypeBuilder.IsPublicComType(this))
			{
				if (containingAssemblyBuilder.IsPersistable() && !this.m_module.IsTransient())
				{
					containingAssemblyBuilder.m_assemblyData.AddPublicComType(this);
				}
				if (!this.m_module.Equals(containingAssemblyBuilder.ManifestModule))
				{
					containingAssemblyBuilder.DefineExportedTypeInMemory(this, this.m_module.m_moduleData.FileToken, this.m_tdType.Token);
				}
			}
			this.m_module.AddType(this.FullName, this);
		}

		// Token: 0x06004D5E RID: 19806 RVA: 0x00118EAC File Offset: 0x001170AC
		[SecurityCritical]
		private MethodBuilder DefinePInvokeMethodHelper(string name, string dllName, string importName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers, CallingConvention nativeCallConv, CharSet nativeCharSet)
		{
			this.CheckContext(new Type[]
			{
				returnType
			});
			this.CheckContext(new Type[][]
			{
				returnTypeRequiredCustomModifiers,
				returnTypeOptionalCustomModifiers,
				parameterTypes
			});
			this.CheckContext(parameterTypeRequiredCustomModifiers);
			this.CheckContext(parameterTypeOptionalCustomModifiers);
			AppDomain.CheckDefinePInvokeSupported();
			object syncRoot = this.SyncRoot;
			MethodBuilder result;
			lock (syncRoot)
			{
				result = this.DefinePInvokeMethodHelperNoLock(name, dllName, importName, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers, nativeCallConv, nativeCharSet);
			}
			return result;
		}

		// Token: 0x06004D5F RID: 19807 RVA: 0x00118F48 File Offset: 0x00117148
		[SecurityCritical]
		private MethodBuilder DefinePInvokeMethodHelperNoLock(string name, string dllName, string importName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers, CallingConvention nativeCallConv, CharSet nativeCharSet)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			if (dllName == null)
			{
				throw new ArgumentNullException("dllName");
			}
			if (dllName.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "dllName");
			}
			if (importName == null)
			{
				throw new ArgumentNullException("importName");
			}
			if (importName.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "importName");
			}
			if ((attributes & MethodAttributes.Abstract) != MethodAttributes.PrivateScope)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadPInvokeMethod"));
			}
			if ((this.m_iAttr & TypeAttributes.ClassSemanticsMask) == TypeAttributes.ClassSemanticsMask)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadPInvokeOnInterface"));
			}
			this.ThrowIfCreated();
			attributes |= MethodAttributes.PinvokeImpl;
			MethodBuilder methodBuilder = new MethodBuilder(name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers, this.m_module, this, false);
			int num;
			byte[] array = methodBuilder.GetMethodSignature().InternalGetSignature(out num);
			if (this.m_listMethods.Contains(methodBuilder))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MethodRedefined"));
			}
			this.m_listMethods.Add(methodBuilder);
			MethodToken token = methodBuilder.GetToken();
			int num2 = 0;
			switch (nativeCallConv)
			{
			case CallingConvention.Winapi:
				num2 = 256;
				break;
			case CallingConvention.Cdecl:
				num2 = 512;
				break;
			case CallingConvention.StdCall:
				num2 = 768;
				break;
			case CallingConvention.ThisCall:
				num2 = 1024;
				break;
			case CallingConvention.FastCall:
				num2 = 1280;
				break;
			}
			switch (nativeCharSet)
			{
			case CharSet.None:
				num2 |= 0;
				break;
			case CharSet.Ansi:
				num2 |= 2;
				break;
			case CharSet.Unicode:
				num2 |= 4;
				break;
			case CharSet.Auto:
				num2 |= 6;
				break;
			}
			TypeBuilder.SetPInvokeData(this.m_module.GetNativeHandle(), dllName, importName, token.Token, num2);
			methodBuilder.SetToken(token);
			return methodBuilder;
		}

		// Token: 0x06004D60 RID: 19808 RVA: 0x00119124 File Offset: 0x00117324
		[SecurityCritical]
		private FieldBuilder DefineDataHelper(string name, byte[] data, int size, FieldAttributes attributes)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			if (size <= 0 || size >= 4128768)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadSizeForData"));
			}
			this.ThrowIfCreated();
			string text = "$ArrayType$" + size.ToString();
			Type type = this.m_module.FindTypeBuilderWithName(text, false);
			TypeBuilder typeBuilder = type as TypeBuilder;
			if (typeBuilder == null)
			{
				TypeAttributes attr = TypeAttributes.Public | TypeAttributes.ExplicitLayout | TypeAttributes.Sealed;
				typeBuilder = this.m_module.DefineType(text, attr, typeof(ValueType), PackingSize.Size1, size);
				typeBuilder.CreateType();
			}
			FieldBuilder fieldBuilder = this.DefineField(name, typeBuilder, attributes | FieldAttributes.Static);
			fieldBuilder.SetData(data, size);
			return fieldBuilder;
		}

		// Token: 0x06004D61 RID: 19809 RVA: 0x001191F0 File Offset: 0x001173F0
		private void VerifyTypeAttributes(TypeAttributes attr)
		{
			if (this.DeclaringType == null)
			{
				if ((attr & TypeAttributes.VisibilityMask) != TypeAttributes.NotPublic && (attr & TypeAttributes.VisibilityMask) != TypeAttributes.Public)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_BadTypeAttrNestedVisibilityOnNonNestedType"));
				}
			}
			else if ((attr & TypeAttributes.VisibilityMask) == TypeAttributes.NotPublic || (attr & TypeAttributes.VisibilityMask) == TypeAttributes.Public)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadTypeAttrNonNestedVisibilityNestedType"));
			}
			if ((attr & TypeAttributes.LayoutMask) != TypeAttributes.NotPublic && (attr & TypeAttributes.LayoutMask) != TypeAttributes.SequentialLayout && (attr & TypeAttributes.LayoutMask) != TypeAttributes.ExplicitLayout)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadTypeAttrInvalidLayout"));
			}
			if ((attr & TypeAttributes.ReservedMask) != TypeAttributes.NotPublic)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadTypeAttrReservedBitsSet"));
			}
		}

		// Token: 0x06004D62 RID: 19810 RVA: 0x0011927F File Offset: 0x0011747F
		public bool IsCreated()
		{
			return this.m_hasBeenCreated;
		}

		// Token: 0x06004D63 RID: 19811
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int DefineType(RuntimeModule module, string fullname, int tkParent, TypeAttributes attributes, int tkEnclosingType, int[] interfaceTokens);

		// Token: 0x06004D64 RID: 19812
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int DefineGenericParam(RuntimeModule module, string name, int tkParent, GenericParameterAttributes attributes, int position, int[] constraints);

		// Token: 0x06004D65 RID: 19813
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void TermCreateClass(RuntimeModule module, int tk, ObjectHandleOnStack type);

		// Token: 0x06004D66 RID: 19814 RVA: 0x00119287 File Offset: 0x00117487
		internal void ThrowIfCreated()
		{
			if (this.IsCreated())
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_TypeHasBeenCreated"));
			}
		}

		// Token: 0x17000C18 RID: 3096
		// (get) Token: 0x06004D67 RID: 19815 RVA: 0x001192A1 File Offset: 0x001174A1
		internal object SyncRoot
		{
			get
			{
				return this.m_module.SyncRoot;
			}
		}

		// Token: 0x06004D68 RID: 19816 RVA: 0x001192AE File Offset: 0x001174AE
		internal ModuleBuilder GetModuleBuilder()
		{
			return this.m_module;
		}

		// Token: 0x17000C19 RID: 3097
		// (get) Token: 0x06004D69 RID: 19817 RVA: 0x001192B6 File Offset: 0x001174B6
		internal RuntimeType BakedRuntimeType
		{
			get
			{
				return this.m_bakedRuntimeType;
			}
		}

		// Token: 0x06004D6A RID: 19818 RVA: 0x001192BE File Offset: 0x001174BE
		internal void SetGenParamAttributes(GenericParameterAttributes genericParameterAttributes)
		{
			this.m_genParamAttributes = genericParameterAttributes;
		}

		// Token: 0x06004D6B RID: 19819 RVA: 0x001192C8 File Offset: 0x001174C8
		internal void SetGenParamCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
		{
			TypeBuilder.CustAttr genParamCustomAttributeNoLock = new TypeBuilder.CustAttr(con, binaryAttribute);
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.SetGenParamCustomAttributeNoLock(genParamCustomAttributeNoLock);
			}
		}

		// Token: 0x06004D6C RID: 19820 RVA: 0x00119314 File Offset: 0x00117514
		internal void SetGenParamCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			TypeBuilder.CustAttr genParamCustomAttributeNoLock = new TypeBuilder.CustAttr(customBuilder);
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.SetGenParamCustomAttributeNoLock(genParamCustomAttributeNoLock);
			}
		}

		// Token: 0x06004D6D RID: 19821 RVA: 0x0011935C File Offset: 0x0011755C
		private void SetGenParamCustomAttributeNoLock(TypeBuilder.CustAttr ca)
		{
			if (this.m_ca == null)
			{
				this.m_ca = new List<TypeBuilder.CustAttr>();
			}
			this.m_ca.Add(ca);
		}

		// Token: 0x06004D6E RID: 19822 RVA: 0x0011937D File Offset: 0x0011757D
		public override string ToString()
		{
			return TypeNameBuilder.ToString(this, TypeNameBuilder.Format.ToString);
		}

		// Token: 0x17000C1A RID: 3098
		// (get) Token: 0x06004D6F RID: 19823 RVA: 0x00119386 File Offset: 0x00117586
		public override Type DeclaringType
		{
			get
			{
				return this.m_DeclaringType;
			}
		}

		// Token: 0x17000C1B RID: 3099
		// (get) Token: 0x06004D70 RID: 19824 RVA: 0x0011938E File Offset: 0x0011758E
		public override Type ReflectedType
		{
			get
			{
				return this.m_DeclaringType;
			}
		}

		// Token: 0x17000C1C RID: 3100
		// (get) Token: 0x06004D71 RID: 19825 RVA: 0x00119396 File Offset: 0x00117596
		public override string Name
		{
			get
			{
				return this.m_strName;
			}
		}

		// Token: 0x17000C1D RID: 3101
		// (get) Token: 0x06004D72 RID: 19826 RVA: 0x0011939E File Offset: 0x0011759E
		public override Module Module
		{
			get
			{
				return this.GetModuleBuilder();
			}
		}

		// Token: 0x17000C1E RID: 3102
		// (get) Token: 0x06004D73 RID: 19827 RVA: 0x001193A6 File Offset: 0x001175A6
		internal int MetadataTokenInternal
		{
			get
			{
				return this.m_tdType.Token;
			}
		}

		// Token: 0x17000C1F RID: 3103
		// (get) Token: 0x06004D74 RID: 19828 RVA: 0x001193B3 File Offset: 0x001175B3
		public override Guid GUID
		{
			get
			{
				if (!this.IsCreated())
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
				}
				return this.m_bakedRuntimeType.GUID;
			}
		}

		// Token: 0x06004D75 RID: 19829 RVA: 0x001193D8 File Offset: 0x001175D8
		public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
		}

		// Token: 0x17000C20 RID: 3104
		// (get) Token: 0x06004D76 RID: 19830 RVA: 0x00119415 File Offset: 0x00117615
		public override Assembly Assembly
		{
			get
			{
				return this.m_module.Assembly;
			}
		}

		// Token: 0x17000C21 RID: 3105
		// (get) Token: 0x06004D77 RID: 19831 RVA: 0x00119422 File Offset: 0x00117622
		public override RuntimeTypeHandle TypeHandle
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
			}
		}

		// Token: 0x17000C22 RID: 3106
		// (get) Token: 0x06004D78 RID: 19832 RVA: 0x00119433 File Offset: 0x00117633
		public override string FullName
		{
			get
			{
				if (this.m_strFullQualName == null)
				{
					this.m_strFullQualName = TypeNameBuilder.ToString(this, TypeNameBuilder.Format.FullName);
				}
				return this.m_strFullQualName;
			}
		}

		// Token: 0x17000C23 RID: 3107
		// (get) Token: 0x06004D79 RID: 19833 RVA: 0x00119450 File Offset: 0x00117650
		public override string Namespace
		{
			get
			{
				return this.m_strNameSpace;
			}
		}

		// Token: 0x17000C24 RID: 3108
		// (get) Token: 0x06004D7A RID: 19834 RVA: 0x00119458 File Offset: 0x00117658
		public override string AssemblyQualifiedName
		{
			get
			{
				return TypeNameBuilder.ToString(this, TypeNameBuilder.Format.AssemblyQualifiedName);
			}
		}

		// Token: 0x17000C25 RID: 3109
		// (get) Token: 0x06004D7B RID: 19835 RVA: 0x00119461 File Offset: 0x00117661
		public override Type BaseType
		{
			get
			{
				return this.m_typeParent;
			}
		}

		// Token: 0x06004D7C RID: 19836 RVA: 0x00119469 File Offset: 0x00117669
		protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetConstructor(bindingAttr, binder, callConvention, types, modifiers);
		}

		// Token: 0x06004D7D RID: 19837 RVA: 0x00119495 File Offset: 0x00117695
		[ComVisible(true)]
		public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetConstructors(bindingAttr);
		}

		// Token: 0x06004D7E RID: 19838 RVA: 0x001194BB File Offset: 0x001176BB
		protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			if (types == null)
			{
				return this.m_bakedRuntimeType.GetMethod(name, bindingAttr);
			}
			return this.m_bakedRuntimeType.GetMethod(name, bindingAttr, binder, callConvention, types, modifiers);
		}

		// Token: 0x06004D7F RID: 19839 RVA: 0x001194FB File Offset: 0x001176FB
		public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetMethods(bindingAttr);
		}

		// Token: 0x06004D80 RID: 19840 RVA: 0x00119521 File Offset: 0x00117721
		public override FieldInfo GetField(string name, BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetField(name, bindingAttr);
		}

		// Token: 0x06004D81 RID: 19841 RVA: 0x00119548 File Offset: 0x00117748
		public override FieldInfo[] GetFields(BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetFields(bindingAttr);
		}

		// Token: 0x06004D82 RID: 19842 RVA: 0x0011956E File Offset: 0x0011776E
		public override Type GetInterface(string name, bool ignoreCase)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetInterface(name, ignoreCase);
		}

		// Token: 0x06004D83 RID: 19843 RVA: 0x00119595 File Offset: 0x00117795
		public override Type[] GetInterfaces()
		{
			if (this.m_bakedRuntimeType != null)
			{
				return this.m_bakedRuntimeType.GetInterfaces();
			}
			if (this.m_typeInterfaces == null)
			{
				return EmptyArray<Type>.Value;
			}
			return this.m_typeInterfaces.ToArray();
		}

		// Token: 0x06004D84 RID: 19844 RVA: 0x001195CA File Offset: 0x001177CA
		public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetEvent(name, bindingAttr);
		}

		// Token: 0x06004D85 RID: 19845 RVA: 0x001195F1 File Offset: 0x001177F1
		public override EventInfo[] GetEvents()
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetEvents();
		}

		// Token: 0x06004D86 RID: 19846 RVA: 0x00119616 File Offset: 0x00117816
		protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		// Token: 0x06004D87 RID: 19847 RVA: 0x00119627 File Offset: 0x00117827
		public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetProperties(bindingAttr);
		}

		// Token: 0x06004D88 RID: 19848 RVA: 0x0011964D File Offset: 0x0011784D
		public override Type[] GetNestedTypes(BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetNestedTypes(bindingAttr);
		}

		// Token: 0x06004D89 RID: 19849 RVA: 0x00119673 File Offset: 0x00117873
		public override Type GetNestedType(string name, BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetNestedType(name, bindingAttr);
		}

		// Token: 0x06004D8A RID: 19850 RVA: 0x0011969A File Offset: 0x0011789A
		public override MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetMember(name, type, bindingAttr);
		}

		// Token: 0x06004D8B RID: 19851 RVA: 0x001196C2 File Offset: 0x001178C2
		[ComVisible(true)]
		public override InterfaceMapping GetInterfaceMap(Type interfaceType)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetInterfaceMap(interfaceType);
		}

		// Token: 0x06004D8C RID: 19852 RVA: 0x001196E8 File Offset: 0x001178E8
		public override EventInfo[] GetEvents(BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetEvents(bindingAttr);
		}

		// Token: 0x06004D8D RID: 19853 RVA: 0x0011970E File Offset: 0x0011790E
		public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetMembers(bindingAttr);
		}

		// Token: 0x06004D8E RID: 19854 RVA: 0x00119734 File Offset: 0x00117934
		public override bool IsAssignableFrom(Type c)
		{
			if (TypeBuilder.IsTypeEqual(c, this))
			{
				return true;
			}
			TypeBuilder typeBuilder = c as TypeBuilder;
			Type type;
			if (typeBuilder != null)
			{
				type = typeBuilder.m_bakedRuntimeType;
			}
			else
			{
				type = c;
			}
			if (type != null && type is RuntimeType)
			{
				return !(this.m_bakedRuntimeType == null) && this.m_bakedRuntimeType.IsAssignableFrom(type);
			}
			if (typeBuilder == null)
			{
				return false;
			}
			if (typeBuilder.IsSubclassOf(this))
			{
				return true;
			}
			if (!base.IsInterface)
			{
				return false;
			}
			Type[] interfaces = typeBuilder.GetInterfaces();
			for (int i = 0; i < interfaces.Length; i++)
			{
				if (TypeBuilder.IsTypeEqual(interfaces[i], this))
				{
					return true;
				}
				if (interfaces[i].IsSubclassOf(this))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06004D8F RID: 19855 RVA: 0x001197E7 File Offset: 0x001179E7
		protected override TypeAttributes GetAttributeFlagsImpl()
		{
			return this.m_iAttr;
		}

		// Token: 0x06004D90 RID: 19856 RVA: 0x001197EF File Offset: 0x001179EF
		protected override bool IsArrayImpl()
		{
			return false;
		}

		// Token: 0x06004D91 RID: 19857 RVA: 0x001197F2 File Offset: 0x001179F2
		protected override bool IsByRefImpl()
		{
			return false;
		}

		// Token: 0x06004D92 RID: 19858 RVA: 0x001197F5 File Offset: 0x001179F5
		protected override bool IsPointerImpl()
		{
			return false;
		}

		// Token: 0x06004D93 RID: 19859 RVA: 0x001197F8 File Offset: 0x001179F8
		protected override bool IsPrimitiveImpl()
		{
			return false;
		}

		// Token: 0x06004D94 RID: 19860 RVA: 0x001197FB File Offset: 0x001179FB
		protected override bool IsCOMObjectImpl()
		{
			return (this.GetAttributeFlagsImpl() & TypeAttributes.Import) != TypeAttributes.NotPublic;
		}

		// Token: 0x06004D95 RID: 19861 RVA: 0x0011980E File Offset: 0x00117A0E
		public override Type GetElementType()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		// Token: 0x06004D96 RID: 19862 RVA: 0x0011981F File Offset: 0x00117A1F
		protected override bool HasElementTypeImpl()
		{
			return false;
		}

		// Token: 0x17000C26 RID: 3110
		// (get) Token: 0x06004D97 RID: 19863 RVA: 0x00119822 File Offset: 0x00117A22
		public override bool IsSecurityCritical
		{
			get
			{
				if (!this.IsCreated())
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
				}
				return this.m_bakedRuntimeType.IsSecurityCritical;
			}
		}

		// Token: 0x17000C27 RID: 3111
		// (get) Token: 0x06004D98 RID: 19864 RVA: 0x00119847 File Offset: 0x00117A47
		public override bool IsSecuritySafeCritical
		{
			get
			{
				if (!this.IsCreated())
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
				}
				return this.m_bakedRuntimeType.IsSecuritySafeCritical;
			}
		}

		// Token: 0x17000C28 RID: 3112
		// (get) Token: 0x06004D99 RID: 19865 RVA: 0x0011986C File Offset: 0x00117A6C
		public override bool IsSecurityTransparent
		{
			get
			{
				if (!this.IsCreated())
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
				}
				return this.m_bakedRuntimeType.IsSecurityTransparent;
			}
		}

		// Token: 0x06004D9A RID: 19866 RVA: 0x00119894 File Offset: 0x00117A94
		[ComVisible(true)]
		public override bool IsSubclassOf(Type c)
		{
			if (TypeBuilder.IsTypeEqual(this, c))
			{
				return false;
			}
			Type baseType = this.BaseType;
			while (baseType != null)
			{
				if (TypeBuilder.IsTypeEqual(baseType, c))
				{
					return true;
				}
				baseType = baseType.BaseType;
			}
			return false;
		}

		// Token: 0x17000C29 RID: 3113
		// (get) Token: 0x06004D9B RID: 19867 RVA: 0x001198D4 File Offset: 0x00117AD4
		public override Type UnderlyingSystemType
		{
			get
			{
				if (this.m_bakedRuntimeType != null)
				{
					return this.m_bakedRuntimeType;
				}
				if (!this.IsEnum)
				{
					return this;
				}
				if (this.m_enumUnderlyingType == null)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NoUnderlyingTypeOnEnum"));
				}
				return this.m_enumUnderlyingType;
			}
		}

		// Token: 0x06004D9C RID: 19868 RVA: 0x00119924 File Offset: 0x00117B24
		public override Type MakePointerType()
		{
			return SymbolType.FormCompoundType("*".ToCharArray(), this, 0);
		}

		// Token: 0x06004D9D RID: 19869 RVA: 0x00119937 File Offset: 0x00117B37
		public override Type MakeByRefType()
		{
			return SymbolType.FormCompoundType("&".ToCharArray(), this, 0);
		}

		// Token: 0x06004D9E RID: 19870 RVA: 0x0011994A File Offset: 0x00117B4A
		public override Type MakeArrayType()
		{
			return SymbolType.FormCompoundType("[]".ToCharArray(), this, 0);
		}

		// Token: 0x06004D9F RID: 19871 RVA: 0x00119960 File Offset: 0x00117B60
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
			return SymbolType.FormCompoundType(text2.ToCharArray(), this, 0);
		}

		// Token: 0x06004DA0 RID: 19872 RVA: 0x001199BF File Offset: 0x00117BBF
		[SecuritySafeCritical]
		public override object[] GetCustomAttributes(bool inherit)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return CustomAttribute.GetCustomAttributes(this.m_bakedRuntimeType, typeof(object) as RuntimeType, inherit);
		}

		// Token: 0x06004DA1 RID: 19873 RVA: 0x001199F4 File Offset: 0x00117BF4
		[SecuritySafeCritical]
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			RuntimeType runtimeType = attributeType.UnderlyingSystemType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "attributeType");
			}
			return CustomAttribute.GetCustomAttributes(this.m_bakedRuntimeType, runtimeType, inherit);
		}

		// Token: 0x06004DA2 RID: 19874 RVA: 0x00119A64 File Offset: 0x00117C64
		[SecuritySafeCritical]
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			RuntimeType runtimeType = attributeType.UnderlyingSystemType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "caType");
			}
			return CustomAttribute.IsDefined(this.m_bakedRuntimeType, runtimeType, inherit);
		}

		// Token: 0x17000C2A RID: 3114
		// (get) Token: 0x06004DA3 RID: 19875 RVA: 0x00119AD4 File Offset: 0x00117CD4
		public override GenericParameterAttributes GenericParameterAttributes
		{
			get
			{
				return this.m_genParamAttributes;
			}
		}

		// Token: 0x06004DA4 RID: 19876 RVA: 0x00119ADC File Offset: 0x00117CDC
		internal void SetInterfaces(params Type[] interfaces)
		{
			this.ThrowIfCreated();
			this.m_typeInterfaces = new List<Type>();
			if (interfaces != null)
			{
				this.m_typeInterfaces.AddRange(interfaces);
			}
		}

		// Token: 0x06004DA5 RID: 19877 RVA: 0x00119B00 File Offset: 0x00117D00
		public GenericTypeParameterBuilder[] DefineGenericParameters(params string[] names)
		{
			if (names == null)
			{
				throw new ArgumentNullException("names");
			}
			if (names.Length == 0)
			{
				throw new ArgumentException();
			}
			for (int i = 0; i < names.Length; i++)
			{
				if (names[i] == null)
				{
					throw new ArgumentNullException("names");
				}
			}
			if (this.m_inst != null)
			{
				throw new InvalidOperationException();
			}
			this.m_inst = new GenericTypeParameterBuilder[names.Length];
			for (int j = 0; j < names.Length; j++)
			{
				this.m_inst[j] = new GenericTypeParameterBuilder(new TypeBuilder(names[j], j, this));
			}
			return this.m_inst;
		}

		// Token: 0x06004DA6 RID: 19878 RVA: 0x00119B8A File Offset: 0x00117D8A
		public override Type MakeGenericType(params Type[] typeArguments)
		{
			this.CheckContext(typeArguments);
			return TypeBuilderInstantiation.MakeGenericType(this, typeArguments);
		}

		// Token: 0x06004DA7 RID: 19879 RVA: 0x00119B9C File Offset: 0x00117D9C
		public override Type[] GetGenericArguments()
		{
			return this.m_inst;
		}

		// Token: 0x17000C2B RID: 3115
		// (get) Token: 0x06004DA8 RID: 19880 RVA: 0x00119BB1 File Offset: 0x00117DB1
		public override bool IsGenericTypeDefinition
		{
			get
			{
				return this.IsGenericType;
			}
		}

		// Token: 0x17000C2C RID: 3116
		// (get) Token: 0x06004DA9 RID: 19881 RVA: 0x00119BB9 File Offset: 0x00117DB9
		public override bool IsGenericType
		{
			get
			{
				return this.m_inst != null;
			}
		}

		// Token: 0x17000C2D RID: 3117
		// (get) Token: 0x06004DAA RID: 19882 RVA: 0x00119BC4 File Offset: 0x00117DC4
		public override bool IsGenericParameter
		{
			get
			{
				return this.m_bIsGenParam;
			}
		}

		// Token: 0x17000C2E RID: 3118
		// (get) Token: 0x06004DAB RID: 19883 RVA: 0x00119BCC File Offset: 0x00117DCC
		public override bool IsConstructedGenericType
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000C2F RID: 3119
		// (get) Token: 0x06004DAC RID: 19884 RVA: 0x00119BCF File Offset: 0x00117DCF
		public override int GenericParameterPosition
		{
			get
			{
				return this.m_genParamPos;
			}
		}

		// Token: 0x17000C30 RID: 3120
		// (get) Token: 0x06004DAD RID: 19885 RVA: 0x00119BD7 File Offset: 0x00117DD7
		public override MethodBase DeclaringMethod
		{
			get
			{
				return this.m_declMeth;
			}
		}

		// Token: 0x06004DAE RID: 19886 RVA: 0x00119BDF File Offset: 0x00117DDF
		public override Type GetGenericTypeDefinition()
		{
			if (this.IsGenericTypeDefinition)
			{
				return this;
			}
			if (this.m_genTypeDef == null)
			{
				throw new InvalidOperationException();
			}
			return this.m_genTypeDef;
		}

		// Token: 0x06004DAF RID: 19887 RVA: 0x00119C08 File Offset: 0x00117E08
		[SecuritySafeCritical]
		public void DefineMethodOverride(MethodInfo methodInfoBody, MethodInfo methodInfoDeclaration)
		{
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.DefineMethodOverrideNoLock(methodInfoBody, methodInfoDeclaration);
			}
		}

		// Token: 0x06004DB0 RID: 19888 RVA: 0x00119C4C File Offset: 0x00117E4C
		[SecurityCritical]
		private void DefineMethodOverrideNoLock(MethodInfo methodInfoBody, MethodInfo methodInfoDeclaration)
		{
			if (methodInfoBody == null)
			{
				throw new ArgumentNullException("methodInfoBody");
			}
			if (methodInfoDeclaration == null)
			{
				throw new ArgumentNullException("methodInfoDeclaration");
			}
			this.ThrowIfCreated();
			if (methodInfoBody.DeclaringType != this)
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentException_BadMethodImplBody"));
			}
			MethodToken methodTokenInternal = this.m_module.GetMethodTokenInternal(methodInfoBody);
			MethodToken methodTokenInternal2 = this.m_module.GetMethodTokenInternal(methodInfoDeclaration);
			TypeBuilder.DefineMethodImpl(this.m_module.GetNativeHandle(), this.m_tdType.Token, methodTokenInternal.Token, methodTokenInternal2.Token);
		}

		// Token: 0x06004DB1 RID: 19889 RVA: 0x00119CE3 File Offset: 0x00117EE3
		public MethodBuilder DefineMethod(string name, MethodAttributes attributes, Type returnType, Type[] parameterTypes)
		{
			return this.DefineMethod(name, attributes, CallingConventions.Standard, returnType, parameterTypes);
		}

		// Token: 0x06004DB2 RID: 19890 RVA: 0x00119CF1 File Offset: 0x00117EF1
		public MethodBuilder DefineMethod(string name, MethodAttributes attributes)
		{
			return this.DefineMethod(name, attributes, CallingConventions.Standard, null, null);
		}

		// Token: 0x06004DB3 RID: 19891 RVA: 0x00119CFE File Offset: 0x00117EFE
		public MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention)
		{
			return this.DefineMethod(name, attributes, callingConvention, null, null);
		}

		// Token: 0x06004DB4 RID: 19892 RVA: 0x00119D0C File Offset: 0x00117F0C
		public MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes)
		{
			return this.DefineMethod(name, attributes, callingConvention, returnType, null, null, parameterTypes, null, null);
		}

		// Token: 0x06004DB5 RID: 19893 RVA: 0x00119D2C File Offset: 0x00117F2C
		public MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers)
		{
			object syncRoot = this.SyncRoot;
			MethodBuilder result;
			lock (syncRoot)
			{
				result = this.DefineMethodNoLock(name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers);
			}
			return result;
		}

		// Token: 0x06004DB6 RID: 19894 RVA: 0x00119D80 File Offset: 0x00117F80
		private MethodBuilder DefineMethodNoLock(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			this.CheckContext(new Type[]
			{
				returnType
			});
			this.CheckContext(new Type[][]
			{
				returnTypeRequiredCustomModifiers,
				returnTypeOptionalCustomModifiers,
				parameterTypes
			});
			this.CheckContext(parameterTypeRequiredCustomModifiers);
			this.CheckContext(parameterTypeOptionalCustomModifiers);
			if (parameterTypes != null)
			{
				if (parameterTypeOptionalCustomModifiers != null && parameterTypeOptionalCustomModifiers.Length != parameterTypes.Length)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_MismatchedArrays", new object[]
					{
						"parameterTypeOptionalCustomModifiers",
						"parameterTypes"
					}));
				}
				if (parameterTypeRequiredCustomModifiers != null && parameterTypeRequiredCustomModifiers.Length != parameterTypes.Length)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_MismatchedArrays", new object[]
					{
						"parameterTypeRequiredCustomModifiers",
						"parameterTypes"
					}));
				}
			}
			this.ThrowIfCreated();
			if (!this.m_isHiddenGlobalType && (this.m_iAttr & TypeAttributes.ClassSemanticsMask) == TypeAttributes.ClassSemanticsMask && (attributes & MethodAttributes.Abstract) == MethodAttributes.PrivateScope && (attributes & MethodAttributes.Static) == MethodAttributes.PrivateScope)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadAttributeOnInterfaceMethod"));
			}
			MethodBuilder methodBuilder = new MethodBuilder(name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers, this.m_module, this, false);
			if (!this.m_isHiddenGlobalType && (methodBuilder.Attributes & MethodAttributes.SpecialName) != MethodAttributes.PrivateScope && methodBuilder.Name.Equals(ConstructorInfo.ConstructorName))
			{
				this.m_constructorCount++;
			}
			this.m_listMethods.Add(methodBuilder);
			return methodBuilder;
		}

		// Token: 0x06004DB7 RID: 19895 RVA: 0x00119EFC File Offset: 0x001180FC
		[SecuritySafeCritical]
		[ComVisible(true)]
		public ConstructorBuilder DefineTypeInitializer()
		{
			object syncRoot = this.SyncRoot;
			ConstructorBuilder result;
			lock (syncRoot)
			{
				result = this.DefineTypeInitializerNoLock();
			}
			return result;
		}

		// Token: 0x06004DB8 RID: 19896 RVA: 0x00119F40 File Offset: 0x00118140
		[SecurityCritical]
		private ConstructorBuilder DefineTypeInitializerNoLock()
		{
			this.ThrowIfCreated();
			MethodAttributes attributes = MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.SpecialName;
			return new ConstructorBuilder(ConstructorInfo.TypeConstructorName, attributes, CallingConventions.Standard, null, this.m_module, this);
		}

		// Token: 0x06004DB9 RID: 19897 RVA: 0x00119F70 File Offset: 0x00118170
		[ComVisible(true)]
		public ConstructorBuilder DefineDefaultConstructor(MethodAttributes attributes)
		{
			if ((this.m_iAttr & TypeAttributes.ClassSemanticsMask) == TypeAttributes.ClassSemanticsMask)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ConstructorNotAllowedOnInterface"));
			}
			object syncRoot = this.SyncRoot;
			ConstructorBuilder result;
			lock (syncRoot)
			{
				result = this.DefineDefaultConstructorNoLock(attributes);
			}
			return result;
		}

		// Token: 0x06004DBA RID: 19898 RVA: 0x00119FD0 File Offset: 0x001181D0
		private ConstructorBuilder DefineDefaultConstructorNoLock(MethodAttributes attributes)
		{
			ConstructorInfo constructorInfo = null;
			if (this.m_typeParent is TypeBuilderInstantiation)
			{
				Type type = this.m_typeParent.GetGenericTypeDefinition();
				if (type is TypeBuilder)
				{
					type = ((TypeBuilder)type).m_bakedRuntimeType;
				}
				if (type == null)
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
				}
				Type type2 = type.MakeGenericType(this.m_typeParent.GetGenericArguments());
				if (type2 is TypeBuilderInstantiation)
				{
					constructorInfo = TypeBuilder.GetConstructor(type2, type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null));
				}
				else
				{
					constructorInfo = type2.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
				}
			}
			if (constructorInfo == null)
			{
				constructorInfo = this.m_typeParent.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
			}
			if (constructorInfo == null)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_NoParentDefaultConstructor"));
			}
			ConstructorBuilder constructorBuilder = this.DefineConstructor(attributes, CallingConventions.Standard, null);
			this.m_constructorCount++;
			ILGenerator ilgenerator = constructorBuilder.GetILGenerator();
			ilgenerator.Emit(OpCodes.Ldarg_0);
			ilgenerator.Emit(OpCodes.Call, constructorInfo);
			ilgenerator.Emit(OpCodes.Ret);
			constructorBuilder.m_isDefaultConstructor = true;
			return constructorBuilder;
		}

		// Token: 0x06004DBB RID: 19899 RVA: 0x0011A0EB File Offset: 0x001182EB
		[ComVisible(true)]
		public ConstructorBuilder DefineConstructor(MethodAttributes attributes, CallingConventions callingConvention, Type[] parameterTypes)
		{
			return this.DefineConstructor(attributes, callingConvention, parameterTypes, null, null);
		}

		// Token: 0x06004DBC RID: 19900 RVA: 0x0011A0F8 File Offset: 0x001182F8
		[SecuritySafeCritical]
		[ComVisible(true)]
		public ConstructorBuilder DefineConstructor(MethodAttributes attributes, CallingConventions callingConvention, Type[] parameterTypes, Type[][] requiredCustomModifiers, Type[][] optionalCustomModifiers)
		{
			if ((this.m_iAttr & TypeAttributes.ClassSemanticsMask) == TypeAttributes.ClassSemanticsMask && (attributes & MethodAttributes.Static) != MethodAttributes.Static)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ConstructorNotAllowedOnInterface"));
			}
			object syncRoot = this.SyncRoot;
			ConstructorBuilder result;
			lock (syncRoot)
			{
				result = this.DefineConstructorNoLock(attributes, callingConvention, parameterTypes, requiredCustomModifiers, optionalCustomModifiers);
			}
			return result;
		}

		// Token: 0x06004DBD RID: 19901 RVA: 0x0011A168 File Offset: 0x00118368
		[SecurityCritical]
		private ConstructorBuilder DefineConstructorNoLock(MethodAttributes attributes, CallingConventions callingConvention, Type[] parameterTypes, Type[][] requiredCustomModifiers, Type[][] optionalCustomModifiers)
		{
			this.CheckContext(parameterTypes);
			this.CheckContext(requiredCustomModifiers);
			this.CheckContext(optionalCustomModifiers);
			this.ThrowIfCreated();
			string name;
			if ((attributes & MethodAttributes.Static) == MethodAttributes.PrivateScope)
			{
				name = ConstructorInfo.ConstructorName;
			}
			else
			{
				name = ConstructorInfo.TypeConstructorName;
			}
			attributes |= MethodAttributes.SpecialName;
			ConstructorBuilder result = new ConstructorBuilder(name, attributes, callingConvention, parameterTypes, requiredCustomModifiers, optionalCustomModifiers, this.m_module, this);
			this.m_constructorCount++;
			return result;
		}

		// Token: 0x06004DBE RID: 19902 RVA: 0x0011A1D4 File Offset: 0x001183D4
		[SecuritySafeCritical]
		public MethodBuilder DefinePInvokeMethod(string name, string dllName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
		{
			return this.DefinePInvokeMethodHelper(name, dllName, name, attributes, callingConvention, returnType, null, null, parameterTypes, null, null, nativeCallConv, nativeCharSet);
		}

		// Token: 0x06004DBF RID: 19903 RVA: 0x0011A1FC File Offset: 0x001183FC
		[SecuritySafeCritical]
		public MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
		{
			return this.DefinePInvokeMethodHelper(name, dllName, entryName, attributes, callingConvention, returnType, null, null, parameterTypes, null, null, nativeCallConv, nativeCharSet);
		}

		// Token: 0x06004DC0 RID: 19904 RVA: 0x0011A224 File Offset: 0x00118424
		[SecuritySafeCritical]
		public MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers, CallingConvention nativeCallConv, CharSet nativeCharSet)
		{
			return this.DefinePInvokeMethodHelper(name, dllName, entryName, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers, nativeCallConv, nativeCharSet);
		}

		// Token: 0x06004DC1 RID: 19905 RVA: 0x0011A250 File Offset: 0x00118450
		[SecuritySafeCritical]
		public TypeBuilder DefineNestedType(string name)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineNestedTypeNoLock(name, TypeAttributes.NestedPrivate, null, null, PackingSize.Unspecified, 0);
			}
			return result;
		}

		// Token: 0x06004DC2 RID: 19906 RVA: 0x0011A298 File Offset: 0x00118498
		[SecuritySafeCritical]
		[ComVisible(true)]
		public TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type parent, Type[] interfaces)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				this.CheckContext(new Type[]
				{
					parent
				});
				this.CheckContext(interfaces);
				result = this.DefineNestedTypeNoLock(name, attr, parent, interfaces, PackingSize.Unspecified, 0);
			}
			return result;
		}

		// Token: 0x06004DC3 RID: 19907 RVA: 0x0011A2FC File Offset: 0x001184FC
		[SecuritySafeCritical]
		public TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type parent)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineNestedTypeNoLock(name, attr, parent, null, PackingSize.Unspecified, 0);
			}
			return result;
		}

		// Token: 0x06004DC4 RID: 19908 RVA: 0x0011A344 File Offset: 0x00118544
		[SecuritySafeCritical]
		public TypeBuilder DefineNestedType(string name, TypeAttributes attr)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineNestedTypeNoLock(name, attr, null, null, PackingSize.Unspecified, 0);
			}
			return result;
		}

		// Token: 0x06004DC5 RID: 19909 RVA: 0x0011A38C File Offset: 0x0011858C
		[SecuritySafeCritical]
		public TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type parent, int typeSize)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineNestedTypeNoLock(name, attr, parent, null, PackingSize.Unspecified, typeSize);
			}
			return result;
		}

		// Token: 0x06004DC6 RID: 19910 RVA: 0x0011A3D8 File Offset: 0x001185D8
		[SecuritySafeCritical]
		public TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type parent, PackingSize packSize)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineNestedTypeNoLock(name, attr, parent, null, packSize, 0);
			}
			return result;
		}

		// Token: 0x06004DC7 RID: 19911 RVA: 0x0011A424 File Offset: 0x00118624
		[SecuritySafeCritical]
		public TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type parent, PackingSize packSize, int typeSize)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineNestedTypeNoLock(name, attr, parent, null, packSize, typeSize);
			}
			return result;
		}

		// Token: 0x06004DC8 RID: 19912 RVA: 0x0011A470 File Offset: 0x00118670
		[SecurityCritical]
		private TypeBuilder DefineNestedTypeNoLock(string name, TypeAttributes attr, Type parent, Type[] interfaces, PackingSize packSize, int typeSize)
		{
			return new TypeBuilder(name, attr, parent, interfaces, this.m_module, packSize, typeSize, this);
		}

		// Token: 0x06004DC9 RID: 19913 RVA: 0x0011A487 File Offset: 0x00118687
		public FieldBuilder DefineField(string fieldName, Type type, FieldAttributes attributes)
		{
			return this.DefineField(fieldName, type, null, null, attributes);
		}

		// Token: 0x06004DCA RID: 19914 RVA: 0x0011A494 File Offset: 0x00118694
		[SecuritySafeCritical]
		public FieldBuilder DefineField(string fieldName, Type type, Type[] requiredCustomModifiers, Type[] optionalCustomModifiers, FieldAttributes attributes)
		{
			object syncRoot = this.SyncRoot;
			FieldBuilder result;
			lock (syncRoot)
			{
				result = this.DefineFieldNoLock(fieldName, type, requiredCustomModifiers, optionalCustomModifiers, attributes);
			}
			return result;
		}

		// Token: 0x06004DCB RID: 19915 RVA: 0x0011A4E0 File Offset: 0x001186E0
		[SecurityCritical]
		private FieldBuilder DefineFieldNoLock(string fieldName, Type type, Type[] requiredCustomModifiers, Type[] optionalCustomModifiers, FieldAttributes attributes)
		{
			this.ThrowIfCreated();
			this.CheckContext(new Type[]
			{
				type
			});
			this.CheckContext(requiredCustomModifiers);
			if (this.m_enumUnderlyingType == null && this.IsEnum && (attributes & FieldAttributes.Static) == FieldAttributes.PrivateScope)
			{
				this.m_enumUnderlyingType = type;
			}
			return new FieldBuilder(this, fieldName, type, requiredCustomModifiers, optionalCustomModifiers, attributes);
		}

		// Token: 0x06004DCC RID: 19916 RVA: 0x0011A53C File Offset: 0x0011873C
		[SecuritySafeCritical]
		public FieldBuilder DefineInitializedData(string name, byte[] data, FieldAttributes attributes)
		{
			object syncRoot = this.SyncRoot;
			FieldBuilder result;
			lock (syncRoot)
			{
				result = this.DefineInitializedDataNoLock(name, data, attributes);
			}
			return result;
		}

		// Token: 0x06004DCD RID: 19917 RVA: 0x0011A584 File Offset: 0x00118784
		[SecurityCritical]
		private FieldBuilder DefineInitializedDataNoLock(string name, byte[] data, FieldAttributes attributes)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return this.DefineDataHelper(name, data, data.Length, attributes);
		}

		// Token: 0x06004DCE RID: 19918 RVA: 0x0011A5A0 File Offset: 0x001187A0
		[SecuritySafeCritical]
		public FieldBuilder DefineUninitializedData(string name, int size, FieldAttributes attributes)
		{
			object syncRoot = this.SyncRoot;
			FieldBuilder result;
			lock (syncRoot)
			{
				result = this.DefineUninitializedDataNoLock(name, size, attributes);
			}
			return result;
		}

		// Token: 0x06004DCF RID: 19919 RVA: 0x0011A5E8 File Offset: 0x001187E8
		[SecurityCritical]
		private FieldBuilder DefineUninitializedDataNoLock(string name, int size, FieldAttributes attributes)
		{
			return this.DefineDataHelper(name, null, size, attributes);
		}

		// Token: 0x06004DD0 RID: 19920 RVA: 0x0011A5F4 File Offset: 0x001187F4
		public PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, Type returnType, Type[] parameterTypes)
		{
			return this.DefineProperty(name, attributes, returnType, null, null, parameterTypes, null, null);
		}

		// Token: 0x06004DD1 RID: 19921 RVA: 0x0011A610 File Offset: 0x00118810
		public PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes)
		{
			return this.DefineProperty(name, attributes, callingConvention, returnType, null, null, parameterTypes, null, null);
		}

		// Token: 0x06004DD2 RID: 19922 RVA: 0x0011A630 File Offset: 0x00118830
		public PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers)
		{
			return this.DefineProperty(name, attributes, (CallingConventions)0, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers);
		}

		// Token: 0x06004DD3 RID: 19923 RVA: 0x0011A654 File Offset: 0x00118854
		[SecuritySafeCritical]
		public PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers)
		{
			object syncRoot = this.SyncRoot;
			PropertyBuilder result;
			lock (syncRoot)
			{
				result = this.DefinePropertyNoLock(name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers);
			}
			return result;
		}

		// Token: 0x06004DD4 RID: 19924 RVA: 0x0011A6A8 File Offset: 0x001188A8
		[SecurityCritical]
		private PropertyBuilder DefinePropertyNoLock(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			this.CheckContext(new Type[]
			{
				returnType
			});
			this.CheckContext(new Type[][]
			{
				returnTypeRequiredCustomModifiers,
				returnTypeOptionalCustomModifiers,
				parameterTypes
			});
			this.CheckContext(parameterTypeRequiredCustomModifiers);
			this.CheckContext(parameterTypeOptionalCustomModifiers);
			this.ThrowIfCreated();
			SignatureHelper propertySigHelper = SignatureHelper.GetPropertySigHelper(this.m_module, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers);
			int sigLength;
			byte[] signature = propertySigHelper.InternalGetSignature(out sigLength);
			PropertyToken prToken = new PropertyToken(TypeBuilder.DefineProperty(this.m_module.GetNativeHandle(), this.m_tdType.Token, name, attributes, signature, sigLength));
			return new PropertyBuilder(this.m_module, name, propertySigHelper, attributes, returnType, prToken, this);
		}

		// Token: 0x06004DD5 RID: 19925 RVA: 0x0011A77C File Offset: 0x0011897C
		[SecuritySafeCritical]
		public EventBuilder DefineEvent(string name, EventAttributes attributes, Type eventtype)
		{
			object syncRoot = this.SyncRoot;
			EventBuilder result;
			lock (syncRoot)
			{
				result = this.DefineEventNoLock(name, attributes, eventtype);
			}
			return result;
		}

		// Token: 0x06004DD6 RID: 19926 RVA: 0x0011A7C4 File Offset: 0x001189C4
		[SecurityCritical]
		private EventBuilder DefineEventNoLock(string name, EventAttributes attributes, Type eventtype)
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
			this.CheckContext(new Type[]
			{
				eventtype
			});
			this.ThrowIfCreated();
			int token = this.m_module.GetTypeTokenInternal(eventtype).Token;
			EventToken evToken = new EventToken(TypeBuilder.DefineEvent(this.m_module.GetNativeHandle(), this.m_tdType.Token, name, attributes, token));
			return new EventBuilder(this.m_module, name, attributes, this, evToken);
		}

		// Token: 0x06004DD7 RID: 19927 RVA: 0x0011A87C File Offset: 0x00118A7C
		[SecuritySafeCritical]
		public TypeInfo CreateTypeInfo()
		{
			object syncRoot = this.SyncRoot;
			TypeInfo result;
			lock (syncRoot)
			{
				result = this.CreateTypeNoLock();
			}
			return result;
		}

		// Token: 0x06004DD8 RID: 19928 RVA: 0x0011A8C0 File Offset: 0x00118AC0
		[SecuritySafeCritical]
		public Type CreateType()
		{
			object syncRoot = this.SyncRoot;
			Type result;
			lock (syncRoot)
			{
				result = this.CreateTypeNoLock();
			}
			return result;
		}

		// Token: 0x06004DD9 RID: 19929 RVA: 0x0011A904 File Offset: 0x00118B04
		internal void CheckContext(params Type[][] typess)
		{
			this.m_module.CheckContext(typess);
		}

		// Token: 0x06004DDA RID: 19930 RVA: 0x0011A912 File Offset: 0x00118B12
		internal void CheckContext(params Type[] types)
		{
			this.m_module.CheckContext(types);
		}

		// Token: 0x06004DDB RID: 19931 RVA: 0x0011A920 File Offset: 0x00118B20
		[SecurityCritical]
		private TypeInfo CreateTypeNoLock()
		{
			if (this.IsCreated())
			{
				return this.m_bakedRuntimeType;
			}
			this.ThrowIfCreated();
			if (this.m_typeInterfaces == null)
			{
				this.m_typeInterfaces = new List<Type>();
			}
			int[] array = new int[this.m_typeInterfaces.Count];
			for (int i = 0; i < this.m_typeInterfaces.Count; i++)
			{
				array[i] = this.m_module.GetTypeTokenInternal(this.m_typeInterfaces[i]).Token;
			}
			int num = 0;
			if (this.m_typeParent != null)
			{
				num = this.m_module.GetTypeTokenInternal(this.m_typeParent).Token;
			}
			if (this.IsGenericParameter)
			{
				int[] array2;
				if (this.m_typeParent != null)
				{
					array2 = new int[this.m_typeInterfaces.Count + 2];
					array2[array2.Length - 2] = num;
				}
				else
				{
					array2 = new int[this.m_typeInterfaces.Count + 1];
				}
				for (int j = 0; j < this.m_typeInterfaces.Count; j++)
				{
					array2[j] = this.m_module.GetTypeTokenInternal(this.m_typeInterfaces[j]).Token;
				}
				int tkParent = (this.m_declMeth == null) ? this.m_DeclaringType.m_tdType.Token : this.m_declMeth.GetToken().Token;
				this.m_tdType = new TypeToken(TypeBuilder.DefineGenericParam(this.m_module.GetNativeHandle(), this.m_strName, tkParent, this.m_genParamAttributes, this.m_genParamPos, array2));
				if (this.m_ca != null)
				{
					foreach (TypeBuilder.CustAttr custAttr in this.m_ca)
					{
						custAttr.Bake(this.m_module, this.MetadataTokenInternal);
					}
				}
				this.m_hasBeenCreated = true;
				return this;
			}
			if ((this.m_tdType.Token & 16777215) != 0 && (num & 16777215) != 0)
			{
				TypeBuilder.SetParentType(this.m_module.GetNativeHandle(), this.m_tdType.Token, num);
			}
			if (this.m_inst != null)
			{
				foreach (GenericTypeParameterBuilder type in this.m_inst)
				{
					if (type is GenericTypeParameterBuilder)
					{
						((GenericTypeParameterBuilder)type).m_type.CreateType();
					}
				}
			}
			if (!this.m_isHiddenGlobalType && this.m_constructorCount == 0 && (this.m_iAttr & TypeAttributes.ClassSemanticsMask) == TypeAttributes.NotPublic && !base.IsValueType && (this.m_iAttr & (TypeAttributes.Abstract | TypeAttributes.Sealed)) != (TypeAttributes.Abstract | TypeAttributes.Sealed))
			{
				this.DefineDefaultConstructor(MethodAttributes.Public);
			}
			int count = this.m_listMethods.Count;
			for (int l = 0; l < count; l++)
			{
				MethodBuilder methodBuilder = this.m_listMethods[l];
				if (methodBuilder.IsGenericMethodDefinition)
				{
					methodBuilder.GetToken();
				}
				MethodAttributes attributes = methodBuilder.Attributes;
				if ((methodBuilder.GetMethodImplementationFlags() & (MethodImplAttributes)135) == MethodImplAttributes.IL && (attributes & MethodAttributes.PinvokeImpl) == MethodAttributes.PrivateScope)
				{
					int sigLength;
					byte[] localSignature = methodBuilder.GetLocalSignature(out sigLength);
					if ((attributes & MethodAttributes.Abstract) != MethodAttributes.PrivateScope && (this.m_iAttr & TypeAttributes.Abstract) == TypeAttributes.NotPublic)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadTypeAttributesNotAbstract"));
					}
					byte[] body = methodBuilder.GetBody();
					if ((attributes & MethodAttributes.Abstract) != MethodAttributes.PrivateScope)
					{
						if (body != null)
						{
							throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadMethodBody"));
						}
					}
					else if (body == null || body.Length == 0)
					{
						if (methodBuilder.m_ilGenerator != null)
						{
							methodBuilder.CreateMethodBodyHelper(methodBuilder.GetILGenerator());
						}
						body = methodBuilder.GetBody();
						if ((body == null || body.Length == 0) && !methodBuilder.m_canBeRuntimeImpl)
						{
							throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadEmptyMethodBody", new object[]
							{
								methodBuilder.Name
							}));
						}
					}
					int maxStack = methodBuilder.GetMaxStack();
					ExceptionHandler[] exceptionHandlers = methodBuilder.GetExceptionHandlers();
					int[] tokenFixups = methodBuilder.GetTokenFixups();
					TypeBuilder.SetMethodIL(this.m_module.GetNativeHandle(), methodBuilder.GetToken().Token, methodBuilder.InitLocals, body, (body != null) ? body.Length : 0, localSignature, sigLength, maxStack, exceptionHandlers, (exceptionHandlers != null) ? exceptionHandlers.Length : 0, tokenFixups, (tokenFixups != null) ? tokenFixups.Length : 0);
					if (this.m_module.ContainingAssemblyBuilder.m_assemblyData.m_access == AssemblyBuilderAccess.Run)
					{
						methodBuilder.ReleaseBakedStructures();
					}
				}
			}
			this.m_hasBeenCreated = true;
			RuntimeType runtimeType = null;
			TypeBuilder.TermCreateClass(this.m_module.GetNativeHandle(), this.m_tdType.Token, JitHelpers.GetObjectHandleOnStack<RuntimeType>(ref runtimeType));
			if (!this.m_isHiddenGlobalType)
			{
				this.m_bakedRuntimeType = runtimeType;
				if (this.m_DeclaringType != null && this.m_DeclaringType.m_bakedRuntimeType != null)
				{
					this.m_DeclaringType.m_bakedRuntimeType.InvalidateCachedNestedType();
				}
				return runtimeType;
			}
			return null;
		}

		// Token: 0x17000C31 RID: 3121
		// (get) Token: 0x06004DDC RID: 19932 RVA: 0x0011ADF8 File Offset: 0x00118FF8
		public int Size
		{
			get
			{
				return this.m_iTypeSize;
			}
		}

		// Token: 0x17000C32 RID: 3122
		// (get) Token: 0x06004DDD RID: 19933 RVA: 0x0011AE00 File Offset: 0x00119000
		public PackingSize PackingSize
		{
			get
			{
				return this.m_iPackingSize;
			}
		}

		// Token: 0x06004DDE RID: 19934 RVA: 0x0011AE08 File Offset: 0x00119008
		public void SetParent(Type parent)
		{
			this.ThrowIfCreated();
			if (parent != null)
			{
				this.CheckContext(new Type[]
				{
					parent
				});
				if (parent.IsInterface)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_CannotSetParentToInterface"));
				}
				this.m_typeParent = parent;
				return;
			}
			else
			{
				if ((this.m_iAttr & TypeAttributes.ClassSemanticsMask) != TypeAttributes.ClassSemanticsMask)
				{
					this.m_typeParent = typeof(object);
					return;
				}
				if ((this.m_iAttr & TypeAttributes.Abstract) == TypeAttributes.NotPublic)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadInterfaceNotAbstract"));
				}
				this.m_typeParent = null;
				return;
			}
		}

		// Token: 0x06004DDF RID: 19935 RVA: 0x0011AE98 File Offset: 0x00119098
		[SecuritySafeCritical]
		[ComVisible(true)]
		public void AddInterfaceImplementation(Type interfaceType)
		{
			if (interfaceType == null)
			{
				throw new ArgumentNullException("interfaceType");
			}
			this.CheckContext(new Type[]
			{
				interfaceType
			});
			this.ThrowIfCreated();
			TypeToken typeTokenInternal = this.m_module.GetTypeTokenInternal(interfaceType);
			TypeBuilder.AddInterfaceImpl(this.m_module.GetNativeHandle(), this.m_tdType.Token, typeTokenInternal.Token);
			this.m_typeInterfaces.Add(interfaceType);
		}

		// Token: 0x06004DE0 RID: 19936 RVA: 0x0011AF0C File Offset: 0x0011910C
		[SecuritySafeCritical]
		public void AddDeclarativeSecurity(SecurityAction action, PermissionSet pset)
		{
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.AddDeclarativeSecurityNoLock(action, pset);
			}
		}

		// Token: 0x06004DE1 RID: 19937 RVA: 0x0011AF50 File Offset: 0x00119150
		[SecurityCritical]
		private void AddDeclarativeSecurityNoLock(SecurityAction action, PermissionSet pset)
		{
			if (pset == null)
			{
				throw new ArgumentNullException("pset");
			}
			if (!Enum.IsDefined(typeof(SecurityAction), action) || action == SecurityAction.RequestMinimum || action == SecurityAction.RequestOptional || action == SecurityAction.RequestRefuse)
			{
				throw new ArgumentOutOfRangeException("action");
			}
			this.ThrowIfCreated();
			byte[] array = null;
			int cb = 0;
			if (!pset.IsEmpty())
			{
				array = pset.EncodeXml();
				cb = array.Length;
			}
			TypeBuilder.AddDeclarativeSecurity(this.m_module.GetNativeHandle(), this.m_tdType.Token, action, array, cb);
		}

		// Token: 0x17000C33 RID: 3123
		// (get) Token: 0x06004DE2 RID: 19938 RVA: 0x0011AFD6 File Offset: 0x001191D6
		public TypeToken TypeToken
		{
			get
			{
				if (this.IsGenericParameter)
				{
					this.ThrowIfCreated();
				}
				return this.m_tdType;
			}
		}

		// Token: 0x06004DE3 RID: 19939 RVA: 0x0011AFEC File Offset: 0x001191EC
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
			TypeBuilder.DefineCustomAttribute(this.m_module, this.m_tdType.Token, this.m_module.GetConstructorToken(con).Token, binaryAttribute, false, false);
		}

		// Token: 0x06004DE4 RID: 19940 RVA: 0x0011B048 File Offset: 0x00119248
		[SecuritySafeCritical]
		public void SetCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			if (customBuilder == null)
			{
				throw new ArgumentNullException("customBuilder");
			}
			customBuilder.CreateCustomAttribute(this.m_module, this.m_tdType.Token);
		}

		// Token: 0x06004DE5 RID: 19941 RVA: 0x0011B06F File Offset: 0x0011926F
		void _TypeBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004DE6 RID: 19942 RVA: 0x0011B076 File Offset: 0x00119276
		void _TypeBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004DE7 RID: 19943 RVA: 0x0011B07D File Offset: 0x0011927D
		void _TypeBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004DE8 RID: 19944 RVA: 0x0011B084 File Offset: 0x00119284
		void _TypeBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x040021AB RID: 8619
		public const int UnspecifiedTypeSize = 0;

		// Token: 0x040021AC RID: 8620
		private List<TypeBuilder.CustAttr> m_ca;

		// Token: 0x040021AD RID: 8621
		private TypeToken m_tdType;

		// Token: 0x040021AE RID: 8622
		private ModuleBuilder m_module;

		// Token: 0x040021AF RID: 8623
		private string m_strName;

		// Token: 0x040021B0 RID: 8624
		private string m_strNameSpace;

		// Token: 0x040021B1 RID: 8625
		private string m_strFullQualName;

		// Token: 0x040021B2 RID: 8626
		private Type m_typeParent;

		// Token: 0x040021B3 RID: 8627
		private List<Type> m_typeInterfaces;

		// Token: 0x040021B4 RID: 8628
		private TypeAttributes m_iAttr;

		// Token: 0x040021B5 RID: 8629
		private GenericParameterAttributes m_genParamAttributes;

		// Token: 0x040021B6 RID: 8630
		internal List<MethodBuilder> m_listMethods;

		// Token: 0x040021B7 RID: 8631
		internal int m_lastTokenizedMethod;

		// Token: 0x040021B8 RID: 8632
		private int m_constructorCount;

		// Token: 0x040021B9 RID: 8633
		private int m_iTypeSize;

		// Token: 0x040021BA RID: 8634
		private PackingSize m_iPackingSize;

		// Token: 0x040021BB RID: 8635
		private TypeBuilder m_DeclaringType;

		// Token: 0x040021BC RID: 8636
		private Type m_enumUnderlyingType;

		// Token: 0x040021BD RID: 8637
		internal bool m_isHiddenGlobalType;

		// Token: 0x040021BE RID: 8638
		private bool m_hasBeenCreated;

		// Token: 0x040021BF RID: 8639
		private RuntimeType m_bakedRuntimeType;

		// Token: 0x040021C0 RID: 8640
		private int m_genParamPos;

		// Token: 0x040021C1 RID: 8641
		private GenericTypeParameterBuilder[] m_inst;

		// Token: 0x040021C2 RID: 8642
		private bool m_bIsGenParam;

		// Token: 0x040021C3 RID: 8643
		private MethodBuilder m_declMeth;

		// Token: 0x040021C4 RID: 8644
		private TypeBuilder m_genTypeDef;

		// Token: 0x02000C41 RID: 3137
		private class CustAttr
		{
			// Token: 0x06007063 RID: 28771 RVA: 0x001831C0 File Offset: 0x001813C0
			public CustAttr(ConstructorInfo con, byte[] binaryAttribute)
			{
				if (con == null)
				{
					throw new ArgumentNullException("con");
				}
				if (binaryAttribute == null)
				{
					throw new ArgumentNullException("binaryAttribute");
				}
				this.m_con = con;
				this.m_binaryAttribute = binaryAttribute;
			}

			// Token: 0x06007064 RID: 28772 RVA: 0x001831F8 File Offset: 0x001813F8
			public CustAttr(CustomAttributeBuilder customBuilder)
			{
				if (customBuilder == null)
				{
					throw new ArgumentNullException("customBuilder");
				}
				this.m_customBuilder = customBuilder;
			}

			// Token: 0x06007065 RID: 28773 RVA: 0x00183218 File Offset: 0x00181418
			[SecurityCritical]
			public void Bake(ModuleBuilder module, int token)
			{
				if (this.m_customBuilder == null)
				{
					TypeBuilder.DefineCustomAttribute(module, token, module.GetConstructorToken(this.m_con).Token, this.m_binaryAttribute, false, false);
					return;
				}
				this.m_customBuilder.CreateCustomAttribute(module, token);
			}

			// Token: 0x04003754 RID: 14164
			private ConstructorInfo m_con;

			// Token: 0x04003755 RID: 14165
			private byte[] m_binaryAttribute;

			// Token: 0x04003756 RID: 14166
			private CustomAttributeBuilder m_customBuilder;
		}
	}
}
