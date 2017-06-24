using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDelegates.Model;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;

namespace WpfDelegates
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class ListContact : Window
	{
		private List<Contact> Contacts { get; set; }

		public ListContact()
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			Contacts = new List<Contact>
				           {
							   new Contact
								   {
                                        Id = "1",
										Name = "DANIEL",
										Lastname = "BARRON",
										Telephone = "72771901",
                                        Address = "CALLE AURELIO MELEAN 778",
								   },
								   new Contact
								   {
                                        Id = "2",
										Name = "EDWIN",
										Lastname = "CRESPO",
										Telephone = "60729598",
                                        Address = "AVENIDA ANICETO ARCE 864"
								   },
                                   new Contact
								   {
                                        Id = "3",
										Name = "BRAYER",
										Lastname = "VILLAGOMEZ",
										Telephone = "72464805",
                                        Address = "CALLE JUAN DE LA CRUZ 221"
								   },
				           };

			DGContacts.DataContext = Contacts;
			DGContacts.Items.Refresh();
		}

		private void BtnCerrar_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void BtnNew_Click(object sender, RoutedEventArgs e)
		{
			EditContact editor = new EditContact();
			editor.OnAccept += AddNewCoctact;
			editor.Show();
		}

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Contact selected = (Contact)DGContacts.SelectedItem;
            EditContact editor = new EditContact(selected);
            editor.OnAccept += EditContact;
            editor.Show();
        }

		private void BtnSearch_Click(object sender, RoutedEventArgs e)
		{
            DGContacts.DataContext = Contacts
                // Obtiene todos los contactos cuya propiedad Name 
                // Contenga el texto del texbnox Search
                .Where(c => c.Name.Contains(TbSearch.Text));
            DGContacts.Items.Refresh();
		}

		private void AddNewCoctact(Contact contact)
		{
			Contacts.Add(contact);
			DGContacts.DataContext = Contacts;
			DGContacts.Items.Refresh();
		}

        private void EditContact(Contact contact)
        {
            DGContacts.Items.Refresh();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Contact selected = (Contact)DGContacts.SelectedItem;
            Contacts.Remove(selected);
            DGContacts.Items.Refresh();
        }

        /*private void button1_Click(object sender, RoutedEventArgs e)
        {
            Contact cont = null;
            string path = "c://Data.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(Contact));
            StreamReader reader = new StreamReader(path);
            cont = (Contact)serializer.Deserialize(reader);
            reader.Close();

            DGContacts.Items.Add(cont);
        }*/
	}
}
