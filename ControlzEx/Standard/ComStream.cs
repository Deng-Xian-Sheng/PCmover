using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ControlzEx.Standard
{
	// Token: 0x020000BB RID: 187
	internal sealed class ComStream : Stream
	{
		// Token: 0x0600037C RID: 892 RVA: 0x00009934 File Offset: 0x00007B34
		private void _Validate()
		{
			if (this._source == null)
			{
				throw new ObjectDisposedException("this");
			}
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00009949 File Offset: 0x00007B49
		public ComStream(ref IStream stream)
		{
			Verify.IsNotNull<IStream>(stream, "stream");
			this._source = stream;
			stream = null;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00009968 File Offset: 0x00007B68
		public override void Close()
		{
			if (this._source != null)
			{
				Utility.SafeRelease<IStream>(ref this._source);
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600037F RID: 895 RVA: 0x0000997D File Offset: 0x00007B7D
		public override bool CanRead
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000380 RID: 896 RVA: 0x0000997D File Offset: 0x00007B7D
		public override bool CanSeek
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000381 RID: 897 RVA: 0x00009980 File Offset: 0x00007B80
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00007247 File Offset: 0x00005447
		public override void Flush()
		{
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000383 RID: 899 RVA: 0x00009984 File Offset: 0x00007B84
		public override long Length
		{
			get
			{
				this._Validate();
				System.Runtime.InteropServices.ComTypes.STATSTG statstg;
				this._source.Stat(out statstg, 1);
				return statstg.cbSize;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000384 RID: 900 RVA: 0x000099AB File Offset: 0x00007BAB
		// (set) Token: 0x06000385 RID: 901 RVA: 0x000099B6 File Offset: 0x00007BB6
		public override long Position
		{
			get
			{
				return this.Seek(0L, SeekOrigin.Current);
			}
			set
			{
				this.Seek(value, SeekOrigin.Begin);
			}
		}

		// Token: 0x06000386 RID: 902 RVA: 0x000099C4 File Offset: 0x00007BC4
		public override int Read(byte[] buffer, int offset, int count)
		{
			this._Validate();
			IntPtr intPtr = IntPtr.Zero;
			int result;
			try
			{
				intPtr = Marshal.AllocHGlobal(4);
				byte[] array = new byte[count];
				this._source.Read(array, count, intPtr);
				Array.Copy(array, 0, buffer, offset, Marshal.ReadInt32(intPtr));
				result = Marshal.ReadInt32(intPtr);
			}
			finally
			{
				Utility.SafeFreeHGlobal(ref intPtr);
			}
			return result;
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00009A2C File Offset: 0x00007C2C
		public override long Seek(long offset, SeekOrigin origin)
		{
			this._Validate();
			IntPtr intPtr = IntPtr.Zero;
			long result;
			try
			{
				intPtr = Marshal.AllocHGlobal(8);
				this._source.Seek(offset, (int)origin, intPtr);
				result = Marshal.ReadInt64(intPtr);
			}
			finally
			{
				Utility.SafeFreeHGlobal(ref intPtr);
			}
			return result;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00009A7C File Offset: 0x00007C7C
		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00009A7C File Offset: 0x00007C7C
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		// Token: 0x040006B4 RID: 1716
		private const int STATFLAG_NONAME = 1;

		// Token: 0x040006B5 RID: 1717
		private IStream _source;
	}
}
