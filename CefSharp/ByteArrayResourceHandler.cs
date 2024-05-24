using System;
using System.IO;
using CefSharp.Callback;

namespace CefSharp
{
	// Token: 0x02000071 RID: 113
	public class ByteArrayResourceHandler : IResourceHandler, IDisposable
	{
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060002CC RID: 716 RVA: 0x00003602 File Offset: 0x00001802
		// (set) Token: 0x060002CD RID: 717 RVA: 0x0000360A File Offset: 0x0000180A
		public byte[] Data { get; private set; }

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060002CE RID: 718 RVA: 0x00003613 File Offset: 0x00001813
		// (set) Token: 0x060002CF RID: 719 RVA: 0x0000361B File Offset: 0x0000181B
		public string MimeType { get; set; }

		// Token: 0x060002D0 RID: 720 RVA: 0x00003624 File Offset: 0x00001824
		public ByteArrayResourceHandler(string mimeType, byte[] data)
		{
			if (string.IsNullOrEmpty(mimeType))
			{
				throw new ArgumentNullException("mimeType", "Please provide a valid mimeType");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data", "Please provide a valid array");
			}
			if (data.Length == 0)
			{
				throw new Exception("Unable to load byte[] with length 0.");
			}
			this.MimeType = mimeType;
			this.Data = data;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000367F File Offset: 0x0000187F
		bool IResourceHandler.ProcessRequest(IRequest request, ICallback callback)
		{
			throw new NotImplementedException("This method should never be called");
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000368B File Offset: 0x0000188B
		void IResourceHandler.GetResponseHeaders(IResponse response, out long responseLength, out string redirectUrl)
		{
			throw new NotImplementedException("This method should never be called");
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00003697 File Offset: 0x00001897
		bool IResourceHandler.ReadResponse(Stream dataOut, out int bytesRead, ICallback callback)
		{
			throw new NotImplementedException("This method should never be called");
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x000036A3 File Offset: 0x000018A3
		void IResourceHandler.Cancel()
		{
			throw new NotImplementedException("This method should never be called");
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x000036AF File Offset: 0x000018AF
		bool IResourceHandler.Open(IRequest request, out bool handleRequest, ICallback callback)
		{
			throw new NotImplementedException("This method should never be called");
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x000036BB File Offset: 0x000018BB
		bool IResourceHandler.Skip(long bytesToSkip, out long bytesSkipped, IResourceSkipCallback callback)
		{
			throw new NotImplementedException("This method should never be called");
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x000036C7 File Offset: 0x000018C7
		bool IResourceHandler.Read(Stream dataOut, out int bytesRead, IResourceReadCallback callback)
		{
			throw new NotImplementedException("This method should never be called");
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x000036D3 File Offset: 0x000018D3
		void IDisposable.Dispose()
		{
		}
	}
}
