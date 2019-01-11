using System;
using System.Linq.Expressions;
using AutoMapper;

namespace WeddingRental.Configurations.Mapping
{
    public static class MapperExtension
    {
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination, TMember>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            Expression<Func<TDestination, TMember>> destinationMember)
        {
            return mappingExpression.ForMember(destinationMember, mo => mo.Ignore());
        }
    }
}
