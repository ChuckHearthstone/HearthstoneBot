using System;
using System.IO;
using System.Security.Cryptography;

namespace HearthstoneBot
{
    class Class41
    {
        public static byte[] smethod_5(byte[] byte_0, byte[] byte_1, byte[] byte_2)
        {
            if (byte_1.Length != 32)
            {
                byte[] array = new byte[32];
                for (int i = 0; i < 32; i++)
                {
                    if (i < byte_1.Length)
                    {
                        array[i] = byte_1[i];
                    }
                    else
                    {
                        array[i] = (byte)i;
                    }
                }
                byte_1 = array;
            }
            if (byte_2.Length != 16)
            {
                byte[] array2 = new byte[16];
                for (int j = 0; j < 16; j++)
                {
                    if (j < byte_2.Length)
                    {
                        array2[j] = byte_2[j];
                    }
                    else
                    {
                        array2[j] = (byte)j;
                    }
                }
                byte_2 = array2;
            }
            byte[] result;
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.Key = byte_1;
                rijndaelManaged.IV = byte_2;
                rijndaelManaged.Mode = CipherMode.ECB;
                rijndaelManaged.Padding = PaddingMode.ISO10126;
                using (CryptoStream cryptoStream = new CryptoStream(new MemoryStream(byte_0), rijndaelManaged.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] array3 = new byte[byte_0.Length];
                    int num = cryptoStream.Read(array3, 0, array3.Length);
                    byte[] array4 = new byte[num];
                    Buffer.BlockCopy(array3, 0, array4, 0, num);
                    result = array4;
                }
            }
            return result;
        }
    }
}
