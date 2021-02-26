using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Org.Tao.DB.Data.Model;
using Org.Tao.DB.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Org.Tao.DB.Data.Dao
{
    public class TagDataService
    {
        private CommonDataContext _context;
        public TagDataService()
        {
            _context = CommonDbFactory.CreateDbContext();
        }
        public async Task<List<TagData>> Get()
        {
            return await _context.TagDatas.ToListAsync();
        }

        public async Task<List<TagData>> GetByTagName(string pTerminalName, string pTagName)
        {
            return await _context.TagDatas
                .Where(td => td.TerminalName == pTerminalName && td.TagName == pTagName)
                .ToListAsync();
        }

        public async Task<PaginatedList<TagData>> GetList(int? pageNumber, int pageSize, string sortField, string sortOrder)
        {
            var tagList = _context.TagDatas.OrderByDynamic(sortField, sortOrder.ToUpper());
            return await PaginatedList<TagData>.CreateAsync(tagList.AsNoTracking(), pageNumber ?? 1, pageSize);
        }

        public async Task<TagData> Get(int id)
        {
            var tagData = await _context.TagDatas.FindAsync(id);
            return tagData;
        }

        public async Task<TagData> Add(TagData tagData)
        {
            _context.TagDatas.Add(tagData);
            await _context.SaveChangesAsync();
            return tagData;
        }

        public void BulkAdd(List<TagData> tagData)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.BulkInsert(tagData);
                transaction.Commit();            
            }
        }

        public async Task<TagData> Update(TagData tagData)
        {
            _context.Entry(tagData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return tagData;
        }

        public async Task<TagData> Delete(int id)
        {
            var result = await _context.TagDatas.FindAsync(id);
            _context.TagDatas.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
