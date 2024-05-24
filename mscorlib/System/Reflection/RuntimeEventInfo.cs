using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.Security;

namespace System.Reflection
{
	// Token: 0x020005E2 RID: 1506
	[Serializable]
	internal sealed class RuntimeEventInfo : EventInfo, ISerializable
	{
		// Token: 0x060045CB RID: 17867 RVA: 0x00101386 File Offset: 0x000FF586
		internal RuntimeEventInfo()
		{
		}

		// Token: 0x060045CC RID: 17868 RVA: 0x00101390 File Offset: 0x000FF590
		[SecurityCritical]
		internal RuntimeEventInfo(int tkEvent, RuntimeType declaredType, RuntimeType.RuntimeTypeCache reflectedTypeCache, out bool isPrivate)
		{
			MetadataImport metadataImport = declaredType.GetRuntimeModule().MetadataImport;
			this.m_token = tkEvent;
			this.m_reflectedTypeCache = reflectedTypeCache;
			this.m_declaringType = declaredType;
			RuntimeType runtimeType = reflectedTypeCache.GetRuntimeType();
			metadataImport.GetEventProps(tkEvent, out this.m_utf8name, out this.m_flags);
			RuntimeMethodInfo runtimeMethodInfo;
			Associates.AssignAssociates(metadataImport, tkEvent, declaredType, runtimeType, out this.m_addMethod, out this.m_removeMethod, out this.m_raiseMethod, out runtimeMethodInfo, out runtimeMethodInfo, out this.m_otherMethod, out isPrivate, out this.m_bindingFlags);
		}

		// Token: 0x060045CD RID: 17869 RVA: 0x0010140C File Offset: 0x000FF60C
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal override bool CacheEquals(object o)
		{
			RuntimeEventInfo runtimeEventInfo = o as RuntimeEventInfo;
			return runtimeEventInfo != null && runtimeEventInfo.m_token == this.m_token && RuntimeTypeHandle.GetModule(this.m_declaringType).Equals(RuntimeTypeHandle.GetModule(runtimeEventInfo.m_declaringType));
		}

		// Token: 0x17000A66 RID: 2662
		// (get) Token: 0x060045CE RID: 17870 RVA: 0x00101450 File Offset: 0x000FF650
		internal BindingFlags BindingFlags
		{
			get
			{
				return this.m_bindingFlags;
			}
		}

		// Token: 0x060045CF RID: 17871 RVA: 0x00101458 File Offset: 0x000FF658
		public override string ToString()
		{
			if (this.m_addMethod == null || this.m_addMethod.GetParametersNoCopy().Length == 0)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NoPublicAddMethod"));
			}
			return this.m_addMethod.GetParametersNoCopy()[0].ParameterType.FormatTypeName() + " " + this.Name;
		}

		// Token: 0x060045D0 RID: 17872 RVA: 0x001014B8 File Offset: 0x000FF6B8
		public override object[] GetCustomAttributes(bool inherit)
		{
			return CustomAttribute.GetCustomAttributes(this, typeof(object) as RuntimeType);
		}

		// Token: 0x060045D1 RID: 17873 RVA: 0x001014D0 File Offset: 0x000FF6D0
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

		// Token: 0x060045D2 RID: 17874 RVA: 0x00101524 File Offset: 0x000FF724
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

		// Token: 0x060045D3 RID: 17875 RVA: 0x00101576 File Offset: 0x000FF776
		public override IList<CustomAttributeData> GetCustomAttributesData()
		{
			return CustomAttributeData.GetCustomAttributesInternal(this);
		}

		// Token: 0x17000A67 RID: 2663
		// (get) Token: 0x060045D4 RID: 17876 RVA: 0x0010157E File Offset: 0x000FF77E
		public override MemberTypes MemberType
		{
			get
			{
				return MemberTypes.Event;
			}
		}

