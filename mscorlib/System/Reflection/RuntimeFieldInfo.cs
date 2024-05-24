using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata;
using System.Runtime.Serialization;
using System.Security;
using System.Threading;

namespace System.Reflection
{
	// Token: 0x020005E5 RID: 1509
	[Serializable]
	internal abstract class RuntimeFieldInfo : FieldInfo, ISerializable
	{
		// Token: 0x06004609 RID: 17929 RVA: 0x0010192B File Offset: 0x000FFB2B
		protected RuntimeFieldInfo()
		{
		}

		// Token: 0x0600460A RID: 17930 RVA: 0x00101933 File Offset: 0x000FFB33
		protected RuntimeFieldInfo(RuntimeType.RuntimeTypeCache reflectedTypeCache, RuntimeType declaringType, BindingFlags bindingFlags)
		{
			this.m_bindingFlags = bindingFlags;
			this.m_declaringType = declaringType;
			this.m_reflectedTypeCache = reflectedTypeCache;
		}

		// Token: 0x17000A82 RID: 2690
		// (get) Token: 0x0600460B RID: 17931 RVA: 0x00101950 File Offset: 0x000FFB50
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

		// Token: 0x17000A83 RID: 2691
		// (get) Token: 0x0600460C RID: 17932 RVA: 0x00101982 File Offset: 0x000FFB82
		internal BindingFlags BindingFlags
		{
			get
			{
				return this.m_bindingFlags;
			}
		}

		// Token: 0x17000A84 RID: 2692
		// (get) Token: 0x0600460D RID: 17933 RVA: 0x0010198A File Offset: 0x000FFB8A
		private RuntimeType ReflectedTypeInternal
		{
			get
			{
				return this.m_reflectedTypeCache.GetRuntimeType();
			}
		}

		// Token: 0x0600460E RID: 17934 RVA: 0x00101997 File Offset: 0x000FFB97
		internal RuntimeType GetDeclaringTypeInternal()
		{
			return this.m_declaringType;
		}

		// Token: 0x0600460F RID: 17935 RVA: 0x0010199F File Offset: 0x000FFB9F
		internal RuntimeType GetRuntimeType()
		{
			return this.m_declaringType;
		}

		// Token: 0x06004610 RID: 17936
		internal abstract RuntimeModule GetRuntimeModule();

		// Token: 0x17000A85 RID: 2693
		// (get) Token: 0x06004611 RID: 17937 RVA: 0x001019A7 File Offset: 0x000FFBA7
		public override MemberTypes MemberType
		{
			get
			{
				return MemberTypes.Field;
			}
		}

		// Token: 0x17000A86 RID: 2694
		// (get) Token: 0x06004612 RID: 17938 RVA: 0x001019AA File Offset: 0x000FFBAA
		public override Type ReflectedType
		{
			get
			{
				if (!this.m_reflectedTypeCache.IsGlobal)
				{
					return this.ReflectedTypeInternal;
				}
				return null;
			}
		}

		// Token: 0x17000A87 RID: 2695
		// (get) Token: 0x06004613 RID: 17939 RVA: 0x001019C1 File Offset: 0x000FFBC1
		public override Type DeclaringType
		{
			get
			{
				if (!this.m_reflectedTypeCache.IsGlobal)
				{
					return this.m_declaringType;
				}
				return null;
			}
		}

		// Token: 0x17000A88 RID: 2696
		// (get) Token: 0x06004614 RID: 17940 RVA: 0x001019D8 File Offset: 0x000FFBD8
		public override Module Module
		{
			get
			{
				return this.GetRuntimeModule();
			}
		}

		// Token: 0x06004615 RID: 17941 RVA: 0x001019E0 File Offset: 0x000FFBE0
		public override string ToString()
		{
			if (CompatibilitySwitches.IsAppEarlierThanWindowsPhone8)
			{
				return this.FieldType.ToString() + " " + this.Name;
			}
			return this.FieldType.FormatTypeName() + " " + this.Name;
		}

		// Token: 0x06004616 RID: 17942 RVA: 0x00101A20 File Offset: 0x000FFC20
		public override object[] GetCustomAttributes(bool inherit)
		{
			return CustomAttribute.GetCustomAttributes(this, typeof(object) as RuntimeType);
		}

		// Token: 0x06004617 RID: 17943 RVA: 0x00101A38 File Offset: 0x000FFC38
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

		// Token: 0x06004618 RID: 17944 RVA: 0x00101A8C File Offset: 0x000FFC8C
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

		// Token: 0x06004619 RID: 17945 RVA: 0x00101ADE File Offset: 0x000FFCDE
		public override IList<CustomAttributeData> GetCustomAttributesData()
		{
			return CustomAttributeData.GetCustomAttributesInternal(this);
		}

		// Token: 0x0600461A RID: 17946 RVA: 0x00101AE6 File Offset: 0x000FFCE6
		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			MemberInfoSerializationHolder.GetSerializationInfo(info, this.Name, this.ReflectedTypeInternal, this.ToString(), MemberTypes.Field);
		}

		// Token: 0x04001CB1 RID: 7345
		private BindingFlags m_bindingFlags;

		// Token: 0x04001CB2 RID: 7346
		protected RuntimeType.RuntimeTypeCache m_reflectedTypeCache;

		// Token: 0x04001CB3 RID: 7347
		protected RuntimeType m_declaringType;

		// Token: 0x04001CB4 RID: 7348
		private RemotingFieldCachedData m_cachedData;
	}
}
