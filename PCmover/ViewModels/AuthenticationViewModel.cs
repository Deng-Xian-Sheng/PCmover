using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Management;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Laplink.Tools.Helpers;
using Laplink.Tools.Popups;
using PcmBrandUI.Properties;
using Prism.Commands;

namespace PCmover.ViewModels
{
	// Token: 0x0200000B RID: 11
	public class AuthenticationViewModel : PopupViewModelBase
	{
		// Token: 0x0600006C RID: 108 RVA: 0x00002ED0 File Offset: 0x000010D0
		public AuthenticationViewModel(AuthenticationData data)
		{
			this._data = data;
			this.LogonFailure = false;
			base.PopupData.Animation = PopupAnimation.Scroll;
			base.PopupData.IsBlackout = true;
			base.PopupData.UseOverlay = false;
			base.PopupData.IsOpen = true;
			this.OnLoginOK = new DelegateCommand<PasswordBox>(new Action<PasswordBox>(this.OnLoginOKCommand), new Func<PasswordBox, bool>(this.CanOnLoginOKCommand));
			this.OnLoginCancel = new DelegateCommand(new Action(this.OnLoginCancelCommand));
			this.LogonFailure = false;
			this.BorderBrush = Brushes.Silver;
			this.Domain = Environment.UserDomainName;
			this.Username = Environment.UserName;
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00002F83 File Offset: 0x00001183
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00002F8B File Offset: 0x0000118B
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				this.SetProperty<string>(ref this._Username, value, "Username");
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002FA0 File Offset: 0x000011A0
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00002FA8 File Offset: 0x000011A8
		public string Password
		{
			get
			{
				return this._Password;
			}
			private set
			{
				this.SetProperty<string>(ref this._Password, value, "Password");
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00002FBD File Offset: 0x000011BD
		// (set) Token: 0x06000072 RID: 114 RVA: 0x00002FC5 File Offset: 0x000011C5
		public string Domain
		{
			get
			{
				return this._Domain;
			}
			set
			{
				this.SetProperty<string>(ref this._Domain, value, "Domain");
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00002FDA File Offset: 0x000011DA
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00002FE2 File Offset: 0x000011E2
		public bool LogonFailure
		{
			get
			{
				return this._LogonFailure;
			}
			private set
			{
				this.SetProperty<bool>(ref this._LogonFailure, value, "LogonFailure");
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00002FF7 File Offset: 0x000011F7
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00002FFF File Offset: 0x000011FF
		public Brush BorderBrush
		{
			get
			{
				return this._BorderBrush;
			}
			private set
			{
				this.SetProperty<Brush>(ref this._BorderBrush, value, "BorderBrush");
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00003014 File Offset: 0x00001214
		// (set) Token: 0x06000078 RID: 120 RVA: 0x0000301C File Offset: 0x0000121C
		public DelegateCommand<PasswordBox> OnLoginOK { get; private set; }

		// Token: 0x06000079 RID: 121 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnLoginOKCommand(PasswordBox passwordBox)
		{
			return true;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003028 File Offset: 0x00001228
		private void OnLoginOKCommand(PasswordBox passwordBox)
		{
			if (AuthenticationViewModel.DomainAuthentication(this.Username, passwordBox.Password, this.Domain))
			{
				base.PopupData.IsOpen = false;
				this._data.IsAuthenticated = true;
				this._data.ResetEvent.Set();
				return;
			}
			this._data.IsAuthenticated = false;
			this.LogonFailure = true;
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600007B RID: 123 RVA: 0x0000308B File Offset: 0x0000128B
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00003093 File Offset: 0x00001293
		public DelegateCommand OnLoginCancel { get; private set; }

		// Token: 0x0600007D RID: 125 RVA: 0x0000309C File Offset: 0x0000129C
		private void OnLoginCancelCommand()
		{
			base.PopupData.IsOpen = false;
			this._data.IsAuthenticated = false;
			this._data.ResetEvent.Set();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000030C8 File Offset: 0x000012C8
		internal static bool DomainAuthentication(string username, string password, string domainName)
		{
			bool result;
			try
			{
				using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domainName, username, password))
				{
					GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(principalContext, IdentityType.Name, AuthenticationViewModel._usersGroup);
					if (groupPrincipal != null)
					{
						using (IEnumerator<Principal> enumerator = groupPrincipal.GetMembers(true).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								if (string.Equals(enumerator.Current.SamAccountName, username, StringComparison.CurrentCultureIgnoreCase))
								{
									return principalContext.ValidateCredentials(username, password);
								}
							}
						}
						groupPrincipal.Dispose();
					}
					result = false;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003174 File Offset: 0x00001374
		internal static bool ShouldAuthenticate(LlTraceSource ts)
		{
			bool flag = Convert.ToBoolean(Resources.Feature_EnforceStandardDomainAuthentication);
			bool flag2 = Convert.ToBoolean(Resources.Feature_EnforceLightDomainAuthentication);
			if (!flag && !flag2)
			{
				ts.TraceCaller("Standard and Light authentication are both disabled, so returning false", "ShouldAuthenticate");
				return false;
			}
			if (AuthenticationViewModel.IsDomainMember())
			{
				try
				{
					PrincipalContext context = new PrincipalContext(ContextType.Domain);
					GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(context, AuthenticationViewModel._usersGroup);
					if (GroupPrincipal.FindByIdentity(context, AuthenticationViewModel._adminGroup) == null && groupPrincipal == null)
					{
						ts.TraceCaller(string.Format("Users and Admin groups do not exist, so returning {0}", flag), "ShouldAuthenticate");
						return flag;
					}
					using (DirectoryEntry directoryEntry = (DirectoryEntry)UserPrincipal.Current.GetUnderlyingObject())
					{
						object[] adPropertyValueObjectArray = AuthenticationViewModel.GetAdPropertyValueObjectArray(directoryEntry, "memberOf");
						if (adPropertyValueObjectArray != null)
						{
							ts.TraceCaller(string.Format("{0} groups found for this user", adPropertyValueObjectArray.Length), "ShouldAuthenticate");
							foreach (string text in adPropertyValueObjectArray)
							{
								if (text.StartsWith("CN=", StringComparison.OrdinalIgnoreCase))
								{
									int num = text.IndexOf(",", 3);
									string text2;
									if (num >= 0)
									{
										text2 = text.Substring(3, num - 3);
									}
									else
									{
										text2 = text.Substring(3);
									}
									if (text2 == AuthenticationViewModel._usersGroup || text2 == AuthenticationViewModel._adminGroup)
									{
										ts.TraceCaller("User is in " + text2 + ", so returning false", "ShouldAuthenticate");
										return false;
									}
								}
							}
						}
						else
						{
							ts.TraceCaller("No groups found for this user, so returning true", "ShouldAuthenticate");
						}
					}
					return true;
				}
				catch (Exception ex)
				{
					ts.TraceException(ex, LlTraceSource.ExceptionDetails.All, "ShouldAuthenticate");
					ts.TraceCaller("Unexpected exception, so returning true", "ShouldAuthenticate");
					return true;
				}
			}
			ts.TraceCaller(string.Format("User not on a domain, so returning {0}", flag), "ShouldAuthenticate");
			return flag;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003380 File Offset: 0x00001580
		private static bool IsDomainMember()
		{
			bool result;
			try
			{
				ManagementObject managementObject2;
				ManagementObject managementObject = managementObject2 = new ManagementObject(string.Format("Win32_ComputerSystem.Name='{0}'", Environment.MachineName));
				try
				{
					managementObject.Get();
					object obj = managementObject["PartOfDomain"];
					result = (obj != null && (bool)obj);
				}
				finally
				{
					if (managementObject2 != null)
					{
						((IDisposable)managementObject2).Dispose();
					}
				}
			}
			catch
			{
				string userDomainName = Environment.UserDomainName;
				string a = (userDomainName != null) ? userDomainName.ToLower() : null;
				string machineName = Environment.MachineName;
				result = (a != ((machineName != null) ? machineName.ToLower() : null));
			}
			return result;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003418 File Offset: 0x00001618
		private static object[] GetAdPropertyValueObjectArray(DirectoryEntry userAccount, string adPropertyKey)
		{
			object[] result = null;
			PropertyValueCollection propertyValueCollection = userAccount.Properties[adPropertyKey];
			if (propertyValueCollection != null)
			{
				object value = propertyValueCollection.Value;
				if (value != null)
				{
					if (value is string)
					{
						result = new object[]
						{
							value
						};
					}
					else
					{
						result = (object[])value;
					}
				}
			}
			return result;
		}

		// Token: 0x04000015 RID: 21
		private static string _usersGroup = "PCmover Users";

		// Token: 0x04000016 RID: 22
		private static string _adminGroup = "PCmover Admins";

		// Token: 0x04000017 RID: 23
		private readonly AuthenticationData _data;

		// Token: 0x04000018 RID: 24
		private string _Username;

		// Token: 0x04000019 RID: 25
		private string _Password;

		// Token: 0x0400001A RID: 26
		private string _Domain;

		// Token: 0x0400001B RID: 27
		private bool _LogonFailure;

		// Token: 0x0400001C RID: 28
		private Brush _BorderBrush;
	}
}
