using Interfaces.System;
using Models.DataTransferObjects;
using Models.Entities;

namespace Interfaces.Repositories
{
    public interface IContactsService
    {
        public Task<List<Contact>> GetAllContacts();

        public Task<PaginationDto> GetContactsWithPagination(int currentPage, int pageSize);

        public Task<Contact> GetContactById(Guid id);

        public Task<Contact> UpdateContact(Contact contact);

        public Task<Contact> CreateContact(Contact contact);

        public void DeleteContactById(Guid id);
    }
}
