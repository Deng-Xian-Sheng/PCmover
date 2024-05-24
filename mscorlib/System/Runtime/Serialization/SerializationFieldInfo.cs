using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.Remoting.Metadata;
using System.Security;
using System.Threading;

namespace System.Runtime.Serialization
{
	// Token: 0x0200073F RID: 1855
	internal sealed class SerializationFieldInfo : FieldInfo
	{
		// Token: 0x17000D75 RID: 3445
		// (get) Token: 0x060051D3 RID: 20947 RVA: 0x0011FDB7 File Offset: 0x0011DFB7
		public override Module Module
		{
			get
			{
				return this.m_field.Module;
			}
		}

		// Token: 0x17000D76 RID: 3446
		// (get) Token: 0x060051D4 RID: 20948 RVA: 0x0011FDC4 File Offset: 0x0011DFC4
		public override int MetadataToken
		{
			get
			{
				return this.m_field.MetadataToken;
			}
		}

		// Token: 0x060051D5 RID: 20949 RVA: 0x0011FDD1 File Offset: 0x0011DFD1
		internal SerializationFieldInfo(RuntimeFieldInfo field, string namePrefix)
		{
			this.m_field = field;
			this.m_serializationName = namePrefix + "+" + this.m_field.Name;
		}

		// Token: 0x17000D77 RID: 3447
		// (get) Token: 0x060051D6 RID: 20950 RVA: 0x0011FDFC File Offset: 0x0011DFFC
		public override string Name
		{
			get
			{
				return this.m_serializationName;
			}
		}

		// Token: 0x17000D78 RID: 3448
		// (get) Token: 0x060051D7 RID: 20951 RVA: 0x0011FE04 File Offset: 0x0011E004
		public override Type DeclaringType
		{
			get
			{
				return this.m_field.DeclaringType;
			}
		}

		// Token: 0x17000D79 RID: 3449
		// (get) Token: 0x060051D8 RID: 20952 RVA: 0x0011FE11 File Offset: 0x0011E011
		public override Type ReflectedType
		{
			get
			{
				return this.m_field.ReflectedType;
			}
		}

		// Token: 0x060051D9 RID: 20953 RVA: 0x0011FE1E File Offset: 0x0011E01E
		public override object[] GetCustomAttributes(bool inherit)
		{
			return this.m_field.GetCustomAttributes(inherit);
		}

		// Token: 0x060051DA RID: 20954 RVA: 0x0011FE2C File Offset: 0x0011E02C
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return this.m_field.GetCustomAttributes(attributeType, inherit);
		}

		// Token: 0x060051DB RID: 20955 RVA: 0x0011FE3B File Offset: 0x0011E03B
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return this.m_field.IsDefined(attributeType, inherit);
		}

		// Token: 0x17000D7A RID: 3450
		// (get) Token: 0x060051DC RID: 20956 RVA: 0x0011FE4A File Offset: 0x0011E04A
		public override Type FieldType
		{
			get
			{
				return this.m_field.FieldType;
			}
		}

		// Token: 0x060051DD RID: 20957 RVA: 0x0011FE57 File Offset: 0x0011E057
		public override object GetValue(object obj)
		{
			return this.m_field.GetValue(obj);
		}

		// Token: 0x060051DE RID: 20958 RVA: 0x0011FE68 File Offset: 0x0011E068
		[SecurityCritical]
		internal object InternalGetValue(object obj)
		{
			RtFieldInfo rtFieldInfo = this.m_field as RtFieldInfo;
			if (rtFieldInfo != null)
			{
				rtFieldInfo.CheckConsistency(obj);
				return rtFieldInfo.UnsafeGetValue(obj);
			}
			return this.m_field.GetValue(obj);
		}

		// Token: 0x060051DF RID: 20959 RVA: 0x0011FEA5 File Offset: 0x0011E0A5
		public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture)
		{
			this.m_field.SetValue(obj, value, invokeAttr, binder, culture);
		}

		// Token: 0x060051E0 RID: 20960 RVA: 0x0011FEBC File Offset: 0x0011E0BC
		[SecurityCritical]
		internal void InternalSetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture)
		{
			RtFieldInfo rtFieldInfo = this.m_field as RtFieldInfo;
			if (rtFieldInfo != null)
			{
				rtFieldInfo.CheckConsistency(obj);
				rtFieldInfo.UnsafeSetValue(obj, value, invokeAttr, binder, culture);
				return;
			}
			this.m_field.SetValue(obj, value, invokeAttr, binder, culture);
		}

		// Token: 0x17000D7B RID: 3451
		// (get) Token: 0x060051E1 RID: 20961 RVA: 0x0011FF05 File Offset: 0x0011E105
		internal RuntimeFieldInfo FieldInfo
		{
			get
			{
				return this.m_field;
			}
		}

		// Token: 0x17000D7C RID: 3452
		// (get) Token: 0x060051E2 RID: 20962 RVA: 0x0011FF0D File Offset: 0x0011E10D
		public override RuntimeFieldHandle FieldHandle
		{
			get
			{
				return this.m_field.FieldHandle;
			}
		}

		// Token: 0x17000D7D RID: 3453
		// (get) Token: 0x060051E3 RID: 20963 RVA: 0x0011FF1A File Offset: 0x0011E11A
		public override FieldAttributes Attributes
		{
			get
			{
				return this.m_field.Attributes;
			}
		}

		// Token: 0x17000D7E RID: 3454
		// (get) Token: 0x060051E4 RID: 20964 RVA: 0x0011FF28 File Offset: 0x0011E128
		internal RemotingFieldCachedData RemotingCache
		{
			get
			{
				RemotingFieldCachedData remotingFieldCachedData = this.m_cachedData;
				if (remotingFieldCachedData == null)
				{
					remotingFieldCachedData = new RemotingFieldCachedData(this);
					RemotingFieldCachedData remotingFieldCachedData2 = Interlocked.CompareExchange<RemotingFieldCachedData>(ref this.m_cachedData, remotingFieldCachedData, null);
					if (remotingFieldCachedData2 != null)
					{
						remotingFieldCachedData = remotingFieldCachedData2;
					}
				}
				return remotingFieldCachedData;
			}
		}

		// Token: 0x0400243E RID: 9278
		internal const string FakeNameSeparatorString = "+";

		// Token: 0x0400243F RID: 9279
		private RuntimeFieldInfo m_field;

		// Token: 0x04002440 RID: 9280
		private string m_serializationName;

		// Token: 0x04002441 RID: 9281
		private RemotingFieldCachedData m_cachedData;
	}
}
