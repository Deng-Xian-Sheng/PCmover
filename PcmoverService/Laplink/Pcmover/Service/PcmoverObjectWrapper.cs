using System;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000018 RID: 24
	public class PcmoverObjectWrapper<T> : IDisposable where T : IPCmoverObject
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00004146 File Offset: 0x00002346
		public T Value
		{
			get
			{
				return this._wrappedObject;
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000414E File Offset: 0x0000234E
		public PcmoverObjectWrapper(T obj)
		{
			this._wrappedObject = obj;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00004160 File Offset: 0x00002360
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposedValue)
			{
				ref T ptr = ref this._wrappedObject;
				T t = default(T);
				if (t == null)
				{
					t = this._wrappedObject;
					ptr = ref t;
					if (t == null)
					{
						goto IL_3E;
					}
				}
				ptr.dispose();
				IL_3E:
				this.disposedValue = true;
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000041B4 File Offset: 0x000023B4
		~PcmoverObjectWrapper()
		{
			this.Dispose(false);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000041E4 File Offset: 0x000023E4
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x04000036 RID: 54
		private T _wrappedObject;

		// Token: 0x04000037 RID: 55
		private bool disposedValue;
	}
}
