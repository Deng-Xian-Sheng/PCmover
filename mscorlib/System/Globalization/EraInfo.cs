using System;
using System.Runtime.Serialization;

namespace System.Globalization
{
	// Token: 0x020003BE RID: 958
	[Serializable]
	internal class EraInfo
	{
		// Token: 0x06002F7A RID: 12154 RVA: 0x000B66D8 File Offset: 0x000B48D8
		internal EraInfo(int era, int startYear, int startMonth, int startDay, int yearOffset, int minEraYear, int maxEraYear)
		{
			this.era = era;
			this.yearOffset = yearOffset;
			this.minEraYear = minEraYear;
			this.maxEraYear = maxEraYear;
			this.ticks = new DateTime(startYear, startMonth, startDay).Ticks;
		}

		// Token: 0x06002F7B RID: 12155 RVA: 0x000B6724 File Offset: 0x000B4924
		internal EraInfo(int era, int startYear, int startMonth, int startDay, int yearOffset, int minEraYear, int maxEraYear, string eraName, string abbrevEraName, string englishEraName)
		{
			this.era = era;
			this.yearOffset = yearOffset;
			this.minEraYear = minEraYear;
			this.maxEraYear = maxEraYear;
			this.ticks = new DateTime(startYear, startMonth, startDay).Ticks;
			this.eraName = eraName;
			this.abbrevEraName = abbrevEraName;
			this.englishEraName = englishEraName;
		}

		// Token: 0x0400142D RID: 5165
		internal int era;

		// Token: 0x0400142E RID: 5166
		internal long ticks;

		// Token: 0x0400142F RID: 5167
		internal int yearOffset;

		// Token: 0x04001430 RID: 5168
		internal int minEraYear;

		// Token: 0x04001431 RID: 5169
		internal int maxEraYear;

		// Token: 0x04001432 RID: 5170
		[OptionalField(VersionAdded = 4)]
		internal string eraName;

		// Token: 0x04001433 RID: 5171
		[OptionalField(VersionAdded = 4)]
		internal string abbrevEraName;

		// Token: 0x04001434 RID: 5172
		[OptionalField(VersionAdded = 4)]
		internal string englishEraName;
	}
}
