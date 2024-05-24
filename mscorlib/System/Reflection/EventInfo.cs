using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Permissions;

namespace System.Reflection
{
	// Token: 0x020005E1 RID: 1505
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_EventInfo))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[Serializable]
	public abstract class EventInfo : MemberInfo, _EventInfo
	{
		// Token: 0x060045B0 RID: 17840 RVA: 0x00101175 File Offset: 0x000FF375
		[__DynamicallyInvokable]
		public static bool operator ==(EventInfo left, EventInfo right)
		{
			return left == right || (left != null && right != null && !(left is RuntimeEventInfo) && !(right is RuntimeEventInfo) && left.Equals(right));
		}

		// Token: 0x060045B1 RID: 17841 RVA: 0x0010119C File Offset: 0x000FF39C
		[__DynamicallyInvokable]
		public static bool operator !=(EventInfo left, EventInfo right)
		{
			return !(left == right);
		}

		// Token: 0x060045B2 RID: 17842 RVA: 0x001011A8 File Offset: 0x000FF3A8
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		// Token: 0x060045B3 RID: 17843 RVA: 0x001011B1 File Offset: 0x000FF3B1
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x17000A5E RID: 2654
		// (get) Token: 0x060045B4 RID: 17844 RVA: 0x001011B9 File Offset: 0x000FF3B9
		public override MemberTypes MemberType
		{
			get
			{
				return MemberTypes.Event;
			}
		}

		// Token: 0x060045B5 RID: 17845 RVA: 0x001011BC File Offset: 0x000FF3BC
		public virtual MethodInfo[] GetOtherMethods(bool nonPublic)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060045B6 RID: 17846
		[__DynamicallyInvokable]
		public abstract MethodInfo GetAddMethod(bool nonPublic);

		// Token: 0x060045B7 RID: 17847
		[__DynamicallyInvokable]
		public abstract MethodInfo GetRemoveMethod(bool nonPublic);

		// Token: 0x060045B8 RID: 17848
		[__DynamicallyInvokable]
		public abstract MethodInfo GetRaiseMethod(bool nonPublic);

		// Token: 0x17000A5F RID: 2655
		// (get) Token: 0x060045B9 RID: 17849
		[__DynamicallyInvokable]
		public abstract EventAttributes Attributes { [__DynamicallyInvokable] get; }

		// Token: 0x17000A60 RID: 2656
		// (get) Token: 0x060045BA RID: 17850 RVA: 0x001011C3 File Offset: 0x000FF3C3
		[__DynamicallyInvokable]
		public virtual MethodInfo AddMethod
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetAddMethod(true);
			}
		}

		// Token: 0x17000A61 RID: 2657
		// (get) Token: 0x060045BB RID: 17851 RVA: 0x001011CC File Offset: 0x000FF3CC
		[__DynamicallyInvokable]
		public virtual MethodInfo RemoveMethod
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetRemoveMethod(true);
			}
		}

		// Token: 0x17000A62 RID: 2658
		// (get) Token: 0x060045BC RID: 17852 RVA: 0x001011D5 File Offset: 0x000FF3D5
		[__DynamicallyInvokable]
		public virtual MethodInfo RaiseMethod
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetRaiseMethod(true);
			}
		}

		// Token: 0x060045BD RID: 17853 RVA: 0x001011DE File Offset: 0x000FF3DE
		public MethodInfo[] GetOtherMethods()
		{
			return this.GetOtherMethods(false);
		}

		// Token: 0x060045BE RID: 17854 RVA: 0x001011E7 File Offset: 0x000FF3E7
		[__DynamicallyInvokable]
		public MethodInfo GetAddMethod()
		{
			return this.GetAddMethod(false);
		}

		// Token: 0x060045BF RID: 17855 RVA: 0x001011F0 File Offset: 0x000FF3F0
		[__DynamicallyInvokable]
		public MethodInfo GetRemoveMethod()
		{
			return this.GetRemoveMethod(false);
		}

		// Token: 0x060045C0 RID: 17856 RVA: 0x001011F9 File Offset: 0x000FF3F9
		[__DynamicallyInvokable]
		public MethodInfo GetRaiseMethod()
		{
			return this.GetRaiseMethod(false);
		}

		// Token: 0x060045C1 RID: 17857 RVA: 0x00101204 File Offset: 0x000FF404
		[DebuggerStepThrough]
		[DebuggerHidden]
		[__DynamicallyInvokable]
		public virtual void AddEventHandler(object target, Delegate handler)
		{
			MethodInfo addMethod = this.GetAddMethod();
			if (addMethod == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NoPublicAddMethod"));
			}
			if (addMethod.ReturnType == typeof(EventRegistrationToken))
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotSupportedOnWinRTEvent"));
			}
			addMethod.Invoke(target, new object[]
			{
				handler
			});
		}

		// Token: 0x060045C2 RID: 17858 RVA: 0x0010126C File Offset: 0x000FF46C
		[DebuggerStepThrough]
		[DebuggerHidden]
		[__DynamicallyInvokable]
		public virtual void RemoveEventHandler(object target, Delegate handler)
		{
			MethodInfo removeMethod = this.GetRemoveMethod();
			if (removeMethod == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NoPublicRemoveMethod"));
			}
			ParameterInfo[] parametersNoCopy = removeMethod.GetParametersNoCopy();
			if (parametersNoCopy[0].ParameterType == typeof(EventRegistrationToken))
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotSupportedOnWinRTEvent"));
			}
			removeMethod.Invoke(target, new object[]
			{
				handler
			});
		}

		// Token: 0x17000A63 RID: 2659
		// (get) Token: 0x060045C3 RID: 17859 RVA: 0x001012DC File Offset: 0x000FF4DC
		[__DynamicallyInvokable]
		public virtual Type EventHandlerType
		{
			[__DynamicallyInvokable]
			get
			{
				MethodInfo addMethod = this.GetAddMethod(true);
				ParameterInfo[] parametersNoCopy = addMethod.GetParametersNoCopy();
				Type typeFromHandle = typeof(Delegate);
				for (int i = 0; i < parametersNoCopy.Length; i++)
				{
					Type parameterType = parametersNoCopy[i].ParameterType;
					if (parameterType.IsSubclassOf(typeFromHandle))
					{
						return parameterType;
					}
				}
				return null;
			}
		}

		// Token: 0x17000A64 RID: 2660
		// (get) Token: 0x060045C4 RID: 17860 RVA: 0x00101329 File Offset: 0x000FF529
		[__DynamicallyInvokable]
		public bool IsSpecialName
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & EventAttributes.SpecialName) > EventAttributes.None;
			}
		}

		// Token: 0x17000A65 RID: 2661
		// (get) Token: 0x060045C5 RID: 17861 RVA: 0x0010133C File Offset: 0x000FF53C
		[__DynamicallyInvokable]
		public virtual bool IsMulticast
		{
			[__DynamicallyInvokable]
			get
			{
				Type eventHandlerType = this.EventHandlerType;
				Type typeFromHandle = typeof(MulticastDelegate);
				return typeFromHandle.IsAssignableFrom(eventHandlerType);
			}
		}

		// Token: 0x060045C6 RID: 17862 RVA: 0x00101362 File Offset: 0x000FF562
		Type _EventInfo.GetType()
		{
			return base.GetType();
		}

		// Token: 0x060045C7 RID: 17863 RVA: 0x0010136A File Offset: 0x000FF56A
		void _EventInfo.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060045C8 RID: 17864 RVA: 0x00101371 File Offset: 0x000FF571
		void _EventInfo.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060045C9 RID: 17865 RVA: 0x00101378 File Offset: 0x000FF578
		void _EventInfo.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060045CA RID: 17866 RVA: 0x0010137F File Offset: 0x000FF57F
		void _EventInfo.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}
	}
}
