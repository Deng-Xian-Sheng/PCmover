using System;
using System.Collections;
using System.Diagnostics;
using System.Xml.XPath;

namespace Laplink.Tools.Helpers
{
	// Token: 0x02000007 RID: 7
	public class LlTextWriterTraceListener : TextWriterTraceListener
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00002750 File Offset: 0x00000950
		// (set) Token: 0x0600001D RID: 29 RVA: 0x00002758 File Offset: 0x00000958
		public bool DisplaySeq { get; set; } = true;

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002761 File Offset: 0x00000961
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002769 File Offset: 0x00000969
		public bool DisplayTime { get; set; } = true;

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002772 File Offset: 0x00000972
		// (set) Token: 0x06000021 RID: 33 RVA: 0x0000277A File Offset: 0x0000097A
		public bool DisplayThreadId { get; set; } = true;

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002783 File Offset: 0x00000983
		// (set) Token: 0x06000023 RID: 35 RVA: 0x0000278B File Offset: 0x0000098B
		public string Tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				this._tag = value;
				if (value != null)
				{
					this._startTag = "<" + value + ">";
					this._endTag = "</" + value + ">";
				}
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000027C3 File Offset: 0x000009C3
		public LlTextWriterTraceListener()
		{
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000027E0 File Offset: 0x000009E0
		public LlTextWriterTraceListener(string fileName) : base(fileName)
		{
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002800 File Offset: 0x00000A00
		public void FormatMessage(TraceEventCache eventCache, ref int id, ref string message)
		{
			this.GetPropertiesFromAttributes();
			string text = "";
			if (this.DisplayTime)
			{
				text += string.Format("{0:H:mm:ss} ", eventCache.DateTime.ToLocalTime());
			}
			if (this.DisplayThreadId)
			{
				text = text + "[" + eventCache.ThreadId + "] ";
			}
			text += message;
			if (this.DisplaySeq)
			{
				if (id == 0)
				{
					id = this._sequenceNumber;
				}
				else
				{
					text = string.Format("{0}: {1}", this._sequenceNumber, text);
				}
				this._sequenceNumber++;
			}
			message = text;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000028AB File Offset: 0x00000AAB
		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
		{
			this.FormatMessage(eventCache, ref id, ref message);
			base.TraceEvent(eventCache, source, eventType, id, message);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000028C5 File Offset: 0x00000AC5
		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
		{
			this.FormatMessage(eventCache, ref id, ref format);
			base.TraceEvent(eventCache, source, eventType, id, format, args);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000028E4 File Offset: 0x00000AE4
		public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
		{
			XPathNavigator xpathNavigator = data as XPathNavigator;
			if (xpathNavigator != null)
			{
				try
				{
					this.GetPropertiesFromAttributes();
					if (this._tag != null)
					{
						string text = xpathNavigator.ToString();
						if (text == null || text.Length == 0 || text[0] != '<')
						{
							text = xpathNavigator.InnerXml;
						}
						if (text != null)
						{
							int num = text.IndexOf(this._startTag);
							if (num >= 0)
							{
								int num2 = text.IndexOf(this._endTag);
								if (num2 >= 0)
								{
									int num3 = num + this._startTag.Length;
									string message = text.Substring(num3, num2 - num3);
									this.TraceEvent(eventCache, source, eventType, id, message);
									return;
								}
							}
						}
					}
				}
				catch (Exception)
				{
				}
			}
			string message2;
			if (data == null)
			{
				message2 = "null";
			}
			else if (this._tag == null)
			{
				message2 = data.ToString();
			}
			else
			{
				message2 = string.Format("No {0} in TraceData {1}: {2}", this._tag, data.GetType(), data);
			}
			this.TraceEvent(eventCache, source, eventType, id, message2);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000029E0 File Offset: 0x00000BE0
		protected override string[] GetSupportedAttributes()
		{
			return new string[]
			{
				"displaySeq",
				"displayTime",
				"displayThreadId",
				"tag"
			};
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002A08 File Offset: 0x00000C08
		private void GetPropertiesFromAttributes()
		{
			if (this._gotProperties)
			{
				return;
			}
			this._gotProperties = true;
			foreach (object obj in base.Attributes)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string a = dictionaryEntry.Key.ToString().ToLower();
				bool flag;
				if (!(a == "displayseq"))
				{
					if (!(a == "displaytime"))
					{
						if (!(a == "displaythreadid"))
						{
							if (a == "tag")
							{
								this.Tag = dictionaryEntry.Value.ToString();
							}
						}
						else if (bool.TryParse(dictionaryEntry.Value.ToString(), out flag))
						{
							this.DisplayThreadId = flag;
						}
					}
					else if (bool.TryParse(dictionaryEntry.Value.ToString(), out flag))
					{
						this.DisplayTime = flag;
					}
				}
				else if (bool.TryParse(dictionaryEntry.Value.ToString(), out flag))
				{
					this.DisplaySeq = flag;
				}
			}
		}

		// Token: 0x04000006 RID: 6
		private string _startTag;

		// Token: 0x04000007 RID: 7
		private string _endTag;

		// Token: 0x04000008 RID: 8
		private string _tag;

		// Token: 0x04000009 RID: 9
		private int _sequenceNumber;

		// Token: 0x0400000A RID: 10
		private bool _gotProperties;
	}
}
