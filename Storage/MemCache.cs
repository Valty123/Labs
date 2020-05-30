using System;
using System.Collections.Generic;
using System.Linq;
using LAB1.Models;

namespace LAB1.Storage
{
    public class MemCache : IStorage<LAB1Data>
    {
        private object _sync = new object();
        private List<LAB1Data> _memCache = new List<LAB1Data>();
        public LAB1Data this[Guid id] 
        { 
            get
            {
                lock (_sync)
                {
                    if (!Has(id)) throw new IncorrectLAB1DataException($"No LAB1Data with id {id}");

                    return _memCache.Single(x => x.Id == id);
                }
            }
            set
            {
                if (id == Guid.Empty) throw new IncorrectLAB1DataException("Cannot request LAB1Data with an empty id");

                lock (_sync)
                {
                    if (Has(id))
                    {
                        RemoveAt(id);
                    }

                    value.Id = id;
                    _memCache.Add(value);
                }
            }
        }

        public System.Collections.Generic.List<LAB1Data> All => _memCache.Select(x => x).ToList();

        public void Add(LAB1Data value)
        {
            if (value.Id != Guid.Empty) throw new IncorrectLAB1DataException($"Cannot add value with predefined id {value.Id}");

            value.Id = Guid.NewGuid();
            this[value.Id] = value;
        }

        public bool Has(Guid id)
        {
            return _memCache.Any(x => x.Id == id);
        }

        public void RemoveAt(Guid id)
        {
            lock (_sync)
            {
                _memCache.RemoveAll(x => x.Id == id);
            }
        }
    }
}