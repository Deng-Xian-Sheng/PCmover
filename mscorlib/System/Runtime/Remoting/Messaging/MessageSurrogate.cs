using System;
using System.Collections;
using System.Runtime.Remoting.Activation;
using System.Runtime.Serialization;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200087E RID: 2174
	internal class MessageSurrogate : ISerializationSurrogate
	{
		// Token: 0x06005C60 RID: 23648 RVA: 0x00143D63 File Offset: 0x00141F63
		[SecurityCritical]
		internal MessageSurrogate(RemotingSurrogateSelector ss)
		{
			this._ss = ss;
		}

		// Token: 0x06005C61 RID: 23649 RVA: 0x00143D74 File Offset: 0x00141F74
		[SecurityCritical]
		public virtual void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			bool flag = false;
			bool flag2 = false;
			IMethodMessage methodMessage = obj as IMethodMessage;
			if (methodMessage != null)
			{
				IDictionaryEnumerator enumerator = methodMessage.Properties.GetEnumerator();
				if (methodMessage is IMethodCallMessage)
				{
					if (obj is IConstructionCallMessage)
					{
						flag2 = true;
					}
					info.SetType(flag2 ? MessageSurrogate._constructionCallType : MessageSurrogate._methodCallType);
				}
				else
				{
					IMethodReturnMessage methodReturnMessage = methodMessage as IMethodReturnMessage;
					if (methodReturnMessage == null)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_InvalidMsg"));
					}
					flag = true;
					info.SetType((obj is IConstructionReturnMessage) ? MessageSurrogate._constructionResponseType : MessageSurrogate._methodResponseType);
					if (((IMethodReturnMessage)methodMessage).Exception != null)
					{
						info.AddValue("__fault", ((IMethodReturnMessage)methodMessage).Exception, MessageSurrogate._exceptionType);
					}
				}
				while (enumerator.MoveNext())
				{
					if (obj != this._ss.GetRootObject() || this._ss.Filter == null || !this._ss.Filter((string)enumerator.Key, enumerator.Value))
					{
						if (enumerator.Value != null)
						{
							string text = enumerator.Key.ToString();
							if (text.Equals("__CallContext"))
							{
								LogicalCallContext logicalCallContext = (LogicalCallContext)enumerator.Value;
								if (logicalCallContext.HasInfo)
								{
									info.AddValue(text, logicalCallContext);
								}
								else
								{
									info.AddValue(text, logicalCallContext.RemotingData.LogicalCallID);
								}
							}
							else if (text.Equals("__MethodSignature"))
							{
								if (flag2 || RemotingServices.IsMethodOverloaded(methodMessage))
								{
									info.AddValue(text, enumerator.Value);
								}
							}
							else
							{
								flag = flag;
								info.AddValue(text, enumerator.Value);
							}
						}
						else
						{
							info.AddValue(enumerator.Key.ToString(), enumerator.Value, MessageSurrogate._objectType);
						}
					}
				}
				return;
			}
			throw new RemotingException(Environment.GetResourceString("Remoting_InvalidMsg"));
		}

		// Token: 0x06005C62 RID: 23650 RVA: 0x00143F5F File Offset: 0x0014215F
		[SecurityCritical]
		public virtual object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_PopulateData"));
		}

		// Token: 0x040029B5 RID: 10677
		private static Type _constructionCallType = typeof(ConstructionCall);

		// Token: 0x040029B6 RID: 10678
		private static Type _methodCallType = typeof(MethodCall);

		// Token: 0x040029B7 RID: 10679
		private static Type _constructionResponseType = typeof(ConstructionResponse);

		// Token: 0x040029B8 RID: 10680
		private static Type _methodResponseType = typeof(MethodResponse);

		// Token: 0x040029B9 RID: 10681
		private static Type _exceptionType = typeof(Exception);

		// Token: 0x040029BA RID: 10682
		private static Type _objectType = typeof(object);

		// Token: 0x040029BB RID: 10683
		[SecurityCritical]
		private RemotingSurrogateSelector _ss;
	}
}
