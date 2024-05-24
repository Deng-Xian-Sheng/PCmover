using System;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200001A RID: 26
	public abstract class PcmProtocolBase : PcmActivity, ITransferMethodActivity
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000084 RID: 132 RVA: 0x0000424D File Offset: 0x0000244D
		public ServiceTransferMethod ActivityServiceTransferMethod { get; }

		// Token: 0x06000085 RID: 133 RVA: 0x00004258 File Offset: 0x00002458
		protected PcmProtocolBase(ActivityType type, PcmoverManager manager, ServiceTransferMethod stm) : base(type, manager)
		{
			this.ActivityServiceTransferMethod = stm;
			this.m_connectionMethod = this.ActivityServiceTransferMethod.GetConnectionMethod();
			if (this.m_connectionMethod == null)
			{
				throw new Exception("Connection method is required");
			}
			this.m_protocol = this.m_connectionMethod.GetPcmProtocol();
			if (this.m_protocol == null)
			{
				throw new Exception("Unexpected null PcmProtocol in PcmProtocolBase");
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000042BC File Offset: 0x000024BC
		protected override void Dispose(bool disposing)
		{
			if (!this.disposedValue)
			{
				if (disposing)
				{
					this.cleanup();
				}
				this.disposedValue = true;
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000042DD File Offset: 0x000024DD
		protected override void OnCancel()
		{
			if (this.m_protocol != null)
			{
				this.m_protocol.bCancel = true;
			}
			base.OnCancel();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000042F9 File Offset: 0x000024F9
		protected override void OnTaskComplete()
		{
			this.cleanup();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004301 File Offset: 0x00002501
		protected override void OnTaskStopped()
		{
			if (this.m_protocol != null)
			{
				this.m_protocol.bCancel = false;
				this.m_protocol.detach();
				this.m_protocol = null;
			}
			this.cleanup();
			this.m_connectionMethod = null;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00004336 File Offset: 0x00002536
		protected void cleanup()
		{
			if (this.m_connectionMethod != null && !this.m_bKeepAlive && this.m_connectionMethod.IsOpen())
			{
				this.m_connectionMethod.CloseConnection();
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00004364 File Offset: 0x00002564
		protected bool Connect()
		{
			if (this.m_connectionMethod != null && !this.m_bKeepAlive && this.m_connectionMethod.IsOpen())
			{
				this.m_connectionMethod.CloseConnection();
			}
			return !this.m_bCancel && this.m_connectionMethod != null && this.m_connectionMethod.MakeConnection() && !this.m_bCancel;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000043C8 File Offset: 0x000025C8
		protected bool ValidateRemoteVersion()
		{
			ENUM_INFOVALIDATION enum_INFOVALIDATION = this.m_protocol.ExchangeInfoPackets();
			if (enum_INFOVALIDATION != ENUM_INFOVALIDATION.INFO_OK)
			{
				this.SetConnectingFailure((enum_INFOVALIDATION == ENUM_INFOVALIDATION.INFO_COMMUNICATION_ERROR) ? ConnectingActivityFailureReason.CommunicationError : ConnectingActivityFailureReason.VersionVerificationFailed);
				return false;
			}
			if (this.m_bCancel)
			{
				return false;
			}
			if (this.m_connectionMethod.PasswordRequired && !this.m_protocol.SendPassword(this.ActivityServiceTransferMethod.GetPassword()))
			{
				this.SetConnectingFailure(ConnectingActivityFailureReason.BadPassword);
				return false;
			}
			return true;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000031A4 File Offset: 0x000013A4
		protected virtual void SetConnectingFailure(ConnectingActivityFailureReason reason)
		{
			this.Info.FailureReason = (int)reason;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00004430 File Offset: 0x00002630
		public TransferSpeeds GetNetSpeeds()
		{
			ulong remoteSpeed = 0UL;
			ulong localSpeed = 0UL;
			PcmProtocol protocol = this.m_protocol;
			if (protocol != null)
			{
				protocol.GetNetSpeeds(out remoteSpeed, out localSpeed);
			}
			return new TransferSpeeds
			{
				RemoteSpeed = remoteSpeed,
				LocalSpeed = localSpeed
			};
		}

		// Token: 0x04000038 RID: 56
		protected ConnectionMethod m_connectionMethod;

		// Token: 0x04000039 RID: 57
		protected PcmProtocol m_protocol;

		// Token: 0x0400003A RID: 58
		protected bool m_bKeepAlive;

		// Token: 0x0400003C RID: 60
		private bool disposedValue;
	}
}
