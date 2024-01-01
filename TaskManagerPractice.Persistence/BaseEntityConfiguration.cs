using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerPractice.Domain.SharedKernel;

namespace TaskManagerPractice.Persistence;

public abstract class BaseEntityConfiguration<TId, TEntity>: IEntityTypeConfiguration<TEntity> 
    where TEntity: Entity<TId> 
    where TId: TypedIdBase
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).HasConversion(
            id => id.Value,
            value => TypedIdBase.Create<TId>(value));
        
        builder.Ignore(e => e.DomainEvents);
    }
}