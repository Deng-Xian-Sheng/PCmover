using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Policy
{
	// Token: 0x02000360 RID: 864
	internal sealed class PEFileEvidenceFactory : IRuntimeEvidenceFactory
	{
		// Token: 0x06002AB5 RID: 10933 RVA: 0x0009E41A File Offset: 0x0009C61A
		[SecurityCritical]
		private PEFileEvidenceFactory(SafePEFileHandle peFile)
		{
			this.m_peFile = peFile;
		}

		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x06002AB6 RID: 10934 RVA: 0x0009E429 File Offset: 0x0009C629
		internal SafePEFileHandle PEFile
		{
			[SecurityCritical]
			get
			{
				return this.m_peFile;
			}
		}

		// Token: 0x170005B5 RID: 1461
		// (get) Token: 0x06002AB7 RID: 10935 RVA: 0x0009E431 File Offset: 0x0009C631
		public IEvidenceFactory Target
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06002AB8 RID: 10936 RVA: 0x0009E434 File Offset: 0x0009C634
		[SecurityCritical]
		private static Evidence CreateSecurityIdentity(SafePEFileHandle peFile, Evidence hostProvidedEvidence)
		{
			PEFileEvidenceFactory target = new PEFileEvidenceFactory(peFile);
			Evidence evidence = new Evidence(target);
			if (hostProvidedEvidence != null)
			{
				evidence.MergeWithNoDuplicates(hostProvidedEvidence);
			}
			return evidence;
		}

		// Token: 0x06002AB9 RID: 10937
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void FireEvidenceGeneratedEvent(SafePEFileHandle peFile, EvidenceTypeGenerated type);

		// Token: 0x06002ABA RID: 10938 RVA: 0x0009E45A File Offset: 0x0009C65A
		[SecuritySafeCritical]
		internal void FireEvidenceGeneratedEvent(EvidenceTypeGenerated type)
		{
			PEFileEvidenceFactory.FireEvidenceGeneratedEvent(this.m_peFile, type);
		}

		// Token: 0x06002ABB RID: 10939
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetAssemblySuppliedEvidence(SafePEFileHandle peFile, ObjectHandleOnStack retSerializedEvidence);

		// Token: 0x06002ABC RID: 10940 RVA: 0x0009E468 File Offset: 0x0009C668
		[SecuritySafeCritical]
		public IEnumerable<EvidenceBase> GetFactorySuppliedEvidence()
		{
			if (this.m_assemblyProvidedEvidence == null)
			{
				byte[] array = null;
				PEFileEvidenceFactory.GetAssemblySuppliedEvidence(this.m_peFile, JitHelpers.GetObjectHandleOnStack<byte[]>(ref array));
				this.m_assemblyProvidedEvidence = new List<EvidenceBase>();
				if (array != null)
				{
					Evidence evidence = new Evidence();
					new SecurityPermission(SecurityPermissionFlag.SerializationFormatter).Assert();
					try
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						using (MemoryStream memoryStream = new MemoryStream(array))
						{
							evidence = (Evidence)binaryFormatter.Deserialize(memoryStream);
						}
					}
					catch
					{
					}
					CodeAccessPermission.RevertAssert();
					if (evidence != null)
					{
						IEnumerator assemblyEnumerator = evidence.GetAssemblyEnumerator();
						while (assemblyEnumerator.MoveNext())
						{
							if (assemblyEnumerator.Current != null)
							{
								EvidenceBase evidenceBase = assemblyEnumerator.Current as EvidenceBase;
								if (evidenceBase == null)
								{
									evidenceBase = new LegacyEvidenceWrapper(assemblyEnumerator.Current);
								}
								this.m_assemblyProvidedEvidence.Add(evidenceBase);
							}
						}
					}
				}
			}
			return this.m_assemblyProvidedEvidence;
		}

		// Token: 0x06002ABD RID: 10941
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetLocationEvidence(SafePEFileHandle peFile, out SecurityZone zone, StringHandleOnStack retUrl);

		// Token: 0x06002ABE RID: 10942
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetPublisherCertificate(SafePEFileHandle peFile, ObjectHandleOnStack retCertificate);

		// Token: 0x06002ABF RID: 10943 RVA: 0x0009E558 File Offset: 0x0009C758
		public EvidenceBase GenerateEvidence(Type evidenceType)
		{
			if (evidenceType == typeof(Site))
			{
				return this.GenerateSiteEvidence();
			}
			if (evidenceType == typeof(Url))
			{
				return this.GenerateUrlEvidence();
			}
			if (evidenceType == typeof(Zone))
			{
				return this.GenerateZoneEvidence();
			}
			if (evidenceType == typeof(Publisher))
			{
				return this.GeneratePublisherEvidence();
			}
			return null;
		}

		// Token: 0x06002AC0 RID: 10944 RVA: 0x0009E5CC File Offset: 0x0009C7CC
		[SecuritySafeCritical]
		private void GenerateLocationEvidence()
		{
			if (!this.m_generatedLocationEvidence)
			{
				SecurityZone securityZone = SecurityZone.NoZone;
				string text = null;
				PEFileEvidenceFactory.GetLocationEvidence(this.m_peFile, out securityZone, JitHelpers.GetStringHandleOnStack(ref text));
				if (securityZone != SecurityZone.NoZone)
				{
					this.m_zoneEvidence = new Zone(securityZone);
				}
				if (!string.IsNullOrEmpty(text))
				{
					this.m_urlEvidence = new Url(text, true);
					if (!text.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
					{
						this.m_siteEvidence = Site.CreateFromUrl(text);
					}
				}
				this.m_generatedLocationEvidence = true;
			}
		}

		// Token: 0x06002AC1 RID: 10945 RVA: 0x0009E640 File Offset: 0x0009C840
		[SecuritySafeCritical]
		private Publisher GeneratePublisherEvidence()
		{
			byte[] array = null;
			PEFileEvidenceFactory.GetPublisherCertificate(this.m_peFile, JitHelpers.GetObjectHandleOnStack<byte[]>(ref array));
			if (array == null)
			{
				return null;
			}
			return new Publisher(new X509Certificate(array));
		}

		// Token: 0x06002AC2 RID: 10946 RVA: 0x0009E671 File Offset: 0x0009C871
		private Site GenerateSiteEvidence()
		{
			if (this.m_siteEvidence == null)
			{
				this.GenerateLocationEvidence();
			}
			return this.m_siteEvidence;
		}

		// Token: 0x06002AC3 RID: 10947 RVA: 0x0009E687 File Offset: 0x0009C887
		private Url GenerateUrlEvidence()
		{
			if (this.m_urlEvidence == null)
			{
				this.GenerateLocationEvidence();
			}
			return this.m_urlEvidence;
		}

		// Token: 0x06002AC4 RID: 10948 RVA: 0x0009E69D File Offset: 0x0009C89D
		private Zone GenerateZoneEvidence()
		{
			if (this.m_zoneEvidence == null)
			{
				this.GenerateLocationEvidence();
			}
			return this.m_zoneEvidence;
		}

		// Token: 0x04001162 RID: 4450
		[SecurityCritical]
		private SafePEFileHandle m_peFile;

		// Token: 0x04001163 RID: 4451
		private List<EvidenceBase> m_assemblyProvidedEvidence;

		// Token: 0x04001164 RID: 4452
		private bool m_generatedLocationEvidence;

		// Token: 0x04001165 RID: 4453
		private Site m_siteEvidence;

		// Token: 0x04001166 RID: 4454
		private Url m_urlEvidence;

		// Token: 0x04001167 RID: 4455
		private Zone m_zoneEvidence;
	}
}
