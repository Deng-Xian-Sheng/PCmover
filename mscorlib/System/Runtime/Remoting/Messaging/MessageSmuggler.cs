using System;
using System.Collections;
using System.Runtime.Remoting.Proxies;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000874 RID: 2164
	internal class MessageSmuggler
	{
		// Token: 0x06005C23 RID: 23587 RVA: 0x00142E89 File Offset: 0x00141089
		private static bool CanSmuggleObjectDirectly(object obj)
		{
			return obj is string || obj.GetType() == typeof(void) || obj.GetType().IsPrimitive;
		}

		// Token: 0x06005C24 RID: 23588 RVA: 0x00142EBC File Offset: 0x001410BC
		[SecurityCritical]
		protected static object[] FixupArgs(object[] args, ref ArrayList argsToSerialize)
		{
			object[] array = new object[args.Length];
			int num = args.Length;
			for (int i = 0; i < num; i++)
			{
				array[i] = MessageSmuggler.FixupArg(args[i], ref argsToSerialize);
			}
			return array;
		}

		// Token: 0x06005C25 RID: 23589 RVA: 0x00142EF0 File Offset: 0x001410F0
		[SecurityCritical]
		protected static object FixupArg(object arg, ref ArrayList argsToSerialize)
		{
			if (arg == null)
			{
				return null;
			}
			MarshalByRefObject marshalByRefObject = arg as MarshalByRefObject;
			int count;
			if (marshalByRefObject != null)
			{
				if (!RemotingServices.IsTransparentProxy(marshalByRefObject) || RemotingServices.GetRealProxy(marshalByRefObject) is RemotingProxy)
				{
					ObjRef objRef = RemotingServices.MarshalInternal(marshalByRefObject, null, null);
					if (objRef.CanSmuggle())
					{
						if (!RemotingServices.IsTransparentProxy(marshalByRefObject))
						{
							ServerIdentity serverIdentity = (ServerIdentity)MarshalByRefObject.GetIdentity(marshalByRefObject);
							serverIdentity.SetHandle();
							objRef.SetServerIdentity(serverIdentity.GetHandle());
							objRef.SetDomainID(AppDomain.CurrentDomain.GetId());
						}
						ObjRef objRef2 = objRef.CreateSmuggleableCopy();
						objRef2.SetMarshaledObject();
						return new SmuggledObjRef(objRef2);
					}
				}
				if (argsToSerialize == null)
				{
					argsToSerialize = new ArrayList();
				}
				count = argsToSerialize.Count;
				argsToSerialize.Add(arg);
				return new MessageSmuggler.SerializedArg(count);
			}
			if (MessageSmuggler.CanSmuggleObjectDirectly(arg))
			{
				return arg;
			}
			Array array = arg as Array;
			if (array != null)
			{
				Type elementType = array.GetType().GetElementType();
				if (elementType.IsPrimitive || elementType == typeof(string))
				{
					return array.Clone();
				}
			}
			if (argsToSerialize == null)
			{
				argsToSerialize = new ArrayList();
			}
			count = argsToSerialize.Count;
			argsToSerialize.Add(arg);
			return new MessageSmuggler.SerializedArg(count);
		}

		// Token: 0x06005C26 RID: 23590 RVA: 0x00143010 File Offset: 0x00141210
		[SecurityCritical]
		protected static object[] UndoFixupArgs(object[] args, ArrayList deserializedArgs)
		{
			object[] array = new object[args.Length];
			int num = args.Length;
			for (int i = 0; i < num; i++)
			{
				array[i] = MessageSmuggler.UndoFixupArg(args[i], deserializedArgs);
			}
			return array;
		}

		// Token: 0x06005C27 RID: 23591 RVA: 0x00143044 File Offset: 0x00141244
		[SecurityCritical]
		protected static object UndoFixupArg(object arg, ArrayList deserializedArgs)
		{
			SmuggledObjRef smuggledObjRef = arg as SmuggledObjRef;
			if (smuggledObjRef != null)
			{
				return smuggledObjRef.ObjRef.GetRealObjectHelper();
			}
			MessageSmuggler.SerializedArg serializedArg = arg as MessageSmuggler.SerializedArg;
			if (serializedArg != null)
			{
				return deserializedArgs[serializedArg.Index];
			}
			return arg;
		}

		// Token: 0x06005C28 RID: 23592 RVA: 0x00143080 File Offset: 0x00141280
		[SecurityCritical]
		protected static int StoreUserPropertiesForMethodMessage(IMethodMessage msg, ref ArrayList argsToSerialize)
		{
			IDictionary properties = msg.Properties;
			MessageDictionary messageDictionary = properties as MessageDictionary;
			if (messageDictionary == null)
			{
				int num = 0;
				foreach (object obj in properties)
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					if (argsToSerialize == null)
					{
						argsToSerialize = new ArrayList();
					}
					argsToSerialize.Add(dictionaryEntry);
					num++;
				}
				return num;
			}
			if (messageDictionary.HasUserData())
			{
				int num2 = 0;
				foreach (object obj2 in messageDictionary.InternalDictionary)
				{
					DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
					if (argsToSerialize == null)
					{
						argsToSerialize = new ArrayList();
					}
					argsToSerialize.Add(dictionaryEntry2);
					num2++;
				}
				return num2;
			}
			return 0;
		}

		// Token: 0x02000C79 RID: 3193
		protected class SerializedArg
		{
			// Token: 0x060070B9 RID: 28857 RVA: 0x00184B15 File Offset: 0x00182D15
			public SerializedArg(int index)
			{
				this._index = index;
			}

			// Token: 0x17001355 RID: 4949
			// (get) Token: 0x060070BA RID: 28858 RVA: 0x00184B24 File Offset: 0x00182D24
			public int Index
			{
				get
				{
					return this._index;
				}
			}

			// Token: 0x04003805 RID: 14341
			private int _index;
		}
	}
}
