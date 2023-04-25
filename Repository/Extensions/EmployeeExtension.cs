using Entities.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions;

public static class EmployeeExtension
{
    public static IQueryable<Employee> Filter(this IQueryable<Employee> employees, uint minAge, uint maxAge) => 
        employees.Where(e => e.Age >= minAge && e.Age <= maxAge);
    
    public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string searchTerm) 
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return employees;
        }
        
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return employees.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
    }

    public static IQueryable<Employee> Sort(this IQueryable<Employee> employees, string orderByQueryString) 
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
        {
            return employees.OrderBy(e => e.Name);
        }

        var orderQuery = QueryExtension.CreateOrderQuery<Employee>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
        {
            return employees.OrderBy(e => e.Name);
        }
            
        return employees.OrderBy(orderQuery); 
    }
}
