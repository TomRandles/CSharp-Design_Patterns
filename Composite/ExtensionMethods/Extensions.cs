using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CompositeDesignPattern.ExtensionMethods
{
    public static class Extensions
    {
        // Very flexible - can pass in any predicate. Makes FindElements flexible. 
        // Multi-purpose and reusable
        public static IEnumerable<XElement> FindElements(this XElement root, Predicate<XElement> predicate )
        {
            // Algorithm to iterate a hierarchical stack and search for an element
            var elementStack = new Stack<XElement>();
            elementStack.Push(root);

            while (elementStack.Any())
            {
                var currentElement = elementStack.Pop();

                foreach (var element in currentElement.Elements())
                {
                    elementStack.Push(element);
                }
                if (predicate(currentElement))
                {
                    yield return currentElement;
                }
            }
        }
    }
}