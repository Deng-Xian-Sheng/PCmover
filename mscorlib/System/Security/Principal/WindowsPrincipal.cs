using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Permissions;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Principal
{
	// Token: 0x02000332 RID: 818
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, SecurityInfrastructure = true)]
	[Serializable]
	public class WindowsPrincipal : ClaimsPrincipal
	{
		// Token: 0x060028E8 RID: 10472 RVA: 0x00096DA4 File Offset: 0x00094FA4
		private WindowsPrincipal()
		{
		}

		// Token: 0x060028E9 RID: 10473 RVA: 0x00096DAC File Offset: 0x00094FAC
		public WindowsPrincipal(WindowsIdentity ntIdentity) : base(ntIdentity)
		{
			if (ntIdentity == null)
			{
				throw new ArgumentNullException("ntIdentity");
			}
			this.m_identity = ntIdentity;
		}

		// Token: 0x060028EA RID: 10474 RVA: 0x00096DCC File Offset: 0x00094FCC
		[OnDeserialized]
		[SecuritySafeCritical]
		private void OnDeserializedMethod(StreamingContext context)
		{
			ClaimsIdentity claimsIdentity = null;
			foreach (ClaimsIdentity claimsIdentity2 in base.Identities)
			{
				if (claimsIdentity2 != null)
				{
					claimsIdentity = claimsIdentity2;
					break;
				}
			}
			if (claimsIdentity == null)
			{
				base.AddIdentity(this.m_identity);
			}
		}

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x060028EB RID: 10475 RVA: 0x00096E2C File Offset: 0x0009502C
		public override IIdentity Identity
		{
			get
			{
				return this.m_identity;
			}
		}

		// Token: 0x060028EC RID: 10476 RVA: 0x00096E34 File Offset: 0x00095034
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlPrincipal = true)]
		public override bool IsInRole(string role)
		{
			if (role == null || role.Length == 0)
			{
				return false;
			}
			NTAccount identity = new NTAccount(role);
			IdentityReferenceCollection identityReferenceCollection = NTAccount.Translate(new IdentityReferenceCollection(1)
			{
				identity
			}, typeof(SecurityIdentifier), false);
			SecurityIdentifier securityIdentifier = identityReferenceCollection[0] as SecurityIdentifier;
			return (securityIdentifier != null && this.IsInRole(securityIdentifier)) || base.IsInRole(role);
		}

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x060028ED RID: 10477 RVA: 0x00096EA0 File Offset: 0x000950A0
		public virtual IEnumerable<Claim> UserClaims
		{
			get
			{
				foreach (ClaimsIdentity claimsIdentity in this.Identities)
				{
					WindowsIdentity windowsIdentity = claimsIdentity as WindowsIdentity;
					if (windowsIdentity != null)
					{
						foreach (Claim claim in windowsIdentity.UserClaims)
						{
							yield return claim;
						}
						IEnumerator<Claim> enumerator2 = null;
					}
				}
				IEnumerator<ClaimsIdentity> enumerator = null;
				yield break;
				yield break;
			}
		}

		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x060028EE RID: 10478 RVA: 0x00096EC0 File Offset: 0x000950C0
		public virtual IEnumerable<Claim> DeviceClaims
		{
			get
			{
				foreach (ClaimsIdentity claimsIdentity in this.Identities)
				{
					WindowsIdentity windowsIdentity = claimsIdentity as WindowsIdentity;
					if (windowsIdentity != null)
					{
						foreach (Claim claim in windowsIdentity.DeviceClaims)
						{
							yield return claim;
						}
						IEnumerator<Claim> enumerator2 = null;
					}
				}
				IEnumerator<ClaimsIdentity> enumerator = null;
				yield break;
				yield break;
			}
		}

		// Token: 0x060028EF RID: 10479 RVA: 0x00096EDD File Offset: 0x000950DD
		public virtual bool IsInRole(WindowsBuiltInRole role)
		{
			if (role < WindowsBuiltInRole.Administrator || role > WindowsBuiltInRole.Replicator)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
				{
					(int)role
				}), "role");
			}
			return this.IsInRole((int)role);
		}

		// Token: 0x060028F0 RID: 10480 RVA: 0x00096F1C File Offset: 0x0009511C
		public virtual bool IsInRole(int rid)
		{
			SecurityIdentifier sid = new SecurityIdentifier(IdentifierAuthority.NTAuthority, new int[]
			{
				32,
				rid
			});
			return this.IsInRole(sid);
		}

		// Token: 0x060028F1 RID: 10481 RVA: 0x00096F48 File Offset: 0x00095148
		[SecuritySafeCritical]
		[ComVisible(false)]
		public virtual bool IsInRole(SecurityIdentifier sid)
		{
			if (sid == null)
			{
				throw new ArgumentNullException("sid");
			}
			if (this.m_identity.AccessToken.IsInvalid)
			{
				return false;
			}
			SafeAccessTokenHandle invalidHandle = SafeAccessTokenHandle.InvalidHandle;
			if (this.m_identity.ImpersonationLevel == TokenImpersonationLevel.None && !Win32Native.DuplicateTokenEx(this.m_identity.AccessToken, 8U, IntPtr.Zero, 2U, 2U, ref invalidHandle))
			{
				throw new SecurityException(Win32Native.GetMessage(Marshal.GetLastWin32Error()));
			}
			bool result = false;
			if (!Win32Native.CheckTokenMembership((this.m_identity.ImpersonationLevel != TokenImpersonationLevel.None) ? this.m_identity.AccessToken : invalidHandle, sid.BinaryForm, ref result))
			{
				throw new SecurityException(Win32Native.GetMessage(Marshal.GetLastWin32Error()));
			}
			invalidHandle.Dispose();
			return result;
		}

		// Token: 0x04001085 RID: 4229
		private WindowsIdentity m_identity;

		// Token: 0x04001086 RID: 4230
		private string[] m_roles;

		// Token: 0x04001087 RID: 4231
		private Hashtable m_rolesTable;

		// Token: 0x04001088 RID: 4232
		private bool m_rolesLoaded;
	}
}
