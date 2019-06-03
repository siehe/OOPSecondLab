using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinedOutClasses
{
    [DataContract]
    class Field
    {
        public int Height { get; set; }
        public int Width { get; set; }
        [DataMember]
        public Cell[][] Cells { get; set; }
        public Character Hero { get; set; }

        public Field(int height, int width)
        {
            Height = height;
            Width = width;
            Cells = new Cell[Height][];
        }
    }
}
