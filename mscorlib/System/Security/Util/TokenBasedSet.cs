using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Threading;

namespace System.Security.Util
{
	// Token: 0x0200037D RID: 893
	[Serializable]
	internal class TokenBasedSet
	{
		// Token: 0x06002C5E RID: 11358 RVA: 0x000A5844 File Offset: 0x000A3A44
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx)
		{
			this.OnDeserializedInternal();
		}

		// Token: 0x06002C5F RID: 11359 RVA: 0x000A584C File Offset: 0x000A3A4C
		private void OnDeserializedInternal()
		{
			if (this.m_objSet != null)
			{
				if (this.m_cElt == 1)
				{
					this.m_Obj = this.m_objSet[this.m_maxIndex];
				}
				else
				{
					this.m_Set = this.m_objSet;
				}
				this.m_objSet = null;
			}
		}

		// Token: 0x06002C60 RID: 11360 RVA: 0x000A5898 File Offset: 0x000A3A98
		[OnSerializing]
		private void OnSerializing(StreamingContext ctx)
		{
			if ((ctx.State & ~(StreamingContextStates.Clone | StreamingContextStates.CrossAppDomain)) != (StreamingContextStates)0)
			{
				if (this.m_cElt == 1)
				{
					this.m_objSet = new object[this.m_maxIndex + 1];
					this.m_objSet[this.m_maxIndex] = this.m_Obj;
					return;
				}
				if (this.m_cElt > 0)
				{
					this.m_objSet = this.m_Set;
				}
			}
		}

		// Token: 0x06002C61 RID: 11361 RVA: 0x000A5901 File Offset: 0x000A3B01
		[OnSerialized]
		private void OnSerialized(StreamingContext ctx)
		{
			if ((ctx.State & ~(StreamingContextStates.Clone | StreamingContextStates.CrossAppDomain)) != (StreamingContextStates)0)
			{
				this.m_objSet = null;
			}
		}

		// Token: 0x06002C62 RID: 11362 RVA: 0x000A591C File Offset: 0x000A3B1C
		internal bool MoveNext(ref TokenBasedSetEnumerator e)
		{
			int cElt = this.m_cElt;
			if (cElt == 0)
			{
				return false;
			}
			if (cElt != 1)
			{
				do
				{
					int num = e.Index + 1;
					e.Index = num;
					if (num > this.m_maxIndex)
					{
						goto Block_5;
					}
					e.Current = Volatile.Read<object>(ref this.m_Set[e.Index]);
				}
				while (e.Current == null);
				return true;
				Block_5:
				e.Current = null;
				return false;
			}
			if (e.Index == -1)
			{
				e.Index = this.m_maxIndex;
				e.Current = this.m_Obj;
				return true;
			}
			e.Index = (int)((short)(this.m_maxIndex + 1));
			e.Current = null;
			return false;
		}

		// Token: 0x06002C63 RID: 11363 RVA: 0x000A59C4 File Offset: 0x000A3BC4
		internal TokenBasedSet()
		{
			this.Reset();
		}

		// Token: 0x06002C64 RID: 11364 RVA: 0x000A59E4 File Offset: 0x000A3BE4
		internal TokenBasedSet(TokenBasedSet tbSet)
		{
			if (tbSet == null)
			{
				this.Reset();
				return;
			}
			if (tbSet.m_cElt > 1)
			{
				object[] set = tbSet.m_Set;
				int num = set.Length;
				object[] array = new object[num];
				Array.Copy(set, 0, array, 0, num);
				this.m_Set = array;
			}
			else
			{
				this.m_Obj = tbSet.m_Obj;
			}
			this.m_cElt = tbSet.m_cElt;
			this.m_maxIndex = tbSet.m_maxIndex;
		}

		// Token: 0x06002C65 RID: 11365 RVA: 0x000A5A6E File Offset: 0x000A3C6E
		internal void Reset()
		{
			this.m_Obj = null;
			this.m_Set = null;
			this.m_cElt = 0;
			this.m_maxIndex = -1;
		}

