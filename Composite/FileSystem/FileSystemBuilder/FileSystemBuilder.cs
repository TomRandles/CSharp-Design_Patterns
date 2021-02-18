using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeDesignPattern.FileItem.FileSystemBuilder
{
    public class FileSystemBuilder
    {
        public DirectoryItem RootDirectory { get; }

        private DirectoryItem _currentDirectory;

        public FileSystemBuilder(string rootDirectory)
        {
            RootDirectory = new DirectoryItem(rootDirectory);
            _currentDirectory = RootDirectory;
        }

        public DirectoryItem AddDirectory(string newDirectoryName)
        {
            var newDIrectoryItem = new DirectoryItem(newDirectoryName);
            _currentDirectory.Add(newDIrectoryItem);
            _currentDirectory = newDIrectoryItem;
            return newDIrectoryItem;
        }

        public FileItem AddFile(string newFileName, long fileBytes)
        {
            var newFileItem = new FileItem(newFileName, fileBytes);
            _currentDirectory.Add(newFileItem);
            return newFileItem;
        }

        public DirectoryItem SetCurrentDirectory(string directoryName)
        {
            // The following is a useful algorithm for iterating through a hierarchical 
            // tree structure without recursion.

            // Need to be able to iterate and search through the existing composite
            //Iterative stack based solution
            var directoryStack = new Stack<DirectoryItem>();
            
            // Sets the stack at the root of the composite
            directoryStack.Push(RootDirectory);

            while (directoryStack.Any())
            {
                var current = directoryStack.Pop();
                // Is this the directory we are searching for? 
                if (current.Name == directoryName)
                {
                    // Yes, then set current directory and exit
                    _currentDirectory = current;
                    return current;
                }
                // Push child directory items onto the stack for search also on next loop iteration
                // Focus on directory items only
                foreach (var item in current.Items.OfType<DirectoryItem>())
                {
                    directoryStack.Push(item);
                }
            }
            throw new InvalidOperationException($"Directory name {directoryName} not found.");
        }
    }
}