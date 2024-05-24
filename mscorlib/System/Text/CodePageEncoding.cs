using System;
using System.Runtime.Serialization;
using System.Security;

namespace System.Text
{
	// Token: 0x02000A5B RID: 2651
	[Serializable]
	internal sealed class CodePageEncoding : ISerializable, IObjectReference
	{
		// Token: 0x06006758 RID: 26456 RVA: 0x0015D138 File Offset: 0x0015B338
		internal CodePageEncoding(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			this.m_codePage = (int)info.GetValue("m_codePage", typeof(int));
			try
			{
				this.m_isReadOnly = (bool)info.GetValue("m_isReadOnly", typeof(bool));
				this.encoderFallback = (EncoderFallback)info.GetValue("encoderFallback", typeof(EncoderFallback));
				this.decoderFallback = (DecoderFallback)info.GetValue("decoderFallback", typeof(DecoderFallback));
			}
			catch (SerializationException)
			{
				this.m_deserializedFromEverett = true;
				this.m_isReadOnly = true;
			}
		}

		// Token: 0x06006759 RID: 26457 RVA: 0x0015D1FC File Offset: 0x0015B3FC
		[SecurityCritical]
		public object GetRealObject(StreamingContext context)
		{
			this.realEncoding = Encoding.GetEncoding(this.m_codePage);
			if (!this.m_deserializedFromEverett && !this.m_isReadOnly)
			{
				this.realEncoding = (Encoding)this.realEncoding.Clone();
				this.realEncoding.EncoderFallback = this.encoderFallback;
				this.realEncoding.DecoderFallback = this.decoderFallback;
			}
			return this.realEncoding;
		}

		// Token: 0x0600675A RID: 26458 RVA: 0x0015D268 File Offset: 0x0015B468
		[SecurityCritical]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new ArgumentException(Environment.GetResourceString("Arg_ExecutionEngineException"));
		}

		// Token: 0x04002E2D RID: 11821
		[NonSerialized]
		private int m_codePage;

		// Token: 0x04002E2E RID: 11822
		[NonSerialized]
		private bool m_isReadOnly;

		// Token: 0x04002E2F RID: 11823
		[NonSerialized]
		private bool m_deserializedFromEverett;

		// Token: 0x04002E30 RID: 11824
		[NonSerialized]
		private EncoderFallback encoderFallback;

		// Token: 0x04002E31 RID: 11825
		[NonSerialized]
		private DecoderFallback decoderFallback;

		// Token: 0x04002E32 RID: 11826
		[NonSerialized]
		private Encoding realEncoding;

		// Token: 0x02000CAD RID: 3245
		[Serializable]
		internal sealed class Decoder : ISerializable, IObjectReference
		{
			// Token: 0x06007150 RID: 29008 RVA: 0x00185EC7 File Offset: 0x001840C7
			internal Decoder(SerializationInfo info, StreamingContext context)
			{
				if (info == null)
				{
					throw new ArgumentNullException("info");
				}
				this.realEncoding = (Encoding)info.GetValue("encoding", typeof(Encoding));
			}

			// Token: 0x06007151 RID: 29009 RVA: 0x00185EFD File Offset: 0x001840FD
			[SecurityCritical]
			public object GetRealObject(StreamingContext context)
			{
				return this.realEncoding.GetDecoder();
			}

			// Token: 0x06007152 RID: 29010 RVA: 0x00185F0A File Offset: 0x0018410A
			[SecurityCritical]
			void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_ExecutionEngineException"));
			}

			// Token: 0x0400389C RID: 14492
			[NonSerialized]
			private Encoding realEncoding;
		}
	}
}
