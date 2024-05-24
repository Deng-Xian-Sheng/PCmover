using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security;

namespace System.Resources
{
	// Token: 0x0200039C RID: 924
	internal sealed class RuntimeResourceSet : ResourceSet, IEnumerable
	{
		// Token: 0x06002D8B RID: 11659 RVA: 0x000AE4F0 File Offset: 0x000AC6F0
		[SecurityCritical]
		internal RuntimeResourceSet(string fileName) : base(false)
		{
			this._resCache = new Dictionary<string, ResourceLocator>(FastResourceComparer.Default);
			Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
			this._defaultReader = new ResourceReader(stream, this._resCache);
			this.Reader = this._defaultReader;
		}

		// Token: 0x06002D8C RID: 11660 RVA: 0x000AE53C File Offset: 0x000AC73C
		[SecurityCritical]
		internal RuntimeResourceSet(Stream stream) : base(false)
		{
			this._resCache = new Dictionary<string, ResourceLocator>(FastResourceComparer.Default);
			this._defaultReader = new ResourceReader(stream, this._resCache);
			this.Reader = this._defaultReader;
		}

		// Token: 0x06002D8D RID: 11661 RVA: 0x000AE574 File Offset: 0x000AC774
		protected override void Dispose(bool disposing)
		{
			if (this.Reader == null)
			{
				return;
			}
			if (disposing)
			{
				IResourceReader reader = this.Reader;
				lock (reader)
				{
					this._resCache = null;
					if (this._defaultReader != null)
					{
						this._defaultReader.Close();
						this._defaultReader = null;
					}
					this._caseInsensitiveTable = null;
					base.Dispose(disposing);
					return;
				}
			}
			this._resCache = null;
			this._caseInsensitiveTable = null;
			this._defaultReader = null;
			base.Dispose(disposing);
		}

		// Token: 0x06002D8E RID: 11662 RVA: 0x000AE608 File Offset: 0x000AC808
		public override IDictionaryEnumerator GetEnumerator()
		{
			return this.GetEnumeratorHelper();
		}

		// Token: 0x06002D8F RID: 11663 RVA: 0x000AE610 File Offset: 0x000AC810
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumeratorHelper();
		}

		// Token: 0x06002D90 RID: 11664 RVA: 0x000AE618 File Offset: 0x000AC818
		private IDictionaryEnumerator GetEnumeratorHelper()
		{
			IResourceReader reader = this.Reader;
			if (reader == null || this._resCache == null)
			{
				throw new ObjectDisposedException(null, Environment.GetResourceString("ObjectDisposed_ResourceSet"));
			}
			return reader.GetEnumerator();
		}

		// Token: 0x06002D91 RID: 11665 RVA: 0x000AE650 File Offset: 0x000AC850
		public override string GetString(string key)
		{
			object @object = this.GetObject(key, false, true);
			return (string)@object;
		}

		// Token: 0x06002D92 RID: 11666 RVA: 0x000AE670 File Offset: 0x000AC870
		public override string GetString(string key, bool ignoreCase)
		{
			object @object = this.GetObject(key, ignoreCase, true);
			return (string)@object;
		}

		// Token: 0x06002D93 RID: 11667 RVA: 0x000AE68D File Offset: 0x000AC88D
		public override object GetObject(string key)
		{
			return this.GetObject(key, false, false);
		}

		// Token: 0x06002D94 RID: 11668 RVA: 0x000AE698 File Offset: 0x000AC898
		public override object GetObject(string key, bool ignoreCase)
		{
			return this.GetObject(key, ignoreCase, false);
		}

