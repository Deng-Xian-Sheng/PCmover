using System;
using System.Collections.Generic;

namespace System.Runtime.Serialization
{
	// Token: 0x02000752 RID: 1874
	public sealed class SafeSerializationEventArgs : EventArgs
	{
		// Token: 0x060052C7 RID: 21191 RVA: 0x00122EE6 File Offset: 0x001210E6
		internal SafeSerializationEventArgs(StreamingContext streamingContext)
		{
			this.m_streamingContext = streamingContext;
		}

		// Token: 0x060052C8 RID: 21192 RVA: 0x00122F00 File Offset: 0x00121100
		public void AddSerializedState(ISafeSerializationData serializedState)
		{
			if (serializedState == null)
			{
				throw new ArgumentNullException("serializedState");
			}
			if (!serializedState.GetType().IsSerializable)
			{
				throw new ArgumentException(Environment.GetResourceString("Serialization_NonSerType", new object[]
				{
					serializedState.GetType(),
					serializedState.GetType().Assembly.FullName
				}));
			}
			this.m_serializedStates.Add(serializedState);
		}

		// Token: 0x17000DB1 RID: 3505
		// (get) Token: 0x060052C9 RID: 21193 RVA: 0x00122F66 File Offset: 0x00121166
		internal IList<object> SerializedStates
		{
			get
			{
				return this.m_serializedStates;
			}
		}

		// Token: 0x17000DB2 RID: 3506
		// (get) Token: 0x060052CA RID: 21194 RVA: 0x00122F6E File Offset: 0x0012116E
		public StreamingContext StreamingContext
		{
			get
			{
				return this.m_streamingContext;
			}
		}

		// Token: 0x040024AE RID: 9390
		private StreamingContext m_streamingContext;

		// Token: 0x040024AF RID: 9391
		private List<object> m_serializedStates = new List<object>();
	}
}
