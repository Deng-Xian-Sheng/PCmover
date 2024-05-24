using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Util;

namespace System.Security.Policy
{
	// Token: 0x02000374 RID: 884
	[ComVisible(true)]
	[Serializable]
	public sealed class Hash : EvidenceBase, ISerializable
	{
		// Token: 0x06002BCB RID: 11211 RVA: 0x000A2FC4 File Offset: 0x000A11C4
		[SecurityCritical]
		internal Hash(SerializationInfo info, StreamingContext context)
		{
			Dictionary<Type, byte[]> dictionary = info.GetValueNoThrow("Hashes", typeof(Dictionary<Type, byte[]>)) as Dictionary<Type, byte[]>;
			if (dictionary != null)
			{
				this.m_hashes = dictionary;
				return;
			}
			this.m_hashes = new Dictionary<Type, byte[]>();
			byte[] array = info.GetValueNoThrow("Md5", typeof(byte[])) as byte[];
			if (array != null)
			{
				this.m_hashes[typeof(MD5)] = array;
			}
			byte[] array2 = info.GetValueNoThrow("Sha1", typeof(byte[])) as byte[];
			if (array2 != null)
			{
				this.m_hashes[typeof(SHA1)] = array2;
			}
			byte[] array3 = info.GetValueNoThrow("RawData", typeof(byte[])) as byte[];
			if (array3 != null)
			{
				this.GenerateDefaultHashes(array3);
			}
		}

