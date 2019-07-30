using GraphQL.Common.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppForGrapQL
{
    public class OwnerConsume
    {
        private readonly GraphQL.Client.GraphQLClient _client;

        public OwnerConsume(GraphQL.Client.GraphQLClient client)
        {
            _client = client;
        }

        public async Task<Owner> GetOwner(int id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query ownerQuery($ownerID: Int!) {
                  owner(id: $ownerID) {
                    id
                    name
                    age
                    location                   
                  }
                }",
                Variables = new { ownerID = id }
            };

            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<Owner>("owner");
        }
        public async Task<Owner[]> GetAllOwner()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query getallownerQuery {
                  owners {
                    id
                    name
                    age
                    location                   
                  }
                }"
            };

            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<Owner[]>("owners");
        }
    }
}
