using System;
using System.Security;

namespace System.Runtime.Serialization
{
	// Token: 0x0200072F RID: 1839
	internal sealed class SurrogateForCyclicalReference : ISerializationSurrogate
	{
		// Token: 0x0600519D RID: 20893 RVA: 0x0011FC4E File Offset: 0x0011DE4E
		internal SurrogateForCyclicalReference(ISerializationSurrogate innerSurrogate)
		{
			if (innerSurrogate == null)
			{
				throw new ArgumentNullException("innerSurrogate");
			}
			this.innerSurrogate = innerSurrogate;
		}

		// Token: 0x0600519E RID: 20894 RVA: 0x0011FC6B File Offset: 0x0011DE6B
		[SecurityCritical]
		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			this.innerSurrogate.GetObjectData(obj, info, context);
		}

		// Token: 0x0600519F RID: 20895 RVA: 0x0011FC7B File Offset: 0x0011DE7B
		[SecurityCritical]
		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			return this.innerSurrogate.SetObjectData(obj, info, context, selector);
		}

		// Token: 0x04002438 RID: 9272
		private ISerializationSurrogate innerSurrogate;
	}
}
