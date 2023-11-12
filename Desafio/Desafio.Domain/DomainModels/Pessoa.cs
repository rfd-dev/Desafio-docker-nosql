using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Desafio.Domain.DomainModels
{
    public class Pessoa
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }

    }
}
