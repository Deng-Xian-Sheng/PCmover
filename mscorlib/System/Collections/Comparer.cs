using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Collections
{
	// Token: 0x02000492 RID: 1170
	[ComVisible(true)]
	[Serializable]
	public sealed class Comparer : IComparer, ISerializable
	{
		// Token: 0x0600382C RID: 14380 RVA: 0x000D7B8F File Offset: 0x000D5D8F
		private Comparer()
		{
			this.m_compareInfo = null;
		}

		// Token: 0x0600382D RID: 14381 RVA: 0x000D7B9E File Offset: 0x000D5D9E
		public Comparer(CultureInfo culture)
		{
			if (culture == null)
			{
				throw new ArgumentNullException("culture");
			}
			this.m_compareInfo = culture.CompareInfo;
		}

		// Token: 0x0600382E RID: 14382 RVA: 0x000D7BC0 File Offset: 0x000D5DC0
		private Comparer(SerializationInfo info, StreamingContext context)
		{
			this.m_compareInfo = null;
			SerializationInfoEnumerator enumerator = info.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string name = enumerator.Name;
				if (name == "CompareInfo")
				{
					this.m_compareInfo = (CompareInfo)info.GetValue("CompareInfo", typeof(CompareInfo));
				}
			}
		}

		// Token: 0x0600382F RID: 14383 RVA: 0x000D7C20 File Offset: 0x000D5E20
		public int Compare(object a, object b)
		{
			if (a == b)
			{
				return 0;
			}
			if (a == null)
			{
				return -1;
			}
			if (b == null)
			{
				return 1;
			}
			if (this.m_compareInfo != null)
			{
				string text = a as string;
				string text2 = b as string;
				if (text != null && text2 != null)
				{
					return this.m_compareInfo.Compare(text, text2);
				}
			}
			IComparable comparable = a as IComparable;
			if (comparable != null)
			{
				return comparable.CompareTo(b);
			}
			IComparable comparable2 = b as IComparable;
			if (comparable2 != null)
			{
				return -comparable2.CompareTo(a);
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_ImplementIComparable"));
		}

		// Token: 0x06003830 RID: 14384 RVA: 0x000D7C9B File Offset: 0x000D5E9B
		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			if (this.m_compareInfo != null)
			{
				info.AddValue("CompareInfo", this.m_compareInfo);
			}
		}

		// Token: 0x040018D0 RID: 6352
		private CompareInfo m_compareInfo;

		// Token: 0x040018D1 RID: 6353
		public static readonly Comparer Default = new Comparer(CultureInfo.CurrentCulture);

		// Token: 0x040018D2 RID: 6354
		public static readonly Comparer DefaultInvariant = new Comparer(CultureInfo.InvariantCulture);

		// Token: 0x040018D3 RID: 6355
		private const string CompareInfoName = "CompareInfo";
	}
}
