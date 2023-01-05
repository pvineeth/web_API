using Abp.UI;
using Final_API.DTO.EmployeeDTO;
using Final_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookres;
        public BookController(IBookRepository _bookres)
        {
            this.bookres = _bookres;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<List<BookDTO>> Get()
        {
            var result = await bookres.GetAllBooks();
            return result;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateBookRequest req)
        {
            try
            {
                var res = await bookres.AddEmployee(req);

                return Ok("Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetID")]
        public async Task<BookDTO> GetID(int id)
        {
            try
            {
                var result = await bookres.GetByID(id);
                return result;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(UpdateBookReqvest bok)
        {
            var book = await bookres.Updatebok(bok);
            if (book != null)
            {
                return Ok("Updated Successfully");
            }
            else
            {
                return NotFound("Employee Not Found");
            }
                
        }
        [HttpDelete]
        public async Task<IActionResult>Delete(int id)
        {
            var res = await bookres.DeleteBook(id);
            if (res !=null)
            {
                return Ok("Deleted Successfully");
            }
            else
            {
                return NotFound("Employee Not Found");
            }
        }
    }
}
