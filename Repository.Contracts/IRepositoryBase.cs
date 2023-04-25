using System.Linq.Expressions;
using System.Linq;
using System;

namespace Repository.Contracts;

/// <summary>
/// The IRepositoryBase interface defines the contract for a generic repository that provides basic CRUD operations for entities of type T.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
public interface IRepositoryBase<T> 
{
    /// <summary>
    /// Returns an IQueryable collection of all entities of type T.
    /// </summary>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entities.</param>
    /// <returns>An IQueryable collection of all entities of type T.</returns>
    IQueryable<T> FindAll(bool trackChanges);

    /// <summary>
    /// Returns an IQueryable collection of entities of type T that match the specified condition.
    /// </summary>
    /// <param name="expression">The expression that specifies the condition.</param>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entities.</param>
    /// <returns>An IQueryable collection of entities of type T that match the specified condition.</returns>
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

    /// <summary>
    /// Adds a new entity of type T to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    void Create(T entity);

    /// <summary>
    /// Updates an existing entity of type T in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    void Update(T entity);

    /// <summary>
    /// Deletes an existing entity of type T from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    void Delete(T entity); 
}
