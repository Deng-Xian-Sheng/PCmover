using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Reflection
{
	// Token: 0x02000600 RID: 1536
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_MemberInfo))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[Serializable]
	public abstract class MemberInfo : ICustomAttributeProvider, _MemberInfo
	{
		// Token: 0x060046D2 RID: 18130 RVA: 0x00102EE9 File Offset: 0x001010E9
		internal virtual bool CacheEquals(object o)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000AB3 RID: 2739
		// (get) Token: 0x060046D3 RID: 18131
		public abstract MemberTypes MemberType { get; }

		// Token: 0x17000AB4 RID: 2740
		// (get) Token: 0x060046D4 RID: 18132
		[__DynamicallyInvokable]
		public abstract string Name { [__DynamicallyInvokable] get; }

		// Token: 0x17000AB5 RID: 2741
		// (get) Token: 0x060046D5 RID: 18133
		[__DynamicallyInvokable]
		public abstract Type DeclaringType { [__DynamicallyInvokable] get; }

		// Token: 0x17000AB6 RID: 2742
		// (get) Token: 0x060046D6 RID: 18134
		[__DynamicallyInvokable]
		public abstract Type ReflectedType { [__DynamicallyInvokable] get; }

		// Token: 0x17000AB7 RID: 2743
		// (get) Token: 0x060046D7 RID: 18135 RVA: 0x00102EF0 File Offset: 0x001010F0
		[__DynamicallyInvokable]
		public virtual IEnumerable<CustomAttributeData> CustomAttributes
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetCustomAttributesData();
			}
		}

		// Token: 0x060046D8 RID: 18136
		[__DynamicallyInvokable]
		public abstract object[] GetCustomAttributes(bool inherit);

		// Token: 0x060046D9 RID: 18137
		[__DynamicallyInvokable]
		public abstract object[] GetCustomAttributes(Type attributeType, bool inherit);

		// Token: 0x060046DA RID: 18138
		[__DynamicallyInvokable]
		public abstract bool IsDefined(Type attributeType, bool inherit);

		// Token: 0x060046DB RID: 18139 RVA: 0x00102EF8 File Offset: 0x001010F8
		public virtual IList<CustomAttributeData> GetCustomAttributesData()
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000AB8 RID: 2744
		// (get) Token: 0x060046DC RID: 18140 RVA: 0x00102EFF File Offset: 0x001010FF
		public virtual int MetadataToken
		{
			get
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x17000AB9 RID: 2745
		// (get) Token: 0x060046DD RID: 18141 RVA: 0x00102F06 File Offset: 0x00101106
		[__DynamicallyInvokable]
		public virtual Module Module
		{
			[__DynamicallyInvokable]
			get
			{
				if (this is Type)
				{
					return ((Type)this).Module;
				}
				throw new NotImplementedException();
			}
		}

		// Token: 0x060046DE RID: 18142 RVA: 0x00102F24 File Offset: 0x00101124
		[__DynamicallyInvokable]
		public static bool operator ==(MemberInfo left, MemberInfo right)
		{
			if (left == right)
			{
				return true;
			}
			if (left == null || right == null)
			{
				return false;
			}
			Type left2;
			Type right2;
			if ((left2 = (left as Type)) != null && (right2 = (right as Type)) != null)
			{
				return left2 == right2;
			}
			MethodBase left3;
			MethodBase right3;
			if ((left3 = (left as MethodBase)) != null && (right3 = (right as MethodBase)) != null)
			{
				return left3 == right3;
			}
			FieldInfo left4;
			FieldInfo right4;
			if ((left4 = (left as FieldInfo)) != null && (right4 = (right as FieldInfo)) != null)
			{
				return left4 == right4;
			}
			EventInfo left5;
			EventInfo right5;
			if ((left5 = (left as EventInfo)) != null && (right5 = (right as EventInfo)) != null)
			{
				return left5 == right5;
			}
			PropertyInfo left6;
			PropertyInfo right6;
			return (left6 = (left as PropertyInfo)) != null && (right6 = (right as PropertyInfo)) != null && left6 == right6;
		}

		// Token: 0x060046DF RID: 18143 RVA: 0x00103014 File Offset: 0x00101214
		[__DynamicallyInvokable]
		public static bool operator !=(MemberInfo left, MemberInfo right)
		{
			return !(left == right);
		}

		// Token: 0x060046E0 RID: 18144 RVA: 0x00103020 File Offset: 0x00101220
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		// Token: 0x060046E1 RID: 18145 RVA: 0x00103029 File Offset: 0x00101229
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060046E2 RID: 18146 RVA: 0x00103031 File Offset: 0x00101231
		Type _MemberInfo.GetType()
		{
			return base.GetType();
		}

		// Token: 0x060046E3 RID: 18147 RVA: 0x00103039 File Offset: 0x00101239
		void _MemberInfo.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060046E4 RID: 18148 RVA: 0x00103040 File Offset: 0x00101240
		void _MemberInfo.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060046E5 RID: 18149 RVA: 0x00103047 File Offset: 0x00101247
		void _MemberInfo.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060046E6 RID: 18150 RVA: 0x0010304E File Offset: 0x0010124E
		void _MemberInfo.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}
	}
}
