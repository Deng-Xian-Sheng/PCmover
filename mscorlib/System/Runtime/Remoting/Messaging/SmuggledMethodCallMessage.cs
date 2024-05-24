using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000876 RID: 2166
	internal class SmuggledMethodCallMessage : MessageSmuggler
	{
		// Token: 0x06005C2C RID: 23596 RVA: 0x0014319C File Offset: 0x0014139C
		[SecurityCritical]
		internal static SmuggledMethodCallMessage SmuggleIfPossible(IMessage msg)
		{
			IMethodCallMessage methodCallMessage = msg as IMethodCallMessage;
			if (methodCallMessage == null)
			{
				return null;
			}
			return new SmuggledMethodCallMessage(methodCallMessage);
		}

		// Token: 0x06005C2D RID: 23597 RVA: 0x001431BB File Offset: 0x001413BB
		private SmuggledMethodCallMessage()
		{
		}

		// Token: 0x06005C2E RID: 23598 RVA: 0x001431C4 File Offset: 0x001413C4
		[SecurityCritical]
		private SmuggledMethodCallMessage(IMethodCallMessage mcm)
		{
			this._uri = mcm.Uri;
			this._methodName = mcm.MethodName;
			this._typeName = mcm.TypeName;
			ArrayList arrayList = null;
			IInternalMessage internalMessage = mcm as IInternalMessage;
			if (internalMessage == null || internalMessage.HasProperties())
			{
				this._propertyCount = MessageSmuggler.StoreUserPropertiesForMethodMessage(mcm, ref arrayList);
			}
			if (mcm.MethodBase.IsGenericMethod)
			{
				Type[] genericArguments = mcm.MethodBase.GetGenericArguments();
				if (genericArguments != null && genericArguments.Length != 0)
				{
					if (arrayList == null)
					{
						arrayList = new ArrayList();
					}
					this._instantiation = new MessageSmuggler.SerializedArg(arrayList.Count);
					arrayList.Add(genericArguments);
				}
			}
			if (RemotingServices.IsMethodOverloaded(mcm))
			{
				if (arrayList == null)
				{
					arrayList = new ArrayList();
				}
				this._methodSignature = new MessageSmuggler.SerializedArg(arrayList.Count);
				arrayList.Add(mcm.MethodSignature);
			}
			LogicalCallContext logicalCallContext = mcm.LogicalCallContext;
			if (logicalCallContext == null)
			{
				this._callContext = null;
			}
			else if (logicalCallContext.HasInfo)
			{
				if (arrayList == null)
				{
					arrayList = new ArrayList();
				}
				this._callContext = new MessageSmuggler.SerializedArg(arrayList.Count);
				arrayList.Add(logicalCallContext);
			}
			else
			{
				this._callContext = logicalCallContext.RemotingData.LogicalCallID;
			}
			this._args = MessageSmuggler.FixupArgs(mcm.Args, ref arrayList);
			if (arrayList != null)
			{
				MemoryStream memoryStream = CrossAppDomainSerializer.SerializeMessageParts(arrayList);
				this._serializedArgs = memoryStream.GetBuffer();
			}
		}

		// Token: 0x06005C2F RID: 23599 RVA: 0x0014330C File Offset: 0x0014150C
		[SecurityCritical]
		internal ArrayList FixupForNewAppDomain()
		{
			ArrayList result = null;
			if (this._serializedArgs != null)
			{
				result = CrossAppDomainSerializer.DeserializeMessageParts(new MemoryStream(this._serializedArgs));
				this._serializedArgs = null;
			}
			return result;
		}

		// Token: 0x17000FD9 RID: 4057
		// (get) Token: 0x06005C30 RID: 23600 RVA: 0x0014333C File Offset: 0x0014153C
		internal string Uri
		{
			get
			{
				return this._uri;
			}
		}

		// Token: 0x17000FDA RID: 4058
		// (get) Token: 0x06005C31 RID: 23601 RVA: 0x00143344 File Offset: 0x00141544
		internal string MethodName
		{
			get
			{
				return this._methodName;
			}
		}

		// Token: 0x17000FDB RID: 4059
		// (get) Token: 0x06005C32 RID: 23602 RVA: 0x0014334C File Offset: 0x0014154C
		internal string TypeName
		{
			get
			{
				return this._typeName;
			}
		}

		// Token: 0x06005C33 RID: 23603 RVA: 0x00143354 File Offset: 0x00141554
		internal Type[] GetInstantiation(ArrayList deserializedArgs)
		{
			if (this._instantiation != null)
			{
				return (Type[])deserializedArgs[this._instantiation.Index];
			}
			return null;
		}

		// Token: 0x06005C34 RID: 23604 RVA: 0x00143376 File Offset: 0x00141576
		internal object[] GetMethodSignature(ArrayList deserializedArgs)
		{
			if (this._methodSignature != null)
			{
				return (object[])deserializedArgs[this._methodSignature.Index];
			}
			return null;
		}

		// Token: 0x06005C35 RID: 23605 RVA: 0x00143398 File Offset: 0x00141598
		[SecurityCritical]
		internal object[] GetArgs(ArrayList deserializedArgs)
		{
			return MessageSmuggler.UndoFixupArgs(this._args, deserializedArgs);
		}

		// Token: 0x06005C36 RID: 23606 RVA: 0x001433A8 File Offset: 0x001415A8
		[SecurityCritical]
		internal LogicalCallContext GetCallContext(ArrayList deserializedArgs)
		{
			if (this._callContext == null)
			{
				return null;
			}
			if (this._callContext is string)
			{
				return new LogicalCallContext
				{
					RemotingData = 
					{
						LogicalCallID = (string)this._callContext
					}
				};
			}
			return (LogicalCallContext)deserializedArgs[((MessageSmuggler.SerializedArg)this._callContext).Index];
		}

		// Token: 0x17000FDC RID: 4060
		// (get) Token: 0x06005C37 RID: 23607 RVA: 0x00143405 File Offset: 0x00141605
		internal int MessagePropertyCount
		{
			get
			{
				return this._propertyCount;
			}
		}

		// Token: 0x06005C38 RID: 23608 RVA: 0x00143410 File Offset: 0x00141610
		internal void PopulateMessageProperties(IDictionary dict, ArrayList deserializedArgs)
		{
			for (int i = 0; i < this._propertyCount; i++)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)deserializedArgs[i];
				dict[dictionaryEntry.Key] = dictionaryEntry.Value;
			}
		}

		// Token: 0x04002998 RID: 10648
		private string _uri;

		// Token: 0x04002999 RID: 10649
		private string _methodName;

		// Token: 0x0400299A RID: 10650
		private string _typeName;

		// Token: 0x0400299B RID: 10651
		private object[] _args;

		// Token: 0x0400299C RID: 10652
		private byte[] _serializedArgs;

		// Token: 0x0400299D RID: 10653
		private MessageSmuggler.SerializedArg _methodSignature;

		// Token: 0x0400299E RID: 10654
		private MessageSmuggler.SerializedArg _instantiation;

		// Token: 0x0400299F RID: 10655
		private object _callContext;

		// Token: 0x040029A0 RID: 10656
		private int _propertyCount;
	}
}
