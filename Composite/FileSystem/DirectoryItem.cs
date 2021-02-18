using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositeDesignPattern.FileItem
{
    public class DirectoryItem : FileSystemItem, IComposite
    {
        public IList<FileSystemItem> Items { get; } = new List<FileSystemItem>();

        public DirectoryItem(string name) : base(name)
        { 
        }
        public override decimal GetSizeInKiloBytes()
        {
            // Sum up all items in the collection
            return Items.Sum(x => x.GetSizeInKiloBytes());
        }

        public void Add(FileSystemItem f)
        {
            Items.Add(f);
        }

        public void Remove(FileSystemItem f)
        {
            if (Items.Contains(f))
                Items.Remove(f);
        }
    }
}