		// Token: 0x06002BCC RID: 11212 RVA: 0x000A3098 File Offset: 0x000A1298
		public Hash(Assembly assembly)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException("assembly");
			}
			if (assembly.IsDynamic)
			{
				throw new ArgumentException(Environment.GetResourceString("Security_CannotGenerateHash"), "assembly");
			}
			this.m_hashes = new Dictionary<Type, byte[]>();
			this.m_assembly = (assembly as RuntimeAssembly);
			if (this.m_assembly == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeAssembly"), "assembly");
			}
		}

		// Token: 0x06002BCD RID: 11213 RVA: 0x000A3116 File Offset: 0x000A1316
		private Hash(Hash hash)
		{
			this.m_assembly = hash.m_assembly;
			this.m_rawData = hash.m_rawData;
			this.m_hashes = new Dictionary<Type, byte[]>(hash.m_hashes);
		}

		// Token: 0x06002BCE RID: 11214 RVA: 0x000A3148 File Offset: 0x000A1348
		private Hash(Type hashType, byte[] hashValue)
		{
			this.m_hashes = new Dictionary<Type, byte[]>();
			byte[] array = new byte[hashValue.Length];
			Array.Copy(hashValue, array, array.Length);
			this.m_hashes[hashType] = hashValue;
		}

		// Token: 0x06002BCF RID: 11215 RVA: 0x000A3186 File Offset: 0x000A1386
		public static Hash CreateSHA1(byte[] sha1)
		{
			if (sha1 == null)
			{
				throw new ArgumentNullException("sha1");
			}
			return new Hash(typeof(SHA1), sha1);
		}

		// Token: 0x06002BD0 RID: 11216 RVA: 0x000A31A6 File Offset: 0x000A13A6
		public static Hash CreateSHA256(byte[] sha256)
		{
			if (sha256 == null)
			{
				throw new ArgumentNullException("sha256");
			}
			return new Hash(typeof(SHA256), sha256);
		}

		// Token: 0x06002BD1 RID: 11217 RVA: 0x000A31C6 File Offset: 0x000A13C6
		public static Hash CreateMD5(byte[] md5)
		{
			if (md5 == null)
			{
				throw new ArgumentNullException("md5");
			}
			return new Hash(typeof(MD5), md5);
		}

		// Token: 0x06002BD2 RID: 11218 RVA: 0x000A31E6 File Offset: 0x000A13E6
		public override EvidenceBase Clone()
		{
			return new Hash(this);
		}

		// Token: 0x06002BD3 RID: 11219 RVA: 0x000A31EE File Offset: 0x000A13EE
		[OnSerializing]
		private void OnSerializing(StreamingContext ctx)
		{
			this.GenerateDefaultHashes();
		}

		// Token: 0x06002BD4 RID: 11220 RVA: 0x000A31F8 File Offset: 0x000A13F8
		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			this.GenerateDefaultHashes();
			byte[] value;
			if (this.m_hashes.TryGetValue(typeof(MD5), out value))
			{
				info.AddValue("Md5", value);
			}
			byte[] value2;
			if (this.m_hashes.TryGetValue(typeof(SHA1), out value2))
			{
				info.AddValue("Sha1", value2);
			}
			info.AddValue("RawData", null);
			info.AddValue("PEFile", IntPtr.Zero);
			info.AddValue("Hashes", this.m_hashes);
		}

		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x06002BD5 RID: 11221 RVA: 0x000A3288 File Offset: 0x000A1488
		public byte[] SHA1
		{
			get
			{
				byte[] array = null;
				if (!this.m_hashes.TryGetValue(typeof(SHA1), out array))
				{
					array = this.GenerateHash(Hash.GetDefaultHashImplementationOrFallback(typeof(SHA1), typeof(SHA1)));
				}
				byte[] array2 = new byte[array.Length];
				Array.Copy(array, array2, array2.Length);
				return array2;
			}
		}

		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x06002BD6 RID: 11222 RVA: 0x000A32E4 File Offset: 0x000A14E4
		public byte[] SHA256
		{
			get
			{
				byte[] array = null;
				if (!this.m_hashes.TryGetValue(typeof(SHA256), out array))
				{
					array = this.GenerateHash(Hash.GetDefaultHashImplementationOrFallback(typeof(SHA256), typeof(SHA256)));
				}
				byte[] array2 = new byte[array.Length];
				Array.Copy(array, array2, array2.Length);
				return array2;
			}
		}

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x06002BD7 RID: 11223 RVA: 0x000A3340 File Offset: 0x000A1540
		public byte[] MD5
		{
			get
			{
				byte[] array = null;
				if (!this.m_hashes.TryGetValue(typeof(MD5), out array))
				{
					array = this.GenerateHash(Hash.GetDefaultHashImplementationOrFallback(typeof(MD5), typeof(MD5)));
				}
				byte[] array2 = new byte[array.Length];
				Array.Copy(array, array2, array2.Length);
				return array2;
			}
		}

		// Token: 0x06002BD8 RID: 11224 RVA: 0x000A339C File Offset: 0x000A159C
		public byte[] GenerateHash(HashAlgorithm hashAlg)
		{
			if (hashAlg == null)
			{
				throw new ArgumentNullException("hashAlg");
			}
			byte[] array = this.GenerateHash(hashAlg.GetType());
			byte[] array2 = new byte[array.Length];
			Array.Copy(array, array2, array2.Length);
			return array2;
		}

		// Token: 0x06002BD9 RID: 11225 RVA: 0x000A33D8 File Offset: 0x000A15D8
		private byte[] GenerateHash(Type hashType)
		{
			Type hashIndexType = Hash.GetHashIndexType(hashType);
			byte[] array = null;
			if (!this.m_hashes.TryGetValue(hashIndexType, out array))
			{
				if (this.m_assembly == null)
				{
					throw new InvalidOperationException(Environment.GetResourceString("Security_CannotGenerateHash"));
				}
				array = Hash.GenerateHash(hashType, this.GetRawData());
				this.m_hashes[hashIndexType] = array;
			}
			return array;
		}

		// Token: 0x06002BDA RID: 11226 RVA: 0x000A3438 File Offset: 0x000A1638
		private static byte[] GenerateHash(Type hashType, byte[] assemblyBytes)
		{
			byte[] result;
			using (HashAlgorithm hashAlgorithm = HashAlgorithm.Create(hashType.FullName))
			{
				result = hashAlgorithm.ComputeHash(assemblyBytes);
			}
			return result;
		}

		// Token: 0x06002BDB RID: 11227 RVA: 0x000A3478 File Offset: 0x000A1678
		private void GenerateDefaultHashes()
		{
			if (this.m_assembly != null)
			{
				this.GenerateDefaultHashes(this.GetRawData());
			}
		}

		// Token: 0x06002BDC RID: 11228 RVA: 0x000A3494 File Offset: 0x000A1694
		private void GenerateDefaultHashes(byte[] assemblyBytes)
		{
			Type[] array = new Type[]
			{
				Hash.GetHashIndexType(typeof(SHA1)),
				Hash.GetHashIndexType(typeof(SHA256)),
				Hash.GetHashIndexType(typeof(MD5))
			};
			foreach (Type type in array)
			{
				Type defaultHashImplementation = Hash.GetDefaultHashImplementation(type);
				if (defaultHashImplementation != null && !this.m_hashes.ContainsKey(type))
				{
					this.m_hashes[type] = Hash.GenerateHash(defaultHashImplementation, assemblyBytes);
				}
			}
		}

		// Token: 0x06002BDD RID: 11229 RVA: 0x000A3528 File Offset: 0x000A1728
		private static Type GetDefaultHashImplementationOrFallback(Type hashAlgorithm, Type fallbackImplementation)
		{
			Type defaultHashImplementation = Hash.GetDefaultHashImplementation(hashAlgorithm);
			if (!(defaultHashImplementation != null))
			{
				return fallbackImplementation;
			}
			return defaultHashImplementation;
		}

		// Token: 0x06002BDE RID: 11230 RVA: 0x000A3548 File Offset: 0x000A1748
		private static Type GetDefaultHashImplementation(Type hashAlgorithm)
		{
			if (hashAlgorithm.IsAssignableFrom(typeof(MD5)))
			{
				if (!CryptoConfig.AllowOnlyFipsAlgorithms)
				{
					return typeof(MD5CryptoServiceProvider);
				}
				return null;
			}
			else
			{
				if (hashAlgorithm.IsAssignableFrom(typeof(SHA256)))
				{
					return Type.GetType("System.Security.Cryptography.SHA256CryptoServiceProvider, System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
				}
				return hashAlgorithm;
			}
		}

		// Token: 0x06002BDF RID: 11231 RVA: 0x000A359C File Offset: 0x000A179C
		private static Type GetHashIndexType(Type hashType)
		{
			Type type = hashType;
			while (type != null && type.BaseType != typeof(HashAlgorithm))
			{
				type = type.BaseType;
			}
			if (type == null)
			{
				type = typeof(HashAlgorithm);
			}
			return type;
		}

		// Token: 0x06002BE0 RID: 11232 RVA: 0x000A35EC File Offset: 0x000A17EC
		private byte[] GetRawData()
		{
			byte[] array = null;
			if (this.m_assembly != null)
			{
				if (this.m_rawData != null)
				{
					array = (this.m_rawData.Target as byte[]);
				}
				if (array == null)
				{
					array = this.m_assembly.GetRawBytes();
					this.m_rawData = new WeakReference(array);
				}
			}
			return array;
		}

		// Token: 0x06002BE1 RID: 11233 RVA: 0x000A3640 File Offset: 0x000A1840
		private SecurityElement ToXml()
		{
			this.GenerateDefaultHashes();
			SecurityElement securityElement = new SecurityElement("System.Security.Policy.Hash");
			securityElement.AddAttribute("version", "2");
			foreach (KeyValuePair<Type, byte[]> keyValuePair in this.m_hashes)
			{
				SecurityElement securityElement2 = new SecurityElement("hash");
				securityElement2.AddAttribute("algorithm", keyValuePair.Key.Name);
				securityElement2.AddAttribute("value", Hex.EncodeHexString(keyValuePair.Value));
				securityElement.AddChild(securityElement2);
			}
			return securityElement;
		}

		// Token: 0x06002BE2 RID: 11234 RVA: 0x000A36F0 File Offset: 0x000A18F0
		public override string ToString()
		{
			return this.ToXml().ToString();
		}

		// Token: 0x040011A9 RID: 4521
		private RuntimeAssembly m_assembly;

		// Token: 0x040011AA RID: 4522
		private Dictionary<Type, byte[]> m_hashes;

		// Token: 0x040011AB RID: 4523
		private WeakReference m_rawData;
	}
}
