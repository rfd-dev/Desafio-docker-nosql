using Desafio.Domain.DomainModels;
using MongoDB.Driver;

namespace Desafio.Application.Context
{
    public interface IMongoDbContext
    {
        IMongoCollection<Pessoa> Pessoas { get; }
    }
}