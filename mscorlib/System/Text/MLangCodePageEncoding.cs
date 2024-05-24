using System;
using System.Runtime.Serialization;
using System.Security;

namespace System.Text
{
	// Token: 0x02000A78 RID: 2680
	[Serializable]
	internal sealed class MLangCodePageEncoding : ISerializable, IObjectReference
	{
		// Token: 0x060068AD RID: 26797 RVA: 0x00162024 File Offset: 0x00160224
		internal MLangCodePageEncoding(SerializationInfo info, StreamingContext context)
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

		// Token: 0x060068AE RID: 26798 RVA: 0x001620E8 File Offset: 0x001602E8
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

		// Token: 0x060068AF RID: 26799 RVA: 0x00162154 File Offset: 0x00160354
		[SecurityCritical]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new ArgumentException(Environment.GetResourceString("Arg_ExecutionEngineException"));
		}

		// Token: 0x04002ECF RID: 11983
		[NonSerialized]
		private int m_codePage;

		// Token: 0x04002ED0 RID: 11984
		[NonSerialized]
		private bool m_isReadOnly;

		// Token: 0x04002ED1 RID: 11985
		[NonSerialized]
		private bool m_deserializedFromEverett;

		// Token: 0x04002ED2 RID: 11986
		[NonSerialized]
		private EncoderFallback encoderFallback;

		// Token: 0x04002ED3 RID: 11987
		[NonSerialized]
		private DecoderFallback decoderFallback;

		// Token: 0x04002ED4 RID: 11988
		[NonSerialized]
		private Encoding realEncoding;

		// Token: 0x02000CB4 RID: 3252
		[Serializable]
		internal sealed class MLangEncoder : ISerializable, IObjectReference
		{
			// Token: 0x06007187 RID: 29063 RVA: 0x001868D4 File Offset: 0x00184AD4
			internal MLangEncoder(SerializationInfo info, StreamingContext context)
			{
				if (info == null)
				{
					throw new ArgumentNullException("info");
				}
				this.realEncoding = (Encoding)info.GetValue("m_encoding", typeof(Encoding));
			}

			// Token: 0x06007188 RID: 29064 RVA: 0x0018690A File Offset: 0x00184B0A
			[SecurityCritical]
			public object GetRealObject(StreamingContext context)
			{
				return this.realEncoding.GetEncoder();
			}

			// Token: 0x06007189 RID: 29065 RVA: 0x00186917 File Offset: 0x00184B17
			[SecurityCritical]
			void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_ExecutionEngineException"));
			}

			// Token: 0x040038BF RID: 14527
			[NonSerialized]
			private Encoding realEncoding;
		}

		// Token: 0x02000CB5 RID: 3253
		[Serializable]
		internal sealed class MLangDecoder : ISerializable, IObjectReference
		{
			// Token: 0x0600718A RID: 29066 RVA: 0x00186928 File Offset: 0x00184B28
			internal MLangDecoder(SerializationInfo info, StreamingContext context)
			{
				if (info == null)
				{
					throw new ArgumentNullException("info");
				}
				this.realEncoding = (Encoding)info.GetValue("m_encoding", typeof(Encoding));
			}

			// Token: 0x0600718B RID: 29067 RVA: 0x0018695E File Offset: 0x00184B5E
			[SecurityCritical]
			public object GetRealObject(StreamingContext context)
			{
				return this.realEncoding.GetDecoder();
			}

			// Token: 0x0600718C RID: 29068 RVA: 0x0018696B File Offset: 0x00184B6B
			[SecurityCritical]
			void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_ExecutionEngineException"));
			}

			// Token: 0x040038C0 RID: 14528
			[NonSerialized]
			private Encoding realEncoding;
		}
	}
}
