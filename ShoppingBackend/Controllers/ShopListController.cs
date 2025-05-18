using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingBackend.Models;

namespace ShoppingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopListController : ControllerBase
    {
        private readonly ShopListDbContext db = new();

        //Hakee ostoslistan
        [HttpGet]
        public ActionResult GetShoplist()
        {
            var items = db.Shoplist.ToList();

            return Ok(items);
        }

        //Tavaroiden lisaaminen ostoslistalle
        [HttpPost]
        public ActionResult AddNewItem([FromBody] Shoplist item)
        {
            db.Shoplist.Add(item);
            db.SaveChanges();
            return Ok("Added new item");
        }

        //Tavaroiden poistaminen listalta
        [HttpDelete("{id}")]
        public ActionResult AddNewItem(int id)
        {
            Shoplist? item = db.Shoplist.Find(id);
            if (item!= null)
            {
                db.Shoplist.Remove(item);
                db.SaveChanges();
                return Ok("Item remove succesfully");
            }
            else
            {
                return NotFound("Product with id " + id + "not found");
            }
        }
    }
}
