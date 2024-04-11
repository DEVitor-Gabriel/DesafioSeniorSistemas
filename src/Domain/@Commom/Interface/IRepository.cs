namespace DesafioSeniorSistemas.Domain.Interface;

public interface IRepository<TEntity>
{
    Task<TEntity> Create(TEntity entity);
    Task<List<TEntity>> CreateByList(List<TEntity> listEntity);
    Task<TEntity> Update(TEntity entity);
    Task<List<TEntity>> UpdateByList(List<TEntity> listEntity);
    Task Delete(TEntity entity);
    Task<List<TEntity>> DeleteByList(List<TEntity> listEntity);
    Task<TEntity> GetById(Guid id);
    Task<List<TEntity>> GetAll();
    
}