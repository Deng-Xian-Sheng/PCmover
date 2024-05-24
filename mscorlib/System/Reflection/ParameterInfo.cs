using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Reflection
{
	// Token: 0x02000615 RID: 1557
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_ParameterInfo))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class ParameterInfo : _ParameterInfo, ICustomAttributeProvider, IObjectReference
	{
		// Token: 0x0600480B RID: 18443 RVA: 0x00106056 File Offset: 0x00104256
		protected ParameterInfo()
		{
		}

		// Token: 0x0600480C RID: 18444 RVA: 0x0010605E File Offset: 0x0010425E
		internal void SetName(string name)
		{
			this.NameImpl = name;
		}

		// Token: 0x0600480D RID: 18445 RVA: 0x00106067 File Offset: 0x00104267
		internal void SetAttributes(ParameterAttributes attributes)
		{
			this.AttrsImpl = attributes;
		}

		// Token: 0x17000B25 RID: 2853
		// (get) Token: 0x0600480E RID: 18446 RVA: 0x00106070 File Offset: 0x00104270
		[__DynamicallyInvokable]
		public virtual Type ParameterType
		{
			[__DynamicallyInvokable]
			get
			{
				return this.ClassImpl;
			}
		}

		// Token: 0x17000B26 RID: 2854
		// (get) Token: 0x0600480F RID: 18447 RVA: 0x00106078 File Offset: 0x00104278
		[__DynamicallyInvokable]
		public virtual string Name
		{
			[__DynamicallyInvokable]
			get
			{
				return this.NameImpl;
			}
		}

		// Token: 0x17000B27 RID: 2855
		// (get) Token: 0x06004810 RID: 18448 RVA: 0x00106080 File Offset: 0x00104280
		[__DynamicallyInvokable]
		public virtual bool HasDefaultValue
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000B28 RID: 2856
		// (get) Token: 0x06004811 RID: 18449 RVA: 0x00106087 File Offset: 0x00104287
		[__DynamicallyInvokable]
		public virtual object DefaultValue
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000B29 RID: 2857
		// (get) Token: 0x06004812 RID: 18450 RVA: 0x0010608E File Offset: 0x0010428E
		public virtual object RawDefaultValue
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000B2A RID: 2858
		// (get) Token: 0x06004813 RID: 18451 RVA: 0x00106095 File Offset: 0x00104295
		[__DynamicallyInvokable]
		public virtual int Position
		{
			[__DynamicallyInvokable]
			get
			{
				return this.PositionImpl;
			}
		}

		// Token: 0x17000B2B RID: 2859
		// (get) Token: 0x06004814 RID: 18452 RVA: 0x0010609D File Offset: 0x0010429D
		[__DynamicallyInvokable]
		public virtual ParameterAttributes Attributes
		{
			[__DynamicallyInvokable]
			get
			{
				return this.AttrsImpl;
			}
		}

		// Token: 0x17000B2C RID: 2860
		// (get) Token: 0x06004815 RID: 18453 RVA: 0x001060A5 File Offset: 0x001042A5
		[__DynamicallyInvokable]
		public virtual MemberInfo Member
		{
			[__DynamicallyInvokable]
			get
			{
				return this.MemberImpl;
			}
		}

		// Token: 0x17000B2D RID: 2861
		// (get) Token: 0x06004816 RID: 18454 RVA: 0x001060AD File Offset: 0x001042AD
		[__DynamicallyInvokable]
		public bool IsIn
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & ParameterAttributes.In) > ParameterAttributes.None;
			}
		}

		// Token: 0x17000B2E RID: 2862
		// (get) Token: 0x06004817 RID: 18455 RVA: 0x001060BA File Offset: 0x001042BA
		[__DynamicallyInvokable]
		public bool IsOut
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & ParameterAttributes.Out) > ParameterAttributes.None;
			}
		}

		// Token: 0x17000B2F RID: 2863
		// (get) Token: 0x06004818 RID: 18456 RVA: 0x001060C7 File Offset: 0x001042C7
		[__DynamicallyInvokable]
		public bool IsLcid
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & ParameterAttributes.Lcid) > ParameterAttributes.None;
			}
		}

		// Token: 0x17000B30 RID: 2864
		// (get) Token: 0x06004819 RID: 18457 RVA: 0x001060D4 File Offset: 0x001042D4
		[__DynamicallyInvokable]
		public bool IsRetval
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & ParameterAttributes.Retval) > ParameterAttributes.None;
			}
		}

		// Token: 0x17000B31 RID: 2865
		// (get) Token: 0x0600481A RID: 18458 RVA: 0x001060E1 File Offset: 0x001042E1
		[__DynamicallyInvokable]
		public bool IsOptional
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & ParameterAttributes.Optional) > ParameterAttributes.None;
			}
		}

		// Token: 0x17000B32 RID: 2866
		// (get) Token: 0x0600481B RID: 18459 RVA: 0x001060F0 File Offset: 0x001042F0
		public virtual int MetadataToken
		{
			get
			{
				RuntimeParameterInfo runtimeParameterInfo = this as RuntimeParameterInfo;
				if (runtimeParameterInfo != null)
				{
					return runtimeParameterInfo.MetadataToken;
				}
				return 134217728;
			}
		}

		// Token: 0x0600481C RID: 18460 RVA: 0x00106113 File Offset: 0x00104313
		public virtual Type[] GetRequiredCustomModifiers()
		{
			return EmptyArray<Type>.Value;
		}

		// Token: 0x0600481D RID: 18461 RVA: 0x0010611A File Offset: 0x0010431A
		public virtual Type[] GetOptionalCustomModifiers()
		{
			return EmptyArray<Type>.Value;
		}

		// Token: 0x0600481E RID: 18462 RVA: 0x00106121 File Offset: 0x00104321
		[__DynamicallyInvokable]
		public override string ToString()
		{
			return this.ParameterType.FormatTypeName() + " " + this.Name;
		}

		// Token: 0x17000B33 RID: 2867
		// (get) Token: 0x0600481F RID: 18463 RVA: 0x0010613E File Offset: 0x0010433E
		[__DynamicallyInvokable]
		public virtual IEnumerable<CustomAttributeData> CustomAttributes
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetCustomAttributesData();
			}
		}

		// Token: 0x06004820 RID: 18464 RVA: 0x00106146 File Offset: 0x00104346
		[__DynamicallyInvokable]
		public virtual object[] GetCustomAttributes(bool inherit)
		{
			return EmptyArray<object>.Value;
		}

		// Token: 0x06004821 RID: 18465 RVA: 0x0010614D File Offset: 0x0010434D
		[__DynamicallyInvokable]
		public virtual object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			return EmptyArray<object>.Value;
		}

		// Token: 0x06004822 RID: 18466 RVA: 0x00106168 File Offset: 0x00104368
		[__DynamicallyInvokable]
		public virtual bool IsDefined(Type attributeType, bool inherit)
		{
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			return false;
		}

		// Token: 0x06004823 RID: 18467 RVA: 0x0010617F File Offset: 0x0010437F
		public virtual IList<CustomAttributeData> GetCustomAttributesData()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004824 RID: 18468 RVA: 0x00106186 File Offset: 0x00104386
		void _ParameterInfo.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004825 RID: 18469 RVA: 0x0010618D File Offset: 0x0010438D
		void _ParameterInfo.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004826 RID: 18470 RVA: 0x00106194 File Offset: 0x00104394
		void _ParameterInfo.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004827 RID: 18471 RVA: 0x0010619B File Offset: 0x0010439B
		void _ParameterInfo.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004828 RID: 18472 RVA: 0x001061A4 File Offset: 0x001043A4
		[SecurityCritical]
		public object GetRealObject(StreamingContext context)
		{
			if (this.MemberImpl == null)
			{
				throw new SerializationException(Environment.GetResourceString("Serialization_InsufficientState"));
			}
			MemberTypes memberType = this.MemberImpl.MemberType;
			if (memberType != MemberTypes.Constructor && memberType != MemberTypes.Method)
			{
				if (memberType != MemberTypes.Property)
				{
					throw new SerializationException(Environment.GetResourceString("Serialization_NoParameterInfo"));
				}
				ParameterInfo[] array = ((RuntimePropertyInfo)this.MemberImpl).GetIndexParametersNoCopy();
				if (array != null && this.PositionImpl > -1 && this.PositionImpl < array.Length)
				{
					return array[this.PositionImpl];
				}
				throw new SerializationException(Environment.GetResourceString("Serialization_BadParameterInfo"));
			}
			else if (this.PositionImpl == -1)
			{
				if (this.MemberImpl.MemberType == MemberTypes.Method)
				{
					return ((MethodInfo)this.MemberImpl).ReturnParameter;
				}
				throw new SerializationException(Environment.GetResourceString("Serialization_BadParameterInfo"));
			}
			else
			{
				ParameterInfo[] array = ((MethodBase)this.MemberImpl).GetParametersNoCopy();
				if (array != null && this.PositionImpl < array.Length)
				{
					return array[this.PositionImpl];
				}
				throw new SerializationException(Environment.GetResourceString("Serialization_BadParameterInfo"));
			}
		}

		// Token: 0x04001DE5 RID: 7653
		protected string NameImpl;

		// Token: 0x04001DE6 RID: 7654
		protected Type ClassImpl;

		// Token: 0x04001DE7 RID: 7655
		protected int PositionImpl;

		// Token: 0x04001DE8 RID: 7656
		protected ParameterAttributes AttrsImpl;

		// Token: 0x04001DE9 RID: 7657
		protected object DefaultValueImpl;

		// Token: 0x04001DEA RID: 7658
		protected MemberInfo MemberImpl;

		// Token: 0x04001DEB RID: 7659
		[OptionalField]
		private IntPtr _importer;

		// Token: 0x04001DEC RID: 7660
		[OptionalField]
		private int _token;

		// Token: 0x04001DED RID: 7661
		[OptionalField]
		private bool bExtraConstChecked;
	}
}
