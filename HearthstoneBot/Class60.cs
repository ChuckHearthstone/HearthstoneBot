using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot
{
    class Class60
    {
        public static byte[] smethod_2(byte[] byte_0)
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream(byte_0))
            {
                result = Class60.smethod_3(memoryStream);
            }
            return result;
        }

        public static byte[] smethod_3(Stream stream_0)
        {
            Class52 @class = new Class52();
            stream_0.Seek(0L, SeekOrigin.Begin);
            MemoryStream memoryStream = new MemoryStream();
            byte[] array = new byte[5];
            if (stream_0.Read(array, 0, 5) != 5)
            {
                throw new Exception("input .lzma is too short");
            }
            long num = 0L;
            for (int i = 0; i < 8; i++)
            {
                int num2 = stream_0.ReadByte();
                if (num2 < 0)
                {
                    throw new Exception("Can't Read 1");
                }
                num |= (long)((long)((ulong)((byte)num2)) << 8 * i);
            }
            @class.imethod_1(array);
            long long_ = stream_0.Length - stream_0.Position;
            @class.imethod_0(stream_0, memoryStream, long_, num, null);
            return memoryStream.ToArray();
        }

    }
}
