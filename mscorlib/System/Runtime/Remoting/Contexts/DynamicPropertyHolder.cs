using System;
using System.Globalization;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x0200080F RID: 2063
	internal class DynamicPropertyHolder
	{
		// Token: 0x060058CB RID: 22731 RVA: 0x00138E34 File Offset: 0x00137034
		[SecurityCritical]
		internal virtual bool AddDynamicProperty(IDynamicProperty prop)
		{
			bool result;
			lock (this)
			{
				DynamicPropertyHolder.CheckPropertyNameClash(prop.Name, this._props, this._numProps);
				bool flag2 = false;
				if (this._props == null || this._numProps == this._props.Length)
				{
					this._props = DynamicPropertyHolder.GrowPropertiesArray(this._props);
					flag2 = true;
				}
				IDynamicProperty[] props = this._props;
				int numProps = this._numProps;
				this._numProps = numProps + 1;
				props[numProps] = prop;
				if (flag2)
				{
					this._sinks = DynamicPropertyHolder.GrowDynamicSinksArray(this._sinks);
				}
				if (this._sinks == null)
				{
					this._sinks = new IDynamicMessageSink[this._props.Length];
					for (int i = 0; i < this._numProps; i++)
					{
						this._sinks[i] = ((IContributeDynamicSink)this._props[i]).GetDynamicSink();
					}
				}
				else
				{
					this._sinks[this._numProps - 1] = ((IContributeDynamicSink)prop).GetDynamicSink();
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060058CC RID: 22732 RVA: 0x00138F48 File Offset: 0x00137148
		[SecurityCritical]
		internal virtual bool RemoveDynamicProperty(string name)
		{
			lock (this)
			{
				for (int i = 0; i < this._numProps; i++)
				{
					if (this._props[i].Name.Equals(name))
					{
						this._props[i] = this._props[this._numProps - 1];
						this._numProps--;
						this._sinks = null;
						return true;
					}
				}
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Contexts_NoProperty"), name));
			}
			bool result;
			return result;
		}

		// Token: 0x17000EBA RID: 3770
		// (get) Token: 0x060058CD RID: 22733 RVA: 0x00138FF0 File Offset: 0x001371F0
		internal virtual IDynamicProperty[] DynamicProperties
		{
			get
			{
				if (this._props == null)
				{
					return null;
				}
				IDynamicProperty[] result;
				lock (this)
				{
					IDynamicProperty[] array = new IDynamicProperty[this._numProps];
					Array.Copy(this._props, array, this._numProps);
					result = array;
				}
				return result;
			}
		}

		// Token: 0x17000EBB RID: 3771
		// (get) Token: 0x060058CE RID: 22734 RVA: 0x00139050 File Offset: 0x00137250
		internal virtual ArrayWithSize DynamicSinks
		{
			[SecurityCritical]
			get
			{
				if (this._numProps == 0)
				{
					return null;
				}
				lock (this)
				{
					if (this._sinks == null)
					{
						this._sinks = new IDynamicMessageSink[this._numProps + 8];
						for (int i = 0; i < this._numProps; i++)
						{
							this._sinks[i] = ((IContributeDynamicSink)this._props[i]).GetDynamicSink();
						}
					}
				}
				return new ArrayWithSize(this._sinks, this._numProps);
			}
		}

		// Token: 0x060058CF RID: 22735 RVA: 0x001390E8 File Offset: 0x001372E8
		private static IDynamicMessageSink[] GrowDynamicSinksArray(IDynamicMessageSink[] sinks)
		{
			int num = ((sinks != null) ? sinks.Length : 0) + 8;
			IDynamicMessageSink[] array = new IDynamicMessageSink[num];
			if (sinks != null)
			{
				Array.Copy(sinks, array, sinks.Length);
			}
			return array;
		}

		// Token: 0x060058D0 RID: 22736 RVA: 0x00139118 File Offset: 0x00137318
		[SecurityCritical]
		internal static void NotifyDynamicSinks(IMessage msg, ArrayWithSize dynSinks, bool bCliSide, bool bStart, bool bAsync)
		{
			for (int i = 0; i < dynSinks.Count; i++)
			{
				if (bStart)
				{
					dynSinks.Sinks[i].ProcessMessageStart(msg, bCliSide, bAsync);
				}
				else
				{
					dynSinks.Sinks[i].ProcessMessageFinish(msg, bCliSide, bAsync);
				}
			}
		}

		// Token: 0x060058D1 RID: 22737 RVA: 0x00139160 File Offset: 0x00137360
		[SecurityCritical]
		internal static void CheckPropertyNameClash(string name, IDynamicProperty[] props, int count)
		{
			for (int i = 0; i < count; i++)
			{
				if (props[i].Name.Equals(name))
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_DuplicatePropertyName"));
				}
			}
		}

		// Token: 0x060058D2 RID: 22738 RVA: 0x0013919C File Offset: 0x0013739C
		internal static IDynamicProperty[] GrowPropertiesArray(IDynamicProperty[] props)
		{
			int num = ((props != null) ? props.Length : 0) + 8;
			IDynamicProperty[] array = new IDynamicProperty[num];
			if (props != null)
			{
				Array.Copy(props, array, props.Length);
			}
			return array;
		}

		// Token: 0x0400286E RID: 10350
		private const int GROW_BY = 8;

		// Token: 0x0400286F RID: 10351
		private IDynamicProperty[] _props;

		// Token: 0x04002870 RID: 10352
		private int _numProps;

		// Token: 0x04002871 RID: 10353
		private IDynamicMessageSink[] _sinks;
	}
}
