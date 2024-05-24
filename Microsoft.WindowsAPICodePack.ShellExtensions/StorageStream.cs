using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.WindowsAPICodePack.ShellExtensions.Resources;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
	// Token: 0x02000018 RID: 24
	public class StorageStream : Stream, IDisposable
	{
		// Token: 0x06000097 RID: 151 RVA: 0x0000358C File Offset: 0x0000178C
		internal StorageStream(IStream stream, bool readOnly)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			this._isReadOnly = readOnly;
			this._stream = stream;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000035D0 File Offset: 0x000017D0
		public override int ReadByte()
		{
			this.ThrowIfDisposed();
			byte[] array = new byte[1];
			int result;
			if (this.Read(array, 0, 1) > 0)
			{
				result = (int)array[0];
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000360C File Offset: 0x0000180C
		public override void WriteByte(byte value)
		{
			this.ThrowIfDisposed();
			byte[] buffer = new byte[]
			{
				value
			};
			this.Write(buffer, 0, 1);
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00003638 File Offset: 0x00001838
		public override bool CanRead
		{
			get
			{
				return this._stream != null;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00003658 File Offset: 0x00001858
		public override bool CanSeek
		{
			get
			{
				return this._stream != null;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00003678 File Offset: 0x00001878
		public override bool CanWrite
		{
			get
			{
				return this._stream != null && !this._isReadOnly;
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000036A0 File Offset: 0x000018A0
		public override int Read(byte[] buffer, int offset, int count)
		{
			this.ThrowIfDisposed();
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", LocalizedMessages.StorageStreamOffsetLessThanZero);
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", LocalizedMessages.StorageStreamCountLessThanZero);
			}
			if (offset + count > buffer.Length)
			{
				throw new ArgumentException(LocalizedMessages.StorageStreamBufferOverflow, "count");
			}
			int num = 0;
			if (count > 0)
			{
				IntPtr intPtr = Marshal.AllocCoTaskMem(8);
				try
				{
					if (offset == 0)
					{
						this._stream.Read(buffer, count, intPtr);
						num = (int)Marshal.ReadInt64(intPtr);
					}
					else
					{
						byte[] array = new byte[count];
						this._stream.Read(array, count, intPtr);
						num = (int)Marshal.ReadInt64(intPtr);
						if (num > 0)
						{
							Array.Copy(array, 0, buffer, offset, num);
						}
					}
				}
				finally
				{
					Marshal.FreeCoTaskMem(intPtr);
				}
			}
			return num;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000037CC File Offset: 0x000019CC
		public override void Write(byte[] buffer, int offset, int count)
		{
			this.ThrowIfDisposed();
			if (this._isReadOnly)
			{
				throw new InvalidOperationException(LocalizedMessages.StorageStreamIsReadonly);
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", LocalizedMessages.StorageStreamOffsetLessThanZero);
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", LocalizedMessages.StorageStreamCountLessThanZero);
			}
			if (offset + count > buffer.Length)
			{
				throw new ArgumentException(LocalizedMessages.StorageStreamBufferOverflow, "count");
			}
			if (count > 0)
			{
				IntPtr intPtr = Marshal.AllocCoTaskMem(8);
				try
				{
					if (offset == 0)
					{
						this._stream.Write(buffer, count, intPtr);
					}
					else
					{
						byte[] array = new byte[count];
						Array.Copy(buffer, offset, array, 0, count);
						this._stream.Write(array, count, intPtr);
					}
				}
				finally
				{
					Marshal.FreeCoTaskMem(intPtr);
				}
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600009F RID: 159 RVA: 0x000038E0 File Offset: 0x00001AE0
		public override long Length
		{
			get
			{
				this.ThrowIfDisposed();
				System.Runtime.InteropServices.ComTypes.STATSTG statstg;
				this._stream.Stat(out statstg, 1);
				return statstg.cbSize;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00003910 File Offset: 0x00001B10
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00003932 File Offset: 0x00001B32
		public override long Position
		{
			get
			{
				this.ThrowIfDisposed();
				return this.Seek(0L, SeekOrigin.Current);
			}
			set
			{
				this.ThrowIfDisposed();
				this.Seek(value, SeekOrigin.Begin);
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00003948 File Offset: 0x00001B48
		public override long Seek(long offset, SeekOrigin origin)
		{
			this.ThrowIfDisposed();
			IntPtr intPtr = Marshal.AllocCoTaskMem(8);
			long result;
			try
			{
				this._stream.Seek(offset, (int)origin, intPtr);
				result = Marshal.ReadInt64(intPtr);
			}
			finally
			{
				Marshal.FreeCoTaskMem(intPtr);
			}
			return result;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000399C File Offset: 0x00001B9C
		public override void SetLength(long value)
		{
			this.ThrowIfDisposed();
			this._stream.SetSize(value);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000039B3 File Offset: 0x00001BB3
		public override void Flush()
		{
			this._stream.Commit(0);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000039C3 File Offset: 0x00001BC3
		protected override void Dispose(bool disposing)
		{
			this._stream = null;
			base.Dispose(disposing);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000039D8 File Offset: 0x00001BD8
		private void ThrowIfDisposed()
		{
			if (this._stream == null)
			{
				throw new ObjectDisposedException(base.GetType().Name);
			}
		}

		// Token: 0x0400003A RID: 58
		private IStream _stream;

		// Token: 0x0400003B RID: 59
		private bool _isReadOnly = false;
	}
}
