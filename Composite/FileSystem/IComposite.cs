namespace CompositeDesignPattern.FileItem
{
    public interface IComposite
    {
        void Add(FileSystemItem f);

        void Remove(FileSystemItem f);
    }
}