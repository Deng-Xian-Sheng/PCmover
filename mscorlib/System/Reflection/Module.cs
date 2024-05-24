using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;

namespace System.Reflection
{
	// Token: 0x0200060C RID: 1548
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_Module))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
	[Serializable]
	public abstract class Module : _Module, ISerializable, ICustomAttributeProvider
	{
		// Token: 0x06004785 RID: 18309 RVA: 0x001049D8 File Offset: 0x00102BD8
		static Module()
		{
			__Filters @object = new __Filters();
			Module.FilterTypeName = new TypeFilter(@object.FilterTypeName);
			Module.FilterTypeNameIgnoreCase = new TypeFilter(@object.FilterTypeNameIgnoreCase);
		}

		// Token: 0x06004787 RID: 18311 RVA: 0x00104A17 File Offset: 0x00102C17
		[__DynamicallyInvokable]
		public static bool operator ==(Module left, Module right)
		{
			return left == right || (left != null && right != null && !(left is RuntimeModule) && !(right is RuntimeModule) && left.Equals(right));
		}

		// Token: 0x06004788 RID: 18312 RVA: 0x00104A3E File Offset: 0x00102C3E
		[__DynamicallyInvokable]
		public static bool operator !=(Module left, Module right)
		{
			return !(left == right);
		}

		// Token: 0x06004789 RID: 18313 RVA: 0x00104A4A File Offset: 0x00102C4A
		[__DynamicallyInvokable]
		public override bool Equals(object o)
		{
			return base.Equals(o);
		}

		// Token: 0x0600478A RID: 18314 RVA: 0x00104A53 File Offset: 0x00102C53
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x0600478B RID: 18315 RVA: 0x00104A5B File Offset: 0x00102C5B
		[__DynamicallyInvokable]
		public override string ToString()
		{
			return this.ScopeName;
		}

		// Token: 0x17000AFE RID: 2814
		// (get) Token: 0x0600478C RID: 18316 RVA: 0x00104A63 File Offset: 0x00102C63
		[__DynamicallyInvokable]
		public virtual IEnumerable<CustomAttributeData> CustomAttributes
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetCustomAttributesData();
			}
		}

		// Token: 0x0600478D RID: 18317 RVA: 0x00104A6B File Offset: 0x00102C6B
		public virtual object[] GetCustomAttributes(bool inherit)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600478E RID: 18318 RVA: 0x00104A72 File Offset: 0x00102C72
		public virtual object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600478F RID: 18319 RVA: 0x00104A79 File Offset: 0x00102C79
		public virtual bool IsDefined(Type attributeType, bool inherit)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004790 RID: 18320 RVA: 0x00104A80 File Offset: 0x00102C80
		public virtual IList<CustomAttributeData> GetCustomAttributesData()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004791 RID: 18321 RVA: 0x00104A87 File Offset: 0x00102C87
		public MethodBase ResolveMethod(int metadataToken)
		{
			return this.ResolveMethod(metadataToken, null, null);
		}

		// Token: 0x06004792 RID: 18322 RVA: 0x00104A94 File Offset: 0x00102C94
		public virtual MethodBase ResolveMethod(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.ResolveMethod(metadataToken, genericTypeArguments, genericMethodArguments);
			}
			throw new NotImplementedException();
		}

		// Token: 0x06004793 RID: 18323 RVA: 0x00104AC0 File Offset: 0x00102CC0
		public FieldInfo ResolveField(int metadataToken)
		{
			return this.ResolveField(metadataToken, null, null);
		}

		// Token: 0x06004794 RID: 18324 RVA: 0x00104ACC File Offset: 0x00102CCC
		public virtual FieldInfo ResolveField(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.ResolveField(metadataToken, genericTypeArguments, genericMethodArguments);
			}
			throw new NotImplementedException();
		}

		// Token: 0x06004795 RID: 18325 RVA: 0x00104AF8 File Offset: 0x00102CF8
		public Type ResolveType(int metadataToken)
		{
			return this.ResolveType(metadataToken, null, null);
		}

		// Token: 0x06004796 RID: 18326 RVA: 0x00104B04 File Offset: 0x00102D04
		public virtual Type ResolveType(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.ResolveType(metadataToken, genericTypeArguments, genericMethodArguments);
			}
			throw new NotImplementedException();
		}

		// Token: 0x06004797 RID: 18327 RVA: 0x00104B30 File Offset: 0x00102D30
		public MemberInfo ResolveMember(int metadataToken)
		{
			return this.ResolveMember(metadataToken, null, null);
		}

		// Token: 0x06004798 RID: 18328 RVA: 0x00104B3C File Offset: 0x00102D3C
		public virtual MemberInfo ResolveMember(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.ResolveMember(metadataToken, genericTypeArguments, genericMethodArguments);
			}
			throw new NotImplementedException();
		}

		// Token: 0x06004799 RID: 18329 RVA: 0x00104B68 File Offset: 0x00102D68
		public virtual byte[] ResolveSignature(int metadataToken)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.ResolveSignature(metadataToken);
			}
			throw new NotImplementedException();
		}

		// Token: 0x0600479A RID: 18330 RVA: 0x00104B94 File Offset: 0x00102D94
		public virtual string ResolveString(int metadataToken)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.ResolveString(metadataToken);
			}
			throw new NotImplementedException();
		}

		// Token: 0x0600479B RID: 18331 RVA: 0x00104BC0 File Offset: 0x00102DC0
		public virtual void GetPEKind(out PortableExecutableKinds peKind, out ImageFileMachine machine)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				runtimeModule.GetPEKind(out peKind, out machine);
			}
			throw new NotImplementedException();
		}

		// Token: 0x17000AFF RID: 2815
		// (get) Token: 0x0600479C RID: 18332 RVA: 0x00104BEC File Offset: 0x00102DEC
		public virtual int MDStreamVersion
		{
			get
			{
				RuntimeModule runtimeModule = this as RuntimeModule;
				if (runtimeModule != null)
				{
					return runtimeModule.MDStreamVersion;
				}
				throw new NotImplementedException();
			}
		}

		// Token: 0x0600479D RID: 18333 RVA: 0x00104C15 File Offset: 0x00102E15
		[SecurityCritical]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600479E RID: 18334 RVA: 0x00104C1C File Offset: 0x00102E1C
		[ComVisible(true)]
		public virtual Type GetType(string className, bool ignoreCase)
		{
			return this.GetType(className, false, ignoreCase);
		}

		// Token: 0x0600479F RID: 18335 RVA: 0x00104C27 File Offset: 0x00102E27
		[ComVisible(true)]
		public virtual Type GetType(string className)
		{
			return this.GetType(className, false, false);
		}

		// Token: 0x060047A0 RID: 18336 RVA: 0x00104C32 File Offset: 0x00102E32
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public virtual Type GetType(string className, bool throwOnError, bool ignoreCase)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000B00 RID: 2816
		// (get) Token: 0x060047A1 RID: 18337 RVA: 0x00104C39 File Offset: 0x00102E39
		[__DynamicallyInvokable]
		public virtual string FullyQualifiedName
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060047A2 RID: 18338 RVA: 0x00104C40 File Offset: 0x00102E40
		public virtual Type[] FindTypes(TypeFilter filter, object filterCriteria)
		{
			Type[] types = this.GetTypes();
			int num = 0;
			for (int i = 0; i < types.Length; i++)
			{
				if (filter != null && !filter(types[i], filterCriteria))
				{
					types[i] = null;
				}
				else
				{
					num++;
				}
			}
			if (num == types.Length)
			{
				return types;
			}
			Type[] array = new Type[num];
			num = 0;
			for (int j = 0; j < types.Length; j++)
			{
				if (types[j] != null)
				{
					array[num++] = types[j];
				}
			}
			return array;
		}

		// Token: 0x060047A3 RID: 18339 RVA: 0x00104CB8 File Offset: 0x00102EB8
		public virtual Type[] GetTypes()
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000B01 RID: 2817
		// (get) Token: 0x060047A4 RID: 18340 RVA: 0x00104CC0 File Offset: 0x00102EC0
		public virtual Guid ModuleVersionId
		{
			get
			{
				RuntimeModule runtimeModule = this as RuntimeModule;
				if (runtimeModule != null)
				{
					return runtimeModule.ModuleVersionId;
				}
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000B02 RID: 2818
		// (get) Token: 0x060047A5 RID: 18341 RVA: 0x00104CEC File Offset: 0x00102EEC
		public virtual int MetadataToken
		{
			get
			{
				RuntimeModule runtimeModule = this as RuntimeModule;
				if (runtimeModule != null)
				{
					return runtimeModule.MetadataToken;
				}
				throw new NotImplementedException();
			}
		}

		// Token: 0x060047A6 RID: 18342 RVA: 0x00104D18 File Offset: 0x00102F18
		public virtual bool IsResource()
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.IsResource();
			}
			throw new NotImplementedException();
		}

		// Token: 0x060047A7 RID: 18343 RVA: 0x00104D41 File Offset: 0x00102F41
		public FieldInfo[] GetFields()
		{
			return this.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		// Token: 0x060047A8 RID: 18344 RVA: 0x00104D4C File Offset: 0x00102F4C
		public virtual FieldInfo[] GetFields(BindingFlags bindingFlags)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.GetFields(bindingFlags);
			}
			throw new NotImplementedException();
		}

		// Token: 0x060047A9 RID: 18345 RVA: 0x00104D76 File Offset: 0x00102F76
		public FieldInfo GetField(string name)
		{
			return this.GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		// Token: 0x060047AA RID: 18346 RVA: 0x00104D84 File Offset: 0x00102F84
		public virtual FieldInfo GetField(string name, BindingFlags bindingAttr)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.GetField(name, bindingAttr);
			}
			throw new NotImplementedException();
		}

		// Token: 0x060047AB RID: 18347 RVA: 0x00104DAF File Offset: 0x00102FAF
		public MethodInfo[] GetMethods()
		{
			return this.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		// Token: 0x060047AC RID: 18348 RVA: 0x00104DBC File Offset: 0x00102FBC
		public virtual MethodInfo[] GetMethods(BindingFlags bindingFlags)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.GetMethods(bindingFlags);
			}
			throw new NotImplementedException();
		}

		// Token: 0x060047AD RID: 18349 RVA: 0x00104DE8 File Offset: 0x00102FE8
		public MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (types == null)
			{
				throw new ArgumentNullException("types");
			}
			for (int i = 0; i < types.Length; i++)
			{
				if (types[i] == null)
				{
					throw new ArgumentNullException("types");
				}
			}
			return this.GetMethodImpl(name, bindingAttr, binder, callConvention, types, modifiers);
		}

		// Token: 0x060047AE RID: 18350 RVA: 0x00104E48 File Offset: 0x00103048
		public MethodInfo GetMethod(string name, Type[] types)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (types == null)
			{
				throw new ArgumentNullException("types");
			}
			for (int i = 0; i < types.Length; i++)
			{
				if (types[i] == null)
				{
					throw new ArgumentNullException("types");
				}
			}
			return this.GetMethodImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, CallingConventions.Any, types, null);
		}

		// Token: 0x060047AF RID: 18351 RVA: 0x00104EA2 File Offset: 0x001030A2
		public MethodInfo GetMethod(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			return this.GetMethodImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, CallingConventions.Any, null, null);
		}

		// Token: 0x060047B0 RID: 18352 RVA: 0x00104EBF File Offset: 0x001030BF
		protected virtual MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000B03 RID: 2819
		// (get) Token: 0x060047B1 RID: 18353 RVA: 0x00104EC8 File Offset: 0x001030C8
		public virtual string ScopeName
		{
			get
			{
				RuntimeModule runtimeModule = this as RuntimeModule;
				if (runtimeModule != null)
				{
					return runtimeModule.ScopeName;
				}
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000B04 RID: 2820
		// (get) Token: 0x060047B2 RID: 18354 RVA: 0x00104EF4 File Offset: 0x001030F4
		[__DynamicallyInvokable]
		public virtual string Name
		{
			[__DynamicallyInvokable]
			get
			{
				RuntimeModule runtimeModule = this as RuntimeModule;
				if (runtimeModule != null)
				{
					return runtimeModule.Name;
				}
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000B05 RID: 2821
		// (get) Token: 0x060047B3 RID: 18355 RVA: 0x00104F20 File Offset: 0x00103120
		[__DynamicallyInvokable]
		public virtual Assembly Assembly
		{
			[__DynamicallyInvokable]
			get
			{
				RuntimeModule runtimeModule = this as RuntimeModule;
				if (runtimeModule != null)
				{
					return runtimeModule.Assembly;
				}
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000B06 RID: 2822
		// (get) Token: 0x060047B4 RID: 18356 RVA: 0x00104F49 File Offset: 0x00103149
		public ModuleHandle ModuleHandle
		{
			get
			{
				return this.GetModuleHandle();
			}
		}

		// Token: 0x060047B5 RID: 18357 RVA: 0x00104F51 File Offset: 0x00103151
		internal virtual ModuleHandle GetModuleHandle()
		{
			return ModuleHandle.EmptyHandle;
		}

		// Token: 0x060047B6 RID: 18358 RVA: 0x00104F58 File Offset: 0x00103158
		public virtual X509Certificate GetSignerCertificate()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060047B7 RID: 18359 RVA: 0x00104F5F File Offset: 0x0010315F
		void _Module.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060047B8 RID: 18360 RVA: 0x00104F66 File Offset: 0x00103166
		void _Module.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060047B9 RID: 18361 RVA: 0x00104F6D File Offset: 0x0010316D
		void _Module.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060047BA RID: 18362 RVA: 0x00104F74 File Offset: 0x00103174
		void _Module.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04001DB3 RID: 7603
		public static readonly TypeFilter FilterTypeName;

		// Token: 0x04001DB4 RID: 7604
		public static readonly TypeFilter FilterTypeNameIgnoreCase;

		// Token: 0x04001DB5 RID: 7605
		private const BindingFlags DefaultLookup = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;
	}
}
