using Microsoft.AspNetCore.Mvc;
using APP_DATA.Models;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Website_Selling_Clothes_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        public WebsiteSellingClothes _context = new WebsiteSellingClothes();
        // GET: api/<BillController>
        [HttpGet("get-all-products")]
        public IEnumerable<Bill> Get()
        {
            return _context.bills.ToList();
        }

        // GET api/<BillController>/5
        [HttpGet("-get-bill-id")]
        public Bill Get(Guid id)
        {
            return _context.bills.Find(id);
        }

        // POST api/<BillController>
        [HttpPost]
        public bool Post([FromBody] Guid id, string productname, string discount, string user, string voucher)
        {
           
            try
            {
                id = new Guid();
                Bill bill = new Bill
                {
                    ProductName = productname,
                    Discount = discount,
                    UserID = user,
                    VoucherID = voucher,
                };
                _context.bills.Add(bill);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        // PUT api/<BillController>/5
        [HttpPut("put-bill")]
        public bool Put( [FromBody] Bill bills)
        {
            Bill billfrDB = _context.bills.Find(bills.ID);
            try
            {
                billfrDB.ProductName = bills.ProductName;
                billfrDB.Discount = bills.Discount;
                billfrDB.UserID = bills.UserID;
                billfrDB.VoucherID = bills.VoucherID;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        // DELETE api/<BillController>/5
        [HttpDelete("delete-bill")]
        public bool Delete(Guid id)
        {
            try
            {
                Bill bills = _context.bills.Find(id);
                _context.bills.Remove(bills);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
