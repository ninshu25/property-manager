using Interfaces.Repositories;
using Interfaces.System;
using Models.DataTransferObjects;
using Models.Entities;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly IDataAccessService _dataAccessService;

        public ContactsRepository(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return _dataAccessService.Query<Contact>().Where<Contact>(contact => contact.Deleted.Equals(false)).ToList();
        }

        public async Task<PaginationDto> GetContactsWithPagination(int currentPage, int pageSize)
        {
            var query = _dataAccessService.Query<Contact>()
                                  .Where(property => !property.Deleted)
                                  .OrderBy(p => p.CreatedDate);

            int totalCount = query.Count();

            var pagedProperties = query.Skip((currentPage - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToList();

            var newt = new PaginationDto
            {
                count = totalCount,
                data = pagedProperties.Cast<object>().ToList()
            };

            return newt;
        }

        public async Task<Contact> GetContactById(Guid id)
        {
            return (Contact)_dataAccessService.Query<Contact>().Where(contact => contact.Id.Equals(id));
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            _dataAccessService.Update<Contact>(contact);
            return contact;
        }

        public async Task<Contact> CreateContact(Contact contact)
        {
            _dataAccessService.Add<Contact>(contact);
            return contact;
        }

        public void DeleteContactById(Guid id)
        {
            _dataAccessService.SoftRemoveById<Contact>(id);
        }

    }
}
