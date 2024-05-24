using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Collections
{
	// Token: 0x0200048A RID: 1162
	[Obsolete("Please use StringComparer instead.")]
	[ComVisible(true)]
	[Serializable]
	public class CaseInsensitiveHashCodeProvider : IHashCodeProvider
	{
		// Token: 0x0600376D RID: 14189 RVA: 0x000D5528 File Offset: 0x000D3728
		public CaseInsensitiveHashCodeProvider()
		{
			this.m_text = CultureInfo.CurrentCulture.TextInfo;
		}

		// Token: 0x0600376E RID: 14190 RVA: 0x000D5540 File Offset: 0x000D3740
		public CaseInsensitiveHashCodeProvider(CultureInfo culture)
		{
			if (culture == null)
			{
				throw new ArgumentNullException("culture");
			}
			this.m_text = culture.TextInfo;
		}

		// Token: 0x17000821 RID: 2081
		// (get) Token: 0x0600376F RID: 14191 RVA: 0x000D5562 File Offset: 0x000D3762
		public static CaseInsensitiveHashCodeProvider Default
		{
			get
			{
				return new CaseInsensitiveHashCodeProvider(CultureInfo.CurrentCulture);
			}
		}

		// Token: 0x17000822 RID: 2082
		// (get) Token: 0x06003770 RID: 14192 RVA: 0x000D556E File Offset: 0x000D376E
		public static CaseInsensitiveHashCodeProvider DefaultInvariant
		{
			get
			{
				if (CaseInsensitiveHashCodeProvider.m_InvariantCaseInsensitiveHashCodeProvider == null)
				{
					CaseInsensitiveHashCodeProvider.m_InvariantCaseInsensitiveHashCodeProvider = new CaseInsensitiveHashCodeProvider(CultureInfo.InvariantCulture);
				}
				return CaseInsensitiveHashCodeProvider.m_InvariantCaseInsensitiveHashCodeProvider;
			}
		}

		// Token: 0x06003771 RID: 14193 RVA: 0x000D5594 File Offset: 0x000D3794
		public int GetHashCode(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			string text = obj as string;
			if (text == null)
			{
				return obj.GetHashCode();
			}
			return this.m_text.GetCaseInsensitiveHashCode(text);
		}

		// Token: 0x040018AF RID: 6319
		private TextInfo m_text;

		// Token: 0x040018B0 RID: 6320
		private static volatile CaseInsensitiveHashCodeProvider m_InvariantCaseInsensitiveHashCodeProvider;
	}
}
