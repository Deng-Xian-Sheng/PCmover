using System;
using System.Runtime.InteropServices;

namespace System.Text
{
	// Token: 0x02000A75 RID: 2677
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public abstract class EncodingProvider
	{
		// Token: 0x06006888 RID: 26760 RVA: 0x001610F6 File Offset: 0x0015F2F6
		[__DynamicallyInvokable]
		public EncodingProvider()
		{
		}

		// Token: 0x06006889 RID: 26761
		[__DynamicallyInvokable]
		public abstract Encoding GetEncoding(string name);

		// Token: 0x0600688A RID: 26762
		[__DynamicallyInvokable]
		public abstract Encoding GetEncoding(int codepage);

		// Token: 0x0600688B RID: 26763 RVA: 0x00161100 File Offset: 0x0015F300
		[__DynamicallyInvokable]
		public virtual Encoding GetEncoding(string name, EncoderFallback encoderFallback, DecoderFallback decoderFallback)
		{
			Encoding encoding = this.GetEncoding(name);
			if (encoding != null)
			{
				encoding = (Encoding)this.GetEncoding(name).Clone();
				encoding.EncoderFallback = encoderFallback;
				encoding.DecoderFallback = decoderFallback;
			}
			return encoding;
		}

		// Token: 0x0600688C RID: 26764 RVA: 0x0016113C File Offset: 0x0015F33C
		[__DynamicallyInvokable]
		public virtual Encoding GetEncoding(int codepage, EncoderFallback encoderFallback, DecoderFallback decoderFallback)
		{
			Encoding encoding = this.GetEncoding(codepage);
			if (encoding != null)
			{
				encoding = (Encoding)this.GetEncoding(codepage).Clone();
				encoding.EncoderFallback = encoderFallback;
				encoding.DecoderFallback = decoderFallback;
			}
			return encoding;
		}

		// Token: 0x0600688D RID: 26765 RVA: 0x00161178 File Offset: 0x0015F378
		internal static void AddProvider(EncodingProvider provider)
		{
			if (provider == null)
			{
				throw new ArgumentNullException("provider");
			}
			object obj = EncodingProvider.s_InternalSyncObject;
			lock (obj)
			{
				if (EncodingProvider.s_providers == null)
				{
					EncodingProvider.s_providers = new EncodingProvider[]
					{
						provider
					};
				}
				else if (Array.IndexOf<EncodingProvider>(EncodingProvider.s_providers, provider) < 0)
				{
					EncodingProvider[] array = new EncodingProvider[EncodingProvider.s_providers.Length + 1];
					Array.Copy(EncodingProvider.s_providers, array, EncodingProvider.s_providers.Length);
					array[array.Length - 1] = provider;
					EncodingProvider.s_providers = array;
				}
			}
		}

		// Token: 0x0600688E RID: 26766 RVA: 0x00161224 File Offset: 0x0015F424
		internal static Encoding GetEncodingFromProvider(int codepage)
		{
			if (EncodingProvider.s_providers == null)
			{
				return null;
			}
			EncodingProvider[] array = EncodingProvider.s_providers;
			foreach (EncodingProvider encodingProvider in array)
			{
				Encoding encoding = encodingProvider.GetEncoding(codepage);
				if (encoding != null)
				{
					return encoding;
				}
			}
			return null;
		}

		// Token: 0x0600688F RID: 26767 RVA: 0x0016126C File Offset: 0x0015F46C
		internal static Encoding GetEncodingFromProvider(string encodingName)
		{
			if (EncodingProvider.s_providers == null)
			{
				return null;
			}
			EncodingProvider[] array = EncodingProvider.s_providers;
			foreach (EncodingProvider encodingProvider in array)
			{
				Encoding encoding = encodingProvider.GetEncoding(encodingName);
				if (encoding != null)
				{
					return encoding;
				}
			}
			return null;
		}

		// Token: 0x06006890 RID: 26768 RVA: 0x001612B4 File Offset: 0x0015F4B4
		internal static Encoding GetEncodingFromProvider(int codepage, EncoderFallback enc, DecoderFallback dec)
		{
			if (EncodingProvider.s_providers == null)
			{
				return null;
			}
			EncodingProvider[] array = EncodingProvider.s_providers;
			foreach (EncodingProvider encodingProvider in array)
			{
				Encoding encoding = encodingProvider.GetEncoding(codepage, enc, dec);
				if (encoding != null)
				{
					return encoding;
				}
			}
			return null;
		}

		// Token: 0x06006891 RID: 26769 RVA: 0x001612FC File Offset: 0x0015F4FC
		internal static Encoding GetEncodingFromProvider(string encodingName, EncoderFallback enc, DecoderFallback dec)
		{
			if (EncodingProvider.s_providers == null)
			{
				return null;
			}
			EncodingProvider[] array = EncodingProvider.s_providers;
			foreach (EncodingProvider encodingProvider in array)
			{
				Encoding encoding = encodingProvider.GetEncoding(encodingName, enc, dec);
				if (encoding != null)
				{
					return encoding;
				}
			}
			return null;
		}

		// Token: 0x04002EB1 RID: 11953
		private static object s_InternalSyncObject = new object();

		// Token: 0x04002EB2 RID: 11954
		private static volatile EncodingProvider[] s_providers;
	}
}
