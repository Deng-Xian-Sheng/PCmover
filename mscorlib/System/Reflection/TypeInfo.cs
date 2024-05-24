using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x02000626 RID: 1574
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class TypeInfo : Type, IReflectableType
	{
		// Token: 0x060048EC RID: 18668 RVA: 0x00107C20 File Offset: 0x00105E20
		[FriendAccessAllowed]
		internal TypeInfo()
		{
		}

		// Token: 0x060048ED RID: 18669 RVA: 0x00107C28 File Offset: 0x00105E28
		[__DynamicallyInvokable]
		TypeInfo IReflectableType.GetTypeInfo()
		{
			return this;
		}

		// Token: 0x060048EE RID: 18670 RVA: 0x00107C2B File Offset: 0x00105E2B
		[__DynamicallyInvokable]
		public virtual Type AsType()
		{
			return this;
		}

		// Token: 0x17000B62 RID: 2914
		// (get) Token: 0x060048EF RID: 18671 RVA: 0x00107C2E File Offset: 0x00105E2E
		[__DynamicallyInvokable]
		public virtual Type[] GenericTypeParameters
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.IsGenericTypeDefinition)
				{
					return this.GetGenericArguments();
				}
				return Type.EmptyTypes;
			}
		}

		// Token: 0x060048F0 RID: 18672 RVA: 0x00107C44 File Offset: 0x00105E44
		[__DynamicallyInvokable]
		public virtual bool IsAssignableFrom(TypeInfo typeInfo)
		{
			if (typeInfo == null)
			{
				return false;
			}
			if (this == typeInfo)
			{
				return true;
			}
			if (typeInfo.IsSubclassOf(this))
			{
				return true;
			}
			if (base.IsInterface)
			{
				return typeInfo.ImplementInterface(this);
			}
			if (this.IsGenericParameter)
			{
				Type[] genericParameterConstraints = this.GetGenericParameterConstraints();
				for (int i = 0; i < genericParameterConstraints.Length; i++)
				{
					if (!genericParameterConstraints[i].IsAssignableFrom(typeInfo))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x060048F1 RID: 18673 RVA: 0x00107CAF File Offset: 0x00105EAF
		[__DynamicallyInvokable]
		public virtual EventInfo GetDeclaredEvent(string name)
		{
			return this.GetEvent(name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x060048F2 RID: 18674 RVA: 0x00107CBA File Offset: 0x00105EBA
		[__DynamicallyInvokable]
		public virtual FieldInfo GetDeclaredField(string name)
		{
			return this.GetField(name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x060048F3 RID: 18675 RVA: 0x00107CC5 File Offset: 0x00105EC5
		[__DynamicallyInvokable]
		public virtual MethodInfo GetDeclaredMethod(string name)
		{
			return base.GetMethod(name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x060048F4 RID: 18676 RVA: 0x00107CD0 File Offset: 0x00105ED0
		[__DynamicallyInvokable]
		public virtual IEnumerable<MethodInfo> GetDeclaredMethods(string name)
		{
			foreach (MethodInfo methodInfo in this.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
			{
				if (methodInfo.Name == name)
				{
					yield return methodInfo;
				}
			}
			MethodInfo[] array = null;
			yield break;
		}

		// Token: 0x060048F5 RID: 18677 RVA: 0x00107CE8 File Offset: 0x00105EE8
		[__DynamicallyInvokable]
		public virtual TypeInfo GetDeclaredNestedType(string name)
		{
			Type nestedType = this.GetNestedType(name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (nestedType == null)
			{
				return null;
			}
			return nestedType.GetTypeInfo();
		}

		// Token: 0x060048F6 RID: 18678 RVA: 0x00107D10 File Offset: 0x00105F10
		[__DynamicallyInvokable]
		public virtual PropertyInfo GetDeclaredProperty(string name)
		{
			return base.GetProperty(name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x17000B63 RID: 2915
		// (get) Token: 0x060048F7 RID: 18679 RVA: 0x00107D1B File Offset: 0x00105F1B
		[__DynamicallyInvokable]
		public virtual IEnumerable<ConstructorInfo> DeclaredConstructors
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetConstructors(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
		}

		// Token: 0x17000B64 RID: 2916
		// (get) Token: 0x060048F8 RID: 18680 RVA: 0x00107D25 File Offset: 0x00105F25
		[__DynamicallyInvokable]
		public virtual IEnumerable<EventInfo> DeclaredEvents
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetEvents(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
		}

		// Token: 0x17000B65 RID: 2917
		// (get) Token: 0x060048F9 RID: 18681 RVA: 0x00107D2F File Offset: 0x00105F2F
		[__DynamicallyInvokable]
		public virtual IEnumerable<FieldInfo> DeclaredFields
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
		}

		// Token: 0x17000B66 RID: 2918
		// (get) Token: 0x060048FA RID: 18682 RVA: 0x00107D39 File Offset: 0x00105F39
		[__DynamicallyInvokable]
		public virtual IEnumerable<MemberInfo> DeclaredMembers
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
		}

		// Token: 0x17000B67 RID: 2919
		// (get) Token: 0x060048FB RID: 18683 RVA: 0x00107D43 File Offset: 0x00105F43
		[__DynamicallyInvokable]
		public virtual IEnumerable<MethodInfo> DeclaredMethods
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
		}

		// Token: 0x17000B68 RID: 2920
		// (get) Token: 0x060048FC RID: 18684 RVA: 0x00107D50 File Offset: 0x00105F50
		[__DynamicallyInvokable]
		public virtual IEnumerable<TypeInfo> DeclaredNestedTypes
		{
			[__DynamicallyInvokable]
			get
			{
				foreach (Type type in this.GetNestedTypes(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
				{
					yield return type.GetTypeInfo();
				}
				Type[] array = null;
				yield break;
			}
		}

		// Token: 0x17000B69 RID: 2921
		// (get) Token: 0x060048FD RID: 18685 RVA: 0x00107D6D File Offset: 0x00105F6D
		[__DynamicallyInvokable]
		public virtual IEnumerable<PropertyInfo> DeclaredProperties
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
		}

		// Token: 0x17000B6A RID: 2922
		// (get) Token: 0x060048FE RID: 18686 RVA: 0x00107D77 File Offset: 0x00105F77
		[__DynamicallyInvokable]
		public virtual IEnumerable<Type> ImplementedInterfaces
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetInterfaces();
			}
		}
	}
}
