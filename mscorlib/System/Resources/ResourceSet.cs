using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Resources
{
	// Token: 0x02000399 RID: 921
	[ComVisible(true)]
	[Serializable]
	public class ResourceSet : IDisposable, IEnumerable
	{
		// Token: 0x06002D64 RID: 11620 RVA: 0x000AD4ED File Offset: 0x000AB6ED
		protected ResourceSet()
		{
			this.CommonInit();
		}

		// Token: 0x06002D65 RID: 11621 RVA: 0x000AD4FB File Offset: 0x000AB6FB
		internal ResourceSet(bool junk)
		{
		}

		// Token: 0x06002D66 RID: 11622 RVA: 0x000AD503 File Offset: 0x000AB703
		public ResourceSet(string fileName)
		{
			this.Reader = new ResourceReader(fileName);
			this.CommonInit();
			this.ReadResources();
		}

		// Token: 0x06002D67 RID: 11623 RVA: 0x000AD523 File Offset: 0x000AB723
		[SecurityCritical]
		public ResourceSet(Stream stream)
		{
			this.Reader = new ResourceReader(stream);
			this.CommonInit();
			this.ReadResources();
		}

		// Token: 0x06002D68 RID: 11624 RVA: 0x000AD543 File Offset: 0x000AB743
		public ResourceSet(IResourceReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			this.Reader = reader;
			this.CommonInit();
			this.ReadResources();
		}

		// Token: 0x06002D69 RID: 11625 RVA: 0x000AD56C File Offset: 0x000AB76C
		private void CommonInit()
		{
			this.Table = new Hashtable();
		}

		// Token: 0x06002D6A RID: 11626 RVA: 0x000AD579 File Offset: 0x000AB779
		public virtual void Close()
		{
			this.Dispose(true);
		}

		// Token: 0x06002D6B RID: 11627 RVA: 0x000AD584 File Offset: 0x000AB784
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				IResourceReader reader = this.Reader;
				this.Reader = null;
				if (reader != null)
				{
					reader.Close();
				}
			}
			this.Reader = null;
			this._caseInsensitiveTable = null;
			this.Table = null;
		}

		// Token: 0x06002D6C RID: 11628 RVA: 0x000AD5C0 File Offset: 0x000AB7C0
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x06002D6D RID: 11629 RVA: 0x000AD5C9 File Offset: 0x000AB7C9
		public virtual Type GetDefaultReader()
		{
			return typeof(ResourceReader);
		}

		// Token: 0x06002D6E RID: 11630 RVA: 0x000AD5D5 File Offset: 0x000AB7D5
		public virtual Type GetDefaultWriter()
		{
			return typeof(ResourceWriter);
		}

		// Token: 0x06002D6F RID: 11631 RVA: 0x000AD5E1 File Offset: 0x000AB7E1
		[ComVisible(false)]
		public virtual IDictionaryEnumerator GetEnumerator()
		{
			return this.GetEnumeratorHelper();
		}

		// Token: 0x06002D70 RID: 11632 RVA: 0x000AD5E9 File Offset: 0x000AB7E9
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumeratorHelper();
		}

		// Token: 0x06002D71 RID: 11633 RVA: 0x000AD5F4 File Offset: 0x000AB7F4
		private IDictionaryEnumerator GetEnumeratorHelper()
		{
			Hashtable table = this.Table;
			if (table == null)
			{
				throw new ObjectDisposedException(null, Environment.GetResourceString("ObjectDisposed_ResourceSet"));
			}
			return table.GetEnumerator();
		}

		// Token: 0x06002D72 RID: 11634 RVA: 0x000AD624 File Offset: 0x000AB824
		public virtual string GetString(string name)
		{
			object objectInternal = this.GetObjectInternal(name);
			string result;
			try
			{
				result = (string)objectInternal;
			}
			catch (InvalidCastException)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceNotString_Name", new object[]
				{
					name
				}));
			}
			return result;
		}

		// Token: 0x06002D73 RID: 11635 RVA: 0x000AD670 File Offset: 0x000AB870
		public virtual string GetString(string name, bool ignoreCase)
		{
			object obj = this.GetObjectInternal(name);
			string text;
			try
			{
				text = (string)obj;
			}
			catch (InvalidCastException)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceNotString_Name", new object[]
				{
					name
				}));
			}
			if (text != null || !ignoreCase)
			{
				return text;
			}
			obj = this.GetCaseInsensitiveObjectInternal(name);
			string result;
			try
			{
				result = (string)obj;
			}
			catch (InvalidCastException)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResourceNotString_Name", new object[]
				{
					name
				}));
			}
			return result;
		}

		// Token: 0x06002D74 RID: 11636 RVA: 0x000AD6FC File Offset: 0x000AB8FC
		public virtual object GetObject(string name)
		{
			return this.GetObjectInternal(name);
		}

		// Token: 0x06002D75 RID: 11637 RVA: 0x000AD708 File Offset: 0x000AB908
		public virtual object GetObject(string name, bool ignoreCase)
		{
			object objectInternal = this.GetObjectInternal(name);
			if (objectInternal != null || !ignoreCase)
			{
				return objectInternal;
			}
			return this.GetCaseInsensitiveObjectInternal(name);
		}

		// Token: 0x06002D76 RID: 11638 RVA: 0x000AD72C File Offset: 0x000AB92C
		protected virtual void ReadResources()
		{
			IDictionaryEnumerator enumerator = this.Reader.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object value = enumerator.Value;
				this.Table.Add(enumerator.Key, value);
			}
		}

		// Token: 0x06002D77 RID: 11639 RVA: 0x000AD768 File Offset: 0x000AB968
		private object GetObjectInternal(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			Hashtable table = this.Table;
			if (table == null)
			{
				throw new ObjectDisposedException(null, Environment.GetResourceString("ObjectDisposed_ResourceSet"));
			}
			return table[name];
		}

		// Token: 0x06002D78 RID: 11640 RVA: 0x000AD7A8 File Offset: 0x000AB9A8
		private object GetCaseInsensitiveObjectInternal(string name)
		{
			Hashtable table = this.Table;
			if (table == null)
			{
				throw new ObjectDisposedException(null, Environment.GetResourceString("ObjectDisposed_ResourceSet"));
			}
			Hashtable hashtable = this._caseInsensitiveTable;
			if (hashtable == null)
			{
				hashtable = new Hashtable(StringComparer.OrdinalIgnoreCase);
				IDictionaryEnumerator enumerator = table.GetEnumerator();
				while (enumerator.MoveNext())
				{
					hashtable.Add(enumerator.Key, enumerator.Value);
				}
				this._caseInsensitiveTable = hashtable;
			}
			return hashtable[name];
		}

		// Token: 0x04001264 RID: 4708
		[NonSerialized]
		protected IResourceReader Reader;

		// Token: 0x04001265 RID: 4709
		protected Hashtable Table;

		// Token: 0x04001266 RID: 4710
		private Hashtable _caseInsensitiveTable;
	}
}
