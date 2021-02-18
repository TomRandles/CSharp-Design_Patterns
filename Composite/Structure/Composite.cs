using System;
using System.Collections.Generic;

namespace CompositeDesignPattern.Structure
{
    public class Composite : Component, IComposite
    {
        public Composite(string name) : base (name)
        {

        }

        private IList<Component> children = new List<Component>();

        public void Add(Component c)
        {
            children.Add(c);
        }

        public override void PrimaryOperation(int depth)
        {
            Console.WriteLine(new String('-', depth) + Name);
            foreach (var c in children)
            {
                c.PrimaryOperation(depth + 2);
            }
        }

        public void Remove(Component c)
        {
            if (children.Contains(c))
            {
                children.Remove(c);
            }
        }
    }
}