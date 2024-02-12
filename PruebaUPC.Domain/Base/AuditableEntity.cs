namespace PruebaUPC.Domain.Base;

public abstract class AuditableEntity : Entity
{
    public DateTime Created { get; set; }
    public DateTime? Modified { get; set; }
}
