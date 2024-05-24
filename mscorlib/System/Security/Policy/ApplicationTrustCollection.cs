using System;
using System.Collections;
using System.Deployment.Internal.Isolation;
using System.Deployment.Internal.Isolation.Manifest;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Security.Policy
{
	// Token: 0x02000346 RID: 838
	[SecurityCritical]
	[ComVisible(true)]
	public sealed class ApplicationTrustCollection : ICollection, IEnumerable
	{
		// Token: 0x17000575 RID: 1397
		// (get) Token: 0x060029A3 RID: 10659 RVA: 0x00099E13 File Offset: 0x00098013
		private static StoreApplicationReference InstallReference
		{
			get
			{
				if (ApplicationTrustCollection.s_installReference == null)
				{
					Interlocked.CompareExchange(ref ApplicationTrustCollection.s_installReference, new StoreApplicationReference(IsolationInterop.GUID_SXS_INSTALL_REFERENCE_SCHEME_OPAQUESTRING, "{60051b8f-4f12-400a-8e50-dd05ebd438d1}", null), null);
				}
				return (StoreApplicationReference)ApplicationTrustCollection.s_installReference;
			}
		}

		// Token: 0x17000576 RID: 1398
		// (get) Token: 0x060029A4 RID: 10660 RVA: 0x00099E48 File Offset: 0x00098048
		private ArrayList AppTrusts
		{
			[SecurityCritical]
			get
			{
				if (this.m_appTrusts == null)
				{
					ArrayList arrayList = new ArrayList();
					if (this.m_storeBounded)
					{
						this.RefreshStorePointer();
						StoreDeploymentMetadataEnumeration storeDeploymentMetadataEnumeration = this.m_pStore.EnumInstallerDeployments(IsolationInterop.GUID_SXS_INSTALL_REFERENCE_SCHEME_OPAQUESTRING, "{60051b8f-4f12-400a-8e50-dd05ebd438d1}", "ApplicationTrust", null);
						foreach (object obj in storeDeploymentMetadataEnumeration)
						{
							IDefinitionAppId deployment = (IDefinitionAppId)obj;
							StoreDeploymentMetadataPropertyEnumeration storeDeploymentMetadataPropertyEnumeration = this.m_pStore.EnumInstallerDeploymentProperties(IsolationInterop.GUID_SXS_INSTALL_REFERENCE_SCHEME_OPAQUESTRING, "{60051b8f-4f12-400a-8e50-dd05ebd438d1}", "ApplicationTrust", deployment);
							foreach (object obj2 in storeDeploymentMetadataPropertyEnumeration)
							{
								StoreOperationMetadataProperty storeOperationMetadataProperty = (StoreOperationMetadataProperty)obj2;
								string value = storeOperationMetadataProperty.Value;
								if (value != null && value.Length > 0)
								{
									SecurityElement element = SecurityElement.FromString(value);
									ApplicationTrust applicationTrust = new ApplicationTrust();
									applicationTrust.FromXml(element);
									arrayList.Add(applicationTrust);
								}
							}
						}
					}
					Interlocked.CompareExchange(ref this.m_appTrusts, arrayList, null);
				}
				return this.m_appTrusts as ArrayList;
			}
		}

		// Token: 0x060029A5 RID: 10661 RVA: 0x00099F90 File Offset: 0x00098190
		[SecurityCritical]
		internal ApplicationTrustCollection() : this(false)
		{
		}

		// Token: 0x060029A6 RID: 10662 RVA: 0x00099F99 File Offset: 0x00098199
		internal ApplicationTrustCollection(bool storeBounded)
		{
			this.m_storeBounded = storeBounded;
		}

		// Token: 0x060029A7 RID: 10663 RVA: 0x00099FA8 File Offset: 0x000981A8
		[SecurityCritical]
		private void RefreshStorePointer()
		{
			if (this.m_pStore != null)
			{
				Marshal.ReleaseComObject(this.m_pStore.InternalStore);
			}
			this.m_pStore = IsolationInterop.GetUserStore();
		}

		// Token: 0x17000577 RID: 1399
		// (get) Token: 0x060029A8 RID: 10664 RVA: 0x00099FCE File Offset: 0x000981CE
		public int Count
		{
			[SecuritySafeCritical]
			get
			{
				return this.AppTrusts.Count;
			}
		}

		// Token: 0x17000578 RID: 1400
		public ApplicationTrust this[int index]
		{
			[SecurityCritical]
			get
			{
				return this.AppTrusts[index] as ApplicationTrust;
			}
		}

		// Token: 0x17000579 RID: 1401
		public ApplicationTrust this[string appFullName]
		{
			[SecurityCritical]
			get
			{
				ApplicationIdentity applicationIdentity = new ApplicationIdentity(appFullName);
				ApplicationTrustCollection applicationTrustCollection = this.Find(applicationIdentity, ApplicationVersionMatch.MatchExactVersion);
				if (applicationTrustCollection.Count > 0)
				{
					return applicationTrustCollection[0];
				}
				return null;
			}
		}

		// Token: 0x060029AB RID: 10667 RVA: 0x0009A020 File Offset: 0x00098220
		[SecurityCritical]
		private void CommitApplicationTrust(ApplicationIdentity applicationIdentity, string trustXml)
		{
			StoreOperationMetadataProperty[] setProperties = new StoreOperationMetadataProperty[]
			{
				new StoreOperationMetadataProperty(ApplicationTrustCollection.ClrPropertySet, "ApplicationTrust", trustXml)
			};
			IEnumDefinitionIdentity enumDefinitionIdentity = applicationIdentity.Identity.EnumAppPath();
			IDefinitionIdentity[] array = new IDefinitionIdentity[1];
			IDefinitionIdentity definitionIdentity = null;
			if (enumDefinitionIdentity.Next(1U, array) == 1U)
			{
				definitionIdentity = array[0];
			}
			IDefinitionAppId definitionAppId = IsolationInterop.AppIdAuthority.CreateDefinition();
			definitionAppId.SetAppPath(1U, new IDefinitionIdentity[]
			{
				definitionIdentity
			});
			definitionAppId.put_Codebase(applicationIdentity.CodeBase);
			using (StoreTransaction storeTransaction = new StoreTransaction())
			{
				storeTransaction.Add(new StoreOperationSetDeploymentMetadata(definitionAppId, ApplicationTrustCollection.InstallReference, setProperties));
				this.RefreshStorePointer();
				this.m_pStore.Transact(storeTransaction.Operations);
			}
			this.m_appTrusts = null;
		}

		// Token: 0x060029AC RID: 10668 RVA: 0x0009A0F4 File Offset: 0x000982F4
		[SecurityCritical]
		public int Add(ApplicationTrust trust)
		{
			if (trust == null)
			{
				throw new ArgumentNullException("trust");
			}
			if (trust.ApplicationIdentity == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ApplicationTrustShouldHaveIdentity"));
			}
			if (this.m_storeBounded)
			{
				this.CommitApplicationTrust(trust.ApplicationIdentity, trust.ToXml().ToString());
				return -1;
			}
			return this.AppTrusts.Add(trust);
		}

		// Token: 0x060029AD RID: 10669 RVA: 0x0009A154 File Offset: 0x00098354
		[SecurityCritical]
		public void AddRange(ApplicationTrust[] trusts)
		{
			if (trusts == null)
			{
				throw new ArgumentNullException("trusts");
			}
			int i = 0;
			try
			{
				while (i < trusts.Length)
				{
					this.Add(trusts[i]);
					i++;
				}
			}
			catch
			{
				for (int j = 0; j < i; j++)
				{
					this.Remove(trusts[j]);
				}
				throw;
			}
		}

		// Token: 0x060029AE RID: 10670 RVA: 0x0009A1B4 File Offset: 0x000983B4
		[SecurityCritical]
		public void AddRange(ApplicationTrustCollection trusts)
		{
			if (trusts == null)
			{
				throw new ArgumentNullException("trusts");
			}
			int num = 0;
			try
			{
				foreach (ApplicationTrust trust in trusts)
				{
					this.Add(trust);
					num++;
				}
			}
			catch
			{
				for (int i = 0; i < num; i++)
				{
					this.Remove(trusts[i]);
				}
				throw;
			}
		}

		// Token: 0x060029AF RID: 10671 RVA: 0x0009A224 File Offset: 0x00098424
		[SecurityCritical]
		public ApplicationTrustCollection Find(ApplicationIdentity applicationIdentity, ApplicationVersionMatch versionMatch)
		{
			ApplicationTrustCollection applicationTrustCollection = new ApplicationTrustCollection(false);
			foreach (ApplicationTrust applicationTrust in this)
			{
				if (CmsUtils.CompareIdentities(applicationTrust.ApplicationIdentity, applicationIdentity, versionMatch))
				{
					applicationTrustCollection.Add(applicationTrust);
				}
			}
			return applicationTrustCollection;
		}

		// Token: 0x060029B0 RID: 10672 RVA: 0x0009A268 File Offset: 0x00098468
		[SecurityCritical]
		public void Remove(ApplicationIdentity applicationIdentity, ApplicationVersionMatch versionMatch)
		{
			ApplicationTrustCollection trusts = this.Find(applicationIdentity, versionMatch);
			this.RemoveRange(trusts);
		}

		// Token: 0x060029B1 RID: 10673 RVA: 0x0009A288 File Offset: 0x00098488
		[SecurityCritical]
		public void Remove(ApplicationTrust trust)
		{
			if (trust == null)
			{
				throw new ArgumentNullException("trust");
			}
			if (trust.ApplicationIdentity == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ApplicationTrustShouldHaveIdentity"));
			}
			if (this.m_storeBounded)
			{
				this.CommitApplicationTrust(trust.ApplicationIdentity, null);
				return;
			}
			this.AppTrusts.Remove(trust);
		}

		// Token: 0x060029B2 RID: 10674 RVA: 0x0009A2E0 File Offset: 0x000984E0
		[SecurityCritical]
		public void RemoveRange(ApplicationTrust[] trusts)
		{
			if (trusts == null)
			{
				throw new ArgumentNullException("trusts");
			}
			int i = 0;
			try
			{
				while (i < trusts.Length)
				{
					this.Remove(trusts[i]);
					i++;
				}
			}
			catch
			{
				for (int j = 0; j < i; j++)
				{
					this.Add(trusts[j]);
				}
				throw;
			}
		}

		// Token: 0x060029B3 RID: 10675 RVA: 0x0009A340 File Offset: 0x00098540
		[SecurityCritical]
		public void RemoveRange(ApplicationTrustCollection trusts)
		{
			if (trusts == null)
			{
				throw new ArgumentNullException("trusts");
			}
			int num = 0;
			try
			{
				foreach (ApplicationTrust trust in trusts)
				{
					this.Remove(trust);
					num++;
				}
			}
			catch
			{
				for (int i = 0; i < num; i++)
				{
					this.Add(trusts[i]);
				}
				throw;
			}
		}

		// Token: 0x060029B4 RID: 10676 RVA: 0x0009A3B0 File Offset: 0x000985B0
		[SecurityCritical]
		public void Clear()
		{
			ArrayList appTrusts = this.AppTrusts;
			if (this.m_storeBounded)
			{
				foreach (object obj in appTrusts)
				{
					ApplicationTrust applicationTrust = (ApplicationTrust)obj;
					if (applicationTrust.ApplicationIdentity == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_ApplicationTrustShouldHaveIdentity"));
					}
					this.CommitApplicationTrust(applicationTrust.ApplicationIdentity, null);
				}
			}
			appTrusts.Clear();
		}

		// Token: 0x060029B5 RID: 10677 RVA: 0x0009A438 File Offset: 0x00098638
		public ApplicationTrustEnumerator GetEnumerator()
		{
			return new ApplicationTrustEnumerator(this);
		}

		// Token: 0x060029B6 RID: 10678 RVA: 0x0009A440 File Offset: 0x00098640
		[SecuritySafeCritical]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new ApplicationTrustEnumerator(this);
		}

		// Token: 0x060029B7 RID: 10679 RVA: 0x0009A448 File Offset: 0x00098648
		[SecuritySafeCritical]
		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_RankMultiDimNotSupported"));
			}
			if (index < 0 || index >= array.Length)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			if (array.Length - index < this.Count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			for (int i = 0; i < this.Count; i++)
			{
				array.SetValue(this[i], index++);
			}
		}

		// Token: 0x060029B8 RID: 10680 RVA: 0x0009A4E2 File Offset: 0x000986E2
		public void CopyTo(ApplicationTrust[] array, int index)
		{
			((ICollection)this).CopyTo(array, index);
		}

		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x060029B9 RID: 10681 RVA: 0x0009A4EC File Offset: 0x000986EC
		public bool IsSynchronized
		{
			[SecuritySafeCritical]
			get
			{
				return false;
			}
		}

		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x060029BA RID: 10682 RVA: 0x0009A4EF File Offset: 0x000986EF
		public object SyncRoot
		{
			[SecuritySafeCritical]
			get
			{
				return this;
			}
		}

		// Token: 0x04001115 RID: 4373
		private const string ApplicationTrustProperty = "ApplicationTrust";

		// Token: 0x04001116 RID: 4374
		private const string InstallerIdentifier = "{60051b8f-4f12-400a-8e50-dd05ebd438d1}";

		// Token: 0x04001117 RID: 4375
		private static Guid ClrPropertySet = new Guid("c989bb7a-8385-4715-98cf-a741a8edb823");

		// Token: 0x04001118 RID: 4376
		private static object s_installReference = null;

		// Token: 0x04001119 RID: 4377
		private object m_appTrusts;

		// Token: 0x0400111A RID: 4378
		private bool m_storeBounded;

		// Token: 0x0400111B RID: 4379
		private Store m_pStore;
	}
}
