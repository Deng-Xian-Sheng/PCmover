using System;

namespace System.Globalization
{
	// Token: 0x020003DF RID: 991
	[Serializable]
	public sealed class SortVersion : IEquatable<SortVersion>
	{
		// Token: 0x1700076E RID: 1902
		// (get) Token: 0x060032DF RID: 13023 RVA: 0x000C4846 File Offset: 0x000C2A46
		public int FullVersion
		{
			get
			{
				return this.m_NlsVersion;
			}
		}

		// Token: 0x1700076F RID: 1903
		// (get) Token: 0x060032E0 RID: 13024 RVA: 0x000C484E File Offset: 0x000C2A4E
		public Guid SortId
		{
			get
			{
				return this.m_SortId;
			}
		}

		// Token: 0x060032E1 RID: 13025 RVA: 0x000C4856 File Offset: 0x000C2A56
		public SortVersion(int fullVersion, Guid sortId)
		{
			this.m_SortId = sortId;
			this.m_NlsVersion = fullVersion;
		}

		// Token: 0x060032E2 RID: 13026 RVA: 0x000C486C File Offset: 0x000C2A6C
		internal SortVersion(int nlsVersion, int effectiveId, Guid customVersion)
		{
			this.m_NlsVersion = nlsVersion;
			if (customVersion == Guid.Empty)
			{
				byte[] bytes = BitConverter.GetBytes(effectiveId);
				byte h = (byte)((uint)effectiveId >> 24);
				byte i = (byte)((effectiveId & 16711680) >> 16);
				byte j = (byte)((effectiveId & 65280) >> 8);
				byte k = (byte)(effectiveId & 255);
				customVersion = new Guid(0, 0, 0, 0, 0, 0, 0, h, i, j, k);
			}
			this.m_SortId = customVersion;
		}

		// Token: 0x060032E3 RID: 13027 RVA: 0x000C48DC File Offset: 0x000C2ADC
		public override bool Equals(object obj)
		{
			SortVersion sortVersion = obj as SortVersion;
			return sortVersion != null && this.Equals(sortVersion);
		}

		// Token: 0x060032E4 RID: 13028 RVA: 0x000C4902 File Offset: 0x000C2B02
		public bool Equals(SortVersion other)
		{
			return !(other == null) && this.m_NlsVersion == other.m_NlsVersion && this.m_SortId == other.m_SortId;
		}

		// Token: 0x060032E5 RID: 13029 RVA: 0x000C4930 File Offset: 0x000C2B30
		public override int GetHashCode()
		{
			return this.m_NlsVersion * 7 | this.m_SortId.GetHashCode();
		}

		// Token: 0x060032E6 RID: 13030 RVA: 0x000C494C File Offset: 0x000C2B4C
		public static bool operator ==(SortVersion left, SortVersion right)
		{
			if (left != null)
			{
				return left.Equals(right);
			}
			return right == null || right.Equals(left);
		}

		// Token: 0x060032E7 RID: 13031 RVA: 0x000C4965 File Offset: 0x000C2B65
		public static bool operator !=(SortVersion left, SortVersion right)
		{
			return !(left == right);
		}

		// Token: 0x0400168F RID: 5775
		private int m_NlsVersion;

		// Token: 0x04001690 RID: 5776
		private Guid m_SortId;
	}
}
