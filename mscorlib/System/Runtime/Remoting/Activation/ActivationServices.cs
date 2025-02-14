﻿using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Runtime.Remoting.Activation
{
	// Token: 0x02000890 RID: 2192
	internal static class ActivationServices
	{
		// Token: 0x06005CE1 RID: 23777 RVA: 0x00145910 File Offset: 0x00143B10
		[SecurityCritical]
		private static void Startup()
		{
			DomainSpecificRemotingData remotingData = Thread.GetDomain().RemotingData;
			if (!remotingData.ActivationInitialized || remotingData.InitializingActivation)
			{
				object configLock = remotingData.ConfigLock;
				bool flag = false;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					Monitor.Enter(configLock, ref flag);
					remotingData.InitializingActivation = true;
					if (!remotingData.ActivationInitialized)
					{
						remotingData.LocalActivator = new LocalActivator();
						remotingData.ActivationListener = new ActivationListener();
						remotingData.ActivationInitialized = true;
					}
					remotingData.InitializingActivation = false;
				}
				finally
				{
					if (flag)
					{
						Monitor.Exit(configLock);
					}
				}
			}
		}

		// Token: 0x06005CE2 RID: 23778 RVA: 0x001459A0 File Offset: 0x00143BA0
		[SecurityCritical]
		private static void InitActivationServices()
		{
			if (ActivationServices.activator == null)
			{
				ActivationServices.activator = ActivationServices.GetActivator();
				if (ActivationServices.activator == null)
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_BadInternalState_ActivationFailure"), Array.Empty<object>()));
				}
			}
		}

		// Token: 0x06005CE3 RID: 23779 RVA: 0x001459E0 File Offset: 0x00143BE0
		[SecurityCritical]
		private static MarshalByRefObject IsCurrentContextOK(RuntimeType serverType, object[] props, bool bNewObj)
		{
			ActivationServices.InitActivationServices();
			ProxyAttribute proxyAttribute = ActivationServices.GetProxyAttribute(serverType);
			MarshalByRefObject marshalByRefObject;
			if (proxyAttribute == ActivationServices.DefaultProxyAttribute)
			{
				marshalByRefObject = proxyAttribute.CreateInstanceInternal(serverType);
			}
			else
			{
				marshalByRefObject = proxyAttribute.CreateInstance(serverType);
				if (marshalByRefObject != null && !RemotingServices.IsTransparentProxy(marshalByRefObject) && !serverType.IsAssignableFrom(marshalByRefObject.GetType()))
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Activation_BadObject"), serverType));
				}
			}
			return marshalByRefObject;
		}

		// Token: 0x06005CE4 RID: 23780 RVA: 0x00145A4C File Offset: 0x00143C4C
		[SecurityCritical]
		private static MarshalByRefObject CreateObjectForCom(RuntimeType serverType, object[] props, bool bNewObj)
		{
			if (ActivationServices.PeekActivationAttributes(serverType) != null)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_ActivForCom"));
			}
			ActivationServices.InitActivationServices();
			ProxyAttribute proxyAttribute = ActivationServices.GetProxyAttribute(serverType);
			MarshalByRefObject result;
			if (proxyAttribute is ICustomFactory)
			{
				result = ((ICustomFactory)proxyAttribute).CreateInstance(serverType);
			}
			else
			{
				result = (MarshalByRefObject)Activator.CreateInstance(serverType, true);
			}
			return result;
		}

		// Token: 0x06005CE5 RID: 23781 RVA: 0x00145AA4 File Offset: 0x00143CA4
		[SecurityCritical]
		private static bool IsCurrentContextOK(RuntimeType serverType, object[] props, ref ConstructorCallMessage ctorCallMsg)
		{
			object[] array = ActivationServices.PeekActivationAttributes(serverType);
			if (array != null)
			{
				ActivationServices.PopActivationAttributes(serverType);
			}
			object[] array2 = new object[]
			{
				ActivationServices.GetGlobalAttribute()
			};
			object[] contextAttributesForType = ActivationServices.GetContextAttributesForType(serverType);
			object[] array3 = contextAttributesForType;
			Context currentContext = Thread.CurrentContext;
			ctorCallMsg = new ConstructorCallMessage(array, array2, array3, serverType);
			ctorCallMsg.Activator = new ConstructionLevelActivator();
			bool flag = ActivationServices.QueryAttributesIfContextOK(currentContext, ctorCallMsg, array2);
			if (flag)
			{
				flag = ActivationServices.QueryAttributesIfContextOK(currentContext, ctorCallMsg, array);
				if (flag)
				{
					flag = ActivationServices.QueryAttributesIfContextOK(currentContext, ctorCallMsg, array3);
				}
			}
			return flag;
		}

		// Token: 0x06005CE6 RID: 23782 RVA: 0x00145B24 File Offset: 0x00143D24
		[SecurityCritical]
		private static void CheckForInfrastructurePermission(RuntimeAssembly asm)
		{
			if (asm != ActivationServices.s_MscorlibAssembly)
			{
				SecurityPermission demand = new SecurityPermission(SecurityPermissionFlag.Infrastructure);
				CodeAccessSecurityEngine.CheckAssembly(asm, demand);
			}
		}

		// Token: 0x06005CE7 RID: 23783 RVA: 0x00145B50 File Offset: 0x00143D50
		[SecurityCritical]
		private static bool QueryAttributesIfContextOK(Context ctx, IConstructionCallMessage ctorMsg, object[] attributes)
		{
			bool flag = true;
			if (attributes != null)
			{
				for (int i = 0; i < attributes.Length; i++)
				{
					IContextAttribute contextAttribute = attributes[i] as IContextAttribute;
					if (contextAttribute == null)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_Activation_BadAttribute"));
					}
					RuntimeAssembly asm = (RuntimeAssembly)contextAttribute.GetType().Assembly;
					ActivationServices.CheckForInfrastructurePermission(asm);
					flag = contextAttribute.IsContextOK(ctx, ctorMsg);
					if (!flag)
					{
						break;
					}
				}
			}
			return flag;
		}

		// Token: 0x06005CE8 RID: 23784 RVA: 0x00145BB4 File Offset: 0x00143DB4
		[SecurityCritical]
		internal static void GetPropertiesFromAttributes(IConstructionCallMessage ctorMsg, object[] attributes)
		{
			if (attributes != null)
			{
				for (int i = 0; i < attributes.Length; i++)
				{
					IContextAttribute contextAttribute = attributes[i] as IContextAttribute;
					if (contextAttribute == null)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_Activation_BadAttribute"));
					}
					RuntimeAssembly asm = (RuntimeAssembly)contextAttribute.GetType().Assembly;
					ActivationServices.CheckForInfrastructurePermission(asm);
					contextAttribute.GetPropertiesForNewContext(ctorMsg);
				}
			}
		}

		// Token: 0x17000FFB RID: 4091
		// (get) Token: 0x06005CE9 RID: 23785 RVA: 0x00145C0E File Offset: 0x00143E0E
		internal static ProxyAttribute DefaultProxyAttribute
		{
			[SecurityCritical]
			get
			{
				return ActivationServices._proxyAttribute;
			}
		}

		// Token: 0x06005CEA RID: 23786 RVA: 0x00145C18 File Offset: 0x00143E18
		[SecurityCritical]
		internal static ProxyAttribute GetProxyAttribute(Type serverType)
		{
			if (!serverType.HasProxyAttribute)
			{
				return ActivationServices.DefaultProxyAttribute;
			}
			ProxyAttribute proxyAttribute = ActivationServices._proxyTable[serverType] as ProxyAttribute;
			if (proxyAttribute == null)
			{
				object[] customAttributes = Attribute.GetCustomAttributes(serverType, ActivationServices.proxyAttributeType, true);
				object[] array = customAttributes;
				if (array != null && array.Length != 0)
				{
					if (!serverType.IsContextful)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_Activation_MBR_ProxyAttribute"));
					}
					proxyAttribute = (array[0] as ProxyAttribute);
				}
				if (!ActivationServices._proxyTable.Contains(serverType))
				{
					Hashtable proxyTable = ActivationServices._proxyTable;
					lock (proxyTable)
					{
						if (!ActivationServices._proxyTable.Contains(serverType))
						{
							ActivationServices._proxyTable.Add(serverType, proxyAttribute);
						}
					}
				}
			}
			return proxyAttribute;
		}

		// Token: 0x06005CEB RID: 23787 RVA: 0x00145CD4 File Offset: 0x00143ED4
		[SecurityCritical]
		internal static MarshalByRefObject CreateInstance(RuntimeType serverType)
		{
			ConstructorCallMessage constructorCallMessage = null;
			bool flag = ActivationServices.IsCurrentContextOK(serverType, null, ref constructorCallMessage);
			MarshalByRefObject marshalByRefObject;
			if (flag && !serverType.IsContextful)
			{
				marshalByRefObject = RemotingServices.AllocateUninitializedObject(serverType);
			}
			else
			{
				marshalByRefObject = (MarshalByRefObject)ActivationServices.ConnectIfNecessary(constructorCallMessage);
				RemotingProxy remotingProxy;
				if (marshalByRefObject == null)
				{
					remotingProxy = new RemotingProxy(serverType);
					marshalByRefObject = (MarshalByRefObject)remotingProxy.GetTransparentProxy();
				}
				else
				{
					remotingProxy = (RemotingProxy)RemotingServices.GetRealProxy(marshalByRefObject);
				}
				remotingProxy.ConstructorMessage = constructorCallMessage;
				if (!flag)
				{
					ContextLevelActivator contextLevelActivator = new ContextLevelActivator();
					contextLevelActivator.NextActivator = constructorCallMessage.Activator;
					constructorCallMessage.Activator = contextLevelActivator;
				}
				else
				{
					constructorCallMessage.ActivateInContext = true;
				}
			}
			return marshalByRefObject;
		}

		// Token: 0x06005CEC RID: 23788 RVA: 0x00145D64 File Offset: 0x00143F64
		[SecurityCritical]
		internal static IConstructionReturnMessage Activate(RemotingProxy remProxy, IConstructionCallMessage ctorMsg)
		{
			IConstructionReturnMessage constructionReturnMessage;
			if (((ConstructorCallMessage)ctorMsg).ActivateInContext)
			{
				constructionReturnMessage = ctorMsg.Activator.Activate(ctorMsg);
				if (constructionReturnMessage.Exception != null)
				{
					throw constructionReturnMessage.Exception;
				}
			}
			else
			{
				ActivationServices.GetPropertiesFromAttributes(ctorMsg, ctorMsg.CallSiteActivationAttributes);
				ActivationServices.GetPropertiesFromAttributes(ctorMsg, ((ConstructorCallMessage)ctorMsg).GetWOMAttributes());
				ActivationServices.GetPropertiesFromAttributes(ctorMsg, ((ConstructorCallMessage)ctorMsg).GetTypeAttributes());
				IMessageSink clientContextChain = Thread.CurrentContext.GetClientContextChain();
				IMethodReturnMessage methodReturnMessage = (IMethodReturnMessage)clientContextChain.SyncProcessMessage(ctorMsg);
				constructionReturnMessage = (methodReturnMessage as IConstructionReturnMessage);
				if (methodReturnMessage == null)
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_Activation_Failed"));
				}
				if (methodReturnMessage.Exception != null)
				{
					throw methodReturnMessage.Exception;
				}
			}
			return constructionReturnMessage;
		}

		// Token: 0x06005CED RID: 23789 RVA: 0x00145E0C File Offset: 0x0014400C
		[SecurityCritical]
		internal static IConstructionReturnMessage DoCrossContextActivation(IConstructionCallMessage reqMsg)
		{
			bool isContextful = reqMsg.ActivationType.IsContextful;
			Context context = null;
			if (isContextful)
			{
				context = new Context();
				ArrayList arrayList = (ArrayList)reqMsg.ContextProperties;
				for (int i = 0; i < arrayList.Count; i++)
				{
					IContextProperty contextProperty = arrayList[i] as IContextProperty;
					if (contextProperty == null)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_Activation_BadAttribute"));
					}
					RuntimeAssembly asm = (RuntimeAssembly)contextProperty.GetType().Assembly;
					ActivationServices.CheckForInfrastructurePermission(asm);
					if (context.GetProperty(contextProperty.Name) == null)
					{
						context.SetProperty(contextProperty);
					}
				}
				context.Freeze();
				for (int j = 0; j < arrayList.Count; j++)
				{
					if (!((IContextProperty)arrayList[j]).IsNewContextOK(context))
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_Activation_PropertyUnhappy"));
					}
				}
			}
			InternalCrossContextDelegate internalCrossContextDelegate = new InternalCrossContextDelegate(ActivationServices.DoCrossContextActivationCallback);
			object[] args = new object[]
			{
				reqMsg
			};
			IConstructionReturnMessage result;
			if (isContextful)
			{
				result = (Thread.CurrentThread.InternalCrossContextCallback(context, internalCrossContextDelegate, args) as IConstructionReturnMessage);
			}
			else
			{
				result = (internalCrossContextDelegate(args) as IConstructionReturnMessage);
			}
			return result;
		}

		// Token: 0x06005CEE RID: 23790 RVA: 0x00145F34 File Offset: 0x00144134
		[SecurityCritical]
		internal static object DoCrossContextActivationCallback(object[] args)
		{
			IConstructionCallMessage constructionCallMessage = (IConstructionCallMessage)args[0];
			IMethodReturnMessage methodReturnMessage = (IMethodReturnMessage)Thread.CurrentContext.GetServerContextChain().SyncProcessMessage(constructionCallMessage);
			IConstructionReturnMessage constructionReturnMessage = methodReturnMessage as IConstructionReturnMessage;
			if (constructionReturnMessage == null)
			{
				Exception e;
				if (methodReturnMessage != null)
				{
					e = methodReturnMessage.Exception;
				}
				else
				{
					e = new RemotingException(Environment.GetResourceString("Remoting_Activation_Failed"));
				}
				constructionReturnMessage = new ConstructorReturnMessage(e, null);
				((ConstructorReturnMessage)constructionReturnMessage).SetLogicalCallContext((LogicalCallContext)constructionCallMessage.Properties[Message.CallContextKey]);
			}
			return constructionReturnMessage;
		}

		// Token: 0x06005CEF RID: 23791 RVA: 0x00145FB4 File Offset: 0x001441B4
		[SecurityCritical]
		internal static IConstructionReturnMessage DoServerContextActivation(IConstructionCallMessage reqMsg)
		{
			Exception e = null;
			Type activationType = reqMsg.ActivationType;
			object serverObj = ActivationServices.ActivateWithMessage(activationType, reqMsg, null, out e);
			return ActivationServices.SetupConstructionReply(serverObj, reqMsg, e);
		}

		// Token: 0x06005CF0 RID: 23792 RVA: 0x00145FE0 File Offset: 0x001441E0
		[SecurityCritical]
		internal static IConstructionReturnMessage SetupConstructionReply(object serverObj, IConstructionCallMessage ctorMsg, Exception e)
		{
			IConstructionReturnMessage constructionReturnMessage;
			if (e == null)
			{
				constructionReturnMessage = new ConstructorReturnMessage((MarshalByRefObject)serverObj, null, 0, (LogicalCallContext)ctorMsg.Properties[Message.CallContextKey], ctorMsg);
			}
			else
			{
				constructionReturnMessage = new ConstructorReturnMessage(e, null);
				((ConstructorReturnMessage)constructionReturnMessage).SetLogicalCallContext((LogicalCallContext)ctorMsg.Properties[Message.CallContextKey]);
			}
			return constructionReturnMessage;
		}

		// Token: 0x06005CF1 RID: 23793 RVA: 0x00146044 File Offset: 0x00144244
		[SecurityCritical]
		internal static object ActivateWithMessage(Type serverType, IMessage msg, ServerIdentity srvIdToBind, out Exception e)
		{
			e = null;
			object obj = RemotingServices.AllocateUninitializedObject(serverType);
			object obj2;
			if (serverType.IsContextful)
			{
				if (msg is ConstructorCallMessage)
				{
					obj2 = ((ConstructorCallMessage)msg).GetThisPtr();
				}
				else
				{
					obj2 = null;
				}
				obj2 = RemotingServices.Wrap((ContextBoundObject)obj, obj2, false);
			}
			else
			{
				if (Thread.CurrentContext != Context.DefaultContext)
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_Activation_Failed"));
				}
				obj2 = obj;
			}
			IMessageSink messageSink = new StackBuilderSink(obj2);
			IMethodReturnMessage methodReturnMessage = (IMethodReturnMessage)messageSink.SyncProcessMessage(msg);
			if (methodReturnMessage.Exception != null)
			{
				e = methodReturnMessage.Exception;
				return null;
			}
			if (serverType.IsContextful)
			{
				return RemotingServices.Wrap((ContextBoundObject)obj);
			}
			return obj;
		}

		// Token: 0x06005CF2 RID: 23794 RVA: 0x001460E8 File Offset: 0x001442E8
		[SecurityCritical]
		internal static void StartListeningForRemoteRequests()
		{
			ActivationServices.Startup();
			DomainSpecificRemotingData remotingData = Thread.GetDomain().RemotingData;
			if (!remotingData.ActivatorListening)
			{
				object configLock = remotingData.ConfigLock;
				bool flag = false;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					Monitor.Enter(configLock, ref flag);
					if (!remotingData.ActivatorListening)
					{
						RemotingServices.MarshalInternal(Thread.GetDomain().RemotingData.ActivationListener, "RemoteActivationService.rem", typeof(IActivator));
						ServerIdentity serverIdentity = (ServerIdentity)IdentityHolder.ResolveIdentity("RemoteActivationService.rem");
						serverIdentity.SetSingletonObjectMode();
						remotingData.ActivatorListening = true;
					}
				}
				finally
				{
					if (flag)
					{
						Monitor.Exit(configLock);
					}
				}
			}
		}

		// Token: 0x06005CF3 RID: 23795 RVA: 0x00146188 File Offset: 0x00144388
		[SecurityCritical]
		internal static IActivator GetActivator()
		{
			DomainSpecificRemotingData remotingData = Thread.GetDomain().RemotingData;
			if (remotingData.LocalActivator == null)
			{
				ActivationServices.Startup();
			}
			return remotingData.LocalActivator;
		}

		// Token: 0x06005CF4 RID: 23796 RVA: 0x001461B3 File Offset: 0x001443B3
		[SecurityCritical]
		internal static void Initialize()
		{
			ActivationServices.GetActivator();
		}

		// Token: 0x06005CF5 RID: 23797 RVA: 0x001461BC File Offset: 0x001443BC
		[SecurityCritical]
		internal static ContextAttribute GetGlobalAttribute()
		{
			DomainSpecificRemotingData remotingData = Thread.GetDomain().RemotingData;
			if (remotingData.LocalActivator == null)
			{
				ActivationServices.Startup();
			}
			return remotingData.LocalActivator;
		}

		// Token: 0x06005CF6 RID: 23798 RVA: 0x001461E8 File Offset: 0x001443E8
		[SecurityCritical]
		internal static IContextAttribute[] GetContextAttributesForType(Type serverType)
		{
			if (!typeof(ContextBoundObject).IsAssignableFrom(serverType) || serverType.IsCOMObject)
			{
				return new ContextAttribute[0];
			}
			int num = 8;
			IContextAttribute[] array = new IContextAttribute[num];
			int num2 = 0;
			object[] customAttributes = serverType.GetCustomAttributes(typeof(IContextAttribute), true);
			foreach (IContextAttribute contextAttribute in customAttributes)
			{
				Type type = contextAttribute.GetType();
				bool flag = false;
				for (int j = 0; j < num2; j++)
				{
					if (type.Equals(array[j].GetType()))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					num2++;
					if (num2 > num - 1)
					{
						IContextAttribute[] array3 = new IContextAttribute[2 * num];
						Array.Copy(array, 0, array3, 0, num);
						array = array3;
						num *= 2;
					}
					array[num2 - 1] = contextAttribute;
				}
			}
			IContextAttribute[] array4 = new IContextAttribute[num2];
			Array.Copy(array, array4, num2);
			return array4;
		}

		// Token: 0x06005CF7 RID: 23799 RVA: 0x001462E0 File Offset: 0x001444E0
		[SecurityCritical]
		internal static object ConnectIfNecessary(IConstructionCallMessage ctorMsg)
		{
			string text = (string)ctorMsg.Properties["Connect"];
			object result = null;
			if (text != null)
			{
				result = RemotingServices.Connect(ctorMsg.ActivationType, text);
			}
			return result;
		}

		// Token: 0x06005CF8 RID: 23800 RVA: 0x00146318 File Offset: 0x00144518
		[SecurityCritical]
		internal static object CheckIfConnected(RemotingProxy proxy, IConstructionCallMessage ctorMsg)
		{
			string text = (string)ctorMsg.Properties["Connect"];
			object result = null;
			if (text != null)
			{
				result = proxy.GetTransparentProxy();
			}
			return result;
		}

		// Token: 0x06005CF9 RID: 23801 RVA: 0x00146348 File Offset: 0x00144548
		internal static void PushActivationAttributes(Type serverType, object[] attributes)
		{
			if (ActivationServices._attributeStack == null)
			{
				ActivationServices._attributeStack = new ActivationAttributeStack();
			}
			ActivationServices._attributeStack.Push(serverType, attributes);
		}

		// Token: 0x06005CFA RID: 23802 RVA: 0x00146367 File Offset: 0x00144567
		internal static object[] PeekActivationAttributes(Type serverType)
		{
			if (ActivationServices._attributeStack == null)
			{
				return null;
			}
			return ActivationServices._attributeStack.Peek(serverType);
		}

		// Token: 0x06005CFB RID: 23803 RVA: 0x0014637D File Offset: 0x0014457D
		internal static void PopActivationAttributes(Type serverType)
		{
			ActivationServices._attributeStack.Pop(serverType);
		}

		// Token: 0x040029DD RID: 10717
		private static volatile IActivator activator = null;

		// Token: 0x040029DE RID: 10718
		private static Hashtable _proxyTable = new Hashtable();

		// Token: 0x040029DF RID: 10719
		private static readonly Type proxyAttributeType = typeof(ProxyAttribute);

		// Token: 0x040029E0 RID: 10720
		[SecurityCritical]
		private static ProxyAttribute _proxyAttribute = new ProxyAttribute();

		// Token: 0x040029E1 RID: 10721
		[ThreadStatic]
		internal static ActivationAttributeStack _attributeStack;

		// Token: 0x040029E2 RID: 10722
		internal static readonly Assembly s_MscorlibAssembly = typeof(object).Assembly;

		// Token: 0x040029E3 RID: 10723
		internal const string ActivationServiceURI = "RemoteActivationService.rem";

		// Token: 0x040029E4 RID: 10724
		internal const string RemoteActivateKey = "Remote";

		// Token: 0x040029E5 RID: 10725
		internal const string PermissionKey = "Permission";

		// Token: 0x040029E6 RID: 10726
		internal const string ConnectKey = "Connect";
	}
}
