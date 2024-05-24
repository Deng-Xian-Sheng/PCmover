using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002D3 RID: 723
	internal struct Span<T>
	{
		// Token: 0x06002581 RID: 9601 RVA: 0x00088F60 File Offset: 0x00087160
		public Span(ArraySegment<T> segment)
		{
			this._Segment = segment;
		}

		// Token: 0x06002582 RID: 9602 RVA: 0x00088F6C File Offset: 0x0008716C
		public Span(T[] array, int offset, int count)
		{
			this = new Span<T>((array != null || offset != 0 || count != 0) ? new ArraySegment<T>(array, offset, count) : default(ArraySegment<T>));
		}

		// Token: 0x06002583 RID: 9603 RVA: 0x00088F9C File Offset: 0x0008719C
		public Span(T[] array)
		{
			this = new Span<T>((array != null) ? new ArraySegment<T>(array) : default(ArraySegment<T>));
		}

		// Token: 0x170004A5 RID: 1189
		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= this._Segment.Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return this._Segment.Array[index + this._Segment.Offset];
			}
			set
			{
				if (index < 0 || index >= this._Segment.Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				this._Segment.Array[index + this._Segment.Offset] = value;
			}
		}

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x06002586 RID: 9606 RVA: 0x0008903C File Offset: 0x0008723C
		public bool IsEmpty
		{
			get
			{
				return this._Segment.Count == 0;
			}
		}

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06002587 RID: 9607 RVA: 0x0008904C File Offset: 0x0008724C
		public int Length
		{
			get
			{
				return this._Segment.Count;
			}
		}

		// Token: 0x06002588 RID: 9608 RVA: 0x00089059 File Offset: 0x00087259
		public Span<T> Slice(int start)
		{
			if (start < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			return new Span<T>(this._Segment.Array, this._Segment.Offset + start, this._Segment.Count - start);
		}

		// Token: 0x06002589 RID: 9609 RVA: 0x0008908F File Offset: 0x0008728F
		public Span<T> Slice(int start, int length)
		{
			if (start < 0 || length > this._Segment.Count - start)
			{
				throw new ArgumentOutOfRangeException();
			}
			return new Span<T>(this._Segment.Array, this._Segment.Offset + start, length);
		}

		// Token: 0x0600258A RID: 9610 RVA: 0x000890CC File Offset: 0x000872CC
		public void Fill(T value)
		{
			for (int i = this._Segment.Offset; i < this._Segment.Count - this._Segment.Offset; i++)
			{
				this._Segment.Array[i] = value;
			}
		}

		// Token: 0x0600258B RID: 9611 RVA: 0x00089118 File Offset: 0x00087318
		public void Clear()
		{
			for (int i = this._Segment.Offset; i < this._Segment.Count - this._Segment.Offset; i++)
			{
				this._Segment.Array[i] = default(T);
			}
		}

		// Token: 0x0600258C RID: 9612 RVA: 0x0008916C File Offset: 0x0008736C
		public T[] ToArray()
		{
			T[] array = new T[this._Segment.Count];
			if (!this.IsEmpty)
			{
				Array.Copy(this._Segment.Array, this._Segment.Offset, array, 0, this._Segment.Count);
			}
			return array;
		}

		// Token: 0x0600258D RID: 9613 RVA: 0x000891BC File Offset: 0x000873BC
		public void CopyTo(Span<T> destination)
		{
			if (destination.Length < this.Length)
			{
				throw new InvalidOperationException("Destination too short");
			}
			if (!this.IsEmpty)
			{
				ArraySegment<T> arraySegment = destination.DangerousGetArraySegment();
				Array.Copy(this._Segment.Array, this._Segment.Offset, arraySegment.Array, arraySegment.Offset, this._Segment.Count);
			}
		}

		// Token: 0x0600258E RID: 9614 RVA: 0x00089228 File Offset: 0x00087428
		public bool Overlaps(ReadOnlySpan<T> destination, out int elementOffset)
		{
			return this.Overlaps(destination, out elementOffset);
		}

		// Token: 0x0600258F RID: 9615 RVA: 0x0008924A File Offset: 0x0008744A
		public ArraySegment<T> DangerousGetArraySegment()
		{
			return this._Segment;
		}

		// Token: 0x06002590 RID: 9616 RVA: 0x00089252 File Offset: 0x00087452
		public static implicit operator Span<T>(T[] array)
		{
			return new Span<T>(array);
		}

		// Token: 0x06002591 RID: 9617 RVA: 0x0008925A File Offset: 0x0008745A
		public static implicit operator ReadOnlySpan<T>(Span<T> span)
		{
			return new ReadOnlySpan<T>(span._Segment);
		}

		// Token: 0x06002592 RID: 9618 RVA: 0x00089267 File Offset: 0x00087467
		public T[] DangerousGetArrayForPinning()
		{
			return this._Segment.Array;
		}

		// Token: 0x04000E1E RID: 3614
		public static readonly Span<T> Empty;

		// Token: 0x04000E1F RID: 3615
		private ArraySegment<T> _Segment;
	}
}
