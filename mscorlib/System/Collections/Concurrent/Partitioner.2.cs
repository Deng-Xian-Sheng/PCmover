using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;

namespace System.Collections.Concurrent
{
	// Token: 0x020004B3 RID: 1203
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public static class Partitioner
	{
		// Token: 0x06003998 RID: 14744 RVA: 0x000DC83E File Offset: 0x000DAA3E
		[__DynamicallyInvokable]
		public static OrderablePartitioner<TSource> Create<TSource>(IList<TSource> list, bool loadBalance)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}
			if (loadBalance)
			{
				return new Partitioner.DynamicPartitionerForIList<TSource>(list);
			}
			return new Partitioner.StaticIndexRangePartitionerForIList<TSource>(list);
		}

		// Token: 0x06003999 RID: 14745 RVA: 0x000DC85E File Offset: 0x000DAA5E
		[__DynamicallyInvokable]
		public static OrderablePartitioner<TSource> Create<TSource>(TSource[] array, bool loadBalance)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (loadBalance)
			{
				return new Partitioner.DynamicPartitionerForArray<TSource>(array);
			}
			return new Partitioner.StaticIndexRangePartitionerForArray<TSource>(array);
		}

		// Token: 0x0600399A RID: 14746 RVA: 0x000DC87E File Offset: 0x000DAA7E
		[__DynamicallyInvokable]
		public static OrderablePartitioner<TSource> Create<TSource>(IEnumerable<TSource> source)
		{
			return Partitioner.Create<TSource>(source, EnumerablePartitionerOptions.None);
		}

		// Token: 0x0600399B RID: 14747 RVA: 0x000DC887 File Offset: 0x000DAA87
		[__DynamicallyInvokable]
		public static OrderablePartitioner<TSource> Create<TSource>(IEnumerable<TSource> source, EnumerablePartitionerOptions partitionerOptions)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if ((partitionerOptions & ~EnumerablePartitionerOptions.NoBuffering) != EnumerablePartitionerOptions.None)
			{
				throw new ArgumentOutOfRangeException("partitionerOptions");
			}
			return new Partitioner.DynamicPartitionerForIEnumerable<TSource>(source, partitionerOptions);
		}

		// Token: 0x0600399C RID: 14748 RVA: 0x000DC8B0 File Offset: 0x000DAAB0
		[__DynamicallyInvokable]
		public static OrderablePartitioner<Tuple<long, long>> Create(long fromInclusive, long toExclusive)
		{
			int num = 3;
			if (toExclusive <= fromInclusive)
			{
				throw new ArgumentOutOfRangeException("toExclusive");
			}
			long num2 = (toExclusive - fromInclusive) / (long)(PlatformHelper.ProcessorCount * num);
			if (num2 == 0L)
			{
				num2 = 1L;
			}
			return Partitioner.Create<Tuple<long, long>>(Partitioner.CreateRanges(fromInclusive, toExclusive, num2), EnumerablePartitionerOptions.NoBuffering);
		}

		// Token: 0x0600399D RID: 14749 RVA: 0x000DC8EF File Offset: 0x000DAAEF
		[__DynamicallyInvokable]
		public static OrderablePartitioner<Tuple<long, long>> Create(long fromInclusive, long toExclusive, long rangeSize)
		{
			if (toExclusive <= fromInclusive)
			{
				throw new ArgumentOutOfRangeException("toExclusive");
			}
			if (rangeSize <= 0L)
			{
				throw new ArgumentOutOfRangeException("rangeSize");
			}
			return Partitioner.Create<Tuple<long, long>>(Partitioner.CreateRanges(fromInclusive, toExclusive, rangeSize), EnumerablePartitionerOptions.NoBuffering);
		}

		// Token: 0x0600399E RID: 14750 RVA: 0x000DC91E File Offset: 0x000DAB1E
		private static IEnumerable<Tuple<long, long>> CreateRanges(long fromInclusive, long toExclusive, long rangeSize)
		{
			bool shouldQuit = false;
			long i = fromInclusive;
			while (i < toExclusive && !shouldQuit)
			{
				long item = i;
				long num;
				try
				{
					num = checked(i + rangeSize);
				}
				catch (OverflowException)
				{
					num = toExclusive;
					shouldQuit = true;
				}
				if (num > toExclusive)
				{
					num = toExclusive;
				}
				yield return new Tuple<long, long>(item, num);
				i += rangeSize;
			}
			yield break;
		}

		// Token: 0x0600399F RID: 14751 RVA: 0x000DC93C File Offset: 0x000DAB3C
		[__DynamicallyInvokable]
		public static OrderablePartitioner<Tuple<int, int>> Create(int fromInclusive, int toExclusive)
		{
			int num = 3;
			if (toExclusive <= fromInclusive)
			{
				throw new ArgumentOutOfRangeException("toExclusive");
			}
			int num2 = (toExclusive - fromInclusive) / (PlatformHelper.ProcessorCount * num);
			if (num2 == 0)
			{
				num2 = 1;
			}
			return Partitioner.Create<Tuple<int, int>>(Partitioner.CreateRanges(fromInclusive, toExclusive, num2), EnumerablePartitionerOptions.NoBuffering);
		}

		// Token: 0x060039A0 RID: 14752 RVA: 0x000DC979 File Offset: 0x000DAB79
		[__DynamicallyInvokable]
		public static OrderablePartitioner<Tuple<int, int>> Create(int fromInclusive, int toExclusive, int rangeSize)
		{
			if (toExclusive <= fromInclusive)
			{
				throw new ArgumentOutOfRangeException("toExclusive");
			}
			if (rangeSize <= 0)
			{
				throw new ArgumentOutOfRangeException("rangeSize");
			}
			return Partitioner.Create<Tuple<int, int>>(Partitioner.CreateRanges(fromInclusive, toExclusive, rangeSize), EnumerablePartitionerOptions.NoBuffering);
		}

		// Token: 0x060039A1 RID: 14753 RVA: 0x000DC9A7 File Offset: 0x000DABA7
		private static IEnumerable<Tuple<int, int>> CreateRanges(int fromInclusive, int toExclusive, int rangeSize)
		{
			bool shouldQuit = false;
			int i = fromInclusive;
			while (i < toExclusive && !shouldQuit)
			{
				int item = i;
				int num;
				try
				{
					num = checked(i + rangeSize);
				}
				catch (OverflowException)
				{
					num = toExclusive;
					shouldQuit = true;
				}
				if (num > toExclusive)
				{
					num = toExclusive;
				}
				yield return new Tuple<int, int>(item, num);
				i += rangeSize;
			}
			yield break;
		}

		// Token: 0x060039A2 RID: 14754 RVA: 0x000DC9C8 File Offset: 0x000DABC8
		private static int GetDefaultChunkSize<TSource>()
		{
			int result;
			if (typeof(TSource).IsValueType)
			{
				if (typeof(TSource).StructLayoutAttribute.Value == LayoutKind.Explicit)
				{
					result = Math.Max(1, 512 / Marshal.SizeOf(typeof(TSource)));
				}
				else
				{
					result = 128;
				}
			}
			else
			{
				result = 512 / IntPtr.Size;
			}
			return result;
		}

		// Token: 0x0400192B RID: 6443
		private const int DEFAULT_BYTES_PER_CHUNK = 512;

		// Token: 0x02000BCA RID: 3018
		private abstract class DynamicPartitionEnumerator_Abstract<TSource, TSourceReader> : IEnumerator<KeyValuePair<long, TSource>>, IDisposable, IEnumerator
		{
			// Token: 0x06006E97 RID: 28311 RVA: 0x0017DA1B File Offset: 0x0017BC1B
			protected DynamicPartitionEnumerator_Abstract(TSourceReader sharedReader, Partitioner.SharedLong sharedIndex) : this(sharedReader, sharedIndex, false)
			{
			}

			// Token: 0x06006E98 RID: 28312 RVA: 0x0017DA26 File Offset: 0x0017BC26
			protected DynamicPartitionEnumerator_Abstract(TSourceReader sharedReader, Partitioner.SharedLong sharedIndex, bool useSingleChunking)
			{
				this.m_sharedReader = sharedReader;
				this.m_sharedIndex = sharedIndex;
				this.m_maxChunkSize = (useSingleChunking ? 1 : Partitioner.DynamicPartitionEnumerator_Abstract<TSource, TSourceReader>.s_defaultMaxChunkSize);
			}

			// Token: 0x06006E99 RID: 28313
			protected abstract bool GrabNextChunk(int requestedChunkSize);

			// Token: 0x170012EB RID: 4843
			// (get) Token: 0x06006E9A RID: 28314
			// (set) Token: 0x06006E9B RID: 28315
			protected abstract bool HasNoElementsLeft { get; set; }

			// Token: 0x170012EC RID: 4844
			// (get) Token: 0x06006E9C RID: 28316
			public abstract KeyValuePair<long, TSource> Current { get; }

			// Token: 0x06006E9D RID: 28317
			public abstract void Dispose();

			// Token: 0x06006E9E RID: 28318 RVA: 0x0017DA4D File Offset: 0x0017BC4D
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x170012ED RID: 4845
			// (get) Token: 0x06006E9F RID: 28319 RVA: 0x0017DA54 File Offset: 0x0017BC54
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x06006EA0 RID: 28320 RVA: 0x0017DA64 File Offset: 0x0017BC64
			public bool MoveNext()
			{
				if (this.m_localOffset == null)
				{
					this.m_localOffset = new Partitioner.SharedInt(-1);
					this.m_currentChunkSize = new Partitioner.SharedInt(0);
					this.m_doublingCountdown = 3;
				}
				if (this.m_localOffset.Value < this.m_currentChunkSize.Value - 1)
				{
					this.m_localOffset.Value++;
					return true;
				}
				int requestedChunkSize;
				if (this.m_currentChunkSize.Value == 0)
				{
					requestedChunkSize = 1;
				}
				else if (this.m_doublingCountdown > 0)
				{
					requestedChunkSize = this.m_currentChunkSize.Value;
				}
				else
				{
					requestedChunkSize = Math.Min(this.m_currentChunkSize.Value * 2, this.m_maxChunkSize);
					this.m_doublingCountdown = 3;
				}
				this.m_doublingCountdown--;
				if (this.GrabNextChunk(requestedChunkSize))
				{
					this.m_localOffset.Value = 0;
					return true;
				}
				return false;
			}

			// Token: 0x040035B3 RID: 13747
			protected readonly TSourceReader m_sharedReader;

			// Token: 0x040035B4 RID: 13748
			protected static int s_defaultMaxChunkSize = Partitioner.GetDefaultChunkSize<TSource>();

			// Token: 0x040035B5 RID: 13749
			protected Partitioner.SharedInt m_currentChunkSize;

			// Token: 0x040035B6 RID: 13750
			protected Partitioner.SharedInt m_localOffset;

			// Token: 0x040035B7 RID: 13751
			private const int CHUNK_DOUBLING_RATE = 3;

			// Token: 0x040035B8 RID: 13752
			private int m_doublingCountdown;

			// Token: 0x040035B9 RID: 13753
			protected readonly int m_maxChunkSize;

			// Token: 0x040035BA RID: 13754
			protected readonly Partitioner.SharedLong m_sharedIndex;
		}

		// Token: 0x02000BCB RID: 3019
		private class DynamicPartitionerForIEnumerable<TSource> : OrderablePartitioner<TSource>
		{
			// Token: 0x06006EA2 RID: 28322 RVA: 0x0017DB51 File Offset: 0x0017BD51
			internal DynamicPartitionerForIEnumerable(IEnumerable<TSource> source, EnumerablePartitionerOptions partitionerOptions) : base(true, false, true)
			{
				this.m_source = source;
				this.m_useSingleChunking = ((partitionerOptions & EnumerablePartitionerOptions.NoBuffering) > EnumerablePartitionerOptions.None);
			}

			// Token: 0x06006EA3 RID: 28323 RVA: 0x0017DB70 File Offset: 0x0017BD70
			public override IList<IEnumerator<KeyValuePair<long, TSource>>> GetOrderablePartitions(int partitionCount)
			{
				if (partitionCount <= 0)
				{
					throw new ArgumentOutOfRangeException("partitionCount");
				}
				IEnumerator<KeyValuePair<long, TSource>>[] array = new IEnumerator<KeyValuePair<long, TSource>>[partitionCount];
				IEnumerable<KeyValuePair<long, TSource>> enumerable = new Partitioner.DynamicPartitionerForIEnumerable<TSource>.InternalPartitionEnumerable(this.m_source.GetEnumerator(), this.m_useSingleChunking, true);
				for (int i = 0; i < partitionCount; i++)
				{
					array[i] = enumerable.GetEnumerator();
				}
				return array;
			}

			// Token: 0x06006EA4 RID: 28324 RVA: 0x0017DBC1 File Offset: 0x0017BDC1
			public override IEnumerable<KeyValuePair<long, TSource>> GetOrderableDynamicPartitions()
			{
				return new Partitioner.DynamicPartitionerForIEnumerable<TSource>.InternalPartitionEnumerable(this.m_source.GetEnumerator(), this.m_useSingleChunking, false);
			}

			// Token: 0x170012EE RID: 4846
			// (get) Token: 0x06006EA5 RID: 28325 RVA: 0x0017DBDA File Offset: 0x0017BDDA
			public override bool SupportsDynamicPartitions
			{
				get
				{
					return true;
				}
			}

			// Token: 0x040035BB RID: 13755
			private IEnumerable<TSource> m_source;

			// Token: 0x040035BC RID: 13756
			private readonly bool m_useSingleChunking;

			// Token: 0x02000D04 RID: 3332
			private class InternalPartitionEnumerable : IEnumerable<KeyValuePair<long, TSource>>, IEnumerable, IDisposable
			{
				// Token: 0x060071F5 RID: 29173 RVA: 0x00188B7C File Offset: 0x00186D7C
				internal InternalPartitionEnumerable(IEnumerator<TSource> sharedReader, bool useSingleChunking, bool isStaticPartitioning)
				{
					this.m_sharedReader = sharedReader;
					this.m_sharedIndex = new Partitioner.SharedLong(-1L);
					this.m_hasNoElementsLeft = new Partitioner.SharedBool(false);
					this.m_sourceDepleted = new Partitioner.SharedBool(false);
					this.m_sharedLock = new object();
					this.m_useSingleChunking = useSingleChunking;
					if (!this.m_useSingleChunking)
					{
						int num = (PlatformHelper.ProcessorCount > 4) ? 4 : 1;
						this.m_FillBuffer = new KeyValuePair<long, TSource>[num * Partitioner.GetDefaultChunkSize<TSource>()];
					}
					if (isStaticPartitioning)
					{
						this.m_activePartitionCount = new Partitioner.SharedInt(0);
						return;
					}
					this.m_activePartitionCount = null;
				}

				// Token: 0x060071F6 RID: 29174 RVA: 0x00188C10 File Offset: 0x00186E10
				public IEnumerator<KeyValuePair<long, TSource>> GetEnumerator()
				{
					if (this.m_disposed)
					{
						throw new ObjectDisposedException(Environment.GetResourceString("PartitionerStatic_CanNotCallGetEnumeratorAfterSourceHasBeenDisposed"));
					}
					return new Partitioner.DynamicPartitionerForIEnumerable<TSource>.InternalPartitionEnumerator(this.m_sharedReader, this.m_sharedIndex, this.m_hasNoElementsLeft, this.m_sharedLock, this.m_activePartitionCount, this, this.m_useSingleChunking);
				}

				// Token: 0x060071F7 RID: 29175 RVA: 0x00188C5F File Offset: 0x00186E5F
				IEnumerator IEnumerable.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x060071F8 RID: 29176 RVA: 0x00188C68 File Offset: 0x00186E68
				private void TryCopyFromFillBuffer(KeyValuePair<long, TSource>[] destArray, int requestedChunkSize, ref int actualNumElementsGrabbed)
				{
					actualNumElementsGrabbed = 0;
					KeyValuePair<long, TSource>[] fillBuffer = this.m_FillBuffer;
					if (fillBuffer == null)
					{
						return;
					}
					if (this.m_FillBufferCurrentPosition >= this.m_FillBufferSize)
					{
						return;
					}
					Interlocked.Increment(ref this.m_activeCopiers);
					int num = Interlocked.Add(ref this.m_FillBufferCurrentPosition, requestedChunkSize);
					int num2 = num - requestedChunkSize;
					if (num2 < this.m_FillBufferSize)
					{
						actualNumElementsGrabbed = ((num < this.m_FillBufferSize) ? num : (this.m_FillBufferSize - num2));
						Array.Copy(fillBuffer, num2, destArray, 0, actualNumElementsGrabbed);
					}
					Interlocked.Decrement(ref this.m_activeCopiers);
				}

				// Token: 0x060071F9 RID: 29177 RVA: 0x00188CF1 File Offset: 0x00186EF1
				internal bool GrabChunk(KeyValuePair<long, TSource>[] destArray, int requestedChunkSize, ref int actualNumElementsGrabbed)
				{
					actualNumElementsGrabbed = 0;
					if (this.m_hasNoElementsLeft.Value)
					{
						return false;
					}
					if (this.m_useSingleChunking)
					{
						return this.GrabChunk_Single(destArray, requestedChunkSize, ref actualNumElementsGrabbed);
					}
					return this.GrabChunk_Buffered(destArray, requestedChunkSize, ref actualNumElementsGrabbed);
				}

				// Token: 0x060071FA RID: 29178 RVA: 0x00188D24 File Offset: 0x00186F24
				internal bool GrabChunk_Single(KeyValuePair<long, TSource>[] destArray, int requestedChunkSize, ref int actualNumElementsGrabbed)
				{
					object sharedLock = this.m_sharedLock;
					bool result;
					lock (sharedLock)
					{
						if (this.m_hasNoElementsLeft.Value)
						{
							result = false;
						}
						else
						{
							try
							{
								if (this.m_sharedReader.MoveNext())
								{
									this.m_sharedIndex.Value = checked(this.m_sharedIndex.Value + 1L);
									destArray[0] = new KeyValuePair<long, TSource>(this.m_sharedIndex.Value, this.m_sharedReader.Current);
									actualNumElementsGrabbed = 1;
									result = true;
								}
								else
								{
									this.m_sourceDepleted.Value = true;
									this.m_hasNoElementsLeft.Value = true;
									result = false;
								}
							}
							catch
							{
								this.m_sourceDepleted.Value = true;
								this.m_hasNoElementsLeft.Value = true;
								throw;
							}
						}
					}
					return result;
				}

				// Token: 0x060071FB RID: 29179 RVA: 0x00188E10 File Offset: 0x00187010
				internal bool GrabChunk_Buffered(KeyValuePair<long, TSource>[] destArray, int requestedChunkSize, ref int actualNumElementsGrabbed)
				{
					this.TryCopyFromFillBuffer(destArray, requestedChunkSize, ref actualNumElementsGrabbed);
					if (actualNumElementsGrabbed == requestedChunkSize)
					{
						return true;
					}
					if (this.m_sourceDepleted.Value)
					{
						this.m_hasNoElementsLeft.Value = true;
						this.m_FillBuffer = null;
						return actualNumElementsGrabbed > 0;
					}
					object sharedLock = this.m_sharedLock;
					lock (sharedLock)
					{
						if (this.m_sourceDepleted.Value)
						{
							return actualNumElementsGrabbed > 0;
						}
						try
						{
							if (this.m_activeCopiers > 0)
							{
								SpinWait spinWait = default(SpinWait);
								while (this.m_activeCopiers > 0)
								{
									spinWait.SpinOnce();
								}
							}
							while (actualNumElementsGrabbed < requestedChunkSize)
							{
								if (!this.m_sharedReader.MoveNext())
								{
									this.m_sourceDepleted.Value = true;
									break;
								}
								this.m_sharedIndex.Value = checked(this.m_sharedIndex.Value + 1L);
								destArray[actualNumElementsGrabbed] = new KeyValuePair<long, TSource>(this.m_sharedIndex.Value, this.m_sharedReader.Current);
								actualNumElementsGrabbed++;
							}
							KeyValuePair<long, TSource>[] fillBuffer = this.m_FillBuffer;
							if (!this.m_sourceDepleted.Value && fillBuffer != null && this.m_FillBufferCurrentPosition >= fillBuffer.Length)
							{
								for (int i = 0; i < fillBuffer.Length; i++)
								{
									if (!this.m_sharedReader.MoveNext())
									{
										this.m_sourceDepleted.Value = true;
										this.m_FillBufferSize = i;
										break;
									}
									this.m_sharedIndex.Value = checked(this.m_sharedIndex.Value + 1L);
									fillBuffer[i] = new KeyValuePair<long, TSource>(this.m_sharedIndex.Value, this.m_sharedReader.Current);
								}
								this.m_FillBufferCurrentPosition = 0;
							}
						}
						catch
						{
							this.m_sourceDepleted.Value = true;
							this.m_hasNoElementsLeft.Value = true;
							throw;
						}
					}
					return actualNumElementsGrabbed > 0;
				}

				// Token: 0x060071FC RID: 29180 RVA: 0x0018902C File Offset: 0x0018722C
				public void Dispose()
				{
					if (!this.m_disposed)
					{
						this.m_disposed = true;
						this.m_sharedReader.Dispose();
					}
				}

				// Token: 0x0400393B RID: 14651
				private readonly IEnumerator<TSource> m_sharedReader;

				// Token: 0x0400393C RID: 14652
				private Partitioner.SharedLong m_sharedIndex;

				// Token: 0x0400393D RID: 14653
				private volatile KeyValuePair<long, TSource>[] m_FillBuffer;

				// Token: 0x0400393E RID: 14654
				private volatile int m_FillBufferSize;

				// Token: 0x0400393F RID: 14655
				private volatile int m_FillBufferCurrentPosition;

				// Token: 0x04003940 RID: 14656
				private volatile int m_activeCopiers;

				// Token: 0x04003941 RID: 14657
				private Partitioner.SharedBool m_hasNoElementsLeft;

				// Token: 0x04003942 RID: 14658
				private Partitioner.SharedBool m_sourceDepleted;

				// Token: 0x04003943 RID: 14659
				private object m_sharedLock;

				// Token: 0x04003944 RID: 14660
				private bool m_disposed;

				// Token: 0x04003945 RID: 14661
				private Partitioner.SharedInt m_activePartitionCount;

				// Token: 0x04003946 RID: 14662
				private readonly bool m_useSingleChunking;
			}

			// Token: 0x02000D05 RID: 3333
			private class InternalPartitionEnumerator : Partitioner.DynamicPartitionEnumerator_Abstract<TSource, IEnumerator<TSource>>
			{
				// Token: 0x060071FD RID: 29181 RVA: 0x00189048 File Offset: 0x00187248
				internal InternalPartitionEnumerator(IEnumerator<TSource> sharedReader, Partitioner.SharedLong sharedIndex, Partitioner.SharedBool hasNoElementsLeft, object sharedLock, Partitioner.SharedInt activePartitionCount, Partitioner.DynamicPartitionerForIEnumerable<TSource>.InternalPartitionEnumerable enumerable, bool useSingleChunking) : base(sharedReader, sharedIndex, useSingleChunking)
				{
					this.m_hasNoElementsLeft = hasNoElementsLeft;
					this.m_sharedLock = sharedLock;
					this.m_enumerable = enumerable;
					this.m_activePartitionCount = activePartitionCount;
					if (this.m_activePartitionCount != null)
					{
						Interlocked.Increment(ref this.m_activePartitionCount.Value);
					}
				}

				// Token: 0x060071FE RID: 29182 RVA: 0x00189098 File Offset: 0x00187298
				protected override bool GrabNextChunk(int requestedChunkSize)
				{
					if (this.HasNoElementsLeft)
					{
						return false;
					}
					if (this.m_localList == null)
					{
						this.m_localList = new KeyValuePair<long, TSource>[this.m_maxChunkSize];
					}
					return this.m_enumerable.GrabChunk(this.m_localList, requestedChunkSize, ref this.m_currentChunkSize.Value);
				}

				// Token: 0x17001386 RID: 4998
				// (get) Token: 0x060071FF RID: 29183 RVA: 0x001890E5 File Offset: 0x001872E5
				// (set) Token: 0x06007200 RID: 29184 RVA: 0x001890F4 File Offset: 0x001872F4
				protected override bool HasNoElementsLeft
				{
					get
					{
						return this.m_hasNoElementsLeft.Value;
					}
					set
					{
						this.m_hasNoElementsLeft.Value = true;
					}
				}

				// Token: 0x17001387 RID: 4999
				// (get) Token: 0x06007201 RID: 29185 RVA: 0x00189104 File Offset: 0x00187304
				public override KeyValuePair<long, TSource> Current
				{
					get
					{
						if (this.m_currentChunkSize == null)
						{
							throw new InvalidOperationException(Environment.GetResourceString("PartitionerStatic_CurrentCalledBeforeMoveNext"));
						}
						return this.m_localList[this.m_localOffset.Value];
					}
				}

				// Token: 0x06007202 RID: 29186 RVA: 0x00189136 File Offset: 0x00187336
				public override void Dispose()
				{
					if (this.m_activePartitionCount != null && Interlocked.Decrement(ref this.m_activePartitionCount.Value) == 0)
					{
						this.m_enumerable.Dispose();
					}
				}

				// Token: 0x04003947 RID: 14663
				private KeyValuePair<long, TSource>[] m_localList;

				// Token: 0x04003948 RID: 14664
				private readonly Partitioner.SharedBool m_hasNoElementsLeft;

				// Token: 0x04003949 RID: 14665
				private readonly object m_sharedLock;

				// Token: 0x0400394A RID: 14666
				private readonly Partitioner.SharedInt m_activePartitionCount;

				// Token: 0x0400394B RID: 14667
				private Partitioner.DynamicPartitionerForIEnumerable<TSource>.InternalPartitionEnumerable m_enumerable;
			}
		}

		// Token: 0x02000BCC RID: 3020
		private abstract class DynamicPartitionerForIndexRange_Abstract<TSource, TCollection> : OrderablePartitioner<TSource>
		{
			// Token: 0x06006EA6 RID: 28326 RVA: 0x0017DBDD File Offset: 0x0017BDDD
			protected DynamicPartitionerForIndexRange_Abstract(TCollection data) : base(true, false, true)
			{
				this.m_data = data;
			}

			// Token: 0x06006EA7 RID: 28327
			protected abstract IEnumerable<KeyValuePair<long, TSource>> GetOrderableDynamicPartitions_Factory(TCollection data);

			// Token: 0x06006EA8 RID: 28328 RVA: 0x0017DBF0 File Offset: 0x0017BDF0
			public override IList<IEnumerator<KeyValuePair<long, TSource>>> GetOrderablePartitions(int partitionCount)
			{
				if (partitionCount <= 0)
				{
					throw new ArgumentOutOfRangeException("partitionCount");
				}
				IEnumerator<KeyValuePair<long, TSource>>[] array = new IEnumerator<KeyValuePair<long, TSource>>[partitionCount];
				IEnumerable<KeyValuePair<long, TSource>> orderableDynamicPartitions_Factory = this.GetOrderableDynamicPartitions_Factory(this.m_data);
				for (int i = 0; i < partitionCount; i++)
				{
					array[i] = orderableDynamicPartitions_Factory.GetEnumerator();
				}
				return array;
			}

			// Token: 0x06006EA9 RID: 28329 RVA: 0x0017DC36 File Offset: 0x0017BE36
			public override IEnumerable<KeyValuePair<long, TSource>> GetOrderableDynamicPartitions()
			{
				return this.GetOrderableDynamicPartitions_Factory(this.m_data);
			}

			// Token: 0x170012EF RID: 4847
			// (get) Token: 0x06006EAA RID: 28330 RVA: 0x0017DC44 File Offset: 0x0017BE44
			public override bool SupportsDynamicPartitions
			{
				get
				{
					return true;
				}
			}

			// Token: 0x040035BD RID: 13757
			private TCollection m_data;
		}

		// Token: 0x02000BCD RID: 3021
		private abstract class DynamicPartitionEnumeratorForIndexRange_Abstract<TSource, TSourceReader> : Partitioner.DynamicPartitionEnumerator_Abstract<TSource, TSourceReader>
		{
			// Token: 0x06006EAB RID: 28331 RVA: 0x0017DC47 File Offset: 0x0017BE47
			protected DynamicPartitionEnumeratorForIndexRange_Abstract(TSourceReader sharedReader, Partitioner.SharedLong sharedIndex) : base(sharedReader, sharedIndex)
			{
			}

			// Token: 0x170012F0 RID: 4848
			// (get) Token: 0x06006EAC RID: 28332
			protected abstract int SourceCount { get; }

			// Token: 0x06006EAD RID: 28333 RVA: 0x0017DC54 File Offset: 0x0017BE54
			protected override bool GrabNextChunk(int requestedChunkSize)
			{
				while (!this.HasNoElementsLeft)
				{
					long num = Volatile.Read(ref this.m_sharedIndex.Value);
					if (this.HasNoElementsLeft)
					{
						return false;
					}
					long num2 = Math.Min((long)(this.SourceCount - 1), num + (long)requestedChunkSize);
					if (Interlocked.CompareExchange(ref this.m_sharedIndex.Value, num2, num) == num)
					{
						this.m_currentChunkSize.Value = (int)(num2 - num);
						this.m_localOffset.Value = -1;
						this.m_startIndex = (int)(num + 1L);
						return true;
					}
				}
				return false;
			}

			// Token: 0x170012F1 RID: 4849
			// (get) Token: 0x06006EAE RID: 28334 RVA: 0x0017DCDB File Offset: 0x0017BEDB
			// (set) Token: 0x06006EAF RID: 28335 RVA: 0x0017DCFB File Offset: 0x0017BEFB
			protected override bool HasNoElementsLeft
			{
				get
				{
					return Volatile.Read(ref this.m_sharedIndex.Value) >= (long)(this.SourceCount - 1);
				}
				set
				{
				}
			}

			// Token: 0x06006EB0 RID: 28336 RVA: 0x0017DCFD File Offset: 0x0017BEFD
			public override void Dispose()
			{
			}

			// Token: 0x040035BE RID: 13758
			protected int m_startIndex;
		}

		// Token: 0x02000BCE RID: 3022
		private class DynamicPartitionerForIList<TSource> : Partitioner.DynamicPartitionerForIndexRange_Abstract<TSource, IList<TSource>>
		{
			// Token: 0x06006EB1 RID: 28337 RVA: 0x0017DCFF File Offset: 0x0017BEFF
			internal DynamicPartitionerForIList(IList<TSource> source) : base(source)
			{
			}

			// Token: 0x06006EB2 RID: 28338 RVA: 0x0017DD08 File Offset: 0x0017BF08
			protected override IEnumerable<KeyValuePair<long, TSource>> GetOrderableDynamicPartitions_Factory(IList<TSource> m_data)
			{
				return new Partitioner.DynamicPartitionerForIList<TSource>.InternalPartitionEnumerable(m_data);
			}

			// Token: 0x02000D06 RID: 3334
			private class InternalPartitionEnumerable : IEnumerable<KeyValuePair<long, TSource>>, IEnumerable
			{
				// Token: 0x06007203 RID: 29187 RVA: 0x0018915D File Offset: 0x0018735D
				internal InternalPartitionEnumerable(IList<TSource> sharedReader)
				{
					this.m_sharedReader = sharedReader;
					this.m_sharedIndex = new Partitioner.SharedLong(-1L);
				}

				// Token: 0x06007204 RID: 29188 RVA: 0x00189179 File Offset: 0x00187379
				public IEnumerator<KeyValuePair<long, TSource>> GetEnumerator()
				{
					return new Partitioner.DynamicPartitionerForIList<TSource>.InternalPartitionEnumerator(this.m_sharedReader, this.m_sharedIndex);
				}

				// Token: 0x06007205 RID: 29189 RVA: 0x0018918C File Offset: 0x0018738C
				IEnumerator IEnumerable.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x0400394C RID: 14668
				private readonly IList<TSource> m_sharedReader;

				// Token: 0x0400394D RID: 14669
				private Partitioner.SharedLong m_sharedIndex;
			}

			// Token: 0x02000D07 RID: 3335
			private class InternalPartitionEnumerator : Partitioner.DynamicPartitionEnumeratorForIndexRange_Abstract<TSource, IList<TSource>>
			{
				// Token: 0x06007206 RID: 29190 RVA: 0x00189194 File Offset: 0x00187394
				internal InternalPartitionEnumerator(IList<TSource> sharedReader, Partitioner.SharedLong sharedIndex) : base(sharedReader, sharedIndex)
				{
				}

				// Token: 0x17001388 RID: 5000
				// (get) Token: 0x06007207 RID: 29191 RVA: 0x0018919E File Offset: 0x0018739E
				protected override int SourceCount
				{
					get
					{
						return this.m_sharedReader.Count;
					}
				}

				// Token: 0x17001389 RID: 5001
				// (get) Token: 0x06007208 RID: 29192 RVA: 0x001891AC File Offset: 0x001873AC
				public override KeyValuePair<long, TSource> Current
				{
					get
					{
						if (this.m_currentChunkSize == null)
						{
							throw new InvalidOperationException(Environment.GetResourceString("PartitionerStatic_CurrentCalledBeforeMoveNext"));
						}
						return new KeyValuePair<long, TSource>((long)(this.m_startIndex + this.m_localOffset.Value), this.m_sharedReader[this.m_startIndex + this.m_localOffset.Value]);
					}
				}
			}
		}

		// Token: 0x02000BCF RID: 3023
		private class DynamicPartitionerForArray<TSource> : Partitioner.DynamicPartitionerForIndexRange_Abstract<TSource, TSource[]>
		{
			// Token: 0x06006EB3 RID: 28339 RVA: 0x0017DD10 File Offset: 0x0017BF10
			internal DynamicPartitionerForArray(TSource[] source) : base(source)
			{
			}

			// Token: 0x06006EB4 RID: 28340 RVA: 0x0017DD19 File Offset: 0x0017BF19
			protected override IEnumerable<KeyValuePair<long, TSource>> GetOrderableDynamicPartitions_Factory(TSource[] m_data)
			{
				return new Partitioner.DynamicPartitionerForArray<TSource>.InternalPartitionEnumerable(m_data);
			}

			// Token: 0x02000D08 RID: 3336
			private class InternalPartitionEnumerable : IEnumerable<KeyValuePair<long, TSource>>, IEnumerable
			{
				// Token: 0x06007209 RID: 29193 RVA: 0x0018920A File Offset: 0x0018740A
				internal InternalPartitionEnumerable(TSource[] sharedReader)
				{
					this.m_sharedReader = sharedReader;
					this.m_sharedIndex = new Partitioner.SharedLong(-1L);
				}

				// Token: 0x0600720A RID: 29194 RVA: 0x00189226 File Offset: 0x00187426
				IEnumerator IEnumerable.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x0600720B RID: 29195 RVA: 0x0018922E File Offset: 0x0018742E
				public IEnumerator<KeyValuePair<long, TSource>> GetEnumerator()
				{
					return new Partitioner.DynamicPartitionerForArray<TSource>.InternalPartitionEnumerator(this.m_sharedReader, this.m_sharedIndex);
				}

				// Token: 0x0400394E RID: 14670
				private readonly TSource[] m_sharedReader;

				// Token: 0x0400394F RID: 14671
				private Partitioner.SharedLong m_sharedIndex;
			}

			// Token: 0x02000D09 RID: 3337
			private class InternalPartitionEnumerator : Partitioner.DynamicPartitionEnumeratorForIndexRange_Abstract<TSource, TSource[]>
			{
				// Token: 0x0600720C RID: 29196 RVA: 0x00189241 File Offset: 0x00187441
				internal InternalPartitionEnumerator(TSource[] sharedReader, Partitioner.SharedLong sharedIndex) : base(sharedReader, sharedIndex)
				{
				}

				// Token: 0x1700138A RID: 5002
				// (get) Token: 0x0600720D RID: 29197 RVA: 0x0018924B File Offset: 0x0018744B
				protected override int SourceCount
				{
					get
					{
						return this.m_sharedReader.Length;
					}
				}

				// Token: 0x1700138B RID: 5003
				// (get) Token: 0x0600720E RID: 29198 RVA: 0x00189258 File Offset: 0x00187458
				public override KeyValuePair<long, TSource> Current
				{
					get
					{
						if (this.m_currentChunkSize == null)
						{
							throw new InvalidOperationException(Environment.GetResourceString("PartitionerStatic_CurrentCalledBeforeMoveNext"));
						}
						return new KeyValuePair<long, TSource>((long)(this.m_startIndex + this.m_localOffset.Value), this.m_sharedReader[this.m_startIndex + this.m_localOffset.Value]);
					}
				}
			}
		}

		// Token: 0x02000BD0 RID: 3024
		private abstract class StaticIndexRangePartitioner<TSource, TCollection> : OrderablePartitioner<TSource>
		{
			// Token: 0x06006EB5 RID: 28341 RVA: 0x0017DD21 File Offset: 0x0017BF21
			protected StaticIndexRangePartitioner() : base(true, true, true)
			{
			}

			// Token: 0x170012F2 RID: 4850
			// (get) Token: 0x06006EB6 RID: 28342
			protected abstract int SourceCount { get; }

			// Token: 0x06006EB7 RID: 28343
			protected abstract IEnumerator<KeyValuePair<long, TSource>> CreatePartition(int startIndex, int endIndex);

			// Token: 0x06006EB8 RID: 28344 RVA: 0x0017DD2C File Offset: 0x0017BF2C
			public override IList<IEnumerator<KeyValuePair<long, TSource>>> GetOrderablePartitions(int partitionCount)
			{
				if (partitionCount <= 0)
				{
					throw new ArgumentOutOfRangeException("partitionCount");
				}
				int num2;
				int num = Math.DivRem(this.SourceCount, partitionCount, out num2);
				IEnumerator<KeyValuePair<long, TSource>>[] array = new IEnumerator<KeyValuePair<long, TSource>>[partitionCount];
				int num3 = -1;
				for (int i = 0; i < partitionCount; i++)
				{
					int num4 = num3 + 1;
					if (i < num2)
					{
						num3 = num4 + num;
					}
					else
					{
						num3 = num4 + num - 1;
					}
					array[i] = this.CreatePartition(num4, num3);
				}
				return array;
			}
		}

		// Token: 0x02000BD1 RID: 3025
		private abstract class StaticIndexRangePartition<TSource> : IEnumerator<KeyValuePair<long, TSource>>, IDisposable, IEnumerator
		{
			// Token: 0x06006EB9 RID: 28345 RVA: 0x0017DD96 File Offset: 0x0017BF96
			protected StaticIndexRangePartition(int startIndex, int endIndex)
			{
				this.m_startIndex = startIndex;
				this.m_endIndex = endIndex;
				this.m_offset = startIndex - 1;
			}

			// Token: 0x170012F3 RID: 4851
			// (get) Token: 0x06006EBA RID: 28346
			public abstract KeyValuePair<long, TSource> Current { get; }

			// Token: 0x06006EBB RID: 28347 RVA: 0x0017DDB7 File Offset: 0x0017BFB7
			public void Dispose()
			{
			}

			// Token: 0x06006EBC RID: 28348 RVA: 0x0017DDB9 File Offset: 0x0017BFB9
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006EBD RID: 28349 RVA: 0x0017DDC0 File Offset: 0x0017BFC0
			public bool MoveNext()
			{
				if (this.m_offset < this.m_endIndex)
				{
					this.m_offset++;
					return true;
				}
				this.m_offset = this.m_endIndex + 1;
				return false;
			}

			// Token: 0x170012F4 RID: 4852
			// (get) Token: 0x06006EBE RID: 28350 RVA: 0x0017DDF7 File Offset: 0x0017BFF7
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x040035BF RID: 13759
			protected readonly int m_startIndex;

			// Token: 0x040035C0 RID: 13760
			protected readonly int m_endIndex;

			// Token: 0x040035C1 RID: 13761
			protected volatile int m_offset;
		}

		// Token: 0x02000BD2 RID: 3026
		private class StaticIndexRangePartitionerForIList<TSource> : Partitioner.StaticIndexRangePartitioner<TSource, IList<TSource>>
		{
			// Token: 0x06006EBF RID: 28351 RVA: 0x0017DE04 File Offset: 0x0017C004
			internal StaticIndexRangePartitionerForIList(IList<TSource> list)
			{
				this.m_list = list;
			}

			// Token: 0x170012F5 RID: 4853
			// (get) Token: 0x06006EC0 RID: 28352 RVA: 0x0017DE13 File Offset: 0x0017C013
			protected override int SourceCount
			{
				get
				{
					return this.m_list.Count;
				}
			}

			// Token: 0x06006EC1 RID: 28353 RVA: 0x0017DE20 File Offset: 0x0017C020
			protected override IEnumerator<KeyValuePair<long, TSource>> CreatePartition(int startIndex, int endIndex)
			{
				return new Partitioner.StaticIndexRangePartitionForIList<TSource>(this.m_list, startIndex, endIndex);
			}

			// Token: 0x040035C2 RID: 13762
			private IList<TSource> m_list;
		}

		// Token: 0x02000BD3 RID: 3027
		private class StaticIndexRangePartitionForIList<TSource> : Partitioner.StaticIndexRangePartition<TSource>
		{
			// Token: 0x06006EC2 RID: 28354 RVA: 0x0017DE2F File Offset: 0x0017C02F
			internal StaticIndexRangePartitionForIList(IList<TSource> list, int startIndex, int endIndex) : base(startIndex, endIndex)
			{
				this.m_list = list;
			}

			// Token: 0x170012F6 RID: 4854
			// (get) Token: 0x06006EC3 RID: 28355 RVA: 0x0017DE44 File Offset: 0x0017C044
			public override KeyValuePair<long, TSource> Current
			{
				get
				{
					if (this.m_offset < this.m_startIndex)
					{
						throw new InvalidOperationException(Environment.GetResourceString("PartitionerStatic_CurrentCalledBeforeMoveNext"));
					}
					return new KeyValuePair<long, TSource>((long)this.m_offset, this.m_list[this.m_offset]);
				}
			}

			// Token: 0x040035C3 RID: 13763
			private volatile IList<TSource> m_list;
		}

		// Token: 0x02000BD4 RID: 3028
		private class StaticIndexRangePartitionerForArray<TSource> : Partitioner.StaticIndexRangePartitioner<TSource, TSource[]>
		{
			// Token: 0x06006EC4 RID: 28356 RVA: 0x0017DE94 File Offset: 0x0017C094
			internal StaticIndexRangePartitionerForArray(TSource[] array)
			{
				this.m_array = array;
			}

			// Token: 0x170012F7 RID: 4855
			// (get) Token: 0x06006EC5 RID: 28357 RVA: 0x0017DEA3 File Offset: 0x0017C0A3
			protected override int SourceCount
			{
				get
				{
					return this.m_array.Length;
				}
			}

			// Token: 0x06006EC6 RID: 28358 RVA: 0x0017DEAD File Offset: 0x0017C0AD
			protected override IEnumerator<KeyValuePair<long, TSource>> CreatePartition(int startIndex, int endIndex)
			{
				return new Partitioner.StaticIndexRangePartitionForArray<TSource>(this.m_array, startIndex, endIndex);
			}

			// Token: 0x040035C4 RID: 13764
			private TSource[] m_array;
		}

		// Token: 0x02000BD5 RID: 3029
		private class StaticIndexRangePartitionForArray<TSource> : Partitioner.StaticIndexRangePartition<TSource>
		{
			// Token: 0x06006EC7 RID: 28359 RVA: 0x0017DEBC File Offset: 0x0017C0BC
			internal StaticIndexRangePartitionForArray(TSource[] array, int startIndex, int endIndex) : base(startIndex, endIndex)
			{
				this.m_array = array;
			}

			// Token: 0x170012F8 RID: 4856
			// (get) Token: 0x06006EC8 RID: 28360 RVA: 0x0017DED0 File Offset: 0x0017C0D0
			public override KeyValuePair<long, TSource> Current
			{
				get
				{
					if (this.m_offset < this.m_startIndex)
					{
						throw new InvalidOperationException(Environment.GetResourceString("PartitionerStatic_CurrentCalledBeforeMoveNext"));
					}
					return new KeyValuePair<long, TSource>((long)this.m_offset, this.m_array[this.m_offset]);
				}
			}

			// Token: 0x040035C5 RID: 13765
			private volatile TSource[] m_array;
		}

		// Token: 0x02000BD6 RID: 3030
		private class SharedInt
		{
			// Token: 0x06006EC9 RID: 28361 RVA: 0x0017DF20 File Offset: 0x0017C120
			internal SharedInt(int value)
			{
				this.Value = value;
			}

			// Token: 0x040035C6 RID: 13766
			internal volatile int Value;
		}

		// Token: 0x02000BD7 RID: 3031
		private class SharedBool
		{
			// Token: 0x06006ECA RID: 28362 RVA: 0x0017DF31 File Offset: 0x0017C131
			internal SharedBool(bool value)
			{
				this.Value = value;
			}

			// Token: 0x040035C7 RID: 13767
			internal volatile bool Value;
		}

		// Token: 0x02000BD8 RID: 3032
		private class SharedLong
		{
			// Token: 0x06006ECB RID: 28363 RVA: 0x0017DF42 File Offset: 0x0017C142
			internal SharedLong(long value)
			{
				this.Value = value;
			}

			// Token: 0x040035C8 RID: 13768
			internal long Value;
		}
	}
}
