using Desafio.Application.Context;
using Desafio.Domain.DomainModels;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Desafio.Application.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly IMongoDbContext _context;
        public PessoaRepository(IMongoDbContext context)
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
        public Task<Pessoa> Get(string cpf)
        {
            FilterDefinition<Pessoa> filter = Builders<Pessoa>.Filter.Eq(m => m.CPF, cpf);
            return _context
                    .Pessoas
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }
        public async Task Create(Pessoa pessoa)
        {
            await _context.Pessoas.InsertOneAsync(pessoa);
        }
        public async Task<long> Count()
        {
            return await _context.Pessoas.CountDocumentsAsync(new BsonDocument());
        }
    }
}
