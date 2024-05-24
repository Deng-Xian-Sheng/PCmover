using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security;

namespace System.Runtime.Serialization
{
	// Token: 0x02000756 RID: 1878
	internal class SerializationEvents
	{
		// Token: 0x060052DA RID: 21210 RVA: 0x00123304 File Offset: 0x00121504
		private List<MethodInfo> GetMethodsWithAttribute(Type attribute, Type t)
		{
			List<MethodInfo> list = new List<MethodInfo>();
			Type type = t;
			while (type != null && type != typeof(object))
			{
				RuntimeType runtimeType = (RuntimeType)type;
				MethodInfo[] methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (MethodInfo methodInfo in methods)
				{
					if (methodInfo.IsDefined(attribute, false))
					{
						list.Add(methodInfo);
					}
				}
				type = type.BaseType;
			}
			list.Reverse();
			if (list.Count != 0)
			{
				return list;
			}
			return null;
		}

		// Token: 0x060052DB RID: 21211 RVA: 0x00123390 File Offset: 0x00121590
		internal SerializationEvents(Type t)
		{
			this.m_OnSerializingMethods = this.GetMethodsWithAttribute(typeof(OnSerializingAttribute), t);
			this.m_OnSerializedMethods = this.GetMethodsWithAttribute(typeof(OnSerializedAttribute), t);
			this.m_OnDeserializingMethods = this.GetMethodsWithAttribute(typeof(OnDeserializingAttribute), t);
			this.m_OnDeserializedMethods = this.GetMethodsWithAttribute(typeof(OnDeserializedAttribute), t);
		}

		// Token: 0x17000DB4 RID: 3508
		// (get) Token: 0x060052DC RID: 21212 RVA: 0x001233FF File Offset: 0x001215FF
		internal bool HasOnSerializingEvents
		{
			get
			{
				return this.m_OnSerializingMethods != null || this.m_OnSerializedMethods != null;
			}
		}

		// Token: 0x060052DD RID: 21213 RVA: 0x00123414 File Offset: 0x00121614
		[SecuritySafeCritical]
		internal void InvokeOnSerializing(object obj, StreamingContext context)
		{
			if (this.m_OnSerializingMethods != null)
			{
				object[] array = new object[]
				{
					context
				};
				SerializationEventHandler serializationEventHandler = null;
				foreach (MethodInfo method in this.m_OnSerializingMethods)
				{
					SerializationEventHandler b = (SerializationEventHandler)Delegate.CreateDelegateNoSecurityCheck((RuntimeType)typeof(SerializationEventHandler), obj, method);
					serializationEventHandler = (SerializationEventHandler)Delegate.Combine(serializationEventHandler, b);
				}
				serializationEventHandler(context);
			}
		}

		// Token: 0x060052DE RID: 21214 RVA: 0x001234AC File Offset: 0x001216AC
		[SecuritySafeCritical]
		internal void InvokeOnDeserializing(object obj, StreamingContext context)
		{
			if (this.m_OnDeserializingMethods != null)
			{
				object[] array = new object[]
				{
					context
				};
				SerializationEventHandler serializationEventHandler = null;
				foreach (MethodInfo method in this.m_OnDeserializingMethods)
				{
					SerializationEventHandler b = (SerializationEventHandler)Delegate.CreateDelegateNoSecurityCheck((RuntimeType)typeof(SerializationEventHandler), obj, method);
					serializationEventHandler = (SerializationEventHandler)Delegate.Combine(serializationEventHandler, b);
				}
				serializationEventHandler(context);
			}
		}

		// Token: 0x060052DF RID: 21215 RVA: 0x00123544 File Offset: 0x00121744
		[SecuritySafeCritical]
		internal void InvokeOnDeserialized(object obj, StreamingContext context)
		{
			if (this.m_OnDeserializedMethods != null)
			{
				object[] array = new object[]
				{
					context
				};
				SerializationEventHandler serializationEventHandler = null;
				foreach (MethodInfo method in this.m_OnDeserializedMethods)
				{
					SerializationEventHandler b = (SerializationEventHandler)Delegate.CreateDelegateNoSecurityCheck((RuntimeType)typeof(SerializationEventHandler), obj, method);
					serializationEventHandler = (SerializationEventHandler)Delegate.Combine(serializationEventHandler, b);
				}
				serializationEventHandler(context);
			}
		}

		// Token: 0x060052E0 RID: 21216 RVA: 0x001235DC File Offset: 0x001217DC
		[SecurityCritical]
		internal SerializationEventHandler AddOnSerialized(object obj, SerializationEventHandler handler)
		{
			if (this.m_OnSerializedMethods != null)
			{
				foreach (MethodInfo method in this.m_OnSerializedMethods)
				{
					SerializationEventHandler b = (SerializationEventHandler)Delegate.CreateDelegateNoSecurityCheck((RuntimeType)typeof(SerializationEventHandler), obj, method);
					handler = (SerializationEventHandler)Delegate.Combine(handler, b);
				}
			}
			return handler;
		}

		// Token: 0x060052E1 RID: 21217 RVA: 0x0012365C File Offset: 0x0012185C
		[SecurityCritical]
		internal SerializationEventHandler AddOnDeserialized(object obj, SerializationEventHandler handler)
		{
			if (this.m_OnDeserializedMethods != null)
			{
				foreach (MethodInfo method in this.m_OnDeserializedMethods)
				{
					SerializationEventHandler b = (SerializationEventHandler)Delegate.CreateDelegateNoSecurityCheck((RuntimeType)typeof(SerializationEventHandler), obj, method);
					handler = (SerializationEventHandler)Delegate.Combine(handler, b);
				}
			}
			return handler;
		}

		// Token: 0x040024B9 RID: 9401
		private List<MethodInfo> m_OnSerializingMethods;

		// Token: 0x040024BA RID: 9402
		private List<MethodInfo> m_OnSerializedMethods;

		// Token: 0x040024BB RID: 9403
		private List<MethodInfo> m_OnDeserializingMethods;

		// Token: 0x040024BC RID: 9404
		private List<MethodInfo> m_OnDeserializedMethods;
	}
}
