using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000877 RID: 2167
	internal class SmuggledMethodReturnMessage : MessageSmuggler
	{
		// Token: 0x06005C39 RID: 23609 RVA: 0x00143450 File Offset: 0x00141650
		[SecurityCritical]
		internal static SmuggledMethodReturnMessage SmuggleIfPossible(IMessage msg)
		{
			IMethodReturnMessage methodReturnMessage = msg as IMethodReturnMessage;
			if (methodReturnMessage == null)
			{
				return null;
			}
			return new SmuggledMethodReturnMessage(methodReturnMessage);
		}

		// Token: 0x06005C3A RID: 23610 RVA: 0x0014346F File Offset: 0x0014166F
		private SmuggledMethodReturnMessage()
		{
		}

		// Token: 0x06005C3B RID: 23611 RVA: 0x00143478 File Offset: 0x00141678
		[SecurityCritical]
		private SmuggledMethodReturnMessage(IMethodReturnMessage mrm)
		{
			ArrayList arrayList = null;
			ReturnMessage returnMessage = mrm as ReturnMessage;
			if (returnMessage == null || returnMessage.HasProperties())
			{
				this._propertyCount = MessageSmuggler.StoreUserPropertiesForMethodMessage(mrm, ref arrayList);
			}
			Exception exception = mrm.Exception;
			if (exception != null)
			{
				if (arrayList == null)
				{
					arrayList = new ArrayList();
				}
				this._exception = new MessageSmuggler.SerializedArg(arrayList.Count);
				arrayList.Add(exception);
			}
			LogicalCallContext logicalCallContext = mrm.LogicalCallContext;
			if (logicalCallContext == null)
			{
				this._callContext = null;
			}
			else if (logicalCallContext.HasInfo)
			{
				if (logicalCallContext.Principal != null)
				{
					logicalCallContext.Principal = null;
				}
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
			this._returnValue = MessageSmuggler.FixupArg(mrm.ReturnValue, ref arrayList);
			this._args = MessageSmuggler.FixupArgs(mrm.Args, ref arrayList);
			if (arrayList != null)
			{
				MemoryStream memoryStream = CrossAppDomainSerializer.SerializeMessageParts(arrayList);
				this._serializedArgs = memoryStream.GetBuffer();
			}
		}

		// Token: 0x06005C3C RID: 23612 RVA: 0x00143578 File Offset: 0x00141778
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

		// Token: 0x06005C3D RID: 23613 RVA: 0x001435A8 File Offset: 0x001417A8
		[SecurityCritical]
		internal object GetReturnValue(ArrayList deserializedArgs)
		{
			return MessageSmuggler.UndoFixupArg(this._returnValue, deserializedArgs);
		}

		// Token: 0x06005C3E RID: 23614 RVA: 0x001435B8 File Offset: 0x001417B8
		[SecurityCritical]
		internal object[] GetArgs(ArrayList deserializedArgs)
		{
			return MessageSmuggler.UndoFixupArgs(this._args, deserializedArgs);
		}

		// Token: 0x06005C3F RID: 23615 RVA: 0x001435D3 File Offset: 0x001417D3
		internal Exception GetException(ArrayList deserializedArgs)
		{
			if (this._exception != null)
			{
				return (Exception)deserializedArgs[this._exception.Index];
			}
			return null;
		}

		// Token: 0x06005C40 RID: 23616 RVA: 0x001435F8 File Offset: 0x001417F8
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

		// Token: 0x17000FDD RID: 4061
		// (get) Token: 0x06005C41 RID: 23617 RVA: 0x00143655 File Offset: 0x00141855
		internal int MessagePropertyCount
		{
			get
			{
				return this._propertyCount;
			}
		}

		// Token: 0x06005C42 RID: 23618 RVA: 0x00143660 File Offset: 0x00141860
		internal void PopulateMessageProperties(IDictionary dict, ArrayList deserializedArgs)
		{
			for (int i = 0; i < this._propertyCount; i++)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)deserializedArgs[i];
				dict[dictionaryEntry.Key] = dictionaryEntry.Value;
			}
		}

		// Token: 0x040029A1 RID: 10657
		private object[] _args;

		// Token: 0x040029A2 RID: 10658
		private object _returnValue;

		// Token: 0x040029A3 RID: 10659
		private byte[] _serializedArgs;

		// Token: 0x040029A4 RID: 10660
		private MessageSmuggler.SerializedArg _exception;

		// Token: 0x040029A5 RID: 10661
		private object _callContext;

		// Token: 0x040029A6 RID: 10662
		private int _propertyCount;
	}
}
