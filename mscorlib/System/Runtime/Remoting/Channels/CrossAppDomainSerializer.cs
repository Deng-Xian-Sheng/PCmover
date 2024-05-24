using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000839 RID: 2105
	internal static class CrossAppDomainSerializer
	{
		// Token: 0x060059EE RID: 23022 RVA: 0x0013D260 File Offset: 0x0013B460
		[SecurityCritical]
		internal static MemoryStream SerializeMessage(IMessage msg)
		{
			MemoryStream memoryStream = new MemoryStream();
			RemotingSurrogateSelector surrogateSelector = new RemotingSurrogateSelector();
			new BinaryFormatter
			{
				SurrogateSelector = surrogateSelector,
				Context = new StreamingContext(StreamingContextStates.CrossAppDomain)
			}.Serialize(memoryStream, msg, null, false);
			memoryStream.Position = 0L;
			return memoryStream;
		}

		// Token: 0x060059EF RID: 23023 RVA: 0x0013D2AC File Offset: 0x0013B4AC
		[SecurityCritical]
		internal static MemoryStream SerializeMessageParts(ArrayList argsToSerialize)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			RemotingSurrogateSelector surrogateSelector = new RemotingSurrogateSelector();
			binaryFormatter.SurrogateSelector = surrogateSelector;
			binaryFormatter.Context = new StreamingContext(StreamingContextStates.CrossAppDomain);
			binaryFormatter.Serialize(memoryStream, argsToSerialize, null, false);
			memoryStream.Position = 0L;
			return memoryStream;
		}

		// Token: 0x060059F0 RID: 23024 RVA: 0x0013D2F8 File Offset: 0x0013B4F8
		[SecurityCritical]
		internal static void SerializeObject(object obj, MemoryStream stm)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			RemotingSurrogateSelector surrogateSelector = new RemotingSurrogateSelector();
			binaryFormatter.SurrogateSelector = surrogateSelector;
			binaryFormatter.Context = new StreamingContext(StreamingContextStates.CrossAppDomain);
			binaryFormatter.Serialize(stm, obj, null, false);
		}

		// Token: 0x060059F1 RID: 23025 RVA: 0x0013D334 File Offset: 0x0013B534
		[SecurityCritical]
		internal static MemoryStream SerializeObject(object obj)
		{
			MemoryStream memoryStream = new MemoryStream();
			CrossAppDomainSerializer.SerializeObject(obj, memoryStream);
			memoryStream.Position = 0L;
			return memoryStream;
		}

		// Token: 0x060059F2 RID: 23026 RVA: 0x0013D357 File Offset: 0x0013B557
		[SecurityCritical]
		internal static IMessage DeserializeMessage(MemoryStream stm)
		{
			return CrossAppDomainSerializer.DeserializeMessage(stm, null);
		}

		// Token: 0x060059F3 RID: 23027 RVA: 0x0013D360 File Offset: 0x0013B560
		[SecurityCritical]
		internal static IMessage DeserializeMessage(MemoryStream stm, IMethodCallMessage reqMsg)
		{
			if (stm == null)
			{
				throw new ArgumentNullException("stm");
			}
			stm.Position = 0L;
			return (IMessage)new BinaryFormatter
			{
				SurrogateSelector = null,
				Context = new StreamingContext(StreamingContextStates.CrossAppDomain)
			}.Deserialize(stm, null, false, true, reqMsg);
		}

		// Token: 0x060059F4 RID: 23028 RVA: 0x0013D3B0 File Offset: 0x0013B5B0
		[SecurityCritical]
		internal static ArrayList DeserializeMessageParts(MemoryStream stm)
		{
			return (ArrayList)CrossAppDomainSerializer.DeserializeObject(stm);
		}

		// Token: 0x060059F5 RID: 23029 RVA: 0x0013D3C0 File Offset: 0x0013B5C0
		[SecurityCritical]
		internal static object DeserializeObject(MemoryStream stm)
		{
			stm.Position = 0L;
			return new BinaryFormatter
			{
				Context = new StreamingContext(StreamingContextStates.CrossAppDomain)
			}.Deserialize(stm, null, false, true, null);
		}
	}
}
