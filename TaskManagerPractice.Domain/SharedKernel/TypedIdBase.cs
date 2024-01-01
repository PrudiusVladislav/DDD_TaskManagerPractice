namespace TaskManagerPractice.Domain.SharedKernel;

public abstract record TypedIdBase(Guid Value)
{
    public static TId New<TId>() where TId : TypedIdBase
    {
        return Create<TId>(Guid.NewGuid());
    }
    public static TId Create<TId>(Guid value) where TId : TypedIdBase
    {
        return (TId)Activator.CreateInstance(typeof(TId), value)!;
    }
}

