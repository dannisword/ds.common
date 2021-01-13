using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

using DS.Common.Dto;
using DS.Common.Entities;
using DS.Repository.Infrastructure;
using DS.Services.Interface;

namespace DS.Services.Implement
{
    public class BlogService : IBlogService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitofwork;

        public BlogService(IUnitOfWork unitofwork, IMapper mapper)
        {
            this._unitofwork = unitofwork;
            this._mapper = mapper;
        }
        /*
        public async Task<IEnumerable<BlogDto>> GetAsync(BlogQueryDto blogQueryDto)
        {
            //var blogs = await this._unitofwork.BlogRepository.GetAllAsync();

            // Convert Blog to BlogDto
            //var blogDtos = this._mapper.Map<IEnumerable<BlogDto>>(blogs);

var ls = new List<BlogDto>();
            return ls;
        }
        
        public async Task<int> AddAsync(BlogDto blogDto)
        {
            // Convert BlogDto to Blog
            var blog = this._mapper.Map<Blog>(blogDto);

            this._unitofwork.BlogRepository.Add(blog);
            return await this._unitofwork.SaveChangeAsync();
        }
        public async Task<int> RemoveAsync(int blogId)
        {
            var blog = await this._unitofwork.BlogRepository.GetAsync(x => x.BlogId == blogId);

            this._unitofwork.BlogRepository.Remove(blog);
            return await this._unitofwork.SaveChangeAsync();
        }
        public async Task<int> UpdateAsync(BlogDto blogDto)
        {
            // Convert BlogDto to Blog
            var blog = this._mapper.Map<Blog>(blogDto);

            this._unitofwork.BlogRepository.Update(blog);
            return await this._unitofwork.SaveChangeAsync();
        }
        */
    }
}