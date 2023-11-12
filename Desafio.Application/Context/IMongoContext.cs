using Desafio.Business.DomainModels;
using MongoDB.Driver;

namespace Desafio.Application.Context
{
    public interface IMongoContext
    {
        IMongoCollection<Pessoa> Pessoas { get; }
    }
}