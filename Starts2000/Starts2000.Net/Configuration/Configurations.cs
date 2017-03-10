using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Starts2000.Net.Configuration
{
    //public static class Configurations
    //{
    //    public const int DEFAULT_BUFFER_SIZE = 1024;
    //    static readonly NameValueCollection _properties;

    //    static Configurations()
    //    {
    //        try
    //        {
    //            _properties = new NameValueCollection();
    //            ConfigurationSectionGroup sectionGroup = 
    //                ConfigurationManager.OpenExeConfiguration(
    //                ConfigurationUserLevel.None).GetSectionGroup("Starts2000");

    //            if (sectionGroup != null)
    //            {
    //                foreach (ConfigurationSection section in sectionGroup.Sections)
    //                {
    //                    if (section is NetConfigurationSection)
    //                    {
    //                        foreach (SessionConfigurationElement element in ((NetConfigurationSection)section).NCindy)
    //                        {
    //                            _properties.Add(section.SectionInformation.Name + "." + element.Key, element.Value);
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch
    //        {
    //        }
    //    }

    //    public static string Get(string key)
    //    {
    //        if (_properties == null)
    //        {
    //            return null;
    //        }
    //        return _properties.Get(key);
    //    }

    //    public static string Get(string key, string defaultValue)
    //    {
    //        string str = Get(key);
    //        if (str != null)
    //        {
    //            return str;
    //        }
    //        return defaultValue;
    //    }

    //    public static bool GetBoolean(string key, bool defaultValue)
    //    {
    //        string str = Get(key);
    //        if (str != null)
    //        {
    //            try
    //            {
    //                return bool.Parse(str);
    //            }
    //            catch (FormatException)
    //            {
    //            }
    //        }
    //        return defaultValue;
    //    }

    //    public static int GetInt(string key, int defaultValue)
    //    {
    //        string s = Get(key);
    //        if (s != null)
    //        {
    //            try
    //            {
    //                return int.Parse(s);
    //            }
    //            catch (FormatException)
    //            {
    //            }
    //        }
    //        return defaultValue;
    //    }

    //    public static int AcceptorBacklog
    //    {
    //        get
    //        {
    //            return GetInt("Acceptor.Backlog", 100);
    //        }
    //    }

    //    public static string DefaultBufferPoolClass
    //    {
    //        get
    //        {
    //            return Get("Buffer.DefaultBufferPoolClass", "NCindy.Buffer.DefaultBufferPool");
    //        }
    //    }

    //    public static string DefaultDispatcherClass
    //    {
    //        get
    //        {
    //            return Get("Dispatcher.DefaultDispatcherClass", "DefaultDispatcher");
    //        }
    //    }

    //    public static string DefaultPipeSessionClass
    //    {
    //        get
    //        {
    //            return Get("Session.DefaultPipeSessionClass", "PipeSession");
    //        }
    //    }

    //    public static string DefaultTcpAcceptorClass
    //    {
    //        get
    //        {
    //            return Get("Acceptor.DefaultTcpAcceptorClass", "AsyncSocketSessionAcceptor");
    //        }
    //    }

    //    public static string DefaultTcpSessionClass
    //    {
    //        get
    //        {
    //            return Get("Session.DefaultTcpSessionClass", "AsyncSocketSession");
    //        }
    //    }

    //    public static string DefaultUdpSessionClass
    //    {
    //        get
    //        {
    //            return Get("Session.DefaultUdpSessionClass", "AsyncSocketSession");
    //        }
    //    }

    //    public static bool DisableInnerException
    //    {
    //        get
    //        {
    //            return GetBoolean("Global.DisableInnerException", false);
    //        }
    //    }

    //    public static int DispatcherCapacity
    //    {
    //        get
    //        {
    //            return GetInt("Dispatcher.Capacity", 1000);
    //        }
    //    }

    //    public static int DispatcherConcurrent
    //    {
    //        get
    //        {
    //            return GetInt("Dispatcher.Concurrent", 1);
    //        }
    //    }

    //    public static int DispatcherKeepAliveTime
    //    {
    //        get
    //        {
    //            return GetInt("Dispatcher.KeepAliveTime", 5000);
    //        }
    //    }

    //    public static string LoggingLevel
    //    {
    //        get
    //        {
    //            return Get("Global.LoggingLevel", "Error");
    //        }
    //    }

    //    public static int MaxBufferPoolSize
    //    {
    //        get
    //        {
    //            return GetInt("Buffer.MaxBufferPoolSize", 1024);
    //        }
    //    }

    //    public static int ReadPacketSize
    //    {
    //        get
    //        {
    //            return GetInt("Session.ReadPacketSize", 8192);
    //        }
    //    }

    //    public static int ReceiveBufferSize
    //    {
    //        get
    //        {
    //            return GetInt("Session.ReceiveBufferSize", -1);
    //        }
    //    }

    //    public static bool ReuseAcceptorAddress
    //    {
    //        get
    //        {
    //            return GetBoolean("Acceptor.ReuseAddress", false);
    //        }
    //    }

    //    public static bool ReuseSessionAddress
    //    {
    //        get
    //        {
    //            return GetBoolean("Session.ReuseAddress", false);
    //        }
    //    }

    //    public static int SendBufferSize
    //    {
    //        get
    //        {
    //            return GetInt("Session.SendBufferSize", -1);
    //        }
    //    }

    //    public static int SessionTimeout
    //    {
    //        get
    //        {
    //            return GetInt("Session.Timeout", 0);
    //        }
    //    }

    //    public static int SoLinger
    //    {
    //        get
    //        {
    //            return GetInt("Session.SoLinger", -1);
    //        }
    //    }

    //    public static bool TcpNoDelay
    //    {
    //        get
    //        {
    //            return GetBoolean("Session.TcpNoDelay", true);
    //        }
    //    }

    //    public static bool UseLinkedBuffer
    //    {
    //        get
    //        {
    //            return false;
    //        }
    //    }

    //    public static int WritePacketSize
    //    {
    //        get
    //        {
    //            return GetInt("Session.WritePacketSize", 1048576);
    //        }
    //    }
    //}
}
