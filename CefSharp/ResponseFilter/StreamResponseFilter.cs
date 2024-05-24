using System;
using System.IO;

namespace CefSharp.ResponseFilter
{
	// Token: 0x020000AF RID: 175
	public sealed class StreamResponseFilter : IResponseFilter, IDisposable
	{
		// Token: 0x06000560 RID: 1376 RVA: 0x000088F3 File Offset: 0x00006AF3
		public StreamResponseFilter(Stream stream)
		{
			this.responseStream = stream;
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x00008902 File Offset: 0x00006B02
		bool IResponseFilter.InitFilter()
		{
			return this.responseStream != null && this.responseStream.CanWrite;
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0000891C File Offset: 0x00006B1C
		FilterStatus IResponseFilter.Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten)
		{
			if (dataIn == null)
			{
				dataInRead = 0L;
				dataOutWritten = 0L;
				return FilterStatus.Done;
			}
			dataInRead = Math.Min(dataIn.Length, dataOut.Length);
			dataOutWritten = dataInRead;
			byte[] array = new byte[dataInRead];
			dataIn.Read(array, 0, array.Length);
			dataOut.Write(array, 0, array.Length);
			this.responseStream.Write(array, 0, array.Length);
			if (dataInRead < dataIn.Length)
			{
				return FilterStatus.NeedMoreData;
			}
			return FilterStatus.Done;
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0000898C File Offset: 0x00006B8C
		public void Dispose()
		{
			this.responseStream = null;
		}

		// Token: 0x04000310 RID: 784
		private Stream responseStream;
	}
}
