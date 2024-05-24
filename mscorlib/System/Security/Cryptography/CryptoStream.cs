using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Security.Cryptography
{
	// Token: 0x02000257 RID: 599
	[ComVisible(true)]
	public class CryptoStream : Stream, IDisposable
	{
		// Token: 0x0600213B RID: 8507 RVA: 0x000752FF File Offset: 0x000734FF
		public CryptoStream(Stream stream, ICryptoTransform transform, CryptoStreamMode mode) : this(stream, transform, mode, false)
		{
		}

		// Token: 0x0600213C RID: 8508 RVA: 0x0007530C File Offset: 0x0007350C
		public CryptoStream(Stream stream, ICryptoTransform transform, CryptoStreamMode mode, bool leaveOpen)
		{
			this._stream = stream;
			this._transformMode = mode;
			this._Transform = transform;
			this._leaveOpen = leaveOpen;
			CryptoStreamMode transformMode = this._transformMode;
			if (transformMode != CryptoStreamMode.Read)
			{
				if (transformMode != CryptoStreamMode.Write)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidValue"));
				}
				if (!this._stream.CanWrite)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_StreamNotWritable"), "stream");
				}
				this._canWrite = true;
			}
			else
			{
				if (!this._stream.CanRead)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_StreamNotReadable"), "stream");
				}
				this._canRead = true;
			}
			this.InitializeBuffer();
		}

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x0600213D RID: 8509 RVA: 0x000753B8 File Offset: 0x000735B8
		public override bool CanRead
		{
			get
			{
				return this._canRead;
			}
		}

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x0600213E RID: 8510 RVA: 0x000753C0 File Offset: 0x000735C0
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x0600213F RID: 8511 RVA: 0x000753C3 File Offset: 0x000735C3
		public override bool CanWrite
		{
			get
			{
				return this._canWrite;
			}
		}

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06002140 RID: 8512 RVA: 0x000753CB File Offset: 0x000735CB
		public override long Length
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnseekableStream"));
			}
		}

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x06002141 RID: 8513 RVA: 0x000753DC File Offset: 0x000735DC
		// (set) Token: 0x06002142 RID: 8514 RVA: 0x000753ED File Offset: 0x000735ED
		public override long Position
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnseekableStream"));
			}
			set
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnseekableStream"));
			}
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x06002143 RID: 8515 RVA: 0x000753FE File Offset: 0x000735FE
		public bool HasFlushedFinalBlock
		{
			get
			{
				return this._finalBlockTransformed;
			}
		}

		// Token: 0x06002144 RID: 8516 RVA: 0x00075408 File Offset: 0x00073608
		public void FlushFinalBlock()
		{
			if (this._finalBlockTransformed)
			{
				throw new NotSupportedException(Environment.GetResourceString("Cryptography_CryptoStream_FlushFinalBlockTwice"));
			}
			byte[] array = this._Transform.TransformFinalBlock(this._InputBuffer, 0, this._InputBufferIndex);
			this._finalBlockTransformed = true;
			if (this._canWrite && this._OutputBufferIndex > 0)
			{
				this._stream.Write(this._OutputBuffer, 0, this._OutputBufferIndex);
				this._OutputBufferIndex = 0;
			}
			if (this._canWrite)
			{
				this._stream.Write(array, 0, array.Length);
			}
			CryptoStream cryptoStream = this._stream as CryptoStream;
			if (cryptoStream != null)
			{
				if (!cryptoStream.HasFlushedFinalBlock)
				{
					cryptoStream.FlushFinalBlock();
				}
			}
			else
			{
				this._stream.Flush();
			}
			if (this._InputBuffer != null)
			{
				Array.Clear(this._InputBuffer, 0, this._InputBuffer.Length);
			}
			if (this._OutputBuffer != null)
			{
				Array.Clear(this._OutputBuffer, 0, this._OutputBuffer.Length);
			}
		}

		// Token: 0x06002145 RID: 8517 RVA: 0x000754F7 File Offset: 0x000736F7
		public override void Flush()
		{
		}

		// Token: 0x06002146 RID: 8518 RVA: 0x000754F9 File Offset: 0x000736F9
		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			if (base.GetType() != typeof(CryptoStream))
			{
				return base.FlushAsync(cancellationToken);
			}
			if (!cancellationToken.IsCancellationRequested)
			{
				return Task.CompletedTask;
			}
			return Task.FromCancellation(cancellationToken);
		}

		// Token: 0x06002147 RID: 8519 RVA: 0x0007552F File Offset: 0x0007372F
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnseekableStream"));
		}

		// Token: 0x06002148 RID: 8520 RVA: 0x00075540 File Offset: 0x00073740
		public override void SetLength(long value)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnseekableStream"));
		}

		// Token: 0x06002149 RID: 8521 RVA: 0x00075554 File Offset: 0x00073754
		public override int Read([In] [Out] byte[] buffer, int offset, int count)
		{
			if (!this.CanRead)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnreadableStream"));
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			int i = count;
			int num = offset;
			if (this._OutputBufferIndex != 0)
			{
				if (this._OutputBufferIndex > count)
				{
					Buffer.InternalBlockCopy(this._OutputBuffer, 0, buffer, offset, count);
					Buffer.InternalBlockCopy(this._OutputBuffer, count, this._OutputBuffer, 0, this._OutputBufferIndex - count);
					this._OutputBufferIndex -= count;
					return count;
				}
				Buffer.InternalBlockCopy(this._OutputBuffer, 0, buffer, offset, this._OutputBufferIndex);
				i -= this._OutputBufferIndex;
				num += this._OutputBufferIndex;
				this._OutputBufferIndex = 0;
			}
			if (this._finalBlockTransformed)
			{
				return count - i;
			}
			if (i > this._OutputBlockSize && this._Transform.CanTransformMultipleBlocks)
			{
				int num2 = i / this._OutputBlockSize;
				int num3 = num2 * this._InputBlockSize;
				byte[] array = new byte[num3];
				Buffer.InternalBlockCopy(this._InputBuffer, 0, array, 0, this._InputBufferIndex);
				int num4 = this._InputBufferIndex;
				num4 += this._stream.Read(array, this._InputBufferIndex, num3 - this._InputBufferIndex);
				this._InputBufferIndex = 0;
				if (num4 <= this._InputBlockSize)
				{
					this._InputBuffer = array;
					this._InputBufferIndex = num4;
				}
				else
				{
					int num5 = num4 / this._InputBlockSize * this._InputBlockSize;
					int num6 = num4 - num5;
					if (num6 != 0)
					{
						this._InputBufferIndex = num6;
						Buffer.InternalBlockCopy(array, num5, this._InputBuffer, 0, num6);
					}
					byte[] array2 = new byte[num5 / this._InputBlockSize * this._OutputBlockSize];
					int num7 = this._Transform.TransformBlock(array, 0, num5, array2, 0);
					Buffer.InternalBlockCopy(array2, 0, buffer, num, num7);
					Array.Clear(array, 0, array.Length);
					Array.Clear(array2, 0, array2.Length);
					i -= num7;
					num += num7;
				}
			}
			while (i > 0)
			{
				while (this._InputBufferIndex < this._InputBlockSize)
				{
					int num4 = this._stream.Read(this._InputBuffer, this._InputBufferIndex, this._InputBlockSize - this._InputBufferIndex);
					if (num4 != 0)
					{
						this._InputBufferIndex += num4;
					}
					else
					{
						byte[] array3 = this._Transform.TransformFinalBlock(this._InputBuffer, 0, this._InputBufferIndex);
						this._OutputBuffer = array3;
						this._OutputBufferIndex = array3.Length;
						this._finalBlockTransformed = true;
						if (i < this._OutputBufferIndex)
						{
							Buffer.InternalBlockCopy(this._OutputBuffer, 0, buffer, num, i);
							this._OutputBufferIndex -= i;
							Buffer.InternalBlockCopy(this._OutputBuffer, i, this._OutputBuffer, 0, this._OutputBufferIndex);
							return count;
						}
						Buffer.InternalBlockCopy(this._OutputBuffer, 0, buffer, num, this._OutputBufferIndex);
						i -= this._OutputBufferIndex;
						this._OutputBufferIndex = 0;
						return count - i;
					}
				}
				int num7 = this._Transform.TransformBlock(this._InputBuffer, 0, this._InputBlockSize, this._OutputBuffer, 0);
				this._InputBufferIndex = 0;
				if (i < num7)
				{
					Buffer.InternalBlockCopy(this._OutputBuffer, 0, buffer, num, i);
					this._OutputBufferIndex = num7 - i;
					Buffer.InternalBlockCopy(this._OutputBuffer, i, this._OutputBuffer, 0, this._OutputBufferIndex);
					return count;
				}
				Buffer.InternalBlockCopy(this._OutputBuffer, 0, buffer, num, num7);
				num += num7;
				i -= num7;
			}
			return count;
		}

		// Token: 0x0600214A RID: 8522 RVA: 0x000758DC File Offset: 0x00073ADC
		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (!this.CanRead)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnreadableStream"));
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			if (base.GetType() != typeof(CryptoStream))
			{
				return base.ReadAsync(buffer, offset, count, cancellationToken);
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCancellation<int>(cancellationToken);
			}
			return this.ReadAsyncInternal(buffer, offset, count, cancellationToken);
		}

		// Token: 0x0600214B RID: 8523 RVA: 0x0007598C File Offset: 0x00073B8C
		private Task<int> ReadAsyncInternal(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			CryptoStream.<ReadAsyncInternal>d__36 <ReadAsyncInternal>d__;
			<ReadAsyncInternal>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<ReadAsyncInternal>d__.<>4__this = this;
			<ReadAsyncInternal>d__.buffer = buffer;
			<ReadAsyncInternal>d__.offset = offset;
			<ReadAsyncInternal>d__.count = count;
			<ReadAsyncInternal>d__.cancellationToken = cancellationToken;
			<ReadAsyncInternal>d__.<>1__state = -1;
			<ReadAsyncInternal>d__.<>t__builder.Start<CryptoStream.<ReadAsyncInternal>d__36>(ref <ReadAsyncInternal>d__);
			return <ReadAsyncInternal>d__.<>t__builder.Task;
		}

		// Token: 0x0600214C RID: 8524 RVA: 0x000759F0 File Offset: 0x00073BF0
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (!this.CanWrite)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnwritableStream"));
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			int i = count;
			int num = offset;
			if (this._InputBufferIndex > 0)
			{
				if (count < this._InputBlockSize - this._InputBufferIndex)
				{
					Buffer.InternalBlockCopy(buffer, offset, this._InputBuffer, this._InputBufferIndex, count);
					this._InputBufferIndex += count;
					return;
				}
				Buffer.InternalBlockCopy(buffer, offset, this._InputBuffer, this._InputBufferIndex, this._InputBlockSize - this._InputBufferIndex);
				num += this._InputBlockSize - this._InputBufferIndex;
				i -= this._InputBlockSize - this._InputBufferIndex;
				this._InputBufferIndex = this._InputBlockSize;
			}
			if (this._OutputBufferIndex > 0)
			{
				this._stream.Write(this._OutputBuffer, 0, this._OutputBufferIndex);
				this._OutputBufferIndex = 0;
			}
			if (this._InputBufferIndex == this._InputBlockSize)
			{
				int count2 = this._Transform.TransformBlock(this._InputBuffer, 0, this._InputBlockSize, this._OutputBuffer, 0);
				this._stream.Write(this._OutputBuffer, 0, count2);
				this._InputBufferIndex = 0;
			}
			while (i > 0)
			{
				if (i < this._InputBlockSize)
				{
					Buffer.InternalBlockCopy(buffer, num, this._InputBuffer, 0, i);
					this._InputBufferIndex += i;
					return;
				}
				if (this._Transform.CanTransformMultipleBlocks)
				{
					int num2 = i / this._InputBlockSize;
					int num3 = num2 * this._InputBlockSize;
					byte[] array = new byte[num2 * this._OutputBlockSize];
					int count2 = this._Transform.TransformBlock(buffer, num, num3, array, 0);
					this._stream.Write(array, 0, count2);
					num += num3;
					i -= num3;
				}
				else
				{
					int count2 = this._Transform.TransformBlock(buffer, num, this._InputBlockSize, this._OutputBuffer, 0);
					this._stream.Write(this._OutputBuffer, 0, count2);
					num += this._InputBlockSize;
					i -= this._InputBlockSize;
				}
			}
		}

		// Token: 0x0600214D RID: 8525 RVA: 0x00075C38 File Offset: 0x00073E38
		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (!this.CanWrite)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnwritableStream"));
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			if (base.GetType() != typeof(CryptoStream))
			{
				return base.WriteAsync(buffer, offset, count, cancellationToken);
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCancellation(cancellationToken);
			}
			return this.WriteAsyncInternal(buffer, offset, count, cancellationToken);
		}

		// Token: 0x0600214E RID: 8526 RVA: 0x00075CE8 File Offset: 0x00073EE8
		private Task WriteAsyncInternal(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			CryptoStream.<WriteAsyncInternal>d__39 <WriteAsyncInternal>d__;
			<WriteAsyncInternal>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteAsyncInternal>d__.<>4__this = this;
			<WriteAsyncInternal>d__.buffer = buffer;
			<WriteAsyncInternal>d__.offset = offset;
			<WriteAsyncInternal>d__.count = count;
			<WriteAsyncInternal>d__.cancellationToken = cancellationToken;
			<WriteAsyncInternal>d__.<>1__state = -1;
			<WriteAsyncInternal>d__.<>t__builder.Start<CryptoStream.<WriteAsyncInternal>d__39>(ref <WriteAsyncInternal>d__);
			return <WriteAsyncInternal>d__.<>t__builder.Task;
		}

		// Token: 0x0600214F RID: 8527 RVA: 0x00075D4C File Offset: 0x00073F4C
		public void Clear()
		{
			this.Close();
		}

		// Token: 0x06002150 RID: 8528 RVA: 0x00075D54 File Offset: 0x00073F54
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing)
				{
					if (!this._finalBlockTransformed)
					{
						this.FlushFinalBlock();
					}
					if (!this._leaveOpen)
					{
						this._stream.Close();
					}
				}
			}
			finally
			{
				try
				{
					this._finalBlockTransformed = true;
					if (this._InputBuffer != null)
					{
						Array.Clear(this._InputBuffer, 0, this._InputBuffer.Length);
					}
					if (this._OutputBuffer != null)
					{
						Array.Clear(this._OutputBuffer, 0, this._OutputBuffer.Length);
					}
					this._InputBuffer = null;
					this._OutputBuffer = null;
					this._canRead = false;
					this._canWrite = false;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		// Token: 0x06002151 RID: 8529 RVA: 0x00075E0C File Offset: 0x0007400C
		private void InitializeBuffer()
		{
			if (this._Transform != null)
			{
				this._InputBlockSize = this._Transform.InputBlockSize;
				this._InputBuffer = new byte[this._InputBlockSize];
				this._OutputBlockSize = this._Transform.OutputBlockSize;
				this._OutputBuffer = new byte[this._OutputBlockSize];
			}
		}

		// Token: 0x04000C1C RID: 3100
		private Stream _stream;

		// Token: 0x04000C1D RID: 3101
		private ICryptoTransform _Transform;

		// Token: 0x04000C1E RID: 3102
		private byte[] _InputBuffer;

		// Token: 0x04000C1F RID: 3103
		private int _InputBufferIndex;

		// Token: 0x04000C20 RID: 3104
		private int _InputBlockSize;

		// Token: 0x04000C21 RID: 3105
		private byte[] _OutputBuffer;

		// Token: 0x04000C22 RID: 3106
		private int _OutputBufferIndex;

		// Token: 0x04000C23 RID: 3107
		private int _OutputBlockSize;

		// Token: 0x04000C24 RID: 3108
		private CryptoStreamMode _transformMode;

		// Token: 0x04000C25 RID: 3109
		private bool _canRead;

		// Token: 0x04000C26 RID: 3110
		private bool _canWrite;

		// Token: 0x04000C27 RID: 3111
		private bool _finalBlockTransformed;

		// Token: 0x04000C28 RID: 3112
		private bool _leaveOpen;

		// Token: 0x02000B41 RID: 2881
		private struct HopToThreadPoolAwaitable : INotifyCompletion
		{
			// Token: 0x06006B83 RID: 27523 RVA: 0x0017394D File Offset: 0x00171B4D
			public CryptoStream.HopToThreadPoolAwaitable GetAwaiter()
			{
				return this;
			}

			// Token: 0x17001224 RID: 4644
			// (get) Token: 0x06006B84 RID: 27524 RVA: 0x00173955 File Offset: 0x00171B55
			public bool IsCompleted
			{
				get
				{
					return false;
				}
			}

			// Token: 0x06006B85 RID: 27525 RVA: 0x00173958 File Offset: 0x00171B58
			public void OnCompleted(Action continuation)
			{
				Task.Run(continuation);
			}

			// Token: 0x06006B86 RID: 27526 RVA: 0x00173961 File Offset: 0x00171B61
			public void GetResult()
			{
			}
		}
	}
}