		// Token: 0x06002C66 RID: 11366 RVA: 0x000A5A94 File Offset: 0x000A3C94
		internal void SetItem(int index, object item)
		{
			if (item == null)
			{
				this.RemoveItem(index);
				return;
			}
			int cElt = this.m_cElt;
			if (cElt == 0)
			{
				this.m_cElt = 1;
				this.m_maxIndex = (int)((short)index);
				this.m_Obj = item;
				return;
			}
			if (cElt != 1)
			{
				object[] array = this.m_Set;
				if (index >= array.Length)
				{
					object[] array2 = new object[index + 1];
					Array.Copy(array, 0, array2, 0, this.m_maxIndex + 1);
					this.m_maxIndex = (int)((short)index);
					array2[index] = item;
					this.m_Set = array2;
					this.m_cElt++;
					return;
				}
				if (array[index] == null)
				{
					this.m_cElt++;
				}
				array[index] = item;
				if (index > this.m_maxIndex)
				{
					this.m_maxIndex = (int)((short)index);
				}
				return;
			}
			else
			{
				if (index == this.m_maxIndex)
				{
					this.m_Obj = item;
					return;
				}
				object obj = this.m_Obj;
				int num = Math.Max(this.m_maxIndex, index);
				object[] array = new object[num + 1];
				array[this.m_maxIndex] = obj;
				array[index] = item;
				this.m_maxIndex = (int)((short)num);
				this.m_cElt = 2;
				this.m_Set = array;
				this.m_Obj = null;
				return;
			}
		}

		// Token: 0x06002C67 RID: 11367 RVA: 0x000A5BC8 File Offset: 0x000A3DC8
		internal object GetItem(int index)
		{
			int cElt = this.m_cElt;
			if (cElt == 0)
			{
				return null;
			}
			if (cElt != 1)
			{
				if (index < this.m_Set.Length)
				{
					return Volatile.Read<object>(ref this.m_Set[index]);
				}
				return null;
			}
			else
			{
				if (index == this.m_maxIndex)
				{
					return this.m_Obj;
				}
				return null;
			}
		}

