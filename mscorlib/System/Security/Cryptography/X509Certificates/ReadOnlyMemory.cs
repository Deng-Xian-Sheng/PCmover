using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002D4 RID: 724
	internal struct ReadOnlyMemory<T>
	{
		// Token: 0x06002594 RID: 9620 RVA: 0x00089276 File Offset: 0x00087476
		public ReadOnlyMemory(ArraySegment<T> segment)
		{
			this._Segment = segment;
		}

		// Token: 0x06002595 RID: 9621 RVA: 0x00089280 File Offset: 0x00087480
		public ReadOnlyMemory(T[] array, int offset, int count)
		{
			this = new ReadOnlyMemory<T>((array != null || offset != 0 || count != 0) ? new ArraySegment<T>(array, offset, count) : default(ArraySegment<T>));
		}

		// Token: 0x06002596 RID: 9622 RVA: 0x000892B0 File Offset: 0x000874B0
		public ReadOnlyMemory(T[] array)
		{
			this = new ReadOnlyMemory<T>((array != null) ? new ArraySegment<T>(array) : default(ArraySegment<T>));
		}

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06002597 RID: 9623 RVA: 0x000892D8 File Offset: 0x000874D8
		public bool IsEmpty
		{
			get
			{
				return this._Segment.Count == 0;
			}
		}

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06002598 RID: 9624 RVA: 0x000892F8 File Offset: 0x000874F8
		public int Length
		{
			get
			{
				return this._Segment.Count;
			}
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06002599 RID: 9625 RVA: 0x00089313 File Offset: 0x00087513
		public ReadOnlySpan<T> Span
		{
			get
			{
				return new ReadOnlySpan<T>(this._Segment);
			}
		}

		// Token: 0x0600259A RID: 9626 RVA: 0x00089320 File Offset: 0x00087520
		public ReadOnlyMemory<T> Slice(int start)
		{
			if (start < 0)
			{
				throw new InvalidOperationException();
			}
			return new ReadOnlyMemory<T>(this._Segment.Array, this._Segment.Offset + start, this._Segment.Count - start);
		}

		// Token: 0x0600259B RID: 9627 RVA: 0x0008936C File Offset: 0x0008756C
		public ReadOnlyMemory<T> Slice(int start, int length)
		{
			if (start < 0)
			{
				throw new InvalidOperationException();
			}
			if (length > this._Segment.Count - start)
			{
				throw new InvalidOperationException();
			}
			return new ReadOnlyMemory<T>(this._Segment.Array, this._Segment.Offset + start, length);
		}

		// Token: 0x0600259C RID: 9628 RVA: 0x000893C0 File Offset: 0x000875C0
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

		// Token: 0x0600259D RID: 9629 RVA: 0x00089434 File Offset: 0x00087634
		public static implicit operator ReadOnlyMemory<T>(T[] array)
		{
			return new ReadOnlyMemory<T>(array);
		}

		// Token: 0x0600259E RID: 9630 RVA: 0x0008943C File Offset: 0x0008763C
		public static implicit operator ArraySegment<T>(ReadOnlyMemory<T> memory)
		{
			return memory._Segment;
		}

		// Token: 0x0600259F RID: 9631 RVA: 0x00089444 File Offset: 0x00087644
		public static implicit operator ReadOnlyMemory<T>(ArraySegment<T> segment)
		{
			return new ReadOnlyMemory<T>(segment);
		}

		// Token: 0x04000E20 RID: 3616
		private readonly ArraySegment<T> _Segment;
	}
}
