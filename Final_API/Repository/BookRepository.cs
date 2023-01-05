using Final_API.Data;
using Final_API.DTO.EmployeeDTO;
using Final_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_API.Repository
{
    public class BookRepository : IBookRepository
    {
        public readonly AppilicationDBContext Context;
        public BookRepository(AppilicationDBContext _Context)
        {
            this.Context = _Context;
        }

        public async Task<bool> AddEmployee(CreateBookRequest emp)
        {
            try
            {
                Book b=new Book()
                {
                    BookName= emp.BookName,
                    Description= emp.Description,
                }; 
                Context.Books.AddAsync(b);
                await Context.SaveChangesAsync();
                return true;

            }
            catch(Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> DeleteBook(int id)
        {
            var result = Context.Books.Find(id);
            if(result !=null)
            {
                Context.Books.Remove(result);
                await Context.SaveChangesAsync();
                return true;

            }
            else
            {
                return false;
            }
        }

        public Task<List<BookDTO>> GetAllBooks()
        {
            var result=Context.Books.Select(x=>new BookDTO() { BookID=x.BookID,BookName=x.BookName,Description=x.Description}).ToListAsync();
            return result;
        }

        public async Task<BookDTO> GetByID(int id)
        {
            var result = await Context.Books.Where(x => x.BookID == id).Select(x => new BookDTO()
            {
                BookID=x.BookID,
                BookName=x.BookName,
                Description=x.Description,  

            }).FirstOrDefaultAsync();
            if(result !=null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("ID not found");
            }
        }

        public async Task<bool> Updatebok(UpdateBookReqvest book)
        {
            var result = await Context.Books.Where(x => x.BookID == book.BookID).FirstOrDefaultAsync();
            if(result !=null)
            {
                result.Description = book.Description;
                result.BookName = book.BookName;
                Context.Books.Update(result);
                await Context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new KeyNotFoundException("Employee Not Found");
            }
        }
    }
}
