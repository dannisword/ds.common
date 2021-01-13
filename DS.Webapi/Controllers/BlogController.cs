using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using DS.Common.Dto;
using DS.Common.Entities;

using DS.Repository.Db;

using DS.Services.Interface;

using DS.Webapi.Controllers.Parameters;
using DS.Webapi.Controllers.ViewModels;

namespace DS.Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BlogController : ControllerBase
    {
        private IMapper mapper;
        public IOrderService OrderService { get; private set; }
        public BlogController(IMapper mapper, IOrderService orderService)
        {
            //this.blogService = blogService;
            this.mapper = mapper;
            this.OrderService = orderService;
        }
        //private Blo
        [HttpGet]
        public IActionResult GetName()
        {
            var order1 = new Order()
            {
                //Id = 10,
                CreatedAt = DateTime.Now,
                CreatedBy = 1,
                UpdatedAt = DateTime.Now,
                UpdatedBy = 1,
                Total = 90
            };
            var detail = new OrderDetail()
            {
                ProductId = 1,
                Qty = 100,
                CreatedAt = DateTime.Now,
                CreatedBy = 1,
                UpdatedAt = DateTime.Now,
                UpdatedBy = 1
            };
            //this.OrderService.Add(order1, detail);
            //int eCode = this.OrderService.Add(order1);
            //return this.Ok(this.OrderService.GetOrder(10));
            return this.Ok(this.OrderService.Add(order1, detail));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            return Content("Delete");//this.Ok(this.OrderService.Delete(id));
        }
        /*
         [HttpPost]
         public async Task<int> AddAsync([FromBody] BlogParameter parameter)
         {
             // Convert BlogParameter to BlogQueryDto
             //var blogDto = this.mapper.Map<BlogDto>(parameter);

             //var status = await this.blogService.AddAsync(blogDto);

             //return status;

             return 1;
         }

         [HttpPatch]
         public async Task<int> UpdateAsync([FromBody] BlogParameter parameter)
         {
             // Convert BlogParameter to BlogQueryDto
             //var blogDto = this.mapper.Map<BlogDto>(parameter);

             //var status = await this.blogService.UpdateAsync(blogDto);

             //return status;

             return 1;
         }
         */
    }
}