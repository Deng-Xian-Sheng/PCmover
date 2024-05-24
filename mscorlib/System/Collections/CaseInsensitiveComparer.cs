using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Collections
{
	// Token: 0x02000489 RID: 1161
	[ComVisible(true)]
	[Serializable]
	public class CaseInsensitiveComparer : IComparer
	{
		// Token: 0x06003768 RID: 14184 RVA: 0x000D5482 File Offset: 0x000D3682
		public CaseInsensitiveComparer()
		{
			this.m_compareInfo = CultureInfo.CurrentCulture.CompareInfo;
		}

		// Token: 0x06003769 RID: 14185 RVA: 0x000D549A File Offset: 0x000D369A
		public CaseInsensitiveComparer(CultureInfo culture)
		{
			if (culture == null)
			{
				throw new ArgumentNullException("culture");
			}
			this.m_compareInfo = culture.CompareInfo;
		}

		// Token: 0x1700081F RID: 2079
		// (get) Token: 0x0600376A RID: 14186 RVA: 0x000D54BC File Offset: 0x000D36BC
		public static CaseInsensitiveComparer Default
		{
			get
			{
				return new CaseInsensitiveComparer(CultureInfo.CurrentCulture);
			}
		}

		// Token: 0x17000820 RID: 2080
		// (get) Token: 0x0600376B RID: 14187 RVA: 0x000D54C8 File Offset: 0x000D36C8
		public static CaseInsensitiveComparer DefaultInvariant
		{
			get
			{
				if (CaseInsensitiveComparer.m_InvariantCaseInsensitiveComparer == null)
				{
					CaseInsensitiveComparer.m_InvariantCaseInsensitiveComparer = new CaseInsensitiveComparer(CultureInfo.InvariantCulture);
				}
				return CaseInsensitiveComparer.m_InvariantCaseInsensitiveComparer;
			}
		}

		// Token: 0x0600376C RID: 14188 RVA: 0x000D54EC File Offset: 0x000D36EC
		public int Compare(object a, object b)
		{
			string text = a as string;
			string text2 = b as string;
			if (text != null && text2 != null)
			{
				return this.m_compareInfo.Compare(text, text2, CompareOptions.IgnoreCase);
			}
			return Comparer.Default.Compare(a, b);
		}

		// Token: 0x040018AD RID: 6317
		private CompareInfo m_compareInfo;

		// Token: 0x040018AE RID: 6318
		private static volatile CaseInsensitiveComparer m_InvariantCaseInsensitiveComparer;
	}
}
