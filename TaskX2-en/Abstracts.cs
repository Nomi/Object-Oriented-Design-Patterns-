
namespace PictureProduction
{
    public interface IMachine
    {
        // you can add required methods here
        void AddAcceptableColor(string col);
        void AddAcceptableShape(IShape shape);
        void AddAcceptableOperation(ITextOperation op);
        void Handle(Order order, IPicture picture);
        void Handle(Order order, Picture picture);
    }
}
