using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper; 
using System.Data.Entity;
using SpaceAgency.App_Start;
using SpaceAgency.Dtos;
using SpaceAgency.Models;

namespace SpaceAgency.Controllers.Api
{
    [BasicAuthentication]
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }


        // GET /api/products
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.
                Include(p => p.Mission).
                Include(m => m.Mission.MissionType).
                ToList();
        }

        // GET /api/products/id
        public IHttpActionResult GetProduct(int id)
        {
            var product = _context.Products.Include(p => p.Mission).
                Include(m => m.Mission.MissionType).
                SingleOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // GET /api/products?name=<name>
        public IHttpActionResult GetProductByName(string name)
        {
            var product = _context.Products.Include(p => p.Mission).
                Include(m => m.Mission.MissionType).
                SingleOrDefault(p => p.Mission.Name == name);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // GET /api/products?dateFrom=<yyyy-mm-dd>&dateTo=<yyyy-mm-dd>
        // 1900-01-01 are default values 
        public IHttpActionResult GetProductByDate(string dateFrom = "1900-01-01", string dateTo = "1900-01-01")
        {
            // DateTime format : yyyy-mm-dd
            DateTime dateTimeFrom = DateTime.Parse(dateFrom);
            DateTime dateTimeTo = DateTime.Parse(dateTo);


            var product = _context.Products.Include(p => p.Mission).
                Include(m => m.Mission.MissionType).
                SingleOrDefault(p => p.AcquisitionDate >= dateTimeFrom && p.AcquisitionDate <= dateTimeTo);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST /api/products
        [HttpPost]
        [BasicAuthentication(Roles = Role.ProductContentAdministrator)]
        public IHttpActionResult AddProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = Mapper.Map<ProductDto, Product>(productDto);
            _context.Products.Add(product);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + product.Id), productDto);
        }

        // PUT api/products/id
        [HttpPut]
        public void UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var productInDb = _context.Missions.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Mapper.Map(productDto, productInDb);

            _context.SaveChanges();
        }

        // DELETE api/products/id
        [HttpDelete]
        public void DeleteProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
