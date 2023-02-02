using AddressBookConsole.Models;
using AddressBookConsole.Services;

namespace AddressBookConsole.Tests
{
    public class AddressBookConsole_Tests
    {
        private MainMenu addressBook;
        Contact contact;


        public AddressBookConsole_Tests()
        {
            // arrange
            addressBook = new MainMenu();
            //contact = new Contact();

        }

        [Fact]
        public void Should_Add_Contact_To_List()
        {
            contact = new Contact();
            contact.FirstName = "TestFirstName 0" ;
            addressBook.contacts.Add(contact);

            contact = new Contact();
            contact.FirstName = "TestFirstName 1";
            addressBook.contacts.Add(contact);

            // assert
            Assert.Equal(2, addressBook.contacts.Count);
            Assert.Equal("TestFirstName 0", addressBook.contacts[0].FirstName);
            Assert.Equal("TestFirstName 1", addressBook.contacts[1].FirstName);
        }


        [Fact]
        public void Should_Remove_Contact_From_List()
        {
            // arrange 
            contact = new Contact();
            addressBook.contacts.Add(contact);
            contact = new Contact(); 
            addressBook.contacts.Add(contact);

            // act
            addressBook.contacts.Remove(contact);

            // assert
            Assert.Single(addressBook.contacts);
        }
    }
}
