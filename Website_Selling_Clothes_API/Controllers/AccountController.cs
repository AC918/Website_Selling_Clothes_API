using Microsoft.AspNetCore.Mvc;
using APP_DATA.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Website_Selling_Clothes_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public WebsiteSellingClothes _context = new WebsiteSellingClothes();
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return _context.accounts.ToList();
        }

        // GET api/<AccountController>/5
        [HttpGet("get-by-id")]
        public Account GetAccountByID(Guid id)
        {
            return _context.accounts.Find(id);
        }

        // POST api/<AccountController>
        [HttpPost("post-Account")]
        public bool Post([FromBody] Guid id, string user, string password, string accountrole)
        {
            try
            {
                id = new Guid();
                Account acc = new Account
                {
                    User = user,
                    Password = password,
                    RoleAccountID = accountrole,
                };
                _context.accounts.Add(acc);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        // PUT api/<AccountController>/5
        [HttpPut("put-acc")]
        public bool Put([FromBody] Account acc)
        {
            
            try
            {
                var account = _context.accounts.FirstOrDefault(x => x.Id == acc.Id);
                account.User = acc.User;
                account.Password = acc.Password;
                _context.accounts.Update(account);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return  false;
            }
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("delete-account")]
        public bool Delete(Guid id)
        {
            try
            {
                Account account = _context.accounts.Find(id);
                _context.accounts.Remove(account);
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
