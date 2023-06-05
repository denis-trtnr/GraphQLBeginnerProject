using GraphQL.Types;

namespace GraphQLAPITest.Types
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            //FloatGraphType since there is no DoubleGraphType in GraphQL
            Field<FloatGraphType>("price");
        }
    }
}
