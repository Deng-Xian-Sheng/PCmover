using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Lifetime;
using System.Security;

namespace System.Runtime.Remoting
{
	// Token: 0x020007CE RID: 1998
	[ClassInterface(ClassInterfaceType.AutoDual)]
	[ComVisible(true)]
	public class ObjectHandle : MarshalByRefObject, IObjectHandle
	{
		// Token: 0x060056C0 RID: 22208 RVA: 0x00134257 File Offset: 0x00132457
		private ObjectHandle()
		{
		}

		// Token: 0x060056C1 RID: 22209 RVA: 0x0013425F File Offset: 0x0013245F
		public ObjectHandle(object o)
		{
			this.WrappedObject = o;
		}

		// Token: 0x060056C2 RID: 22210 RVA: 0x0013426E File Offset: 0x0013246E
		public object Unwrap()
		{
			return this.WrappedObject;
		}

		// Token: 0x060056C3 RID: 22211 RVA: 0x00134278 File Offset: 0x00132478
		[SecurityCritical]
		public override object InitializeLifetimeService()
		{
			MarshalByRefObject marshalByRefObject = this.WrappedObject as MarshalByRefObject;
			if (marshalByRefObject != null && marshalByRefObject.InitializeLifetimeService() == null)
			{
				return null;
			}
			return (ILease)base.InitializeLifetimeService();
		}

		// Token: 0x040027AD RID: 10157
		private object WrappedObject;
	}
}
