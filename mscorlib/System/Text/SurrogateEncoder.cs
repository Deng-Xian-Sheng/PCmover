using System;
using System.Runtime.Serialization;
using System.Security;

namespace System.Text
{
	// Token: 0x02000A7E RID: 2686
	[Serializable]
	internal sealed class SurrogateEncoder : ISerializable, IObjectReference
	{
		// Token: 0x060068D5 RID: 26837 RVA: 0x00163F5B File Offset: 0x0016215B
		internal SurrogateEncoder(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			this.realEncoding = (Encoding)info.GetValue("m_encoding", typeof(Encoding));
		}

		// Token: 0x060068D6 RID: 26838 RVA: 0x00163F91 File Offset: 0x00162191
		[SecurityCritical]
		public object GetRealObject(StreamingContext context)
		{
			return this.realEncoding.GetEncoder();
		}

		// Token: 0x060068D7 RID: 26839 RVA: 0x00163F9E File Offset: 0x0016219E
		[SecurityCritical]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new ArgumentException(Environment.GetResourceString("Arg_ExecutionEngineException"));
		}

		// Token: 0x04002F06 RID: 12038
		[NonSerialized]
		private Encoding realEncoding;
	}
}
