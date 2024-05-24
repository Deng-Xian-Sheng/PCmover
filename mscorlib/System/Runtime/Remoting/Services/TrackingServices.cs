using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Services
{
	// Token: 0x02000806 RID: 2054
	[SecurityCritical]
	[ComVisible(true)]
	public class TrackingServices
	{
		// Token: 0x17000EA7 RID: 3751
		// (get) Token: 0x06005870 RID: 22640 RVA: 0x00137E3C File Offset: 0x0013603C
		private static object TrackingServicesSyncObject
		{
			get
			{
				if (TrackingServices.s_TrackingServicesSyncObject == null)
				{
					object value = new object();
					Interlocked.CompareExchange(ref TrackingServices.s_TrackingServicesSyncObject, value, null);
				}
				return TrackingServices.s_TrackingServicesSyncObject;
			}
		}

		// Token: 0x06005871 RID: 22641 RVA: 0x00137E68 File Offset: 0x00136068
		[SecurityCritical]
		public static void RegisterTrackingHandler(ITrackingHandler handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			object trackingServicesSyncObject = TrackingServices.TrackingServicesSyncObject;
			lock (trackingServicesSyncObject)
			{
				if (-1 != TrackingServices.Match(handler))
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_TrackingHandlerAlreadyRegistered", new object[]
					{
						"handler"
					}));
				}
				if (TrackingServices._Handlers == null || TrackingServices._Size == TrackingServices._Handlers.Length)
				{
					ITrackingHandler[] array = new ITrackingHandler[TrackingServices._Size * 2 + 4];
					if (TrackingServices._Handlers != null)
					{
						Array.Copy(TrackingServices._Handlers, array, TrackingServices._Size);
					}
					TrackingServices._Handlers = array;
				}
				Volatile.Write<ITrackingHandler>(ref TrackingServices._Handlers[TrackingServices._Size++], handler);
			}
		}

		// Token: 0x06005872 RID: 22642 RVA: 0x00137F4C File Offset: 0x0013614C
		[SecurityCritical]
		public static void UnregisterTrackingHandler(ITrackingHandler handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			object trackingServicesSyncObject = TrackingServices.TrackingServicesSyncObject;
			lock (trackingServicesSyncObject)
			{
				int num = TrackingServices.Match(handler);
				if (-1 == num)
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_HandlerNotRegistered", new object[]
					{
						handler
					}));
				}
				Array.Copy(TrackingServices._Handlers, num + 1, TrackingServices._Handlers, num, TrackingServices._Size - num - 1);
				TrackingServices._Size--;
			}
		}

		// Token: 0x17000EA8 RID: 3752
		// (get) Token: 0x06005873 RID: 22643 RVA: 0x00137FEC File Offset: 0x001361EC
		public static ITrackingHandler[] RegisteredHandlers
		{
			[SecurityCritical]
			get
			{
				object trackingServicesSyncObject = TrackingServices.TrackingServicesSyncObject;
				ITrackingHandler[] result;
				lock (trackingServicesSyncObject)
				{
					if (TrackingServices._Size == 0)
					{
						result = new ITrackingHandler[0];
					}
					else
					{
						ITrackingHandler[] array = new ITrackingHandler[TrackingServices._Size];
						for (int i = 0; i < TrackingServices._Size; i++)
						{
							array[i] = TrackingServices._Handlers[i];
						}
						result = array;
					}
				}
				return result;
			}
		}

		// Token: 0x06005874 RID: 22644 RVA: 0x0013806C File Offset: 0x0013626C
		[SecurityCritical]
		internal static void MarshaledObject(object obj, ObjRef or)
		{
			try
			{
				ITrackingHandler[] handlers = TrackingServices._Handlers;
				for (int i = 0; i < TrackingServices._Size; i++)
				{
					Volatile.Read<ITrackingHandler>(ref handlers[i]).MarshaledObject(obj, or);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06005875 RID: 22645 RVA: 0x001380BC File Offset: 0x001362BC
		[SecurityCritical]
		internal static void UnmarshaledObject(object obj, ObjRef or)
		{
			try
			{
				ITrackingHandler[] handlers = TrackingServices._Handlers;
				for (int i = 0; i < TrackingServices._Size; i++)
				{
					Volatile.Read<ITrackingHandler>(ref handlers[i]).UnmarshaledObject(obj, or);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06005876 RID: 22646 RVA: 0x0013810C File Offset: 0x0013630C
		[SecurityCritical]
		internal static void DisconnectedObject(object obj)
		{
			try
			{
				ITrackingHandler[] handlers = TrackingServices._Handlers;
				for (int i = 0; i < TrackingServices._Size; i++)
				{
					Volatile.Read<ITrackingHandler>(ref handlers[i]).DisconnectedObject(obj);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06005877 RID: 22647 RVA: 0x0013815C File Offset: 0x0013635C
		private static int Match(ITrackingHandler handler)
		{
			int result = -1;
			for (int i = 0; i < TrackingServices._Size; i++)
			{
				if (TrackingServices._Handlers[i] == handler)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x0400284F RID: 10319
		private static volatile ITrackingHandler[] _Handlers = new ITrackingHandler[0];

		// Token: 0x04002850 RID: 10320
		private static volatile int _Size = 0;

		// Token: 0x04002851 RID: 10321
		private static object s_TrackingServicesSyncObject = null;
	}
}
