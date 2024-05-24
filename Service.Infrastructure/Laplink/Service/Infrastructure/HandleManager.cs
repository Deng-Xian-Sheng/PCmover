using System;
using System.Collections.Generic;

namespace Laplink.Service.Infrastructure
{
	// Token: 0x02000005 RID: 5
	public class HandleManager<T>
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002634 File Offset: 0x00000834
		// (set) Token: 0x0600002C RID: 44 RVA: 0x0000263C File Offset: 0x0000083C
		public bool allowNull { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002645 File Offset: 0x00000845
		// (set) Token: 0x0600002E RID: 46 RVA: 0x0000264D File Offset: 0x0000084D
		private protected Dictionary<int, T> Dict { protected get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002658 File Offset: 0x00000858
		public int Count
		{
			get
			{
				Dictionary<int, T> dict = this.Dict;
				int count;
				lock (dict)
				{
					count = this.Dict.Count;
				}
				return count;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000026A0 File Offset: 0x000008A0
		private int NextHandle
		{
			get
			{
				int nextHandle = this._nextHandle;
				this._nextHandle = nextHandle + 1;
				int result = nextHandle;
				if (this._nextHandle == 0)
				{
					this._nextHandle++;
				}
				return result;
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000026D4 File Offset: 0x000008D4
		public HandleManager(int startHandle, EqualityComparer<T> comparer = null)
		{
			this._nextHandle = startHandle;
			this.T_comparer = (comparer ?? EqualityComparer<T>.Default);
			this.Dict = new Dictionary<int, T>();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002700 File Offset: 0x00000900
		public int Add(T data, out bool added)
		{
			if (!this.allowNull && data == null)
			{
				added = false;
				return 0;
			}
			Dictionary<int, T> dict = this.Dict;
			int result;
			lock (dict)
			{
				foreach (KeyValuePair<int, T> keyValuePair in this.Dict)
				{
					if (this.T_comparer.Equals(keyValuePair.Value, data))
					{
						added = false;
						return keyValuePair.Key;
					}
				}
				int nextHandle = this.NextHandle;
				this.Dict.Add(nextHandle, data);
				added = true;
				result = nextHandle;
			}
			return result;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000027CC File Offset: 0x000009CC
		public int Add(T data)
		{
			bool flag;
			return this.Add(data, out flag);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000027E4 File Offset: 0x000009E4
		public int Get(T data)
		{
			Dictionary<int, T> dict = this.Dict;
			lock (dict)
			{
				foreach (KeyValuePair<int, T> keyValuePair in this.Dict)
				{
					if (this.T_comparer.Equals(keyValuePair.Value, data))
					{
						return keyValuePair.Key;
					}
				}
			}
			return 0;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000287C File Offset: 0x00000A7C
		public T Get(int handle)
		{
			T result;
			try
			{
				Dictionary<int, T> dict = this.Dict;
				lock (dict)
				{
					result = this.Dict[handle];
				}
			}
			catch (Exception)
			{
				result = default(T);
			}
			return result;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000028E0 File Offset: 0x00000AE0
		public bool Contains(T data)
		{
			return this.Get(data) != 0;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000028EC File Offset: 0x00000AEC
		public bool Delete(int handle)
		{
			bool result;
			try
			{
				Dictionary<int, T> dict = this.Dict;
				lock (dict)
				{
					result = this.Dict.Remove(handle);
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002948 File Offset: 0x00000B48
		public bool DeleteAll()
		{
			bool result;
			try
			{
				Dictionary<int, T> dict = this.Dict;
				lock (dict)
				{
					this.Dict.Clear();
					result = true;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000029A4 File Offset: 0x00000BA4
		public void CallForEach(Action<T> action)
		{
			Dictionary<int, T> dict = this.Dict;
			Dictionary<int, T> dictionary;
			lock (dict)
			{
				dictionary = new Dictionary<int, T>(this.Dict);
			}
			foreach (KeyValuePair<int, T> keyValuePair in dictionary)
			{
				action(keyValuePair.Value);
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002A30 File Offset: 0x00000C30
		public T Find(Func<T, bool> comparer)
		{
			Dictionary<int, T> dict = this.Dict;
			T result;
			lock (dict)
			{
				foreach (KeyValuePair<int, T> keyValuePair in this.Dict)
				{
					if (comparer(keyValuePair.Value))
					{
						return keyValuePair.Value;
					}
				}
				result = default(T);
			}
			return result;
		}

		// Token: 0x04000013 RID: 19
		private EqualityComparer<T> T_comparer;

		// Token: 0x04000014 RID: 20
		private int _nextHandle;
	}
}
