using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;

namespace Shotr.Core.Entities
{
    public class dcrypt
    {
        private List<byte[]> key;
        private RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        public dcrypt()
        {
            key = PopulateGraph();
        }

        public dcrypt(string keyfile)
        {
            var x = File.ReadAllBytes(keyfile);
            DeserializeKey(x);
        }

        public dcrypt(byte[] keyfile)
        {
            DeserializeKey(keyfile);
        }

        public byte[] Key => SerializeKey();

        public void NewKey()
        {
            key = PopulateGraph();
        }

        public void WriteKeyToFile(string filepath)
        {
            File.WriteAllBytes(filepath, Key);
        }

        public byte[] Encrypt(byte[] data)
        {
            return Encrypt(data, 0, data.Length);
        }

        public byte[] Encrypt(byte[] data, dcryptCompressionOptions compression)
        {
            return Encrypt(data, 0, data.Length, compression);
        }

        public byte[] Encrypt(byte[] data, int offset, int count, dcryptCompressionOptions compression = dcryptCompressionOptions.NoCompress)
        {
            //compression?
            if (compression == dcryptCompressionOptions.Compress)
            {
                data = Compress(data);
                count = data.Length;
                offset = 0;
            }
            var newdata = new byte[count + 1];
            //start in here.
            var p = new byte[1];
            rng.GetBytes(p);
            var randchr = p[0];
            var chr = key[randchr][randchr];
            for (var i = offset; i < count; i++)
            {
                chr = key[chr][data[i]];
                Buffer.BlockCopy(new[] { chr }, 0, newdata, i, 1);
            }
            //append first byte to end.
            Buffer.BlockCopy(new[] { randchr }, 0, newdata, newdata.Length - 1, 1);
            return newdata;
        }

        public byte[] Decrypt(byte[] data)
        {
            return Decrypt(data, 0, data.Length);
        }

        public byte[] Decrypt(byte[] data, int offset, int count)
        {
            var newdata = new byte[count - 1];
            var chr = data[count - 1];
            chr = key[chr][chr];
            byte xchr = 0x00;
            for (var i = offset; i < count - 1; i++)
            {
                xchr = data[i];
                for (var j = 0; j < 256; j++)
                {
                    if (key[chr][j] == xchr)
                    {
                        Buffer.BlockCopy(new[] { (byte)j }, 0, newdata, i, 1);
                        chr = key[chr][j];
                        break;
                    }
                }
            }
            //check for gzip headers, if it's compressed then attempt to decompress.
            if (newdata.Length > 2 && (newdata[0] == 0x1F && newdata[1] == 0x8B))
                try
                {
                    return Decompress(newdata);
                }
                catch { }
            return newdata;
        }

        private void DeserializeKey(byte[] data)
        {
            if (data.Length != 65536)
                throw new InvalidDataException();
            key = new List<byte[]>();
            var buff = new byte[256];
            for (var j = 0; j < 256; j++)
            {
                Buffer.BlockCopy(data, (j == 0 ? 0 : j * 256), buff, 0, buff.Length);
                //add to list.
                Array.Reverse(buff);
                key.Add(buff);
                buff = new byte[256];
            }
            /*MemoryStream ms = new MemoryStream(Decompress(data));
            key = (List<byte[]>)bin.Deserialize(ms);*/
        }

        private byte[] SerializeKey()
        {
            //write all bytes to a file in order.
            var buff = new byte[65536];
            for (var i = 0; i < key.Count; i++)
            {
                Array.Reverse(key[i]);
                Buffer.BlockCopy(key[i], 0, buff, i * 256, key[i].Length);
            }
            return buff;
            /*MemoryStream ms = new MemoryStream();
            bin.Serialize(ms, key);
            return ms.ToArray();*/
        }

        private List<byte[]> PopulateGraph()
        {
            var x = new List<byte[]>();
            for (var i = 0; i < 256; i++)
            {
                var arr = new byte[256];
                x.Add(arr);
            }

            var ar = new byte[256];
            for (var w = 0; w < ar.Length; w++)
                ar[w] = (byte)w;

            for (var i = 0; i < 256; i++)
            {
                //generate a 255-byte array.
                var p = RearrangeBytes(ar);
                for (var j = 0; j < 256; j++)
                {
                    x[i] = p;
                }
            }
            return x;
        }

        private byte[] Decompress(byte[] key)
        {
            Stream stream = new MemoryStream(key);
            using (var decompress = new GZipStream(stream, CompressionMode.Decompress, false))
            {
                try
                {
                    const int size = 1024;
                    var buffer = new byte[size];
                    using (var memory = new MemoryStream())
                    {
                        var count = 0;
                        do
                        {
                            count = decompress.Read(buffer, 0, size);
                            if (count > 0)
                            {
                                memory.Write(buffer, 0, count);
                            }
                        }
                        while (count > 0);
                        return memory.ToArray();
                    }
                }
                catch
                {
                    throw new InvalidDataException();
                }
            }
        }

        private byte[] Compress(byte[] data)
        {
            using (var memory = new MemoryStream())
            {
                using (var gzip = new GZipStream(memory, CompressionMode.Compress, false))
                {
                    gzip.Write(data, 0, data.Length);
                }
                return memory.ToArray();
            }
        }

        private byte[] RearrangeBytes(byte[] arr)
        {
            var w = new List<byte>();
            //populate w with arr.
            for (var i = 0; i < arr.Length; i++)
                w.Add(arr[i]);

            var newarr = new byte[256];
            var dstOffset = 0;
            while (true)
            {
                var p = new byte[1];
                rng.GetBytes(p);
                var f = w[p[0] % w.Count];
                w.Remove(f);
                Buffer.BlockCopy(new[] { f }, 0, newarr, dstOffset, 1);
                dstOffset++;
                if (w.Count == 0)
                    break;
            }
            return newarr;
        }

        public static string ToHex(int value)
        {
            return String.Format("0x{0:X}", value);
        }
    }

    public enum dcryptCompressionOptions
    {
        Compress = 0x1,
        NoCompress = 0x0
    }
}