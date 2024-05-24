using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Reflection
{
	// Token: 0x0200061D RID: 1565
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class ReflectionTypeLoadException : SystemException, ISerializable
	{
		// Token: 0x0600489C RID: 18588 RVA: 0x0010744B File Offset: 0x0010564B
		private ReflectionTypeLoadException() : base(Environment.GetResourceString("ReflectionTypeLoad_LoadFailed"))
		{
			base.SetErrorCode(-2146232830);
		}

		// Token: 0x0600489D RID: 18589 RVA: 0x00107468 File Offset: 0x00105668
		private ReflectionTypeLoadException(string message) : base(message)
		{
			base.SetErrorCode(-2146232830);
		}

		// Token: 0x0600489E RID: 18590 RVA: 0x0010747C File Offset: 0x0010567C
		[__DynamicallyInvokable]
		public ReflectionTypeLoadException(Type[] classes, Exception[] exceptions) : base(null)
		{
			this._classes = classes;
			this._exceptions = exceptions;
			base.SetErrorCode(-2146232830);
		}

		// Token: 0x0600489F RID: 18591 RVA: 0x0010749E File Offset: 0x0010569E
		[__DynamicallyInvokable]
		public ReflectionTypeLoadException(Type[] classes, Exception[] exceptions, string message) : base(message)
		{
			this._classes = classes;
			this._exceptions = exceptions;
			base.SetErrorCode(-2146232830);
		}

		// Token: 0x060048A0 RID: 18592 RVA: 0x001074C0 File Offset: 0x001056C0
		internal ReflectionTypeLoadException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this._classes = (Type[])info.GetValue("Types", typeof(Type[]));
			this._exceptions = (Exception[])info.GetValue("Exceptions", typeof(Exception[]));
		}

		// Token: 0x17000B53 RID: 2899
		// (get) Token: 0x060048A1 RID: 18593 RVA: 0x00107515 File Offset: 0x00105715
		[__DynamicallyInvokable]
		public Type[] Types
		{
			[__DynamicallyInvokable]
			get
			{
				return this._classes;
			}
		}

		// Token: 0x17000B54 RID: 2900
		// (get) Token: 0x060048A2 RID: 18594 RVA: 0x0010751D File Offset: 0x0010571D
		[__DynamicallyInvokable]
		public Exception[] LoaderExceptions
		{
			[__DynamicallyInvokable]
			get
			{
				return this._exceptions;
			}
		}

		// Token: 0x060048A3 RID: 18595 RVA: 0x00107528 File Offset: 0x00105728
		[SecurityCritical]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("Types", this._classes, typeof(Type[]));
			info.AddValue("Exceptions", this._exceptions, typeof(Exception[]));
		}

		// Token: 0x04001E10 RID: 7696
		private Type[] _classes;

		// Token: 0x04001E11 RID: 7697
		private Exception[] _exceptions;
	}
}
