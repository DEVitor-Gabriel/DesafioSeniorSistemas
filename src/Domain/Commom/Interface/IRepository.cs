namespace DesafioSeniorSistemas.Domain.Interface;

public interface IRepository<TEntity>
{
    Task<TEntity> Create(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task Delete(TEntity entity);
    Task<TEntity?> GetById(Guid id);
    Task<List<TEntity>> GetAll();
    
}