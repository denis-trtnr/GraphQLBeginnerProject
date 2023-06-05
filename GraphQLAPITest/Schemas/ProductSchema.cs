using GraphQL.Types;
using GraphQLAPITest.Mutations;
using GraphQLAPITest.Queries;

namespace GraphQLAPITest.Schemas
{
    public class ProductSchema : Schema
    {
        public ProductSchema(ProductQuery productQuery, ProductMutation productMutation)
        {
            Query = productQuery;
            Mutation = productMutation;

        }
    }
}
