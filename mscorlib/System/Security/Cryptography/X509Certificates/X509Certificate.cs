using System;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Security.Util;
using System.Text;
using Microsoft.Win32;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002AF RID: 687
	[ComVisible(true)]
	[Serializable]
	public class X509Certificate : IDisposable, IDeserializationCallback, ISerializable
	{
		// Token: 0x06002428 RID: 9256 RVA: 0x00082753 File Offset: 0x00080953
		[SecuritySafeCritical]
		private void Init()
		{
			this.m_safeCertContext = SafeCertContextHandle.InvalidHandle;
		}

		// Token: 0x06002429 RID: 9257 RVA: 0x00082760 File Offset: 0x00080960
		public X509Certificate()
		{
			this.Init();
		}

		// Token: 0x0600242A RID: 9258 RVA: 0x0008276E File Offset: 0x0008096E
		public X509Certificate(byte[] data) : this()
		{
			if (data != null && data.Length != 0)
			{
				this.LoadCertificateFromBlob(data, null, X509KeyStorageFlags.DefaultKeySet, false);
			}
		}

		// Token: 0x0600242B RID: 9259 RVA: 0x00082787 File Offset: 0x00080987
		public X509Certificate(byte[] rawData, string password) : this()
		{
			this.LoadCertificateFromBlob(rawData, password, X509KeyStorageFlags.DefaultKeySet, true);
		}

		// Token: 0x0600242C RID: 9260 RVA: 0x00082799 File Offset: 0x00080999
		public X509Certificate(byte[] rawData, SecureString password) : this()
		{
			this.LoadCertificateFromBlob(rawData, password, X509KeyStorageFlags.DefaultKeySet, true);
		}

		// Token: 0x0600242D RID: 9261 RVA: 0x000827AB File Offset: 0x000809AB
		public X509Certificate(byte[] rawData, string password, X509KeyStorageFlags keyStorageFlags) : this()
		{
			this.LoadCertificateFromBlob(rawData, password, keyStorageFlags, true);
		}

		// Token: 0x0600242E RID: 9262 RVA: 0x000827BD File Offset: 0x000809BD
		public X509Certificate(byte[] rawData, SecureString password, X509KeyStorageFlags keyStorageFlags) : this()
		{
			this.LoadCertificateFromBlob(rawData, password, keyStorageFlags, true);
		}

		// Token: 0x0600242F RID: 9263 RVA: 0x000827CF File Offset: 0x000809CF
		[SecuritySafeCritical]
		public X509Certificate(string fileName) : this()
		{
			this.LoadCertificateFromFile(fileName, null, X509KeyStorageFlags.DefaultKeySet);
		}

		// Token: 0x06002430 RID: 9264 RVA: 0x000827E0 File Offset: 0x000809E0
		[SecuritySafeCritical]
		public X509Certificate(string fileName, string password) : this()
		{
			this.LoadCertificateFromFile(fileName, password, X509KeyStorageFlags.DefaultKeySet);
		}

		// Token: 0x06002431 RID: 9265 RVA: 0x000827F1 File Offset: 0x000809F1
		[SecuritySafeCritical]
		public X509Certificate(string fileName, SecureString password) : this()
		{
			this.LoadCertificateFromFile(fileName, password, X509KeyStorageFlags.DefaultKeySet);
		}

		// Token: 0x06002432 RID: 9266 RVA: 0x00082802 File Offset: 0x00080A02
		[SecuritySafeCritical]
		public X509Certificate(string fileName, string password, X509KeyStorageFlags keyStorageFlags) : this()
		{
			this.LoadCertificateFromFile(fileName, password, keyStorageFlags);
		}

		// Token: 0x06002433 RID: 9267 RVA: 0x00082813 File Offset: 0x00080A13
		[SecuritySafeCritical]
		public X509Certificate(string fileName, SecureString password, X509KeyStorageFlags keyStorageFlags) : this()
		{
			this.LoadCertificateFromFile(fileName, password, keyStorageFlags);
		}

		// Token: 0x06002434 RID: 9268 RVA: 0x00082824 File Offset: 0x00080A24
		[SecurityCritical]
		[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public X509Certificate(IntPtr handle) : this()
		{
			if (handle == IntPtr.Zero)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_InvalidHandle"), "handle");
			}
			X509Utils.DuplicateCertContext(handle, this.m_safeCertContext);
		}

		// Token: 0x06002435 RID: 9269 RVA: 0x0008285A File Offset: 0x00080A5A
		[SecuritySafeCritical]
		public X509Certificate(X509Certificate cert) : this()
		{
			if (cert == null)
			{
				throw new ArgumentNullException("cert");
			}
			if (cert.m_safeCertContext.pCertContext != IntPtr.Zero)
			{
				this.m_safeCertContext = cert.GetCertContextForCloning();
				this.m_certContextCloned = true;
			}
		}

		// Token: 0x06002436 RID: 9270 RVA: 0x0008289C File Offset: 0x00080A9C
		public X509Certificate(SerializationInfo info, StreamingContext context) : this()
		{
			byte[] array = (byte[])info.GetValue("RawData", typeof(byte[]));
			if (array != null)
			{
				this.LoadCertificateFromBlob(array, null, X509KeyStorageFlags.DefaultKeySet, false);
			}
		}

		// Token: 0x06002437 RID: 9271 RVA: 0x000828D7 File Offset: 0x00080AD7
		public static X509Certificate CreateFromCertFile(string filename)
		{
			return new X509Certificate(filename);
		}

		// Token: 0x06002438 RID: 9272 RVA: 0x000828DF File Offset: 0x00080ADF
		public static X509Certificate CreateFromSignedFile(string filename)
		{
			return new X509Certificate(filename);
		}

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06002439 RID: 9273 RVA: 0x000828E7 File Offset: 0x00080AE7
		[ComVisible(false)]
		public IntPtr Handle
		{
			[SecurityCritical]
			[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
			get
			{
				return this.m_safeCertContext.pCertContext;
			}
		}

		// Token: 0x0600243A RID: 9274 RVA: 0x000828F4 File Offset: 0x00080AF4
		[SecuritySafeCritical]
		[Obsolete("This method has been deprecated.  Please use the Subject property instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
		public virtual string GetName()
		{
			this.ThrowIfContextInvalid();
			return X509Utils._GetSubjectInfo(this.m_safeCertContext, 2U, true);
		}

		// Token: 0x0600243B RID: 9275 RVA: 0x00082909 File Offset: 0x00080B09
		[SecuritySafeCritical]
		[Obsolete("This method has been deprecated.  Please use the Issuer property instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
		public virtual string GetIssuerName()
		{
			this.ThrowIfContextInvalid();
			return X509Utils._GetIssuerName(this.m_safeCertContext, true);
		}

		// Token: 0x0600243C RID: 9276 RVA: 0x0008291D File Offset: 0x00080B1D
		[SecuritySafeCritical]
		public virtual byte[] GetSerialNumber()
		{
			this.ThrowIfContextInvalid();
			if (this.m_serialNumber == null)
			{
				this.m_serialNumber = X509Utils._GetSerialNumber(this.m_safeCertContext);
			}
			return (byte[])this.m_serialNumber.Clone();
		}

		// Token: 0x0600243D RID: 9277 RVA: 0x0008294E File Offset: 0x00080B4E
		public virtual string GetSerialNumberString()
		{
			return this.SerialNumber;
		}

		// Token: 0x0600243E RID: 9278 RVA: 0x00082956 File Offset: 0x00080B56
		[SecuritySafeCritical]
		public virtual byte[] GetKeyAlgorithmParameters()
		{
			this.ThrowIfContextInvalid();
			if (this.m_publicKeyParameters == null)
			{
				this.m_publicKeyParameters = X509Utils._GetPublicKeyParameters(this.m_safeCertContext);
			}
			return (byte[])this.m_publicKeyParameters.Clone();
		}

		// Token: 0x0600243F RID: 9279 RVA: 0x00082987 File Offset: 0x00080B87
		[SecuritySafeCritical]
		public virtual string GetKeyAlgorithmParametersString()
		{
			this.ThrowIfContextInvalid();
			return Hex.EncodeHexString(this.GetKeyAlgorithmParameters());
		}

		// Token: 0x06002440 RID: 9280 RVA: 0x0008299A File Offset: 0x00080B9A
		[SecuritySafeCritical]
		public virtual string GetKeyAlgorithm()
		{
			this.ThrowIfContextInvalid();
			if (this.m_publicKeyOid == null)
			{
				this.m_publicKeyOid = X509Utils._GetPublicKeyOid(this.m_safeCertContext);
			}
			return this.m_publicKeyOid;
		}

		// Token: 0x06002441 RID: 9281 RVA: 0x000829C1 File Offset: 0x00080BC1
		[SecuritySafeCritical]
		public virtual byte[] GetPublicKey()
		{
			this.ThrowIfContextInvalid();
			if (this.m_publicKeyValue == null)
			{
				this.m_publicKeyValue = X509Utils._GetPublicKeyValue(this.m_safeCertContext);
			}
			return (byte[])this.m_publicKeyValue.Clone();
		}

		// Token: 0x06002442 RID: 9282 RVA: 0x000829F2 File Offset: 0x00080BF2
		public virtual string GetPublicKeyString()
		{
			return Hex.EncodeHexString(this.GetPublicKey());
		}

		// Token: 0x06002443 RID: 9283 RVA: 0x000829FF File Offset: 0x00080BFF
		[SecuritySafeCritical]
		public virtual byte[] GetRawCertData()
		{
			return this.RawData;
		}

		// Token: 0x06002444 RID: 9284 RVA: 0x00082A07 File Offset: 0x00080C07
		public virtual string GetRawCertDataString()
		{
			return Hex.EncodeHexString(this.GetRawCertData());
		}

		// Token: 0x06002445 RID: 9285 RVA: 0x00082A14 File Offset: 0x00080C14
		public virtual byte[] GetCertHash()
		{
			this.SetThumbprint();
			return (byte[])this.m_thumbprint.Clone();
		}

		// Token: 0x06002446 RID: 9286 RVA: 0x00082A2C File Offset: 0x00080C2C
		[SecuritySafeCritical]
		public virtual byte[] GetCertHash(HashAlgorithmName hashAlgorithm)
		{
			this.ThrowIfContextInvalid();
			if (string.IsNullOrEmpty(hashAlgorithm.Name))
			{
				throw new ArgumentException(Environment.GetResourceString("Cryptography_HashAlgorithmNameNullOrEmpty"), "hashAlgorithm");
			}
			byte[] result;
			using (HashAlgorithm hashAlgorithm2 = CryptoConfig.CreateFromName(hashAlgorithm.Name) as HashAlgorithm)
			{
				if (hashAlgorithm2 == null || hashAlgorithm2 is KeyedHashAlgorithm)
				{
					throw new CryptographicException(-1073741275);
				}
				byte[] rawData = this.m_rawData;
				if (rawData == null)
				{
					rawData = this.RawData;
				}
				result = hashAlgorithm2.ComputeHash(rawData);
			}
			return result;
		}

		// Token: 0x06002447 RID: 9287 RVA: 0x00082AC0 File Offset: 0x00080CC0
		public virtual string GetCertHashString()
		{
			this.SetThumbprint();
			return Hex.EncodeHexString(this.m_thumbprint);
		}

		// Token: 0x06002448 RID: 9288 RVA: 0x00082AD4 File Offset: 0x00080CD4
		public virtual string GetCertHashString(HashAlgorithmName hashAlgorithm)
		{
			byte[] certHash = this.GetCertHash(hashAlgorithm);
			return Hex.EncodeHexString(certHash);
		}

		// Token: 0x06002449 RID: 9289 RVA: 0x00082AF0 File Offset: 0x00080CF0
		public virtual string GetEffectiveDateString()
		{
			return this.NotBefore.ToString();
		}

		// Token: 0x0600244A RID: 9290 RVA: 0x00082B0C File Offset: 0x00080D0C
		public virtual string GetExpirationDateString()
		{
			return this.NotAfter.ToString();
		}

		// Token: 0x0600244B RID: 9291 RVA: 0x00082B28 File Offset: 0x00080D28
		[ComVisible(false)]
		public override bool Equals(object obj)
		{
			if (!(obj is X509Certificate))
			{
				return false;
			}
			X509Certificate other = (X509Certificate)obj;
			return this.Equals(other);
		}

		// Token: 0x0600244C RID: 9292 RVA: 0x00082B50 File Offset: 0x00080D50
		[SecuritySafeCritical]
		public virtual bool Equals(X509Certificate other)
		{
			if (other == null)
			{
				return false;
			}
			if (this.m_safeCertContext.IsInvalid)
			{
				return other.m_safeCertContext.IsInvalid;
			}
			return this.Issuer.Equals(other.Issuer) && this.SerialNumber.Equals(other.SerialNumber);
		}

		// Token: 0x0600244D RID: 9293 RVA: 0x00082BA8 File Offset: 0x00080DA8
		[SecuritySafeCritical]
		public override int GetHashCode()
		{
			if (this.m_safeCertContext.IsInvalid)
			{
				return 0;
			}
			this.SetThumbprint();
			int num = 0;
			int num2 = 0;
			while (num2 < this.m_thumbprint.Length && num2 < 4)
			{
				num = (num << 8 | (int)this.m_thumbprint[num2]);
				num2++;
			}
			return num;
		}

		// Token: 0x0600244E RID: 9294 RVA: 0x00082BF1 File Offset: 0x00080DF1
		public override string ToString()
		{
			return this.ToString(false);
		}

		// Token: 0x0600244F RID: 9295 RVA: 0x00082BFC File Offset: 0x00080DFC
		[SecuritySafeCritical]
		public virtual string ToString(bool fVerbose)
		{
			if (!fVerbose || this.m_safeCertContext.IsInvalid)
			{
				return base.GetType().FullName;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[Subject]" + Environment.NewLine + "  ");
			stringBuilder.Append(this.Subject);
			stringBuilder.Append(string.Concat(new string[]
			{
				Environment.NewLine,
				Environment.NewLine,
				"[Issuer]",
				Environment.NewLine,
				"  "
			}));
			stringBuilder.Append(this.Issuer);
			stringBuilder.Append(string.Concat(new string[]
			{
				Environment.NewLine,
				Environment.NewLine,
				"[Serial Number]",
				Environment.NewLine,
				"  "
			}));
			stringBuilder.Append(this.SerialNumber);
			stringBuilder.Append(string.Concat(new string[]
			{
				Environment.NewLine,
				Environment.NewLine,
				"[Not Before]",
				Environment.NewLine,
				"  "
			}));
			stringBuilder.Append(X509Certificate.FormatDate(this.NotBefore));
			stringBuilder.Append(string.Concat(new string[]
			{
				Environment.NewLine,
				Environment.NewLine,
				"[Not After]",
				Environment.NewLine,
				"  "
			}));
			stringBuilder.Append(X509Certificate.FormatDate(this.NotAfter));
			stringBuilder.Append(string.Concat(new string[]
			{
				Environment.NewLine,
				Environment.NewLine,
				"[Thumbprint]",
				Environment.NewLine,
				"  "
			}));
			stringBuilder.Append(this.GetCertHashString());
			stringBuilder.Append(Environment.NewLine);
			return stringBuilder.ToString();
		}

		// Token: 0x06002450 RID: 9296 RVA: 0x00082DD4 File Offset: 0x00080FD4
		protected static string FormatDate(DateTime date)
		{
			CultureInfo cultureInfo = CultureInfo.CurrentCulture;
			if (!cultureInfo.DateTimeFormat.Calendar.IsValidDay(date.Year, date.Month, date.Day, 0))
			{
				if (cultureInfo.DateTimeFormat.Calendar is UmAlQuraCalendar)
				{
					cultureInfo = (cultureInfo.Clone() as CultureInfo);
					cultureInfo.DateTimeFormat.Calendar = new HijriCalendar();
				}
				else
				{
					cultureInfo = CultureInfo.InvariantCulture;
				}
			}
			return date.ToString(cultureInfo);
		}

		// Token: 0x06002451 RID: 9297 RVA: 0x00082E4D File Offset: 0x0008104D
		public virtual string GetFormat()
		{
			return "X509";
		}

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06002452 RID: 9298 RVA: 0x00082E54 File Offset: 0x00081054
		public string Issuer
		{
			[SecuritySafeCritical]
			get
			{
				this.ThrowIfContextInvalid();
				if (this.m_issuerName == null)
				{
					this.m_issuerName = X509Utils._GetIssuerName(this.m_safeCertContext, false);
				}
				return this.m_issuerName;
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06002453 RID: 9299 RVA: 0x00082E7C File Offset: 0x0008107C
		public string Subject
		{
			[SecuritySafeCritical]
			get
			{
				this.ThrowIfContextInvalid();
				if (this.m_subjectName == null)
				{
					this.m_subjectName = X509Utils._GetSubjectInfo(this.m_safeCertContext, 2U, false);
				}
				return this.m_subjectName;
			}
		}

		// Token: 0x06002454 RID: 9300 RVA: 0x00082EA5 File Offset: 0x000810A5
		[SecurityCritical]
		[ComVisible(false)]
		[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
		public virtual void Import(byte[] rawData)
		{
			this.Reset();
			this.LoadCertificateFromBlob(rawData, null, X509KeyStorageFlags.DefaultKeySet, false);
		}

		// Token: 0x06002455 RID: 9301 RVA: 0x00082EB7 File Offset: 0x000810B7
		[SecurityCritical]
		[ComVisible(false)]
		[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
		public virtual void Import(byte[] rawData, string password, X509KeyStorageFlags keyStorageFlags)
		{
			this.Reset();
			this.LoadCertificateFromBlob(rawData, password, keyStorageFlags, true);
		}

		// Token: 0x06002456 RID: 9302 RVA: 0x00082EC9 File Offset: 0x000810C9
		[SecurityCritical]
		[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
		public virtual void Import(byte[] rawData, SecureString password, X509KeyStorageFlags keyStorageFlags)
		{
			this.Reset();
			this.LoadCertificateFromBlob(rawData, password, keyStorageFlags, true);
		}

		// Token: 0x06002457 RID: 9303 RVA: 0x00082EDB File Offset: 0x000810DB
		[SecurityCritical]
		[ComVisible(false)]
		[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
		public virtual void Import(string fileName)
		{
			this.Reset();
			this.LoadCertificateFromFile(fileName, null, X509KeyStorageFlags.DefaultKeySet);
		}

		// Token: 0x06002458 RID: 9304 RVA: 0x00082EEC File Offset: 0x000810EC
		[SecurityCritical]
		[ComVisible(false)]
		[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
		public virtual void Import(string fileName, string password, X509KeyStorageFlags keyStorageFlags)
		{
			this.Reset();
			this.LoadCertificateFromFile(fileName, password, keyStorageFlags);
		}

		// Token: 0x06002459 RID: 9305 RVA: 0x00082EFD File Offset: 0x000810FD
		[SecurityCritical]
		[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
		public virtual void Import(string fileName, SecureString password, X509KeyStorageFlags keyStorageFlags)
		{
			this.Reset();
			this.LoadCertificateFromFile(fileName, password, keyStorageFlags);
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x00082F0E File Offset: 0x0008110E
		[SecuritySafeCritical]
		[ComVisible(false)]
		public virtual byte[] Export(X509ContentType contentType)
		{
			return this.ExportHelper(contentType, null);
		}

		// Token: 0x0600245B RID: 9307 RVA: 0x00082F18 File Offset: 0x00081118
		[SecuritySafeCritical]
		[ComVisible(false)]
		public virtual byte[] Export(X509ContentType contentType, string password)
		{
			return this.ExportHelper(contentType, password);
		}

		// Token: 0x0600245C RID: 9308 RVA: 0x00082F22 File Offset: 0x00081122
		[SecuritySafeCritical]
		public virtual byte[] Export(X509ContentType contentType, SecureString password)
		{
			return this.ExportHelper(contentType, password);
		}

		// Token: 0x0600245D RID: 9309 RVA: 0x00082F2C File Offset: 0x0008112C
		[SecurityCritical]
		[ComVisible(false)]
		[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
		public virtual void Reset()
		{
			this.m_subjectName = null;
			this.m_issuerName = null;
			this.m_serialNumber = null;
			this.m_publicKeyParameters = null;
			this.m_publicKeyValue = null;
			this.m_publicKeyOid = null;
			this.m_rawData = null;
			this.m_thumbprint = null;
			this.m_notBefore = DateTime.MinValue;
			this.m_notAfter = DateTime.MinValue;
			if (!this.m_safeCertContext.IsInvalid)
			{
				if (!this.m_certContextCloned)
				{
					this.m_safeCertContext.Dispose();
				}
				this.m_safeCertContext = SafeCertContextHandle.InvalidHandle;
			}
			this.m_certContextCloned = false;
		}

		// Token: 0x0600245E RID: 9310 RVA: 0x00082FB9 File Offset: 0x000811B9
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x0600245F RID: 9311 RVA: 0x00082FC2 File Offset: 0x000811C2
		[SecuritySafeCritical]
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Reset();
			}
		}

		// Token: 0x06002460 RID: 9312 RVA: 0x00082FCD File Offset: 0x000811CD
		[SecurityCritical]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (this.m_safeCertContext.IsInvalid)
			{
				info.AddValue("RawData", null);
				return;
			}
			info.AddValue("RawData", this.RawData);
		}

		// Token: 0x06002461 RID: 9313 RVA: 0x00082FFA File Offset: 0x000811FA
		void IDeserializationCallback.OnDeserialization(object sender)
		{
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06002462 RID: 9314 RVA: 0x00082FFC File Offset: 0x000811FC
		internal SafeCertContextHandle CertContext
		{
			[SecurityCritical]
			get
			{
				return this.m_safeCertContext;
			}
		}

		// Token: 0x06002463 RID: 9315 RVA: 0x00083004 File Offset: 0x00081204
		[SecurityCritical]
		internal SafeCertContextHandle GetCertContextForCloning()
		{
			this.m_certContextCloned = true;
			return this.m_safeCertContext;
		}

		// Token: 0x06002464 RID: 9316 RVA: 0x00083013 File Offset: 0x00081213
		[SecurityCritical]
		private void ThrowIfContextInvalid()
		{
			if (this.m_safeCertContext.IsInvalid)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidHandle"), "m_safeCertContext");
			}
		}

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06002465 RID: 9317 RVA: 0x00083038 File Offset: 0x00081238
		private DateTime NotAfter
		{
			[SecuritySafeCritical]
			get
			{
				this.ThrowIfContextInvalid();
				if (this.m_notAfter == DateTime.MinValue)
				{
					Win32Native.FILE_TIME file_TIME = default(Win32Native.FILE_TIME);
					X509Utils._GetDateNotAfter(this.m_safeCertContext, ref file_TIME);
					this.m_notAfter = DateTime.FromFileTime(file_TIME.ToTicks());
				}
				return this.m_notAfter;
			}
		}

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06002466 RID: 9318 RVA: 0x0008308C File Offset: 0x0008128C
		private DateTime NotBefore
		{
			[SecuritySafeCritical]
			get
			{
				this.ThrowIfContextInvalid();
				if (this.m_notBefore == DateTime.MinValue)
				{
					Win32Native.FILE_TIME file_TIME = default(Win32Native.FILE_TIME);
					X509Utils._GetDateNotBefore(this.m_safeCertContext, ref file_TIME);
					this.m_notBefore = DateTime.FromFileTime(file_TIME.ToTicks());
				}
				return this.m_notBefore;
			}
		}

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06002467 RID: 9319 RVA: 0x000830DE File Offset: 0x000812DE
		private byte[] RawData
		{
			[SecurityCritical]
			get
			{
				this.ThrowIfContextInvalid();
				if (this.m_rawData == null)
				{
					this.m_rawData = X509Utils._GetCertRawData(this.m_safeCertContext);
				}
				return (byte[])this.m_rawData.Clone();
			}
		}

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06002468 RID: 9320 RVA: 0x0008310F File Offset: 0x0008130F
		private string SerialNumber
		{
			[SecuritySafeCritical]
			get
			{
				this.ThrowIfContextInvalid();
				if (this.m_serialNumber == null)
				{
					this.m_serialNumber = X509Utils._GetSerialNumber(this.m_safeCertContext);
				}
				return Hex.EncodeHexStringFromInt(this.m_serialNumber);
			}
		}

		// Token: 0x06002469 RID: 9321 RVA: 0x0008313B File Offset: 0x0008133B
		[SecuritySafeCritical]
		private void SetThumbprint()
		{
			this.ThrowIfContextInvalid();
			if (this.m_thumbprint == null)
			{
				this.m_thumbprint = X509Utils._GetThumbprint(this.m_safeCertContext);
			}
		}

		// Token: 0x0600246A RID: 9322 RVA: 0x0008315C File Offset: 0x0008135C
		[SecurityCritical]
		private byte[] ExportHelper(X509ContentType contentType, object password)
		{
			switch (contentType)
			{
			case X509ContentType.Cert:
			case X509ContentType.SerializedCert:
				break;
			case X509ContentType.Pfx:
			{
				KeyContainerPermission keyContainerPermission = new KeyContainerPermission(KeyContainerPermissionFlags.Open | KeyContainerPermissionFlags.Export);
				keyContainerPermission.Demand();
				break;
			}
			default:
				throw new CryptographicException(Environment.GetResourceString("Cryptography_X509_InvalidContentType"));
			}
			IntPtr intPtr = IntPtr.Zero;
			byte[] array = null;
			SafeCertStoreHandle safeCertStoreHandle = X509Utils.ExportCertToMemoryStore(this);
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				intPtr = X509Utils.PasswordToHGlobalUni(password);
				array = X509Utils._ExportCertificatesToBlob(safeCertStoreHandle, contentType, intPtr);
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
				}
				safeCertStoreHandle.Dispose();
			}
			if (array == null)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_X509_ExportFailed"));
			}
			return array;
		}

		// Token: 0x0600246B RID: 9323 RVA: 0x00083204 File Offset: 0x00081404
		[SecuritySafeCritical]
		private void LoadCertificateFromBlob(byte[] rawData, object password, X509KeyStorageFlags keyStorageFlags, bool passwordProvided)
		{
			if (rawData == null || rawData.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EmptyOrNullArray"), "rawData");
			}
			X509ContentType x509ContentType = X509Utils.MapContentType(X509Utils._QueryCertBlobType(rawData));
			if (x509ContentType == X509ContentType.Pfx && (keyStorageFlags & X509KeyStorageFlags.PersistKeySet) == X509KeyStorageFlags.PersistKeySet)
			{
				KeyContainerPermission keyContainerPermission = new KeyContainerPermission(KeyContainerPermissionFlags.Create);
				keyContainerPermission.Demand();
			}
			if (x509ContentType == X509ContentType.Pfx && !AppDomain.IsStillInEarlyInit())
			{
				IterationCountLimitEnforcer.EnforceIterationCountLimit(rawData, false, passwordProvided);
			}
			uint dwFlags = X509Utils.MapKeyStorageFlags(keyStorageFlags);
			IntPtr intPtr = IntPtr.Zero;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				intPtr = X509Utils.PasswordToHGlobalUni(password);
				X509Utils.LoadCertFromBlob(rawData, intPtr, dwFlags, (keyStorageFlags & X509KeyStorageFlags.PersistKeySet) != X509KeyStorageFlags.DefaultKeySet, this.m_safeCertContext);
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
				}
			}
		}

		// Token: 0x0600246C RID: 9324 RVA: 0x000832C0 File Offset: 0x000814C0
		[SecurityCritical]
		private void LoadCertificateFromFile(string fileName, object password, X509KeyStorageFlags keyStorageFlags)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			string fullPathInternal = Path.GetFullPathInternal(fileName);
			new FileIOPermission(FileIOPermissionAccess.Read, fullPathInternal).Demand();
			X509ContentType x509ContentType = X509Utils.MapContentType(X509Utils._QueryCertFileType(fileName));
			if (x509ContentType == X509ContentType.Pfx && (keyStorageFlags & X509KeyStorageFlags.PersistKeySet) == X509KeyStorageFlags.PersistKeySet)
			{
				KeyContainerPermission keyContainerPermission = new KeyContainerPermission(KeyContainerPermissionFlags.Create);
				keyContainerPermission.Demand();
			}
			uint dwFlags = X509Utils.MapKeyStorageFlags(keyStorageFlags);
			IntPtr intPtr = IntPtr.Zero;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				intPtr = X509Utils.PasswordToHGlobalUni(password);
				X509Utils.LoadCertFromFile(fileName, intPtr, dwFlags, (keyStorageFlags & X509KeyStorageFlags.PersistKeySet) != X509KeyStorageFlags.DefaultKeySet, this.m_safeCertContext);
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
				}
			}
		}

		// Token: 0x04000D96 RID: 3478
		private const string m_format = "X509";

		// Token: 0x04000D97 RID: 3479
		private string m_subjectName;

		// Token: 0x04000D98 RID: 3480
		private string m_issuerName;

		// Token: 0x04000D99 RID: 3481
		private byte[] m_serialNumber;

		// Token: 0x04000D9A RID: 3482
		private byte[] m_publicKeyParameters;

		// Token: 0x04000D9B RID: 3483
		private byte[] m_publicKeyValue;

		// Token: 0x04000D9C RID: 3484
		private string m_publicKeyOid;

		// Token: 0x04000D9D RID: 3485
		private byte[] m_rawData;

		// Token: 0x04000D9E RID: 3486
		private byte[] m_thumbprint;

		// Token: 0x04000D9F RID: 3487
		private DateTime m_notBefore;

		// Token: 0x04000DA0 RID: 3488
		private DateTime m_notAfter;

		// Token: 0x04000DA1 RID: 3489
		[SecurityCritical]
		private SafeCertContextHandle m_safeCertContext;

		// Token: 0x04000DA2 RID: 3490
		private bool m_certContextCloned;

		// Token: 0x04000DA3 RID: 3491
		internal const X509KeyStorageFlags KeyStorageFlagsAll = X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable | X509KeyStorageFlags.UserProtected | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.EphemeralKeySet;
	}
}
