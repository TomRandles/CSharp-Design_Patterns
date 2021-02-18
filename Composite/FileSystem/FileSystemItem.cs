using System;
using System.Collections.Generic;
using System.Text;

namespace CompositeDesignPattern.FileItem
{
    public abstract class FileSystemItem
    {
        public string Name { get; }
        public FileSystemItem(string name)
        {
            Name = name;
        }

        public abstract decimal GetSizeInKiloBytes();
    }
}
