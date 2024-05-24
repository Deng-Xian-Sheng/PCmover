using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000445 RID: 1093
	internal class EventPayload : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
	{
		// Token: 0x06003608 RID: 13832 RVA: 0x000D23A5 File Offset: 0x000D05A5
		internal EventPayload(List<string> payloadNames, List<object> payloadValues)
		{
			this.m_names = payloadNames;
			this.m_values = payloadValues;
		}

		// Token: 0x170007FE RID: 2046
		// (get) Token: 0x06003609 RID: 13833 RVA: 0x000D23BB File Offset: 0x000D05BB
		public ICollection<string> Keys
		{
			get
			{
				return this.m_names;
			}
		}

		// Token: 0x170007FF RID: 2047
		// (get) Token: 0x0600360A RID: 13834 RVA: 0x000D23C3 File Offset: 0x000D05C3
		public ICollection<object> Values
		{
			get
			{
				return this.m_values;
			}
		}

		// Token: 0x17000800 RID: 2048
		public object this[string key]
		{
			get
			{
				if (key == null)
				{
					throw new ArgumentNullException("key");
				}
				int num = 0;
				foreach (string a in this.m_names)
				{
					if (a == key)
					{
						return this.m_values[num];
					}
					num++;
				}
				throw new KeyNotFoundException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x0600360D RID: 13837 RVA: 0x000D2453 File Offset: 0x000D0653
		public void Add(string key, object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600360E RID: 13838 RVA: 0x000D245A File Offset: 0x000D065A
		public void Add(KeyValuePair<string, object> payloadEntry)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600360F RID: 13839 RVA: 0x000D2461 File Offset: 0x000D0661
		public void Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06003610 RID: 13840 RVA: 0x000D2468 File Offset: 0x000D0668
		public bool Contains(KeyValuePair<string, object> entry)
		{
			return this.ContainsKey(entry.Key);
		}

		// Token: 0x06003611 RID: 13841 RVA: 0x000D2478 File Offset: 0x000D0678
		public bool ContainsKey(string key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			foreach (string a in this.m_names)
			{
				if (a == key)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x17000801 RID: 2049
		// (get) Token: 0x06003612 RID: 13842 RVA: 0x000D24E4 File Offset: 0x000D06E4
		public int Count
		{
			get
			{
				return this.m_names.Count;
			}
		}

		// Token: 0x17000802 RID: 2050
		// (get) Token: 0x06003613 RID: 13843 RVA: 0x000D24F1 File Offset: 0x000D06F1
		public bool IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06003614 RID: 13844 RVA: 0x000D24F4 File Offset: 0x000D06F4
		public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			int num;
			for (int i = 0; i < this.Keys.Count; i = num + 1)
			{
				yield return new KeyValuePair<string, object>(this.m_names[i], this.m_values[i]);
				num = i;
			}
			yield break;
		}

		// Token: 0x06003615 RID: 13845 RVA: 0x000D2504 File Offset: 0x000D0704
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<KeyValuePair<string, object>>)this).GetEnumerator();
		}

		// Token: 0x06003616 RID: 13846 RVA: 0x000D2519 File Offset: 0x000D0719
		public void CopyTo(KeyValuePair<string, object>[] payloadEntries, int count)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06003617 RID: 13847 RVA: 0x000D2520 File Offset: 0x000D0720
		public bool Remove(string key)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06003618 RID: 13848 RVA: 0x000D2527 File Offset: 0x000D0727
		public bool Remove(KeyValuePair<string, object> entry)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06003619 RID: 13849 RVA: 0x000D2530 File Offset: 0x000D0730
		public bool TryGetValue(string key, out object value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			int num = 0;
			foreach (string a in this.m_names)
			{
				if (a == key)
				{
					value = this.m_values[num];
					return true;
				}
				num++;
			}
			value = null;
			return false;
		}

		// Token: 0x04001828 RID: 6184
		private List<string> m_names;

		// Token: 0x04001829 RID: 6185
		private List<object> m_values;
	}
}