		// Token: 0x06002C68 RID: 11368 RVA: 0x000A5C20 File Offset: 0x000A3E20
		internal object RemoveItem(int index)
		{
			object result = null;
			int cElt = this.m_cElt;
			if (cElt != 0)
			{
				if (cElt != 1)
				{
					if (index < this.m_Set.Length && (result = Volatile.Read<object>(ref this.m_Set[index])) != null)
					{
						Volatile.Write<object>(ref this.m_Set[index], null);
						this.m_cElt--;
						if (index == this.m_maxIndex)
						{
							this.ResetMaxIndex(this.m_Set);
						}
						if (this.m_cElt == 1)
						{
							this.m_Obj = Volatile.Read<object>(ref this.m_Set[this.m_maxIndex]);
							this.m_Set = null;
						}
					}
				}
				else if (index != this.m_maxIndex)
				{
					result = null;
				}
				else
				{
					result = this.m_Obj;
					this.Reset();
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06002C69 RID: 11369 RVA: 0x000A5D04 File Offset: 0x000A3F04
		private void ResetMaxIndex(object[] aObj)
		{
			for (int i = aObj.Length - 1; i >= 0; i--)
			{
				if (aObj[i] != null)
				{
					this.m_maxIndex = (int)((short)i);
					return;
				}
			}
			this.m_maxIndex = -1;
		}

		// Token: 0x06002C6A RID: 11370 RVA: 0x000A5D3A File Offset: 0x000A3F3A
		internal int GetStartingIndex()
		{
			if (this.m_cElt <= 1)
			{
				return this.m_maxIndex;
			}
			return 0;
		}

		// Token: 0x06002C6B RID: 11371 RVA: 0x000A5D4F File Offset: 0x000A3F4F
		internal int GetCount()
		{
			return this.m_cElt;
		}

		// Token: 0x06002C6C RID: 11372 RVA: 0x000A5D57 File Offset: 0x000A3F57
		internal int GetMaxUsedIndex()
		{
			return this.m_maxIndex;
		}

		// Token: 0x06002C6D RID: 11373 RVA: 0x000A5D61 File Offset: 0x000A3F61
		internal bool FastIsEmpty()
		{
			return this.m_cElt == 0;
		}

		// Token: 0x06002C6E RID: 11374 RVA: 0x000A5D6C File Offset: 0x000A3F6C
		internal TokenBasedSet SpecialUnion(TokenBasedSet other)
		{
			this.OnDeserializedInternal();
			TokenBasedSet tokenBasedSet = new TokenBasedSet();
			int num;
			if (other != null)
			{
				other.OnDeserializedInternal();
				num = ((this.GetMaxUsedIndex() > other.GetMaxUsedIndex()) ? this.GetMaxUsedIndex() : other.GetMaxUsedIndex());
			}
			else
			{
				num = this.GetMaxUsedIndex();
			}
			for (int i = 0; i <= num; i++)
			{
				object item = this.GetItem(i);
				IPermission permission = item as IPermission;
				ISecurityElementFactory securityElementFactory = item as ISecurityElementFactory;
				object obj = (other != null) ? other.GetItem(i) : null;
				IPermission permission2 = obj as IPermission;
				ISecurityElementFactory securityElementFactory2 = obj as ISecurityElementFactory;
				if (item != null || obj != null)
				{
					if (item == null)
					{
						if (securityElementFactory2 != null)
						{
							permission2 = PermissionSet.CreatePerm(securityElementFactory2, false);
						}
						PermissionToken token = PermissionToken.GetToken(permission2);
						if (token == null)
						{
							throw new SerializationException(Environment.GetResourceString("Serialization_InsufficientState"));
						}
						tokenBasedSet.SetItem(token.m_index, permission2);
					}
					else if (obj == null)
					{
						if (securityElementFactory != null)
						{
							permission = PermissionSet.CreatePerm(securityElementFactory, false);
						}
						PermissionToken token2 = PermissionToken.GetToken(permission);
						if (token2 == null)
						{
							throw new SerializationException(Environment.GetResourceString("Serialization_InsufficientState"));
						}
						tokenBasedSet.SetItem(token2.m_index, permission);
					}
				}
			}
			return tokenBasedSet;
		}

		// Token: 0x06002C6F RID: 11375 RVA: 0x000A5E84 File Offset: 0x000A4084
		internal void SpecialSplit(ref TokenBasedSet unrestrictedPermSet, ref TokenBasedSet normalPermSet, bool ignoreTypeLoadFailures)
		{
			int maxUsedIndex = this.GetMaxUsedIndex();
			for (int i = this.GetStartingIndex(); i <= maxUsedIndex; i++)
			{
				object item = this.GetItem(i);
				if (item != null)
				{
					IPermission permission = item as IPermission;
					if (permission == null)
					{
						permission = PermissionSet.CreatePerm(item, ignoreTypeLoadFailures);
					}
					PermissionToken token = PermissionToken.GetToken(permission);
					if (permission != null && token != null)
					{
						if (permission is IUnrestrictedPermission)
						{
							if (unrestrictedPermSet == null)
							{
								unrestrictedPermSet = new TokenBasedSet();
							}
							unrestrictedPermSet.SetItem(token.m_index, permission);
						}
						else
						{
							if (normalPermSet == null)
							{
								normalPermSet = new TokenBasedSet();
							}
							normalPermSet.SetItem(token.m_index, permission);
						}
					}
				}
			}
		}

		// Token: 0x040011CA RID: 4554
		private int m_initSize = 24;

		// Token: 0x040011CB RID: 4555
		private int m_increment = 8;

		// Token: 0x040011CC RID: 4556
		private object[] m_objSet;

		// Token: 0x040011CD RID: 4557
		[OptionalField(VersionAdded = 2)]
		private volatile object m_Obj;

		// Token: 0x040011CE RID: 4558
		[OptionalField(VersionAdded = 2)]
		private volatile object[] m_Set;

		// Token: 0x040011CF RID: 4559
		private int m_cElt;

		// Token: 0x040011D0 RID: 4560
		private volatile int m_maxIndex;
	}
}
