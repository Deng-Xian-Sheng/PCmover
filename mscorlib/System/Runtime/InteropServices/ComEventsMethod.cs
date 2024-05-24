using System;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009AD RID: 2477
	internal class ComEventsMethod
	{
		// Token: 0x06006314 RID: 25364 RVA: 0x00151C35 File Offset: 0x0014FE35
		internal ComEventsMethod(int dispid)
		{
			this._delegateWrappers = null;
			this._dispid = dispid;
		}

		// Token: 0x06006315 RID: 25365 RVA: 0x00151C4B File Offset: 0x0014FE4B
		internal static ComEventsMethod Find(ComEventsMethod methods, int dispid)
		{
			while (methods != null && methods._dispid != dispid)
			{
				methods = methods._next;
			}
			return methods;
		}

		// Token: 0x06006316 RID: 25366 RVA: 0x00151C64 File Offset: 0x0014FE64
		internal static ComEventsMethod Add(ComEventsMethod methods, ComEventsMethod method)
		{
			method._next = methods;
			return method;
		}

		// Token: 0x06006317 RID: 25367 RVA: 0x00151C70 File Offset: 0x0014FE70
		internal static ComEventsMethod Remove(ComEventsMethod methods, ComEventsMethod method)
		{
			if (methods == method)
			{
				methods = methods._next;
			}
			else
			{
				ComEventsMethod comEventsMethod = methods;
				while (comEventsMethod != null && comEventsMethod._next != method)
				{
					comEventsMethod = comEventsMethod._next;
				}
				if (comEventsMethod != null)
				{
					comEventsMethod._next = method._next;
				}
			}
			return methods;
		}

		// Token: 0x1700111F RID: 4383
		// (get) Token: 0x06006318 RID: 25368 RVA: 0x00151CB2 File Offset: 0x0014FEB2
		internal int DispId
		{
			get
			{
				return this._dispid;
			}
		}

		// Token: 0x17001120 RID: 4384
		// (get) Token: 0x06006319 RID: 25369 RVA: 0x00151CBA File Offset: 0x0014FEBA
		internal bool Empty
		{
			get
			{
				return this._delegateWrappers == null || this._delegateWrappers.Length == 0;
			}
		}

		// Token: 0x0600631A RID: 25370 RVA: 0x00151CD0 File Offset: 0x0014FED0
		internal void AddDelegate(Delegate d)
		{
			int num = 0;
			if (this._delegateWrappers != null)
			{
				num = this._delegateWrappers.Length;
			}
			for (int i = 0; i < num; i++)
			{
				if (this._delegateWrappers[i].Delegate.GetType() == d.GetType())
				{
					this._delegateWrappers[i].Delegate = Delegate.Combine(this._delegateWrappers[i].Delegate, d);
					return;
				}
			}
			ComEventsMethod.DelegateWrapper[] array = new ComEventsMethod.DelegateWrapper[num + 1];
			if (num > 0)
			{
				this._delegateWrappers.CopyTo(array, 0);
			}
			ComEventsMethod.DelegateWrapper delegateWrapper = new ComEventsMethod.DelegateWrapper(d);
			array[num] = delegateWrapper;
			this._delegateWrappers = array;
		}

		// Token: 0x0600631B RID: 25371 RVA: 0x00151D68 File Offset: 0x0014FF68
		internal void RemoveDelegate(Delegate d)
		{
			int num = this._delegateWrappers.Length;
			int num2 = -1;
			for (int i = 0; i < num; i++)
			{
				if (this._delegateWrappers[i].Delegate.GetType() == d.GetType())
				{
					num2 = i;
					break;
				}
			}
			if (num2 < 0)
			{
				return;
			}
			Delegate @delegate = Delegate.Remove(this._delegateWrappers[num2].Delegate, d);
			if (@delegate != null)
			{
				this._delegateWrappers[num2].Delegate = @delegate;
				return;
			}
			if (num == 1)
			{
				this._delegateWrappers = null;
				return;
			}
			ComEventsMethod.DelegateWrapper[] array = new ComEventsMethod.DelegateWrapper[num - 1];
			int j;
			for (j = 0; j < num2; j++)
			{
				array[j] = this._delegateWrappers[j];
			}
			while (j < num - 1)
			{
				array[j] = this._delegateWrappers[j + 1];
				j++;
			}
			this._delegateWrappers = array;
		}

		// Token: 0x0600631C RID: 25372 RVA: 0x00151E38 File Offset: 0x00150038
		internal object Invoke(object[] args)
		{
			object result = null;
			ComEventsMethod.DelegateWrapper[] delegateWrappers = this._delegateWrappers;
			foreach (ComEventsMethod.DelegateWrapper delegateWrapper in delegateWrappers)
			{
				if (delegateWrapper != null && delegateWrapper.Delegate != null)
				{
					result = delegateWrapper.Invoke(args);
				}
			}
			return result;
		}

		// Token: 0x04002CB0 RID: 11440
		private ComEventsMethod.DelegateWrapper[] _delegateWrappers;

		// Token: 0x04002CB1 RID: 11441
		private int _dispid;

		// Token: 0x04002CB2 RID: 11442
		private ComEventsMethod _next;

		// Token: 0x02000C9A RID: 3226
		internal class DelegateWrapper
		{
			// Token: 0x06007119 RID: 28953 RVA: 0x00185510 File Offset: 0x00183710
			public DelegateWrapper(Delegate d)
			{
				this._d = d;
			}

			// Token: 0x17001366 RID: 4966
			// (get) Token: 0x0600711A RID: 28954 RVA: 0x0018551F File Offset: 0x0018371F
			// (set) Token: 0x0600711B RID: 28955 RVA: 0x00185527 File Offset: 0x00183727
			public Delegate Delegate
			{
				get
				{
					return this._d;
				}
				set
				{
					this._d = value;
				}
			}

			// Token: 0x0600711C RID: 28956 RVA: 0x00185530 File Offset: 0x00183730
			public object Invoke(object[] args)
			{
				if (this._d == null)
				{
					return null;
				}
				if (!this._once)
				{
					this.PreProcessSignature();
					this._once = true;
				}
				if (this._cachedTargetTypes != null && this._expectedParamsCount == args.Length)
				{
					for (int i = 0; i < this._expectedParamsCount; i++)
					{
						if (this._cachedTargetTypes[i] != null)
						{
							args[i] = Enum.ToObject(this._cachedTargetTypes[i], args[i]);
						}
					}
				}
				return this._d.DynamicInvoke(args);
			}

			// Token: 0x0600711D RID: 28957 RVA: 0x001855B0 File Offset: 0x001837B0
			private void PreProcessSignature()
			{
				ParameterInfo[] parameters = this._d.Method.GetParameters();
				this._expectedParamsCount = parameters.Length;
				Type[] array = new Type[this._expectedParamsCount];
				bool flag = false;
				for (int i = 0; i < this._expectedParamsCount; i++)
				{
					ParameterInfo parameterInfo = parameters[i];
					if (parameterInfo.ParameterType.IsByRef && parameterInfo.ParameterType.HasElementType && parameterInfo.ParameterType.GetElementType().IsEnum)
					{
						flag = true;
						array[i] = parameterInfo.ParameterType.GetElementType();
					}
				}
				if (flag)
				{
					this._cachedTargetTypes = array;
				}
			}

			// Token: 0x04003856 RID: 14422
			private Delegate _d;

			// Token: 0x04003857 RID: 14423
			private bool _once;

			// Token: 0x04003858 RID: 14424
			private int _expectedParamsCount;

			// Token: 0x04003859 RID: 14425
			private Type[] _cachedTargetTypes;
		}
	}
}
