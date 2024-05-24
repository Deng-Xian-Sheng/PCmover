using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ControlzEx.Standard
{
	// Token: 0x020000BC RID: 188
	internal sealed class ManagedIStream : IStream, IDisposable
	{
		// Token: 0x0600038A RID: 906 RVA: 0x00009A83 File Offset: 0x00007C83
		public ManagedIStream(Stream source)
		{
			Verify.IsNotNull<Stream>(source, "source");
			this._source = source;
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00009A9D File Offset: 0x00007C9D
		private void _Validate()
		{
			if (this._source == null)
			{
				throw new ObjectDisposedException("this");
			}
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00009AB4 File Offset: 0x00007CB4
		[Obsolete("The method is not implemented", true)]
		public void Clone(out IStream ppstm)
		{
			ppstm = null;
			HRESULT.STG_E_INVALIDFUNCTION.ThrowIfFailed("The method is not implemented.");
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00009AD6 File Offset: 0x00007CD6
		public void Commit(int grfCommitFlags)
		{
			this._Validate();
			this._source.Flush();
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00009AEC File Offset: 0x00007CEC
		public void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
		{
			Verify.IsNotNull<IStream>(pstm, "pstm");
			this._Validate();
			byte[] array = new byte[4096];
			long num;
			int num2;
			for (num = 0L; num < cb; num += (long)num2)
			{
				num2 = this._source.Read(array, 0, array.Length);
				if (num2 == 0)
				{
					break;
				}
				pstm.Write(array, num2, IntPtr.Zero);
			}
			if (IntPtr.Zero != pcbRead)
			{
				Marshal.WriteInt64(pcbRead, num);
			}
			if (IntPtr.Zero != pcbWritten)
			{
				Marshal.WriteInt64(pcbWritten, num);
			}
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00009B70 File Offset: 0x00007D70
		[Obsolete("The method is not implemented", true)]
		public void LockRegion(long libOffset, long cb, int dwLockType)
		{
			HRESULT.STG_E_INVALIDFUNCTION.ThrowIfFailed("The method is not implemented.");
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00009B90 File Offset: 0x00007D90
		public void Read(byte[] pv, int cb, IntPtr pcbRead)
		{
			this._Validate();
			int val = this._source.Read(pv, 0, cb);
			if (IntPtr.Zero != pcbRead)
			{
				Marshal.WriteInt32(pcbRead, val);
			}
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00009BC8 File Offset: 0x00007DC8
		[Obsolete("The method is not implemented", true)]
		public void Revert()
		{
			HRESULT.STG_E_INVALIDFUNCTION.ThrowIfFailed("The method is not implemented.");
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00009BE8 File Offset: 0x00007DE8
		public void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
		{
			this._Validate();
			long val = this._source.Seek(dlibMove, (SeekOrigin)dwOrigin);
			if (IntPtr.Zero != plibNewPosition)
			{
				Marshal.WriteInt64(plibNewPosition, val);
			}
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00009C1D File Offset: 0x00007E1D
		public void SetSize(long libNewSize)
		{
			this._Validate();
			this._source.SetLength(libNewSize);
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00009C31 File Offset: 0x00007E31
		public void Stat(out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg, int grfStatFlag)
		{
			pstatstg = default(System.Runtime.InteropServices.ComTypes.STATSTG);
			this._Validate();
			pstatstg.type = 2;
			pstatstg.cbSize = this._source.Length;
			pstatstg.grfMode = 2;
			pstatstg.grfLocksSupported = 2;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00009C68 File Offset: 0x00007E68
		[Obsolete("The method is not implemented", true)]
		public void UnlockRegion(long libOffset, long cb, int dwLockType)
		{
			HRESULT.STG_E_INVALIDFUNCTION.ThrowIfFailed("The method is not implemented.");
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00009C87 File Offset: 0x00007E87
		public void Write(byte[] pv, int cb, IntPtr pcbWritten)
		{
			this._Validate();
			this._source.Write(pv, 0, cb);
			if (IntPtr.Zero != pcbWritten)
			{
				Marshal.WriteInt32(pcbWritten, cb);
			}
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00009CB1 File Offset: 0x00007EB1
		public void Dispose()
		{
			this._source = null;
		}

		// Token: 0x040006B6 RID: 1718
		private const int STGTY_STREAM = 2;

		// Token: 0x040006B7 RID: 1719
		private const int STGM_READWRITE = 2;

		// Token: 0x040006B8 RID: 1720
		private const int LOCK_EXCLUSIVE = 2;

		// Token: 0x040006B9 RID: 1721
		private Stream _source;
	}
}
