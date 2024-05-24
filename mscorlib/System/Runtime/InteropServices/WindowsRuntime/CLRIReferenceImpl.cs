using System;
using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A00 RID: 2560
	internal sealed class CLRIReferenceImpl<T> : CLRIPropertyValueImpl, IReference<T>, IPropertyValue, ICustomPropertyProvider
	{
		// Token: 0x0600652A RID: 25898 RVA: 0x00158B40 File Offset: 0x00156D40
		public CLRIReferenceImpl(PropertyType type, T obj) : base(type, obj)
		{
			this._value = obj;
		}

		// Token: 0x17001161 RID: 4449
		// (get) Token: 0x0600652B RID: 25899 RVA: 0x00158B56 File Offset: 0x00156D56
		public T Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x0600652C RID: 25900 RVA: 0x00158B5E File Offset: 0x00156D5E
		public override string ToString()
		{
			if (this._value != null)
			{
				return this._value.ToString();
			}
			return base.ToString();
		}

		// Token: 0x0600652D RID: 25901 RVA: 0x00158B85 File Offset: 0x00156D85
		ICustomProperty ICustomPropertyProvider.GetCustomProperty(string name)
		{
			return ICustomPropertyProviderImpl.CreateProperty(this._value, name);
		}

		// Token: 0x0600652E RID: 25902 RVA: 0x00158B98 File Offset: 0x00156D98
		ICustomProperty ICustomPropertyProvider.GetIndexedProperty(string name, Type indexParameterType)
		{
			return ICustomPropertyProviderImpl.CreateIndexedProperty(this._value, name, indexParameterType);
		}

		// Token: 0x0600652F RID: 25903 RVA: 0x00158BAC File Offset: 0x00156DAC
		string ICustomPropertyProvider.GetStringRepresentation()
		{
			return this._value.ToString();
		}

		// Token: 0x17001162 RID: 4450
		// (get) Token: 0x06006530 RID: 25904 RVA: 0x00158BBE File Offset: 0x00156DBE
		Type ICustomPropertyProvider.Type
		{
			get
			{
				return this._value.GetType();
			}
		}

		// Token: 0x06006531 RID: 25905 RVA: 0x00158BD0 File Offset: 0x00156DD0
		[FriendAccessAllowed]
		internal static object UnboxHelper(object wrapper)
		{
			IReference<T> reference = (IReference<T>)wrapper;
			return reference.Value;
		}

		// Token: 0x04002D2D RID: 11565
		private T _value;
	}
}
