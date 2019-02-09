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

        // GET /api/products?name=<name>&dateFrom=<yyyy-mm-dd>&dateTo=<yyyy-mm-dd>
        // 1900-01-01 and 3000-01-01 are default values 
        public IEnumerable<Product> GetProducts(string name="", string dateFrom = "1900-01-01", string dateTo = "3000-01-01")
        {

            DateTime dateTimeFrom = DateTime.Parse(dateFrom);
            DateTime dateTimeTo = DateTime.Parse(dateTo);

            if (name != "")
            {
                var products = _context.Products.
                    Include(p => p.Mission).
                    Include(m => m.Mission.MissionType).
                    Where(p => p.AcquisitionDate >= dateTimeFrom &&
                               p.AcquisitionDate <= dateTimeTo &&
                               p.Mission.Name == name).
                    ToList();

                return products;
            }
            else
            {
                var products = _context.Products.
                    Include(p => p.Mission).
                    Include(m => m.Mission.MissionType).
                    Where(p => p.AcquisitionDate >= dateTimeFrom &&
                               p.AcquisitionDate <= dateTimeTo).
                    ToList();

                return products;
            }
            
           
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
        [BasicAuthentication(Roles = Role.ProductContentAdministrator)]
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
        [BasicAuthentication(Roles = Role.ProductContentAdministrator)]
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
