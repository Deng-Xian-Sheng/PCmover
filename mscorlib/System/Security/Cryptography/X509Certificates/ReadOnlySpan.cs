using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002D2 RID: 722
	internal struct ReadOnlySpan<T>
	{
		// Token: 0x06002571 RID: 9585 RVA: 0x00088CBB File Offset: 0x00086EBB
		public ReadOnlySpan(ArraySegment<T> segment)
		{
			this._Segment = segment;
		}

		// Token: 0x06002572 RID: 9586 RVA: 0x00088CC4 File Offset: 0x00086EC4
		public ReadOnlySpan(T[] array, int offset, int count)
		{
			this = new ReadOnlySpan<T>((array != null || offset != 0 || count != 0) ? new ArraySegment<T>(array, offset, count) : default(ArraySegment<T>));
		}

		// Token: 0x06002573 RID: 9587 RVA: 0x00088CF4 File Offset: 0x00086EF4
		public ReadOnlySpan(T[] array)
		{
			this = new ReadOnlySpan<T>((array != null) ? new ArraySegment<T>(array) : default(ArraySegment<T>));
		}

		// Token: 0x170004A1 RID: 1185
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
		}

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x06002575 RID: 9589 RVA: 0x00088D57 File Offset: 0x00086F57
		public bool IsEmpty
		{
			get
			{
				return this._Segment.Count == 0;
			}
		}

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06002576 RID: 9590 RVA: 0x00088D67 File Offset: 0x00086F67
		public bool IsNull
		{
			get
			{
				return this._Segment.Array == null;
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06002577 RID: 9591 RVA: 0x00088D77 File Offset: 0x00086F77
		public int Length
		{
			get
			{
				return this._Segment.Count;
			}
		}

		// Token: 0x06002578 RID: 9592 RVA: 0x00088D84 File Offset: 0x00086F84
		public ReadOnlySpan<T> Slice(int start)
		{
			if (start < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			return new ReadOnlySpan<T>(this._Segment.Array, this._Segment.Offset + start, this._Segment.Count - start);
		}

		// Token: 0x06002579 RID: 9593 RVA: 0x00088DBA File Offset: 0x00086FBA
		public ReadOnlySpan<T> Slice(int start, int length)
		{
			if (start < 0)
			{
				throw new InvalidOperationException();
			}
			if (length > this._Segment.Count - start)
			{
				throw new InvalidOperationException();
			}
			return new ReadOnlySpan<T>(this._Segment.Array, this._Segment.Offset + start, length);
		}

		// Token: 0x0600257A RID: 9594 RVA: 0x00088DFC File Offset: 0x00086FFC
		public T[] ToArray()
		{
			T[] array = new T[this._Segment.Count];
			if (!this.IsEmpty)
			{
				Array.Copy(this._Segment.Array, this._Segment.Offset, array, 0, this._Segment.Count);
			}
			return array;
		}

		// Token: 0x0600257B RID: 9595 RVA: 0x00088E4C File Offset: 0x0008704C
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

		// Token: 0x0600257C RID: 9596 RVA: 0x00088EB8 File Offset: 0x000870B8
		public bool Overlaps(ReadOnlySpan<T> destination)
		{
			int num;
			return this.Overlaps(destination, out num);
		}

		// Token: 0x0600257D RID: 9597 RVA: 0x00088ED0 File Offset: 0x000870D0
		public bool Overlaps(ReadOnlySpan<T> destination, out int elementOffset)
		{
			elementOffset = 0;
			if (this.IsEmpty || destination.IsEmpty)
			{
				return false;
			}
			if (this._Segment.Array != destination._Segment.Array)
			{
				return false;
			}
			elementOffset = destination._Segment.Offset - this._Segment.Offset;
			if (elementOffset >= this._Segment.Count || elementOffset <= -destination._Segment.Count)
			{
				elementOffset = 0;
				return false;
			}
			return true;
		}

		// Token: 0x0600257E RID: 9598 RVA: 0x00088F4E File Offset: 0x0008714E
		public ArraySegment<T> DangerousGetArraySegment()
		{
			return this._Segment;
		}

		// Token: 0x0600257F RID: 9599 RVA: 0x00088F56 File Offset: 0x00087156
		public static implicit operator ReadOnlySpan<T>(T[] array)
		{
			return new ReadOnlySpan<T>(array);
		}

		// Token: 0x04000E1C RID: 3612
		public static readonly Span<T> Empty;

		// Token: 0x04000E1D RID: 3613
		private ArraySegment<T> _Segment;
	}
}
