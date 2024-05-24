using System;
using System.IO;
using System.Net;
using System.Text;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x020002CD RID: 717
	internal class sp
	{
		// Token: 0x0600208C RID: 8332 RVA: 0x00140114 File Offset: 0x0013F114
		internal byte[] a(byte[] A_0, string A_1, TimestampServer A_2)
		{
			ss ss = null;
			try
			{
				Random random = new Random();
				int a_ = random.Next(1073741824, int.MaxValue);
				sr sr = new sr(A_1, A_0, true, a_);
				byte[] array = sr.d();
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(A_2.Url);
				httpWebRequest.Headers.Clear();
				httpWebRequest.ProtocolVersion = HttpVersion.Version10;
				httpWebRequest.Method = "POST";
				httpWebRequest.UserAgent = "DynamicPDF";
				httpWebRequest.ContentType = "application/timestamp-query";
				httpWebRequest.ContentLength = (long)array.Length;
				if (A_2.UserName != string.Empty && A_2.Password != string.Empty)
				{
					httpWebRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(A_2.UserName + ":" + A_2.Password)));
				}
				if (A_2.Timeout != 0)
				{
					httpWebRequest.Timeout = A_2.Timeout;
				}
				Stream requestStream = httpWebRequest.GetRequestStream();
				requestStream.Write(array, 0, array.Length);
				requestStream.Flush();
				Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
				byte[] array2 = new byte[16384];
				int num = responseStream.Read(array2, 0, array2.Length);
				int num2 = num;
				while ((num = responseStream.Read(array2, num2, array2.Length - num2)) > 0)
				{
					num2 += num;
				}
				Stream a_2 = new MemoryStream(array2);
				ss = new ss(a_2);
				ss.a();
				if (ss.b() != 0 && ss.b() != 1)
				{
					throw new TimestampException("Timestamp information is not present");
				}
				if (ss.c().c() != sr.c())
				{
					throw new TimestampException("Timestamping is not successful. Difference in nonce value.");
				}
				bool flag = true;
				for (int i = 0; i < 20; i++)
				{
					if (sr.b().c()[i] != ss.c().b().c()[i])
					{
						flag = false;
					}
				}
				if (ss.c().b().b().b() != sr.b().b().b() && !flag)
				{
					throw new TimestampException("Timestamping is not successful. Difference in messageImprint.");
				}
			}
			catch (WebException ex)
			{
				TimestampException ex2 = new TimestampException("Error while connecting to the URL. " + ex.Message);
				throw ex2;
			}
			return ss.d();
		}
	}
}
