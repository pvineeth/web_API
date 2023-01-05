using Final_API.DTO.EmployeeDTO;

namespace Final_API.Repository
{
    public interface IBookRepository
    {
        Task<List<BookDTO>> GetAllBooks();
        Task<bool> AddEmployee(CreateBookRequest emp);
        Task<BookDTO> GetByID(int id);
        Task<bool>Updatebok(UpdateBookReqvest emp); 
        Task<bool>DeleteBook(int id);
    }
}
