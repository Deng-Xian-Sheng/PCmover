using System;
using System.Collections.Generic;
using System.ComponentModel;
using CefSharp.Core;

namespace CefSharp
{
	// Token: 0x02000008 RID: 8
	public class PostData : IPostData, IDisposable
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00002AAC File Offset: 0x00000CAC
		public IList<IPostDataElement> Elements
		{
			get
			{
				return this.postData.Elements;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00002AB9 File Offset: 0x00000CB9
		public bool IsReadOnly
		{
			get
			{
				return this.postData.IsReadOnly;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00002AC6 File Offset: 0x00000CC6
		public bool IsDisposed
		{
			get
			{
				return this.postData.IsDisposed;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00002AD3 File Offset: 0x00000CD3
		public bool HasExcludedElements
		{
			get
			{
				return this.postData.HasExcludedElements;
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00002AE0 File Offset: 0x00000CE0
		public bool AddElement(IPostDataElement element)
		{
			return this.postData.AddElement(element);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00002AEE File Offset: 0x00000CEE
		public IPostDataElement CreatePostDataElement()
		{
			return new PostDataElement();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00002AF5 File Offset: 0x00000CF5
		public void Dispose()
		{
			this.postData.Dispose();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00002B02 File Offset: 0x00000D02
		public bool RemoveElement(IPostDataElement element)
		{
			return this.postData.RemoveElement(element);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00002B10 File Offset: 0x00000D10
		public void RemoveElements()
		{
			this.postData.RemoveElements();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00002B1D File Offset: 0x00000D1D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IPostData UnWrap()
		{
			return this.postData;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00002B25 File Offset: 0x00000D25
		public static IPostData Create()
		{
			return new PostData();
		}

		// Token: 0x04000004 RID: 4
		private PostData postData = new PostData();
	}
}
