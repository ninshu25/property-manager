using Interfaces.Repositories;
using Models.DataTransferObjects;
using Models.Entities;

namespace Services.Domain
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactsRepository;
        public ContactsService(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository ?? throw new ArgumentNullException(nameof(contactsRepository));
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _contactsRepository.GetAllContacts();
        }

        public async Task<PaginationDto> GetContactsWithPagination(int currentPage, int pageSize)
        {
            return await _contactsRepository.GetContactsWithPagination(currentPage, pageSize);
        }

        public async Task<Contact> GetContactById(Guid id)
        {
            return await _contactsRepository.GetContactById(id);
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            return await _contactsRepository.UpdateContact(contact);
        }

        public async Task<Contact> CreateContact(Contact contact)
        {
            return await _contactsRepository.CreateContact(contact);
        }

        public void DeleteContactById(Guid id)
        {
            _contactsRepository.DeleteContactById(id);
        }
    }
}
