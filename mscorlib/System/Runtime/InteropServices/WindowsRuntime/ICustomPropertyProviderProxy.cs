using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A0E RID: 2574
	internal class ICustomPropertyProviderProxy<T1, T2> : IGetProxyTarget, ICustomPropertyProvider, ICustomQueryInterface, IEnumerable, IBindableVector, IBindableIterable, IBindableVectorView
	{
		// Token: 0x06006583 RID: 25987 RVA: 0x00159488 File Offset: 0x00157688
		internal ICustomPropertyProviderProxy(object target, InterfaceForwardingSupport flags)
		{
			this._target = target;
			this._flags = flags;
		}

		// Token: 0x06006584 RID: 25988 RVA: 0x001594A0 File Offset: 0x001576A0
		internal static object CreateInstance(object target)
		{
			InterfaceForwardingSupport interfaceForwardingSupport = InterfaceForwardingSupport.None;
			if (target is IList)
			{
				interfaceForwardingSupport |= InterfaceForwardingSupport.IBindableVector;
			}
			if (target is IList<!0>)
			{
				interfaceForwardingSupport |= InterfaceForwardingSupport.IVector;
			}
			if (target is IBindableVectorView)
			{
				interfaceForwardingSupport |= InterfaceForwardingSupport.IBindableVectorView;
			}
			if (target is IReadOnlyList<T2>)
			{
				interfaceForwardingSupport |= InterfaceForwardingSupport.IVectorView;
			}
			if (target is IEnumerable)
			{
				interfaceForwardingSupport |= InterfaceForwardingSupport.IBindableIterableOrIIterable;
			}
			return new ICustomPropertyProviderProxy<T1, T2>(target, interfaceForwardingSupport);
		}

		// Token: 0x06006585 RID: 25989 RVA: 0x001594F3 File Offset: 0x001576F3
		ICustomProperty ICustomPropertyProvider.GetCustomProperty(string name)
		{
			return ICustomPropertyProviderImpl.CreateProperty(this._target, name);
		}

		// Token: 0x06006586 RID: 25990 RVA: 0x00159501 File Offset: 0x00157701
		ICustomProperty ICustomPropertyProvider.GetIndexedProperty(string name, Type indexParameterType)
		{
			return ICustomPropertyProviderImpl.CreateIndexedProperty(this._target, name, indexParameterType);
		}

		// Token: 0x06006587 RID: 25991 RVA: 0x00159510 File Offset: 0x00157710
		string ICustomPropertyProvider.GetStringRepresentation()
		{
			return IStringableHelper.ToString(this._target);
		}

		// Token: 0x17001170 RID: 4464
		// (get) Token: 0x06006588 RID: 25992 RVA: 0x0015951D File Offset: 0x0015771D
		Type ICustomPropertyProvider.Type
		{
			get
			{
				return this._target.GetType();
			}
		}

		// Token: 0x06006589 RID: 25993 RVA: 0x0015952A File Offset: 0x0015772A
		public override string ToString()
		{
			return IStringableHelper.ToString(this._target);
		}

		// Token: 0x0600658A RID: 25994 RVA: 0x00159537 File Offset: 0x00157737
		object IGetProxyTarget.GetTarget()
		{
			return this._target;
		}

		// Token: 0x0600658B RID: 25995 RVA: 0x00159540 File Offset: 0x00157740
		[SecurityCritical]
		public CustomQueryInterfaceResult GetInterface([In] ref Guid iid, out IntPtr ppv)
		{
			ppv = IntPtr.Zero;
			if (iid == typeof(IBindableIterable).GUID && (this._flags & InterfaceForwardingSupport.IBindableIterableOrIIterable) == InterfaceForwardingSupport.None)
			{
				return CustomQueryInterfaceResult.Failed;
			}
			if (iid == typeof(IBindableVector).GUID && (this._flags & (InterfaceForwardingSupport.IBindableVector | InterfaceForwardingSupport.IVector)) == InterfaceForwardingSupport.None)
			{
				return CustomQueryInterfaceResult.Failed;
			}
			if (iid == typeof(IBindableVectorView).GUID && (this._flags & (InterfaceForwardingSupport.IBindableVectorView | InterfaceForwardingSupport.IVectorView)) == InterfaceForwardingSupport.None)
			{
				return CustomQueryInterfaceResult.Failed;
			}
			return CustomQueryInterfaceResult.NotHandled;
		}

		// Token: 0x0600658C RID: 25996 RVA: 0x001595CF File Offset: 0x001577CF
		public IEnumerator GetEnumerator()
		{
			return ((IEnumerable)this._target).GetEnumerator();
		}

		// Token: 0x0600658D RID: 25997 RVA: 0x001595E4 File Offset: 0x001577E4
		object IBindableVector.GetAt(uint index)
		{
			IBindableVector ibindableVectorNoThrow = this.GetIBindableVectorNoThrow();
			if (ibindableVectorNoThrow != null)
			{
				return ibindableVectorNoThrow.GetAt(index);
			}
			return this.GetVectorOfT().GetAt(index);
		}

		// Token: 0x17001171 RID: 4465
		// (get) Token: 0x0600658E RID: 25998 RVA: 0x00159614 File Offset: 0x00157814
		uint IBindableVector.Size
		{
			get
			{
				IBindableVector ibindableVectorNoThrow = this.GetIBindableVectorNoThrow();
				if (ibindableVectorNoThrow != null)
				{
					return ibindableVectorNoThrow.Size;
				}
				return this.GetVectorOfT().Size;
			}
		}

		// Token: 0x0600658F RID: 25999 RVA: 0x00159640 File Offset: 0x00157840
		IBindableVectorView IBindableVector.GetView()
		{
			IBindableVector ibindableVectorNoThrow = this.GetIBindableVectorNoThrow();
			if (ibindableVectorNoThrow != null)
			{
				return ibindableVectorNoThrow.GetView();
			}
			return new ICustomPropertyProviderProxy<T1, T2>.IVectorViewToIBindableVectorViewAdapter<T1>(this.GetVectorOfT().GetView());
		}

		// Token: 0x06006590 RID: 26000 RVA: 0x00159670 File Offset: 0x00157870
		bool IBindableVector.IndexOf(object value, out uint index)
		{
			IBindableVector ibindableVectorNoThrow = this.GetIBindableVectorNoThrow();
			if (ibindableVectorNoThrow != null)
			{
				return ibindableVectorNoThrow.IndexOf(value, out index);
			}
			return this.GetVectorOfT().IndexOf(ICustomPropertyProviderProxy<T1, T2>.ConvertTo<T1>(value), out index);
		}

		// Token: 0x06006591 RID: 26001 RVA: 0x001596A4 File Offset: 0x001578A4
		void IBindableVector.SetAt(uint index, object value)
		{
			IBindableVector ibindableVectorNoThrow = this.GetIBindableVectorNoThrow();
			if (ibindableVectorNoThrow != null)
			{
				ibindableVectorNoThrow.SetAt(index, value);
				return;
			}
			this.GetVectorOfT().SetAt(index, ICustomPropertyProviderProxy<T1, T2>.ConvertTo<T1>(value));
		}

		// Token: 0x06006592 RID: 26002 RVA: 0x001596D8 File Offset: 0x001578D8
		void IBindableVector.InsertAt(uint index, object value)
		{
			IBindableVector ibindableVectorNoThrow = this.GetIBindableVectorNoThrow();
			if (ibindableVectorNoThrow != null)
			{
				ibindableVectorNoThrow.InsertAt(index, value);
				return;
			}
			this.GetVectorOfT().InsertAt(index, ICustomPropertyProviderProxy<T1, T2>.ConvertTo<T1>(value));
		}

		// Token: 0x06006593 RID: 26003 RVA: 0x0015970C File Offset: 0x0015790C
		void IBindableVector.RemoveAt(uint index)
		{
			IBindableVector ibindableVectorNoThrow = this.GetIBindableVectorNoThrow();
			if (ibindableVectorNoThrow != null)
			{
				ibindableVectorNoThrow.RemoveAt(index);
				return;
			}
			this.GetVectorOfT().RemoveAt(index);
		}

		// Token: 0x06006594 RID: 26004 RVA: 0x00159738 File Offset: 0x00157938
		void IBindableVector.Append(object value)
		{
			IBindableVector ibindableVectorNoThrow = this.GetIBindableVectorNoThrow();
			if (ibindableVectorNoThrow != null)
			{
				ibindableVectorNoThrow.Append(value);
				return;
			}
			this.GetVectorOfT().Append(ICustomPropertyProviderProxy<T1, T2>.ConvertTo<T1>(value));
		}

		// Token: 0x06006595 RID: 26005 RVA: 0x00159768 File Offset: 0x00157968
		void IBindableVector.RemoveAtEnd()
		{
			IBindableVector ibindableVectorNoThrow = this.GetIBindableVectorNoThrow();
			if (ibindableVectorNoThrow != null)
			{
				ibindableVectorNoThrow.RemoveAtEnd();
				return;
			}
			this.GetVectorOfT().RemoveAtEnd();
		}

		// Token: 0x06006596 RID: 26006 RVA: 0x00159794 File Offset: 0x00157994
		void IBindableVector.Clear()
		{
			IBindableVector ibindableVectorNoThrow = this.GetIBindableVectorNoThrow();
			if (ibindableVectorNoThrow != null)
			{
				ibindableVectorNoThrow.Clear();
				return;
			}
			this.GetVectorOfT().Clear();
		}

		// Token: 0x06006597 RID: 26007 RVA: 0x001597BD File Offset: 0x001579BD
		[SecuritySafeCritical]
		private IBindableVector GetIBindableVectorNoThrow()
		{
			if ((this._flags & InterfaceForwardingSupport.IBindableVector) != InterfaceForwardingSupport.None)
			{
				return JitHelpers.UnsafeCast<IBindableVector>(this._target);
			}
			return null;
		}

		// Token: 0x06006598 RID: 26008 RVA: 0x001597D6 File Offset: 0x001579D6
		[SecuritySafeCritical]
		private IVector_Raw<T1> GetVectorOfT()
		{
			if ((this._flags & InterfaceForwardingSupport.IVector) != InterfaceForwardingSupport.None)
			{
				return JitHelpers.UnsafeCast<IVector_Raw<T1>>(this._target);
			}
			throw new InvalidOperationException();
		}

		// Token: 0x06006599 RID: 26009 RVA: 0x001597F4 File Offset: 0x001579F4
		object IBindableVectorView.GetAt(uint index)
		{
			IBindableVectorView ibindableVectorViewNoThrow = this.GetIBindableVectorViewNoThrow();
			if (ibindableVectorViewNoThrow != null)
			{
				return ibindableVectorViewNoThrow.GetAt(index);
			}
			return this.GetVectorViewOfT().GetAt(index);
		}

		// Token: 0x17001172 RID: 4466
		// (get) Token: 0x0600659A RID: 26010 RVA: 0x00159824 File Offset: 0x00157A24
		uint IBindableVectorView.Size
		{
			get
			{
				IBindableVectorView ibindableVectorViewNoThrow = this.GetIBindableVectorViewNoThrow();
				if (ibindableVectorViewNoThrow != null)
				{
					return ibindableVectorViewNoThrow.Size;
				}
				return this.GetVectorViewOfT().Size;
			}
		}

		// Token: 0x0600659B RID: 26011 RVA: 0x00159850 File Offset: 0x00157A50
		bool IBindableVectorView.IndexOf(object value, out uint index)
		{
			IBindableVectorView ibindableVectorViewNoThrow = this.GetIBindableVectorViewNoThrow();
			if (ibindableVectorViewNoThrow != null)
			{
				return ibindableVectorViewNoThrow.IndexOf(value, out index);
			}
			return this.GetVectorViewOfT().IndexOf(ICustomPropertyProviderProxy<T1, T2>.ConvertTo<T2>(value), out index);
		}

		// Token: 0x0600659C RID: 26012 RVA: 0x00159884 File Offset: 0x00157A84
		IBindableIterator IBindableIterable.First()
		{
			IBindableVectorView ibindableVectorViewNoThrow = this.GetIBindableVectorViewNoThrow();
			if (ibindableVectorViewNoThrow != null)
			{
				return ibindableVectorViewNoThrow.First();
			}
			return new ICustomPropertyProviderProxy<T1, T2>.IteratorOfTToIteratorAdapter<T2>(this.GetVectorViewOfT().First());
		}

		// Token: 0x0600659D RID: 26013 RVA: 0x001598B2 File Offset: 0x00157AB2
		[SecuritySafeCritical]
		private IBindableVectorView GetIBindableVectorViewNoThrow()
		{
			if ((this._flags & InterfaceForwardingSupport.IBindableVectorView) != InterfaceForwardingSupport.None)
			{
				return JitHelpers.UnsafeCast<IBindableVectorView>(this._target);
			}
			return null;
		}

		// Token: 0x0600659E RID: 26014 RVA: 0x001598CB File Offset: 0x00157ACB
		[SecuritySafeCritical]
		private IVectorView<T2> GetVectorViewOfT()
		{
			if ((this._flags & InterfaceForwardingSupport.IVectorView) != InterfaceForwardingSupport.None)
			{
				return JitHelpers.UnsafeCast<IVectorView<T2>>(this._target);
			}
			throw new InvalidOperationException();
		}

		// Token: 0x0600659F RID: 26015 RVA: 0x001598E8 File Offset: 0x00157AE8
		private static T ConvertTo<T>(object value)
		{
			ThrowHelper.IfNullAndNullsAreIllegalThenThrow<T>(value, ExceptionArgument.value);
			return (T)((object)value);
		}

		// Token: 0x04002D3A RID: 11578
		private object _target;

		// Token: 0x04002D3B RID: 11579
		private InterfaceForwardingSupport _flags;

		// Token: 0x02000CA6 RID: 3238
		private sealed class IVectorViewToIBindableVectorViewAdapter<T> : IBindableVectorView, IBindableIterable
		{
			// Token: 0x06007147 RID: 28999 RVA: 0x00185E37 File Offset: 0x00184037
			public IVectorViewToIBindableVectorViewAdapter(IVectorView<T> vectorView)
			{
				this._vectorView = vectorView;
			}

			// Token: 0x06007148 RID: 29000 RVA: 0x00185E46 File Offset: 0x00184046
			object IBindableVectorView.GetAt(uint index)
			{
				return this._vectorView.GetAt(index);
			}

			// Token: 0x1700136C RID: 4972
			// (get) Token: 0x06007149 RID: 29001 RVA: 0x00185E59 File Offset: 0x00184059
			uint IBindableVectorView.Size
			{
				get
				{
					return this._vectorView.Size;
				}
			}

			// Token: 0x0600714A RID: 29002 RVA: 0x00185E66 File Offset: 0x00184066
			bool IBindableVectorView.IndexOf(object value, out uint index)
			{
				return this._vectorView.IndexOf(ICustomPropertyProviderProxy<T1, T2>.ConvertTo<T>(value), out index);
			}

			// Token: 0x0600714B RID: 29003 RVA: 0x00185E7A File Offset: 0x0018407A
			IBindableIterator IBindableIterable.First()
			{
				return new ICustomPropertyProviderProxy<T1, T2>.IteratorOfTToIteratorAdapter<T>(this._vectorView.First());
			}

			// Token: 0x04003883 RID: 14467
			private IVectorView<T> _vectorView;
		}

		// Token: 0x02000CA7 RID: 3239
		private sealed class IteratorOfTToIteratorAdapter<T> : IBindableIterator
		{
			// Token: 0x0600714C RID: 29004 RVA: 0x00185E8C File Offset: 0x0018408C
			public IteratorOfTToIteratorAdapter(IIterator<T> iterator)
			{
				this._iterator = iterator;
			}

			// Token: 0x1700136D RID: 4973
			// (get) Token: 0x0600714D RID: 29005 RVA: 0x00185E9B File Offset: 0x0018409B
			public bool HasCurrent
			{
				get
				{
					return this._iterator.HasCurrent;
				}
			}

			// Token: 0x1700136E RID: 4974
			// (get) Token: 0x0600714E RID: 29006 RVA: 0x00185EA8 File Offset: 0x001840A8
			public object Current
			{
				get
				{
					return this._iterator.Current;
				}
			}

			// Token: 0x0600714F RID: 29007 RVA: 0x00185EBA File Offset: 0x001840BA
			public bool MoveNext()
			{
				return this._iterator.MoveNext();
			}

			// Token: 0x04003884 RID: 14468
			private IIterator<T> _iterator;
		}
	}
}
