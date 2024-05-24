using System;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000003 RID: 3
	public class AuthorizeTaskHelper
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002276 File Offset: 0x00000476
		private PcmoverManager Manager
		{
			get
			{
				return this._activity.Manager;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002283 File Offset: 0x00000483
		private LlTraceSource Ts
		{
			get
			{
				return this.Manager.Ts;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002290 File Offset: 0x00000490
		private AuthorizationRequestData AuthRequest
		{
			get
			{
				ServiceTask serviceTask = this._serviceTask;
				return ((serviceTask != null) ? serviceTask.AuthRequest : null) ?? this.Manager.AuthRequest;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000022B4 File Offset: 0x000004B4
		private bool CanBeValidated
		{
			get
			{
				return this.AuthRequest != null && (!string.IsNullOrWhiteSpace(this.AuthRequest.ValidationCode) || !string.IsNullOrWhiteSpace(this.AuthRequest.SerialNumber) || this.Manager.EnginePolicy.bGetSerialNumberFromServer);
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002308 File Offset: 0x00000508
		public AuthorizeTaskHelper(PcmActivity activity, ServiceTask serviceTask, PcmProtocol protocol = null)
		{
			this._activity = activity;
			this._serviceTask = serviceTask;
			this._protocol = protocol;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002328 File Offset: 0x00000528
		public bool IsAuthorized()
		{
			ServiceTask serviceTask = this._serviceTask;
			IPcmTask pcmTask = (serviceTask != null) ? serviceTask.Task : null;
			if (pcmTask == null)
			{
				this.Ts.TraceCaller("Task is null", "IsAuthorized");
				return false;
			}
			if (pcmTask.IsAuthorized)
			{
				this.Ts.TraceCaller("Already authorized", "IsAuthorized");
				return true;
			}
			bool flag = true;
			while (flag)
			{
				ValidationResult result = new ValidationResult();
				if (this.CanBeValidated)
				{
					AuthorizationRequestData authRequest = this.AuthRequest;
					string text = authRequest.ValidationCode;
					bool flag2 = false;
					if (string.IsNullOrWhiteSpace(text))
					{
						text = authRequest.SerialNumber;
					}
					else
					{
						flag2 = this.Manager.IsTransferValidationCode(text);
					}
					object registrationLock = this.Manager._registrationLock;
					string text2;
					uint num2;
					lock (registrationLock)
					{
						uint num = pcmTask.AuthorizeTransfer(text, authRequest.User, authRequest.Email, out text2, out num2);
						if (num == 0U && flag2 && authRequest.SerialNumber != text)
						{
							this.Ts.TraceCaller("Invalid validation code, trying the serial number", "IsAuthorized");
							text = authRequest.SerialNumber;
							flag2 = false;
							num = pcmTask.AuthorizeTransfer(text, authRequest.User, authRequest.Email, out text2, out num2);
						}
						if (num != 0U)
						{
							this.Ts.TraceCaller("Authorization approved by reg server", "IsAuthorized");
							return true;
						}
					}
					this.Ts.TraceCaller(string.Format("Authorization not approved by reg server, errorCode {0}: {1}", num2, text2), "IsAuthorized");
					if (num2 == 0U && this._protocol != null && !flag2)
					{
						this.Ts.TraceCaller("Requesting the other computer to authorize the transfer", "IsAuthorized");
						string text3;
						uint num3;
						uint num = this._protocol.SendAuthorizeTransferCommand((PcmTask)pcmTask, text, authRequest.User, authRequest.Email, out text3, out num3);
						if (num != 0U)
						{
							this.Ts.TraceCaller("Authorized by the other computer", "IsAuthorized");
							return true;
						}
						this.Ts.TraceCaller("Not authorized by the other computer", "IsAuthorized");
						if (num3 != 0U)
						{
							text2 = text3;
							num2 = num3;
						}
					}
					result = new ValidationResult
					{
						Message = text2
					};
					result.SetErrorCode(num2);
					ValidationErrorCode errorCode = result.ErrorCode;
					if ((errorCode == ValidationErrorCode.SerialNum || errorCode - ValidationErrorCode.WrongVersion <= 1) && this.Manager._app.RegistrationServer.SerialNumber == text)
					{
						this.Manager._app.RegistrationServer.SerialNumber = string.Empty;
					}
				}
				else if (this._serviceTask.Task.IsPreValidated)
				{
					object registrationLock = this.Manager._registrationLock;
					lock (registrationLock)
					{
						AuthorizationRequestData authRequest2 = this.AuthRequest;
						string text4;
						uint num4;
						if (pcmTask.AuthorizePreValidation((authRequest2 != null) ? authRequest2.User : null, (authRequest2 != null) ? authRequest2.Email : null, out text4, out num4) != 0U)
						{
							this.Ts.TraceCaller("Pre-Validation Authorization approved by reg server", "IsAuthorized");
							return true;
						}
						this.Ts.TraceCaller(string.Format("Pre-Validation Authorization not approved by reg server, errorCode {0}: {1}", num4, text4), "IsAuthorized");
						result = new ValidationResult
						{
							Message = text4
						};
						result.SetErrorCode(num4);
					}
				}
				flag = (this.Manager.CallUiControlCallback(delegate(int replyHandle)
				{
					this.Manager.PcmoverCcm.State.ControlCallback.UiAuthorizationError(replyHandle, this._activity.Info, this._serviceTask.Handle, result);
				}, 0, "DisplayAuthorizationError") != 0);
			}
			this.Ts.TraceCaller("Not authorized. Do not allow transfer.", "IsAuthorized");
			return false;
		}

		// Token: 0x04000002 RID: 2
		private readonly PcmActivity _activity;

		// Token: 0x04000003 RID: 3
		private readonly ServiceTask _serviceTask;

		// Token: 0x04000004 RID: 4
		private readonly PcmProtocol _protocol;
	}
}
