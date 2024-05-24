using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A01 RID: 2561
	internal sealed class CLRIReferenceArrayImpl<T> : CLRIPropertyValueImpl, IReferenceArray<T>, IPropertyValue, ICustomPropertyProvider, IList, ICollection, IEnumerable
	{
		// Token: 0x06006532 RID: 25906 RVA: 0x00158BEF File Offset: 0x00156DEF
		public CLRIReferenceArrayImpl(PropertyType type, T[] obj) : base(type, obj)
		{
			this._value = obj;
			this._list = this._value;
		}

		// Token: 0x17001163 RID: 4451
		// (get) Token: 0x06006533 RID: 25907 RVA: 0x00158C0C File Offset: 0x00156E0C
		public T[] Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x06006534 RID: 25908 RVA: 0x00158C14 File Offset: 0x00156E14
		public override string ToString()
		{
			if (this._value != null)
			{
				return this._value.ToString();
			}
			return base.ToString();
		}

		// Token: 0x06006535 RID: 25909 RVA: 0x00158C30 File Offset: 0x00156E30
		ICustomProperty ICustomPropertyProvider.GetCustomProperty(string name)
		{
			return ICustomPropertyProviderImpl.CreateProperty(this._value, name);
		}

		// Token: 0x06006536 RID: 25910 RVA: 0x00158C3E File Offset: 0x00156E3E
		ICustomProperty ICustomPropertyProvider.GetIndexedProperty(string name, Type indexParameterType)
		{
			return ICustomPropertyProviderImpl.CreateIndexedProperty(this._value, name, indexParameterType);
		}

		// Token: 0x06006537 RID: 25911 RVA: 0x00158C4D File Offset: 0x00156E4D
		string ICustomPropertyProvider.GetStringRepresentation()
		{
			return this._value.ToString();
		}

		// Token: 0x17001164 RID: 4452
		// (get) Token: 0x06006538 RID: 25912 RVA: 0x00158C5A File Offset: 0x00156E5A
		Type ICustomPropertyProvider.Type
		{
			get
			{
				return this._value.GetType();
			}
		}

		// Token: 0x06006539 RID: 25913 RVA: 0x00158C67 File Offset: 0x00156E67
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this._value.GetEnumerator();
		}

		// Token: 0x17001165 RID: 4453
		object IList.this[int index]
		{
			get
			{
				return this._list[index];
			}
			set
			{
				this._list[index] = value;
			}
		}

		// Token: 0x0600653C RID: 25916 RVA: 0x00158C91 File Offset: 0x00156E91
		int IList.Add(object value)
		{
			return this._list.Add(value);
		}

		// Token: 0x0600653D RID: 25917 RVA: 0x00158C9F File Offset: 0x00156E9F
		bool IList.Contains(object value)
		{
			return this._list.Contains(value);
		}

		// Token: 0x0600653E RID: 25918 RVA: 0x00158CAD File Offset: 0x00156EAD
		void IList.Clear()
		{
			this._list.Clear();
		}

		// Token: 0x17001166 RID: 4454
		// (get) Token: 0x0600653F RID: 25919 RVA: 0x00158CBA File Offset: 0x00156EBA
		bool IList.IsReadOnly
		{
			get
			{
				return this._list.IsReadOnly;
			}
		}

		// Token: 0x17001167 RID: 4455
		// (get) Token: 0x06006540 RID: 25920 RVA: 0x00158CC7 File Offset: 0x00156EC7
		bool IList.IsFixedSize
		{
			get
			{
				return this._list.IsFixedSize;
			}
		}

		// Token: 0x06006541 RID: 25921 RVA: 0x00158CD4 File Offset: 0x00156ED4
		int IList.IndexOf(object value)
		{
			return this._list.IndexOf(value);
		}

		// Token: 0x06006542 RID: 25922 RVA: 0x00158CE2 File Offset: 0x00156EE2
		void IList.Insert(int index, object value)
		{
			this._list.Insert(index, value);
		}

		// Token: 0x06006543 RID: 25923 RVA: 0x00158CF1 File Offset: 0x00156EF1
		void IList.Remove(object value)
		{
			this._list.Remove(value);
		}

		// Token: 0x06006544 RID: 25924 RVA: 0x00158CFF File Offset: 0x00156EFF
		void IList.RemoveAt(int index)
		{
			this._list.RemoveAt(index);
		}

		// Token: 0x06006545 RID: 25925 RVA: 0x00158D0D File Offset: 0x00156F0D
		void ICollection.CopyTo(Array array, int index)
		{
			this._list.CopyTo(array, index);
		}

		// Token: 0x17001168 RID: 4456
		// (get) Token: 0x06006546 RID: 25926 RVA: 0x00158D1C File Offset: 0x00156F1C
		int ICollection.Count
		{
			get
			{
				return this._list.Count;
			}
		}

		// Token: 0x17001169 RID: 4457
		// (get) Token: 0x06006547 RID: 25927 RVA: 0x00158D29 File Offset: 0x00156F29
		object ICollection.SyncRoot
		{
			get
			{
				return this._list.SyncRoot;
			}
		}

		// Token: 0x1700116A RID: 4458
		// (get) Token: 0x06006548 RID: 25928 RVA: 0x00158D36 File Offset: 0x00156F36
		bool ICollection.IsSynchronized
		{
			get
			{
				return this._list.IsSynchronized;
			}
		}

		// Token: 0x06006549 RID: 25929 RVA: 0x00158D44 File Offset: 0x00156F44
		[FriendAccessAllowed]
		internal static object UnboxHelper(object wrapper)
		{
			IReferenceArray<T> referenceArray = (IReferenceArray<T>)wrapper;
			return referenceArray.Value;
		}

		// Token: 0x04002D2E RID: 11566
		private T[] _value;

		// Token: 0x04002D2F RID: 11567
		private IList _list;
	}
}
