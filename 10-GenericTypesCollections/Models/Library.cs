using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_GenericTypesCollections.Models
{
    internal class Library<T>where T : Book
    {
        public List<T> Items { get; set; }
        public string Name { get; set; }

        public Library()
        {
            Items = new List<T>();
        }

        public Library(string name):this()
        {
            Name = name;
        }

        public void Add(T item)
        {
            Items.Add(item);
            Console.WriteLine($"{item.Title} Elave edildi");
        }

        public void Remove(T item)
        {
            Items.Remove(item);
            Console.WriteLine("Silindi");
        }

        public List<T> GetAll()
        {
            return Items;
        }

        public int Count()
        {
            return Items.Count;
        }

        public T FindByIndex(int index)
        {
            if(index >= 0 && index < Items.Count) return Items[index];
            else return default(T);
        }
    }
}
