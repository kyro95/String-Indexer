using System;
using System.Collections.Generic;

namespace Indexer
{
    public class Storage
    {
        public Storage(string _key = "") { Key = _key;}
        public string Key { get; set; }
        public int Index { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public string Str { get; set; } = "";
        public string NewStr { get; set; } = "";
        public IEnumerator<Storage> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}