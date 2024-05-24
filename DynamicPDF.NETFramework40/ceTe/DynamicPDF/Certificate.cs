using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000655 RID: 1621
	public class Certificate
	{
		// Token: 0x06003D61 RID: 15713 RVA: 0x00214FD8 File Offset: 0x00213FD8
		public Certificate(X509Certificate2 certificate)
		{
			if (!certificate.HasPrivateKey)
			{
				throw new GeneratorException("Private Key does not exist in the certificate.");
			}
			this.a = certificate;
		}

		// Token: 0x06003D62 RID: 15714 RVA: 0x00215024 File Offset: 0x00214024
		public Certificate(string certificatePath, string password)
		{
			this.a = new X509Certificate2(certificatePath, password, X509KeyStorageFlags.MachineKeySet);
			if (!this.a.HasPrivateKey)
			{
				throw new GeneratorException("Private Key does not exist in the certificate.");
			}
		}

		// Token: 0x06003D63 RID: 15715 RVA: 0x0021507C File Offset: 0x0021407C
		public Certificate(byte[] certificateData, string password)
		{
			this.a = new X509Certificate2(certificateData, password, X509KeyStorageFlags.MachineKeySet);
			if (!this.a.HasPrivateKey)
			{
				throw new GeneratorException("Private Key does not exist in the certificate.");
			}
		}

		// Token: 0x06003D64 RID: 15716 RVA: 0x002150D4 File Offset: 0x002140D4
		public Certificate(string storeName, StoreLocation storeLocation, string certificateSubject)
		{
			X509Store a_ = new X509Store(storeName, storeLocation);
			this.a(a_, certificateSubject);
		}

		// Token: 0x06003D65 RID: 15717 RVA: 0x00215114 File Offset: 0x00214114
		public Certificate(StoreName storeName, StoreLocation storeLocation, string certificateSubject)
		{
			X509Store a_ = new X509Store(storeName, storeLocation);
			this.a(a_, certificateSubject);
		}

		// Token: 0x06003D66 RID: 15718 RVA: 0x00215154 File Offset: 0x00214154
		public Certificate(string certificateSubject)
		{
			X509Store a_ = new X509Store();
			this.a(a_, certificateSubject);
		}

		// Token: 0x06003D67 RID: 15719 RVA: 0x00215194 File Offset: 0x00214194
		private void a(X509Store A_0, string A_1)
		{
			A_0.Open(OpenFlags.ReadOnly);
			X509Certificate2Collection certificates = A_0.Certificates;
			foreach (X509Certificate2 x509Certificate in certificates)
			{
				if (x509Certificate.Subject.Contains(A_1))
				{
					if (x509Certificate.HasPrivateKey)
					{
						this.a = x509Certificate;
						break;
					}
				}
			}
			if (this.a == null)
			{
				throw new GeneratorException("Cannot extract the certificate from the store.");
			}
		}

		// Token: 0x06003D68 RID: 15720 RVA: 0x00215218 File Offset: 0x00214218
		private string b()
		{
			string[] array = this.a.SubjectName.Decode(X500DistinguishedNameFlags.UseSemicolons).Split(new char[]
			{
				';'
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Trim().StartsWith("CN=", true, CultureInfo.CurrentCulture))
				{
					string[] array2 = array[i].Split(new char[]
					{
						'='
					});
					string result;
					if (array2.Length > 1)
					{
						result = array2[1];
					}
					else
					{
						result = "Unknown";
					}
					return result;
				}
			}
			return "Unknown";
		}

		// Token: 0x06003D69 RID: 15721 RVA: 0x002152C8 File Offset: 0x002142C8
		internal X509Certificate2 c()
		{
			return this.a;
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06003D6A RID: 15722 RVA: 0x002152E0 File Offset: 0x002142E0
		public string SubjectName
		{
			get
			{
				if (this.b == null)
				{
					this.b = this.b();
				}
				return this.b;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06003D6B RID: 15723 RVA: 0x00215314 File Offset: 0x00214314
		public string Subject
		{
			get
			{
				return this.a.SubjectName.Format(false);
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06003D6C RID: 15724 RVA: 0x00215338 File Offset: 0x00214338
		public string Issuer
		{
			get
			{
				return this.a.IssuerName.Format(false);
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06003D6D RID: 15725 RVA: 0x0021535C File Offset: 0x0021435C
		public string TimestampServerUrl
		{
			get
			{
				if (this.d == null)
				{
					this.d = this.a();
				}
				return this.d;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06003D6E RID: 15726 RVA: 0x00215390 File Offset: 0x00214390
		// (set) Token: 0x06003D6F RID: 15727 RVA: 0x002153A8 File Offset: 0x002143A8
		public bool SignSilently
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x06003D70 RID: 15728 RVA: 0x002153B4 File Offset: 0x002143B4
		private string a()
		{
			X509ExtensionCollection extensions = this.a.Extensions;
			string result = string.Empty;
			foreach (X509Extension x509Extension in extensions)
			{
				if (x509Extension.Oid.Value.Equals("1.2.840.113583.1.1.9.1"))
				{
					byte[] rawData = x509Extension.RawData;
					int i;
					for (i = 0; i < rawData.Length; i++)
					{
						if (rawData[i] == 134)
						{
							i++;
							break;
						}
					}
					int num = (int)rawData[i++];
					byte[] array = new byte[num];
					Array.Copy(rawData, i, array, 0, num);
					result = Encoding.ASCII.GetString(array);
					break;
				}
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x04002111 RID: 8465
		private X509Certificate2 a;

		// Token: 0x04002112 RID: 8466
		private string b = null;

		// Token: 0x04002113 RID: 8467
		private bool c = true;

		// Token: 0x04002114 RID: 8468
		private string d = string.Empty;
	}
}
