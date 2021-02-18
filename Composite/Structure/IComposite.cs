namespace CompositeDesignPattern.Structure
{
    public interface IComposite
    {
        void Add(Component c);
        void Remove(Component c);
        void PrimaryOperation(int depth);
    }
}