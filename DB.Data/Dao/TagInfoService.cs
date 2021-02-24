using Microsoft.EntityFrameworkCore;
using Org.Tao.DB.Data.Model;
using Org.Tao.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Org.Tao.DB.Data.Dao
{
    public class TagInfoService
    {
        private CommonDataContext _context;
        public TagInfoService() 
        {
            _context = CommonDbFactory.CreateDbContext();
        }
        public async Task<List<TagInfo>> Get()
        {
            return await _context.TagInfos.ToListAsync();
        }

        public async Task<PaginatedList<TagInfo>> GetList(int? pageNumber, int pageSize, string sortField, string sortOrder)
        {            
            var tagList = _context.TagInfos.OrderByDynamic(sortField, sortOrder.ToUpper());
            return await PaginatedList<TagInfo>.CreateAsync(tagList.AsNoTracking(), pageNumber ?? 1, pageSize);
        }

        public async Task<TagInfo> Get(int id)
        {
            var tagInfo = await _context.TagInfos.FindAsync(id);
            return tagInfo;
        }

        public async Task<TagInfo> Add(TagInfo tagInfo)
        {
            _context.TagInfos.Add(tagInfo);
            await _context.SaveChangesAsync();
            return tagInfo;
        }

        public async Task<TagInfo> Update(TagInfo tagInfo)
        {
            _context.Entry(tagInfo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return tagInfo;
        }

        public async Task<TagInfo> Delete(int id)
        {
            var result = await _context.TagInfos.FindAsync(id);
            _context.TagInfos.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
