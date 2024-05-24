using System;
using System.Collections.Generic;
using System.Threading;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200044A RID: 1098
	internal sealed class NameInfo : ConcurrentSetItem<KeyValuePair<string, EventTags>, NameInfo>
	{
		// Token: 0x06003645 RID: 13893 RVA: 0x000D2DCC File Offset: 0x000D0FCC
		internal static void ReserveEventIDsBelow(int eventId)
		{
			int num;
			int num2;
			do
			{
				num = NameInfo.lastIdentity;
				num2 = (NameInfo.lastIdentity & -16777216) + eventId;
				num2 = Math.Max(num2, num);
			}
			while (Interlocked.CompareExchange(ref NameInfo.lastIdentity, num2, num) != num);
		}

		// Token: 0x06003646 RID: 13894 RVA: 0x000D2E04 File Offset: 0x000D1004
		public NameInfo(string name, EventTags tags, int typeMetadataSize)
		{
			this.name = name;
			this.tags = (tags & (EventTags)268435455);
			this.identity = Interlocked.Increment(ref NameInfo.lastIdentity);
			int prefixSize = 0;
			Statics.EncodeTags((int)this.tags, ref prefixSize, null);
			this.nameMetadata = Statics.MetadataForString(name, prefixSize, 0, typeMetadataSize);
			prefixSize = 2;
			Statics.EncodeTags((int)this.tags, ref prefixSize, this.nameMetadata);
		}

		// Token: 0x06003647 RID: 13895 RVA: 0x000D2E6F File Offset: 0x000D106F
		public override int Compare(NameInfo other)
		{
			return this.Compare(other.name, other.tags);
		}

		// Token: 0x06003648 RID: 13896 RVA: 0x000D2E83 File Offset: 0x000D1083
		public override int Compare(KeyValuePair<string, EventTags> key)
		{
			return this.Compare(key.Key, key.Value & (EventTags)268435455);
		}

		// Token: 0x06003649 RID: 13897 RVA: 0x000D2EA0 File Offset: 0x000D10A0
		private int Compare(string otherName, EventTags otherTags)
		{
			int num = StringComparer.Ordinal.Compare(this.name, otherName);
			if (num == 0 && this.tags != otherTags)
			{
				num = ((this.tags < otherTags) ? -1 : 1);
			}
			return num;
		}

		// Token: 0x04001844 RID: 6212
		private static int lastIdentity = 184549376;

		// Token: 0x04001845 RID: 6213
		internal readonly string name;

		// Token: 0x04001846 RID: 6214
		internal readonly EventTags tags;

		// Token: 0x04001847 RID: 6215
		internal readonly int identity;

		// Token: 0x04001848 RID: 6216
		internal readonly byte[] nameMetadata;
	}
}
