using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CefSharp
{
	// Token: 0x02000021 RID: 33
	public class DomNode : IDomNode, IEnumerable<KeyValuePair<string, string>>, IEnumerable
	{
		// Token: 0x060000B1 RID: 177 RVA: 0x00002F93 File Offset: 0x00001193
		public DomNode(string tagName, IDictionary<string, string> attributes)
		{
			this.TagName = tagName;
			this.attributes = attributes;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00002FAC File Offset: 0x000011AC
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (this.attributes != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in this.attributes)
				{
					stringBuilder.AppendFormat("{0}{1}:'{2}'", (0 < stringBuilder.Length) ? ", " : string.Empty, keyValuePair.Key, keyValuePair.Value);
				}
			}
			if (!string.IsNullOrWhiteSpace(this.TagName))
			{
				stringBuilder.Insert(0, string.Format("{0} ", this.TagName));
			}
			if (stringBuilder.Length < 1)
			{
				return base.ToString();
			}
			return stringBuilder.ToString();
		}

		// Token: 0x17000040 RID: 64
		public string this[string name]
		{
			get
			{
				if (this.attributes == null || this.attributes.Count < 1 || !this.attributes.ContainsKey(name))
				{
					return null;
				}
				return this.attributes[name];
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x000030A0 File Offset: 0x000012A0
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x000030A8 File Offset: 0x000012A8
		public string TagName { get; private set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x000030B1 File Offset: 0x000012B1
		public ReadOnlyCollection<string> AttributeNames
		{
			get
			{
				if (this.attributes == null)
				{
					return new ReadOnlyCollection<string>(new List<string>());
				}
				return Array.AsReadOnly<string>(this.attributes.Keys.ToArray<string>());
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000030DB File Offset: 0x000012DB
		public bool HasAttribute(string attributeName)
		{
			return this.attributes != null && this.attributes.ContainsKey(attributeName);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000030F3 File Offset: 0x000012F3
		public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			if (this.attributes == null)
			{
				return new Dictionary<string, string>().GetEnumerator();
			}
			return this.attributes.GetEnumerator();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003118 File Offset: 0x00001318
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x04000036 RID: 54
		private readonly IDictionary<string, string> attributes;
	}
}
