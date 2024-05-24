using System;
using System.IO;

namespace System.Security.Cryptography
{
	// Token: 0x0200026F RID: 623
	internal sealed class TailStream : Stream
	{
		// Token: 0x06002215 RID: 8725 RVA: 0x00078983 File Offset: 0x00076B83
		public TailStream(int bufferSize)
		{
			this._Buffer = new byte[bufferSize];
			this._BufferSize = bufferSize;
		}

		// Token: 0x06002216 RID: 8726 RVA: 0x0007899E File Offset: 0x00076B9E
		public void Clear()
		{
			this.Close();
		}

		// Token: 0x06002217 RID: 8727 RVA: 0x000789A8 File Offset: 0x00076BA8
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing)
				{
					if (this._Buffer != null)
					{
						Array.Clear(this._Buffer, 0, this._Buffer.Length);
					}
					this._Buffer = null;
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x06002218 RID: 8728 RVA: 0x000789F8 File Offset: 0x00076BF8
		public byte[] Buffer
		{
			get
			{
				return (byte[])this._Buffer.Clone();
			}
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06002219 RID: 8729 RVA: 0x00078A0A File Offset: 0x00076C0A
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x0600221A RID: 8730 RVA: 0x00078A0D File Offset: 0x00076C0D
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x0600221B RID: 8731 RVA: 0x00078A10 File Offset: 0x00076C10
		public override bool CanWrite
		{
			get
			{
				return this._Buffer != null;
			}
		}

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x0600221C RID: 8732 RVA: 0x00078A1B File Offset: 0x00076C1B
		public override long Length
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnseekableStream"));
			}
		}

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x0600221D RID: 8733 RVA: 0x00078A2C File Offset: 0x00076C2C
		// (set) Token: 0x0600221E RID: 8734 RVA: 0x00078A3D File Offset: 0x00076C3D
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

		// Token: 0x0600221F RID: 8735 RVA: 0x00078A4E File Offset: 0x00076C4E
		public override void Flush()
		{
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x00078A50 File Offset: 0x00076C50
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnseekableStream"));
		}

		// Token: 0x06002221 RID: 8737 RVA: 0x00078A61 File Offset: 0x00076C61
		public override void SetLength(long value)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnseekableStream"));
		}

		// Token: 0x06002222 RID: 8738 RVA: 0x00078A72 File Offset: 0x00076C72
		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnreadableStream"));
		}

		// Token: 0x06002223 RID: 8739 RVA: 0x00078A84 File Offset: 0x00076C84
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this._Buffer == null)
			{
				throw new ObjectDisposedException("TailStream");
			}
			if (count == 0)
			{
				return;
			}
			if (this._BufferFull)
			{
				if (count > this._BufferSize)
				{
					System.Buffer.InternalBlockCopy(buffer, offset + count - this._BufferSize, this._Buffer, 0, this._BufferSize);
					return;
				}
				System.Buffer.InternalBlockCopy(this._Buffer, this._BufferSize - count, this._Buffer, 0, this._BufferSize - count);
				System.Buffer.InternalBlockCopy(buffer, offset, this._Buffer, this._BufferSize - count, count);
				return;
			}
			else
			{
				if (count > this._BufferSize)
				{
					System.Buffer.InternalBlockCopy(buffer, offset + count - this._BufferSize, this._Buffer, 0, this._BufferSize);
					this._BufferFull = true;
					return;
				}
				if (count + this._BufferIndex >= this._BufferSize)
				{
					System.Buffer.InternalBlockCopy(this._Buffer, this._BufferIndex + count - this._BufferSize, this._Buffer, 0, this._BufferSize - count);
					System.Buffer.InternalBlockCopy(buffer, offset, this._Buffer, this._BufferIndex, count);
					this._BufferFull = true;
					return;
				}
				System.Buffer.InternalBlockCopy(buffer, offset, this._Buffer, this._BufferIndex, count);
				this._BufferIndex += count;
				return;
			}
		}

		// Token: 0x04000C61 RID: 3169
		private byte[] _Buffer;

		// Token: 0x04000C62 RID: 3170
		private int _BufferSize;

		// Token: 0x04000C63 RID: 3171
		private int _BufferIndex;

		// Token: 0x04000C64 RID: 3172
		private bool _BufferFull;
	}
}