		// Token: 0x17000A68 RID: 2664
		// (get) Token: 0x060045D5 RID: 17877 RVA: 0x00101584 File Offset: 0x000FF784
		public override string Name
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_name == null)
				{
					this.m_name = new Utf8String(this.m_utf8name).ToString();
				}
				return this.m_name;
			}
		}

		// Token: 0x17000A69 RID: 2665
		// (get) Token: 0x060045D6 RID: 17878 RVA: 0x001015BE File Offset: 0x000FF7BE
		public override Type DeclaringType
		{
			get
			{
				return this.m_declaringType;
			}
		}

		// Token: 0x17000A6A RID: 2666
		// (get) Token: 0x060045D7 RID: 17879 RVA: 0x001015C6 File Offset: 0x000FF7C6
		public override Type ReflectedType
		{
			get
			{
				return this.ReflectedTypeInternal;
			}
		}

		// Token: 0x17000A6B RID: 2667
		// (get) Token: 0x060045D8 RID: 17880 RVA: 0x001015CE File Offset: 0x000FF7CE
		private RuntimeType ReflectedTypeInternal
		{
			get
			{
				return this.m_reflectedTypeCache.GetRuntimeType();
			}
		}

		// Token: 0x17000A6C RID: 2668
		// (get) Token: 0x060045D9 RID: 17881 RVA: 0x001015DB File Offset: 0x000FF7DB
		public override int MetadataToken
		{
			get
			{
				return this.m_token;
			}
		}

		// Token: 0x17000A6D RID: 2669
		// (get) Token: 0x060045DA RID: 17882 RVA: 0x001015E3 File Offset: 0x000FF7E3
		public override Module Module
		{
			get
			{
				return this.GetRuntimeModule();
			}
		}

		// Token: 0x060045DB RID: 17883 RVA: 0x001015EB File Offset: 0x000FF7EB
		internal RuntimeModule GetRuntimeModule()
		{
			return this.m_declaringType.GetRuntimeModule();
		}

		// Token: 0x060045DC RID: 17884 RVA: 0x001015F8 File Offset: 0x000FF7F8
		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			MemberInfoSerializationHolder.GetSerializationInfo(info, this.Name, this.ReflectedTypeInternal, null, MemberTypes.Event);
		}

		// Token: 0x060045DD RID: 17885 RVA: 0x0010161C File Offset: 0x000FF81C
		public override MethodInfo[] GetOtherMethods(bool nonPublic)
		{
			List<MethodInfo> list = new List<MethodInfo>();
			if (this.m_otherMethod == null)
			{
				return new MethodInfo[0];
			}
			for (int i = 0; i < this.m_otherMethod.Length; i++)
			{
				if (Associates.IncludeAccessor(this.m_otherMethod[i], nonPublic))
				{
					list.Add(this.m_otherMethod[i]);
				}
			}
			return list.ToArray();
		}

		// Token: 0x060045DE RID: 17886 RVA: 0x00101675 File Offset: 0x000FF875
		public override MethodInfo GetAddMethod(bool nonPublic)
		{
			if (!Associates.IncludeAccessor(this.m_addMethod, nonPublic))
			{
				return null;
			}
			return this.m_addMethod;
		}

		// Token: 0x060045DF RID: 17887 RVA: 0x0010168D File Offset: 0x000FF88D
		public override MethodInfo GetRemoveMethod(bool nonPublic)
		{
			if (!Associates.IncludeAccessor(this.m_removeMethod, nonPublic))
			{
				return null;
			}
			return this.m_removeMethod;
		}

		// Token: 0x060045E0 RID: 17888 RVA: 0x001016A5 File Offset: 0x000FF8A5
		public override MethodInfo GetRaiseMethod(bool nonPublic)
		{
			if (!Associates.IncludeAccessor(this.m_raiseMethod, nonPublic))
			{
				return null;
			}
			return this.m_raiseMethod;
		}

		// Token: 0x17000A6E RID: 2670
		// (get) Token: 0x060045E1 RID: 17889 RVA: 0x001016BD File Offset: 0x000FF8BD
		public override EventAttributes Attributes
		{
			get
			{
				return this.m_flags;
			}
		}

		// Token: 0x04001C92 RID: 7314
		private int m_token;

		// Token: 0x04001C93 RID: 7315
		private EventAttributes m_flags;

		// Token: 0x04001C94 RID: 7316
		private string m_name;

		// Token: 0x04001C95 RID: 7317
		[SecurityCritical]
		private unsafe void* m_utf8name;

		// Token: 0x04001C96 RID: 7318
		private RuntimeType.RuntimeTypeCache m_reflectedTypeCache;

		// Token: 0x04001C97 RID: 7319
		private RuntimeMethodInfo m_addMethod;

		// Token: 0x04001C98 RID: 7320
		private RuntimeMethodInfo m_removeMethod;

		// Token: 0x04001C99 RID: 7321
		private RuntimeMethodInfo m_raiseMethod;

		// Token: 0x04001C9A RID: 7322
		private MethodInfo[] m_otherMethod;

		// Token: 0x04001C9B RID: 7323
		private RuntimeType m_declaringType;

		// Token: 0x04001C9C RID: 7324
		private BindingFlags m_bindingFlags;
	}
}
