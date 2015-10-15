using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Runtime.Serialization;

using Maileon;
using Maileon.Reports;
using Maileon.Ping;
using Maileon.Contacts;
using Maileon.Contactfilters;
using Maileon.Transactions;
using Maileon.Blacklists;
using Maileon.Mailings;
using Maileon.Utils;
using Maileon.Utils.JSON;

namespace MaileonTest
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaileonConfiguration config = new MaileonConfiguration("b8e09c19-98b9-4e0d-a2f4-d160e5d85bfc", "https://api.maileon.com/1.0/");
            MaileonTransactionsService transactionsService = new MaileonTransactionsService(config);
            transactionsService.Debug = true;
            MaileonContactsService contactsService = new MaileonContactsService(config);

            Contact contact = new Contact();
            contact.Email = "balogh.viktor@maileon.hu";
            contact.Permission = Permissions.DoubleOptInPlus;
            contact.StandardFields.Add(new StandardField(StandardFieldNames.Fullname, "Balogh Viktor"));
            contact.CustomFields.Add(new CustomField("Utolsó bejelentkezés", "2015-10-02 17:05"));
            contact.CustomFields.Add(new CustomField("Telefon", "+36301234567"));

            contactsService.CreateContact(contact, SynchronizationMode.Update);
            
            Transaction transaction = new Transaction();
            transaction.Type = transactionsService.FindTransactionTypeIdByName("jelentkezesek");
            transaction.Contact = new ContactReference("balogh.viktor@maileon.hu");
            transaction.SetContent(
                "{\"tanfolyam.nev\" : \"A tanfolyam neve\",\n" +
                "\"tanfolyam.cookie\" : \"cookie\",\n" +
                "\"tanfolyam.kod\" : \"tanfolyamkod\",\n" +
                "\"kapcsolat.cim.iranyitoszam\" : \"1118\",\n" +
                "\"kapcsolat.cim.telepules\" : \"Budapest\",\n" +
                "\"kapcsolat.cim.utca\" : \"Rétköz utca 7.\",\n" +
                "\"kapcsolat.nev\" : \"Balogh Viktor\",\n" +
                "\"kapcsolat.telefon\" : \"+36301234567\",\n" +
                "\"kapcsolat.utolso.bejelentkezes\" : \"2015-10-02 17:22\",\n" +
                "\"datum\" : \"2015-10-02 17:22\"}"
            );
            transactionsService.CreateTransaction(transaction);
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}