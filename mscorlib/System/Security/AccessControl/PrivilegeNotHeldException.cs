using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace System.Security.AccessControl
{
	// Token: 0x0200022B RID: 555
	[Serializable]
	public sealed class PrivilegeNotHeldException : UnauthorizedAccessException, ISerializable
	{
		// Token: 0x06002011 RID: 8209 RVA: 0x00070EDE File Offset: 0x0006F0DE
		public PrivilegeNotHeldException() : base(Environment.GetResourceString("PrivilegeNotHeld_Default"))
		{
		}

		// Token: 0x06002012 RID: 8210 RVA: 0x00070EF0 File Offset: 0x0006F0F0
		public PrivilegeNotHeldException(string privilege) : base(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("PrivilegeNotHeld_Named"), privilege))
		{
			this._privilegeName = privilege;
		}

		// Token: 0x06002013 RID: 8211 RVA: 0x00070F14 File Offset: 0x0006F114
		public PrivilegeNotHeldException(string privilege, Exception inner) : base(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("PrivilegeNotHeld_Named"), privilege), inner)
		{
			this._privilegeName = privilege;
		}

		// Token: 0x06002014 RID: 8212 RVA: 0x00070F39 File Offset: 0x0006F139
		internal PrivilegeNotHeldException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this._privilegeName = info.GetString("PrivilegeName");
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x06002015 RID: 8213 RVA: 0x00070F54 File Offset: 0x0006F154
		public string PrivilegeName
		{
			get
			{
				return this._privilegeName;
			}
		}

		// Token: 0x06002016 RID: 8214 RVA: 0x00070F5C File Offset: 0x0006F15C
		[SecurityCritical]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("PrivilegeName", this._privilegeName, typeof(string));
		}

		// Token: 0x04000B8F RID: 2959
		private readonly string _privilegeName;
	}
}
