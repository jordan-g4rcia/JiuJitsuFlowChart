using JJFC.Web.Models;
using JJFC.Web.Models.Database;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace JJFC.Web.Repositories;

public class PositionRepository
{
    private readonly IMongoClient _mongoClient;

    public PositionRepository(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }
    
    public async Task<List<Position>> GetAll()
    {
        List<Position> positionCollection = await GetCollection().AsQueryable()
            .ToListAsync();
        return positionCollection;
    }

    public async Task<Position> GetById(string id)
    {
        var profile = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(u => u.Id == id);
        return profile;
    }
    
    public async Task<Position> Create(Position data)
    {
        data.CreatedAt = DateTime.UtcNow;
        data.UpdatedAt = DateTime.UtcNow;
        await GetCollection().InsertOneAsync(data);
        var positionList = await GetCollection().AsQueryable().ToListAsync();
        return positionList.FirstOrDefault(x => x.Id == data.Id);
    }
    
    private IMongoCollection<Position> GetCollection()
    {
        IMongoDatabase database = _mongoClient.GetDatabase("jjfc");
        IMongoCollection<Position> collection = database.GetCollection<Position>("positions");
        return collection;
    }
}