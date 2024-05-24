using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using Microsoft.Runtime.Hosting;

namespace System.Reflection
{
	// Token: 0x0200061F RID: 1567
	[ComVisible(true)]
	[Serializable]
	public class StrongNameKeyPair : IDeserializationCallback, ISerializable
	{
		// Token: 0x060048A4 RID: 18596 RVA: 0x00107584 File Offset: 0x00105784
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public StrongNameKeyPair(FileStream keyPairFile)
		{
			if (keyPairFile == null)
			{
				throw new ArgumentNullException("keyPairFile");
			}
			int num = (int)keyPairFile.Length;
			this._keyPairArray = new byte[num];
			keyPairFile.Read(this._keyPairArray, 0, num);
			this._keyPairExported = true;
		}

		// Token: 0x060048A5 RID: 18597 RVA: 0x001075CF File Offset: 0x001057CF
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public StrongNameKeyPair(byte[] keyPairArray)
		{
			if (keyPairArray == null)
			{
				throw new ArgumentNullException("keyPairArray");
			}
			this._keyPairArray = new byte[keyPairArray.Length];
			Array.Copy(keyPairArray, this._keyPairArray, keyPairArray.Length);
			this._keyPairExported = true;
		}

		// Token: 0x060048A6 RID: 18598 RVA: 0x00107609 File Offset: 0x00105809
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public StrongNameKeyPair(string keyPairContainer)
		{
			if (keyPairContainer == null)
			{
				throw new ArgumentNullException("keyPairContainer");
			}
			this._keyPairContainer = keyPairContainer;
			this._keyPairExported = false;
		}

		// Token: 0x060048A7 RID: 18599 RVA: 0x00107630 File Offset: 0x00105830
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected StrongNameKeyPair(SerializationInfo info, StreamingContext context)
		{
			this._keyPairExported = (bool)info.GetValue("_keyPairExported", typeof(bool));
			this._keyPairArray = (byte[])info.GetValue("_keyPairArray", typeof(byte[]));
			this._keyPairContainer = (string)info.GetValue("_keyPairContainer", typeof(string));
			this._publicKey = (byte[])info.GetValue("_publicKey", typeof(byte[]));
		}

		// Token: 0x17000B55 RID: 2901
		// (get) Token: 0x060048A8 RID: 18600 RVA: 0x001076C4 File Offset: 0x001058C4
		public byte[] PublicKey
		{
			[SecuritySafeCritical]
			get
			{
				if (this._publicKey == null)
				{
					this._publicKey = this.ComputePublicKey();
				}
				byte[] array = new byte[this._publicKey.Length];
				Array.Copy(this._publicKey, array, this._publicKey.Length);
				return array;
			}
		}

		// Token: 0x060048A9 RID: 18601 RVA: 0x00107708 File Offset: 0x00105908
		[SecurityCritical]
		private unsafe byte[] ComputePublicKey()
		{
			byte[] array = null;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
			}
			finally
			{
				IntPtr zero = IntPtr.Zero;
				int num = 0;
				try
				{
					bool flag;
					if (this._keyPairExported)
					{
						flag = StrongNameHelpers.StrongNameGetPublicKey(null, this._keyPairArray, this._keyPairArray.Length, out zero, out num);
					}
					else
					{
						flag = StrongNameHelpers.StrongNameGetPublicKey(this._keyPairContainer, null, 0, out zero, out num);
					}
					if (!flag)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_StrongNameGetPublicKey"));
					}
					array = new byte[num];
					Buffer.Memcpy(array, 0, (byte*)zero.ToPointer(), 0, num);
				}
				finally
				{
					if (zero != IntPtr.Zero)
					{
						StrongNameHelpers.StrongNameFreeBuffer(zero);
					}
				}
			}
			return array;
		}

		// Token: 0x060048AA RID: 18602 RVA: 0x001077BC File Offset: 0x001059BC
		[SecurityCritical]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_keyPairExported", this._keyPairExported);
			info.AddValue("_keyPairArray", this._keyPairArray);
			info.AddValue("_keyPairContainer", this._keyPairContainer);
			info.AddValue("_publicKey", this._publicKey);
		}

		// Token: 0x060048AB RID: 18603 RVA: 0x0010780D File Offset: 0x00105A0D
		void IDeserializationCallback.OnDeserialization(object sender)
		{
		}

		// Token: 0x060048AC RID: 18604 RVA: 0x0010780F File Offset: 0x00105A0F
		private bool GetKeyPair(out object arrayOrContainer)
		{
			arrayOrContainer = (this._keyPairExported ? this._keyPairArray : this._keyPairContainer);
			return this._keyPairExported;
		}

		// Token: 0x04001E15 RID: 7701
		private bool _keyPairExported;

		// Token: 0x04001E16 RID: 7702
		private byte[] _keyPairArray;

		// Token: 0x04001E17 RID: 7703
		private string _keyPairContainer;

		// Token: 0x04001E18 RID: 7704
		private byte[] _publicKey;
	}
}
