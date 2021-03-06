using System;
using GeneXus.Mail.Internals;
using GeneXus.Configuration;

namespace GeneXus.Mail
{
	
	public class GXPOP3Session : GXMailSession
	{
		private IPOP3Session session;
		private short secure;
		private short newMessages;        

		public GXPOP3Session()
		{
            string openPop = string.Empty;
            Config.GetValueOf("OpenPOP",out openPop);
            if (!Environment.Is64BitProcess && string.IsNullOrEmpty(openPop))
            {
                session = new POP3Session();
            }
            else
            {
                session = new POP3SessionOpenPop();
            }           			
			secure = 0;
			newMessages = 1;
		}

		public string AttachDir
		{
			get
			{
				return session.AttachDir;
			}
			set
			{
				session.AttachDir = value;
			}
		}

		public short Secure
		{
			get
			{
				return secure;
			}
			set
			{
				secure = value;
			}
		}

		public int Count
		{
			get
			{
                return session.GetMessageCount();
			}
		}

		public string Host
		{
			get
			{
				return session.Host;
			}
			set
			{
				session.Host = value;
			}
		}

		public short NewMessages
		{
			get
			{
				return newMessages;
			}
			set
			{
				newMessages = value;
			}
		}

		public string UserName
		{
			get
			{
				return session.UserName;
			}
			set
			{
				session.UserName = value;
			}
		}

		public string Password
		{
            get
            {
                return session.Password;
            }
            set
			{
				session.Password = value;
			}
		}

		public int Port
		{
			get
			{
				return session.Port;
			}
			set
			{
				session.Port = value;
			}
		}

		public short Timeout
		{
			get
			{
				return (short)session.Timeout;
			}
			set
			{
				session.Timeout = value;
			}
		}

		public short Delete()
		{
			ResetError();
			session.Delete(this);
			return errorCode;
		}

		public short GetNextUID(ref string nextUID)
		{
			ResetError();
            nextUID = session.GetNextUID(this);
			return errorCode;
		}

		public short Login()
		{
			ResetError();
			session.Login(this);
			return errorCode;
		}

		public short Logout()
		{
			session.Logout(this);
			return errorCode;
		}

		public short Receive(GXMailMessage msg)
		{
			ResetError();
			session.Receive(this, msg);
			return errorCode;
		}

		public short Skip()
		{
			ResetError();
			session.Skip(this);
			return errorCode;
		}
	}
}
