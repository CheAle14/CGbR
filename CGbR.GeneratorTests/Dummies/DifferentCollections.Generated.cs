/*
 * This code was generated by the CGbR generator on 08.04.2016. Any manual changes will be lost on the next build.
 * 
 * For questions or bug reports please refer to https://github.com/Toxantron/CGbR or contact the distributor of the
 * 3rd party generator target.
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CGbR.GeneratorTests
{
    /// <summary>
    /// Auto generated class by CGbR project
    /// </summary>
    public partial class DifferentCollections
    {
        #region BinarySerializer

        private static Encoding _encoder = new UTF8Encoding();

        /// <summary>
        /// Binary size of the object
        /// </summary>
        public int Size
        {
            get 
            { 
                var size = 6;
                // Add size for collections and strings
                size += Integers.Count() * 4;
                size += Doubles.Count * 8;
                size += Longs.Length * 8;
  
                return size;              
            }
        }

        /// <summary>
        /// Convert object to bytes
        /// </summary>
        public byte[] ToBytes()
        {
            var index = 0;
            var bytes = new byte[Size];

            return ToBytes(bytes, ref index);
        }

        /// <summary>
        /// Convert object to bytes within object tree
        /// </summary>
        public byte[] ToBytes(byte[] bytes, ref int index)
        {
            if (index + Size > bytes.Length)
                throw new ArgumentOutOfRangeException("");
            // Convert Integers
            // Two bytes length information for each dimension
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)(Integers == null ? 0 : Integers.Count())), 0, bytes, index, 2);
            index += 2;
            // Skip null collections
            if (Integers != null)
            foreach(var value in Integers)
            {
            	Buffer.BlockCopy(BitConverter.GetBytes(value), 0, bytes, index, 4);;
            	index += 4;
            }
            // Convert Doubles
            // Two bytes length information for each dimension
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)(Doubles == null ? 0 : Doubles.Count)), 0, bytes, index, 2);
            index += 2;
            // Skip null collections
            if (Doubles != null)
            for(var i = 0; index < Doubles.Count; index++)
            {
                var value = Doubles[i];
            	Buffer.BlockCopy(BitConverter.GetBytes(value), 0, bytes, index, 8);;
            	index += 8;
            }
            // Convert Longs
            // Two bytes length information for each dimension
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)(Longs == null ? 0 : Longs.Length)), 0, bytes, index, 2);
            index += 2;
            // Skip null collections
            if (Longs != null)
            foreach(var value in Longs)
            {
            	Buffer.BlockCopy(BitConverter.GetBytes(value), 0, bytes, index, 8);;
            	index += 8;
            }
            return bytes;
        }

        /// <summary>
        /// Create object from byte array
        /// </summary>
        public DifferentCollections FromBytes(byte[] bytes)
        {
            var index = 0;            
            return FromBytes(bytes, ref index); 
        }

        /// <summary>
        /// Create object from segment in byte array
        /// </summary>
        public DifferentCollections FromBytes(byte[] bytes, ref int index)
        {
            return this;
        }

        /// <summary>
        /// Writer property of type UInt16 to bytes by using pointer opertations
        /// </summary>
        private static unsafe void Include(UInt16 value, byte[] bytes, int index)
        {
            fixed(byte* b = bytes)
                *((UInt16*)(b + index)) = value;
        }
        /// <summary>
        /// Writer property of type Int32 to bytes by using pointer opertations
        /// </summary>
        private static unsafe void Include(Int32 value, byte[] bytes, int index)
        {
            fixed(byte* b = bytes)
                *((Int32*)(b + index)) = value;
        }
        /// <summary>
        /// Writer property of type Double to bytes by using pointer opertations
        /// </summary>
        private static unsafe void Include(Double value, byte[] bytes, int index)
        {
            fixed(byte* b = bytes)
                *((Double*)(b + index)) = value;
        }
        /// <summary>
        /// Writer property of type Int64 to bytes by using pointer opertations
        /// </summary>
        private static unsafe void Include(Int64 value, byte[] bytes, int index)
        {
            fixed(byte* b = bytes)
                *((Int64*)(b + index)) = value;
        }

        
        #endregion

        #region JsonSerializer

        /// <summary>
        /// Convert object to JSON string
        /// </summary>
        public string ToJson()
        {
            var builder = new StringBuilder();
            using(var writer = new StringWriter(builder))
            {
                IncludeJson(writer);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public void IncludeJson(TextWriter writer)
        {
            writer.Write('{');

            writer.Write("\"Integers\":");
            if (Integers == null)
                writer.Write("null");
            else
            {
                writer.Write('[');
                foreach (var value in Integers)
                {
            		writer.Write(value.ToString(CultureInfo.InvariantCulture));
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write(",\"Doubles\":");
            if (Doubles == null)
                writer.Write("null");
            else
            {
                writer.Write('[');
                foreach (var value in Doubles)
                {
            		writer.Write(value.ToString(CultureInfo.InvariantCulture));
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write(",\"Longs\":");
            if (Longs == null)
                writer.Write("null");
            else
            {
                writer.Write('[');
                foreach (var value in Longs)
                {
            		writer.Write(value.ToString(CultureInfo.InvariantCulture));
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write('}');
        }

        /// <summary>
        /// Convert object to JSON string
        /// </summary>
        public DifferentCollections FromJson(string json)
        {
            using (var reader = new JsonTextReader(new StringReader(json)))
            {
                return FromJson(reader);
            }
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public DifferentCollections FromJson(JsonReader reader)
        {
            while (reader.Read())
            {
                // Break on EndObject
                if (reader.TokenType == JsonToken.EndObject)
                    break;

                // Only look for properties
                if (reader.TokenType != JsonToken.PropertyName)
                    continue;

                switch ((string) reader.Value)
                {
                    case "Integers":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var integers = new List<int>();
                        while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                            integers.Add(Convert.ToInt32(reader.Value));
                        Integers = integers;
                        break;

                    case "Doubles":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var doubles = new List<double>();
                        while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                            doubles.Add(Convert.ToDouble(reader.Value));
                        Doubles = doubles;
                        break;

                    case "Longs":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var longs = new List<long>();
                        while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                            longs.Add(Convert.ToInt64(reader.Value));
                        Longs = longs.ToArray();
                        break;

                }
            }

            return this;
        }

        
        #endregion

    }
}