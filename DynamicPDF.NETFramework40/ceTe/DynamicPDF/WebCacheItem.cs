using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Web;
using Microsoft.Win32;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200066B RID: 1643
	[Obsolete("This class is obsolete.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class WebCacheItem
	{
		// Token: 0x06003DFC RID: 15868 RVA: 0x002170F8 File Offset: 0x002160F8
		static WebCacheItem()
		{
			try
			{
				using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\ceTe Software\\DynamicPDF WebCache"))
				{
					WebCacheItem.c = (string)registryKey.GetValue("Base Path");
					if (!WebCacheItem.c.EndsWith("\\"))
					{
						WebCacheItem.c += "\\";
					}
				}
			}
			catch (Exception a_)
			{
				throw new WebCacheException("DynamicPDF WebCache is not properly configured. The base path could not be retrieved.", a_);
			}
		}

		// Token: 0x06003DFD RID: 15869 RVA: 0x002171D0 File Offset: 0x002161D0
		internal WebCacheItem(string A_0)
		{
			DateTime utcNow = DateTime.UtcNow;
			int a_ = (int)((long)(utcNow - WebCacheItem.b).TotalSeconds % 60466176L);
			string text = this.a(a_, utcNow.Millisecond);
			this.f = "/" + text + "/" + A_0;
			this.a(a_, text);
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06003DFE RID: 15870 RVA: 0x00217238 File Offset: 0x00216238
		public string FilePath
		{
			get
			{
				return this.e;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06003DFF RID: 15871 RVA: 0x00217250 File Offset: 0x00216250
		public string Url
		{
			get
			{
				return this.f;
			}
		}

		// Token: 0x06003E00 RID: 15872 RVA: 0x00217268 File Offset: 0x00216268
		public void Redirect()
		{
			HttpContext.Current.Response.Redirect(this.f);
		}

		// Token: 0x06003E01 RID: 15873 RVA: 0x00217284 File Offset: 0x00216284
		private void a(int A_0, string A_1)
		{
			string text;
			try
			{
				NameValueCollection serverVariables = HttpContext.Current.Request.ServerVariables;
				text = string.Concat(new string[]
				{
					WebCacheItem.c,
					serverVariables["SERVER_NAME"],
					"\\",
					serverVariables["SERVER_PORT"],
					"\\",
					this.a(A_0)
				});
			}
			catch (Exception a_)
			{
				throw new WebCacheException("The context for the web server could not be retrieved.", a_);
			}
			try
			{
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
			}
			catch (Exception a_)
			{
				throw new WebCacheException("Could not access a file cache directory.", a_);
			}
			this.e = text + "\\" + A_1.Substring(3) + ".pdf";
		}

		// Token: 0x06003E02 RID: 15874 RVA: 0x00217364 File Offset: 0x00216364
		private string a(int A_0, int A_1)
		{
			char[] array = new char[33];
			this.b(array, A_0);
			this.a(array, A_1);
			this.b(array);
			this.a(array);
			return new string(array);
		}

		// Token: 0x06003E03 RID: 15875 RVA: 0x002173A8 File Offset: 0x002163A8
		private void b(char[] A_0, int A_1)
		{
			A_0[4] = WebCacheItem.a[A_1 % 36];
			A_1 /= 36;
			A_0[3] = WebCacheItem.a[A_1 % 36];
			A_1 /= 36;
			A_0[2] = WebCacheItem.a[A_1 % 36];
			A_1 /= 36;
			A_0[1] = WebCacheItem.a[A_1 % 36];
			A_1 /= 36;
			A_0[0] = WebCacheItem.a[A_1];
		}

		// Token: 0x06003E04 RID: 15876 RVA: 0x0021740C File Offset: 0x0021640C
		private void a(char[] A_0, int A_1)
		{
			A_0[6] = WebCacheItem.a[A_1 % 36];
			A_1 /= 36;
			A_0[5] = WebCacheItem.a[A_1];
		}

		// Token: 0x06003E05 RID: 15877 RVA: 0x0021742C File Offset: 0x0021642C
		private void b(char[] A_0)
		{
			A_0[7] = WebCacheItem.a[WebCacheItem.d.Next(9) * 4];
		}

		// Token: 0x06003E06 RID: 15878 RVA: 0x00217448 File Offset: 0x00216448
		private void a(char[] A_0)
		{
			for (int i = 8; i < 33; i++)
			{
				A_0[i] = WebCacheItem.a[WebCacheItem.d.Next(36)];
			}
		}

		// Token: 0x06003E07 RID: 15879 RVA: 0x00217480 File Offset: 0x00216480
		private string a(int A_0)
		{
			int num = A_0 / 180;
			char[] array = new char[]
			{
				'\0',
				'\0',
				'\0',
				WebCacheItem.a[num % 36]
			};
			num /= 36;
			array[2] = WebCacheItem.a[num % 36];
			num /= 36;
			array[1] = WebCacheItem.a[num % 36];
			num /= 36;
			array[0] = WebCacheItem.a[num];
			return new string(array);
		}

		// Token: 0x04002174 RID: 8564
		private static char[] a = new char[]
		{
			'0',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9',
			'A',
			'B',
			'C',
			'D',
			'E',
			'F',
			'G',
			'H',
			'I',
			'J',
			'K',
			'L',
			'M',
			'N',
			'O',
			'P',
			'Q',
			'R',
			'S',
			'T',
			'U',
			'V',
			'W',
			'X',
			'Y',
			'Z'
		};

		// Token: 0x04002175 RID: 8565
		private static DateTime b = new DateTime(1970, 1, 1, 0, 0, 0);

		// Token: 0x04002176 RID: 8566
		private static string c;

		// Token: 0x04002177 RID: 8567
		private static Random d = new Random();

		// Token: 0x04002178 RID: 8568
		private string e;

		// Token: 0x04002179 RID: 8569
		private string f;
	}
}
