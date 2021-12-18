using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using bookapi.Repositories;
using bookapi.Models;
using AutoMapper;
using bookapi.Dtos;

namespace BookAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public  class BooksController : ControllerBase 
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;      
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BookReadDto>> GetBooks() 
        {
            var Booktmp = await _bookRepository.Get();
            return _mapper.Map<IEnumerable<BookReadDto>>(Booktmp);
            //return Booktmp;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookReadDto>> GetBooks(int id) 
        {
            var Booktmp = await _bookRepository.Get(id);
            if (Booktmp != null) {
               //return await _bookRepository.Get(id);
               return Ok(_mapper.Map<BookReadDto>(Booktmp));
            } else {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Book>>PostBooks([FromBody] Book book) 
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new {id = newBook.Id},newBook);
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book) 
        {
            if(id != book.Id) 
            {
                return BadRequest();
            }

            await _bookRepository.Update(book);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var bookToDelete = await _bookRepository.Get(id);
            if (bookToDelete == null) 
            {
                return NotFound();
            }

            await _bookRepository.Delete(bookToDelete.Id);
            return NoContent();
        }

    }
    
}