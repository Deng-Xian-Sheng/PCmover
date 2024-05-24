using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;

namespace System.Reflection
{
	// Token: 0x0200060D RID: 1549
	[Serializable]
	internal class RuntimeModule : Module
	{
		// Token: 0x060047BB RID: 18363 RVA: 0x00104F7B File Offset: 0x0010317B
		internal RuntimeModule()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060047BC RID: 18364
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetType(RuntimeModule module, string className, bool ignoreCase, bool throwOnError, ObjectHandleOnStack type);

		// Token: 0x060047BD RID: 18365
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall")]
		private static extern bool nIsTransientInternal(RuntimeModule module);

		// Token: 0x060047BE RID: 18366
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetScopeName(RuntimeModule module, StringHandleOnStack retString);

		// Token: 0x060047BF RID: 18367
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetFullyQualifiedName(RuntimeModule module, StringHandleOnStack retString);

		// Token: 0x060047C0 RID: 18368
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern RuntimeType[] GetTypes(RuntimeModule module);

		// Token: 0x060047C1 RID: 18369 RVA: 0x00104F88 File Offset: 0x00103188
		[SecuritySafeCritical]
		internal RuntimeType[] GetDefinedTypes()
		{
			return RuntimeModule.GetTypes(this.GetNativeHandle());
		}

		// Token: 0x060047C2 RID: 18370
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsResource(RuntimeModule module);

		// Token: 0x060047C3 RID: 18371
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetSignerCertificate(RuntimeModule module, ObjectHandleOnStack retData);

		// Token: 0x060047C4 RID: 18372 RVA: 0x00104F98 File Offset: 0x00103198
		private static RuntimeTypeHandle[] ConvertToTypeHandleArray(Type[] genericArguments)
		{
			if (genericArguments == null)
			{
				return null;
			}
			int num = genericArguments.Length;
			RuntimeTypeHandle[] array = new RuntimeTypeHandle[num];
			for (int i = 0; i < num; i++)
			{
				Type type = genericArguments[i];
				if (type == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidGenericInstArray"));
				}
				type = type.UnderlyingSystemType;
				if (type == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidGenericInstArray"));
				}
				if (!(type is RuntimeType))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidGenericInstArray"));
				}
				array[i] = type.GetTypeHandleInternal();
			}
			return array;
		}

