using System;
using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Proxies;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting
{
	// Token: 0x020007B3 RID: 1971
	internal sealed class IdentityHolder
	{
		// Token: 0x17000E12 RID: 3602
		// (get) Token: 0x0600556B RID: 21867 RVA: 0x0012F5D6 File Offset: 0x0012D7D6
		internal static Hashtable URITable
		{
			get
			{
				return IdentityHolder._URITable;
			}
		}

		// Token: 0x17000E13 RID: 3603
		// (get) Token: 0x0600556C RID: 21868 RVA: 0x0012F5DD File Offset: 0x0012D7DD
		internal static Context DefaultContext
		{
			[SecurityCritical]
			get
			{
				if (IdentityHolder._cachedDefaultContext == null)
				{
					IdentityHolder._cachedDefaultContext = Thread.GetDomain().GetDefaultContext();
				}
				return IdentityHolder._cachedDefaultContext;
			}
		}

		// Token: 0x0600556D RID: 21869 RVA: 0x0012F600 File Offset: 0x0012D800
		private static string MakeURIKey(string uri)
		{
			return Identity.RemoveAppNameOrAppGuidIfNecessary(uri.ToLower(CultureInfo.InvariantCulture));
		}

		// Token: 0x0600556E RID: 21870 RVA: 0x0012F612 File Offset: 0x0012D812
		private static string MakeURIKeyNoLower(string uri)
		{
			return Identity.RemoveAppNameOrAppGuidIfNecessary(uri);
		}

		// Token: 0x17000E14 RID: 3604
		// (get) Token: 0x0600556F RID: 21871 RVA: 0x0012F61A File Offset: 0x0012D81A
		internal static ReaderWriterLock TableLock
		{
			get
			{
				return Thread.GetDomain().RemotingData.IDTableLock;
			}
		}

		// Token: 0x06005570 RID: 21872 RVA: 0x0012F62C File Offset: 0x0012D82C
		private static void CleanupIdentities(object state)
		{
			IDictionaryEnumerator enumerator = IdentityHolder.URITable.GetEnumerator();
			ArrayList arrayList = new ArrayList();
			while (enumerator.MoveNext())
			{
				object value = enumerator.Value;
				WeakReference weakReference = value as WeakReference;
				if (weakReference != null && weakReference.Target == null)
				{
					arrayList.Add(enumerator.Key);
				}
			}
			foreach (object obj in arrayList)
			{
				string key = (string)obj;
				IdentityHolder.URITable.Remove(key);
			}
		}

		// Token: 0x06005571 RID: 21873 RVA: 0x0012F6D0 File Offset: 0x0012D8D0
		[SecurityCritical]
		internal static void FlushIdentityTable()
		{
			ReaderWriterLock tableLock = IdentityHolder.TableLock;
			bool flag = !tableLock.IsWriterLockHeld;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				if (flag)
				{
					tableLock.AcquireWriterLock(int.MaxValue);
				}
				IdentityHolder.CleanupIdentities(null);
			}
			finally
			{
				if (flag && tableLock.IsWriterLockHeld)
				{
					tableLock.ReleaseWriterLock();
				}
			}
		}

		// Token: 0x06005572 RID: 21874 RVA: 0x0012F72C File Offset: 0x0012D92C
		private IdentityHolder()
		{
		}

		// Token: 0x06005573 RID: 21875 RVA: 0x0012F734 File Offset: 0x0012D934
		[SecurityCritical]
		internal static Identity ResolveIdentity(string URI)
		{
			if (URI == null)
			{
				throw new ArgumentNullException("URI");
			}
			ReaderWriterLock tableLock = IdentityHolder.TableLock;
			bool flag = !tableLock.IsReaderLockHeld;
			RuntimeHelpers.PrepareConstrainedRegions();
			Identity result;
			try
			{
				if (flag)
				{
					tableLock.AcquireReaderLock(int.MaxValue);
				}
				result = IdentityHolder.ResolveReference(IdentityHolder.URITable[IdentityHolder.MakeURIKey(URI)]);
			}
			finally
			{
				if (flag && tableLock.IsReaderLockHeld)
				{
					tableLock.ReleaseReaderLock();
				}
			}
			return result;
		}

		// Token: 0x06005574 RID: 21876 RVA: 0x0012F7B0 File Offset: 0x0012D9B0
		[SecurityCritical]
		internal static Identity CasualResolveIdentity(string uri)
		{
			if (uri == null)
			{
				return null;
			}
			Identity identity = IdentityHolder.CasualResolveReference(IdentityHolder.URITable[IdentityHolder.MakeURIKeyNoLower(uri)]);
			if (identity == null)
			{
				identity = IdentityHolder.CasualResolveReference(IdentityHolder.URITable[IdentityHolder.MakeURIKey(uri)]);
				if (identity == null || identity.IsInitializing)
				{
					identity = RemotingConfigHandler.CreateWellKnownObject(uri);
				}
			}
			return identity;
		}

		// Token: 0x06005575 RID: 21877 RVA: 0x0012F804 File Offset: 0x0012DA04
		private static Identity ResolveReference(object o)
		{
			WeakReference weakReference = o as WeakReference;
			if (weakReference != null)
			{
				return (Identity)weakReference.Target;
			}
			return (Identity)o;
		}

		// Token: 0x06005576 RID: 21878 RVA: 0x0012F830 File Offset: 0x0012DA30
		private static Identity CasualResolveReference(object o)
		{
			WeakReference weakReference = o as WeakReference;
			if (weakReference != null)
			{
				return (Identity)weakReference.Target;
			}
			return (Identity)o;
		}

		// Token: 0x06005577 RID: 21879 RVA: 0x0012F85C File Offset: 0x0012DA5C
		[SecurityCritical]
		internal static ServerIdentity FindOrCreateServerIdentity(MarshalByRefObject obj, string objURI, int flags)
		{
			ServerIdentity serverIdentity = null;
			bool flag;
			serverIdentity = (ServerIdentity)MarshalByRefObject.GetIdentity(obj, out flag);
			if (serverIdentity == null)
			{
				Context serverCtx;
				if (obj is ContextBoundObject)
				{
					serverCtx = Thread.CurrentContext;
				}
				else
				{
					serverCtx = IdentityHolder.DefaultContext;
				}
				ServerIdentity serverIdentity2 = new ServerIdentity(obj, serverCtx);
				if (flag)
				{
					serverIdentity = obj.__RaceSetServerIdentity(serverIdentity2);
				}
				else
				{
					RealProxy realProxy = RemotingServices.GetRealProxy(obj);
					realProxy.IdentityObject = serverIdentity2;
					serverIdentity = (ServerIdentity)realProxy.IdentityObject;
				}
				if (IdOps.bIsInitializing(flags))
				{
					serverIdentity.IsInitializing = true;
				}
			}
			if (IdOps.bStrongIdentity(flags))
			{
				ReaderWriterLock tableLock = IdentityHolder.TableLock;
				bool flag2 = !tableLock.IsWriterLockHeld;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					if (flag2)
					{
						tableLock.AcquireWriterLock(int.MaxValue);
					}
					if (serverIdentity.ObjURI == null || !serverIdentity.IsInIDTable())
					{
						IdentityHolder.SetIdentity(serverIdentity, objURI, DuplicateIdentityOption.Unique);
					}
					if (serverIdentity.IsDisconnected())
					{
						serverIdentity.SetFullyConnected();
					}
				}
				finally
				{
					if (flag2 && tableLock.IsWriterLockHeld)
					{
						tableLock.ReleaseWriterLock();
					}
				}
			}
			return serverIdentity;
		}

		// Token: 0x06005578 RID: 21880 RVA: 0x0012F958 File Offset: 0x0012DB58
		[SecurityCritical]
		internal static Identity FindOrCreateIdentity(string objURI, string URL, ObjRef objectRef)
		{
			Identity identity = null;
			bool flag = URL != null;
			identity = IdentityHolder.ResolveIdentity(flag ? URL : objURI);
			if (flag && identity != null && identity is ServerIdentity)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_WellKnown_CantDirectlyConnect"), URL));
			}
			if (identity == null)
			{
				identity = new Identity(objURI, URL);
				ReaderWriterLock tableLock = IdentityHolder.TableLock;
				bool flag2 = !tableLock.IsWriterLockHeld;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					if (flag2)
					{
						tableLock.AcquireWriterLock(int.MaxValue);
					}
					identity = IdentityHolder.SetIdentity(identity, null, DuplicateIdentityOption.UseExisting);
					identity.RaceSetObjRef(objectRef);
				}
				finally
				{
					if (flag2 && tableLock.IsWriterLockHeld)
					{
						tableLock.ReleaseWriterLock();
					}
				}
			}
			return identity;
		}

		// Token: 0x06005579 RID: 21881 RVA: 0x0012FA08 File Offset: 0x0012DC08
		[SecurityCritical]
		private static Identity SetIdentity(Identity idObj, string URI, DuplicateIdentityOption duplicateOption)
		{
			bool flag = idObj is ServerIdentity;
			if (idObj.URI == null)
			{
				idObj.SetOrCreateURI(URI);
				if (idObj.ObjectRef != null)
				{
					idObj.ObjectRef.URI = idObj.URI;
				}
			}
			string key = IdentityHolder.MakeURIKey(idObj.URI);
			object obj = IdentityHolder.URITable[key];
			if (obj != null)
			{
				WeakReference weakReference = obj as WeakReference;
				Identity identity;
				bool flag2;
				if (weakReference != null)
				{
					identity = (Identity)weakReference.Target;
					flag2 = (identity is ServerIdentity);
				}
				else
				{
					identity = (Identity)obj;
					flag2 = (identity is ServerIdentity);
				}
				if (identity != null && identity != idObj)
				{
					if (duplicateOption == DuplicateIdentityOption.Unique)
					{
						string uri = idObj.URI;
						throw new RemotingException(Environment.GetResourceString("Remoting_URIClash", new object[]
						{
							uri
						}));
					}
					if (duplicateOption == DuplicateIdentityOption.UseExisting)
					{
						idObj = identity;
					}
				}
				else if (weakReference != null)
				{
					if (flag2)
					{
						IdentityHolder.URITable[key] = idObj;
					}
					else
					{
						weakReference.Target = idObj;
					}
				}
			}
			else
			{
				object value;
				if (flag)
				{
					value = idObj;
					((ServerIdentity)idObj).SetHandle();
				}
				else
				{
					value = new WeakReference(idObj);
				}
				IdentityHolder.URITable.Add(key, value);
				idObj.SetInIDTable();
				IdentityHolder.SetIDCount++;
				if (IdentityHolder.SetIDCount % 64 == 0)
				{
					IdentityHolder.CleanupIdentities(null);
				}
			}
			return idObj;
		}

		// Token: 0x0600557A RID: 21882 RVA: 0x0012FB53 File Offset: 0x0012DD53
		[SecurityCritical]
		internal static void RemoveIdentity(string uri)
		{
			IdentityHolder.RemoveIdentity(uri, true);
		}

		// Token: 0x0600557B RID: 21883 RVA: 0x0012FB5C File Offset: 0x0012DD5C
		[SecurityCritical]
		internal static void RemoveIdentity(string uri, bool bResetURI)
		{
			string key = IdentityHolder.MakeURIKey(uri);
			ReaderWriterLock tableLock = IdentityHolder.TableLock;
			bool flag = !tableLock.IsWriterLockHeld;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				if (flag)
				{
					tableLock.AcquireWriterLock(int.MaxValue);
				}
				object obj = IdentityHolder.URITable[key];
				WeakReference weakReference = obj as WeakReference;
				Identity identity;
				if (weakReference != null)
				{
					identity = (Identity)weakReference.Target;
					weakReference.Target = null;
				}
				else
				{
					identity = (Identity)obj;
					if (identity != null)
					{
						((ServerIdentity)identity).ResetHandle();
					}
				}
				if (identity != null)
				{
					IdentityHolder.URITable.Remove(key);
					identity.ResetInIDTable(bResetURI);
				}
			}
			finally
			{
				if (flag && tableLock.IsWriterLockHeld)
				{
					tableLock.ReleaseWriterLock();
				}
			}
		}

		// Token: 0x0600557C RID: 21884 RVA: 0x0012FC14 File Offset: 0x0012DE14
		[SecurityCritical]
		internal static bool AddDynamicProperty(MarshalByRefObject obj, IDynamicProperty prop)
		{
			if (RemotingServices.IsObjectOutOfContext(obj))
			{
				RealProxy realProxy = RemotingServices.GetRealProxy(obj);
				return realProxy.IdentityObject.AddProxySideDynamicProperty(prop);
			}
			MarshalByRefObject obj2 = (MarshalByRefObject)RemotingServices.AlwaysUnwrap((ContextBoundObject)obj);
			ServerIdentity serverIdentity = (ServerIdentity)MarshalByRefObject.GetIdentity(obj2);
			if (serverIdentity != null)
			{
				return serverIdentity.AddServerSideDynamicProperty(prop);
			}
			throw new RemotingException(Environment.GetResourceString("Remoting_NoIdentityEntry"));
		}

		// Token: 0x0600557D RID: 21885 RVA: 0x0012FC74 File Offset: 0x0012DE74
		[SecurityCritical]
		internal static bool RemoveDynamicProperty(MarshalByRefObject obj, string name)
		{
			if (RemotingServices.IsObjectOutOfContext(obj))
			{
				RealProxy realProxy = RemotingServices.GetRealProxy(obj);
				return realProxy.IdentityObject.RemoveProxySideDynamicProperty(name);
			}
			MarshalByRefObject obj2 = (MarshalByRefObject)RemotingServices.AlwaysUnwrap((ContextBoundObject)obj);
			ServerIdentity serverIdentity = (ServerIdentity)MarshalByRefObject.GetIdentity(obj2);
			if (serverIdentity != null)
			{
				return serverIdentity.RemoveServerSideDynamicProperty(name);
			}
			throw new RemotingException(Environment.GetResourceString("Remoting_NoIdentityEntry"));
		}

		// Token: 0x04002759 RID: 10073
		private static volatile int SetIDCount = 0;

		// Token: 0x0400275A RID: 10074
		private const int CleanUpCountInterval = 64;

		// Token: 0x0400275B RID: 10075
		private const int INFINITE = 2147483647;

		// Token: 0x0400275C RID: 10076
		private static Hashtable _URITable = new Hashtable();

		// Token: 0x0400275D RID: 10077
		private static volatile Context _cachedDefaultContext = null;
	}
}
