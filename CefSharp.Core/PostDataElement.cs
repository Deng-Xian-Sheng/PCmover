using System;
using System.ComponentModel;
using CefSharp.Core;

namespace CefSharp
{
	// Token: 0x02000009 RID: 9
	public class PostDataElement : IPostDataElement, IDisposable
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00002B3F File Offset: 0x00000D3F
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x00002B4C File Offset: 0x00000D4C
		public string File
		{
			get
			{
				return this.postDataElement.File;
			}
			set
			{
				this.postDataElement.File = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00002B5A File Offset: 0x00000D5A
		public bool IsReadOnly
		{
			get
			{
				return this.postDataElement.IsReadOnly;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00002B67 File Offset: 0x00000D67
		public PostDataElementType Type
		{
			get
			{
				return this.postDataElement.Type;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00002B74 File Offset: 0x00000D74
		// (set) Token: 0x060000BC RID: 188 RVA: 0x00002B81 File Offset: 0x00000D81
		public byte[] Bytes
		{
			get
			{
				return this.postDataElement.Bytes;
			}
			set
			{
				this.postDataElement.Bytes = value;
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00002B8F File Offset: 0x00000D8F
		public void Dispose()
		{
			this.postDataElement.Dispose();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00002B9C File Offset: 0x00000D9C
		public void SetToEmpty()
		{
			this.postDataElement.SetToEmpty();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00002BA9 File Offset: 0x00000DA9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IPostDataElement UnWrap()
		{
			return this.postDataElement;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00002BB1 File Offset: 0x00000DB1
		public static IPostDataElement Create()
		{
			return new PostDataElement();
		}

		// Token: 0x04000005 RID: 5
		internal PostDataElement postDataElement = new PostDataElement();
	}
}
