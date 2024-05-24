using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Collections
{
	// Token: 0x02000490 RID: 1168
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class BitArray : ICollection, IEnumerable, ICloneable
	{
		// Token: 0x06003802 RID: 14338 RVA: 0x000D6F31 File Offset: 0x000D5131
		private BitArray()
		{
		}

		// Token: 0x06003803 RID: 14339 RVA: 0x000D6F39 File Offset: 0x000D5139
		[__DynamicallyInvokable]
		public BitArray(int length) : this(length, false)
		{
		}

		// Token: 0x06003804 RID: 14340 RVA: 0x000D6F44 File Offset: 0x000D5144
		[__DynamicallyInvokable]
		public BitArray(int length, bool defaultValue)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this.m_array = new int[BitArray.GetArrayLength(length, 32)];
			this.m_length = length;
			int num = defaultValue ? -1 : 0;
			for (int i = 0; i < this.m_array.Length; i++)
			{
				this.m_array[i] = num;
			}
			this._version = 0;
		}

		// Token: 0x06003805 RID: 14341 RVA: 0x000D6FB8 File Offset: 0x000D51B8
		[__DynamicallyInvokable]
		public BitArray(byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			if (bytes.Length > 268435455)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ArrayTooLarge", new object[]
				{
					8
				}), "bytes");
			}
			this.m_array = new int[BitArray.GetArrayLength(bytes.Length, 4)];
			this.m_length = bytes.Length * 8;
			int num = 0;
			int num2 = 0;
			while (bytes.Length - num2 >= 4)
			{
				this.m_array[num++] = ((int)(bytes[num2] & byte.MaxValue) | (int)(bytes[num2 + 1] & byte.MaxValue) << 8 | (int)(bytes[num2 + 2] & byte.MaxValue) << 16 | (int)(bytes[num2 + 3] & byte.MaxValue) << 24);
				num2 += 4;
			}
			switch (bytes.Length - num2)
			{
			case 1:
				goto IL_103;
			case 2:
				break;
			case 3:
				this.m_array[num] = (int)(bytes[num2 + 2] & byte.MaxValue) << 16;
				break;
			default:
				goto IL_11C;
			}
			this.m_array[num] |= (int)(bytes[num2 + 1] & byte.MaxValue) << 8;
			IL_103:
			this.m_array[num] |= (int)(bytes[num2] & byte.MaxValue);
			IL_11C:
			this._version = 0;
		}

		// Token: 0x06003806 RID: 14342 RVA: 0x000D70E8 File Offset: 0x000D52E8
		[__DynamicallyInvokable]
		public BitArray(bool[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			this.m_array = new int[BitArray.GetArrayLength(values.Length, 32)];
			this.m_length = values.Length;
			for (int i = 0; i < values.Length; i++)
			{
				if (values[i])
				{
					this.m_array[i / 32] |= 1 << i % 32;
				}
			}
			this._version = 0;
		}

		// Token: 0x06003807 RID: 14343 RVA: 0x000D7160 File Offset: 0x000D5360
		[__DynamicallyInvokable]
		public BitArray(int[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length > 67108863)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ArrayTooLarge", new object[]
				{
					32
				}), "values");
			}
			this.m_array = new int[values.Length];
			this.m_length = values.Length * 32;
			Array.Copy(values, this.m_array, values.Length);
			this._version = 0;
		}

		// Token: 0x06003808 RID: 14344 RVA: 0x000D71E0 File Offset: 0x000D53E0
		[__DynamicallyInvokable]
		public BitArray(BitArray bits)
		{
			if (bits == null)
			{
				throw new ArgumentNullException("bits");
			}
			int arrayLength = BitArray.GetArrayLength(bits.m_length, 32);
			this.m_array = new int[arrayLength];
			this.m_length = bits.m_length;
			Array.Copy(bits.m_array, this.m_array, arrayLength);
			this._version = bits._version;
		}

		// Token: 0x17000844 RID: 2116
		[__DynamicallyInvokable]
		public bool this[int index]
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Get(index);
			}
			[__DynamicallyInvokable]
			set
			{
				this.Set(index, value);
			}
		}

		// Token: 0x0600380B RID: 14347 RVA: 0x000D7258 File Offset: 0x000D5458
		[__DynamicallyInvokable]
		public bool Get(int index)
		{
			if (index < 0 || index >= this.Length)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			return (this.m_array[index / 32] & 1 << index % 32) != 0;
		}

		// Token: 0x0600380C RID: 14348 RVA: 0x000D7294 File Offset: 0x000D5494
		[__DynamicallyInvokable]
		public void Set(int index, bool value)
		{
			if (index < 0 || index >= this.Length)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			if (value)
			{
				this.m_array[index / 32] |= 1 << index % 32;
			}
			else
			{
				this.m_array[index / 32] &= ~(1 << index % 32);
			}
			this._version++;
		}

		// Token: 0x0600380D RID: 14349 RVA: 0x000D7310 File Offset: 0x000D5510
		[__DynamicallyInvokable]
		public void SetAll(bool value)
		{
			int num = value ? -1 : 0;
			int arrayLength = BitArray.GetArrayLength(this.m_length, 32);
			for (int i = 0; i < arrayLength; i++)
			{
				this.m_array[i] = num;
			}
			this._version++;
		}

		// Token: 0x0600380E RID: 14350 RVA: 0x000D7358 File Offset: 0x000D5558
		[__DynamicallyInvokable]
		public BitArray And(BitArray value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (this.Length != value.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_ArrayLengthsDiffer"));
			}
			int arrayLength = BitArray.GetArrayLength(this.m_length, 32);
			for (int i = 0; i < arrayLength; i++)
			{
				this.m_array[i] &= value.m_array[i];
			}
			this._version++;
			return this;
		}

		// Token: 0x0600380F RID: 14351 RVA: 0x000D73D4 File Offset: 0x000D55D4
		[__DynamicallyInvokable]
		public BitArray Or(BitArray value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (this.Length != value.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_ArrayLengthsDiffer"));
			}
			int arrayLength = BitArray.GetArrayLength(this.m_length, 32);
			for (int i = 0; i < arrayLength; i++)
			{
				this.m_array[i] |= value.m_array[i];
			}
			this._version++;
			return this;
		}

		// Token: 0x06003810 RID: 14352 RVA: 0x000D7450 File Offset: 0x000D5650
		[__DynamicallyInvokable]
		public BitArray Xor(BitArray value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (this.Length != value.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_ArrayLengthsDiffer"));
			}
			int arrayLength = BitArray.GetArrayLength(this.m_length, 32);
			for (int i = 0; i < arrayLength; i++)
			{
				this.m_array[i] ^= value.m_array[i];
			}
			this._version++;
			return this;
		}

		// Token: 0x06003811 RID: 14353 RVA: 0x000D74CC File Offset: 0x000D56CC
		[__DynamicallyInvokable]
		public BitArray Not()
		{
			int arrayLength = BitArray.GetArrayLength(this.m_length, 32);
			for (int i = 0; i < arrayLength; i++)
			{
				this.m_array[i] = ~this.m_array[i];
			}
			this._version++;
			return this;
		}

		// Token: 0x17000845 RID: 2117
		// (get) Token: 0x06003812 RID: 14354 RVA: 0x000D7513 File Offset: 0x000D5713
		// (set) Token: 0x06003813 RID: 14355 RVA: 0x000D751C File Offset: 0x000D571C
		[__DynamicallyInvokable]
		public int Length
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_length;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
				}
				int arrayLength = BitArray.GetArrayLength(value, 32);
				if (arrayLength > this.m_array.Length || arrayLength + 256 < this.m_array.Length)
				{
					int[] array = new int[arrayLength];
					Array.Copy(this.m_array, array, (arrayLength > this.m_array.Length) ? this.m_array.Length : arrayLength);
					this.m_array = array;
				}
				if (value > this.m_length)
				{
					int num = BitArray.GetArrayLength(this.m_length, 32) - 1;
					int num2 = this.m_length % 32;
					if (num2 > 0)
					{
						this.m_array[num] &= (1 << num2) - 1;
					}
					Array.Clear(this.m_array, num + 1, arrayLength - num - 1);
				}
				this.m_length = value;
				this._version++;
			}
		}

		// Token: 0x06003814 RID: 14356 RVA: 0x000D7600 File Offset: 0x000D5800
		public void CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (array.Rank != 1)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_RankMultiDimNotSupported"));
			}
			if (array is int[])
			{
				Array.Copy(this.m_array, 0, array, index, BitArray.GetArrayLength(this.m_length, 32));
				return;
			}
			if (array is byte[])
			{
				int arrayLength = BitArray.GetArrayLength(this.m_length, 8);
				if (array.Length - index < arrayLength)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
				}
				byte[] array2 = (byte[])array;
				for (int i = 0; i < arrayLength; i++)
				{
					array2[index + i] = (byte)(this.m_array[i / 4] >> i % 4 * 8 & 255);
				}
				return;
			}
			else
			{
				if (!(array is bool[]))
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_BitArrayTypeUnsupported"));
				}
				if (array.Length - index < this.m_length)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
				}
				bool[] array3 = (bool[])array;
				for (int j = 0; j < this.m_length; j++)
				{
					array3[index + j] = ((this.m_array[j / 32] >> j % 32 & 1) != 0);
				}
				return;
			}
		}

		// Token: 0x17000846 RID: 2118
		// (get) Token: 0x06003815 RID: 14357 RVA: 0x000D7748 File Offset: 0x000D5948
		public int Count
		{
			get
			{
				return this.m_length;
			}
		}

		// Token: 0x06003816 RID: 14358 RVA: 0x000D7750 File Offset: 0x000D5950
		public object Clone()
		{
			return new BitArray(this.m_array)
			{
				_version = this._version,
				m_length = this.m_length
			};
		}

		// Token: 0x17000847 RID: 2119
		// (get) Token: 0x06003817 RID: 14359 RVA: 0x000D7782 File Offset: 0x000D5982
		public object SyncRoot
		{
			get
			{
				if (this._syncRoot == null)
				{
					Interlocked.CompareExchange<object>(ref this._syncRoot, new object(), null);
				}
				return this._syncRoot;
			}
		}

		// Token: 0x17000848 RID: 2120
		// (get) Token: 0x06003818 RID: 14360 RVA: 0x000D77A4 File Offset: 0x000D59A4
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000849 RID: 2121
		// (get) Token: 0x06003819 RID: 14361 RVA: 0x000D77A7 File Offset: 0x000D59A7
		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600381A RID: 14362 RVA: 0x000D77AA File Offset: 0x000D59AA
		[__DynamicallyInvokable]
		public IEnumerator GetEnumerator()
		{
			return new BitArray.BitArrayEnumeratorSimple(this);
		}

		// Token: 0x0600381B RID: 14363 RVA: 0x000D77B2 File Offset: 0x000D59B2
		private static int GetArrayLength(int n, int div)
		{
			if (n <= 0)
			{
				return 0;
			}
			return (n - 1) / div + 1;
		}

		// Token: 0x040018C3 RID: 6339
		private const int BitsPerInt32 = 32;

		// Token: 0x040018C4 RID: 6340
		private const int BytesPerInt32 = 4;

		// Token: 0x040018C5 RID: 6341
		private const int BitsPerByte = 8;

		// Token: 0x040018C6 RID: 6342
		private int[] m_array;

		// Token: 0x040018C7 RID: 6343
		private int m_length;

		// Token: 0x040018C8 RID: 6344
		private int _version;

		// Token: 0x040018C9 RID: 6345
		[NonSerialized]
		private object _syncRoot;

		// Token: 0x040018CA RID: 6346
		private const int _ShrinkThreshold = 256;

		// Token: 0x02000BAD RID: 2989
		[Serializable]
		private class BitArrayEnumeratorSimple : IEnumerator, ICloneable
		{
			// Token: 0x06006DC0 RID: 28096 RVA: 0x0017B2D3 File Offset: 0x001794D3
			internal BitArrayEnumeratorSimple(BitArray bitarray)
			{
				this.bitarray = bitarray;
				this.index = -1;
				this.version = bitarray._version;
			}

			// Token: 0x06006DC1 RID: 28097 RVA: 0x0017B2F5 File Offset: 0x001794F5
			public object Clone()
			{
				return base.MemberwiseClone();
			}

			// Token: 0x06006DC2 RID: 28098 RVA: 0x0017B300 File Offset: 0x00179500
			public virtual bool MoveNext()
			{
				if (this.version != this.bitarray._version)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
				}
				if (this.index < this.bitarray.Count - 1)
				{
					this.index++;
					this.currentElement = this.bitarray.Get(this.index);
					return true;
				}
				this.index = this.bitarray.Count;
				return false;
			}

			// Token: 0x1700129F RID: 4767
			// (get) Token: 0x06006DC3 RID: 28099 RVA: 0x0017B380 File Offset: 0x00179580
			public virtual object Current
			{
				get
				{
					if (this.index == -1)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
					}
					if (this.index >= this.bitarray.Count)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumEnded"));
					}
					return this.currentElement;
				}
			}

			// Token: 0x06006DC4 RID: 28100 RVA: 0x0017B3D4 File Offset: 0x001795D4
			public void Reset()
			{
				if (this.version != this.bitarray._version)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
				}
				this.index = -1;
			}

			// Token: 0x04003555 RID: 13653
			private BitArray bitarray;

			// Token: 0x04003556 RID: 13654
			private int index;

			// Token: 0x04003557 RID: 13655
			private int version;

			// Token: 0x04003558 RID: 13656
			private bool currentElement;
		}
	}
}
