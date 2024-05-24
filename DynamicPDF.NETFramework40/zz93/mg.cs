using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using ceTe.DynamicPDF.Imaging;

namespace zz93
{
	// Token: 0x020001E2 RID: 482
	internal class mg
	{
		// Token: 0x060014C0 RID: 5312 RVA: 0x000E845C File Offset: 0x000E745C
		internal static mf a(ij A_0, string A_1, string A_2)
		{
			if (!A_1.Contains("base64"))
			{
				Uri uri = n9.a(A_2, A_1);
				if (uri != null)
				{
					A_1 = uri.ToString();
				}
			}
			lock (mg.c)
			{
				try
				{
					mf mf = mg.a(A_0, A_1.ToUpper());
					if (mf == null)
					{
						return mg.b(A_0, A_1);
					}
					return mf;
				}
				catch (Exception)
				{
				}
			}
			return null;
		}

		// Token: 0x060014C1 RID: 5313 RVA: 0x000E851C File Offset: 0x000E751C
		private static mf b(ij A_0, string A_1)
		{
			int key = 0;
			int num = 0;
			mf result;
			if (!A_1.Contains("base64"))
			{
				try
				{
					byte[] array = n9.a(new Uri(A_1));
					if (array.Length > 0)
					{
						ImageData image = ImageData.GetImage(array);
						mf a_;
						if ((long)image.Width <= 5L || (long)image.Height <= 5L)
						{
							a_ = new mf(image, array);
						}
						else
						{
							a_ = new mf(image, null);
						}
						oc oc = new oc(a_, array.Length, mg.d.ComputeHash(array));
						num = A_1.ToUpper().GetHashCode();
						if (!mg.b.ContainsKey(key))
						{
							foreach (oc oc2 in mg.a.Values)
							{
								oc2.a(false);
							}
						}
						mg.a.Add(num, oc);
						if (!A_0.q().Contains(num))
						{
							A_0.q().Add(num);
							key = A_0.GetHashCode();
							oc.a(true);
							if (!mg.b.ContainsKey(key))
							{
								mg.b.Add(key, A_0.q());
							}
							else
							{
								mg.b[key] = A_0.q();
							}
						}
						return oc.a();
					}
				}
				catch (Exception)
				{
				}
				result = null;
			}
			else if (A_1.Contains("base64"))
			{
				int num2 = A_1.IndexOf("base64,");
				num2 += 7;
				string text = A_1.Substring(num2, A_1.Length - num2);
				text = text.Replace("%3D", "=");
				try
				{
					byte[] array2 = Convert.FromBase64String(text);
					if (array2 != null)
					{
						ImageData image = ImageData.GetImage(array2);
						mf a_;
						if ((long)image.Width <= 5L || (long)image.Height <= 5L)
						{
							a_ = new mf(image, array2);
						}
						else
						{
							a_ = new mf(image, null);
						}
						oc oc = new oc(a_, array2.Length, mg.d.ComputeHash(array2));
						num = A_1.ToUpper().GetHashCode();
						if (!mg.b.ContainsKey(key))
						{
							foreach (oc oc2 in mg.a.Values)
							{
								oc2.a(false);
							}
						}
						mg.a.Add(num, oc);
						if (!A_0.q().Contains(num))
						{
							A_0.q().Add(num);
							key = A_0.GetHashCode();
							oc.a(true);
							if (!mg.b.ContainsKey(key))
							{
								mg.b.Add(key, A_0.q());
							}
							else
							{
								mg.b[key] = A_0.q();
							}
						}
						return oc.a();
					}
				}
				catch (Exception)
				{
				}
				result = null;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060014C2 RID: 5314 RVA: 0x000E88F0 File Offset: 0x000E78F0
		private static mf a(ij A_0, string A_1)
		{
			int hashCode = A_1.ToUpper().GetHashCode();
			int hashCode2 = A_0.GetHashCode();
			mf result;
			if (mg.a.ContainsKey(hashCode))
			{
				oc oc = mg.a[hashCode];
				if (!mg.b.ContainsKey(hashCode2))
				{
					foreach (oc oc2 in mg.a.Values)
					{
						oc2.a(false);
					}
					if (!A_0.q().Contains(hashCode))
					{
						oc oc3 = oc;
						oc3.a(oc3.b() + 1);
						oc.a(true);
						A_0.q().Add(hashCode);
					}
					mg.b.Add(hashCode2, A_0.q());
				}
				else if (!oc.c())
				{
					A_0.q().Add(hashCode);
					oc oc4 = oc;
					oc4.a(oc4.b() + 1);
					oc.a(true);
				}
				result = oc.a();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060014C3 RID: 5315 RVA: 0x000E8A34 File Offset: 0x000E7A34
		internal static void a(ij A_0)
		{
			int hashCode = A_0.GetHashCode();
			lock (mg.c)
			{
				try
				{
					if (mg.b.ContainsKey(hashCode))
					{
						List<int> list = mg.b[hashCode];
						for (int i = 0; i < list.Count; i++)
						{
							int key = list[i];
							if (mg.a.ContainsKey(key))
							{
								oc oc = mg.a[key];
								oc.a(oc.b() - 1);
								if (mg.a[key].b() == 0)
								{
									mg.a.Remove(key);
								}
							}
						}
						list.Clear();
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x040009D4 RID: 2516
		private static Dictionary<int, oc> a = new Dictionary<int, oc>();

		// Token: 0x040009D5 RID: 2517
		private static Dictionary<int, List<int>> b = new Dictionary<int, List<int>>();

		// Token: 0x040009D6 RID: 2518
		private static object c = new object();

		// Token: 0x040009D7 RID: 2519
		private static MD5 d = MD5.Create();
	}
}
