﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Threading;

namespace System.Reflection
{
	// Token: 0x020005E6 RID: 1510
	[Serializable]
	internal sealed class RtFieldInfo : RuntimeFieldInfo, IRuntimeFieldInfo
	{
		// Token: 0x0600461B RID: 17947
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PerformVisibilityCheckOnField(IntPtr field, object target, RuntimeType declaringType, FieldAttributes attr, uint invocationFlags);

		// Token: 0x0600461C RID: 17948 RVA: 0x00101B10 File Offset: 0x000FFD10
		private bool IsNonW8PFrameworkAPI()
		{
			if (base.GetRuntimeType().IsNonW8PFrameworkAPI())
			{
				return true;
			}
			if (this.m_declaringType.IsEnum)
			{
				return false;
			}
			RuntimeAssembly runtimeAssembly = this.GetRuntimeAssembly();
			if (runtimeAssembly.IsFrameworkAssembly())
			{
				int invocableAttributeCtorToken = runtimeAssembly.InvocableAttributeCtorToken;
				if (System.Reflection.MetadataToken.IsNullToken(invocableAttributeCtorToken) || !CustomAttribute.IsAttributeDefined(this.GetRuntimeModule(), this.MetadataToken, invocableAttributeCtorToken))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x17000A89 RID: 2697
		// (get) Token: 0x0600461D RID: 17949 RVA: 0x00101B70 File Offset: 0x000FFD70
		internal INVOCATION_FLAGS InvocationFlags
		{
			get
			{
				if ((this.m_invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_INITIALIZED) == INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					Type declaringType = this.DeclaringType;
					bool flag = declaringType is ReflectionOnlyType;
					INVOCATION_FLAGS invocation_FLAGS = INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN;
					if ((declaringType != null && declaringType.ContainsGenericParameters) || (declaringType == null && this.Module.Assembly.ReflectionOnly) || flag)
					{
						invocation_FLAGS |= INVOCATION_FLAGS.INVOCATION_FLAGS_NO_INVOKE;
					}
					if (invocation_FLAGS == INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
					{
						if ((this.m_fieldAttributes & FieldAttributes.InitOnly) != FieldAttributes.PrivateScope)
						{
							invocation_FLAGS |= INVOCATION_FLAGS.INVOCATION_FLAGS_IS_CTOR;
						}
						if ((this.m_fieldAttributes & FieldAttributes.HasFieldRVA) != FieldAttributes.PrivateScope)
						{
							invocation_FLAGS |= INVOCATION_FLAGS.INVOCATION_FLAGS_IS_CTOR;
						}
						bool flag2 = this.IsSecurityCritical && !this.IsSecuritySafeCritical;
						bool flag3 = (this.m_fieldAttributes & FieldAttributes.FieldAccessMask) != FieldAttributes.Public || (declaringType != null && declaringType.NeedsReflectionSecurityCheck);
						if (flag2 || flag3)
						{
							invocation_FLAGS |= INVOCATION_FLAGS.INVOCATION_FLAGS_NEED_SECURITY;
						}
						Type fieldType = this.FieldType;
						if (fieldType.IsPointer || fieldType.IsEnum || fieldType.IsPrimitive)
						{
							invocation_FLAGS |= INVOCATION_FLAGS.INVOCATION_FLAGS_RISKY_METHOD;
						}
					}
					if (AppDomain.ProfileAPICheck && this.IsNonW8PFrameworkAPI())
					{
						invocation_FLAGS |= INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API;
					}
					this.m_invocationFlags = (invocation_FLAGS | INVOCATION_FLAGS.INVOCATION_FLAGS_INITIALIZED);
				}
				return this.m_invocationFlags;
			}
		}

		// Token: 0x0600461E RID: 17950 RVA: 0x00101C8A File Offset: 0x000FFE8A
		private RuntimeAssembly GetRuntimeAssembly()
		{
			return this.m_declaringType.GetRuntimeAssembly();
		}

		// Token: 0x0600461F RID: 17951 RVA: 0x00101C97 File Offset: 0x000FFE97
		[SecurityCritical]
		internal RtFieldInfo(RuntimeFieldHandleInternal handle, RuntimeType declaringType, RuntimeType.RuntimeTypeCache reflectedTypeCache, BindingFlags bindingFlags) : base(reflectedTypeCache, declaringType, bindingFlags)
		{
			this.m_fieldHandle = handle.Value;
			this.m_fieldAttributes = RuntimeFieldHandle.GetAttributes(handle);
		}

		// Token: 0x17000A8A RID: 2698
		// (get) Token: 0x06004620 RID: 17952 RVA: 0x00101CBC File Offset: 0x000FFEBC
		RuntimeFieldHandleInternal IRuntimeFieldInfo.Value
		{
			[SecuritySafeCritical]
			get
			{
				return new RuntimeFieldHandleInternal(this.m_fieldHandle);
			}
		}

		// Token: 0x06004621 RID: 17953 RVA: 0x00101CCC File Offset: 0x000FFECC
		internal void CheckConsistency(object target)
		{
			if ((this.m_fieldAttributes & FieldAttributes.Static) == FieldAttributes.Static || this.m_declaringType.IsInstanceOfType(target))
			{
				return;
			}
			if (target == null)
			{
				throw new TargetException(Environment.GetResourceString("RFLCT.Targ_StatFldReqTarg"));
			}
			throw new ArgumentException(string.Format(CultureInfo.CurrentUICulture, Environment.GetResourceString("Arg_FieldDeclTarget"), this.Name, this.m_declaringType, target.GetType()));
		}

		// Token: 0x06004622 RID: 17954 RVA: 0x00101D34 File Offset: 0x000FFF34
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal override bool CacheEquals(object o)
		{
			RtFieldInfo rtFieldInfo = o as RtFieldInfo;
			return rtFieldInfo != null && rtFieldInfo.m_fieldHandle == this.m_fieldHandle;
		}

		// Token: 0x06004623 RID: 17955 RVA: 0x00101D60 File Offset: 0x000FFF60
		[SecurityCritical]
		[DebuggerStepThrough]
		[DebuggerHidden]
		internal void InternalSetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture, ref StackCrawlMark stackMark)
		{
			INVOCATION_FLAGS invocationFlags = this.InvocationFlags;
			RuntimeType runtimeType = this.DeclaringType as RuntimeType;
			if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NO_INVOKE) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				if (runtimeType != null && runtimeType.ContainsGenericParameters)
				{
					throw new InvalidOperationException(Environment.GetResourceString("Arg_UnboundGenField"));
				}
				if ((runtimeType == null && this.Module.Assembly.ReflectionOnly) || runtimeType is ReflectionOnlyType)
				{
					throw new InvalidOperationException(Environment.GetResourceString("Arg_ReflectionOnlyField"));
				}
				throw new FieldAccessException();
			}
			else
			{
				this.CheckConsistency(obj);
				RuntimeType runtimeType2 = (RuntimeType)this.FieldType;
				value = runtimeType2.CheckValue(value, binder, culture, invokeAttr);
				if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					RuntimeAssembly executingAssembly = RuntimeAssembly.GetExecutingAssembly(ref stackMark);
					if (executingAssembly != null && !executingAssembly.IsSafeForReflection())
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
						{
							this.FullName
						}));
					}
				}
				if ((invocationFlags & (INVOCATION_FLAGS.INVOCATION_FLAGS_NEED_SECURITY | INVOCATION_FLAGS.INVOCATION_FLAGS_IS_CTOR)) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					RtFieldInfo.PerformVisibilityCheckOnField(this.m_fieldHandle, obj, this.m_declaringType, this.m_fieldAttributes, (uint)this.m_invocationFlags);
				}
				bool domainInitialized = false;
				if (runtimeType == null)
				{
					RuntimeFieldHandle.SetValue(this, obj, value, runtimeType2, this.m_fieldAttributes, null, ref domainInitialized);
					return;
				}
				domainInitialized = runtimeType.DomainInitialized;
				RuntimeFieldHandle.SetValue(this, obj, value, runtimeType2, this.m_fieldAttributes, runtimeType, ref domainInitialized);
				runtimeType.DomainInitialized = domainInitialized;
				return;
			}
		}

		// Token: 0x06004624 RID: 17956 RVA: 0x00101EA4 File Offset: 0x001000A4
		[SecurityCritical]
		[DebuggerStepThrough]
		[DebuggerHidden]
		internal void UnsafeSetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture)
		{
			RuntimeType runtimeType = this.DeclaringType as RuntimeType;
			RuntimeType runtimeType2 = (RuntimeType)this.FieldType;
			value = runtimeType2.CheckValue(value, binder, culture, invokeAttr);
			bool domainInitialized = false;
			if (runtimeType == null)
			{
				RuntimeFieldHandle.SetValue(this, obj, value, runtimeType2, this.m_fieldAttributes, null, ref domainInitialized);
				return;
			}
			domainInitialized = runtimeType.DomainInitialized;
			RuntimeFieldHandle.SetValue(this, obj, value, runtimeType2, this.m_fieldAttributes, runtimeType, ref domainInitialized);
			runtimeType.DomainInitialized = domainInitialized;
		}

		// Token: 0x06004625 RID: 17957 RVA: 0x00101F18 File Offset: 0x00100118
		[SecuritySafeCritical]
		[DebuggerStepThrough]
		[DebuggerHidden]
		internal object InternalGetValue(object obj, ref StackCrawlMark stackMark)
		{
			INVOCATION_FLAGS invocationFlags = this.InvocationFlags;
			RuntimeType runtimeType = this.DeclaringType as RuntimeType;
			if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NO_INVOKE) == INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				this.CheckConsistency(obj);
				if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					RuntimeAssembly executingAssembly = RuntimeAssembly.GetExecutingAssembly(ref stackMark);
					if (executingAssembly != null && !executingAssembly.IsSafeForReflection())
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
						{
							this.FullName
						}));
					}
				}
				RuntimeType runtimeType2 = (RuntimeType)this.FieldType;
				if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NEED_SECURITY) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					RtFieldInfo.PerformVisibilityCheckOnField(this.m_fieldHandle, obj, this.m_declaringType, this.m_fieldAttributes, (uint)(this.m_invocationFlags & ~INVOCATION_FLAGS.INVOCATION_FLAGS_IS_CTOR));
				}
				return this.UnsafeGetValue(obj);
			}
			if (runtimeType != null && this.DeclaringType.ContainsGenericParameters)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Arg_UnboundGenField"));
			}
			if ((runtimeType == null && this.Module.Assembly.ReflectionOnly) || runtimeType is ReflectionOnlyType)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Arg_ReflectionOnlyField"));
			}
			throw new FieldAccessException();
		}

		// Token: 0x06004626 RID: 17958 RVA: 0x0010201C File Offset: 0x0010021C
		[SecurityCritical]
		[DebuggerStepThrough]
		[DebuggerHidden]
		internal object UnsafeGetValue(object obj)
		{
			RuntimeType runtimeType = this.DeclaringType as RuntimeType;
			RuntimeType fieldType = (RuntimeType)this.FieldType;
			bool domainInitialized = false;
			if (runtimeType == null)
			{
				return RuntimeFieldHandle.GetValue(this, obj, fieldType, null, ref domainInitialized);
			}
			domainInitialized = runtimeType.DomainInitialized;
			object value = RuntimeFieldHandle.GetValue(this, obj, fieldType, runtimeType, ref domainInitialized);
			runtimeType.DomainInitialized = domainInitialized;
			return value;
		}

		// Token: 0x17000A8B RID: 2699
		// (get) Token: 0x06004627 RID: 17959 RVA: 0x00102073 File Offset: 0x00100273
		public override string Name
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_name == null)
				{
					this.m_name = RuntimeFieldHandle.GetName(this);
				}
				return this.m_name;
			}
		}

		// Token: 0x17000A8C RID: 2700
		// (get) Token: 0x06004628 RID: 17960 RVA: 0x0010208F File Offset: 0x0010028F
		internal string FullName
		{
			get
			{
				return string.Format("{0}.{1}", this.DeclaringType.FullName, this.Name);
			}
		}

		// Token: 0x17000A8D RID: 2701
		// (get) Token: 0x06004629 RID: 17961 RVA: 0x001020AC File Offset: 0x001002AC
		public override int MetadataToken
		{
			[SecuritySafeCritical]
			get
			{
				return RuntimeFieldHandle.GetToken(this);
			}
		}

		// Token: 0x0600462A RID: 17962 RVA: 0x001020B4 File Offset: 0x001002B4
		[SecuritySafeCritical]
		internal override RuntimeModule GetRuntimeModule()
		{
			return RuntimeTypeHandle.GetModule(RuntimeFieldHandle.GetApproxDeclaringType(this));
		}

		// Token: 0x0600462B RID: 17963 RVA: 0x001020C4 File Offset: 0x001002C4
		public override object GetValue(object obj)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.InternalGetValue(obj, ref stackCrawlMark);
		}

		// Token: 0x0600462C RID: 17964 RVA: 0x001020DC File Offset: 0x001002DC
		public override object GetRawConstantValue()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x0600462D RID: 17965 RVA: 0x001020E3 File Offset: 0x001002E3
		[SecuritySafeCritical]
		[DebuggerStepThrough]
		[DebuggerHidden]
		public unsafe override object GetValueDirect(TypedReference obj)
		{
			if (obj.IsNull)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_TypedReference_Null"));
			}
			return RuntimeFieldHandle.GetValueDirect(this, (RuntimeType)this.FieldType, (void*)(&obj), (RuntimeType)this.DeclaringType);
		}

		// Token: 0x0600462E RID: 17966 RVA: 0x00102120 File Offset: 0x00100320
		[SecuritySafeCritical]
		[DebuggerStepThrough]
		[DebuggerHidden]
		public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.InternalSetValue(obj, value, invokeAttr, binder, culture, ref stackCrawlMark);
		}

		// Token: 0x0600462F RID: 17967 RVA: 0x0010213E File Offset: 0x0010033E
		[SecuritySafeCritical]
		[DebuggerStepThrough]
		[DebuggerHidden]
		public unsafe override void SetValueDirect(TypedReference obj, object value)
		{
			if (obj.IsNull)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_TypedReference_Null"));
			}
			RuntimeFieldHandle.SetValueDirect(this, (RuntimeType)this.FieldType, (void*)(&obj), value, (RuntimeType)this.DeclaringType);
		}

		// Token: 0x17000A8E RID: 2702
		// (get) Token: 0x06004630 RID: 17968 RVA: 0x0010217C File Offset: 0x0010037C
		public override RuntimeFieldHandle FieldHandle
		{
			get
			{
				Type declaringType = this.DeclaringType;
				if ((declaringType == null && this.Module.Assembly.ReflectionOnly) || declaringType is ReflectionOnlyType)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotAllowedInReflectionOnly"));
				}
				return new RuntimeFieldHandle(this);
			}
		}

		// Token: 0x06004631 RID: 17969 RVA: 0x001021C9 File Offset: 0x001003C9
		internal IntPtr GetFieldHandle()
		{
			return this.m_fieldHandle;
		}

		// Token: 0x17000A8F RID: 2703
		// (get) Token: 0x06004632 RID: 17970 RVA: 0x001021D1 File Offset: 0x001003D1
		public override FieldAttributes Attributes
		{
			get
			{
				return this.m_fieldAttributes;
			}
		}

		// Token: 0x17000A90 RID: 2704
		// (get) Token: 0x06004633 RID: 17971 RVA: 0x001021D9 File Offset: 0x001003D9
		public override Type FieldType
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_fieldType == null)
				{
					this.m_fieldType = new Signature(this, this.m_declaringType).FieldType;
				}
				return this.m_fieldType;
			}
		}

		// Token: 0x06004634 RID: 17972 RVA: 0x00102206 File Offset: 0x00100406
		[SecuritySafeCritical]
		public override Type[] GetRequiredCustomModifiers()
		{
			return new Signature(this, this.m_declaringType).GetCustomModifiers(1, true);
		}

		// Token: 0x06004635 RID: 17973 RVA: 0x0010221B File Offset: 0x0010041B
		[SecuritySafeCritical]
		public override Type[] GetOptionalCustomModifiers()
		{
			return new Signature(this, this.m_declaringType).GetCustomModifiers(1, false);
		}

		// Token: 0x04001CB5 RID: 7349
		private IntPtr m_fieldHandle;

		// Token: 0x04001CB6 RID: 7350
		private FieldAttributes m_fieldAttributes;

		// Token: 0x04001CB7 RID: 7351
		private string m_name;

		// Token: 0x04001CB8 RID: 7352
		private RuntimeType m_fieldType;

		// Token: 0x04001CB9 RID: 7353
		private INVOCATION_FLAGS m_invocationFlags;
	}
}
