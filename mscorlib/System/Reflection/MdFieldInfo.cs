using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.Security;

namespace System.Reflection
{
	// Token: 0x020005E7 RID: 1511
	[Serializable]
	internal sealed class MdFieldInfo : RuntimeFieldInfo, ISerializable
	{
		// Token: 0x06004636 RID: 17974 RVA: 0x00102230 File Offset: 0x00100430
		internal MdFieldInfo(int tkField, FieldAttributes fieldAttributes, RuntimeTypeHandle declaringTypeHandle, RuntimeType.RuntimeTypeCache reflectedTypeCache, BindingFlags bindingFlags) : base(reflectedTypeCache, declaringTypeHandle.GetRuntimeType(), bindingFlags)
		{
			this.m_tkField = tkField;
			this.m_name = null;
			this.m_fieldAttributes = fieldAttributes;
		}

		// Token: 0x06004637 RID: 17975 RVA: 0x00102258 File Offset: 0x00100458
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal override bool CacheEquals(object o)
		{
			MdFieldInfo mdFieldInfo = o as MdFieldInfo;
			return mdFieldInfo != null && mdFieldInfo.m_tkField == this.m_tkField && this.m_declaringType.GetTypeHandleInternal().GetModuleHandle().Equals(mdFieldInfo.m_declaringType.GetTypeHandleInternal().GetModuleHandle());
		}

		// Token: 0x17000A91 RID: 2705
		// (get) Token: 0x06004638 RID: 17976 RVA: 0x001022B0 File Offset: 0x001004B0
		public override string Name
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_name == null)
				{
					this.m_name = this.GetRuntimeModule().MetadataImport.GetName(this.m_tkField).ToString();
				}
				return this.m_name;
			}
		}

		// Token: 0x17000A92 RID: 2706
		// (get) Token: 0x06004639 RID: 17977 RVA: 0x001022F8 File Offset: 0x001004F8
		public override int MetadataToken
		{
			get
			{
				return this.m_tkField;
			}
		}

		// Token: 0x0600463A RID: 17978 RVA: 0x00102300 File Offset: 0x00100500
		internal override RuntimeModule GetRuntimeModule()
		{
			return this.m_declaringType.GetRuntimeModule();
		}

		// Token: 0x17000A93 RID: 2707
		// (get) Token: 0x0600463B RID: 17979 RVA: 0x0010230D File Offset: 0x0010050D
		public override RuntimeFieldHandle FieldHandle
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000A94 RID: 2708
		// (get) Token: 0x0600463C RID: 17980 RVA: 0x00102314 File Offset: 0x00100514
		public override FieldAttributes Attributes
		{
			get
			{
				return this.m_fieldAttributes;
			}
		}

		// Token: 0x17000A95 RID: 2709
		// (get) Token: 0x0600463D RID: 17981 RVA: 0x0010231C File Offset: 0x0010051C
		public override bool IsSecurityCritical
		{
			get
			{
				return this.DeclaringType.IsSecurityCritical;
			}
		}

		// Token: 0x17000A96 RID: 2710
		// (get) Token: 0x0600463E RID: 17982 RVA: 0x00102329 File Offset: 0x00100529
		public override bool IsSecuritySafeCritical
		{
			get
			{
				return this.DeclaringType.IsSecuritySafeCritical;
			}
		}

		// Token: 0x17000A97 RID: 2711
		// (get) Token: 0x0600463F RID: 17983 RVA: 0x00102336 File Offset: 0x00100536
		public override bool IsSecurityTransparent
		{
			get
			{
				return this.DeclaringType.IsSecurityTransparent;
			}
		}

		// Token: 0x06004640 RID: 17984 RVA: 0x00102343 File Offset: 0x00100543
		[DebuggerStepThrough]
		[DebuggerHidden]
		public override object GetValueDirect(TypedReference obj)
		{
			return this.GetValue(null);
		}

		// Token: 0x06004641 RID: 17985 RVA: 0x0010234C File Offset: 0x0010054C
		[DebuggerStepThrough]
		[DebuggerHidden]
		public override void SetValueDirect(TypedReference obj, object value)
		{
			throw new FieldAccessException(Environment.GetResourceString("Acc_ReadOnly"));
		}

		// Token: 0x06004642 RID: 17986 RVA: 0x0010235D File Offset: 0x0010055D
		[DebuggerStepThrough]
		[DebuggerHidden]
		public override object GetValue(object obj)
		{
			return this.GetValue(false);
		}

		// Token: 0x06004643 RID: 17987 RVA: 0x00102366 File Offset: 0x00100566
		public override object GetRawConstantValue()
		{
			return this.GetValue(true);
		}

		// Token: 0x06004644 RID: 17988 RVA: 0x00102370 File Offset: 0x00100570
		[SecuritySafeCritical]
		private object GetValue(bool raw)
		{
			object value = MdConstant.GetValue(this.GetRuntimeModule().MetadataImport, this.m_tkField, this.FieldType.GetTypeHandleInternal(), raw);
			if (value == DBNull.Value)
			{
				throw new NotSupportedException(Environment.GetResourceString("Arg_EnumLitValueNotFound"));
			}
			return value;
		}

		// Token: 0x06004645 RID: 17989 RVA: 0x001023B9 File Offset: 0x001005B9
		[DebuggerStepThrough]
		[DebuggerHidden]
		public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture)
		{
			throw new FieldAccessException(Environment.GetResourceString("Acc_ReadOnly"));
		}

		// Token: 0x17000A98 RID: 2712
		// (get) Token: 0x06004646 RID: 17990 RVA: 0x001023CC File Offset: 0x001005CC
		public override Type FieldType
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_fieldType == null)
				{
					ConstArray sigOfFieldDef = this.GetRuntimeModule().MetadataImport.GetSigOfFieldDef(this.m_tkField);
					this.m_fieldType = new Signature(sigOfFieldDef.Signature.ToPointer(), sigOfFieldDef.Length, this.m_declaringType).FieldType;
				}
				return this.m_fieldType;
			}
		}

		// Token: 0x06004647 RID: 17991 RVA: 0x00102433 File Offset: 0x00100633
		public override Type[] GetRequiredCustomModifiers()
		{
			return EmptyArray<Type>.Value;
		}

		// Token: 0x06004648 RID: 17992 RVA: 0x0010243A File Offset: 0x0010063A
		public override Type[] GetOptionalCustomModifiers()
		{
			return EmptyArray<Type>.Value;
		}

		// Token: 0x04001CBA RID: 7354
		private int m_tkField;

		// Token: 0x04001CBB RID: 7355
		private string m_name;

		// Token: 0x04001CBC RID: 7356
		private RuntimeType m_fieldType;

		// Token: 0x04001CBD RID: 7357
		private FieldAttributes m_fieldAttributes;
	}
}