		// Token: 0x060047C5 RID: 18373 RVA: 0x00105024 File Offset: 0x00103224
		[SecuritySafeCritical]
		public override byte[] ResolveSignature(int metadataToken)
		{
			MetadataToken metadataToken2 = new MetadataToken(metadataToken);
			if (!this.MetadataImport.IsValidToken(metadataToken2))
			{
				throw new ArgumentOutOfRangeException("metadataToken", Environment.GetResourceString("Argument_InvalidToken", new object[]
				{
					metadataToken2,
					this
				}));
			}
			if (!metadataToken2.IsMemberRef && !metadataToken2.IsMethodDef && !metadataToken2.IsTypeSpec && !metadataToken2.IsSignature && !metadataToken2.IsFieldDef)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidToken", new object[]
				{
					metadataToken2,
					this
				}), "metadataToken");
			}
			ConstArray constArray;
			if (metadataToken2.IsMemberRef)
			{
				constArray = this.MetadataImport.GetMemberRefProps(metadataToken);
			}
			else
			{
				constArray = this.MetadataImport.GetSignatureFromToken(metadataToken);
			}
			byte[] array = new byte[constArray.Length];
			for (int i = 0; i < constArray.Length; i++)
			{
				array[i] = constArray[i];
			}
			return array;
		}

		// Token: 0x060047C6 RID: 18374 RVA: 0x00105128 File Offset: 0x00103328
		[SecuritySafeCritical]
		public unsafe override MethodBase ResolveMethod(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			MetadataToken metadataToken2 = new MetadataToken(metadataToken);
			if (!this.MetadataImport.IsValidToken(metadataToken2))
			{
				throw new ArgumentOutOfRangeException("metadataToken", Environment.GetResourceString("Argument_InvalidToken", new object[]
				{
					metadataToken2,
					this
				}));
			}
			RuntimeTypeHandle[] typeInstantiationContext = RuntimeModule.ConvertToTypeHandleArray(genericTypeArguments);
			RuntimeTypeHandle[] methodInstantiationContext = RuntimeModule.ConvertToTypeHandleArray(genericMethodArguments);
			MethodBase methodBase;
			try
			{
				if (!metadataToken2.IsMethodDef && !metadataToken2.IsMethodSpec)
				{
					if (!metadataToken2.IsMemberRef)
					{
						throw new ArgumentException("metadataToken", Environment.GetResourceString("Argument_ResolveMethod", new object[]
						{
							metadataToken2,
							this
						}));
					}
					if (*(byte*)this.MetadataImport.GetMemberRefProps(metadataToken2).Signature.ToPointer() == 6)
					{
						throw new ArgumentException("metadataToken", Environment.GetResourceString("Argument_ResolveMethod", new object[]
						{
							metadataToken2,
							this
						}));
					}
				}
				IRuntimeMethodInfo runtimeMethodInfo = ModuleHandle.ResolveMethodHandleInternal(this.GetNativeHandle(), metadataToken2, typeInstantiationContext, methodInstantiationContext);
				Type type = RuntimeMethodHandle.GetDeclaringType(runtimeMethodInfo);
				if (type.IsGenericType || type.IsArray)
				{
					MetadataToken token = new MetadataToken(this.MetadataImport.GetParentToken(metadataToken2));
					if (metadataToken2.IsMethodSpec)
					{
						token = new MetadataToken(this.MetadataImport.GetParentToken(token));
					}
					type = this.ResolveType(token, genericTypeArguments, genericMethodArguments);
				}
				methodBase = RuntimeType.GetMethodBase(type as RuntimeType, runtimeMethodInfo);
			}
			catch (BadImageFormatException innerException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadImageFormatExceptionResolve"), innerException);
			}
			return methodBase;
		}

		// Token: 0x060047C7 RID: 18375 RVA: 0x001052EC File Offset: 0x001034EC
		[SecurityCritical]
		private FieldInfo ResolveLiteralField(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			MetadataToken metadataToken2 = new MetadataToken(metadataToken);
			if (!this.MetadataImport.IsValidToken(metadataToken2) || !metadataToken2.IsFieldDef)
			{
				throw new ArgumentOutOfRangeException("metadataToken", string.Format(CultureInfo.CurrentUICulture, Environment.GetResourceString("Argument_InvalidToken", new object[]
				{
					metadataToken2,
					this
				}), Array.Empty<object>()));
			}
			string name = this.MetadataImport.GetName(metadataToken2).ToString();
			int parentToken = this.MetadataImport.GetParentToken(metadataToken2);
			Type type = this.ResolveType(parentToken, genericTypeArguments, genericMethodArguments);
			type.GetFields();
			FieldInfo field;
			try
			{
				field = type.GetField(name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
			catch
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ResolveField", new object[]
				{
					metadataToken2,
					this
				}), "metadataToken");
			}
			return field;
		}

		// Token: 0x060047C8 RID: 18376 RVA: 0x001053EC File Offset: 0x001035EC
		[SecuritySafeCritical]
		public unsafe override FieldInfo ResolveField(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			MetadataToken metadataToken2 = new MetadataToken(metadataToken);
			if (!this.MetadataImport.IsValidToken(metadataToken2))
			{
				throw new ArgumentOutOfRangeException("metadataToken", Environment.GetResourceString("Argument_InvalidToken", new object[]
				{
					metadataToken2,
					this
				}));
			}
			RuntimeTypeHandle[] typeInstantiationContext = RuntimeModule.ConvertToTypeHandleArray(genericTypeArguments);
			RuntimeTypeHandle[] methodInstantiationContext = RuntimeModule.ConvertToTypeHandleArray(genericMethodArguments);
			FieldInfo result;
			try
			{
				IRuntimeFieldInfo runtimeFieldInfo;
				if (!metadataToken2.IsFieldDef)
				{
					if (!metadataToken2.IsMemberRef)
					{
						throw new ArgumentException("metadataToken", Environment.GetResourceString("Argument_ResolveField", new object[]
						{
							metadataToken2,
							this
						}));
					}
					if (*(byte*)this.MetadataImport.GetMemberRefProps(metadataToken2).Signature.ToPointer() != 6)
					{
						throw new ArgumentException("metadataToken", Environment.GetResourceString("Argument_ResolveField", new object[]
						{
							metadataToken2,
							this
						}));
					}
					runtimeFieldInfo = ModuleHandle.ResolveFieldHandleInternal(this.GetNativeHandle(), metadataToken2, typeInstantiationContext, methodInstantiationContext);
				}
				runtimeFieldInfo = ModuleHandle.ResolveFieldHandleInternal(this.GetNativeHandle(), metadataToken, typeInstantiationContext, methodInstantiationContext);
				RuntimeType runtimeType = RuntimeFieldHandle.GetApproxDeclaringType(runtimeFieldInfo.Value);
				if (runtimeType.IsGenericType || runtimeType.IsArray)
				{
					int parentToken = ModuleHandle.GetMetadataImport(this.GetNativeHandle()).GetParentToken(metadataToken);
					runtimeType = (RuntimeType)this.ResolveType(parentToken, genericTypeArguments, genericMethodArguments);
				}
				result = RuntimeType.GetFieldInfo(runtimeType, runtimeFieldInfo);
			}
			catch (MissingFieldException)
			{
				result = this.ResolveLiteralField(metadataToken2, genericTypeArguments, genericMethodArguments);
			}
			catch (BadImageFormatException innerException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadImageFormatExceptionResolve"), innerException);
			}
			return result;
		}

		// Token: 0x060047C9 RID: 18377 RVA: 0x001055B8 File Offset: 0x001037B8
		[SecuritySafeCritical]
		public override Type ResolveType(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			MetadataToken metadataToken2 = new MetadataToken(metadataToken);
			if (metadataToken2.IsGlobalTypeDefToken)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ResolveModuleType", new object[]
				{
					metadataToken2
				}), "metadataToken");
			}
			if (!this.MetadataImport.IsValidToken(metadataToken2))
			{
				throw new ArgumentOutOfRangeException("metadataToken", Environment.GetResourceString("Argument_InvalidToken", new object[]
				{
					metadataToken2,
					this
				}));
			}
			if (!metadataToken2.IsTypeDef && !metadataToken2.IsTypeSpec && !metadataToken2.IsTypeRef)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ResolveType", new object[]
				{
					metadataToken2,
					this
				}), "metadataToken");
			}
			RuntimeTypeHandle[] typeInstantiationContext = RuntimeModule.ConvertToTypeHandleArray(genericTypeArguments);
			RuntimeTypeHandle[] methodInstantiationContext = RuntimeModule.ConvertToTypeHandleArray(genericMethodArguments);
			Type result;
			try
			{
				Type runtimeType = this.GetModuleHandle().ResolveTypeHandle(metadataToken, typeInstantiationContext, methodInstantiationContext).GetRuntimeType();
				if (runtimeType == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_ResolveType", new object[]
					{
						metadataToken2,
						this
					}), "metadataToken");
				}
				result = runtimeType;
			}
			catch (BadImageFormatException innerException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadImageFormatExceptionResolve"), innerException);
			}
			return result;
		}

		// Token: 0x060047CA RID: 18378 RVA: 0x00105704 File Offset: 0x00103904
		[SecuritySafeCritical]
		public unsafe override MemberInfo ResolveMember(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			MetadataToken metadataToken2 = new MetadataToken(metadataToken);
			if (metadataToken2.IsProperty)
			{
				throw new ArgumentException(Environment.GetResourceString("InvalidOperation_PropertyInfoNotAvailable"));
			}
			if (metadataToken2.IsEvent)
			{
				throw new ArgumentException(Environment.GetResourceString("InvalidOperation_EventInfoNotAvailable"));
			}
			if (metadataToken2.IsMethodSpec || metadataToken2.IsMethodDef)
			{
				return this.ResolveMethod(metadataToken, genericTypeArguments, genericMethodArguments);
			}
			if (metadataToken2.IsFieldDef)
			{
				return this.ResolveField(metadataToken, genericTypeArguments, genericMethodArguments);
			}
			if (metadataToken2.IsTypeRef || metadataToken2.IsTypeDef || metadataToken2.IsTypeSpec)
			{
				return this.ResolveType(metadataToken, genericTypeArguments, genericMethodArguments);
			}
			if (!metadataToken2.IsMemberRef)
			{
				throw new ArgumentException("metadataToken", Environment.GetResourceString("Argument_ResolveMember", new object[]
				{
					metadataToken2,
					this
				}));
			}
			if (!this.MetadataImport.IsValidToken(metadataToken2))
			{
				throw new ArgumentOutOfRangeException("metadataToken", Environment.GetResourceString("Argument_InvalidToken", new object[]
				{
					metadataToken2,
					this
				}));
			}
			if (*(byte*)this.MetadataImport.GetMemberRefProps(metadataToken2).Signature.ToPointer() == 6)
			{
				return this.ResolveField(metadataToken2, genericTypeArguments, genericMethodArguments);
			}
			return this.ResolveMethod(metadataToken2, genericTypeArguments, genericMethodArguments);
		}

		// Token: 0x060047CB RID: 18379 RVA: 0x00105858 File Offset: 0x00103A58
		[SecuritySafeCritical]
		public override string ResolveString(int metadataToken)
		{
			MetadataToken metadataToken2 = new MetadataToken(metadataToken);
			if (!metadataToken2.IsString)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentUICulture, Environment.GetResourceString("Argument_ResolveString"), metadataToken, this.ToString()));
			}
			if (!this.MetadataImport.IsValidToken(metadataToken2))
			{
				throw new ArgumentOutOfRangeException("metadataToken", string.Format(CultureInfo.CurrentUICulture, Environment.GetResourceString("Argument_InvalidToken", new object[]
				{
					metadataToken2,
					this
				}), Array.Empty<object>()));
			}
			string userString = this.MetadataImport.GetUserString(metadataToken);
			if (userString == null)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentUICulture, Environment.GetResourceString("Argument_ResolveString"), metadataToken, this.ToString()));
			}
			return userString;
		}

		// Token: 0x060047CC RID: 18380 RVA: 0x00105923 File Offset: 0x00103B23
		public override void GetPEKind(out PortableExecutableKinds peKind, out ImageFileMachine machine)
		{
			ModuleHandle.GetPEKind(this.GetNativeHandle(), out peKind, out machine);
		}

		// Token: 0x17000B07 RID: 2823
		// (get) Token: 0x060047CD RID: 18381 RVA: 0x00105932 File Offset: 0x00103B32
		public override int MDStreamVersion
		{
			[SecuritySafeCritical]
			get
			{
				return ModuleHandle.GetMDStreamVersion(this.GetNativeHandle());
			}
		}

		// Token: 0x060047CE RID: 18382 RVA: 0x0010593F File Offset: 0x00103B3F
		protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			return this.GetMethodInternal(name, bindingAttr, binder, callConvention, types, modifiers);
		}

		// Token: 0x060047CF RID: 18383 RVA: 0x00105950 File Offset: 0x00103B50
		internal MethodInfo GetMethodInternal(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			if (this.RuntimeType == null)
			{
				return null;
			}
			if (types == null)
			{
				return this.RuntimeType.GetMethod(name, bindingAttr);
			}
			return this.RuntimeType.GetMethod(name, bindingAttr, binder, callConvention, types, modifiers);
		}

		// Token: 0x17000B08 RID: 2824
		// (get) Token: 0x060047D0 RID: 18384 RVA: 0x00105988 File Offset: 0x00103B88
		internal RuntimeType RuntimeType
		{
			get
			{
				if (this.m_runtimeType == null)
				{
					this.m_runtimeType = ModuleHandle.GetModuleType(this.GetNativeHandle());
				}
				return this.m_runtimeType;
			}
		}

		// Token: 0x060047D1 RID: 18385 RVA: 0x001059AF File Offset: 0x00103BAF
		[SecuritySafeCritical]
		internal bool IsTransientInternal()
		{
			return RuntimeModule.nIsTransientInternal(this.GetNativeHandle());
		}

		// Token: 0x17000B09 RID: 2825
		// (get) Token: 0x060047D2 RID: 18386 RVA: 0x001059BC File Offset: 0x00103BBC
		internal MetadataImport MetadataImport
		{
			[SecurityCritical]
			get
			{
				return ModuleHandle.GetMetadataImport(this.GetNativeHandle());
			}
		}

		// Token: 0x060047D3 RID: 18387 RVA: 0x001059C9 File Offset: 0x00103BC9
		public override object[] GetCustomAttributes(bool inherit)
		{
			return CustomAttribute.GetCustomAttributes(this, typeof(object) as RuntimeType);
		}

		// Token: 0x060047D4 RID: 18388 RVA: 0x001059E0 File Offset: 0x00103BE0
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

		// Token: 0x060047D5 RID: 18389 RVA: 0x00105A34 File Offset: 0x00103C34
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

		// Token: 0x060047D6 RID: 18390 RVA: 0x00105A86 File Offset: 0x00103C86
		public override IList<CustomAttributeData> GetCustomAttributesData()
		{
			return CustomAttributeData.GetCustomAttributesInternal(this);
		}

		// Token: 0x060047D7 RID: 18391 RVA: 0x00105A8E File Offset: 0x00103C8E
		[SecurityCritical]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			UnitySerializationHolder.GetUnitySerializationInfo(info, 5, this.ScopeName, this.GetRuntimeAssembly());
		}

		// Token: 0x060047D8 RID: 18392 RVA: 0x00105AB4 File Offset: 0x00103CB4
		[SecuritySafeCritical]
		[ComVisible(true)]
		public override Type GetType(string className, bool throwOnError, bool ignoreCase)
		{
			if (className == null)
			{
				throw new ArgumentNullException("className");
			}
			RuntimeType result = null;
			RuntimeModule.GetType(this.GetNativeHandle(), className, throwOnError, ignoreCase, JitHelpers.GetObjectHandleOnStack<RuntimeType>(ref result));
			return result;
		}

		// Token: 0x060047D9 RID: 18393 RVA: 0x00105AE8 File Offset: 0x00103CE8
		[SecurityCritical]
		internal string GetFullyQualifiedName()
		{
			string result = null;
			RuntimeModule.GetFullyQualifiedName(this.GetNativeHandle(), JitHelpers.GetStringHandleOnStack(ref result));
			return result;
		}

		// Token: 0x17000B0A RID: 2826
		// (get) Token: 0x060047DA RID: 18394 RVA: 0x00105B0C File Offset: 0x00103D0C
		public override string FullyQualifiedName
		{
			[SecuritySafeCritical]
			get
			{
				string fullyQualifiedName = this.GetFullyQualifiedName();
				if (fullyQualifiedName != null)
				{
					bool flag = true;
					try
					{
						Path.GetFullPathInternal(fullyQualifiedName);
					}
					catch (ArgumentException)
					{
						flag = false;
					}
					if (flag)
					{
						new FileIOPermission(FileIOPermissionAccess.PathDiscovery, fullyQualifiedName).Demand();
					}
				}
				return fullyQualifiedName;
			}
		}

		// Token: 0x060047DB RID: 18395 RVA: 0x00105B54 File Offset: 0x00103D54
		[SecuritySafeCritical]
		public override Type[] GetTypes()
		{
			return RuntimeModule.GetTypes(this.GetNativeHandle());
		}

		// Token: 0x17000B0B RID: 2827
		// (get) Token: 0x060047DC RID: 18396 RVA: 0x00105B70 File Offset: 0x00103D70
		public override Guid ModuleVersionId
		{
			[SecuritySafeCritical]
			get
			{
				Guid result;
				this.MetadataImport.GetScopeProps(out result);
				return result;
			}
		}

		// Token: 0x17000B0C RID: 2828
		// (get) Token: 0x060047DD RID: 18397 RVA: 0x00105B8E File Offset: 0x00103D8E
		public override int MetadataToken
		{
			[SecuritySafeCritical]
			get
			{
				return ModuleHandle.GetToken(this.GetNativeHandle());
			}
		}

		// Token: 0x060047DE RID: 18398 RVA: 0x00105B9B File Offset: 0x00103D9B
		public override bool IsResource()
		{
			return RuntimeModule.IsResource(this.GetNativeHandle());
		}

		// Token: 0x060047DF RID: 18399 RVA: 0x00105BA8 File Offset: 0x00103DA8
		public override FieldInfo[] GetFields(BindingFlags bindingFlags)
		{
			if (this.RuntimeType == null)
			{
				return new FieldInfo[0];
			}
			return this.RuntimeType.GetFields(bindingFlags);
		}

		// Token: 0x060047E0 RID: 18400 RVA: 0x00105BCB File Offset: 0x00103DCB
		public override FieldInfo GetField(string name, BindingFlags bindingAttr)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (this.RuntimeType == null)
			{
				return null;
			}
			return this.RuntimeType.GetField(name, bindingAttr);
		}

		// Token: 0x060047E1 RID: 18401 RVA: 0x00105BF8 File Offset: 0x00103DF8
		public override MethodInfo[] GetMethods(BindingFlags bindingFlags)
		{
			if (this.RuntimeType == null)
			{
				return new MethodInfo[0];
			}
			return this.RuntimeType.GetMethods(bindingFlags);
		}

		// Token: 0x17000B0D RID: 2829
		// (get) Token: 0x060047E2 RID: 18402 RVA: 0x00105C1C File Offset: 0x00103E1C
		public override string ScopeName
		{
			[SecuritySafeCritical]
			get
			{
				string result = null;
				RuntimeModule.GetScopeName(this.GetNativeHandle(), JitHelpers.GetStringHandleOnStack(ref result));
				return result;
			}
		}

		// Token: 0x17000B0E RID: 2830
		// (get) Token: 0x060047E3 RID: 18403 RVA: 0x00105C40 File Offset: 0x00103E40
		public override string Name
		{
			[SecuritySafeCritical]
			get
			{
				string fullyQualifiedName = this.GetFullyQualifiedName();
				int num = fullyQualifiedName.LastIndexOf('\\');
				if (num == -1)
				{
					return fullyQualifiedName;
				}
				return new string(fullyQualifiedName.ToCharArray(), num + 1, fullyQualifiedName.Length - num - 1);
			}
		}

		// Token: 0x17000B0F RID: 2831
		// (get) Token: 0x060047E4 RID: 18404 RVA: 0x00105C7B File Offset: 0x00103E7B
		public override Assembly Assembly
		{
			get
			{
				return this.GetRuntimeAssembly();
			}
		}

		// Token: 0x060047E5 RID: 18405 RVA: 0x00105C83 File Offset: 0x00103E83
		internal RuntimeAssembly GetRuntimeAssembly()
		{
			return this.m_runtimeAssembly;
		}

		// Token: 0x060047E6 RID: 18406 RVA: 0x00105C8B File Offset: 0x00103E8B
		internal override ModuleHandle GetModuleHandle()
		{
			return new ModuleHandle(this);
		}

		// Token: 0x060047E7 RID: 18407 RVA: 0x00105C93 File Offset: 0x00103E93
		internal RuntimeModule GetNativeHandle()
		{
			return this;
		}

		// Token: 0x060047E8 RID: 18408 RVA: 0x00105C98 File Offset: 0x00103E98
		[SecuritySafeCritical]
		public override X509Certificate GetSignerCertificate()
		{
			byte[] array = null;
			RuntimeModule.GetSignerCertificate(this.GetNativeHandle(), JitHelpers.GetObjectHandleOnStack<byte[]>(ref array));
			if (array == null)
			{
				return null;
			}
			return new X509Certificate(array);
		}

		// Token: 0x04001DB6 RID: 7606
		private RuntimeType m_runtimeType;

		// Token: 0x04001DB7 RID: 7607
		private RuntimeAssembly m_runtimeAssembly;

		// Token: 0x04001DB8 RID: 7608
		private IntPtr m_pRefClass;

		// Token: 0x04001DB9 RID: 7609
		private IntPtr m_pData;

		// Token: 0x04001DBA RID: 7610
		private IntPtr m_pGlobals;

		// Token: 0x04001DBB RID: 7611
		private IntPtr m_pFields;
	}
}
