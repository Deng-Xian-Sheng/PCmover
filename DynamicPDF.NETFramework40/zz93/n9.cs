using System;
using System.IO;
using System.Net;

namespace zz93
{
	// Token: 0x02000223 RID: 547
	internal class n9
	{
		// Token: 0x060019E9 RID: 6633 RVA: 0x0010E6C4 File Offset: 0x0010D6C4
		internal static Uri b(Uri A_0)
		{
			Uri result;
			if (Uri.IsWellFormedUriString(A_0.AbsolutePath, UriKind.Absolute))
			{
				string fileName = Path.GetFileName(A_0.AbsolutePath);
				if (fileName != null && fileName.Length > 0)
				{
					result = new Uri(A_0.AbsolutePath.Substring(0, A_0.AbsolutePath.Length - fileName.Length));
				}
				else
				{
					result = A_0;
				}
			}
			else if (A_0.IsFile)
			{
				result = new Uri(Path.GetDirectoryName(A_0.AbsolutePath) + "\\");
			}
			else
			{
				result = A_0;
			}
			return result;
		}

		// Token: 0x060019EA RID: 6634 RVA: 0x0010E764 File Offset: 0x0010D764
		internal static bool b(string A_0)
		{
			return A_0.StartsWith("\\\\");
		}

		// Token: 0x060019EB RID: 6635 RVA: 0x0010E790 File Offset: 0x0010D790
		internal static bool a(string A_0)
		{
			return A_0.IndexOf(':') >= 1;
		}

		// Token: 0x060019EC RID: 6636 RVA: 0x0010E7B8 File Offset: 0x0010D7B8
		internal static string b(string A_0, string A_1)
		{
			if (!Uri.IsWellFormedUriString(A_0, UriKind.Absolute) && !n9.a(A_0) && !n9.b(A_0))
			{
				if (A_0.StartsWith(".."))
				{
					int num = 0;
					int num2 = 0;
					while (A_0.IndexOf("..", num) >= 0)
					{
						num2++;
						num += 3;
					}
					A_0 = A_0.Substring(num);
					char[] anyOf = new char[]
					{
						'\\',
						'/'
					};
					for (int i = 0; i < num2; i++)
					{
						A_1 = A_1.Substring(0, A_1.Length - 1);
						if (A_1.LastIndexOfAny(anyOf) <= 1)
						{
							A_1 += "\\";
							break;
						}
						A_1 = A_1.Substring(0, A_1.LastIndexOfAny(anyOf) + 1);
					}
				}
				if (A_0.StartsWith("//"))
				{
					A_0 = A_0.Remove(0, 2);
				}
				Uri baseUri = new Uri(A_1);
				Uri uri = new Uri(baseUri, A_0);
				if (uri.IsFile)
				{
					A_0 = uri.LocalPath;
				}
				else
				{
					A_0 = uri.AbsoluteUri;
				}
			}
			return A_0;
		}

		// Token: 0x060019ED RID: 6637 RVA: 0x0010E908 File Offset: 0x0010D908
		internal static Uri a(string A_0, string A_1)
		{
			if (A_1.Contains("&amp;"))
			{
				A_1 = A_1.Replace("&amp;", "&");
			}
			if (A_0 != null && A_0.Contains("%2520"))
			{
				A_0 = A_0.Replace("%2520", " ");
			}
			Uri result;
			if (Uri.IsWellFormedUriString(A_0, UriKind.Absolute) && Uri.IsWellFormedUriString(A_1, UriKind.RelativeOrAbsolute))
			{
				result = new Uri(new Uri(A_0), A_1);
			}
			else
			{
				if (A_0 != null)
				{
					Uri uri = new Uri(A_0);
					if (uri.IsFile)
					{
						return new Uri(new Uri(A_0), A_1);
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060019EE RID: 6638 RVA: 0x0010E9C4 File Offset: 0x0010D9C4
		internal static byte[] a(Uri A_0)
		{
			Stream stream = null;
			byte[] result;
			try
			{
				if (!A_0.IsFile)
				{
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(A_0);
					HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
					stream = httpWebResponse.GetResponseStream();
				}
				else
				{
					FileWebRequest fileWebRequest = (FileWebRequest)WebRequest.Create(A_0);
					FileWebResponse fileWebResponse = (FileWebResponse)fileWebRequest.GetResponse();
					stream = fileWebResponse.GetResponseStream();
				}
				if (stream.CanSeek)
				{
					byte[] array = new byte[stream.Length];
					stream.Read(array, 0, array.Length);
					result = array;
				}
				else
				{
					byte[] buffer = new byte[1024];
					MemoryStream memoryStream = new MemoryStream(1024);
					int num;
					do
					{
						num = stream.Read(buffer, 0, 1024);
						memoryStream.Write(buffer, 0, num);
					}
					while (num > 0);
					result = memoryStream.ToArray();
				}
			}
			finally
			{
				if (stream != null)
				{
					stream.Close();
				}
			}
			return result;
		}
	}
}
