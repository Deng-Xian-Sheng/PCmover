using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

namespace Laplink.Tools.Helpers
{
	// Token: 0x02000006 RID: 6
	public class IdentityHelper
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002553 File Offset: 0x00000753
		public static bool IsAdministrator
		{
			get
			{
				return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000256C File Offset: 0x0000076C
		public static void ExamineRoles(WindowsIdentity identity)
		{
			if (identity == null)
			{
				return;
			}
			WindowsPrincipal windowsPrincipal = new WindowsPrincipal(identity);
			windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
			windowsPrincipal.IsInRole("Administrators");
			foreach (IdentityReference identityReference in identity.Groups)
			{
				if (identityReference.IsValidTargetType(typeof(SecurityIdentifier)))
				{
					SecurityIdentifier securityIdentifier = (SecurityIdentifier)identityReference.Translate(typeof(SecurityIdentifier));
					bool flag = securityIdentifier.IsWellKnown(WellKnownSidType.AccountAdministratorSid);
					bool flag2 = securityIdentifier.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid);
					if (flag || flag2)
					{
						securityIdentifier.ToString();
					}
				}
			}
			List<string> list = new List<string>();
			foreach (IdentityReference identityReference2 in identity.Groups.Translate(typeof(NTAccount)))
			{
				list.Add(identityReference2.Value);
			}
			int count = list.Count;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000267C File Offset: 0x0000087C
		public static void ExamineClaims(ClaimsIdentity identity)
		{
			if (identity == null)
			{
				return;
			}
			foreach (Claim claim in identity.Claims)
			{
				IdentityHelper.ExamineClaim(claim);
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000026CC File Offset: 0x000008CC
		public static void ExamineClaim(Claim claim)
		{
			if (claim == null)
			{
				return;
			}
			string issuer = claim.Issuer;
			string originalIssuer = claim.OriginalIssuer;
			foreach (KeyValuePair<string, string> keyValuePair in claim.Properties)
			{
				string key = keyValuePair.Key;
				string value = keyValuePair.Value;
			}
			ClaimsIdentity subject = claim.Subject;
			string type = claim.Type;
			string value2 = claim.Value;
			string valueType = claim.ValueType;
		}
	}
}
