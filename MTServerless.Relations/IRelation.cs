using MTServerless.Models.Input;

namespace MTServerless.Relations
{
    public interface IRelation
    {
        bool Validate(TableItem[] input);
    }
}
