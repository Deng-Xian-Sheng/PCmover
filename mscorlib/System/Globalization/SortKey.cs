using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Globalization
{
	// Token: 0x020003CF RID: 975
	[ComVisible(true)]
	[Serializable]
	public class SortKey
	{
		// Token: 0x0600315B RID: 12635 RVA: 0x000BD9C4 File Offset: 0x000BBBC4
		internal SortKey(string localeName, string str, CompareOptions options, byte[] keyData)
		{
			this.m_KeyData = keyData;
			this.localeName = localeName;
			this.options = options;
			this.m_String = str;
		}

		// Token: 0x0600315C RID: 12636 RVA: 0x000BD9E9 File Offset: 0x000BBBE9
		[OnSerializing]
		private void OnSerializing(StreamingContext context)
		{
			if (this.win32LCID == 0)
			{
				this.win32LCID = CultureInfo.GetCultureInfo(this.localeName).LCID;
			}
		}

		// Token: 0x0600315D RID: 12637 RVA: 0x000BDA09 File Offset: 0x000BBC09
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			if (string.IsNullOrEmpty(this.localeName) && this.win32LCID != 0)
			{
				this.localeName = CultureInfo.GetCultureInfo(this.win32LCID).Name;
			}
		}

		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x0600315E RID: 12638 RVA: 0x000BDA36 File Offset: 0x000BBC36
		public virtual string OriginalString
		{
			get
			{
				return this.m_String;
			}
		}

		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x0600315F RID: 12639 RVA: 0x000BDA3E File Offset: 0x000BBC3E
		public virtual byte[] KeyData
		{
			get
			{
				return (byte[])this.m_KeyData.Clone();
			}
		}

		// Token: 0x06003160 RID: 12640 RVA: 0x000BDA50 File Offset: 0x000BBC50
		public static int Compare(SortKey sortkey1, SortKey sortkey2)
		{
			if (sortkey1 == null || sortkey2 == null)
			{
				throw new ArgumentNullException((sortkey1 == null) ? "sortkey1" : "sortkey2");
			}
			byte[] keyData = sortkey1.m_KeyData;
			byte[] keyData2 = sortkey2.m_KeyData;
			if (keyData.Length == 0)
			{
				if (keyData2.Length == 0)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (keyData2.Length == 0)
				{
					return 1;
				}
				int num = (keyData.Length < keyData2.Length) ? keyData.Length : keyData2.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyData[i] > keyData2[i])
					{
						return 1;
					}
					if (keyData[i] < keyData2[i])
					{
						return -1;
					}
				}
				return 0;
			}
		}

		// Token: 0x06003161 RID: 12641 RVA: 0x000BDACC File Offset: 0x000BBCCC
		public override bool Equals(object value)
		{
			SortKey sortKey = value as SortKey;
			return sortKey != null && SortKey.Compare(this, sortKey) == 0;
		}

		// Token: 0x06003162 RID: 12642 RVA: 0x000BDAEF File Offset: 0x000BBCEF
		public override int GetHashCode()
		{
			return CompareInfo.GetCompareInfo(this.localeName).GetHashCodeOfString(this.m_String, this.options);
		}

		// Token: 0x06003163 RID: 12643 RVA: 0x000BDB10 File Offset: 0x000BBD10
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"SortKey - ",
				this.localeName,
				", ",
				this.options.ToString(),
				", ",
				this.m_String
			});
		}

		// Token: 0x04001512 RID: 5394
		[OptionalField(VersionAdded = 3)]
		internal string localeName;

		// Token: 0x04001513 RID: 5395
		[OptionalField(VersionAdded = 1)]
		internal int win32LCID;

		// Token: 0x04001514 RID: 5396
		internal CompareOptions options;

		// Token: 0x04001515 RID: 5397
		internal string m_String;

		// Token: 0x04001516 RID: 5398
		internal byte[] m_KeyData;
	}
}