		// Token: 0x06002D95 RID: 11669 RVA: 0x000AE6A4 File Offset: 0x000AC8A4
		private object GetObject(string key, bool ignoreCase, bool isString)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (this.Reader == null || this._resCache == null)
			{
				throw new ObjectDisposedException(null, Environment.GetResourceString("ObjectDisposed_ResourceSet"));
			}
			object obj = null;
			IResourceReader reader = this.Reader;
			object result;
			lock (reader)
			{
				if (this.Reader == null)
				{
					throw new ObjectDisposedException(null, Environment.GetResourceString("ObjectDisposed_ResourceSet"));
				}
				ResourceLocator resourceLocator;
				if (this._defaultReader != null)
				{
					int num = -1;
					if (this._resCache.TryGetValue(key, out resourceLocator))
					{
						obj = resourceLocator.Value;
						num = resourceLocator.DataPosition;
					}
					if (num == -1 && obj == null)
					{
						num = this._defaultReader.FindPosForResource(key);
					}
					if (num != -1 && obj == null)
					{
						ResourceTypeCode value;
						if (isString)
						{
							obj = this._defaultReader.LoadString(num);
							value = ResourceTypeCode.String;
						}
						else
						{
							obj = this._defaultReader.LoadObject(num, out value);
						}
						resourceLocator = new ResourceLocator(num, ResourceLocator.CanCache(value) ? obj : null);
						Dictionary<string, ResourceLocator> resCache = this._resCache;
						lock (resCache)
						{
							this._resCache[key] = resourceLocator;
						}
					}
					if (obj != null || !ignoreCase)
					{
						return obj;
					}
				}
				if (!this._haveReadFromReader)
				{
					if (ignoreCase && this._caseInsensitiveTable == null)
					{
						this._caseInsensitiveTable = new Dictionary<string, ResourceLocator>(StringComparer.OrdinalIgnoreCase);
					}
					if (this._defaultReader == null)
					{
						IDictionaryEnumerator enumerator = this.Reader.GetEnumerator();
						while (enumerator.MoveNext())
						{
							DictionaryEntry entry = enumerator.Entry;
							string key2 = (string)entry.Key;
							ResourceLocator value2 = new ResourceLocator(-1, entry.Value);
							this._resCache.Add(key2, value2);
							if (ignoreCase)
							{
								this._caseInsensitiveTable.Add(key2, value2);
							}
						}
						if (!ignoreCase)
						{
							this.Reader.Close();
						}
					}
					else
					{
						ResourceReader.ResourceEnumerator enumeratorInternal = this._defaultReader.GetEnumeratorInternal();
						while (enumeratorInternal.MoveNext())
						{
							string key3 = (string)enumeratorInternal.Key;
							int dataPosition = enumeratorInternal.DataPosition;
							ResourceLocator value3 = new ResourceLocator(dataPosition, null);
							this._caseInsensitiveTable.Add(key3, value3);
						}
					}
					this._haveReadFromReader = true;
				}
				object obj2 = null;
				bool flag3 = false;
				bool keyInWrongCase = false;
				if (this._defaultReader != null && this._resCache.TryGetValue(key, out resourceLocator))
				{
					flag3 = true;
					obj2 = this.ResolveResourceLocator(resourceLocator, key, this._resCache, keyInWrongCase);
				}
				if (!flag3 && ignoreCase && this._caseInsensitiveTable.TryGetValue(key, out resourceLocator))
				{
					keyInWrongCase = true;
					obj2 = this.ResolveResourceLocator(resourceLocator, key, this._resCache, keyInWrongCase);
				}
				result = obj2;
			}
			return result;
		}

		// Token: 0x06002D96 RID: 11670 RVA: 0x000AE96C File Offset: 0x000ACB6C
		private object ResolveResourceLocator(ResourceLocator resLocation, string key, Dictionary<string, ResourceLocator> copyOfCache, bool keyInWrongCase)
		{
			object obj = resLocation.Value;
			if (obj == null)
			{
				IResourceReader reader = this.Reader;
				ResourceTypeCode value;
				lock (reader)
				{
					obj = this._defaultReader.LoadObject(resLocation.DataPosition, out value);
				}
				if (!keyInWrongCase && ResourceLocator.CanCache(value))
				{
					resLocation.Value = obj;
					copyOfCache[key] = resLocation;
				}
			}
			return obj;
		}

		// Token: 0x04001286 RID: 4742
		internal const int Version = 2;

		// Token: 0x04001287 RID: 4743
		private Dictionary<string, ResourceLocator> _resCache;

		// Token: 0x04001288 RID: 4744
		private ResourceReader _defaultReader;

		// Token: 0x04001289 RID: 4745
		private Dictionary<string, ResourceLocator> _caseInsensitiveTable;

		// Token: 0x0400128A RID: 4746
		private bool _haveReadFromReader;
	}
}
