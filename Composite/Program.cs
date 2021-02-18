using CompositeDesignPattern.ExtensionMethods;
using CompositeDesignPattern.FileItem;
using CompositeDesignPattern.FileItem.FileSystemBuilder;
using CompositeDesignPattern.Structure;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Xml.Linq;

namespace CompositeDesignPattern
{
    class Program
    {
        // Represents client in the Composite Pattern implementation
        static void Main(string[] args)
        {
            // ExampleComposite1();

            // ExampleComposite2();

            // ExampleBuilderComposite();

            // Explore composites in .Net 
            // XElement - XML processing
            XElement xml = XElement.Load(@"XElement\File-system.xml");
            
            // Predicate: interested in elements with no child elements, i.e. composite leaves 
            foreach (var leaf in xml.FindElements(x => !x.HasElements))
            {
                Console.WriteLine($"\t Leaf: {leaf.Attribute("name")}, byte size: {leaf.Attribute("fileBytes")}");
            }
        }

        private static void ExampleBuilderComposite()
        {
            var builder = new FileSystemBuilder("development");
            // More readable
            builder.AddDirectory("project1");
            // Add files to project1
            builder.AddFile("p1f1.txt", 2100);
            builder.AddFile("p1f2.txt", 3100);
            //Add sub-dir to project1 dir
            builder.AddDirectory("sub-dir");
            // Add files to sub-dir
            builder.AddFile("p1f3.txt", 4100);
            builder.AddFile("p1f4.txt", 5100);
            builder.SetCurrentDirectory("development");
            builder.AddDirectory("project2");
            // Add files to project1
            builder.AddFile("p2f1.txt", 6100);
            builder.AddFile("p2f2.txt", 7100);

            Console.WriteLine($"Total size (root) : {builder.RootDirectory.GetSizeInKiloBytes()}");
            // Convert composite hierarchy to json representation
            Console.WriteLine(JsonConvert.SerializeObject(builder.RootDirectory, Formatting.Indented));
        }

        private static void ExampleComposite2()
        {
            var root = new DirectoryItem("development");
            var proj1 = new DirectoryItem("project1");
            var proj2 = new DirectoryItem("project2");
            root.Add(proj1);
            root.Add(proj2);

            proj1.Add(new FileItem.FileItem("p1f1.txt", 2100));
            proj1.Add(new FileItem.FileItem("p1f2.txt", 3100));
            var subDir1 = new DirectoryItem("sub-dir1");
            subDir1.Add(new FileItem.FileItem("p1f3.txt", 4100));
            subDir1.Add(new FileItem.FileItem("p1f4.txt", 5100));
            proj1.Add(subDir1);

            proj2.Add(new FileItem.FileItem("p2f1.txt", 6100));
            proj2.Add(new FileItem.FileItem("p2f2.txt", 7100));

            Console.WriteLine($"Total size (proj2): {proj2.GetSizeInKiloBytes()}");
            Console.WriteLine($"Total size (proj1): {proj1.GetSizeInKiloBytes()}");
            Console.WriteLine($"Total size (root) : {root.GetSizeInKiloBytes()}");
        }

        private static void ExampleComposite1()
        {
            // Create a tree structure
            var root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            var comp1 = new Composite("Composite C1");
            comp1.Add(new Leaf("Leaf C1-A"));
            comp1.Add(new Leaf("Leaf C1-B"));
            var comp2 = new Composite("Composite C2");
            comp2.Add(new Leaf("Leaf C2-A"));
            comp1.Add(comp2);

            root.Add(comp1);
            root.Add(new Leaf("Leaf C"));

            // Add and remove a leaf
            var leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.PrimaryOperation(1);

            // Composite - act on composite at any level
            // Invoke PrimaryOperation on composite and leaf
            comp2.PrimaryOperation(1);
            leaf.PrimaryOperation(1);
        }
    }
}