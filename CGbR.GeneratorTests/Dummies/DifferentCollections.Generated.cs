/*
 * This code was generated by the CGbR generator on 25.04.2016. Any manual changes will be lost on the next build.
 * 
 * For questions or bug reports please refer to https://github.com/Toxantron/CGbR or contact the distributor of the
 * 3rd party generator target.
 */
using CGbR.Lib;
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
    public partial class DifferentCollections : IByteSerializable
    {
        #region BinarySerializer

        /// <summary>
        /// Binary size of the object
        /// </summary>
        public int Size
        {
            get 
            { 
                var size = 12;
                // Add size for collections and strings
                size += Integers == null ? 0 : Integers.Count() * 4;
                size += Doubles == null ? 0 : Doubles.Count * 8;
                size += Longs == null ? 0 : Longs.Length * 8;
                size += MultiDimension == null ? 0 : MultiDimension.Length * 4;
                size += Names == null ? 0 : Names.Count;
  
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
        void IByteSerializable.ToBytes(byte[] bytes, ref int index)
        {
            ToBytes(bytes, ref index);
        }

        /// <summary>
        /// Convert object to bytes within object tree
        /// </summary>
        public byte[] ToBytes(byte[] bytes, ref int index)
        {
            if (index + Size > bytes.Length)
                throw new ArgumentOutOfRangeException("index", "Object does not fit in array");

            // Convert Integers
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(Integers == null ? 0 : Integers.Count()), bytes, index);
            index += 2;
            if (Integers != null)
            {
                foreach(var value in Integers)
                {
            		GeneratorByteConverter.Include(value, bytes, index);
            		index += 4;
                }
            }
            // Convert Doubles
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(Doubles == null ? 0 : Doubles.Count), bytes, index);
            index += 2;
            if (Doubles != null)
            {
                for(var i = 0; i < Doubles.Count; i++)
                {
                    var value = Doubles[i];
            		GeneratorByteConverter.Include(value, bytes, index);
            		index += 8;
                }
            }
            // Convert Longs
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(Longs == null ? 0 : Longs.Length), bytes, index);
            index += 2;
            if (Longs != null)
            {
                for(var i = 0; i < Longs.GetLength(0); i++)
                {
                    var value = Longs[i];
            		GeneratorByteConverter.Include(value, bytes, index);
            		index += 8;
                }
            }
            // Convert MultiDimension
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(MultiDimension == null ? 0 : MultiDimension.GetLength(0)), bytes, index);
            index += 2;
            GeneratorByteConverter.Include((ushort)(MultiDimension == null ? 0 : MultiDimension.GetLength(1)), bytes, index);
            index += 2;
            if (MultiDimension != null)
            {
                for(var i = 0; i < MultiDimension.GetLength(0); i++)
                for(var j = 0; j < MultiDimension.GetLength(1); j++)
                {
                    var value = MultiDimension[i,j];
            		GeneratorByteConverter.Include(value, bytes, index);
            		index += 4;
                }
            }
            // Convert Names
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(Names == null ? 0 : Names.Count), bytes, index);
            index += 2;
            if (Names != null)
            {
                foreach(var value in Names)
                {
            		GeneratorByteConverter.Include(value, bytes, ref index);
                }
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
        void IByteSerializable.FromBytes(byte[] bytes, ref int index)
        {
            FromBytes(bytes, ref index);
        }

        /// <summary>
        /// Create object from segment in byte array
        /// </summary>
        public DifferentCollections FromBytes(byte[] bytes, ref int index)
        {
            // Read Integers
            var integersLength = BitConverter.ToUInt16(bytes, index);
            index += 2;
            var tempIntegers = new List<int>(integersLength);
            for (var i = 0; i < integersLength; i++)
            {
            	var value = BitConverter.ToInt32(bytes, index);
            	index += 4;
                tempIntegers.Add(value);
            }
            Integers = tempIntegers;
            // Read Doubles
            var doublesLength = BitConverter.ToUInt16(bytes, index);
            index += 2;
            var tempDoubles = new List<double>(doublesLength);
            for (var i = 0; i < doublesLength; i++)
            {
            	var value = BitConverter.ToDouble(bytes, index);
            	index += 8;
                tempDoubles.Add(value);
            }
            Doubles = tempDoubles;
            // Read Longs
            var longsLength = BitConverter.ToUInt16(bytes, index);
            index += 2;
            var tempLongs = new long[longsLength];
            for (var i = 0; i < longsLength; i++)
            {
            	var value = BitConverter.ToInt64(bytes, index);
            	index += 8;
                tempLongs[i] = value;
            }
            Longs = tempLongs;
            // Read MultiDimension
            var multidimensionLength = BitConverter.ToUInt16(bytes, index);
            index += 2;
            var multidimensionWidth = BitConverter.ToUInt16(bytes, index);
            index += 2;
            var tempMultiDimension = new uint[multidimensionLength,multidimensionWidth];
            for (var i = 0; i < multidimensionLength; i++)
            for (var j = 0; j < multidimensionWidth; j++)
            {
            	var value = BitConverter.ToUInt32(bytes, index);
            	index += 4;
                tempMultiDimension[i,j] = value;
            }
            MultiDimension = tempMultiDimension;
            // Read Names
            var namesLength = BitConverter.ToUInt16(bytes, index);
            index += 2;
            var tempNames = new List<string>(namesLength);
            for (var i = 0; i < namesLength; i++)
            {
            	var value = GeneratorByteConverter.GetString(bytes, ref index);
                tempNames.Add(value);
            }
            Names = tempNames;

            return this;
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
            {
                writer.Write("null");
            }
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
            {
                writer.Write("null");
            }
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
            {
                writer.Write("null");
            }
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
    
            writer.Write(",\"MultiDimension\":");
            if (MultiDimension == null)
            {
                writer.Write("null");
            }
            else
            {
                writer.Write('[');
                foreach (var value in MultiDimension)
                {
            		writer.Write(value.ToString(CultureInfo.InvariantCulture));
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write(",\"Names\":");
            if (Names == null)
            {
                writer.Write("null");
            }
            else
            {
                writer.Write('[');
                foreach (var value in Names)
                {
            		writer.Write(string.Format("\"{0}\"", value));
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

                    case "MultiDimension":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var multidimension = new List<uint>();
                        while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                            multidimension.Add(Convert.ToUInt32(reader.Value));
                        // TODO: MultiDimension = multidimension.ToArray();<-- Figure this out!
                        break;

                    case "Names":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var names = new List<string>();
                        while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                            names.Add(Convert.ToString(reader.Value));
                        Names = names;
                        break;

                }
            }

            return this;
        }

        
        #endregion

    }
}