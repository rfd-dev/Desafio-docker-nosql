using Desafio.Application.Context;
using Desafio.Business.DomainModels;
using Desafio.Business.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Desafio.Application.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly IMongoContext _context;
        public PessoaRepository(IMongoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await _context
                        .Pessoas
                        .Find(_ => true)
                        .ToListAsync();
        }
        public Task<Pessoa> Get(long id)
        {
            FilterDefinition<Pessoa> filter = Builders<Pessoa>.Filter.Eq(m => m.Id, id);
            return _context
                    .Pessoas
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }
        public async Task Create(Pessoa pessoa)
        {
            pessoa.Id = await this.GetNextId();
            await _context.Pessoas.InsertOneAsync(pessoa);
        }
        public async Task<long> GetNextId()
        {
            return await _context.Pessoas.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}
