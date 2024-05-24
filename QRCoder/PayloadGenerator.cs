using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace QRCoder
{
	// Token: 0x0200000D RID: 13
	public static class PayloadGenerator
	{
		// Token: 0x06000031 RID: 49 RVA: 0x00002ED8 File Offset: 0x000010D8
		private static bool IsValidIban(string iban)
		{
			string text = iban.ToUpper().Replace(" ", "").Replace("-", "");
			bool flag = Regex.IsMatch(text, "^[a-zA-Z]{2}[0-9]{2}([a-zA-Z0-9]?){16,30}$");
			string text2 = (text.Substring(4) + text.Substring(0, 4)).ToCharArray().Aggregate("", (string current, char c) => current + (char.IsLetter(c) ? ((int)(c - '7')).ToString() : c.ToString()));
			int num = 0;
			for (int i = 0; i < (int)Math.Ceiling((double)(text2.Length - 2) / 7.0); i++)
			{
				int num2 = (i == 0) ? 0 : 2;
				int num3 = i * 7 + num2;
				if (!int.TryParse(((i == 0) ? "" : num.ToString()) + text2.Substring(num3, Math.Min(9 - num2, text2.Length - num3)), NumberStyles.Any, CultureInfo.InvariantCulture, out num))
				{
					break;
				}
				num %= 97;
			}
			bool flag2 = num == 1;
			return flag && flag2;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002FF4 File Offset: 0x000011F4
		private static bool IsValidQRIban(string iban)
		{
			bool flag = false;
			try
			{
				int num = Convert.ToInt32(iban.ToUpper().Replace(" ", "").Replace("-", "").Substring(4, 5));
				flag = (num >= 30000 && num <= 31999);
			}
			catch
			{
			}
			return PayloadGenerator.IsValidIban(iban) && flag;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003068 File Offset: 0x00001268
		private static bool IsValidBic(string bic)
		{
			return Regex.IsMatch(bic.Replace(" ", ""), "^([a-zA-Z]{4}[a-zA-Z]{2}[a-zA-Z0-9]{2}([a-zA-Z0-9]{3})?)$");
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003084 File Offset: 0x00001284
		private static string ConvertStringToEncoding(string message, string encoding)
		{
			Encoding encoding2 = Encoding.GetEncoding(encoding);
			Encoding utf = Encoding.UTF8;
			byte[] bytes = utf.GetBytes(message);
			byte[] array = Encoding.Convert(utf, encoding2, bytes);
			return encoding2.GetString(array, 0, array.Length);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000030B8 File Offset: 0x000012B8
		private static string EscapeInput(string inp, bool simple = false)
		{
			char[] array = new char[]
			{
				'\\',
				';',
				',',
				':'
			};
			if (simple)
			{
				array = new char[]
				{
					':'
				};
			}
			foreach (char c in array)
			{
				inp = inp.Replace(c.ToString(), "\\" + c.ToString());
			}
			return inp;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000311C File Offset: 0x0000131C
		public static bool ChecksumMod10(string digits)
		{
			if (string.IsNullOrEmpty(digits) || digits.Length < 2)
			{
				return false;
			}
			int[] array = new int[]
			{
				0,
				9,
				4,
				6,
				8,
				2,
				7,
				1,
				3,
				5
			};
			int num = 0;
			for (int i = 0; i < digits.Length - 1; i++)
			{
				int num2 = Convert.ToInt32(digits[i]) - 48;
				num = array[(num2 + num) % 10];
			}
			return (10 - num) % 10 == Convert.ToInt32(digits[digits.Length - 1]) - 48;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000319C File Offset: 0x0000139C
		private static bool isHexStyle(string inp)
		{
			return Regex.IsMatch(inp, "\\A\\b[0-9a-fA-F]+\\b\\Z") || Regex.IsMatch(inp, "\\A\\b(0[xX])?[0-9a-fA-F]+\\b\\Z");
		}

		// Token: 0x02000022 RID: 34
		public abstract class Payload
		{
			// Token: 0x17000007 RID: 7
			// (get) Token: 0x060000A7 RID: 167 RVA: 0x00006CFB File Offset: 0x00004EFB
			public virtual int Version
			{
				get
				{
					return -1;
				}
			}

			// Token: 0x17000008 RID: 8
			// (get) Token: 0x060000A8 RID: 168 RVA: 0x00006CFE File Offset: 0x00004EFE
			public virtual QRCodeGenerator.ECCLevel EccLevel
			{
				get
				{
					return QRCodeGenerator.ECCLevel.M;
				}
			}

			// Token: 0x17000009 RID: 9
			// (get) Token: 0x060000A9 RID: 169 RVA: 0x00006D01 File Offset: 0x00004F01
			public virtual QRCodeGenerator.EciMode EciMode
			{
				get
				{
					return QRCodeGenerator.EciMode.Default;
				}
			}

			// Token: 0x060000AA RID: 170
			public abstract override string ToString();
		}

		// Token: 0x02000023 RID: 35
		public class WiFi : PayloadGenerator.Payload
		{
			// Token: 0x060000AC RID: 172 RVA: 0x00006D0C File Offset: 0x00004F0C
			public WiFi(string ssid, string password, PayloadGenerator.WiFi.Authentication authenticationMode, bool isHiddenSSID = false, bool escapeHexStrings = true)
			{
				this.ssid = PayloadGenerator.EscapeInput(ssid, false);
				this.ssid = ((escapeHexStrings && PayloadGenerator.isHexStyle(this.ssid)) ? ("\"" + this.ssid + "\"") : this.ssid);
				this.password = PayloadGenerator.EscapeInput(password, false);
				this.password = ((escapeHexStrings && PayloadGenerator.isHexStyle(this.password)) ? ("\"" + this.password + "\"") : this.password);
				this.authenticationMode = authenticationMode.ToString();
				this.isHiddenSsid = isHiddenSSID;
			}

			// Token: 0x060000AD RID: 173 RVA: 0x00006DBC File Offset: 0x00004FBC
			public override string ToString()
			{
				return string.Concat(new string[]
				{
					"WIFI:T:",
					this.authenticationMode,
					";S:",
					this.ssid,
					";P:",
					this.password,
					";",
					this.isHiddenSsid ? "H:true" : string.Empty,
					";"
				});
			}

			// Token: 0x04000033 RID: 51
			private readonly string ssid;

			// Token: 0x04000034 RID: 52
			private readonly string password;

			// Token: 0x04000035 RID: 53
			private readonly string authenticationMode;

			// Token: 0x04000036 RID: 54
			private readonly bool isHiddenSsid;

			// Token: 0x02000062 RID: 98
			public enum Authentication
			{
				// Token: 0x04000121 RID: 289
				WEP,
				// Token: 0x04000122 RID: 290
				WPA,
				// Token: 0x04000123 RID: 291
				nopass
			}
		}

		// Token: 0x02000024 RID: 36
		public class Mail : PayloadGenerator.Payload
		{
			// Token: 0x060000AE RID: 174 RVA: 0x00006E2F File Offset: 0x0000502F
			public Mail(string mailReceiver = null, string subject = null, string message = null, PayloadGenerator.Mail.MailEncoding encoding = PayloadGenerator.Mail.MailEncoding.MAILTO)
			{
				this.mailReceiver = mailReceiver;
				this.subject = subject;
				this.message = message;
				this.encoding = encoding;
			}

			// Token: 0x060000AF RID: 175 RVA: 0x00006E54 File Offset: 0x00005054
			public override string ToString()
			{
				string result = string.Empty;
				switch (this.encoding)
				{
				case PayloadGenerator.Mail.MailEncoding.MAILTO:
				{
					List<string> list = new List<string>();
					if (!string.IsNullOrEmpty(this.subject))
					{
						list.Add("subject=" + Uri.EscapeDataString(this.subject));
					}
					if (!string.IsNullOrEmpty(this.message))
					{
						list.Add("body=" + Uri.EscapeDataString(this.message));
					}
					string str = list.Any<string>() ? ("?" + string.Join("&", list.ToArray())) : "";
					result = "mailto:" + this.mailReceiver + str;
					break;
				}
				case PayloadGenerator.Mail.MailEncoding.MATMSG:
					result = string.Concat(new string[]
					{
						"MATMSG:TO:",
						this.mailReceiver,
						";SUB:",
						PayloadGenerator.EscapeInput(this.subject, false),
						";BODY:",
						PayloadGenerator.EscapeInput(this.message, false),
						";;"
					});
					break;
				case PayloadGenerator.Mail.MailEncoding.SMTP:
					result = string.Concat(new string[]
					{
						"SMTP:",
						this.mailReceiver,
						":",
						PayloadGenerator.EscapeInput(this.subject, true),
						":",
						PayloadGenerator.EscapeInput(this.message, true)
					});
					break;
				}
				return result;
			}

			// Token: 0x04000037 RID: 55
			private readonly string mailReceiver;

			// Token: 0x04000038 RID: 56
			private readonly string subject;

			// Token: 0x04000039 RID: 57
			private readonly string message;

			// Token: 0x0400003A RID: 58
			private readonly PayloadGenerator.Mail.MailEncoding encoding;

			// Token: 0x02000063 RID: 99
			public enum MailEncoding
			{
				// Token: 0x04000125 RID: 293
				MAILTO,
				// Token: 0x04000126 RID: 294
				MATMSG,
				// Token: 0x04000127 RID: 295
				SMTP
			}
		}

		// Token: 0x02000025 RID: 37
		public class SMS : PayloadGenerator.Payload
		{
			// Token: 0x060000B0 RID: 176 RVA: 0x00006FBD File Offset: 0x000051BD
			public SMS(string number, PayloadGenerator.SMS.SMSEncoding encoding = PayloadGenerator.SMS.SMSEncoding.SMS)
			{
				this.number = number;
				this.subject = string.Empty;
				this.encoding = encoding;
			}

			// Token: 0x060000B1 RID: 177 RVA: 0x00006FDE File Offset: 0x000051DE
			public SMS(string number, string subject, PayloadGenerator.SMS.SMSEncoding encoding = PayloadGenerator.SMS.SMSEncoding.SMS)
			{
				this.number = number;
				this.subject = subject;
				this.encoding = encoding;
			}

			// Token: 0x060000B2 RID: 178 RVA: 0x00006FFC File Offset: 0x000051FC
			public override string ToString()
			{
				string result = string.Empty;
				switch (this.encoding)
				{
				case PayloadGenerator.SMS.SMSEncoding.SMS:
				{
					string str = string.Empty;
					if (!string.IsNullOrEmpty(this.subject))
					{
						str = "?body=" + Uri.EscapeDataString(this.subject);
					}
					result = "sms:" + this.number + str;
					break;
				}
				case PayloadGenerator.SMS.SMSEncoding.SMSTO:
					result = "SMSTO:" + this.number + ":" + this.subject;
					break;
				case PayloadGenerator.SMS.SMSEncoding.SMS_iOS:
				{
					string str2 = string.Empty;
					if (!string.IsNullOrEmpty(this.subject))
					{
						str2 = ";body=" + Uri.EscapeDataString(this.subject);
					}
					result = "sms:" + this.number + str2;
					break;
				}
				}
				return result;
			}

			// Token: 0x0400003B RID: 59
			private readonly string number;

			// Token: 0x0400003C RID: 60
			private readonly string subject;

			// Token: 0x0400003D RID: 61
			private readonly PayloadGenerator.SMS.SMSEncoding encoding;

			// Token: 0x02000064 RID: 100
			public enum SMSEncoding
			{
				// Token: 0x04000129 RID: 297
				SMS,
				// Token: 0x0400012A RID: 298
				SMSTO,
				// Token: 0x0400012B RID: 299
				SMS_iOS
			}
		}

		// Token: 0x02000026 RID: 38
		public class MMS : PayloadGenerator.Payload
		{
			// Token: 0x060000B3 RID: 179 RVA: 0x000070C4 File Offset: 0x000052C4
			public MMS(string number, PayloadGenerator.MMS.MMSEncoding encoding = PayloadGenerator.MMS.MMSEncoding.MMS)
			{
				this.number = number;
				this.subject = string.Empty;
				this.encoding = encoding;
			}

			// Token: 0x060000B4 RID: 180 RVA: 0x000070E5 File Offset: 0x000052E5
			public MMS(string number, string subject, PayloadGenerator.MMS.MMSEncoding encoding = PayloadGenerator.MMS.MMSEncoding.MMS)
			{
				this.number = number;
				this.subject = subject;
				this.encoding = encoding;
			}

			// Token: 0x060000B5 RID: 181 RVA: 0x00007104 File Offset: 0x00005304
			public override string ToString()
			{
				string result = string.Empty;
				PayloadGenerator.MMS.MMSEncoding mmsencoding = this.encoding;
				if (mmsencoding != PayloadGenerator.MMS.MMSEncoding.MMS)
				{
					if (mmsencoding == PayloadGenerator.MMS.MMSEncoding.MMSTO)
					{
						string str = string.Empty;
						if (!string.IsNullOrEmpty(this.subject))
						{
							str = "?subject=" + Uri.EscapeDataString(this.subject);
						}
						result = "mmsto:" + this.number + str;
					}
				}
				else
				{
					string str2 = string.Empty;
					if (!string.IsNullOrEmpty(this.subject))
					{
						str2 = "?body=" + Uri.EscapeDataString(this.subject);
					}
					result = "mms:" + this.number + str2;
				}
				return result;
			}

			// Token: 0x0400003E RID: 62
			private readonly string number;

			// Token: 0x0400003F RID: 63
			private readonly string subject;

			// Token: 0x04000040 RID: 64
			private readonly PayloadGenerator.MMS.MMSEncoding encoding;

			// Token: 0x02000065 RID: 101
			public enum MMSEncoding
			{
				// Token: 0x0400012D RID: 301
				MMS,
				// Token: 0x0400012E RID: 302
				MMSTO
			}
		}

		// Token: 0x02000027 RID: 39
		public class Geolocation : PayloadGenerator.Payload
		{
			// Token: 0x060000B6 RID: 182 RVA: 0x0000719E File Offset: 0x0000539E
			public Geolocation(string latitude, string longitude, PayloadGenerator.Geolocation.GeolocationEncoding encoding = PayloadGenerator.Geolocation.GeolocationEncoding.GEO)
			{
				this.latitude = latitude.Replace(",", ".");
				this.longitude = longitude.Replace(",", ".");
				this.encoding = encoding;
			}

			// Token: 0x060000B7 RID: 183 RVA: 0x000071DC File Offset: 0x000053DC
			public override string ToString()
			{
				PayloadGenerator.Geolocation.GeolocationEncoding geolocationEncoding = this.encoding;
				if (geolocationEncoding == PayloadGenerator.Geolocation.GeolocationEncoding.GEO)
				{
					return "geo:" + this.latitude + "," + this.longitude;
				}
				if (geolocationEncoding != PayloadGenerator.Geolocation.GeolocationEncoding.GoogleMaps)
				{
					return "geo:";
				}
				return "http://maps.google.com/maps?q=" + this.latitude + "," + this.longitude;
			}

			// Token: 0x04000041 RID: 65
			private readonly string latitude;

			// Token: 0x04000042 RID: 66
			private readonly string longitude;

			// Token: 0x04000043 RID: 67
			private readonly PayloadGenerator.Geolocation.GeolocationEncoding encoding;

			// Token: 0x02000066 RID: 102
			public enum GeolocationEncoding
			{
				// Token: 0x04000130 RID: 304
				GEO,
				// Token: 0x04000131 RID: 305
				GoogleMaps
			}
		}

		// Token: 0x02000028 RID: 40
		public class PhoneNumber : PayloadGenerator.Payload
		{
			// Token: 0x060000B8 RID: 184 RVA: 0x00007236 File Offset: 0x00005436
			public PhoneNumber(string number)
			{
				this.number = number;
			}

			// Token: 0x060000B9 RID: 185 RVA: 0x00007245 File Offset: 0x00005445
			public override string ToString()
			{
				return "tel:" + this.number;
			}

			// Token: 0x04000044 RID: 68
			private readonly string number;
		}

		// Token: 0x02000029 RID: 41
		public class SkypeCall : PayloadGenerator.Payload
		{
			// Token: 0x060000BA RID: 186 RVA: 0x00007257 File Offset: 0x00005457
			public SkypeCall(string skypeUsername)
			{
				this.skypeUsername = skypeUsername;
			}

			// Token: 0x060000BB RID: 187 RVA: 0x00007266 File Offset: 0x00005466
			public override string ToString()
			{
				return "skype:" + this.skypeUsername + "?call";
			}

			// Token: 0x04000045 RID: 69
			private readonly string skypeUsername;
		}

		// Token: 0x0200002A RID: 42
		public class Url : PayloadGenerator.Payload
		{
			// Token: 0x060000BC RID: 188 RVA: 0x0000727D File Offset: 0x0000547D
			public Url(string url)
			{
				this.url = url;
			}

			// Token: 0x060000BD RID: 189 RVA: 0x0000728C File Offset: 0x0000548C
			public override string ToString()
			{
				if (this.url.StartsWith("http"))
				{
					return this.url;
				}
				return "http://" + this.url;
			}

			// Token: 0x04000046 RID: 70
			private readonly string url;
		}

		// Token: 0x0200002B RID: 43
		public class WhatsAppMessage : PayloadGenerator.Payload
		{
			// Token: 0x060000BE RID: 190 RVA: 0x000072B7 File Offset: 0x000054B7
			public WhatsAppMessage(string number, string message)
			{
				this.number = number;
				this.message = message;
			}

			// Token: 0x060000BF RID: 191 RVA: 0x000072CD File Offset: 0x000054CD
			public WhatsAppMessage(string message)
			{
				this.number = string.Empty;
				this.message = message;
			}

			// Token: 0x060000C0 RID: 192 RVA: 0x000072E8 File Offset: 0x000054E8
			public override string ToString()
			{
				string str = Regex.Replace(this.number, "^[0+]+|[ ()-]", string.Empty);
				return "https://wa.me/" + str + "?text=" + Uri.EscapeDataString(this.message);
			}

			// Token: 0x04000047 RID: 71
			private readonly string number;

			// Token: 0x04000048 RID: 72
			private readonly string message;
		}

		// Token: 0x0200002C RID: 44
		public class Bookmark : PayloadGenerator.Payload
		{
			// Token: 0x060000C1 RID: 193 RVA: 0x00007326 File Offset: 0x00005526
			public Bookmark(string url, string title)
			{
				this.url = PayloadGenerator.EscapeInput(url, false);
				this.title = PayloadGenerator.EscapeInput(title, false);
			}

			// Token: 0x060000C2 RID: 194 RVA: 0x00007348 File Offset: 0x00005548
			public override string ToString()
			{
				return string.Concat(new string[]
				{
					"MEBKM:TITLE:",
					this.title,
					";URL:",
					this.url,
					";;"
				});
			}

			// Token: 0x04000049 RID: 73
			private readonly string url;

			// Token: 0x0400004A RID: 74
			private readonly string title;
		}

		// Token: 0x0200002D RID: 45
		public class ContactData : PayloadGenerator.Payload
		{
			// Token: 0x060000C3 RID: 195 RVA: 0x00007380 File Offset: 0x00005580
			public ContactData(PayloadGenerator.ContactData.ContactOutputType outputType, string firstname, string lastname, string nickname = null, string phone = null, string mobilePhone = null, string workPhone = null, string email = null, DateTime? birthday = null, string website = null, string street = null, string houseNumber = null, string city = null, string zipCode = null, string country = null, string note = null, string stateRegion = null, PayloadGenerator.ContactData.AddressOrder addressOrder = PayloadGenerator.ContactData.AddressOrder.Default, string org = null, string orgTitle = null)
			{
				this.firstname = firstname;
				this.lastname = lastname;
				this.nickname = nickname;
				this.org = org;
				this.orgTitle = orgTitle;
				this.phone = phone;
				this.mobilePhone = mobilePhone;
				this.workPhone = workPhone;
				this.email = email;
				this.birthday = birthday;
				this.website = website;
				this.street = street;
				this.houseNumber = houseNumber;
				this.city = city;
				this.stateRegion = stateRegion;
				this.zipCode = zipCode;
				this.country = country;
				this.addressOrder = addressOrder;
				this.note = note;
				this.outputType = outputType;
			}

			// Token: 0x060000C4 RID: 196 RVA: 0x00007430 File Offset: 0x00005630
			public override string ToString()
			{
				string text = string.Empty;
				if (this.outputType == PayloadGenerator.ContactData.ContactOutputType.MeCard)
				{
					text += "MECARD+\r\n";
					if (!string.IsNullOrEmpty(this.firstname) && !string.IsNullOrEmpty(this.lastname))
					{
						text = string.Concat(new string[]
						{
							text,
							"N:",
							this.lastname,
							", ",
							this.firstname,
							"\r\n"
						});
					}
					else if (!string.IsNullOrEmpty(this.firstname) || !string.IsNullOrEmpty(this.lastname))
					{
						text = string.Concat(new string[]
						{
							text,
							"N:",
							this.firstname,
							this.lastname,
							"\r\n"
						});
					}
					if (!string.IsNullOrEmpty(this.org))
					{
						text = text + "ORG:" + this.org + "\r\n";
					}
					if (!string.IsNullOrEmpty(this.orgTitle))
					{
						text = text + "TITLE:" + this.orgTitle + "\r\n";
					}
					if (!string.IsNullOrEmpty(this.phone))
					{
						text = text + "TEL:" + this.phone + "\r\n";
					}
					if (!string.IsNullOrEmpty(this.mobilePhone))
					{
						text = text + "TEL:" + this.mobilePhone + "\r\n";
					}
					if (!string.IsNullOrEmpty(this.workPhone))
					{
						text = text + "TEL:" + this.workPhone + "\r\n";
					}
					if (!string.IsNullOrEmpty(this.email))
					{
						text = text + "EMAIL:" + this.email + "\r\n";
					}
					if (!string.IsNullOrEmpty(this.note))
					{
						text = text + "NOTE:" + this.note + "\r\n";
					}
					if (this.birthday != null)
					{
						text = text + "BDAY:" + this.birthday.Value.ToString("yyyyMMdd") + "\r\n";
					}
					string str = string.Empty;
					if (this.addressOrder == PayloadGenerator.ContactData.AddressOrder.Default)
					{
						str = string.Concat(new string[]
						{
							"ADR:,,",
							(!string.IsNullOrEmpty(this.street)) ? (this.street + " ") : "",
							(!string.IsNullOrEmpty(this.houseNumber)) ? this.houseNumber : "",
							",",
							(!string.IsNullOrEmpty(this.zipCode)) ? this.zipCode : "",
							",",
							(!string.IsNullOrEmpty(this.city)) ? this.city : "",
							",",
							(!string.IsNullOrEmpty(this.stateRegion)) ? this.stateRegion : "",
							",",
							(!string.IsNullOrEmpty(this.country)) ? this.country : "",
							"\r\n"
						});
					}
					else
					{
						str = string.Concat(new string[]
						{
							"ADR:,,",
							(!string.IsNullOrEmpty(this.houseNumber)) ? (this.houseNumber + " ") : "",
							(!string.IsNullOrEmpty(this.street)) ? this.street : "",
							",",
							(!string.IsNullOrEmpty(this.city)) ? this.city : "",
							",",
							(!string.IsNullOrEmpty(this.stateRegion)) ? this.stateRegion : "",
							",",
							(!string.IsNullOrEmpty(this.zipCode)) ? this.zipCode : "",
							",",
							(!string.IsNullOrEmpty(this.country)) ? this.country : "",
							"\r\n"
						});
					}
					text += str;
					if (!string.IsNullOrEmpty(this.website))
					{
						text = text + "URL:" + this.website + "\r\n";
					}
					if (!string.IsNullOrEmpty(this.nickname))
					{
						text = text + "NICKNAME:" + this.nickname + "\r\n";
					}
					text = text.Trim(new char[]
					{
						'\r',
						'\n'
					});
				}
				else
				{
					string text2 = this.outputType.ToString().Substring(5);
					if (text2.Length > 1)
					{
						text2 = text2.Insert(1, ".");
					}
					else
					{
						text2 += ".0";
					}
					text += "BEGIN:VCARD\r\n";
					text = text + "VERSION:" + text2 + "\r\n";
					text = string.Concat(new string[]
					{
						text,
						"N:",
						(!string.IsNullOrEmpty(this.lastname)) ? this.lastname : "",
						";",
						(!string.IsNullOrEmpty(this.firstname)) ? this.firstname : "",
						";;;\r\n"
					});
					text = string.Concat(new string[]
					{
						text,
						"FN:",
						(!string.IsNullOrEmpty(this.firstname)) ? (this.firstname + " ") : "",
						(!string.IsNullOrEmpty(this.lastname)) ? this.lastname : "",
						"\r\n"
					});
					if (!string.IsNullOrEmpty(this.org))
					{
						text = text + "ORG:" + this.org + "\r\n";
					}
					if (!string.IsNullOrEmpty(this.orgTitle))
					{
						text = text + "TITLE:" + this.orgTitle + "\r\n";
					}
					if (!string.IsNullOrEmpty(this.phone))
					{
						text += "TEL;";
						if (this.outputType == PayloadGenerator.ContactData.ContactOutputType.VCard21)
						{
							text = text + "HOME;VOICE:" + this.phone;
						}
						else if (this.outputType == PayloadGenerator.ContactData.ContactOutputType.VCard3)
						{
							text = text + "TYPE=HOME,VOICE:" + this.phone;
						}
						else
						{
							text = text + "TYPE=home,voice;VALUE=uri:tel:" + this.phone;
						}
						text += "\r\n";
					}
					if (!string.IsNullOrEmpty(this.mobilePhone))
					{
						text += "TEL;";
						if (this.outputType == PayloadGenerator.ContactData.ContactOutputType.VCard21)
						{
							text = text + "HOME;CELL:" + this.mobilePhone;
						}
						else if (this.outputType == PayloadGenerator.ContactData.ContactOutputType.VCard3)
						{
							text = text + "TYPE=HOME,CELL:" + this.mobilePhone;
						}
						else
						{
							text = text + "TYPE=home,cell;VALUE=uri:tel:" + this.mobilePhone;
						}
						text += "\r\n";
					}
					if (!string.IsNullOrEmpty(this.workPhone))
					{
						text += "TEL;";
						if (this.outputType == PayloadGenerator.ContactData.ContactOutputType.VCard21)
						{
							text = text + "WORK;VOICE:" + this.workPhone;
						}
						else if (this.outputType == PayloadGenerator.ContactData.ContactOutputType.VCard3)
						{
							text = text + "TYPE=WORK,VOICE:" + this.workPhone;
						}
						else
						{
							text = text + "TYPE=work,voice;VALUE=uri:tel:" + this.workPhone;
						}
						text += "\r\n";
					}
					text += "ADR;";
					if (this.outputType == PayloadGenerator.ContactData.ContactOutputType.VCard21)
					{
						text += "HOME;PREF:";
					}
					else if (this.outputType == PayloadGenerator.ContactData.ContactOutputType.VCard3)
					{
						text += "TYPE=HOME,PREF:";
					}
					else
					{
						text += "TYPE=home,pref:";
					}
					string str2 = string.Empty;
					if (this.addressOrder == PayloadGenerator.ContactData.AddressOrder.Default)
					{
						str2 = string.Concat(new string[]
						{
							";;",
							(!string.IsNullOrEmpty(this.street)) ? (this.street + " ") : "",
							(!string.IsNullOrEmpty(this.houseNumber)) ? this.houseNumber : "",
							";",
							(!string.IsNullOrEmpty(this.zipCode)) ? this.zipCode : "",
							";",
							(!string.IsNullOrEmpty(this.city)) ? this.city : "",
							";",
							(!string.IsNullOrEmpty(this.stateRegion)) ? this.stateRegion : "",
							";",
							(!string.IsNullOrEmpty(this.country)) ? this.country : "",
							"\r\n"
						});
					}
					else
					{
						str2 = string.Concat(new string[]
						{
							";;",
							(!string.IsNullOrEmpty(this.houseNumber)) ? (this.houseNumber + " ") : "",
							(!string.IsNullOrEmpty(this.street)) ? this.street : "",
							";",
							(!string.IsNullOrEmpty(this.city)) ? this.city : "",
							";",
							(!string.IsNullOrEmpty(this.stateRegion)) ? this.stateRegion : "",
							";",
							(!string.IsNullOrEmpty(this.zipCode)) ? this.zipCode : "",
							";",
							(!string.IsNullOrEmpty(this.country)) ? this.country : "",
							"\r\n"
						});
					}
					text += str2;
					if (this.birthday != null)
					{
						text = text + "BDAY:" + this.birthday.Value.ToString("yyyyMMdd") + "\r\n";
					}
					if (!string.IsNullOrEmpty(this.website))
					{
						text = text + "URL:" + this.website + "\r\n";
					}
					if (!string.IsNullOrEmpty(this.email))
					{
						text = text + "EMAIL:" + this.email + "\r\n";
					}
					if (!string.IsNullOrEmpty(this.note))
					{
						text = text + "NOTE:" + this.note + "\r\n";
					}
					if (this.outputType != PayloadGenerator.ContactData.ContactOutputType.VCard21 && !string.IsNullOrEmpty(this.nickname))
					{
						text = text + "NICKNAME:" + this.nickname + "\r\n";
					}
					text += "END:VCARD";
				}
				return text;
			}

			// Token: 0x0400004B RID: 75
			private readonly string firstname;

			// Token: 0x0400004C RID: 76
			private readonly string lastname;

			// Token: 0x0400004D RID: 77
			private readonly string nickname;

			// Token: 0x0400004E RID: 78
			private readonly string org;

			// Token: 0x0400004F RID: 79
			private readonly string orgTitle;

			// Token: 0x04000050 RID: 80
			private readonly string phone;

			// Token: 0x04000051 RID: 81
			private readonly string mobilePhone;

			// Token: 0x04000052 RID: 82
			private readonly string workPhone;

			// Token: 0x04000053 RID: 83
			private readonly string email;

			// Token: 0x04000054 RID: 84
			private readonly DateTime? birthday;

			// Token: 0x04000055 RID: 85
			private readonly string website;

			// Token: 0x04000056 RID: 86
			private readonly string street;

			// Token: 0x04000057 RID: 87
			private readonly string houseNumber;

			// Token: 0x04000058 RID: 88
			private readonly string city;

			// Token: 0x04000059 RID: 89
			private readonly string zipCode;

			// Token: 0x0400005A RID: 90
			private readonly string stateRegion;

			// Token: 0x0400005B RID: 91
			private readonly string country;

			// Token: 0x0400005C RID: 92
			private readonly string note;

			// Token: 0x0400005D RID: 93
			private readonly PayloadGenerator.ContactData.ContactOutputType outputType;

			// Token: 0x0400005E RID: 94
			private readonly PayloadGenerator.ContactData.AddressOrder addressOrder;

			// Token: 0x02000067 RID: 103
			public enum ContactOutputType
			{
				// Token: 0x04000133 RID: 307
				MeCard,
				// Token: 0x04000134 RID: 308
				VCard21,
				// Token: 0x04000135 RID: 309
				VCard3,
				// Token: 0x04000136 RID: 310
				VCard4
			}

			// Token: 0x02000068 RID: 104
			public enum AddressOrder
			{
				// Token: 0x04000138 RID: 312
				Default,
				// Token: 0x04000139 RID: 313
				Reversed
			}
		}

		// Token: 0x0200002E RID: 46
		public class BitcoinLikeCryptoCurrencyAddress : PayloadGenerator.Payload
		{
			// Token: 0x060000C5 RID: 197 RVA: 0x00007E90 File Offset: 0x00006090
			public BitcoinLikeCryptoCurrencyAddress(PayloadGenerator.BitcoinLikeCryptoCurrencyAddress.BitcoinLikeCryptoCurrencyType currencyType, string address, double? amount, string label = null, string message = null)
			{
				this.currencyType = currencyType;
				this.address = address;
				if (!string.IsNullOrEmpty(label))
				{
					this.label = Uri.EscapeDataString(label);
				}
				if (!string.IsNullOrEmpty(message))
				{
					this.message = Uri.EscapeDataString(message);
				}
				this.amount = amount;
			}

			// Token: 0x060000C6 RID: 198 RVA: 0x00007EE4 File Offset: 0x000060E4
			public override string ToString()
			{
				string str = null;
				KeyValuePair<string, string>[] source = new KeyValuePair<string, string>[]
				{
					new KeyValuePair<string, string>("label", this.label),
					new KeyValuePair<string, string>("message", this.message),
					new KeyValuePair<string, string>("amount", (this.amount != null) ? this.amount.Value.ToString("#.########", CultureInfo.InvariantCulture) : null)
				};
				if (source.Any((KeyValuePair<string, string> keyPair) => !string.IsNullOrEmpty(keyPair.Value)))
				{
					str = "?" + string.Join("&", (from keyPair in source
					where !string.IsNullOrEmpty(keyPair.Value)
					select keyPair.Key + "=" + keyPair.Value).ToArray<string>());
				}
				return Enum.GetName(typeof(PayloadGenerator.BitcoinLikeCryptoCurrencyAddress.BitcoinLikeCryptoCurrencyType), this.currencyType).ToLower() + ":" + this.address + str;
			}

			// Token: 0x0400005F RID: 95
			private readonly PayloadGenerator.BitcoinLikeCryptoCurrencyAddress.BitcoinLikeCryptoCurrencyType currencyType;

			// Token: 0x04000060 RID: 96
			private readonly string address;

			// Token: 0x04000061 RID: 97
			private readonly string label;

			// Token: 0x04000062 RID: 98
			private readonly string message;

			// Token: 0x04000063 RID: 99
			private readonly double? amount;

			// Token: 0x02000069 RID: 105
			public enum BitcoinLikeCryptoCurrencyType
			{
				// Token: 0x0400013B RID: 315
				Bitcoin,
				// Token: 0x0400013C RID: 316
				BitcoinCash,
				// Token: 0x0400013D RID: 317
				Litecoin
			}
		}

		// Token: 0x0200002F RID: 47
		public class BitcoinAddress : PayloadGenerator.BitcoinLikeCryptoCurrencyAddress
		{
			// Token: 0x060000C7 RID: 199 RVA: 0x00008020 File Offset: 0x00006220
			public BitcoinAddress(string address, double? amount, string label = null, string message = null) : base(PayloadGenerator.BitcoinLikeCryptoCurrencyAddress.BitcoinLikeCryptoCurrencyType.Bitcoin, address, amount, label, message)
			{
			}
		}

		// Token: 0x02000030 RID: 48
		public class BitcoinCashAddress : PayloadGenerator.BitcoinLikeCryptoCurrencyAddress
		{
			// Token: 0x060000C8 RID: 200 RVA: 0x0000802E File Offset: 0x0000622E
			public BitcoinCashAddress(string address, double? amount, string label = null, string message = null) : base(PayloadGenerator.BitcoinLikeCryptoCurrencyAddress.BitcoinLikeCryptoCurrencyType.BitcoinCash, address, amount, label, message)
			{
			}
		}

		// Token: 0x02000031 RID: 49
		public class LitecoinAddress : PayloadGenerator.BitcoinLikeCryptoCurrencyAddress
		{
			// Token: 0x060000C9 RID: 201 RVA: 0x0000803C File Offset: 0x0000623C
			public LitecoinAddress(string address, double? amount, string label = null, string message = null) : base(PayloadGenerator.BitcoinLikeCryptoCurrencyAddress.BitcoinLikeCryptoCurrencyType.Litecoin, address, amount, label, message)
			{
			}
		}

		// Token: 0x02000032 RID: 50
		public class SwissQrCode : PayloadGenerator.Payload
		{
			// Token: 0x060000CA RID: 202 RVA: 0x0000804C File Offset: 0x0000624C
			public SwissQrCode(PayloadGenerator.SwissQrCode.Iban iban, PayloadGenerator.SwissQrCode.Currency currency, PayloadGenerator.SwissQrCode.Contact creditor, PayloadGenerator.SwissQrCode.Reference reference, PayloadGenerator.SwissQrCode.AdditionalInformation additionalInformation = null, PayloadGenerator.SwissQrCode.Contact debitor = null, decimal? amount = null, DateTime? requestedDateOfPayment = null, PayloadGenerator.SwissQrCode.Contact ultimateCreditor = null, string alternativeProcedure1 = null, string alternativeProcedure2 = null)
			{
				this.iban = iban;
				this.creditor = creditor;
				this.ultimateCreditor = ultimateCreditor;
				this.additionalInformation = ((additionalInformation != null) ? additionalInformation : new PayloadGenerator.SwissQrCode.AdditionalInformation(null, null));
				if (amount != null && amount.ToString().Length > 12)
				{
					throw new PayloadGenerator.SwissQrCode.SwissQrCodeException("Amount (including decimals) must be shorter than 13 places.");
				}
				this.amount = amount;
				this.currency = currency;
				this.requestedDateOfPayment = requestedDateOfPayment;
				this.debitor = debitor;
				if (iban.IsQrIban && reference.RefType != PayloadGenerator.SwissQrCode.Reference.ReferenceType.QRR)
				{
					throw new PayloadGenerator.SwissQrCode.SwissQrCodeException("If QR-IBAN is used, you have to choose \"QRR\" as reference type!");
				}
				if (!iban.IsQrIban && reference.RefType == PayloadGenerator.SwissQrCode.Reference.ReferenceType.QRR)
				{
					throw new PayloadGenerator.SwissQrCode.SwissQrCodeException("If non QR-IBAN is used, you have to choose either \"SCOR\" or \"NON\" as reference type!");
				}
				this.reference = reference;
				if (alternativeProcedure1 != null && alternativeProcedure1.Length > 100)
				{
					throw new PayloadGenerator.SwissQrCode.SwissQrCodeException("Alternative procedure information block 1 must be shorter than 101 chars.");
				}
				this.alternativeProcedure1 = alternativeProcedure1;
				if (alternativeProcedure2 != null && alternativeProcedure2.Length > 100)
				{
					throw new PayloadGenerator.SwissQrCode.SwissQrCodeException("Alternative procedure information block 2 must be shorter than 101 chars.");
				}
				this.alternativeProcedure2 = alternativeProcedure2;
			}

			// Token: 0x060000CB RID: 203 RVA: 0x00008164 File Offset: 0x00006364
			public override string ToString()
			{
				string text = "SPC" + this.br;
				text = text + "0200" + this.br;
				text = text + "1" + this.br;
				text = text + this.iban.ToString() + this.br;
				text += this.creditor.ToString();
				text += string.Concat(Enumerable.Repeat<string>(this.br, 7).ToArray<string>());
				text = text + ((this.amount != null) ? string.Format("{0:0.00}", this.amount).Replace(",", ".") : string.Empty) + this.br;
				text = text + this.currency.ToString() + this.br;
				if (this.debitor != null)
				{
					text += this.debitor.ToString();
				}
				else
				{
					text += string.Concat(Enumerable.Repeat<string>(this.br, 7).ToArray<string>());
				}
				text = text + this.reference.RefType.ToString() + this.br;
				text = text + ((!string.IsNullOrEmpty(this.reference.ReferenceText)) ? this.reference.ReferenceText : string.Empty) + this.br;
				text = text + ((!string.IsNullOrEmpty(this.additionalInformation.UnstructureMessage)) ? this.additionalInformation.UnstructureMessage : string.Empty) + this.br;
				text = text + this.additionalInformation.Trailer + this.br;
				text = text + ((!string.IsNullOrEmpty(this.additionalInformation.BillInformation)) ? this.additionalInformation.BillInformation : string.Empty) + this.br;
				if (!string.IsNullOrEmpty(this.alternativeProcedure1))
				{
					text = text + this.alternativeProcedure1.Replace("\n", "") + this.br;
				}
				if (!string.IsNullOrEmpty(this.alternativeProcedure2))
				{
					text = text + this.alternativeProcedure2.Replace("\n", "") + this.br;
				}
				if (text.EndsWith(this.br))
				{
					text = text.Remove(text.Length - this.br.Length);
				}
				return text;
			}

			// Token: 0x04000064 RID: 100
			private readonly string br = "\r\n";

			// Token: 0x04000065 RID: 101
			private readonly string alternativeProcedure1;

			// Token: 0x04000066 RID: 102
			private readonly string alternativeProcedure2;

			// Token: 0x04000067 RID: 103
			private readonly PayloadGenerator.SwissQrCode.Iban iban;

			// Token: 0x04000068 RID: 104
			private readonly decimal? amount;

			// Token: 0x04000069 RID: 105
			private readonly PayloadGenerator.SwissQrCode.Contact creditor;

			// Token: 0x0400006A RID: 106
			private readonly PayloadGenerator.SwissQrCode.Contact ultimateCreditor;

			// Token: 0x0400006B RID: 107
			private readonly PayloadGenerator.SwissQrCode.Contact debitor;

			// Token: 0x0400006C RID: 108
			private readonly PayloadGenerator.SwissQrCode.Currency currency;

			// Token: 0x0400006D RID: 109
			private readonly DateTime? requestedDateOfPayment;

			// Token: 0x0400006E RID: 110
			private readonly PayloadGenerator.SwissQrCode.Reference reference;

			// Token: 0x0400006F RID: 111
			private readonly PayloadGenerator.SwissQrCode.AdditionalInformation additionalInformation;

			// Token: 0x0200006B RID: 107
			public class AdditionalInformation
			{
				// Token: 0x06000183 RID: 387 RVA: 0x0000C1B0 File Offset: 0x0000A3B0
				public AdditionalInformation(string unstructuredMessage = null, string billInformation = null)
				{
					if (((unstructuredMessage != null) ? unstructuredMessage.Length : 0) + ((billInformation != null) ? billInformation.Length : 0) > 140)
					{
						throw new PayloadGenerator.SwissQrCode.AdditionalInformation.SwissQrCodeAdditionalInformationException("Unstructured message and bill information must be shorter than 141 chars in total/combined.");
					}
					this.unstructuredMessage = unstructuredMessage;
					this.billInformation = billInformation;
					this.trailer = "EPD";
				}

				// Token: 0x17000034 RID: 52
				// (get) Token: 0x06000184 RID: 388 RVA: 0x0000C207 File Offset: 0x0000A407
				public string UnstructureMessage
				{
					get
					{
						if (string.IsNullOrEmpty(this.unstructuredMessage))
						{
							return null;
						}
						return this.unstructuredMessage.Replace("\n", "");
					}
				}

				// Token: 0x17000035 RID: 53
				// (get) Token: 0x06000185 RID: 389 RVA: 0x0000C22D File Offset: 0x0000A42D
				public string BillInformation
				{
					get
					{
						if (string.IsNullOrEmpty(this.billInformation))
						{
							return null;
						}
						return this.billInformation.Replace("\n", "");
					}
				}

				// Token: 0x17000036 RID: 54
				// (get) Token: 0x06000186 RID: 390 RVA: 0x0000C253 File Offset: 0x0000A453
				public string Trailer
				{
					get
					{
						return this.trailer;
					}
				}

				// Token: 0x04000142 RID: 322
				private readonly string unstructuredMessage;

				// Token: 0x04000143 RID: 323
				private readonly string billInformation;

				// Token: 0x04000144 RID: 324
				private readonly string trailer;

				// Token: 0x02000088 RID: 136
				public class SwissQrCodeAdditionalInformationException : Exception
				{
					// Token: 0x0600020E RID: 526 RVA: 0x0000DF38 File Offset: 0x0000C138
					public SwissQrCodeAdditionalInformationException()
					{
					}

					// Token: 0x0600020F RID: 527 RVA: 0x0000DF40 File Offset: 0x0000C140
					public SwissQrCodeAdditionalInformationException(string message) : base(message)
					{
					}

					// Token: 0x06000210 RID: 528 RVA: 0x0000DF49 File Offset: 0x0000C149
					public SwissQrCodeAdditionalInformationException(string message, Exception inner) : base(message, inner)
					{
					}
				}
			}

			// Token: 0x0200006C RID: 108
			public class Reference
			{
				// Token: 0x06000187 RID: 391 RVA: 0x0000C25C File Offset: 0x0000A45C
				public Reference(PayloadGenerator.SwissQrCode.Reference.ReferenceType referenceType, string reference = null, PayloadGenerator.SwissQrCode.Reference.ReferenceTextType? referenceTextType = null)
				{
					this.referenceType = referenceType;
					this.referenceTextType = referenceTextType;
					if (referenceType == PayloadGenerator.SwissQrCode.Reference.ReferenceType.NON && reference != null)
					{
						throw new PayloadGenerator.SwissQrCode.Reference.SwissQrCodeReferenceException("Reference is only allowed when referenceType not equals \"NON\"");
					}
					if (referenceType != PayloadGenerator.SwissQrCode.Reference.ReferenceType.NON && reference != null && referenceTextType == null)
					{
						throw new PayloadGenerator.SwissQrCode.Reference.SwissQrCodeReferenceException("You have to set an ReferenceTextType when using the reference text.");
					}
					PayloadGenerator.SwissQrCode.Reference.ReferenceTextType? referenceTextType2 = referenceTextType;
					PayloadGenerator.SwissQrCode.Reference.ReferenceTextType referenceTextType3 = PayloadGenerator.SwissQrCode.Reference.ReferenceTextType.QrReference;
					if ((referenceTextType2.GetValueOrDefault() == referenceTextType3 & referenceTextType2 != null) && reference != null && reference.Length > 27)
					{
						throw new PayloadGenerator.SwissQrCode.Reference.SwissQrCodeReferenceException("QR-references have to be shorter than 28 chars.");
					}
					referenceTextType2 = referenceTextType;
					referenceTextType3 = PayloadGenerator.SwissQrCode.Reference.ReferenceTextType.QrReference;
					if ((referenceTextType2.GetValueOrDefault() == referenceTextType3 & referenceTextType2 != null) && reference != null && !Regex.IsMatch(reference, "^[0-9]+$"))
					{
						throw new PayloadGenerator.SwissQrCode.Reference.SwissQrCodeReferenceException("QR-reference must exist out of digits only.");
					}
					referenceTextType2 = referenceTextType;
					referenceTextType3 = PayloadGenerator.SwissQrCode.Reference.ReferenceTextType.QrReference;
					if ((referenceTextType2.GetValueOrDefault() == referenceTextType3 & referenceTextType2 != null) && reference != null && !PayloadGenerator.ChecksumMod10(reference))
					{
						throw new PayloadGenerator.SwissQrCode.Reference.SwissQrCodeReferenceException("QR-references is invalid. Checksum error.");
					}
					referenceTextType2 = referenceTextType;
					referenceTextType3 = PayloadGenerator.SwissQrCode.Reference.ReferenceTextType.CreditorReferenceIso11649;
					if ((referenceTextType2.GetValueOrDefault() == referenceTextType3 & referenceTextType2 != null) && reference != null && reference.Length > 25)
					{
						throw new PayloadGenerator.SwissQrCode.Reference.SwissQrCodeReferenceException("Creditor references (ISO 11649) have to be shorter than 26 chars.");
					}
					this.reference = reference;
				}

				// Token: 0x17000037 RID: 55
				// (get) Token: 0x06000188 RID: 392 RVA: 0x0000C372 File Offset: 0x0000A572
				public PayloadGenerator.SwissQrCode.Reference.ReferenceType RefType
				{
					get
					{
						return this.referenceType;
					}
				}

				// Token: 0x17000038 RID: 56
				// (get) Token: 0x06000189 RID: 393 RVA: 0x0000C37A File Offset: 0x0000A57A
				public string ReferenceText
				{
					get
					{
						if (string.IsNullOrEmpty(this.reference))
						{
							return null;
						}
						return this.reference.Replace("\n", "");
					}
				}

				// Token: 0x04000145 RID: 325
				private readonly PayloadGenerator.SwissQrCode.Reference.ReferenceType referenceType;

				// Token: 0x04000146 RID: 326
				private readonly string reference;

				// Token: 0x04000147 RID: 327
				private readonly PayloadGenerator.SwissQrCode.Reference.ReferenceTextType? referenceTextType;

				// Token: 0x02000089 RID: 137
				public enum ReferenceType
				{
					// Token: 0x040002A3 RID: 675
					QRR,
					// Token: 0x040002A4 RID: 676
					SCOR,
					// Token: 0x040002A5 RID: 677
					NON
				}

				// Token: 0x0200008A RID: 138
				public enum ReferenceTextType
				{
					// Token: 0x040002A7 RID: 679
					QrReference,
					// Token: 0x040002A8 RID: 680
					CreditorReferenceIso11649
				}

				// Token: 0x0200008B RID: 139
				public class SwissQrCodeReferenceException : Exception
				{
					// Token: 0x06000211 RID: 529 RVA: 0x0000DF53 File Offset: 0x0000C153
					public SwissQrCodeReferenceException()
					{
					}

					// Token: 0x06000212 RID: 530 RVA: 0x0000DF5B File Offset: 0x0000C15B
					public SwissQrCodeReferenceException(string message) : base(message)
					{
					}

					// Token: 0x06000213 RID: 531 RVA: 0x0000DF64 File Offset: 0x0000C164
					public SwissQrCodeReferenceException(string message, Exception inner) : base(message, inner)
					{
					}
				}
			}

			// Token: 0x0200006D RID: 109
			public class Iban
			{
				// Token: 0x0600018A RID: 394 RVA: 0x0000C3A0 File Offset: 0x0000A5A0
				public Iban(string iban, PayloadGenerator.SwissQrCode.Iban.IbanType ibanType)
				{
					if (ibanType == PayloadGenerator.SwissQrCode.Iban.IbanType.Iban && !PayloadGenerator.IsValidIban(iban))
					{
						throw new PayloadGenerator.SwissQrCode.Iban.SwissQrCodeIbanException("The IBAN entered isn't valid.");
					}
					if (ibanType == PayloadGenerator.SwissQrCode.Iban.IbanType.QrIban && !PayloadGenerator.IsValidQRIban(iban))
					{
						throw new PayloadGenerator.SwissQrCode.Iban.SwissQrCodeIbanException("The QR-IBAN entered isn't valid.");
					}
					if (!iban.StartsWith("CH") && !iban.StartsWith("LI"))
					{
						throw new PayloadGenerator.SwissQrCode.Iban.SwissQrCodeIbanException("The IBAN must start with \"CH\" or \"LI\".");
					}
					this.iban = iban;
					this.ibanType = ibanType;
				}

				// Token: 0x17000039 RID: 57
				// (get) Token: 0x0600018B RID: 395 RVA: 0x0000C413 File Offset: 0x0000A613
				public bool IsQrIban
				{
					get
					{
						return this.ibanType == PayloadGenerator.SwissQrCode.Iban.IbanType.QrIban;
					}
				}

				// Token: 0x0600018C RID: 396 RVA: 0x0000C41E File Offset: 0x0000A61E
				public override string ToString()
				{
					return this.iban.Replace("-", "").Replace("\n", "").Replace(" ", "");
				}

				// Token: 0x04000148 RID: 328
				private string iban;

				// Token: 0x04000149 RID: 329
				private PayloadGenerator.SwissQrCode.Iban.IbanType ibanType;

				// Token: 0x0200008C RID: 140
				public enum IbanType
				{
					// Token: 0x040002AA RID: 682
					Iban,
					// Token: 0x040002AB RID: 683
					QrIban
				}

				// Token: 0x0200008D RID: 141
				public class SwissQrCodeIbanException : Exception
				{
					// Token: 0x06000214 RID: 532 RVA: 0x0000DF6E File Offset: 0x0000C16E
					public SwissQrCodeIbanException()
					{
					}

					// Token: 0x06000215 RID: 533 RVA: 0x0000DF76 File Offset: 0x0000C176
					public SwissQrCodeIbanException(string message) : base(message)
					{
					}

					// Token: 0x06000216 RID: 534 RVA: 0x0000DF7F File Offset: 0x0000C17F
					public SwissQrCodeIbanException(string message, Exception inner) : base(message, inner)
					{
					}
				}
			}

			// Token: 0x0200006E RID: 110
			public class Contact
			{
				// Token: 0x0600018D RID: 397 RVA: 0x0000C453 File Offset: 0x0000A653
				[Obsolete("This constructor is deprecated. Use WithStructuredAddress instead.")]
				public Contact(string name, string zipCode, string city, string country, string street = null, string houseNumber = null) : this(name, zipCode, city, country, street, houseNumber, PayloadGenerator.SwissQrCode.Contact.AddressType.StructuredAddress)
				{
				}

				// Token: 0x0600018E RID: 398 RVA: 0x0000C465 File Offset: 0x0000A665
				[Obsolete("This constructor is deprecated. Use WithCombinedAddress instead.")]
				public Contact(string name, string country, string addressLine1, string addressLine2) : this(name, null, null, country, addressLine1, addressLine2, PayloadGenerator.SwissQrCode.Contact.AddressType.CombinedAddress)
				{
				}

				// Token: 0x0600018F RID: 399 RVA: 0x0000C475 File Offset: 0x0000A675
				public static PayloadGenerator.SwissQrCode.Contact WithStructuredAddress(string name, string zipCode, string city, string country, string street = null, string houseNumber = null)
				{
					return new PayloadGenerator.SwissQrCode.Contact(name, zipCode, city, country, street, houseNumber, PayloadGenerator.SwissQrCode.Contact.AddressType.StructuredAddress);
				}

				// Token: 0x06000190 RID: 400 RVA: 0x0000C485 File Offset: 0x0000A685
				public static PayloadGenerator.SwissQrCode.Contact WithCombinedAddress(string name, string country, string addressLine1, string addressLine2)
				{
					return new PayloadGenerator.SwissQrCode.Contact(name, null, null, country, addressLine1, addressLine2, PayloadGenerator.SwissQrCode.Contact.AddressType.CombinedAddress);
				}

				// Token: 0x06000191 RID: 401 RVA: 0x0000C494 File Offset: 0x0000A694
				private Contact(string name, string zipCode, string city, string country, string streetOrAddressline1, string houseNumberOrAddressline2, PayloadGenerator.SwissQrCode.Contact.AddressType addressType)
				{
					string text = "^([a-zA-Z0-9\\.,;:'\\ \\+\\-/\\(\\)?\\*\\[\\]\\{\\}\\\\`´~ ]|[!\"#%&<>÷=@_$£]|[àáâäçèéêëìíîïñòóôöùúûüýßÀÁÂÄÇÈÉÊËÌÍÎÏÒÓÔÖÙÚÛÜÑ])*$";
					this.adrType = addressType;
					if (string.IsNullOrEmpty(name))
					{
						throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("Name must not be empty.");
					}
					if (name.Length > 70)
					{
						throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("Name must be shorter than 71 chars.");
					}
					if (!Regex.IsMatch(name, text))
					{
						throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("Name must match the following pattern as defined in pain.001: " + text);
					}
					this.name = name;
					if (this.adrType == PayloadGenerator.SwissQrCode.Contact.AddressType.StructuredAddress)
					{
						if (!string.IsNullOrEmpty(streetOrAddressline1) && streetOrAddressline1.Length > 70)
						{
							throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("Street must be shorter than 71 chars.");
						}
						if (!string.IsNullOrEmpty(streetOrAddressline1) && !Regex.IsMatch(streetOrAddressline1, text))
						{
							throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("Street must match the following pattern as defined in pain.001: " + text);
						}
						this.streetOrAddressline1 = streetOrAddressline1;
						if (!string.IsNullOrEmpty(houseNumberOrAddressline2) && houseNumberOrAddressline2.Length > 16)
						{
							throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("House number must be shorter than 17 chars.");
						}
						this.houseNumberOrAddressline2 = houseNumberOrAddressline2;
					}
					else
					{
						if (!string.IsNullOrEmpty(streetOrAddressline1) && streetOrAddressline1.Length > 70)
						{
							throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("Address line 1 must be shorter than 71 chars.");
						}
						if (!string.IsNullOrEmpty(streetOrAddressline1) && !Regex.IsMatch(streetOrAddressline1, text))
						{
							throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("Address line 1 must match the following pattern as defined in pain.001: " + text);
						}
						this.streetOrAddressline1 = streetOrAddressline1;
						if (string.IsNullOrEmpty(houseNumberOrAddressline2))
						{
							throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("Address line 2 must be provided for combined addresses (address line-based addresses).");
						}
						if (!string.IsNullOrEmpty(houseNumberOrAddressline2) && houseNumberOrAddressline2.Length > 70)
						{
							throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("Address line 2 must be shorter than 71 chars.");
						}
						if (!string.IsNullOrEmpty(houseNumberOrAddressline2) && !Regex.IsMatch(houseNumberOrAddressline2, text))
						{
							throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("Address line 2 must match the following pattern as defined in pain.001: " + text);
						}
						this.houseNumberOrAddressline2 = houseNumberOrAddressline2;
					}
					if (this.adrType == PayloadGenerator.SwissQrCode.Contact.AddressType.StructuredAddress)
					{
						if (string.IsNullOrEmpty(zipCode))
						{
							throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("Zip code must not be empty.");
						}
						if (zipCode.Length > 16)
						{
							throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("Zip code must be shorter than 17 chars.");
						}
						if (!Regex.IsMatch(zipCode, text))
						{
							throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("Zip code must match the following pattern as defined in pain.001: " + text);
						}
						this.zipCode = zipCode;
						if (string.IsNullOrEmpty(city))
						{
							throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("City must not be empty.");
						}
						if (city.Length > 35)
						{
							throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("City name must be shorter than 36 chars.");
						}
						if (!Regex.IsMatch(city, text))
						{
							throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("City name must match the following pattern as defined in pain.001: " + text);
						}
						this.city = city;
					}
					else
					{
						this.zipCode = (this.city = string.Empty);
					}
					if (!PayloadGenerator.SwissQrCode.Contact.IsValidTwoLetterCode(country))
					{
						throw new PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException("Country must be a valid \"two letter\" country code as defined by  ISO 3166-1, but it isn't.");
					}
					this.country = country;
				}

				// Token: 0x06000192 RID: 402 RVA: 0x0000C701 File Offset: 0x0000A901
				private static bool IsValidTwoLetterCode(string code)
				{
					return PayloadGenerator.SwissQrCode.Contact.twoLetterCodes.Contains(code);
				}

				// Token: 0x06000193 RID: 403 RVA: 0x0000C710 File Offset: 0x0000A910
				private static HashSet<string> ValidTwoLetterCodes()
				{
					return new HashSet<string>(new string[]
					{
						"AF",
						"AL",
						"DZ",
						"AS",
						"AD",
						"AO",
						"AI",
						"AQ",
						"AG",
						"AR",
						"AM",
						"AW",
						"AU",
						"AT",
						"AZ",
						"BS",
						"BH",
						"BD",
						"BB",
						"BY",
						"BE",
						"BZ",
						"BJ",
						"BM",
						"BT",
						"BO",
						"BQ",
						"BA",
						"BW",
						"BV",
						"BR",
						"IO",
						"BN",
						"BG",
						"BF",
						"BI",
						"CV",
						"KH",
						"CM",
						"CA",
						"KY",
						"CF",
						"TD",
						"CL",
						"CN",
						"CX",
						"CC",
						"CO",
						"KM",
						"CG",
						"CD",
						"CK",
						"CR",
						"CI",
						"HR",
						"CU",
						"CW",
						"CY",
						"CZ",
						"DK",
						"DJ",
						"DM",
						"DO",
						"EC",
						"EG",
						"SV",
						"GQ",
						"ER",
						"EE",
						"SZ",
						"ET",
						"FK",
						"FO",
						"FJ",
						"FI",
						"FR",
						"GF",
						"PF",
						"TF",
						"GA",
						"GM",
						"GE",
						"DE",
						"GH",
						"GI",
						"GR",
						"GL",
						"GD",
						"GP",
						"GU",
						"GT",
						"GG",
						"GN",
						"GW",
						"GY",
						"HT",
						"HM",
						"VA",
						"HN",
						"HK",
						"HU",
						"IS",
						"IN",
						"ID",
						"IR",
						"IQ",
						"IE",
						"IM",
						"IL",
						"IT",
						"JM",
						"JP",
						"JE",
						"JO",
						"KZ",
						"KE",
						"KI",
						"KP",
						"KR",
						"KW",
						"KG",
						"LA",
						"LV",
						"LB",
						"LS",
						"LR",
						"LY",
						"LI",
						"LT",
						"LU",
						"MO",
						"MG",
						"MW",
						"MY",
						"MV",
						"ML",
						"MT",
						"MH",
						"MQ",
						"MR",
						"MU",
						"YT",
						"MX",
						"FM",
						"MD",
						"MC",
						"MN",
						"ME",
						"MS",
						"MA",
						"MZ",
						"MM",
						"NA",
						"NR",
						"NP",
						"NL",
						"NC",
						"NZ",
						"NI",
						"NE",
						"NG",
						"NU",
						"NF",
						"MP",
						"MK",
						"NO",
						"OM",
						"PK",
						"PW",
						"PS",
						"PA",
						"PG",
						"PY",
						"PE",
						"PH",
						"PN",
						"PL",
						"PT",
						"PR",
						"QA",
						"RE",
						"RO",
						"RU",
						"RW",
						"BL",
						"SH",
						"KN",
						"LC",
						"MF",
						"PM",
						"VC",
						"WS",
						"SM",
						"ST",
						"SA",
						"SN",
						"RS",
						"SC",
						"SL",
						"SG",
						"SX",
						"SK",
						"SI",
						"SB",
						"SO",
						"ZA",
						"GS",
						"SS",
						"ES",
						"LK",
						"SD",
						"SR",
						"SJ",
						"SE",
						"CH",
						"SY",
						"TW",
						"TJ",
						"TZ",
						"TH",
						"TL",
						"TG",
						"TK",
						"TO",
						"TT",
						"TN",
						"TR",
						"TM",
						"TC",
						"TV",
						"UG",
						"UA",
						"AE",
						"GB",
						"US",
						"UM",
						"UY",
						"UZ",
						"VU",
						"VE",
						"VN",
						"VG",
						"VI",
						"WF",
						"EH",
						"YE",
						"ZM",
						"ZW",
						"AX"
					}, StringComparer.OrdinalIgnoreCase);
				}

				// Token: 0x06000194 RID: 404 RVA: 0x0000D154 File Offset: 0x0000B354
				public override string ToString()
				{
					return ((this.adrType == PayloadGenerator.SwissQrCode.Contact.AddressType.StructuredAddress) ? "S" : "K") + this.br + this.name.Replace("\n", "") + this.br + ((!string.IsNullOrEmpty(this.streetOrAddressline1)) ? this.streetOrAddressline1.Replace("\n", "") : string.Empty) + this.br + ((!string.IsNullOrEmpty(this.houseNumberOrAddressline2)) ? this.houseNumberOrAddressline2.Replace("\n", "") : string.Empty) + this.br + this.zipCode.Replace("\n", "") + this.br + this.city.Replace("\n", "") + this.br + this.country + this.br;
				}

				// Token: 0x0400014A RID: 330
				private static readonly HashSet<string> twoLetterCodes = PayloadGenerator.SwissQrCode.Contact.ValidTwoLetterCodes();

				// Token: 0x0400014B RID: 331
				private string br = "\r\n";

				// Token: 0x0400014C RID: 332
				private string name;

				// Token: 0x0400014D RID: 333
				private string streetOrAddressline1;

				// Token: 0x0400014E RID: 334
				private string houseNumberOrAddressline2;

				// Token: 0x0400014F RID: 335
				private string zipCode;

				// Token: 0x04000150 RID: 336
				private string city;

				// Token: 0x04000151 RID: 337
				private string country;

				// Token: 0x04000152 RID: 338
				private PayloadGenerator.SwissQrCode.Contact.AddressType adrType;

				// Token: 0x0200008E RID: 142
				public enum AddressType
				{
					// Token: 0x040002AD RID: 685
					StructuredAddress,
					// Token: 0x040002AE RID: 686
					CombinedAddress
				}

				// Token: 0x0200008F RID: 143
				public class SwissQrCodeContactException : Exception
				{
					// Token: 0x06000217 RID: 535 RVA: 0x0000DF89 File Offset: 0x0000C189
					public SwissQrCodeContactException()
					{
					}

					// Token: 0x06000218 RID: 536 RVA: 0x0000DF91 File Offset: 0x0000C191
					public SwissQrCodeContactException(string message) : base(message)
					{
					}

					// Token: 0x06000219 RID: 537 RVA: 0x0000DF9A File Offset: 0x0000C19A
					public SwissQrCodeContactException(string message, Exception inner) : base(message, inner)
					{
					}
				}
			}

			// Token: 0x0200006F RID: 111
			public enum Currency
			{
				// Token: 0x04000154 RID: 340
				CHF = 756,
				// Token: 0x04000155 RID: 341
				EUR = 978
			}

			// Token: 0x02000070 RID: 112
			public class SwissQrCodeException : Exception
			{
				// Token: 0x06000196 RID: 406 RVA: 0x0000D265 File Offset: 0x0000B465
				public SwissQrCodeException()
				{
				}

				// Token: 0x06000197 RID: 407 RVA: 0x0000D26D File Offset: 0x0000B46D
				public SwissQrCodeException(string message) : base(message)
				{
				}

				// Token: 0x06000198 RID: 408 RVA: 0x0000D276 File Offset: 0x0000B476
				public SwissQrCodeException(string message, Exception inner) : base(message, inner)
				{
				}
			}
		}

		// Token: 0x02000033 RID: 51
		public class Girocode : PayloadGenerator.Payload
		{
			// Token: 0x060000CC RID: 204 RVA: 0x000083E0 File Offset: 0x000065E0
			public Girocode(string iban, string bic, string name, decimal amount, string remittanceInformation = "", PayloadGenerator.Girocode.TypeOfRemittance typeOfRemittance = PayloadGenerator.Girocode.TypeOfRemittance.Unstructured, string purposeOfCreditTransfer = "", string messageToGirocodeUser = "", PayloadGenerator.Girocode.GirocodeVersion version = PayloadGenerator.Girocode.GirocodeVersion.Version1, PayloadGenerator.Girocode.GirocodeEncoding encoding = PayloadGenerator.Girocode.GirocodeEncoding.ISO_8859_1)
			{
				this.version = version;
				this.encoding = encoding;
				if (!PayloadGenerator.IsValidIban(iban))
				{
					throw new PayloadGenerator.Girocode.GirocodeException("The IBAN entered isn't valid.");
				}
				this.iban = iban.Replace(" ", "").ToUpper();
				if (!PayloadGenerator.IsValidBic(bic))
				{
					throw new PayloadGenerator.Girocode.GirocodeException("The BIC entered isn't valid.");
				}
				this.bic = bic.Replace(" ", "").ToUpper();
				if (name.Length > 70)
				{
					throw new PayloadGenerator.Girocode.GirocodeException("(Payee-)Name must be shorter than 71 chars.");
				}
				this.name = name;
				if (amount.ToString().Replace(",", ".").Contains(".") && amount.ToString().Replace(",", ".").Split(new char[]
				{
					'.'
				})[1].TrimEnd(new char[]
				{
					'0'
				}).Length > 2)
				{
					throw new PayloadGenerator.Girocode.GirocodeException("Amount must have less than 3 digits after decimal point.");
				}
				if (amount < 0.01m || amount > 999999999.99m)
				{
					throw new PayloadGenerator.Girocode.GirocodeException("Amount has to at least 0.01 and must be smaller or equal to 999999999.99.");
				}
				this.amount = amount;
				if (purposeOfCreditTransfer.Length > 4)
				{
					throw new PayloadGenerator.Girocode.GirocodeException("Purpose of credit transfer can only have 4 chars at maximum.");
				}
				this.purposeOfCreditTransfer = purposeOfCreditTransfer;
				if (typeOfRemittance == PayloadGenerator.Girocode.TypeOfRemittance.Unstructured && remittanceInformation.Length > 140)
				{
					throw new PayloadGenerator.Girocode.GirocodeException("Unstructured reference texts have to shorter than 141 chars.");
				}
				if (typeOfRemittance == PayloadGenerator.Girocode.TypeOfRemittance.Structured && remittanceInformation.Length > 35)
				{
					throw new PayloadGenerator.Girocode.GirocodeException("Structured reference texts have to shorter than 36 chars.");
				}
				this.typeOfRemittance = typeOfRemittance;
				this.remittanceInformation = remittanceInformation;
				if (messageToGirocodeUser.Length > 70)
				{
					throw new PayloadGenerator.Girocode.GirocodeException("Message to the Girocode-User reader texts have to shorter than 71 chars.");
				}
				this.messageToGirocodeUser = messageToGirocodeUser;
			}

			// Token: 0x060000CD RID: 205 RVA: 0x000085B4 File Offset: 0x000067B4
			public override string ToString()
			{
				return PayloadGenerator.ConvertStringToEncoding("BCD" + this.br + ((this.version == PayloadGenerator.Girocode.GirocodeVersion.Version1) ? "001" : "002") + this.br + ((int)(this.encoding + 1)).ToString() + this.br + "SCT" + this.br + this.bic + this.br + this.name + this.br + this.iban + this.br + string.Format("EUR{0:0.00}", this.amount).Replace(",", ".") + this.br + this.purposeOfCreditTransfer + this.br + ((this.typeOfRemittance == PayloadGenerator.Girocode.TypeOfRemittance.Structured) ? this.remittanceInformation : string.Empty) + this.br + ((this.typeOfRemittance == PayloadGenerator.Girocode.TypeOfRemittance.Unstructured) ? this.remittanceInformation : string.Empty) + this.br + this.messageToGirocodeUser, this.encoding.ToString().Replace("_", "-"));
			}

			// Token: 0x04000070 RID: 112
			private string br = "\n";

			// Token: 0x04000071 RID: 113
			private readonly string iban;

			// Token: 0x04000072 RID: 114
			private readonly string bic;

			// Token: 0x04000073 RID: 115
			private readonly string name;

			// Token: 0x04000074 RID: 116
			private readonly string purposeOfCreditTransfer;

			// Token: 0x04000075 RID: 117
			private readonly string remittanceInformation;

			// Token: 0x04000076 RID: 118
			private readonly string messageToGirocodeUser;

			// Token: 0x04000077 RID: 119
			private readonly decimal amount;

			// Token: 0x04000078 RID: 120
			private readonly PayloadGenerator.Girocode.GirocodeVersion version;

			// Token: 0x04000079 RID: 121
			private readonly PayloadGenerator.Girocode.GirocodeEncoding encoding;

			// Token: 0x0400007A RID: 122
			private readonly PayloadGenerator.Girocode.TypeOfRemittance typeOfRemittance;

			// Token: 0x02000071 RID: 113
			public enum GirocodeVersion
			{
				// Token: 0x04000157 RID: 343
				Version1,
				// Token: 0x04000158 RID: 344
				Version2
			}

			// Token: 0x02000072 RID: 114
			public enum TypeOfRemittance
			{
				// Token: 0x0400015A RID: 346
				Structured,
				// Token: 0x0400015B RID: 347
				Unstructured
			}

			// Token: 0x02000073 RID: 115
			public enum GirocodeEncoding
			{
				// Token: 0x0400015D RID: 349
				UTF_8,
				// Token: 0x0400015E RID: 350
				ISO_8859_1,
				// Token: 0x0400015F RID: 351
				ISO_8859_2,
				// Token: 0x04000160 RID: 352
				ISO_8859_4,
				// Token: 0x04000161 RID: 353
				ISO_8859_5,
				// Token: 0x04000162 RID: 354
				ISO_8859_7,
				// Token: 0x04000163 RID: 355
				ISO_8859_10,
				// Token: 0x04000164 RID: 356
				ISO_8859_15
			}

			// Token: 0x02000074 RID: 116
			public class GirocodeException : Exception
			{
				// Token: 0x06000199 RID: 409 RVA: 0x0000D280 File Offset: 0x0000B480
				public GirocodeException()
				{
				}

				// Token: 0x0600019A RID: 410 RVA: 0x0000D288 File Offset: 0x0000B488
				public GirocodeException(string message) : base(message)
				{
				}

				// Token: 0x0600019B RID: 411 RVA: 0x0000D291 File Offset: 0x0000B491
				public GirocodeException(string message, Exception inner) : base(message, inner)
				{
				}
			}
		}

		// Token: 0x02000034 RID: 52
		public class BezahlCode : PayloadGenerator.Payload
		{
			// Token: 0x060000CE RID: 206 RVA: 0x00008700 File Offset: 0x00006900
			public BezahlCode(PayloadGenerator.BezahlCode.AuthorityType authority, string name, string account = "", string bnc = "", string iban = "", string bic = "", string reason = "") : this(authority, name, account, bnc, iban, bic, 0m, string.Empty, 0, null, null, string.Empty, string.Empty, null, reason, 0, string.Empty, PayloadGenerator.BezahlCode.Currency.EUR, null, 1)
			{
			}

			// Token: 0x060000CF RID: 207 RVA: 0x00008764 File Offset: 0x00006964
			public BezahlCode(PayloadGenerator.BezahlCode.AuthorityType authority, string name, string account, string bnc, decimal amount, string periodicTimeunit = "", int periodicTimeunitRotation = 0, DateTime? periodicFirstExecutionDate = null, DateTime? periodicLastExecutionDate = null, string reason = "", int postingKey = 0, PayloadGenerator.BezahlCode.Currency currency = PayloadGenerator.BezahlCode.Currency.EUR, DateTime? executionDate = null) : this(authority, name, account, bnc, string.Empty, string.Empty, amount, periodicTimeunit, periodicTimeunitRotation, periodicFirstExecutionDate, periodicLastExecutionDate, string.Empty, string.Empty, null, reason, postingKey, string.Empty, currency, executionDate, 2)
			{
			}

			// Token: 0x060000D0 RID: 208 RVA: 0x000087B4 File Offset: 0x000069B4
			public BezahlCode(PayloadGenerator.BezahlCode.AuthorityType authority, string name, string iban, string bic, decimal amount, string periodicTimeunit = "", int periodicTimeunitRotation = 0, DateTime? periodicFirstExecutionDate = null, DateTime? periodicLastExecutionDate = null, string creditorId = "", string mandateId = "", DateTime? dateOfSignature = null, string reason = "", string sepaReference = "", PayloadGenerator.BezahlCode.Currency currency = PayloadGenerator.BezahlCode.Currency.EUR, DateTime? executionDate = null) : this(authority, name, string.Empty, string.Empty, iban, bic, amount, periodicTimeunit, periodicTimeunitRotation, periodicFirstExecutionDate, periodicLastExecutionDate, creditorId, mandateId, dateOfSignature, reason, 0, sepaReference, currency, executionDate, 3)
			{
			}

			// Token: 0x060000D1 RID: 209 RVA: 0x000087F0 File Offset: 0x000069F0
			public BezahlCode(PayloadGenerator.BezahlCode.AuthorityType authority, string name, string account, string bnc, string iban, string bic, decimal amount, string periodicTimeunit = "", int periodicTimeunitRotation = 0, DateTime? periodicFirstExecutionDate = null, DateTime? periodicLastExecutionDate = null, string creditorId = "", string mandateId = "", DateTime? dateOfSignature = null, string reason = "", int postingKey = 0, string sepaReference = "", PayloadGenerator.BezahlCode.Currency currency = PayloadGenerator.BezahlCode.Currency.EUR, DateTime? executionDate = null, int internalMode = 0)
			{
				if (internalMode == 1)
				{
					if (authority != PayloadGenerator.BezahlCode.AuthorityType.contact && authority != PayloadGenerator.BezahlCode.AuthorityType.contact_v2)
					{
						throw new PayloadGenerator.BezahlCode.BezahlCodeException("The constructor without an amount may only ne used with authority types 'contact' and 'contact_v2'.");
					}
					if (authority == PayloadGenerator.BezahlCode.AuthorityType.contact && (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(bnc)))
					{
						throw new PayloadGenerator.BezahlCode.BezahlCodeException("When using authority type 'contact' the parameters 'account' and 'bnc' must be set.");
					}
					if (authority != PayloadGenerator.BezahlCode.AuthorityType.contact_v2)
					{
						bool flag = !string.IsNullOrEmpty(account) && !string.IsNullOrEmpty(bnc);
						bool flag2 = !string.IsNullOrEmpty(iban) && !string.IsNullOrEmpty(bic);
						if ((!flag && !flag2) || (flag && flag2))
						{
							throw new PayloadGenerator.BezahlCode.BezahlCodeException("When using authority type 'contact_v2' either the parameters 'account' and 'bnc' or the parameters 'iban' and 'bic' must be set. Leave the other parameter pair empty.");
						}
					}
				}
				else if (internalMode == 2)
				{
					if (authority != PayloadGenerator.BezahlCode.AuthorityType.periodicsinglepayment && authority != PayloadGenerator.BezahlCode.AuthorityType.singledirectdebit && authority != PayloadGenerator.BezahlCode.AuthorityType.singlepayment)
					{
						throw new PayloadGenerator.BezahlCode.BezahlCodeException("The constructor with 'account' and 'bnc' may only be used with 'non SEPA' authority types. Either choose another authority type or switch constructor.");
					}
					if (authority == PayloadGenerator.BezahlCode.AuthorityType.periodicsinglepayment && (string.IsNullOrEmpty(periodicTimeunit) || periodicTimeunitRotation == 0))
					{
						throw new PayloadGenerator.BezahlCode.BezahlCodeException("When using 'periodicsinglepayment' as authority type, the parameters 'periodicTimeunit' and 'periodicTimeunitRotation' must be set.");
					}
				}
				else if (internalMode == 3)
				{
					if (authority != PayloadGenerator.BezahlCode.AuthorityType.periodicsinglepaymentsepa && authority != PayloadGenerator.BezahlCode.AuthorityType.singledirectdebitsepa && authority != PayloadGenerator.BezahlCode.AuthorityType.singlepaymentsepa)
					{
						throw new PayloadGenerator.BezahlCode.BezahlCodeException("The constructor with 'iban' and 'bic' may only be used with 'SEPA' authority types. Either choose another authority type or switch constructor.");
					}
					if (authority == PayloadGenerator.BezahlCode.AuthorityType.periodicsinglepaymentsepa && (string.IsNullOrEmpty(periodicTimeunit) || periodicTimeunitRotation == 0))
					{
						throw new PayloadGenerator.BezahlCode.BezahlCodeException("When using 'periodicsinglepaymentsepa' as authority type, the parameters 'periodicTimeunit' and 'periodicTimeunitRotation' must be set.");
					}
				}
				this.authority = authority;
				if (name.Length > 70)
				{
					throw new PayloadGenerator.BezahlCode.BezahlCodeException("(Payee-)Name must be shorter than 71 chars.");
				}
				this.name = name;
				if (reason.Length > 27)
				{
					throw new PayloadGenerator.BezahlCode.BezahlCodeException("Reasons texts have to be shorter than 28 chars.");
				}
				this.reason = reason;
				bool flag3 = !string.IsNullOrEmpty(account) && !string.IsNullOrEmpty(bnc);
				bool flag4 = !string.IsNullOrEmpty(iban) && !string.IsNullOrEmpty(bic);
				if (authority == PayloadGenerator.BezahlCode.AuthorityType.periodicsinglepayment || authority == PayloadGenerator.BezahlCode.AuthorityType.singledirectdebit || authority == PayloadGenerator.BezahlCode.AuthorityType.singlepayment || authority == PayloadGenerator.BezahlCode.AuthorityType.contact || (authority == PayloadGenerator.BezahlCode.AuthorityType.contact_v2 && flag3))
				{
					if (!Regex.IsMatch(account.Replace(" ", ""), "^[0-9]{1,9}$"))
					{
						throw new PayloadGenerator.BezahlCode.BezahlCodeException("The account entered isn't valid.");
					}
					this.account = account.Replace(" ", "").ToUpper();
					if (!Regex.IsMatch(bnc.Replace(" ", ""), "^[0-9]{1,9}$"))
					{
						throw new PayloadGenerator.BezahlCode.BezahlCodeException("The bnc entered isn't valid.");
					}
					this.bnc = bnc.Replace(" ", "").ToUpper();
					if (authority != PayloadGenerator.BezahlCode.AuthorityType.contact && authority != PayloadGenerator.BezahlCode.AuthorityType.contact_v2)
					{
						if (postingKey < 0 || postingKey >= 100)
						{
							throw new PayloadGenerator.BezahlCode.BezahlCodeException("PostingKey must be within 0 and 99.");
						}
						this.postingKey = postingKey;
					}
				}
				if (authority == PayloadGenerator.BezahlCode.AuthorityType.periodicsinglepaymentsepa || authority == PayloadGenerator.BezahlCode.AuthorityType.singledirectdebitsepa || authority == PayloadGenerator.BezahlCode.AuthorityType.singlepaymentsepa || (authority == PayloadGenerator.BezahlCode.AuthorityType.contact_v2 && flag4))
				{
					if (!PayloadGenerator.IsValidIban(iban))
					{
						throw new PayloadGenerator.BezahlCode.BezahlCodeException("The IBAN entered isn't valid.");
					}
					this.iban = iban.Replace(" ", "").ToUpper();
					if (!PayloadGenerator.IsValidBic(bic))
					{
						throw new PayloadGenerator.BezahlCode.BezahlCodeException("The BIC entered isn't valid.");
					}
					this.bic = bic.Replace(" ", "").ToUpper();
					if (authority != PayloadGenerator.BezahlCode.AuthorityType.contact_v2)
					{
						if (sepaReference.Length > 35)
						{
							throw new PayloadGenerator.BezahlCode.BezahlCodeException("SEPA reference texts have to be shorter than 36 chars.");
						}
						this.sepaReference = sepaReference;
						if (!string.IsNullOrEmpty(creditorId) && !Regex.IsMatch(creditorId.Replace(" ", ""), "^[a-zA-Z]{2,2}[0-9]{2,2}([A-Za-z0-9]|[\\+|\\?|/|\\-|:|\\(|\\)|\\.|,|']){3,3}([A-Za-z0-9]|[\\+|\\?|/|\\-|:|\\(|\\)|\\.|,|']){1,28}$"))
						{
							throw new PayloadGenerator.BezahlCode.BezahlCodeException("The creditorId entered isn't valid.");
						}
						this.creditorId = creditorId;
						if (!string.IsNullOrEmpty(mandateId) && !Regex.IsMatch(mandateId.Replace(" ", ""), "^([A-Za-z0-9]|[\\+|\\?|/|\\-|:|\\(|\\)|\\.|,|']){1,35}$"))
						{
							throw new PayloadGenerator.BezahlCode.BezahlCodeException("The mandateId entered isn't valid.");
						}
						this.mandateId = mandateId;
						if (dateOfSignature != null)
						{
							this.dateOfSignature = dateOfSignature.Value;
						}
					}
				}
				if (authority != PayloadGenerator.BezahlCode.AuthorityType.contact && authority != PayloadGenerator.BezahlCode.AuthorityType.contact_v2)
				{
					if (amount.ToString().Replace(",", ".").Contains(".") && amount.ToString().Replace(",", ".").Split(new char[]
					{
						'.'
					})[1].TrimEnd(new char[]
					{
						'0'
					}).Length > 2)
					{
						throw new PayloadGenerator.BezahlCode.BezahlCodeException("Amount must have less than 3 digits after decimal point.");
					}
					if (amount < 0.01m || amount > 999999999.99m)
					{
						throw new PayloadGenerator.BezahlCode.BezahlCodeException("Amount has to at least 0.01 and must be smaller or equal to 999999999.99.");
					}
					this.amount = amount;
					this.currency = currency;
					if (executionDate == null)
					{
						this.executionDate = DateTime.Now;
					}
					else
					{
						if (DateTime.Today.Ticks > executionDate.Value.Ticks)
						{
							throw new PayloadGenerator.BezahlCode.BezahlCodeException("Execution date must be today or in future.");
						}
						this.executionDate = executionDate.Value;
					}
					if (authority == PayloadGenerator.BezahlCode.AuthorityType.periodicsinglepayment || authority == PayloadGenerator.BezahlCode.AuthorityType.periodicsinglepaymentsepa)
					{
						if (periodicTimeunit.ToUpper() != "M" && periodicTimeunit.ToUpper() != "W")
						{
							throw new PayloadGenerator.BezahlCode.BezahlCodeException("The periodicTimeunit must be either 'M' (monthly) or 'W' (weekly).");
						}
						this.periodicTimeunit = periodicTimeunit;
						if (periodicTimeunitRotation < 1 || periodicTimeunitRotation > 52)
						{
							throw new PayloadGenerator.BezahlCode.BezahlCodeException("The periodicTimeunitRotation must be 1 or greater. (It means repeat the payment every 'periodicTimeunitRotation' weeks/months.");
						}
						this.periodicTimeunitRotation = periodicTimeunitRotation;
						if (periodicFirstExecutionDate != null)
						{
							this.periodicFirstExecutionDate = periodicFirstExecutionDate.Value;
						}
						if (periodicLastExecutionDate != null)
						{
							this.periodicLastExecutionDate = periodicLastExecutionDate.Value;
						}
					}
				}
			}

			// Token: 0x060000D2 RID: 210 RVA: 0x00008CEC File Offset: 0x00006EEC
			public override string ToString()
			{
				string text = string.Format("bank://{0}?", this.authority);
				text = text + "name=" + Uri.EscapeDataString(this.name) + "&";
				if (this.authority != PayloadGenerator.BezahlCode.AuthorityType.contact && this.authority != PayloadGenerator.BezahlCode.AuthorityType.contact_v2)
				{
					if (this.authority == PayloadGenerator.BezahlCode.AuthorityType.periodicsinglepayment || this.authority == PayloadGenerator.BezahlCode.AuthorityType.singledirectdebit || this.authority == PayloadGenerator.BezahlCode.AuthorityType.singlepayment)
					{
						text = text + "account=" + this.account + "&";
						text = text + "bnc=" + this.bnc + "&";
						if (this.postingKey > 0)
						{
							text += string.Format("postingkey={0}&", this.postingKey);
						}
					}
					else
					{
						text = text + "iban=" + this.iban + "&";
						text = text + "bic=" + this.bic + "&";
						if (!string.IsNullOrEmpty(this.sepaReference))
						{
							text = text + "separeference=" + Uri.EscapeDataString(this.sepaReference) + "&";
						}
						if (this.authority == PayloadGenerator.BezahlCode.AuthorityType.singledirectdebitsepa)
						{
							if (!string.IsNullOrEmpty(this.creditorId))
							{
								text = text + "creditorid=" + Uri.EscapeDataString(this.creditorId) + "&";
							}
							if (!string.IsNullOrEmpty(this.mandateId))
							{
								text = text + "mandateid=" + Uri.EscapeDataString(this.mandateId) + "&";
							}
							if (this.dateOfSignature != DateTime.MinValue)
							{
								text = text + "dateofsignature=" + this.dateOfSignature.ToString("ddMMyyyy") + "&";
							}
						}
					}
					text += string.Format("amount={0:0.00}&", this.amount).Replace(".", ",");
					if (!string.IsNullOrEmpty(this.reason))
					{
						text = text + "reason=" + Uri.EscapeDataString(this.reason) + "&";
					}
					text += string.Format("currency={0}&", this.currency);
					text = text + "executiondate=" + this.executionDate.ToString("ddMMyyyy") + "&";
					if (this.authority == PayloadGenerator.BezahlCode.AuthorityType.periodicsinglepayment || this.authority == PayloadGenerator.BezahlCode.AuthorityType.periodicsinglepaymentsepa)
					{
						text = text + "periodictimeunit=" + this.periodicTimeunit + "&";
						text += string.Format("periodictimeunitrotation={0}&", this.periodicTimeunitRotation);
						if (this.periodicFirstExecutionDate != DateTime.MinValue)
						{
							text = text + "periodicfirstexecutiondate=" + this.periodicFirstExecutionDate.ToString("ddMMyyyy") + "&";
						}
						if (this.periodicLastExecutionDate != DateTime.MinValue)
						{
							text = text + "periodiclastexecutiondate=" + this.periodicLastExecutionDate.ToString("ddMMyyyy") + "&";
						}
					}
				}
				else
				{
					if (this.authority == PayloadGenerator.BezahlCode.AuthorityType.contact)
					{
						text = text + "account=" + this.account + "&";
						text = text + "bnc=" + this.bnc + "&";
					}
					else if (this.authority == PayloadGenerator.BezahlCode.AuthorityType.contact_v2)
					{
						if (!string.IsNullOrEmpty(this.account) && !string.IsNullOrEmpty(this.bnc))
						{
							text = text + "account=" + this.account + "&";
							text = text + "bnc=" + this.bnc + "&";
						}
						else
						{
							text = text + "iban=" + this.iban + "&";
							text = text + "bic=" + this.bic + "&";
						}
					}
					if (!string.IsNullOrEmpty(this.reason))
					{
						text = text + "reason=" + Uri.EscapeDataString(this.reason) + "&";
					}
				}
				return text.Trim(new char[]
				{
					'&'
				});
			}

			// Token: 0x0400007B RID: 123
			private readonly string name;

			// Token: 0x0400007C RID: 124
			private readonly string iban;

			// Token: 0x0400007D RID: 125
			private readonly string bic;

			// Token: 0x0400007E RID: 126
			private readonly string account;

			// Token: 0x0400007F RID: 127
			private readonly string bnc;

			// Token: 0x04000080 RID: 128
			private readonly string sepaReference;

			// Token: 0x04000081 RID: 129
			private readonly string reason;

			// Token: 0x04000082 RID: 130
			private readonly string creditorId;

			// Token: 0x04000083 RID: 131
			private readonly string mandateId;

			// Token: 0x04000084 RID: 132
			private readonly string periodicTimeunit;

			// Token: 0x04000085 RID: 133
			private readonly decimal amount;

			// Token: 0x04000086 RID: 134
			private readonly int postingKey;

			// Token: 0x04000087 RID: 135
			private readonly int periodicTimeunitRotation;

			// Token: 0x04000088 RID: 136
			private readonly PayloadGenerator.BezahlCode.Currency currency;

			// Token: 0x04000089 RID: 137
			private readonly PayloadGenerator.BezahlCode.AuthorityType authority;

			// Token: 0x0400008A RID: 138
			private readonly DateTime executionDate;

			// Token: 0x0400008B RID: 139
			private readonly DateTime dateOfSignature;

			// Token: 0x0400008C RID: 140
			private readonly DateTime periodicFirstExecutionDate;

			// Token: 0x0400008D RID: 141
			private readonly DateTime periodicLastExecutionDate;

			// Token: 0x02000075 RID: 117
			public enum Currency
			{
				// Token: 0x04000166 RID: 358
				AED = 784,
				// Token: 0x04000167 RID: 359
				AFN = 971,
				// Token: 0x04000168 RID: 360
				ALL = 8,
				// Token: 0x04000169 RID: 361
				AMD = 51,
				// Token: 0x0400016A RID: 362
				ANG = 532,
				// Token: 0x0400016B RID: 363
				AOA = 973,
				// Token: 0x0400016C RID: 364
				ARS = 32,
				// Token: 0x0400016D RID: 365
				AUD = 36,
				// Token: 0x0400016E RID: 366
				AWG = 533,
				// Token: 0x0400016F RID: 367
				AZN = 944,
				// Token: 0x04000170 RID: 368
				BAM = 977,
				// Token: 0x04000171 RID: 369
				BBD = 52,
				// Token: 0x04000172 RID: 370
				BDT = 50,
				// Token: 0x04000173 RID: 371
				BGN = 975,
				// Token: 0x04000174 RID: 372
				BHD = 48,
				// Token: 0x04000175 RID: 373
				BIF = 108,
				// Token: 0x04000176 RID: 374
				BMD = 60,
				// Token: 0x04000177 RID: 375
				BND = 96,
				// Token: 0x04000178 RID: 376
				BOB = 68,
				// Token: 0x04000179 RID: 377
				BOV = 984,
				// Token: 0x0400017A RID: 378
				BRL = 986,
				// Token: 0x0400017B RID: 379
				BSD = 44,
				// Token: 0x0400017C RID: 380
				BTN = 64,
				// Token: 0x0400017D RID: 381
				BWP = 72,
				// Token: 0x0400017E RID: 382
				BYR = 974,
				// Token: 0x0400017F RID: 383
				BZD = 84,
				// Token: 0x04000180 RID: 384
				CAD = 124,
				// Token: 0x04000181 RID: 385
				CDF = 976,
				// Token: 0x04000182 RID: 386
				CHE = 947,
				// Token: 0x04000183 RID: 387
				CHF = 756,
				// Token: 0x04000184 RID: 388
				CHW = 948,
				// Token: 0x04000185 RID: 389
				CLF = 990,
				// Token: 0x04000186 RID: 390
				CLP = 152,
				// Token: 0x04000187 RID: 391
				CNY = 156,
				// Token: 0x04000188 RID: 392
				COP = 170,
				// Token: 0x04000189 RID: 393
				COU = 970,
				// Token: 0x0400018A RID: 394
				CRC = 188,
				// Token: 0x0400018B RID: 395
				CUC = 931,
				// Token: 0x0400018C RID: 396
				CUP = 192,
				// Token: 0x0400018D RID: 397
				CVE = 132,
				// Token: 0x0400018E RID: 398
				CZK = 203,
				// Token: 0x0400018F RID: 399
				DJF = 262,
				// Token: 0x04000190 RID: 400
				DKK = 208,
				// Token: 0x04000191 RID: 401
				DOP = 214,
				// Token: 0x04000192 RID: 402
				DZD = 12,
				// Token: 0x04000193 RID: 403
				EGP = 818,
				// Token: 0x04000194 RID: 404
				ERN = 232,
				// Token: 0x04000195 RID: 405
				ETB = 230,
				// Token: 0x04000196 RID: 406
				EUR = 978,
				// Token: 0x04000197 RID: 407
				FJD = 242,
				// Token: 0x04000198 RID: 408
				FKP = 238,
				// Token: 0x04000199 RID: 409
				GBP = 826,
				// Token: 0x0400019A RID: 410
				GEL = 981,
				// Token: 0x0400019B RID: 411
				GHS = 936,
				// Token: 0x0400019C RID: 412
				GIP = 292,
				// Token: 0x0400019D RID: 413
				GMD = 270,
				// Token: 0x0400019E RID: 414
				GNF = 324,
				// Token: 0x0400019F RID: 415
				GTQ = 320,
				// Token: 0x040001A0 RID: 416
				GYD = 328,
				// Token: 0x040001A1 RID: 417
				HKD = 344,
				// Token: 0x040001A2 RID: 418
				HNL = 340,
				// Token: 0x040001A3 RID: 419
				HRK = 191,
				// Token: 0x040001A4 RID: 420
				HTG = 332,
				// Token: 0x040001A5 RID: 421
				HUF = 348,
				// Token: 0x040001A6 RID: 422
				IDR = 360,
				// Token: 0x040001A7 RID: 423
				ILS = 376,
				// Token: 0x040001A8 RID: 424
				INR = 356,
				// Token: 0x040001A9 RID: 425
				IQD = 368,
				// Token: 0x040001AA RID: 426
				IRR = 364,
				// Token: 0x040001AB RID: 427
				ISK = 352,
				// Token: 0x040001AC RID: 428
				JMD = 388,
				// Token: 0x040001AD RID: 429
				JOD = 400,
				// Token: 0x040001AE RID: 430
				JPY = 392,
				// Token: 0x040001AF RID: 431
				KES = 404,
				// Token: 0x040001B0 RID: 432
				KGS = 417,
				// Token: 0x040001B1 RID: 433
				KHR = 116,
				// Token: 0x040001B2 RID: 434
				KMF = 174,
				// Token: 0x040001B3 RID: 435
				KPW = 408,
				// Token: 0x040001B4 RID: 436
				KRW = 410,
				// Token: 0x040001B5 RID: 437
				KWD = 414,
				// Token: 0x040001B6 RID: 438
				KYD = 136,
				// Token: 0x040001B7 RID: 439
				KZT = 398,
				// Token: 0x040001B8 RID: 440
				LAK = 418,
				// Token: 0x040001B9 RID: 441
				LBP = 422,
				// Token: 0x040001BA RID: 442
				LKR = 144,
				// Token: 0x040001BB RID: 443
				LRD = 430,
				// Token: 0x040001BC RID: 444
				LSL = 426,
				// Token: 0x040001BD RID: 445
				LYD = 434,
				// Token: 0x040001BE RID: 446
				MAD = 504,
				// Token: 0x040001BF RID: 447
				MDL = 498,
				// Token: 0x040001C0 RID: 448
				MGA = 969,
				// Token: 0x040001C1 RID: 449
				MKD = 807,
				// Token: 0x040001C2 RID: 450
				MMK = 104,
				// Token: 0x040001C3 RID: 451
				MNT = 496,
				// Token: 0x040001C4 RID: 452
				MOP = 446,
				// Token: 0x040001C5 RID: 453
				MRO = 478,
				// Token: 0x040001C6 RID: 454
				MUR = 480,
				// Token: 0x040001C7 RID: 455
				MVR = 462,
				// Token: 0x040001C8 RID: 456
				MWK = 454,
				// Token: 0x040001C9 RID: 457
				MXN = 484,
				// Token: 0x040001CA RID: 458
				MXV = 979,
				// Token: 0x040001CB RID: 459
				MYR = 458,
				// Token: 0x040001CC RID: 460
				MZN = 943,
				// Token: 0x040001CD RID: 461
				NAD = 516,
				// Token: 0x040001CE RID: 462
				NGN = 566,
				// Token: 0x040001CF RID: 463
				NIO = 558,
				// Token: 0x040001D0 RID: 464
				NOK = 578,
				// Token: 0x040001D1 RID: 465
				NPR = 524,
				// Token: 0x040001D2 RID: 466
				NZD = 554,
				// Token: 0x040001D3 RID: 467
				OMR = 512,
				// Token: 0x040001D4 RID: 468
				PAB = 590,
				// Token: 0x040001D5 RID: 469
				PEN = 604,
				// Token: 0x040001D6 RID: 470
				PGK = 598,
				// Token: 0x040001D7 RID: 471
				PHP = 608,
				// Token: 0x040001D8 RID: 472
				PKR = 586,
				// Token: 0x040001D9 RID: 473
				PLN = 985,
				// Token: 0x040001DA RID: 474
				PYG = 600,
				// Token: 0x040001DB RID: 475
				QAR = 634,
				// Token: 0x040001DC RID: 476
				RON = 946,
				// Token: 0x040001DD RID: 477
				RSD = 941,
				// Token: 0x040001DE RID: 478
				RUB = 643,
				// Token: 0x040001DF RID: 479
				RWF = 646,
				// Token: 0x040001E0 RID: 480
				SAR = 682,
				// Token: 0x040001E1 RID: 481
				SBD = 90,
				// Token: 0x040001E2 RID: 482
				SCR = 690,
				// Token: 0x040001E3 RID: 483
				SDG = 938,
				// Token: 0x040001E4 RID: 484
				SEK = 752,
				// Token: 0x040001E5 RID: 485
				SGD = 702,
				// Token: 0x040001E6 RID: 486
				SHP = 654,
				// Token: 0x040001E7 RID: 487
				SLL = 694,
				// Token: 0x040001E8 RID: 488
				SOS = 706,
				// Token: 0x040001E9 RID: 489
				SRD = 968,
				// Token: 0x040001EA RID: 490
				SSP = 728,
				// Token: 0x040001EB RID: 491
				STD = 678,
				// Token: 0x040001EC RID: 492
				SVC = 222,
				// Token: 0x040001ED RID: 493
				SYP = 760,
				// Token: 0x040001EE RID: 494
				SZL = 748,
				// Token: 0x040001EF RID: 495
				THB = 764,
				// Token: 0x040001F0 RID: 496
				TJS = 972,
				// Token: 0x040001F1 RID: 497
				TMT = 934,
				// Token: 0x040001F2 RID: 498
				TND = 788,
				// Token: 0x040001F3 RID: 499
				TOP = 776,
				// Token: 0x040001F4 RID: 500
				TRY = 949,
				// Token: 0x040001F5 RID: 501
				TTD = 780,
				// Token: 0x040001F6 RID: 502
				TWD = 901,
				// Token: 0x040001F7 RID: 503
				TZS = 834,
				// Token: 0x040001F8 RID: 504
				UAH = 980,
				// Token: 0x040001F9 RID: 505
				UGX = 800,
				// Token: 0x040001FA RID: 506
				USD = 840,
				// Token: 0x040001FB RID: 507
				USN = 997,
				// Token: 0x040001FC RID: 508
				UYI = 940,
				// Token: 0x040001FD RID: 509
				UYU = 858,
				// Token: 0x040001FE RID: 510
				UZS = 860,
				// Token: 0x040001FF RID: 511
				VEF = 937,
				// Token: 0x04000200 RID: 512
				VND = 704,
				// Token: 0x04000201 RID: 513
				VUV = 548,
				// Token: 0x04000202 RID: 514
				WST = 882,
				// Token: 0x04000203 RID: 515
				XAF = 950,
				// Token: 0x04000204 RID: 516
				XAG = 961,
				// Token: 0x04000205 RID: 517
				XAU = 959,
				// Token: 0x04000206 RID: 518
				XBA = 955,
				// Token: 0x04000207 RID: 519
				XBB,
				// Token: 0x04000208 RID: 520
				XBC,
				// Token: 0x04000209 RID: 521
				XBD,
				// Token: 0x0400020A RID: 522
				XCD = 951,
				// Token: 0x0400020B RID: 523
				XDR = 960,
				// Token: 0x0400020C RID: 524
				XOF = 952,
				// Token: 0x0400020D RID: 525
				XPD = 964,
				// Token: 0x0400020E RID: 526
				XPF = 953,
				// Token: 0x0400020F RID: 527
				XPT = 962,
				// Token: 0x04000210 RID: 528
				XSU = 994,
				// Token: 0x04000211 RID: 529
				XTS = 963,
				// Token: 0x04000212 RID: 530
				XUA = 965,
				// Token: 0x04000213 RID: 531
				XXX = 999,
				// Token: 0x04000214 RID: 532
				YER = 886,
				// Token: 0x04000215 RID: 533
				ZAR = 710,
				// Token: 0x04000216 RID: 534
				ZMW = 967,
				// Token: 0x04000217 RID: 535
				ZWL = 932
			}

			// Token: 0x02000076 RID: 118
			public enum AuthorityType
			{
				// Token: 0x04000219 RID: 537
				[Obsolete]
				singlepayment,
				// Token: 0x0400021A RID: 538
				singlepaymentsepa,
				// Token: 0x0400021B RID: 539
				[Obsolete]
				singledirectdebit,
				// Token: 0x0400021C RID: 540
				singledirectdebitsepa,
				// Token: 0x0400021D RID: 541
				[Obsolete]
				periodicsinglepayment,
				// Token: 0x0400021E RID: 542
				periodicsinglepaymentsepa,
				// Token: 0x0400021F RID: 543
				contact,
				// Token: 0x04000220 RID: 544
				contact_v2
			}

			// Token: 0x02000077 RID: 119
			public class BezahlCodeException : Exception
			{
				// Token: 0x0600019C RID: 412 RVA: 0x0000D29B File Offset: 0x0000B49B
				public BezahlCodeException()
				{
				}

				// Token: 0x0600019D RID: 413 RVA: 0x0000D2A3 File Offset: 0x0000B4A3
				public BezahlCodeException(string message) : base(message)
				{
				}

				// Token: 0x0600019E RID: 414 RVA: 0x0000D2AC File Offset: 0x0000B4AC
				public BezahlCodeException(string message, Exception inner) : base(message, inner)
				{
				}
			}
		}

		// Token: 0x02000035 RID: 53
		public class CalendarEvent : PayloadGenerator.Payload
		{
			// Token: 0x060000D3 RID: 211 RVA: 0x000090EC File Offset: 0x000072EC
			public CalendarEvent(string subject, string description, string location, DateTime start, DateTime end, bool allDayEvent, PayloadGenerator.CalendarEvent.EventEncoding encoding = PayloadGenerator.CalendarEvent.EventEncoding.Universal)
			{
				this.subject = subject;
				this.description = description;
				this.location = location;
				this.encoding = encoding;
				string format = allDayEvent ? "yyyyMMdd" : "yyyyMMddTHHmmss";
				this.start = start.ToString(format);
				this.end = end.ToString(format);
			}

			// Token: 0x060000D4 RID: 212 RVA: 0x0000914C File Offset: 0x0000734C
			public override string ToString()
			{
				string text = "BEGIN:VEVENT" + Environment.NewLine;
				text = text + "SUMMARY:" + this.subject + Environment.NewLine;
				text += ((!string.IsNullOrEmpty(this.description)) ? ("DESCRIPTION:" + this.description + Environment.NewLine) : "");
				text += ((!string.IsNullOrEmpty(this.location)) ? ("LOCATION:" + this.location + Environment.NewLine) : "");
				text = text + "DTSTART:" + this.start + Environment.NewLine;
				text = text + "DTEND:" + this.end + Environment.NewLine;
				text += "END:VEVENT";
				if (this.encoding == PayloadGenerator.CalendarEvent.EventEncoding.iCalComplete)
				{
					text = string.Concat(new string[]
					{
						"BEGIN:VCALENDAR",
						Environment.NewLine,
						"VERSION:2.0",
						Environment.NewLine,
						text,
						Environment.NewLine,
						"END:VCALENDAR"
					});
				}
				return text;
			}

			// Token: 0x0400008E RID: 142
			private readonly string subject;

			// Token: 0x0400008F RID: 143
			private readonly string description;

			// Token: 0x04000090 RID: 144
			private readonly string location;

			// Token: 0x04000091 RID: 145
			private readonly string start;

			// Token: 0x04000092 RID: 146
			private readonly string end;

			// Token: 0x04000093 RID: 147
			private readonly PayloadGenerator.CalendarEvent.EventEncoding encoding;

			// Token: 0x02000078 RID: 120
			public enum EventEncoding
			{
				// Token: 0x04000222 RID: 546
				iCalComplete,
				// Token: 0x04000223 RID: 547
				Universal
			}
		}

		// Token: 0x02000036 RID: 54
		public class OneTimePassword : PayloadGenerator.Payload
		{
			// Token: 0x1700000A RID: 10
			// (get) Token: 0x060000D5 RID: 213 RVA: 0x00009263 File Offset: 0x00007463
			// (set) Token: 0x060000D6 RID: 214 RVA: 0x0000926B File Offset: 0x0000746B
			public PayloadGenerator.OneTimePassword.OneTimePasswordAuthType Type { get; set; }

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x060000D7 RID: 215 RVA: 0x00009274 File Offset: 0x00007474
			// (set) Token: 0x060000D8 RID: 216 RVA: 0x0000927C File Offset: 0x0000747C
			public string Secret { get; set; }

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x060000D9 RID: 217 RVA: 0x00009285 File Offset: 0x00007485
			// (set) Token: 0x060000DA RID: 218 RVA: 0x0000928D File Offset: 0x0000748D
			public PayloadGenerator.OneTimePassword.OneTimePasswordAuthAlgorithm AuthAlgorithm { get; set; }

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x060000DB RID: 219 RVA: 0x00009298 File Offset: 0x00007498
			// (set) Token: 0x060000DC RID: 220 RVA: 0x000092CD File Offset: 0x000074CD
			[Obsolete("This property is obsolete, use AuthAlgorithm instead", false)]
			public PayloadGenerator.OneTimePassword.OoneTimePasswordAuthAlgorithm Algorithm
			{
				get
				{
					return (PayloadGenerator.OneTimePassword.OoneTimePasswordAuthAlgorithm)Enum.Parse(typeof(PayloadGenerator.OneTimePassword.OoneTimePasswordAuthAlgorithm), this.AuthAlgorithm.ToString());
				}
				set
				{
					this.AuthAlgorithm = (PayloadGenerator.OneTimePassword.OneTimePasswordAuthAlgorithm)Enum.Parse(typeof(PayloadGenerator.OneTimePassword.OneTimePasswordAuthAlgorithm), value.ToString());
				}
			}

			// Token: 0x1700000E RID: 14
			// (get) Token: 0x060000DD RID: 221 RVA: 0x000092F6 File Offset: 0x000074F6
			// (set) Token: 0x060000DE RID: 222 RVA: 0x000092FE File Offset: 0x000074FE
			public string Issuer { get; set; }

			// Token: 0x1700000F RID: 15
			// (get) Token: 0x060000DF RID: 223 RVA: 0x00009307 File Offset: 0x00007507
			// (set) Token: 0x060000E0 RID: 224 RVA: 0x0000930F File Offset: 0x0000750F
			public string Label { get; set; }

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x060000E1 RID: 225 RVA: 0x00009318 File Offset: 0x00007518
			// (set) Token: 0x060000E2 RID: 226 RVA: 0x00009320 File Offset: 0x00007520
			public int Digits { get; set; } = 6;

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x060000E3 RID: 227 RVA: 0x00009329 File Offset: 0x00007529
			// (set) Token: 0x060000E4 RID: 228 RVA: 0x00009331 File Offset: 0x00007531
			public int? Counter { get; set; }

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x060000E5 RID: 229 RVA: 0x0000933A File Offset: 0x0000753A
			// (set) Token: 0x060000E6 RID: 230 RVA: 0x00009342 File Offset: 0x00007542
			public int? Period { get; set; } = new int?(30);

			// Token: 0x060000E7 RID: 231 RVA: 0x0000934C File Offset: 0x0000754C
			public override string ToString()
			{
				PayloadGenerator.OneTimePassword.OneTimePasswordAuthType type = this.Type;
				if (type == PayloadGenerator.OneTimePassword.OneTimePasswordAuthType.TOTP)
				{
					return this.TimeToString();
				}
				if (type != PayloadGenerator.OneTimePassword.OneTimePasswordAuthType.HOTP)
				{
					throw new ArgumentOutOfRangeException();
				}
				return this.HMACToString();
			}

			// Token: 0x060000E8 RID: 232 RVA: 0x0000937C File Offset: 0x0000757C
			private string HMACToString()
			{
				StringBuilder stringBuilder = new StringBuilder("otpauth://hotp/");
				this.ProcessCommonFields(stringBuilder);
				stringBuilder.Append("&counter=" + (this.Counter ?? 1).ToString());
				return stringBuilder.ToString();
			}

			// Token: 0x060000E9 RID: 233 RVA: 0x000093D4 File Offset: 0x000075D4
			private string TimeToString()
			{
				if (this.Period == null)
				{
					throw new Exception("Period must be set when using OneTimePasswordAuthType.TOTP");
				}
				StringBuilder stringBuilder = new StringBuilder("otpauth://totp/");
				this.ProcessCommonFields(stringBuilder);
				int? period = this.Period;
				int num = 30;
				if (!(period.GetValueOrDefault() == num & period != null))
				{
					stringBuilder.Append("&period=" + this.Period.ToString());
				}
				return stringBuilder.ToString();
			}

			// Token: 0x060000EA RID: 234 RVA: 0x00009458 File Offset: 0x00007658
			private void ProcessCommonFields(StringBuilder sb)
			{
				if (String40Methods.IsNullOrWhiteSpace(this.Secret))
				{
					throw new Exception("Secret must be a filled out base32 encoded string");
				}
				string str = this.Secret.Replace(" ", "");
				string text = null;
				string text2 = null;
				if (!String40Methods.IsNullOrWhiteSpace(this.Issuer))
				{
					if (this.Issuer.Contains(":"))
					{
						throw new Exception("Issuer must not have a ':'");
					}
					text = Uri.EscapeDataString(this.Issuer);
				}
				if (!String40Methods.IsNullOrWhiteSpace(this.Label) && this.Label.Contains(":"))
				{
					throw new Exception("Label must not have a ':'");
				}
				if (this.Label != null && this.Issuer != null)
				{
					text2 = this.Issuer + ":" + this.Label;
				}
				else if (this.Issuer != null)
				{
					text2 = this.Issuer;
				}
				if (text2 != null)
				{
					sb.Append(text2);
				}
				sb.Append("?secret=" + str);
				if (text != null)
				{
					sb.Append("&issuer=" + text);
				}
				if (this.Digits != 6)
				{
					sb.Append("&digits=" + this.Digits.ToString());
				}
			}

			// Token: 0x02000079 RID: 121
			public enum OneTimePasswordAuthType
			{
				// Token: 0x04000225 RID: 549
				TOTP,
				// Token: 0x04000226 RID: 550
				HOTP
			}

			// Token: 0x0200007A RID: 122
			public enum OneTimePasswordAuthAlgorithm
			{
				// Token: 0x04000228 RID: 552
				SHA1,
				// Token: 0x04000229 RID: 553
				SHA256,
				// Token: 0x0400022A RID: 554
				SHA512
			}

			// Token: 0x0200007B RID: 123
			[Obsolete("This enum is obsolete, use OneTimePasswordAuthAlgorithm instead", false)]
			public enum OoneTimePasswordAuthAlgorithm
			{
				// Token: 0x0400022C RID: 556
				SHA1,
				// Token: 0x0400022D RID: 557
				SHA256,
				// Token: 0x0400022E RID: 558
				SHA512
			}
		}

		// Token: 0x02000037 RID: 55
		public class ShadowSocksConfig : PayloadGenerator.Payload
		{
			// Token: 0x060000EC RID: 236 RVA: 0x000095A5 File Offset: 0x000077A5
			public ShadowSocksConfig(string hostname, int port, string password, PayloadGenerator.ShadowSocksConfig.Method method, string tag = null) : this(hostname, port, password, method, null, tag)
			{
			}

			// Token: 0x060000ED RID: 237 RVA: 0x000095B8 File Offset: 0x000077B8
			public ShadowSocksConfig(string hostname, int port, string password, PayloadGenerator.ShadowSocksConfig.Method method, string plugin, string pluginOption, string tag = null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["plugin"] = plugin + (string.IsNullOrEmpty(pluginOption) ? "" : (";" + pluginOption));
				this..ctor(hostname, port, password, method, dictionary, tag);
			}

			// Token: 0x060000EE RID: 238 RVA: 0x00009608 File Offset: 0x00007808
			private string UrlEncode(string i)
			{
				string text = i;
				foreach (KeyValuePair<string, string> keyValuePair in this.UrlEncodeTable)
				{
					text = text.Replace(keyValuePair.Key, keyValuePair.Value);
				}
				return text;
			}

			// Token: 0x060000EF RID: 239 RVA: 0x0000966C File Offset: 0x0000786C
			public ShadowSocksConfig(string hostname, int port, string password, PayloadGenerator.ShadowSocksConfig.Method method, Dictionary<string, string> parameters, string tag = null)
			{
				this.encryptionTexts = new Dictionary<string, string>
				{
					{
						"Chacha20IetfPoly1305",
						"chacha20-ietf-poly1305"
					},
					{
						"Aes128Gcm",
						"aes-128-gcm"
					},
					{
						"Aes192Gcm",
						"aes-192-gcm"
					},
					{
						"Aes256Gcm",
						"aes-256-gcm"
					},
					{
						"XChacha20IetfPoly1305",
						"xchacha20-ietf-poly1305"
					},
					{
						"Aes128Cfb",
						"aes-128-cfb"
					},
					{
						"Aes192Cfb",
						"aes-192-cfb"
					},
					{
						"Aes256Cfb",
						"aes-256-cfb"
					},
					{
						"Aes128Ctr",
						"aes-128-ctr"
					},
					{
						"Aes192Ctr",
						"aes-192-ctr"
					},
					{
						"Aes256Ctr",
						"aes-256-ctr"
					},
					{
						"Camellia128Cfb",
						"camellia-128-cfb"
					},
					{
						"Camellia192Cfb",
						"camellia-192-cfb"
					},
					{
						"Camellia256Cfb",
						"camellia-256-cfb"
					},
					{
						"Chacha20Ietf",
						"chacha20-ietf"
					},
					{
						"Aes256Cb",
						"aes-256-cfb"
					},
					{
						"Aes128Ofb",
						"aes-128-ofb"
					},
					{
						"Aes192Ofb",
						"aes-192-ofb"
					},
					{
						"Aes256Ofb",
						"aes-256-ofb"
					},
					{
						"Aes128Cfb1",
						"aes-128-cfb1"
					},
					{
						"Aes192Cfb1",
						"aes-192-cfb1"
					},
					{
						"Aes256Cfb1",
						"aes-256-cfb1"
					},
					{
						"Aes128Cfb8",
						"aes-128-cfb8"
					},
					{
						"Aes192Cfb8",
						"aes-192-cfb8"
					},
					{
						"Aes256Cfb8",
						"aes-256-cfb8"
					},
					{
						"Chacha20",
						"chacha20"
					},
					{
						"BfCfb",
						"bf-cfb"
					},
					{
						"Rc4Md5",
						"rc4-md5"
					},
					{
						"Salsa20",
						"salsa20"
					},
					{
						"DesCfb",
						"des-cfb"
					},
					{
						"IdeaCfb",
						"idea-cfb"
					},
					{
						"Rc2Cfb",
						"rc2-cfb"
					},
					{
						"Cast5Cfb",
						"cast5-cfb"
					},
					{
						"Salsa20Ctr",
						"salsa20-ctr"
					},
					{
						"Rc4",
						"rc4"
					},
					{
						"SeedCfb",
						"seed-cfb"
					},
					{
						"Table",
						"table"
					}
				};
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary[" "] = "+";
				dictionary["\0"] = "%00";
				dictionary["\t"] = "%09";
				dictionary["\n"] = "%0a";
				dictionary["\r"] = "%0d";
				dictionary["\""] = "%22";
				dictionary["#"] = "%23";
				dictionary["$"] = "%24";
				dictionary["%"] = "%25";
				dictionary["&"] = "%26";
				dictionary["'"] = "%27";
				dictionary["+"] = "%2b";
				dictionary[","] = "%2c";
				dictionary["/"] = "%2f";
				dictionary[":"] = "%3a";
				dictionary[";"] = "%3b";
				dictionary["<"] = "%3c";
				dictionary["="] = "%3d";
				dictionary[">"] = "%3e";
				dictionary["?"] = "%3f";
				dictionary["@"] = "%40";
				dictionary["["] = "%5b";
				dictionary["\\"] = "%5c";
				dictionary["]"] = "%5d";
				dictionary["^"] = "%5e";
				dictionary["`"] = "%60";
				dictionary["{"] = "%7b";
				dictionary["|"] = "%7c";
				dictionary["}"] = "%7d";
				dictionary["~"] = "%7e";
				this.UrlEncodeTable = dictionary;
				base..ctor();
				this.hostname = ((Uri.CheckHostName(hostname) == UriHostNameType.IPv6) ? ("[" + hostname + "]") : hostname);
				if (port < 1 || port > 65535)
				{
					throw new PayloadGenerator.ShadowSocksConfig.ShadowSocksConfigException("Value of 'port' must be within 0 and 65535.");
				}
				this.port = port;
				this.password = password;
				this.method = method;
				this.methodStr = this.encryptionTexts[method.ToString()];
				this.tag = tag;
				if (parameters != null)
				{
					this.parameter = string.Join("&", (from kv in parameters
					select this.UrlEncode(kv.Key) + "=" + this.UrlEncode(kv.Value)).ToArray<string>());
				}
			}

			// Token: 0x060000F0 RID: 240 RVA: 0x00009B68 File Offset: 0x00007D68
			public override string ToString()
			{
				if (string.IsNullOrEmpty(this.parameter))
				{
					string s = string.Format("{0}:{1}@{2}:{3}", new object[]
					{
						this.methodStr,
						this.password,
						this.hostname,
						this.port
					});
					string str = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
					return "ss://" + str + ((!string.IsNullOrEmpty(this.tag)) ? ("#" + this.tag) : string.Empty);
				}
				string s2 = this.methodStr + ":" + this.password;
				string text = Convert.ToBase64String(Encoding.UTF8.GetBytes(s2)).Replace('+', '-').Replace('/', '_').TrimEnd(new char[]
				{
					'='
				});
				return string.Format("ss://{0}@{1}:{2}/?{3}{4}", new object[]
				{
					text,
					this.hostname,
					this.port,
					this.parameter,
					(!string.IsNullOrEmpty(this.tag)) ? ("#" + this.tag) : string.Empty
				});
			}

			// Token: 0x0400009C RID: 156
			private readonly string hostname;

			// Token: 0x0400009D RID: 157
			private readonly string password;

			// Token: 0x0400009E RID: 158
			private readonly string tag;

			// Token: 0x0400009F RID: 159
			private readonly string methodStr;

			// Token: 0x040000A0 RID: 160
			private readonly string parameter;

			// Token: 0x040000A1 RID: 161
			private readonly PayloadGenerator.ShadowSocksConfig.Method method;

			// Token: 0x040000A2 RID: 162
			private readonly int port;

			// Token: 0x040000A3 RID: 163
			private Dictionary<string, string> encryptionTexts;

			// Token: 0x040000A4 RID: 164
			private Dictionary<string, string> UrlEncodeTable;

			// Token: 0x0200007C RID: 124
			public enum Method
			{
				// Token: 0x04000230 RID: 560
				Chacha20IetfPoly1305,
				// Token: 0x04000231 RID: 561
				Aes128Gcm,
				// Token: 0x04000232 RID: 562
				Aes192Gcm,
				// Token: 0x04000233 RID: 563
				Aes256Gcm,
				// Token: 0x04000234 RID: 564
				XChacha20IetfPoly1305,
				// Token: 0x04000235 RID: 565
				Aes128Cfb,
				// Token: 0x04000236 RID: 566
				Aes192Cfb,
				// Token: 0x04000237 RID: 567
				Aes256Cfb,
				// Token: 0x04000238 RID: 568
				Aes128Ctr,
				// Token: 0x04000239 RID: 569
				Aes192Ctr,
				// Token: 0x0400023A RID: 570
				Aes256Ctr,
				// Token: 0x0400023B RID: 571
				Camellia128Cfb,
				// Token: 0x0400023C RID: 572
				Camellia192Cfb,
				// Token: 0x0400023D RID: 573
				Camellia256Cfb,
				// Token: 0x0400023E RID: 574
				Chacha20Ietf,
				// Token: 0x0400023F RID: 575
				Aes256Cb,
				// Token: 0x04000240 RID: 576
				Aes128Ofb,
				// Token: 0x04000241 RID: 577
				Aes192Ofb,
				// Token: 0x04000242 RID: 578
				Aes256Ofb,
				// Token: 0x04000243 RID: 579
				Aes128Cfb1,
				// Token: 0x04000244 RID: 580
				Aes192Cfb1,
				// Token: 0x04000245 RID: 581
				Aes256Cfb1,
				// Token: 0x04000246 RID: 582
				Aes128Cfb8,
				// Token: 0x04000247 RID: 583
				Aes192Cfb8,
				// Token: 0x04000248 RID: 584
				Aes256Cfb8,
				// Token: 0x04000249 RID: 585
				Chacha20,
				// Token: 0x0400024A RID: 586
				BfCfb,
				// Token: 0x0400024B RID: 587
				Rc4Md5,
				// Token: 0x0400024C RID: 588
				Salsa20,
				// Token: 0x0400024D RID: 589
				DesCfb,
				// Token: 0x0400024E RID: 590
				IdeaCfb,
				// Token: 0x0400024F RID: 591
				Rc2Cfb,
				// Token: 0x04000250 RID: 592
				Cast5Cfb,
				// Token: 0x04000251 RID: 593
				Salsa20Ctr,
				// Token: 0x04000252 RID: 594
				Rc4,
				// Token: 0x04000253 RID: 595
				SeedCfb,
				// Token: 0x04000254 RID: 596
				Table
			}

			// Token: 0x0200007D RID: 125
			public class ShadowSocksConfigException : Exception
			{
				// Token: 0x0600019F RID: 415 RVA: 0x0000D2B6 File Offset: 0x0000B4B6
				public ShadowSocksConfigException()
				{
				}

				// Token: 0x060001A0 RID: 416 RVA: 0x0000D2BE File Offset: 0x0000B4BE
				public ShadowSocksConfigException(string message) : base(message)
				{
				}

				// Token: 0x060001A1 RID: 417 RVA: 0x0000D2C7 File Offset: 0x0000B4C7
				public ShadowSocksConfigException(string message, Exception inner) : base(message, inner)
				{
				}
			}
		}

		// Token: 0x02000038 RID: 56
		public class MoneroTransaction : PayloadGenerator.Payload
		{
			// Token: 0x060000F2 RID: 242 RVA: 0x00009CC8 File Offset: 0x00007EC8
			public MoneroTransaction(string address, float? txAmount = null, string txPaymentId = null, string recipientName = null, string txDescription = null)
			{
				if (string.IsNullOrEmpty(address))
				{
					throw new PayloadGenerator.MoneroTransaction.MoneroTransactionException("The address is mandatory and has to be set.");
				}
				this.address = address;
				if (txAmount != null)
				{
					float? num = txAmount;
					float num2 = 0f;
					if (num.GetValueOrDefault() <= num2 & num != null)
					{
						throw new PayloadGenerator.MoneroTransaction.MoneroTransactionException("Value of 'txAmount' must be greater than 0.");
					}
				}
				this.txAmount = txAmount;
				this.txPaymentId = txPaymentId;
				this.recipientName = recipientName;
				this.txDescription = txDescription;
			}

			// Token: 0x060000F3 RID: 243 RVA: 0x00009D48 File Offset: 0x00007F48
			public override string ToString()
			{
				return ("monero://" + this.address + ((!string.IsNullOrEmpty(this.txPaymentId) || !string.IsNullOrEmpty(this.recipientName) || !string.IsNullOrEmpty(this.txDescription) || this.txAmount != null) ? "?" : string.Empty) + ((!string.IsNullOrEmpty(this.txPaymentId)) ? ("tx_payment_id=" + Uri.EscapeDataString(this.txPaymentId) + "&") : string.Empty) + ((!string.IsNullOrEmpty(this.recipientName)) ? ("recipient_name=" + Uri.EscapeDataString(this.recipientName) + "&") : string.Empty) + ((this.txAmount != null) ? ("tx_amount=" + this.txAmount.ToString().Replace(",", ".") + "&") : string.Empty) + ((!string.IsNullOrEmpty(this.txDescription)) ? ("tx_description=" + Uri.EscapeDataString(this.txDescription)) : string.Empty)).TrimEnd(new char[]
				{
					'&'
				});
			}

			// Token: 0x040000A5 RID: 165
			private readonly string address;

			// Token: 0x040000A6 RID: 166
			private readonly string txPaymentId;

			// Token: 0x040000A7 RID: 167
			private readonly string recipientName;

			// Token: 0x040000A8 RID: 168
			private readonly string txDescription;

			// Token: 0x040000A9 RID: 169
			private readonly float? txAmount;

			// Token: 0x0200007E RID: 126
			public class MoneroTransactionException : Exception
			{
				// Token: 0x060001A2 RID: 418 RVA: 0x0000D2D1 File Offset: 0x0000B4D1
				public MoneroTransactionException()
				{
				}

				// Token: 0x060001A3 RID: 419 RVA: 0x0000D2D9 File Offset: 0x0000B4D9
				public MoneroTransactionException(string message) : base(message)
				{
				}

				// Token: 0x060001A4 RID: 420 RVA: 0x0000D2E2 File Offset: 0x0000B4E2
				public MoneroTransactionException(string message, Exception inner) : base(message, inner)
				{
				}
			}
		}

		// Token: 0x02000039 RID: 57
		public class SlovenianUpnQr : PayloadGenerator.Payload
		{
			// Token: 0x17000013 RID: 19
			// (get) Token: 0x060000F4 RID: 244 RVA: 0x00009E94 File Offset: 0x00008094
			public override int Version
			{
				get
				{
					return 15;
				}
			}

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x060000F5 RID: 245 RVA: 0x00009E98 File Offset: 0x00008098
			public override QRCodeGenerator.ECCLevel EccLevel
			{
				get
				{
					return QRCodeGenerator.ECCLevel.M;
				}
			}

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x060000F6 RID: 246 RVA: 0x00009E9B File Offset: 0x0000809B
			public override QRCodeGenerator.EciMode EciMode
			{
				get
				{
					return QRCodeGenerator.EciMode.Iso8859_2;
				}
			}

			// Token: 0x060000F7 RID: 247 RVA: 0x00009E9E File Offset: 0x0000809E
			private string LimitLength(string value, int maxLength)
			{
				if (value.Length > maxLength)
				{
					return value.Substring(0, maxLength);
				}
				return value;
			}

			// Token: 0x060000F8 RID: 248 RVA: 0x00009EB4 File Offset: 0x000080B4
			public SlovenianUpnQr(string payerName, string payerAddress, string payerPlace, string recipientName, string recipientAddress, string recipientPlace, string recipientIban, string description, double amount, string recipientSiModel = "SI00", string recipientSiReference = "", string code = "OTHR") : this(payerName, payerAddress, payerPlace, recipientName, recipientAddress, recipientPlace, recipientIban, description, amount, null, recipientSiModel, recipientSiReference, code)
			{
			}

			// Token: 0x060000F9 RID: 249 RVA: 0x00009EE8 File Offset: 0x000080E8
			public SlovenianUpnQr(string payerName, string payerAddress, string payerPlace, string recipientName, string recipientAddress, string recipientPlace, string recipientIban, string description, double amount, DateTime? deadline, string recipientSiModel = "SI99", string recipientSiReference = "", string code = "OTHR")
			{
				this._payerName = this.LimitLength(payerName.Trim(), 33);
				this._payerAddress = this.LimitLength(payerAddress.Trim(), 33);
				this._payerPlace = this.LimitLength(payerPlace.Trim(), 33);
				this._amount = this.FormatAmount(amount);
				this._code = this.LimitLength(code.Trim().ToUpper(), 4);
				this._purpose = this.LimitLength(description.Trim(), 42);
				this._deadLine = ((deadline == null) ? "" : ((deadline != null) ? deadline.GetValueOrDefault().ToString("dd.MM.yyyy") : null));
				this._recipientIban = this.LimitLength(recipientIban.Trim(), 34);
				this._recipientName = this.LimitLength(recipientName.Trim(), 33);
				this._recipientAddress = this.LimitLength(recipientAddress.Trim(), 33);
				this._recipientPlace = this.LimitLength(recipientPlace.Trim(), 33);
				this._recipientSiModel = this.LimitLength(recipientSiModel.Trim().ToUpper(), 4);
				this._recipientSiReference = this.LimitLength(recipientSiReference.Trim(), 22);
			}

			// Token: 0x060000FA RID: 250 RVA: 0x0000A0BC File Offset: 0x000082BC
			private string FormatAmount(double amount)
			{
				int num = (int)Math.Round(amount * 100.0);
				return string.Format("{0:00000000000}", num);
			}

			// Token: 0x060000FB RID: 251 RVA: 0x0000A0EC File Offset: 0x000082EC
			private int CalculateChecksum()
			{
				return 5 + this._payerName.Length + this._payerAddress.Length + this._payerPlace.Length + this._amount.Length + this._code.Length + this._purpose.Length + this._deadLine.Length + this._recipientIban.Length + this._recipientName.Length + this._recipientAddress.Length + this._recipientPlace.Length + this._recipientSiModel.Length + this._recipientSiReference.Length + 19;
			}

			// Token: 0x060000FC RID: 252 RVA: 0x0000A19C File Offset: 0x0000839C
			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("UPNQR");
				stringBuilder.Append('\n').Append('\n').Append('\n').Append('\n').Append('\n');
				stringBuilder.Append(this._payerName).Append('\n');
				stringBuilder.Append(this._payerAddress).Append('\n');
				stringBuilder.Append(this._payerPlace).Append('\n');
				stringBuilder.Append(this._amount).Append('\n').Append('\n').Append('\n');
				stringBuilder.Append(this._code.ToUpper()).Append('\n');
				stringBuilder.Append(this._purpose).Append('\n');
				stringBuilder.Append(this._deadLine).Append('\n');
				stringBuilder.Append(this._recipientIban.ToUpper()).Append('\n');
				stringBuilder.Append(this._recipientSiModel).Append(this._recipientSiReference).Append('\n');
				stringBuilder.Append(this._recipientName).Append('\n');
				stringBuilder.Append(this._recipientAddress).Append('\n');
				stringBuilder.Append(this._recipientPlace).Append('\n');
				stringBuilder.AppendFormat("{0:000}", this.CalculateChecksum()).Append('\n');
				return stringBuilder.ToString();
			}

			// Token: 0x040000AA RID: 170
			private string _payerName = "";

			// Token: 0x040000AB RID: 171
			private string _payerAddress = "";

			// Token: 0x040000AC RID: 172
			private string _payerPlace = "";

			// Token: 0x040000AD RID: 173
			private string _amount = "";

			// Token: 0x040000AE RID: 174
			private string _code = "";

			// Token: 0x040000AF RID: 175
			private string _purpose = "";

			// Token: 0x040000B0 RID: 176
			private string _deadLine = "";

			// Token: 0x040000B1 RID: 177
			private string _recipientIban = "";

			// Token: 0x040000B2 RID: 178
			private string _recipientName = "";

			// Token: 0x040000B3 RID: 179
			private string _recipientAddress = "";

			// Token: 0x040000B4 RID: 180
			private string _recipientPlace = "";

			// Token: 0x040000B5 RID: 181
			private string _recipientSiModel = "";

			// Token: 0x040000B6 RID: 182
			private string _recipientSiReference = "";
		}

		// Token: 0x0200003A RID: 58
		public class RussiaPaymentOrder : PayloadGenerator.Payload
		{
			// Token: 0x060000FD RID: 253 RVA: 0x0000A315 File Offset: 0x00008515
			private RussiaPaymentOrder()
			{
				this.mFields = new PayloadGenerator.RussiaPaymentOrder.MandatoryFields();
				this.oFields = new PayloadGenerator.RussiaPaymentOrder.OptionalFields();
			}

			// Token: 0x060000FE RID: 254 RVA: 0x0000A340 File Offset: 0x00008540
			public RussiaPaymentOrder(string name, string personalAcc, string bankName, string BIC, string correspAcc, PayloadGenerator.RussiaPaymentOrder.OptionalFields optionalFields = null, PayloadGenerator.RussiaPaymentOrder.CharacterSets characterSet = PayloadGenerator.RussiaPaymentOrder.CharacterSets.utf_8) : this()
			{
				this.characterSet = characterSet;
				this.mFields.Name = PayloadGenerator.RussiaPaymentOrder.ValidateInput(name, "Name", "^.{1,160}$", null);
				this.mFields.PersonalAcc = PayloadGenerator.RussiaPaymentOrder.ValidateInput(personalAcc, "PersonalAcc", "^[1-9]\\d{4}[0-9ABCEHKMPTX]\\d{14}$", null);
				this.mFields.BankName = PayloadGenerator.RussiaPaymentOrder.ValidateInput(bankName, "BankName", "^.{1,45}$", null);
				this.mFields.BIC = PayloadGenerator.RussiaPaymentOrder.ValidateInput(BIC, "BIC", "^\\d{9}$", null);
				this.mFields.CorrespAcc = PayloadGenerator.RussiaPaymentOrder.ValidateInput(correspAcc, "CorrespAcc", "^[1-9]\\d{4}[0-9ABCEHKMPTX]\\d{14}$", null);
				if (optionalFields != null)
				{
					this.oFields = optionalFields;
				}
			}

			// Token: 0x060000FF RID: 255 RVA: 0x0000A3F8 File Offset: 0x000085F8
			public override string ToString()
			{
				string name = this.characterSet.ToString().Replace("_", "-");
				byte[] bytes = this.ToBytes();
				return Encoding.GetEncoding(name).GetString(bytes);
			}

			// Token: 0x06000100 RID: 256 RVA: 0x0000A438 File Offset: 0x00008638
			public byte[] ToBytes()
			{
				this.separator = this.DetermineSeparator();
				string[] array = new string[17];
				array[0] = "ST0001";
				int num = 1;
				int num2 = (int)this.characterSet;
				array[num] = num2.ToString();
				array[2] = this.separator;
				array[3] = "Name=";
				array[4] = this.mFields.Name;
				array[5] = this.separator;
				array[6] = "PersonalAcc=";
				array[7] = this.mFields.PersonalAcc;
				array[8] = this.separator;
				array[9] = "BankName=";
				array[10] = this.mFields.BankName;
				array[11] = this.separator;
				array[12] = "BIC=";
				array[13] = this.mFields.BIC;
				array[14] = this.separator;
				array[15] = "CorrespAcc=";
				array[16] = this.mFields.CorrespAcc;
				string text = string.Concat(array);
				List<string> optionalFieldsAsList = this.GetOptionalFieldsAsList();
				if (optionalFieldsAsList.Count > 0)
				{
					text = text + "|" + string.Join("|", optionalFieldsAsList.ToArray());
				}
				text += this.separator;
				string name = this.characterSet.ToString().Replace("_", "-");
				byte[] array2 = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(name), Encoding.UTF8.GetBytes(text));
				if (array2.Length > 300)
				{
					throw new PayloadGenerator.RussiaPaymentOrder.RussiaPaymentOrderException(string.Format("Data too long. Payload must not exceed 300 bytes, but actually is {0} bytes long. Remove additional data fields or shorten strings/values.", array2.Length));
				}
				return array2;
			}

			// Token: 0x06000101 RID: 257 RVA: 0x0000A5B4 File Offset: 0x000087B4
			private string DetermineSeparator()
			{
				List<string> mandatoryFieldsAsList = this.GetMandatoryFieldsAsList();
				List<string> optionalFieldsAsList = this.GetOptionalFieldsAsList();
				string[] array = new string[]
				{
					"|",
					"#",
					";",
					":",
					"^",
					"_",
					"~",
					"{",
					"}",
					"!",
					"#",
					"$",
					"%",
					"&",
					"(",
					")",
					"*",
					"+",
					",",
					"/",
					"@"
				};
				for (int i = 0; i < array.Length; i++)
				{
					string sepCandidate = array[i];
					if (!mandatoryFieldsAsList.Any((string x) => x.Contains(sepCandidate)) && !optionalFieldsAsList.Any((string x) => x.Contains(sepCandidate)))
					{
						return sepCandidate;
					}
				}
				throw new PayloadGenerator.RussiaPaymentOrder.RussiaPaymentOrderException("No valid separator found.");
			}

			// Token: 0x06000102 RID: 258 RVA: 0x0000A6E6 File Offset: 0x000088E6
			private List<string> GetOptionalFieldsAsList()
			{
				return (from field in this.oFields.GetType().GetProperties()
				where field.GetValue(this.oFields, null) != null
				select field).Select(delegate(PropertyInfo field)
				{
					object value = field.GetValue(this.oFields, null);
					string str = field.PropertyType.Equals(typeof(DateTime?)) ? ((DateTime)value).ToString("dd.MM.yyyy") : value.ToString();
					return field.Name + "=" + str;
				}).ToList<string>();
			}

			// Token: 0x06000103 RID: 259 RVA: 0x0000A71F File Offset: 0x0000891F
			private List<string> GetMandatoryFieldsAsList()
			{
				return (from field in this.mFields.GetType().GetFields()
				where field.GetValue(this.mFields) != null
				select field).Select(delegate(FieldInfo field)
				{
					object value = field.GetValue(this.mFields);
					string str = field.FieldType.Equals(typeof(DateTime?)) ? ((DateTime)value).ToString("dd.MM.yyyy") : value.ToString();
					return field.Name + "=" + str;
				}).ToList<string>();
			}

			// Token: 0x06000104 RID: 260 RVA: 0x0000A758 File Offset: 0x00008958
			private static string ValidateInput(string input, string fieldname, string pattern, string errorText = null)
			{
				return PayloadGenerator.RussiaPaymentOrder.ValidateInput(input, fieldname, new string[]
				{
					pattern
				}, errorText);
			}

			// Token: 0x06000105 RID: 261 RVA: 0x0000A76C File Offset: 0x0000896C
			private static string ValidateInput(string input, string fieldname, string[] patterns, string errorText = null)
			{
				if (input == null)
				{
					throw new PayloadGenerator.RussiaPaymentOrder.RussiaPaymentOrderException("The input for '" + fieldname + "' must not be null.");
				}
				foreach (string text in patterns)
				{
					if (!Regex.IsMatch(input, text))
					{
						throw new PayloadGenerator.RussiaPaymentOrder.RussiaPaymentOrderException(errorText ?? string.Concat(new string[]
						{
							"The input for '",
							fieldname,
							"' (",
							input,
							") doesn't match the pattern ",
							text
						}));
					}
				}
				return input;
			}

			// Token: 0x040000B7 RID: 183
			private PayloadGenerator.RussiaPaymentOrder.CharacterSets characterSet;

			// Token: 0x040000B8 RID: 184
			private PayloadGenerator.RussiaPaymentOrder.MandatoryFields mFields;

			// Token: 0x040000B9 RID: 185
			private PayloadGenerator.RussiaPaymentOrder.OptionalFields oFields;

			// Token: 0x040000BA RID: 186
			private string separator = "|";

			// Token: 0x0200007F RID: 127
			private class MandatoryFields
			{
				// Token: 0x04000255 RID: 597
				public string Name;

				// Token: 0x04000256 RID: 598
				public string PersonalAcc;

				// Token: 0x04000257 RID: 599
				public string BankName;

				// Token: 0x04000258 RID: 600
				public string BIC;

				// Token: 0x04000259 RID: 601
				public string CorrespAcc;
			}

			// Token: 0x02000080 RID: 128
			public class OptionalFields
			{
				// Token: 0x1700003A RID: 58
				// (get) Token: 0x060001A6 RID: 422 RVA: 0x0000D2F4 File Offset: 0x0000B4F4
				// (set) Token: 0x060001A7 RID: 423 RVA: 0x0000D2FC File Offset: 0x0000B4FC
				public string Sum
				{
					get
					{
						return this._sum;
					}
					set
					{
						this._sum = PayloadGenerator.RussiaPaymentOrder.ValidateInput(value, "Sum", "^\\d{1,18}$", null);
					}
				}

				// Token: 0x1700003B RID: 59
				// (get) Token: 0x060001A8 RID: 424 RVA: 0x0000D315 File Offset: 0x0000B515
				// (set) Token: 0x060001A9 RID: 425 RVA: 0x0000D31D File Offset: 0x0000B51D
				public string Purpose
				{
					get
					{
						return this._purpose;
					}
					set
					{
						this._purpose = PayloadGenerator.RussiaPaymentOrder.ValidateInput(value, "Purpose", "^.{1,160}$", null);
					}
				}

				// Token: 0x1700003C RID: 60
				// (get) Token: 0x060001AA RID: 426 RVA: 0x0000D336 File Offset: 0x0000B536
				// (set) Token: 0x060001AB RID: 427 RVA: 0x0000D33E File Offset: 0x0000B53E
				public string PayeeINN
				{
					get
					{
						return this._payeeInn;
					}
					set
					{
						this._payeeInn = PayloadGenerator.RussiaPaymentOrder.ValidateInput(value, "PayeeINN", "^.{1,12}$", null);
					}
				}

				// Token: 0x1700003D RID: 61
				// (get) Token: 0x060001AC RID: 428 RVA: 0x0000D357 File Offset: 0x0000B557
				// (set) Token: 0x060001AD RID: 429 RVA: 0x0000D35F File Offset: 0x0000B55F
				public string PayerINN
				{
					get
					{
						return this._payerInn;
					}
					set
					{
						this._payerInn = PayloadGenerator.RussiaPaymentOrder.ValidateInput(value, "PayerINN", "^.{1,12}$", null);
					}
				}

				// Token: 0x1700003E RID: 62
				// (get) Token: 0x060001AE RID: 430 RVA: 0x0000D378 File Offset: 0x0000B578
				// (set) Token: 0x060001AF RID: 431 RVA: 0x0000D380 File Offset: 0x0000B580
				public string DrawerStatus
				{
					get
					{
						return this._drawerStatus;
					}
					set
					{
						this._drawerStatus = PayloadGenerator.RussiaPaymentOrder.ValidateInput(value, "DrawerStatus", "^.{1,2}$", null);
					}
				}

				// Token: 0x1700003F RID: 63
				// (get) Token: 0x060001B0 RID: 432 RVA: 0x0000D399 File Offset: 0x0000B599
				// (set) Token: 0x060001B1 RID: 433 RVA: 0x0000D3A1 File Offset: 0x0000B5A1
				public string KPP
				{
					get
					{
						return this._kpp;
					}
					set
					{
						this._kpp = PayloadGenerator.RussiaPaymentOrder.ValidateInput(value, "KPP", "^.{1,9}$", null);
					}
				}

				// Token: 0x17000040 RID: 64
				// (get) Token: 0x060001B2 RID: 434 RVA: 0x0000D3BA File Offset: 0x0000B5BA
				// (set) Token: 0x060001B3 RID: 435 RVA: 0x0000D3C2 File Offset: 0x0000B5C2
				public string CBC
				{
					get
					{
						return this._cbc;
					}
					set
					{
						this._cbc = PayloadGenerator.RussiaPaymentOrder.ValidateInput(value, "CBC", "^.{1,20}$", null);
					}
				}

				// Token: 0x17000041 RID: 65
				// (get) Token: 0x060001B4 RID: 436 RVA: 0x0000D3DB File Offset: 0x0000B5DB
				// (set) Token: 0x060001B5 RID: 437 RVA: 0x0000D3E3 File Offset: 0x0000B5E3
				public string OKTMO
				{
					get
					{
						return this._oktmo;
					}
					set
					{
						this._oktmo = PayloadGenerator.RussiaPaymentOrder.ValidateInput(value, "OKTMO", "^.{1,11}$", null);
					}
				}

				// Token: 0x17000042 RID: 66
				// (get) Token: 0x060001B6 RID: 438 RVA: 0x0000D3FC File Offset: 0x0000B5FC
				// (set) Token: 0x060001B7 RID: 439 RVA: 0x0000D404 File Offset: 0x0000B604
				public string PaytReason
				{
					get
					{
						return this._paytReason;
					}
					set
					{
						this._paytReason = PayloadGenerator.RussiaPaymentOrder.ValidateInput(value, "PaytReason", "^.{1,2}$", null);
					}
				}

				// Token: 0x17000043 RID: 67
				// (get) Token: 0x060001B8 RID: 440 RVA: 0x0000D41D File Offset: 0x0000B61D
				// (set) Token: 0x060001B9 RID: 441 RVA: 0x0000D425 File Offset: 0x0000B625
				public string TaxPeriod
				{
					get
					{
						return this._taxPeriod;
					}
					set
					{
						this._taxPeriod = PayloadGenerator.RussiaPaymentOrder.ValidateInput(value, "ТaxPeriod", "^.{1,10}$", null);
					}
				}

				// Token: 0x17000044 RID: 68
				// (get) Token: 0x060001BA RID: 442 RVA: 0x0000D43E File Offset: 0x0000B63E
				// (set) Token: 0x060001BB RID: 443 RVA: 0x0000D446 File Offset: 0x0000B646
				public string DocNo
				{
					get
					{
						return this._docNo;
					}
					set
					{
						this._docNo = PayloadGenerator.RussiaPaymentOrder.ValidateInput(value, "DocNo", "^.{1,15}$", null);
					}
				}

				// Token: 0x17000045 RID: 69
				// (get) Token: 0x060001BC RID: 444 RVA: 0x0000D45F File Offset: 0x0000B65F
				// (set) Token: 0x060001BD RID: 445 RVA: 0x0000D467 File Offset: 0x0000B667
				public DateTime? DocDate { get; set; }

				// Token: 0x17000046 RID: 70
				// (get) Token: 0x060001BE RID: 446 RVA: 0x0000D470 File Offset: 0x0000B670
				// (set) Token: 0x060001BF RID: 447 RVA: 0x0000D478 File Offset: 0x0000B678
				public string TaxPaytKind
				{
					get
					{
						return this._taxPaytKind;
					}
					set
					{
						this._taxPaytKind = PayloadGenerator.RussiaPaymentOrder.ValidateInput(value, "TaxPaytKind", "^.{1,2}$", null);
					}
				}

				// Token: 0x17000047 RID: 71
				// (get) Token: 0x060001C0 RID: 448 RVA: 0x0000D491 File Offset: 0x0000B691
				// (set) Token: 0x060001C1 RID: 449 RVA: 0x0000D499 File Offset: 0x0000B699
				public string LastName { get; set; }

				// Token: 0x17000048 RID: 72
				// (get) Token: 0x060001C2 RID: 450 RVA: 0x0000D4A2 File Offset: 0x0000B6A2
				// (set) Token: 0x060001C3 RID: 451 RVA: 0x0000D4AA File Offset: 0x0000B6AA
				public string FirstName { get; set; }

				// Token: 0x17000049 RID: 73
				// (get) Token: 0x060001C4 RID: 452 RVA: 0x0000D4B3 File Offset: 0x0000B6B3
				// (set) Token: 0x060001C5 RID: 453 RVA: 0x0000D4BB File Offset: 0x0000B6BB
				public string MiddleName { get; set; }

				// Token: 0x1700004A RID: 74
				// (get) Token: 0x060001C6 RID: 454 RVA: 0x0000D4C4 File Offset: 0x0000B6C4
				// (set) Token: 0x060001C7 RID: 455 RVA: 0x0000D4CC File Offset: 0x0000B6CC
				public string PayerAddress { get; set; }

				// Token: 0x1700004B RID: 75
				// (get) Token: 0x060001C8 RID: 456 RVA: 0x0000D4D5 File Offset: 0x0000B6D5
				// (set) Token: 0x060001C9 RID: 457 RVA: 0x0000D4DD File Offset: 0x0000B6DD
				public string PersonalAccount { get; set; }

				// Token: 0x1700004C RID: 76
				// (get) Token: 0x060001CA RID: 458 RVA: 0x0000D4E6 File Offset: 0x0000B6E6
				// (set) Token: 0x060001CB RID: 459 RVA: 0x0000D4EE File Offset: 0x0000B6EE
				public string DocIdx { get; set; }

				// Token: 0x1700004D RID: 77
				// (get) Token: 0x060001CC RID: 460 RVA: 0x0000D4F7 File Offset: 0x0000B6F7
				// (set) Token: 0x060001CD RID: 461 RVA: 0x0000D4FF File Offset: 0x0000B6FF
				public string PensAcc { get; set; }

				// Token: 0x1700004E RID: 78
				// (get) Token: 0x060001CE RID: 462 RVA: 0x0000D508 File Offset: 0x0000B708
				// (set) Token: 0x060001CF RID: 463 RVA: 0x0000D510 File Offset: 0x0000B710
				public string Contract { get; set; }

				// Token: 0x1700004F RID: 79
				// (get) Token: 0x060001D0 RID: 464 RVA: 0x0000D519 File Offset: 0x0000B719
				// (set) Token: 0x060001D1 RID: 465 RVA: 0x0000D521 File Offset: 0x0000B721
				public string PersAcc { get; set; }

				// Token: 0x17000050 RID: 80
				// (get) Token: 0x060001D2 RID: 466 RVA: 0x0000D52A File Offset: 0x0000B72A
				// (set) Token: 0x060001D3 RID: 467 RVA: 0x0000D532 File Offset: 0x0000B732
				public string Flat { get; set; }

				// Token: 0x17000051 RID: 81
				// (get) Token: 0x060001D4 RID: 468 RVA: 0x0000D53B File Offset: 0x0000B73B
				// (set) Token: 0x060001D5 RID: 469 RVA: 0x0000D543 File Offset: 0x0000B743
				public string Phone { get; set; }

				// Token: 0x17000052 RID: 82
				// (get) Token: 0x060001D6 RID: 470 RVA: 0x0000D54C File Offset: 0x0000B74C
				// (set) Token: 0x060001D7 RID: 471 RVA: 0x0000D554 File Offset: 0x0000B754
				public string PayerIdType { get; set; }

				// Token: 0x17000053 RID: 83
				// (get) Token: 0x060001D8 RID: 472 RVA: 0x0000D55D File Offset: 0x0000B75D
				// (set) Token: 0x060001D9 RID: 473 RVA: 0x0000D565 File Offset: 0x0000B765
				public string PayerIdNum { get; set; }

				// Token: 0x17000054 RID: 84
				// (get) Token: 0x060001DA RID: 474 RVA: 0x0000D56E File Offset: 0x0000B76E
				// (set) Token: 0x060001DB RID: 475 RVA: 0x0000D576 File Offset: 0x0000B776
				public string ChildFio { get; set; }

				// Token: 0x17000055 RID: 85
				// (get) Token: 0x060001DC RID: 476 RVA: 0x0000D57F File Offset: 0x0000B77F
				// (set) Token: 0x060001DD RID: 477 RVA: 0x0000D587 File Offset: 0x0000B787
				public DateTime? BirthDate { get; set; }

				// Token: 0x17000056 RID: 86
				// (get) Token: 0x060001DE RID: 478 RVA: 0x0000D590 File Offset: 0x0000B790
				// (set) Token: 0x060001DF RID: 479 RVA: 0x0000D598 File Offset: 0x0000B798
				public string PaymTerm { get; set; }

				// Token: 0x17000057 RID: 87
				// (get) Token: 0x060001E0 RID: 480 RVA: 0x0000D5A1 File Offset: 0x0000B7A1
				// (set) Token: 0x060001E1 RID: 481 RVA: 0x0000D5A9 File Offset: 0x0000B7A9
				public string PaymPeriod { get; set; }

				// Token: 0x17000058 RID: 88
				// (get) Token: 0x060001E2 RID: 482 RVA: 0x0000D5B2 File Offset: 0x0000B7B2
				// (set) Token: 0x060001E3 RID: 483 RVA: 0x0000D5BA File Offset: 0x0000B7BA
				public string Category { get; set; }

				// Token: 0x17000059 RID: 89
				// (get) Token: 0x060001E4 RID: 484 RVA: 0x0000D5C3 File Offset: 0x0000B7C3
				// (set) Token: 0x060001E5 RID: 485 RVA: 0x0000D5CB File Offset: 0x0000B7CB
				public string ServiceName { get; set; }

				// Token: 0x1700005A RID: 90
				// (get) Token: 0x060001E6 RID: 486 RVA: 0x0000D5D4 File Offset: 0x0000B7D4
				// (set) Token: 0x060001E7 RID: 487 RVA: 0x0000D5DC File Offset: 0x0000B7DC
				public string CounterId { get; set; }

				// Token: 0x1700005B RID: 91
				// (get) Token: 0x060001E8 RID: 488 RVA: 0x0000D5E5 File Offset: 0x0000B7E5
				// (set) Token: 0x060001E9 RID: 489 RVA: 0x0000D5ED File Offset: 0x0000B7ED
				public string CounterVal { get; set; }

				// Token: 0x1700005C RID: 92
				// (get) Token: 0x060001EA RID: 490 RVA: 0x0000D5F6 File Offset: 0x0000B7F6
				// (set) Token: 0x060001EB RID: 491 RVA: 0x0000D5FE File Offset: 0x0000B7FE
				public string QuittId { get; set; }

				// Token: 0x1700005D RID: 93
				// (get) Token: 0x060001EC RID: 492 RVA: 0x0000D607 File Offset: 0x0000B807
				// (set) Token: 0x060001ED RID: 493 RVA: 0x0000D60F File Offset: 0x0000B80F
				public DateTime? QuittDate { get; set; }

				// Token: 0x1700005E RID: 94
				// (get) Token: 0x060001EE RID: 494 RVA: 0x0000D618 File Offset: 0x0000B818
				// (set) Token: 0x060001EF RID: 495 RVA: 0x0000D620 File Offset: 0x0000B820
				public string InstNum { get; set; }

				// Token: 0x1700005F RID: 95
				// (get) Token: 0x060001F0 RID: 496 RVA: 0x0000D629 File Offset: 0x0000B829
				// (set) Token: 0x060001F1 RID: 497 RVA: 0x0000D631 File Offset: 0x0000B831
				public string ClassNum { get; set; }

				// Token: 0x17000060 RID: 96
				// (get) Token: 0x060001F2 RID: 498 RVA: 0x0000D63A File Offset: 0x0000B83A
				// (set) Token: 0x060001F3 RID: 499 RVA: 0x0000D642 File Offset: 0x0000B842
				public string SpecFio { get; set; }

				// Token: 0x17000061 RID: 97
				// (get) Token: 0x060001F4 RID: 500 RVA: 0x0000D64B File Offset: 0x0000B84B
				// (set) Token: 0x060001F5 RID: 501 RVA: 0x0000D653 File Offset: 0x0000B853
				public string AddAmount { get; set; }

				// Token: 0x17000062 RID: 98
				// (get) Token: 0x060001F6 RID: 502 RVA: 0x0000D65C File Offset: 0x0000B85C
				// (set) Token: 0x060001F7 RID: 503 RVA: 0x0000D664 File Offset: 0x0000B864
				public string RuleId { get; set; }

				// Token: 0x17000063 RID: 99
				// (get) Token: 0x060001F8 RID: 504 RVA: 0x0000D66D File Offset: 0x0000B86D
				// (set) Token: 0x060001F9 RID: 505 RVA: 0x0000D675 File Offset: 0x0000B875
				public string ExecId { get; set; }

				// Token: 0x17000064 RID: 100
				// (get) Token: 0x060001FA RID: 506 RVA: 0x0000D67E File Offset: 0x0000B87E
				// (set) Token: 0x060001FB RID: 507 RVA: 0x0000D686 File Offset: 0x0000B886
				public string RegType { get; set; }

				// Token: 0x17000065 RID: 101
				// (get) Token: 0x060001FC RID: 508 RVA: 0x0000D68F File Offset: 0x0000B88F
				// (set) Token: 0x060001FD RID: 509 RVA: 0x0000D697 File Offset: 0x0000B897
				public string UIN { get; set; }

				// Token: 0x17000066 RID: 102
				// (get) Token: 0x060001FE RID: 510 RVA: 0x0000D6A0 File Offset: 0x0000B8A0
				// (set) Token: 0x060001FF RID: 511 RVA: 0x0000D6A8 File Offset: 0x0000B8A8
				public PayloadGenerator.RussiaPaymentOrder.TechCode? TechCode { get; set; }

				// Token: 0x0400025A RID: 602
				private string _sum;

				// Token: 0x0400025B RID: 603
				private string _purpose;

				// Token: 0x0400025C RID: 604
				private string _payeeInn;

				// Token: 0x0400025D RID: 605
				private string _payerInn;

				// Token: 0x0400025E RID: 606
				private string _drawerStatus;

				// Token: 0x0400025F RID: 607
				private string _kpp;

				// Token: 0x04000260 RID: 608
				private string _cbc;

				// Token: 0x04000261 RID: 609
				private string _oktmo;

				// Token: 0x04000262 RID: 610
				private string _paytReason;

				// Token: 0x04000263 RID: 611
				private string _taxPeriod;

				// Token: 0x04000264 RID: 612
				private string _docNo;

				// Token: 0x04000266 RID: 614
				private string _taxPaytKind;
			}

			// Token: 0x02000081 RID: 129
			public enum TechCode
			{
				// Token: 0x04000288 RID: 648
				Мобильная_связь_стационарный_телефон = 1,
				// Token: 0x04000289 RID: 649
				Коммунальные_услуги_ЖКХAFN,
				// Token: 0x0400028A RID: 650
				ГИБДД_налоги_пошлины_бюджетные_платежи,
				// Token: 0x0400028B RID: 651
				Охранные_услуги,
				// Token: 0x0400028C RID: 652
				Услуги_оказываемые_УФМС,
				// Token: 0x0400028D RID: 653
				ПФР,
				// Token: 0x0400028E RID: 654
				Погашение_кредитов,
				// Token: 0x0400028F RID: 655
				Образовательные_учреждения,
				// Token: 0x04000290 RID: 656
				Интернет_и_ТВ,
				// Token: 0x04000291 RID: 657
				Электронные_деньги,
				// Token: 0x04000292 RID: 658
				Отдых_и_путешествия,
				// Token: 0x04000293 RID: 659
				Инвестиции_и_страхование,
				// Token: 0x04000294 RID: 660
				Спорт_и_здоровье,
				// Token: 0x04000295 RID: 661
				Благотворительные_и_общественные_организации,
				// Token: 0x04000296 RID: 662
				Прочие_услуги
			}

			// Token: 0x02000082 RID: 130
			public enum CharacterSets
			{
				// Token: 0x04000298 RID: 664
				windows_1251 = 1,
				// Token: 0x04000299 RID: 665
				utf_8,
				// Token: 0x0400029A RID: 666
				koi8_r
			}

			// Token: 0x02000083 RID: 131
			public class RussiaPaymentOrderException : Exception
			{
				// Token: 0x06000201 RID: 513 RVA: 0x0000D6B9 File Offset: 0x0000B8B9
				public RussiaPaymentOrderException(string message) : base(message)
				{
				}
			}
		}
	}
}
