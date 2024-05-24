using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x0200002A RID: 42
	[NullableContext(1)]
	[Nullable(0)]
	[GeneratedCode("simple-json", "1.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class JsonObject : DynamicObject, IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
	{
		// Token: 0x060003BD RID: 957 RVA: 0x00007343 File Offset: 0x00005543
		public JsonObject()
		{
			this._members = new Dictionary<string, object>();
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00007356 File Offset: 0x00005556
		public JsonObject(IEqualityComparer<string> comparer)
		{
			this._members = new Dictionary<string, object>(comparer);
		}

		// Token: 0x17000129 RID: 297
		public object this[int index]
		{
			get
			{
				return JsonObject.GetAtIndex(this._members, index);
			}
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00007378 File Offset: 0x00005578
		internal static object GetAtIndex(IDictionary<string, object> obj, int index)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (index >= obj.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int num = 0;
			foreach (KeyValuePair<string, object> keyValuePair in obj)
			{
				if (num++ == index)
				{
					return keyValuePair.Value;
				}
			}
			return null;
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x000073F4 File Offset: 0x000055F4
		public void Add(string key, object value)
		{
			this._members.Add(key, value);
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00007403 File Offset: 0x00005603
		public bool ContainsKey(string key)
		{
			return this._members.ContainsKey(key);
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x00007411 File Offset: 0x00005611
		public ICollection<string> Keys
		{
			get
			{
				return this._members.Keys;
			}
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0000741E File Offset: 0x0000561E
		public bool Remove(string key)
		{
			return this._members.Remove(key);
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0000742C File Offset: 0x0000562C
		public bool TryGetValue(string key, out object value)
		{
			return this._members.TryGetValue(key, out value);
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x0000743B File Offset: 0x0000563B
		public ICollection<object> Values
		{
			get
			{
				return this._members.Values;
			}
		}

		// Token: 0x1700012C RID: 300
		public object this[string key]
		{
			get
			{
				return this._members[key];
			}
			set
			{
				this._members[key] = value;
			}
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00007465 File Offset: 0x00005665
		public void Add([Nullable(new byte[]
		{
			0,
			1,
			1
		})] KeyValuePair<string, object> item)
		{
			this._members.Add(item.Key, item.Value);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00007480 File Offset: 0x00005680
		public void Clear()
		{
			this._members.Clear();
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00007490 File Offset: 0x00005690
		public bool Contains([Nullable(new byte[]
		{
			0,
			1,
			1
		})] KeyValuePair<string, object> item)
		{
			object obj;
			return this._members.TryGetValue(item.Key, out obj) && obj == item.Value;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000074C0 File Offset: 0x000056C0
		public void CopyTo([Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] KeyValuePair<string, object>[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int num = this.Count;
			foreach (KeyValuePair<string, object> keyValuePair in this)
			{
				array[arrayIndex++] = keyValuePair;
				if (--num <= 0)
				{
					break;
				}
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060003CD RID: 973 RVA: 0x00007530 File Offset: 0x00005730
		public int Count
		{
			get
			{
				return this._members.Count;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060003CE RID: 974 RVA: 0x0000753D File Offset: 0x0000573D
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00007540 File Offset: 0x00005740
		public bool Remove([Nullable(new byte[]
		{
			0,
			1,
			1
		})] KeyValuePair<string, object> item)
		{
			return this._members.Remove(item.Key);
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00007554 File Offset: 0x00005754
		[return: Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			return this._members.GetEnumerator();
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00007566 File Offset: 0x00005766
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this._members.GetEnumerator();
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00007578 File Offset: 0x00005778
		public override string ToString()
		{
			return SimpleJson.SerializeObject(this);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00007580 File Offset: 0x00005780
		public override bool TryConvert(ConvertBinder binder, out object result)
		{
			if (binder == null)
			{
				throw new ArgumentNullException("binder");
			}
			Type type = binder.Type;
			if (type == typeof(IEnumerable) || type == typeof(IEnumerable<KeyValuePair<string, object>>) || type == typeof(IDictionary<string, object>) || type == typeof(IDictionary))
			{
				result = this;
				return true;
			}
			return base.TryConvert(binder, out result);
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x000075F7 File Offset: 0x000057F7
		public override bool TryDeleteMember(DeleteMemberBinder binder)
		{
			if (binder == null)
			{
				throw new ArgumentNullException("binder");
			}
			return this._members.Remove(binder.Name);
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00007618 File Offset: 0x00005818
		public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
		{
			if (indexes == null)
			{
				throw new ArgumentNullException("indexes");
			}
			if (indexes.Length == 1)
			{
				result = ((IDictionary<string, object>)this)[(string)indexes[0]];
				return true;
			}
			result = null;
			return true;
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00007644 File Offset: 0x00005844
		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			object obj;
			if (this._members.TryGetValue(binder.Name, out obj))
			{
				result = obj;
				return true;
			}
			result = null;
			return true;
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0000766F File Offset: 0x0000586F
		public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
		{
			if (indexes == null)
			{
				throw new ArgumentNullException("indexes");
			}
			if (indexes.Length == 1)
			{
				((IDictionary<string, object>)this)[(string)indexes[0]] = value;
				return true;
			}
			return base.TrySetIndex(binder, indexes, value);
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0000769F File Offset: 0x0000589F
		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			if (binder == null)
			{
				throw new ArgumentNullException("binder");
			}
			this._members[binder.Name] = value;
			return true;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x000076C2 File Offset: 0x000058C2
		public override IEnumerable<string> GetDynamicMemberNames()
		{
			foreach (string text in this.Keys)
			{
				yield return text;
			}
			IEnumerator<string> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x040000E0 RID: 224
		private readonly Dictionary<string, object> _members;
	}
}
