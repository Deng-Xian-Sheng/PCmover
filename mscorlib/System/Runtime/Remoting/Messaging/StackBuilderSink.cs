﻿using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Metadata;
using System.Security;
using System.Security.Principal;
using System.Threading;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200087F RID: 2175
	[Serializable]
	internal class StackBuilderSink : IMessageSink
	{
		// Token: 0x06005C63 RID: 23651 RVA: 0x00143F70 File Offset: 0x00142170
		public StackBuilderSink(MarshalByRefObject server)
		{
			this._server = server;
		}

		// Token: 0x06005C64 RID: 23652 RVA: 0x00143F7F File Offset: 0x0014217F
		public StackBuilderSink(object server)
		{
			this._server = server;
			if (this._server == null)
			{
				this._bStatic = true;
			}
		}

		// Token: 0x06005C65 RID: 23653 RVA: 0x00143FA0 File Offset: 0x001421A0
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage msg)
		{
			IMessage message = InternalSink.ValidateMessage(msg);
			if (message != null)
			{
				return message;
			}
			IMethodCallMessage methodCallMessage = msg as IMethodCallMessage;
			LogicalCallContext logicalCallContext = null;
			LogicalCallContext logicalCallContext2 = Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext;
			object data = logicalCallContext2.GetData("__xADCall");
			bool flag = false;
			IMessage message2;
			try
			{
				object server = this._server;
				StackBuilderSink.VerifyIsOkToCallMethod(server, methodCallMessage);
				LogicalCallContext logicalCallContext3;
				if (methodCallMessage != null)
				{
					logicalCallContext3 = methodCallMessage.LogicalCallContext;
				}
				else
				{
					logicalCallContext3 = (LogicalCallContext)msg.Properties["__CallContext"];
				}
				logicalCallContext = CallContext.SetLogicalCallContext(logicalCallContext3);
				flag = true;
				logicalCallContext3.PropagateIncomingHeadersToCallContext(msg);
				StackBuilderSink.PreserveThreadPrincipalIfNecessary(logicalCallContext3, logicalCallContext);
				if (this.IsOKToStackBlt(methodCallMessage, server) && ((Message)methodCallMessage).Dispatch(server))
				{
					message2 = new StackBasedReturnMessage();
					((StackBasedReturnMessage)message2).InitFields((Message)methodCallMessage);
					LogicalCallContext logicalCallContext4 = Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext;
					logicalCallContext4.PropagateOutgoingHeadersToMessage(message2);
					((StackBasedReturnMessage)message2).SetLogicalCallContext(logicalCallContext4);
				}
				else
				{
					MethodBase methodBase = StackBuilderSink.GetMethodBase(methodCallMessage);
					object[] array = null;
					RemotingMethodCachedData reflectionCachedData = InternalRemotingServices.GetReflectionCachedData(methodBase);
					object[] args = Message.CoerceArgs(methodCallMessage, reflectionCachedData.Parameters);
					object ret = this.PrivateProcessMessage(methodBase.MethodHandle, args, server, out array);
					this.CopyNonByrefOutArgsFromOriginalArgs(reflectionCachedData, args, ref array);
					LogicalCallContext logicalCallContext5 = Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext;
					if (data != null && (bool)data && logicalCallContext5 != null)
					{
						logicalCallContext5.RemovePrincipalIfNotSerializable();
					}
					message2 = new ReturnMessage(ret, array, (array == null) ? 0 : array.Length, logicalCallContext5, methodCallMessage);
					logicalCallContext5.PropagateOutgoingHeadersToMessage(message2);
					CallContext.SetLogicalCallContext(logicalCallContext);
				}
			}
			catch (Exception e)
			{
				message2 = new ReturnMessage(e, methodCallMessage);
				((ReturnMessage)message2).SetLogicalCallContext(methodCallMessage.LogicalCallContext);
				if (flag)
				{
					CallContext.SetLogicalCallContext(logicalCallContext);
				}
			}
			return message2;
		}

		// Token: 0x06005C66 RID: 23654 RVA: 0x00144174 File Offset: 0x00142374
		[SecurityCritical]
		public virtual IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
		{
			IMethodCallMessage methodCallMessage = (IMethodCallMessage)msg;
			IMessageCtrl result = null;
			IMessage message = null;
			LogicalCallContext logicalCallContext = null;
			bool flag = false;
			try
			{
				try
				{
					LogicalCallContext logicalCallContext2 = (LogicalCallContext)methodCallMessage.Properties[Message.CallContextKey];
					object server = this._server;
					StackBuilderSink.VerifyIsOkToCallMethod(server, methodCallMessage);
					logicalCallContext = CallContext.SetLogicalCallContext(logicalCallContext2);
					flag = true;
					logicalCallContext2.PropagateIncomingHeadersToCallContext(msg);
					StackBuilderSink.PreserveThreadPrincipalIfNecessary(logicalCallContext2, logicalCallContext);
					ServerChannelSinkStack serverChannelSinkStack = msg.Properties["__SinkStack"] as ServerChannelSinkStack;
					if (serverChannelSinkStack != null)
					{
						serverChannelSinkStack.ServerObject = server;
					}
					MethodBase methodBase = StackBuilderSink.GetMethodBase(methodCallMessage);
					object[] array = null;
					RemotingMethodCachedData reflectionCachedData = InternalRemotingServices.GetReflectionCachedData(methodBase);
					object[] args = Message.CoerceArgs(methodCallMessage, reflectionCachedData.Parameters);
					object ret = this.PrivateProcessMessage(methodBase.MethodHandle, args, server, out array);
					this.CopyNonByrefOutArgsFromOriginalArgs(reflectionCachedData, args, ref array);
					if (replySink != null)
					{
						LogicalCallContext logicalCallContext3 = Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext;
						if (logicalCallContext3 != null)
						{
							logicalCallContext3.RemovePrincipalIfNotSerializable();
						}
						message = new ReturnMessage(ret, array, (array == null) ? 0 : array.Length, logicalCallContext3, methodCallMessage);
						logicalCallContext3.PropagateOutgoingHeadersToMessage(message);
					}
				}
				catch (Exception e)
				{
					if (replySink != null)
					{
						message = new ReturnMessage(e, methodCallMessage);
						((ReturnMessage)message).SetLogicalCallContext((LogicalCallContext)methodCallMessage.Properties[Message.CallContextKey]);
					}
				}
				finally
				{
					if (replySink != null)
					{
						replySink.SyncProcessMessage(message);
					}
				}
			}
			finally
			{
				if (flag)
				{
					CallContext.SetLogicalCallContext(logicalCallContext);
				}
			}
			return result;
		}

		// Token: 0x17000FDF RID: 4063
		// (get) Token: 0x06005C67 RID: 23655 RVA: 0x00144318 File Offset: 0x00142518
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x06005C68 RID: 23656 RVA: 0x0014431C File Offset: 0x0014251C
		[SecurityCritical]
		internal bool IsOKToStackBlt(IMethodMessage mcMsg, object server)
		{
			bool result = false;
			Message message = mcMsg as Message;
			if (message != null)
			{
				IInternalMessage internalMessage = message;
				if (message.GetFramePtr() != IntPtr.Zero && message.GetThisPtr() == server && (internalMessage.IdentityObject == null || (internalMessage.IdentityObject != null && internalMessage.IdentityObject == internalMessage.ServerIdentityObject)))
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06005C69 RID: 23657 RVA: 0x00144374 File Offset: 0x00142574
		[SecurityCritical]
		private static MethodBase GetMethodBase(IMethodMessage msg)
		{
			MethodBase methodBase = msg.MethodBase;
			if (null == methodBase)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Message_MethodMissing"), msg.MethodName, msg.TypeName));
			}
			return methodBase;
		}

		// Token: 0x06005C6A RID: 23658 RVA: 0x001443B8 File Offset: 0x001425B8
		[SecurityCritical]
		private static void VerifyIsOkToCallMethod(object server, IMethodMessage msg)
		{
			bool flag = false;
			MarshalByRefObject marshalByRefObject = server as MarshalByRefObject;
			if (marshalByRefObject != null)
			{
				bool flag2;
				Identity identity = MarshalByRefObject.GetIdentity(marshalByRefObject, out flag2);
				if (identity != null)
				{
					ServerIdentity serverIdentity = identity as ServerIdentity;
					if (serverIdentity != null && serverIdentity.MarshaledAsSpecificType)
					{
						Type serverType = serverIdentity.ServerType;
						if (serverType != null)
						{
							MethodBase methodBase = StackBuilderSink.GetMethodBase(msg);
							RuntimeType runtimeType = (RuntimeType)methodBase.DeclaringType;
							if (runtimeType != serverType && !runtimeType.IsAssignableFrom(serverType))
							{
								throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_InvalidCallingType"), methodBase.DeclaringType.FullName, serverType.FullName));
							}
							if (runtimeType.IsInterface)
							{
								StackBuilderSink.VerifyNotIRemoteDispatch(runtimeType);
							}
							flag = true;
						}
					}
				}
				if (!flag)
				{
					MethodBase methodBase2 = StackBuilderSink.GetMethodBase(msg);
					RuntimeType runtimeType2 = (RuntimeType)methodBase2.ReflectedType;
					if (!runtimeType2.IsInterface)
					{
						if (!runtimeType2.IsInstanceOfType(marshalByRefObject))
						{
							throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_InvalidCallingType"), runtimeType2.FullName, marshalByRefObject.GetType().FullName));
						}
					}
					else
					{
						StackBuilderSink.VerifyNotIRemoteDispatch(runtimeType2);
					}
				}
			}
		}

		// Token: 0x06005C6B RID: 23659 RVA: 0x001444D8 File Offset: 0x001426D8
		[SecurityCritical]
		private static void VerifyNotIRemoteDispatch(RuntimeType reflectedType)
		{
			if (reflectedType.FullName.Equals(StackBuilderSink.sIRemoteDispatch) && reflectedType.GetRuntimeAssembly().GetSimpleName().Equals(StackBuilderSink.sIRemoteDispatchAssembly))
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_CantInvokeIRemoteDispatch"));
			}
		}

		// Token: 0x06005C6C RID: 23660 RVA: 0x00144514 File Offset: 0x00142714
		internal void CopyNonByrefOutArgsFromOriginalArgs(RemotingMethodCachedData methodCache, object[] args, ref object[] marshalResponseArgs)
		{
			int[] nonRefOutArgMap = methodCache.NonRefOutArgMap;
			if (nonRefOutArgMap.Length != 0)
			{
				if (marshalResponseArgs == null)
				{
					marshalResponseArgs = new object[methodCache.Parameters.Length];
				}
				foreach (int num in nonRefOutArgMap)
				{
					marshalResponseArgs[num] = args[num];
				}
			}
		}

		// Token: 0x06005C6D RID: 23661 RVA: 0x0014455C File Offset: 0x0014275C
		[SecurityCritical]
		internal static void PreserveThreadPrincipalIfNecessary(LogicalCallContext messageCallContext, LogicalCallContext threadCallContext)
		{
			if (threadCallContext != null && messageCallContext.Principal == null)
			{
				IPrincipal principal = threadCallContext.Principal;
				if (principal != null)
				{
					messageCallContext.Principal = principal;
				}
			}
		}

		// Token: 0x17000FE0 RID: 4064
		// (get) Token: 0x06005C6E RID: 23662 RVA: 0x00144585 File Offset: 0x00142785
		internal object ServerObject
		{
			get
			{
				return this._server;
			}
		}

		// Token: 0x06005C6F RID: 23663
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern object _PrivateProcessMessage(IntPtr md, object[] args, object server, out object[] outArgs);

		// Token: 0x06005C70 RID: 23664 RVA: 0x0014458D File Offset: 0x0014278D
		[SecurityCritical]
		public object PrivateProcessMessage(RuntimeMethodHandle md, object[] args, object server, out object[] outArgs)
		{
			return this._PrivateProcessMessage(md.Value, args, server, out outArgs);
		}

		// Token: 0x040029BC RID: 10684
		private object _server;

		// Token: 0x040029BD RID: 10685
		private static string sIRemoteDispatch = "System.EnterpriseServices.IRemoteDispatch";

		// Token: 0x040029BE RID: 10686
		private static string sIRemoteDispatchAssembly = "System.EnterpriseServices";

		// Token: 0x040029BF RID: 10687
		private bool _bStatic;
	}
}
