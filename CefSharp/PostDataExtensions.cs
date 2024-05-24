using System;
using System.Collections.Specialized;
using System.Text;

namespace CefSharp
{
	// Token: 0x0200008B RID: 139
	public static class PostDataExtensions
	{
		// Token: 0x060003E9 RID: 1001 RVA: 0x00003B6C File Offset: 0x00001D6C
		public static string GetCharSet(this IRequest request)
		{
			NameValueCollection headers = request.Headers;
			string text = null;
			foreach (object obj in headers)
			{
				string text2 = (string)obj;
				if (text2.Equals("content-type", StringComparison.InvariantCultureIgnoreCase))
				{
					string[] values = headers.GetValues(text2);
					int num = 0;
					if (num >= values.Length)
					{
						break;
					}
					string text3 = values[num];
					text = text3;
					break;
				}
			}
			if (text == null)
			{
				return null;
			}
			int num2 = text.IndexOf(";", StringComparison.InvariantCulture);
			if (num2 == -1)
			{
				return null;
			}
			string text4 = text.Substring(num2 + 1).Trim();
			int num3 = text4.IndexOf("=", StringComparison.InvariantCulture);
			if (num3 == -1)
			{
				return null;
			}
			string text5 = text4.Substring(0, num3).Trim();
			if (!text5.Equals("charset", StringComparison.InvariantCultureIgnoreCase))
			{
				return null;
			}
			string text6 = text4.Substring(num3 + 1).Trim();
			text6 = text6.TrimStart(new char[]
			{
				' ',
				'"'
			});
			return text6.TrimEnd(new char[]
			{
				' ',
				'"',
				';'
			});
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00003CA4 File Offset: 0x00001EA4
		public static string GetBody(this IPostDataElement postDataElement, string charSet = null)
		{
			byte[] bytes = postDataElement.Bytes;
			if (bytes.Length == 0)
			{
				return null;
			}
			Encoding encoding = Encoding.Default;
			if (charSet != null)
			{
				try
				{
					encoding = Encoding.GetEncoding(charSet);
				}
				catch (ArgumentException)
				{
				}
			}
			return encoding.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00003CF0 File Offset: 0x00001EF0
		public static void AddFile(this IPostData postData, string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			IPostDataElement postDataElement = postData.CreatePostDataElement();
			postDataElement.File = fileName;
			postData.AddElement(postDataElement);
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00003D28 File Offset: 0x00001F28
		public static void AddData(this IPostData postData, string data, Encoding encoding = null)
		{
			if (string.IsNullOrEmpty(data))
			{
				throw new ArgumentNullException("data");
			}
			if (encoding == null)
			{
				encoding = Encoding.Default;
			}
			IPostDataElement postDataElement = postData.CreatePostDataElement();
			postDataElement.Bytes = encoding.GetBytes(data);
			postData.AddElement(postDataElement);
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00003D70 File Offset: 0x00001F70
		public static void AddData(this IPostData postData, byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			IPostDataElement postDataElement = postData.CreatePostDataElement();
			postDataElement.Bytes = bytes;
			postData.AddElement(postDataElement);
		}
	}
}
