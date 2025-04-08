using MongoDB.Driver;
using reimbursmentServicesApi.Models;

namespace reimbursmentServicesApi.Services
{
    public class MongoService
    {
        private readonly IMongoCollection<Reimbursement> _reimbursements;

        public MongoService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("ReimbursementDB");
            _reimbursements = database.GetCollection<Reimbursement>("Reimbursements");
        }

        public async Task CreateAsync(Reimbursement reimbursement) =>
            await _reimbursements.InsertOneAsync(reimbursement);

        public async Task<List<Reimbursement>> GetAllAsync() =>
            await _reimbursements.Find(_ => true).ToListAsync();
    }
}
