using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Core.Utils
{
    internal static class SerializeHelper
    {
        internal static byte[] Serialize(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Serializer.NonGeneric.Serialize(stream, obj);
                return stream.ToArray();
            }
        }

        internal static object Deserialize(byte[] buffer, int index, int count, Type type)
        {
            using (MemoryStream stream = new MemoryStream(buffer, index, count))
            {
                return Serializer.NonGeneric.Deserialize(type, stream);
            }
        }
    }
}
