using System;
using System.Collections.Specialized;
using System.IO;
using CefSharp.Callback;

namespace CefSharp.Lagacy
{
	// Token: 0x020000BC RID: 188
	public class ResourceHandler : IResourceHandler, IDisposable
	{
		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000596 RID: 1430 RVA: 0x00008FD3 File Offset: 0x000071D3
		// (set) Token: 0x06000597 RID: 1431 RVA: 0x00008FDB File Offset: 0x000071DB
		public string Charset { get; set; }

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000598 RID: 1432 RVA: 0x00008FE4 File Offset: 0x000071E4
		// (set) Token: 0x06000599 RID: 1433 RVA: 0x00008FEC File Offset: 0x000071EC
		public string MimeType { get; set; }

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x00008FF5 File Offset: 0x000071F5
		// (set) Token: 0x0600059B RID: 1435 RVA: 0x00008FFD File Offset: 0x000071FD
		public Stream Stream { get; set; }

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x00009006 File Offset: 0x00007206
		// (set) Token: 0x0600059D RID: 1437 RVA: 0x0000900E File Offset: 0x0000720E
		public int StatusCode { get; set; }

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x00009017 File Offset: 0x00007217
		// (set) Token: 0x0600059F RID: 1439 RVA: 0x0000901F File Offset: 0x0000721F
		public string StatusText { get; set; }

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x00009028 File Offset: 0x00007228
		// (set) Token: 0x060005A1 RID: 1441 RVA: 0x00009030 File Offset: 0x00007230
		public long? ResponseLength { get; set; }

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x00009039 File Offset: 0x00007239
		// (set) Token: 0x060005A3 RID: 1443 RVA: 0x00009041 File Offset: 0x00007241
		public NameValueCollection Headers { get; private set; }

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060005A4 RID: 1444 RVA: 0x0000904A File Offset: 0x0000724A
		// (set) Token: 0x060005A5 RID: 1445 RVA: 0x00009052 File Offset: 0x00007252
		public bool AutoDisposeStream { get; set; }

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060005A6 RID: 1446 RVA: 0x0000905B File Offset: 0x0000725B
		// (set) Token: 0x060005A7 RID: 1447 RVA: 0x00009063 File Offset: 0x00007263
		public CefErrorCode? ErrorCode { get; set; }

		// Token: 0x060005A8 RID: 1448 RVA: 0x0000906C File Offset: 0x0000726C
		public ResourceHandler(string mimeType = "text/html", Stream stream = null, bool autoDisposeStream = false, string charset = null)
		{
			if (string.IsNullOrEmpty(mimeType))
			{
				throw new ArgumentNullException("mimeType", "Please provide a valid mimeType");
			}
			this.StatusCode = 200;
			this.StatusText = "OK";
			this.MimeType = mimeType;
			this.Headers = new NameValueCollection();
			this.Stream = stream;
			this.AutoDisposeStream = autoDisposeStream;
			this.Charset = charset;
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x000090D5 File Offset: 0x000072D5
		protected virtual bool ProcessRequestAsync(IRequest request, ICallback callback)
		{
			callback.Continue();
			return true;
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x000090DE File Offset: 0x000072DE
		protected virtual void Cancel()
		{
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x000090E0 File Offset: 0x000072E0
		protected virtual void Dispose()
		{
			if (this.AutoDisposeStream && this.Stream != null)
			{
				this.Stream.Dispose();
				this.Stream = null;
			}
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x00009104 File Offset: 0x00007304
		protected virtual Stream GetResponse(IResponse response, out long responseLength, out string redirectUrl)
		{
			redirectUrl = null;
			responseLength = -1L;
			response.MimeType = this.MimeType;
			response.StatusCode = this.StatusCode;
			response.StatusText = this.StatusText;
			response.Headers = this.Headers;
			if (!string.IsNullOrEmpty(this.Charset))
			{
				response.Charset = this.Charset;
			}
			if (this.ResponseLength != null)
			{
				responseLength = this.ResponseLength.Value;
			}
			else if (this.Stream != null && this.Stream.CanSeek)
			{
				responseLength = this.Stream.Length;
			}
			return this.Stream;
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x000091AB File Offset: 0x000073AB
		void IResourceHandler.Cancel()
		{
			this.Cancel();
			this.Stream = null;
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x000091BA File Offset: 0x000073BA
		void IDisposable.Dispose()
		{
			this.Dispose();
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x000091C4 File Offset: 0x000073C4
		void IResourceHandler.GetResponseHeaders(IResponse response, out long responseLength, out string redirectUrl)
		{
			if (this.ErrorCode != null)
			{
				responseLength = 0L;
				redirectUrl = null;
				response.ErrorCode = this.ErrorCode.Value;
				return;
			}
			this.Stream = this.GetResponse(response, out responseLength, out redirectUrl);
			if (this.Stream != null && this.Stream.CanSeek)
			{
				this.Stream.Position = 0L;
			}
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x0000922E File Offset: 0x0000742E
		bool IResourceHandler.Open(IRequest request, out bool handleRequest, ICallback callback)
		{
			callback.Dispose();
			handleRequest = false;
			return false;
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x0000923A File Offset: 0x0000743A
		bool IResourceHandler.ProcessRequest(IRequest request, ICallback callback)
		{
			return this.ProcessRequestAsync(request, callback);
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x00009244 File Offset: 0x00007444
		bool IResourceHandler.Read(Stream dataOut, out int bytesRead, IResourceReadCallback callback)
		{
			bytesRead = -1;
			return false;
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0000924C File Offset: 0x0000744C
		bool IResourceHandler.ReadResponse(Stream dataOut, out int bytesRead, ICallback callback)
		{
			callback.Dispose();
			if (this.Stream == null)
			{
				bytesRead = 0;
				return false;
			}
			byte[] array = new byte[dataOut.Length];
			bytesRead = this.Stream.Read(array, 0, array.Length);
			if (bytesRead == 0)
			{
				return false;
			}
			dataOut.Write(array, 0, array.Length);
			return bytesRead > 0;
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x000092A1 File Offset: 0x000074A1
		bool IResourceHandler.Skip(long bytesToSkip, out long bytesSkipped, IResourceSkipCallback callback)
		{
			throw new NotImplementedException();
		}
	}
}
