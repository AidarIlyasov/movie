using System;
using System.Linq.Expressions;
using MovieApp.Application.Entities.MovieAggregate;

namespace MovieApp.Application.Helpers
{
    public class OrderBy<T>: IOrderBy
    {
        private readonly Expression<Func<Movie, T>> expression;
	
        public OrderBy(Expression<Func<Movie, T>> expression)
        {
            this.expression = expression;
        }

        public dynamic Expression => this.expression;
    }
}